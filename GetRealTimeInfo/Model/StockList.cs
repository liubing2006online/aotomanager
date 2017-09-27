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
        public decimal BuyVariableAmount { get; set; }
        /// <summary>
        /// 买入策略
        /// </summary>
        public string BuyStrategy { get; set; }
        /// <summary>
        /// 买入标记价格
        /// </summary>
        public decimal BuyMarkPrice { get; set; }

        public decimal SalePrice { get; set; }
        /// <summary>
        /// 卖出数量
        /// </summary>
        public int SaleAmount { get; set; }
        /// <summary>
        /// 卖出变化趋势
        /// </summary>
        public int SaleVariableTrend { get; set; }

        /// <summary>
        /// 卖出变化数量
        /// </summary>
        public decimal SaleVariableAmount { get; set; }
        /// <summary>
        /// 卖出策略
        /// </summary>
        public string SaleStrategy { get; set; }
        /// <summary>
        /// 卖出标记价格
        /// </summary>
        public decimal SaleMarkPrice { get; set; }

        public string Monitor { get; set; }
    }
}
