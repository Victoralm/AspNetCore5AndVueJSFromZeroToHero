using DapperFantom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Models
{
    public class UserViewModel
    {
        public Category Category { get; set; }
        public List<Category> CategorieList { get; set; }
        public Citiy City { get; set; }
        public List<Citiy> CityList { get; set; }
        public Article Article { get; set; }
        public List<Article> ArticleList { get; set; }
        public Admin User { get; set; }
        public List<Admin> UserList { get; set; }

        public UserViewModel()
        {
            Category = new Category();
            CategorieList = new List<Category>();
            City = new Citiy();
            CityList = new List<Citiy>();
            Article = new Article();
            ArticleList = new List<Article>();
            User = new Admin();
            UserList = new List<Admin>();
        }
    }
}
