using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Biponee.DLL
{
    public class AdminGetway
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["biponeeDbConnectioon"].ConnectionString;

        public List<AdminC> getAdminByEmailAnsPassword(String email,String Password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM admins WHERE Email = '" + email + "' AND Password = '" + Password + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<AdminC> list = new List<AdminC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["AdminID"]);
                String adminEmail = reader["Email"].ToString();
                String password = reader["Password"].ToString();
                String firstName = reader["FirstName"].ToString();
                String lastName = reader["LastName"].ToString();

               list.Add( new AdminC(id, adminEmail, password, firstName, lastName));
            }

            return list;
        }

        public List<AdminC> getAdminById(int adminId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM admins WHERE AdminID = " + adminId;

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<AdminC> list = new List<AdminC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["AdminID"]);
                String adminEmail = reader["Email"].ToString();
                String password = reader["Password"].ToString();
                String firstName = reader["FirstName"].ToString();
                String lastName = reader["LastName"].ToString();

                list.Add(new AdminC(id, adminEmail, password, firstName, lastName));
            }

            return list;
        }
    }
}