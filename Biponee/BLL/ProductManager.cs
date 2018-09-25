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
            return productGetway.getElectronicProduct();
        }
        public List<DailyNeedProduct> GetADailyNeedProuct()
        {
            return productGetway.getADailyNeedProduct();
        }
        public List<MobileProduct> GetAllMobileProduct()
        {
            return productGetway.getAllMobileProduct();
        }
        public List<MobileProduct> GetAllMobileProduct(String ProductCode)
        {
            return productGetway.getAMobileProduct(ProductCode);
        }

        public List<ClothingProduct> getAClothingProduct(String ProductCode)
        {
            return productGetway.getaClothingProduct(ProductCode);
        }

        public List<ElectronicsProduct> GetElectronicsProducts(String ProductCode)
        {
            return productGetway.getElectronicProduct(ProductCode);
        }

        public List<DailyNeedProduct> GetADailyNeedProuct(String productCode)
        {
            return productGetway.getADailyNeedProduct(productCode);
        }
        public List<MobileProduct> GetAMobileProduct(String productCode)
        {
            return productGetway.getMobileProduct(productCode);
        }



       public List<Product> GetProduct(String name)
       {
            return productGetway.getAllProductOfThisName(name);
       }

        public Boolean isThisCodeAlreadyExist(String code)
        {
            List<Product> productList = productGetway.getAllProduct(code);
            if (productList.Count > 0)
            {
                return true;
            }
            return false;
        }

        public Product getProductByProductId(int id)
        {
            List<Product> list = productGetway.GetAllProduct(id);
            return list[0];
        }

        public List<ProductC> GetProducts(int secId,String CategoryName)
        {
            //  return productGetway.getAllProductOfthisCategory(secId, CategoryName);
            return null;
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

        public List<Product> GetAllProduct()
        {
            return productGetway.GetAllProduct();
        }
    }
}