using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Service;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using PhoneStore.BL.Repository.EF;
using PhoneStore.BL.Repository;

namespace PhoneStore.BL.Auth
{
    public class AuthHelper
    {
        private IUserManager manager;

        public AuthHelper(IUserManager manager)
        {
            this.manager = manager;
        }

        public void UserSetCookie(HttpContextBase context, User user, string value)
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


        public void LogOffUser(HttpContextBase context)
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

        public bool IsAuthenticated(HttpContextBase context)
        {
            HttpCookie cookie = context.Request.Cookies[Constants.NameCookie];

            if (cookie != null)
            {
                User user = manager.GetUserByCookies(cookie.Value);

                return user != null;
            }
            return false;
        }

        private void UpdateCookies(User user, string cookie)
        {
            manager.UpdateCookies(user, cookie);
        }
    }
}