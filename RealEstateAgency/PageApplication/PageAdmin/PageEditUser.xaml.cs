﻿using RealEstateAgency.ApplicationData;
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
        public PageEditUser()
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
            if (string.IsNullOrEmpty(_editUser.Name))
            {
                errors.AppendLine("Введите название");
            }
            else if (txbLogin.Text == "")
            {
                MessageBox.Show("Введите значение 'Категория'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            if (txbName.Text == "")
            {
                MessageBox.Show("Введите значение 'Вид выпечки'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (txbLastName.Text == "")
            {
                MessageBox.Show("Введите значение 'Вид теста'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (txbLogin.Text == "")
            {
                MessageBox.Show("Введите значение 'Начинка'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (txbEmail.Text == "")
            {
                MessageBox.Show("Введите значение 'Повар'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (txbNumberPhone.Text == "")
            {
                MessageBox.Show("Введите значение 'Цена'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (txbAdress.Text == "")
            {
                MessageBox.Show("Введите значение 'Вес'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (Convert.ToString(roleCombo.ItemsSource) == "")
            {
                MessageBox.Show("Введите значение 'Вес'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
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
                BunAndBagelEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно изменены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            AppFrame.FrmMain.Navigate(new Main());

        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            roleCombo.SelectedIndex = -1;
            txbLogin.Clear();
            txbName.Clear();
            txbLastName.Clear();
            txbLogin.Clear();
            txbEmail.Clear();
            txbNumberPhone.Clear();
            txbAdress.Clear();
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

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}

