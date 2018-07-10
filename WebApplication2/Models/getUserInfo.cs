using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// 个人信息读取
    /// </summary>
    public class getUserInfo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string psnid { get; set; }
        /// <summary>
        /// 省份证号
        /// </summary>
        public string sfz { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string loginname { get; set; }

    }
}