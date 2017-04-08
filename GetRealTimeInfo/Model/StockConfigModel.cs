using System;
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
        /// 是否限定时间
        /// </summary>
        public Boolean LimitTime { get; set; }
        /// <summary>
        /// 买入开始时间
        /// </summary>
        public DateTime BuyBeginTime { get; set; }
        /// <summary>
        /// 买入结束时间
        /// </summary>
        public DateTime BuyEndTime { get; set; }

        public string Mobile { get; set; }

        public DateTime CloseComputerTime { get; set; }

        public Boolean Monitoring { get; set; }

        public int TradeSoftWare { get; set; }

        public List<StockList> StockList { get; set; }

    }
}
