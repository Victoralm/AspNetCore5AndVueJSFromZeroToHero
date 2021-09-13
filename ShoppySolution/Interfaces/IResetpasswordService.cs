using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IResetpasswordService
    {
        public Resetpassword Add(Resetpassword entity);

        public bool Delete(Resetpassword entity);

        public void Update(Resetpassword entity);

        public Resetpassword GetById(int id);

        public Resetpassword Get(Expression<Func<Resetpassword, bool>> predicate = null);

        public List<Resetpassword> GetList(Expression<Func<Resetpassword, bool>> filter = null);
    }
}
