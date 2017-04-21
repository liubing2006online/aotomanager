using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo
{
    public class GetInfo
    {

        public const string url = "http://hq.sinajs.cn/list=";
        
        public static StockModel Get(string code="300115")
        {
            try
            {
                string realCode = "";
                if (code.IndexOf('6') == 0)
                    realCode = string.Format("sh{0}", code);
                else
                    realCode = string.Format("sz{0}", code);
                string htmlinfo = Utils.Request_WebRequest(string.Format("{0}{1}", url, realCode), 0, Encoding.Default);
                if (!string.IsNullOrEmpty(htmlinfo))
                {
                    string datainfo = htmlinfo.Substring(htmlinfo.IndexOf('"') + 1, htmlinfo.Length - 2 - htmlinfo.IndexOf('"'));
                    string[] strinfo = datainfo.Split(',');
                    StockModel model = new StockModel();
                    model.Name = strinfo[0];
                    model.TodayBeginPrice = decimal.Parse(strinfo[1].Substring(0, strinfo[1].Length-1));
                    model.YesterdayEndPrice = decimal.Parse(strinfo[2].Substring(0,strinfo[2].Length - 1));
                    model.CurrentPrice = decimal.Parse(strinfo[3].Substring(0,strinfo[3].Length - 1));
                    model.TodayHighestPrice = decimal.Parse(strinfo[4].Substring(0, strinfo[4].Length - 1));
                    model.TodayLowestPrice = decimal.Parse(strinfo[5].Substring(0, strinfo[5].Length - 1));
                    return model;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
