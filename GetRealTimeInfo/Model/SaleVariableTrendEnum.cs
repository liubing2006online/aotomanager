using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo.Model
{
    public enum SaleVariableTrendEnum : int
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
        /// 上破后回落
        /// </summary>
        [Description("上破后回落")]
        UpThenFallBack = 3,
        /// <summary>
        /// 上破后下破
        /// </summary>
        [Description("上破后下破")]
        UpThenDown = 4
    }
}
