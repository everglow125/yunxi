using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 店铺信息
	/// </summary>
	[Serializable]
	public class Shop:BaseModel
	{

		/// <summary> 
		/// 店铺Id 
		/// </summary> 
		[DisplayName("店铺Id")] 
		[ColumnMapping(Name="shop_id")] 
		public long ShopId { get; set; }

		/// <summary> 
		/// 店铺名称 
		/// </summary> 
		[DisplayName("店铺名称")] 
		[ColumnMapping(Name="shop_name")] 
		public string ShopName { get; set; }

		/// <summary> 
		/// 店铺详细地址 
		/// </summary> 
		[DisplayName("店铺详细地址")] 
		[ColumnMapping(Name="shop_address")] 
		public string ShopAddress { get; set; }


		/// <summary> 
		/// 默认图片 
		/// </summary> 
		[DisplayName("默认图片")] 
		[ColumnMapping(Name="shop_loge")] 
		public string ShopLoge { get; set; }

		/// <summary> 
		/// 省 
		/// </summary> 
		[DisplayName("省")] 
		[ColumnMapping(Name="province")] 
		public int Province { get; set; }

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
		/// 店铺状态 1未审核 2已审核 3主动关店 4强制关店 
		/// </summary> 
		[DisplayName("店铺状态 1未审核 2已审核 3主动关店 4强制关店")] 
		[ColumnMapping(Name="shop_status")] 
		public int ShopStatus { get; set; }

		/// <summary> 
		/// 许可证图片 
		/// </summary> 
		[DisplayName("许可证图片")] 
		[ColumnMapping(Name="permit_image")] 
		public string PermitImage { get; set; }


		public void TrimColumns()
		{

			this.ShopName = (this.ShopName ?? "").Trim();

			this.ShopAddress = (this.ShopAddress ?? "").Trim();

			this.ShopLoge = (this.ShopLoge ?? "").Trim();

			this.City = (this.City ?? "").Trim();

			this.County = (this.County ?? "").Trim();

			this.PermitImage = (this.PermitImage ?? "").Trim();

		}
	}
}
