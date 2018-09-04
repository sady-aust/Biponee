using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Biponee.DLL
{
    public class UserGetway
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["biponeeDbConnectioon"].ConnectionString;
        public int InsertUser(UserC user)
        {
           
          
                SqlConnection connection = new SqlConnection(connectionString);
                String Query = "INSERT INTO users VALUES ('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + user.Password +"')";
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                
                int res = command.ExecuteNonQuery();
                connection.Close();
                return res;
            
        }

        public List<UserC> getUser(String email,String password)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM users WHERE Email = '" + email + "' AND Password = '" + password + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<UserC> list = new List<UserC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["UserId"]);
                String firstName = reader["FirstName"].ToString();
                String lastName = reader["LastName"].ToString();
                String Email = reader["Email"].ToString();
                String Password = reader["Password"].ToString();

                list.Add(new UserC(id, firstName, lastName, Email, Password));
            }

            return list;
        }

        public List<UserC> getUser(String email)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM users WHERE Email = '" + email + "'";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<UserC> list = new List<UserC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["UserId"]);
                String firstName = reader["FirstName"].ToString();
                String lastName = reader["LastName"].ToString();
                String Email = reader["Email"].ToString();
                String Password = reader["Password"].ToString();

                list.Add(new UserC(id, firstName, lastName, Email, Password));
            }

            return list;
        }

    }
}