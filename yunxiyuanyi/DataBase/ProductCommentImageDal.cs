using Common;
using Entity.LogicModel;
using IDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ProductCommentImageDal : BaseDal<ProductCommentImage>, IProductCommentImageDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(ProductCommentImage t)
        {
            string sql = "select top 1 1 from product_comment_images  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from product_comment_images  where image_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<ProductCommentImage> GetAll()
        {
            string sql = "select * from product_comment_images  ";
            return MysqlDapper.ExecuteSql_ToList<ProductCommentImage,ProductCommentImage>(sql, null);
        }

        private string GetWhere(ProductCommentImage t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.ImageId>-1) sb.Append(" and image_id=@ImageId ");
			if(!string.IsNullOrEmpty(t.ImageUrl)) sb.Append(" and image_url=@ImageUrl ");
			if(t.CommentId>-1) sb.Append(" and comment_id=@CommentId ");
			if(!string.IsNullOrEmpty(t.CreateByName)) sb.Append(" and create_by_name=@CreateByName ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.ImageStatus>-1) sb.Append(" and image_status=@ImageStatus ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<ProductCommentImage> GetList(ProductCommentImage t)
        {
            string sql = "select * from product_comment_images  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<ProductCommentImage,ProductCommentImage>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<ProductCommentImage> GetList(ProductCommentImage t, out int recordCount)
        {
            string sql = "select * from product_comment_images  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from product_comment_images  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<ProductCommentImage,ProductCommentImage>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override ProductCommentImage GetById(long id)
        {
            string sql = "select top 1 * from product_comment_images  where image_id=@Id ";
            return MysqlDapper.ExecuteSql_First<ProductCommentImage,ProductCommentImage>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into product_comment_images (image_url,comment_id,create_by_name,create_by,create_time,image_status) values (@ImageUrl,@CommentId,@CreateByName,@CreateBy,@CreateTime,@ImageStatus)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(ProductCommentImage t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<ProductCommentImage> ts)
        {
            string sql = GetInsertStr();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        ///获取更新语句
        /// </summary>
        /// <returns></returns>
        private string GetUpdate()
        {
            string sql = "Update product_comment_images set image_url= @ImageUrl,comment_id= @CommentId,create_by_name= @CreateByName,image_status= @ImageStatus where image_id=@ImageId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(ProductCommentImage t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<ProductCommentImage> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from product_comment_images where image_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from product_comment_images where image_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

