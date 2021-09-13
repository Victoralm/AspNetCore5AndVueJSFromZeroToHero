using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IOrderitemBL
    {
        OrderitemDO Add(OrderitemDO model);
        OrderitemDO Update(OrderitemDO model);
        bool Delete(OrderitemDO model);
        OrderitemDO GetById(int id);
        OrderitemDO GetById(Expression<Func<OrderitemDO, bool>> predicate = null);
        List<OrderitemDO> GetList(Expression<Func<OrderitemDO, bool>> filter = null);
    }
}
