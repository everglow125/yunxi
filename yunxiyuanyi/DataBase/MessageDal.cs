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
    public class MessageDal : BaseDal<Message>, IMessageDal
    {
        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(Message t)
        {
            string sql = "select top 1 1 from messages  where 1=1 ";
            return MysqlDapper.ExecuteSql_First<int>(sql, t) > 0;
        }

        /// <summary>
        /// 是否已存在
        /// </summary>
        public override bool IsExisted(int id)
        {
            string sql = "select top 1 1 from messages  where msg_id=@Id ";
            return MysqlDapper.ExecuteSql_First<int>(sql, new { Id = id }) > 0;
        }

        /// <summary>
        /// 获取所有Model对象
        /// </summary>
        public override IList<Message> GetAll()
        {
            string sql = "select * from messages  ";
            return MysqlDapper.ExecuteSql_ToList<Message,Message>(sql, null);
        }

        private string GetWhere(Message t)
        {
            StringBuilder sb = new StringBuilder();

			if(t.MsgId>-1) sb.Append(" and msg_id=@MsgId ");
			if(!string.IsNullOrEmpty(t.MsgTitle)) sb.Append(" and msg_title=@MsgTitle ");
			if(!string.IsNullOrEmpty(t.MsgContent)) sb.Append(" and msg_content=@MsgContent ");
			if(t.CreateBy>-1) sb.Append(" and create_by=@CreateBy ");
			if(t.MsgStatus>-1) sb.Append(" and msg_status=@MsgStatus ");
			if(t.AddresseeId>-1) sb.Append(" and addressee_id=@AddresseeId ");
			if(!string.IsNullOrEmpty(t.Sender)) sb.Append(" and sender=@Sender ");
			if(!string.IsNullOrEmpty(t.AddresseeName)) sb.Append(" and addressee_name=@AddresseeName ");
            return sb.ToString();
        }

        /// <summary>
        /// 根据条件返回所有信息
        /// </summary>
        public override IList<Message> GetList(Message t)
        {
            string sql = "select * from messages  where 1=1 ";
            string where = GetWhere(t);
            return MysqlDapper.ExecuteSql_ToList<Message,Message>(sql + where, t);
        }


        /// <summary>
        /// 根据条件返回指定页的数据
        /// </summary>
        public override IList<Message> GetList(Message t, out int recordCount)
        {
            string sql = "select * from messages  where 1=1 ";
            string where = GetWhere(t);
            string sqlCount = "select count(1) from messages  where 1=1 ";
            recordCount = MysqlDapper.ExecuteSP_First<int>(sqlCount + where, t);
            return MysqlDapper.ExecuteSql_ToList<Message,Message>(sql + where, t);
        }

        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        public override Message GetById(long id)
        {
            string sql = "select top 1 * from messages  where msg_id=@Id ";
            return MysqlDapper.ExecuteSql_First<Message,Message>(sql, new { Id = id });
        }
        /// <summary>
        ///获取插入语句
        /// </summary>
        /// <returns></returns>
        private string GetInsertStr()
        {
            string sql = "Insert into messages (msg_title,msg_content,create_by,create_time,msg_status,addressee_id,sender,read_time,addressee_name) values (@MsgTitle,@MsgContent,@CreateBy,@CreateTime,@MsgStatus,@AddresseeId,@Sender,@ReadTime,@AddresseeName)";
            return sql;
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        public override int Insert(Message t)
        {
            string sql = GetInsertStr();
            return MysqlDapper.InsertAndReturnId(sql, t);
        }

        /// <summary>
        /// 批量新增对象
        /// </summary>
        public override int BatchInsert(IList<Message> ts)
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
            string sql = "Update messages set msg_title= @MsgTitle,msg_content= @MsgContent,msg_status= @MsgStatus,addressee_id= @AddresseeId,sender= @Sender,read_time= @ReadTime,addressee_name= @AddresseeName where msg_id=@MsgId";
            return sql;
        }
        /// <summary>
        /// 更新对象
        /// </summary>
        public override int Update(Message t)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, t);
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public override int BatchUpdate(IList<Message> ts)
        {
            string sql = GetUpdate();
            return MysqlDapper.ExecuteSql(sql, ts);
        }

        /// <summary>
        /// 根据Id删除对象
        /// </summary>
        public override int Delete(long id)
        {
            string sql = "delete from messages where msg_id = @Id";
            return MysqlDapper.ExecuteSql(sql, new { Id = id });
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override int Delete(IList<long> ids)
        {
            string sql = string.Format("delete from messages where msg_id in ({0})", string.Join(",", ids));
            return MysqlDapper.ExecuteSql(sql, null);
        }
    }
}

