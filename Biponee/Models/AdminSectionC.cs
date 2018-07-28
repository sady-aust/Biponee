using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class AdminSectionC
    {
        public AdminC Admin { get; set; }
        public List<SectionC> Sections { get; set; }
        public List<ProductC> products { get; set; }
      

        public AdminSectionC(AdminC admin, List<SectionC> sections)
        {
            Admin = admin;
            Sections = sections;
        }

        public AdminSectionC(AdminC admin, List<SectionC> sections,List<ProductC> products)
        {
            this.Admin = admin;
            this.Sections = sections;
            this.products = products;
        }

    }
}