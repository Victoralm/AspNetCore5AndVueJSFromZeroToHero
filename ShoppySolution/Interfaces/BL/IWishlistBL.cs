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
        WishlistDO Update(WishlistDO model);
        bool Delete(WishlistDO model);
        WishlistDO GetById(int id);
        WishlistDO GetById(Expression<Func<WishlistDO, bool>> predicate = null);
        List<WishlistDO> GetList(Expression<Func<WishlistDO, bool>> filter = null);
    }
}
