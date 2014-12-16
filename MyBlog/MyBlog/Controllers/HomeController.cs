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
                title = "First Post";
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


        public ActionResult Article() {
            var model = new ArticleModel();
            return View(model); ;
            
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
            var model = new ArticleModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AddCommentModel model)
        {
            if (model.User != null && model.User.Avatar != null && model.User.Avatar.ContentLength > 0)
            {
                model.User.Avatar.SaveAs("C:/Temp/" + model.User.Avatar.FileName);
            }
            if (!string.IsNullOrWhiteSpace(model.Comment))
            {
                CommentsRepository.Comments.Add(model.Comment);
            }

            return View(new ArticleModel());
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

            return RedirectToAction("Index");
        }
    }
}
