using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// 简历求职意向读取
    /// </summary>
    public class getResumeJobWanted
    {
        /// <summary>
        /// 求职意向id
        /// </summary>
       public string jobwantedid { get; set; }
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