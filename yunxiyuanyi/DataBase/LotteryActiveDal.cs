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
    public class LotteryActiveDal : BaseDal<LotteryActive>, ILotteryActiveDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(LotteryActive t)
        {
            string sql = "select top 1 1 from lottery_actives  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from lottery_actives  where active_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<LotteryActive> GetAll()
        {
            string sql = "select * from lottery_actives  ";
            return MysqlDapper.ExecuteSql_ToList<LotteryActive,LotteryActive>(sql, null);
        }

        private string GetWhere(LotteryActive t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.ActiveId>-1) sb.Append(" and active_id=@ActiveId ");
			if(t.PrizeId>-1) sb.Append(" and prize_id=@PrizeId ");
			if(t.LotteryId>-1) sb.Append(" and lottery_id=@LotteryId ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(!string.IsNullOrEmpty(t.ActiveIp)) sb.Append(" and active_ip=@ActiveIp ");
			if(t.ActiveType>-1) sb.Append(" and active_type=@ActiveType ");
			if(!string.IsNullOrEmpty(t.PrizeName)) sb.Append(" and prize_name=@PrizeName ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<LotteryActive> GetList(LotteryActive t)
        {
            string sql = "select * from lottery_actives  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<LotteryActive,LotteryActive>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<LotteryActive> GetList(LotteryActive t, out int recordCount)
        {
            string sql = "select * from lottery_actives  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from lottery_actives  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<LotteryActive,LotteryActive>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override LotteryActive GetById(long id)
        {
            string sql = "select top 1 * from lottery_actives  where active_id=@Id ";
            return MysqlDapper.ExecuteSql_First<LotteryActive,LotteryActive>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into lottery_actives (prize_id,lottery_id,create_by,create_time,active_ip,active_type,prize_name) values (@PrizeId,@LotteryId,@CreateBy,@CreateTime,@ActiveIp,@ActiveType,@PrizeName)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(LotteryActive t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<LotteryActive> ts)
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
            string sql = "Update lottery_actives set prize_id= @PrizeId,lottery_id= @LotteryId,active_ip= @ActiveIp,active_type= @ActiveType,prize_name= @PrizeName where active_id=@ActiveId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(LotteryActive t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<LotteryActive> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from lottery_actives where active_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from lottery_actives where active_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

