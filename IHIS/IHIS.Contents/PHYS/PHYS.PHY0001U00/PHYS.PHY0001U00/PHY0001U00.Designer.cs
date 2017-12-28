namespace IHIS.PHYS
{
    partial class PHY0001U00
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PHY0001U00));
            this.grdOCS0132 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pnlAutoCreateSinryouryou = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.grdRehaSinryouryouCode = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.pnlAutoCreateSinryouryou.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRehaSinryouryouCode)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdOCS0132
            // 
            resources.ApplyResources(this.grdOCS0132, "grdOCS0132");
            this.grdOCS0132.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdOCS0132.ColPerLine = 2;
            this.grdOCS0132.Cols = 3;
            this.grdOCS0132.ExecuteQuery = null;
            this.grdOCS0132.FixedCols = 1;
            this.grdOCS0132.FixedRows = 1;
            this.grdOCS0132.HeaderHeights.Add(21);
            this.grdOCS0132.Name = "grdOCS0132";
            this.grdOCS0132.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0132.ParamList")));
            this.grdOCS0132.QuerySQL = "SELECT A.CODE, A.CODE_NAME, A.CODE_TYPE, A.MENT\r\n  FROM OCS0132 A\r\n WHERE A.HOSP_" +
                "CODE = :f_hosp_code\r\n   AND A.CODE_TYPE = :f_code_type\r\n";
            this.grdOCS0132.RowHeaderVisible = true;
            this.grdOCS0132.Rows = 2;
            this.grdOCS0132.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0132_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "code";
            this.xEditGridCell1.CellWidth = 203;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "code_name";
            this.xEditGridCell2.CellWidth = 54;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "Y";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "N";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "ment";
            this.xEditGridCell4.CellWidth = 233;
            this.xEditGridCell4.Col = 1;
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
            this.btnList.Font = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Font = null;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // pnlAutoCreateSinryouryou
            // 
            this.pnlAutoCreateSinryouryou.AccessibleDescription = null;
            this.pnlAutoCreateSinryouryou.AccessibleName = null;
            resources.ApplyResources(this.pnlAutoCreateSinryouryou, "pnlAutoCreateSinryouryou");
            this.pnlAutoCreateSinryouryou.BackgroundImage = null;
            this.pnlAutoCreateSinryouryou.Controls.Add(this.grdOCS0132);
            this.pnlAutoCreateSinryouryou.Font = null;
            this.pnlAutoCreateSinryouryou.Name = "pnlAutoCreateSinryouryou";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.AccessibleDescription = null;
            this.xFlatLabel1.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.Font = null;
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.AccessibleDescription = null;
            this.xFlatLabel2.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.Font = null;
            this.xFlatLabel2.Name = "xFlatLabel2";
            // 
            // grdRehaSinryouryouCode
            // 
            resources.ApplyResources(this.grdRehaSinryouryouCode, "grdRehaSinryouryouCode");
            this.grdRehaSinryouryouCode.ApplyPaintEventToAllColumn = true;
            this.grdRehaSinryouryouCode.CallerID = '2';
            this.grdRehaSinryouryouCode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7});
            this.grdRehaSinryouryouCode.ColPerLine = 3;
            this.grdRehaSinryouryouCode.Cols = 4;
            this.grdRehaSinryouryouCode.ExecuteQuery = null;
            this.grdRehaSinryouryouCode.FixedCols = 1;
            this.grdRehaSinryouryouCode.FixedRows = 1;
            this.grdRehaSinryouryouCode.HeaderHeights.Add(21);
            this.grdRehaSinryouryouCode.Name = "grdRehaSinryouryouCode";
            this.grdRehaSinryouryouCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRehaSinryouryouCode.ParamList")));
            this.grdRehaSinryouryouCode.QuerySQL = resources.GetString("grdRehaSinryouryouCode.QuerySQL");
            this.grdRehaSinryouryouCode.RowHeaderVisible = true;
            this.grdRehaSinryouryouCode.Rows = 2;
            this.grdRehaSinryouryouCode.ToolTipActive = true;
            this.grdRehaSinryouryouCode.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdRehaSinryouryouCode_GridFindSelected);
            this.grdRehaSinryouryouCode.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdRehaSinryouryouCode_GridFindClick);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "code";
            this.xEditGridCell5.CellWidth = 91;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4,
            this.xComboItem5});
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "G1";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "G2";
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "SA";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "hangmog_code";
            this.xEditGridCell6.CellWidth = 89;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "hangmog_name";
            this.xEditGridCell7.CellWidth = 192;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // PHY0001U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.grdRehaSinryouryouCode);
            this.Controls.Add(this.xFlatLabel2);
            this.Controls.Add(this.xFlatLabel1);
            this.Controls.Add(this.pnlAutoCreateSinryouryou);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "PHY0001U00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.PHYS0001U00_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.pnlAutoCreateSinryouryou.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRehaSinryouryouCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XEditGrid grdOCS0132;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel pnlAutoCreateSinryouryou;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XFlatLabel xFlatLabel1;
        private IHIS.Framework.XFlatLabel xFlatLabel2;
        private IHIS.Framework.XEditGrid grdRehaSinryouryouCode;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XComboItem xComboItem5;
    }
}
