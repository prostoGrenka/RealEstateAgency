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
using System.Xml.XPath;

namespace RealEstateAgency.PageApplication.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageInfoUser.xaml
    /// </summary>
    public partial class PageInfoUser : Page
    {
        public PageInfoUser()
        {
            InitializeComponent();
            List<User> products = AppConnect.modelOdb.User.ToList();
            var currentProduct = ReaEntities.GetContext().User.ToList();
            ListUsers.ItemsSource = currentProduct;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new AdminPage());
        }

        private void btnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new PageAddUser());
        }
        List<User> users;

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new PageEditUser());
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var selectedUsers = ListUsers.SelectedItems.Cast<User>().ToList();
            List<User> users = AppConnect.modelOdb.User.ToList();
            var userall = users;
            if (selectedUsers != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить выбранный товар?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ReaEntities.GetContext().User.RemoveRange(selectedUsers);
                        ReaEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены");
                        ListUsers.ItemsSource = ReaEntities.GetContext().Client.ToList();
                        this.users = AppConnect.modelOdb.User.ToList();

                        if (this.users.Count > 0)
                        {
                            tbCounter.Text = "Найдено " + this.users.Count + " товаров";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ListOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
