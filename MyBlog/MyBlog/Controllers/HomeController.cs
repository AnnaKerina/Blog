using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using System.Data.Entity;
using Forms.Repository;
using MyBlog.Repository;


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

            //string query = Request.QueryString["Foo"];
            //var model = new ArticleModel();
            var readers = new NewDataReaders();
            return View(readers.GetArticleModel(title));
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
                model.User.Avatar.SaveAs("C:/Users/Alexander/Documents/Temp/" + model.User.Avatar.FileName);
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
            //    if (model.User != null && model.User.Avatar != null && model.User.Avatar.ContentLength > 0)
            //    {
            //        model.User.Avatar.SaveAs("C:/Users/Alexander/Documents/Temp/" + model.User.Avatar.FileName);
            //    }
            if (!string.IsNullOrWhiteSpace(model.Body))
            {
                CommentsRepository.Titels.Add(model.Body);
            }

            return View(new ArticleModel());
        }

        //[HttpGet]
        //public ActionResult Index(string title)
        //{
        //    if (title == null)
        //    {
        //        title = "This is my first title";
        //    }

            //using (var ctx = new EFContext())
            //{
            //    var post = ctx.Posts.Where(p => p.Title == title).FirstOrDefault();
            //    var postModel = new PostModel(post.Title, post.Body, post.DateCreated);
            //    var commentModel = new Collection<string>();
            //    if (post.Comments != null && post.Comments.Any())
            //    {
            //        foreach (var item in post.Comments)
            //        {
            //            commentModel.Add(item.Body);
            //        }
            //    }

            //    var dao = new MongoDAO();
            //    var mPost = dao.LoadPost(title);

            //    return View(new ArticleModel(postModel, commentModel));
            //}

        //    var readers = new NewDataReaders();
        //    return View(readers.GetArticleModel(title));
        //}

        //[HttpPost]
        //public ActionResult Index(ArticleModel model)
        //{
        //    var title = "This is my first title";

        //    if (model.NewComment != null && ModelState.IsValid)
        //    {

                //using (var ctx = new EFContext())
                //{
                //    var post = ctx.Posts.Where(p => p.Title == title).FirstOrDefault();
                //    if (post != null)
                //    {
                //        ctx.Comments.Add(new Comment() { Body = model.NewComment.Comment, PostID = post.PostID });
                //        ctx.SaveChanges();
                //    }
                //}
                //var readers = new NewDataReaders();
                //readers.AddComment(title, model.NewComment.Comment);
        //        CommentsRepository.Comments.Add(model.NewComment.Comment);
        //        ModelState.Clear();
        //        return RedirectToAction("Index", new { title = title });
        //    }

        //    return View(model);
        //}
    }
}
