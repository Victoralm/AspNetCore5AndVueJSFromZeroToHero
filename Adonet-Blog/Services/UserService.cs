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

        
        public UserService(IConfiguration config)
        {
            ConnectionService connServ = new ConnectionService(config);
            this._conn = connServ.DbConnection();
        }
    }
}
