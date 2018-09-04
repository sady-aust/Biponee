using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models.Products
{
    public class Product
    {
        public String ProductName { get; set; }
        public String ProductCode { get; set; }
        public int SectionId { get; set; }
        public Double Price { get; set; }
        public String Category { get; set; }
        public String Description { get; set; }
        public String ImageLink { get; set; }
        public String BrandName { get; set; }

        public Product(string productName, string productCode, int sectionId, Double price, string category, string description, string imageLink, string brandName)
        {
            ProductName = productName;
            ProductCode = productCode;
            SectionId = sectionId;
            Price = price;
            Category = category;
            Description = description;
            ImageLink = imageLink;
            BrandName = brandName;
        }

        public Product()
        {
        }
    }
}