using IHIS.Framework;

namespace IHIS
{
    partial class FormSettingVPN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingVPN));
            this.btnList = new IHIS.Framework.XButtonList();
            this.lbVPNKey = new System.Windows.Forms.Label();
            this.txtVPNKey = new System.Windows.Forms.TextBox();
            this.lbErrMsg = new System.Windows.Forms.Label();
            this.lbVPNCert = new System.Windows.Forms.Label();
            this.txtVPNCert = new System.Windows.Forms.TextBox();
            this.lbVPNInfo = new System.Windows.Forms.Label();
            this.btnTestConnection = new IHIS.XPButton();
            this.btnBrowseKey = new IHIS.XPButton();
            this.btnBrowseCert = new IHIS.XPButton();
            this.btnCancel = new IHIS.XPButton();
            this.btnSave = new IHIS.XPButton();
            this.btnVPN = new IHIS.XPButton();
            this.lbUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnList
            // 
            this.btnList.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(-29, 201);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(1, 34);
            this.btnList.TabIndex = 15;
            // 
            // lbVPNKey
            // 
            this.lbVPNKey.BackColor = System.Drawing.Color.Transparent;
            this.lbVPNKey.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbVPNKey.Location = new System.Drawing.Point(0, 227);
            this.lbVPNKey.Name = "lbVPNKey";
            this.lbVPNKey.Size = new System.Drawing.Size(95, 19);
            this.lbVPNKey.TabIndex = 29;
            this.lbVPNKey.Text = "VPN Key";
            this.lbVPNKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVPNKey
            // 
            this.txtVPNKey.BackColor = System.Drawing.SystemColors.Window;
            this.txtVPNKey.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtVPNKey.Location = new System.Drawing.Point(101, 227);
            this.txtVPNKey.MaxLength = 7;
            this.txtVPNKey.Name = "txtVPNKey";
            this.txtVPNKey.ReadOnly = true;
            this.txtVPNKey.Size = new System.Drawing.Size(237, 20);
            this.txtVPNKey.TabIndex = 30;
            // 
            // lbErrMsg
            // 
            this.lbErrMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbErrMsg.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbErrMsg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbErrMsg.Location = new System.Drawing.Point(99, 309);
            this.lbErrMsg.Name = "lbErrMsg";
            this.lbErrMsg.Size = new System.Drawing.Size(267, 28);
            this.lbErrMsg.TabIndex = 28;
            this.lbErrMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbVPNCert
            // 
            this.lbVPNCert.BackColor = System.Drawing.Color.Transparent;
            this.lbVPNCert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbVPNCert.Location = new System.Drawing.Point(0, 199);
            this.lbVPNCert.Name = "lbVPNCert";
            this.lbVPNCert.Size = new System.Drawing.Size(95, 19);
            this.lbVPNCert.TabIndex = 25;
            this.lbVPNCert.Text = "VPN証明書";
            this.lbVPNCert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVPNCert
            // 
            this.txtVPNCert.BackColor = System.Drawing.SystemColors.Window;
            this.txtVPNCert.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtVPNCert.Location = new System.Drawing.Point(101, 199);
            this.txtVPNCert.MaxLength = 7;
            this.txtVPNCert.Name = "txtVPNCert";
            this.txtVPNCert.ReadOnly = true;
            this.txtVPNCert.Size = new System.Drawing.Size(237, 20);
            this.txtVPNCert.TabIndex = 26;
            // 
            // lbVPNInfo
            // 
            this.lbVPNInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbVPNInfo.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbVPNInfo.ForeColor = System.Drawing.Color.Black;
            this.lbVPNInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbVPNInfo.Location = new System.Drawing.Point(118, 128);
            this.lbVPNInfo.Name = "lbVPNInfo";
            this.lbVPNInfo.Size = new System.Drawing.Size(180, 24);
            this.lbVPNInfo.TabIndex = 24;
            this.lbVPNInfo.Text = "VPN情報";
            this.lbVPNInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(101, 263);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(114, 32);
            this.btnTestConnection.TabIndex = 32;
            this.btnTestConnection.Text = "Test connection";
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnBrowseKey
            // 
            this.btnBrowseKey.Location = new System.Drawing.Point(340, 227);
            this.btnBrowseKey.Name = "btnBrowseKey";
            this.btnBrowseKey.Size = new System.Drawing.Size(21, 20);
            this.btnBrowseKey.TabIndex = 31;
            this.btnBrowseKey.Text = "...";
            this.btnBrowseKey.Click += new System.EventHandler(this.btnBrowseKey_Click);
            // 
            // btnBrowseCert
            // 
            this.btnBrowseCert.Location = new System.Drawing.Point(340, 199);
            this.btnBrowseCert.Name = "btnBrowseCert";
            this.btnBrowseCert.Size = new System.Drawing.Size(21, 20);
            this.btnBrowseCert.TabIndex = 27;
            this.btnBrowseCert.Text = "...";
            this.btnBrowseCert.Click += new System.EventHandler(this.btnBrowseCert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(299, 379);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(216, 379);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 32);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnVPN
            // 
            this.btnVPN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVPN.Image = ((System.Drawing.Image)(resources.GetObject("btnVPN.Image")));
            this.btnVPN.Location = new System.Drawing.Point(15, 13);
            this.btnVPN.Name = "btnVPN";
            this.btnVPN.Size = new System.Drawing.Size(74, 59);
            this.btnVPN.TabIndex = 0;
            this.btnVPN.Click += new System.EventHandler(this.btnVPN_Click);
            // 
            // lbUserID
            // 
            this.lbUserID.BackColor = System.Drawing.Color.Transparent;
            this.lbUserID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbUserID.Location = new System.Drawing.Point(0, 171);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(95, 19);
            this.lbUserID.TabIndex = 33;
            this.lbUserID.Text = "User ID";
            this.lbUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtUserID.Location = new System.Drawing.Point(101, 171);
            this.txtUserID.MaxLength = 7;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(150, 20);
            this.txtUserID.TabIndex = 34;
            // 
            // FormSettingVPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(388, 436);
            this.Controls.Add(this.lbUserID);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnBrowseKey);
            this.Controls.Add(this.lbVPNKey);
            this.Controls.Add(this.txtVPNKey);
            this.Controls.Add(this.lbErrMsg);
            this.Controls.Add(this.btnBrowseCert);
            this.Controls.Add(this.lbVPNCert);
            this.Controls.Add(this.txtVPNCert);
            this.Controls.Add(this.lbVPNInfo);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnVPN);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(394, 464);
            this.Name = "FormSettingVPN";
            this.Text = "FormSettingVPN";
            this.Load += new System.EventHandler(this.FormSettingVPN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XPButton btnVPN;
        private IHIS.Framework.XButtonList btnList;
        private XPButton btnSave;
        private XPButton btnCancel;
        private XPButton btnTestConnection;
        private XPButton btnBrowseKey;
        private System.Windows.Forms.Label lbVPNKey;
        private System.Windows.Forms.TextBox txtVPNKey;
        private System.Windows.Forms.Label lbErrMsg;
        private XPButton btnBrowseCert;
        private System.Windows.Forms.Label lbVPNCert;
        private System.Windows.Forms.TextBox txtVPNCert;
        private System.Windows.Forms.Label lbVPNInfo;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.TextBox txtUserID;
    }
}