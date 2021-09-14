using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IPaymentService
    {
        public Payment Add(Payment entity);

        public bool Delete(Payment entity);

        public bool Update(Payment entity);

        public Payment GetById(int id);

        public Payment Get(Expression<Func<Payment, bool>> predicate = null);

        public List<Payment> GetList(Expression<Func<Payment, bool>> filter = null);
    }
}
