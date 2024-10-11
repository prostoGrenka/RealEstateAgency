using RealEstateAgency.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();

             List<RealtyFlat> products = AppConnect.modelOdb.RealtyFlat.ToList();
            var currentProduct = ReaEntities.GetContext().RealtyFlat.ToList();
            listProducts.ItemsSource = currentProduct;


            Downloads();
        }
        List<RealtyFlat> realtyFlats;
        public void Downloads()
        {
            realtyFlats = AppConnect.modelOdb.RealtyFlat.ToList();

            if (realtyFlats.Count > 0)
            {
                tbCounter.Text = "Найдено " + realtyFlats.Count + " товаров";
            }
            else
            {
                tbCounter.Text = "Ничего не найдено";
            }
            listProducts.ItemsSource = realtyFlats;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = listProducts.SelectedItems.Cast<RealtyFlat>().ToList();
            List<RealtyFlat> product = AppConnect.modelOdb.RealtyFlat.ToList();
            var productall = product;
            if (selectedProduct != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить выбранный товар?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    try
                    {
                        ReaEntities.GetContext().RealtyFlat.RemoveRange(selectedProduct);
                        ReaEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены");
                        listProducts.ItemsSource = ReaEntities.GetContext().RealtyFlat.ToList();
                        realtyFlats = AppConnect.modelOdb.RealtyFlat.ToList();

                        if (realtyFlats.Count > 0)
                        {
                            tbCounter.Text = "Найдено " + realtyFlats.Count + " товаров";
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
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new PageAddData());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            findGoods();
        }
        RealtyFlat[] findGoods()
        {
            List<RealtyFlat> product = AppConnect.modelOdb.RealtyFlat.ToList();
            var productall = product;

            if (product.Count > 0)
            {
                tbCounter.Text = "Найдено " + product.Count + " товаров";
            }
            else
            {
                tbCounter.Text = "Ничего не найдено";
            }
            listProducts.ItemsSource = product;
            return product.ToArray();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new PageEditData((sender as Button).DataContext as RealtyFlat));
        }

        private void listProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnInfoUser_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new PageInfoUser());
        }

        private void filtreForSearch_Click(object sender, RoutedEventArgs e)
        {
            FiltreWindow windowForGetFiltre = new FiltreWindow();
            windowForGetFiltre.ShowDialog();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
