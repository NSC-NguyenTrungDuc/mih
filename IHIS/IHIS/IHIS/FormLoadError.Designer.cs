namespace IHIS
{
    partial class FormLoadError
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbProcess = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbContent = new System.Windows.Forms.Label();
            this.lbAppName = new System.Windows.Forms.LinkLabel();
            this.lbUrl = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(1, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 2);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(1, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(470, 2);
            this.label2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IHIS.Properties.Resources.icon_kc;
            this.pictureBox1.Location = new System.Drawing.Point(24, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 26);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(89, 96);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(38, 13);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Name:";
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(89, 128);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(33, 13);
            this.lbFrom.TabIndex = 4;
            this.lbFrom.Text = "From:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(89, 162);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(365, 21);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            // 
            // lbProcess
            // 
            this.lbProcess.AutoSize = true;
            this.lbProcess.Location = new System.Drawing.Point(89, 189);
            this.lbProcess.Name = "lbProcess";
            this.lbProcess.Size = new System.Drawing.Size(0, 13);
            this.lbProcess.TabIndex = 6;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(12, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(79, 13);
            this.lbTitle.TabIndex = 7;
            this.lbTitle.Text = "Deleting cache";
            // 
            // lbContent
            // 
            this.lbContent.Location = new System.Drawing.Point(41, 32);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(413, 36);
            this.lbContent.TabIndex = 8;
            this.lbContent.Text = "KCCKを起動するために必要な処理を行っています。しばらくお待ちください。";
            // 
            // lbAppName
            // 
            this.lbAppName.AutoSize = true;
            this.lbAppName.Location = new System.Drawing.Point(153, 96);
            this.lbAppName.Name = "lbAppName";
            this.lbAppName.Size = new System.Drawing.Size(35, 13);
            this.lbAppName.TabIndex = 9;
            this.lbAppName.TabStop = true;
            this.lbAppName.Text = "KCCK";
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Location = new System.Drawing.Point(153, 128);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(76, 13);
            this.lbUrl.TabIndex = 10;
            this.lbUrl.Text = "ihis.karte.clinic";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(379, 224);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormLoadError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 262);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbUrl);
            this.Controls.Add(this.lbAppName);
            this.Controls.Add(this.lbContent);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbProcess);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLoadError";
            this.Text = "Deleting cache";
            this.Load += new System.EventHandler(this.FormLoadError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbProcess;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbContent;
        private System.Windows.Forms.LinkLabel lbAppName;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.Button btnClose;
    }
}