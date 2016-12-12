using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 产品评价信息
	/// </summary>
	[Serializable]
	public class ProductComment:BaseModel
	{

		/// <summary> 
		/// 自增主键 
		/// </summary> 
		[DisplayName("自增主键")] 
		[ColumnMapping(Name="comment_id")] 
		public long CommentId { get; set; }



		/// <summary> 
		/// 评论内容 
		/// </summary> 
		[DisplayName("评论内容")] 
		[ColumnMapping(Name="comment_content")] 
		public string CommentContent { get; set; }

		/// <summary> 
		/// 评论状态 1未审核 2已审核 4已删除 
		/// </summary> 
		[DisplayName("评论状态 1未审核 2已审核 4已删除")] 
		[ColumnMapping(Name="comment_status")] 
		public int CommentStatus { get; set; }

		/// <summary> 
		/// 评论类型 
		/// </summary> 
		[DisplayName("评论类型")] 
		[ColumnMapping(Name="comment_type")] 
		public int CommentType { get; set; }

		/// <summary> 
		/// 商品Id 
		/// </summary> 
		[DisplayName("商品Id")] 
		[ColumnMapping(Name="product_id")] 
		public long ProductId { get; set; }

		/// <summary> 
		/// 父节点 
		/// </summary> 
		[DisplayName("父节点")] 
		[ColumnMapping(Name="parent_id")] 
		public long ParentId { get; set; }

		/// <summary> 
		/// 赞同总数 
		/// </summary> 
		[DisplayName("赞同总数")] 
		[ColumnMapping(Name="approve_count")] 
		public int ApproveCount { get; set; }

		/// <summary> 
		/// 反对总数 
		/// </summary> 
		[DisplayName("反对总数")] 
		[ColumnMapping(Name="opposition_count")] 
		public int OppositionCount { get; set; }


		public void TrimColumns()
		{

			this.CommentContent = (this.CommentContent ?? "").Trim();

		}
	}
}
