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
using System.Threading;
using Qiniu.Storage;
using Qiniu.Http;
using Qiniu.Storage.Model;
using System.Configuration;
namespace AotoTrade
{
    public partial class Main : Form
    {
        Mac mac;
        public static bool SaveFileFlag = false;
        public static bool DelFileFlag = false;
        StockConfigModel model;
        Thread thread = null;
        private delegate void FlushClient(); //代理
        public Main()
        {
            InitializeComponent();
            mac = new Mac(System.Configuration.ConfigurationManager.AppSettings["AK"],System.Configuration.ConfigurationManager.AppSettings["SK"]);
            Control.CheckForIllegalCrossThreadCalls = false;
            model = Download(Utils.FileNameAoto);
            BindData(model);

            #region 交易线程
            //Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        model = CanDownload(Utils.FileNameAoto, mac);
            //        BindData(model);
            //        if (model.Monitoring)
            //        {
            //            Thread.Sleep(1000);
            //            if(model.LimitTime)
            //            { 
            //                if(DateTime.Parse(DateTime.Now.ToLongTimeString()) >= DateTime.Parse(model.BuyBeginTime.ToLongTimeString()) && DateTime.Parse(DateTime.Now.ToLongTimeString()) <DateTime.Parse( model.BuyEndTime.ToLongTimeString()) )
            //                    Monitoring(model);
            //            }
            //            else
            //                Monitoring(model);
            //        }
            //        Thread.Sleep(5600);
            //    }
            //});
            thread = new Thread(CrossThreadFlush);
            thread.IsBackground = true;
            thread.Start();
            #endregion

        }

        private void CrossThreadFlush()
        {
            while (true)
            {
                //将sleep和无限循环放在等待异步的外面
                ThreadFunction();
                Thread.Sleep(5600);
            }
        }

        private void ThreadFunction()
        {
            if (this.dataGrid.InvokeRequired)//等待异步
            {
                FlushClient fc = new FlushClient(ThreadFunction);
                this.Invoke(fc); //通过代理调用刷新方法
            }
            else
            {
                model = CanDownload(Utils.FileNameAoto, mac);
                BindData(model);
                if (model.Monitoring)
                {
                    Thread.Sleep(1000);
                    if (model.LimitTime)
                    {
                        if (DateTime.Parse(DateTime.Now.ToLongTimeString()) >= DateTime.Parse(model.BuyBeginTime.ToLongTimeString()) && DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(model.BuyEndTime.ToLongTimeString()))
                            Monitoring(model);
                    }
                    else
                        Monitoring(model);
                }
            }
        }


        private void Monitoring(StockConfigModel model)
        {
            foreach (StockList stock in model.StockList)
            {
                if(stock.Monitor == "监控中")
                   reachBuyCondition(model,stock);
            }
           
        }

        private void reachBuyCondition(StockConfigModel model,StockList stock)
        {
            decimal currentPrice = GetInfo.Get(stock.StockCode).CurrentPrice;
            if (currentPrice <= stock.BuyPrice&&currentPrice!=0&&stock.BuyAmount!=0)
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                Boolean flagTrade = false;
                if(cbxSoft.SelectedIndex==0)
                   flagTrade  =  ZhaoShangZhiYuanTrade(stock);
                else
                    flagTrade = JQKA(stock);
                sw.Stop();
               

                //Task.Factory.StartNew(()=>{
                if(flagTrade)
                { 
                   string ename = System.Configuration.ConfigurationManager.AppSettings["ename"];
                   string epwd = System.Configuration.ConfigurationManager.AppSettings["epwd"];
                   string server = System.Configuration.ConfigurationManager.AppSettings["server"];
                   int port =Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["port"]);
                   string add = System.Configuration.ConfigurationManager.AppSettings["add"];
                   string subject = string.Format("成功以{0}元买入{1}({2}){3}股", stock.CurrentPrice, stock.StockName, stock.StockCode, stock.BuyAmount);
                   string body = string.Format("用时{0}秒", sw.Elapsed.TotalSeconds);

                   Simplify.Mail.MailSenderSettings settings = new Simplify.Mail.MailSenderSettings(server, port, ename, epwd);
                   Simplify.Mail.MailSender msender = new Simplify.Mail.MailSender(settings);
                   msender.Send(new System.Net.Mail.MailMessage(add, add, subject, body));

                //});
                    stock.BuyAmount = 0;
                    stock.Monitor = "已停止";

                    UploadFile(model);
                }
            }
        }

        private Boolean SaveAsDefaultFile(string filename, StockConfigModel model)
        {
            //if (GetTrueCondition())
            //{
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

                File.WriteAllText(filename, json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            //}
        }


        /// <summary>
        /// 上传完成后回调
        /// </summary>
        /// <param name="key"></param>
        /// <param name="respInfo"></param>
        /// <param name="respJson"></param>
        private void OnUploadCompleted(string key, ResponseInfo respInfo, string respJson)
        {
            // respInfo.StatusCode
            // respJson是返回的json消息，示例: { "key":"FILE","hash":"HASH","fsize":FILE_SIZE }
            if (respInfo.StatusCode == 200)
                lblMessage.Text = "上传成功！";
            else
                lblMessage.Text = "上传失败";
        }
        private Boolean DelFile(string filename)
        {
            BucketManager bm = new BucketManager(mac);
            string marker = ""; // 首次请求时marker必须为空
            string prefix = null; // 按文件名前缀保留搜索结果
            string delimiter = null; // 目录分割字符(比如"/")
            int limit = 100; // 最大值1000
                             // 返回结果存储在items中
            List<FileDesc> items = new List<FileDesc>();
            // 由于limit限制，可能需要执行多次操作
            // 返回值中Marker字段若非空，则表示文件数超过了limit

            ListFilesResult list = bm.listFiles(Utils.bucket, filename, marker, limit, delimiter);
            List<FileDesc> fileList = list.Items;
            foreach (FileDesc f in fileList)
            {
                var result = bm.delete(Utils.bucket, f.Key);
                if (result.ResponseInfo.StatusCode == 200)
                    return true;
                else
                    return false;
            }
            return true;
        }

        private void UploadFile(StockConfigModel model)
        {
            try
            {
                SaveFileFlag = SaveAsDefaultFile(Utils.FileNameAoto, model);
                // 本地文件
                string localFile = Utils.FileNameAoto;
                // 上传策略
                PutPolicy putPolicy = new PutPolicy();
                // 设置要上传的目标空间
                putPolicy.Scope = Utils.bucket;
                // 上传策略的过期时间(单位:秒)
                putPolicy.SetExpires(3600);
                // 文件上传完毕后，在多少天后自动被删除
                putPolicy.DeleteAfterDays = 1;
                // 请注意这里的Zone设置(如果不设置，就默认为华东机房)
                var zoneId = Qiniu.Common.AutoZone.Query(Common.AK, Utils.bucket);
                Qiniu.Common.Config.ConfigZone(zoneId);
                //Mac mac = new Mac(AK, SK); // Use AK & SK here
                // 生成上传凭证
                string uploadToken = Auth.createUploadToken(putPolicy, mac);
                UploadOptions uploadOptions = null;

                // 上传完毕事件处理
                UpCompletionHandler uploadCompleted = new UpCompletionHandler(OnUploadCompleted);
                // 方式1：使用UploadManager
                //默认设置 Qiniu.Common.Config.PUT_THRESHOLD = 512*1024;
                //可以适当修改,UploadManager会根据这个阈值自动选择是否使用分片(Resumable)上传    
                UploadManager um = new UploadManager();

                DelFileFlag = DelFile(Utils.FileNameAoto);

                um.uploadFile(localFile, Utils.FileNameAoto, uploadToken, uploadOptions, uploadCompleted);
                // 方式2：使用FormManager
                //FormUploader fm = new FormUploader();
                //fm.uploadFile(localFile, saveKey, token, uploadOptions, uploadCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误" + ex.Message, "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private StockConfigModel GetModelFromDataContainer()
        {
            StockConfigModel model = new StockConfigModel();
            model.AvailableBalance = Convert.ToInt32(txtBalance.Text);
            model.LimitTime = chkLimitTime.Checked;
            model.BuyBeginTime = dtBeginTime.Value;
            model.BuyEndTime = dtEndTime.Value;
            model.Monitoring = lblMonitor.Text == "正在监控..." ? true : false;
            List<StockList> list = new List<StockList>();
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                DataGridViewCellCollection cells = dataGrid.Rows[i].Cells;
                if (cells["StockCode"].Value != null && cells["StockName"].Value != null)
                {
                    if (cells["StockCode"].Value.ToString() != "" && cells["StockName"].Value.ToString() != "")
                        list.Add(new StockList { StockCode = cells["StockCode"].Value.ToString(), StockName = cells["StockName"].Value.ToString(), BuyPrice = Convert.ToDecimal(cells["BuyPrice"].Value), BuyAmount = Convert.ToInt32(cells["BuyAmount"].Value), Monitor = cells["Monitor"].Value.ToString() });
                }
            }
            model.StockList = list;
            return model;
        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            BindData(Download(Utils.FileNameAoto));
        }

        private StockConfigModel CanDownload(string FileNameAoto, Mac mac)
        {

            return Utils.CanGetFile(mac) ? Download(FileNameAoto) : model;

        }

        private StockConfigModel Download(string FileNameAoto)
        {
           
            string filepath =Utils.DownloadFile(FileNameAoto);
            if (filepath != "")
            {
                string json = File.ReadAllText(filepath);

                StockConfigModel configModel = Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(StockConfigModel)) as StockConfigModel;

                lblMessage.Text = "下载文件转换成功," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                lblMessage.ForeColor = Color.OrangeRed;
                System.Threading.Thread.Sleep(1000);
                lblMessage.ForeColor = System.Drawing.SystemColors.HotTrack;

                return configModel;
               
            }
            else
            {
                return null;
            }
        }

        private void BindData(StockConfigModel configModel)
        {
            if (configModel != null)
            {
                int Cnt = 0;
                foreach (StockList ll in configModel.StockList)
                {
                    ll.CurrentPrice = GetInfo.Get(ll.StockCode).CurrentPrice;
                    if (ll.Monitor == "监控中")
                        Cnt++;
                }

                dataGrid.DataSource = configModel.StockList;
                txtBalance.Text = configModel.AvailableBalance.ToString();
                chkLimitTime.Checked = configModel.LimitTime;
                dtBeginTime.Value = configModel.BuyBeginTime;
                dtEndTime.Value = configModel.BuyEndTime;
                lblMonitor.Visible = true;
                lblMonitor.Text = Cnt > 0 ? "正在监控..." : "监控已停止...";
                cbxSoft.SelectedIndex = configModel.TradeSoftWare;
            }
        }



        private Boolean ZhaoShangZhiYuanTrade(StockList stock)
        {
            IntPtr myIntPtr = Utils.FindWindow("TdxW_MainFrame_Class", null);
            Boolean flagFore = Utils.SetForegroundWindow(myIntPtr);
            if (flagFore)
            {
                Boolean flagShowMax = Utils.ShowWindow(myIntPtr, 3);
                if (flagShowMax)
                {
                    System.Threading.Thread.Sleep(500);
                    Utils.SetCursorPos(43, 62);
                    System.Threading.Thread.Sleep(100);
                    Utils.mouse_event(Utils.MouseEventFlag.LeftDown, 0, 0, 0, 0); //模拟鼠标按下操作
                    Utils.mouse_event(Utils.MouseEventFlag.LeftUp, 0, 0, 0, 0); //模拟鼠标放开操作
                    Thread.Sleep(200);
                    SendKeys.SendWait(stock.StockCode);
                    Thread.Sleep(300);
                    SendKeys.SendWait(stock.CurrentPrice.ToString());
                    Thread.Sleep(200);
                    SendKeys.SendWait("{TAB}");
                    Thread.Sleep(200);
                    SendKeys.SendWait(stock.BuyAmount.ToString());
                    Thread.Sleep(200);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(200);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(500);
                    SendKeys.SendWait("{ENTER}");
                }
            }
            return flagFore;
        }


        private Boolean JQKA(StockList stock)
        {
            IntPtr myIntPtr = Utils.FindWindow(null, "网上股票交易系统5.0");
            Boolean flagFore = Utils.SetForegroundWindow(myIntPtr);
            if (flagFore)
            {
                Boolean flagShowMax = Utils.ShowWindow(myIntPtr, 3);
                if (flagShowMax)
                {
                    //Thread.Sleep(300);
                    SendKeys.SendWait("{F1}");
                    Thread.Sleep(200);
                    SendKeys.SendWait(stock.StockCode);
                    Thread.Sleep(300);
                    SendKeys.SendWait("{TAB}");
                    Thread.Sleep(200);
                    SendKeys.SendWait(stock.CurrentPrice.ToString());
                    Thread.Sleep(200);
                    SendKeys.SendWait("{TAB}");
                    Thread.Sleep(200);
                    SendKeys.SendWait(stock.BuyAmount.ToString());
                    Thread.Sleep(200);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(200);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(200);
                    SendKeys.SendWait("{ENTER}");
                }
            }
            return flagFore;
        }

    }
}
