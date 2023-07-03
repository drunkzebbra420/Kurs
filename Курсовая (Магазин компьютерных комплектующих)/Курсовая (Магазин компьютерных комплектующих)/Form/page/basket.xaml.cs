using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Курсовая__Магазин_компьютерных_комплектующих_.Model;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Form.page
{
    /// <summary>
    /// Логика взаимодействия для basket.xaml
    /// </summary>
    public partial class basket : Page
    {
        public basket()
        {
            InitializeComponent();
            var zapFiltr = addContext.Context.PickapPoints.FromSqlRaw("select * from pickap_point ;");
            foreach (var item in zapFiltr)
            {
                string stroka = $"{item.SityPickapPoint}, {item.StreetPickapPoint} {item.HousePickapPoint}";
                AdresDeliveri.Items.Add(stroka);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SetValuePage();
        }

        public void SetValuePage()
        {
            ListBasket.ItemsSource = addContext.baskets.ToList();

            int totalCount = addContext.baskets.Sum(b => b.Count);
            CountProduct.Text = totalCount.ToString();

            decimal? totalCost = addContext.baskets.Sum(b => b.CostProduct * b.Count);
            SumText.Text = totalCost.ToString();
        }

        private void ZakzButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdresDeliveri.SelectedValue != null)
            {
                if (ListBasket.Items.Count > 0)
                {
                    int index = 0;
                    Order order = new Order();
                    {
                        order.IdOrder = addContext.Context.Orders.Max(x => Convert.ToInt32(x.IdOrder +1));
                        order.UserOrder = addContext.idUser;
                        order.DateOrder = DateTime.Now;
                        order.PickapPointOrder = Convert.ToInt32(AdresDeliveri.SelectedIndex+1);
                        order.CodeToGet = addContext.Context.Orders.Max(x => Convert.ToInt32(x.CodeToGet+1));
                    };
                    addContext.Context.Orders.Add(order);
                    addContext.Context.SaveChanges();

                    int ore = addContext.Context.Orders.Max(x => Convert.ToInt32(x.IdOrder));
                    bool orderPlaced = true;
                    for (int i = 0; i < ListBasket.Items.Count; i++)
                    {
                        Orderproduct orderproduct = new Orderproduct();
                        {
                            orderproduct.IdOrder = ore;
                            orderproduct.IdProduct = addContext.baskets[i].Id;
                            orderproduct.Count = addContext.baskets[i].Count;
                        }
                        int? sdf = orderproduct.Count = addContext.baskets[i].Count;

                        var productsToUpdate = addContext.Context.Products.Where(p => p.IdProduct == orderproduct.IdProduct);

                        var productToUpdate = addContext.Context.Products.FirstOrDefault(p => p.IdProduct == orderproduct.IdProduct);
                        if (productToUpdate != null && productToUpdate.CountInStockProduct >= orderproduct.Count)
                        {
                            productToUpdate.CountInStockProduct -= orderproduct.Count;

                            addContext.Context.Orderproducts.Add(orderproduct);
                            addContext.Context.SaveChanges();

                        }
                        else
                        {
                            orderPlaced = false;
                            MessageBox.Show($"Ошибка оформления заказа: Недостаточно товаров в наличии для {productToUpdate.NameProduct}.");
                            break;
                        }
                    }
                    if (orderPlaced)
                    {
                        MessageBox.Show("Заказ оформлен");
                        GenerateChek();
                        addContext.baskets.Clear();
                        ListBasket.ItemsSource = null;
                        SumText.Text = "0";
                        CountProduct.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show("Выберите товар");
                }
            }
            else
            {
                MessageBox.Show("Выберите пункт выдачи");
            }
        }

        public void GenerateChek()
        {
            decimal totalCost = Convert.ToDecimal(SumText.Text);
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            int rowHeight = 20;
            int tableWidth = (int)page.Width.Point - 120;
            XRect rect;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12);
            int startY = 50;
            {
                gfx.DrawString($"Номер заказа: {addContext.Context.Orders.Max(x => Convert.ToInt32(x.IdOrder))}", font, XBrushes.Black, new XPoint(10, startY));
                //gfx.DrawString("OOO PC Store", font, XBrushes.Black, new XPoint(10, startY));
                startY+=20;
                gfx.DrawString("Добро пожаловать", font, XBrushes.Black, new XPoint(10, startY));
                startY+=20;
                gfx.DrawString($"Дата: {DateTime.Now.ToShortDateString()}", font, XBrushes.Black, new XPoint(10, startY));


                startY+=20;
                gfx.DrawString("************************************************", font, XBrushes.Black, new XPoint(10, startY));
                startY += 20;

                foreach (var item in addContext.baskets)
                {
                    gfx.DrawString($"Наименование товара: {item.Name}", font, XBrushes.Black, new XPoint(10, startY));
                    gfx.DrawString($"  кол-во товара: {item.Count}          = {item.CostProduct * item.Count} ₽", font, XBrushes.Black, new XPoint(10, startY + 20));
                    gfx.DrawString($"Цена за одну штуку: {item.CostProduct} ₽", font, XBrushes.Black, new XPoint(250, startY + 20));

                    startY += 40;
                }
                gfx.DrawString("************************************************", font, XBrushes.Black, new XPoint(10, startY));
                startY += 20;

                gfx.DrawString("ИТОГ : ", font, XBrushes.Black, new XPoint(10, startY));
                gfx.DrawString($"     {totalCost} ₽", font, XBrushes.Black, new XPoint(10, startY + 20));
                startY += 40;

                gfx.DrawString("************************************************", font, XBrushes.Black, new XPoint(10, startY));
                startY += 20;

                gfx.DrawString("Адрес пункта выдачи: ", font, XBrushes.Black, new XPoint(10, startY));
                gfx.DrawString($"{AdresDeliveri.SelectedValue}", font, XBrushes.Black, new XPoint(150, startY));

                startY += 20;

                gfx.DrawString("Код для получения: ", font, XBrushes.Black, new XPoint(10, startY));
                gfx.DrawString($"{addContext.Context.Orders.Max(x => x.CodeToGet)}", font, XBrushes.Black, new XPoint(150, startY));

                string filePath = "chek.pdf";
                document.Save(filePath);
                document.Close();
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }


            private void MenuItem_Click(object sender, RoutedEventArgs e)
            {
                if (ListBasket.SelectedValue != null)
                {
                    var items = (dynamic)ListBasket.SelectedItem;
                    int Article = items.Id;
                    if (MessageBox.Show("Вы точно хотите удалить ", "Удаление товара из корзины", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var itemsDelet = addContext.baskets.FirstOrDefault(x => x.Id == Article);
                        addContext.baskets.Remove(itemsDelet);
                        addContext.Context.SaveChanges();
                        MessageBox.Show("Товар удалён из корзины");
                        var it = addContext.Context.Products.ToList();
                        foreach (var itemss in it)
                        {
                            addContext.Context.Entry(itemss).Reload();
                        }
                        ListBasket.ItemsSource = null;
                        ListBasket.ItemsSource = addContext.baskets.ToList();
                        CountProduct.Text = null;
                        SumText.Text = "0";

                        CountProduct.Text = ListBasket.Items.Count.ToString();
                    }
                }
            }

            private void minus_Click(object sender, RoutedEventArgs e)
            {

                if (((Basket)ListBasket.SelectedItem).Count >= 2)
                {
                    ((Basket)ListBasket.SelectedItem).Count -= 1;

                    if (((Basket)ListBasket.SelectedItem).Count >= 1)
                    {
                        SetValuePage();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Количество не может быть меньше 1!");
                }
            }
            private void Plus_Click(object sender, RoutedEventArgs e)
            {
                if (ListBasket.SelectedValue!=null)
                {
                    ((Basket)ListBasket.SelectedItem).Count +=1;
                    SetValuePage();
                }

            }
        }
    }


