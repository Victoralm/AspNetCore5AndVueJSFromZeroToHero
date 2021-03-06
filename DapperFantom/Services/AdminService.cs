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

        public List<Admin> GetAllUsers()
        {
            List<Admin> userList = new List<Admin>();

            try
            {
                userList = this._dapperConnection.Query<Admin>(@"select * from [Admins]").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userList;
        }

        public int AddUser(Admin adm)
        {
            var result = this._dapperConnection.Insert(adm);

            return Convert.ToInt32(result);
        }

        public Admin GetUserById(int id)
        {
            Admin admin = new Admin();

            try
            {
                var par = new DynamicParameters();
                par.Add("@AdminId", id);
                admin = this._dapperConnection.Query<Admin>($@"select * from [Admins] where [AdminId]=@AdminId", par).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return admin;
        }

        public Admin UpdateUser(Admin adm)
        {
            
            try
            {
                var par = new DynamicParameters();
                par.Add("@id", adm.AdminId);
                par.Add("@Username", adm.Username);
                par.Add("@Password", adm.Password);
                this._dapperConnection.Execute($@"update [Admins] set [Username]=@Username, [Password]=@Password where [AdminId]=@id", par);
                return adm;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Admin();
            }
        }

        public bool DeleteUser(Admin adm)
        {
            try
            {
                var par = new DynamicParameters();
                par.Add("@id", adm.AdminId);
                this._dapperConnection.Execute($@"delete from [Admins] where [AdminId]=@id", par);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
