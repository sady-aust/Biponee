using System;
using System.Collections.Generic;
using Biponee.BLL;
using Biponee.Models;
using System.Linq;
using System.Web;
using Biponee.DAL;

namespace Biponee.BLL
{
    public class OrderManager
    {
        OrderGetway orderGetway = new OrderGetway();

        public Boolean InsertOrder(OrderC order)
        {
            if (orderGetway.InsertOrder(order)>0)
            {
                return true;
            }
            return false;
        }

        public int GetLastOrderID()
        {
            return orderGetway.GetLastInsertedOrderID();
        }

        public List<OrderC> getAllOrder(int uId)
        {
            return orderGetway.getAllOrders(uId);
        }
    }
}