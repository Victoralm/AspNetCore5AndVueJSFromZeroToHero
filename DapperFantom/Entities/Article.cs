using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Entities
{
    /// <summary>
    /// POCO class representing the Article Db table
    /// </summary>
    public class Article
    {
        public int ArticleId { get; set; }
        public string Guid { get; set; }
        public int CategoryId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
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
