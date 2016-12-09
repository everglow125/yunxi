using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 投诉信息
    /// </summary>
    [Serializable]
    public class Complaint
    {

        /// <summary> 
        /// 主键 
        /// </summary> 
        [DisplayName("主键")]
        [ColumnMapping(Name = "complaint_id")]
        public long ComplaintId { get; set; }

        /// <summary> 
        /// 标题 
        /// </summary> 
        [DisplayName("标题")]
        [ColumnMapping(Name = "complaint_title")]
        public string ComplaintTitle { get; set; }

        /// <summary> 
        /// 创建人 
        /// </summary> 
        [DisplayName("创建人")]
        [ColumnMapping(Name = "create_by")]
        public long CreateBy { get; set; }

        /// <summary> 
        /// 投诉内容 
        /// </summary> 
        [DisplayName("投诉内容")]
        [ColumnMapping(Name = "complaint_content")]
        public string ComplaintContent { get; set; }

        /// <summary> 
        /// 状态 0未处理 1已处理 
        /// </summary> 
        [DisplayName("状态 0未处理 1已处理")]
        [ColumnMapping(Name = "complaint_status")]
        public int ComplaintStatus { get; set; }

        /// <summary> 
        /// 创建时间 
        /// </summary> 
        [DisplayName("创建时间")]
        [ColumnMapping(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary> 
        /// 投诉类型 1店铺 2商品 3用户 
        /// </summary> 
        [DisplayName("投诉类型 1店铺 2商品 3用户")]
        [ColumnMapping(Name = "complaint_type")]
        public int ComplaintType { get; set; }

        /// <summary> 
        /// 投诉对象Id 
        /// </summary> 
        [DisplayName("投诉对象Id")]
        [ColumnMapping(Name = "complaint_object")]
        public long ComplaintObject { get; set; }

        /// <summary> 
        /// 处理时间 
        /// </summary> 
        [DisplayName("处理时间")]
        [ColumnMapping(Name = "deal_time")]
        public DateTime DealTime { get; set; }

        /// <summary> 
        /// 处理人 
        /// </summary> 
        [DisplayName("处理人")]
        [ColumnMapping(Name = "deal_by")]
        public long DealBy { get; set; }

        /// <summary> 
        /// 处理答复 
        /// </summary> 
        [DisplayName("处理答复")]
        [ColumnMapping(Name = "deal_reply")]
        public string DealReply { get; set; }


        public void TrimColumns()
        {
            this.ComplaintTitle = (this.ComplaintTitle ?? "").Trim();
            this.ComplaintContent = (this.ComplaintContent ?? "").Trim();
            this.DealReply = (this.DealReply ?? "").Trim();

        }
    }

}
