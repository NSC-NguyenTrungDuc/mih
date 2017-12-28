namespace IHIS.PHYS
{
    partial class JubsuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JubsuForm));
            this.cboGwa = new IHIS.Framework.XDictComboBox();
            this.cboDoctor = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnJubsu = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboJubsuGubun = new IHIS.Framework.XDictComboBox();
            this.dbxJubsu = new IHIS.Framework.XDisplayBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.SuspendLayout();
            // 
            // cboGwa
            // 
            this.cboGwa.ExecuteQuery = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGwa.ParamList")));
            this.cboGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGwa.SelectedValueChanged += new System.EventHandler(this.cboGwa_SelectedValueChanged);
            // 
            // cboDoctor
            // 
            this.cboDoctor.ExecuteQuery = null;
            resources.ApplyResources(this.cboDoctor, "cboDoctor");
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDoctor.ParamList")));
            this.cboDoctor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDoctor.DDLBSetting += new System.EventHandler(this.cboDoctor_DDLBSetting);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // btnJubsu
            // 
            this.btnJubsu.Image = global::IHIS.PHYS.Properties.Resources.전송_16;
            resources.ApplyResources(this.btnJubsu, "btnJubsu");
            this.btnJubsu.Name = "btnJubsu";
            this.btnJubsu.Click += new System.EventHandler(this.btnJubsu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::IHIS.PHYS.Properties.Resources.종료;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // cboJubsuGubun
            // 
            this.cboJubsuGubun.ExecuteQuery = null;
            resources.ApplyResources(this.cboJubsuGubun, "cboJubsuGubun");
            this.cboJubsuGubun.Name = "cboJubsuGubun";
            this.cboJubsuGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboJubsuGubun.ParamList")));
            this.cboJubsuGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // dbxJubsu
            // 
            resources.ApplyResources(this.dbxJubsu, "dbxJubsu");
            this.dbxJubsu.Name = "dbxJubsu";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // JubsuForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.xLabel4);
            this.Controls.Add(this.dbxJubsu);
            this.Controls.Add(this.cboJubsuGubun);
            this.Controls.Add(this.xLabel3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnJubsu);
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.cboDoctor);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.cboGwa);
            this.Name = "JubsuForm";
            this.Load += new System.EventHandler(this.JubsuForm_Load);
            this.Controls.SetChildIndex(this.cboGwa, 0);
            this.Controls.SetChildIndex(this.xLabel1, 0);
            this.Controls.SetChildIndex(this.cboDoctor, 0);
            this.Controls.SetChildIndex(this.xLabel2, 0);
            this.Controls.SetChildIndex(this.btnJubsu, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.xLabel3, 0);
            this.Controls.SetChildIndex(this.cboJubsuGubun, 0);
            this.Controls.SetChildIndex(this.dbxJubsu, 0);
            this.Controls.SetChildIndex(this.xLabel4, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XDictComboBox cboGwa;
        private IHIS.Framework.XDictComboBox cboDoctor;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XButton btnJubsu;
        private IHIS.Framework.XButton btnClose;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XDictComboBox cboJubsuGubun;
        private IHIS.Framework.XDisplayBox dbxJubsu;
        private IHIS.Framework.XLabel xLabel4;

    }
}