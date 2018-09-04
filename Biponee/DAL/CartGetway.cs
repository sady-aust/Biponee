using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Biponee.DLL
{
    public class CartGetway
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["biponeeDbConnectioon"].ConnectionString;

        public int InsertCartItem(CartC cart)
        {


            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "INSERT INTO carts VALUES (" + cart.ProductId + "," + cart.Qunaity + "," + cart.UserID + "," + cart.Status +",'"+cart.Size+"')";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;

        }
        public List<CartC> getcartItems(int uId)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM carts WHERE UserId = "+uId+"AND Status = 0";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CartC> list = new List<CartC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["CartItemId"]);
                int productId = Convert.ToInt32(reader["ProductId"]);
                int Quantity = Convert.ToInt32(reader["Quantity"]);
                int UserId = Convert.ToInt32(reader["UserId"]);
                int status = Convert.ToInt32(reader["Status"]);
                String size = reader["Size"].ToString();
               


                list.Add(new CartC(id,productId,Quantity,UserId,status, size));
            }

            return list;
        }

        //SELECT products.ImageLink,products.ProductName,products.Price ,carts.Quantity FROM carts INNER JOIN products ON products.ProductId = carts.ProductId WHERE carts.UserId=1 AND carts.Status=0;

        public List<CartC> getAllCartItemWithImage(int UserId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT products.ImageLink,products.ProductName,products.Price ,carts.Quantity,carts.Size FROM carts INNER JOIN products ON products.ProductId = carts.ProductId WHERE carts.UserId =" + UserId +"AND carts.Status = 0";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CartC> list = new List<CartC>();

            while (reader.Read())
            {
              
                String imgLink =reader["ImageLink"].ToString();
                String name = reader["ProductName"].ToString();
                String price = reader["Price"].ToString();
                int quanity = Convert.ToInt32((reader["Quantity"].ToString()));
                String size = reader["Size"].ToString();


                list.Add(new CartC(quanity,imgLink,price,name,size));
            }

            return list;


        }
        

        

    }
}