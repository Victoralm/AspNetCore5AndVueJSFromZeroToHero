using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Entities
{
    /// <summary>
    /// POCO class representing the Category Db table
    /// </summary>
    public class Category
    {
        [Dapper.Contrib.Extensions.Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a Category name")]
        [MinLength(4, ErrorMessage = "Min 4 characters")]
        [MaxLength(50, ErrorMessage = "Max 50 characters")]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please enter a Slug name")]
        [MinLength(4, ErrorMessage = "Min 4 characters")]
        [MaxLength(50, ErrorMessage = "Max 50 characters")]
        [Display(Name = "Slug name")]
        public string Slug { get; set; }

        public byte OrderBy { get; set; }
    }
}
