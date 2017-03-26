using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;
using PhoneStore.BL.Service;
using PhoneStore.BL.Repository.EF;
using PhoneStore.BL.Auth;

namespace PhoneStore.Controllers
{
    public class AccountController : Controller
    {        
        private UserManager manager = new UserManager();

        // GET: Home
        [HttpGet]
        public ActionResult Login()
        {
             if (!AuthHelper.IsAuthenticated(HttpContext))
                 return View();

            return RedirectToAction("Ads", "Home");
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                User currentUser = manager.GetUser(login);

                if (currentUser != null)
                {
                    AuthHelper.LogInUser(HttpContext, currentUser, Guid.NewGuid().ToString());
                    return RedirectToAction("Ads", "Home");
                }
                else
                    ModelState.AddModelError("", "Неверный логин или пароль");
            }
                return View();
        }
        
        [HttpGet]
        public ActionResult LogOff()
        {
            AuthHelper.LogOffUser(HttpContext);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                if (manager.IsAlreadyRegister(user))
                {
                    user.RegDate = DateTime.Now;
                    user.Cookie = Guid.NewGuid().ToString();
                    user.IsActive = false;
                    manager.Add(user);
                    return RedirectToAction("ResultRegister", user);
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким e-mail уже существует");
            }
              return View();
        }

        [HttpGet]
        public ViewResult ResultRegister(User user)
        {
            return View(user);
        }
    }
}