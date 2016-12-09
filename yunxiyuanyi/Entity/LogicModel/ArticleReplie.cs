using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 文章回复
    /// </summary>
    [Serializable]
    public class ArticleReplie
    {

        /// <summary> 
        /// 自增主键 
        /// </summary> 
        [DisplayName("自增主键")]
        [ColumnMapping(Name = "reply_id")]
        public long ReplyId { get; set; }

        /// <summary> 
        /// 创建人 
        /// </summary> 
        [DisplayName("创建人")]
        [ColumnMapping(Name = "create_by")]
        public long CreateBy { get; set; }

        /// <summary> 
        /// 创建时间 
        /// </summary> 
        [DisplayName("创建时间")]
        [ColumnMapping(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary> 
        /// 回复内容 
        /// </summary> 
        [DisplayName("回复内容")]
        [ColumnMapping(Name = "reply_content")]
        public string ReplyContent { get; set; }

        /// <summary> 
        /// 回复状态 
        /// </summary> 
        [DisplayName("回复状态")]
        [ColumnMapping(Name = "reply_status")]
        public int ReplyStatus { get; set; }

        /// <summary> 
        /// 回复类型 
        /// </summary> 
        [DisplayName("回复类型")]
        [ColumnMapping(Name = "reply_type")]
        public int ReplyType { get; set; }

        /// <summary> 
        /// 支持数 
        /// </summary> 
        [DisplayName("支持数")]
        [ColumnMapping(Name = "approve_count")]
        public int ApproveCount { get; set; }

        /// <summary> 
        /// 反对数 
        /// </summary> 
        [DisplayName("反对数")]
        [ColumnMapping(Name = "oppose_count")]
        public int OpposeCount { get; set; }

        /// <summary> 
        /// 文章Id 
        /// </summary> 
        [DisplayName("文章Id")]
        [ColumnMapping(Name = "article_id")]
        public long ArticleId { get; set; }

        /// <summary> 
        /// 父评论 
        /// </summary> 
        [DisplayName("父评论")]
        [ColumnMapping(Name = "parent_id")]
        public long ParentId { get; set; }


        public void TrimColumns()
        {
            this.ReplyContent = (this.ReplyContent ?? "").Trim();

        }
    }

}
