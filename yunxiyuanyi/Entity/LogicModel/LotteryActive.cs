using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 抽奖行为记录
	/// </summary>
	[Serializable]
	public class LotteryActive:BaseModel
	{

		/// <summary> 
		/// 自增主键 
		/// </summary> 
		[DisplayName("自增主键")] 
		[ColumnMapping(Name="active_id")] 
		public long ActiveId { get; set; }

		/// <summary> 
		/// 奖品Id 
		/// </summary> 
		[DisplayName("奖品Id")] 
		[ColumnMapping(Name="prize_id")] 
		public long PrizeId { get; set; }

		/// <summary> 
		/// 抽奖活动Id 
		/// </summary> 
		[DisplayName("抽奖活动Id")] 
		[ColumnMapping(Name="lottery_id")] 
		public long LotteryId { get; set; }



		/// <summary> 
		/// 用户IP 
		/// </summary> 
		[DisplayName("用户IP")] 
		[ColumnMapping(Name="active_ip")] 
		public string ActiveIp { get; set; }

		/// <summary> 
		/// 中将类型 
		/// </summary> 
		[DisplayName("中将类型")] 
		[ColumnMapping(Name="active_type")] 
		public int ActiveType { get; set; }

		/// <summary> 
		/// 奖品名称 
		/// </summary> 
		[DisplayName("奖品名称")] 
		[ColumnMapping(Name="prize_name")] 
		public string PrizeName { get; set; }


		public void TrimColumns()
		{

			this.ActiveIp = (this.ActiveIp ?? "").Trim();

			this.PrizeName = (this.PrizeName ?? "").Trim();

		}
	}
}
