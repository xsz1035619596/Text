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
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class SingularNum
    {
        #region 获取公共数据字典
        /// <summary>
        /// 获取公共数据字典。
        /// </summary>
        /// <param name="dicname">字典名</param>
        /// <param name="itemid">父类码值</param>
        /// <returns></returns>
        public string CreatePostHttpResponse(string dicname, string itemid)
        {
            string url = "http://cqjyht.cqhrss.gov.cn/cqhrweb/services/ServiceAgent";
            var requestEncoding = Encoding.UTF8;

            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "");
            //request.ContentType = "application/x-www-form-urlencoded";

            //如果需要POST数据  
            string text = GetString("developer", "123321", dicname, itemid);

            byte[] data = requestEncoding.GetBytes(text);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var ss = request.GetResponse();
            //return ss as HttpWebResponse;

            var webResponse = ss as HttpWebResponse;
            Stream ou = webResponse.GetResponseStream();
            StreamReader objReader = null;
            try
            {
                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
            }
            catch (Exception)
            {

            }

            string strHtml = "", strLine = "";
            strHtml = objReader.ReadToEnd();

            ou.Close();
            return strHtml;
        }
        /// <summary>
        /// 通用
        /// </summary>
        /// <param name="url"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public string strString(string url, string xml)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ServicePoint.Expect100Continue = false;
            request.Method = "POST";
            request.MediaType = "application/xop+xml";
            request.ContentType = "text/xml";
            request.Timeout = 10000;
            Stream writer = request.GetRequestStream();
            string text = xml;
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(text);
            text = doc.OuterXml;

            byte[] bin = System.Text.Encoding.UTF8.GetBytes(text);
            writer.Write(bin, 0, bin.Length);

            writer.Close();
            HttpWebResponse res = null;

            try
            {
                res = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException wex)
            {
                res = (HttpWebResponse)wex.Response;

            }
            catch (Exception ex)
            {
                if (res == null)
                    res.Close();
                return ex.ToString();
            }

            Stream ou = res.GetResponseStream();
            StreamReader objReader = null;
            try
            {
                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
            }
            catch (Exception)
            {

            }

            string strHtml = "", strLine = "";
            strHtml = objReader.ReadToEnd();

            ou.Close();
            return strHtml;

            return "";
        }
        public string GetString(string UserName, string passWord, string dicname, string itemid)
        {

            return "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.webservice.wondersgroup.com/\">"
                   + "<soapenv:Header>"
                   + "<soap:Head soap:actor=\"http://schemas.xmlsoap.org/soap/actor/next\" soap:mustUnderstand=\"0\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">"
                   + "<soap:username>" + UserName + "</soap:username>"
                   + "<soap:password>" + passWord + "</soap:password>"
                   + "</soap:Head>"
                   + "</soapenv:Header>"
                   + "<soapenv:Body>"

                + "<ws:getDic soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">"
                + "<xml xsi:type=\"xsd: string\" xs:type=\"type:string\" xmlns:xs=\"http://www.w3.org/2000/XMLSchema-instance\">"
                + "<![CDATA["
                   + "<input>"
                   + "<dicname>" + dicname + "</dicname>"
                   + "<itemid>" + itemid + "</itemid>"
                   + "</input>"
                + " ]]></xml>"
                + "</ws:getDic>"
                   + "</soapenv:Body>"
                   + "</soapenv:Envelope>";

        }

        #endregion

        #region 获取接口调用者的信息
        public string GetString_getJkUserInfo(string UserName, string passWord, string jkuser)
        {

            return "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.webservice.wondersgroup.com/\">"
                   + "<soapenv:Header>"
                   + "<soap:Head soap:actor=\"http://schemas.xmlsoap.org/soap/actor/next\" soap:mustUnderstand=\"0\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">"
                   + "<soap:username>" + UserName + "</soap:username>"
                   + "<soap:password>" + passWord + "</soap:password>"
                   + "</soap:Head>"
                   + "</soapenv:Header>"
                   + "<soapenv:Body>"

                + "<ws:getJkUserInfo soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">"
                + "<xml xsi:type=\"xsd: string\" xs:type=\"type:string\" xmlns:xs=\"http://www.w3.org/2000/XMLSchema-instance\">"
                + "<![CDATA["
                   + "<input>"
                   + "<jkuser>" + jkuser + "</jkuser>"
                   + "</input>"
                + " ]]></xml>"
                + "</ws:getJkUserInfo>"
                   + "</soapenv:Body>"
                   + "</soapenv:Envelope>";

        }
        /// <summary>
        /// 获取接口调用者信息——接口调用者需与就业局联系申请接口账号。
        /// </summary>
        /// <param name="jkuser">接口调用者</param>
        /// <returns></returns>
        public string CreatePostHttpResponse_getJkUserInfo(string jkuser)
        {
            string url = "http://cqjyht.cqhrss.gov.cn/cqhrweb/services/ServiceAgent";
            var requestEncoding = Encoding.UTF8;

            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "");
            //request.ContentType = "application/x-www-form-urlencoded";

            //如果需要POST数据  
            string text = GetString_getJkUserInfo("developer", "123321", jkuser);

            byte[] data = requestEncoding.GetBytes(text);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var ss = request.GetResponse();
            //return ss as HttpWebResponse;


            var webResponse = ss as HttpWebResponse;
            Stream ou = webResponse.GetResponseStream();
            StreamReader objReader = null;
            try
            {
                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
            }
            catch (Exception)
            {

            }

            string strHtml = "", strLine = "";
            strHtml = objReader.ReadToEnd();

            ou.Close();
            return strHtml;
        }
        #endregion

        #region 个人信息读取
        public string GetString_getUserInfo(string UserName, string passWord, string psnid,string sfz,string loginname)
        {

            return "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.webservice.wondersgroup.com/\">"
                   + "<soapenv:Header>"
                   + "<soap:Head soap:actor=\"http://schemas.xmlsoap.org/soap/actor/next\" soap:mustUnderstand=\"0\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">"
                   + "<soap:username>" + UserName + "</soap:username>"
                   + "<soap:password>" + passWord + "</soap:password>"
                   + "</soap:Head>"
                   + "</soapenv:Header>"
                   + "<soapenv:Body>"

                + "<ws:getUserInfo soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">"
                + "<xml xsi:type=\"xsd: string\" xs:type=\"type:string\" xmlns:xs=\"http://www.w3.org/2000/XMLSchema-instance\">"
                + "<![CDATA["
                   + "<input>"
                   + "<psnid>" + psnid + "</psnid>"
                   + "<sfz>" + sfz + "</sfz>"
                   + "<loginname>" + loginname + "</loginname>"
                   + "</input>"
                + " ]]></xml>"
                + "</ws:getUserInfo>"
                   + "</soapenv:Body>"
                   + "</soapenv:Envelope>";

        }
        /// <summary>
        /// 个人信息读取
        /// </summary>
        /// <param name="psnid">用户ID</param>
        /// <param name="sfz">省份证号</param>
        /// <param name="loginname">登录名</param>
        /// <returns></returns>
        public string CreatePostHttpResponse_getUserInfo(string psnid, string sfz, string loginname)
        {
            string url = "http://cqjyht.cqhrss.gov.cn/cqhrweb/services/ServiceAgent";
            var requestEncoding = Encoding.UTF8;

            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "");
            //request.ContentType = "application/x-www-form-urlencoded";

            //如果需要POST数据  
            string text = GetString_getUserInfo("developer", "123321", psnid,sfz,loginname);

            byte[] data = requestEncoding.GetBytes(text);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var ss = request.GetResponse();
            //return ss as HttpWebResponse;


            var webResponse = ss as HttpWebResponse;
            Stream ou = webResponse.GetResponseStream();
            StreamReader objReader = null;
            try
            {
                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
            }
            catch (Exception)
            {

            }

            string strHtml = "", strLine = "";
            strHtml = objReader.ReadToEnd();

            ou.Close();
            return strHtml;
        }
        #endregion

        #region 简历基本信息读取
        public string GetString_getResumeBase(string UserName, string passWord, string resumeid, string personid, string realname,string sfz,string pagesize,string pageindex)
        {

            return "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.webservice.wondersgroup.com/\">"
                   + "<soapenv:Header>"
                   + "<soap:Head soap:actor=\"http://schemas.xmlsoap.org/soap/actor/next\" soap:mustUnderstand=\"0\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">"
                   + "<soap:username>" + UserName + "</soap:username>"
                   + "<soap:password>" + passWord + "</soap:password>"
                   + "</soap:Head>"
                   + "</soapenv:Header>"
                   + "<soapenv:Body>"

                + "<ws:getResumeBase soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">"
                + "<xml xsi:type=\"xsd: string\" xs:type=\"type:string\" xmlns:xs=\"http://www.w3.org/2000/XMLSchema-instance\">"
                + "<![CDATA["
                   + "<input>"
                   + "<resumeid>" + resumeid + "</resumeid>"
                   + "<personid>" + personid + "</personid>"
                   + "<realname>" + realname + "</realname>"
                   + "<sfz>" + sfz + "</sfz>"
                   + "<pagesize>" + pagesize + "</pagesize>"
                   + "<pageindex>" + pageindex + "</pageindex>"
                   +"</input>"
                     + " ]]></xml>"
                    + "</ws:getResumeBase>"
                   + "</soapenv:Body>"
                   + "</soapenv:Envelope>";

        }
        /// <summary>
        /// 简历基本信息读取
        /// </summary>
        /// <param name="resumeid">简历id</param>
        /// <param name="personid">个人id</param>
        /// <param name="realname">真实姓名</param>
        /// <param name="sfz"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string CreatePostHttpResponse_getResumeBase(string resumeid, string personid, string realname, string sfz, string pagesize, string pageindex)
        {
            string url = "http://cqjyht.cqhrss.gov.cn/cqhrweb/services/ServiceAgent";
            var requestEncoding = Encoding.UTF8;

            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "");
            //request.ContentType = "application/x-www-form-urlencoded";

            //如果需要POST数据  
            string text = GetString_getResumeBase("developer", "123321", resumeid, personid, realname, sfz, pagesize, pageindex);

            byte[] data = requestEncoding.GetBytes(text);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var ss = request.GetResponse();
            //return ss as HttpWebResponse;


            var webResponse = ss as HttpWebResponse;
            Stream ou = webResponse.GetResponseStream();
            StreamReader objReader = null;
            try
            {
                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
            }
            catch (Exception)
            {

            }

            string strHtml = "", strLine = "";
            strHtml = objReader.ReadToEnd();

            ou.Close();
            return strHtml;
        }
        #endregion

        #region 简历经历读取
        public string GetString_getResumeExp(string UserName, string passWord, string jlid, string resumeid, string pagesize, string pageindex)
        {

            return "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.webservice.wondersgroup.com/\">"
                   + "<soapenv:Header>"
                   + "<soap:Head soap:actor=\"http://schemas.xmlsoap.org/soap/actor/next\" soap:mustUnderstand=\"0\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">"
                   + "<soap:username>" + UserName + "</soap:username>"
                   + "<soap:password>" + passWord + "</soap:password>"
                   + "</soap:Head>"
                   + "</soapenv:Header>"
                   + "<soapenv:Body>"

                + "<ws:getResumeExp soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">"
                + "<xml xsi:type=\"xsd: string\" xs:type=\"type:string\" xmlns:xs=\"http://www.w3.org/2000/XMLSchema-instance\">"
                + "<![CDATA["
                   + "<input>"
                   + "<jlid>" + jlid + "</jlid>"
                   + "<resumeid>" + resumeid + "</resumeid>"
                   + "<pagesize>" + pagesize + "</pagesize>"
                   + "<pageindex>" + pageindex + "</pageindex>"
                   + "</input>"
                     + " ]]></xml>"
                    + "</ws:getResumeExp>"
                   + "</soapenv:Body>"
                   + "</soapenv:Envelope>";

        }
        /// <summary>
        /// 简历经历读取
        /// </summary>
        /// <param name="jlid">经历id</param>
        /// <param name="resumeid">简历id</param>
        /// <param name="pagesize">页容量</param>
        /// <param name="pageindex">当前页</param>
        /// <returns></returns>
        public string CreatePostHttpResponse_getResumeExp(string jlid, string resumeid, string pagesize, string pageindex)
        {
            string url = "http://cqjyht.cqhrss.gov.cn/cqhrweb/services/ServiceAgent";
            var requestEncoding = Encoding.UTF8;

            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "");
            //request.ContentType = "application/x-www-form-urlencoded";

            //如果需要POST数据  
            string text = GetString_getResumeExp("developer", "123321", jlid, resumeid,pagesize, pageindex);

            byte[] data = requestEncoding.GetBytes(text);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var ss = request.GetResponse();
            //return ss as HttpWebResponse;


            var webResponse = ss as HttpWebResponse;
            Stream ou = webResponse.GetResponseStream();
            StreamReader objReader = null;
            try
            {
                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
            }
            catch (Exception)
            {

            }

            string strHtml = "", strLine = "";
            strHtml = objReader.ReadToEnd();

            ou.Close();
            return strHtml;
        }
        #endregion

        #region 简历求职意向读取
        public string GetString_getResumeJobWanted(string UserName, string passWord, string jobwantedid, string resumeid, string pagesize, string pageindex)
        {

            return "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.webservice.wondersgroup.com/\">"
                   + "<soapenv:Header>"
                   + "<soap:Head soap:actor=\"http://schemas.xmlsoap.org/soap/actor/next\" soap:mustUnderstand=\"0\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">"
                   + "<soap:username>" + UserName + "</soap:username>"
                   + "<soap:password>" + passWord + "</soap:password>"
                   + "</soap:Head>"
                   + "</soapenv:Header>"
                   + "<soapenv:Body>"

                + "<ws:getResumeJobWanted  soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">"
                + "<xml xsi:type=\"xsd: string\" xs:type=\"type:string\" xmlns:xs=\"http://www.w3.org/2000/XMLSchema-instance\">"
                + "<![CDATA["
                   + "<input>"
                   + "<jobwantedid>" + jobwantedid + "</jobwantedid>"
                   + "<resumeid>" + resumeid + "</resumeid>"
                   + "<pagesize>" + pagesize + "</pagesize>"
                   + "<pageindex>" + pageindex + "</pageindex>"
                   + "</input>"
                     + " ]]></xml>"
                    + "</ws:getResumeJobWanted >"
                   + "</soapenv:Body>"
                   + "</soapenv:Envelope>";

        }
        /// <summary>
        /// 简历经历读取
        /// </summary>
        /// <param name="jobwantedid">求职意向id</param>
        /// <param name="resumeid">简历id</param>
        /// <param name="pagesize">页容量</param>
        /// <param name="pageindex">当前页</param>
        /// <returns></returns>
        public string CreatePostHttpResponse_getResumeJobWanted(string jobwantedid, string resumeid, string pagesize, string pageindex)
        {
            string url = "http://cqjyht.cqhrss.gov.cn/cqhrweb/services/ServiceAgent";
            var requestEncoding = Encoding.UTF8;

            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "");
            //request.ContentType = "application/x-www-form-urlencoded";

            //如果需要POST数据  
            string text = GetString_getResumeJobWanted("developer", "123321", jobwantedid, resumeid, pagesize, pageindex);

            byte[] data = requestEncoding.GetBytes(text);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var ss = request.GetResponse();
            //return ss as HttpWebResponse;


            var webResponse = ss as HttpWebResponse;
            Stream ou = webResponse.GetResponseStream();
            StreamReader objReader = null;
            try
            {
                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
            }
            catch (Exception)
            {

            }

            string strHtml = "", strLine = "";
            strHtml = objReader.ReadToEnd();

            ou.Close();
            return strHtml;
        }
        #endregion

        #region 单位信息读取
        public string GetString_getUnit(string UserName, string passWord,getUnit model)
        {

            return "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.webservice.wondersgroup.com/\">"
                   + "<soapenv:Header>"
                   + "<soap:Head soap:actor=\"http://schemas.xmlsoap.org/soap/actor/next\" soap:mustUnderstand=\"0\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">"
                   + "<soap:username>" + UserName + "</soap:username>"
                   + "<soap:password>" + passWord + "</soap:password>"
                   + "</soap:Head>"
                   + "</soapenv:Header>"
                   + "<soapenv:Body>"
                + "<ws:getUnit soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">"
                + "<xml xsi:type=\"xsd: string\" xs:type=\"type:string\" xmlns:xs=\"http://www.w3.org/2000/XMLSchema-instance\">"
                + "<![CDATA["
                   + "<input>"
                   + "<unitid>" + model.unitid + "</unitid>"
                   + "<unitname>" + model.unitname + "</unitname>"
                    + "<organcode>"+ model.organcode+ "</organcode>"
                    + "<businessid>"+ model.businessid+ "</businessid>"
                    + "<loginname>"+ model.loginname+ "</loginname>"
                    + "<password>"+ model.password+ "</password>"
                    + "<comtype>"+ model.comtype+ "</comtype>"
                    + "<commericaltype>"+ model.commericaltype+ "</commericaltype>"
                    + "<comaddress>"+ model.comaddress+ "</comaddress>"
                    + "<coordinatex>"+ model.coordinatex+ "</coordinatex>"
                    + "<coordinatey>"+ model.coordinatey+ "</coordinatey>"
                    + "<geoid>"+ model.geoid+ "</geoid>"
                    + "<bz>"+ model.bz+ "</bz>"
                    + "<legle>"+ model.legle+ "</legle>"
                    + "<pagesize>" + model.pagesize + "</pagesize>"
                   + "<pageindex>" + model.pageindex + "</pageindex>"
                   + "</input>"
                     + " ]]></xml>"
                    + "</ws:getUnit>"
                   + "</soapenv:Body>"
                   + "</soapenv:Envelope>";

        }
        /// <summary>
        /// 简历经历读取
        /// </summary>
        /// <param name="jobwantedid">求职意向id</param>
        /// <param name="resumeid">简历id</param>
        /// <param name="pagesize">页容量</param>
        /// <param name="pageindex">当前页</param>
        /// <returns></returns>
        public string CreatePostHttpResponse_getUnit(getUnit model)
        {
            string url = "http://cqjyht.cqhrss.gov.cn/cqhrweb/services/ServiceAgent";
            var requestEncoding = Encoding.UTF8;

            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "");
            //request.ContentType = "application/x-www-form-urlencoded";

            //如果需要POST数据  
            string text = GetString_getUnit("developer", "123321", model);

            byte[] data = requestEncoding.GetBytes(text);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var ss = request.GetResponse();
            //return ss as HttpWebResponse;

            var webResponse = ss as HttpWebResponse;
            Stream ou = webResponse.GetResponseStream();
            StreamReader objReader = null;
            try
            {
                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
            }
            catch (Exception)
            {

            }

            string strHtml = "", strLine = "";
            strHtml = objReader.ReadToEnd();

            ou.Close();
            return strHtml;
        }
        #endregion

    }
}