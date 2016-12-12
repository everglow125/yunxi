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
    public class ProductImageDal : BaseDal<ProductImage>, IProductImageDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(ProductImage t)
        {
            string sql = "select top 1 1 from product_images  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from product_images  where product_img_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<ProductImage> GetAll()
        {
            string sql = "select * from product_images  ";
            return MysqlDapper.ExecuteSql_ToList<ProductImage,ProductImage>(sql, null);
        }

        private string GetWhere(ProductImage t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.ProductImgId>-1) sb.Append(" and product_img_id=@ProductImgId ");
			if(!string.IsNullOrEmpty(t.ImgUrl)) sb.Append(" and img_url=@ImgUrl ");
			if(t.ProductId>-1) sb.Append(" and product_id=@ProductId ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.SortIndex>-1) sb.Append(" and sort_index=@SortIndex ");
			if(t.ImgStatus>-1) sb.Append(" and img_status=@ImgStatus ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<ProductImage> GetList(ProductImage t)
        {
            string sql = "select * from product_images  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<ProductImage,ProductImage>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<ProductImage> GetList(ProductImage t, out int recordCount)
        {
            string sql = "select * from product_images  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from product_images  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<ProductImage,ProductImage>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override ProductImage GetById(long id)
        {
            string sql = "select top 1 * from product_images  where product_img_id=@Id ";
            return MysqlDapper.ExecuteSql_First<ProductImage,ProductImage>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into product_images (img_url,product_id,create_time,create_by,sort_index,img_status) values (@ImgUrl,@ProductId,@CreateTime,@CreateBy,@SortIndex,@ImgStatus)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(ProductImage t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<ProductImage> ts)
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
            string sql = "Update product_images set img_url= @ImgUrl,product_id= @ProductId,sort_index= @SortIndex,img_status= @ImgStatus where product_img_id=@ProductImgId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(ProductImage t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<ProductImage> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from product_images where product_img_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from product_images where product_img_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

