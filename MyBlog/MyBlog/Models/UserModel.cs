﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class UserModel
    {
        //public ICollection<string> Countries
        //{
        //    get
        //    {
        //        return Forms.Repository.CountriesRepository.Countries;
        //    }
        //}

        //public UserModel() 
        //{
        //    Country = "Belarus";
        //    Age = 21;
        //    Username = "Samedriss";
        //    Text = "Littel blog adout me.";
        //}
    

        public string Username { get; set; }

        public string Text { get; set; }
    }
}