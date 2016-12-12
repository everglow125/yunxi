using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 订单产品信息
	/// </summary>
	[Serializable]
	public class OrderItem:BaseModel
	{

		/// <summary> 
		/// 主键 
		/// </summary> 
		[DisplayName("主键")] 
		[ColumnMapping(Name="order_item_id")] 
		public long OrderItemId { get; set; }

		/// <summary> 
		/// 产品Id 
		/// </summary> 
		[DisplayName("产品Id")] 
		[ColumnMapping(Name="product_id")] 
		public long ProductId { get; set; }

		/// <summary> 
		/// 产品名称 
		/// </summary> 
		[DisplayName("产品名称")] 
		[ColumnMapping(Name="product_name")] 
		public string ProductName { get; set; }

		/// <summary> 
		/// 单价 
		/// </summary> 
		[DisplayName("单价")] 
		[ColumnMapping(Name="unit_price")] 
		public decimal UnitPrice { get; set; }

		/// <summary> 
		/// 数量 
		/// </summary> 
		[DisplayName("数量")] 
		[ColumnMapping(Name="quantity")] 
		public int Quantity { get; set; }

		/// <summary> 
		/// 优惠信息 
		/// </summary> 
		[DisplayName("优惠信息")] 
		[ColumnMapping(Name="promotion_id")] 
		public long PromotionId { get; set; }

		/// <summary> 
		/// 总优惠额度 
		/// </summary> 
		[DisplayName("总优惠额度")] 
		[ColumnMapping(Name="total_discount")] 
		public decimal TotalDiscount { get; set; }

		/// <summary> 
		/// 商品总额 
		/// </summary> 
		[DisplayName("商品总额")] 
		[ColumnMapping(Name="total_amount")] 
		public decimal TotalAmount { get; set; }

		/// <summary> 
		/// 实付金额 
		/// </summary> 
		[DisplayName("实付金额")] 
		[ColumnMapping(Name="total_paid")] 
		public decimal TotalPaid { get; set; }

		/// <summary> 
		/// 状态 
		/// </summary> 
		[DisplayName("状态")] 
		[ColumnMapping(Name="order_item_status")] 
		public int OrderItemStatus { get; set; }

		/// <summary> 
		/// 默认图片 
		/// </summary> 
		[DisplayName("默认图片")] 
		[ColumnMapping(Name="default_image")] 
		public string DefaultImage { get; set; }

		/// <summary> 
		/// 快递信息 
		/// </summary> 
		[DisplayName("快递信息")] 
		[ColumnMapping(Name="express_id")] 
		public int ExpressId { get; set; }


		public void TrimColumns()
		{

			this.ProductName = (this.ProductName ?? "").Trim();

			this.DefaultImage = (this.DefaultImage ?? "").Trim();

		}
	}
}
