using Entities;
using Interfaces.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AdminBL : IAdminBL
    {
        public AdminDO Add(AdminDO model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AdminDO model)
        {
            throw new NotImplementedException();
        }

        public AdminDO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AdminDO GetById(Expression<Func<AdminDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<AdminDO> GetList(Expression<Func<AdminDO, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public AddressDO Login(AddressDO model)
        {
            throw new NotImplementedException();
        }

        public AdminDO Update(AdminDO model)
        {
            throw new NotImplementedException();
        }
    }
}
