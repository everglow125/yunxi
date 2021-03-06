using Entity.LogicModel;
using IDataBase;
using ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductCommentImageBll : IProductCommentImageBll
    {

        private IProductCommentImageDal Instance;
        public ProductCommentImageBll(IProductCommentImageDal instance)
        {
            Instance = instance;
        }
        /// <summary>
        /// 是否已存在
        /// </summary>
        public bool IsExisted(ProductCommentImage t)
        {
            return Instance.IsExisted(t);
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public bool IsExisted(int Id)
        {
            return Instance.IsExisted(Id);
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public IList<ProductCommentImage> GetAll()
        {
            return Instance.GetAll();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public IList<ProductCommentImage> GetList(ProductCommentImage t)
        {
            return Instance.GetList(t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public IList<ProductCommentImage> GetList(ProductCommentImage t, out int recordCount)
        {
            return Instance.GetList(t, out recordCount);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public ProductCommentImage GetById(long id)
        {
            return Instance.GetById(id);
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public int Insert(ProductCommentImage t)
        {
            return Instance.Insert(t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public int BatchInsert(IList<ProductCommentImage> ts)
        {
            return Instance.BatchInsert(ts);
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        public int Update(ProductCommentImage t)
        {
            return Instance.Update(t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public int BatchUpdate(IList<ProductCommentImage> ts)
        {
            return Instance.BatchUpdate(ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public int Delete(long id)
        {
            return Instance.Delete(id);
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(IList<long> ids)
        {
            return Instance.Delete(ids);
        }
    }
}

