namespace IHIS.NURO
{
    partial class SendBilling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendBilling));
            this.btnSend = new IHIS.Framework.XButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnCancel = new IHIS.Framework.XButton();
            this.xpanel = new IHIS.Framework.XPanel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel3.SuspendLayout();
            this.xpanel.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.AccessibleDescription = null;
            this.btnSend.AccessibleName = null;
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.BackgroundImage = null;
            this.btnSend.Name = "btnSend";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnCancel);
            this.xPanel3.Controls.Add(this.btnSend);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // xpanel
            // 
            this.xpanel.AccessibleDescription = null;
            this.xpanel.AccessibleName = null;
            resources.ApplyResources(this.xpanel, "xpanel");
            this.xpanel.BackgroundImage = null;
            this.xpanel.Controls.Add(this.webBrowser1);
            this.xpanel.Font = null;
            this.xpanel.Name = "xpanel";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AccessibleDescription = null;
            this.webBrowser1.AccessibleName = null;
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackColor = IHIS.Framework.XColor.ShadowForeColor;
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xpanel);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // SendBilling
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendBilling";
            this.ShowIcon = false;
            this.xPanel3.ResumeLayout(false);
            this.xpanel.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XButton btnSend;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xpanel;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XButton btnCancel;

    }
}