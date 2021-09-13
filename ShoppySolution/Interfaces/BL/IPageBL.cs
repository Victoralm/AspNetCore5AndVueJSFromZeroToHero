using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IPageBL
    {
        PageDO Add(PageDO model);
        PageDO Update(PageDO model);
        bool Delete(PageDO model);
        PageDO GetById(int id);
        PageDO GetById(Expression<Func<PageDO, bool>> predicate = null);
        List<PageDO> GetList(Expression<Func<PageDO, bool>> filter = null);
    }
}
