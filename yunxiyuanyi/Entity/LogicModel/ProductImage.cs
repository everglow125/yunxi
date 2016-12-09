using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 商品图片信息
    /// </summary>
    [Serializable]
    public class ProductImage
    {

        /// <summary> 
        /// 自增主键 
        /// </summary> 
        [DisplayName("自增主键")]
        [ColumnMapping(Name = "product_img_id")]
        public long ProductImgId { get; set; }

        /// <summary> 
        /// 图片路径 
        /// </summary> 
        [DisplayName("图片路径")]
        [ColumnMapping(Name = "img_url")]
        public string ImgUrl { get; set; }

        /// <summary> 
        /// 商品Id 
        /// </summary> 
        [DisplayName("商品Id")]
        [ColumnMapping(Name = "product_id")]
        public long ProductId { get; set; }

        /// <summary> 
        /// 创建时间 
        /// </summary> 
        [DisplayName("创建时间")]
        [ColumnMapping(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary> 
        /// 创建人 
        /// </summary> 
        [DisplayName("创建人")]
        [ColumnMapping(Name = "create_by")]
        public long CreateBy { get; set; }

        /// <summary> 
        /// 排序信息 
        /// </summary> 
        [DisplayName("排序信息")]
        [ColumnMapping(Name = "sort_index")]
        public int SortIndex { get; set; }

        /// <summary> 
        /// 图片状态  1未审核 2已审核 3已删除 
        /// </summary> 
        [DisplayName("图片状态  1未审核 2已审核 3已删除")]
        [ColumnMapping(Name = "img_status")]
        public int ImgStatus { get; set; }


        public void TrimColumns()
        {
            this.ImgUrl = (this.ImgUrl ?? "").Trim();

        }
    }

}
