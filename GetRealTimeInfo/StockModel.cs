using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo
{
    public class StockModel
    {
        public string Name { get; set; }
        public decimal TodayBeginPrice { get; set; }
        public decimal YesterdayEndPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal TodayHighestPrice { get; set; }

        public decimal TodayLowestPrice { get; set; }
    }
}
