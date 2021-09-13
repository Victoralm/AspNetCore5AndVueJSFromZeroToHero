using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IAdminBL
    {
        AdminDO Add(AdminDO model);
        AdminDO Update(AdminDO model);
        bool Delete(AdminDO model);
        AdminDO GetById(int id);
        AdminDO GetById(Expression<Func<AdminDO, bool>> predicate = null);
        List<AdminDO> GetList(Expression<Func<AdminDO, bool>> filter = null);
        AddressDO Login(AddressDO model);
    }
}
