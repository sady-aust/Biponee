using Biponee.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class UserSectionC
    {
        public List<SectionC> Sections { get; set; }
        public List<MobileProduct> MobileProduct { get; set; }
        public List<ElectronicsProduct> ElectronicProducts { get; set; }
        public List<DailyNeedProduct> DailyNeedProducts { get; set; }
        public List<ClothingProduct> ClothingProducts { get; set; }

        public UserSectionC(List<SectionC> sections, List<MobileProduct> mobileProduct, List<ElectronicsProduct> electronicProducts, List<DailyNeedProduct> dailyNeedProducts, List<ClothingProduct> clothingProducts)
        {
            Sections = sections;
            MobileProduct = mobileProduct;
            ElectronicProducts = electronicProducts;
            DailyNeedProducts = dailyNeedProducts;
            ClothingProducts = clothingProducts;
        }
    }
}