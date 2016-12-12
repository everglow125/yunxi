using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataBase
{
    public interface IBaseDal<T> where T : class
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        bool IsExisted(T t);

        /// <summary>
        /// 是否已存在
        /// </summary>
        bool IsExisted(int Id);

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        IList<T> GetAll();

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        IList<T> GetList(T t);


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        IList<T> GetList(T t, out int recordCount);

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        T GetById(long id);

        /// <summary>
        /// 新增对象
        /// </summary>
        int Insert(T t);

        /// <summary>
        /// 批量新增对象
        /// </summary>
        int BatchInsert(IList<T> ts);

        /// <summary>
        /// 更新对象
        /// </summary>
        int Update(T t);

        /// <summary>
        /// 批量更新对象
        /// </summary>
        int BatchUpdate(IList<T> ts);

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        int Delete(long id);

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        int Delete(IList<long> ids);
    }
}
