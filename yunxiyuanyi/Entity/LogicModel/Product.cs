using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 商品信息
	/// </summary>
	[Serializable]
	public class Product:BaseModel
	{

		/// <summary> 
		/// 自增主键 
		/// </summary> 
		[DisplayName("自增主键")] 
		[ColumnMapping(Name="product_id")] 
		public long ProductId { get; set; }

		/// <summary> 
		/// 商品名称 
		/// </summary> 
		[DisplayName("商品名称")] 
		[ColumnMapping(Name="product_name")] 
		public string ProductName { get; set; }



		/// <summary> 
		/// 店铺Id 
		/// </summary> 
		[DisplayName("店铺Id")] 
		[ColumnMapping(Name="shop_id")] 
		public long ShopId { get; set; }

		/// <summary> 
		/// 分类Id 
		/// </summary> 
		[DisplayName("分类Id")] 
		[ColumnMapping(Name="category_id")] 
		public long CategoryId { get; set; }

		/// <summary> 
		/// 单价 
		/// </summary> 
		[DisplayName("单价")] 
		[ColumnMapping(Name="unit_price")] 
		public decimal UnitPrice { get; set; }

		/// <summary> 
		/// 总库存数 
		/// </summary> 
		[DisplayName("总库存数")] 
		[ColumnMapping(Name="stock_quantity")] 
		public int StockQuantity { get; set; }

		/// <summary> 
		/// 已售数量 
		/// </summary> 
		[DisplayName("已售数量")] 
		[ColumnMapping(Name="saled_quantity")] 
		public int SaledQuantity { get; set; }

		/// <summary> 
		/// 商品简介 
		/// </summary> 
		[DisplayName("商品简介")] 
		[ColumnMapping(Name="product_summary")] 
		public string ProductSummary { get; set; }

		/// <summary> 
		/// 详情 
		/// </summary> 
		[DisplayName("详情")] 
		[ColumnMapping(Name="product_content")] 
		public string ProductContent { get; set; }

		/// <summary> 
		/// 默认图片 
		/// </summary> 
		[DisplayName("默认图片")] 
		[ColumnMapping(Name="default_image")] 
		public string DefaultImage { get; set; }

		/// <summary> 
		/// 商品状态 1草稿 2正常 4下架 8删除 16强制下架 
		/// </summary> 
		[DisplayName("商品状态 1草稿 2正常 4下架 8删除 16强制下架")] 
		[ColumnMapping(Name="product_status")] 
		public int ProductStatus { get; set; }


		public void TrimColumns()
		{

			this.ProductName = (this.ProductName ?? "").Trim();

			this.ProductSummary = (this.ProductSummary ?? "").Trim();

			this.ProductContent = (this.ProductContent ?? "").Trim();

			this.DefaultImage = (this.DefaultImage ?? "").Trim();

		}
	}
}
