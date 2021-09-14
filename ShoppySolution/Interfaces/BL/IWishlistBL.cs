using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IWishlistBL
    {
        WishlistDO Add(WishlistDO model);
        bool Update(WishlistDO model);
        bool Delete(WishlistDO model);
        WishlistDO GetById(int id);
        WishlistDO Get(Expression<Func<WishlistDO, bool>> predicate = null);
        List<WishlistDO> GetList(Expression<Func<WishlistDO, bool>> filter = null);
    }
}
