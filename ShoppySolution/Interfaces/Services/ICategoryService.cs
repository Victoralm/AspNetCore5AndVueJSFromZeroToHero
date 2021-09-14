using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICategoryService
    {
        public Category Add(Category entity);

        public bool Delete(Category entity);

        public bool Update(Category entity);

        public Category GetById(int id);

        public Category Get(Expression<Func<Category, bool>> predicate = null);

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null);
    }
}
