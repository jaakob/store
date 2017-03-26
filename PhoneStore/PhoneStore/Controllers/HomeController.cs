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

        // GET: Ads
        public ActionResult Ads()
        {
            if (AuthHelper.IsAuthenticated(HttpContext))
            {
                User user = manager.GetUserByCookies(HttpContext.Request.Cookies[Constants.NameCookie].Value);
                return View(user);
            }
            else
                return RedirectToAction("Login", "Account");
        }
    }
}