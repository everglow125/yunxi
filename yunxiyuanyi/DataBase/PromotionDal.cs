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
    public class PromotionDal : BaseDal<Promotion>, IPromotionDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Promotion t)
        {
            string sql = "select top 1 1 from promotions  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from promotions  where promotion_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Promotion> GetAll()
        {
            string sql = "select * from promotions  ";
            return MysqlDapper.ExecuteSql_ToList<Promotion,Promotion>(sql, null);
        }

        private string GetWhere(Promotion t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.PromotionId>-1) sb.Append(" and promotion_id=@PromotionId ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(!string.IsNullOrEmpty(t.PromotionTitle)) sb.Append(" and promotion_title=@PromotionTitle ");
			if(!string.IsNullOrEmpty(t.PromotionContent)) sb.Append(" and promotion_content=@PromotionContent ");
			if(t.PromotionStatus>-1) sb.Append(" and promotion_status=@PromotionStatus ");
			if(t.PromotionType>-1) sb.Append(" and promotion_type=@PromotionType ");
			if(t.ShopId>-1) sb.Append(" and shop_id=@ShopId ");
			if(!string.IsNullOrEmpty(t.PromotionImage)) sb.Append(" and promotion_image=@PromotionImage ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Promotion> GetList(Promotion t)
        {
            string sql = "select * from promotions  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Promotion,Promotion>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Promotion> GetList(Promotion t, out int recordCount)
        {
            string sql = "select * from promotions  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from promotions  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Promotion,Promotion>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Promotion GetById(long id)
        {
            string sql = "select top 1 * from promotions  where promotion_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Promotion,Promotion>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into promotions (create_time,create_by,promotion_title,promotion_content,promotion_status,begin_time,end_time,promotion_type,min_amount,promotion_value,shop_id,promotion_image) values (@CreateTime,@CreateBy,@PromotionTitle,@PromotionContent,@PromotionStatus,@BeginTime,@EndTime,@PromotionType,@MinAmount,@PromotionValue,@ShopId,@PromotionImage)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Promotion t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Promotion> ts)
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
            string sql = "Update promotions set promotion_title= @PromotionTitle,promotion_content= @PromotionContent,promotion_status= @PromotionStatus,begin_time= @BeginTime,end_time= @EndTime,promotion_type= @PromotionType,min_amount= @MinAmount,promotion_value= @PromotionValue,shop_id= @ShopId,promotion_image= @PromotionImage where promotion_id=@PromotionId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Promotion t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Promotion> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from promotions where promotion_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from promotions where promotion_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

