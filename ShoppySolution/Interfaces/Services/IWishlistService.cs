using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IWishlistService
    {
        public Wishlist Add(Wishlist entity);

        public bool Delete(Wishlist entity);

        public bool Update(Wishlist entity);

        public Wishlist GetById(int id);

        public Wishlist Get(Expression<Func<Wishlist, bool>> predicate = null);

        public List<Wishlist> GetList(Expression<Func<Wishlist, bool>> filter = null);
    }
}
