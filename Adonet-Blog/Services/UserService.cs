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
    /// Used to get and send data to the User Db table
    /// </summary>
    public class UserService
    {
        private SqlConnection _conn;
        SqlCommand _command;
        PostService _postServ;

        /// <summary>
        /// Injecting IConfiguration as dependency
        /// </summary>
        /// <param name="config"></param>
        public UserService(IConfiguration config)
        {
            ConnectionService connServ = new ConnectionService(config);
            this._conn = connServ.DbConnection();
            //this._postServ = new PostService(config);
        }


        public User GetSingleUser(int id)
        {
            User user = new User();
            // SQL query
            this._command = new SqlCommand($"select * from [User] where [UserId] = {id}", this._conn);
            // Defines the command type
            this._command.CommandType = CommandType.Text;
            // Getting the data and closing the connection
            IDataReader dataReader = this._command.ExecuteReader(CommandBehavior.CloseConnection);

            // Storing the data
            while (dataReader.Read())
            {
                user.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString());
                user.Username = dataReader["Username"] is DBNull ? string.Empty : dataReader["Username"].ToString();
                user.Password = dataReader["Password"] is DBNull ? string.Empty : dataReader["Password"].ToString();
            }

            return user;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            // SQL query
            this._command = new SqlCommand("select * from [User]", this._conn);
            // Defines the command type
            this._command.CommandType = CommandType.Text;
            // Getting the data and closing the connection
            IDataReader dataReader = this._command.ExecuteReader(CommandBehavior.CloseConnection);

            // Storing the data
            while (dataReader.Read())
            {
                User user = new User();
                user.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString());
                user.Username = dataReader["Username"] is DBNull ? string.Empty : dataReader["Username"].ToString();
                user.Password = dataReader["Password"] is DBNull ? string.Empty : dataReader["Password"].ToString();

                users.Add(user);
            }

            return users;
        }

        public User Login(User user)
        {
            return Login(user.Username, user.Password);
        }
        
        public User Login(string username, string password)
        {
            User myUser = new User();

            // SQL query
            //this._command = new SqlCommand($"select * from [User] where [Username] = {username} and [Password] = {password}", this._conn);
            //// Defines the command type
            //this._command.CommandType = CommandType.Text;
            //// Getting the data and closing the connection
            //IDataReader dataReader = this._command.ExecuteReader(CommandBehavior.CloseConnection);

            string mySqlQuery = "select * from [User] where [Username] = @username and [Password] = @password";
            this._command = new SqlCommand(mySqlQuery, this._conn);
            this._command.Parameters.AddWithValue("@username", username);
            this._command.Parameters.AddWithValue("@password", password);
            IDataReader dataReader = this._command.ExecuteReader(CommandBehavior.CloseConnection);

            // Storing the data
            while (dataReader.Read())
            {
                myUser.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString());
                myUser.Username = dataReader["Username"] is DBNull ? string.Empty : dataReader["Username"].ToString();
                myUser.Password = dataReader["Password"] is DBNull ? string.Empty : dataReader["Password"].ToString();
            }

            return myUser;
        }
    }
}
