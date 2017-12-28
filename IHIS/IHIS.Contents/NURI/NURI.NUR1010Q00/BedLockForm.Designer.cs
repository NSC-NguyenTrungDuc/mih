namespace IHIS.NURI
{
    partial class BedLockForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BedLockForm));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xGroupBox1 = new IHIS.Framework.XGroupBox();
            this.rbxReser = new IHIS.Framework.XRadioButton();
            this.rbxNoUse = new IHIS.Framework.XRadioButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.bedLockImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnLock = new IHIS.Framework.XButton();
            this.dtpIpwonDate = new IHIS.Framework.XDatePicker();
            this.lblIpwonDate = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.lblSuname = new IHIS.Framework.XLabel();
            this.txtBigo = new IHIS.Framework.XTextBox();
            this.txtSuname = new IHIS.Framework.XTextBox();
            this.dbxTitle = new IHIS.Framework.XDisplayBox();
            this.xPanel1.SuspendLayout();
            this.xGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xGroupBox1);
            this.xPanel1.Controls.Add(this.btnClose);
            this.xPanel1.Controls.Add(this.btnLock);
            this.xPanel1.Controls.Add(this.dtpIpwonDate);
            this.xPanel1.Controls.Add(this.lblIpwonDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.lblSuname);
            this.xPanel1.Controls.Add(this.txtBigo);
            this.xPanel1.Controls.Add(this.txtSuname);
            this.xPanel1.Controls.Add(this.dbxTitle);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(270, 267);
            this.xPanel1.TabIndex = 1;
            // 
            // xGroupBox1
            // 
            this.xGroupBox1.Controls.Add(this.rbxReser);
            this.xGroupBox1.Controls.Add(this.rbxNoUse);
            this.xGroupBox1.Location = new System.Drawing.Point(9, 59);
            this.xGroupBox1.Name = "xGroupBox1";
            this.xGroupBox1.Size = new System.Drawing.Size(248, 35);
            this.xGroupBox1.TabIndex = 8;
            this.xGroupBox1.TabStop = false;
            // 
            // rbxReser
            // 
            this.rbxReser.AutoSize = true;
            this.rbxReser.Location = new System.Drawing.Point(128, 12);
            this.rbxReser.Name = "rbxReser";
            this.rbxReser.Size = new System.Drawing.Size(116, 17);
            this.rbxReser.TabIndex = 1;
            this.rbxReser.Text = "未登録患者予約";
            this.rbxReser.UseVisualStyleBackColor = true;
            this.rbxReser.CheckedChanged += new System.EventHandler(this.rbxReser_CheckedChanged);
            // 
            // rbxNoUse
            // 
            this.rbxNoUse.AutoSize = true;
            this.rbxNoUse.Checked = true;
            this.rbxNoUse.Location = new System.Drawing.Point(30, 12);
            this.rbxNoUse.Name = "rbxNoUse";
            this.rbxNoUse.Size = new System.Drawing.Size(64, 17);
            this.rbxNoUse.TabIndex = 0;
            this.rbxNoUse.TabStop = true;
            this.rbxNoUse.Text = "未使用";
            this.rbxNoUse.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageIndex = 1;
            this.btnClose.ImageList = this.bedLockImageList;
            this.btnClose.Location = new System.Drawing.Point(179, 229);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "閉じる";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bedLockImageList
            // 
            this.bedLockImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("bedLockImageList.ImageStream")));
            this.bedLockImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.bedLockImageList.Images.SetKeyName(0, "");
            this.bedLockImageList.Images.SetKeyName(1, "");
            // 
            // btnLock
            // 
            this.btnLock.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.Image")));
            this.btnLock.ImageIndex = 0;
            this.btnLock.ImageList = this.bedLockImageList;
            this.btnLock.Location = new System.Drawing.Point(94, 229);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(85, 30);
            this.btnLock.TabIndex = 6;
            this.btnLock.Text = "ロック　　";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // dtpIpwonDate
            // 
            this.dtpIpwonDate.Enabled = false;
            this.dtpIpwonDate.IsJapanYearType = true;
            this.dtpIpwonDate.Location = new System.Drawing.Point(108, 129);
            this.dtpIpwonDate.Name = "dtpIpwonDate";
            this.dtpIpwonDate.Size = new System.Drawing.Size(150, 20);
            this.dtpIpwonDate.TabIndex = 2;
            this.dtpIpwonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIpwonDate
            // 
            this.lblIpwonDate.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblIpwonDate.EdgeRounding = false;
            this.lblIpwonDate.Enabled = false;
            this.lblIpwonDate.Location = new System.Drawing.Point(9, 129);
            this.lblIpwonDate.Name = "lblIpwonDate";
            this.lblIpwonDate.Size = new System.Drawing.Size(96, 20);
            this.lblIpwonDate.TabIndex = 5;
            this.lblIpwonDate.Text = "入院予定日";
            this.lblIpwonDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(9, 155);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(96, 69);
            this.xLabel2.TabIndex = 4;
            this.xLabel2.Text = "備　考";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSuname
            // 
            this.lblSuname.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSuname.EdgeRounding = false;
            this.lblSuname.Enabled = false;
            this.lblSuname.Location = new System.Drawing.Point(9, 103);
            this.lblSuname.Name = "lblSuname";
            this.lblSuname.Size = new System.Drawing.Size(96, 20);
            this.lblSuname.TabIndex = 3;
            this.lblSuname.Text = "患者名";
            this.lblSuname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBigo
            // 
            this.txtBigo.Location = new System.Drawing.Point(108, 155);
            this.txtBigo.MaxLength = 100;
            this.txtBigo.Multiline = true;
            this.txtBigo.Name = "txtBigo";
            this.txtBigo.Size = new System.Drawing.Size(151, 69);
            this.txtBigo.TabIndex = 3;
            // 
            // txtSuname
            // 
            this.txtSuname.Enabled = false;
            this.txtSuname.Location = new System.Drawing.Point(108, 103);
            this.txtSuname.Name = "txtSuname";
            this.txtSuname.Size = new System.Drawing.Size(150, 20);
            this.txtSuname.TabIndex = 1;
            // 
            // dbxTitle
            // 
            this.dbxTitle.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.dbxTitle.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.dbxTitle.Location = new System.Drawing.Point(9, 9);
            this.dbxTitle.Name = "dbxTitle";
            this.dbxTitle.Size = new System.Drawing.Size(251, 50);
            this.dbxTitle.TabIndex = 0;
            // 
            // BedLockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 289);
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BedLockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "病床ロック";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xGroupBox1.ResumeLayout(false);
            this.xGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XDisplayBox dbxTitle;
        private IHIS.Framework.XLabel lblSuname;
        private IHIS.Framework.XTextBox txtBigo;
        private IHIS.Framework.XTextBox txtSuname;
        private IHIS.Framework.XDatePicker dtpIpwonDate;
        private IHIS.Framework.XLabel lblIpwonDate;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XButton btnLock;
        private IHIS.Framework.XButton btnClose;
        private System.Windows.Forms.ImageList bedLockImageList;
        private IHIS.Framework.XGroupBox xGroupBox1;
        private IHIS.Framework.XRadioButton rbxReser;
        private IHIS.Framework.XRadioButton rbxNoUse;
    }
}