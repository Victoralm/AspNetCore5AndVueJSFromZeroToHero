using Adonet_Blog.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Adonet_Blog.Services
{
    /// <summary>
    /// Used to get and send data to the Post Db table
    /// </summary>
    public class PostService
    {
        private SqlConnection _conn;
        SqlCommand _command;
        private IConfiguration _config;

        /// <summary>
        /// Injecting IServiceProvider as dependency
        /// </summary>
        /// <param name="serviceProvider"></param>
        public PostService(IServiceProvider serviceProvider)
        {
            this._config = serviceProvider.GetRequiredService<IConfiguration>();
            string connectionString = _config.GetConnectionString("Default").ToString();
            this._conn = new SqlConnection(connectionString);

            // Opens the connection with the Db if not opened already
            if (this._conn.State != ConnectionState.Open)
            {
                this._conn.Open();
            }
        }

        public List<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();
            // SQL query
            this._command = new SqlCommand("select * from Post", this._conn);
            // Defines the command type
            this._command.CommandType = CommandType.Text;
            // Closes the connection
            IDataReader dataReader = this._command.ExecuteReader(CommandBehavior.CloseConnection);

            // getting the data
            while(dataReader.Read())
            {
                Post post = new Post();
                post.PostId = dataReader["PostId"] is DBNull ? 0 : int.Parse(dataReader["PostId"].ToString());
                post.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString());
                post.Title = dataReader["Title"] is DBNull ? "" : dataReader["Title"].ToString();
                post.Content = dataReader["Content"] is DBNull ? "" : dataReader["Content"].ToString();

                if (dataReader["Publishing_Date"] != DBNull.Value)
                {
                    post.Publishing_Date = DateTime.Parse(dataReader["Publishing_Date"].ToString());
                }
                
                if (dataReader["Modified_Date"] != DBNull.Value)
                {
                    post.Modified_Date = DateTime.Parse(dataReader["Modified_Date"].ToString());
                }

                posts.Add(post);
            }

            return posts;
        }

        public Post GetPost(int id)
        {
            Post post = new Post();
            // SQL query
            this._command = new SqlCommand($"select Post.*, [User].Username from Post right join [User] ON [User].UserId = Post.UserId where Post.PostId = {id}", this._conn);
            // Defines the command type
            this._command.CommandType = CommandType.Text;
            // Closes the connection
            IDataReader dataReader = this._command.ExecuteReader(CommandBehavior.CloseConnection);

            // getting the data
            while (dataReader.Read())
            {
                post.PostId = dataReader["PostId"] is DBNull ? 0 : int.Parse(dataReader["PostId"].ToString());
                post.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString());
                post.Title = dataReader["Title"] is DBNull ? string.Empty : dataReader["Title"].ToString();
                post.Content = dataReader["Content"] is DBNull ? string.Empty : dataReader["Content"].ToString();

                if (dataReader["Publishing_Date"] != DBNull.Value)
                {
                    post.Publishing_Date = DateTime.Parse(dataReader["Publishing_Date"].ToString());
                }

                if (dataReader["Modified_Date"] != DBNull.Value)
                {
                    post.Modified_Date = DateTime.Parse(dataReader["Modified_Date"].ToString());
                }

                User myUser = new User
                {
                    UserId = post.PostId,
                    Username = dataReader["Username"] is DBNull ? "This post may have been deleted." : dataReader["Username"].ToString(),
                    //Password = dataReader["Password"] is DBNull ? "This post may have been deleted." : dataReader["Password"].ToString(),
                };

                post.Writer = myUser;
            }

            return post;
        }
    }
}
