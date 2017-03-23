using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GetRealTimeInfo.Model;
using Qiniu.Util;

namespace GetRealTimeInfo
{
     public static class Utils
    {
        public static string bucket = "aoto";
        public static string FileNameAoto = "aoto.txt";
        public static string Uri = "http://rs.qiniu.com/stat/";
        public static string Path = "http://omy714q6d.bkt.clouddn.com/aoto.txt";
        public static Boolean CanGetFile(Mac mac)
        {
            if (!File.Exists(FileNameAoto))
                return true;
            else
            {
                DateTime filemodifiedTime = File.GetLastWriteTime(FileNameAoto);
                FileInfoModel remoteModel = Utils.GetRemoteFileUploadTime(bucket, FileNameAoto, Uri, mac);
                if (Utils.ConvertLongDateTime(remoteModel.putTime) > filemodifiedTime)
                    return true;
                else
                    return false;
            }
        }


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


        public static DateTime ConvertLongDateTime(long d)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            //long lTime = long.Parse(d + "0000");
            TimeSpan toNow = new TimeSpan(d);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
        }

        public static Model.FileInfoModel GetRemoteFileUploadTime(string bucket, string FileNameAoto, string Uri, Mac mac)
        {
            string base64 = GetBase64(bucket, FileNameAoto);
            string info = Request_WebRequest(string.Format("{0}{1}", Uri, base64), 0, null, mac);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Model.FileInfoModel>(info);
        }


        public static string GetBase64(string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            return Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
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
            request.Headers.Add("Authorization", GetToken(uri, mac));
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


        public static string GetToken(string url, Mac mac)
        {
            return Auth.createManageToken(url, null, mac);
        }
    }
}
