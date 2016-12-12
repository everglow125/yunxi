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
    public class FavoriteDal : BaseDal<Favorite>, IFavoriteDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Favorite t)
        {
            string sql = "select top 1 1 from favorites  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from favorites  where favorites_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Favorite> GetAll()
        {
            string sql = "select * from favorites  ";
            return MysqlDapper.ExecuteSql_ToList<Favorite,Favorite>(sql, null);
        }

        private string GetWhere(Favorite t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.FavoritesId>-1) sb.Append(" and favorites_id=@FavoritesId ");
			if(t.FavoritesType>-1) sb.Append(" and favorites_type=@FavoritesType ");
			if(t.ObjectId>-1) sb.Append(" and object_id=@ObjectId ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(!string.IsNullOrEmpty(t.DefalutName)) sb.Append(" and defalut_name=@DefalutName ");
			if(!string.IsNullOrEmpty(t.ObjectTitle)) sb.Append(" and object_title=@ObjectTitle ");
			if(t.FavoritesStatus>-1) sb.Append(" and favorites_status=@FavoritesStatus ");
			if(!string.IsNullOrEmpty(t.ObjectImage)) sb.Append(" and object_image=@ObjectImage ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Favorite> GetList(Favorite t)
        {
            string sql = "select * from favorites  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Favorite,Favorite>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Favorite> GetList(Favorite t, out int recordCount)
        {
            string sql = "select * from favorites  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from favorites  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Favorite,Favorite>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Favorite GetById(long id)
        {
            string sql = "select top 1 * from favorites  where favorites_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Favorite,Favorite>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into favorites (favorites_type,object_id,create_by,create_time,defalut_name,object_title,favorites_status,object_image) values (@FavoritesType,@ObjectId,@CreateBy,@CreateTime,@DefalutName,@ObjectTitle,@FavoritesStatus,@ObjectImage)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Favorite t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Favorite> ts)
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
            string sql = "Update favorites set favorites_type= @FavoritesType,object_id= @ObjectId,defalut_name= @DefalutName,object_title= @ObjectTitle,favorites_status= @FavoritesStatus,object_image= @ObjectImage where favorites_id=@FavoritesId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Favorite t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Favorite> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from favorites where favorites_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from favorites where favorites_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

