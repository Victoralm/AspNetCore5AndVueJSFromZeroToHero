using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IResetpasswordBL
    {
        ResetpasswordDO Add(ResetpasswordDO model);
        bool Update(ResetpasswordDO model);
        bool Delete(ResetpasswordDO model);
        ResetpasswordDO GetById(int id);
        ResetpasswordDO Get(Expression<Func<ResetpasswordDO, bool>> predicate = null);
        List<ResetpasswordDO> GetList(Expression<Func<ResetpasswordDO, bool>> filter = null);
    }
}
