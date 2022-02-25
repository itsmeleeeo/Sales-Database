using Assignment1_lfe_gfr_41_82.Entities;
using Assignment1_lfe_gfr_41_82.Utilities;
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

namespace Assignment1_lfe_gfr_41_82
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //initialize the objects
        
        List<ProductInfo> myStore = new List<ProductInfo>();
        List<ProductInfo> filteredData = new List<ProductInfo>();
        public MainWindow()
        {
            InitializeComponent();
            //reading the file from the file serivce
            string fileContents = FileService.ReadFile(@"..\..\Data\Assignment1.psv");
            //saving into list our file parser
            myStore = ProductInfoParser.ParseRoster(fileContents);

            ToggleEventHandler(false);

            //all methods that calls datagrids, bindings and event handlers
            initializeDataGrid();
            populateDataGrid();
            TotalTransactions();
            AverageTransaction();
            populateProductCategory();
            populateSubProductCategory();
            populateShippingMode();
            populateProvince();
            FilteredDataGrid();
            PopulateFilteredDataGrid();
            PopulateTotalCustomers();
            PopulateTotalOrders();
            PopulateTotalProfit();
            
            txtProfitMargin.TextChanged += ProfitMarginEventHandler;
            chboxProfit.Unchecked += CheckBoxUnchecked;
            chboxProfit.Checked += CheckBoxChecked;
            listShi.SelectionChanged += UpdateSelectShipping;
            listSubCat.SelectionChanged += UpdateSubCategories;
            listProv.SelectionChanged += updateProvinceFilter;
            listCat.SelectionChanged += updateCategoriesFilter;
            btnReset.Click += ButtonReset;
            ToggleEventHandler(true);
        }
        //filter the provinces
        private void ToggleEventHandler(bool toggle)
        {
            if(toggle)
            {
                listProv.SelectionChanged += updateProvinceFilter;
            } else
            {
                listProv.SelectionChanged -= updateProvinceFilter;
            }
        }
<<<<<<< HEAD

=======
>>>>>>> 022207dba77ff8b4925e05aafbcb360a87c50ec1
        //setting the columns and binding the data to columns
        private void initializeDataGrid()
        {
            DataGridTextColumn productCategory = new DataGridTextColumn();
            productCategory.Header = "Product Category";
            productCategory.Binding = new Binding("productCategory");

            DataGridTextColumn productSubCategory = new DataGridTextColumn();
            productSubCategory.Header = "Product Sub-Category";
            productSubCategory.Binding = new Binding("productSubCategory");

            DataGridTextColumn productName = new DataGridTextColumn();
            productName.Header = "Product Name";
            productName.Binding = new Binding("productName");

            DataGridTextColumn orderQuantity = new DataGridTextColumn();
            orderQuantity.Header = "Order Quantity";
            orderQuantity.Binding = new Binding("orderQuantity");

            DataGridTextColumn sales = new DataGridTextColumn();
            sales.Header = "Sales";
            sales.Binding = new Binding("sales");
            sales.Binding.StringFormat = "$00.00";
           

            DataGridTextColumn unitPrice = new DataGridTextColumn();
            unitPrice.Header = "Unit Price";
            unitPrice.Binding = new Binding("unitPrice");
            unitPrice.Binding.StringFormat = "$00.00";

            DataGridTextColumn shippingMode = new DataGridTextColumn();
            shippingMode.Header = "Shipping Mode";
            shippingMode.Binding = new Binding("shippingMode");

            DataGridTextColumn profit = new DataGridTextColumn();
            profit.Header = "Profit";
            profit.Binding = new Binding("profit");
            profit.Binding.StringFormat = "$00.00";

            DataGridTextColumn customerName = new DataGridTextColumn();
            customerName.Header = "Customer Name";
            customerName.Binding = new Binding("customerName");

            DataGridTextColumn customerSegment = new DataGridTextColumn();
            customerSegment.Header = "Customer Segment";
            customerSegment.Binding = new Binding("customerSegment");

            DataGridTextColumn province = new DataGridTextColumn();
            province.Header = "Province";
            province.Binding = new Binding("province");

            dataGridProducts.Columns.Add(productCategory);
            dataGridProducts.Columns.Add(productSubCategory);
            dataGridProducts.Columns.Add(productName);
            dataGridProducts.Columns.Add(orderQuantity);
            dataGridProducts.Columns.Add(sales);
            dataGridProducts.Columns.Add(unitPrice);
            dataGridProducts.Columns.Add(shippingMode);
            dataGridProducts.Columns.Add(profit);
            dataGridProducts.Columns.Add(customerName);
            dataGridProducts.Columns.Add(customerSegment);
            dataGridProducts.Columns.Add(province);
        }
        //populating the datagrid with the file data
        private void populateDataGrid()
        {
            foreach(ProductInfo pi in myStore)
            {
                dataGridProducts.Items.Add(pi);
            }
        }

        //select product category and check whether has duplicated category and add into the list
        private void populateProductCategory()
        {
            var productCategory = myStore.Select(x => x.productCategory).Distinct();
            foreach (var p in productCategory)
            {
                listCat.Items.Add(p.Trim());
            }
            listCat.SelectAll();

        }
        //select subcategory list order by and select the distinct to check whether has duplicated or not and add to the list
        private void populateSubProductCategory()
        {
            var productSubCategory = myStore.OrderBy(x => x.productSubCategory);
            var orderProductSubCategory = productSubCategory.Select(x => x.productSubCategory).Distinct();
            foreach (var p in orderProductSubCategory)
            {
                listSubCat.Items.Add(p.Trim());
            }
        }

        //select shipment and check whether has duplicated values or not and add into the list
        private void populateShippingMode()
        {
            var productShippingMode = myStore.Select(x => x.shippingMode).Distinct();
            foreach (var p in productShippingMode)
            {
                listShi.Items.Add(p.Trim());
            }
            listShi.SelectAll();
        }
        //select and order the provinces then check whether has duplicated or not and add to the list
        private void populateProvince()
        {
            var productProvin = myStore.OrderBy(x => x.province);
            var orderedProvince = productProvin.Select(x => x.province).Distinct();
            foreach (var p in orderedProvince)
            {
                listProv.Items.Add(p.Trim());
            }
        }
        //select all sales and sum them up them count the amount of transactions and check the average
        private void AverageTransaction()
        {
            double total = 0.0;
            var avgTransaction = (from s in myStore select s.sales).Sum();
            var transactions = myStore.Count();

            total = avgTransaction / transactions;

            txtAverageTransaction.Text = String.Format("${0:#.00}", Convert.ToDecimal(total));
        }
        //it counts all the transacations
        private void TotalTransactions()
        {
            
            var totalTransactions = myStore.Count();
            txtTotalTransactions.Text = totalTransactions.ToString();
        }

        //filtered datagrid that updates everytime an item is selected
        private void FilteredDataGrid()
        {
            //Setup the DataGrid Layout and formating by binding it to the values of the object
            DataGridTextColumn customerName = new DataGridTextColumn();
            customerName.Header = "Customer Name";
            customerName.Binding = new Binding("customerName");

            DataGridTextColumn orderQuantity = new DataGridTextColumn();
            orderQuantity.Header = "Order Quantity";
            orderQuantity.Binding = new Binding("orderQuantity");

            DataGridTextColumn unitPrice = new DataGridTextColumn();
            unitPrice.Header = "Unit Price";
            unitPrice.Binding = new Binding("unitPrice");
            unitPrice.Binding.StringFormat = "$00.00";

            DataGridTextColumn subTotal = new DataGridTextColumn();
            subTotal.Header = "Sub Total";
            subTotal.Binding = new Binding("subTotal");
            subTotal.Binding.StringFormat = "$00.00";

            DataGridTextColumn profit = new DataGridTextColumn();
            profit.Header = "Profit";
            profit.Binding = new Binding("profit");
            profit.Binding.StringFormat = "$00.00";

            DataGridTextColumn customerSegment = new DataGridTextColumn();
            customerSegment.Header = "Customer Segment";
            customerSegment.Binding = new Binding("customerSegment");

            filteredDataGrid.Columns.Add(customerName);
            filteredDataGrid.Columns.Add(orderQuantity);
            filteredDataGrid.Columns.Add(unitPrice);
            filteredDataGrid.Columns.Add(subTotal);
            filteredDataGrid.Columns.Add(profit);
            filteredDataGrid.Columns.Add(customerSegment);
        }

       
        private void PopulateFilteredDataGrid()
        {
            //Populate the filtered Data Grid at the start of the program
            foreach (ProductInfo pi in myStore)
            {
              filteredDataGrid.Items.Add(pi);
            }
        }

        //Those Event Handlers are use to get the first update on the filteredData List
        //and send the values to the UpdateFilteredDataGrid Method
        private void updateProvinceFilter(object o, EventArgs ea)
        {

            var selectedProvinces = listProv.SelectedItems.OfType<string>();
            var provinceSelected = from p in myStore
                                   join province in selectedProvinces on p.province equals province 
                                   select p;

            filteredData = provinceSelected.ToList();

            UpdateFilteredDataGrid();
        }

        //update the subcategories once its select and sort them into the datagrid
        private void UpdateSubCategories(object o, EventArgs ea)
        {
            var selectedSubCategories = listSubCat.SelectedItems.OfType<string>();
            var subCategoriesSelected = from p in myStore
                                        join subcategories in selectedSubCategories on p.productSubCategory equals subcategories
                                        select p;

            filteredData = subCategoriesSelected.ToList();

            UpdateFilteredDataGrid();
        }

        //update the shipping once its select and sort them into the datagrid
        private void UpdateSelectShipping(object o, EventArgs ea)
        {
            var selecShipping = listShi.SelectedItems.OfType<string>();
            var filteredShipping = from p in myStore
                                   join shiping in selecShipping on p.shippingMode equals shiping
                                   select p;

            filteredData = filteredShipping.ToList();

            UpdateFilteredDataGrid();
        }
        //update the category once its select and sort them into the datagrid
        private void updateCategoriesFilter(object o, EventArgs ea)
        {
            var selectedCategories = listCat.SelectedItems.OfType<string>();


            var categoriesSelected = from p in myStore
                                     join categories in selectedCategories on p.productCategory equals categories
                                     select p;
            filteredData = categoriesSelected.ToList();
            UpdateFilteredDataGrid();
        }
        
        //Those methods show on the text box the values of the list when it is first created
        private void PopulateTotalCustomers()
        {
            var totalCustomers = myStore.Select(x => x.customerName).Distinct();
            var customerCount = totalCustomers.Count();
            txtTotalCustomers.Text = customerCount.ToString();
        }

        //select total orders and sum them up and display on the screen
        private void PopulateTotalOrders()
        {
            var totalOrders = myStore.Select(x => x.orderQuantity).Sum();
            txtTotalOrders.Text = totalOrders.ToString();
        }

        private void PopulateTotalProfit()
        {
            var totalProfit = myStore.Select(x => x.profit).Sum();
            txtTotalProfits.Text = String.Format("${0:0,000.00}", Convert.ToDecimal(totalProfit));
        }

        //Methods to activate or deactivate the text box if the check box is checked or not
        private void CheckBoxChecked(object o, EventArgs ea)
        {
            txtProfitMargin.IsEnabled = true;
        }
        private void CheckBoxUnchecked(object o, EventArgs ea)
        {
            txtProfitMargin.IsEnabled = false;
        }

        private void UpdateFilteredDataGrid()
        {
            //This method receives the first filteredData value and from there it applies the other filters to it
            //This method prints the Data Grid filtered too and count the values that should dynamically change
            var selectedCategories = listCat.SelectedItems.OfType<string>();

            var selecShipping = listShi.SelectedItems.OfType<string>();

            var selectedSubCategories = listSubCat.SelectedItems.OfType<string>();

            var selectedProvinces = listProv.SelectedItems.OfType<string>();
           
            var finalFilterPro= from p in filteredData
                              join final in selectedProvinces on p.province equals final
                              select p;
            var finalFilterCat = from p in finalFilterPro
                                 join final in selectedCategories on p.productCategory equals final
                                 select p;
            var finalFilterShi = from p in finalFilterCat
                                 join final in selecShipping on p.shippingMode equals final
                                 select p;
            var finalFilterSubCat = from p in finalFilterShi
                                    join final in selecShipping on p.shippingMode equals final
                                    select p;
            
            
                filteredData = finalFilterSubCat.ToList();
            

            try
            {
                filteredDataGrid.Items.Clear();
                foreach (ProductInfo p in filteredData)
                {
                    filteredDataGrid.Items.Add(p);
                }
                
                //Total of customers found after filtering 
                txtTotalCustomers.Text = Convert.ToString(filteredData.Count());

                //Total of orders after filtered
                var totalOrders = filteredData.Select(x => x.orderQuantity).Sum();
                txtTotalOrders.Text = totalOrders.ToString();

                //Total profit after filtered
                var totalProfit = filteredData.Select(x => x.profit).Sum();
                txtTotalProfits.Text = String.Format("${0:0,000.00}", Convert.ToDecimal(totalProfit));

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //check if the user has entered the right value integer or not then check in the list the profit related to that percentage and filter the list
        //Gabriel and I could filter by the a profit margin however we could not make the profit margin work together withh other filters, I am sorry.
        private void ProfitMarginEventHandler(object o, EventArgs ea)
        {
            int profitMargin = 0;
            if (int.TryParse(txtProfitMargin.Text, out profitMargin) == false)
            {
                MessageBox.Show("You must enter an integer for the profit filter");
            }

            var subtotal = from s in myStore
                           join sm in myStore on s.profit equals sm.profit
                           where (s.profit / (s.orderQuantity * s.unitPrice)) * 100 >= profitMargin
                           select s;

            filteredDataGrid.Items.Clear();

            foreach (ProductInfo s in subtotal)
            {
                filteredDataGrid.Items.Add(s);
            }
            profitMargin = 0;

            //Total of customers found after filtering 
                txtTotalCustomers.Text = Convert.ToString(subtotal.Count());

            //Total of orders after filtered
            var totalOrders = subtotal.Select(x => x.orderQuantity).Sum();
            txtTotalOrders.Text = totalOrders.ToString();

            //Total profit after filtered
            var totalProfit = subtotal.Select(x => x.profit).Sum();
            txtTotalProfits.Text = String.Format("${0:0,000.00}", Convert.ToDecimal(totalProfit));


        }
        private void ButtonReset(object o,EventArgs ea)
        {
            //Reset button method, clear the list and unselected the SubCategorie and the Province filter 
            //and selec all the ones on the Shipping mode and Categories list
            filteredData.Clear();
            listShi.SelectAll();
            listCat.SelectAll();
            listSubCat.UnselectAll();
            listProv.UnselectAll();
        }
    }
}
