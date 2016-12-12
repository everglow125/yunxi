using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
	/// <summary>
	/// 邮箱/短信验证
	/// </summary>
	[Serializable]
	public class Verification:BaseModel
	{

		/// <summary> 
		/// 验证码主键 
		/// </summary> 
		[DisplayName("验证码主键")] 
		[ColumnMapping(Name="verification_id")] 
		public long VerificationId { get; set; }

		/// <summary> 
		/// 验证码 
		/// </summary> 
		[DisplayName("验证码")] 
		[ColumnMapping(Name="verification_code")] 
		public string VerificationCode { get; set; }



		/// <summary> 
		/// 失效时间 
		/// </summary> 
		[DisplayName("失效时间")] 
		[ColumnMapping(Name="failure_time")] 
		public DateTime FailureTime { get; set; }

		/// <summary> 
		/// 验证类型 
		/// </summary> 
		[DisplayName("验证类型")] 
		[ColumnMapping(Name="verification_type")] 
		public int VerificationType { get; set; }

		/// <summary> 
		/// 验证状态 1未验证 2已验证 4已失效 
		/// </summary> 
		[DisplayName("验证状态 1未验证 2已验证 4已失效")] 
		[ColumnMapping(Name="verification_status")] 
		public int VerificationStatus { get; set; }


		public void TrimColumns()
		{

			this.VerificationCode = (this.VerificationCode ?? "").Trim();

		}
	}
}
