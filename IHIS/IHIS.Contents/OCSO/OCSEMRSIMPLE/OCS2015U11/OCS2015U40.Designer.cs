namespace IHIS.OCSO
{
    partial class OCS2015U40
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2015U40));
            this.xPnlHistoryMedicalRecord = new IHIS.Framework.XPanel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grdHistoryMedicalRecord = new IHIS.Framework.XEditGrid();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xPnlHistoryMedicalRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistoryMedicalRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPnlHistoryMedicalRecord
            // 
            this.xPnlHistoryMedicalRecord.AccessibleDescription = null;
            this.xPnlHistoryMedicalRecord.AccessibleName = null;
            resources.ApplyResources(this.xPnlHistoryMedicalRecord, "xPnlHistoryMedicalRecord");
            this.xPnlHistoryMedicalRecord.BackgroundImage = null;
            this.xPnlHistoryMedicalRecord.Controls.Add(this.pnlContent);
            this.xPnlHistoryMedicalRecord.Controls.Add(this.grdHistoryMedicalRecord);
            this.xPnlHistoryMedicalRecord.DrawBorder = true;
            this.xPnlHistoryMedicalRecord.Font = null;
            this.xPnlHistoryMedicalRecord.MinimumSize = new System.Drawing.Size(933, 600);
            this.xPnlHistoryMedicalRecord.Name = "xPnlHistoryMedicalRecord";
            // 
            // pnlContent
            // 
            this.pnlContent.AccessibleDescription = null;
            this.pnlContent.AccessibleName = null;
            resources.ApplyResources(this.pnlContent, "pnlContent");
            this.pnlContent.BackgroundImage = null;
            this.pnlContent.Font = null;
            this.pnlContent.Name = "pnlContent";
            // 
            // grdHistoryMedicalRecord
            // 
            resources.ApplyResources(this.grdHistoryMedicalRecord, "grdHistoryMedicalRecord");
            this.grdHistoryMedicalRecord.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell13,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdHistoryMedicalRecord.ColPerLine = 5;
            this.grdHistoryMedicalRecord.Cols = 6;
            this.grdHistoryMedicalRecord.ExecuteQuery = null;
            this.grdHistoryMedicalRecord.FixedCols = 1;
            this.grdHistoryMedicalRecord.FixedRows = 1;
            this.grdHistoryMedicalRecord.HeaderHeights.Add(22);
            this.grdHistoryMedicalRecord.Name = "grdHistoryMedicalRecord";
            this.grdHistoryMedicalRecord.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdHistoryMedicalRecord.ParamList")));
            this.grdHistoryMedicalRecord.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdHistoryMedicalRecord.RowHeaderVisible = true;
            this.grdHistoryMedicalRecord.Rows = 2;
            this.grdHistoryMedicalRecord.ToolTipActive = true;
            this.grdHistoryMedicalRecord.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdHistoryMedicalRecord_MouseDoubleClick);
            this.grdHistoryMedicalRecord.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHistoryMedicalRecord_QueryStarting);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 50;
            this.xEditGridCell13.CellName = "version";
            this.xEditGridCell13.CellWidth = 77;
            this.xEditGridCell13.Col = 1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellLen = 50;
            this.xEditGridCell1.CellName = "action";
            this.xEditGridCell1.CellWidth = 88;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "author";
            this.xEditGridCell2.CellWidth = 147;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.CellLen = 100;
            this.xEditGridCell3.CellName = "date";
            this.xEditGridCell3.CellWidth = 117;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 200;
            this.xEditGridCell4.CellName = "memo";
            this.xEditGridCell4.CellWidth = 63;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.InitValue = "N";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowGradientEnd = IHIS.Framework.XColor.MenuGradientStartColor;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 50;
            this.xEditGridCell5.CellName = "emrRecordId";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // OCS2015U40
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.xPnlHistoryMedicalRecord);
            this.Name = "OCS2015U40";
            this.xPnlHistoryMedicalRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHistoryMedicalRecord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.XPanel xPnlHistoryMedicalRecord;
        private Framework.XEditGrid grdHistoryMedicalRecord;
        private Framework.XEditGridCell xEditGridCell13;
        private Framework.XEditGridCell xEditGridCell1;
        private Framework.XEditGridCell xEditGridCell2;
        private Framework.XEditGridCell xEditGridCell3;
        private Framework.XEditGridCell xEditGridCell4;
        private System.Windows.Forms.Panel pnlContent;
        private Framework.XEditGridCell xEditGridCell5;
    }
}
