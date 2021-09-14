using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ISettingService
    {
        public Setting Add(Setting entity);

        public bool Delete(Setting entity);

        public bool Update(Setting entity);

        public Setting GetById(int id);

        public Setting Get(Expression<Func<Setting, bool>> predicate = null);

        public List<Setting> GetList(Expression<Func<Setting, bool>> filter = null);
    }
}
