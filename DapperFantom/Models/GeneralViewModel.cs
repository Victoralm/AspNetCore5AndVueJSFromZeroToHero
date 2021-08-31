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
        public List<Category> CategorieList { get; set; }
        public Citiy City { get; set; }
        public List<Citiy> CityList { get; set; }
        public Article Article { get; set; }
        public List<Article> ArticleList { get; set; }

        public GeneralViewModel()
        {
            Category = new Category();
            CategorieList = new List<Category>();
            City = new Citiy();
            CityList = new List<Citiy>();
            Article = new Article();
            ArticleList = new List<Article>();
        }
    }
}
