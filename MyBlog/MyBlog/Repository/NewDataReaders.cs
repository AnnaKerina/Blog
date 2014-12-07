using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyBlog.Repository
{
    public class NewDataReaders
    {
        public ArticleModel GetArticleModel(string title)
        {
            PostModel postModel = null;
            Collection<string> comments = null;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseModel"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM ArticleTable WHERE Title = @title"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("title", title));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            postModel = new PostModel(
                                reader["Title"].ToString(),
                                reader["Body"].ToString(),
                                DateTime.Parse(reader["Date"].ToString()),
                                reader["Path"].ToString()
                                );
                        }
                    }
                }
                using (var command = new SqlCommand("SELECT CommentTable.* FROM CommentTable INNER JOIN ArticleTable ON CommentTable.ArticleID = ArticleTable.ArticleID WHERE ArticleTable.Title = @title"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("title", title));
                    comments = new Collection<string>();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            comments.Add(dataReader["Body"].ToString());
                        }
                    }
                }
            }

            return new ArticleModel(postModel, comments);
        }


        public void AddComment(string title, string comment)
        {
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(@"INSERT INTO Comment
	            SELECT PostID, @comment AS MyPost 
                FROM Post 
                WHERE Title = @title"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("comment", comment));
                    sqlCommand.Parameters.Add(new SqlParameter("title", title));
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}