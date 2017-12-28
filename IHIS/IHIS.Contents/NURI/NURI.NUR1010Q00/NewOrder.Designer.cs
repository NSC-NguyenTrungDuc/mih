namespace IHIS.NURI
{
    partial class NewOrder
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
            this.pnlImage = new IHIS.Framework.XPanel();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            this.pnlImage.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.AliceBlue);
            this.pnlImage.BackgroundImage = global::IHIS.NURI.Properties.Resources.NewOrder;
            this.pnlImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(597, 260);
            this.pnlImage.TabIndex = 1;
            this.pnlImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseClick);
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackGroundColor = new IHIS.Framework.XColor(System.Drawing.Color.Azure);
            this.ClientSize = new System.Drawing.Size(597, 260);
            this.Controls.Add(this.pnlImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "追加オーダのお知らせ";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.NewOrder_Deactivate);
            this.MdiChildActivate += new System.EventHandler(this.NewOrder_MdiChildActivate);
            this.Controls.SetChildIndex(this.pnlImage, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel pnlImage;
    }
}