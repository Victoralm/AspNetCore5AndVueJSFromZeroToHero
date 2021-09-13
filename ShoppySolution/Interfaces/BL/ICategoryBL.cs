using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface ICategoryBL
    {
        CategoryDO Add(CategoryDO model);
        CategoryDO Update(CategoryDO model);
        bool Delete(CategoryDO model);
        CategoryDO GetById(int id);
        CategoryDO GetById(Expression<Func<CategoryDO, bool>> predicate = null);
        List<CategoryDO> GetList(Expression<Func<CategoryDO, bool>> filter = null);
    }
}
