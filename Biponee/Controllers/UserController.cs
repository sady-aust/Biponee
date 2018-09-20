using Biponee.BLL;
using Biponee.Models;
using Biponee.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biponee.Controllers
{
    public class UserController : Controller
    {

        ProductManager productManager = new ProductManager();
        SectionManager sectionManager = new SectionManager();
        UserManager userManager = new UserManager();
       
        // GET: User
        public ActionResult Index()
        {
            List<ClothingProduct> clothingProduct = productManager.GetAllCLothingProduct();
            List<DailyNeedProduct> dailyNeedProducts = productManager.GetADailyNeedProuct();
            List<ElectronicsProduct> electronicsProduct = productManager.GetAllElectroinicProduct();
            List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();

            List<SectionC> sections = sectionManager.getAllSections();
          
            return View(new UserSectionC(sections,mobileProducts,electronicsProduct,dailyNeedProducts, clothingProduct));
        }

       
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult CustmerAccount()
        {
            return View();
        }

        public ActionResult ViewCart()
        {
            List<SectionC> sections = sectionManager.getAllSections();
            ViewBag.sections = sections;
            return View();
        }

        public ActionResult ProductPage(String code,int sectionId)
        {
           
            List<SectionC> sections = sectionManager.getAllSections();
            ViewBag.sections = sections;

            if(sectionId == 1)
            {
                 ClothingProduct clothingProduct= productManager.getAClothingProduct(code)[0];
                 ViewBag.product = clothingProduct;
            }
            else if(sectionId == 2)
            {
                ElectronicsProduct electronicsProduct = productManager.GetElectronicsProducts(code)[0];
                 ViewBag.product = electronicsProduct;

            }
            else if (sectionId == 3)
            {
                DailyNeedProduct dailyNeedProduct = productManager.GetADailyNeedProuct(code)[0];
                ViewBag.product = dailyNeedProduct;

            }
            else if (sectionId == 4)
            {
                MobileProduct mobileProduct = productManager.GetAllMobileProduct(code)[0];
                ViewBag.product = mobileProduct;

            }


            return View();
        }
        public ActionResult Products(int id, String ProductName, String category, Boolean searchInCategory = false)
        {
            if (ProductName != null)
            {
              /*  List<ProductC> productList = productManager.GetProducts(ProductName);
                List<SectionC> sections = sectionManager.getAllSections();
                ViewBag.sections = sections;
                return View(productList);*/
            }

            else
            {
                if (!searchInCategory)
                {
                    List<SectionC> sections = sectionManager.getAllSections();
                    ViewBag.sections = sections;
                    List<ClothingProduct> clothingproductList = null;
                    List<ElectronicsProduct> electronicsProductList = null;
                    List<DailyNeedProduct> dailyNeedProductList = null;
                    List<MobileProduct> mobileProductList = null;
                    if (id == 1)
                    {
                        clothingproductList = productManager.GetAllCLothingProduct();
                      
                    }
                    else if(id == 2)
                    {
                        electronicsProductList = productManager.GetAllElectroinicProduct();
                      
                    }
                    else if (id == 3)
                    {
                         dailyNeedProductList = productManager.GetADailyNeedProuct();
                        
                    }
                    else if(id == 4)
                    {
                         mobileProductList = productManager.GetAllMobileProduct();
                       
                    }

                    View(new UserSectionC(null, mobileProductList, electronicsProductList,dailyNeedProductList,clothingproductList));
                  
                   
                 
                }
                else
                {
                    List<ProductC> productList = productManager.GetProducts(id, category);
                    List<SectionC> sections = sectionManager.getAllSections();
                    ViewBag.sections = sections;
                    return View(productList);
                }
            }

            return View();
        }


        public JsonResult userSignUp(String FirstName,String LastName,String email,String Password)
        {
            UserC user = new UserC(FirstName, LastName, email, Password);
           Boolean res = userManager.insertUserInfo(user);

            if (res)
            {
                UserC loginuser = userManager.getetUser(email, Password);
                return Json(loginuser, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
           
        }

        public JsonResult userLogIn(String Email,String Password)
        {
            UserC res = userManager.getetUser(Email, Password);
         
            return Json(res, JsonRequestBehavior.AllowGet);

        }

        public JsonResult PlaceOrder(OrderC order)
        {
            return Json(null,JsonRequestBehavior.AllowGet);
        }
        public JsonResult allProduct()
        {
            List<Product> productList = productManager.GetAllProduct();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getclothProduct(String Code)
        {
            ClothingProduct clothingProduct = productManager.getAClothingProduct(Code)[0];
            return Json(clothingProduct, JsonRequestBehavior.AllowGet);
        }
    }
}