namespace IHIS.ADMA
{
    partial class ADMS2016U00
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMS2016U00));
            this.grdSharding = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.grdSharding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdSharding
            // 
            resources.ApplyResources(this.grdSharding, "grdSharding");
            this.grdSharding.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3});
            this.grdSharding.ColPerLine = 2;
            this.grdSharding.Cols = 2;
            this.grdSharding.ExecuteQuery = null;
            this.grdSharding.FixedRows = 1;
            this.grdSharding.HeaderHeights.Add(21);
            this.grdSharding.Name = "grdSharding";
            this.grdSharding.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSharding.ParamList")));
            this.grdSharding.Rows = 2;
            this.grdSharding.ToolTipActive = true;
            this.grdSharding.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdSharding_ItemValueChanging);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hosp_group_cd";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hosp_group_name";
            this.xEditGridCell2.CellWidth = 341;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "maintenance_mode";
            this.xEditGridCell3.CellWidth = 123;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // ADMS2016U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdSharding);
            this.Name = "ADMS2016U00";
            this.Load += new System.EventHandler(this.ADMS2016U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSharding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XEditGrid grdSharding;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
    }
}

