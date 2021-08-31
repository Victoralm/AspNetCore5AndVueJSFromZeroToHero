﻿using Dapper;
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
    public class ArticleService
    {
        private IDbConnection _dapperConnection;
        private ConnectionService _connectionService;

        public ArticleService(IConfiguration config)
        {
            this._connectionService = new ConnectionService(config);
            this._dapperConnection = this._connectionService.ForDapper();
        }

        public int Add(Article article)
        {
            // The Dapper table plural nomenclatures are a little bit annoying...
            var result = this._dapperConnection.Insert(article);

            if(result > 0)
            {
                return int.Parse(result.ToString());
            }
            return 0;
        }

        public Article GetArticleById(int id)
        {
            Article article = new Article();

            try
            {
                article = this._dapperConnection.Query<Article>($"select * from [Articles] where [Articles].[ArticleId] = {id}").FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return article;
        }
    }
}