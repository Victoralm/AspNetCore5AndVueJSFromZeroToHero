using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISliderService
    {
        public Slider Add(Slider entity);

        public bool Delete(Slider entity);

        public void Update(Slider entity);

        public Slider GetById(int id);

        public Slider Get(Expression<Func<Slider, bool>> predicate = null);

        public List<Slider> GetList(Expression<Func<Slider, bool>> filter = null);
    }
}
