using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo.Model
{
    public enum BuyVariableTrendEnum : int
    {
        /// <summary>
        /// 达到或上破
        /// </summary>
        [Description("达到或上破")]
        ReachOrUp = 1,
        /// <summary>
        /// 达到或下破
        /// </summary>
        [Description("达到或下破")]
        ReachOrDown = 2,
        /// <summary>
        /// 下破后反弹
        /// </summary>
        [Description("下破后反弹")]
        DownThenRebound = 3,
        /// <summary>
        /// 下破后上破
        /// </summary>
        [Description("下破后上破")]
        DownThenUp = 4
    }
}
