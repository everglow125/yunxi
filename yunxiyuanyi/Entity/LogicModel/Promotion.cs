using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 优惠活动
	/// </summary>
	[Serializable]
	public class Promotion:BaseModel
	{

		/// <summary> 
		/// 优惠主键 
		/// </summary> 
		[DisplayName("优惠主键")] 
		[ColumnMapping(Name="promotion_id")] 
		public long PromotionId { get; set; }



		/// <summary> 
		/// 活动标题 
		/// </summary> 
		[DisplayName("活动标题")] 
		[ColumnMapping(Name="promotion_title")] 
		public string PromotionTitle { get; set; }

		/// <summary> 
		/// 活动内容 
		/// </summary> 
		[DisplayName("活动内容")] 
		[ColumnMapping(Name="promotion_content")] 
		public string PromotionContent { get; set; }

		/// <summary> 
		/// 优惠状态 1草稿 2正常 4下架 
		/// </summary> 
		[DisplayName("优惠状态 1草稿 2正常 4下架")] 
		[ColumnMapping(Name="promotion_status")] 
		public int PromotionStatus { get; set; }

		/// <summary> 
		/// 开始时间 
		/// </summary> 
		[DisplayName("开始时间")] 
		[ColumnMapping(Name="begin_time")] 
		public DateTime BeginTime { get; set; }

		/// <summary> 
		/// 结束时间 
		/// </summary> 
		[DisplayName("结束时间")] 
		[ColumnMapping(Name="end_time")] 
		public DateTime EndTime { get; set; }

		/// <summary> 
		/// 优惠类型 1满减 2折扣 
		/// </summary> 
		[DisplayName("优惠类型 1满减 2折扣")] 
		[ColumnMapping(Name="promotion_type")] 
		public int PromotionType { get; set; }

		/// <summary> 
		/// 最低消费金额 0表示不限制 
		/// </summary> 
		[DisplayName("最低消费金额 0表示不限制")] 
		[ColumnMapping(Name="min_amount")] 
		public decimal MinAmount { get; set; }

		/// <summary> 
		/// 优惠额度 
		/// </summary> 
		[DisplayName("优惠额度")] 
		[ColumnMapping(Name="promotion_value")] 
		public decimal PromotionValue { get; set; }

		/// <summary> 
		/// 店铺Id 0表示官方活动 其余表示店铺活动 
		/// </summary> 
		[DisplayName("店铺Id 0表示官方活动 其余表示店铺活动")] 
		[ColumnMapping(Name="shop_id")] 
		public long ShopId { get; set; }

		/// <summary> 
		/// 活动预览图片 
		/// </summary> 
		[DisplayName("活动预览图片")] 
		[ColumnMapping(Name="promotion_image")] 
		public string PromotionImage { get; set; }


		public void TrimColumns()
		{

			this.PromotionTitle = (this.PromotionTitle ?? "").Trim();

			this.PromotionContent = (this.PromotionContent ?? "").Trim();

			this.PromotionImage = (this.PromotionImage ?? "").Trim();

		}
	}
}
