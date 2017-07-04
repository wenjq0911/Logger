using Chloe;
using Logger.Data.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data
{
    public class BaseService<T>
    {
        public IBaseDao<T> BaseDao { get; set; }

        public int Delete(Expression<Func<T, bool>> condition)
        {
            return BaseDao.Delete(condition);
        }

        public int Delete(T entity)
        {
            return BaseDao.Delete(entity);
        }

        public int DeleteByKey(object key)
        {
            return BaseDao.DeleteByKey(key);
        }

        public object Insert(Expression<Func<T>> body)
        {
            return BaseDao.Insert(body);
        }

        public T Insert(T entity)
        {
            return BaseDao.Insert(entity);
        }

        public IQuery<T> Query()
        {
            return BaseDao.Query();
        }

        public T QueryByKey(object key, bool tracking = false)
        {
            return BaseDao.QueryByKey(key, tracking);
        }

        public IEnumerable<T1> SqlQuery<T1>(string sql, params DbParam[] parameters) where T1 : new()
        {
            return BaseDao.SqlQuery<T1>(sql, parameters);
        }

        public IEnumerable<T1> SqlQuery<T1>(string sql, CommandType cmdType, params DbParam[] parameters) where T1 : new()
        {
            return BaseDao.SqlQuery<T1>(sql, cmdType, parameters);
        }

        public void TrackEntity(object entity)
        {
            BaseDao.TrackEntity(entity);
        }

        public int Update(T entity)
        {
            return BaseDao.Update(entity);
        }

        public int Update(Expression<Func<T, bool>> condition, Expression<Func<T, T>> body)
        {
            return BaseDao.Update(condition, body);
        }
        public IQuery<T> Query(Expression<Func<T, bool>> condition) {
            return BaseDao.Query(condition);
        }
        public IQuery<T> QueryByPage<S>(int page, int size, out long count, Expression<Func<T, bool>> where = null, Expression<Func<T, S>> order = null,bool asc=true) {
            return BaseDao.QueryByPage(page, size, out count,where,order, asc);
        }

    }
}
