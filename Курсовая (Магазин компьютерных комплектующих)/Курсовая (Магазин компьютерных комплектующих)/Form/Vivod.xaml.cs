using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Курсовая__Магазин_компьютерных_комплектующих_.Model;
using Курсовая__Магазин_компьютерных_комплектующих_.Form.page;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Form
{
    /// <summary>
    /// Логика взаимодействия для Vivod.xaml
    /// </summary>
    public partial class Vivod : Window
    {
        public Vivod()
        {
            InitializeComponent();
           
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            var it = addContext.Context.Products.ToList();
            foreach (var itemss in it)
            {
                addContext.Context.Entry(itemss).Reload();
            }
            mainProduct mainProduct = new mainProduct();
            mainProduct.List.ItemsSource = addContext.Context.Products.ToList();

        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Sortcombo.Items.Add("-");
        //    Sortcombo.Items.Add("По возрастанию");
        //    Sortcombo.Items.Add("По убыванию");

        //    Filtrcombo.Items.Add("Все");
        //    var zapFiltr = addContext.Context.Types.Select(x => x.NameType).ToList();
        //    foreach(var item in zapFiltr)
        //    {
        //        Filtrcombo.Items.Add(item);
        //    }

        //    List.ItemsSource = addContext.Context.Products.ToList();
        //}
        //void lisISenpty()
        //{
        //    if (List.Items.Count == 0)
        //    {
        //        ListEmpty.Visibility = Visibility.Visible;
        //        List.Visibility = Visibility.Hidden;
        //    }
        //    else
        //    {
        //        ListEmpty.Visibility = Visibility.Collapsed;
        //        List.Visibility = Visibility.Visible;
        //    }
        //}
        //void SearchSortFiltr()
        //{
        //    List.ItemsSource = null;
        //    var query = addContext.Context.Products.ToList();
        //    foreach (var item in query)
        //    {
        //        addContext.Context.Entry(item).Reload();
        //    }
        //    if (Filtrcombo.SelectedValue != null)
        //    {
        //        switch (Filtrcombo.SelectedIndex)
        //        {
        //            case 0:
        //                break;
        //            case 1:
        //            case 2:
        //            case 3:
        //            case 4:
        //            case 5:
        //            case 6:
        //            case 7:
        //                query = query.Where(x => Convert.ToInt32(x.TypeProduct) == Convert.ToInt32(Filtrcombo.SelectedIndex)).ToList();
        //                break;
        //        }
        //    }
        //    if (Sortcombo.SelectedValue!=null)
        //    {
        //        switch (Sortcombo.SelectedIndex)
        //        {
        //            case 0:
        //                query = query.ToList();
        //                break;
        //            case 1:
        //                query = query.OrderBy(x => x.CostProduct).ToList();
        //                break;
        //            case 2:
        //                query = query.OrderByDescending(x => x.CostProduct).ToList();
        //                break;
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(SearchBox.Text))
        //    {
        //        query = query.Where(x => x.NameProduct.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
        //    }



        //    List.ItemsSource = query;
        //    //CountStrok.Text = List.Items.Count.ToString();
        //}

        //private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    SearchSortFiltr();
        //    lisISenpty();
        //}

        //private void Sortcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SearchSortFiltr();
        //}

        //private void Filtrcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SearchSortFiltr();
        //    lisISenpty();
        //}

        //private void infoBTN_Click(object sender, RoutedEventArgs e)
        //{
        //    string path = "/Form/page/infProd.xaml";
        //    Uri pageUr1 = new Uri(path, UriKind.Relative);


        //    if(List.SelectedItem != null)
        //    {

        //        var items = (dynamic)List.SelectedItem;
        //        infoPeoduct infoPeoduct = new infoPeoduct();
        //        infoPeoduct.TitleBlock.Text = items.NameProduct;
        //        productInfo.Navigate(pageUr1);
        //        //infoPeoduct.Show();


        //    }
    }
    }

