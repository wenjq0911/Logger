using Logger.Data.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data
{
    public class BaseDao<T>
    {
        public Db<T> _db { get; set; }

        public BaseDao()
        {
            _db = new Db<T>();
        }
    }
}
