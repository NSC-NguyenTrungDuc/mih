//namespace OCS2015U30
namespace IHIS.OCSO
{
    partial class TagsManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagsManager));
            this.xPnlTagManage = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.tlbNodeTag = new System.Windows.Forms.Label();
            this.tlbRootTag = new System.Windows.Forms.Label();
            this.grdNodeTags = new IHIS.Framework.XEditGrid();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.grdRootTag = new IHIS.Framework.XEditGrid();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xPnlTagManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNodeTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRootTag)).BeginInit();
            this.SuspendLayout();
            // 
            // xPnlTagManage
            // 
            this.xPnlTagManage.Controls.Add(this.btnList);
            this.xPnlTagManage.Controls.Add(this.tlbNodeTag);
            this.xPnlTagManage.Controls.Add(this.tlbRootTag);
            this.xPnlTagManage.Controls.Add(this.grdNodeTags);
            this.xPnlTagManage.Controls.Add(this.grdRootTag);
            this.xPnlTagManage.DrawBorder = true;
            this.xPnlTagManage.Location = new System.Drawing.Point(0, 0);
            this.xPnlTagManage.Margin = new System.Windows.Forms.Padding(0);
            this.xPnlTagManage.MinimumSize = new System.Drawing.Size(800, 600);
            this.xPnlTagManage.Name = "xPnlTagManage";
            this.xPnlTagManage.Size = new System.Drawing.Size(998, 680);
            this.xPnlTagManage.TabIndex = 7;
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnList.Location = new System.Drawing.Point(385, 628);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 34);
            this.btnList.TabIndex = 103;
            // 
            // tlbNodeTag
            // 
            this.tlbNodeTag.AutoSize = true;
            this.tlbNodeTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlbNodeTag.Location = new System.Drawing.Point(448, 11);
            this.tlbNodeTag.Name = "tlbNodeTag";
            this.tlbNodeTag.Size = new System.Drawing.Size(69, 13);
            this.tlbNodeTag.TabIndex = 3;
            this.tlbNodeTag.Text = "Node Tags";
            // 
            // tlbRootTag
            // 
            this.tlbRootTag.AutoSize = true;
            this.tlbRootTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlbRootTag.Location = new System.Drawing.Point(8, 11);
            this.tlbRootTag.Name = "tlbRootTag";
            this.tlbRootTag.Size = new System.Drawing.Size(66, 13);
            this.tlbRootTag.TabIndex = 2;
            this.tlbRootTag.Text = "Root Tags";
            // 
            // grdNodeTags
            // 
            this.grdNodeTags.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell14,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11});
            this.grdNodeTags.ColPerLine = 6;
            this.grdNodeTags.Cols = 7;
            this.grdNodeTags.ExecuteQuery = null;
            this.grdNodeTags.FixedCols = 1;
            this.grdNodeTags.FixedRows = 1;
            this.grdNodeTags.HeaderHeights.Add(23);
            this.grdNodeTags.Location = new System.Drawing.Point(452, 29);
            this.grdNodeTags.Name = "grdNodeTags";
            this.grdNodeTags.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNodeTags.ParamList")));
            this.grdNodeTags.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdNodeTags.RowHeaderVisible = true;
            this.grdNodeTags.Rows = 2;
            this.grdNodeTags.Size = new System.Drawing.Size(532, 589);
            this.grdNodeTags.TabIndex = 1;
            this.grdNodeTags.ToolTipActive = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "tagId";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderText = "Tag Id";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell6.CellName = "filter";
            this.xEditGridCell6.CellWidth = 43;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell6.HeaderText = "Filter";
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell7.CellLen = 50;
            this.xEditGridCell7.CellName = "tagCode";
            this.xEditGridCell7.CellWidth = 104;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell7.HeaderText = "Tag Code";
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.CellLen = 100;
            this.xEditGridCell8.CellName = "tagName";
            this.xEditGridCell8.CellWidth = 132;
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.HeaderText = "Tag Name";
            this.xEditGridCell8.IsNotNull = true;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 100;
            this.xEditGridCell9.CellName = "displayTxt";
            this.xEditGridCell9.CellWidth = 128;
            this.xEditGridCell9.Col = 4;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderText = "Display text";
            this.xEditGridCell9.InitValue = "N";
            this.xEditGridCell9.RowGradientEnd = IHIS.Framework.XColor.MenuGradientStartColor;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 200;
            this.xEditGridCell10.CellName = "memo";
            this.xEditGridCell10.Col = 5;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderText = "Memo";
            this.xEditGridCell10.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell10.ReservedMemoFileName = "C:\\ihis\\OCSA\\OCS.Lib.CommonForms.dll";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "tagParent";
            this.xEditGridCell11.Col = 6;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderText = "Tag Parents";
            // 
            // grdRootTag
            // 
            this.grdRootTag.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell13,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdRootTag.ColPerLine = 5;
            this.grdRootTag.Cols = 6;
            this.grdRootTag.ExecuteQuery = null;
            this.grdRootTag.FixedCols = 1;
            this.grdRootTag.FixedRows = 1;
            this.grdRootTag.HeaderHeights.Add(22);
            this.grdRootTag.Location = new System.Drawing.Point(8, 29);
            this.grdRootTag.Name = "grdRootTag";
            this.grdRootTag.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRootTag.ParamList")));
            this.grdRootTag.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRootTag.RowHeaderVisible = true;
            this.grdRootTag.Rows = 2;
            this.grdRootTag.Size = new System.Drawing.Size(438, 589);
            this.grdRootTag.TabIndex = 0;
            this.grdRootTag.ToolTipActive = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "tagId";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderText = "Tag Id";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellName = "filter";
            this.xEditGridCell1.CellWidth = 52;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.HeaderText = "Filter";
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "tagCode";
            this.xEditGridCell2.CellWidth = 62;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.HeaderText = "Tag Code";
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.CellLen = 100;
            this.xEditGridCell3.CellName = "tagName";
            this.xEditGridCell3.CellWidth = 113;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.HeaderText = "Tag Name";
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 100;
            this.xEditGridCell4.CellName = "displayTxt";
            this.xEditGridCell4.CellWidth = 160;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderText = "Display text";
            this.xEditGridCell4.InitValue = "N";
            this.xEditGridCell4.RowGradientEnd = IHIS.Framework.XColor.MenuGradientStartColor;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "memo";
            this.xEditGridCell5.CellWidth = 50;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderText = "Memo";
            this.xEditGridCell5.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell5.ReservedMemoFileName = "C:\\ihis\\OCSA\\OCS.Lib.CommonForms.dll";
            // 
            // TagsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xPnlTagManage);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "TagsManager";
            this.Size = new System.Drawing.Size(990, 681);
            this.xPnlTagManage.ResumeLayout(false);
            this.xPnlTagManage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNodeTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRootTag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPnlTagManage;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Label tlbNodeTag;
        private System.Windows.Forms.Label tlbRootTag;
        private IHIS.Framework.XEditGrid grdNodeTags;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGrid grdRootTag;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;

    }
}
