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
    public class ArticleReplyDal : BaseDal<ArticleReply>, IArticleReplyDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(ArticleReply t)
        {
            string sql = "select top 1 1 from article_replies  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from article_replies  where reply_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<ArticleReply> GetAll()
        {
            string sql = "select * from article_replies  ";
            return MysqlDapper.ExecuteSql_ToList<ArticleReply, ArticleReply>(sql, null);
        }

        private string GetWhere(ArticleReply t)
        {
            StringBuilder sb = new StringBuilder();

            if (t.ReplyId > -1) sb.Append(" and reply_id=@ReplyId ");
            if (t.CreateBy > -1) sb.Append(" and create_by=@CreateBy ");
            if (!string.IsNullOrEmpty(t.ReplyContent)) sb.Append(" and reply_content=@ReplyContent ");
            if (t.ReplyStatus > -1) sb.Append(" and reply_status=@ReplyStatus ");
            if (t.ReplyType > -1) sb.Append(" and reply_type=@ReplyType ");
            if (t.ApproveCount > -1) sb.Append(" and approve_count=@ApproveCount ");
            if (t.OpposeCount > -1) sb.Append(" and oppose_count=@OpposeCount ");
            if (t.ArticleId > -1) sb.Append(" and article_id=@ArticleId ");
            if (t.ParentId > -1) sb.Append(" and parent_id=@ParentId ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<ArticleReply> GetList(ArticleReply t)
        {
            string sql = "select * from article_replies  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<ArticleReply, ArticleReply>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<ArticleReply> GetList(ArticleReply t, out int recordCount)
        {
            string sql = "select * from article_replies  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from article_replies  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<ArticleReply, ArticleReply>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override ArticleReply GetById(long id)
        {
            string sql = "select top 1 * from article_replies  where reply_id=@Id ";
            return MysqlDapper.ExecuteSql_First<ArticleReply, ArticleReply>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into article_replies (create_by,create_time,reply_content,reply_status,reply_type,approve_count,oppose_count,article_id,parent_id) values (@CreateBy,@CreateTime,@ReplyContent,@ReplyStatus,@ReplyType,@ApproveCount,@OpposeCount,@ArticleId,@ParentId)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(ArticleReply t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<ArticleReply> ts)
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
            string sql = "Update article_replies set reply_content= @ReplyContent,reply_status= @ReplyStatus,reply_type= @ReplyType,approve_count= @ApproveCount,oppose_count= @OpposeCount,article_id= @ArticleId,parent_id= @ParentId where reply_id=@ReplyId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(ArticleReply t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<ArticleReply> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from article_replies where reply_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from article_replies where reply_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

