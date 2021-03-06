using Adonet_Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonet_Blog.Models
{
    public class BlogModel
    {
        public List<Post> postList { get; set; }
        public Post post { get; set; }
        public List<User> userList { get; set; }
        public User user { get; set; }

        public BlogModel()
        {
            postList = new List<Post>();
            post = new Post();
            userList = new List<User>();
            user = new User();
        }
    }
}
