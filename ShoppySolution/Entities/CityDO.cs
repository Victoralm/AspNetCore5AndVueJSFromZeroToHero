using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class CityDO
    /// </summary>
    public class CityDO
    {
        public CityDO()
        {
            Addresses = new List<AddressDO>();
            Users = new List<UserDO>();
        }

        public int Id { get; set; }
        public int Provinceid { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ProvinceDO Province { get; set; }
        public virtual List<AddressDO> Addresses { get; set; }
        public virtual List<UserDO> Users { get; set; }
    }
}
