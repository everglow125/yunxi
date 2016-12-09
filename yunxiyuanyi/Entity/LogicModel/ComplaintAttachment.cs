using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 投诉信息附件
    /// </summary>
    [Serializable]
    public class ComplaintAttachment
    {

        /// <summary> 
        /// 主键 
        /// </summary> 
        [DisplayName("主键")]
        [ColumnMapping(Name = "attachment_id")]
        public long AttachmentId { get; set; }

        /// <summary> 
        /// 投诉Id 
        /// </summary> 
        [DisplayName("投诉Id")]
        [ColumnMapping(Name = "complaint_id")]
        public long ComplaintId { get; set; }

        /// <summary> 
        /// 附件标题 
        /// </summary> 
        [DisplayName("附件标题")]
        [ColumnMapping(Name = "attachment_title")]
        public string AttachmentTitle { get; set; }

        /// <summary> 
        /// 附件地址 
        /// </summary> 
        [DisplayName("附件地址")]
        [ColumnMapping(Name = "attachment_url")]
        public string AttachmentUrl { get; set; }

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


        public void TrimColumns()
        {
            this.AttachmentTitle = (this.AttachmentTitle ?? "").Trim();
            this.AttachmentUrl = (this.AttachmentUrl ?? "").Trim();

        }
    }

}
