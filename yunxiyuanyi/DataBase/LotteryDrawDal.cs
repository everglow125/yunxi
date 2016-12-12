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
    public class LotteryDrawDal : BaseDal<LotteryDraw>, ILotteryDrawDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(LotteryDraw t)
        {
            string sql = "select top 1 1 from lottery_draws  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from lottery_draws  where lottery_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<LotteryDraw> GetAll()
        {
            string sql = "select * from lottery_draws  ";
            return MysqlDapper.ExecuteSql_ToList<LotteryDraw,LotteryDraw>(sql, null);
        }

        private string GetWhere(LotteryDraw t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.LotteryId>-1) sb.Append(" and lottery_id=@LotteryId ");
			if(!string.IsNullOrEmpty(t.LotteryTitle)) sb.Append(" and lottery_title=@LotteryTitle ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(!string.IsNullOrEmpty(t.LotteryContent)) sb.Append(" and lottery_content=@LotteryContent ");
			if(t.ShopId>-1) sb.Append(" and shop_id=@ShopId ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<LotteryDraw> GetList(LotteryDraw t)
        {
            string sql = "select * from lottery_draws  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<LotteryDraw,LotteryDraw>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<LotteryDraw> GetList(LotteryDraw t, out int recordCount)
        {
            string sql = "select * from lottery_draws  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from lottery_draws  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<LotteryDraw,LotteryDraw>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override LotteryDraw GetById(long id)
        {
            string sql = "select top 1 * from lottery_draws  where lottery_id=@Id ";
            return MysqlDapper.ExecuteSql_First<LotteryDraw,LotteryDraw>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into lottery_draws (lottery_title,create_time,create_by,lottery_content,shop_id,begin_time,end_time) values (@LotteryTitle,@CreateTime,@CreateBy,@LotteryContent,@ShopId,@BeginTime,@EndTime)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(LotteryDraw t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<LotteryDraw> ts)
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
            string sql = "Update lottery_draws set lottery_title= @LotteryTitle,lottery_content= @LotteryContent,shop_id= @ShopId,begin_time= @BeginTime,end_time= @EndTime where lottery_id=@LotteryId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(LotteryDraw t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<LotteryDraw> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from lottery_draws where lottery_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from lottery_draws where lottery_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

