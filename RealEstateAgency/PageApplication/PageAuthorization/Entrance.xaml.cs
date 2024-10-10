using RealEstateAgency.ApplicationData;
using RealEstateAgency.PageApplication.PageAdmin;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealEstateAgency.PageApplication.PageAuthorization
{
    /// <summary>
    /// Логика взаимодействия для Entrance.xaml
    /// </summary>
    public partial class Entrance : Page
    {
        public Entrance()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelOdb.User.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор " + userObj.Login + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.FrmMain.Navigate(new AdminPage());
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Пользователь " + userObj.Login + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.FrmMain.Navigate(new AdminPage());
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new Registration());
        }
    }
}

