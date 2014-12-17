using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using System.Data.Entity;
using Forms.Repository;
using MyBlog.Repository;
using System.Collections.ObjectModel;
using MyBlog.Repository.Domain;


namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index(string title)
        {
            if (title == null)
            {
                title = "First Post1";
            }

            using (var ctx = new EFContext())
            {
                var post = ctx.Posts.Where(p => p.Title == title).FirstOrDefault();
                var postModel = new PostModel(post.Title, post.Body, post.Date);
                var commentModel = new Collection<CommentItemModel>();
                if (post.Comments != null && post.Comments.Any())
                {
                    foreach (var item in post.Comments)
                    {
                        CommentItemModel comment = new CommentItemModel(item.Username, item.Body,item.Date);
                        commentModel.Add(comment);
                    }
                }
                return View(new ArticleModel(postModel, commentModel));
            }
        }

        public ActionResult AboutMe() {
            var model = new AboutMe();
            return View(model);
        }

        public ActionResult Contacts()
        {
            var model = new ContactsModel();
            return View(model);
        }

        public ActionResult Titels() {
            var db = new EFContext();
            return View(db.Posts.AsEnumerable());
        }

        [HttpPost]
        public ActionResult Index(ArticleModel model, string title)
        {
            if (title == null)
            {
                title = "First Post";
            }

            if (model.NewComment != null && ModelState.IsValid)
            {

                using (var ctx = new EFContext())
                {
                    var post = ctx.Posts.Where(p => p.Title == title).FirstOrDefault();
                    if (post != null)
                    {
                        ctx.Comments.Add(new Comment() { Body = model.NewComment.Comment, ArticleID = post.ID, Username = model.NewComment.User.Username,Date=DateTime.Now });
                        ctx.SaveChanges();
                    }
                }
                ModelState.Clear();
                return RedirectToAction("Index", new { title = title });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddArticle()
        {
            var model = new ArticleModel();
            return View(model);
        }



        [HttpPost]
        public ActionResult AddArticle(ArticleModel model)
        {
           
            if (!string.IsNullOrWhiteSpace(model.Post.Body))
            {
                CommentsRepository.Titels.Add(model.Post.Body);
            }

            return View(new ArticleModel());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            var db = new EFContext();
            post.Date = DateTime.Now;
            db.Posts.Add(post);
            db.SaveChanges();

            return RedirectToAction("Titels", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new EFContext();
            if (id == null)
            {
                return HttpNotFound();
            }
            Post post = db.Posts.Find(id);
            if (post != null)
            {
                return View(post);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            var db = new EFContext();
            post.Date = DateTime.Now;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Titels", "Home");
        }

        public ActionResult Delete(int id)
        {
            var db = new EFContext();
            Post post = db.Posts.Find(id);
            if (post != null)
            {
                db.Posts.Remove(post);
                db.SaveChanges();
            }
            return RedirectToAction("Titels", "Home");
        }
    }
}
