using Biponee.Models;
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

        public int insertProduct(ProductC product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "INSERT INTO products VALUES ('" + product.ProductName + "','" + product.ProductCode + "'," + product.SectionId + ",'" + product.Price + "','" + product.Category + "','" + product.Description + "','" + product.ImageLink + "','" + product.LCount + "','" + product.MCount + "','" + product.XLCount + "','" + product.XXLCount + "','" + product.Quantity + "')";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }

        public List<ProductC> getAllProduct()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<ProductC> list = new List<ProductC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"]);
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                String price = reader["Price"].ToString();
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                String lCount = reader["LCount"].ToString();
                String mCount = reader["MCount"].ToString();
                String xlCount = reader["XLCount"].ToString();
                String xxlCount = reader["XXLCount"].ToString();
                String quantiy = reader["Quantity"].ToString();

                list.Add(new ProductC(id, name, code, secId, price, category, description, imgLink, lCount, mCount, xlCount, xxlCount, quantiy));
            }

            return list;
        }

        public List<ProductC> getAllOfThisSection(int mysectionId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = " + mysectionId;

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<ProductC> list = new List<ProductC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"]);
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                String price = reader["Price"].ToString();
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                String lCount = reader["LCount"].ToString();
                String mCount = reader["MCount"].ToString();
                String xlCount = reader["XLCount"].ToString();
                String xxlCount = reader["XXLCount"].ToString();
                String quantiy = reader["Quantity"].ToString();

                list.Add(new ProductC(id, name, code, secId, price, category, description, imgLink, lCount, mCount, xlCount, xxlCount, quantiy));
            }

            return list;
        }

        public List<ProductC> getProducts(int mysectionId, String productCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId = " + mysectionId + " AND ProductCode ='" + productCode + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<ProductC> list = new List<ProductC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"]);
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                String price = reader["Price"].ToString();
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                String lCount = reader["LCount"].ToString();
                String mCount = reader["MCount"].ToString();
                String xlCount = reader["XLCount"].ToString();
                String xxlCount = reader["XXLCount"].ToString();
                String quantiy = reader["Quantity"].ToString();
                list.Add(new ProductC(id, name, code, secId, price, category, description, imgLink, lCount, mCount, xlCount, xxlCount, quantiy));
            }

            return list;
        }
        public List<ProductC> getProductWithProductCode(String productCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE ProductCode='" + productCode + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<ProductC> list = new List<ProductC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"]);
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                String price = reader["Price"].ToString();
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                String lCount = reader["LCount"].ToString();
                String mCount = reader["MCount"].ToString();
                String xlCount = reader["XLCount"].ToString();
                String xxlCount = reader["XXLCount"].ToString();
                String quantiy = reader["Quantity"].ToString();
                list.Add(new ProductC(id, name, code, secId, price, category, description, imgLink, lCount, mCount, xlCount, xxlCount, quantiy));
            }

            return list;
        }

        public List<ProductC> getProducts(int Productid)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE ProductId='" + Productid + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<ProductC> list = new List<ProductC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"]);
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                String price = reader["Price"].ToString();
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                String lCount = reader["LCount"].ToString();
                String mCount = reader["MCount"].ToString();
                String xlCount = reader["XLCount"].ToString();
                String xxlCount = reader["XXLCount"].ToString();
                String quantiy = reader["Quantity"].ToString();
                list.Add(new ProductC(id, name, code, secId, price, category, description, imgLink, lCount, mCount, xlCount, xxlCount, quantiy));
            }

            return list;
        }

        public List<ProductC> getAllProductOfthisCategory(int SectionId,String Category)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE SectionId=" + SectionId + " AND Category ='"+ Category + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<ProductC> list = new List<ProductC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"]);
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                String price = reader["Price"].ToString();
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                String lCount = reader["LCount"].ToString();
                String mCount = reader["MCount"].ToString();
                String xlCount = reader["XLCount"].ToString();
                String xxlCount = reader["XXLCount"].ToString();
                String quantiy = reader["Quantity"].ToString();
                list.Add(new ProductC(id, name, code, secId, price, category, description, imgLink, lCount, mCount, xlCount, xxlCount, quantiy));
            }

            return list;
        }

        public List<ProductC> getProducts(String sName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM products WHERE ProductName LIKE'%" + sName + "%'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<ProductC> list = new List<ProductC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"]);
                String name = reader["ProductName"].ToString();
                String code = reader["ProductCode"].ToString();
                int secId = (int)reader["SectionId"];
                String price = reader["Price"].ToString();
                String category = reader["Category"].ToString();
                String description = reader["Description"].ToString();
                String imgLink = reader["ImageLink"].ToString();
                String lCount = reader["LCount"].ToString();
                String mCount = reader["MCount"].ToString();
                String xlCount = reader["XLCount"].ToString();
                String xxlCount = reader["XXLCount"].ToString();
                String quantiy = reader["Quantity"].ToString();
                list.Add(new ProductC(id, name, code, secId, price, category, description, imgLink, lCount, mCount, xlCount, xxlCount, quantiy));
            }

            return list;
        }

    }
}