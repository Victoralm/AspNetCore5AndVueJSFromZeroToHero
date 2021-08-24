using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonet_Blog.Entities
{
    /// <summary>
    /// POCO class for the User DB table
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Post> Posts { get; set; }
    }
}
