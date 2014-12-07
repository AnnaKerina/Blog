using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class ContactsModel
    {
        public ContactsModel()
        {
            text = "My contacts";
            numder = "+375253456744";
            email = "mvc@gmail.com";
            nextNumder = "+375337894738";
            address = "bla-bla-bla";
        }

        public string text { get; set; }
        public string numder { get; set;}
        public string email { get; set; }
        public string nextNumder {get; set;}
        public string address { get; set; }
    }
}