using HanJie.CSLCN.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HanJie.CSLCN.Models.DataModels
{
    public class UserInfo : BaseDataModel<UserInfo, UserInfoDto>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
    }
}
