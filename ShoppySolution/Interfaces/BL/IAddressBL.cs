using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IAddressBL
    {
        AddressDO Add(AddressDO model);
        AddressDO Update(AddressDO model);
        bool Delete(AddressDO model);
        AddressDO GetById(int id);
        AddressDO GetById(Expression<Func<AddressDO, bool>> predicate = null);
        List<AddressDO> GetList(Expression<Func<AddressDO, bool>> filter = null);
    }
}
