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
        List<ProductInfo> myStore = new List<ProductInfo>();
        List<ProductInfo> filteredData = new List<ProductInfo>();
        public MainWindow()
        {
            InitializeComponent();
            string fileContents = FileService.ReadFile(@"..\..\Data\Assignment1.psv");
            myStore = ProductInfoParser.ParseRoster(fileContents);

            ToggleEventHandler(false);

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
            ToggleEventHandler(true);
        }

        private void ToggleEventHandler(bool toggle)
        {
            if(toggle)
            {
                listProv.SelectionChanged += updateSelectedInfo;
            } else
            {
                listProv.SelectionChanged -= updateSelectedInfo;
            }
        }

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

            DataGridTextColumn unitPrice = new DataGridTextColumn();
            unitPrice.Header = "Unit Price";
            unitPrice.Binding = new Binding("unitPrice");

            DataGridTextColumn shippingMode = new DataGridTextColumn();
            shippingMode.Header = "Shipping Mode";
            shippingMode.Binding = new Binding("shippingMode");

            DataGridTextColumn profit = new DataGridTextColumn();
            profit.Header = "Profit";
            profit.Binding = new Binding("profit");

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

        private void populateDataGrid()
        {
            foreach(ProductInfo pi in myStore)
            {
                dataGridProducts.Items.Add(pi);
            }
        }

        private void populateProductCategory()
        {
            var productCategory = myStore.Select(x => x.productCategory).Distinct();
            foreach (var p in productCategory)
            {
                listCat.Items.Add(p.Trim());
            }
            listCat.SelectAll();

        }
        private void populateSubProductCategory()
        {
            var productSubCategory = myStore.OrderBy(x => x.productSubCategory);
            var orderProductSubCategory = productSubCategory.Select(x => x.productSubCategory).Distinct();
            foreach (var p in orderProductSubCategory)
            {
                listSubCat.Items.Add(p.Trim());
            }
        }

        private void populateShippingMode()
        {
            
            var productShippingMode = myStore.Select(x => x.shippingMode).Distinct();
            foreach (var p in productShippingMode)
            {
                listShi.Items.Add(p.Trim());
            }
            listShi.SelectAll();
        }
        private void populateProvince()
        {
            var productProvin = myStore.OrderBy(x => x.province);
            var orderedProvince = productProvin.Select(x => x.province).Distinct();
            foreach (var p in orderedProvince)
            {
                listProv.Items.Add(p.Trim());
            }
        }

        private void AverageTransaction()
        {
            double total = 0.0;
            var avgTransaction = (from s in myStore select s.sales).Sum();
            var transactions = myStore.Count();

            total = avgTransaction / transactions;

            txtAverageTransaction.Text = String.Format("${0:#.00}", Convert.ToDecimal(total));
        }

        private void TotalTransactions()
        {
            var totalTransactions = myStore.Count();
            txtTotalTransactions.Text = totalTransactions.ToString();
        }

        private void FilteredDataGrid()
        {
            DataGridTextColumn customerName = new DataGridTextColumn();
            customerName.Header = "Customer Name";
            customerName.Binding = new Binding("customerName");

            DataGridTextColumn orderQuantity = new DataGridTextColumn();
            orderQuantity.Header = "Order Quantity";
            orderQuantity.Binding = new Binding("orderQuantity");

            DataGridTextColumn unitPrice = new DataGridTextColumn();
            unitPrice.Header = "Unit Price";
            unitPrice.Binding = new Binding("unitPrice");

            DataGridTextColumn subTotal = new DataGridTextColumn();
            subTotal.Header = "Sub Total";
            subTotal.Binding = new Binding("sales");

            DataGridTextColumn profit = new DataGridTextColumn();
            profit.Header = "Profit";
            profit.Binding = new Binding("profit");

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
            foreach(ProductInfo pi in myStore)
            {
              filteredDataGrid.Items.Add(pi);
          }
        }
        private void updateSelectedInfo(object o, EventArgs ea)
        {
              var selectedProvinces = listProv.Items.OfType<ListViewItem>().Where(x => x.IsSelected).Select(x => x.Content);
            try {
                var provinceSelected = from p in myStore
                    // join province in selectedProvinces on p.province equals province
                where p.province == Convert.ToString(listProv.SelectedItem.ToString()) //&&
                                                                                       // p.shippingMode == Convert.ToString(listShi.SelectedItem.ToString())
                select p;


                filteredDataGrid.Items.Clear();
           foreach(ProductInfo p in provinceSelected)
            {
                filteredDataGrid.Items.Add(p);
            }

            //string totalTransactionsFiltered = provinceSelected.Count().ToString();
            //Total of customers found after filtering 
            txtTotalCustomers.Text = Convert.ToString(provinceSelected.Count());

            //Total of orders after filtered
            var totalOrders = provinceSelected.Select(x => x.orderQuantity).Sum();
            txtTotalOrders.Text = totalOrders.ToString();

            //Total profit after filtered
            var totalProfit = provinceSelected.Select(x => x.profit).Sum();
            txtTotalProfits.Text = String.Format("${0:0,000.00}", Convert.ToDecimal(totalProfit));
        }       
        private void PopulateTotalCustomers()
        {
            var totalCustomers = myStore.Select(x => x.customerName).Distinct();
            var customerCount = totalCustomers.Count();
            txtTotalCustomers.Text = customerCount.ToString();
        }

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

        private void chboxProfit_Checked(object sender, RoutedEventArgs e)
        {
            if(chboxProfit.IsChecked == true)
            {
                txtProfitMargin.IsEnabled = true;
            }
        }
    }
}
