﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Entities
{
    /// <summary>
    /// POCO class representing the City Db table
    /// </summary>
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
