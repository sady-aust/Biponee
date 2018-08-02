using Biponee.DLL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.BLL
{
    public class CartManager
    {
        CartGetway cartGetway = new CartGetway();

        public Boolean insertItem(CartC cartC)
        {
            if (cartGetway.InsertCartItem(cartC) > 0)
            {
                return true;
            }

            return false;
        }

        public List<CartC> getAllItem(int Uid)
        {
            return cartGetway.getcartItems(Uid);
        }

        public List<CartC> getAllItemWithImage(int uId)
        {
            return cartGetway.getAllCartItemWithImage(uId);
        }

    }
}