namespace IHIS.NURO
{
    partial class FormHaori
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
            this.wcHaori.Size = new System.Drawing.Size(1472, 775);
            this.wcHaori.TabIndex = 0;
            this.wcHaori.Text = "webControl1";
            this.wcHaori.WebView = this.webView1;
            // 
            // FormHaori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 775);
            this.Controls.Add(this.wcHaori);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormHaori";
            this.Text = "患者基本情報";
            this.Load += new System.EventHandler(this.FormHaori_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EO.WebBrowser.WinForm.WebControl wcHaori;
        private EO.WebBrowser.WebView webView1;
    }
}