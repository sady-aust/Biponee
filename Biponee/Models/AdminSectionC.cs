using Biponee.Models.Products;
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
        public List<ClothingProduct> ClothingProducts { get; set; }
        public List<ElectronicsProduct> ElectronicProducts { get; set; }
        public List<DailyNeedProduct> DailyNeedProducts { get; set; }

        public List<MobileProduct> MobileProduct { get; set; }


      
        public AdminSectionC(AdminC admin, List<SectionC> sections, List<ClothingProduct> clothingProducts, List<ElectronicsProduct> electronicProducts, List<DailyNeedProduct> dailyNeedProducts, List<MobileProduct> mobileProduct)
        {
            this.Admin = admin;
            Sections = sections;
            ClothingProducts = clothingProducts;
            ElectronicProducts = electronicProducts;
            DailyNeedProducts = dailyNeedProducts;
            MobileProduct = mobileProduct;
        }

        public AdminSectionC(List<SectionC> sections, List<ClothingProduct> clothingProducts, List<ElectronicsProduct> electronicProducts, List<DailyNeedProduct> dailyNeedProducts, List<MobileProduct> mobileProduct)
        {
            Sections = sections;
            ClothingProducts = clothingProducts;
            ElectronicProducts = electronicProducts;
            DailyNeedProducts = dailyNeedProducts;
            MobileProduct = mobileProduct;
        }
    }
}