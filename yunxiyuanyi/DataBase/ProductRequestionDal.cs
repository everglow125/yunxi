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
    public class ProductRequestionDal : BaseDal<ProductRequestion>, IProductRequestionDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(ProductRequestion t)
        {
            string sql = "select top 1 1 from product_requestions  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from product_requestions  where question_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<ProductRequestion> GetAll()
        {
            string sql = "select * from product_requestions  ";
            return MysqlDapper.ExecuteSql_ToList<ProductRequestion,ProductRequestion>(sql, null);
        }

        private string GetWhere(ProductRequestion t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.QuestionId>-1) sb.Append(" and question_id=@QuestionId ");
			if(!string.IsNullOrEmpty(t.QuestionTitle)) sb.Append(" and question_title=@QuestionTitle ");
			if(!string.IsNullOrEmpty(t.QuestionContent)) sb.Append(" and question_content=@QuestionContent ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.ProductId>-1) sb.Append(" and product_id=@ProductId ");
			if(t.ReplyBy>-1) sb.Append(" and reply_by=@ReplyBy ");
			if(!string.IsNullOrEmpty(t.ReplyContent)) sb.Append(" and reply_content=@ReplyContent ");
			if(t.QuestionStatus>-1) sb.Append(" and question_status=@QuestionStatus ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<ProductRequestion> GetList(ProductRequestion t)
        {
            string sql = "select * from product_requestions  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<ProductRequestion,ProductRequestion>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<ProductRequestion> GetList(ProductRequestion t, out int recordCount)
        {
            string sql = "select * from product_requestions  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from product_requestions  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<ProductRequestion,ProductRequestion>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override ProductRequestion GetById(long id)
        {
            string sql = "select top 1 * from product_requestions  where question_id=@Id ";
            return MysqlDapper.ExecuteSql_First<ProductRequestion,ProductRequestion>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into product_requestions (question_title,question_content,create_by,create_time,product_id,reply_by,reply_content,reply_time,question_status) values (@QuestionTitle,@QuestionContent,@CreateBy,@CreateTime,@ProductId,@ReplyBy,@ReplyContent,@ReplyTime,@QuestionStatus)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(ProductRequestion t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<ProductRequestion> ts)
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
            string sql = "Update product_requestions set question_title= @QuestionTitle,question_content= @QuestionContent,product_id= @ProductId,reply_by= @ReplyBy,reply_content= @ReplyContent,reply_time= @ReplyTime,question_status= @QuestionStatus where question_id=@QuestionId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(ProductRequestion t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<ProductRequestion> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from product_requestions where question_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from product_requestions where question_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

