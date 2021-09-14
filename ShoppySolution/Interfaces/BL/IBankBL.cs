using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IBankBL
    {
        BankDO Add(BankDO model);
        bool Update(BankDO model);
        bool Delete(BankDO model);
        BankDO GetById(int id);
        BankDO Get(Expression<Func<BankDO, bool>> predicate = null);
        List<BankDO> GetList(Expression<Func<BankDO, bool>> filter = null);
    }
}
