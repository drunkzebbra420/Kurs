using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Курсовая__Магазин_компьютерных_комплектующих_.Model;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Form.page
{
    /// <summary>
    /// Логика взаимодействия для mainProduct.xaml
    /// </summary>
    public partial class mainProduct : Page
    {
        public mainProduct()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            var it = addContext.Context.Products.ToList();
            foreach (var itemss in it)
            {
                addContext.Context.Entry(itemss).Reload();
            }
            Sortcombo.Items.Add("-");
            Sortcombo.Items.Add("По возрастанию");
            Sortcombo.Items.Add("По убыванию");

            Filtrcombo.Items.Add("Все");
            var zapFiltr = addContext.Context.Types.Select(x => x.NameType).ToList();
            foreach (var item in zapFiltr)
            {
                Filtrcombo.Items.Add(item);
            }

            if (addContext.Role == 1)
            {
                addProduct.Visibility = Visibility.Collapsed;
                ComtextMenu.Visibility = Visibility.Collapsed;
            }
            else
            {
                ComtextMenu.Visibility = Visibility.Visible;
                addProduct.Visibility = Visibility.Visible;
            }

            if(addContext.Role == 2)
            {
                RoleUser.Visibility = Visibility.Visible;
            }
           

            List.ItemsSource = null;
            List.ItemsSource = addContext.Context.Products.ToList();
        }


        void lisISenpty()
        {
            if (List.Items.Count == 0)
            {
                ListEmpty.Visibility = Visibility.Visible;
                List.Visibility = Visibility.Hidden;
            }
            else
            {
                ListEmpty.Visibility = Visibility.Collapsed;
                List.Visibility = Visibility.Visible;
            }
        }
        void SearchSortFiltr()
        {
            List.ItemsSource = null;
            var query = addContext.Context.Products.ToList();
            foreach (var item in query)
            {
                addContext.Context.Entry(item).Reload();
            }
            if (Filtrcombo.SelectedValue != null)
            {
                switch (Filtrcombo.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        query = query.Where(x => Convert.ToInt32(x.TypeProduct) == Convert.ToInt32(Filtrcombo.SelectedIndex)).ToList();
                        break;
                }
            }
            if (Sortcombo.SelectedValue!=null)
            {
                switch (Sortcombo.SelectedIndex)
                {
                    case 0:
                        query = query.ToList();
                        break;
                    case 1:
                        query = query.OrderBy(x => x.CostProduct).ToList();
                        break;
                    case 2:
                        query = query.OrderByDescending(x => x.CostProduct).ToList();
                        break;
                }
            }
            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                query = query.Where(x => x.NameProduct.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            }



            List.ItemsSource = query;
            //CountStrok.Text = List.Items.Count.ToString();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchSortFiltr();
            lisISenpty();
        }

        private void Sortcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchSortFiltr();
        }

        private void Filtrcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchSortFiltr();
            lisISenpty();
        }

        private void infoBTN_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedItem != null)
            {
                var item = (dynamic)List.SelectedItem;
                this.NavigationService.Navigate(new infProd(item));
                //MessageBox.Show(item.Images);
                //productInfo.Navigate(pageUr1);
                //infoPeoduct.Show();
            }
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            Vivod vivod = new Vivod();
            addProduct adddd = new addProduct();
            adddd.Show();
            vivod.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedValue != null)
            {
                var items = (dynamic)List.SelectedItem;
                int Article = items.IdProduct;
                if (MessageBox.Show("Вы точно хотите удалить ", "Удаление клиента", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var itemsDelet = addContext.Context.Products.FirstOrDefault(x => x.IdProduct == Article);
                    addContext.Context.Products.Remove(itemsDelet);
                    addContext.Context.SaveChanges();
                    MessageBox.Show("Товар удалён");
                    var it = addContext.Context.Products.ToList();
                    foreach (var itemss in it)
                    {
                        addContext.Context.Entry(itemss).Reload();
                    }
                    List.ItemsSource = null;
                    List.ItemsSource = addContext.Context.Products.ToList();
                }
            }
        }


        private void seeBasket_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new basket());

        }

        private void trashBTN_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedValue != null)
            {
                var items = (dynamic)List.SelectedItem;
                int Article = items.IdProduct;
                if (addContext.baskets.Where(x => x.Id==Article).ToList().Count==0)
                {

                    addContext.baskets.Add(new Basket()
                    {
                        Id = items.IdProduct,
                        Name= items.NameProduct,
                        CostProduct= items.CostProduct,
                        PhotoProduct = items.PhotoProduct,
                        Count = 1

                    });
                    MessageBox.Show("Товар добавлен в корзину");
                }
                else
                {
                    MessageBox.Show("Товар уже есть в корзине", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window wd = Window.GetWindow(this);
            wd.Close();

        }

    }
}
