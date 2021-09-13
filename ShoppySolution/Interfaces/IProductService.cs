using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProductService
    {
        public Product Add(Product entity);

        public bool Delete(Product entity);

        public void Update(Product entity);

        public Product GetById(int id);

        public Product Get(Expression<Func<Product, bool>> predicate = null);

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null);
    }
}
