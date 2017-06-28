﻿using Chloe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Domain
{
    [Table("Users")]
    public class UserInfo
    {
        [AutoIncrement]
        public int id { get; set; }
        public string  name { get; set; }
    }
}
