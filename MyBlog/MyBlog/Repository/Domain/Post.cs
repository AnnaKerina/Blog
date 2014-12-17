using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Repository.Domain
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}