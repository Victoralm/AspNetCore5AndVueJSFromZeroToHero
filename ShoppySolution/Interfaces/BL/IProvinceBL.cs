using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IProvinceBL
    {
        ProvinceDO Add(ProvinceDO model);
        ProvinceDO Update(ProvinceDO model);
        bool Delete(ProvinceDO model);
        ProvinceDO GetById(int id);
        ProvinceDO GetById(Expression<Func<ProvinceDO, bool>> predicate = null);
        List<ProvinceDO> GetList(Expression<Func<ProvinceDO, bool>> filter = null);
    }
}
