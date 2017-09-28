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
        StockConfigModel mainConfigModel;
        public MdiForm(string code, string name, string buyamount, string buyprice, string buyvariabletrend, string buyvariableamount, string saleamount, string saleprice, string salevariabletrend, string salevariableamount, StockConfigModel configModel, DataGridView DataGrid)
        {
            InitializeComponent();

            List<DictionaryEntry> buyVarTrendList = new List<DictionaryEntry>();
            buyVarTrendList.Add(new DictionaryEntry(BuyVariableTrendEnum.ReachOrUp.GetEnumDescription(), (int)BuyVariableTrendEnum.ReachOrUp));
            buyVarTrendList.Add(new DictionaryEntry(BuyVariableTrendEnum.ReachOrDown.GetEnumDescription(), (int)BuyVariableTrendEnum.ReachOrDown));
            buyVarTrendList.Add(new DictionaryEntry(BuyVariableTrendEnum.DownThenRebound.GetEnumDescription(), (int)BuyVariableTrendEnum.DownThenRebound));
            buyVarTrendList.Add(new DictionaryEntry(BuyVariableTrendEnum.DownThenUp.GetEnumDescription(), (int)BuyVariableTrendEnum.DownThenUp));
            cbxBuyVarTrend.DataSource = buyVarTrendList;
            cbxBuyVarTrend.ValueMember = "Value";
            cbxBuyVarTrend.DisplayMember = "Key";

            List<DictionaryEntry> SaleVarTrendList = new List<DictionaryEntry>();
            SaleVarTrendList.Add(new DictionaryEntry(SaleVariableTrendEnum.ReachOrUp.GetEnumDescription(), (int)SaleVariableTrendEnum.ReachOrUp));
            SaleVarTrendList.Add(new DictionaryEntry(SaleVariableTrendEnum.ReachOrDown.GetEnumDescription(), (int)SaleVariableTrendEnum.ReachOrDown));
            SaleVarTrendList.Add(new DictionaryEntry(SaleVariableTrendEnum.UpThenFallBack.GetEnumDescription(), (int)SaleVariableTrendEnum.UpThenFallBack));
            SaleVarTrendList.Add(new DictionaryEntry(SaleVariableTrendEnum.UpThenDown.GetEnumDescription(), (int)SaleVariableTrendEnum.UpThenDown));
            cbxSaleVarTrend.DataSource = SaleVarTrendList;
            cbxSaleVarTrend.ValueMember = "Value";
            cbxSaleVarTrend.DisplayMember = "Key";
            if (code == "")
            {
                this.Text = "添加证券";
                cbxBuyVarTrend.SelectedValue = (int)BuyVariableTrendEnum.ReachOrDown;
                cbxSaleVarTrend.SelectedValue = (int)SaleVariableTrendEnum.ReachOrUp;
                txtBuyVarAmount.Text = "0";
                txtSaleVarAmount.Text = "0";
            }
            else
            {
                this.Text = "修改信息";
                cbxBuyVarTrend.SelectedValue = int.Parse(buyvariabletrend);
                cbxSaleVarTrend.SelectedValue = int.Parse(salevariabletrend);
                txtCode.Text = code;
                txtName.Text = name;
                txtBuyAmount.Text = buyamount;
                txtBuyPrice.Text = buyprice;
                txtBuyVarAmount.Text = buyvariableamount;
                txtSaleAmount.Text = saleamount;
                txtSalePrice.Text = saleprice;
                txtSaleVarAmount.Text = salevariableamount;
            }
            mainConfigModel = configModel;
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
                cbxBuyChooseAmount.Text = "";
                cbxBuyChooseAmount.DataSource = CalculateBuyStore();
                cbxBuyChooseAmount.ValueMember = "Value";
                cbxBuyChooseAmount.DisplayMember = "Key";
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
                cbxBuyChooseAmount.Text = "";
                cbxBuyChooseAmount.DataSource = CalculateBuyStore();
                cbxBuyChooseAmount.ValueMember = "Value";
                cbxBuyChooseAmount.DisplayMember = "Key";
            }

        }
        private List<DictionaryEntry> CalculateBuyStore()
        {
            if (txtBalance.Text != "" && txtBuyPrice.Text != "")
            {
                return GetAllStoreHouseList(decimal.Parse(txtBalance.Text), decimal.Parse(txtBuyPrice.Text));
            }
            return null;
        }

        private List<DictionaryEntry> CalculateSaleStore()
        {
            if (txtBalance.Text != "" && txtSalePrice.Text != "")
            {
                return GetAllStoreHouseList(decimal.Parse(txtBalance.Text), decimal.Parse(txtSalePrice.Text));
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
            if (cbxBuyChooseAmount.SelectedIndex != -1)
            {
                txtBuyAmount.Text = cbxBuyChooseAmount.SelectedValue.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("证券代码为空！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }
            if (txtBuyPrice.Text.Trim() == "")
            {
                MessageBox.Show("买入价格为空！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuyPrice.Focus();
                return;
            }
            if (txtSalePrice.Text.Trim() == "")
            {
                MessageBox.Show("卖出价格为空！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalePrice.Focus();
                return;
            }
            if (txtBuyVarAmount.Text.Trim() == "")
            {
                MessageBox.Show("请输入一个数值！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuyVarAmount.Focus();
                return;
            }
            if (txtSaleVarAmount.Text.Trim() == "")
            {
                MessageBox.Show("请输入一个数值！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaleVarAmount.Focus();
                return;
            }

            StockList stock = new StockList();
            stock.StockCode = txtCode.Text.Trim();
            stock.StockName = txtName.Text.Trim();
            stock.BuyPrice = decimal.Parse(txtBuyPrice.Text.Trim());
            stock.BuyAmount = int.Parse(txtBuyAmount.Text.Trim() == "" ? "0" : txtBuyAmount.Text.Trim());
            stock.BuyVariableAmount = decimal.Parse(txtBuyVarAmount.Text.Trim());
            stock.BuyVariableTrend = Convert.ToInt32(cbxBuyVarTrend.SelectedValue);
            stock.BuyStrategy = string.Format("{0}{1}元", ((BuyVariableTrendEnum)cbxBuyVarTrend.SelectedValue).GetEnumDescription(), txtBuyVarAmount.Text.Trim());
            stock.SalePrice = decimal.Parse(txtSalePrice.Text.Trim());
            stock.SaleAmount = int.Parse(txtSaleAmount.Text.Trim() == "" ? "0" : txtSaleAmount.Text.Trim());
            stock.SaleVariableAmount = decimal.Parse(txtSaleVarAmount.Text.Trim());
            stock.SaleVariableTrend = Convert.ToInt32(cbxSaleVarTrend.SelectedValue);
            stock.SaleStrategy = string.Format("{0}{1}元", ((SaleVariableTrendEnum)cbxSaleVarTrend.SelectedValue).GetEnumDescription(), txtSaleVarAmount.Text.Trim());

            foreach (StockList ll in mainConfigModel.StockList)
            {
                ll.BuyStrategy = string.Format("{0}{1}元", ((BuyVariableTrendEnum)ll.BuyVariableTrend).GetEnumDescription(), ll.BuyVariableAmount);
                ll.SaleStrategy = string.Format("{0}{1}元", ((SaleVariableTrendEnum)ll.SaleVariableTrend).GetEnumDescription(), ll.SaleVariableAmount);
            }
            bool flag = false;
            for (int i = 0; i < mainConfigModel.StockList.Count; i++)
            {
                if (mainConfigModel.StockList[i].StockCode == stock.StockCode)
                {
                    stock.Monitor = mainConfigModel.StockList[i].Monitor;
                    mainConfigModel.StockList[i] = stock;
                    flag = true;
                }
            }

            if (!flag)
            {
                mainConfigModel.StockList.Add(stock);
                stock.Monitor = "已停止";
            }
            mainConfigModel.StockList.Add(new StockList { StockCode = "", StockName = "", BuyPrice = 0, BuyAmount = 0, CurrentPrice = 0, SalePrice = 0, SaleAmount = 0, Monitor = "" });
            mainDataGrid.DataSource = mainConfigModel.StockList;
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

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '.'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }


        private void txtSaleVarAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '.'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void txtSaleAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void cbxBuyVarTrend_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBuyVarTrend.SelectedValue != null)
            {
                if (Convert.ToInt32(cbxBuyVarTrend.SelectedValue) == (int)BuyVariableTrendEnum.DownThenRebound)
                    txtBuyVarAmount.Text = "0.05";
                else
                    txtBuyVarAmount.Text = "0";
            }
        }

        private void cbxSaleVarTrend_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSaleVarTrend.SelectedValue != null)
            {
                if (Convert.ToInt32(cbxSaleVarTrend.SelectedValue) == (int)SaleVariableTrendEnum.UpThenFallBack)
                    txtSaleVarAmount.Text = "0.05";
                else
                    txtSaleVarAmount.Text = "0";
            }
        }
    }
}
