using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyBlog.Repository.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyBlog.Repository
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Blog")
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}