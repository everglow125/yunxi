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
    public class PrizeDal : BaseDal<Prize>, IPrizeDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Prize t)
        {
            string sql = "select top 1 1 from prizes  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from prizes  where prize_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Prize> GetAll()
        {
            string sql = "select * from prizes  ";
            return MysqlDapper.ExecuteSql_ToList<Prize,Prize>(sql, null);
        }

        private string GetWhere(Prize t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.PrizeId>-1) sb.Append(" and prize_id=@PrizeId ");
			if(!string.IsNullOrEmpty(t.PrizeName)) sb.Append(" and prize_name=@PrizeName ");
			if(t.PrizeIndex>-1) sb.Append(" and prize_index=@PrizeIndex ");
			if(t.TotalInventory>-1) sb.Append(" and total_inventory=@TotalInventory ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.WinningRate>-1) sb.Append(" and winning_rate=@WinningRate ");
			if(t.LotteryId>-1) sb.Append(" and lottery_id=@LotteryId ");
			if(!string.IsNullOrEmpty(t.PrizeImage)) sb.Append(" and prize_image=@PrizeImage ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Prize> GetList(Prize t)
        {
            string sql = "select * from prizes  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Prize,Prize>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Prize> GetList(Prize t, out int recordCount)
        {
            string sql = "select * from prizes  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from prizes  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Prize,Prize>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Prize GetById(long id)
        {
            string sql = "select top 1 * from prizes  where prize_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Prize,Prize>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into prizes (prize_name,prize_index,total_inventory,create_by,create_time,winning_rate,lottery_id,prize_image) values (@PrizeName,@PrizeIndex,@TotalInventory,@CreateBy,@CreateTime,@WinningRate,@LotteryId,@PrizeImage)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Prize t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Prize> ts)
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
            string sql = "Update prizes set prize_name= @PrizeName,prize_index= @PrizeIndex,total_inventory= @TotalInventory,winning_rate= @WinningRate,lottery_id= @LotteryId,prize_image= @PrizeImage where prize_id=@PrizeId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Prize t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Prize> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from prizes where prize_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from prizes where prize_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

