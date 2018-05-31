using GetRealTimeInfo;
using GetRealTimeInfo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AotoTrade
{
    public partial class SettingForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Main mainForm;
        public SettingForm(Main mForm)
        {
            mainForm = mForm;
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            ConfigModel config = Utils.GetConfig();
            if (config != null)
            {
                txtAK.Text = config.AK;
                txtSK.Text = config.SK;
                txtUserName.Text = config.ename;
                txtPassword.Text = config.epwd;
                txtPort.Text = config.port;
                txtServer.Text = config.server;
                txtAddress.Text = config.add;
                txtSendAddress.Text = config.sendadd;
                txtBucket.Text = config.Bucket;
                txtFileName.Text = config.FileName;
                txtPath.Text = config.Path;
                txtRefresh.Text = config.RefreshTime;
                txtBuySuccessVoice.Text = config.BuySuccessVoice;
                txtSaleSuccessVoice.Text = config.SaleSuccessVoice;
            }
            else
            {
                MessageBox.Show("settings.txt 配置文件不存在", "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigModel config = GetConfigByControls();
            if (config != null)
            {
                if (!Utils.SaveConfig(config))
                {
                    log.ErrorFormat("settings.txt 交易项目保存配置出错");
                    mainForm.SetMessage("交易项目保存配置失败," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    mainForm.LoadConfig();
                    mainForm.SetMessage("交易项目保存配置成功," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                this.Close();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ConfigModel config = GetConfigByControls();
            if (config != null)
            {
                if (mainForm.SendMail("测试邮件", "", config))
                    SetMessage("邮件发送成功");
                else
                    SetMessage("邮件发送失败");
            }
        }

        private ConfigModel GetConfigByControls()
        {
            if (txtAK.Text.Trim() == "" || txtSK.Text.Trim() == "" || txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtPort.Text.Trim() == "" || txtServer.Text.Trim() == "" || txtAddress.Text.Trim() == "" || txtBucket.Text.Trim() == "" || txtFileName.Text.Trim() == "" || txtPath.Text.Trim() == "")
            {
                MessageBox.Show("配置不能为空", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            ConfigModel config = new ConfigModel();
            config.AK = txtAK.Text.Trim();
            config.SK = txtSK.Text.Trim();
            config.ename = txtUserName.Text.Trim();
            config.epwd = txtPassword.Text.Trim();
            config.port = txtPort.Text.Trim();
            config.server = txtServer.Text.Trim();
            config.add = txtAddress.Text.Trim();
            config.sendadd = txtSendAddress.Text.Trim();
            config.Bucket = txtBucket.Text.Trim();
            config.FileName = txtFileName.Text.Trim();
            config.Path = txtPath.Text.Trim();
            config.RefreshTime = txtRefresh.Text.Trim();
            config.BuySuccessVoice = txtBuySuccessVoice.Text.Trim();
            config.SaleSuccessVoice = txtSaleSuccessVoice.Text.Trim();
            return config;
        }

        public void SetMessage(string text)
        {
            lblMessage.Text = text;
            lblMessage.ForeColor = (lblMessage.ForeColor == Color.OrangeRed) ? System.Drawing.SystemColors.HotTrack : Color.OrangeRed;
        }
    }
}
