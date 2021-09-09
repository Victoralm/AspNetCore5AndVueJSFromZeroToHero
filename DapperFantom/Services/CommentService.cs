using Dapper;
using Dapper.Contrib.Extensions;
using DapperFantom.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Services
{
    public class CommentService
    {
        private IDbConnection _dapperConnection;
        private ConnectionService _connectionService;

        public CommentService(IConfiguration config)
        {
            this._connectionService = new ConnectionService(config);
            this._dapperConnection = this._connectionService.ForDapper();
        }

        public int AddComment(Comment comment)
        {
            try
            {
                long result = this._dapperConnection.Insert(comment);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
