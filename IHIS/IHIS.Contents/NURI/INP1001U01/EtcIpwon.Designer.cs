namespace IHIS.NURI
{
    partial class EtcIpwon :IHIS.Framework.XForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EtcIpwon));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.txtDoctor = new IHIS.Framework.XTextBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdHistory = new IHIS.Framework.XEditGrid();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.dtpIpwonDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.dtpToiwonDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.cboGwa = new IHIS.Framework.XBuseoCombo();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.fwkGubun = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.layCommonDoctor = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtDoctor);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(589, 30);
            this.pnlTop.TabIndex = 1;
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(194, 4);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(100, 20);
            this.txtDoctor.TabIndex = 1;
            this.txtDoctor.Visible = false;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(589, 32);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 180);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(589, 32);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "保存", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "閉じる", -1, "")});
            this.btnList.Location = new System.Drawing.Point(102, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 32);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdHistory
            // 
            this.grdHistory.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell7,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdHistory.ColPerLine = 4;
            this.grdHistory.Cols = 4;
            this.grdHistory.ControlBinding = true;
            this.grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHistory.FixedRows = 1;
            this.grdHistory.HeaderHeights.Add(21);
            this.grdHistory.Location = new System.Drawing.Point(0, 30);
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.QuerySQL = resources.GetString("grdHistory.QuerySQL");
            this.grdHistory.ReadOnly = true;
            this.grdHistory.Rows = 2;
            this.grdHistory.Size = new System.Drawing.Size(392, 150);
            this.grdHistory.TabIndex = 0;
            this.grdHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdHistory_MouseDown);
            this.grdHistory.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdHistory_QueryEnd);
            this.grdHistory.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHistory_QueryStarting);
            this.grdHistory.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdHistory_GridCellPainting);
            this.grdHistory.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdHistory_RowFocusChanged);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "pkinp1001";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "pkinp1001";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.ApplyPaintingEvent = true;
            this.xEditGridCell1.BindControl = this.dtpIpwonDate;
            this.xEditGridCell1.CellName = "ipwon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 90;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.HeaderText = "入院日付";
            this.xEditGridCell1.IsJapanYearType = true;
            this.xEditGridCell1.IsNotNull = true;
            // 
            // dtpIpwonDate
            // 
            this.dtpIpwonDate.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.dtpIpwonDate.IsJapanYearType = true;
            this.dtpIpwonDate.Location = new System.Drawing.Point(72, 10);
            this.dtpIpwonDate.Name = "dtpIpwonDate";
            this.dtpIpwonDate.Size = new System.Drawing.Size(119, 21);
            this.dtpIpwonDate.TabIndex = 1;
            this.dtpIpwonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.ApplyPaintingEvent = true;
            this.xEditGridCell2.BindControl = this.dtpToiwonDate;
            this.xEditGridCell2.CellName = "toiwon_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 90;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell2.HeaderText = "退院日付";
            this.xEditGridCell2.IsJapanYearType = true;
            this.xEditGridCell2.IsNotNull = true;
            // 
            // dtpToiwonDate
            // 
            this.dtpToiwonDate.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.dtpToiwonDate.IsJapanYearType = true;
            this.dtpToiwonDate.Location = new System.Drawing.Point(71, 39);
            this.dtpToiwonDate.Name = "dtpToiwonDate";
            this.dtpToiwonDate.Size = new System.Drawing.Size(119, 21);
            this.dtpToiwonDate.TabIndex = 3;
            this.dtpToiwonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.ApplyPaintingEvent = true;
            this.xEditGridCell3.BindControl = this.cboGwa;
            this.xEditGridCell3.CellName = "gwa";
            this.xEditGridCell3.CellWidth = 112;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.HeaderText = "診療科";
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell3.UserSQL = "SELECT GWA, GWA_NAME\r\n  FROM BAS0260\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r" +
                "\n   AND BUSEO_GUBUN = \'1\'";
            // 
            // cboGwa
            // 
            this.cboGwa.Location = new System.Drawing.Point(72, 68);
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.Size = new System.Drawing.Size(119, 21);
            this.cboGwa.TabIndex = 5;
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.txtDoctor;
            this.xEditGridCell4.CellName = "doctor";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "医師";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ApplyPaintingEvent = true;
            this.xEditGridCell5.CellName = "ipwon_type";
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.HeaderText = "入院タイプ";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell5.UserSQL = "SELECT A.CODE, A.CODE_NAME\r\n  FROM BAS0102 A\r\n WHERE A.HOSP_CODE = FN_ADM_LOAD_HO" +
                "SP_CODE()\r\n   AND A.CODE_TYPE = \'IPWON_TYPE\'";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.cboGwa);
            this.pnlRight.Controls.Add(this.xLabel3);
            this.pnlRight.Controls.Add(this.dtpToiwonDate);
            this.pnlRight.Controls.Add(this.xLabel2);
            this.pnlRight.Controls.Add(this.dtpIpwonDate);
            this.pnlRight.Controls.Add(this.xLabel1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(392, 30);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(197, 150);
            this.pnlRight.TabIndex = 4;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Location = new System.Drawing.Point(5, 68);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(65, 21);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "診療科";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(5, 39);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(65, 21);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "退院日付";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(5, 10);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(65, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "入院日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fwkGubun
            // 
            this.fwkGubun.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2,
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkGubun.InputSQL = resources.GetString("fwkGubun.InputSQL");
            this.fwkGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGubun_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "gubun";
            this.findColumnInfo1.ColWidth = 69;
            this.findColumnInfo1.HeaderText = "保険区分";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "gubun_name";
            this.findColumnInfo2.ColWidth = 122;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "保険名";
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "last_check_date";
            this.findColumnInfo3.ColType = IHIS.Framework.FindColType.Date;
            this.findColumnInfo3.HeaderText = "最終確認日";
            this.findColumnInfo3.Mask = "YYYY/MM/DD";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo4.ColName = "gongbi_yn";
            this.findColumnInfo4.ColWidth = 59;
            this.findColumnInfo4.HeaderText = "公費適用";
            // 
            // layCommonDoctor
            // 
            this.layCommonDoctor.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layCommonDoctor.QuerySQL = "SELECT DOCTOR \r\n  FROM BAS0270 \r\n WHERE HOSP_CODE  = :f_hosp_code\r\n   AND DOCTOR_" +
                "GWA = :f_gwa \r\n   AND COMMON_DOCTOR_YN = \'Y\'";
            this.layCommonDoctor.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCommonDoctor_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.txtDoctor;
            this.singleLayoutItem1.DataName = "doctor";
            // 
            // EtcIpwon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 234);
            this.Controls.Add(this.grdHistory);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "EtcIpwon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "他院履歴登録";
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlRight, 0);
            this.Controls.SetChildIndex(this.grdHistory, 0);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlRight;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XEditGrid grdHistory;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XDatePicker dtpToiwonDate;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDatePicker dtpIpwonDate;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XBuseoCombo cboGwa;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XTextBox txtDoctor;
        private IHIS.Framework.XFindWorker fwkGubun;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private IHIS.Framework.SingleLayout layCommonDoctor;
        private IHIS.Framework.SingleLayoutItem singleLayoutItem1;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
    }
}