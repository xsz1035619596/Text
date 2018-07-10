//SoapAction报错原因 http://blog.csdn.net/wxyong3/article/details/38727503


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            #region MyRegion
            //var webResponse = CreatePostHttpResponse();
            //Stream ou = webResponse.GetResponseStream();
            //StreamReader objReader = null;
            //try
            //{
            //    objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
            //}
            //catch (Exception)
            //{

            //}

            //string strHtml = "", strLine = "";
            //strHtml = objReader.ReadToEnd();

            //ou.Close();
            //return Content(strHtml);
            #endregion

          
            //return Content(SingularNum.CreatePostHttpResponse("DicAreaApp","0"));//获取公共数据字典。
            //return Content(SingularNum.CreatePostHttpResponse_getJkUserInfo("DicAreaApp"));//获取接口调用者信息
            //return Content(SingularNum.CreatePostHttpResponse_getUserInfo("","500226199712221578","2"));//个人信息读取
            //return Content(SingularNum.CreatePostHttpResponse_getResumeBase("","","徐世章","500226199712221578","",""));//简历基本信息读取
            //return Content(SingularNum.CreatePostHttpResponse_getResumeExp("", "1","", ""));//简历基本信息读取
            //return Content(SingularNum.CreatePostHttpResponse_getResumeJobWanted("", "1", "", ""));//简历求职意向读取
            getUnit model = new getUnit();

            var ceshi = new
            {
                unitid = 10,
                unitname = 10,
                organcode = 10,
                businessid = 10,
                loginname = 10,
                password = 10,
                comtype = 10,
                commericaltype = 10,
                comaddress = 10,
                coordinatex = 10,
                coordinatey = 10,
                geoid = 10,
                bz = 10,
                legle = 10,
                pagesize = 10,
                pageindex = 1
            };
    
            var s= JsonConvert.SerializeObject(ceshi);
            getUnit model2 = JsonConvert.DeserializeObject<getUnit>(s);


            //SingularNum SingularNum = new SingularNum();


            //getDic getDic = new getDic() { dicname= "DicAreaApp", itemid="0" };
            //return Content(SingularNum<getDic>.GetCreateInstens<getDic>(getDic));//获取公共数据字典

            //getJkUserInfo getJkUserInfo = new getJkUserInfo() { jkuser="1" }; 
            //return Content(SingularNum<getJkUserInfo>.GetCreateInstens<getJkUserInfo>(getJkUserInfo));//获取接口调用者信息

            //getUserInfo getUserInfo = new getUserInfo() { sfz ="500226199712221578"};
            //return Content(SingularNum<getUserInfo>.GetCreateInstens<getUserInfo>(getUserInfo));//个人信息读取

            //getResumeBase getResumeBase = new getResumeBase() { sfz = "500226199712221578" };
            //return Content(SingularNum<getResumeBase>.GetCreateInstens<getResumeBase>(getResumeBase));//简历基本信息读取

            //getResumeExp getResumeExp = new getResumeExp() { resumeid = "1" };
            //return Content(SingularNum<getResumeExp>.GetCreateInstens<getResumeExp>(getResumeExp));//简历经历读取

            //getResumeJobWanted getResumeJobWanted = new getResumeJobWanted() { resumeid = "1" };
            //return Content(SingularNum<getResumeJobWanted>.GetCreateInstens<getResumeJobWanted>(getResumeJobWanted));//简历求职意向读取

            //getUnit getUnit = new getUnit() {
            //    unitid = "10",
            //    unitname = "10",
            //    organcode = "10",
            //    businessid = "10",
            //    loginname = "x1035619596",
            //    password = "x1035619596",
            //    comtype = "10",
            //    commericaltype = "10",
            //    comaddress = "10",
            //    coordinatex = "10",
            //    coordinatey = "10",
            //    geoid = "10",
            //    bz = "10",
            //    legle = "10",
            //    pagesize = "10",
            //    pageindex = "1"
            //};
            //return Content(SingularNum<getUnit>.GetCreateInstens<getUnit>(getUnit));//单位信息读取

            addPostJob addPostJob = new addPostJob() {
               unitid="100000027573",
               jobname="测试岗位",
               jobdescription="测试",
               wagelower="3000",
               wageupper ="5000",
               vocationaltitle="2029900",
               workperiod="1",
               probation="3",
               professional="20203",
               education="21",
               vocationalskilln="0",
               vocationalskill="9",
               worklocation="50000000",
              jobtype="1",
               accommodation="0",
               worktime="1",
               environment="1",
               expertisetitle="83",
               psnrequiedcnt="1",
               man="1",
               women="0",
               agelower="20",
               ageupper="40",
               trafficaround="1",
               height="1",
               vision="1",
               graduatingstudent="0",
               enddate="2018-07-11",//时间无法正确填写
               disabledperson="0",
               foreignlanguage="",
               zzmm ="1",
               mqzt="1",
               wysp="1",
               jsjsp="1",
               jkuser="***",
               isband="1",
               jbr="566"
            };
            //return Content(SingularNum<addPostJob>.GetCreateInstens<addPostJob>(addPostJob));//岗位信息写入


            addRelation addRelation = new addRelation() { 
                resumeid="1",
                jobid="必",
                oprdate = "必",
                applystatus = "必",
                comefrom = "必",
                lastoprdate = "必",
                relationid = "必",
                jkuser = "123",
            };

            // return Content(SingularNum<addRelation>.GetCreateInstens<addRelation>(addRelation));//招录信息写入

            addJobFairAddr addJobFairAddr = new addJobFairAddr() {
                cdmc = "测试场地1",
                tws="2",
                address="测试地址",
                tell="1582223333",
                contactor="qx",
                gljgid="9999",
                jkuser="cs233"
            };
            //return Content(SingularNum<addJobFairAddr>.GetCreateInstens<addJobFairAddr>(addJobFairAddr));//招聘会场地及摊位新增

            addJobFair addJobFair = new addJobFair() {
                loginname="1",
                password2="1",
                fairName="1",
                content="1",
                fairType="1",
                startDate="1",
                addrid="1"    
            };
            //return Content(SingularNum<addJobFair>.GetCreateInstens<addJobFair>(addJobFair));//招聘会新增

            getJobFairDetail getJobFairDetail = new getJobFairDetail() {
                fairId = "100000199236"
            };
            return Content(SingularNum<getJobFairDetail>.GetCreateInstens<getJobFairDetail>(getJobFairDetail));//招聘会详细信息读取
        }





    }
}


