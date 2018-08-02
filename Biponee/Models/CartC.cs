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
        public String ImageLink { get; set; }
        public String Price { get; set; }
        public String name { get; set; }

        public CartC(int cartItemId, int productId, int qunaity, int userID, int status,String imgLink,String price)
        {
            CartItemId = cartItemId;
            ProductId = productId;
            Qunaity = qunaity;
            UserID = userID;
            Status = status;
            ImageLink = imgLink;
            Price = price;
        }

        public CartC(int productId, int qunaity, int userID, int status, String imgLink, String price)
        {
           
            ProductId = productId;
            Qunaity = qunaity;
            UserID = userID;
            Status = status;
            ImageLink = imgLink;
            Price = price;
        }

        public CartC(int qunaity, string imageLink, string price, string name)
        {
            Qunaity = qunaity;
            ImageLink = imageLink;
            Price = price;
            this.name = name;
        }

        public CartC()
        {
        }
    }
}