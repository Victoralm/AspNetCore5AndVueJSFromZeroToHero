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
        public List<Category> CategoryList { get; set; }
        public City City { get; set; }
        public List<City> CityList { get; set; }
        public Article Article { get; set; }
        public List<Article> ArticleList { get; set; }
        public Admin User { get; set; }
        public List<Admin> UserList { get; set; }

        public UserViewModel()
        {
            Category = new Category();
            CategoryList = new List<Category>();
            City = new City();
            CityList = new List<City>();
            Article = new Article();
            ArticleList = new List<Article>();
            User = new Admin();
            UserList = new List<Admin>();
        }
    }
}
