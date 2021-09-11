﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.MySqlDbContext
{
    public partial class Resetpassword
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public DateTime? Lastdate { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual User User { get; set; }
    }
}
