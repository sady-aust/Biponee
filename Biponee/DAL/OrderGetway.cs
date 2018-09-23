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
            String Query = "INSERT INTO orders VALUES ('" + order.FirstName + "','" + order.LastName + "','" + order.Phone + "','" + order.Address + "','" + order.State + "','" + order.City + "'," + order.UserId + ",'" + order.PaymentMethod + "'," + order.Total + ")";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }
    }
}