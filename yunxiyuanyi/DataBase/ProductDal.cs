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
    public class ProductDal : BaseDal<Product>, IProductDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Product t)
        {
            string sql = "select top 1 1 from products  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from products  where product_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Product> GetAll()
        {
            string sql = "select * from products  ";
            return MysqlDapper.ExecuteSql_ToList<Product,Product>(sql, null);
        }

        private string GetWhere(Product t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.ProductId>-1) sb.Append(" and product_id=@ProductId ");
			if(!string.IsNullOrEmpty(t.ProductName)) sb.Append(" and product_name=@ProductName ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.ShopId>-1) sb.Append(" and shop_id=@ShopId ");
			if(t.CategoryId>-1) sb.Append(" and category_id=@CategoryId ");
			if(t.StockQuantity>-1) sb.Append(" and stock_quantity=@StockQuantity ");
			if(t.SaledQuantity>-1) sb.Append(" and saled_quantity=@SaledQuantity ");
			if(!string.IsNullOrEmpty(t.ProductSummary)) sb.Append(" and product_summary=@ProductSummary ");
			if(!string.IsNullOrEmpty(t.ProductContent)) sb.Append(" and product_content=@ProductContent ");
			if(!string.IsNullOrEmpty(t.DefaultImage)) sb.Append(" and default_image=@DefaultImage ");
			if(t.ProductStatus>-1) sb.Append(" and product_status=@ProductStatus ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Product> GetList(Product t)
        {
            string sql = "select * from products  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Product,Product>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Product> GetList(Product t, out int recordCount)
        {
            string sql = "select * from products  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from products  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Product,Product>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Product GetById(long id)
        {
            string sql = "select top 1 * from products  where product_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Product,Product>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into products (product_name,create_time,create_by,shop_id,category_id,unit_price,stock_quantity,saled_quantity,product_summary,product_content,default_image,product_status) values (@ProductName,@CreateTime,@CreateBy,@ShopId,@CategoryId,@UnitPrice,@StockQuantity,@SaledQuantity,@ProductSummary,@ProductContent,@DefaultImage,@ProductStatus)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Product t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Product> ts)
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
            string sql = "Update products set product_name= @ProductName,shop_id= @ShopId,category_id= @CategoryId,unit_price= @UnitPrice,stock_quantity= @StockQuantity,saled_quantity= @SaledQuantity,product_summary= @ProductSummary,product_content= @ProductContent,default_image= @DefaultImage,product_status= @ProductStatus where product_id=@ProductId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Product t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Product> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from products where product_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from products where product_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

