using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.MySqlDbContext
{
    public partial class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
