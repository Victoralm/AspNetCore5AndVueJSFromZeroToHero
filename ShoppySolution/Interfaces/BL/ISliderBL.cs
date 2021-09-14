using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface ISliderBL
    {
        SliderDO Add(SliderDO model);
        bool Update(SliderDO model);
        bool Delete(SliderDO model);
        SliderDO GetById(int id);
        SliderDO Get(Expression<Func<SliderDO, bool>> predicate = null);
        List<SliderDO> GetList(Expression<Func<SliderDO, bool>> filter = null);
    }
}
