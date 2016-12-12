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
    public class OrderDal : BaseDal<Order>, IOrderDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Order t)
        {
            string sql = "select top 1 1 from orders  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from orders  where order_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Order> GetAll()
        {
            string sql = "select * from orders  ";
            return MysqlDapper.ExecuteSql_ToList<Order,Order>(sql, null);
        }

        private string GetWhere(Order t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.OrderId>-1) sb.Append(" and order_id=@OrderId ");
			if(!string.IsNullOrEmpty(t.OrderNum)) sb.Append(" and order_num=@OrderNum ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.OrderStatus>-1) sb.Append(" and order_status=@OrderStatus ");
			if(!string.IsNullOrEmpty(t.MobieNum)) sb.Append(" and mobie_num=@MobieNum ");
			if(t.Province>-1) sb.Append(" and province=@Province ");
			if(!string.IsNullOrEmpty(t.City)) sb.Append(" and city=@City ");
			if(!string.IsNullOrEmpty(t.County)) sb.Append(" and county=@County ");
			if(!string.IsNullOrEmpty(t.Address)) sb.Append(" and address=@Address ");
			if(!string.IsNullOrEmpty(t.Postcode)) sb.Append(" and postcode=@Postcode ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Order> GetList(Order t)
        {
            string sql = "select * from orders  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Order,Order>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Order> GetList(Order t, out int recordCount)
        {
            string sql = "select * from orders  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from orders  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Order,Order>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Order GetById(long id)
        {
            string sql = "select top 1 * from orders  where order_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Order,Order>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into orders (order_num,create_by,create_time,order_status,pay_time,total_amount,mobie_num,province,city,county,address,postcode,express_fee) values (@OrderNum,@CreateBy,@CreateTime,@OrderStatus,@PayTime,@TotalAmount,@MobieNum,@Province,@City,@County,@Address,@Postcode,@ExpressFee)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Order t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Order> ts)
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
            string sql = "Update orders set order_num= @OrderNum,order_status= @OrderStatus,pay_time= @PayTime,total_amount= @TotalAmount,mobie_num= @MobieNum,province= @Province,city= @City,county= @County,address= @Address,postcode= @Postcode,express_fee= @ExpressFee where order_id=@OrderId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Order t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Order> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from orders where order_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from orders where order_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

