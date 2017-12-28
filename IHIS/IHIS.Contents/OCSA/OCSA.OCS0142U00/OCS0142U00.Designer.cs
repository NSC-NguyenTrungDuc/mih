namespace IHIS.OCSA
{
    partial class OCS0142U00 : IHIS.Framework.XScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0142U00));
            this.lblInptu_Tab = new IHIS.Framework.XLabel();
            this.grdOCS0142 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell_InputTbl = new IHIS.Framework.XEditGridCell();
            this.fbxInputTab = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell_input_tbl_name = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell_OrderGubun = new IHIS.Framework.XEditGridCell();
            this.fbxOrderGubun = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell_order_gubun_name = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell_main_yn = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell_default_yu = new IHIS.Framework.XEditGridCell();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cboSystem = new IHIS.Framework.XDictComboBox();
            this.pnlCenter = new IHIS.Framework.XPanel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btlList = new IHIS.Framework.XButtonList();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.singleLayout1 = new IHIS.Framework.SingleLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0142)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btlList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInptu_Tab
            // 
            this.lblInptu_Tab.Location = new System.Drawing.Point(29, 7);
            this.lblInptu_Tab.Name = "lblInptu_Tab";
            this.lblInptu_Tab.Size = new System.Drawing.Size(100, 21);
            this.lblInptu_Tab.TabIndex = 0;
            this.lblInptu_Tab.Text = "INPUT_TAB";
            // 
            // grdOCS0142
            // 
            this.grdOCS0142.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell_InputTbl,
            this.xEditGridCell_input_tbl_name,
            this.xEditGridCell_OrderGubun,
            this.xEditGridCell_order_gubun_name,
            this.xEditGridCell_main_yn,
            this.xEditGridCell_default_yu});
            this.grdOCS0142.ColPerLine = 6;
            this.grdOCS0142.Cols = 7;
            this.grdOCS0142.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS0142.FixedCols = 1;
            this.grdOCS0142.FixedRows = 1;
            this.grdOCS0142.HeaderHeights.Add(20);
            this.grdOCS0142.Location = new System.Drawing.Point(0, 0);
            this.grdOCS0142.Name = "grdOCS0142";
            this.grdOCS0142.QuerySQL = resources.GetString("grdOCS0142.QuerySQL");
            this.grdOCS0142.RowHeaderVisible = true;
            this.grdOCS0142.Rows = 2;
            this.grdOCS0142.Size = new System.Drawing.Size(870, 410);
            this.grdOCS0142.TabIndex = 2;
            this.grdOCS0142.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdOCS0142_GridFindSelected);
            this.grdOCS0142.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0142_QueryStarting);
            // 
            // xEditGridCell_InputTbl
            // 
            this.xEditGridCell_InputTbl.CellName = "input_tab";
            this.xEditGridCell_InputTbl.Col = 1;
            this.xEditGridCell_InputTbl.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell_InputTbl.EnableEdit = false;
            this.xEditGridCell_InputTbl.FindWorker = this.fbxInputTab;
            this.xEditGridCell_InputTbl.HeaderText = "INPUT_TAB";
            this.xEditGridCell_InputTbl.IsNotNull = true;
            // 
            // fbxInputTab
            // 
            this.fbxInputTab.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fbxInputTab.InputSQL = "SELECT A.CODE, A.CODE_NAME\r\n  FROM OCS0132 A\r\n WHERE A.HOSP_CODE = FN_ADM_LOAD_HO" +
    "SP_CODE()\r\n   AND A.CODE_TYPE = \'INPUT_TAB\'\r\n ORDER BY A.CODE";
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "input_tab";
            this.findColumnInfo1.HeaderText = "INPUT_TAB";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo2.ColName = "input_tab_name";
            this.findColumnInfo2.HeaderText = "INPUR_TAB名";
            // 
            // xEditGridCell_input_tbl_name
            // 
            this.xEditGridCell_input_tbl_name.CellName = "input_tab_name";
            this.xEditGridCell_input_tbl_name.CellWidth = 153;
            this.xEditGridCell_input_tbl_name.Col = 2;
            this.xEditGridCell_input_tbl_name.HeaderText = "INPUT_TAB名";
            this.xEditGridCell_input_tbl_name.IsReadOnly = true;
            this.xEditGridCell_input_tbl_name.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell_OrderGubun
            // 
            this.xEditGridCell_OrderGubun.CellName = "order_gubun";
            this.xEditGridCell_OrderGubun.CellWidth = 161;
            this.xEditGridCell_OrderGubun.Col = 3;
            this.xEditGridCell_OrderGubun.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell_OrderGubun.EnableEdit = false;
            this.xEditGridCell_OrderGubun.FindWorker = this.fbxOrderGubun;
            this.xEditGridCell_OrderGubun.HeaderText = "ORDER_GUBUN";
            this.xEditGridCell_OrderGubun.IsNotNull = true;
            // 
            // fbxOrderGubun
            // 
            this.fbxOrderGubun.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fbxOrderGubun.InputSQL = "SELECT A.CODE, A.CODE_NAME\r\n  FROM OCS0132 A \r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
    "P_CODE() \r\n   AND CODE_TYPE = \'ORDER_GUBUN_BAS\'\r\n ORDER BY A.CODE";
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "order_gubun";
            this.findColumnInfo3.HeaderText = "ORDER_GUBUN";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo4.ColName = "order_gubun_name";
            this.findColumnInfo4.HeaderText = "ORDER_GUBUN名";
            // 
            // xEditGridCell_order_gubun_name
            // 
            this.xEditGridCell_order_gubun_name.CellName = "order_gubun_name";
            this.xEditGridCell_order_gubun_name.CellWidth = 169;
            this.xEditGridCell_order_gubun_name.Col = 4;
            this.xEditGridCell_order_gubun_name.HeaderText = "ORDER_GUBUN名";
            this.xEditGridCell_order_gubun_name.IsReadOnly = true;
            this.xEditGridCell_order_gubun_name.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell_main_yn
            // 
            this.xEditGridCell_main_yn.CellName = "main_yn";
            this.xEditGridCell_main_yn.CellWidth = 112;
            this.xEditGridCell_main_yn.Col = 5;
            this.xEditGridCell_main_yn.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell_main_yn.HeaderText = "MAIN_YN";
            // 
            // xEditGridCell_default_yu
            // 
            this.xEditGridCell_default_yu.CellName = "default_yn";
            this.xEditGridCell_default_yu.CellWidth = 138;
            this.xEditGridCell_default_yu.Col = 6;
            this.xEditGridCell_default_yu.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell_default_yu.HeaderText = "DEFAULT_YN";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cboSystem);
            this.pnlTop.Controls.Add(this.lblInptu_Tab);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(870, 38);
            this.pnlTop.TabIndex = 4;
            // 
            // cboSystem
            // 
            this.cboSystem.Location = new System.Drawing.Point(150, 7);
            this.cboSystem.Name = "cboSystem";
            this.cboSystem.Size = new System.Drawing.Size(177, 21);
            this.cboSystem.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSystem.TabIndex = 1;
            this.cboSystem.UserSQL = "SELECT \'%\', \'全体\'\r\n  FROM DUAL\r\n UNION \r\nSELECT A.CODE, A.CODE||\':\'||A.CODE_NAME\r\n" +
    "  FROM OCS0132 A\r\n WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r\n   AND A.CODE_TY" +
    "PE = \'INPUT_TAB\'";
            this.cboSystem.SelectedValueChanged += new System.EventHandler(this.cboSystem_SelectedValueChanged);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grdOCS0142);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 38);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(870, 410);
            this.pnlCenter.TabIndex = 5;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btlList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 448);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(870, 35);
            this.pnlBottom.TabIndex = 6;
            // 
            // btlList
            // 
            this.btlList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btlList.Location = new System.Drawing.Point(541, 2);
            this.btlList.Name = "btlList";
            this.btlList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btlList.Size = new System.Drawing.Size(325, 34);
            this.btlList.TabIndex = 8;
            this.btlList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btlList_ButtonClick);
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "123";
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "21";
            this.xComboItem1.ValueItem = "2";
            // 
            // OCS0142U00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "OCS0142U00";
            this.Size = new System.Drawing.Size(870, 483);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0142U00_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0142)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btlList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XLabel lblInptu_Tab;
        private Framework.XEditGrid grdOCS0142;
        private Framework.XEditGridCell xEditGridCell_InputTbl;
        private Framework.XEditGridCell xEditGridCell_input_tbl_name;
        private Framework.XEditGridCell xEditGridCell_OrderGubun;
        private Framework.XEditGridCell xEditGridCell_order_gubun_name;
        private Framework.XEditGridCell xEditGridCell_main_yn;
        private Framework.XEditGridCell xEditGridCell_default_yu;
        private Framework.XPanel pnlTop;
        private Framework.XPanel pnlCenter;
        private Framework.XPanel pnlBottom;
        private Framework.XButtonList btlList;
        private Framework.XComboItem xComboItem2;
        private Framework.XComboItem xComboItem1;
        private Framework.XDictComboBox cboSystem;
        private Framework.SingleLayout singleLayout1;
        private Framework.FindColumnInfo findColumnInfo1;
        private Framework.FindColumnInfo findColumnInfo2;
        private Framework.XFindWorker fbxOrderGubun;
        private Framework.FindColumnInfo findColumnInfo3;
        private Framework.FindColumnInfo findColumnInfo4;
        private Framework.XFindWorker fbxInputTab;
    }
}
