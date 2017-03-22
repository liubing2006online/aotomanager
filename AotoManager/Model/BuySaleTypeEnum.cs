using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AotoManager.Model
{
    public class BuySaleTypeEnum
    {
        /// <summary>
        /// 达到或上破
        /// </summary>
        public int ReachOrUp = 1;
        /// <summary>
        /// 达到或下破
        /// </summary>
        public int ReachOrDown = 2;

        /// <summary>
        /// 下破后反弹
        /// </summary>
        public int DownThenRebound = 3;

        /// <summary>
        /// 下破后上破
        /// </summary>
        public int DownThenUp = 4;
    }
}
