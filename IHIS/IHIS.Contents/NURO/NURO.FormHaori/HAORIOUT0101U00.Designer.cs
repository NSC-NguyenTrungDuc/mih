namespace IHIS.NURO
{
    partial class HAORIOUT0101U00
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
            this.wcHaori = new EO.WebBrowser.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.SuspendLayout();
            // 
            // wcHaori
            // 
            this.wcHaori.BackColor = System.Drawing.Color.White;
            this.wcHaori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcHaori.Location = new System.Drawing.Point(0, 0);
            this.wcHaori.Name = "wcHaori";
            this.wcHaori.Size = new System.Drawing.Size(1478, 804);
            this.wcHaori.TabIndex = 1;
            this.wcHaori.Text = "webControl1";
            this.wcHaori.WebView = this.webView1;
            // 
            // webView1
            // 
            this.webView1.DownloadCompleted += new EO.WebBrowser.DownloadEventHandler(this.webView1_DownloadCompleted);
            // 
            // HAORIOUT0101U00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wcHaori);
            this.Name = "HAORIOUT0101U00";
            this.Size = new System.Drawing.Size(1478, 804);
            this.Load += new System.EventHandler(this.FormHaori_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EO.WebBrowser.WinForm.WebControl wcHaori;
        private EO.WebBrowser.WebView webView1;
    }
}

