using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo
{
     public static class Utils
    {

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
    }
}
