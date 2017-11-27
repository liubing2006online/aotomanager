using AotoManager;
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

namespace AotoManager
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
            ConfigModel config = Utils.GetConfig();
            if (config != null)
            {
                txtAK.Text = config.AK;
                txtSK.Text = config.SK;
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
                    log.ErrorFormat("settings.txt 主项目保存配置出错");
                    mainForm.SetMessage("主项目保存配置失败," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    mainForm.SetMessage("主项目保存配置成功," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    mainForm.AKtxt = config.AK;
                    mainForm.SKtxt = config.SK;
                }
                this.Close();
            }
        }

        private ConfigModel GetConfigByControls()
        {
            if (txtAK.Text.Trim() == "" || txtSK.Text.Trim() == "")
            {
                MessageBox.Show("配置项不能为空", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            ConfigModel config = new ConfigModel();
            config.AK = txtAK.Text.Trim();
            config.SK = txtSK.Text.Trim();
            return config;
        }
    }
}
