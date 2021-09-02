using Dapper;
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

        public List<Citiy> GetAllCitiesDapper()
        {
            List<Citiy> citList = new List<Citiy>();

            try
            {
                citList = this._dapperConnection.Query<Citiy>(@"select * from [Citys]").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return citList;
        }
    }
}
