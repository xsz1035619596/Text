using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// 单位信息读取
    /// </summary>
    public class getUnit
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public string unitid { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string unitname { get; set; }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string organcode { get; set; }
        /// <summary>
        /// 工商登记号
        /// </summary>
        public string businessid { get; set; }
        /// <summary>
        /// 登陆账号
        /// </summary>
        public string loginname { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 单位类型字典
        /// </summary>
        public string comtype { get; set; }
        /// <summary>
        /// 经济类型字典
        /// </summary>
        public string commericaltype { get; set; }
        /// <summary>
        /// 工商注册地址
        /// </summary>
        public string comaddress { get; set; }
        /// <summary>
        /// 地标横坐标
        /// </summary>
        public string coordinatex { get; set; }
        /// <summary>
        /// 地标纵坐标
        /// </summary>
        public string coordinatey { get; set; }
        /// <summary>
        /// 地位id
        /// </summary>
        public string geoid { get; set; }
        /// <summary>
        /// 公司备注
        /// </summary>
        public string bz { get; set; }
        /// <summary>
        /// 法定代表人
        /// </summary>
        public string legle { get; set; }
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