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

        public PromoCode GetPromoCode(String code,String email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM promocodes WHERE email = '" + email + "' AND promocode = '" + code + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<PromoCode> list = new List<PromoCode>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["promoId"]);
                String PromoCode = reader["promocode"].ToString();
                String Email = reader["email"].ToString();
                int Discount = Convert.ToInt32(reader["discount"].ToString());
                Boolean IsApplied = Convert.ToBoolean(reader["isapplied"].ToString());

                list.Add(new PromoCode(id,PromoCode,Email,Discount,IsApplied));
            }

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        public int UpdatePromoCode(String code, String email)
        {
         
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "UPDATE promocodes SET isapplied ='"+ true +"' WHERE email ='"+email+ "' AND promocode = '"+code+"'";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }
    }
}