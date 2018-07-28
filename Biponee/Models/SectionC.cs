using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class SectionC
    {
        public int SectionID { get; set; }
        public String SectionName { get; set; }

        public SectionC(int sectionID, string sectionName)
        {
            SectionID = sectionID;
            SectionName = sectionName;
        }

        public SectionC()
        {
        }
    }
}