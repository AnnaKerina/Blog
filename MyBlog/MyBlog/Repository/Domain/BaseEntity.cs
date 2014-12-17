using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Repository.Domain
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}