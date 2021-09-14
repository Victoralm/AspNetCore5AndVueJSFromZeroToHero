using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IPageService
    {
        public Page Add(Page entity);

        public bool Delete(Page entity);

        public bool Update(Page entity);

        public Page GetById(int id);

        public Page Get(Expression<Func<Page, bool>> predicate = null);

        public List<Page> GetList(Expression<Func<Page, bool>> filter = null);
    }
}
