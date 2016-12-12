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
    public class ShopDal : BaseDal<Shop>, IShopDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Shop t)
        {
            string sql = "select top 1 1 from shops  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from shops  where shop_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Shop> GetAll()
        {
            string sql = "select * from shops  ";
            return MysqlDapper.ExecuteSql_ToList<Shop,Shop>(sql, null);
        }

        private string GetWhere(Shop t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.ShopId>-1) sb.Append(" and shop_id=@ShopId ");
			if(!string.IsNullOrEmpty(t.ShopName)) sb.Append(" and shop_name=@ShopName ");
			if(!string.IsNullOrEmpty(t.ShopAddress)) sb.Append(" and shop_address=@ShopAddress ");
			if(!string.IsNullOrEmpty(t.ShopLoge)) sb.Append(" and shop_loge=@ShopLoge ");
			if(t.Province>-1) sb.Append(" and province=@Province ");
			if(!string.IsNullOrEmpty(t.City)) sb.Append(" and city=@City ");
			if(!string.IsNullOrEmpty(t.County)) sb.Append(" and county=@County ");
			if(t.ShopStatus>-1) sb.Append(" and shop_status=@ShopStatus ");
			if(!string.IsNullOrEmpty(t.PermitImage)) sb.Append(" and permit_image=@PermitImage ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Shop> GetList(Shop t)
        {
            string sql = "select * from shops  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Shop,Shop>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Shop> GetList(Shop t, out int recordCount)
        {
            string sql = "select * from shops  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from shops  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Shop,Shop>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Shop GetById(long id)
        {
            string sql = "select top 1 * from shops  where shop_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Shop,Shop>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into shops (shop_name,shop_address,create_time,shop_loge,province,city,county,shop_status,permit_image) values (@ShopName,@ShopAddress,@CreateTime,@ShopLoge,@Province,@City,@County,@ShopStatus,@PermitImage)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Shop t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Shop> ts)
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
            string sql = "Update shops set shop_name= @ShopName,shop_address= @ShopAddress,shop_loge= @ShopLoge,province= @Province,city= @City,county= @County,shop_status= @ShopStatus,permit_image= @PermitImage where shop_id=@ShopId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Shop t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Shop> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from shops where shop_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from shops where shop_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

