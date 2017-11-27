namespace AotoTrade
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDownload = new System.Windows.Forms.Button();
            this.dtBuyEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtBuyBeginTime = new System.Windows.Forms.DateTimePicker();
            this.lblBuyEndTime = new System.Windows.Forms.Label();
            this.lblBuyBeginTime = new System.Windows.Forms.Label();
            this.chkLimitBuyTime = new System.Windows.Forms.CheckBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.StockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyStrategy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleStrategy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyVariableTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleVariableTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyVariableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleVariableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyMarkPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleMarkPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.cbxSoft = new System.Windows.Forms.ComboBox();
            this.chkGapLower = new System.Windows.Forms.CheckBox();
            this.dtSaleEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtSaleBeginTime = new System.Windows.Forms.DateTimePicker();
            this.lblSaleEndTime = new System.Windows.Forms.Label();
            this.lblSaleBeginTime = new System.Windows.Forms.Label();
            this.chkLimitSaleTime = new System.Windows.Forms.CheckBox();
            this.btnSetting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(32, 24);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(81, 29);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "下载文件";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dtBuyEndTime
            // 
            this.dtBuyEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtBuyEndTime.Location = new System.Drawing.Point(510, 428);
            this.dtBuyEndTime.Name = "dtBuyEndTime";
            this.dtBuyEndTime.Size = new System.Drawing.Size(97, 21);
            this.dtBuyEndTime.TabIndex = 25;
            this.dtBuyEndTime.Value = new System.DateTime(2017, 3, 18, 14, 59, 30, 0);
            // 
            // dtBuyBeginTime
            // 
            this.dtBuyBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtBuyBeginTime.Location = new System.Drawing.Point(297, 428);
            this.dtBuyBeginTime.Name = "dtBuyBeginTime";
            this.dtBuyBeginTime.Size = new System.Drawing.Size(97, 21);
            this.dtBuyBeginTime.TabIndex = 24;
            this.dtBuyBeginTime.Value = new System.DateTime(2017, 3, 18, 9, 31, 0, 0);
            // 
            // lblBuyEndTime
            // 
            this.lblBuyEndTime.AutoSize = true;
            this.lblBuyEndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBuyEndTime.Location = new System.Drawing.Point(400, 430);
            this.lblBuyEndTime.Name = "lblBuyEndTime";
            this.lblBuyEndTime.Size = new System.Drawing.Size(104, 16);
            this.lblBuyEndTime.TabIndex = 23;
            this.lblBuyEndTime.Text = "买入结束时间";
            // 
            // lblBuyBeginTime
            // 
            this.lblBuyBeginTime.AutoSize = true;
            this.lblBuyBeginTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBuyBeginTime.Location = new System.Drawing.Point(187, 430);
            this.lblBuyBeginTime.Name = "lblBuyBeginTime";
            this.lblBuyBeginTime.Size = new System.Drawing.Size(104, 16);
            this.lblBuyBeginTime.TabIndex = 22;
            this.lblBuyBeginTime.Text = "买入开始时间";
            // 
            // chkLimitBuyTime
            // 
            this.chkLimitBuyTime.AutoSize = true;
            this.chkLimitBuyTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkLimitBuyTime.Location = new System.Drawing.Point(30, 430);
            this.chkLimitBuyTime.Name = "chkLimitBuyTime";
            this.chkLimitBuyTime.Size = new System.Drawing.Size(123, 20);
            this.chkLimitBuyTime.TabIndex = 21;
            this.chkLimitBuyTime.Text = "限定买入时间";
            this.chkLimitBuyTime.UseVisualStyleBackColor = true;
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBalance.Location = new System.Drawing.Point(107, 69);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(116, 26);
            this.txtBalance.TabIndex = 20;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBalance.Location = new System.Drawing.Point(29, 72);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(72, 16);
            this.lblBalance.TabIndex = 19;
            this.lblBalance.Text = "可用余额";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockCode,
            this.StockName,
            this.Monitor,
            this.CurrentPrice,
            this.BuyPrice,
            this.BuyAmount,
            this.BuyStrategy,
            this.SalePrice,
            this.SaleAmount,
            this.SaleStrategy,
            this.BuyVariableTrend,
            this.SaleVariableTrend,
            this.BuyVariableAmount,
            this.SaleVariableAmount,
            this.BuyMarkPrice,
            this.SaleMarkPrice});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGrid.Location = new System.Drawing.Point(-7, 118);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F);
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(1141, 288);
            this.dataGrid.TabIndex = 18;
            // 
            // StockCode
            // 
            this.StockCode.DataPropertyName = "StockCode";
            this.StockCode.HeaderText = "证券代码";
            this.StockCode.MaxInputLength = 6;
            this.StockCode.Name = "StockCode";
            this.StockCode.ReadOnly = true;
            // 
            // StockName
            // 
            this.StockName.DataPropertyName = "StockName";
            this.StockName.HeaderText = "证券名称";
            this.StockName.Name = "StockName";
            this.StockName.ReadOnly = true;
            // 
            // Monitor
            // 
            this.Monitor.DataPropertyName = "Monitor";
            this.Monitor.HeaderText = "监控状态";
            this.Monitor.Name = "Monitor";
            this.Monitor.ReadOnly = true;
            // 
            // CurrentPrice
            // 
            this.CurrentPrice.DataPropertyName = "CurrentPrice";
            this.CurrentPrice.HeaderText = "当前价格";
            this.CurrentPrice.Name = "CurrentPrice";
            this.CurrentPrice.ReadOnly = true;
            // 
            // BuyPrice
            // 
            this.BuyPrice.DataPropertyName = "BuyPrice";
            this.BuyPrice.HeaderText = "买入价格";
            this.BuyPrice.Name = "BuyPrice";
            this.BuyPrice.ReadOnly = true;
            // 
            // BuyAmount
            // 
            this.BuyAmount.DataPropertyName = "BuyAmount";
            this.BuyAmount.HeaderText = "买入数量";
            this.BuyAmount.Name = "BuyAmount";
            this.BuyAmount.ReadOnly = true;
            this.BuyAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BuyStrategy
            // 
            this.BuyStrategy.DataPropertyName = "BuyStrategy";
            this.BuyStrategy.HeaderText = "买入策略";
            this.BuyStrategy.Name = "BuyStrategy";
            this.BuyStrategy.ReadOnly = true;
            this.BuyStrategy.Width = 150;
            // 
            // SalePrice
            // 
            this.SalePrice.DataPropertyName = "SalePrice";
            this.SalePrice.HeaderText = "卖出价格";
            this.SalePrice.Name = "SalePrice";
            this.SalePrice.ReadOnly = true;
            // 
            // SaleAmount
            // 
            this.SaleAmount.DataPropertyName = "SaleAmount";
            this.SaleAmount.HeaderText = "卖出数量";
            this.SaleAmount.Name = "SaleAmount";
            this.SaleAmount.ReadOnly = true;
            // 
            // SaleStrategy
            // 
            this.SaleStrategy.DataPropertyName = "SaleStrategy";
            this.SaleStrategy.HeaderText = "卖出策略";
            this.SaleStrategy.Name = "SaleStrategy";
            this.SaleStrategy.ReadOnly = true;
            this.SaleStrategy.Width = 150;
            // 
            // BuyVariableTrend
            // 
            this.BuyVariableTrend.DataPropertyName = "BuyVariableTrend";
            this.BuyVariableTrend.HeaderText = "买入变化趋势";
            this.BuyVariableTrend.Name = "BuyVariableTrend";
            this.BuyVariableTrend.ReadOnly = true;
            this.BuyVariableTrend.Visible = false;
            // 
            // SaleVariableTrend
            // 
            this.SaleVariableTrend.DataPropertyName = "SaleVariableTrend";
            this.SaleVariableTrend.HeaderText = "卖出变化趋势";
            this.SaleVariableTrend.Name = "SaleVariableTrend";
            this.SaleVariableTrend.ReadOnly = true;
            this.SaleVariableTrend.Visible = false;
            // 
            // BuyVariableAmount
            // 
            this.BuyVariableAmount.DataPropertyName = "BuyVariableAmount";
            this.BuyVariableAmount.HeaderText = "买入变化数量";
            this.BuyVariableAmount.Name = "BuyVariableAmount";
            this.BuyVariableAmount.ReadOnly = true;
            this.BuyVariableAmount.Visible = false;
            // 
            // SaleVariableAmount
            // 
            this.SaleVariableAmount.DataPropertyName = "SaleVariableAmount";
            this.SaleVariableAmount.HeaderText = "卖出变化数量";
            this.SaleVariableAmount.Name = "SaleVariableAmount";
            this.SaleVariableAmount.ReadOnly = true;
            this.SaleVariableAmount.Visible = false;
            // 
            // BuyMarkPrice
            // 
            this.BuyMarkPrice.DataPropertyName = "BuyMarkPrice";
            this.BuyMarkPrice.HeaderText = "买入标记价格";
            this.BuyMarkPrice.Name = "BuyMarkPrice";
            this.BuyMarkPrice.ReadOnly = true;
            this.BuyMarkPrice.Visible = false;
            // 
            // SaleMarkPrice
            // 
            this.SaleMarkPrice.DataPropertyName = "SaleMarkPrice";
            this.SaleMarkPrice.HeaderText = "卖出标记价格";
            this.SaleMarkPrice.Name = "SaleMarkPrice";
            this.SaleMarkPrice.ReadOnly = true;
            this.SaleMarkPrice.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMessage.Location = new System.Drawing.Point(445, 76);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 26;
            // 
            // lblMonitor
            // 
            this.lblMonitor.AutoSize = true;
            this.lblMonitor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMonitor.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblMonitor.Location = new System.Drawing.Point(374, 507);
            this.lblMonitor.Name = "lblMonitor";
            this.lblMonitor.Size = new System.Drawing.Size(96, 16);
            this.lblMonitor.TabIndex = 27;
            this.lblMonitor.Text = "正在监控...";
            this.lblMonitor.Visible = false;
            // 
            // cbxSoft
            // 
            this.cbxSoft.Enabled = false;
            this.cbxSoft.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxSoft.FormattingEnabled = true;
            this.cbxSoft.Items.AddRange(new object[] {
            "招商智远",
            "10JQKA"});
            this.cbxSoft.Location = new System.Drawing.Point(270, 70);
            this.cbxSoft.Name = "cbxSoft";
            this.cbxSoft.Size = new System.Drawing.Size(124, 24);
            this.cbxSoft.TabIndex = 28;
            // 
            // chkGapLower
            // 
            this.chkGapLower.AutoSize = true;
            this.chkGapLower.Enabled = false;
            this.chkGapLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkGapLower.Location = new System.Drawing.Point(659, 430);
            this.chkGapLower.Name = "chkGapLower";
            this.chkGapLower.Size = new System.Drawing.Size(91, 20);
            this.chkGapLower.TabIndex = 29;
            this.chkGapLower.Text = "跳空低开";
            this.chkGapLower.UseVisualStyleBackColor = true;
            // 
            // dtSaleEndTime
            // 
            this.dtSaleEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtSaleEndTime.Location = new System.Drawing.Point(510, 454);
            this.dtSaleEndTime.Name = "dtSaleEndTime";
            this.dtSaleEndTime.Size = new System.Drawing.Size(97, 21);
            this.dtSaleEndTime.TabIndex = 34;
            this.dtSaleEndTime.Value = new System.DateTime(2017, 3, 18, 14, 59, 30, 0);
            // 
            // dtSaleBeginTime
            // 
            this.dtSaleBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtSaleBeginTime.Location = new System.Drawing.Point(297, 454);
            this.dtSaleBeginTime.Name = "dtSaleBeginTime";
            this.dtSaleBeginTime.Size = new System.Drawing.Size(97, 21);
            this.dtSaleBeginTime.TabIndex = 33;
            this.dtSaleBeginTime.Value = new System.DateTime(2017, 3, 18, 9, 31, 0, 0);
            // 
            // lblSaleEndTime
            // 
            this.lblSaleEndTime.AutoSize = true;
            this.lblSaleEndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSaleEndTime.Location = new System.Drawing.Point(400, 456);
            this.lblSaleEndTime.Name = "lblSaleEndTime";
            this.lblSaleEndTime.Size = new System.Drawing.Size(104, 16);
            this.lblSaleEndTime.TabIndex = 32;
            this.lblSaleEndTime.Text = "卖出结束时间";
            // 
            // lblSaleBeginTime
            // 
            this.lblSaleBeginTime.AutoSize = true;
            this.lblSaleBeginTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSaleBeginTime.Location = new System.Drawing.Point(187, 456);
            this.lblSaleBeginTime.Name = "lblSaleBeginTime";
            this.lblSaleBeginTime.Size = new System.Drawing.Size(104, 16);
            this.lblSaleBeginTime.TabIndex = 31;
            this.lblSaleBeginTime.Text = "卖出开始时间";
            // 
            // chkLimitSaleTime
            // 
            this.chkLimitSaleTime.AutoSize = true;
            this.chkLimitSaleTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkLimitSaleTime.Location = new System.Drawing.Point(30, 456);
            this.chkLimitSaleTime.Name = "chkLimitSaleTime";
            this.chkLimitSaleTime.Size = new System.Drawing.Size(123, 20);
            this.chkLimitSaleTime.TabIndex = 30;
            this.chkLimitSaleTime.Text = "限定卖出时间";
            this.chkLimitSaleTime.UseVisualStyleBackColor = true;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(986, 24);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(81, 29);
            this.btnSetting.TabIndex = 35;
            this.btnSetting.Text = "配置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 560);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.dtSaleEndTime);
            this.Controls.Add(this.dtSaleBeginTime);
            this.Controls.Add(this.lblSaleEndTime);
            this.Controls.Add(this.lblSaleBeginTime);
            this.Controls.Add(this.chkLimitSaleTime);
            this.Controls.Add(this.chkGapLower);
            this.Controls.Add(this.cbxSoft);
            this.Controls.Add(this.lblMonitor);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dtBuyEndTime);
            this.Controls.Add(this.dtBuyBeginTime);
            this.Controls.Add(this.lblBuyEndTime);
            this.Controls.Add(this.lblBuyBeginTime);
            this.Controls.Add(this.chkLimitBuyTime);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.btnDownload);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AotoTD";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DateTimePicker dtBuyEndTime;
        private System.Windows.Forms.DateTimePicker dtBuyBeginTime;
        private System.Windows.Forms.Label lblBuyEndTime;
        private System.Windows.Forms.Label lblBuyBeginTime;
        private System.Windows.Forms.CheckBox chkLimitBuyTime;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblMonitor;
        private System.Windows.Forms.ComboBox cbxSoft;
        private System.Windows.Forms.CheckBox chkGapLower;
        private System.Windows.Forms.DateTimePicker dtSaleEndTime;
        private System.Windows.Forms.DateTimePicker dtSaleBeginTime;
        private System.Windows.Forms.Label lblSaleEndTime;
        private System.Windows.Forms.Label lblSaleBeginTime;
        private System.Windows.Forms.CheckBox chkLimitSaleTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyStrategy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleStrategy;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyVariableTrend;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleVariableTrend;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyVariableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleVariableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyMarkPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleMarkPrice;
        private System.Windows.Forms.Button btnSetting;
    }
}

