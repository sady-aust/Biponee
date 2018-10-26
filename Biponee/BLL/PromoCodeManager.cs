using Biponee.DAL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.BLL
{
    public class PromoCodeManager
    {

        PromoCodeGetway promoCodeGetway = new PromoCodeGetway();

        public bool InsertPromoCode(PromoCode promoCode)
        {
            return promoCodeGetway.InsertPromoCode(promoCode) > 0 ? true : false;
        }
    }
}