namespace IHIS.OCSI
{
    partial class frmInputNurseID
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
            this.txtNurseID = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.SuspendLayout();
            // 
            // txtNurseID
            // 
            this.txtNurseID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNurseID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNurseID.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtNurseID.Location = new System.Drawing.Point(127, 19);
            this.txtNurseID.Name = "txtNurseID";
            this.txtNurseID.Size = new System.Drawing.Size(182, 31);
            this.txtNurseID.TabIndex = 0;
            this.txtNurseID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNurseID_KeyDown);
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel1.Location = new System.Drawing.Point(15, 19);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(106, 30);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "看護確認ID";
            // 
            // frmInputNurseID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 91);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.txtNurseID);
            this.Name = "frmInputNurseID";
            this.Text = "frmInputNurseID";
            this.Controls.SetChildIndex(this.txtNurseID, 0);
            this.Controls.SetChildIndex(this.xLabel1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public IHIS.Framework.XTextBox txtNurseID;
        private IHIS.Framework.XLabel xLabel1;
    }
}