using GetRealTimeInfo;
using GetRealTimeInfo.Model;
using System;
using System.Collections;
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
    public partial class MdiForm : Form
    {
        public MdiForm()
        {
            InitializeComponent();
        }
        DataGridView mainDataGrid;
        public MdiForm(string code, string name, string buyamount, string buyprice, string buyvariabletrend, string buyvariableamount, DataGridView DataGrid)
        {
            InitializeComponent();

            List<DictionaryEntry> varTrendList = new List<DictionaryEntry>();
            varTrendList.Add(new DictionaryEntry(BuyVariableTrendEnum.ReachOrUp.GetEnumDescription(), (int)BuyVariableTrendEnum.ReachOrUp));
            varTrendList.Add(new DictionaryEntry(BuyVariableTrendEnum.ReachOrDown.GetEnumDescription(), (int)BuyVariableTrendEnum.ReachOrDown));
            varTrendList.Add(new DictionaryEntry(BuyVariableTrendEnum.DownThenRebound.GetEnumDescription(), (int)BuyVariableTrendEnum.DownThenRebound));
            varTrendList.Add(new DictionaryEntry(BuyVariableTrendEnum.DownThenUp.GetEnumDescription(), (int)BuyVariableTrendEnum.DownThenUp));
            cbxVarTrend.DataSource = varTrendList;
            cbxVarTrend.ValueMember = "Value";
            cbxVarTrend.DisplayMember = "Key";

            txtCode.Text = code;
            txtName.Text = name;
            txtBuyAmount.Text = buyamount;
            txtBuyPrice.Text = buyprice;
            cbxVarTrend.SelectedValue = int.Parse(buyvariabletrend);
            txtVarAmount.Text = buyvariableamount;
            mainDataGrid = DataGrid;

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

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            string code = txtCode.Text.Trim();
            if (code.Length == 6)
            {
                StockModel model = GetInfo.Get(code);
                txtName.Text = model.Name;
                txtBuyPrice.Text = model.CurrentPrice.ToString();
            }
        }

        private void txtBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '.'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void txtBuyPrice_KeyUp(object sender, KeyEventArgs e)
        {
            decimal buyprice = 0M;
            if (!decimal.TryParse(txtBuyPrice.Text, out buyprice))
            {
                txtBuyPrice.Text = "";
            }
            else
            {
                cbxBuyAmount.Text = "";
                cbxBuyAmount.DataSource = CalculateStore();
                cbxBuyAmount.ValueMember = "Value";
                cbxBuyAmount.DisplayMember = "Key";
            }
        }

        private void txtBalance_KeyUp(object sender, KeyEventArgs e)
        {
            decimal balance;
            if (!decimal.TryParse(txtBalance.Text, out balance))
            {
                txtBalance.Text = "";
            }
            else
            {
                cbxBuyAmount.Text = "";
                cbxBuyAmount.DataSource = CalculateStore();
                cbxBuyAmount.ValueMember = "Value";
                cbxBuyAmount.DisplayMember = "Key";
            }

        }
        private List<DictionaryEntry> CalculateStore()
        {
            if (txtBalance.Text != "" && txtBuyPrice.Text != "")
            {
                return GetAllStoreHouseList(decimal.Parse(txtBalance.Text), decimal.Parse(txtBuyPrice.Text));
            }
            return null;
        }

        private List<DictionaryEntry> GetAllStoreHouseList(decimal balance, decimal price)
        {
            if (price == 0)
                return null;
            int allstore = Utils.GetStoreHouse(balance, price);
            int halfstore = Utils.GetStoreHouse(balance / 2, price);
            int threestore = Utils.GetStoreHouse(balance / 3, price);
            int fivestore = Utils.GetStoreHouse(balance / 5, price);
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            if (allstore != 0)
                list.Add(new DictionaryEntry(string.Format("全仓({0})", allstore), allstore));
            if (halfstore != 0)
                list.Add(new DictionaryEntry(string.Format("半仓({0})", halfstore), halfstore));
            if (threestore != 0)
                list.Add(new DictionaryEntry(string.Format("三分之一仓({0})", threestore), threestore));
            if (fivestore != 0)
                list.Add(new DictionaryEntry(string.Format("五分之一仓({0})", fivestore), fivestore));
            return list;
        }

        private void cbxBuyAmount_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxBuyAmount.SelectedIndex != -1)
            {
                txtBuyAmount.Text = cbxBuyAmount.SelectedValue.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mainDataGrid.SelectedRows[0].Cells["StockCode"].Value = txtCode.Text.Trim();
            mainDataGrid.SelectedRows[0].Cells["StockName"].Value = txtName.Text.Trim();
            mainDataGrid.SelectedRows[0].Cells["BuyPrice"].Value = txtBuyPrice.Text.Trim();
            mainDataGrid.SelectedRows[0].Cells["BuyAmount"].Value = txtBuyAmount.Text.Trim();
            mainDataGrid.SelectedRows[0].Cells["BuyVariableAmount"].Value = txtVarAmount.Text.Trim();
            mainDataGrid.SelectedRows[0].Cells["BuyVariableTrend"].Value = cbxVarTrend.SelectedValue;
            mainDataGrid.SelectedRows[0].Cells["BuyStrategy"].Value = string.Format("{0}{1}元", ((BuyVariableTrendEnum)cbxVarTrend.SelectedValue).GetEnumDescription(), txtVarAmount.Text.Trim());
            this.Close();
        }

        private void txtVarAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '.'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
