using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 买家信息
	/// </summary>
	[Serializable]
	public class Customer:BaseModel
	{

		/// <summary> 
		/// 主键 
		/// </summary> 
		[DisplayName("主键")] 
		[ColumnMapping(Name="customer_id")] 
		public long CustomerId { get; set; }

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
		/// 购买总数 
		/// </summary> 
		[DisplayName("购买总数")] 
		[ColumnMapping(Name="bought_count")] 
		public int BoughtCount { get; set; }


		public void TrimColumns()
		{

			this.IdentityCard = (this.IdentityCard ?? "").Trim();

		}
	}
}
