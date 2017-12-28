namespace IHIS.NURI
{
    partial class CheckNurse
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
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtNurseID = new IHIS.Framework.XTextBox();
            this.btnOK = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.SuspendLayout();
            // 
            // lblSuname
            // 
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold);
            this.xLabel1.Location = new System.Drawing.Point(6, 5);
            this.xLabel1.Name = "lblSuname";
            this.xLabel1.Size = new System.Drawing.Size(224, 35);
            this.xLabel1.TabIndex = 1;
            this.xLabel1.Text = "看護師IDを入力してください。";
            // 
            // txtNurseID
            // 
            this.txtNurseID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNurseID.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNurseID.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtNurseID.Location = new System.Drawing.Point(6, 44);
            this.txtNurseID.MaxLength = 10;
            this.txtNurseID.Name = "txtNurseID";
            this.txtNurseID.Size = new System.Drawing.Size(224, 26);
            this.txtNurseID.TabIndex = 2;
            this.txtNurseID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(67, 76);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "確　認";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消し";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CheckNurse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 129);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtNurseID);
            this.Name = "CheckNurse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "看護師ID入力";
            this.Controls.SetChildIndex(this.txtNurseID, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.xLabel1, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XTextBox txtNurseID;
        private IHIS.Framework.XButton btnOK;
        private IHIS.Framework.XButton btnCancel;
    }
}