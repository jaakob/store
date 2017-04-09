using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;
using PhoneStore.BL.Service;
using PhoneStore.BL.Auth;

namespace PhoneStore.Controllers
{
    public class AdsController : Controller
    {
        private IPhoneManager phoneManager;
        private IUserManager userManager;
        private AuthHelper authHelper;

        public AdsController(IPhoneManager phoneManager, IUserManager userManager)
        {
            this.phoneManager = phoneManager;
            this.userManager = userManager;
            this.authHelper = new AuthHelper(userManager);
        }

        [HttpPost]        
        public ActionResult AddingPhone(Phone phone)       
        {            
            if (ModelState.IsValid)
            {   
                return JavaScript("window.location = '" + Url.Action("AddingPage", phone) + "'");
            }
            return PartialView(phone);            
        }

        [HttpGet]
        public ActionResult AddingPage(Phone phone)
        {
            if (!AuthHelper.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Login", "Account");
            }
            return View(phone);
        }

        [HttpPost]
        public ActionResult AddingConfirmation(Phone phone, IEnumerable<HttpPostedFileBase> uploads)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.GetUserByCookies(HttpContext.Request.Cookies[Constants.NameCookie].Value);
                phone.UserId = userManager.GetUserId(user);
                phoneManager.Add(phone);                
                if (uploads != null)
                {                    
                    foreach (var file in uploads)
                    {
                        if (file != null)
                        {                                            
                            string fileName = System.IO.Path.GetFileName(file.FileName);
                            int phoneId = phoneManager.GetPhoneId(phone);
                            string directoryName = phoneId.ToString();                            
                            Directory.CreateDirectory(Server.MapPath("~/Images/" + directoryName));
                            file.SaveAs(Server.MapPath("~/Images/" + directoryName + "/" + fileName));              
                            Image newImage = new Image {
                                PhoneId = phoneId,
                                ImageURL = directoryName + "/" + fileName
                            };
                            phoneManager.AddImage(newImage);
                            TempData["Uploads"] = uploads;
                        }
                    }
                }                
                return RedirectToAction("AddingResult");
            }
            return RedirectToAction("AddingPage", phone);            
        }

        [HttpGet]
        public ActionResult AddingResult()
        {
            if (!AuthHelper.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}