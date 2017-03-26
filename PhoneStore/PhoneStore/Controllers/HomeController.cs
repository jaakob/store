using System;
using System.Web;
using System.Web.Mvc;
using PhoneStore.BL;
using PhoneStore.Models;
using PhoneStore.BL.Auth;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        private IManager manager;        
        
        public HomeController(IManager manager)
        {
            this.manager = manager;
        }
        
        [HttpGet]
        public ActionResult Register()
        {
            //User newUser = manager.AddUser("1234@mail", "password123", "Jon", "Andersen", "co0kie2323233", DateTime.Now, "0000123", true); 
            ViewBag.Message = null;
            ViewBag.IsLogged = false;
            HttpCookie cookie = Request.Cookies.Get("LoginCookie");
            if (cookie == null)
            {
                return View();
            }
            else 
            {
                var user = manager.GetUserByCookie(cookie.Value.ToString());
                if (user != null && user.IsActive == true)
                {                    
                    return RedirectToAction("Store");
                }
                else
                {
                    return View();
                }
            }    
            
        }

        [HttpPost]
        public ActionResult Register(Registration registerUser)
        {
            if (ModelState.IsValid)
            {
                if (manager.IsExists(registerUser.Email) == true)
                {
                    ViewBag.Message = "Such email is already registered! Please use it for logging in.";
                    ViewBag.IsLogged = false;
                    return View("Register");
                }
                if (registerUser.Password != registerUser.RepeatPassword)
                {
                    ViewBag.Message = "Password and repeated password doesn't match.";
                    ViewBag.IsLogged = false;
                    return View("Register");
                }
                else
                {
                    string CookieValue = Guid.NewGuid().ToString();
                    if (registerUser.ContactPhone == null)
                    { registerUser.ContactPhone = ""; }

                    User newUser = manager.AddUser(
                        registerUser.Email, registerUser.Password, registerUser.FirstName, 
                        registerUser.LastName, CookieValue, DateTime.Now, registerUser.ContactPhone, false);
                    Authentication.SendAuthEmail(registerUser.Email, "http://localhost:49742/Register/Confirmation/" + CookieValue);
                    ViewBag.Message = null;
                    ViewBag.IsLogged = false;
                    ViewBag.RegisterMessage = "Registration link has been sent to specified email.\n Please follow it to finish registration!";
                    //return RedirectToAction("Login");
                    return View("Register");
                }
                
            }
            else
            {
                ViewBag.IsLogged = false;
                return View("Register");
            }            
        }
        [HttpGet]
        public ActionResult Login()
        {
            HttpCookie cookie = Request.Cookies.Get("LoginCookie");
            if (cookie == null)
            {
                ViewBag.Message = null;
                return View();
            }
            else
            {
                var user = manager.GetUserByCookie(cookie.Value.ToString());
                if (user != null && user.IsActive == true)
                {                    
                    return RedirectToAction("Store");
                }
                else
                {
                    return View();
                }
            }

        }

        [HttpPost]
        public ActionResult Login(Login user)
        {
            if (ModelState.IsValid)
            {
                var currentUser = manager.GetUserByEmail(user.Email);
                if (currentUser != null && currentUser.Password == user.Password)
                {
                    if (currentUser.IsActive == true)
                    {
                        var cookie = new HttpCookie("LoginCookie")
                        {
                            Value = Guid.NewGuid().ToString(),
                            Expires = DateTime.Now.AddDays(1)
                        };
                        manager.UpdateCookiesForUser(user.Email, cookie.Value);
                        Response.SetCookie(cookie);
                        return RedirectToAction("Store");
                    }
                    else
                    {
                        ViewBag.Message = "User isn't activated yet! Please follow the link from email.";
                        return View("Login");
                    }
                }
                ViewBag.Message = "User or password is incorrect!";
                return View("Login");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        public ActionResult Store()
        {            
            HttpCookie cookie = Request.Cookies.Get("LoginCookie");
            if (cookie == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var user = manager.GetUserByCookie(cookie.Value.ToString());
                if (user != null && user.IsActive == true)
                {
                    ViewBag.IsLogged = true;
                    return View(user);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }        
        
        public ActionResult LogOut()
        {
            HttpCookie cookie = Request.Cookies.Get("LoginCookie");
            if (cookie != null)
            {
                cookie.Value = null;
                Response.SetCookie(cookie);
                ViewBag.IsLogged = false;
                return RedirectToAction("Login");
            }            
            else
                return RedirectToAction("Store");
            
        }


  }
}