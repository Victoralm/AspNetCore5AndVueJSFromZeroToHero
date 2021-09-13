using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface ICityBL
    {
        CityDO Add(CityDO model);
        CityDO Update(CityDO model);
        bool Delete(CityDO model);
        CityDO GetById(int id);
        CityDO GetById(Expression<Func<CityDO, bool>> predicate = null);
        List<CityDO> GetList(Expression<Func<CityDO, bool>> filter = null);
    }
}
