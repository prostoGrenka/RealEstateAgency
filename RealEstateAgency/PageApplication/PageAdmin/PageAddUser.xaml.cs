using RealEstateAgency.ApplicationData;
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

namespace RealEstateAgency.PageApplication.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageAddUser.xaml
    /// </summary>
    public partial class PageAddUser : Page
    {
        public PageAddUser()
        {
            InitializeComponent();
            roleCombo.ItemsSource = ReaEntities.GetContext().Role.Select(x => x.Role1).ToList();

        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.modelOdb.User.Count(x => x.Login == txbLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с таки логином уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                User user = new User()
                {
                    Login = txbLogin.Text,
                    Password = psbPass.Password,
                    IdRole = roleCombo.SelectedIndex + 1,
                };
                AppConnect.modelOdb.User.Add(user);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("данные добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.FrmMain.Navigate(new AdminPage());

            }
            catch
            {
                MessageBox.Show("Ошибка добавления данных!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void PasswordBox_PasswordChange(object sender, RoutedEventArgs e)
        {
            if (psbPass.Password != txbPass.Text)
            {
                RegBtn.IsEnabled = false;
                psbPass.Background = Brushes.LightCoral;
                psbPass.Background = Brushes.Red;
            }
            else
            {
                RegBtn.IsEnabled = true;
                psbPass.Background = Brushes.LightGreen;
                psbPass.Background = Brushes.Green;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new PageInfoUser());
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            roleCombo.SelectedIndex = -1;
            txbLogin.Clear();
            txbLogin.Clear();
        }
    }
}
