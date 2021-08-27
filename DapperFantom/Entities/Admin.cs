using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Entities
{
    /// <summary>
    /// POCO class representing the Admin Db table
    /// </summary>
    public class Admin
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
