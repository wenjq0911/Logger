using Logger.Common;
using Logger.Data;
using Logger.Domain;
using Logger.IDao;
using Logger.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Service
{
    public class UserService : IUserService
    {
        public IUserDao UserDao { get; set; }
        public IDeptDao DeptDao { get; set; }


        [Transaction]
        public void Save(UserInfo user,Dept dept)
        {
            DeptDao.Save(dept);
            UserDao.Save(user);
        }
    }
}
