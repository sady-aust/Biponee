using Biponee.BLL;
using Biponee.Models;
using Biponee.Models.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Biponee.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager();
        SectionManager sectionManager = new SectionManager();
        ProductManager productManager = new ProductManager();

      

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminPage()
        {

            int id = Convert.ToInt32(Session["adminId"]);
            return View();
        }
        public ActionResult AddProduct()
        {
           
            List<SectionC> sections = sectionManager.getAllSections();
            Session["sectionInfo"] = sections;
            List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
            List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
            List<DailyNeedProduct> dailyNeedProducts = productManager.GetAllDailyNeedProuct();
            List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();
            return View(new AdminSectionC(sections, clothingProducts,electronicsProducts,dailyNeedProducts,mobileProducts));
        }
        [HttpPost]
        public ActionResult AddProduct(ClothingProduct product,ElectronicsProduct electronics,DailyNeedProduct dailyNeeds,MobileProduct mobile,int SectionId)
        {
             WebImage photo = null;
             var newFileName = "";
             var imagePath = "";
             photo = WebImage.GetImageFromRequest();
             if (product.ProductName != null && product.SectionId > 0 && product.ProductCode != null && product.Price != 0 && photo != null)
             {
                 if (!productManager.isThisCodeAlreadyExist(product.ProductCode))
                 {
                     photo.FileName = product.ProductCode + "img";
                     newFileName = photo.FileName;


                     imagePath = @"Style/ProductImage/" + product.SectionId + @"/" + newFileName;

                     photo.Save(@"~/" + imagePath);
                     product.ImageLink = imagePath;

                    Boolean res = false;

                    if (SectionId == 1)
                    {
                        res = productManager.InsertClothingProduct(product);
                    }
                    else if (SectionId == 2)
                    {
                        res = productManager.InsertElectronicsProduct(electronics);
                    }
                    else if (SectionId == 3)
                    {
                        res = productManager.InsertDailyNeedsProduct(dailyNeeds);
                    }
                    else if (SectionId == 4)
                    {
                        res = productManager.InsertMobileProduct(mobile);
                    }

                    if (res)
                     {
                        ViewBag.insertResult = "1";

                         List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
                         List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
                         List<DailyNeedProduct> dailyNeedProducts = productManager.GetAllDailyNeedProuct();
                         List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();
                         return View(new AdminSectionC((AdminC)Session["adminIndo"],(List<SectionC>) Session["sectionInfo"], clothingProducts,electronicsProducts,dailyNeedProducts,mobileProducts));
                     }
                     else
                     {
                         List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
                         List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
                         List<DailyNeedProduct> dailyNeedProducts = productManager.GetAllDailyNeedProuct();
                         List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();
                         return View(new AdminSectionC((AdminC)Session["adminIndo"], (List<SectionC>)Session["sectionInfo"], clothingProducts, electronicsProducts, dailyNeedProducts, mobileProducts));
                     }
                 }
                 else
                 {
                    ViewBag.insertResult = "2";
                     List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
                     List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
                     List<DailyNeedProduct> dailyNeedProducts = productManager.GetAllDailyNeedProuct();
                     List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();
                     return View(new AdminSectionC((AdminC)Session["adminIndo"], (List<SectionC>)Session["sectionInfo"], clothingProducts, electronicsProducts, dailyNeedProducts, mobileProducts));
                 }
             }
             else
             {
                ViewBag.insertResult = "3";
                 List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
                 List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
                 List<DailyNeedProduct> dailyNeedProducts = productManager.GetAllDailyNeedProuct();
                 List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();
                 return View(new AdminSectionC((AdminC)Session["adminIndo"], (List<SectionC>)Session["sectionInfo"], clothingProducts, electronicsProducts, dailyNeedProducts, mobileProducts));
             }
           

           
            
        }


       
        public ActionResult Orders(int id)
        {
            AdminC admin = adminManager.getAdminInfo(id);
            return View(admin);
        }
        public ActionResult Charts(int id)
        {
            AdminC admin = adminManager.getAdminInfo(id);
            return View(admin);
           
        }

        public JsonResult getAdmin(String Email,String Password)
        {
           int idNo = adminManager.isExist(Email, Password);

            if (idNo >0)
            {
                AdminC loggingAdmin = adminManager.getAdminInfo(idNo);
                return Json(loggingAdmin, JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);

        }

       /* public JsonResult getAllProduct(int SectionId)
        {
            List<ProductC> list = productManager.GetAllProductThisSection(SectionId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }*/

        public JsonResult  getProductOfThisCode(int SectionId, String Code)
        {
           

            if (SectionId == 1)
            {
                List<ClothingProduct> list = productManager.getAClothingProduct(Code);
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            return Json("Moro");
        }
    }
}