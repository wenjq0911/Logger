using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data.Interface
{
    public interface IBaseDao<T>
    {
        Db<T> _db { get; set; }
    }
}
