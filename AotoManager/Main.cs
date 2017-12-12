using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Qiniu.Util;
using Qiniu.Storage;
using Qiniu.Http;
using Qiniu.Storage.Model;
using System.Collections;
using GetRealTimeInfo;
using GetRealTimeInfo.Model;

namespace AotoManager
{
    public partial class Main : Form
    {
        string bucket = Utils.bucket;
        string FileNameAoto = Utils.FileNameAoto;
        string AK;
        string SK;
        public string Uri;
        Mac mac;
        public static bool SaveFileFlag = false;
        public static bool DelFileFlag = false;
        public string Path = Utils.Path;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string AKtxt { set { txtAK.Text = value; } }
        public string SKtxt { set { txtSK.Text = value; } }
        public Main()
        {
            InitializeComponent();
            ConfigModel config = Utils.GetConfig();
            if (config != null)
            {
                AK = config.AK;
                SK = config.SK;
            }
            else
            {
                MessageBox.Show("settings.txt 配置文件不存在", "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Uri = Utils.Uri;

            mac = new Mac(AK, SK);
            txtAK.Text = AK;
            txtSK.Text = SK;
            cbxSoft.SelectedIndex = 1;
            //Model.StockConfigModel model = new Model.StockConfigModel();
            //model.AvailableBalance = 900000;
            //model.BuyBeginTime = DateTime.Parse(DateTime.Now.ToString("09:30:00"));
            //model.BuyEndTime = DateTime.Parse(DateTime.Now.ToString("14:59:59"));
            //model.LimitTime = true;
            //List<StockList> stocklist = new List<StockList>();
            //stocklist.Add(new StockList() { BuyAmount = 300, BuyPrice = 21.8M, SaleAmount = 300, SalePrice = 29M, StockCode = "300115", StockName = "长盈精密" });

            //stocklist.Add(new StockList() { BuyAmount = 900, BuyPrice = 11.8M, SaleAmount = 700, SalePrice = 16.8M, StockCode = "000046", StockName = "泛海建设" });

            //model.StockList = stocklist;


            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (GetTrueCondition())
            {
                UploadFile(GetModelFromDataContainer());
            }
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
                MessageBox.Show("出现错误" + ex.Message, "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetMessage(string text)
        {
            lblMessage.Text = text;
            lblMessage.ForeColor = (lblMessage.ForeColor == Color.OrangeRed) ? System.Drawing.SystemColors.HotTrack : Color.OrangeRed;
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
            {
                SetMessage("上传成功," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
                SetMessage("上传失败," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        /// <summary>
        /// 删除远端文件
        /// </summary>
        /// <param name="filename">按文件名前缀保留搜索结果</param>
        /// <returns></returns>
        private Boolean DelFile(string filename)
        {
            BucketManager bm = new BucketManager(mac);
            string marker = ""; // 首次请求时marker必须为空
            string delimiter = null; // 目录分割字符(比如"/")
            int limit = 100; // 最大值1000
                             // 返回结果存储在items中
            List<FileDesc> items = new List<FileDesc>();
            // 由于limit限制，可能需要执行多次操作
            // 返回值中Marker字段若非空，则表示文件数超过了limit

            ListFilesResult list = bm.listFiles(bucket, filename, marker, limit, delimiter);
            List<FileDesc> fileList = list.Items;
            if (fileList != null)
            {
                foreach (FileDesc f in fileList)
                {
                    var result = bm.delete(bucket, f.Key);
                    if (result.ResponseInfo.StatusCode == 200)
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }




        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = "";
                if (Utils.DownloadFile(FileNameAoto))
                {
                    filepath = FileNameAoto;

                    string json = File.ReadAllText(filepath);

                    StockConfigModel configModel = Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(StockConfigModel)) as StockConfigModel;

                    BindData(configModel);

                    SetMessage("下载成功," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                    MessageBox.Show("下载文件出现错误", "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("下载文件出现错误,{0}", ex.Message);
                MessageBox.Show("下载文件出现错误", "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindData(StockConfigModel configModel)
        {
            int Cnt = 0;
            foreach (StockList ll in configModel.StockList)
            {
                StockModel infoModel = GetInfo.Get(ll.StockCode);
                if (infoModel != null)
                    ll.CurrentPrice = infoModel.CurrentPrice;
                else
                    ll.CurrentPrice = 0;

                ll.BuyStrategy = string.Format("{0}{1}元", ((BuyVariableTrendEnum)ll.BuyVariableTrend).GetEnumDescription(), ll.BuyVariableAmount);
                ll.SaleStrategy = string.Format("{0}{1}元", ((SaleVariableTrendEnum)ll.SaleVariableTrend).GetEnumDescription(), ll.SaleVariableAmount);

                if (ll.Monitor == "监控中")
                    Cnt++;
            }

            configModel.StockList.Add(new StockList { StockCode = "", StockName = "", BuyPrice = 0, BuyAmount = 0, CurrentPrice = 0, SalePrice = 0, SaleAmount = 0, Monitor = "" });
            dataGrid.DataSource = configModel.StockList;
            txtBalance.Text = configModel.AvailableBalance.ToString();
            chkLimitBuyTime.Checked = configModel.LimitBuyTime;
            chkLimitSaleTime.Checked = configModel.LimitSaleTime;
            dtBuyBeginTime.Value = configModel.BuyBeginTime;
            dtBuyEndTime.Value = configModel.BuyEndTime;
            dtSaleBeginTime.Value = configModel.SaleBeginTime;
            dtSaleEndTime.Value = configModel.SaleEndTime;
            btnStop.Visible = true;
            lblMonitor.Visible = true;
            cbxSoft.SelectedIndex = configModel.TradeSoftWare;
            btnStop.Text = Cnt > 0 ? "停止监控" : "开始监控";
            lblMonitor.Text = Cnt > 0 ? "正在监控..." : "监控已停止...";
            btnCloseComputer.Text = configModel.CloseComputerTime == DateTime.MinValue ? "关闭电脑" : "取消关闭";
            chkGapLower.Checked = configModel.UseGapLowerTactics;
        }



        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            if (GetTrueCondition())
            {
                int balance = Convert.ToInt32(txtBalance.Text);
                int Cnt = 0;
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[txtBuyPrice].Value != null && dataGrid.Rows[i].Cells[txtBuyPrice].Value.ToString() != "0.00" && dataGrid.Rows[i].Cells[txtStockName].Value.ToString() != "")
                        Cnt++;
                }


                if (Cnt != 0)
                {
                    decimal everyBalance = Convert.ToDecimal(balance / Cnt);
                    for (int i = 0; i < Cnt; i++)
                    {
                        decimal price;
                        if (decimal.TryParse(dataGrid.Rows[i].Cells[txtBuyPrice].Value.ToString(), out price))
                        {
                            dataGrid.Rows[i].Cells[txtBuyAmount].Value = Utils.GetStoreHouse(everyBalance, price);
                        }
                    }
                }
            }
        }

        private Boolean GetTrueCondition()
        {
            if (txtBalance.Text != "" && txtBalance.Text.Length > 2 && dataGrid.Rows.Count != 0)
                return true;
            else
                return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GetTrueCondition())
            {
                if (SaveAsDefaultFile(FileNameAoto, GetModelFromDataContainer()))
                    MessageBox.Show("保存文件到本地成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("保存文件到本地失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            model.TradeSoftWare = cbxSoft.SelectedIndex;
            //关机设置
            model.CloseComputerTime = (btnCloseComputer.Text == "取消关闭") ? DateTime.Now : DateTime.MinValue;
            int Cnt = 0;



            List<StockList> list = new List<StockList>();
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                DataGridViewCellCollection cells = dataGrid.Rows[i].Cells;
                if (cells[txtStockCode].Value != null && cells[txtStockName].Value != null)
                {
                    if (cells[txtStockCode].Value.ToString() != "" && cells[txtStockName].Value.ToString() != "")
                    {
                        list.Add(new StockList { StockCode = cells[txtStockCode].Value.ToString(), StockName = cells[txtStockName].Value.ToString(), BuyPrice = Convert.ToDecimal(cells[txtBuyPrice].Value), BuyAmount = Convert.ToInt32(cells[txtBuyAmount].Value), Monitor = cells[txtMonitor].Value.ToString(), BuyVariableTrend = Convert.ToInt32(cells[txtBuyVariableTrend].Value), BuyVariableAmount = Convert.ToDecimal(cells[txtBuyVariableAmount].Value), SalePrice = Convert.ToDecimal(cells[txtSalePrice].Value), SaleAmount = Convert.ToInt32(cells[txtSaleAmount].Value), SaleVariableTrend = Convert.ToInt32(cells[txtSaleVariableTrend].Value), SaleVariableAmount = Convert.ToDecimal(cells[txtSaleVariableAmount].Value) });
                        if (cells[txtMonitor].Value.ToString() == "监控中")
                            Cnt++;
                    }

                }
            }

            model.Monitoring = Cnt > 0 ? true : false;
            model.StockList = list;
            model.UseGapLowerTactics = chkGapLower.Checked;
            return model;
        }


        private void ClearRow(int rowIndex)
        {
            dataGrid.Rows[rowIndex].Cells[txtStockCode].Value = "";
            dataGrid.Rows[rowIndex].Cells[txtStockName].Value = "";
            dataGrid.Rows[rowIndex].Cells[txtBuyPrice].Value = 0M;
            dataGrid.Rows[rowIndex].Cells[txtBuyAmount].Value = 0M;
            dataGrid.Rows[rowIndex].Cells[txtMonitor].Value = 0M;

        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var cell = dataGrid.Rows[e.RowIndex].Cells[0].Value;

                if (cell == null)
                    return;
                string code = cell.ToString();
                if (code.Length == 6)
                {
                    StockModel model = GetInfo.Get(code);
                    if (model != null)
                    {
                        bool flag = false;
                        for (int j = 0; j < dataGrid.Rows.Count; j++)
                        {
                            if (j != e.RowIndex)
                            {
                                if (dataGrid.Rows[j].Cells[txtStockCode].Value != null)
                                {
                                    if (dataGrid.Rows[j].Cells[txtStockCode].Value.ToString() == dataGrid.Rows[e.RowIndex].Cells[txtStockCode].Value.ToString())
                                    {
                                        flag = true; break;
                                    }
                                }

                            }
                        }
                        if (flag)
                        {
                            MessageBox.Show("证券信息重复！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ClearRow(e.RowIndex);
                        }
                        else
                        {
                            dataGrid.Rows[e.RowIndex].Cells[txtStockName].Value = model.Name;
                            dataGrid.Rows[e.RowIndex].Cells[txtBuyPrice].Value = model.CurrentPrice;
                            dataGrid.Rows[e.RowIndex].Cells[txtBuyAmount].Value = 100;//默认值
                            dataGrid.Rows[e.RowIndex].Cells[txtMonitor].Value = "已停止";//默认值
                            dataGrid.Rows[e.RowIndex].Cells[txtBuyVariableTrend].Value = (int)BuyVariableTrendEnum.ReachOrDown;
                            dataGrid.Rows[e.RowIndex].Cells[txtBuyVariableAmount].Value = 0.00M;
                            dataGrid.Rows[e.RowIndex].Cells[txtBuyStrategy].Value = string.Format("{0}{1}元", BuyVariableTrendEnum.ReachOrDown.GetEnumDescription(), 0);

                            dataGrid.Rows[e.RowIndex].Cells[txtSalePrice].Value = Math.Round(model.CurrentPrice * 1.04M, 2);
                            dataGrid.Rows[e.RowIndex].Cells[txtSaleAmount].Value = 100;//默认值
                            dataGrid.Rows[e.RowIndex].Cells[txtSaleVariableTrend].Value = (int)SaleVariableTrendEnum.ReachOrUp;
                            dataGrid.Rows[e.RowIndex].Cells[txtSaleVariableAmount].Value = 0.00M;
                            dataGrid.Rows[e.RowIndex].Cells[txtSaleStrategy].Value = string.Format("{0}{1}元", SaleVariableTrendEnum.ReachOrUp.GetEnumDescription(), 0);

                        }
                    }
                    else
                    {
                        MessageBox.Show("获取信息失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearRow(e.RowIndex);
                    }
                }
                else
                {
                    ClearRow(e.RowIndex);
                    StockConfigModel model = GetModelFromDataContainer();
                    BindData(model);
                }
            }
            if (e.RowIndex == dataGrid.Rows.Count - 1)
            {
                DataGridViewCellCollection cells = dataGrid.Rows[e.RowIndex].Cells;
                if (cells[txtStockCode].Value != null && cells[txtStockCode].Value.ToString() != "" && cells[txtStockName].Value.ToString() != "")
                {
                    StockConfigModel model = GetModelFromDataContainer();
                    BindData(model);
                }

            }
        }

        private void dataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                StockConfigModel model = GetModelFromDataContainer();
                if (dataGrid.CurrentRow.Index != dataGrid.Rows.Count - 1)
                {
                    model.StockList.RemoveAt(dataGrid.CurrentRow.Index);
                    BindData(model);
                }
            }

        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                dataGrid.Rows[e.RowIndex].Selected = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Boolean flag = (btnStop.Text == "停止监控");
            btnStop.Text = flag ? "开始监控" : "停止监控";

            lblMonitor.Text = flag ? "正在监控..." : "监控已停止...";
            StockConfigModel model = GetModelFromDataContainer();
            model.StockList.ForEach(x => x.Monitor = flag ? "已停止" : "监控中");
            BindData(model);
        }

        private void btnSetFull_Click(object sender, EventArgs e)
        {
            if (GetTrueCondition())
            {
                int balance = Convert.ToInt32(txtBalance.Text);
                int Cnt = 0;
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[txtBuyPrice].Value != null)
                    {
                        if (dataGrid.Rows[i].Cells[txtBuyPrice].Value.ToString() != "0.00" && dataGrid.Rows[i].Cells[txtStockName].Value.ToString() != "")
                            Cnt++;
                    }
                }


                if (Cnt != 0)
                {
                    decimal everyBalance = Convert.ToDecimal(balance);
                    for (int i = 0; i < Cnt; i++)
                    {
                        decimal price;
                        if (decimal.TryParse(dataGrid.Rows[i].Cells[txtBuyPrice].Value.ToString(), out price))
                        {
                            dataGrid.Rows[i].Cells[txtBuyAmount].Value = Utils.GetStoreHouse(everyBalance, price);
                        }
                    }
                }
            }
        }

        private void btnCloseComputer_Click(object sender, EventArgs e)
        {
            btnCloseComputer.Text = btnCloseComputer.Text == "关闭电脑" ? "取消关闭" : "关闭电脑";
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


        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var codecell = dataGrid[txtStockCode, e.RowIndex].Value;
            if (codecell != null)
            {
                dataGrid.Rows[e.RowIndex].Selected = true;

                string name = dataGrid[txtStockName, e.RowIndex].Value.ToString();

                string buyamount = dataGrid[txtBuyAmount, e.RowIndex].Value.ToString();

                string buyprice = dataGrid[txtBuyPrice, e.RowIndex].Value.ToString();

                string buyvariabletrend = dataGrid[txtBuyVariableTrend, e.RowIndex].Value.ToString();

                string buyvariableamount = dataGrid[txtBuyVariableAmount, e.RowIndex].Value.ToString();

                string saleamount = dataGrid[txtSaleAmount, e.RowIndex].Value.ToString();

                string saleprice = dataGrid[txtSalePrice, e.RowIndex].Value.ToString();

                string salevariabletrend = dataGrid[txtSaleVariableTrend, e.RowIndex].Value.ToString();

                string salevariableamount = dataGrid[txtSaleVariableAmount, e.RowIndex].Value.ToString();

                MdiForm form = new MdiForm(codecell.ToString(), name, buyamount, buyprice, buyvariabletrend, buyvariableamount, saleamount, saleprice, salevariabletrend, salevariableamount, GetModelFromDataContainer(), dataGrid, e.RowIndex);
                form.ShowDialog();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm(this);
            form.ShowDialog();
        }
    }
}

