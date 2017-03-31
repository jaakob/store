using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.BL.Auth;
using PhoneStore.Models;
using PhoneStore.BL.Service;


namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        UserManager manager = new UserManager();//fix
        PhoneManager phoneManager = new PhoneManager();//fix

        // GET: Ads
        public ActionResult Ads()
        {
            if (AuthHelper.IsAuthenticated(HttpContext))
            {
                User user = manager.GetUserByCookies(HttpContext.Request.Cookies[Constants.NameCookie].Value);
                if (user.IsActive)
                { 
                    ViewBag.UploadResult = TempData["UploadResult"];                    
                    return View(user);
                }                
                return RedirectToAction("Login", "Account");
            }            
            return RedirectToAction("Login", "Account");
        }

        //test mode
        [HttpPost]
        public ActionResult PhonesSearch(int id)
        {
            var phones = phoneManager.GetPhones(id, id);            
            if (phones == null)
            {
                return HttpNotFound();
            }
            return PartialView(phones);
        }

        [ChildActionOnly]
        public PartialViewResult GetPhones()
        {                       
            List<Phone> phones = phoneManager.GetPhones(1, 5);
            return PartialView("~/Views/Home/PhonesSearch.cshtml", phones);
        }
    }
}