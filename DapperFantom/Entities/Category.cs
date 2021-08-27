using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Entities
{
    /// <summary>
    /// POCO class representing the Category Db table
    /// </summary>
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public byte OrderBy { get; set; }
    }
}
