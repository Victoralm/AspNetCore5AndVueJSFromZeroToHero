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
        public List<Category> CategoryList { get; set; }
        public City City { get; set; }
        public List<City> CityList { get; set; }
        public Article Article { get; set; }
        public List<Article> ArticleList { get; set; }
        public Article PrevArticle { get; set; }
        public Article NextArticle { get; set; }

        public GeneralViewModel()
        {
            Category = new Category();
            CategoryList = new List<Category>();
            City = new City();
            CityList = new List<City>();
            Article = new Article();
            ArticleList = new List<Article>();
            PrevArticle = new Article();
            NextArticle = new Article();
        }
    }
}
