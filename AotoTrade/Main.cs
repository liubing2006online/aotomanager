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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net.Mail;
using DotNetSpeech;
namespace AotoTrade
{
    public partial class Main : Form
    {
        string AK;
        string SK;
        //string RefreshTime;
        ConfigModel config;
        Mac mac;
        public static bool SaveFileFlag = false;
        public static bool DelFileFlag = false;
        StockConfigModel model;
        Thread thread = null;
        private delegate void FlushClient(); //代理

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        // 导入的方法必须是static extern的，并且没有方法体。调用这些方法就相当于调用Windows API。   
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
        ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool ExitWindowsEx(int flg, int rea);

        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        internal const int EWX_SHUTDOWN = 0x00000001;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        DotNetSpeech.SpeechVoiceSpeakFlags SSF = DotNetSpeech.SpeechVoiceSpeakFlags.SVSFlagsAsync;
        DotNetSpeech.SpVoice voice = new SpVoiceClass();

        public Main()
        {
            InitializeComponent();
            LoadConfig();
            mac = new Mac(AK, SK);
            //Control.CheckForIllegalCrossThreadCalls = false;
            model = Download(Utils.FileNameAoto);
            BindData(model);

            #region 交易线程
            thread = new Thread(CrossThreadFlush);
            thread.IsBackground = true;
            thread.Start();
            #endregion

        }

        public void LoadConfig()
        {
            config = Utils.GetConfig();
            if (config != null)
            {
                AK = config.AK;
                SK = config.SK;
                Utils.bucket = config.Bucket;
                Utils.FileNameAoto = config.FileName;
                Utils.Path = string.Format("{0}/{1}", config.Path, config.FileName);
            }
            else
            {
                MessageBox.Show("settings.txt 配置文件不存在", "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrossThreadFlush()
        {
            while (true)
            {
                //将sleep和无限循环放在等待异步的外面
                ThreadFunction();
                Thread.Sleep(string.IsNullOrEmpty(config.RefreshTime) ? 4800 : int.Parse(config.RefreshTime));
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
                try
                {
                    model = CanDownload(Utils.FileNameAoto, mac);
                    CloseComputer(model);
                    BindData(model);
                    AllMonitor(model);
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("监控出错,{0}", ex.Message);
                }
            }
        }

        /// <summary>
        /// 关闭电脑
        /// </summary>
        /// <param name="model"></param>
        private void CloseComputer(StockConfigModel model)
        {
            if (model != null && model.CloseComputerTime.Date == DateTime.Today && DateTime.Now >= model.CloseComputerTime)
            {
                lblMessage.Text = "正在关闭...";
                #region 发送邮件通知
                SendMail(lblMessage.Text, "");
                #endregion
                #region 开关关闭
                model.CloseComputerTime = DateTime.MinValue;
                UploadFile(model);
                #endregion
                Thread.Sleep(2000);
                DoExitWin(EWX_SHUTDOWN);
            }
        }

        /// <summary>
        /// 监控方法
        /// </summary>
        /// <param name="model"></param>
        private void AllMonitor(StockConfigModel model)
        {
            if (model != null && model.Monitoring)
            {
                if (model.LimitBuyTime)
                {
                    if (DateTime.Parse(DateTime.Now.ToLongTimeString()) >= DateTime.Parse(model.BuyBeginTime.ToLongTimeString()) && DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(model.BuyEndTime.ToLongTimeString()))
                        Monitoring(model, TradeTypeEnum.Buy);
                }
                else
                    Monitoring(model, TradeTypeEnum.Buy);

                if (model.LimitSaleTime)
                {
                    if (DateTime.Parse(DateTime.Now.ToLongTimeString()) >= DateTime.Parse(model.SaleBeginTime.ToLongTimeString()) && DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(model.SaleEndTime.ToLongTimeString()))
                        Monitoring(model, TradeTypeEnum.Sale);
                }
                else
                    Monitoring(model, TradeTypeEnum.Sale);
            }
        }


        private void DoExitWin(int flg)
        {
            bool ok;
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
            ok = AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ok = ExitWindowsEx(flg, 0);
        }


        private void Monitoring(StockConfigModel model, TradeTypeEnum type)
        {
            foreach (StockList stock in model.StockList)
            {
                if (stock.Monitor == "监控中")
                {
                    if (type == TradeTypeEnum.Buy)
                        reachBuyCondition(model, stock);
                    else
                        reachSaleCondition(model, stock);
                }
            }
        }

        /// <summary>
        /// 根据策略得到购买价格
        /// </summary>
        /// <param name="config"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        private decimal GetBuyPriceByTactics(StockConfigModel config, StockList stock)
        {
            if (config.UseGapLowerTactics)
            {
                StockModel model = GetInfo.Get(stock.StockCode);
                if (model.YesterdayEndPrice / model.TodayBeginPrice >= 1.01M)
                {
                    return Math.Round(stock.BuyPrice * (1 - (model.TodayBeginPrice / model.YesterdayEndPrice)), 2);
                }
            }
            return stock.BuyPrice;
        }
        /// <summary>
        /// 达到购买条件
        /// </summary>
        /// <param name="model">全量数据model</param>
        /// <param name="stock">监控中的证券model</param>
        private void reachBuyCondition(StockConfigModel model, StockList stock)
        {
            //decimal currentPrice = GetInfo.Get(stock.StockCode).CurrentPrice;//实时再获取一次
            decimal currentPrice = stock.CurrentPrice;//和绑定Grid的数据保持一致
            if (CurrentCanTrade(model, stock, TradeTypeEnum.Buy) && currentPrice != 0 && stock.BuyAmount != 0)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Boolean flagTrade = false;
                if (cbxSoft.SelectedIndex == 0)
                    flagTrade = ZhaoShangZhiYuanTrade(stock, TradeTypeEnum.Buy);
                else
                    flagTrade = JQKA(stock, TradeTypeEnum.Buy);
                sw.Stop();

                if (flagTrade)
                {
                    int buyamount = stock.BuyAmount;

                    Task.Factory.StartNew(() =>
                    {
                        SendTradeSuccessMail(buyamount, stock, sw, TradeTypeEnum.Buy);
                    });

                    voice.Speak(string.Format(config.BuySuccessVoice, stock.StockName, stock.CurrentPrice), SSF);

                    model.AvailableBalance = Convert.ToInt32(Math.Floor(model.AvailableBalance - (stock.CurrentPrice * stock.BuyAmount)));//计算剩余金额
                    stock.BuyAmount = 0;
                    stock.Monitor = "已停止";

                    UploadFile(model);
                }
            }
        }

        /// <summary>
        /// 达到卖出条件
        /// </summary>
        /// <param name="model">全量数据model</param>
        /// <param name="stock">监控中的证券model</param>
        private void reachSaleCondition(StockConfigModel model, StockList stock)
        {
            //decimal currentPrice = GetInfo.Get(stock.StockCode).CurrentPrice;//实时再获取一次
            decimal currentPrice = stock.CurrentPrice;//和绑定Grid的数据保持一致
            if (CurrentCanTrade(model, stock, TradeTypeEnum.Sale) && currentPrice != 0 && stock.SaleAmount != 0)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Boolean flagTrade = false;
                if (cbxSoft.SelectedIndex == 0)
                    flagTrade = ZhaoShangZhiYuanTrade(stock, TradeTypeEnum.Sale);
                else
                    flagTrade = JQKA(stock, TradeTypeEnum.Sale);
                sw.Stop();

                if (flagTrade)
                {
                    int saleamount = stock.SaleAmount;

                    Task.Factory.StartNew(() =>
                    {
                        SendTradeSuccessMail(saleamount, stock, sw, TradeTypeEnum.Sale);
                    });

                    voice.Speak(string.Format(config.SaleSuccessVoice, stock.StockName, stock.CurrentPrice), SSF);

                    model.AvailableBalance = Convert.ToInt32(Math.Floor(model.AvailableBalance + (stock.CurrentPrice * stock.SaleAmount)));//计算剩余金额
                    stock.SaleAmount = 0;
                    stock.Monitor = "已停止";

                    UploadFile(model);
                }
            }
        }

        /// <summary>
        /// 是否能下单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        private bool CurrentCanTrade(StockConfigModel model, StockList stock, TradeTypeEnum type)
        {
            if (type == TradeTypeEnum.Buy)
            {
                if (stock.BuyVariableTrend != 0)
                {
                    if (stock.BuyVariableTrend == (int)BuyVariableTrendEnum.ReachOrDown)
                    {
                        return stock.CurrentPrice <= GetBuyPriceByTactics(model, stock);
                    }
                    else if (stock.BuyVariableTrend == (int)BuyVariableTrendEnum.DownThenRebound)
                    {
                        if (stock.BuyPrice - stock.CurrentPrice >= stock.BuyVariableAmount)
                            stock.BuyMarkPrice = stock.CurrentPrice;

                        if (stock.CurrentPrice - stock.BuyMarkPrice >= stock.BuyVariableAmount)
                            return true;
                    }
                    else if (stock.BuyVariableTrend == (int)BuyVariableTrendEnum.DownThenUp)
                    {
                        if (stock.BuyMarkPrice == 0)
                        {
                            if (stock.BuyPrice - stock.CurrentPrice >= stock.BuyVariableAmount)
                                stock.BuyMarkPrice = stock.CurrentPrice;
                        }
                        else
                        {
                            if (stock.BuyMarkPrice - stock.CurrentPrice >= stock.BuyVariableAmount)
                                stock.BuyMarkPrice = stock.CurrentPrice;
                        }

                        if (stock.CurrentPrice - stock.BuyMarkPrice >= stock.BuyVariableAmount)
                            return true;
                    }
                    else if (stock.BuyVariableTrend == (int)BuyVariableTrendEnum.ReachOrUp)
                    {
                        return stock.CurrentPrice >= stock.BuyPrice;
                    }
                }
            }
            else
            {
                if (stock.SaleVariableTrend != 0)
                {
                    if (stock.SaleVariableTrend == (int)SaleVariableTrendEnum.ReachOrDown)
                    {
                        return stock.CurrentPrice <= stock.SalePrice;
                    }
                    else if (stock.SaleVariableTrend == (int)SaleVariableTrendEnum.UpThenFallBack)
                    {
                        if (stock.CurrentPrice - stock.SalePrice >= stock.SaleVariableAmount)
                            stock.SaleMarkPrice = stock.CurrentPrice;

                        if (stock.SaleMarkPrice - stock.CurrentPrice >= stock.SaleVariableAmount)
                            return true;
                    }
                    else if (stock.SaleVariableTrend == (int)SaleVariableTrendEnum.UpThenDown)
                    {
                        if (stock.SaleMarkPrice == 0)
                        {
                            if (stock.CurrentPrice - stock.SalePrice >= stock.SaleVariableAmount)
                                stock.SaleMarkPrice = stock.CurrentPrice;
                        }
                        else
                        {
                            if (stock.CurrentPrice - stock.SaleMarkPrice >= stock.SaleVariableAmount)
                                stock.SaleMarkPrice = stock.CurrentPrice;
                        }

                        if (stock.SaleMarkPrice - stock.CurrentPrice >= stock.SaleVariableAmount)
                            return true;
                    }
                    else if (stock.SaleVariableTrend == (int)SaleVariableTrendEnum.ReachOrUp)
                    {
                        return stock.CurrentPrice >= stock.SalePrice;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 发送交易成功邮件
        /// </summary>
        /// <param name="amount">数量</param>
        /// <param name="stock">证券model</param>
        /// <param name="sw">所耗时间</param>
        /// <param name="type">买/卖类型</param>
        private void SendTradeSuccessMail(int amount, StockList stock, Stopwatch sw, TradeTypeEnum type)
        {
            string subject, body;
            if (type == TradeTypeEnum.Buy)
            {
                subject = string.Format("成功以{0}元买入{1}({2}){3}股", stock.CurrentPrice, stock.StockName, stock.StockCode, amount);
                body = string.Format("用时{0}秒", sw.Elapsed.TotalSeconds);
            }
            else
            {
                subject = string.Format("成功以{0}元卖出{1}({2}){3}股", stock.CurrentPrice, stock.StockName, stock.StockCode, amount);
                body = string.Format("用时{0}秒", sw.Elapsed.TotalSeconds);
            }
            SendMail(subject, body);
        }

        /// <summary>
        /// 发送邮件公共方法
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        public bool SendMail(string subject, string body, ConfigModel config = null)
        {
            try
            {
                if (config == null)
                    config = Utils.GetConfig();
                if (config != null)
                {
                    string ename = config.ename;
                    string epwd = config.epwd;
                    string server = config.server;
                    int port = Convert.ToInt16(config.port);
                    string add = config.add;
                    Simplify.Mail.MailSenderSettings settings = new Simplify.Mail.MailSenderSettings(server, port, ename, epwd);
                    Simplify.Mail.MailSender msender = new Simplify.Mail.MailSender(settings);
                    List<string> addList = add.Split(',').ToList<string>();
                    MailMessage mailMess = new MailMessage();
                    foreach (string address in addList)
                        mailMess.Bcc.Add(address);
                    mailMess.From = new MailAddress(config.sendadd);
                    mailMess.Subject = subject;
                    mailMess.Body = body;
                    msender.Send(mailMess);
                    return true;
                }
                else
                {
                    log.ErrorFormat("settings.txt 配置文件不存在");
                    return false;
                }
            }
            catch (Exception ex)
            {
                string text = "邮件发送失败," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.ErrorFormat("邮件发送失败.{0}", ex.Message);
                SetMessage(text);
                return false;
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
                SetMessage("上传成功!" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            else
                SetMessage("上传失败," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
                //putPolicy.DeleteAfterDays = 1;
                // 请注意这里的Zone设置(如果不设置，就默认为华东机房)
                var zoneId = Qiniu.Common.AutoZone.Query(AK, Utils.bucket);
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
                string text = "上传文件出现错误" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.ErrorFormat(text, ex.Message);
            }
        }
        private string txtStockCode = "StockCode";
        private string txtStockName = "StockName";
        private string txtBuyAmount = "BuyAmount";
        private string txtBuyPrice = "BuyPrice";
        private string txtBuyVariableTrend = "BuyVariableTrend";
        private string txtBuyVariableAmount = "BuyVariableAmount";
        private string txtSaleAmount = "SaleAmount";
        private string txtSalePrice = "SalePrice";
        private string txtSaleVariableTrend = "SaleVariableTrend";
        private string txtSaleVariableAmount = "SaleVariableAmount";
        private string txtMonitor = "Monitor";
        private string txtBuyStrategy = "BuyStrategy";
        private string txtSaleStrategy = "SaleStrategy";

        /// <summary>
        /// 从数据容器获取实体model
        /// </summary>
        /// <returns></returns>
        private StockConfigModel GetModelFromDataContainer()
        {
            StockConfigModel model = new StockConfigModel();
            model.AvailableBalance = Convert.ToInt32(txtBalance.Text);
            model.LimitBuyTime = chkLimitBuyTime.Checked;
            model.LimitSaleTime = chkLimitSaleTime.Checked;
            model.BuyBeginTime = dtBuyBeginTime.Value;
            model.BuyEndTime = dtBuyEndTime.Value;
            model.SaleBeginTime = dtSaleBeginTime.Value;
            model.SaleEndTime = dtSaleEndTime.Value;
            model.Monitoring = lblMonitor.Text == "正在监控..." ? true : false;
            List<StockList> list = new List<StockList>();
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                DataGridViewCellCollection cells = dataGrid.Rows[i].Cells;
                if (cells[txtStockCode].Value != null && cells[txtStockName].Value != null)
                {
                    if (cells[txtStockCode].Value.ToString() != "" && cells[txtStockName].Value.ToString() != "")
                        list.Add(new StockList { StockCode = cells[txtStockCode].Value.ToString(), StockName = cells[txtStockName].Value.ToString(), BuyPrice = Convert.ToDecimal(cells[txtBuyPrice].Value), BuyAmount = Convert.ToInt32(cells[txtBuyAmount].Value), Monitor = cells[txtMonitor].Value.ToString() });
                }
            }
            model.StockList = list;
            return model;
        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            LoadConfig();
            BindData(Download(Utils.FileNameAoto));
        }

        private StockConfigModel CanDownload(string FileNameAoto, Mac mac)
        {

            return Utils.CanGetFile(mac) ? Download(FileNameAoto) : model;

        }

        private StockConfigModel Download(string FileNameAoto)
        {

            string filepath = "";
            if (Utils.DownloadFile(FileNameAoto))
            {
                filepath = FileNameAoto;

                string json = File.ReadAllText(filepath);

                StockConfigModel configModel = Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(StockConfigModel)) as StockConfigModel;

                SetMessage("下载文件转换成功," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                log.DebugFormat(lblMessage.Text);

                return configModel;

            }
            else
            {
                SetMessage("下载文件出现错误," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                log.ErrorFormat(lblMessage.Text);
                return null;
            }
        }

        public void SetMessage(string text)
        {
            lblMessage.Text = text;
            lblMessage.ForeColor = (lblMessage.ForeColor == Color.OrangeRed) ? System.Drawing.SystemColors.HotTrack : Color.OrangeRed;
        }

        private void BindData(StockConfigModel configModel)
        {
            if (configModel != null)
            {
                int Cnt = 0;
                foreach (StockList ll in configModel.StockList)
                {
                    StockModel smodel = GetInfo.Get(ll.StockCode);
                    ll.CurrentPrice = smodel.CurrentPrice;

                    ll.BuyStrategy = string.Format("{0}{1}元", ((BuyVariableTrendEnum)ll.BuyVariableTrend).GetEnumDescription(), ll.BuyVariableAmount);
                    ll.SaleStrategy = string.Format("{0}{1}元", ((SaleVariableTrendEnum)ll.SaleVariableTrend).GetEnumDescription(), ll.SaleVariableAmount);
                    if (ll.CurrentPrice >= smodel.YesterdayEndPrice)
                        ll.IncreaseAmt = string.Format("{0}", Math.Round((ll.CurrentPrice / smodel.YesterdayEndPrice - 1) * 100, 2));
                    else
                        ll.IncreaseAmt = string.Format("-{0}", Math.Round((1 - ll.CurrentPrice / smodel.YesterdayEndPrice) * 100, 2));
                    if (ll.Monitor == "监控中")
                        Cnt++;
                }

                dataGrid.DataSource = configModel.StockList;
                dataGrid.Refresh();
                txtBalance.Text = configModel.AvailableBalance.ToString();
                chkLimitBuyTime.Checked = configModel.LimitBuyTime;
                chkLimitSaleTime.Checked = configModel.LimitSaleTime;
                dtBuyBeginTime.Value = configModel.BuyBeginTime;
                dtBuyEndTime.Value = configModel.BuyEndTime;
                dtSaleBeginTime.Value = configModel.SaleBeginTime;
                dtSaleEndTime.Value = configModel.SaleEndTime;
                lblMonitor.Visible = true;
                lblMonitor.Text = Cnt > 0 ? "正在监控..." : "监控已停止...";
                cbxSoft.SelectedIndex = configModel.TradeSoftWare;
                chkGapLower.Checked = configModel.UseGapLowerTactics;
            }
        }



        private Boolean ZhaoShangZhiYuanTrade(StockList stock, TradeTypeEnum type)
        {
            IntPtr myIntPtr = Utils.FindWindow("TdxW_MainFrame_Class", null);
            Boolean flagFore = Utils.SetForegroundWindow(myIntPtr);
            if (flagFore)
            {
                Boolean flagShowMax = Utils.ShowWindow(myIntPtr, 3);
                if (flagShowMax)
                {
                    if (type == TradeTypeEnum.Buy)
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
            }
            return flagFore;
        }


        private Boolean JQKA(StockList stock, TradeTypeEnum type)
        {
            IntPtr myIntPtr = Utils.FindWindow(null, "网上股票交易系统5.0");
            Boolean flagFore = Utils.SetForegroundWindow(myIntPtr);
            if (flagFore)
            {
                Boolean flagShowMax = Utils.ShowWindow(myIntPtr, 3);
                if (flagShowMax)
                {
                    if (type == TradeTypeEnum.Buy)
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
                    else
                    {
                        SendKeys.SendWait("{F2}");
                        Thread.Sleep(200);
                        SendKeys.SendWait(stock.StockCode);
                        Thread.Sleep(300);
                        SendKeys.SendWait("{TAB}");
                        Thread.Sleep(200);
                        SendKeys.SendWait(stock.CurrentPrice.ToString());
                        Thread.Sleep(200);
                        SendKeys.SendWait("{TAB}");
                        Thread.Sleep(200);
                        SendKeys.SendWait(stock.SaleAmount.ToString());
                        Thread.Sleep(200);
                        SendKeys.SendWait("{ENTER}");
                        Thread.Sleep(200);
                        SendKeys.SendWait("{ENTER}");
                        Thread.Sleep(200);
                        SendKeys.SendWait("{ENTER}");
                    }
                }
            }
            return flagFore;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm(this);
            form.ShowDialog();
        }

        private void dataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dataGrid.Rows[e.RowIndex].Cells["IncreaseAmt"].Value.ToString().Contains("-"))
            {
                dataGrid.Rows[e.RowIndex].Cells["IncreaseAmt"].Style.ForeColor = Color.FromArgb(21, 151, 21);
                dataGrid.Rows[e.RowIndex].Cells["CurrentPrice"].Style.ForeColor = Color.FromArgb(21, 151, 21);
            }
            else
            {
                dataGrid.Rows[e.RowIndex].Cells["IncreaseAmt"].Style.ForeColor = Color.FromArgb(193, 35, 40);
                dataGrid.Rows[e.RowIndex].Cells["CurrentPrice"].Style.ForeColor = Color.FromArgb(193, 35, 40);
            }
        }
    }
}
