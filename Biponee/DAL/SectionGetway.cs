using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Biponee.DLL
{
    public class SectionGetway
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["biponeeDbConnectioon"].ConnectionString;
        public List<SectionC> getAllSections()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "SELECT * FROM sections";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<SectionC> list = new List<SectionC>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["SectionID"]);
                String name = reader["SectionName"].ToString();
               

                list.Add(new SectionC(id,name));
            }

            return list;
        }
    }
}
