using Dapper;
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
    public class CityService
    {
        private IDbConnection _dapperConnection;
        private ConnectionService _connectionService;

        public CityService(IConfiguration config)
        {
            this._connectionService = new ConnectionService(config);
            this._dapperConnection = this._connectionService.ForDapper();
        }

        public List<City> GetAllCitiesDapper()
        {
            List<City> citList = new List<City>();

            try
            {
                citList = this._dapperConnection.Query<City>(@"select * from [Citys]").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return citList;
        }

        public List<City> GetAllCitiesAlt()
        {
            List<City> citList = new List<City>();

            try
            {
                citList = this._dapperConnection.GetAll<City>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return citList;
        }
    }
}
