using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Repository.Domain
{
    public class Comment : BaseEntity
    {

        public int ArticleID { get; set; }

        public string Body { get; set; }

        public string Username { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("ArticleID")]

        public virtual Post Post { get; set; }
    }
}