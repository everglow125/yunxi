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
    public class UserPointActiveDal : BaseDal<UserPointActive>, IUserPointActiveDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(UserPointActive t)
        {
            string sql = "select top 1 1 from user_point_actives  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from user_point_actives  where active_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<UserPointActive> GetAll()
        {
            string sql = "select * from user_point_actives  ";
            return MysqlDapper.ExecuteSql_ToList<UserPointActive,UserPointActive>(sql, null);
        }

        private string GetWhere(UserPointActive t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.ActiveId>-1) sb.Append(" and active_id=@ActiveId ");
			if(t.ActiveType>-1) sb.Append(" and active_type=@ActiveType ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.ActiveValue>-1) sb.Append(" and active_value=@ActiveValue ");
			if(!string.IsNullOrEmpty(t.ActiveIp)) sb.Append(" and active_ip=@ActiveIp ");
			if(t.ActiveOrigin>-1) sb.Append(" and active_origin=@ActiveOrigin ");
			if(!string.IsNullOrEmpty(t.ActiveRemark)) sb.Append(" and active_remark=@ActiveRemark ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<UserPointActive> GetList(UserPointActive t)
        {
            string sql = "select * from user_point_actives  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<UserPointActive,UserPointActive>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<UserPointActive> GetList(UserPointActive t, out int recordCount)
        {
            string sql = "select * from user_point_actives  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from user_point_actives  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<UserPointActive,UserPointActive>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override UserPointActive GetById(long id)
        {
            string sql = "select top 1 * from user_point_actives  where active_id=@Id ";
            return MysqlDapper.ExecuteSql_First<UserPointActive,UserPointActive>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into user_point_actives (active_type,create_by,create_time,active_value,active_ip,active_origin,active_remark) values (@ActiveType,@CreateBy,@CreateTime,@ActiveValue,@ActiveIp,@ActiveOrigin,@ActiveRemark)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(UserPointActive t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<UserPointActive> ts)
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
            string sql = "Update user_point_actives set active_type= @ActiveType,active_value= @ActiveValue,active_ip= @ActiveIp,active_origin= @ActiveOrigin,active_remark= @ActiveRemark where active_id=@ActiveId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(UserPointActive t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<UserPointActive> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from user_point_actives where active_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from user_point_actives where active_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

