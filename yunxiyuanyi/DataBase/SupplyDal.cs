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
    public class SupplyDal : BaseDal<Supply>, ISupplyDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Supply t)
        {
            string sql = "select top 1 1 from supplies  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from supplies  where supply_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Supply> GetAll()
        {
            string sql = "select * from supplies  ";
            return MysqlDapper.ExecuteSql_ToList<Supply,Supply>(sql, null);
        }

        private string GetWhere(Supply t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.SupplyId>-1) sb.Append(" and supply_id=@SupplyId ");
			if(t.UserId>-1) sb.Append(" and user_id=@UserId ");
			if(!string.IsNullOrEmpty(t.IdentityCard)) sb.Append(" and identity_card=@IdentityCard ");
			if(t.SupplyStatus>-1) sb.Append(" and supply_status=@SupplyStatus ");
			if(!string.IsNullOrEmpty(t.RealName)) sb.Append(" and real_name=@RealName ");
			if(!string.IsNullOrEmpty(t.IdentityCardFront)) sb.Append(" and identity_card_front=@IdentityCardFront ");
			if(!string.IsNullOrEmpty(t.IdentityCardBach)) sb.Append(" and identity_card_bach=@IdentityCardBach ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Supply> GetList(Supply t)
        {
            string sql = "select * from supplies  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Supply,Supply>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Supply> GetList(Supply t, out int recordCount)
        {
            string sql = "select * from supplies  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from supplies  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Supply,Supply>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Supply GetById(long id)
        {
            string sql = "select top 1 * from supplies  where supply_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Supply,Supply>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into supplies (user_id,create_time,identity_card,supply_status,real_name,identity_card_front,identity_card_bach) values (@UserId,@CreateTime,@IdentityCard,@SupplyStatus,@RealName,@IdentityCardFront,@IdentityCardBach)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Supply t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Supply> ts)
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
            string sql = "Update supplies set user_id= @UserId,identity_card= @IdentityCard,supply_status= @SupplyStatus,real_name= @RealName,identity_card_front= @IdentityCardFront,identity_card_bach= @IdentityCardBach where supply_id=@SupplyId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Supply t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Supply> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from supplies where supply_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from supplies where supply_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

