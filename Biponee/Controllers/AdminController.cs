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
        OrderManager orderManager = new OrderManager();
        CartItemManager cartManager = new CartItemManager();
        UserManager userManager = new UserManager();
        PromoCodeManager promoCodeManager = new PromoCodeManager();

      

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminPage()
        {

            int id = Convert.ToInt32(Session["adminId"]);
            List<OrderC> allOrders = orderManager.getAllOrder();
            ViewBag.orders = allOrders;

            List<OrderC> sortedOrder = allOrders.OrderBy(o => o.Total).ToList();
            OrderC maximumTotalOrder = sortedOrder[sortedOrder.Count - 1];

           UserC starcustomer = userManager.getAUser(maximumTotalOrder.UserId);

            List<UserC> userList = userManager.getAllUser();
            ViewBag.users = userList;
            ViewBag.starCustomer = starcustomer;
            return View();
        }
        public ActionResult AddProduct()
        {
           
            List<SectionC> sections = sectionManager.getAllSections();
            Session["sectionInfo"] = sections;
            List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
            List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
            List<DailyNeedProduct> dailyNeedProducts = productManager.GetADailyNeedProuct();
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
                    Boolean res = false;
                    if (SectionId == 1)
                    {
                        product.ImageLink = imagePath;
                        res = productManager.InsertClothingProduct(product);
                    }

                   else if (SectionId == 2)
                    {
                        electronics.ImageLink = imagePath;
                        res = productManager.InsertElectronicsProduct(electronics);
                    }

                   else if (SectionId == 3)
                    {
                        dailyNeeds.ImageLink = imagePath;
                        res = productManager.InsertDailyNeedsProduct(dailyNeeds);
                    }

                   else if (SectionId == 4)
                    {
                        mobile.ImageLink = imagePath;
                        productManager.InsertMobileProduct(mobile);
                    }

                    if (res)
                     {
                        ViewBag.insertResult = "1";

                         List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
                         List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
                         List<DailyNeedProduct> dailyNeedProducts = productManager.GetADailyNeedProuct();
                         List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();
                         return View(new AdminSectionC((AdminC)Session["adminIndo"],(List<SectionC>) Session["sectionInfo"], clothingProducts,electronicsProducts,dailyNeedProducts,mobileProducts));
                     }
                     else
                     {
                         List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
                         List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
                         List<DailyNeedProduct> dailyNeedProducts = productManager.GetADailyNeedProuct();
                         List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();
                         return View(new AdminSectionC((AdminC)Session["adminIndo"], (List<SectionC>)Session["sectionInfo"], clothingProducts, electronicsProducts, dailyNeedProducts, mobileProducts));
                     }
                 }
                 else
                 {
                    ViewBag.insertResult = "2";
                     List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
                     List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
                     List<DailyNeedProduct> dailyNeedProducts = productManager.GetADailyNeedProuct();
                     List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();
                     return View(new AdminSectionC((AdminC)Session["adminIndo"], (List<SectionC>)Session["sectionInfo"], clothingProducts, electronicsProducts, dailyNeedProducts, mobileProducts));
                 }
             }
             else
             {
                ViewBag.insertResult = "3";
                 List<ClothingProduct> clothingProducts = productManager.GetAllCLothingProduct();
                 List<ElectronicsProduct> electronicsProducts = productManager.GetAllElectroinicProduct();
                 List<DailyNeedProduct> dailyNeedProducts = productManager.GetADailyNeedProuct();
                 List<MobileProduct> mobileProducts = productManager.GetAllMobileProduct();
                 return View(new AdminSectionC((AdminC)Session["adminIndo"], (List<SectionC>)Session["sectionInfo"], clothingProducts, electronicsProducts, dailyNeedProducts, mobileProducts));
             }
           

           
            
        }


       
        public ActionResult Orders()
        {

            List<OrderC> allOrders = orderManager.getAllOrder();

            ViewBag.orders = allOrders;
          
            return View();
        }
        public ActionResult Charts(int id)
        {
            AdminC admin = adminManager.getAdminInfo(id);
            return View(admin);
           
        }

        public ActionResult AddPromoCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPromoCode(PromoCode promoCode)
        {
            if (promoCodeManager.InsertPromoCode(promoCode))
            {
                return View();
            }
            return null;
        }

        public ActionResult ViewOrderDetails(int OrderId)
        {
            OrderC aOrder = orderManager.GetOrder(OrderId);
            List<CartItemC> cartItems = cartManager.getAllCartItems(OrderId);

            OrderDetails aOrderDetails = new OrderDetails(aOrder, cartItems);
            return View(aOrderDetails);
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


        public JsonResult  getProductOfThisCode(int SectionId, String Code)
        {
           

            if (SectionId == 1)
            {
                List<ClothingProduct> list = productManager.getAClothingProduct(Code);
               
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else if(SectionId == 2)
            {
                List<ElectronicsProduct> list = productManager.GetElectronicsProducts(Code);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else if(SectionId == 3)
            {
                List<DailyNeedProduct> list = productManager.GetADailyNeedProuct(Code);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else if(SectionId == 4)
            {
                List<MobileProduct> list = productManager.GetAllMobileProduct(Code);
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            return Json("");
        }

        public JsonResult updateClothingProductInfo(ClothingProduct product)
        {


            if (productManager.UpdateClothingProduct(product))
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        public JsonResult updateElectronicsProductInfo(ElectronicsProduct product)
        {
            if (productManager.UpdateElectronicsProduct(product))
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }

            return Json("false", JsonRequestBehavior.AllowGet);

        }

        public JsonResult updateDailyNeedProduct(DailyNeedProduct product)
        {
            if (productManager.UpdateDailyNeedsProduct(product)){
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);

        }
        public JsonResult updateMobileProduct(MobileProduct product)
        {
            if (productManager.UpdateMobileProduct(product))
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProduct(int ProductId,String ImageLink)
        {
           
           
            if (productManager.DeleteProduct(ProductId))
            {
                String imagePath = Request.MapPath("~/" + ImageLink + ".jpeg");
                if ((System.IO.File.Exists(imagePath)))
                {
                  System.IO.File.Delete(imagePath);
                }

                return Json("true",JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }


       public JsonResult GetOrderDetails(int OrderId)
        {
            OrderC aOrder = orderManager.GetOrder(OrderId);
            List<CartItemC> cartItems = cartManager.getAllCartItems(OrderId);

            OrderDetails aOrderDetails = new OrderDetails(aOrder, cartItems);
            return Json(aOrderDetails, JsonRequestBehavior.AllowGet);
        }



    }
}