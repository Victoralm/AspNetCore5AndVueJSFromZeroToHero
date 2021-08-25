using Adonet_Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonet_Blog.Models
{
    public class LoginModel
    {
        public User User { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public LoginModel()
        {
            User = new User();
            Success = false;
            Message = string.Empty;
        }
    }
}
