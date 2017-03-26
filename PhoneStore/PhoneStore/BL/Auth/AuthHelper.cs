using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Service;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace PhoneStore.BL.Auth
{
    public static class AuthHelper
    {
        public static void LogInUser(HttpContextBase context, User user, string value)
        {
            if (value == null)
                throw new Exception("Cookie is empty");

            HttpCookie cookie = new HttpCookie(Constants.NameCookie)
            {
                Value = value,
                Expires = DateTime.Now.AddDays(1)
            };

            context.Response.Cookies.Add(cookie);
            UpdateCookies(user, context.Response.Cookies[Constants.NameCookie].Value);
        }


        public static void LogOffUser(HttpContextBase context)
        {
            if (context.Request.Cookies[Constants.NameCookie] != null)
            {
                HttpCookie cookie = new HttpCookie(Constants.NameCookie)
                {
                    Expires = DateTime.Now.AddDays(-1)
                };

                context.Response.Cookies.Add(cookie);
            }                
        }

        public static bool IsAuthenticated(HttpContextBase context)
        {
            HttpCookie cookie = context.Request.Cookies[Constants.NameCookie];

            if (cookie != null)
            {
                UserManager manager = new UserManager();

                User user = manager.GetUserByCookies(cookie.Value);

                return user != null;
            }

            return false;
        }

        private static void UpdateCookies(User user, string cookie)
        {
            UserManager manager = new UserManager();
            manager.UpdateCookies(user, cookie);
        }
    }
}