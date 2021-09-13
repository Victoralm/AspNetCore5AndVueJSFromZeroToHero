using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IBrandService
    {
        public Brand Add(Brand entity);

        public bool Delete(Brand entity);

        public void Update(Brand entity);

        public Brand GetById(int id);

        public Brand Get(Expression<Func<Brand, bool>> predicate = null);

        public List<Brand> GetList(Expression<Func<Brand, bool>> filter = null);
    }
}
