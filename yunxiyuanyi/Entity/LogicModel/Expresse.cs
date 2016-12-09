using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 快递信息
    /// </summary>
    [Serializable]
    public class Expresse
    {

        /// <summary> 
        /// 主键 
        /// </summary> 
        [DisplayName("主键")]
        [ColumnMapping(Name = "express_id")]
        public long ExpressId { get; set; }

        /// <summary> 
        /// 快递单号 
        /// </summary> 
        [DisplayName("快递单号")]
        [ColumnMapping(Name = "express_num")]
        public string ExpressNum { get; set; }

        /// <summary> 
        /// 快递公司 
        /// </summary> 
        [DisplayName("快递公司")]
        [ColumnMapping(Name = "express_company")]
        public string ExpressCompany { get; set; }

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


        public void TrimColumns()
        {
            this.ExpressNum = (this.ExpressNum ?? "").Trim();
            this.ExpressCompany = (this.ExpressCompany ?? "").Trim();

        }
    }

}
