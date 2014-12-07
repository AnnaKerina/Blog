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
        private readonly ICollection<string> comments;

        public ArticleModel()
        {
            Title = "This is an article title";
            Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec dignissim orci dolor, sed sodales nibh molestie nec. In hac habitasse platea dictumst. Integer commodo mi mi, et dapibus nisi mattis eget. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque tristique ligula a sem molestie pretium. Quisque dolor justo, placerat eu tincidunt in, aliquam at velit. Aenean a tincidunt ipsum. Fusce finibus vel risus quis pulvinar. Vestibulum condimentum vel massa sit amet vestibulum. Suspendisse ante elit, pulvinar eu elit sed, condimentum rhoncus justo. Curabitur auctor, velit vitae posuere efficitur, felis orci fringilla nunc, eget auctor sem quam sed magna. Aenean tristique dui lacinia mauris euismod, at hendrerit nisl volutpat. Sed gravida eleifend ex, eu ultricies nisi convallis vel.";
            Date = DateTime.Now;
            Path = "~/images/img2.jpg";
            Likes = new Collection<LikeModel>();
            //Comments = new Collection<CommentItemModel>();
        }

        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Path { get; set; }

        public ICollection<LikeModel> Likes { get; set; }
        //public ICollection<CommentItemModel> Comments { get; set; }

        public ICollection<string> Comments
        {
            get
            {
                return CommentsRepository.Comments;
            }
        }
        public ICollection<string> Titels
        {
            get
            {
                return CommentsRepository.Titels;
            }
        }

        public ArticleModel(PostModel post, ICollection<string> comments)
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

        public AddCommentModel NewComment { get; set; }


    }
}