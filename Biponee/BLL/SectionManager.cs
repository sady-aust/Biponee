using Biponee.DLL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.BLL
{
    public class SectionManager
    {
        SectionGetway sectionGetway = new SectionGetway();

        public List<SectionC> getAllSections()
        {
            return sectionGetway.getAllSections();
        }
    }
}