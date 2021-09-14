using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IProductImageBL
    {
        ProductImageDO Add(ProductImageDO model);
        bool Update(ProductImageDO model);
        bool Delete(ProductImageDO model);
        ProductImageDO GetById(int id);
        ProductImageDO Get(Expression<Func<ProductImageDO, bool>> predicate = null);
        List<ProductImageDO> GetList(Expression<Func<ProductImageDO, bool>> filter = null);
    }
}
