using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// 岗位信息写入
    /// </summary>
    public class addPostJob
    {
        /// <summary>
        /// 单位用户ID
        /// </summary>
        public string unitid { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string jobname { get; set; }
        /// <summary>
        /// 岗位描述
        /// </summary>
        public string jobdescription { get; set; }
        /// <summary>
        /// 工资上限（元/月）
        /// </summary>
        public string wageupper { get; set; }
        /// <summary>
        /// 工资下限(元/月)
        /// </summary>
        public string wagelower { get; set; }
        /// <summary>
        /// 岗位类别（职业技能工种）
        /// </summary>
        public string vocationaltitle { get; set; }
        /// <summary>
        /// 工作年限
        /// </summary>
        public string workperiod { get; set; }
        /// <summary>
        /// 试用期（个月）
        /// </summary>
        public string probation { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string professional { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        public string education { get; set; }
        /// <summary>
        /// 职业技能等级
        /// </summary>
        public string vocationalskilln { get; set; }
        /// <summary>
        /// 专业技术水平
        /// </summary>
        public string vocationalskill { get; set; }
        /// <summary>
        /// 工作地点
        /// </summary>
        public string worklocation { get; set; }
        /// <summary>
        /// 工作性质
        /// </summary>
        public string jobtype { get; set; }
        /// <summary>
        /// 是否提供食宿
        /// </summary>
        public string accommodation { get; set; }
        /// <summary>
        /// 工作班时
        /// </summary>
        public string worktime { get; set; }
        /// <summary>
        /// 环境
        /// </summary>
        public string environment { get; set; }
        /// <summary>
        /// 专业技术职称
        /// </summary>
        public string expertisetitle { get; set; }
        /// <summary>
        /// 招聘人数
        /// </summary>
        public string psnrequiedcnt { get; set; }
        /// <summary>
        /// 其中招聘男性
        /// </summary>
        public string man { get; set; }
        /// <summary>
        /// 其中招聘女性
        /// </summary>
        public string women { get; set; }
        /// <summary>
        /// 年龄下限
        /// </summary>
        public string agelower { get; set; }
        /// <summary>
        /// 年龄上限
        /// </summary>
        public string ageupper { get; set; }
        /// <summary>
        /// 保险情况
        /// </summary>
        public string trafficaround { get; set; }
        /// <summary>
        /// 身高要求
        /// </summary>
        public string height { get; set; }
        /// <summary>
        /// 视力要求
        /// </summary>
        public string vision { get; set; }
        /// <summary>
        /// 是否招应届生
        /// </summary>
        public string graduatingstudent { get; set; }
        /// <summary>
        /// 有效期结束时间
        /// </summary>
        public string enddate { get; set; }
        /// <summary>
        /// 是否招残疾人员
        /// </summary>
        public string disabledperson { get; set; }
        /// <summary>
        /// 外语能力
        /// </summary>
        public string foreignlanguage { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string zzmm { get; set; }
        /// <summary>
        /// 外语语种
        /// </summary>
        public string mqzt { get; set; }
        /// <summary>
        /// 外语水平
        /// </summary>
        public string wysp { get; set; }
        /// <summary>
        /// 计算机水平
        /// </summary>
        public string jsjsp { get; set; }
        /// <summary>
        /// 接口调用者
        /// </summary>
        public string jkuser { get; set; }
        /// <summary>
        /// 是否与当地就业局任务绑定
        /// </summary>
        public string isband { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        public string jbr { get; set; }
    }
}