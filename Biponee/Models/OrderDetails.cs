using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class OrderDetails
    {
        public OrderC Order{get;set;}
        public List<CartItemC> Carts { get; set; }

        public OrderDetails(OrderC order, List<CartItemC> carts)
        {
            Order = order;
            Carts = carts;
        }
    }
}