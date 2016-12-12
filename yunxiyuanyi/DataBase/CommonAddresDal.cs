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
    public class CommonAddresDal : BaseDal<CommonAddres>, ICommonAddresDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(CommonAddres t)
        {
            string sql = "select top 1 1 from common_address  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from common_address  where address_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<CommonAddres> GetAll()
        {
            string sql = "select * from common_address  ";
            return MysqlDapper.ExecuteSql_ToList<CommonAddres,CommonAddres>(sql, null);
        }

        private string GetWhere(CommonAddres t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.AddressId>-1) sb.Append(" and address_id=@AddressId ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(!string.IsNullOrEmpty(t.Consignee)) sb.Append(" and consignee=@Consignee ");
			if(!string.IsNullOrEmpty(t.MobieNum)) sb.Append(" and mobie_num=@MobieNum ");
			if(t.SortIndex>-1) sb.Append(" and sort_index=@SortIndex ");
			if(t.AddressStatus>-1) sb.Append(" and address_status=@AddressStatus ");
			if(!string.IsNullOrEmpty(t.PostCode)) sb.Append(" and post_code=@PostCode ");
			if(!string.IsNullOrEmpty(t.City)) sb.Append(" and city=@City ");
			if(!string.IsNullOrEmpty(t.County)) sb.Append(" and county=@County ");
			if(!string.IsNullOrEmpty(t.Address)) sb.Append(" and address=@Address ");
			if(t.Province>-1) sb.Append(" and province=@Province ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<CommonAddres> GetList(CommonAddres t)
        {
            string sql = "select * from common_address  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<CommonAddres,CommonAddres>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<CommonAddres> GetList(CommonAddres t, out int recordCount)
        {
            string sql = "select * from common_address  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from common_address  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<CommonAddres,CommonAddres>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override CommonAddres GetById(long id)
        {
            string sql = "select top 1 * from common_address  where address_id=@Id ";
            return MysqlDapper.ExecuteSql_First<CommonAddres,CommonAddres>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into common_address (create_by,consignee,mobie_num,create_time,sort_index,address_status,isdefault,post_code,city,county,address,province) values (@CreateBy,@Consignee,@MobieNum,@CreateTime,@SortIndex,@AddressStatus,@Isdefault,@PostCode,@City,@County,@Address,@Province)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(CommonAddres t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<CommonAddres> ts)
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
            string sql = "Update common_address set consignee= @Consignee,mobie_num= @MobieNum,sort_index= @SortIndex,address_status= @AddressStatus,isdefault= @Isdefault,post_code= @PostCode,city= @City,county= @County,address= @Address,province= @Province where address_id=@AddressId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(CommonAddres t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<CommonAddres> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from common_address where address_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from common_address where address_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

