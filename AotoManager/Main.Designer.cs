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
            this.btnAverage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkLimitTime = new System.Windows.Forms.CheckBox();
            this.lblBeginTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtBeginTime = new System.Windows.Forms.DateTimePicker();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.StockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockCode,
            this.StockName,
            this.BuyPrice,
            this.BuyAmount});
            this.dataGrid.Location = new System.Drawing.Point(12, 165);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(907, 288);
            this.dataGrid.TabIndex = 7;
            this.dataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEndEdit);
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
            // btnGetInfo
            // 
            this.btnGetInfo.Location = new System.Drawing.Point(751, 116);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(75, 23);
            this.btnGetInfo.TabIndex = 18;
            this.btnGetInfo.Text = "button2";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
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
            this.BuyAmount.ReadOnly = true;
            this.BuyAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 585);
            this.Controls.Add(this.btnGetInfo);
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
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyAmount;
    }
}

