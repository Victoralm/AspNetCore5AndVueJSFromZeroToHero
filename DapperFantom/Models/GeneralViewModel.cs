using DapperFantom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Models
{
    public class GeneralViewModel
    {
        public Category Category { get; set; }
        public Article Article { get; set; }
        public List<Category> CategorieList { get; set; }
        public List<Article> ArticleList { get; set; }
    }
}
