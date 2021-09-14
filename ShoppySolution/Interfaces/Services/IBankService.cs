using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IBankService
    {
        public Bank Add(Bank entity);

        public bool Delete(Bank entity);

        public bool Update(Bank entity);

        public Bank GetById(int id);

        public Bank Get(Expression<Func<Bank, bool>> predicate = null);

        public List<Bank> GetList(Expression<Func<Bank, bool>> filter = null);
    }
}
