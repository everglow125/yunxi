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
    public class ProductCommentDal : BaseDal<ProductComment>, IProductCommentDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(ProductComment t)
        {
            string sql = "select top 1 1 from product_comments  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from product_comments  where comment_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<ProductComment> GetAll()
        {
            string sql = "select * from product_comments  ";
            return MysqlDapper.ExecuteSql_ToList<ProductComment,ProductComment>(sql, null);
        }

        private string GetWhere(ProductComment t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.CommentId>-1) sb.Append(" and comment_id=@CommentId ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(!string.IsNullOrEmpty(t.CommentContent)) sb.Append(" and comment_content=@CommentContent ");
			if(t.CommentStatus>-1) sb.Append(" and comment_status=@CommentStatus ");
			if(t.CommentType>-1) sb.Append(" and comment_type=@CommentType ");
			if(t.ProductId>-1) sb.Append(" and product_id=@ProductId ");
			if(t.ParentId>-1) sb.Append(" and parent_id=@ParentId ");
			if(t.ApproveCount>-1) sb.Append(" and approve_count=@ApproveCount ");
			if(t.OppositionCount>-1) sb.Append(" and opposition_count=@OppositionCount ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<ProductComment> GetList(ProductComment t)
        {
            string sql = "select * from product_comments  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<ProductComment,ProductComment>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<ProductComment> GetList(ProductComment t, out int recordCount)
        {
            string sql = "select * from product_comments  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from product_comments  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<ProductComment,ProductComment>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override ProductComment GetById(long id)
        {
            string sql = "select top 1 * from product_comments  where comment_id=@Id ";
            return MysqlDapper.ExecuteSql_First<ProductComment,ProductComment>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into product_comments (create_by,create_time,comment_content,comment_status,comment_type,product_id,parent_id,approve_count,opposition_count) values (@CreateBy,@CreateTime,@CommentContent,@CommentStatus,@CommentType,@ProductId,@ParentId,@ApproveCount,@OppositionCount)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(ProductComment t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<ProductComment> ts)
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
            string sql = "Update product_comments set comment_content= @CommentContent,comment_status= @CommentStatus,comment_type= @CommentType,product_id= @ProductId,parent_id= @ParentId,approve_count= @ApproveCount,opposition_count= @OppositionCount where comment_id=@CommentId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(ProductComment t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<ProductComment> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from product_comments where comment_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from product_comments where comment_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

