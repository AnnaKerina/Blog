using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class CommentItemModel
    {
        public CommentItemModel() { }

        public CommentItemModel(string Username, string Body, DateTime Date)
        {
            this.Username = Username;
            this.Body = Body;
            this.Date = Date;
        }

        public string Username { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
    }
}