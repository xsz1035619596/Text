using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// 简历基本信息读取
    /// </summary>
    public class getResumeBase
    {
        /// <summary>
        /// 简历id
        /// </summary>
       public string resumeid { get; set; }
        /// <summary>
        /// 个人id
        /// </summary>
        public string personid { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string realname { get; set; }
        //身份证
        public string sfz { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public string pagesize { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public string pageindex { get; set; }

    }
}