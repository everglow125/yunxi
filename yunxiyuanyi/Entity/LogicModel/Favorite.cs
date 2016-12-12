using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 收藏夹
	/// </summary>
	[Serializable]
	public class Favorite:BaseModel
	{

		/// <summary> 
		/// 主键 
		/// </summary> 
		[DisplayName("主键")] 
		[ColumnMapping(Name="favorites_id")] 
		public long FavoritesId { get; set; }

		/// <summary> 
		/// 类型 1店铺 2商品 
		/// </summary> 
		[DisplayName("类型 1店铺 2商品")] 
		[ColumnMapping(Name="favorites_type")] 
		public int FavoritesType { get; set; }

		/// <summary> 
		/// 收藏对象Id 
		/// </summary> 
		[DisplayName("收藏对象Id")] 
		[ColumnMapping(Name="object_id")] 
		public long ObjectId { get; set; }



		/// <summary> 
		/// 创建人名字 
		/// </summary> 
		[DisplayName("创建人名字")] 
		[ColumnMapping(Name="defalut_name")] 
		public string DefalutName { get; set; }

		/// <summary> 
		/// 收藏对象标题 
		/// </summary> 
		[DisplayName("收藏对象标题")] 
		[ColumnMapping(Name="object_title")] 
		public string ObjectTitle { get; set; }

		/// <summary> 
		/// 收藏状态 0已取消 1已关注 
		/// </summary> 
		[DisplayName("收藏状态 0已取消 1已关注")] 
		[ColumnMapping(Name="favorites_status")] 
		public int FavoritesStatus { get; set; }

		/// <summary> 
		/// 收藏对象图片 
		/// </summary> 
		[DisplayName("收藏对象图片")] 
		[ColumnMapping(Name="object_image")] 
		public string ObjectImage { get; set; }


		public void TrimColumns()
		{

			this.DefalutName = (this.DefalutName ?? "").Trim();

			this.ObjectTitle = (this.ObjectTitle ?? "").Trim();

			this.ObjectImage = (this.ObjectImage ?? "").Trim();

		}
	}
}
