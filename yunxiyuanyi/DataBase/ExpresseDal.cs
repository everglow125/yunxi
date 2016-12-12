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
    public class ExpresseDal : BaseDal<Expresse>, IExpresseDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Expresse t)
        {
            string sql = "select top 1 1 from expresses  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from expresses  where express_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Expresse> GetAll()
        {
            string sql = "select * from expresses  ";
            return MysqlDapper.ExecuteSql_ToList<Expresse,Expresse>(sql, null);
        }

        private string GetWhere(Expresse t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.ExpressId>-1) sb.Append(" and express_id=@ExpressId ");
			if(!string.IsNullOrEmpty(t.ExpressNum)) sb.Append(" and express_num=@ExpressNum ");
			if(!string.IsNullOrEmpty(t.ExpressCompany)) sb.Append(" and express_company=@ExpressCompany ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Expresse> GetList(Expresse t)
        {
            string sql = "select * from expresses  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Expresse,Expresse>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Expresse> GetList(Expresse t, out int recordCount)
        {
            string sql = "select * from expresses  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from expresses  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Expresse,Expresse>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Expresse GetById(long id)
        {
            string sql = "select top 1 * from expresses  where express_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Expresse,Expresse>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into expresses (express_num,express_company,create_by,create_time) values (@ExpressNum,@ExpressCompany,@CreateBy,@CreateTime)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Expresse t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Expresse> ts)
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
            string sql = "Update expresses set express_num= @ExpressNum,express_company= @ExpressCompany where express_id=@ExpressId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Expresse t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Expresse> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from expresses where express_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from expresses where express_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

