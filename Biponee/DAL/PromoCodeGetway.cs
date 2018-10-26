using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Biponee.DAL
{
    public class PromoCodeGetway
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["biponeeDbConnectioon"].ConnectionString;

        public int InsertPromoCode(PromoCode promocode)

        {
            promocode.isApplied = false;
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "INSERT INTO promocodes VALUES ('" + promocode.Code + "','" + promocode.Email + "'," + promocode.Discount + ",'" + promocode.isApplied +  "')";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }
    }
}