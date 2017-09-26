using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo.Model
{
    public class StockList
    {
        public string StockCode { get; set; }

        public string StockName { get; set; }
        public decimal CurrentPrice { get; set; }
        //public decimal SalePrice { get; set; }
        /// <summary>
        /// 卖出数量
        /// </summary>
        //public int SaleAmount { get; set; }
        /// <summary>
        /// 卖出策略（实际只存在一种，故省略）
        /// </summary>
        //public int SaleType { get; set; }

        public decimal BuyPrice { get; set; }
        /// <summary>
        /// 买入数量
        /// </summary>
        public int BuyAmount { get; set; }
        /// <summary>
        /// 买入变化趋势
        /// </summary>
        public int BuyVariableTrend { get; set; }

        /// <summary>
        /// 买入变化数量
        /// </summary>
        public int BuyVariableAmount { get; set; }
        /// <summary>
        /// 买入策略
        /// </summary>
        public string BuyStrategy { get; set; }
        public string Monitor { get; set; }
    }
}
