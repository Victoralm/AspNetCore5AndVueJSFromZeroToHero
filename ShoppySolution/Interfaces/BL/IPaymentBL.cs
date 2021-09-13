using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IPaymentBL
    {
        PaymentDO Add(PaymentDO model);
        PaymentDO Update(PaymentDO model);
        bool Delete(PaymentDO model);
        PaymentDO GetById(int id);
        PaymentDO GetById(Expression<Func<PaymentDO, bool>> predicate = null);
        List<PaymentDO> GetList(Expression<Func<PaymentDO, bool>> filter = null);
    }
}
