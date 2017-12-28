namespace IHIS.OCSI
{
    partial class frmOrderInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderInfo));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxMain = new IHIS.Framework.XDisplayBox();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.dbxMain);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(166, 175);
            this.xPanel1.TabIndex = 0;
            this.xPanel1.MouseLeave += new System.EventHandler(this.frmOrderInfo_MouseLeave);
            this.xPanel1.MouseEnter += new System.EventHandler(this.frmOrderInfo_MouseEnter);
            // 
            // dbxMain
            // 
            this.dbxMain.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.GradientInactiveCaption);
            this.dbxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbxMain.Font = new System.Drawing.Font("MS PGothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dbxMain.Location = new System.Drawing.Point(0, 0);
            this.dbxMain.Name = "dbxMain";
            this.dbxMain.Size = new System.Drawing.Size(166, 175);
            this.dbxMain.TabIndex = 0;
            this.dbxMain.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.dbxMain.MouseLeave += new System.EventHandler(this.frmOrderInfo_MouseLeave);
            this.dbxMain.MouseEnter += new System.EventHandler(this.frmOrderInfo_MouseEnter);
            // 
            // frmOrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(166, 175);
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrderInfo";
            this.Opacity = 0.85;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmOrderInfo";
            this.Load += new System.EventHandler(this.frmOrderInfo_Load);
            this.MouseEnter += new System.EventHandler(this.frmOrderInfo_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.frmOrderInfo_MouseLeave);
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XDisplayBox dbxMain;


    }
}