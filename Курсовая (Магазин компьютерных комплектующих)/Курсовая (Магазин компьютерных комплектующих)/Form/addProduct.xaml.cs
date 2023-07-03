using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Курсовая__Магазин_компьютерных_комплектующих_.Model;
using Курсовая__Магазин_компьютерных_комплектующих_.Form;
using Курсовая__Магазин_компьютерных_комплектующих_.Form.page;
using System.Text.RegularExpressions;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Form
{
    /// <summary>
    /// Логика взаимодействия для addProduct.xaml
    /// </summary>
    public partial class addProduct : Window
    {
        public addProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg";
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;
                ImageSourceConverter imgsc = new ImageSourceConverter();
                ImageSource imageSource = (ImageSource)imgsc.ConvertFromString(filename);
                imageProduct.Source = imageSource;
                string[] fpath = filename.Split(new char[] { '\\' });
                pathBox.Text = fpath[fpath.Length - 1];
                FileInfo fileInf = new FileInfo(filename);
                fileInf.CopyTo($@"C:\Users\Emil\source\repos\Курсовая (Магазин компьютерных комплектующих)\Курсовая (Магазин компьютерных комплектующих)\image\productPhoto\{fpath[fpath.Length - 1]}", true);

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var zapType = addContext.Context.Types.Select(x => x.NameType).ToList();
            foreach (var item in zapType)
            {
                typeCombo.Items.Add(item);
            }
            var zapManufact = addContext.Context.Manufactures.Select(x => x.NameManufacture).ToList();
            foreach (var item in zapManufact)
            {
                ManufactureCombo.Items.Add(item);
            }
            var zapSupl = addContext.Context.Supplers.Select(x => x.NameSupplers).ToList();
            foreach (var item in zapSupl)
            {
                SupplCombo.Items.Add(item);
            }
        }

        private void saveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (nameProduct.Text != "" && DescriptionBox.Text != "" && typeCombo.SelectedItem != null && ManufactureCombo.SelectedItem != null && SupplCombo.SelectedItem != null && CountInBox.Text != "" && CostBox.Text != "" && pathBox.Text != "")
            {
                Product product = new Product();
                {
                    product.IdProduct = addContext.Context.Products.Max(x => Convert.ToInt32(x.IdProduct +1));
                    product.NameProduct = nameProduct.Text;
                    product.DiscriptionProduct= DescriptionBox.Text;
                    product.TypeProduct = Convert.ToInt32(typeCombo.SelectedIndex +1);
                    product.ManufactureProduct = Convert.ToInt32(ManufactureCombo.SelectedIndex)+1;
                    product.SupplProduct = Convert.ToInt32(SupplCombo.SelectedIndex +1);
                    product.CountInStockProduct = Convert.ToInt32(CountInBox.Text);
                    product.CostProduct = Convert.ToInt32(CostBox.Text);
                    product.PhotoProduct = pathBox.Text ;
                };
                addContext.Context.Products.Add(product);

                var it = addContext.Context.Products.ToList();
                foreach (var itemss in it)
                {
                    addContext.Context.Entry(itemss).Reload();
                }
               
                addContext.Context.SaveChanges();
                MessageBox.Show("Товар успешно добавлен");
                this.Close();
            }
            //else if(nameProduct.Text != "" && DescriptionBox.Text != "" && typeCombo.SelectedItem != null && ManufactureCombo.SelectedItem != null && SupplCombo.SelectedItem != null && CountInBox.Text != "" && CostBox.Text != "" && pathBox.Text == "")
            //{
            //    Product product = new Product();
            //    {
            //        product.IdProduct = addContext.Context.Products.Max(x => Convert.ToInt32(x.IdProduct +1));
            //        product.NameProduct = nameProduct.Text;
            //        product.DiscriptionProduct= DescriptionBox.Text;
            //        product.TypeProduct = typeCombo.SelectedIndex;
            //        product.ManufactureProduct = ManufactureCombo.SelectedIndex;
            //        product.SupplProduct = SupplCombo.SelectedIndex;
            //        product.CountInStockProduct = Convert.ToInt32(CountInBox.Text);
            //        product.CostProduct = Convert.ToInt32(CostBox.Text);
            //        product.PhotoProduct = null;
            //    };
            //    addContext.Context.Products.Add(product);

            //    addContext.Context.SaveChanges();
            //    MessageBox.Show("Товар успешно добавлен");
            //    this.Close();
            //}
            else
            {
                MessageBox.Show("Заполните поля");
            }

        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void CostBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

