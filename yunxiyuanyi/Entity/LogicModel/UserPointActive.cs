using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 用户积分记录
    /// </summary>
    [Serializable]
    public class UserPointActive
    {

        /// <summary> 
        ///  
        /// </summary> 
        [DisplayName("")]
        [ColumnMapping(Name = "active_id")]
        public long ActiveId { get; set; }

        /// <summary> 
        /// 积分操作类型 1消耗 2获取 
        /// </summary> 
        [DisplayName("积分操作类型 1消耗 2获取")]
        [ColumnMapping(Name = "active_type")]
        public int ActiveType { get; set; }

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
        /// 积分值 
        /// </summary> 
        [DisplayName("积分值")]
        [ColumnMapping(Name = "active_value")]
        public int ActiveValue { get; set; }

        /// <summary> 
        /// 操作IP 
        /// </summary> 
        [DisplayName("操作IP")]
        [ColumnMapping(Name = "active_ip")]
        public string ActiveIp { get; set; }

        /// <summary> 
        /// 动作来源 1登录 2抽奖 
        /// </summary> 
        [DisplayName("动作来源 1登录 2抽奖")]
        [ColumnMapping(Name = "active_origin")]
        public int ActiveOrigin { get; set; }

        /// <summary> 
        ///  
        /// </summary> 
        [DisplayName("")]
        [ColumnMapping(Name = "active_remark")]
        public string ActiveRemark { get; set; }


        public void TrimColumns()
        {
            this.ActiveIp = (this.ActiveIp ?? "").Trim();
            this.ActiveRemark = (this.ActiveRemark ?? "").Trim();

        }
    }

}
