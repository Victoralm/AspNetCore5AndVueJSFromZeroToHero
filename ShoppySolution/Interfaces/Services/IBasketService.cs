using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IBasketService
    {
        public Basket Add(Basket entity);

        public bool Delete(Basket entity);

        public bool Update(Basket entity);

        public Basket GetById(int id);

        public Basket Get(Expression<Func<Basket, bool>> predicate = null);

        public List<Basket> GetList(Expression<Func<Basket, bool>> filter = null);
    }
}
