using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 卖家信息
	/// </summary>
	[Serializable]
	public class Supply:BaseModel
	{

		/// <summary> 
		/// 自增主键 
		/// </summary> 
		[DisplayName("自增主键")] 
		[ColumnMapping(Name="supply_id")] 
		public long SupplyId { get; set; }

		/// <summary> 
		/// 用户Id 
		/// </summary> 
		[DisplayName("用户Id")] 
		[ColumnMapping(Name="user_id")] 
		public long UserId { get; set; }


		/// <summary> 
		/// 身份证号 
		/// </summary> 
		[DisplayName("身份证号")] 
		[ColumnMapping(Name="identity_card")] 
		public string IdentityCard { get; set; }

		/// <summary> 
		/// 卖家状态 1未审核 2已审核 4已禁用 
		/// </summary> 
		[DisplayName("卖家状态 1未审核 2已审核 4已禁用")] 
		[ColumnMapping(Name="supply_status")] 
		public int SupplyStatus { get; set; }

		/// <summary> 
		/// 真实姓名 
		/// </summary> 
		[DisplayName("真实姓名")] 
		[ColumnMapping(Name="real_name")] 
		public string RealName { get; set; }

		/// <summary> 
		/// 身份证正面 
		/// </summary> 
		[DisplayName("身份证正面")] 
		[ColumnMapping(Name="identity_card_front")] 
		public string IdentityCardFront { get; set; }

		/// <summary> 
		/// 身份证反面 
		/// </summary> 
		[DisplayName("身份证反面")] 
		[ColumnMapping(Name="identity_card_bach")] 
		public string IdentityCardBach { get; set; }


		public void TrimColumns()
		{

			this.IdentityCard = (this.IdentityCard ?? "").Trim();

			this.RealName = (this.RealName ?? "").Trim();

			this.IdentityCardFront = (this.IdentityCardFront ?? "").Trim();

			this.IdentityCardBach = (this.IdentityCardBach ?? "").Trim();

		}
	}
}
