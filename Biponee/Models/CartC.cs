using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class CartC
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Qunaity { get; set; }
        public int UserID { get; set; }
        public int Status { get; set; }
        public String Size { get; set; }


        public String ProductName { get; set; }
        public String ImageLink { get; set; }
        public String Price { get; set; }


        public CartC(int cartItemId, int productId, int qunaity, int userID, int status,String size)
        {
            CartItemId = cartItemId;
            ProductId = productId;
            Qunaity = qunaity;
            UserID = userID;
            Status = status;
            Size = size;
        }

        public CartC(int productId, int qunaity, int userID, int status, String size)
        {
            ProductId = productId;
            Qunaity = qunaity;
            UserID = userID;
            Status = status;
            Size = size;
        }

        public CartC(int quantity,String imageLink,String price,String name,String size)
        {
            Qunaity = quantity;
            ImageLink = imageLink;
            Price = price;
            ProductName = name;
            Size = size;
        }

        public CartC()
        {
        }
    }
}