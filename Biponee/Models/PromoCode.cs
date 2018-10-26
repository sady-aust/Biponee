using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class PromoCode
    {

        public int PromoId { get; set; }
        public String Code { get; set; }
        public String Email { get; set; }
        public int Discount { get; set; }
        public Boolean isApplied { get; set; }

        public PromoCode(int promoId, string code, string email, int discount, bool isApplied)
        {
            PromoId = promoId;
            Code = code;
            Email = email;
            Discount = discount;
            this.isApplied = isApplied;
        }

        public PromoCode(string code, string email, int discount, bool isApplied)
        {
            Code = code;
            Email = email;
            Discount = discount;
            this.isApplied = isApplied;
        }

        public PromoCode()
        {
        }
    }
}