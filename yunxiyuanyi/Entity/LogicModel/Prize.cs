using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 奖品信息
	/// </summary>
	[Serializable]
	public class Prize:BaseModel
	{

		/// <summary> 
		/// 自增主键 
		/// </summary> 
		[DisplayName("自增主键")] 
		[ColumnMapping(Name="prize_id")] 
		public long PrizeId { get; set; }

		/// <summary> 
		/// 奖品名称 
		/// </summary> 
		[DisplayName("奖品名称")] 
		[ColumnMapping(Name="prize_name")] 
		public string PrizeName { get; set; }

		/// <summary> 
		/// 奖品在抽奖程序的显示位置 
		/// </summary> 
		[DisplayName("奖品在抽奖程序的显示位置")] 
		[ColumnMapping(Name="prize_index")] 
		public int PrizeIndex { get; set; }

		/// <summary> 
		/// 奖品库存 
		/// </summary> 
		[DisplayName("奖品库存")] 
		[ColumnMapping(Name="total_inventory")] 
		public int TotalInventory { get; set; }



		/// <summary> 
		/// 中奖率 
		/// </summary> 
		[DisplayName("中奖率")] 
		[ColumnMapping(Name="winning_rate")] 
		public int WinningRate { get; set; }

		/// <summary> 
		/// 抽奖活动 
		/// </summary> 
		[DisplayName("抽奖活动")] 
		[ColumnMapping(Name="lottery_id")] 
		public long LotteryId { get; set; }

		/// <summary> 
		/// 奖品图片位置 
		/// </summary> 
		[DisplayName("奖品图片位置")] 
		[ColumnMapping(Name="prize_image")] 
		public string PrizeImage { get; set; }


		public void TrimColumns()
		{

			this.PrizeName = (this.PrizeName ?? "").Trim();

			this.PrizeImage = (this.PrizeImage ?? "").Trim();

		}
	}
}
