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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtVarAmount = new System.Windows.Forms.TextBox();
            this.lblVarAmount = new System.Windows.Forms.Label();
            this.lblVarTrend = new System.Windows.Forms.Label();
            this.cbxVarTrend = new System.Windows.Forms.ComboBox();
            this.txtBuyAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxBuyAmount = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUnit);
            this.groupBox1.Controls.Add(this.txtVarAmount);
            this.groupBox1.Controls.Add(this.lblVarAmount);
            this.groupBox1.Controls.Add(this.lblVarTrend);
            this.groupBox1.Controls.Add(this.cbxVarTrend);
            this.groupBox1.Controls.Add(this.txtBuyAmount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxBuyAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBuyPrice);
            this.groupBox1.Controls.Add(this.lblBuyPrice);
            this.groupBox1.Location = new System.Drawing.Point(12, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 333);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "买入参数";
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
            // txtVarAmount
            // 
            this.txtVarAmount.Location = new System.Drawing.Point(82, 74);
            this.txtVarAmount.Name = "txtVarAmount";
            this.txtVarAmount.Size = new System.Drawing.Size(51, 21);
            this.txtVarAmount.TabIndex = 12;
            this.txtVarAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarAmount_KeyPress);
            // 
            // lblVarAmount
            // 
            this.lblVarAmount.AutoSize = true;
            this.lblVarAmount.Location = new System.Drawing.Point(11, 77);
            this.lblVarAmount.Name = "lblVarAmount";
            this.lblVarAmount.Size = new System.Drawing.Size(65, 12);
            this.lblVarAmount.TabIndex = 11;
            this.lblVarAmount.Text = "变化数量：";
            // 
            // lblVarTrend
            // 
            this.lblVarTrend.AutoSize = true;
            this.lblVarTrend.Location = new System.Drawing.Point(11, 48);
            this.lblVarTrend.Name = "lblVarTrend";
            this.lblVarTrend.Size = new System.Drawing.Size(65, 12);
            this.lblVarTrend.TabIndex = 10;
            this.lblVarTrend.Text = "变化趋势：";
            // 
            // cbxVarTrend
            // 
            this.cbxVarTrend.FormattingEnabled = true;
            this.cbxVarTrend.Location = new System.Drawing.Point(82, 45);
            this.cbxVarTrend.Name = "cbxVarTrend";
            this.cbxVarTrend.Size = new System.Drawing.Size(95, 20);
            this.cbxVarTrend.TabIndex = 9;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "实际买入数量：";
            // 
            // cbxBuyAmount
            // 
            this.cbxBuyAmount.FormattingEnabled = true;
            this.cbxBuyAmount.Location = new System.Drawing.Point(93, 147);
            this.cbxBuyAmount.Name = "cbxBuyAmount";
            this.cbxBuyAmount.Size = new System.Drawing.Size(130, 20);
            this.cbxBuyAmount.TabIndex = 6;
            this.cbxBuyAmount.DropDownClosed += new System.EventHandler(this.cbxBuyAmount_DropDownClosed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "可选买入数量：";
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
            // MdiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 529);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Name = "MdiForm";
            this.Text = "修改信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.ComboBox cbxBuyAmount;
        private System.Windows.Forms.TextBox txtBuyAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtVarAmount;
        private System.Windows.Forms.Label lblVarAmount;
        private System.Windows.Forms.Label lblVarTrend;
        private System.Windows.Forms.ComboBox cbxVarTrend;
    }
}