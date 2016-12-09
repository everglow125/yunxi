using IDataBase;
using ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BaseBll<T> : IBaseBll<T> where T : class
    {

        private IBaseDal<T> Instance;
        public BaseBll(IBaseDal<T> instance)
        {
            Instance = instance;
        }
        /// <summary>
        /// 是否已存在
        /// </summary>
        public virtual bool IsExisted(T t)
        {
            return Instance.IsExisted(t);
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public virtual bool IsExisted(int Id)
        {
            return Instance.IsExisted(Id);
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public virtual IList<T> GetAll()
        {
            return Instance.GetAll();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public virtual IList<T> GetList(T t)
        {
            return Instance.GetList(t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public virtual IList<T> GetList(T t, out int recordCount, int? pageIndex = null, int? pageSize = null)
        {
            return Instance.GetList(t, out recordCount, pageIndex, pageSize);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public virtual T GetById(long id)
        {
            return Instance.GetById(id);
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public virtual int Insert(T t)
        {
            return Instance.Insert(t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public virtual int BatchInsert(IList<T> ts)
        {
            return Instance.BatchInsert(ts);
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        public virtual int Update(T t)
        {
            return Instance.Update(t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public virtual int BatchUpdate(IList<T> ts)
        {
            return Instance.BatchUpdate(ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public virtual int Delete(long id)
        {
            return Instance.Delete(id);
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual int Delete(IList<long> ids)
        {
            return Instance.Delete(ids);
        }
    }
}
