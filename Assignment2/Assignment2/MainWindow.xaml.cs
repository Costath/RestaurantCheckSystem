using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        //Beverages list to present in the ComboBox
        private ObservableCollection<MenuItem> Beverages = new ObservableCollection<MenuItem>();
        //Appetizers list to present in the ComboBox
        private ObservableCollection<MenuItem> Appetizers = new ObservableCollection<MenuItem>();
        //Main Courses list to present in the ComboBox
        private ObservableCollection<MenuItem> MainCourseDishes = new ObservableCollection<MenuItem>();
        //Desserts list to present in the ComboBox
        private ObservableCollection<MenuItem> Desserts = new ObservableCollection<MenuItem>();
        //OrderedFood list to present in the DataGrid
        private ObservableCollection<OrderedFood> Check = new ObservableCollection<OrderedFood>();
        //Menu instance to create the available MenuItem objects
        private Menu menu = new Menu { };
        //Local variable to hold the Subtotal value
        private decimal Subtotal = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadCollectionData();

            //Set the ComboBoxes ItemSource as the ObservableCollection lists of MenuItem
            BeveragesComboBox.ItemsSource = Beverages;
            AppetizersComboBox.ItemsSource = Appetizers;
            MainCourseDishesComboBox.ItemsSource = MainCourseDishes;
            DessertsComboBox.ItemsSource = Desserts;

            //Set the DataGrid ItemSource as the ObservableCollection list of OrderedFood
            CheckDataGrid.ItemsSource = Check;

        }
        /// <summary>
        /// Load the ObservableCollection lists with MenuItem objects
        /// </summary>
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
            foreach (MenuItem item in menu.MainCourseDishes)
            {
                MainCourseDishes.Add(item);
            }
            foreach (MenuItem item in menu.Desserts)
            {
                Desserts.Add(item);
            }
        }

        private void BeveragesComboBox_DropDownClosed(object sender, EventArgs e)
        {
            //Hold the ComboBox selection
            MenuItem selection;

            //If no item is selected and the DropDown closes, this try and catch handles the exception
            try
            {
                selection = menu.Beverages.ElementAt(BeveragesComboBox.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            //Flags if the selected item is already present in the Check list
            bool itemPresent = false;

            //Runs the Check list verifing if the selected item is already present
            foreach (OrderedFood Row in Check)
            {
                if (Row.Name == selection.Name)
                {
                    Row.Quantity++;
                    CheckDataGrid.Items.Refresh();
                    itemPresent = true;
                }
            }

            //Adds the selected item to the Check list in case the item was not present
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
            //Hold the ComboBox selection
            MenuItem selection;

            //If no item is selected and the DropDown closes, this try and catch handles the exceptio
            try
            {
                selection = menu.Appetizers.ElementAt(AppetizersComboBox.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            //Flags if the selected item is already present in the Check list
            bool itemPresent = false;

            //Runs the Check list verifing if the selected item is already present
            foreach (OrderedFood Row in Check)
            {
                if (Row.Name == selection.Name)
                {
                    Row.Quantity++;
                    CheckDataGrid.Items.Refresh();
                    itemPresent = true;
                }
            }

            //Adds the selected item to the Check list in case the item was not present
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
            //Hold the ComboBox selection
            MenuItem selection;

            //If no item is selected and the DropDown closes, this try and catch handles the exception
            try
            {
                selection = menu.MainCourseDishes.ElementAt(MainCourseDishesComboBox.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            //Flags if the selected item is already present in the Check list
            bool itemPresent = false;

            //Runs the Check list verifing if the selected item is already present
            foreach (OrderedFood Row in Check)
            {
                if (Row.Name == selection.Name)
                {
                    Row.Quantity++;
                    CheckDataGrid.Items.Refresh();
                    itemPresent = true;
                }
            }

            //Adds the selected item to the Check list in case the item was not present
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
            //Hold the ComboBox selection
            MenuItem selection;

            //If no item is selected and the DropDown closes, this try and catch handles the exception
            try
            {
                 selection = menu.Desserts.ElementAt(DessertsComboBox.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            //Flags if the selected item is already present in the Check list
            bool itemPresent = false;

            //Runs the Check list verifing if the selected item is already present
            foreach (OrderedFood Row in Check)
            {
                if (Row.Name == selection.Name)
                {
                    Row.Quantity++;
                    CheckDataGrid.Items.Refresh();
                    itemPresent = true;
                }
            }

            //Adds the selected item to the Check list in case the item was not present
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
            //set the CheckDataGrid columns ReadOnly property as true
            foreach (var column in CheckDataGrid.Columns)
            {
                column.IsReadOnly = true;
            }

            //set the CheckDataGrid Quantity column ReadOnly property as false
            CheckDataGrid.Columns.Where(x => x.Header.ToString() == "Quantity").FirstOrDefault().IsReadOnly = false;

            //Place '0' formated to money in the monetary TextBoxes
            SubTotalTextBox.Text = (0).ToString("c");
            TaxTextBox.Text = (0).ToString("c");
            TotalTextBox.Text = (0).ToString("c");
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            //Clears the Check list, crearing the CheckDataGrid
            Check.Clear();
            
            //Clears the ComboBoxes selections
            BeveragesComboBox.SelectedIndex = -1;
            AppetizersComboBox.SelectedIndex = -1;
            MainCourseDishesComboBox.SelectedIndex = -1;
            DessertsComboBox.SelectedIndex = -1;

            UpdateMonetaryTextBoxes();
        }

        private void RemoveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            //In case the RemoveItemBtn is clicked with no item selected, this try and catch handles the exception
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
            //Update the monetary TextBoxes everytime the CheckDataGrid selection is changed
            UpdateMonetaryTextBoxes();
        }

        /// <summary>
        /// Updates the monetary TextBoxes based on the items present in the Check list
        /// </summary>
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
            //Create and prepare a FlowDocument to print
            FlowDocument doc = CreateFlowDocument();
            IDocumentPaginatorSource idpSource = doc;
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Printing the Check.");
        }

        /// <summary>
        /// Prepare a FlowDocument to print
        /// </summary>
        /// <returns></returns>
        private FlowDocument CreateFlowDocument()
        {
            FlowDocument doc = new FlowDocument();
            Section sec = new Section();
            Paragraph parag = new Paragraph();

            //Document header
            parag.Inlines.Add("Name\t\t          Quantity\t     Price");
            sec.Blocks.Add(parag);
            doc.Blocks.Add(sec);

            //Adds each item from the Check list to the document
            foreach (var row in Check)
            {
                parag = null;
                parag = new Paragraph();

                parag.Inlines.Add(row.ToString());
                sec.Blocks.Add(parag);
                doc.Blocks.Add(sec);
            }
            
            //Calculates, formats and adds the monetary values to the document 
            parag = new Paragraph();
            parag.Inlines.Add($"------------------------------------------------------\n");
            parag.Inlines.Add($"Subtotal\t\t\t{Subtotal,25:c}\n");
            parag.Inlines.Add($"Tax\t\t\t{Subtotal * 0.13m,25:c}\n");
            parag.Inlines.Add($"Total\t\t\t{Subtotal * 1.13m,25:c}");
            sec.Blocks.Add(parag);
            doc.Blocks.Add(sec);

            return doc;
        }

        private void Hyperlink_Handler(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
