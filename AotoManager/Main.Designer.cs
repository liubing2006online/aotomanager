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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnUpload = new System.Windows.Forms.Button();
            this.openFileDialogUpload = new System.Windows.Forms.OpenFileDialog();
            this.lblAK = new System.Windows.Forms.Label();
            this.txtAK = new System.Windows.Forms.TextBox();
            this.lblSK = new System.Windows.Forms.Label();
            this.txtSK = new System.Windows.Forms.TextBox();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.StockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyStrategy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleStrategy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyVariableTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyVariableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleVariableTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleVariableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyMarkPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleMarkPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAverage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkLimitBuyTime = new System.Windows.Forms.CheckBox();
            this.lblBuyBeginTime = new System.Windows.Forms.Label();
            this.lblBuyEndTime = new System.Windows.Forms.Label();
            this.dtBuyBeginTime = new System.Windows.Forms.DateTimePicker();
            this.dtBuyEndTime = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cbxSoft = new System.Windows.Forms.ComboBox();
            this.btnSetFull = new System.Windows.Forms.Button();
            this.btnCloseComputer = new System.Windows.Forms.Button();
            this.chkGapLower = new System.Windows.Forms.CheckBox();
            this.dtSaleEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtSaleBeginTime = new System.Windows.Forms.DateTimePicker();
            this.lblSaleEndTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkLimitSaleTime = new System.Windows.Forms.CheckBox();
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
            // lblSK
            // 
            this.lblSK.AutoSize = true;
            this.lblSK.Location = new System.Drawing.Point(49, 71);
            this.lblSK.Name = "lblSK";
            this.lblSK.Size = new System.Drawing.Size(59, 12);
            this.lblSK.TabIndex = 4;
            this.lblSK.Text = "SecretKey";
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
            this.txtBalance.MaxLength = 10;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(116, 26);
            this.txtBalance.TabIndex = 9;
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockCode,
            this.StockName,
            this.CurrentPrice,
            this.Monitor,
            this.BuyPrice,
            this.BuyAmount,
            this.BuyStrategy,
            this.SalePrice,
            this.SaleAmount,
            this.SaleStrategy,
            this.BuyVariableTrend,
            this.BuyVariableAmount,
            this.SaleVariableTrend,
            this.SaleVariableAmount,
            this.BuyMarkPrice,
            this.SaleMarkPrice});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Location = new System.Drawing.Point(12, 165);
            this.dataGrid.Name = "dataGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(1034, 304);
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
            // 
            // SaleAmount
            // 
            this.SaleAmount.DataPropertyName = "SaleAmount";
            this.SaleAmount.HeaderText = "卖出数量";
            this.SaleAmount.Name = "SaleAmount";
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
            // BuyVariableAmount
            // 
            this.BuyVariableAmount.DataPropertyName = "BuyVariableAmount";
            this.BuyVariableAmount.HeaderText = "买入变化数量";
            this.BuyVariableAmount.Name = "BuyVariableAmount";
            this.BuyVariableAmount.ReadOnly = true;
            this.BuyVariableAmount.Visible = false;
            // 
            // SaleVariableTrend
            // 
            this.SaleVariableTrend.DataPropertyName = "SaleVariableTrend";
            this.SaleVariableTrend.HeaderText = "卖出变化趋势";
            this.SaleVariableTrend.Name = "SaleVariableTrend";
            this.SaleVariableTrend.ReadOnly = true;
            this.SaleVariableTrend.Visible = false;
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
            this.btnSave.Location = new System.Drawing.Point(43, 552);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkLimitBuyTime
            // 
            this.chkLimitBuyTime.AutoSize = true;
            this.chkLimitBuyTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkLimitBuyTime.Location = new System.Drawing.Point(49, 477);
            this.chkLimitBuyTime.Name = "chkLimitBuyTime";
            this.chkLimitBuyTime.Size = new System.Drawing.Size(123, 20);
            this.chkLimitBuyTime.TabIndex = 13;
            this.chkLimitBuyTime.Text = "限定买入时间";
            this.chkLimitBuyTime.UseVisualStyleBackColor = true;
            // 
            // lblBuyBeginTime
            // 
            this.lblBuyBeginTime.AutoSize = true;
            this.lblBuyBeginTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBuyBeginTime.Location = new System.Drawing.Point(206, 477);
            this.lblBuyBeginTime.Name = "lblBuyBeginTime";
            this.lblBuyBeginTime.Size = new System.Drawing.Size(104, 16);
            this.lblBuyBeginTime.TabIndex = 14;
            this.lblBuyBeginTime.Text = "买入开始时间";
            // 
            // lblBuyEndTime
            // 
            this.lblBuyEndTime.AutoSize = true;
            this.lblBuyEndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBuyEndTime.Location = new System.Drawing.Point(419, 477);
            this.lblBuyEndTime.Name = "lblBuyEndTime";
            this.lblBuyEndTime.Size = new System.Drawing.Size(104, 16);
            this.lblBuyEndTime.TabIndex = 15;
            this.lblBuyEndTime.Text = "买入结束时间";
            // 
            // dtBuyBeginTime
            // 
            this.dtBuyBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtBuyBeginTime.Location = new System.Drawing.Point(316, 475);
            this.dtBuyBeginTime.Name = "dtBuyBeginTime";
            this.dtBuyBeginTime.Size = new System.Drawing.Size(97, 21);
            this.dtBuyBeginTime.TabIndex = 16;
            this.dtBuyBeginTime.Value = new System.DateTime(2017, 3, 18, 9, 31, 0, 0);
            // 
            // dtBuyEndTime
            // 
            this.dtBuyEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtBuyEndTime.Location = new System.Drawing.Point(529, 475);
            this.dtBuyEndTime.Name = "dtBuyEndTime";
            this.dtBuyEndTime.Size = new System.Drawing.Size(97, 21);
            this.dtBuyEndTime.TabIndex = 17;
            this.dtBuyEndTime.Value = new System.DateTime(2017, 3, 18, 14, 59, 30, 0);
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
            this.btnStop.Location = new System.Drawing.Point(301, 552);
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
            this.lblMonitor.Location = new System.Drawing.Point(405, 557);
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
            // dtSaleEndTime
            // 
            this.dtSaleEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtSaleEndTime.Location = new System.Drawing.Point(529, 505);
            this.dtSaleEndTime.Name = "dtSaleEndTime";
            this.dtSaleEndTime.Size = new System.Drawing.Size(97, 21);
            this.dtSaleEndTime.TabIndex = 29;
            this.dtSaleEndTime.Value = new System.DateTime(2017, 3, 18, 14, 59, 30, 0);
            // 
            // dtSaleBeginTime
            // 
            this.dtSaleBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtSaleBeginTime.Location = new System.Drawing.Point(316, 505);
            this.dtSaleBeginTime.Name = "dtSaleBeginTime";
            this.dtSaleBeginTime.Size = new System.Drawing.Size(97, 21);
            this.dtSaleBeginTime.TabIndex = 28;
            this.dtSaleBeginTime.Value = new System.DateTime(2017, 3, 18, 9, 31, 0, 0);
            // 
            // lblSaleEndTime
            // 
            this.lblSaleEndTime.AutoSize = true;
            this.lblSaleEndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSaleEndTime.Location = new System.Drawing.Point(419, 507);
            this.lblSaleEndTime.Name = "lblSaleEndTime";
            this.lblSaleEndTime.Size = new System.Drawing.Size(104, 16);
            this.lblSaleEndTime.TabIndex = 27;
            this.lblSaleEndTime.Text = "卖出结束时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(206, 507);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "卖出开始时间";
            // 
            // chkLimitSaleTime
            // 
            this.chkLimitSaleTime.AutoSize = true;
            this.chkLimitSaleTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkLimitSaleTime.Location = new System.Drawing.Point(49, 507);
            this.chkLimitSaleTime.Name = "chkLimitSaleTime";
            this.chkLimitSaleTime.Size = new System.Drawing.Size(123, 20);
            this.chkLimitSaleTime.TabIndex = 25;
            this.chkLimitSaleTime.Text = "限定卖出时间";
            this.chkLimitSaleTime.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 641);
            this.Controls.Add(this.dtSaleEndTime);
            this.Controls.Add(this.dtSaleBeginTime);
            this.Controls.Add(this.lblSaleEndTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkLimitSaleTime);
            this.Controls.Add(this.chkGapLower);
            this.Controls.Add(this.btnCloseComputer);
            this.Controls.Add(this.btnSetFull);
            this.Controls.Add(this.cbxSoft);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblMonitor);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.dtBuyEndTime);
            this.Controls.Add(this.dtBuyBeginTime);
            this.Controls.Add(this.lblBuyEndTime);
            this.Controls.Add(this.lblBuyBeginTime);
            this.Controls.Add(this.chkLimitBuyTime);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAverage);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.txtSK);
            this.Controls.Add(this.lblSK);
            this.Controls.Add(this.txtAK);
            this.Controls.Add(this.lblAK);
            this.Controls.Add(this.btnUpload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lblSK;
        private System.Windows.Forms.TextBox txtSK;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnAverage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkLimitBuyTime;
        private System.Windows.Forms.Label lblBuyBeginTime;
        private System.Windows.Forms.Label lblBuyEndTime;
        private System.Windows.Forms.DateTimePicker dtBuyBeginTime;
        private System.Windows.Forms.DateTimePicker dtBuyEndTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblMonitor;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ComboBox cbxSoft;
        private System.Windows.Forms.Button btnSetFull;
        private System.Windows.Forms.Button btnCloseComputer;
        private System.Windows.Forms.CheckBox chkGapLower;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyStrategy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleStrategy;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyVariableTrend;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyVariableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleVariableTrend;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleVariableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyMarkPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleMarkPrice;
        private System.Windows.Forms.DateTimePicker dtSaleEndTime;
        private System.Windows.Forms.DateTimePicker dtSaleBeginTime;
        private System.Windows.Forms.Label lblSaleEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkLimitSaleTime;
    }
}

