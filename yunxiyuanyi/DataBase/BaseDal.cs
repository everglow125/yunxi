using IDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class BaseDal<T> : IBaseDal<T> where T : class
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public virtual bool IsExisted(T t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public virtual bool IsExisted(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public virtual IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public virtual IList<T> GetList(T t)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public virtual IList<T> GetList(T t, out int recordCount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public virtual T GetById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public virtual int Insert(T t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public virtual int BatchInsert(IList<T> ts)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        public virtual int Update(T t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public virtual int BatchUpdate(IList<T> ts)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public virtual int Delete(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual int Delete(IList<long> ids)
        {
            throw new NotImplementedException();
        }
    }
}
