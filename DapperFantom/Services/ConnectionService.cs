using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Services
{
    public class ConnectionService
    {
        private SqlConnection _conn;
        private IConfiguration _config;

        public ConnectionService(IConfiguration config)
        {
            this._config = config;
            string connString = this._config.GetConnectionString("Default").ToString();
            this._conn = new SqlConnection(connString);

            if (this._conn.State != ConnectionState.Open)
            {
                this._conn.Open();
            }
        }

        internal SqlConnection DbConnection()
        {
            return this._conn;
        }

        internal SqlConnection ForDapper()
        {
            var state = this._conn.State;

            if (state != ConnectionState.Open)
            {
                this._conn.Open();
            }

            return this._conn;
        }
    }
}
