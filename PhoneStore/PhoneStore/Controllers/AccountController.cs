using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;
using PhoneStore.BL.Service;
using PhoneStore.BL.Repository.EF;
using PhoneStore.BL.Auth;
using System.Threading.Tasks;


namespace PhoneStore.Controllers
{
    public class AccountController : Controller
    {        
        private UserManager manager = new UserManager();

        // GET: Home
        [HttpGet]
        public ActionResult Login()
        {
            if (AuthHelper.IsAuthenticated(HttpContext))
            {
                User user = manager.GetUserByCookies(HttpContext.Request.Cookies[Constants.NameCookie].Value);
                if (user.IsActive)
                {
                    return RedirectToAction("Ads", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                User currentUser = manager.GetUser(login);

                if (currentUser != null)
                {
                    if (currentUser.IsActive == true)
                    {
                        AuthHelper.LogInUser(HttpContext, currentUser, Guid.NewGuid().ToString());
                        return RedirectToAction("Ads", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Данный Email не авторизован. Пожалуйста, пройдите по полученной ссылке");
                    }
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
            if (AuthHelper.IsAuthenticated(HttpContext))
            {
                User user = manager.GetUserByCookies(HttpContext.Request.Cookies[Constants.NameCookie].Value);
                if (user.IsActive)
                {
                    return RedirectToAction("Ads", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(User user)
        {
            if (ModelState.IsValid)
            {
                if (manager.IsAlreadyRegister(user))
                {
                    user.RegDate = DateTime.Now;
                    user.Cookie = Guid.NewGuid().ToString();
                    user.IsActive = false;
                    manager.Add(user);
                    await EmailService.SendEmailAsync(user.Email, user.Cookie);
                    return RedirectToAction("ResultRegister");
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким e-mail уже существует");
            }
              return View();
        }

        [HttpGet]
        public ViewResult ResultRegister()
        {
            return View();
        }
    }
}