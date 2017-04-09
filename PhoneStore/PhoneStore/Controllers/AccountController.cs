using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;
using PhoneStore.BL.Service;
using PhoneStore.BL.Repository.EF;
using PhoneStore.BL.Auth;
using System.Net.Mail;
using System.Threading.Tasks;
using PhoneStore.BL.Email;
using PhoneStore.Security;

namespace PhoneStore.Controllers
{
    public class AccountController : Controller
    {
        private IUserManager manager;
        private AuthHelper authHelper;


        public AccountController(IUserManager manager)
        {
            this.manager = manager;
            authHelper = new AuthHelper(manager);
        }

        // GET: Home
        [HttpGet]
        public ActionResult Login()
        {
             if (!authHelper.IsAuthenticated(HttpContext))
                 return View();

            return RedirectToAction("Ads", "Home");
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                login.Password = SecurityHelper.GetHashSha256(login.Password);
                User currentUser = manager.GetUser(login);

                if (currentUser != null)
                {
                    if (currentUser.IsActive == true)
                    {
                        authHelper.UserSetCookie(HttpContext, currentUser, Guid.NewGuid().ToString());
                        return RedirectToAction("Ads", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Подтвердите регистрацию по email");
                }
                else
                    ModelState.AddModelError("", "Неверный логин или пароль");
            }
            return View();
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            authHelper.LogOffUser(HttpContext);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registration(User user)
        {
            if (ModelState.IsValid)
            {
                if (manager.IsAlreadyRegister(user))
                {
                    user.RegDate = DateTime.Now;
                    user.Cookie = Guid.NewGuid().ToString();
                    user.IsActive = false;
                    user.Password = SecurityHelper.GetHashSha256(user.Password);
                    manager.Add(user);
                    try
                    {
                        await EmailHelper.SendMail(user);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    return RedirectToAction("ResultRegister");
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким e-mail уже существует");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult ConfirmEmail(string token)
        {
            User currentUser = manager.GetUserByCookies(token);

            if (currentUser != null)
            {
                currentUser.IsActive = true;
                manager.UpdateIsActive(currentUser);
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ResultRegister()
        {
            return View();
        }
    }
}