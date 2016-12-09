using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 文章信息
    /// </summary>
    [Serializable]
    public class Article
    {

        /// <summary> 
        /// 自增主键 
        /// </summary> 
        [DisplayName("自增主键")]
        [ColumnMapping(Name = "article_id")]
        public long ArticleId { get; set; }

        /// <summary> 
        /// 文章标题 
        /// </summary> 
        [DisplayName("文章标题")]
        [ColumnMapping(Name = "article_title")]
        public string ArticleTitle { get; set; }

        /// <summary> 
        /// 文章内容 
        /// </summary> 
        [DisplayName("文章内容")]
        [ColumnMapping(Name = "article_content")]
        public string ArticleContent { get; set; }

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
        /// 文章状态 1草稿 2未审核 4审核通过 8审核不通过 16主动删除 32强制删除 
        /// </summary> 
        [DisplayName("文章状态 1草稿 2未审核 4审核通过 8审核不通过 16主动删除 32强制删除")]
        [ColumnMapping(Name = "article_status")]
        public int ArticleStatus { get; set; }

        /// <summary> 
        /// 阅读次数 
        /// </summary> 
        [DisplayName("阅读次数")]
        [ColumnMapping(Name = "read_count")]
        public int ReadCount { get; set; }

        /// <summary> 
        /// 回复统计 
        /// </summary> 
        [DisplayName("回复统计")]
        [ColumnMapping(Name = "reply_count")]
        public int ReplyCount { get; set; }

        /// <summary> 
        /// 支持统计 
        /// </summary> 
        [DisplayName("支持统计")]
        [ColumnMapping(Name = "approve_count")]
        public int ApproveCount { get; set; }

        /// <summary> 
        /// 反对统计 
        /// </summary> 
        [DisplayName("反对统计")]
        [ColumnMapping(Name = "oppose_count")]
        public int OpposeCount { get; set; }

        /// <summary> 
        /// 修改时间 
        /// </summary> 
        [DisplayName("修改时间")]
        [ColumnMapping(Name = "modify_time")]
        public DateTime ModifyTime { get; set; }

        /// <summary> 
        /// 是否精品 
        /// </summary> 
        [DisplayName("是否精品")]
        [ColumnMapping(Name = "is_high_quality")]
        public bool IsHighQuality { get; set; }

        /// <summary> 
        /// 是否置顶 
        /// </summary> 
        [DisplayName("是否置顶")]
        [ColumnMapping(Name = "is_top")]
        public bool IsTop { get; set; }

        /// <summary> 
        /// 分类 
        /// </summary> 
        [DisplayName("分类")]
        [ColumnMapping(Name = "category_id")]
        public long CategoryId { get; set; }


        public void TrimColumns()
        {
            this.ArticleTitle = (this.ArticleTitle ?? "").Trim();
            this.ArticleContent = (this.ArticleContent ?? "").Trim();

        }
    }

}
