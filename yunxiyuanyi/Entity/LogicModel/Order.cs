using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 订单信息
	/// </summary>
	[Serializable]
	public class Order:BaseModel
	{

		/// <summary> 
		/// 自增主键 
		/// </summary> 
		[DisplayName("自增主键")] 
		[ColumnMapping(Name="order_id")] 
		public long OrderId { get; set; }

		/// <summary> 
		/// 订单编号 
		/// </summary> 
		[DisplayName("订单编号")] 
		[ColumnMapping(Name="order_num")] 
		public string OrderNum { get; set; }



		/// <summary> 
		/// 订单状态 
		/// </summary> 
		[DisplayName("订单状态")] 
		[ColumnMapping(Name="order_status")] 
		public int OrderStatus { get; set; }

		/// <summary> 
		/// 支付时间 
		/// </summary> 
		[DisplayName("支付时间")] 
		[ColumnMapping(Name="pay_time")] 
		public DateTime PayTime { get; set; }

		/// <summary> 
		/// 订单总额 
		/// </summary> 
		[DisplayName("订单总额")] 
		[ColumnMapping(Name="total_amount")] 
		public decimal TotalAmount { get; set; }

		/// <summary> 
		/// 手机号 
		/// </summary> 
		[DisplayName("手机号")] 
		[ColumnMapping(Name="mobie_num")] 
		public string MobieNum { get; set; }

		/// <summary> 
		/// 省 
		/// </summary> 
		[DisplayName("省")] 
		[ColumnMapping(Name="province")] 
		public int Province { get; set; }

		/// <summary> 
		/// 市 
		/// </summary> 
		[DisplayName("市")] 
		[ColumnMapping(Name="city")] 
		public string City { get; set; }

		/// <summary> 
		/// 县 
		/// </summary> 
		[DisplayName("县")] 
		[ColumnMapping(Name="county")] 
		public string County { get; set; }

		/// <summary> 
		/// 详细地址 
		/// </summary> 
		[DisplayName("详细地址")] 
		[ColumnMapping(Name="address")] 
		public string Address { get; set; }

		/// <summary> 
		/// 邮编 
		/// </summary> 
		[DisplayName("邮编")] 
		[ColumnMapping(Name="postcode")] 
		public string Postcode { get; set; }

		/// <summary> 
		/// 快递费 
		/// </summary> 
		[DisplayName("快递费")] 
		[ColumnMapping(Name="express_fee")] 
		public decimal ExpressFee { get; set; }


		public void TrimColumns()
		{

			this.OrderNum = (this.OrderNum ?? "").Trim();

			this.MobieNum = (this.MobieNum ?? "").Trim();

			this.City = (this.City ?? "").Trim();

			this.County = (this.County ?? "").Trim();

			this.Address = (this.Address ?? "").Trim();

			this.Postcode = (this.Postcode ?? "").Trim();

		}
	}
}
