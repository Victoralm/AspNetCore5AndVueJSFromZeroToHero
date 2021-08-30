using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Entities
{
    /// <summary>
    /// POCO class representing the Article Db table
    /// </summary>
    public class Article
    {
        [Dapper.Contrib.Extensions.Key]
        public int ArticleId { get; set; }
        public string Guid { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter your name and surname")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Please enter the Title for the Article")]
        public string Title { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "Please select a city")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please enter your Email address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a correct email")]
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter the Content for the Article")]
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte Seen { get; set; }
        public byte Status { get; set; }
        public int HomeView { get; set; }
        public int Hit { get; set; }
        public int CommentCount { get; set; }
    }
}
