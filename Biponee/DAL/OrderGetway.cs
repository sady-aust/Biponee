using System;
using System.Collections.Generic;
using Biponee.Models;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Biponee.DAL
{
    public class OrderGetway
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["biponeeDbConnectioon"].ConnectionString;

        public int InsertOrder(OrderC order)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "INSERT INTO orders VALUES ('" + order.FirstName + "','" + order.LastName + "','" + order.Phone + "','" + order.Address + "','" + order.State + "','" + order.City + "'," + order.UserId + ",'" + order.PaymentMethod + "'," + order.Total +",'"+order.Date+ "')";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }

        public int GetLastInsertedOrderID()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String QUERY = "SELECT * FROM orders";

            SqlCommand command = new SqlCommand(QUERY, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<int> list = new List<int>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["orderId"]);
                

                list.Add(id);
            }


            return list[list.Count - 1];
        }

        public List<OrderC> getAllOrders(int UserID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String QUERY = "SELECT * FROM orders WHERE userId ="+UserID;

            SqlCommand command = new SqlCommand(QUERY, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<OrderC> list = new List<OrderC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["orderId"]);
                String firstName = (String)reader["firstName"];
                String lastName = (String)reader["lastName"];
                String phone = (String)reader["phone"];
                String address = (String)reader["address"];
                String state = (String)reader["city"];
                String city = (String)reader["state"];
                int userId = (int)reader["userId"];
                String paymentMethod = (String)reader["paymentmethod"];
                double total = Convert.ToDouble(reader["total"]);
                String date = (String)reader["date"];
                list.Add(new OrderC(id,firstName,lastName,phone,address,state,city,userId,paymentMethod,total, date));
            }


            return list;
        }
    }
}