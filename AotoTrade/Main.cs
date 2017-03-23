using GetRealTimeInfo;
using GetRealTimeInfo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qiniu.Util;
namespace AotoTrade
{
    public partial class Main : Form
    {
        Mac mac;
        public Main()
        {
            InitializeComponent();
            mac = new Mac(Common.AK, Common.SK);
            Download(Utils.FileNameAoto);
           
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                CanDownload(Utils.FileNameAoto, mac);
                System.Threading.Thread.Sleep(5600);
                }
            });
            
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            CanDownload(Utils.FileNameAoto,mac);
        }

        private void CanDownload(string FileNameAoto, Mac mac)
        {
            if (Utils.CanGetFile(mac))
            {
                Download(FileNameAoto);
            }
        }

        private void Download(string FileNameAoto)
        {
           
            string filepath =Utils.DownloadFile(FileNameAoto);
            if (filepath != "")
            {
                string json = File.ReadAllText(filepath);

                StockConfigModel configModel = Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(StockConfigModel)) as StockConfigModel;

                BindData(configModel);

                if(configModel!=null)
                {
                    lblMessage.Text = "下载文件转换成功,"+DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    lblMessage.ForeColor = Color.OrangeRed;
                    System.Threading.Thread.Sleep(1000);
                    lblMessage.ForeColor = System.Drawing.SystemColors.HotTrack;
                }
                else
                { 
                    lblMessage.Text = "下载文件转换失败";
                    lblMessage.ForeColor = Color.OrangeRed;
                }
            }
            else
            {
                lblMessage.Text = "下载文件出现错误";
            }
        }

        private void BindData(StockConfigModel configModel)
        {
            foreach (StockList ll in configModel.StockList)
                ll.CurrentPrice = GetInfo.Get(ll.StockCode).CurrentPrice;

            dataGrid.DataSource = configModel.StockList;
            txtBalance.Text = configModel.AvailableBalance.ToString();
            chkLimitTime.Checked = configModel.LimitTime;
            dtBeginTime.Value = configModel.BuyBeginTime;
            dtEndTime.Value = configModel.BuyEndTime;
        }

    }
}
