using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IShippingBL
    {
        ShippingDO Add(ShippingDO model);
        bool Update(ShippingDO model);
        bool Delete(ShippingDO model);
        ShippingDO GetById(int id);
        ShippingDO Get(Expression<Func<ShippingDO, bool>> predicate = null);
        List<ShippingDO> GetList(Expression<Func<ShippingDO, bool>> filter = null);
    }
}
