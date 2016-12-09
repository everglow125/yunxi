using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 产品提问信息
    /// </summary>
    [Serializable]
    public class ProductRequestion
    {

        /// <summary> 
        /// 自增主键 
        /// </summary> 
        [DisplayName("自增主键")]
        [ColumnMapping(Name = "question_id")]
        public long QuestionId { get; set; }

        /// <summary> 
        /// 问题标题 
        /// </summary> 
        [DisplayName("问题标题")]
        [ColumnMapping(Name = "question_title")]
        public string QuestionTitle { get; set; }

        /// <summary> 
        /// 问题内容 
        /// </summary> 
        [DisplayName("问题内容")]
        [ColumnMapping(Name = "question_content")]
        public string QuestionContent { get; set; }

        /// <summary> 
        /// 提问人 
        /// </summary> 
        [DisplayName("提问人")]
        [ColumnMapping(Name = "create_by")]
        public long CreateBy { get; set; }

        /// <summary> 
        /// 提问时间 
        /// </summary> 
        [DisplayName("提问时间")]
        [ColumnMapping(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary> 
        /// 产品Id 
        /// </summary> 
        [DisplayName("产品Id")]
        [ColumnMapping(Name = "product_id")]
        public long ProductId { get; set; }

        /// <summary> 
        /// 回复人 
        /// </summary> 
        [DisplayName("回复人")]
        [ColumnMapping(Name = "reply_by")]
        public long ReplyBy { get; set; }

        /// <summary> 
        /// 回复内容 
        /// </summary> 
        [DisplayName("回复内容")]
        [ColumnMapping(Name = "reply_content")]
        public string ReplyContent { get; set; }

        /// <summary> 
        /// 回复时间 
        /// </summary> 
        [DisplayName("回复时间")]
        [ColumnMapping(Name = "reply_time")]
        public DateTime ReplyTime { get; set; }

        /// <summary> 
        /// 提问状态 1未答复 2已答复 4已删除 
        /// </summary> 
        [DisplayName("提问状态 1未答复 2已答复 4已删除")]
        [ColumnMapping(Name = "question_status")]
        public int QuestionStatus { get; set; }


        public void TrimColumns()
        {
            this.QuestionTitle = (this.QuestionTitle ?? "").Trim();
            this.QuestionContent = (this.QuestionContent ?? "").Trim();
            this.ReplyContent = (this.ReplyContent ?? "").Trim();

        }
    }

}
