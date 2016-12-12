using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 评论图片
	/// </summary>
	[Serializable]
	public class ProductCommentImage:BaseModel
	{

		/// <summary> 
		/// 主键 
		/// </summary> 
		[DisplayName("主键")] 
		[ColumnMapping(Name="image_id")] 
		public long ImageId { get; set; }

		/// <summary> 
		/// 图片路径 
		/// </summary> 
		[DisplayName("图片路径")] 
		[ColumnMapping(Name="image_url")] 
		public string ImageUrl { get; set; }

		/// <summary> 
		/// 评价Id 
		/// </summary> 
		[DisplayName("评价Id")] 
		[ColumnMapping(Name="comment_id")] 
		public long CommentId { get; set; }

		/// <summary> 
		/// 创建人姓名 
		/// </summary> 
		[DisplayName("创建人姓名")] 
		[ColumnMapping(Name="create_by_name")] 
		public string CreateByName { get; set; }



		/// <summary> 
		/// 图片状态 
		/// </summary> 
		[DisplayName("图片状态")] 
		[ColumnMapping(Name="image_status")] 
		public int ImageStatus { get; set; }


		public void TrimColumns()
		{

			this.ImageUrl = (this.ImageUrl ?? "").Trim();

			this.CreateByName = (this.CreateByName ?? "").Trim();

		}
	}
}
