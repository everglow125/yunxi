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
    public class UserDal : BaseDal<User>, IUserDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(User t)
        {
            string sql = "select top 1 1 from users  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from users  where user_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<User> GetAll()
        {
            string sql = "select * from users  ";
            return MysqlDapper.ExecuteSql_ToList<User,User>(sql, null);
        }

        private string GetWhere(User t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.UserId>-1) sb.Append(" and user_id=@UserId ");
			if(!string.IsNullOrEmpty(t.LoginName)) sb.Append(" and login_name=@LoginName ");
			if(!string.IsNullOrEmpty(t.NickName)) sb.Append(" and nick_name=@NickName ");
			if(!string.IsNullOrEmpty(t.MobieNum)) sb.Append(" and mobie_num=@MobieNum ");
			if(!string.IsNullOrEmpty(t.LoginPwd)) sb.Append(" and login_pwd=@LoginPwd ");
			if(!string.IsNullOrEmpty(t.Email)) sb.Append(" and email=@Email ");
			if(t.UserStatus>-1) sb.Append(" and user_status=@UserStatus ");
			if(t.UserRole>-1) sb.Append(" and user_role=@UserRole ");
			if(t.UserPoint>-1) sb.Append(" and user_point=@UserPoint ");
			if(t.EmpiricalValue>-1) sb.Append(" and empirical_value=@EmpiricalValue ");
			if(t.UserLevel>-1) sb.Append(" and user_level=@UserLevel ");
			if(!string.IsNullOrEmpty(t.PhotoUrl)) sb.Append(" and photo_url=@PhotoUrl ");
			if(t.UserSex>-1) sb.Append(" and user_sex=@UserSex ");
			if(!string.IsNullOrEmpty(t.UserDescription)) sb.Append(" and user_description=@UserDescription ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<User> GetList(User t)
        {
            string sql = "select * from users  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<User,User>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<User> GetList(User t, out int recordCount)
        {
            string sql = "select * from users  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from users  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<User,User>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override User GetById(long id)
        {
            string sql = "select top 1 * from users  where user_id=@Id ";
            return MysqlDapper.ExecuteSql_First<User,User>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into users (login_name,nick_name,mobie_num,login_pwd,email,user_status,user_role,create_time,user_point,empirical_value,user_level,photo_url,user_sex,user_birth,user_description) values (@LoginName,@NickName,@MobieNum,@LoginPwd,@Email,@UserStatus,@UserRole,@CreateTime,@UserPoint,@EmpiricalValue,@UserLevel,@PhotoUrl,@UserSex,@UserBirth,@UserDescription)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(User t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<User> ts)
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
            string sql = "Update users set login_name= @LoginName,nick_name= @NickName,mobie_num= @MobieNum,login_pwd= @LoginPwd,email= @Email,user_status= @UserStatus,user_role= @UserRole,user_point= @UserPoint,empirical_value= @EmpiricalValue,user_level= @UserLevel,photo_url= @PhotoUrl,user_sex= @UserSex,user_birth= @UserBirth,user_description= @UserDescription where user_id=@UserId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(User t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<User> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from users where user_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from users where user_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

