using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models.Products
{
    public class DailyNeedProduct : Product
    {
       public int Quantity { get; set; }
        public DailyNeedProduct(string productName, string productCode, int sectionId, double price,int quntity ,string category, string description, string imageLink, string brandName) : base(productName, productCode, sectionId, price, category, description, imageLink, brandName)
        {
            this.Quantity = quntity;
        }

        public DailyNeedProduct() : base()
        {

        }
    }
}