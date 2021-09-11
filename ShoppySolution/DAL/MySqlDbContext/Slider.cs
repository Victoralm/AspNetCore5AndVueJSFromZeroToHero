using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.MySqlDbContext
{
    public partial class Slider
    {
        public int Id { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
    }
}
