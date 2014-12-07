using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class PostModel
    {
        private readonly string title, body, path;
        private readonly DateTime date;

        public PostModel(string title, string body, DateTime date, string path)
        {
            this.title = title;
            this.body = body;
            this.date = date;
            this.path = path;
        }

        public string Title
        {
            get
            {
                return title;
            }
        }

        public string Body
        {
            get
            {
                return body;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
        }
        public string Path 
        {
            get 
            {
                return path;
            }
        }
    }
}