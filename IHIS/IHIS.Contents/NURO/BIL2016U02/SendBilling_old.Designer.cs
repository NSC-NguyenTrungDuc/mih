namespace IHIS.NURO
{
    partial class SendBilling_old
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendBilling_old));
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnSend = new IHIS.Framework.XButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnSend);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // btnSend
            // 
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.Name = "btnSend";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            // 
            // SendBilling_old
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.xPanel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendBilling_old";
            this.ShowIcon = false;
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButton btnSend;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}