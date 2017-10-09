using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo.Model
{
    public enum TradeTypeEnum : int
    {
        /// <summary>
        /// 买
        /// </summary>
        [Description("买")]
        Buy = 1,
        /// <summary>
        /// 卖
        /// </summary>
        [Description("卖")]
        Sale = 2
    }
}
