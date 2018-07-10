using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// 招录信息写入
    /// </summary>
    public class addRelation
    {
        /// <summary>
        /// 简历ID
        /// </summary>
        public string resumeid { get; set; }
        /// <summary>
        /// 岗位ID
        /// </summary>
       public string jobid { get; set; }
        /// <summary>
        /// 匹配时间
        /// </summary>
        public string oprdate { get; set; }
        /// <summary>
        /// 求职状态
        /// </summary>
        public string applystatus { get; set; }
        /// <summary>
        /// 来源字典
        /// </summary>
        public string comefrom { get; set; }
        /// <summary>
        /// 最近一次操作时间
        /// </summary>
        public string lastoprdate { get; set; }
        /// <summary>
        /// 主键ID
        /// </summary>
        public string relationid { get; set; }
        /// <summary>
        /// 接口调用者
        /// </summary>
        public string jkuser { get; set; }

    }
}