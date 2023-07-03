using System;
using System.Data;
using System.Linq;
using System.Windows;
using Курсовая__Магазин_компьютерных_комплектующих_.Form;
using Курсовая__Магазин_компьютерных_комплектующих_.Model;

namespace Курсовая__Магазин_компьютерных_комплектующих_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void PokazPass_Click(object sender, RoutedEventArgs e)
        {
            if (PokazPass.IsChecked == true)
            {
                PassSeeBox.Text = PassBox.Password;
                PassSeeBox.Visibility = Visibility.Visible;
                PassBox.Visibility = Visibility.Hidden;

            }
            else
            {
                PassBox.Password = PassSeeBox.Text;
                PassSeeBox.Visibility = Visibility.Hidden;
                PassBox.Visibility = Visibility.Visible;
            }
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text!="" && PassBox.Password!="")
            {
                var Name1 = addContext.Context.Users.Where(x => x.PasswordUser == PassBox.Password && x.LoginUser == LoginBox.Text).ToList();
                if (Name1.Count()==1)
                {
                    foreach (var roles in Name1)
                    {
                        switch (roles.RoleUser)
                        {
                            case 1:
                                MessageBox.Show($"Добро пожаловать ! \n{roles.SurNameUser} {roles.NameUser} {roles.PatronymicUser}", "Вы успешно вошли");
                                addContext.Role = Convert.ToInt32(roles.RoleUser);
                                break;
                            case 2:
                                MessageBox.Show($"Добро пожаловать ! \n{roles.SurNameUser} {roles.NameUser} {roles.PatronymicUser}", "Вы успешно вошли");
                                addContext.Role = Convert.ToInt32(roles.RoleUser);
                                break;
                            
                        }
                        addContext.idUser = Convert.ToInt32(roles.IdUser);

                    }
                    Vivod mainWindow = new Vivod();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не верный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    PassBox.Password = "";
                }
            }
        }

        private void RegisrtBTN_Click(object sender, RoutedEventArgs e)
        {
            registr registr = new registr();
            registr.Show();
            this.Close();
        }
    }
}
