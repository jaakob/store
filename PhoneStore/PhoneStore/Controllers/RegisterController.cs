using System.Web.Mvc;
using PhoneStore.BL.Auth;
using PhoneStore.Models;
using PhoneStore.BL.Service;

namespace PhoneStore.Controllers
{
    public class RegisterController : Controller
    {
        UserManager manager = new UserManager();
        

        public ActionResult Confirm(string id)
        {
            ViewBag.Status = "";
            if (AuthHelper.IsAuthenticated(HttpContext))
            {
                User user = manager.GetUserByCookies(HttpContext.Request.Cookies[Constants.NameCookie].Value);
                return RedirectToAction("Ads","Home");
            }
            User currentUser = manager.GetUserByCookies(id);
            if (currentUser == null)
            {
                return View();
            }
            if (currentUser != null)
            {
                if (currentUser.IsActive == false)
                {
                    manager.MakeActive(currentUser);
                    ViewBag.Status = "success";
                    return View();
                }
                if (currentUser.IsActive == true)
                {
                    ViewBag.Status = "alreadyActive";
                    return View();
                }
            }        
            return View("Login","Account");
        }
    }
}