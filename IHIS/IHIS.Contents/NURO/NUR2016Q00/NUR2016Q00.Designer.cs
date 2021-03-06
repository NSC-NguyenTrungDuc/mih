namespace IHIS.NURO
{
    partial class NUR2016Q00
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR2016Q00));
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.txtHospName = new IHIS.Framework.XTextBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.txtHospCode = new IHIS.Framework.XTextBox();
            this.xGroupBox1 = new IHIS.Framework.XGroupBox();
            this.txtRegion = new IHIS.Framework.XTextBox();
            this.grdHospList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHospList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // txtHospName
            // 
            this.txtHospName.AccessibleDescription = null;
            this.txtHospName.AccessibleName = null;
            resources.ApplyResources(this.txtHospName, "txtHospName");
            this.txtHospName.BackgroundImage = null;
            this.txtHospName.Name = "txtHospName";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // txtHospCode
            // 
            this.txtHospCode.AccessibleDescription = null;
            this.txtHospCode.AccessibleName = null;
            resources.ApplyResources(this.txtHospCode, "txtHospCode");
            this.txtHospCode.BackgroundImage = null;
            this.txtHospCode.Name = "txtHospCode";
            // 
            // xGroupBox1
            // 
            this.xGroupBox1.AccessibleDescription = null;
            this.xGroupBox1.AccessibleName = null;
            resources.ApplyResources(this.xGroupBox1, "xGroupBox1");
            this.xGroupBox1.BackgroundImage = null;
            this.xGroupBox1.Controls.Add(this.txtRegion);
            this.xGroupBox1.Controls.Add(this.xLabel5);
            this.xGroupBox1.Controls.Add(this.txtHospCode);
            this.xGroupBox1.Controls.Add(this.xLabel7);
            this.xGroupBox1.Controls.Add(this.txtHospName);
            this.xGroupBox1.Controls.Add(this.xLabel6);
            this.xGroupBox1.Name = "xGroupBox1";
            this.xGroupBox1.Protect = true;
            this.xGroupBox1.TabStop = false;
            // 
            // txtRegion
            // 
            this.txtRegion.AccessibleDescription = null;
            this.txtRegion.AccessibleName = null;
            resources.ApplyResources(this.txtRegion, "txtRegion");
            this.txtRegion.BackgroundImage = null;
            this.txtRegion.Name = "txtRegion";
            // 
            // grdHospList
            // 
            resources.ApplyResources(this.grdHospList, "grdHospList");
            this.grdHospList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell5,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdHospList.ColPerLine = 5;
            this.grdHospList.ColResizable = true;
            this.grdHospList.Cols = 6;
            this.grdHospList.ExecuteQuery = null;
            this.grdHospList.FixedCols = 1;
            this.grdHospList.FixedRows = 1;
            this.grdHospList.HeaderHeights.Add(23);
            this.grdHospList.Name = "grdHospList";
            this.grdHospList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdHospList.ParamList")));
            this.grdHospList.RowHeaderVisible = true;
            this.grdHospList.Rows = 2;
            this.grdHospList.ToolTipActive = true;
            this.grdHospList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdHospList_MouseDown);
            this.grdHospList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdHospList_MouseDoubleClick);
            this.grdHospList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHospList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hosp_code";
            this.xEditGridCell1.CellWidth = 81;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "yoyang_name";
            this.xEditGridCell2.CellWidth = 277;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "kana_name";
            this.xEditGridCell5.CellWidth = 232;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 200;
            this.xEditGridCell3.CellName = "address";
            this.xEditGridCell3.CellWidth = 300;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 20;
            this.xEditGridCell4.CellName = "telephone";
            this.xEditGridCell4.CellWidth = 107;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resources.TXT_BTN_SEARCH, -1, global::IHIS.NURO.Properties.Resources.MSG_005),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resources.TXT_BTN_PROCESS, -1, global::IHIS.NURO.Properties.Resources.MSG_LINK_SUCCESS),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.F2, global::IHIS.NURO.Properties.Resources.TXT_BTN_CLOSE, -1, global::IHIS.NURO.Properties.Resources.MSG_LINK_SUCCESS)});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // NUR2016Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdHospList);
            this.Controls.Add(this.xGroupBox1);
            this.Name = "NUR2016Q00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR2016Q00_ScreenOpen);
            this.xGroupBox1.ResumeLayout(false);
            this.xGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHospList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XTextBox txtHospCode;
        private IHIS.Framework.XTextBox txtHospName;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XGroupBox xGroupBox1;
        private IHIS.Framework.XEditGrid grdHospList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XTextBox txtRegion;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
    }
}
