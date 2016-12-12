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
    public class PaymentDal : BaseDal<Payment>, IPaymentDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Payment t)
        {
            string sql = "select top 1 1 from payments  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from payments  where payment_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Payment> GetAll()
        {
            string sql = "select * from payments  ";
            return MysqlDapper.ExecuteSql_ToList<Payment,Payment>(sql, null);
        }

        private string GetWhere(Payment t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.PaymentId>-1) sb.Append(" and payment_id=@PaymentId ");
			if(t.OrderId>-1) sb.Append(" and order_id=@OrderId ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.PaymentStatus>-1) sb.Append(" and payment_status=@PaymentStatus ");
			if(!string.IsNullOrEmpty(t.PaidAccount)) sb.Append(" and paid_account=@PaidAccount ");
			if(!string.IsNullOrEmpty(t.PayeeAccount)) sb.Append(" and payee_account=@PayeeAccount ");
			if(!string.IsNullOrEmpty(t.TradeNum)) sb.Append(" and trade_num=@TradeNum ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Payment> GetList(Payment t)
        {
            string sql = "select * from payments  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Payment,Payment>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Payment> GetList(Payment t, out int recordCount)
        {
            string sql = "select * from payments  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from payments  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Payment,Payment>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Payment GetById(long id)
        {
            string sql = "select top 1 * from payments  where payment_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Payment,Payment>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into payments (order_id,create_by,create_time,total_paid,payment_status,paid_account,payee_account,trade_num) values (@OrderId,@CreateBy,@CreateTime,@TotalPaid,@PaymentStatus,@PaidAccount,@PayeeAccount,@TradeNum)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Payment t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Payment> ts)
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
            string sql = "Update payments set order_id= @OrderId,total_paid= @TotalPaid,payment_status= @PaymentStatus,paid_account= @PaidAccount,payee_account= @PayeeAccount,trade_num= @TradeNum where payment_id=@PaymentId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Payment t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Payment> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from payments where payment_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from payments where payment_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

