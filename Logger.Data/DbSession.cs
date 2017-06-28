using Chloe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data
{
    public class DbSession
    {
        public static IDbSession session { get; set; }
    }

}
