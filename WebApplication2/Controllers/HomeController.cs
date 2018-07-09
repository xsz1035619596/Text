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

            SingularNum SingularNum = new SingularNum();
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

            return Content(SingularNum.CreatePostHttpResponse_getUnit(model2));//简历求职意向读取
            
        }





    }
}


