////SoapAction报错原因 http://blog.csdn.net/wxyong3/article/details/38727503


//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Web;
//using System.Web.Mvc;
//using System.Xml;

//namespace WebApplication2.DAL
//{
//    public class ss
//    {

//        public ActionResult Index()
//        {
//            var webResponse = CreatePostHttpResponse();
//            Stream ou = webResponse.GetResponseStream();
//            StreamReader objReader = null;
//            try
//            {
//                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
//            }
//            catch (Exception)
//            {

//            }

//            string strHtml = "", strLine = "";
//            strHtml = objReader.ReadToEnd();

//            ou.Close();
//            return Convert(strHtml);

//        }


//        public HttpWebResponse CreatePostHttpResponse()
//        {
//            string url = "http://cqjyht.cqhrss.gov.cn/cqhrweb/services/ServiceAgent";
//            var requestEncoding = Encoding.UTF8;

//            HttpWebRequest request = null;
//            request = WebRequest.Create(url) as HttpWebRequest;
//            request.Method = "POST";
//            request.Headers.Add("getDic", "");
//            //request.ContentType = "application/x-www-form-urlencoded";

//            //如果需要POST数据  
//            string text = GetString("xsz1035619596", "xsz1035619596", "getDic", "0");

//            byte[] data = requestEncoding.GetBytes(text);
//            using (Stream stream = request.GetRequestStream())
//            {
//                stream.Write(data, 0, data.Length);
//            }
//            var ss = request.GetResponse();
//            return ss as HttpWebResponse;
//        }

//        public string strString(string url, string xml)
//        {
//            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
//            request.ServicePoint.Expect100Continue = false;
//            request.Method = "POST";
//            request.MediaType = "application/xop+xml";
//            request.ContentType = "text/xml";
//            request.Timeout = 10000;
//            Stream writer = request.GetRequestStream();
//            string text = xml;
//            XmlDocument doc = new XmlDocument();

//            doc.LoadXml(text);
//            text = doc.OuterXml;

//            byte[] bin = System.Text.Encoding.UTF8.GetBytes(text);
//            writer.Write(bin, 0, bin.Length);

//            writer.Close();
//            HttpWebResponse res = null;

//            try
//            {
//                res = request.GetResponse() as HttpWebResponse;
//            }
//            catch (WebException wex)
//            {
//                res = (HttpWebResponse)wex.Response;

//            }
//            catch (Exception ex)
//            {
//                if (res == null)
//                    res.Close();
//                return ex.ToString();
//            }

//            Stream ou = res.GetResponseStream();
//            StreamReader objReader = null;
//            try
//            {
//                objReader = new StreamReader(ou, System.Text.Encoding.GetEncoding("utf-8"));
//            }
//            catch (Exception)
//            {

//            }

//            string strHtml = "", strLine = "";
//            strHtml = objReader.ReadToEnd();

//            ou.Close();
//            return strHtml;

//            return "";
//        }




//        public string GetString(string UserName, string passWord, string dicname, string itemid)
//        {

//            return "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.webservice.wondersgroup.com/\">"
//                   + "<soapenv:Header>"
//                   + "<soap:Head soap:actor=\"http://schemas.xmlsoap.org/soap/actor/next\" soap:mustUnderstand=\"0\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">"
//                   + "<soap:username>" + UserName + "</soap:username>"
//                   + "<soap:password>" + passWord + "</soap:password>"
//                   + "</soap:Head>"
//                   + "</soapenv:Header>"
//                   + "<soapenv:Body>"

//                + "<ws:getDic soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">"
//                + "<xml xsi:type=\"xsd: string\" xs:type=\"type:string\" xmlns:xs=\"http://www.w3.org/2000/XMLSchema-instance\">"
//                + "<![CDATA["
//                   + "<input>"
//                   + "<dicname>" + dicname + "</dicname>"
//                   + "<itemid>" + itemid + "</itemid>"
//                   + "</input>"
//                + " ]]></xml>"
//                + "</ws:getDic>"
//                   + "</soapenv:Body>"
//                   + "</soapenv:Envelope>";

//        }




//    }
//}


