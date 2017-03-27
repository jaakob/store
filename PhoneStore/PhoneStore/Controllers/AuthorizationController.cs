using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneStore.Controllers
{
    public class AuthorizationController : Controller
    {
        public ActionResult Authorization(UserApp user)
        {
            return View(user);
        }

    }
}
