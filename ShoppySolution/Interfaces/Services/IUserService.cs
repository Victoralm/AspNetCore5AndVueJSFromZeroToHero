using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IUserService
    {
        public User Add(User entity);

        public bool Delete(User entity);

        public bool Update(User entity);

        public User GetById(int id);

        public User Get(Expression<Func<User, bool>> predicate = null);

        public List<User> GetList(Expression<Func<User, bool>> filter = null);
    }
}
