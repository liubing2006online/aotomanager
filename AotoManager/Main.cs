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
        string bucket =Utils.bucket;
        string FileNameAoto = Utils.FileNameAoto;
        string AK;
        string SK;
        public string Uri;
        Mac mac;
        public static bool SaveFileFlag = false;
        public static bool DelFileFlag = false;
        public string Path = Utils.Path;
        public Main()
        {
            InitializeComponent();
            AK = Common.AK;
            SK = Common.SK; ;
            Uri = Utils.Uri;
            
            mac = new Mac(AK, SK);
            txtAK.Text = AK;
            txtSK.Text = SK;

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
            if(GetTrueCondition())
            {
              UploadFile(GetModelFromDataContainer());
            }
        }

        private void UploadFile(StockConfigModel model)
        {
            try
            {
                SaveFileFlag = SaveAsDefaultFile(FileNameAoto, model);
                // 本地文件
                string localFile = FileNameAoto;
                // 上传策略
                PutPolicy putPolicy = new PutPolicy();
                // 设置要上传的目标空间
                putPolicy.Scope = bucket;
                // 上传策略的过期时间(单位:秒)
                putPolicy.SetExpires(3600);
                // 文件上传完毕后，在多少天后自动被删除
                putPolicy.DeleteAfterDays = 1;
                // 请注意这里的Zone设置(如果不设置，就默认为华东机房)
                var zoneId = Qiniu.Common.AutoZone.Query(AK, bucket);
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

                DelFileFlag = DelFile(FileNameAoto);

                um.uploadFile(localFile, FileNameAoto, uploadToken, uploadOptions, uploadCompleted);
                // 方式2：使用FormManager
                //FormUploader fm = new FormUploader();
                //fm.uploadFile(localFile, saveKey, token, uploadOptions, uploadCompleted);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误" + ex.Message, "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                lblMessage.Text = "上传成功," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                lblMessage.ForeColor = (lblMessage.ForeColor == Color.OrangeRed) ? System.Drawing.SystemColors.HotTrack : Color.OrangeRed;
            }
            else
                lblMessage.Text = "上传失败";
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
            foreach (FileDesc f in fileList)
            {
                var result = bm.delete(bucket, f.Key);
                if (result.ResponseInfo.StatusCode == 200)
                    return true;
                else
                    return false;
            }
            return true;
        }


 

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            string filepath =Utils.DownloadFile(FileNameAoto);
            if (filepath != "")
            {
            string json = File.ReadAllText(filepath);

            StockConfigModel configModel = Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(StockConfigModel)) as StockConfigModel;

            BindData(configModel);
            }
            else
                MessageBox.Show("下载文件出现错误", "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BindData(StockConfigModel configModel)
        {
            int Cnt = 0;
            foreach (StockList ll in configModel.StockList)
            {
                StockModel infoModel= GetInfo.Get(ll.StockCode);
                if (infoModel != null)
                    ll.CurrentPrice = infoModel.CurrentPrice;
                else
                    ll.CurrentPrice = 0;

                if (ll.Monitor == "监控中")
                    Cnt++;
            }
                
            configModel.StockList.Add(new StockList { StockCode = "", StockName = "", BuyPrice = 0, BuyAmount = 0, CurrentPrice = 0, Monitor = "" });
            dataGrid.DataSource = configModel.StockList;
            txtBalance.Text = configModel.AvailableBalance.ToString();
            chkLimitTime.Checked = configModel.LimitTime;
            dtBeginTime.Value = configModel.BuyBeginTime;
            dtEndTime.Value = configModel.BuyEndTime;
            btnStop.Visible = true;
            lblMonitor.Visible = true;

            btnStop.Text = Cnt>0 ? "停止监控" : "开始监控";
            lblMonitor.Text = Cnt > 0 ? "正在监控..." : "监控已停止...";

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

        private int GetStoreHouse(decimal balance, decimal price)
        {
            int tempStore = (int)Math.Floor(balance / price);
            List<DictionaryEntry> dicAll = new List<DictionaryEntry>();
            return tempStore - tempStore % 100;
        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            if (GetTrueCondition())
            {
                int balance = Convert.ToInt32(txtBalance.Text);
                int Cnt=0;
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells["BuyPrice"].Value.ToString() != "0.00" && dataGrid.Rows[i].Cells["StockName"].Value.ToString() != "")
                        Cnt++;
                }

                
                if(Cnt!=0)
                { 
                    decimal everyBalance = Convert.ToDecimal(balance / Cnt);
                    for (int i = 0; i < Cnt; i++)
                    {
                        decimal price;
                        if(decimal.TryParse(dataGrid.Rows[i].Cells["BuyPrice"].Value.ToString(),out price))
                        { 
                          dataGrid.Rows[i].Cells["BuyAmount"].Value = GetStoreHouse(everyBalance, price);
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
            if(GetTrueCondition())
            { 
            if (SaveAsDefaultFile(FileNameAoto,GetModelFromDataContainer()))
                MessageBox.Show("保存文件到本地成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("保存文件到本地失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean SaveAsDefaultFile(string filename,StockConfigModel model)
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
            model.LimitTime = chkLimitTime.Checked;
            model.BuyBeginTime = dtBeginTime.Value;
            model.BuyEndTime = dtEndTime.Value;
           

            int Cnt = 0;
            


            List<StockList> list = new List<StockList>();
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                DataGridViewCellCollection cells = dataGrid.Rows[i].Cells;
                if (cells["StockCode"].Value!=null &&cells["StockName"].Value!=null)
                {
                    if (cells["StockCode"].Value.ToString() != "" && cells["StockName"].Value.ToString() != "")
                    { 
                        list.Add(new StockList { StockCode = cells["StockCode"].Value.ToString(), StockName = cells["StockName"].Value.ToString(), BuyPrice = Convert.ToDecimal(cells["BuyPrice"].Value), BuyAmount = Convert.ToInt32(cells["BuyAmount"].Value), Monitor = cells["Monitor"].Value.ToString()});
                        if (cells["Monitor"].Value.ToString() == "监控中")
                            Cnt++;
                    }

                }
            }

            model.Monitoring = Cnt>0 ? true : false;
            model.StockList = list;
            return model;
        }


        private void ClearRow(int rowIndex)
        {
            dataGrid.Rows[rowIndex].Cells["StockCode"].Value = "";
            dataGrid.Rows[rowIndex].Cells["StockName"].Value = "";
            dataGrid.Rows[rowIndex].Cells["BuyPrice"].Value = 0M;
            dataGrid.Rows[rowIndex].Cells["BuyAmount"].Value = 0M;
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           if(e.ColumnIndex==0)
            { 
           var cell = dataGrid.Rows[e.RowIndex].Cells[0].Value;
            
            if (cell == null)
                return;
            string code = cell.ToString();
           if (code.Length==6)
            { 
               StockModel model=  GetInfo.Get(code);
               if (model != null)
               {
                    for (int j = 0; j < dataGrid.Rows.Count; j++)
                    {
                        if (j != e.RowIndex)
                        {
                            if (dataGrid.Rows[j].Cells["StockCode"].Value.ToString() == dataGrid.Rows[e.RowIndex].Cells["StockCode"].Value.ToString())
                            { 
                                MessageBox.Show("证券信息重复！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                ClearRow(e.RowIndex);
                            }
                            else
                            {
                                dataGrid.Rows[e.RowIndex].Cells["StockName"].Value = model.Name;
                                dataGrid.Rows[e.RowIndex].Cells["BuyPrice"].Value = model.CurrentPrice;
                                dataGrid.Rows[e.RowIndex].Cells["BuyAmount"].Value = 100;//默认值

                                dataGrid.Rows[e.RowIndex].Cells["Monitor"].Value = "已停止";//默认值
                            }
                        }
                    }
                }
               else
                { 
                    MessageBox.Show("获取信息失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearRow(e.RowIndex);
                }
            }
            }
            if (e.RowIndex == dataGrid.Rows.Count - 1)
            {
                DataGridViewCellCollection cells= dataGrid.Rows[e.RowIndex].Cells;
                if (cells["StockCode"].Value.ToString() != ""&& cells["StockName"].Value.ToString() != "")
                {
                    StockConfigModel model= GetModelFromDataContainer();
                    BindData(model);
                }

            }
        }

        private void dataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                StockConfigModel model = GetModelFromDataContainer();
                if(dataGrid.CurrentRow.Index!= dataGrid.Rows.Count-1)
                { 
                model.StockList.RemoveAt(dataGrid.CurrentRow.Index);
                BindData(model);
                }
            }
            
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid.Rows[e.RowIndex].Selected = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Boolean flag = (btnStop.Text == "停止监控");
            btnStop.Text= flag ? "开始监控" : "停止监控";

            lblMonitor.Text = flag ? "正在监控..." : "监控已停止...";
            StockConfigModel model = GetModelFromDataContainer();
            model.StockList.ForEach(x => x.Monitor =  flag ? "已停止": "监控中");
            BindData(model);
        }
    }
}

