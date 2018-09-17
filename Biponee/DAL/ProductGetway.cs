using Biponee.Models;
using Biponee.Models.Products;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Biponee.DLL
{
    public class ProductGetway
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["biponeeDbConnectioon"].ConnectionString;

        public int insertClothingProduct(ClothingProduct product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "INSERT INTO products VALUES ('" + product.ProductName + "','" + product.ProductCode + "'," + product.SectionId + "," + product.Price + ",'" + product.Category + "','" + product.Description + "','" + product.ImageLink + "'," + product.LCount + "," + product.MCount + "," + product.XLCount + "," + product.XXLCount+",null" + ",'" + product.BrandName + "')";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }

        public int insertElectronicsProduct(ElectronicsProduct product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "INSERT INTO products VALUES ('" + product.ProductName + "','" + product.ProductCode + "'," + product.SectionId + "," + product.Price + ",'" + product.Category + "','" + product.Description + "','" + product.ImageLink + "',null,null,null,null,"  + product.Quantity + ",'" + product.BrandName + "')";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }

        public int insertDailyNeedsProduct(DailyNeedProduct product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "INSERT INTO products VALUES ('" + product.ProductName + "','" + product.ProductCode + "'," + product.SectionId + "," + product.Price + ",'" + product.Category + "','" + product.Description + "','" + product.ImageLink + "',null,null,null,null," + product.Quantity + ",'" + product.BrandName + "')";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }
        public int insertMobileProduct(MobileProduct product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "INSERT INTO products VALUES ('" + product.ProductName + "','" + product.ProductCode + "'," + product.SectionId + "," + product.Price + ",'" + product.Category + "','" + product.Description + "','" + product.ImageLink + "',null,null,null,null," + product.Quantity + ",'" + product.BrandName + "')";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }


        public List<ClothingProduct> getAllClothingProduct()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = 1";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

          
                List<ClothingProduct> list = new List<ClothingProduct>();

                while (reader.Read())
                {
                    int id = (int)reader["ProductId"];
                    String name = reader["ProductName"].ToString();
                    String code = reader["ProductCode"].ToString();
                    int secId = (int)reader["SectionId"];
                    Double price = Convert.ToDouble(reader["Price"].ToString());
                    String category = reader["Category"].ToString();
                    String description = reader["Description"].ToString();
                    String imgLink = reader["ImageLink"].ToString();
                    int lCount = (int)reader["LCount"];
                    int mCount = (int)reader["MCount"];
                    int xlCount = (int)reader["XLCount"];
                    int xxlCount = (int)reader["XXLCount"];
                    String brandName = reader["BrandName"].ToString();

                list.Add(new ClothingProduct(id,name, code, secId, price, category, description, imgLink, brandName, lCount, mCount, xlCount,xxlCount));
                }

                return list;
            }

        public List<Product> getAllProduct(String pCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE ProductCode ='"+ pCode + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Product> list = new List<Product>();

            while (reader.Read())
            {
                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int lCount = (int)reader["LCount"];
                int mCount = (int)reader["MCount"];
                int xlCount = (int)reader["XLCount"];
                int xxlCount = (int)reader["XXLCount"];
                String brandName = reader["BrandName"].ToString();

                list.Add(new Product(id, name, code, secId, price, category, description, imgLink, brandName));
            }

            return list;
        }


        public List<ElectronicsProduct> getElectronicProduct()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = 2";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            List<ElectronicsProduct> list = new List<ElectronicsProduct>();

            while (reader.Read())
            {
                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int Quantity = (int)reader["Quantity"];
                String brandName = reader["BrandName"].ToString();
                list.Add(new ElectronicsProduct(id,name, code, secId, price, Quantity, category, description, imgLink, brandName));
            }

            return list;
        }

        public List<ElectronicsProduct> getElectronicProduct(String productCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = 2 AND ProductCode='"+productCode+"'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            List<ElectronicsProduct> list = new List<ElectronicsProduct>();

            while (reader.Read())
            {

                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int Quantity = (int)reader["Quantity"];
                String brandName = reader["BrandName"].ToString();
                list.Add(new ElectronicsProduct(id,name, code, secId, price, Quantity, category, description, imgLink, brandName));
            }

            return list;
        }

        public List<DailyNeedProduct> getDailyNeedProduct(String productCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = 3 AND ProductCode='" + productCode + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            List<DailyNeedProduct> list = new List<DailyNeedProduct>();

            while (reader.Read())
            {

                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int Quantity = (int)reader["Quantity"];
                String brandName = reader["BrandName"].ToString();
                list.Add(new DailyNeedProduct(id, name, code, secId, price, Quantity, category, description, imgLink, brandName));
            }

            return list;
        }

        public List<MobileProduct> getMobileProduct(String productCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = 4 AND ProductCode='" + productCode + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            List<MobileProduct> list = new List<MobileProduct>();

            while (reader.Read())
            {

                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int Quantity = (int)reader["Quantity"];
                String brandName = reader["BrandName"].ToString();
                list.Add(new MobileProduct(id, name, code, secId, price, Quantity, category, description, imgLink, brandName));
            }

            return list;
        }


        public List<DailyNeedProduct> getADailyNeedProduct()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = 3";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            List<DailyNeedProduct> list = new List<DailyNeedProduct>();

            while (reader.Read())
            {
                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int Quantity = (int)reader["Quantity"];
                String brandName = reader["BrandName"].ToString();
                list.Add(new DailyNeedProduct(id,name, code, secId, price, Quantity, category, description, imgLink, brandName));
            }

            return list;
        }

        public List<DailyNeedProduct> getADailyNeedProduct(String productCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = 3 AND ProductCode = '"+ productCode+"'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            List<DailyNeedProduct> list = new List<DailyNeedProduct>();

            while (reader.Read())
            {
                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int Quantity = (int)reader["Quantity"];
                String brandName = reader["BrandName"].ToString();
                list.Add(new DailyNeedProduct(id,name, code, secId, price, Quantity, category, description, imgLink, brandName));
            }

            return list;
        }

        public List<MobileProduct> getAllMobileProduct()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = 4";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            List<MobileProduct> list = new List<MobileProduct>();

            while (reader.Read())
            {
                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int Quantity = (int)reader["Quantity"];
                String brandName = reader["BrandName"].ToString();
                list.Add(new MobileProduct(id,name, code, secId, price, Quantity, category, description, imgLink, brandName));
            }

            return list;
        }


        public List<MobileProduct> getAMobileProduct(String productCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = 4 AND ProductCode ='"+productCode+"'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            List<MobileProduct> list = new List<MobileProduct>();

            while (reader.Read())
            {
                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int Quantity = (int)reader["Quantity"];
                String brandName = reader["BrandName"].ToString();
                list.Add(new MobileProduct(id,name, code, secId, price, Quantity, category, description, imgLink, brandName));
            }

            return list;
        }



        public List<ClothingProduct> getaClothingProduct(String productCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE ProductCode ='" + productCode + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

          
                List<ClothingProduct> list = new List<ClothingProduct>();

                while (reader.Read())
                {
                int id = (int)reader["ProductId"];
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                Double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                int lCount = (int)reader["LCount"];
                int mCount = (int)reader["MCount"];
                int xlCount = (int)reader["XLCount"];
                int xxlCount = (int)reader["XXLCount"];
                String brandName = reader["BrandName"].ToString();

                list.Add(new ClothingProduct(id,name, code, secId, price, category, description, imgLink, brandName, lCount, mCount, xlCount, xxlCount));
                }

                return list;
            
        }
       


      

        public List<Product> GetAllProduct()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Product> list = new List<Product>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"]);
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                double price =Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                String lCount = reader["LCount"].ToString();
                String mCount = reader["MCount"].ToString();
                String xlCount = reader["XLCount"].ToString();
                String xxlCount = reader["XXLCount"].ToString();
                String quantiy = reader["Quantity"].ToString();
                String brandName = reader["BrandName"].ToString();
                list.Add(new Product(id,name,code,secId,price,category,description,imgLink,brandName));
            }

            return list;
        }
        public List<Product> GetAllProduct(int pid)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE ProductId ="+ pid;
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Product> list = new List<Product>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"]);
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                double price = Convert.ToDouble(reader["Price"].ToString());
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                String lCount = reader["LCount"].ToString();
                String mCount = reader["MCount"].ToString();
                String xlCount = reader["XLCount"].ToString();
                String xxlCount = reader["XXLCount"].ToString();
                String quantiy = reader["Quantity"].ToString();
                String brandName = reader["BrandName"].ToString();
                list.Add(new Product(id, name, code, secId, price, category, description, imgLink, brandName));
            }

            return list;
        }

        public int UpdateProductInfo(ClothingProduct product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "UPDATE products SET productName = '" + product.ProductName + "',ProductCode='" + product.ProductCode +
                "',Price=" + product.Price + ",Category ='" + product.Category + "',Description='" + product.Description + "',LCount=" + product.LCount + ",MCount=" +
                product.MCount + ",XLCount=" + product.XLCount + ",XXLCount=" + product.XXLCount + ",BrandName='" + product.BrandName + "' WHERE ProductId="+product.ProductId;
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;

        }

        public int UpdateProductInfo(ElectronicsProduct product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "UPDATE products SET productName = '" + product.ProductName + "',ProductCode='" + product.ProductCode +
                "',Price=" + product.Price + ",Category ='" + product.Category + "',Description='" + product.Description + "',Quantity=" + product.Quantity +
               ",BrandName='" + product.BrandName + "' WHERE ProductId=" + product.ProductId;
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }

        public int UpdateProductInfo(DailyNeedProduct product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "UPDATE products SET productName = '" + product.ProductName + "',ProductCode='" + product.ProductCode +
                "',Price=" + product.Price + ",Category ='" + product.Category + "',Description='" + product.Description + "',Quantity=" + product.Quantity +
               ",BrandName='" + product.BrandName + "' WHERE ProductId=" + product.ProductId;
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }

        public int UpdateProductInfo(MobileProduct product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "UPDATE products SET productName = '" + product.ProductName + "',ProductCode='" + product.ProductCode +
                "',Price=" + product.Price + ",Category ='" + product.Category + "',Description='" + product.Description + "',Quantity=" + product.Quantity +
               ",BrandName='" + product.BrandName + "' WHERE ProductId=" + product.ProductId;
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }

        public int DeleteProduct(int productId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "DELETE FROM products WHERE ProductId=" + productId;
            SqlCommand command = new SqlCommand(Query,connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

       

       
    }
}