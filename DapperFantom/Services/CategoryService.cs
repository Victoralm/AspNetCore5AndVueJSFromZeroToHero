﻿using Dapper;
using Dapper.Contrib.Extensions;
using DapperFantom.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Services
{
    public class CategoryService
    {
        private SqlConnection _adoNetConnection;
        private IDbConnection _dapperConnection;
        private ConnectionService _connectionService;

        public CategoryService(IConfiguration config)
        {
            this._connectionService = new ConnectionService(config);
            this._adoNetConnection = this._connectionService.DbConnection();
            this._dapperConnection = this._connectionService.ForDapper();
        }

        public List<Category> GetAllCategAdoNet()
        {
            List<Category> categories = new List<Category>();

            // SQL query
            SqlCommand command = new SqlCommand("select * from [Categorys]", this._adoNetConnection);
            // Defines the command type
            command.CommandType = CommandType.Text;

            // Getting the data and closing the connection
            IDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Storing the data
            while (dataReader.Read())
            {
                Category categ = new Category();

                categ.CategoryId = dataReader["CategoryId"] is DBNull ? 0 : int.Parse(dataReader["CategoryId"].ToString());
                categ.CategoryName = dataReader["CategoryName"] is DBNull ? "" : dataReader["CategoryName"].ToString();
                categ.Slug = dataReader["Slug"] is DBNull ? "" : dataReader["Slug"].ToString();
                //categ.OrderBy = (byte)(dataReader["OrderBy"] is DBNull ? 0 : Convert.ToByte(dataReader["OrderBy"].ToString()));
                categ.OrderBy = (byte)(dataReader["OrderBy"] is DBNull ? 0 : byte.Parse(dataReader["OrderBy"].ToString()));

                categories.Add(categ);
            }

            return categories;
        }

        public int AddCategory(Category category)
        {
            try
            {
                // The Dapper table plural nomenclatures are a little bit annoying!!!
                var result = this._dapperConnection.Insert(category);

                //var par = new DynamicParameters();
                //par.Add("@CategoryName", categ.CategoryName);
                //par.Add("@Slug", categ.Slug);
                //var result = this._dapperConnection.Query<Category>("insert into [Categories] ([CategoryName], [Slug]) values (@CategoryName, @Slug"), par);

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return 0;
            }
        }

        public List<Category> GetAllCategDapper()
        {
            List<Category> categories = new List<Category>();

            try
            {
                categories = this._dapperConnection.Query<Category>(@"select * from [Categorys]").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return categories;
        }
    }
}
