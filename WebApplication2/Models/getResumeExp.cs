using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// 简历经历读取
    /// </summary>
    public class getResumeExp
    {
        /// <summary>
        /// 经历id
        /// </summary>
       public string jlid { get; set; }
        /// <summary>
        /// 简历id
        /// </summary>
       public string resumeid { get; set; }
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