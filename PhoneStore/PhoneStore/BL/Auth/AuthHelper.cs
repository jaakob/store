using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Service;
using PhoneStore.BL.Repository.EF;
using PhoneStore.DAL.EF;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace PhoneStore.BL.Auth
{
    public sealed class AuthHelper
    {
        private static IUserManager manager; //= new UserManager(new EfUserRepository());

        public AuthHelper(IUserManager imanager)
        {
            manager = imanager;
        }

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
                //UserManager manager = new UserManager();                
                User user = manager.GetUserByCookies(cookie.Value);

                return user != null && user.IsActive == true;                
            }

            return false;
        }

        private static void UpdateCookies(User user, string cookie)
        {
            //UserManager manager = new UserManager();
            manager.UpdateCookies(user, cookie);
        }
    }
}