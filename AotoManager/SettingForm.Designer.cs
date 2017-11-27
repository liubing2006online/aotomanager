namespace AotoManager
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
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(99, 118);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(214, 118);
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
            this.lblAK.Location = new System.Drawing.Point(36, 28);
            this.lblAK.Name = "lblAK";
            this.lblAK.Size = new System.Drawing.Size(59, 12);
            this.lblAK.TabIndex = 2;
            this.lblAK.Text = "AccessKey";
            // 
            // lblSK
            // 
            this.lblSK.AutoSize = true;
            this.lblSK.Location = new System.Drawing.Point(36, 65);
            this.lblSK.Name = "lblSK";
            this.lblSK.Size = new System.Drawing.Size(59, 12);
            this.lblSK.TabIndex = 3;
            this.lblSK.Text = "SecretKey";
            // 
            // txtAK
            // 
            this.txtAK.Location = new System.Drawing.Point(114, 25);
            this.txtAK.Name = "txtAK";
            this.txtAK.Size = new System.Drawing.Size(230, 21);
            this.txtAK.TabIndex = 4;
            // 
            // txtSK
            // 
            this.txtSK.Location = new System.Drawing.Point(114, 62);
            this.txtSK.Name = "txtSK";
            this.txtSK.Size = new System.Drawing.Size(230, 21);
            this.txtSK.TabIndex = 5;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 181);
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
    }
}