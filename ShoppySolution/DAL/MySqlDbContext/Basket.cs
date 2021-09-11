﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.MySqlDbContext
{
    public partial class Basket
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
        public int Piece { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
