using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_lfe_gfr_41_82.Entities
{
    class ProductInfo
    {
        //all properties of the object
        public int Id { get; set; }
        public int orderQuantity { get; set; }
        public double sales { get; set; }
        public string shippingMode { get; set; }
        public double profit { get; set; }
        public double unitPrice { get; set; }
        public string customerName { get; set; }
        public string province { get; set; }
        public string customerSegment { get; set; }
        public string productCategory { get; set; }
        public string productSubCategory { get; set; }
        public string productName { get; set; }

        //constructor with backing fields 
        public ProductInfo(int nId, int nOrderQuantity, double nSales, string nShippingMode, double nProfit, 
            double nUnitPrice, string nCustomerName, string nProvince, string nCustomerSegnment, string nProductCategory, string nProductSubCategory, string nProductName)
        {
            this.Id = nId;
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
