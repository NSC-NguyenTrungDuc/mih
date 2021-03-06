using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.OCSA
{
    partial class frmYaksok_code
    {
        private IHIS.Framework.XLabel xLabel62;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XTextBox txtYaksok_code;
        private IHIS.Framework.XTextBox txtYaksok_name;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XLabel xLabel2;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYaksok_code));
            this.xLabel62 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtYaksok_code = new IHIS.Framework.XTextBox();
            this.txtYaksok_name = new IHIS.Framework.XTextBox();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xLabel2 = new IHIS.Framework.XLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel62
            // 
            this.xLabel62.BackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel62.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel62.EdgeRounding = false;
            resources.ApplyResources(this.xLabel62, "xLabel62");
            this.xLabel62.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel62.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel62.Name = "xLabel62";
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel1.Name = "xLabel1";
            // 
            // txtYaksok_code
            // 
            this.txtYaksok_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtYaksok_code, "txtYaksok_code");
            this.txtYaksok_code.Name = "txtYaksok_code";
            this.txtYaksok_code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtYaksok_code_DataValidating);
            // 
            // txtYaksok_name
            // 
            resources.ApplyResources(this.txtYaksok_name, "txtYaksok_name");
            this.txtYaksok_name.Name = "txtYaksok_name";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xLabel2
            // 
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // frmYaksok_code
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.txtYaksok_name);
            this.Controls.Add(this.txtYaksok_code);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.xLabel62);
            this.Name = "frmYaksok_code";
            this.Load += new System.EventHandler(this.frmYaksok_code_Load);
            this.Controls.SetChildIndex(this.xLabel62, 0);
            this.Controls.SetChildIndex(this.xLabel1, 0);
            this.Controls.SetChildIndex(this.txtYaksok_code, 0);
            this.Controls.SetChildIndex(this.txtYaksok_name, 0);
            this.Controls.SetChildIndex(this.xButtonList1, 0);
            this.Controls.SetChildIndex(this.xLabel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
