using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class CurrentUserService
    {
        public static string CurrentUserKey = "CurrentUserKey";

        public UserAccount GetCurentUser()
        {
            if (HttpContext.Current == null)
            {
                throw new InvalidOperationException();
            }

            return HttpContext.Current.Items[CurrentUserKey] as UserAccount;
        }
    }
}