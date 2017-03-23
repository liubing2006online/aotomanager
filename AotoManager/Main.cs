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
                try
                {
                    SaveFileFlag = SaveAsDefaultFile(FileNameAoto);
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
        }


        /// <summary>
        /// 上传完成后回调
        /// </summary>
        /// <param name="key"></param>
        /// <param name="respInfo"></param>
        /// <param name="respJson"></param>
        private static void OnUploadCompleted(string key, ResponseInfo respInfo, string respJson)
        {
            // respInfo.StatusCode
            // respJson是返回的json消息，示例: { "key":"FILE","hash":"HASH","fsize":FILE_SIZE }
            if (respInfo.StatusCode == 200)
                MessageBox.Show("上传成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("上传失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dataGrid.DataSource = configModel.StockList;
            txtBalance.Text = configModel.AvailableBalance.ToString();
            chkLimitTime.Checked = configModel.LimitTime;
            dtBeginTime.Value = configModel.BuyBeginTime;
            dtEndTime.Value = configModel.BuyEndTime;
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
                decimal everyBalance = Convert.ToDecimal(balance / dataGrid.Rows.Count);
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {

                    decimal price = Convert.ToDecimal(dataGrid.Rows[i].Cells[2].Value);

                    dataGrid.Rows[i].Cells[3].Value = GetStoreHouse(everyBalance, price);
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
            if (SaveAsDefaultFile(FileNameAoto))
                MessageBox.Show("保存文件到本地成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("保存文件到本地失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean SaveAsDefaultFile(string filename)
        {
            if (GetTrueCondition())
            {
                try
                {
                    StockConfigModel model = new StockConfigModel();
                    model.AvailableBalance = Convert.ToInt32(txtBalance.Text);
                    model.LimitTime = chkLimitTime.Checked;
                    model.BuyBeginTime = dtBeginTime.Value;
                    model.BuyEndTime = dtEndTime.Value;
                    List<StockList> list = new List<StockList>();
                    for (int i = 0; i < dataGrid.Rows.Count; i++)
                    {
                        list.Add(new StockList { StockCode = dataGrid.Rows[i].Cells[0].Value.ToString(), StockName = dataGrid.Rows[i].Cells[1].Value.ToString(), BuyPrice = Convert.ToDecimal(dataGrid.Rows[i].Cells[2].Value), BuyAmount = Convert.ToInt32(dataGrid.Rows[i].Cells[3].Value) });
                    }
                    model.StockList = list;

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

                    File.WriteAllText(filename, json);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }




        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           string code = dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
           StockModel model=  GetInfo.Get(code);
           if (model != null)
           {
                dataGrid.Rows[e.RowIndex].Cells[1].Value = model.Name;
                dataGrid.Rows[e.RowIndex].Cells[2].Value = model.CurrentPrice;
            }
           else
             MessageBox.Show("获取信息失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

