using DapperFantom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Models
{
    public class PaginationModel
    {
        public int TotalCount { get; set; }
        public List<Article> ArticleList { get; set; }
        public string Html { get; set; }
        public int PageCount { get; set; }
    }
}
