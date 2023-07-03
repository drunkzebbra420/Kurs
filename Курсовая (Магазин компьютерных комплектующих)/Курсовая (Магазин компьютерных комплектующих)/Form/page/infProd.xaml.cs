using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Курсовая__Магазин_компьютерных_комплектующих_.Model;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Form.page
{
    /// <summary>
    /// Логика взаимодействия для infProd.xaml
    /// </summary>
    public partial class infProd : Page
    {
        Product title;
        public int id = 0;
        public string Name = "";
        public decimal? cost = 0;
        public string photo = "";
        public string ImageBasket = "";
        public infProd(Product title)
        {
            InitializeComponent();
            var it = addContext.Context.Products.ToList();
            foreach (var itemss in it)
            {
                addContext.Context.Entry(itemss).Reload();
            }
            id = title.IdProduct;
            Name = title.NameProduct;
            cost = title.CostProduct;
            photo = title.Image;
            ImageBasket = title.PhotoProduct;
            NameProduct.Text = title.NameProduct;
            DiscriptionProduct.Text = title.DiscriptionProduct;
            ManufactureProduct.Text = title.ManufactureProductNavigation.NameManufacture;
            SuppleProduct.Text = title.SupplProductNavigation.NameSupplers;
            CategoriProduct.Text = title.TypeProductNavigation.NameType;
            CostProduct.Text = title.CostProduct.ToString();
            CountProduct.Text = title.CountInStockProduct.ToString();
            if (title.Image!=null)
            {
                imageTests.ImageSource= new BitmapImage(new Uri(photo, UriKind.Relative));
            }
            else
            {
                imageTests.ImageSource= new BitmapImage(new Uri(@"\image\productPhoto\NullVlaue\NullValueImage.png", UriKind.Relative));
            }
        }

        private void trashBTN_Click(object sender, RoutedEventArgs e)
        {
            
            if (addContext.baskets.Where(x => x.Id == id).ToList().Count==0)
            {

                addContext.baskets.Add(new Basket()
                {
                    Id = id,
                    Name = Name,
                    CostProduct = cost,
                    PhotoProduct = ImageBasket,
                    Count = 1
                }) ;
                MessageBox.Show("Товар добавлен в корзину");
            }
            else
            {
                MessageBox.Show("Товар уже есть в корзине");
            }
        }
    }
}
