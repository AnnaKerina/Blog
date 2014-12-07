using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class AboutMe
    {
        public AboutMe() 
        {
            path = "";
            name = "Hanna";
            surName = "Kerina";
            age = 21;
            text = "Littel story about me.";
        }

        public string path { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public int age { get; set; }
        public string text { get; set; }
    }
}