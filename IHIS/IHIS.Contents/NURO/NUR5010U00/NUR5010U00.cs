#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.NURO;
using IHIS.NURO.Properties;

#endregion

namespace IHIS.NURO
{
	/// <summary>
	/// OUT0101U02에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR5010U00 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XFindWorker fwkCommon;
        private IHIS.Framework.XButtonList btnList;
        private XPanel pnlFill;
        private XLabel xLabel1;
        private XEditGrid grdList;
        private XDatePicker dtpFromDate;
        private XRadioButton rbtDay;
        private XRadioButton rbtOver;
        private XRadioButton rbtAll;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XCheckBox cbxTorikomi;
        private SingleLayout layConfirm_yn;
        private SingleLayoutItem singleLayoutItem1;
        private XCheckBox cbxConfirm_yn;
        private SingleLayout layIsMaked;
        private SingleLayoutItem singleLayoutItem2;
        private MultiLayout layTimeGubun;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public NUR5010U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR5010U00));
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cbxConfirm_yn = new IHIS.Framework.XCheckBox();
            this.cbxTorikomi = new IHIS.Framework.XCheckBox();
            this.rbtDay = new IHIS.Framework.XRadioButton();
            this.rbtOver = new IHIS.Framework.XRadioButton();
            this.rbtAll = new IHIS.Framework.XRadioButton();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.layConfirm_yn = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layIsMaked = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layTimeGubun = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeGubun)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "++.gif");
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.cbxConfirm_yn);
            this.pnlTop.Controls.Add(this.cbxTorikomi);
            this.pnlTop.Controls.Add(this.rbtDay);
            this.pnlTop.Controls.Add(this.rbtOver);
            this.pnlTop.Controls.Add(this.rbtAll);
            this.pnlTop.Controls.Add(this.dtpFromDate);
            this.pnlTop.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Name = "pnlTop";
            // 
            // cbxConfirm_yn
            // 
            this.cbxConfirm_yn.AutoCheck = false;
            resources.ApplyResources(this.cbxConfirm_yn, "cbxConfirm_yn");
            this.cbxConfirm_yn.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.cbxConfirm_yn.Name = "cbxConfirm_yn";
            this.cbxConfirm_yn.UseVisualStyleBackColor = false;
            // 
            // cbxTorikomi
            // 
            resources.ApplyResources(this.cbxTorikomi, "cbxTorikomi");
            this.cbxTorikomi.Name = "cbxTorikomi";
            this.cbxTorikomi.UseVisualStyleBackColor = false;
            this.cbxTorikomi.CheckedChanged += new System.EventHandler(this.cbxTorikomi_CheckedChanged);
            // 
            // rbtDay
            // 
            resources.ApplyResources(this.rbtDay, "rbtDay");
            this.rbtDay.Name = "rbtDay";
            this.rbtDay.UseVisualStyleBackColor = true;
            this.rbtDay.CheckedChanged += new System.EventHandler(this.rbtAll_CheckedChanged);
            // 
            // rbtOver
            // 
            resources.ApplyResources(this.rbtOver, "rbtOver");
            this.rbtOver.Name = "rbtOver";
            this.rbtOver.UseVisualStyleBackColor = true;
            this.rbtOver.CheckedChanged += new System.EventHandler(this.rbtAll_CheckedChanged);
            // 
            // rbtAll
            // 
            resources.ApplyResources(this.rbtAll, "rbtAll");
            this.rbtAll.Checked = true;
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.TabStop = true;
            this.rbtAll.UseVisualStyleBackColor = true;
            this.rbtAll.CheckedChanged += new System.EventHandler(this.rbtAll_CheckedChanged);
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // fwkCommon
            // 
            this.fwkCommon.IsSetControlText = true;
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            this.fwkCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkCommon_QueryStarting);
            // 
            // pnlFill
            // 
            this.pnlFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFill.Controls.Add(this.grdList);
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.Name = "pnlFill";
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
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
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17});
            this.grdList.ColPerLine = 15;
            this.grdList.Cols = 16;
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(25);
            this.grdList.IncludeUnChangedRowAtSaving = true;
            this.grdList.Name = "grdList";
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.ToolTipActive = true;
            this.grdList.UseDefaultTransaction = false;
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            this.grdList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdList_GridColumnChanged);
            this.grdList.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdList_GridFindSelected);
            this.grdList.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdList_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "naewon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 90;
            this.xEditGridCell1.Col = -1;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsJapanYearType = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "jubsu_time";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell2.CellWidth = 61;
            this.xEditGridCell2.Col = 1;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.Mask = "HH:MI";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "jinryo_start_time";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell3.CellWidth = 56;
            this.xEditGridCell3.Col = 2;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.Mask = "HH:MI";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "jinryo_end_time";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell4.CellWidth = 45;
            this.xEditGridCell4.Col = -1;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AutoTabDataSelected = true;
            this.xEditGridCell5.CellName = "bunho";
            this.xEditGridCell5.CellWidth = 83;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 30;
            this.xEditGridCell6.CellName = "suname";
            this.xEditGridCell6.CellWidth = 85;
            this.xEditGridCell6.Col = 4;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 30;
            this.xEditGridCell7.CellName = "suname2";
            this.xEditGridCell7.CellWidth = 100;
            this.xEditGridCell7.Col = 5;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "chojae";
            this.xEditGridCell8.CellWidth = 65;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell8.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE = \'CHOJAE\'";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 500;
            this.xEditGridCell9.CellName = "sang_name";
            this.xEditGridCell9.CellWidth = 140;
            this.xEditGridCell9.Col = 8;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 50;
            this.xEditGridCell10.CellName = "doctor";
            this.xEditGridCell10.CellWidth = 95;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 20;
            this.xEditGridCell11.CellName = "doctor_name";
            this.xEditGridCell11.CellWidth = 93;
            this.xEditGridCell11.Col = 10;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "nurse";
            this.xEditGridCell12.CellWidth = 70;
            this.xEditGridCell12.Col = 11;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell12.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 30;
            this.xEditGridCell13.CellName = "nurse_name";
            this.xEditGridCell13.CellWidth = 90;
            this.xEditGridCell13.Col = 12;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 30;
            this.xEditGridCell14.CellName = "emergency";
            this.xEditGridCell14.Col = 13;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 5;
            this.xEditGridCell15.CellName = "ho_code";
            this.xEditGridCell15.CellWidth = 35;
            this.xEditGridCell15.Col = 14;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEng;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 500;
            this.xEditGridCell16.CellName = "bigo";
            this.xEditGridCell16.CellWidth = 40;
            this.xEditGridCell16.Col = 15;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "gwa";
            this.xEditGridCell17.CellWidth = 67;
            this.xEditGridCell17.Col = 6;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell17.UserSQL = "SELECT GWA, GWA_NAME\r\n  FROM BAS0260\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r" +
                "\n   AND BUSEO_GUBUN = \'1\'\r\n   AND SYSDATE BETWEEN START_DATE AND END_DATE\r\n ORDE" +
                "R BY GWA";
            // 
            // layConfirm_yn
            // 
            this.layConfirm_yn.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layConfirm_yn.QuerySQL = resources.GetString("layConfirm_yn.QuerySQL");
            this.layConfirm_yn.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layConfirm_yn_QueryStarting_1);
            this.layConfirm_yn.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layConfirm_yn_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "confirm_yn";
            // 
            // layIsMaked
            // 
            this.layIsMaked.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layIsMaked.QuerySQL = resources.GetString("layIsMaked.QuerySQL");
            this.layIsMaked.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layIsMaked_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "maked_yn";
            // 
            // layTimeGubun
            // 
            this.layTimeGubun.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layTimeGubun.QuerySQL = resources.GetString("layTimeGubun.QuerySQL");
            this.layTimeGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTimeGubun_QueryStarting);
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "symya_gubun";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "from_time";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "to_time";
            // 
            // NUR5010U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.xPanel3);
            resources.ApplyResources(this, "$this");
            this.Name = "NUR5010U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NUR5010U00_Closing);
            this.Load += new System.EventHandler(this.NUR5010U00_Load);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeGubun)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Command

		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch (command)
			{
                case "OCS0270Q00":

                    this.grdList.SetItemValue(this.grdList.CurrentRowNumber, "doctor_name", commandParam["doctor_name"].ToString());
                    this.grdList.SetItemValue(this.grdList.CurrentRowNumber, "doctor", commandParam["doctor"].ToString());
					break;

				case "OUT0101" :

					#region 환자검색후

					try
					{
                        this.grdList.SetItemValue(this.grdList.CurrentRowNumber, "bunho", ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["bunho"]);
                        this.grdList.SetItemValue(this.grdList.CurrentRowNumber, "suname", ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["suname"]);
                        this.grdList.SetItemValue(this.grdList.CurrentRowNumber, "suname2", ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["suname2"]);
					}
					catch
					{
					}

					#endregion

					break;				
			}

			return base.Command (command, commandParam);
		}
		#endregion

        private int cnt = 0;
        private bool mIsSaveSuccess = true;
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                case FunctionType.Delete:
                case FunctionType.Update:

                    if (this.cbxConfirm_yn.Checked)
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        XMessageBox.Show(Resources.XMessageBox1, Resources.Caption1, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
            }

            switch (e.Func)
            { 
                case FunctionType.Reset:
                    e.IsBaseCall = false;
                    this.cbxTorikomi.ResetData();
                    this.cbxConfirm_yn.ResetData();
                    this.rbtAll.Checked = true;
                    this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
                    
                    this.grdList.Reset();

                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdList.QueryLayout(false);

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = false; 
                    mIsSaveSuccess = true;

                    string cmdText = "";
                    BindVarCollection bc = new BindVarCollection();
                    cnt = 0;
                    try
                    {
                        Service.BeginTransaction();

                        cmdText = @"DELETE FROM NUR5010
                                     WHERE HOSP_CODE = :f_hosp_code
                                       --AND NAEWON_DATE BETWEEN :f_from_date AND :f_to_date
                                       AND NAEWON_DATE = :f_from_date";

                        bc.Add("f_hosp_code", EnvironInfo.HospCode);
                        bc.Add("f_from_date", this.dtpFromDate.GetDataValue());

                        Service.ExecuteNonQuery(cmdText, bc);

                        if (!this.grdList.SaveLayout())
                            throw new Exception();

                        Service.CommitTransaction();
                        this.cbxTorikomi.Checked = false;
                        XMessageBox.Show(Resources.XMessageBox2, Resources.Caption2, MessageBoxIcon.Information);
                        //e.IsSuccess = true;
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                        mIsSaveSuccess = false;
                        XMessageBox.Show(Resources.XMessageBox3 + cnt + Resources.XMessageBox4 + Service.ErrFullMsg, Resources.Caption3, MessageBoxIcon.Error);

                    }

                    break;
            }
        }

        private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    this.grdList.SetItemValue(this.grdList.CurrentRowNumber, "naewon_date", this.dtpFromDate.GetDataValue());
                    break;
            }
        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layConfirm_yn.QueryLayout();

            if (this.cbxTorikomi.Checked && !this.cbxConfirm_yn.Checked) //신규데이터조회
            {
                this.grdList.QuerySQL = @"SELECT DISTINCT
                                                   A.NAEWON_DATE                                        NAEWON_DATE
                                                 , A.JUBSU_TIME                                         JUBSU_TIME
                                                 , A.ARRIVE_TIME                                        JINRYO_START_TIME
                                                 , ''                                                   JINRYO_END_TIME
                                                 , A.BUNHO                                              BUNHO 
                                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)                          SUNAME
                                                 , FN_OUT_LOAD_SUNAME2(A.BUNHO)                         SUNAME2
                                                 , A.CHOJAE                                             CHOJAE
                                                 , FN_NUR_LOAD_OUT_SANG_NAME(A.BUNHO, A.NAEWON_DATE, A.GWA)   SANG
                                                 , A.DOCTOR                                             DOCTOR
                                                 , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)     DOCTOR_NAME    
                                                 , ''                                                   NURSE_ID
                                                 , ''                                                   NURSE_NAME
                                                 , ''                                                   EMERGENCY
                                                 , B.HO_CODE1                                           HO_CODE
                                                 , ''                                                   BIGO
                                                 , A.GWA                                                GWA
                                              FROM OUT1001 A
                                                 , INP1001 B 
                                             WHERE A.HOSP_CODE           = :f_hosp_code
                                               AND B.HOSP_CODE(+)        = A.HOSP_CODE
                                               AND A.NAEWON_DATE         = :f_date 
                                               AND A.NAEWON_YN <> 'N'
                                               AND B.IPWON_DATE(+)       = A.NAEWON_DATE
                                               AND B.BUNHO(+)            = A.BUNHO
                                               AND B.JAEWON_FLAG(+)      = 'Y'
                                               AND NVL(B.CANCEL_YN, 'N') = 'N' 
                                               ";
            }
            else //저장데이타 조회
            {
                this.grdList.QuerySQL = @"SELECT A.NAEWON_DATE                                        NAEWON_DATE
                                                 , A.JUBSU_TIME                                         JUBSU_TIME
                                                 , A.JINRYO_START_TIME                                  JINRYO_START_TIME
                                                 , A.JINRYO_END_TIME                                    JINRYO_END_TIME
                                                 , A.BUNHO                                              BUNHO 
                                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)                          SUNAME
                                                 , FN_OUT_LOAD_SUNAME2(A.BUNHO)                         SUNAME2
                                                 , A.CHOJAE                                             CHOJAE
                                                 , A.SANG_NAME                                          SANG_NAME
                                                 , A.DOCTOR                                             DOCTOR
                                                 , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)     DOCTOR_NAME    
                                                 , A.NURSE                                              NURSE_ID
                                                 , FN_ADM_LOAD_USER_NAME(A.NURSE)                       NURSE_NAME
                                                 , A.EMERGENCY                                          EMERGENCY
                                                 , A.HO_CODE                                            HO_CODE
                                                 , A.BIGO                                               BIGO
                                                 , A.GWA                                                GWA
                                              FROM NUR5010 A 
                                             WHERE A.HOSP_CODE           = :f_hosp_code
                                               AND A.NAEWON_DATE         = :f_date 
                                               ";                
            }
        
            if(this.layTimeGubun.RowCount > 0)
            {
                string temp_query = @"AND ( (:f_gubun = '%') ";
                string day_query = @"";
                string over_query = @"";

                bool isDayAdded = false;
                int rowCnt = 0;

                DataRow[] rows = layTimeGubun.LayoutTable.Select(" symya_gubun = '0'"); //시간내
                foreach(DataRow row in rows)
                {
                    if (!isDayAdded)
                    {
                        day_query += " \r\n OR (:f_gubun = 'DAY' AND ( ";
                        over_query += " \r\n OR (:f_gubun = 'OVER' AND ( ";
                    }
                    isDayAdded = true;

                    //두번째부터 OR 넣어줌
                    if (rowCnt != 0)
                    {
                        day_query += " OR \r\n";
                        over_query += " AND \r\n";
                    }

                    day_query += "A.JUBSU_TIME BETWEEN '" + row["from_time"] + "' AND '" + row["to_time"] + "' ";
                    over_query += "A.JUBSU_TIME NOT BETWEEN '" + row["from_time"] + "' AND '" + row["to_time"] + "' ";

                    //마지막 데이타일 때
                    rowCnt++;
                    if (rows.Length == rowCnt)
                    {
                        day_query += " ) ";
                        over_query += " ) ";
                    }

                }
                temp_query += day_query + " ) ";
                temp_query += over_query + " ) )";
                this.grdList.QuerySQL += temp_query;

            }

            this.grdList.QuerySQL += "\r\n ORDER BY A.NAEWON_DATE, A.JUBSU_TIME, A.BUNHO, A.GWA";

            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_date", this.dtpFromDate.GetDataValue());

            if(rbtAll.Checked)
                this.grdList.SetBindVarValue("f_gubun", "%");
            if (rbtDay.Checked)
                this.grdList.SetBindVarValue("f_gubun", "DAY");
            if (rbtOver.Checked)
                this.grdList.SetBindVarValue("f_gubun", "OVER");

        }

        private void rbtAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.cbxConfirm_yn.Checked)
            //    return;
  
            this.grdList.QueryLayout(false);
        }

        private void NUR5010U00_Load(object sender, EventArgs e)
        {
            this.grdList.SavePerformer = new XSavePerformer(this);       

            DateTime sysDate = EnvironInfo.GetSysDate();
            this.dtpFromDate.SetDataValue(sysDate);

            this.layTimeGubun.QueryLayout(false);

            if (OpenParam != null)
            {
                if (OpenParam.Contains("nur_wrdt"))
                {
                    this.dtpFromDate.SetDataValue(OpenParam["nur_wrdt"].ToString());
                }
            }

            this.grdList.QueryLayout(false);
        }

        private void dtpFromDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.layIsMaked.QueryLayout();

            if (this.layIsMaked.GetItemValue("maked_yn").ToString() == "Y")
            {
                this.cbxTorikomi.Checked = false;
            }
            else
            {
                this.cbxTorikomi.Checked = true;
            }

            this.layTimeGubun.QueryLayout(false);

            this.grdList.QueryLayout(false);
        }

        private void grdList_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            switch (e.ColName)
            { 
                case "bunho":
                    XScreen.OpenScreen(this, "OUT0101Q01", ScreenOpenStyle.ResponseFixed);
                    break;

                case "doctor":
                    CommonItemCollection openParams = new CommonItemCollection();
                    openParams.Add("gwa", this.grdList.GetItemString(e.RowNumber, "gwa") == "" ? "" : this.grdList.GetItemString(e.RowNumber, "gwa"));
                    openParams.Add("word", "");
                    openParams.Add("all_gubun", "N");

                    XScreen.OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
                    break;

                case "nurse":
                    this.fwkCommon.InputSQL = @"SELECT B.USER_ID
                                                     , B.USER_NM
                                                  FROM ADM3200 B
                                                 WHERE HOSP_CODE = :f_hosp_code
                                                   AND (B.USER_END_YMD IS NULL
                                                    OR SYSDATE < B.USER_END_YMD)
                                                   AND (B.USER_ID LIKE TRIM(:f_find1)||'%'
                                                    OR B.USER_NM LIKE '%' || :f_find1 || '%')
                                                   AND B.USER_GUBUN = '2'
                                                   --AND B.DEPT_CODE = :f_buseo_code
                                                   AND B.USER_GROUP LIKE 'NUR%'
                                                 ORDER BY 1, 2";
                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("nurse", Resources.fwkCommonText1, FindColType.String, 80, 10, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos.Add("nurse_name", Resources.fwkCommonText2, FindColType.String, 120, 30, true, FilterType.InitYes);
                    break;
            }
        }

        private void grdList_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            switch (e.ColName)
            { 
                case "nurse":
                    this.grdList.SetItemValue(e.RowNumber, "nurse", e.ReturnValues[0].ToString());
                    this.grdList.SetItemValue(e.RowNumber, "nurse_name", e.ReturnValues[1].ToString());
                    break;
            }
        }

        private void fwkCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layConfirm_yn_QueryStarting_1(object sender, CancelEventArgs e)
        {
            this.layConfirm_yn.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layConfirm_yn.SetBindVarValue("f_date", this.dtpFromDate.GetDataValue());

        }

        private void layConfirm_yn_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layConfirm_yn.GetItemValue("confirm_yn").ToString() == "Y")
            {
                this.cbxConfirm_yn.Checked = true;
                this.grdList.ReadOnly = true;
            }
            else
            {
                this.cbxConfirm_yn.Checked = false;
                this.grdList.ReadOnly = false;
            }
        }

        private void layIsMaked_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layIsMaked.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layIsMaked.SetBindVarValue("f_date", this.dtpFromDate.GetDataValue());

            if (rbtAll.Checked)
                this.layIsMaked.SetBindVarValue("f_gubun", "%");
            if (rbtDay.Checked)
                this.layIsMaked.SetBindVarValue("f_gubun", "DAY");
            if (rbtOver.Checked)
                this.layIsMaked.SetBindVarValue("f_gubun", "OVER");

        }

        private void cbxTorikomi_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxConfirm_yn.Checked)
                return;

            this.grdList.QueryLayout(false);            
        }

        private void grdList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            switch (e.ColName)
            {
                case "bunho":
                    string bunho = BizCodeHelper.GetStandardBunHo(e.ChangeValue.ToString());
                    this.grdList.SetItemValue(e.RowNumber, e.ColName, bunho);

                    string cmdText = @"SELECT A.SUNAME 
                                          FROM OUT0101 A
                                         WHERE A.HOSP_CODE = :f_hosp_code
                                           AND A.BUNHO     = :f_bunho";
                    BindVarCollection bc = new BindVarCollection();
                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
                    bc.Add("f_bunho", bunho);

                    object suname = Service.ExecuteScalar(cmdText, bc);

                    if (!TypeCheck.IsNull(suname))
                    {
                        this.grdList.SetItemValue(e.RowNumber, "suname", suname);
                    }


                    break;
            }
        }

        private void layTimeGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layTimeGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layTimeGubun.SetBindVarValue("f_date", this.dtpFromDate.GetDataValue());
        }

        #region 저장로직
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR5010U00 parent = null;

            public XSavePerformer(NUR5010U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = string.Empty;

                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                parent.cnt++;

                if (callerID == '1')
                {
                    switch(item.RowState)
                    {
                        case DataRowState.Deleted:
                            return true;
                            break;
                        default:
                            cmdText = @"INSERT INTO NUR5010
                                             ( SYS_DATE           , SYS_ID            
                                             , UPD_DATE           , UPD_ID            
                                             , HOSP_CODE          
                                             , NAEWON_DATE        , JUBSU_TIME        
                                             , JINRYO_START_TIME  , JINRYO_END_TIME
                                             , BUNHO              , CHOJAE
                                             , SANG_NAME          , DOCTOR
                                             , NURSE              , EMERGENCY
                                             , HO_CODE            , BIGO
                                             , GWA                )
                                         VALUES
                                              ( SYSDATE           , :f_user_id
                                              , SYSDATE           , :f_user_id
                                              , :f_hosp_code   
                                              , :f_naewon_date       , :f_jubsu_time        
                                              , :f_jinryo_start_time  , :f_jinryo_end_time
                                              , :f_bunho              , :f_chojae
                                              , :f_sang_name          , :f_doctor
                                              , :f_nurse              , :f_emergency
                                              , :f_ho_code            , :f_bigo
                                              , :f_gwa                )";
                            break;
                    }

                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void NUR5010U00_Closing(object sender, CancelEventArgs e)
        {
            if (!this.mIsSaveSuccess)
                e.Cancel = true;

            this.mIsSaveSuccess = true;
        }


    }
}

