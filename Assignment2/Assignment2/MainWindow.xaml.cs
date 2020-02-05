using System;
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
            MenuItem selection;

            try
            {
                selection = menu.Beverages.ElementAt(BeveragesComboBox.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

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

            UpdateMonetaryTextBoxes();
        }

        private void AppetizersComboBox_DropDownClosed(object sender, EventArgs e)
        {
            MenuItem selection;

            try
            {
                selection = menu.Appetizers.ElementAt(AppetizersComboBox.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

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

            UpdateMonetaryTextBoxes();
        }

        private void MainCoursesComboBox_DropDownClosed(object sender, EventArgs e)
        {
            MenuItem selection;

            try
            {
                selection = menu.MainCourses.ElementAt(MainCoursesComboBox.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

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

            UpdateMonetaryTextBoxes();
        }

        private void DessertsComboBox_DropDownClosed(object sender, EventArgs e)
        {
            MenuItem selection;

            try
            {
                 selection = menu.Desserts.ElementAt(DessertsComboBox.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

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

            UpdateMonetaryTextBoxes();
        }

        private void MainAppWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var column in CheckDataGrid.Columns)
            {
                column.IsReadOnly = true;
            }
            
            CheckDataGrid.Columns.Where(x => x.Header.ToString() == "Quantity").FirstOrDefault().IsReadOnly = false;

            SubTotalTextBox.Text = (0).ToString("c");
            TaxTextBox.Text = (0).ToString("c");
            TotalTextBox.Text = (0).ToString("c");
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Check.Clear();
            BeveragesComboBox.SelectedIndex = -1;
            AppetizersComboBox.SelectedIndex = -1;
            MainCoursesComboBox.SelectedIndex = -1;
            DessertsComboBox.SelectedIndex = -1;

            UpdateMonetaryTextBoxes();
        }

        private void RemoveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckDataGrid.SelectedIndex != -1)
                {
                    OrderedFood element = Check.ElementAt(CheckDataGrid.SelectedIndex);
                    Subtotal -= element.Price * element.Quantity;
                    Check.RemoveAt(CheckDataGrid.SelectedIndex);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            UpdateMonetaryTextBoxes();
        }

        private void CheckDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMonetaryTextBoxes();
        }

        private void UpdateMonetaryTextBoxes()
        {
            Subtotal = 0;

            foreach (var row in Check)
            {
                Subtotal += row.Price * row.Quantity;
            }

            SubTotalTextBox.Text = (Subtotal).ToString("c");
            TaxTextBox.Text = (Subtotal * 0.13m).ToString("c");
            TotalTextBox.Text = (Subtotal * 1.13m).ToString("c");
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument doc = CreateFlowDocument();
            IDocumentPaginatorSource idpSource = doc;
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Printing the Check.");
        }

        private FlowDocument CreateFlowDocument()
        {
            FlowDocument doc = new FlowDocument();
            Section sec = new Section();
            Paragraph parag = new Paragraph();

            parag.Inlines.Add("Name\t\t          Quantity\t     Price");
            sec.Blocks.Add(parag);
            doc.Blocks.Add(sec);

            foreach (var row in Check)
            {
                parag = null;
                parag = new Paragraph();

                parag.Inlines.Add(row.ToString());
                sec.Blocks.Add(parag);
                doc.Blocks.Add(sec);
            }

            parag = new Paragraph();
            parag.Inlines.Add($"------------------------------------------------------\n");
            parag.Inlines.Add($"Subtotal\t\t\t{Subtotal,25:c}\n");
            parag.Inlines.Add($"Tax\t\t\t{Subtotal * 0.13m,25:c}\n");
            parag.Inlines.Add($"Total\t\t\t{Subtotal * 1.13m,25:c}");
            sec.Blocks.Add(parag);
            doc.Blocks.Add(sec);

            return doc;
        }
    }
}
