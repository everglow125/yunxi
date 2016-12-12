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
    public class ArticleDal : BaseDal<Article>, IArticleDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Article t)
        {
            string sql = "select top 1 1 from articles  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from articles  where article_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Article> GetAll()
        {
            string sql = "select * from articles  ";
            return MysqlDapper.ExecuteSql_ToList<Article,Article>(sql, null);
        }

        private string GetWhere(Article t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.ArticleId>-1) sb.Append(" and article_id=@ArticleId ");
			if(!string.IsNullOrEmpty(t.ArticleTitle)) sb.Append(" and article_title=@ArticleTitle ");
			if(!string.IsNullOrEmpty(t.ArticleContent)) sb.Append(" and article_content=@ArticleContent ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.ArticleStatus>-1) sb.Append(" and article_status=@ArticleStatus ");
			if(t.ReadCount>-1) sb.Append(" and read_count=@ReadCount ");
			if(t.ReplyCount>-1) sb.Append(" and reply_count=@ReplyCount ");
			if(t.ApproveCount>-1) sb.Append(" and approve_count=@ApproveCount ");
			if(t.OpposeCount>-1) sb.Append(" and oppose_count=@OpposeCount ");
			if(t.CategoryId>-1) sb.Append(" and category_id=@CategoryId ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Article> GetList(Article t)
        {
            string sql = "select * from articles  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Article,Article>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Article> GetList(Article t, out int recordCount)
        {
            string sql = "select * from articles  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from articles  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Article,Article>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Article GetById(long id)
        {
            string sql = "select top 1 * from articles  where article_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Article,Article>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into articles (article_title,article_content,create_by,create_time,article_status,read_count,reply_count,approve_count,oppose_count,modify_time,is_high_quality,is_top,category_id) values (@ArticleTitle,@ArticleContent,@CreateBy,@CreateTime,@ArticleStatus,@ReadCount,@ReplyCount,@ApproveCount,@OpposeCount,@ModifyTime,@IsHighQuality,@IsTop,@CategoryId)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Article t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Article> ts)
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
            string sql = "Update articles set article_title= @ArticleTitle,article_content= @ArticleContent,article_status= @ArticleStatus,read_count= @ReadCount,reply_count= @ReplyCount,approve_count= @ApproveCount,oppose_count= @OpposeCount,modify_time= @ModifyTime,is_high_quality= @IsHighQuality,is_top= @IsTop,category_id= @CategoryId where article_id=@ArticleId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Article t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Article> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from articles where article_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from articles where article_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

