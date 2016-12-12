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
    public class ComplaintDal : BaseDal<Complaint>, IComplaintDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Complaint t)
        {
            string sql = "select top 1 1 from complaints  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from complaints  where complaint_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Complaint> GetAll()
        {
            string sql = "select * from complaints  ";
            return MysqlDapper.ExecuteSql_ToList<Complaint, Complaint>(sql, null);
        }

        private string GetWhere(Complaint t)
        {
            StringBuilder sb = new StringBuilder();

            if (t.ComplaintId > -1) sb.Append(" and complaint_id=@ComplaintId ");
            if (!string.IsNullOrEmpty(t.ComplaintTitle)) sb.Append(" and complaint_title=@ComplaintTitle ");
            if (t.CreateBy > -1) sb.Append(" and create_by=@CreateBy ");
            if (!string.IsNullOrEmpty(t.ComplaintContent)) sb.Append(" and complaint_content=@ComplaintContent ");
            if (t.ComplaintStatus > -1) sb.Append(" and complaint_status=@ComplaintStatus ");
            if (t.ComplaintType > -1) sb.Append(" and complaint_type=@ComplaintType ");
            if (t.ComplaintObject > -1) sb.Append(" and complaint_object=@ComplaintObject ");
            if (t.DealBy > -1) sb.Append(" and deal_by=@DealBy ");
            if (!string.IsNullOrEmpty(t.DealReply)) sb.Append(" and deal_reply=@DealReply ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Complaint> GetList(Complaint t)
        {
            string sql = "select * from complaints  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Complaint, Complaint>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Complaint> GetList(Complaint t, out int recordCount)
        {
            string sql = "select * from complaints  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from complaints  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Complaint, Complaint>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Complaint GetById(long id)
        {
            string sql = "select top 1 * from complaints  where complaint_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Complaint, Complaint>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into complaints (complaint_title,create_by,complaint_content,complaint_status,create_time,complaint_type,complaint_object,deal_time,deal_by,deal_reply) values (@ComplaintTitle,@CreateBy,@ComplaintContent,@ComplaintStatus,@CreateTime,@ComplaintType,@ComplaintObject,@DealTime,@DealBy,@DealReply)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Complaint t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Complaint> ts)
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
            string sql = "Update complaints set complaint_title= @ComplaintTitle,complaint_content= @ComplaintContent,complaint_status= @ComplaintStatus,complaint_type= @ComplaintType,complaint_object= @ComplaintObject,deal_time= @DealTime,deal_by= @DealBy,deal_reply= @DealReply where complaint_id=@ComplaintId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Complaint t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Complaint> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from complaints where complaint_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from complaints where complaint_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

