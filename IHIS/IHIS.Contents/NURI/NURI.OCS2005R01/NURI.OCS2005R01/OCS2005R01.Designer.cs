namespace IHIS.NURI
{
    partial class OCS2005R01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2005R01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cboHoDong = new IHIS.Framework.XDictComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboKiGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpQryDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnSiksaPrint = new IHIS.Framework.XButton();
            this.dwPrint = new IHIS.Framework.XDataWindow();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdSiksa = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xToolTip1 = new IHIS.Framework.XToolTip();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSiksa)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "출력.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.cboHoDong);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.cboKiGubun);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpQryDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(937, 41);
            this.xPanel1.TabIndex = 0;
            // 
            // cboHoDong
            // 
            this.cboHoDong.Location = new System.Drawing.Point(327, 10);
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.Size = new System.Drawing.Size(121, 21);
            this.cboHoDong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoDong.TabIndex = 5;
            this.cboHoDong.UserSQL = "SELECT A.GWA, A.GWA_NAME\r\nFROM BAS0260 A\r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE AND BUSEO_GUBUN = \'2\'\r\nAND TRUNC(SYSD" +
                "ATE) BETWEEN A.START_DATE\r\n                       AND NVL(A.END_DATE, TO_DATE(\'9" +
                "9981231\', \'YYYYMMDD\'))\r\nORDER BY A.GWA";
            this.cboHoDong.SelectedValueChanged += new System.EventHandler(this.cboHoDong_SelectedValueChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(239, 10);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(88, 20);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "病棟";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboKiGubun
            // 
            this.cboKiGubun.Location = new System.Drawing.Point(553, 10);
            this.cboKiGubun.Name = "cboKiGubun";
            this.cboKiGubun.Size = new System.Drawing.Size(121, 21);
            this.cboKiGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboKiGubun.TabIndex = 3;
            this.cboKiGubun.UserSQL = "SELECT CODE, CODE_NAME\r\nFROM OCS0132\r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE AND CODE_TYPE = \'KI_GUBUN\'\r\nORDER BY SORT" +
                "_KEY";
            this.cboKiGubun.SelectedValueChanged += new System.EventHandler(this.cboHoDong_SelectedValueChanged);
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(465, 10);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(88, 20);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "食事区分";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpQryDate
            // 
            this.dtpQryDate.Location = new System.Drawing.Point(108, 10);
            this.dtpQryDate.Name = "dtpQryDate";
            this.dtpQryDate.Size = new System.Drawing.Size(113, 20);
            this.dtpQryDate.TabIndex = 1;
            this.dtpQryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpQryDate.TextChanged += new System.EventHandler(this.dtpQryDate_TextChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(19, 10);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(88, 20);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "照会日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnSiksaPrint);
            this.xPanel2.Controls.Add(this.dwPrint);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 550);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(937, 40);
            this.xPanel2.TabIndex = 1;
            // 
            // btnSiksaPrint
            // 
            this.btnSiksaPrint.ImageIndex = 0;
            this.btnSiksaPrint.ImageList = this.ImageList;
            this.btnSiksaPrint.Location = new System.Drawing.Point(22, 7);
            this.btnSiksaPrint.Name = "btnSiksaPrint";
            this.btnSiksaPrint.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnSiksaPrint.Size = new System.Drawing.Size(124, 26);
            this.btnSiksaPrint.TabIndex = 2;
            this.btnSiksaPrint.Text = "食事伝票印刷";
            this.btnSiksaPrint.Click += new System.EventHandler(this.btnSiksaPrint_Click);
            // 
            // dwPrint
            // 
            this.dwPrint.DataWindowObject = "ocs2005r01";
            this.dwPrint.LibraryList = "..\\NURI\\nuri.ocs2005r01.pbd";
            this.dwPrint.Location = new System.Drawing.Point(327, 7);
            this.dwPrint.Name = "dwPrint";
            this.dwPrint.Size = new System.Drawing.Size(75, 23);
            this.dwPrint.TabIndex = 1;
            this.dwPrint.Text = "dwWindow";
            this.dwPrint.Visible = false;
            // 
            // btnList
            // 
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(689, 4);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdSiksa
            // 
            this.grdSiksa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell14,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13});
            this.grdSiksa.ColPerLine = 10;
            this.grdSiksa.Cols = 11;
            this.grdSiksa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSiksa.FixedCols = 1;
            this.grdSiksa.FixedRows = 1;
            this.grdSiksa.HeaderHeights.Add(27);
            this.grdSiksa.Location = new System.Drawing.Point(0, 41);
            this.grdSiksa.Name = "grdSiksa";
            this.grdSiksa.QuerySQL = resources.GetString("grdSiksa.QuerySQL");
            this.grdSiksa.RowHeaderVisible = true;
            this.grdSiksa.Rows = 2;
            this.grdSiksa.Size = new System.Drawing.Size(937, 509);
            this.grdSiksa.TabIndex = 2;
            this.grdSiksa.ToolTipActive = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "query_date_jp";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "query_date_jp";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "ki_gubun";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "ki_gubun";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "pkinp1001";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "pkinp1001";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderText = "患者番号";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 100;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.HeaderText = "氏名";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "sex_name";
            this.xEditGridCell5.CellWidth = 43;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.HeaderText = "性別";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "birth_jp";
            this.xEditGridCell6.CellWidth = 129;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.HeaderText = "生年月日";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "age";
            this.xEditGridCell7.CellWidth = 48;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.HeaderText = "年齢";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "ho_dong";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "ho_dong";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "ho_dong_name";
            this.xEditGridCell9.CellWidth = 77;
            this.xEditGridCell9.Col = 6;
            this.xEditGridCell9.HeaderText = "病棟";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.SuppressRepeating = true;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "ho_code";
            this.xEditGridCell10.CellWidth = 54;
            this.xEditGridCell10.Col = 7;
            this.xEditGridCell10.HeaderText = "病室";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.SuppressRepeating = true;
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bed_no";
            this.xEditGridCell11.CellWidth = 47;
            this.xEditGridCell11.Col = 8;
            this.xEditGridCell11.HeaderText = "病床";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "nut_name";
            this.xEditGridCell12.CellWidth = 130;
            this.xEditGridCell12.Col = 9;
            this.xEditGridCell12.HeaderText = "食事";
            this.xEditGridCell12.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "nut_comment";
            this.xEditGridCell13.CellWidth = 187;
            this.xEditGridCell13.Col = 10;
            this.xEditGridCell13.DisplayMemoText = true;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell13.HeaderText = "コメント";
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // OCS2005R01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdSiksa);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS2005R01";
            this.Size = new System.Drawing.Size(937, 590);
            this.Load += new System.EventHandler(this.OCS2005R01_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSiksa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdSiksa;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XDictComboBox cboKiGubun;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDatePicker dtpQryDate;
        private IHIS.Framework.XDictComboBox cboHoDong;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XDataWindow dwPrint;
        private IHIS.Framework.XButton btnSiksaPrint;
        private IHIS.Framework.XToolTip xToolTip1;
    }
}
