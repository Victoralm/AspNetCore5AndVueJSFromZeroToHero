using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IUserBL
    {
        UserDO Add(UserDO model);
        UserDO Update(UserDO model);
        bool Delete(UserDO model);
        UserDO GetById(int id);
        UserDO GetById(Expression<Func<UserDO, bool>> predicate = null);
        List<UserDO> GetList(Expression<Func<UserDO, bool>> filter = null);
    }
}
