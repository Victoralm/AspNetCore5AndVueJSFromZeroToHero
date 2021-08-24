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

            // Opens the connection with the Db if not opened already
            if (this._conn.State != ConnectionState.Open)
            {
                this._conn.Open();
            }
        }
    }
}
