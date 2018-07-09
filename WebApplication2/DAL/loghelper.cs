using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System;

namespace WebApplication2.DAL
{
    /// <summary>
    /// 日志文件存放文件夹分类枚举
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 普通信息
        /// </summary>
        Info,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 其他全部信息
        /// </summary>
        Overall,
    }
    public class LogHelper
    {
        /// <summary>
        /// 日志存放路径
        /// </summary>
        public static string LogPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"\log";
            }
        }

        /// <summary>
        /// 信息类型
        /// </summary>
        public enum LogLevel
        {
            /// <summary>
            /// 普通信息
            /// </summary>
            Info,
            /// <summary>
            /// 错误
            /// </summary>
            Error
        }

        /// <summary>
        /// 普通信息写入日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logType"></param>
        public static void Info(string message, LogType logType = LogType.Overall)
        {
            if (string.IsNullOrEmpty(message))
                return;
            var path = string.Format(@"\{0}\", logType.ToString());
            WriteLog(path, "", message);
        }
        /// <summary>
        /// 自定义错误信息写入
        /// </summary>
        /// <param name="message">自定义消息</param>
        /// <param name="logType">存储目录类型</param>
        public static void Error(string message, LogType logType = LogType.Overall)
        {
            if (string.IsNullOrEmpty(message))
                return;
            var path = string.Format(@"\{0}\", logType.ToString());
            WriteLog(path, "Error ", message);
        }
        /// <summary>
        /// 程序异常信息写入
        /// </summary>
        /// <param name="e">异常</param>
        /// <param name="logType">存储目录类型</param>
        public static void Error(Exception e, LogType logType = LogType.Overall)
        {
            if (e == null)
                return;
            var path = string.Format(@"\{0}\", logType.ToString());
            WriteLog(path, "Error ", e.Message);
        }
        /// <summary>
        /// 写日志的最终执行动作
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="prefix">前缀</param>
        /// <param name="message">内容</param>
        public static void WriteLog(string path, string prefix, string message)
        {
            path = LogPath + path;
            var fileName = string.Format("{0}{1}.log", prefix, DateTime.Now.ToString("yyyyMMdd"));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (FileStream fs = new FileStream(path + fileName, FileMode.Append, FileAccess.Write,
                                                  FileShare.Write, 1024, FileOptions.Asynchronous))
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToString("HH:mm:ss") + " " + message + "\r\n");
                IAsyncResult writeResult = fs.BeginWrite(buffer, 0, buffer.Length,
                    (asyncResult) =>
                    {
                        var fStream = (FileStream)asyncResult.AsyncState;
                        fStream.EndWrite(asyncResult);
                    },

                    fs);
                fs.Close();
            }
        }
    }
}




