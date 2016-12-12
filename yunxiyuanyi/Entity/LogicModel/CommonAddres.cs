using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 常用地址
	/// </summary>
	[Serializable]
	public class CommonAddres:BaseModel
	{

		/// <summary> 
		/// 主键 
		/// </summary> 
		[DisplayName("主键")] 
		[ColumnMapping(Name="address_id")] 
		public long AddressId { get; set; }


		/// <summary> 
		/// 收件人 
		/// </summary> 
		[DisplayName("收件人")] 
		[ColumnMapping(Name="consignee")] 
		public string Consignee { get; set; }

		/// <summary> 
		/// 手机号 
		/// </summary> 
		[DisplayName("手机号")] 
		[ColumnMapping(Name="mobie_num")] 
		public string MobieNum { get; set; }


		/// <summary> 
		/// 排序 
		/// </summary> 
		[DisplayName("排序")] 
		[ColumnMapping(Name="sort_index")] 
		public int SortIndex { get; set; }

		/// <summary> 
		/// 状态 0禁用 1启用 
		/// </summary> 
		[DisplayName("状态 0禁用 1启用")] 
		[ColumnMapping(Name="address_status")] 
		public int AddressStatus { get; set; }

		/// <summary> 
		/// 是否默认 
		/// </summary> 
		[DisplayName("是否默认")] 
		[ColumnMapping(Name="isdefault")] 
		public bool Isdefault { get; set; }

		/// <summary> 
		/// 邮编 
		/// </summary> 
		[DisplayName("邮编")] 
		[ColumnMapping(Name="post_code")] 
		public string PostCode { get; set; }

		/// <summary> 
		/// 市 
		/// </summary> 
		[DisplayName("市")] 
		[ColumnMapping(Name="city")] 
		public string City { get; set; }

		/// <summary> 
		/// 县 
		/// </summary> 
		[DisplayName("县")] 
		[ColumnMapping(Name="county")] 
		public string County { get; set; }

		/// <summary> 
		/// 详细地址 
		/// </summary> 
		[DisplayName("详细地址")] 
		[ColumnMapping(Name="address")] 
		public string Address { get; set; }

		/// <summary> 
		/// 省 
		/// </summary> 
		[DisplayName("省")] 
		[ColumnMapping(Name="province")] 
		public int Province { get; set; }


		public void TrimColumns()
		{

			this.Consignee = (this.Consignee ?? "").Trim();

			this.MobieNum = (this.MobieNum ?? "").Trim();

			this.PostCode = (this.PostCode ?? "").Trim();

			this.City = (this.City ?? "").Trim();

			this.County = (this.County ?? "").Trim();

			this.Address = (this.Address ?? "").Trim();

		}
	}
}
