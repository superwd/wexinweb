using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WeixinWebformDemo.Include.Log
{
    public static class MyLog
    {
        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="strMsg">日志信息</param>
        public static void WriteRunLog(string strMsg)
        {
            if (strMsg != "")
            {
                StreamWriter sw = null;
                try
                {
                    string strDir = GetMapPath(GetMapPath("") + "\\Logs\\RunLog\\");
                    if (!Directory.Exists(strDir))  //目录是空,先建立目录
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    string strFileName = strDir + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";  //文件路径
                    sw = new StreamWriter(strFileName, true, System.Text.Encoding.Default);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + strMsg);
                }
                catch
                {

                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                        sw = null;
                    }
                }
            }
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="strMsg">日志信息</param>
        public static void WriteErrorLog(string strMsg)
        {
            if (strMsg != "")
            {
                StreamWriter sw = null;
                try
                {
                    string strDir = GetMapPath(GetMapPath("") + "\\Logs\\ErrorLog\\");
                    if (!Directory.Exists(strDir))  //目录是空,先建立目录
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    string strFileName = strDir + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";  //文件路径
                    sw = new StreamWriter(strFileName, true, System.Text.Encoding.Default);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + strMsg);
                }
                catch
                {

                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                        sw = null;
                    }
                }
            }
        }

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (strPath.StartsWith("~/"))
                strPath = strPath.Substring(2);
            else if (strPath.StartsWith("/"))
                strPath = strPath.Substring(1);
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }
    }
}