﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo.Model
{
    public class StockConfigModel
    {
        /// <summary>
        /// 可用余额（整数）
        /// </summary>
        public int AvailableBalance;
        /// <summary>
        /// 是否限定买入时间
        /// </summary>
        public Boolean LimitBuyTime { get; set; }
        /// <summary>
        /// 是否限定卖出时间
        /// </summary>
        public Boolean LimitSaleTime { get; set; }
        /// <summary>
        /// 买入开始时间
        /// </summary>
        public DateTime BuyBeginTime { get; set; }
        /// <summary>
        /// 买入结束时间
        /// </summary>
        public DateTime BuyEndTime { get; set; }

        /// <summary>
        /// 卖出开始时间
        /// </summary>
        public DateTime SaleBeginTime { get; set; }
        /// <summary>
        /// 卖出结束时间
        /// </summary>
        public DateTime SaleEndTime { get; set; }

        public string Mobile { get; set; }

        public DateTime CloseComputerTime { get; set; }

        public Boolean Monitoring { get; set; }

        public int TradeSoftWare { get; set; }
        /// <summary>
        /// 使用跳空低开策略
        /// </summary>
        public Boolean UseGapLowerTactics { get; set; }
        public List<StockList> StockList { get; set; }

    }
}
