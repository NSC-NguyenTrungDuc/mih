namespace IHIS.NURO
{
    partial class ReserCommentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReserCommentForm));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtReserComment = new IHIS.Framework.XTextBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cboReserGubun = new IHIS.Framework.XDictComboBox();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.txtReserComment);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Controls.Add(this.xPanel3);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // txtReserComment
            // 
            resources.ApplyResources(this.txtReserComment, "txtReserComment");
            this.txtReserComment.Name = "txtReserComment";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Controls.Add(this.cboReserGubun);
            this.xPanel3.Controls.Add(this.btnCancel);
            this.xPanel3.Controls.Add(this.btnClose);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // cboReserGubun
            // 
            resources.ApplyResources(this.cboReserGubun, "cboReserGubun");
            this.cboReserGubun.Name = "cboReserGubun";
            this.cboReserGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            //TODO: thêm proto RES1001U00FrmModifyReserCboReserGubunRequest
            this.cboReserGubun.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE = \'RESER_GUBUN\'\r\n ORDER BY SORT_KEY";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::IHIS.NURO.Properties.Resources.삭제1;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::IHIS.NURO.Properties.Resources.닫기;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReserCommentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReserCommentForm";
            this.Load += new System.EventHandler(this.ReserCommentForm_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XTextBox txtReserComment;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButton btnClose;
        private IHIS.Framework.XButton btnCancel;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDictComboBox cboReserGubun;
    }
}