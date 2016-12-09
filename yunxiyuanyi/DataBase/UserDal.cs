using Entity.LogicModel;
using IDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class UserDal : BaseDal<User>, IUserDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(User t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<User> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<User> GetList(User t)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<User> GetList(User t, out int recordCount, int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override User GetById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(User t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<User> ts)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(User t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<User> ts)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            throw new NotImplementedException();
        }
    }
}
