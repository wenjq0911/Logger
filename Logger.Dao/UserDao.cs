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
    public class UserDao : BaseDao<UserInfo>,IUserDao
    {
        public void Save(UserInfo user)
        {
            _db.Insert(user);
        }
    }
}
