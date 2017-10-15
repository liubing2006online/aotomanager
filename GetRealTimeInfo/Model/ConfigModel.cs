﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo.Model
{
    public class ConfigModel
    {
        /// <summary>
        /// 邮箱用户名
        /// </summary>
        public string ename;
        /// <summary>
        /// 邮箱密码
        /// </summary>
        public string epwd { get; set; }
        /// <summary>
        /// 发送邮件服务器
        /// </summary>
        public string server { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public string port { get; set; }
        /// <summary>
        /// 接收者地址
        /// </summary>
        public string add { get; set; }

        public string AK { get; set; }

        public string SK { get; set; }
    }
}