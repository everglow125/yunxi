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
    public class CustomerDal : BaseDal<Customer>, ICustomerDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Customer t)
        {
            string sql = "select top 1 1 from customers  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from customers  where customer_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Customer> GetAll()
        {
            string sql = "select * from customers  ";
            return MysqlDapper.ExecuteSql_ToList<Customer,Customer>(sql, null);
        }

        private string GetWhere(Customer t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.CustomerId>-1) sb.Append(" and customer_id=@CustomerId ");
			if(t.UserId>-1) sb.Append(" and user_id=@UserId ");
			if(!string.IsNullOrEmpty(t.IdentityCard)) sb.Append(" and identity_card=@IdentityCard ");
			if(t.BoughtCount>-1) sb.Append(" and bought_count=@BoughtCount ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Customer> GetList(Customer t)
        {
            string sql = "select * from customers  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Customer,Customer>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Customer> GetList(Customer t, out int recordCount)
        {
            string sql = "select * from customers  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from customers  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Customer,Customer>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Customer GetById(long id)
        {
            string sql = "select top 1 * from customers  where customer_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Customer,Customer>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into customers (user_id,identity_card,bought_count) values (@UserId,@IdentityCard,@BoughtCount)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Customer t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Customer> ts)
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
            string sql = "Update customers set user_id= @UserId,identity_card= @IdentityCard,bought_count= @BoughtCount where customer_id=@CustomerId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Customer t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Customer> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from customers where customer_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from customers where customer_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

