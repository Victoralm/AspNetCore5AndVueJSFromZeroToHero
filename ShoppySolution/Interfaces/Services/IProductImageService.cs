using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IProductImageService
    {
        public ProductImage Add(ProductImage entity);

        public bool Delete(ProductImage entity);

        public bool Update(ProductImage entity);

        public ProductImage GetById(int id);

        public ProductImage Get(Expression<Func<ProductImage, bool>> predicate = null);

        public List<ProductImage> GetList(Expression<Func<ProductImage, bool>> filter = null);
    }
}
