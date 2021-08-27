using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Entities
{
    /// <summary>
    /// POCO class representing the Comment Db table
    /// </summary>
    public class Comment
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
