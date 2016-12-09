using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 付款信息
    /// </summary>
    [Serializable]
    public class Payment
    {

        /// <summary> 
        /// 自增主键 
        /// </summary> 
        [DisplayName("自增主键")]
        [ColumnMapping(Name = "payment_id")]
        public long PaymentId { get; set; }

        /// <summary> 
        /// 订单Id 
        /// </summary> 
        [DisplayName("订单Id")]
        [ColumnMapping(Name = "order_id")]
        public long OrderId { get; set; }

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
        /// 实付金额 
        /// </summary> 
        [DisplayName("实付金额")]
        [ColumnMapping(Name = "total_paid")]
        public decimal TotalPaid { get; set; }

        /// <summary> 
        /// 支付状态 
        /// </summary> 
        [DisplayName("支付状态")]
        [ColumnMapping(Name = "payment_status")]
        public int PaymentStatus { get; set; }

        /// <summary> 
        /// 付款账号 
        /// </summary> 
        [DisplayName("付款账号")]
        [ColumnMapping(Name = "paid_account")]
        public string PaidAccount { get; set; }

        /// <summary> 
        /// 收款账号 
        /// </summary> 
        [DisplayName("收款账号")]
        [ColumnMapping(Name = "payee_account")]
        public string PayeeAccount { get; set; }

        /// <summary> 
        /// 交易流水号 
        /// </summary> 
        [DisplayName("交易流水号")]
        [ColumnMapping(Name = "trade_num")]
        public string TradeNum { get; set; }


        public void TrimColumns()
        {
            this.PaidAccount = (this.PaidAccount ?? "").Trim();
            this.PayeeAccount = (this.PayeeAccount ?? "").Trim();
            this.TradeNum = (this.TradeNum ?? "").Trim();

        }
    }

}
