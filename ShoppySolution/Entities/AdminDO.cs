using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class AdminDO
    /// </summary>
    public class AdminDO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter an username")]
        [MaxLength(15, ErrorMessage = "Maximum of 15 characters for username")]
        [MinLength(4, ErrorMessage = "Minimum of 4 characters for username")]
        [Display(Name = "Admin username")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [MaxLength(15, ErrorMessage = "Maximum of 15 characters for password")]
        [MinLength(4, ErrorMessage = "Minimum of 4 characters for password")]
        [Display(Name = "Admin password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Authority")]
        public int? Authority { get; set; }

        [Display(Name = "Active")]
        public int? Confirmation { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [MaxLength(15, ErrorMessage = "Maximum of 15 characters for your name")]
        [MinLength(4, ErrorMessage = "Minimum of 4 characters for your name")]
        [Display(Name = "Admin name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname")]
        [MaxLength(15, ErrorMessage = "Maximum of 15 characters for your surname")]
        [MinLength(4, ErrorMessage = "Minimum of 4 characters for your surname")]
        [Display(Name = "Admin surname")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [MaxLength(25, ErrorMessage = "Maximum of 25 characters for your email")]
        [MinLength(8, ErrorMessage = "Minimum of 8 characters for your email")]
        [Display(Name = "Admin email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
