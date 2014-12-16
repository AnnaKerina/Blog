using Forms.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class ArticleModel
    {

        private readonly PostModel post;
        private readonly ICollection<CommentItemModel> comments;

        public ArticleModel() { }

        public ArticleModel(PostModel post, ICollection<CommentItemModel> comments)
        {
            this.post = post;
            this.comments = comments;
        }

        public PostModel Post
        {
            get
            {
                return post;
            }
        }

        public ICollection<CommentItemModel> Comments
        {
            get
            {
                return comments;
            }
        }

        public AddCommentModel NewComment { get; set; }
    }
}