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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.modelOdb.User.Count(x => x.Login == loginTbox.Text) > 0)
            {
                MessageBox.Show("Пользователь с таки логином уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                User user = new User()
                {
                    Login = loginTbox.Text,
                    Password = passRepeatBox.Password,
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
            if (passRepeatBox.Password != passBox.Text)
            {
                btnAdd.IsEnabled = false;
                passBox.Background = Brushes.LightCoral;
                passRepeatBox.Background = Brushes.Red;
            }
            else
            {
                btnAdd.IsEnabled = true;
                passBox.Background = Brushes.LightGreen;
                passRepeatBox.Background = Brushes.Green;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new PageInfoUser());
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            roleCombo.SelectedIndex = -1;
            loginTbox.Clear();
            passBox.Clear();
            passRepeatBox.Clear();
        }

        private void passBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
