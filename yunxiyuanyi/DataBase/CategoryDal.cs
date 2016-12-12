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
    public class CategoryDal : BaseDal<Category>, ICategoryDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Category t)
        {
            string sql = "select top 1 1 from categories  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from categories  where category_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Category> GetAll()
        {
            string sql = "select * from categories  ";
            return MysqlDapper.ExecuteSql_ToList<Category,Category>(sql, null);
        }

        private string GetWhere(Category t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.CategoryId>-1) sb.Append(" and category_id=@CategoryId ");
			if(!string.IsNullOrEmpty(t.CategoryName)) sb.Append(" and category_name=@CategoryName ");
			if(t.ParentId>-1) sb.Append(" and parent_id=@ParentId ");
			if(t.CategoryStatus>-1) sb.Append(" and category_status=@CategoryStatus ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Category> GetList(Category t)
        {
            string sql = "select * from categories  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Category,Category>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Category> GetList(Category t, out int recordCount)
        {
            string sql = "select * from categories  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from categories  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Category,Category>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Category GetById(long id)
        {
            string sql = "select top 1 * from categories  where category_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Category,Category>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into categories (category_name,parent_id,create_time,category_status,create_by) values (@CategoryName,@ParentId,@CreateTime,@CategoryStatus,@CreateBy)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Category t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Category> ts)
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
            string sql = "Update categories set category_name= @CategoryName,parent_id= @ParentId,category_status= @CategoryStatus where category_id=@CategoryId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Category t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Category> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from categories where category_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from categories where category_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

