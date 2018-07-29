using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class ProductC
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public String ProductCode { get; set; }
        public int SectionId { get; set; }
        public String Price { get; set; }
        public String Category { get; set; }
        public String Description { set; get; }
        public String ImageLink { set; get; }
        public String LCount { get; set; }
        public String MCount { get; set; }
        public String XLCount { get; set; }
        public String XXLCount { get; set; }
        public String Quantity { get; set; }

        public ProductC(int productId, string productName, string productCode, int sectionId, string price, string category, string description, string imageLink, string lCount, string mCount, string xLCount, string xLLCount,String quantity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductCode = productCode;
            SectionId = sectionId;
            Price = price;
            Category = category;
            Description = description;
            ImageLink = imageLink;
            LCount = lCount;
            MCount = mCount;
            XLCount = xLCount;
            XXLCount = xLLCount;
            Quantity = quantity;
        }

        public ProductC(string productName, string productCode, int sectionId, string price, string category, string description, string imageLink, string lCount, string mCount, string xLCount, string xLLCount,String quantity)
        {
            ProductName = productName;
            ProductCode = productCode;
            SectionId = sectionId;
            Price = price;
            Category = category;
            Description = description;
            ImageLink = imageLink;
            LCount = lCount;
            MCount = mCount;
            XLCount = xLCount;
            XXLCount = xLLCount;
            Quantity = quantity;
        }

        public ProductC()
        {
        }
    }
}