using Dapper;
using DapperFantom.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Services
{
    public class AdminService
    {
        private IDbConnection _dapperConnection;
        private ConnectionService _connectionService;

        public AdminService(IConfiguration config)
        {
            this._connectionService = new ConnectionService(config);
            this._dapperConnection = this._connectionService.ForDapper();
        }

        public Admin Login(Admin adm)
        {
            Admin admin = new Admin();

            try
            {
                var par = new DynamicParameters();
                par.Add("@Username", adm.Username);
                par.Add("@Password", adm.Password);
                admin = this._dapperConnection.Query<Admin>($@"select [AdminId],[Username],[Password] from [Admins] where [Username]=@Username and [Password]=@Password", par).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return admin;
        }
    }
}
