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
    public class AddressBL : IAddressBL
    {
        public AddressDO Add(AddressDO model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AddressDO model)
        {
            throw new NotImplementedException();
        }

        public AddressDO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AddressDO GetById(Expression<Func<AddressDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<AddressDO> GetList(Expression<Func<AddressDO, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public AddressDO Update(AddressDO model)
        {
            throw new NotImplementedException();
        }
    }
}
