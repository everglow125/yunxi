using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common;
namespace Entity.LogicModel
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class User
    {

        /// <summary> 
        /// 自增主键 
        /// </summary> 
        [DisplayName("自增主键")]
        [ColumnMapping(Name = "user_id")]
        public long UserId { get; set; }

        /// <summary> 
        /// 登录名 
        /// </summary> 
        [DisplayName("登录名")]
        [ColumnMapping(Name = "login_name")]
        public string LoginName { get; set; }

        /// <summary> 
        /// 昵称 
        /// </summary> 
        [DisplayName("昵称")]
        [ColumnMapping(Name = "nick_name")]
        public string NickName { get; set; }

        /// <summary> 
        /// 联系电话 
        /// </summary> 
        [DisplayName("联系电话")]
        [ColumnMapping(Name = "mobie_num")]
        public string MobieNum { get; set; }

        /// <summary> 
        /// 登录密码 
        /// </summary> 
        [DisplayName("登录密码")]
        [ColumnMapping(Name = "login_pwd")]
        public string LoginPwd { get; set; }

        /// <summary> 
        /// 邮箱 
        /// </summary> 
        [DisplayName("邮箱")]
        [ColumnMapping(Name = "email")]
        public string Email { get; set; }

        /// <summary> 
        /// 用户状态 1手机已验证 2邮箱已验证 4已禁用 
        /// </summary> 
        [DisplayName("用户状态 1手机已验证 2邮箱已验证 4已禁用")]
        [ColumnMapping(Name = "user_status")]
        public int UserStatus { get; set; }

        /// <summary> 
        /// 用户角色 1管理员 2买家 4卖家 8客服 
        /// </summary> 
        [DisplayName("用户角色 1管理员 2买家 4卖家 8客服")]
        [ColumnMapping(Name = "user_role")]
        public int UserRole { get; set; }

        /// <summary> 
        /// 创建时间 
        /// </summary> 
        [DisplayName("创建时间")]
        [ColumnMapping(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary> 
        /// 用户积分 
        /// </summary> 
        [DisplayName("用户积分")]
        [ColumnMapping(Name = "user_point")]
        public int UserPoint { get; set; }

        /// <summary> 
        /// 用户经验值 
        /// </summary> 
        [DisplayName("用户经验值")]
        [ColumnMapping(Name = "empirical_value")]
        public int EmpiricalValue { get; set; }

        /// <summary> 
        /// 用户等级 
        /// </summary> 
        [DisplayName("用户等级")]
        [ColumnMapping(Name = "user_level")]
        public int UserLevel { get; set; }

        /// <summary> 
        /// 用户头像 
        /// </summary> 
        [DisplayName("用户头像")]
        [ColumnMapping(Name = "photo_url")]
        public string PhotoUrl { get; set; }

        /// <summary> 
        /// 性别 
        /// </summary> 
        [DisplayName("性别")]
        [ColumnMapping(Name = "user_sex")]
        public int UserSex { get; set; }

        /// <summary> 
        /// 出生日期 
        /// </summary> 
        [DisplayName("出生日期")]
        [ColumnMapping(Name = "user_birth")]
        public DateTime UserBirth { get; set; }

        /// <summary> 
        /// 自我介绍 
        /// </summary> 
        [DisplayName("自我介绍")]
        [ColumnMapping(Name = "user_description")]
        public string UserDescription { get; set; }


        public void TrimColumns()
        {
            this.LoginName = (this.LoginName ?? "").Trim();
            this.NickName = (this.NickName ?? "").Trim();
            this.MobieNum = (this.MobieNum ?? "").Trim();
            this.LoginPwd = (this.LoginPwd ?? "").Trim();
            this.Email = (this.Email ?? "").Trim();
            this.PhotoUrl = (this.PhotoUrl ?? "").Trim();
            this.UserDescription = (this.UserDescription ?? "").Trim();

        }
    }

}
