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

        public bool isValid(String code,String email)
        {
           PromoCode aPromoCode= promoCodeGetway.GetPromoCode(code, email);

            if (aPromoCode == null)
            {
                return false;
            }
            else {
                if (aPromoCode.isApplied)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public PromoCode getPromocode(String code, String email)
        {
            PromoCode aPromoCode = promoCodeGetway.GetPromoCode(code, email);

            return aPromoCode;
        }

        public bool ApplyPromoCode(String code,String mail)
        {
            return promoCodeGetway.UpdatePromoCode(code, mail)>0? true:false;
        }
    }
}