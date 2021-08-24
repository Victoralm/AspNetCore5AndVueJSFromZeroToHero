using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Adonet_Blog.Services
{
    public class ConnectionService
    {
        private SqlConnection _conn;
        private IConfiguration _config;

        public ConnectionService(IConfiguration config)
        {
            this._config = config;
            string connectionString = _config.GetConnectionString("Default").ToString();
            this._conn = new SqlConnection(connectionString);

            // Opens the connection with the Db if not opened already
            if (this._conn.State != ConnectionState.Open)
            {
                this._conn.Open();
            }
        }

        internal SqlConnection DbConnection()
        {
            return this._conn;
        }
    }
}
