namespace IHIS.CLIS
{
    partial class CLIS2015U13
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLIS2015U13));
            this.grdCLIS2015U13 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.grdCLIS2015U13)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdCLIS2015U13
            // 
            resources.ApplyResources(this.grdCLIS2015U13, "grdCLIS2015U13");
            this.grdCLIS2015U13.ApplyPaintEventToAllColumn = true;
            this.grdCLIS2015U13.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell19});
            this.grdCLIS2015U13.ColPerLine = 2;
            this.grdCLIS2015U13.Cols = 3;
            this.grdCLIS2015U13.ControlBinding = true;
            this.grdCLIS2015U13.ExecuteQuery = null;
            this.grdCLIS2015U13.FixedCols = 1;
            this.grdCLIS2015U13.FixedRows = 1;
            this.grdCLIS2015U13.HeaderHeights.Add(30);
            this.grdCLIS2015U13.Name = "grdCLIS2015U13";
            this.grdCLIS2015U13.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCLIS2015U13.ParamList")));
            this.grdCLIS2015U13.RowHeaderVisible = true;
            this.grdCLIS2015U13.Rows = 2;
            this.grdCLIS2015U13.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdCLIS2015U13.ToolTipActive = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "item_code";
            this.xEditGridCell18.CellWidth = 117;
            this.xEditGridCell18.Col = 1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "item_name";
            this.xEditGridCell19.CellWidth = 167;
            this.xEditGridCell19.Col = 2;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "email";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // CLIS2015U13
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.grdCLIS2015U13);
            this.Name = "CLIS2015U13";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CLIS2015U13_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.grdCLIS2015U13)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XMstGrid grdCLIS2015U13;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell17;

    }
}
