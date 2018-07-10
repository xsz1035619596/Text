using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// 招聘会场地及摊位新增
    /// </summary>
    public class addJobFairAddr
    {
        /// <summary>
        /// 场地名称
        /// </summary>
       public string cdmc { get; set; }
        /// <summary>
        /// 摊位数
        /// </summary>
       public string tws { get; set; }
        /// <summary>
        /// 场地地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string tell { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string contactor { get; set; }
        /// <summary>
        /// 管理机构id
        /// </summary>
        public string gljgid { get; set; }
        /// <summary>
        /// 接口调用者
        /// </summary>
        public string jkuser { get; set; }

    }
}