namespace AotoTrade
{
    partial class SettingForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAK = new System.Windows.Forms.Label();
            this.lblSK = new System.Windows.Forms.Label();
            this.txtAK = new System.Windows.Forms.TextBox();
            this.txtSK = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblSendAddress = new System.Windows.Forms.Label();
            this.txtSendAddress = new System.Windows.Forms.TextBox();
            this.lblBucket = new System.Windows.Forms.Label();
            this.txtBucket = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(99, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(214, 458);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAK
            // 
            this.lblAK.AutoSize = true;
            this.lblAK.Location = new System.Drawing.Point(42, 29);
            this.lblAK.Name = "lblAK";
            this.lblAK.Size = new System.Drawing.Size(59, 12);
            this.lblAK.TabIndex = 2;
            this.lblAK.Text = "AccessKey";
            // 
            // lblSK
            // 
            this.lblSK.AutoSize = true;
            this.lblSK.Location = new System.Drawing.Point(42, 66);
            this.lblSK.Name = "lblSK";
            this.lblSK.Size = new System.Drawing.Size(59, 12);
            this.lblSK.TabIndex = 3;
            this.lblSK.Text = "SecretKey";
            // 
            // txtAK
            // 
            this.txtAK.Location = new System.Drawing.Point(120, 26);
            this.txtAK.Name = "txtAK";
            this.txtAK.Size = new System.Drawing.Size(100, 21);
            this.txtAK.TabIndex = 4;
            // 
            // txtSK
            // 
            this.txtSK.Location = new System.Drawing.Point(120, 63);
            this.txtSK.Name = "txtSK";
            this.txtSK.Size = new System.Drawing.Size(100, 21);
            this.txtSK.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(24, 404);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(77, 12);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "接收邮箱地址";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(120, 401);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(199, 21);
            this.txtAddress.TabIndex = 7;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 203);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(89, 12);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "发送邮箱用户名";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(120, 200);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 9;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(24, 241);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 12);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "发送邮箱密码";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 238);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 11;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(24, 320);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(77, 12);
            this.lblPort.TabIndex = 12;
            this.lblPort.Text = "发送邮箱端口";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(120, 317);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 13;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(12, 280);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(89, 12);
            this.lblServer.TabIndex = 14;
            this.lblServer.Text = "发送邮箱服务器";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(120, 277);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 21);
            this.txtServer.TabIndex = 15;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(267, 210);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(98, 49);
            this.btnTest.TabIndex = 16;
            this.btnTest.Text = "测试邮件发送";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessage.Location = new System.Drawing.Point(264, 276);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 17;
            // 
            // lblSendAddress
            // 
            this.lblSendAddress.AutoSize = true;
            this.lblSendAddress.Location = new System.Drawing.Point(24, 362);
            this.lblSendAddress.Name = "lblSendAddress";
            this.lblSendAddress.Size = new System.Drawing.Size(77, 12);
            this.lblSendAddress.TabIndex = 18;
            this.lblSendAddress.Text = "发送邮箱地址";
            // 
            // txtSendAddress
            // 
            this.txtSendAddress.Location = new System.Drawing.Point(120, 359);
            this.txtSendAddress.Name = "txtSendAddress";
            this.txtSendAddress.Size = new System.Drawing.Size(199, 21);
            this.txtSendAddress.TabIndex = 19;
            // 
            // lblBucket
            // 
            this.lblBucket.AutoSize = true;
            this.lblBucket.Location = new System.Drawing.Point(42, 99);
            this.lblBucket.Name = "lblBucket";
            this.lblBucket.Size = new System.Drawing.Size(41, 12);
            this.lblBucket.TabIndex = 20;
            this.lblBucket.Text = "Bucket";
            // 
            // txtBucket
            // 
            this.txtBucket.Location = new System.Drawing.Point(120, 96);
            this.txtBucket.Name = "txtBucket";
            this.txtBucket.Size = new System.Drawing.Size(100, 21);
            this.txtBucket.TabIndex = 21;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(42, 129);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(53, 12);
            this.lblFileName.TabIndex = 22;
            this.lblFileName.Text = "FileName";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(120, 126);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(100, 21);
            this.txtFileName.TabIndex = 23;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(42, 164);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(29, 12);
            this.lblPath.TabIndex = 24;
            this.lblPath.Text = "Path";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(120, 161);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(228, 21);
            this.txtPath.TabIndex = 25;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 512);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtBucket);
            this.Controls.Add(this.lblBucket);
            this.Controls.Add(this.txtSendAddress);
            this.Controls.Add(this.lblSendAddress);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtSK);
            this.Controls.Add(this.txtAK);
            this.Controls.Add(this.lblSK);
            this.Controls.Add(this.lblAK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAK;
        private System.Windows.Forms.Label lblSK;
        private System.Windows.Forms.TextBox txtAK;
        private System.Windows.Forms.TextBox txtSK;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblSendAddress;
        private System.Windows.Forms.TextBox txtSendAddress;
        private System.Windows.Forms.Label lblBucket;
        private System.Windows.Forms.TextBox txtBucket;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
    }
}