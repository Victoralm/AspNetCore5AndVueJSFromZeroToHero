using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IUnitBL
    {
        UnitDO Add(UnitDO model);
        UnitDO Update(UnitDO model);
        bool Delete(UnitDO model);
        UnitDO GetById(int id);
        UnitDO GetById(Expression<Func<UnitDO, bool>> predicate = null);
        List<UnitDO> GetList(Expression<Func<UnitDO, bool>> filter = null);
    }
}
