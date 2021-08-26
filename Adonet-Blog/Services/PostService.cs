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

        /// <summary>
        /// Injecting IConfiguration as dependency
        /// </summary>
        /// <param name="config"></param>
        public PostService(IConfiguration config)
        {
            ConnectionService connServ = new ConnectionService(config);
            this._conn = connServ.DbConnection();
        }

        public List<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();
            // SQL query
            this._command = new SqlCommand("select * from [Post]", this._conn);
            // Defines the command type
            this._command.CommandType = CommandType.Text;
            // Getting the data and closing the connection
            IDataReader dataReader = this._command.ExecuteReader(CommandBehavior.CloseConnection);

            // Storing the data
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
            //this._command = new SqlCommand($"select [Post].*, [User].[Username] from [Post] right join [User] ON [User].[UserId] = [Post].[UserId] where [Post].[PostId] = {id}", this._conn);
            this._command = new SqlCommand($"select [Post].*, [User].[Username] from [Post] left join [User] ON [User].[UserId] = [Post].[UserId] where [Post].[PostId] = {id}", this._conn);
            // Defines the command type
            this._command.CommandType = CommandType.Text;
            // Getting the data and closing the connection
            IDataReader dataReader = this._command.ExecuteReader(CommandBehavior.CloseConnection);

            // Storing the data
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

        public List<Post> GetPostsByUser(int userId)
        {
            List<Post> posts = new List<Post>();
            // SQL query
            //this._command = new SqlCommand($"select [Post].*, [User].[Username] from Post right join [User] ON [User].[UserId] = [Post].[UserId] where [Post].[UserId] = {userId}", this._conn);
            this._command = new SqlCommand($"select [Post].*, [User].[Username] from Post left join [User] ON [User].[UserId] = [Post].[UserId] where [Post].[UserId] = {userId}", this._conn);
            // Defines the command type
            this._command.CommandType = CommandType.Text;
            // Getting the data and closing the connection
            IDataReader dataReader = this._command.ExecuteReader(CommandBehavior.CloseConnection);

            // Storing the data
            while (dataReader.Read())
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

                User myUser = new User
                {
                    UserId = post.PostId,
                    Username = dataReader["Username"] is DBNull ? "This post may have been deleted." : dataReader["Username"].ToString(),
                };

                post.Writer = myUser;

                posts.Add(post);
            }

            return posts;
        }

        public bool Create(Post post)
        {
            bool result = false;

            // SQL query
            this._command = new SqlCommand("insert into  [Post] (UserId, Title, Content, Publishing_Date, Modified_Date) values (@UserId, @Title, @Content, @Publishing_Date, @Modified_Date)", this._conn);
            this._command.Parameters.AddWithValue("@UserId", post.UserId);
            this._command.Parameters.AddWithValue("@Title", post.Title);
            this._command.Parameters.AddWithValue("@Content", post.Content);
            this._command.Parameters.AddWithValue("@Publishing_Date", post.Publishing_Date);
            this._command.Parameters.AddWithValue("@Modified_Date", post.Modified_Date);

            // Getting the querry result
            int success = this._command.ExecuteNonQuery();

            result = success != 0 ? true : false;

            return result;
        }

        public bool Update(Post post)
        {
            bool result = false;

            // SQL query
            this._command = new SqlCommand("update [Post] set [Title]=@Title, [Content]=@Content, [Modified_Date]=@Modified_Date where [Post].[PostId] = @PostId", this._conn);
            this._command.Parameters.AddWithValue("@Title", post.Title);
            this._command.Parameters.AddWithValue("@Content", post.Content);
            this._command.Parameters.AddWithValue("@Modified_Date", post.Modified_Date);
            this._command.Parameters.AddWithValue("@PostId", post.PostId);

            // Getting the querry result
            int success = this._command.ExecuteNonQuery();

            result = success != 0 ? true : false;

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;

            // SQL query
            this._command = new SqlCommand("delete [Post] where [Post].[PostId] = @PostId", this._conn);
            this._command.Parameters.AddWithValue("@PostId", id);

            // Getting the querry result
            int success = this._command.ExecuteNonQuery();

            result = success != 0 ? true : false;

            return result;
        }

        public bool Delete(Post post)
        {
            return Delete(post.PostId);
        }
    }
}
