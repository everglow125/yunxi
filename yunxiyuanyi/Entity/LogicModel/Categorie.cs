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
    public class Categorie
    {

        /// <summary> 
        /// 主键 
        /// </summary> 
        [DisplayName("主键")]
        [ColumnMapping(Name = "category_id")]
        public long CategoryId { get; set; }

        /// <summary> 
        /// 名称 
        /// </summary> 
        [DisplayName("名称")]
        [ColumnMapping(Name = "category_name")]
        public string CategoryName { get; set; }

        /// <summary> 
        /// 父级菜单 
        /// </summary> 
        [DisplayName("父级菜单")]
        [ColumnMapping(Name = "parent_id")]
        public long ParentId { get; set; }

        /// <summary> 
        /// 创建时间 
        /// </summary> 
        [DisplayName("创建时间")]
        [ColumnMapping(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary> 
        /// 状态 0禁用 1启用 
        /// </summary> 
        [DisplayName("状态 0禁用 1启用")]
        [ColumnMapping(Name = "category_status")]
        public int CategoryStatus { get; set; }

        /// <summary> 
        /// 创建人 
        /// </summary> 
        [DisplayName("创建人")]
        [ColumnMapping(Name = "create_by")]
        public long CreateBy { get; set; }


        public void TrimColumns()
        {
            this.CategoryName = (this.CategoryName ?? "").Trim();

        }
    }

}
