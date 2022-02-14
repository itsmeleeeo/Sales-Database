using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_lfe_gfr_41_82.Entities
{
    class ProductInfo
    {
        public string productCategory { get; set; }
        public string productSubCategory { get; set; }
        public string productName { get; set; }
        public int orderQuantity { get; set; }
        public double sales { get; set; }
        public double unitPrice { get; set; }
        public string shippingMode { get; set; }
        public double profit { get; set; }
        public string customerName { get; set; }
        public string customerSegment { get; set; }
        public string province { get; set; }

        public ProductInfo(string nProductCategory, string nProductSubCategory, string nProductName, int nOrderQuantity, double nSales, double nUnitPrice, 
            string nShippingMode, double nProfit, string nCustomerName, string nCustomerSegnment, string nProvince)
        {
            this.productCategory = nProductCategory;
            this.productSubCategory = nProductSubCategory;
            this.productName = nProductName;
            this.orderQuantity = nOrderQuantity;
            this.sales = nSales;
            this.unitPrice = nUnitPrice;
            this.shippingMode = nShippingMode;
            this.profit = nProfit;
            this.customerName = nCustomerName;
            this.customerSegment = nCustomerSegnment;
            this.province = nProvince;
        }
    }
}
