using IHIS.Framework;
//namespace OCS2015U30
namespace IHIS.OCSO
{
    partial class OCS2015U30
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2015U30));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.xPnlTagManage = new IHIS.Framework.XPanel();
            this.grdNodeTags = new IHIS.Framework.XEditGrid();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlMain.SuspendLayout();
            this.xPnlTagManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNodeTags)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // pnlMain
            // 
            this.pnlMain.AccessibleDescription = null;
            this.pnlMain.AccessibleName = null;
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.BackgroundImage = null;
            this.pnlMain.Controls.Add(this.xPnlTagManage);
            this.pnlMain.Controls.Add(this.xPanel1);
            this.pnlMain.Font = null;
            this.pnlMain.Name = "pnlMain";
            // 
            // xPnlTagManage
            // 
            this.xPnlTagManage.AccessibleDescription = null;
            this.xPnlTagManage.AccessibleName = null;
            resources.ApplyResources(this.xPnlTagManage, "xPnlTagManage");
            this.xPnlTagManage.BackgroundImage = null;
            this.xPnlTagManage.Controls.Add(this.grdNodeTags);
            this.xPnlTagManage.DrawBorder = true;
            this.xPnlTagManage.Font = null;
            this.xPnlTagManage.MinimumSize = new System.Drawing.Size(100, 100);
            this.xPnlTagManage.Name = "xPnlTagManage";
            // 
            // grdNodeTags
            // 
            resources.ApplyResources(this.grdNodeTags, "grdNodeTags");
            this.grdNodeTags.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell14,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell1,
            this.xEditGridCell6,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdNodeTags.ColPerLine = 6;
            this.grdNodeTags.Cols = 7;
            this.grdNodeTags.ExecuteQuery = null;
            this.grdNodeTags.FixedCols = 1;
            this.grdNodeTags.FixedRows = 1;
            this.grdNodeTags.HeaderHeights.Add(23);
            this.grdNodeTags.Name = "grdNodeTags";
            this.grdNodeTags.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNodeTags.ParamList")));
            this.grdNodeTags.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdNodeTags.RowHeaderVisible = true;
            this.grdNodeTags.Rows = 2;
            this.grdNodeTags.ToolTipActive = true;
            this.grdNodeTags.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNodeTags_GridColumnChanged);
            this.grdNodeTags.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdTag_MouseClick);
            this.grdNodeTags.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdNodeTags_GridFindClick);
            this.grdNodeTags.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNodeTags_QueryStarting);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "tagId";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell7.CellLen = 50;
            this.xEditGridCell7.CellName = "tagCode";
            this.xEditGridCell7.CellWidth = 104;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.CellLen = 16;
            this.xEditGridCell8.CellName = "tagName";
            this.xEditGridCell8.CellWidth = 141;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsNotNull = true;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 100;
            this.xEditGridCell9.CellName = "displayTxt";
            this.xEditGridCell9.CellWidth = 139;
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.InitValue = "N";
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.RowGradientEnd = IHIS.Framework.XColor.MenuGradientStartColor;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "tagLevel";
            this.xEditGridCell1.CellWidth = 125;
            this.xEditGridCell1.Col = 4;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell6.CellName = "filter";
            this.xEditGridCell6.CellWidth = 131;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 128;
            this.xEditGridCell10.CellName = "memo";
            this.xEditGridCell10.CellWidth = 108;
            this.xEditGridCell10.Col = 6;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell10.ReservedMemoFileName = "C:\\ihis\\OCSA\\OCS.Lib.CommonForms.dll";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 50;
            this.xEditGridCell11.CellName = "tagParent";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 50;
            this.xEditGridCell12.CellName = "sys_id";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // OCS2015U30
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlMain);
            this.MinimumSize = new System.Drawing.Size(800, 566);
            this.Name = "OCS2015U30";
            this.Load += new System.EventHandler(this.OCS2015U30_Load);
            this.pnlMain.ResumeLayout(false);
            this.xPnlTagManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNodeTags)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private TagManager tagManager1;
        private XPanel panel1;
        private System.Windows.Forms.Panel pnlMain;
        private XPanel xPnlTagManage;
        private XButtonList btnList;
        private XEditGrid grdNodeTags;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell1;
        private XPanel xPanel1;

    }
}
