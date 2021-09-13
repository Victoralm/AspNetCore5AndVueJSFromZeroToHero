using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICityService
    {
        public City Add(City entity);

        public bool Delete(City entity);

        public void Update(City entity);

        public City GetById(int id);

        public City Get(Expression<Func<City, bool>> predicate = null);

        public List<City> GetList(Expression<Func<City, bool>> filter = null);
    }
}
