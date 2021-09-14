using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IShippingService
    {
        public Shipping Add(Shipping entity);

        public bool Delete(Shipping entity);

        public bool Update(Shipping entity);

        public Shipping GetById(int id);

        public Shipping Get(Expression<Func<Shipping, bool>> predicate = null);

        public List<Shipping> GetList(Expression<Func<Shipping, bool>> filter = null);
    }
}
