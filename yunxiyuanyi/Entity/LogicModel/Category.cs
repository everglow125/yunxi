using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 分类信息表
	/// </summary>
	[Serializable]
	public class Category:BaseModel
	{

		/// <summary> 
		/// 主键 
		/// </summary> 
		[DisplayName("主键")] 
		[ColumnMapping(Name="category_id")] 
		public long CategoryId { get; set; }

		/// <summary> 
		/// 名称 
		/// </summary> 
		[DisplayName("名称")] 
		[ColumnMapping(Name="category_name")] 
		public string CategoryName { get; set; }

		/// <summary> 
		/// 父级菜单 
		/// </summary> 
		[DisplayName("父级菜单")] 
		[ColumnMapping(Name="parent_id")] 
		public long ParentId { get; set; }


		/// <summary> 
		/// 状态 0禁用 1启用 
		/// </summary> 
		[DisplayName("状态 0禁用 1启用")] 
		[ColumnMapping(Name="category_status")] 
		public int CategoryStatus { get; set; }



		public void TrimColumns()
		{

			this.CategoryName = (this.CategoryName ?? "").Trim();

		}
	}
}
