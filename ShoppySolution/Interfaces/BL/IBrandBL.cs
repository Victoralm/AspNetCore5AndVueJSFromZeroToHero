using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IBrandBL
    {
        BrandDO Add(BrandDO model);
        bool Update(BrandDO model);
        bool Delete(BrandDO model);
        BrandDO GetById(int id);
        BrandDO Get(Expression<Func<BrandDO, bool>> predicate = null);
        List<BrandDO> GetList(Expression<Func<BrandDO, bool>> filter = null);
    }
}
