using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IBankInstallmentService
    {
        public BankInstallment Add(BankInstallment entity);

        public bool Delete(BankInstallment entity);

        public bool Update(BankInstallment entity);

        public BankInstallment GetById(int id);

        public BankInstallment Get(Expression<Func<BankInstallment, bool>> predicate = null);

        public List<BankInstallment> GetList(Expression<Func<BankInstallment, bool>> filter = null);
    }
}
