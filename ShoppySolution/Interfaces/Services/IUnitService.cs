using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IUnitService
    {
        public Unit Add(Unit entity);

        public bool Delete(Unit entity);

        public bool Update(Unit entity);

        public Unit GetById(int id);

        public Unit Get(Expression<Func<Unit, bool>> predicate = null);

        public List<Unit> GetList(Expression<Func<Unit, bool>> filter = null);
    }
}
