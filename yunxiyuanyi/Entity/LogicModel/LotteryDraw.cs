using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 抽奖活动表
    /// </summary>
    [Serializable]
    public class LotteryDraw : BaseModel
    {

        /// <summary> 
        /// 自增主键 
        /// </summary> 
        [DisplayName("自增主键")]
        [ColumnMapping(Name = "lottery_id")]
        public long LotteryId { get; set; }

        /// <summary> 
        /// 活动标题 
        /// </summary> 
        [DisplayName("活动标题")]
        [ColumnMapping(Name = "lottery_title")]
        public string LotteryTitle { get; set; }

        /// <summary> 
        /// 活动内容 
        /// </summary> 
        [DisplayName("活动内容")]
        [ColumnMapping(Name = "lottery_content")]
        public string LotteryContent { get; set; }

        /// <summary> 
        /// 店铺Id 
        /// </summary> 
        [DisplayName("店铺Id")]
        [ColumnMapping(Name = "shop_id")]
        public long ShopId { get; set; }

        /// <summary> 
        /// 开始时间 
        /// </summary> 
        [DisplayName("开始时间")]
        [ColumnMapping(Name = "begin_time")]
        public DateTime BeginTime { get; set; }

        /// <summary> 
        /// 结束时间 
        /// </summary> 
        [DisplayName("结束时间")]
        [ColumnMapping(Name = "end_time")]
        public DateTime EndTime { get; set; }


        public void TrimColumns()
        {

            this.LotteryTitle = (this.LotteryTitle ?? "").Trim();

            this.LotteryContent = (this.LotteryContent ?? "").Trim();

        }
    }
}
