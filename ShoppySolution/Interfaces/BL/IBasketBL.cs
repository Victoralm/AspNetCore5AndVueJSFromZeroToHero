using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IBasketBL
    {
        BasketDO Add(BasketDO model);
        BasketDO Update(BasketDO model);
        bool Delete(BasketDO model);
        BasketDO GetById(int id);
        BasketDO GetById(Expression<Func<BasketDO, bool>> predicate = null);
        List<BasketDO> GetList(Expression<Func<BasketDO, bool>> filter = null);
    }
}
