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
    /// Логика взаимодействия для PageAddData.xaml
    /// </summary>
    public partial class PageAddData : Page
    {
        private RealtyFlat _editgoods = new RealtyFlat();
        public PageAddData( )
        {
            InitializeComponent();

            DataContext = _editgoods;

            destinyCombo.ItemsSource = ReaEntities.GetContext().Destiny.Select(x => x.Destiny1).ToList();
            quantityRoomCombo.ItemsSource = ReaEntities.GetContext().QuantityRoom.Select(x => x.QuantityRoom1).ToList();
            floorCombo.ItemsSource = ReaEntities.GetContext().Floor.Select(x => x.Floor1).ToList();
            clientCombo.ItemsSource = ReaEntities.GetContext().Client.Select(x => x.NumberContract).ToList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int destiny = destinyCombo.SelectedIndex + 1;
                int quantityRoom = quantityRoomCombo.SelectedIndex + 1;
                int floor = floorCombo.SelectedIndex + 1;
                int orderClient = clientCombo.SelectedIndex + 1;
                string adress = adressBox.Text;
                int price = Convert.ToInt32(priceBox.Text);
                int squareFlat = Convert.ToInt32(squareFlatBox.Text);
                string photo = photoBox.Text;

                try
                {

                    RealtyFlat goods = new RealtyFlat()
                    {
                        IdDestiny = destiny,
                        IdQuantityRoom = quantityRoom,
                        IdFloor = floor,
                        IdClient = orderClient,
                        SquareFlat = squareFlat,
                        Adress = adress,
                        Price = price
                    };
                    AppConnect.modelOdb.RealtyFlat.Add(goods);
                    AppConnect.modelOdb.SaveChanges();
                    MessageBox.Show("данные добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    AppFrame.FrmMain.Navigate(new AdminPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                AppConnect.modelOdb.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных! Все поля должны быть заполнены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AppConnect.modelOdb.SaveChanges();

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrmMain.Navigate(new AdminPage());
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            destinyCombo.SelectedIndex = -1;
            quantityRoomCombo.SelectedIndex = -1;
            floorCombo.SelectedIndex = -1;
            clientCombo.SelectedIndex = -1;
            priceBox.Clear();
            squareFlatBox.Clear();
            adressBox.Clear();
            photoBox.Clear();
        }

        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }
    }
}
