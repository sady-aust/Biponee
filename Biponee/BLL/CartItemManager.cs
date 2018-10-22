using Biponee.DAL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.BLL
{
    public class CartItemManager
    {
        CartItemGetway cartItemGetway = new CartItemGetway();

        public Boolean insertCartItem(List<CartItemC> cartItem)
        {
            Boolean isAllInserted = true;
            for(int i = 0; i < cartItem.Count; i++)
            {
                if (cartItemGetway.insertCartItem(cartItem[i])<=0 || cartItemGetway.UpdatePorductQuantity(cartItem[i])<=0)
                {
                    isAllInserted = false;
                }
            }

            return isAllInserted;
        }

        public List<CartItemC> getAllCartItems(int orderid)
        {
            return cartItemGetway.getAllCartItem(orderid);
        }
    }
}