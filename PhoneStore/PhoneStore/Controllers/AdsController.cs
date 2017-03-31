using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;
using PhoneStore.BL.Service;

namespace PhoneStore.Controllers
{
    public class AdsController : Controller
    {
        UserManager manager = new UserManager();//fix
        PhoneManager phoneManager = new PhoneManager();//fix

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if(upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Images/" + fileName));
                TempData["UploadResult"] = Server.MapPath("~/Images/" + fileName); //need for testing
            }            
            return RedirectToAction("Ads", "Home");
        }

        [HttpPost]
        public ActionResult AddingPhone(Phone phone)
        {
            if (ModelState.IsValid)
            {                
                return RedirectToAction("AddingPage", phone);
            }
            //return View();
            return RedirectToAction("AddingPage", phone);
        }

        [HttpGet]
        public ActionResult AddingPage(Phone phone)
        {
            return View(phone);
        }

        [HttpPost]
        public ActionResult AddingConfirmation(Phone phone)
        {
            if (ModelState.IsValid)
            {
                var user = manager.GetUserByCookies(HttpContext.Request.Cookies[Constants.NameCookie].Value);
                phone.UserId = manager.GetUserId(user);
                phoneManager.Add(phone);
                return RedirectToAction("AddingResult");
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddingResult()
        {
            return View();
        }
    }
}