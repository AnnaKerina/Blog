using Forms.Repository;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlog.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/



        public ContentResult Index()
        {
            return new ContentResult() { Content = "Hello world" };
        }

        public ContentResult GetByUrl(string seoUrl)
        {
            return new ContentResult() { Content = "#" + seoUrl + "#" };
        }

        public ActionResult Account()
        {
            var model = new UserModel();
            return View(model);
        }

        public ActionResult AboutMe() {
            var model = new UserModel();
            return View(model);
        }


        //[HttpGet]
        //public ActionResult Index()
        //{
        //    Session["sessionKey"] = new UserAccount() { UserName = "TempUserName" };

        //    var ticker = new FormsAuthenticationTicket(2, "Alex", DateTime.Now, DateTime.Now.AddMonths(1), true,
        //        String.Empty);
        //    var encTicket = FormsAuthentication.Encrypt(ticker);

        //    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
        //    cookie.Expires = DateTime.Now.AddMonths(1);

        //    Response.Cookies.Add(cookie);

        //    return View(new ArticleModel());
        //}

        //[HttpPost]
        //[Authorize]
        //public ActionResult Index(ArticleModel model)
        //{
        //    var userAccount = Session["sessionKey"] as UserAccount;

        //    if (model.NewComment != null && ModelState.IsValid)
        //    {
        //        CommentsRepository.Comments.Add(model.NewComment.Comment);
        //        ModelState.Clear();
        //    }

        //    return View(model);
        //}

    }
}
