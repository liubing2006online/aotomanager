using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Qiniu.Util;
namespace AotoManager
{
    public static class Util
    {
        ///// <summary>
        ///// Http下载文件
        ///// </summary>
        //public static string HttpDownloadFile(string url, string path)
        //{
        //    try
        //    {
        //        // 设置参数
        //        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        //        //发送请求并获取相应回应数据
        //        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //        //直到request.GetResponse()程序才开始向目标网页发送Post请求
        //        Stream responseStream = response.GetResponseStream();
        //        //创建本地文件写入流
        //        Stream stream = new FileStream(path, FileMode.Create);
        //        byte[] bArr = new byte[1024];
        //        int size = responseStream.Read(bArr, 0, (int)bArr.Length);
        //        while (size > 0)
        //        {
        //            stream.Write(bArr, 0, size);
        //            size = responseStream.Read(bArr, 0, (int)bArr.Length);
        //        }
        //        stream.Close();
        //        responseStream.Close();
        //        return path;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}


        /// <summary>
        /// 通过 WebRequest/WebResponse 类访问远程地址
        /// 调用端自己处理异常
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="timeout">访问超时时间，单位毫秒；如果不设置超时时间，传入0</param>
        /// <param name="encoding">如果不知道具体的编码，传入null</param>
        /// <returns></returns>
        public static string Request_WebRequest(string uri, int timeout, Encoding encoding)
        {
            string result = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(new Uri(uri));
                //if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                //{
                //    request.Credentials = GetCredentialCache(uri, username, password);
                //    request.Headers.Add("Authorization", GetAuthorization(username, password));
                //}
                if (timeout > 0)
                    request.Timeout = timeout;
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader sr = encoding == null ? new StreamReader(stream) : new StreamReader(stream, encoding);
                result = sr.ReadToEnd();
                sr.Close();
                stream.Close();
                return result;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 通过 WebRequest/WebResponse 类访问远程地址并返回结果，加入认证
        /// 调用端自己处理异常
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="timeout">访问超时时间，单位毫秒；如果不设置超时时间，传入0</param>
        /// <param name="encoding">如果不知道具体的编码，传入null</param>
        /// <param name="MAC">认证信息</param>
        /// <returns></returns>
        public static string Request_WebRequest(string uri, int timeout, Encoding encoding, Mac mac)
        {
            string result = string.Empty;

            WebRequest request = WebRequest.Create(new Uri(uri));

            //if (!string.IsNullOrEmpty(storeName) && !string.IsNullOrEmpty(fileName))
            //{
                //request.Credentials = GetCredentialCache(uri, storeName, fileName);
                request.Headers.Add("Authorization", GetToken(uri,mac));
            //}

            if (timeout > 0)
                request.Timeout = timeout;

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = encoding == null ? new StreamReader(stream) : new StreamReader(stream, encoding);

            result = sr.ReadToEnd();

            sr.Close();
            stream.Close();

            return result;
        }

        #region # 生成 Http Basic 访问凭证 #

        private static CredentialCache GetCredentialCache(string uri, string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            CredentialCache credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "QBox", new NetworkCredential(username, password));

            return credCache;
        }

        private static string GetAuthorization(string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            return "QBox " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
        }

        public static string GetBase64(string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            return Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
        }

        public static string GetToken(string url,Mac mac)
        {
           return Auth.createManageToken(url, null, mac);
        }

        /// <summary>
        /// unix时间戳转换成日期
        /// </summary>
        /// <param name="unixTimeStamp">时间戳（秒）</param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(this DateTime target, long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            return start.AddSeconds(timestamp);
        }

        #endregion
    }
}
