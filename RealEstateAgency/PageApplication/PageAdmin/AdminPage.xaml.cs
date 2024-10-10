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
        List<RealtyFlat> productBunAndBagel;
        public void Downloads()
        {
            productBunAndBagel = AppConnect.modelOdb.RealtyFlat.ToList();

            if (productBunAndBagel.Count > 0)
            {
                tbCounter.Text = "Найдено " + productBunAndBagel.Count + " товаров";
            }
            else
            {
                tbCounter.Text = "Ничего не найдено";
            }
            listProducts.ItemsSource = productBunAndBagel;
            //comboSort.Items.Add("По вохврастанию товаров на складе");
            //comboSort.Items.Add("По уменьшению товаров на складе");
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
                        productBunAndBagel = AppConnect.modelOdb.RealtyFlat.ToList();

                        if (productBunAndBagel.Count > 0)
                        {
                            tbCounter.Text = "Найдено " + productBunAndBagel.Count + " товаров";
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
            //if (TBoxSearch != null)
            //{
            //    product = product.Where(x => x.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            //}
            //if (comboSort.SelectedIndex > 0)
            //{
            //    switch (comboSort.SelectedIndex)
            //    {
            //        case 0:
            //            product = product.OrderBy(x => x.Quantity).ToList<RealtyFlat>();
            //            break;
            //        case 1:
            //            product = product.OrderByDescending(x => x.Quantity).ToList<RealtyFlat>();
            //            break;
            //    }
            //}
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
    }
}
