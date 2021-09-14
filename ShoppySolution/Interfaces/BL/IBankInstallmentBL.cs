using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IBankInstallmentBL
    {
        BankInstallmentDO Add(BankInstallmentDO model);
        bool Update(BankInstallmentDO model);
        bool Delete(BankInstallmentDO model);
        BankInstallmentDO GetById(int id);
        BankInstallmentDO Get(Expression<Func<BankInstallmentDO, bool>> predicate = null);
        List<BankInstallmentDO> GetList(Expression<Func<BankInstallmentDO, bool>> filter = null);
    }
}
