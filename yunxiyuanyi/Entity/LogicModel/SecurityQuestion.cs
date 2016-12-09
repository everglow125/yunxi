using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SecurityQuestion
    {

        /// <summary> 
        /// 密保主键 
        /// </summary> 
        [DisplayName("密保主键")]
        [ColumnMapping(Name = "security_id")]
        public long SecurityId { get; set; }

        /// <summary> 
        /// 密保问题 
        /// </summary> 
        [DisplayName("密保问题")]
        [ColumnMapping(Name = "security_title")]
        public string SecurityTitle { get; set; }

        /// <summary> 
        /// 密保答案 
        /// </summary> 
        [DisplayName("密保答案")]
        [ColumnMapping(Name = "security_answer")]
        public string SecurityAnswer { get; set; }

        /// <summary> 
        /// 创建人 
        /// </summary> 
        [DisplayName("创建人")]
        [ColumnMapping(Name = "create_by")]
        public int CreateBy { get; set; }

        /// <summary> 
        /// 创建时间 
        /// </summary> 
        [DisplayName("创建时间")]
        [ColumnMapping(Name = "create_time")]
        public DateTime CreateTime { get; set; }


        public void TrimColumns()
        {
            this.SecurityTitle = (this.SecurityTitle ?? "").Trim();
            this.SecurityAnswer = (this.SecurityAnswer ?? "").Trim();

        }
    }

}