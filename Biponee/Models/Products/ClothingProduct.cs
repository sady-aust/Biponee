using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models.Products
{
    public class ClothingProduct : Product
    {
        public int LCount { get; set; }
        public int MCount { get; set; }
        public int XLCount { get; set; }
        public int XXLCount { get; set; }

        public ClothingProduct(String productName,String productCode, int sectionId,Double price,String category,String description,String imageLink,String brandName,
            int lCount,int mCount,int xlCount,int xxlCount) :base(productName,productCode,sectionId,price,category,description,imageLink,brandName)
        {
            this.LCount = lCount;
            this.MCount = mCount;
            this.XLCount = xlCount;
            this.XXLCount = xxlCount;
        }

        public ClothingProduct(int productId,String productName, String productCode, int sectionId, Double price, String category, String description, String imageLink, String brandName,
           int lCount, int mCount, int xlCount, int xxlCount) : base(productId,productName, productCode, sectionId, price, category, description, imageLink, brandName)
        {
            this.LCount = lCount;
            this.MCount = mCount;
            this.XLCount = xlCount;
            this.XXLCount = xxlCount;
        }

        public ClothingProduct():base()
        {
        }
    }
}