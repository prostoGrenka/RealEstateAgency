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
    /// Логика взаимодействия для PageEditUser.xaml
    /// </summary>
    public partial class PageEditUser : Page
    {
        private User _editUser = new User();
        public PageEditUser(User selectedUser)
        {

            InitializeComponent();

            if (selectedUser != null)
            {
                _editUser = selectedUser;
            }

            roleCombo.ItemsSource = ReaEntities.GetContext().Role.Select(x => x.Role1).ToList();

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(_editUser.Login))
            {
                errors.AppendLine("Введите логин");
            }
            else if (loginTbox.Text == "")
            {
                MessageBox.Show("Заполните поле пароль", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            if (passBox.Text == "")
            {
                MessageBox.Show("Заполните поле, пароля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (passRepeatBox.Password == "")
            {
                MessageBox.Show("Заполните поле павтора пароля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_editUser.Id == 0)
            {
                ReaEntities.GetContext().User.Add(_editUser);
            }
            try
            {
                ReaEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно изменены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            AppFrame.FrmMain.Navigate(new AdminPage());

        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            roleCombo.SelectedIndex = -1;
            loginTbox.Clear();
            passBox.Clear();
            passRepeatBox.Clear();
        }

        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new AdminPage());
        }
        private void PasswordBox_PasswordChange(object sender, RoutedEventArgs e)
        {
            if (passRepeatBox.Password != passBox.Text)
            {
                btnSave.IsEnabled = false;
                passBox.Background = Brushes.LightCoral;
                passRepeatBox.Background = Brushes.Red;
            }
            else
            {
                btnSave.IsEnabled = true;
                passBox.Background = Brushes.LightGreen;
                passRepeatBox.Background = Brushes.Green;
            }
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

