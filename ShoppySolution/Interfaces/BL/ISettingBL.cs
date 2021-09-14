using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface ISettingBL
    {
        SettingDO Add(SettingDO model);
        bool Update(SettingDO model);
        bool Delete(SettingDO model);
        SettingDO GetById(int id);
        SettingDO Get(Expression<Func<SettingDO, bool>> predicate = null);
        List<SettingDO> GetList(Expression<Func<SettingDO, bool>> filter = null);
    }
}
