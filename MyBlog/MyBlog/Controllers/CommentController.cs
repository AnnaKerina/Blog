using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using MyBlog.Repository;

namespace MyBlog.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        public ActionResult Recent()
        {
            var db = new EFContext();
            return View(db.Comments.AsEnumerable());
        }

    }
}
