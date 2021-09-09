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

        public List<Comment> GetAllCommntsFromArticle(int articleId)
        {
            List<Comment> commentLst = new List<Comment>();

            try
            {
                var par = new DynamicParameters();
                par.Add("@ArticleId", articleId);
                commentLst = this._dapperConnection.Query<Comment>("select * from [Comments] where [ArticleId] = @ArticleId order by [CreatedDate] asc", par).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return commentLst;
        }
    }
}
