using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.BL.Auth;
using PhoneStore.Models;
using PhoneStore.BL.Service;
using PagedList.Mvc;
using PagedList;


namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        private IPhoneManager phoneManager;        
        private IUserManager userManager;
        private AuthHelper authHelper;
        private static string search = ""; 

        public HomeController(IPhoneManager phoneManager, IUserManager userManager)
        {
            this.phoneManager = phoneManager;
            this.userManager = userManager;
            this.authHelper = new AuthHelper(userManager);
        }

        // GET: Ads
        public ActionResult Ads()
        {
            if (AuthHelper.IsAuthenticated(HttpContext))
            {
                //User user = userManager.GetUserByCookies(HttpContext.Request.Cookies[Constants.NameCookie].Value);
                //return View(user);
                return View();
            }            
            return RedirectToAction("Login", "Account");
        }
        
        [HttpPost]        
        public ActionResult PhonesSearch(string searchString, int? page)
        {
            if (searchString != null)
            {
                search = searchString;
            }            
            int pageSize = 5;
            var phones = phoneManager.FindPhones(search);
            int pageNumber = (page ?? 1);
            ViewBag.Page = "Search";
            return PartialView(phones.ToPagedList(pageNumber, pageSize));
        } 

        public PartialViewResult GetPhones(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);            
            List<Phone> phones = phoneManager.GetPhones();
            return PartialView("~/Views/Home/PhonesSearch.cshtml", phones.ToPagedList(pageNumber, pageSize));
        }

    }
}