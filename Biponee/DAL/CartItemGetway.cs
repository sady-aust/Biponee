using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Biponee.DAL
{
    public class CartItemGetway
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["biponeeDbConnectioon"].ConnectionString;
        public int insertCartItem(CartItemC cartItem)
        {
           SqlConnection connection = new SqlConnection(connectionString);
            String Query = "INSERT INTO CartItems VALUES (" + cartItem.OrderId + "," + cartItem.ProductId + ",'" + cartItem.ProductImage + "','"+ cartItem.ProductName+"','" + cartItem.ProductSize + "'," + cartItem.UnitPrice + "," + cartItem.Qty + "," + Convert.ToDouble(cartItem.Subtotal) + ")";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }

        public int UpdatePorductQuantity(CartItemC cartItem)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            if (cartItem.ProductSize == null)
            {
                String QUERY = "UPDATE products SET Quantity =Quantity -" + cartItem.Qty + " WHERE ProductId =" + cartItem.ProductId;
                SqlCommand command = new SqlCommand(QUERY, connection);
                connection.Open();
                int res = command.ExecuteNonQuery();
                connection.Close();

                return res;

            }
            else
            {
                if (cartItem.ProductSize.Equals("L"))
                {
                    String QUERY = "UPDATE products SET LCount =LCount -" + cartItem.Qty + " WHERE ProductId =" + cartItem.ProductId;
                    SqlCommand command = new SqlCommand(QUERY, connection);
                    connection.Open();
                    int res = command.ExecuteNonQuery();
                    connection.Close();

                    return res;

                }
                else if (cartItem.ProductSize.Equals("M"))
                {
                    String QUERY = "UPDATE products SET MCount =MCount -" + cartItem.Qty + " WHERE ProductId =" + cartItem.ProductId;
                    SqlCommand command = new SqlCommand(QUERY, connection);
                    connection.Open();
                    int res = command.ExecuteNonQuery();
                    connection.Close();

                    return res;

                }
                else if (cartItem.ProductSize.Equals("XL"))
                {
                    String QUERY = "UPDATE products SET XLCount =XLCount -" + cartItem.Qty + " WHERE ProductId =" + cartItem.ProductId;
                    SqlCommand command = new SqlCommand(QUERY, connection);
                    connection.Open();
                    int res = command.ExecuteNonQuery();
                    connection.Close();

                    return res;

                }
                else if (cartItem.ProductSize.Equals("XXL"))
                {
                    String QUERY = "UPDATE products SET XXLCount =XXLCount -" + cartItem.Qty + " WHERE ProductId =" + cartItem.ProductId;
                    SqlCommand command = new SqlCommand(QUERY, connection);
                    connection.Open();
                    int res = command.ExecuteNonQuery();
                    connection.Close();

                    return res;

                }
            }

            return -1;
        }
        

    }
}