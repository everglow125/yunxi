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
    public class SecurityQuestionDal : BaseDal<SecurityQuestion>, ISecurityQuestionDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(SecurityQuestion t)
        {
            string sql = "select top 1 1 from security_questions  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from security_questions  where security_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<SecurityQuestion> GetAll()
        {
            string sql = "select * from security_questions  ";
            return MysqlDapper.ExecuteSql_ToList<SecurityQuestion,SecurityQuestion>(sql, null);
        }

        private string GetWhere(SecurityQuestion t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.SecurityId>-1) sb.Append(" and security_id=@SecurityId ");
			if(!string.IsNullOrEmpty(t.SecurityTitle)) sb.Append(" and security_title=@SecurityTitle ");
			if(!string.IsNullOrEmpty(t.SecurityAnswer)) sb.Append(" and security_answer=@SecurityAnswer ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<SecurityQuestion> GetList(SecurityQuestion t)
        {
            string sql = "select * from security_questions  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<SecurityQuestion,SecurityQuestion>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<SecurityQuestion> GetList(SecurityQuestion t, out int recordCount)
        {
            string sql = "select * from security_questions  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from security_questions  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<SecurityQuestion,SecurityQuestion>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override SecurityQuestion GetById(long id)
        {
            string sql = "select top 1 * from security_questions  where security_id=@Id ";
            return MysqlDapper.ExecuteSql_First<SecurityQuestion,SecurityQuestion>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into security_questions (security_title,security_answer,create_by,create_time) values (@SecurityTitle,@SecurityAnswer,@CreateBy,@CreateTime)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(SecurityQuestion t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<SecurityQuestion> ts)
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
            string sql = "Update security_questions set security_title= @SecurityTitle,security_answer= @SecurityAnswer where security_id=@SecurityId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(SecurityQuestion t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<SecurityQuestion> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from security_questions where security_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from security_questions where security_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

