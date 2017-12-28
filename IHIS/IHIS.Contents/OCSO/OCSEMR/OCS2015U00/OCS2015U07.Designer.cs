namespace IHIS.OCSO
{
    partial class OCS2015U07
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2015U07));
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdList.ColPerLine = 2;
            this.grdList.ColResizable = true;
            this.grdList.Cols = 3;
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(24);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.ResizableAtOnlyHeader = false;
            this.grdList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.ToolTipActive = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Meiryo UI", 10F);
            this.xEditGridCell1.CellLen = 150;
            this.xEditGridCell1.CellName = "TagName";
            this.xEditGridCell1.CellWidth = 103;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Meiryo UI", 10F);
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.MenuGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Meiryo UI", 10F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Meiryo UI", 10F);
            this.xEditGridCell2.CellLen = 450;
            this.xEditGridCell2.CellName = "Content";
            this.xEditGridCell2.CellWidth = 520;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Meiryo UI", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Meiryo UI", 10F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "display_yn";
            this.xEditGridCell4.CellWidth = 160;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.InitValue = "N";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // OCS2015U07
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xPanel3);
            this.Name = "OCS2015U07";
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.XPanel xPanel3;
        private Framework.XEditGrid grdList;
        private Framework.XEditGridCell xEditGridCell1;
        private Framework.XEditGridCell xEditGridCell2;
        private Framework.XEditGridCell xEditGridCell4;

    }
}
