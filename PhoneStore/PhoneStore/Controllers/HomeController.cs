using PhoneStore.DAL.EF;
using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserApp user)
        {
            //user.UserId = 1;
            //user.IsActive = false;
            //user.RegDate = DateTime.Now.Date;
            //user.Cookies = "aaa";

            //ps.Users.Add(user);
            //ps.SaveChanges();
           // Manager manager = new Manager(user);
                return View();

        }
        public ActionResult Authorization(UserApp user)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Success(UserApp user)
        {

            Manager manager = new Manager(user);
            return View(user);
        }
    }
}