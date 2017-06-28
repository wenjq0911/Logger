using Logger.Data;
using Logger.Domain;
using Logger.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Dao
{
    public class DeptDao : BaseDao<Dept>, IDeptDao
    {
        public void Save(Dept dept)
        {
            _db.Insert(dept);
        }
    }
}
