using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IProductBL
    {
        ProductDO Add(ProductDO model);
        ProductDO Update(ProductDO model);
        bool Delete(ProductDO model);
        ProductDO GetById(int id);
        ProductDO GetById(Expression<Func<ProductDO, bool>> predicate = null);
        List<ProductDO> GetList(Expression<Func<ProductDO, bool>> filter = null);
    }
}
