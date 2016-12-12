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
    public class OrderItemDal : BaseDal<OrderItem>, IOrderItemDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(OrderItem t)
        {
            string sql = "select top 1 1 from order_items  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from order_items  where order_item_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<OrderItem> GetAll()
        {
            string sql = "select * from order_items  ";
            return MysqlDapper.ExecuteSql_ToList<OrderItem,OrderItem>(sql, null);
        }

        private string GetWhere(OrderItem t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.OrderItemId>-1) sb.Append(" and order_item_id=@OrderItemId ");
			if(t.ProductId>-1) sb.Append(" and product_id=@ProductId ");
			if(!string.IsNullOrEmpty(t.ProductName)) sb.Append(" and product_name=@ProductName ");
			if(t.Quantity>-1) sb.Append(" and quantity=@Quantity ");
			if(t.PromotionId>-1) sb.Append(" and promotion_id=@PromotionId ");
			if(t.OrderItemStatus>-1) sb.Append(" and order_item_status=@OrderItemStatus ");
			if(!string.IsNullOrEmpty(t.DefaultImage)) sb.Append(" and default_image=@DefaultImage ");
			if(t.ExpressId>-1) sb.Append(" and express_id=@ExpressId ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<OrderItem> GetList(OrderItem t)
        {
            string sql = "select * from order_items  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<OrderItem,OrderItem>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<OrderItem> GetList(OrderItem t, out int recordCount)
        {
            string sql = "select * from order_items  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from order_items  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<OrderItem,OrderItem>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override OrderItem GetById(long id)
        {
            string sql = "select top 1 * from order_items  where order_item_id=@Id ";
            return MysqlDapper.ExecuteSql_First<OrderItem,OrderItem>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into order_items (product_id,product_name,unit_price,quantity,promotion_id,total_discount,total_amount,total_paid,order_item_status,default_image,express_id) values (@ProductId,@ProductName,@UnitPrice,@Quantity,@PromotionId,@TotalDiscount,@TotalAmount,@TotalPaid,@OrderItemStatus,@DefaultImage,@ExpressId)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(OrderItem t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<OrderItem> ts)
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
            string sql = "Update order_items set product_id= @ProductId,product_name= @ProductName,unit_price= @UnitPrice,quantity= @Quantity,promotion_id= @PromotionId,total_discount= @TotalDiscount,total_amount= @TotalAmount,total_paid= @TotalPaid,order_item_status= @OrderItemStatus,default_image= @DefaultImage,express_id= @ExpressId where order_item_id=@OrderItemId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(OrderItem t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<OrderItem> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from order_items where order_item_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from order_items where order_item_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

