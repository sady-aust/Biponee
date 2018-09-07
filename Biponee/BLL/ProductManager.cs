using Biponee.DLL;
using Biponee.Models;
using Biponee.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.BLL
{
    public class ProductManager
    {
        ProductGetway productGetway = new ProductGetway();

        public Boolean InsertClothingProduct(ClothingProduct product)
        {
            if (productGetway.insertClothingProduct(product) > 0)
            {
                return true;
            }

            return false;
        }

        public Boolean InsertElectronicsProduct(ElectronicsProduct product)
        {
            if (productGetway.insertElectronicsProduct(product) > 0)
            {
                return true;
            }

            return false;
        }

        public Boolean InsertDailyNeedsProduct(DailyNeedProduct product)
        {
            if (productGetway.insertDailyNeedsProduct(product) > 0)
            {
                return true;
            }

            return false;
        }
        public Boolean InsertMobileProduct(MobileProduct product)
        {
            if (productGetway.insertMobileProduct(product) > 0)
            {
                return true;
            }

            return false;
        }


        public List<ClothingProduct> GetAllCLothingProduct()
        {
            return productGetway.getAllClothingProduct();
        }
        public List<ElectronicsProduct> GetAllElectroinicProduct()
        {
            return productGetway.getAllElectronicsProduct();
        }
        public List<DailyNeedProduct> GetAllDailyNeedProuct()
        {
            return productGetway.getAllDailyNeedProduct();
        }
        public List<MobileProduct> GetAllMobileProduct()
        {
            return productGetway.getMobileProduct();
        }
        public List<MobileProduct> GetAllMobileProduct(String ProductCode)
        {
            return productGetway.getMobileProduct(ProductCode);
        }

        public List<ClothingProduct> getAClothingProduct(String ProductCode)
        {
            return productGetway.getaClothingProduct(ProductCode);
        }

        public List<ElectronicsProduct> GetElectronicsProducts(String ProductCode)
        {
            return productGetway.getAllElectronicsProduct(ProductCode);
        }

        public List<DailyNeedProduct> GetAllDailyNeedProuct(String productCode)
        {
            return productGetway.getAllDailyNeedProduct(productCode);
        }


        /* public List<ProductC> GetAllProductThisSection(int id)
         {
             return productGetway.getAllOfThisSection(id);
         }*/

        /* public List<ProductC> GetProduct(int secId, String productCode)
         {
             return productGetway.getProducts(secId, productCode);
         }*/





        public Boolean isThisCodeAlreadyExist(String code)
        {
            List<ProductC> productList = productGetway.getProductWithProductCode(code);
            if (productList.Count > 0)
            {
                return true;
            }
            return false;
        }

        public ProductC getProductByProductId(int id)
        {
            List<ProductC> list = productGetway.getProducts(id);
            return list[0];
        }

        public List<ProductC> GetProducts(int secId,String CategoryName)
        {
            return productGetway.getAllProductOfthisCategory(secId, CategoryName);
        }

        public List<ProductC> GetProducts(String name)
        {
            return productGetway.getProducts(name);
        }

        public Boolean UpdateClothingProduct(ClothingProduct product)
        {
            if (productGetway.UpdateProductInfo(product)>0)
            {
                return true;
            }
            return false;
        }

        public Boolean UpdateElectronicsProduct(ElectronicsProduct product)
        {
            if (productGetway.UpdateProductInfo(product) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean UpdateDailyNeedsProduct(DailyNeedProduct product)
        {
            if(productGetway.UpdateProductInfo(product) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean UpdateMobileProduct(MobileProduct product)
        {
            if (productGetway.UpdateProductInfo(product) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean DeleteProduct(int id)
        {
            if (productGetway.DeleteProduct(id) > 0)
            {
                return true;
            }
            return false;
        }
    }
}