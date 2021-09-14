using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IProvinceService
    {
        public Province Add(Province entity);

        public bool Delete(Province entity);

        public bool Update(Province entity);

        public Province GetById(int id);

        public Province Get(Expression<Func<Province, bool>> predicate = null);

        public List<Province> GetList(Expression<Func<Province, bool>> filter = null);
    }
}
