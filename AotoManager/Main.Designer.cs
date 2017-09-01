namespace AotoManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnUpload = new System.Windows.Forms.Button();
            this.openFileDialogUpload = new System.Windows.Forms.OpenFileDialog();
            this.lblAK = new System.Windows.Forms.Label();
            this.txtAK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSK = new System.Windows.Forms.TextBox();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.StockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAverage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkLimitTime = new System.Windows.Forms.CheckBox();
            this.lblBeginTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtBeginTime = new System.Windows.Forms.DateTimePicker();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cbxSoft = new System.Windows.Forms.ComboBox();
            this.btnSetFull = new System.Windows.Forms.Button();
            this.btnCloseComputer = new System.Windows.Forms.Button();
            this.chkGapLower = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(612, 114);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(85, 30);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // openFileDialogUpload
            // 
            this.openFileDialogUpload.FileName = "openFileDialog1";
            // 
            // lblAK
            // 
            this.lblAK.AutoSize = true;
            this.lblAK.Location = new System.Drawing.Point(47, 25);
            this.lblAK.Name = "lblAK";
            this.lblAK.Size = new System.Drawing.Size(59, 12);
            this.lblAK.TabIndex = 2;
            this.lblAK.Text = "AccessKey";
            // 
            // txtAK
            // 
            this.txtAK.Location = new System.Drawing.Point(134, 22);
            this.txtAK.Name = "txtAK";
            this.txtAK.Size = new System.Drawing.Size(213, 21);
            this.txtAK.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "SecurityKey";
            // 
            // txtSK
            // 
            this.txtSK.Location = new System.Drawing.Point(134, 61);
            this.txtSK.Name = "txtSK";
            this.txtSK.Size = new System.Drawing.Size(213, 21);
            this.txtSK.TabIndex = 5;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(301, 112);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(85, 32);
            this.btnDownLoad.TabIndex = 6;
            this.btnDownLoad.Text = "DownLoad";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBalance.Location = new System.Drawing.Point(48, 119);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(72, 16);
            this.lblBalance.TabIndex = 8;
            this.lblBalance.Text = "可用余额";
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBalance.Location = new System.Drawing.Point(126, 116);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(116, 26);
            this.txtBalance.TabIndex = 9;
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockCode,
            this.StockName,
            this.BuyPrice,
            this.BuyAmount,
            this.CurrentPrice,
            this.Monitor});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.Location = new System.Drawing.Point(12, 165);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(907, 288);
            this.dataGrid.TabIndex = 7;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            this.dataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEndEdit);
            this.dataGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGrid_KeyUp);
            // 
            // StockCode
            // 
            this.StockCode.DataPropertyName = "StockCode";
            this.StockCode.HeaderText = "证券代码";
            this.StockCode.MaxInputLength = 6;
            this.StockCode.Name = "StockCode";
            // 
            // StockName
            // 
            this.StockName.DataPropertyName = "StockName";
            this.StockName.HeaderText = "证券名称";
            this.StockName.Name = "StockName";
            this.StockName.ReadOnly = true;
            // 
            // BuyPrice
            // 
            this.BuyPrice.DataPropertyName = "BuyPrice";
            this.BuyPrice.HeaderText = "买入价格";
            this.BuyPrice.Name = "BuyPrice";
            // 
            // BuyAmount
            // 
            this.BuyAmount.DataPropertyName = "BuyAmount";
            this.BuyAmount.HeaderText = "买入数量";
            this.BuyAmount.Name = "BuyAmount";
            this.BuyAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CurrentPrice
            // 
            this.CurrentPrice.DataPropertyName = "CurrentPrice";
            this.CurrentPrice.HeaderText = "当前价格";
            this.CurrentPrice.Name = "CurrentPrice";
            this.CurrentPrice.ReadOnly = true;
            this.CurrentPrice.Visible = false;
            // 
            // Monitor
            // 
            this.Monitor.DataPropertyName = "Monitor";
            this.Monitor.HeaderText = "监控状态";
            this.Monitor.Name = "Monitor";
            this.Monitor.ReadOnly = true;
            this.Monitor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnAverage
            // 
            this.btnAverage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAverage.Location = new System.Drawing.Point(408, 114);
            this.btnAverage.Name = "btnAverage";
            this.btnAverage.Size = new System.Drawing.Size(180, 30);
            this.btnAverage.TabIndex = 10;
            this.btnAverage.Text = "平均配置资金仓位";
            this.btnAverage.UseVisualStyleBackColor = true;
            this.btnAverage.Click += new System.EventHandler(this.btnAverage_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(43, 521);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkLimitTime
            // 
            this.chkLimitTime.AutoSize = true;
            this.chkLimitTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkLimitTime.Location = new System.Drawing.Point(49, 477);
            this.chkLimitTime.Name = "chkLimitTime";
            this.chkLimitTime.Size = new System.Drawing.Size(123, 20);
            this.chkLimitTime.TabIndex = 13;
            this.chkLimitTime.Text = "限定买入时间";
            this.chkLimitTime.UseVisualStyleBackColor = true;
            // 
            // lblBeginTime
            // 
            this.lblBeginTime.AutoSize = true;
            this.lblBeginTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBeginTime.Location = new System.Drawing.Point(206, 477);
            this.lblBeginTime.Name = "lblBeginTime";
            this.lblBeginTime.Size = new System.Drawing.Size(104, 16);
            this.lblBeginTime.TabIndex = 14;
            this.lblBeginTime.Text = "买入开始时间";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndTime.Location = new System.Drawing.Point(419, 477);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(104, 16);
            this.lblEndTime.TabIndex = 15;
            this.lblEndTime.Text = "买入结束时间";
            // 
            // dtBeginTime
            // 
            this.dtBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtBeginTime.Location = new System.Drawing.Point(316, 475);
            this.dtBeginTime.Name = "dtBeginTime";
            this.dtBeginTime.Size = new System.Drawing.Size(97, 21);
            this.dtBeginTime.TabIndex = 16;
            this.dtBeginTime.Value = new System.DateTime(2017, 3, 18, 9, 31, 0, 0);
            // 
            // dtEndTime
            // 
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEndTime.Location = new System.Drawing.Point(529, 475);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(97, 21);
            this.dtEndTime.TabIndex = 17;
            this.dtEndTime.Value = new System.DateTime(2017, 3, 18, 14, 59, 30, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(301, 521);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(84, 30);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "停止监控";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblMonitor
            // 
            this.lblMonitor.AutoSize = true;
            this.lblMonitor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMonitor.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblMonitor.Location = new System.Drawing.Point(405, 526);
            this.lblMonitor.Name = "lblMonitor";
            this.lblMonitor.Size = new System.Drawing.Size(96, 16);
            this.lblMonitor.TabIndex = 19;
            this.lblMonitor.Text = "正在监控...";
            this.lblMonitor.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMessage.Location = new System.Drawing.Point(413, 30);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 20;
            // 
            // cbxSoft
            // 
            this.cbxSoft.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxSoft.FormattingEnabled = true;
            this.cbxSoft.Items.AddRange(new object[] {
            "招商智远",
            "10JQKA"});
            this.cbxSoft.Location = new System.Drawing.Point(752, 116);
            this.cbxSoft.Name = "cbxSoft";
            this.cbxSoft.Size = new System.Drawing.Size(124, 24);
            this.cbxSoft.TabIndex = 21;
            // 
            // btnSetFull
            // 
            this.btnSetFull.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetFull.Location = new System.Drawing.Point(408, 71);
            this.btnSetFull.Name = "btnSetFull";
            this.btnSetFull.Size = new System.Drawing.Size(180, 30);
            this.btnSetFull.TabIndex = 22;
            this.btnSetFull.Text = "每个品种配置全仓";
            this.btnSetFull.UseVisualStyleBackColor = true;
            this.btnSetFull.Click += new System.EventHandler(this.btnSetFull_Click);
            // 
            // btnCloseComputer
            // 
            this.btnCloseComputer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseComputer.Location = new System.Drawing.Point(763, 16);
            this.btnCloseComputer.Name = "btnCloseComputer";
            this.btnCloseComputer.Size = new System.Drawing.Size(102, 30);
            this.btnCloseComputer.TabIndex = 23;
            this.btnCloseComputer.Text = "关闭电脑";
            this.btnCloseComputer.UseVisualStyleBackColor = true;
            this.btnCloseComputer.Click += new System.EventHandler(this.btnCloseComputer_Click);
            // 
            // chkGapLower
            // 
            this.chkGapLower.AutoSize = true;
            this.chkGapLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkGapLower.Location = new System.Drawing.Point(676, 477);
            this.chkGapLower.Name = "chkGapLower";
            this.chkGapLower.Size = new System.Drawing.Size(91, 20);
            this.chkGapLower.TabIndex = 24;
            this.chkGapLower.Text = "跳空低开";
            this.chkGapLower.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 585);
            this.Controls.Add(this.chkGapLower);
            this.Controls.Add(this.btnCloseComputer);
            this.Controls.Add(this.btnSetFull);
            this.Controls.Add(this.cbxSoft);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblMonitor);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.dtEndTime);
            this.Controls.Add(this.dtBeginTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblBeginTime);
            this.Controls.Add(this.chkLimitTime);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAverage);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.txtSK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAK);
            this.Controls.Add(this.lblAK);
            this.Controls.Add(this.btnUpload);
            this.Name = "Main";
            this.Text = "AotoManager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialogUpload;
        private System.Windows.Forms.Label lblAK;
        private System.Windows.Forms.TextBox txtAK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSK;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnAverage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkLimitTime;
        private System.Windows.Forms.Label lblBeginTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtBeginTime;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monitor;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ComboBox cbxSoft;
        private System.Windows.Forms.Button btnSetFull;
        private System.Windows.Forms.Button btnCloseComputer;
        private System.Windows.Forms.CheckBox chkGapLower;
    }
}

