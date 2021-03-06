namespace IHIS.Framework
{
    partial class FindHospitalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindHospitalForm));
            this.xGridCell10 = new IHIS.Framework.XGridCell();
            this.xGridCell9 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.txtHospcode = new IHIS.Framework.XTextBox();
            this.lblName = new IHIS.Framework.XLabel();
            this.grdHospCode = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.searchBtn = new IHIS.Framework.XButton();
            this.closeBtn = new IHIS.Framework.XButton();
            this.enterBtn = new IHIS.Framework.XButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdHospCode)).BeginInit();
            this.SuspendLayout();
            // 
            // xGridCell10
            // 
            this.xGridCell10.CellName = "tel";
            this.xGridCell10.CellWidth = 104;
            this.xGridCell10.Col = 6;
            resources.ApplyResources(this.xGridCell10, "xGridCell10");
            // 
            // xGridCell9
            // 
            this.xGridCell9.CellName = "ho_dong";
            this.xGridCell9.CellWidth = 120;
            this.xGridCell9.Col = 9;
            resources.ApplyResources(this.xGridCell9, "xGridCell9");
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "ipwon_yn";
            this.xGridCell8.CellWidth = 60;
            this.xGridCell8.Col = 8;
            resources.ApplyResources(this.xGridCell8, "xGridCell8");
            // 
            // xGridCell7
            // 
            this.xGridCell7.CellName = "address";
            this.xGridCell7.CellWidth = 219;
            this.xGridCell7.Col = 7;
            resources.ApplyResources(this.xGridCell7, "xGridCell7");
            // 
            // txtHospcode
            // 
            this.txtHospcode.AccessibleDescription = null;
            this.txtHospcode.AccessibleName = null;
            resources.ApplyResources(this.txtHospcode, "txtHospcode");
            this.txtHospcode.BackgroundImage = null;
            this.txtHospcode.Font = null;
            this.txtHospcode.Name = "txtHospcode";
            // 
            // lblName
            // 
            this.lblName.AccessibleDescription = null;
            this.lblName.AccessibleName = null;
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblName.EdgeRounding = false;
            this.lblName.Font = null;
            this.lblName.Image = null;
            this.lblName.Name = "lblName";
            // 
            // grdHospCode
            // 
            resources.ApplyResources(this.grdHospCode, "grdHospCode");
            this.grdHospCode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2});
            this.grdHospCode.ColPerLine = 2;
            this.grdHospCode.Cols = 2;
            this.grdHospCode.ExecuteQuery = null;
            this.grdHospCode.FixedRows = 1;
            this.grdHospCode.HeaderHeights.Add(21);
            this.grdHospCode.Name = "grdHospCode";
            this.grdHospCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdHospCode.ParamList")));
            this.grdHospCode.RowHeaderFont = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grdHospCode.Rows = 2;
            this.grdHospCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHospCode_QueryStarting);
            this.grdHospCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdHospCode_MouseDown);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "hosp_code";
            this.xGridCell1.CellWidth = 136;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "hosp_name";
            this.xGridCell2.CellWidth = 231;
            this.xGridCell2.Col = 1;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            // 
            // searchBtn
            // 
            this.searchBtn.AccessibleDescription = null;
            this.searchBtn.AccessibleName = null;
            resources.ApplyResources(this.searchBtn, "searchBtn");
            this.searchBtn.BackgroundImage = null;
            this.searchBtn.Font = null;
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.AccessibleDescription = null;
            this.closeBtn.AccessibleName = null;
            resources.ApplyResources(this.closeBtn, "closeBtn");
            this.closeBtn.BackgroundImage = null;
            this.closeBtn.Font = null;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // enterBtn
            // 
            this.enterBtn.AccessibleDescription = null;
            this.enterBtn.AccessibleName = null;
            resources.ApplyResources(this.enterBtn, "enterBtn");
            this.enterBtn.BackgroundImage = null;
            this.enterBtn.Font = null;
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // FindHospitalForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.grdHospCode);
            this.Controls.Add(this.txtHospcode);
            this.Controls.Add(this.lblName);
            this.Icon = null;
            this.Name = "FindHospitalForm";
            this.Load += new System.EventHandler(this.FindHospitalForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindHospitalForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdHospCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XGridCell xGridCell10;
        private XGridCell xGridCell9;
        private XGridCell xGridCell8;
        private XGridCell xGridCell7;
        private XTextBox txtHospcode;
        private XLabel lblName;
        private XGrid grdHospCode;
        private XGridCell xGridCell1;
        private XGridCell xGridCell2;
        private XButton searchBtn;
        private XButton closeBtn;
        private XButton enterBtn;
    }
}