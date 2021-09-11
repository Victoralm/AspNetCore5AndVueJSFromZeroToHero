﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.MySqlDbContext
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public int Productid { get; set; }
        public string Address { get; set; }
        public int Orderby { get; set; }

        public virtual Product Product { get; set; }
    }
}
