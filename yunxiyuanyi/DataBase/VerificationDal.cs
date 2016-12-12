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
    public class VerificationDal : BaseDal<Verification>, IVerificationDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Verification t)
        {
            string sql = "select top 1 1 from verifications  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from verifications  where verification_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Verification> GetAll()
        {
            string sql = "select * from verifications  ";
            return MysqlDapper.ExecuteSql_ToList<Verification,Verification>(sql, null);
        }

        private string GetWhere(Verification t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.VerificationId>-1) sb.Append(" and verification_id=@VerificationId ");
			if(!string.IsNullOrEmpty(t.VerificationCode)) sb.Append(" and verification_code=@VerificationCode ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.VerificationType>-1) sb.Append(" and verification_type=@VerificationType ");
			if(t.VerificationStatus>-1) sb.Append(" and verification_status=@VerificationStatus ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Verification> GetList(Verification t)
        {
            string sql = "select * from verifications  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Verification,Verification>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Verification> GetList(Verification t, out int recordCount)
        {
            string sql = "select * from verifications  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from verifications  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Verification,Verification>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Verification GetById(long id)
        {
            string sql = "select top 1 * from verifications  where verification_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Verification,Verification>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into verifications (verification_code,create_by,create_time,failure_time,verification_type,verification_status) values (@VerificationCode,@CreateBy,@CreateTime,@FailureTime,@VerificationType,@VerificationStatus)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Verification t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Verification> ts)
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
            string sql = "Update verifications set verification_code= @VerificationCode,failure_time= @FailureTime,verification_type= @VerificationType,verification_status= @VerificationStatus where verification_id=@VerificationId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Verification t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Verification> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from verifications where verification_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from verifications where verification_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

