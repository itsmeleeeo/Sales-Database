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
            var productCategory = from p in myStore
                                  select p.productCategory;

        }
        private void populateSubProductCategory()
        {
            var productSubCategory = from p in myStore
                                  select p.productSubCategory;
        }

        private void populateShippingMode()
        {
            var productShippingMode = from p in myStore
                                     select p.shippingMode;
        }
        private void populateProvince()
        {
            var productProvince = from p in myStore
                                      select p.province;
        }
    }
}
