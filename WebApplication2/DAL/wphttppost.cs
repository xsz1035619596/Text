using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;



namespace WebApplication2.DAL
{
    public class wphttppost
    {


        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }


        /// <summary>
        /// 得到需要传递的参数格式
        /// </summary>
        /// <param name="sParaTemp">参数键值</param>
        /// <returns></returns>
        public static string datapost(SortedDictionary<string, string> sParaTemp)
        {
            Encoding myEncoding = Encoding.GetEncoding("gb2312");
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in sParaTemp)
            {
                prestr.Append(temp.Key + "=" + HttpUtility.UrlEncode(temp.Value, myEncoding) + "&");
            }


            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);


            return prestr.ToString();
        }


        /// <summary>
        /// post方式提交
        /// </summary>
        /// <param name="postdata">传递的参数先调用datapost()方法</param>
        /// <param name="url">访问的地址</param>
        /// <param name="timeout">超时时间 6</param>
        /// <returns></returns>
        public static string Post(string postdata, string url, int timeout)
        {
            LogHelper Dvmt = new LogHelper();
            //Dvmt.NetFramework.Helper.LogHelper.LogSave(string.Format("postdata: {0} url: {1} timeout:{2}", postdata, url, timeout));
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接


            string result = "";//返回结果


            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;


            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }


                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);


                request.Method = "POST";
                request.Timeout = timeout * 1000;


                //这个在Post的时候，一定要加上，如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
                request.ServicePoint.Expect100Continue = false;


                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                //proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                //request.Proxy = proxy;


                //设置POST的数据类型和长度
                request.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = data.Length;


                ////是否使用证书
                //if (isUseCert)
                //{
                //    string path = HttpContext.Current.Request.PhysicalApplicationPath;
                //    X509Certificate2 cert = new X509Certificate2(path + WxPayConfig.SSLCERT_PATH, WxPayConfig.SSLCERT_PASSWORD);
                //    request.ClientCertificates.Add(cert);
                //    //Log.Debug("WxPayApi", "PostXml used cert");
                //}


                //往服务器写入数据
                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();


                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();


                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
                //Dvmt.NetFramework.Helper.LogHelper.LogSave(string.Format("Exception message: {0}", e.Message));
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                //Log.Error("HttpService", e.ToString());
                //if (e.Status == WebExceptionStatus.ProtocolError)
                //{
                //Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                //Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                //}
                //throw new WxPayException(e.ToString());
               // Dvmt.NetFramework.Helper.LogHelper.LogSave(string.Format("WebException message: {0}", e.Message));
            }
            catch (Exception e)
            {
               // Dvmt.NetFramework.Helper.LogHelper.LogSave(string.Format("Exception message: {0}", e.Message));
                //Log.Error("HttpService", e.ToString());
                //throw new WxPayException(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }


        /// <summary>
        /// 处理http GET请求，返回数据
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <returns>http GET成功后返回的数据，失败抛WebException异常</returns>
        public static string Get(string url)
        {
            System.GC.Collect();
            string result = "";


            HttpWebRequest request = null;
            HttpWebResponse response = null;


            //请求url以获取数据
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }


                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);


                request.Method = "GET";


                //设置代理
                //WebProxy proxy = new WebProxy();
                //proxy.Address = new Uri(WxPayConfig.PROXY_URL);
                //request.Proxy = proxy;


                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();


                //获取HTTP返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
                //Log.Error("Exception message: {0}", e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                //Log.Error("HttpService", e.ToString());
                //if (e.Status == WebExceptionStatus.ProtocolError)
                //{
                //    Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                //    Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                //}
                //throw new WxPayException(e.ToString());
            }
            catch (Exception e)
            {
                //Log.Error("HttpService", e.ToString());
                //throw new WxPayException(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }
    }
}



