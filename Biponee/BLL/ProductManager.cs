using Biponee.DLL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.BLL
{
    public class ProductManager
    {
        ProductGetway productGetway = new ProductGetway();

        public Boolean insertProduct(ProductC product)
        {
            if (productGetway.insertProduct(product) > 0)
            {
                return true;
            }

            return false;
        }

        public List<ProductC> getAllProduct()
        {
            return productGetway.getAllProduct();
        }

        public List<ProductC> getAllProductThisSection(int id)
        {
            return productGetway.getAllOfThisSection(id);
        }

        public List<ProductC> getProduct(int secId, String productCode)
        {
            return productGetway.getproduct(secId, productCode);
        }





        public Boolean isThisCodeAlreadyExist(String code)
        {
            List<ProductC> productList = productGetway.getProductWithProductCode(code);
            if (productList.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}