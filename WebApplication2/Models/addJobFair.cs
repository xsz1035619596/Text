using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// 招聘会新增
    /// </summary>
    public class addJobFair
    {
        /// <summary>
        /// 登录名
        /// </summary>
       public string loginname { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
       public string password2 { get; set; }
        /// <summary>
        /// 招聘会新增
        /// </summary>
       public string fairName { get; set; }
        /// <summary>
        /// 招聘会内容
        /// </summary>
       public string content { get; set; }
        /// <summary>
        /// 招聘会类型代码
        /// </summary>
        public string fairType { get; set; }
        /// <summary>
        /// 举办时间
        /// </summary>
        public string startDate { get; set; }
        /// <summary>
        /// 招聘会场地id
        /// </summary>
        public string addrid { get; set; }
        /// <summary>
        /// 接口调用者
        /// </summary>
        public string jkuser { get; set; }

    }
}