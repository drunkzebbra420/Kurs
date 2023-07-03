using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Курсовая__Магазин_компьютерных_комплектующих_.Model;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Form
{
    /// <summary>
    /// Логика взаимодействия для registr.xaml
    /// </summary>
    public partial class registr : Window
    {
        public registr()
        {
            InitializeComponent();
            addContext.Context.Users.ToList().ForEach(x => addContext.Context.Entry(x).Reload());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            {
                Regex regex = new Regex("[^а-яА-Яa-zA-Z]+");
                e.Handled = regex.IsMatch(e.Text);
            }
        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (PokazPass.IsChecked == true)
            {
                SeePassBox.Text = PassBox.Password;
                SeePassBox.Visibility = Visibility.Visible;
                PassBox.Visibility = Visibility.Hidden;
            }
            else
            {
                PassBox.Password = SeePassBox.Text;
                SeePassBox.Visibility = Visibility.Hidden;
                PassBox.Visibility = Visibility.Visible;
            }
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {

            if (SurnameBox.Text != "" & NameBox.Text != "" & PatronymicBox.Text != "" & LoginBox.Text!= null & PassBox.Password != "" & PhoneNumber.Text != "")
            {
                User user = new User();
                {
                    user.IdUser = addContext.Context.Users.Max(x => Convert.ToInt32(x.IdUser +1));
                    user.SurNameUser = SurnameBox.Text;
                    user.NameUser= NameBox.Text;
                    user.PatronymicUser = PatronymicBox.Text;
                    user.LoginUser = LoginBox.Text;
                    user.PasswordUser = PassBox.Password;
                    user.NumTelefonUser = PhoneNumber.Text;
                    user.RoleUser = 1;
                };
                addContext.Context.Users.Add(user);
                try
                {
                    addContext.Context.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрированы");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка" , MessageBoxButton.OK, MessageBoxImage.Error);
                    addContext.Context.Users.Remove(user);
                    user = null;
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

