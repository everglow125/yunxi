using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 站内信
	/// </summary>
	[Serializable]
	public class Message:BaseModel
	{

		/// <summary> 
		/// 主键 
		/// </summary> 
		[DisplayName("主键")] 
		[ColumnMapping(Name="msg_id")] 
		public long MsgId { get; set; }

		/// <summary> 
		/// 标题 
		/// </summary> 
		[DisplayName("标题")] 
		[ColumnMapping(Name="msg_title")] 
		public string MsgTitle { get; set; }

		/// <summary> 
		/// 内容 
		/// </summary> 
		[DisplayName("内容")] 
		[ColumnMapping(Name="msg_content")] 
		public string MsgContent { get; set; }



		/// <summary> 
		/// 状态 1未读 2已读 4删除 
		/// </summary> 
		[DisplayName("状态 1未读 2已读 4删除")] 
		[ColumnMapping(Name="msg_status")] 
		public int MsgStatus { get; set; }

		/// <summary> 
		/// 收件人 
		/// </summary> 
		[DisplayName("收件人")] 
		[ColumnMapping(Name="addressee_id")] 
		public int AddresseeId { get; set; }

		/// <summary> 
		/// 发件人名称 
		/// </summary> 
		[DisplayName("发件人名称")] 
		[ColumnMapping(Name="sender")] 
		public string Sender { get; set; }

		/// <summary> 
		/// 读取时间 
		/// </summary> 
		[DisplayName("读取时间")] 
		[ColumnMapping(Name="read_time")] 
		public DateTime ReadTime { get; set; }

		/// <summary> 
		/// 收件人昵称 
		/// </summary> 
		[DisplayName("收件人昵称")] 
		[ColumnMapping(Name="addressee_name")] 
		public string AddresseeName { get; set; }


		public void TrimColumns()
		{

			this.MsgTitle = (this.MsgTitle ?? "").Trim();

			this.MsgContent = (this.MsgContent ?? "").Trim();

			this.Sender = (this.Sender ?? "").Trim();

			this.AddresseeName = (this.AddresseeName ?? "").Trim();

		}
	}
}
