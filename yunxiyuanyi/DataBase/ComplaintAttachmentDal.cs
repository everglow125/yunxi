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
    public class ComplaintAttachmentDal : BaseDal<ComplaintAttachment>, IComplaintAttachmentDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(ComplaintAttachment t)
        {
            string sql = "select top 1 1 from complaint_attachments  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from complaint_attachments  where attachment_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<ComplaintAttachment> GetAll()
        {
            string sql = "select * from complaint_attachments  ";
            return MysqlDapper.ExecuteSql_ToList<ComplaintAttachment,ComplaintAttachment>(sql, null);
        }

        private string GetWhere(ComplaintAttachment t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.AttachmentId>-1) sb.Append(" and attachment_id=@AttachmentId ");
			if(t.ComplaintId>-1) sb.Append(" and complaint_id=@ComplaintId ");
			if(!string.IsNullOrEmpty(t.AttachmentTitle)) sb.Append(" and attachment_title=@AttachmentTitle ");
			if(!string.IsNullOrEmpty(t.AttachmentUrl)) sb.Append(" and attachment_url=@AttachmentUrl ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<ComplaintAttachment> GetList(ComplaintAttachment t)
        {
            string sql = "select * from complaint_attachments  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<ComplaintAttachment,ComplaintAttachment>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<ComplaintAttachment> GetList(ComplaintAttachment t, out int recordCount)
        {
            string sql = "select * from complaint_attachments  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from complaint_attachments  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<ComplaintAttachment,ComplaintAttachment>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override ComplaintAttachment GetById(long id)
        {
            string sql = "select top 1 * from complaint_attachments  where attachment_id=@Id ";
            return MysqlDapper.ExecuteSql_First<ComplaintAttachment,ComplaintAttachment>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into complaint_attachments (complaint_id,attachment_title,attachment_url,create_time,create_by) values (@ComplaintId,@AttachmentTitle,@AttachmentUrl,@CreateTime,@CreateBy)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(ComplaintAttachment t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<ComplaintAttachment> ts)
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
            string sql = "Update complaint_attachments set complaint_id= @ComplaintId,attachment_title= @AttachmentTitle,attachment_url= @AttachmentUrl where attachment_id=@AttachmentId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(ComplaintAttachment t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<ComplaintAttachment> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from complaint_attachments where attachment_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from complaint_attachments where attachment_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

