using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using Forms.Repository;
using MyBlog.Repository;

namespace MyBlog.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Recent()
        {
            var db = new EFContext();
            return View(db.Posts.AsEnumerable());
        }

    }
}
