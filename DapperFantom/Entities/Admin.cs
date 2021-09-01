using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Entities
{
    /// <summary>
    /// POCO class representing the Admin Db table
    /// </summary>
    public class Admin
    {
        [Dapper.Contrib.Extensions.Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        [MinLength(4, ErrorMessage = "Min 4 characters")]
        [MaxLength(50, ErrorMessage = "Max 50 characters")]
        [Display(Name = "Your Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(4, ErrorMessage = "Min 4 characters")]
        [MaxLength(50, ErrorMessage = "Max 50 characters")]
        [Display(Name = "Your Password")]
        public string Password { get; set; }
    }
}
