using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.BL.Auth;
using PhoneStore.Models;
using PhoneStore.BL.Service;
using PhoneStore.BL.Repository.EF;
using PhoneStore.UI.ViewModels;
using PhoneStore.UI;
using System.IO;
using PhoneStore.BL.Service.Image;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        private IUserManager userManager;
        private IPhoneManager phoneManager;
        private IImageManager imageManager;
        private AuthHelper authHelper;
        public int PageSize { get; set; } = 5;

        public HomeController(IUserManager userManager, IPhoneManager phoneManager, IImageManager imageManager)
        {
            this.userManager = userManager;
            this.phoneManager = phoneManager;
            this.imageManager = imageManager;
            authHelper = new AuthHelper(userManager);
        }

        [HttpGet]
        public ActionResult Ads(string filter = null, int page = 1)
        {
            if (authHelper.IsAuthenticated(HttpContext))
            {
                if (filter == "")
                    filter = null;

                PhoneListViewModel model = new PhoneListViewModel()
                {
                    Phones = phoneManager.GetAllPhones()
                };

                model.PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    PhoneCurrentPage = PageSize,
                    TotalPhone = filter == null ? model.Phones.Count() : model.Phones.Where(e => e.Model.ToLower().Contains(filter.ToLower())).Count()
                };

                model.Phones = model.Phones
                    .Where(e => filter == null || e.Model.ToLower().Contains(filter.ToLower()))
                    .OrderBy(e => e.PhoneId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize);

                if (filter == null)
                    return View(model);
                else
                    return PartialView("_PartialAds", model);
            }
            else
                return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Ads(Phone phone)
        {
                return RedirectToAction("AdsAdditional", phone);
        }

        [HttpGet]
        public ActionResult AdsAdditional(Phone phone)
        {
            if (authHelper.IsAuthenticated(HttpContext))
                return View(phone);

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult AdsAdditional(Phone phone, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                User user = userManager.GetUserByCookies(HttpContext.Request.Cookies[Constants.NameCookie].Value);
                phone.UserId = user.UserId;

                phoneManager.Add(phone);

                if (image != null)
                {
                    string fileName = Path.GetFileName(image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    image.SaveAs(path);

                    ApplicationImage appImage = new ApplicationImage()
                    {
                        Image = Url.Content("~/Images/" + fileName),
                        PhoneId = phoneManager.GetPhoneId(phone)
                    };

                    imageManager.Add(appImage);
                }

                return RedirectToAction("AdResult", phone);
            }
            return View(phone);
        }

        [HttpGet]
        public ActionResult AdResult(Phone phone)
        {
            if (authHelper.IsAuthenticated(HttpContext))
            {
                if (phone.Model == null)
                {
                    return RedirectToAction("Ads");
                }

                return View(phone);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}