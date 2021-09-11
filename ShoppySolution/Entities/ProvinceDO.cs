using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class ProvinceDO
    /// </summary>
    public class ProvinceDO
    {
        public ProvinceDO()
        {
            Cities = new List<CityDO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Order { get; set; }

        public virtual List<CityDO> Cities { get; set; }
    }
}
