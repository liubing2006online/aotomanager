namespace AotoManager
{
    partial class MdiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.gbxBuy = new System.Windows.Forms.GroupBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtBuyVarAmount = new System.Windows.Forms.TextBox();
            this.lblBuyVarAmount = new System.Windows.Forms.Label();
            this.lblBuyVarTrend = new System.Windows.Forms.Label();
            this.cbxBuyVarTrend = new System.Windows.Forms.ComboBox();
            this.txtBuyAmount = new System.Windows.Forms.TextBox();
            this.lblBuyAmount = new System.Windows.Forms.Label();
            this.cbxBuyChooseAmount = new System.Windows.Forms.ComboBox();
            this.lblBuyChooseAmount = new System.Windows.Forms.Label();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbxSale = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaleVarAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSaleVarTrend = new System.Windows.Forms.Label();
            this.cbxSaleVarTrend = new System.Windows.Forms.ComboBox();
            this.txtSaleAmount = new System.Windows.Forms.TextBox();
            this.lblSaleAmount = new System.Windows.Forms.Label();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.gbxBuy.SuspendLayout();
            this.gbxSale.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(94, 26);
            this.txtCode.MaxLength = 6;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(72, 21);
            this.txtCode.TabIndex = 0;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(23, 29);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(65, 12);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "证券代码：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(317, 26);
            this.txtName.MaxLength = 10;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(72, 21);
            this.txtName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "证券名称：";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(94, 74);
            this.txtBalance.MaxLength = 20;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(72, 21);
            this.txtBalance.TabIndex = 4;
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            this.txtBalance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBalance_KeyUp);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(23, 77);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(65, 12);
            this.lblBalance.TabIndex = 5;
            this.lblBalance.Text = "可用资金：";
            // 
            // gbxBuy
            // 
            this.gbxBuy.Controls.Add(this.lblUnit);
            this.gbxBuy.Controls.Add(this.txtBuyVarAmount);
            this.gbxBuy.Controls.Add(this.lblBuyVarAmount);
            this.gbxBuy.Controls.Add(this.lblBuyVarTrend);
            this.gbxBuy.Controls.Add(this.cbxBuyVarTrend);
            this.gbxBuy.Controls.Add(this.txtBuyAmount);
            this.gbxBuy.Controls.Add(this.lblBuyAmount);
            this.gbxBuy.Controls.Add(this.cbxBuyChooseAmount);
            this.gbxBuy.Controls.Add(this.lblBuyChooseAmount);
            this.gbxBuy.Controls.Add(this.txtBuyPrice);
            this.gbxBuy.Controls.Add(this.lblBuyPrice);
            this.gbxBuy.Location = new System.Drawing.Point(12, 138);
            this.gbxBuy.Name = "gbxBuy";
            this.gbxBuy.Size = new System.Drawing.Size(229, 333);
            this.gbxBuy.TabIndex = 6;
            this.gbxBuy.TabStop = false;
            this.gbxBuy.Text = "买入参数";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(139, 77);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(17, 12);
            this.lblUnit.TabIndex = 13;
            this.lblUnit.Text = "元";
            // 
            // txtBuyVarAmount
            // 
            this.txtBuyVarAmount.Location = new System.Drawing.Point(82, 74);
            this.txtBuyVarAmount.Name = "txtBuyVarAmount";
            this.txtBuyVarAmount.Size = new System.Drawing.Size(51, 21);
            this.txtBuyVarAmount.TabIndex = 12;
            this.txtBuyVarAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarAmount_KeyPress);
            // 
            // lblBuyVarAmount
            // 
            this.lblBuyVarAmount.AutoSize = true;
            this.lblBuyVarAmount.Location = new System.Drawing.Point(11, 77);
            this.lblBuyVarAmount.Name = "lblBuyVarAmount";
            this.lblBuyVarAmount.Size = new System.Drawing.Size(65, 12);
            this.lblBuyVarAmount.TabIndex = 11;
            this.lblBuyVarAmount.Text = "变化数量：";
            // 
            // lblBuyVarTrend
            // 
            this.lblBuyVarTrend.AutoSize = true;
            this.lblBuyVarTrend.Location = new System.Drawing.Point(11, 48);
            this.lblBuyVarTrend.Name = "lblBuyVarTrend";
            this.lblBuyVarTrend.Size = new System.Drawing.Size(65, 12);
            this.lblBuyVarTrend.TabIndex = 10;
            this.lblBuyVarTrend.Text = "变化趋势：";
            // 
            // cbxBuyVarTrend
            // 
            this.cbxBuyVarTrend.FormattingEnabled = true;
            this.cbxBuyVarTrend.Location = new System.Drawing.Point(82, 45);
            this.cbxBuyVarTrend.Name = "cbxBuyVarTrend";
            this.cbxBuyVarTrend.Size = new System.Drawing.Size(95, 20);
            this.cbxBuyVarTrend.TabIndex = 9;
            this.cbxBuyVarTrend.SelectedIndexChanged += new System.EventHandler(this.cbxBuyVarTrend_SelectedIndexChanged);
            // 
            // txtBuyAmount
            // 
            this.txtBuyAmount.Location = new System.Drawing.Point(93, 185);
            this.txtBuyAmount.MaxLength = 6;
            this.txtBuyAmount.Name = "txtBuyAmount";
            this.txtBuyAmount.ReadOnly = true;
            this.txtBuyAmount.Size = new System.Drawing.Size(72, 21);
            this.txtBuyAmount.TabIndex = 8;
            // 
            // lblBuyAmount
            // 
            this.lblBuyAmount.AutoSize = true;
            this.lblBuyAmount.Location = new System.Drawing.Point(11, 188);
            this.lblBuyAmount.Name = "lblBuyAmount";
            this.lblBuyAmount.Size = new System.Drawing.Size(89, 12);
            this.lblBuyAmount.TabIndex = 7;
            this.lblBuyAmount.Text = "实际买入数量：";
            // 
            // cbxBuyChooseAmount
            // 
            this.cbxBuyChooseAmount.FormattingEnabled = true;
            this.cbxBuyChooseAmount.Location = new System.Drawing.Point(93, 147);
            this.cbxBuyChooseAmount.Name = "cbxBuyChooseAmount";
            this.cbxBuyChooseAmount.Size = new System.Drawing.Size(130, 20);
            this.cbxBuyChooseAmount.TabIndex = 6;
            this.cbxBuyChooseAmount.DropDownClosed += new System.EventHandler(this.cbxBuyAmount_DropDownClosed);
            // 
            // lblBuyChooseAmount
            // 
            this.lblBuyChooseAmount.AutoSize = true;
            this.lblBuyChooseAmount.Location = new System.Drawing.Point(11, 150);
            this.lblBuyChooseAmount.Name = "lblBuyChooseAmount";
            this.lblBuyChooseAmount.Size = new System.Drawing.Size(89, 12);
            this.lblBuyChooseAmount.TabIndex = 5;
            this.lblBuyChooseAmount.Text = "可选买入数量：";
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.Location = new System.Drawing.Point(82, 103);
            this.txtBuyPrice.MaxLength = 6;
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(72, 21);
            this.txtBuyPrice.TabIndex = 2;
            this.txtBuyPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuyPrice_KeyPress);
            this.txtBuyPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuyPrice_KeyUp);
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(11, 106);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(65, 12);
            this.lblBuyPrice.TabIndex = 3;
            this.lblBuyPrice.Text = "买入价格：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(131, 482);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 482);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbxSale
            // 
            this.gbxSale.Controls.Add(this.label4);
            this.gbxSale.Controls.Add(this.txtSaleVarAmount);
            this.gbxSale.Controls.Add(this.label5);
            this.gbxSale.Controls.Add(this.lblSaleVarTrend);
            this.gbxSale.Controls.Add(this.cbxSaleVarTrend);
            this.gbxSale.Controls.Add(this.txtSaleAmount);
            this.gbxSale.Controls.Add(this.lblSaleAmount);
            this.gbxSale.Controls.Add(this.txtSalePrice);
            this.gbxSale.Controls.Add(this.lblSalePrice);
            this.gbxSale.Location = new System.Drawing.Point(241, 138);
            this.gbxSale.Name = "gbxSale";
            this.gbxSale.Size = new System.Drawing.Size(229, 333);
            this.gbxSale.TabIndex = 14;
            this.gbxSale.TabStop = false;
            this.gbxSale.Text = "卖出参数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "元";
            // 
            // txtSaleVarAmount
            // 
            this.txtSaleVarAmount.Location = new System.Drawing.Point(82, 74);
            this.txtSaleVarAmount.Name = "txtSaleVarAmount";
            this.txtSaleVarAmount.Size = new System.Drawing.Size(51, 21);
            this.txtSaleVarAmount.TabIndex = 12;
            this.txtSaleVarAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaleVarAmount_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "变化数量：";
            // 
            // lblSaleVarTrend
            // 
            this.lblSaleVarTrend.AutoSize = true;
            this.lblSaleVarTrend.Location = new System.Drawing.Point(11, 48);
            this.lblSaleVarTrend.Name = "lblSaleVarTrend";
            this.lblSaleVarTrend.Size = new System.Drawing.Size(65, 12);
            this.lblSaleVarTrend.TabIndex = 10;
            this.lblSaleVarTrend.Text = "变化趋势：";
            // 
            // cbxSaleVarTrend
            // 
            this.cbxSaleVarTrend.FormattingEnabled = true;
            this.cbxSaleVarTrend.Location = new System.Drawing.Point(82, 45);
            this.cbxSaleVarTrend.Name = "cbxSaleVarTrend";
            this.cbxSaleVarTrend.Size = new System.Drawing.Size(95, 20);
            this.cbxSaleVarTrend.TabIndex = 9;
            this.cbxSaleVarTrend.SelectedIndexChanged += new System.EventHandler(this.cbxSaleVarTrend_SelectedIndexChanged);
            // 
            // txtSaleAmount
            // 
            this.txtSaleAmount.Location = new System.Drawing.Point(93, 185);
            this.txtSaleAmount.MaxLength = 6;
            this.txtSaleAmount.Name = "txtSaleAmount";
            this.txtSaleAmount.Size = new System.Drawing.Size(72, 21);
            this.txtSaleAmount.TabIndex = 8;
            this.txtSaleAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaleAmount_KeyPress);
            // 
            // lblSaleAmount
            // 
            this.lblSaleAmount.AutoSize = true;
            this.lblSaleAmount.Location = new System.Drawing.Point(11, 188);
            this.lblSaleAmount.Name = "lblSaleAmount";
            this.lblSaleAmount.Size = new System.Drawing.Size(89, 12);
            this.lblSaleAmount.TabIndex = 7;
            this.lblSaleAmount.Text = "实际卖出数量：";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(82, 103);
            this.txtSalePrice.MaxLength = 6;
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(72, 21);
            this.txtSalePrice.TabIndex = 2;
            this.txtSalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalePrice_KeyPress);
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Location = new System.Drawing.Point(11, 106);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(65, 12);
            this.lblSalePrice.TabIndex = 3;
            this.lblSalePrice.Text = "卖出价格：";
            // 
            // MdiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 529);
            this.Controls.Add(this.gbxSale);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbxBuy);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Name = "MdiForm";
            this.Text = "修改信息";
            this.gbxBuy.ResumeLayout(false);
            this.gbxBuy.PerformLayout();
            this.gbxSale.ResumeLayout(false);
            this.gbxSale.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.GroupBox gbxBuy;
        private System.Windows.Forms.Label lblBuyChooseAmount;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.ComboBox cbxBuyChooseAmount;
        private System.Windows.Forms.TextBox txtBuyAmount;
        private System.Windows.Forms.Label lblBuyAmount;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtBuyVarAmount;
        private System.Windows.Forms.Label lblBuyVarAmount;
        private System.Windows.Forms.Label lblBuyVarTrend;
        private System.Windows.Forms.ComboBox cbxBuyVarTrend;
        private System.Windows.Forms.GroupBox gbxSale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSaleVarAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSaleVarTrend;
        private System.Windows.Forms.ComboBox cbxSaleVarTrend;
        private System.Windows.Forms.TextBox txtSaleAmount;
        private System.Windows.Forms.Label lblSaleAmount;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label lblSalePrice;
    }
}