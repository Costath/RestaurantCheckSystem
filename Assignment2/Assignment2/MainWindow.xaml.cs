﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<MenuItem> Beverages = new ObservableCollection<MenuItem>();
        private ObservableCollection<MenuItem> Appetizers = new ObservableCollection<MenuItem>();
        private ObservableCollection<MenuItem> MainCourses = new ObservableCollection<MenuItem>();
        private ObservableCollection<MenuItem> Desserts = new ObservableCollection<MenuItem>();
        private ObservableCollection<OrderedFood> Check = new ObservableCollection<OrderedFood>();
        private Menu menu = new Menu { };
        private decimal Subtotal = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadCollectionData();

            BeveragesComboBox.ItemsSource = Beverages;
            AppetizersComboBox.ItemsSource = Appetizers;
            MainCoursesComboBox.ItemsSource = MainCourses;
            DessertsComboBox.ItemsSource = Desserts;
            CheckDataGrid.ItemsSource = Check;
        }

        private void LoadCollectionData()
        {
            foreach (MenuItem item in menu.Beverages)
            {
                Beverages.Add(item);
            }
            foreach (MenuItem item in menu.Appetizers)
            {
                Appetizers.Add(item);
            }
            foreach (MenuItem item in menu.MainCourses)
            {
                MainCourses.Add(item);
            }
            foreach (MenuItem item in menu.Desserts)
            {
                Desserts.Add(item);
            }
        }

        private void BeveragesComboBox_DropDownClosed(object sender, EventArgs e)
        {
            MenuItem selection = menu.Beverages.ElementAt(BeveragesComboBox.SelectedIndex);
            bool itemPresent = false;

            foreach (OrderedFood Row in Check)
            {
                if (Row.Name == selection.Name)
                {
                    Row.Quantity++;
                    CheckDataGrid.Items.Refresh();
                    itemPresent = true;
                }
            }

            if (!itemPresent)
            {
                Check.Add(new OrderedFood
                {
                    Name = selection.Name,
                    Quantity = 1,
                    Price = selection.Price
                });
            }

            Subtotal += selection.Price;
        }

        private void AppetizersComboBox_DropDownClosed(object sender, EventArgs e)
        {
            MenuItem selection = menu.Appetizers.ElementAt(AppetizersComboBox.SelectedIndex);
            bool itemPresent = false;

            foreach (OrderedFood Row in Check)
            {
                if (Row.Name == selection.Name)
                {
                    Row.Quantity++;
                    CheckDataGrid.Items.Refresh();
                    itemPresent = true;
                }
            }

            if (!itemPresent)
            {
                Check.Add(new OrderedFood
                {
                    Name = selection.Name,
                    Quantity = 1,
                    Price = selection.Price
                });
            }

            Subtotal += selection.Price;
        }

        private void MainCoursesComboBox_DropDownClosed(object sender, EventArgs e)
        {
            MenuItem selection = menu.MainCourses.ElementAt(MainCoursesComboBox.SelectedIndex);
            bool itemPresent = false;

            foreach (OrderedFood Row in Check)
            {
                if (Row.Name == selection.Name)
                {
                    Row.Quantity++;
                    CheckDataGrid.Items.Refresh();
                    itemPresent = true;
                }
            }

            if (!itemPresent)
            {
                Check.Add(new OrderedFood
                {
                    Name = selection.Name,
                    Quantity = 1,
                    Price = selection.Price
                });
            }

            Subtotal += selection.Price;
        }

        private void DessertsComboBox_DropDownClosed(object sender, EventArgs e)
        {
            MenuItem selection = menu.Desserts.ElementAt(DessertsComboBox.SelectedIndex);
            bool itemPresent = false;

            foreach (OrderedFood Row in Check)
            {
                if (Row.Name == selection.Name)
                {
                    Row.Quantity++;
                    CheckDataGrid.Items.Refresh();
                    itemPresent = true;
                }
            }

            if (!itemPresent)
            {
                Check.Add(new OrderedFood
                {
                    Name = selection.Name,
                    Quantity = 1,
                    Price = selection.Price
                });
            }

            Subtotal += selection.Price;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            foreach (var column in CheckDataGrid.Columns)
            {
                column.IsReadOnly = true;
            }
            
            CheckDataGrid.Columns.Where(x => x.Header.ToString() == "Quantity").FirstOrDefault().IsReadOnly = false;
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Check.Clear();
            BeveragesComboBox.SelectedIndex = -1;
            AppetizersComboBox.SelectedIndex = -1;
            MainCoursesComboBox.SelectedIndex = -1;
            DessertsComboBox.SelectedIndex = -1;

            Subtotal = 0;
        }

        private void RemoveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckDataGrid.SelectedIndex != -1)
            {
                OrderedFood element = Check.ElementAt(CheckDataGrid.SelectedIndex);
                Subtotal -= element.Price * element.Quantity;
                Check.RemoveAt(CheckDataGrid.SelectedIndex);
            }

        }

    }
}