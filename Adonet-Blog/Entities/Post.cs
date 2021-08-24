using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonet_Blog.Entities
{
    /// <summary>
    /// POCO class for the Post DB table
    /// </summary>
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Publishing_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public User Writer { get; set; }
    }
}
