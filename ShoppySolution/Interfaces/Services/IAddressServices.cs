using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IAddressServices
    {
        public Address Add(Address entity);

        public bool Delete(Address entity);

        public void Update(Address entity);

        public Address GetById(int id);

        public Address Get(Expression<Func<Address, bool>> predicate = null);

        public List<Address> GetList(Expression<Func<Address, bool>> filter = null);
    }
}
