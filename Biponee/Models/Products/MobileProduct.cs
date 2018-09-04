using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models.Products
{
    public class MobileProduct : Product
    {
        public int Quantity { get; set; }
        public MobileProduct(string productName, string productCode, int sectionId, double price, int quantity,string category, string description, string imageLink, string brandName) : base(productName, productCode, sectionId, price, category, description, imageLink, brandName)
        {
            this.Quantity = quantity;
        }

        public MobileProduct() : base()
        {

        }
    }
}