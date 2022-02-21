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
        public MainWindow()
        {
            InitializeComponent();
            string fileContents = FileService.ReadFile(@"..\..\Data\Assignment1.psv");
            myStore = ProductInfoParser.ParseRoster(fileContents);

            initializeDataGrid();
            populateDataGrid();
            TotalTransactions();
            AverageTransaction();
            populateProductCategory();
            populateSubProductCategory();
            populateShippingMode();
            populateProvince();
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
    }
}
