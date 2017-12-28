#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Schs;
#endregion

namespace IHIS.SCHS
{
	/// <summary>
	/// SCH0201Q02에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH0201Q02 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XDictComboBox cbxJundalPart;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XDataWindow dwReserList;
		private IHIS.Framework.XDatePicker dtFromDate;
		private IHIS.Framework.XDatePicker dtToDate;
		private IHIS.Framework.XDataWindow dwReserPrn;
		private IHIS.Framework.MultiLayout layReserList02;
        private IHIS.Framework.MultiLayout layReserList03;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboBox cboPrintGubun;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private const string CACHE_COMBOJUNDAL_KEYS = "SCHS.SCH0201Q02.CbJundal";

		public SCH0201Q02()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            this.cbxJundalPart.ExecuteQuery = ComboJundal;
            this.layReserList02.ExecuteQuery = GetReserList02;
            this.layReserList03.ExecuteQuery = GetReserList03;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0201Q02));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cboPrintGubun = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtToDate = new IHIS.Framework.XDatePicker();
            this.dtFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cbxJundalPart = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dwReserPrn = new IHIS.Framework.XDataWindow();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dwReserList = new IHIS.Framework.XDataWindow();
            this.layReserList02 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.layReserList03 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList03)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.cboPrintGubun);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.dtToDate);
            this.xPanel1.Controls.Add(this.dtFromDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.cbxJundalPart);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // cboPrintGubun
            // 
            this.cboPrintGubun.AccessibleDescription = null;
            this.cboPrintGubun.AccessibleName = null;
            resources.ApplyResources(this.cboPrintGubun, "cboPrintGubun");
            this.cboPrintGubun.BackgroundImage = null;
            this.cboPrintGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cboPrintGubun.Font = null;
            this.cboPrintGubun.Name = "cboPrintGubun";
            this.cboPrintGubun.SelectedValueChanged += new System.EventHandler(this.cboPrintGubun_SelectedValueChanged);
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "1";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "2";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "3";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // dtToDate
            // 
            this.dtToDate.AccessibleDescription = null;
            this.dtToDate.AccessibleName = null;
            resources.ApplyResources(this.dtToDate, "dtToDate");
            this.dtToDate.BackgroundImage = null;
            this.dtToDate.IsVietnameseYearType = false;
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtToDate_DataValidating);
            // 
            // dtFromDate
            // 
            this.dtFromDate.AccessibleDescription = null;
            this.dtFromDate.AccessibleName = null;
            resources.ApplyResources(this.dtFromDate, "dtFromDate");
            this.dtFromDate.BackgroundImage = null;
            this.dtFromDate.IsVietnameseYearType = false;
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtFromDate_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // cbxJundalPart
            // 
            this.cbxJundalPart.AccessibleDescription = null;
            this.cbxJundalPart.AccessibleName = null;
            resources.ApplyResources(this.cbxJundalPart, "cbxJundalPart");
            this.cbxJundalPart.BackgroundImage = null;
            this.cbxJundalPart.ExecuteQuery = null;
            this.cbxJundalPart.Font = null;
            this.cbxJundalPart.Name = "cbxJundalPart";
            this.cbxJundalPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxJundalPart.ParamList")));
            this.cbxJundalPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxJundalPart.SelectionChangeCommitted += new System.EventHandler(this.cbxJundalPart_SelectionChangeCommitted);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.dwReserPrn);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // dwReserPrn
            // 
            resources.ApplyResources(this.dwReserPrn, "dwReserPrn");
            this.dwReserPrn.DataWindowObject = "d_reser_list_prn";
            this.dwReserPrn.LibraryList = "SCHS\\schs.sch0201q02.pbd";
            this.dwReserPrn.Name = "dwReserPrn";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.dwReserList);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // dwReserList
            // 
            resources.ApplyResources(this.dwReserList, "dwReserList");
            this.dwReserList.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList.DataWindowObject = "d_reser_list_01";
            this.dwReserList.LibraryList = "SCHS\\schs.sch0201q02.pbd";
            this.dwReserList.LiveScroll = false;
            this.dwReserList.Name = "dwReserList";
            this.dwReserList.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_RowFocusChanged);
            this.dwReserList.Click += new System.EventHandler(this.dwReserList_Click);
            // 
            // layReserList02
            // 
            this.layReserList02.ExecuteQuery = null;
            this.layReserList02.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem51});
            this.layReserList02.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserList02.ParamList")));
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "pksch0201";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "in_out_gubun";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "fkocs";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "bunho";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "gwa";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "gumsaja";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "hangmog_code";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "jundal_table";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "jundal_part";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "reser_date";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "reser_time";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "input_date";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "input_id";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "suname";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "reser_yn";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "cancel_yn";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "acting_date";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "hope_date";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "comments";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "hangmog_name";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "gwa_name";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "upd_name";
            // 
            // layReserList03
            // 
            this.layReserList03.ExecuteQuery = null;
            this.layReserList03.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38});
            this.layReserList03.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserList03.ParamList")));
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "reser_date";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "suname";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "in_out_gubun";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "bunho";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "acting_date";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "comments";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "jundal_part_name";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "gwa_name";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "upd_name";
            // 
            // SCH0201Q02
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "SCH0201Q02";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layReserList02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList03)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad

        // 조회조건에 따라 쿼리할 레이아웃을 바꿔준다
        MultiLayout mQueryLay = null;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			// 현재 오픈한 시스템이 어디냐에 따라 메인 DataWindow의 오브젝트를 달리 한다.

            cbxJundalPart.SetDictDDLB();
            cbxJundalPart.SetDataValue("%");
            dtFromDate.SetDataValue(DateTime.Now);
            dtToDate.SetDataValue(DateTime.Now);

			if (EnvironInfo.CurrSystemID == "INPS" || 
				EnvironInfo.CurrSystemID == "OUTS" ||
				EnvironInfo.CurrSystemID == "CHTS"   )
			{
				// 의사회계는 자세히는 안봐도 되니까 디폴트로 이걸로
				// 디스플레이 용
				this.dwReserList.DataWindowObject = "d_reser_list_02";
                ApplyMultiLangForReserList02();
                //this.dsvReserList02.WorkTp = '3';
                //this.dsvReserList02.MOutputLayout = this.layReserList03;
                mQueryLay = this.layReserList03;

				// 프린트용
				this.dwReserPrn.DataWindowObject = "d_reser_list_prn2";
                ApplyMultiLangForReserPrn2();
				this.cboPrintGubun.SetDataValue("2");
			}
			else
			{
				// 딴데는 잘 모르니깐 자세한걸로...
				// 디스플레이 용
				this.dwReserList.DataWindowObject = "d_reser_list_01";
                ApplyMultiLangForReserList();
                //this.dsvReserList02.WorkTp = '2';
                //this.dsvReserList02.MOutputLayout = this.layReserList02;
                mQueryLay = this.layReserList02;

				// 프린트 용
				this.dwReserPrn.DataWindowObject = "d_reser_list_prn";
                ApplyMultiLangForReserPrn();
				this.cboPrintGubun.SetDataValue("1");
			}

            ReserList01Query();
//			if (TypeCheck.IsNull(cbxJundalPart.GetDataValue().ToString()) == false)
//			{
//				ReserList01Query();
//			}
		}
		#endregion

		#region Reser List Query
		private void ReserList01Query()
		{
            dwReserList.Reset();
            layReserList02.Reset();

            mQueryLay.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            mQueryLay.SetBindVarValue("f_gwa", cbxJundalPart.GetDataValue());
            mQueryLay.SetBindVarValue("f_from_date", dtFromDate.GetDataValue());
            mQueryLay.SetBindVarValue("f_to_date", dtToDate.GetDataValue());

            if (mQueryLay.QueryLayout(true))
            {
                if (this.mQueryLay.RowCount > 0)
                {
                    // 잠시
                    //dwReserList.FillData(this.dsvReserList02.MOutputLayout);
                    this.dwReserList.FillData(this.mQueryLay.LayoutTable);
                    dwReserList.Refresh();
                }
            }
		}
		#endregion

		#region [dw       ]
		private void dwReserList_Click(object sender, System.EventArgs e)
		{
			dwReserList.Refresh();
		}

		private void dwReserList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList.Refresh();
		}
		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch( e.Func )
			{
				case FunctionType.Query:
					e.IsBaseCall = false;

					// 검사종목 조회
					ReserList01Query();

					break;
				case FunctionType.Print:
					e.IsBaseCall = false;
                    if (this.mQueryLay.RowCount > 0)
					{
						dwReserPrn.Reset();
                        dwReserPrn.FillData(this.mQueryLay.LayoutTable);

						string FromDate = "t_from_date.text = '" + dtFromDate.GetDataValue() + "'";
						string ToDate   = "t_to_date.text = '" + dtToDate.GetDataValue() + "'";
						dwReserPrn.Modify(FromDate);
						dwReserPrn.Modify(ToDate);
						dwReserPrn.Refresh();

						try
						{
							dwReserPrn.Print();
						}
						catch
						{
						}
					}
					break;
				default:
					break;
			}
		}

		#endregion

		#region XComboBox  콤보 박스

		#region 출력구분 콤보

		private void cboPrintGubun_SelectedValueChanged(object sender, System.EventArgs e)
		{
			switch (this.cboPrintGubun.SelectedValue.ToString())
			{
				case "1":   // 과별 상세

					// 디스플레이 용
					this.dwReserList.DataWindowObject = "d_reser_list_01";
                    ApplyMultiLangForReserList();
                    //this.dsvReserList02.WorkTp = '2';
                    //this.dsvReserList02.MOutputLayout = this.layReserList02;
                    mQueryLay = this.layReserList02;

					// 프린트 용
					this.dwReserPrn.DataWindowObject = "d_reser_list_prn";
                    ApplyMultiLangForReserPrn();
					break;
				case "2":   // 과별 내역
					
					// 디스플레이 용
					this.dwReserList.DataWindowObject = "d_reser_list_02";
                    ApplyMultiLangForReserList02();
                    //this.dsvReserList02.WorkTp = '3';
                    //this.dsvReserList02.MOutputLayout = this.layReserList03;
                    mQueryLay = this.layReserList03;

					// 프린트용
					this.dwReserPrn.DataWindowObject = "d_reser_list_prn2";
                    ApplyMultiLangForReserPrn2();
					break;
				case "3":   // 환자별 별도 내역

					// 디스플레이 용
					this.dwReserList.DataWindowObject = "d_reser_list_03";
                    ApplyMultiLangForReserList03();
                    //this.dsvReserList02.WorkTp = '2';
                    //this.dsvReserList02.MOutputLayout = this.layReserList02;
                    mQueryLay = this.layReserList02;

					// 프린트 용
					this.dwReserPrn.DataWindowObject = "d_reser_list_prn3";
                    ApplyMultiLangForReserPrn3();
					break;
			}

			this.btnList.PerformClick(FunctionType.Query);
		}

		#endregion

		#region 과 콤보

		private void cbxJundalPart_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			if (TypeCheck.IsNull(cbxJundalPart.GetDataValue().ToString()) == false)
			{
				ReserList01Query();
			}
		}

		#endregion

		#endregion

		#region XDatePicker 조회일자

		private void dtFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.btnList.PerformClick(FunctionType.Query);
		}

        private void dtToDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.btnList.PerformClick(FunctionType.Query);
		}

		#endregion


        #region Updated code

        #region ComboJundal
        /// <summary>
        /// ComboJundal
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> ComboJundal(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            SchsSCH0201Q02JundalComboListResult res = CacheService.Instance.Get<SchsSCH0201Q02JundalComboListArgs, SchsSCH0201Q02JundalComboListResult>(
                new SchsSCH0201Q02JundalComboListArgs(), delegate(SchsSCH0201Q02JundalComboListResult result)
                {
                    return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                           result.ComboListItem != null && result.ComboListItem.Count > 0;
                });

            if (res != null && res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in res.ComboListItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetReserList02
        /// <summary>
        /// GetReserList02
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetReserList02(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            SchsSCH0201Q02ReserList02Args args = new SchsSCH0201Q02ReserList02Args();
            args.Gwa = cbxJundalPart.GetDataValue();
            args.FromDate = dtFromDate.GetDataValue();
            args.ToDate = dtToDate.GetDataValue();
            SchsSCH0201Q02ReserList02Result res = CloudService.Instance.Submit<SchsSCH0201Q02ReserList02Result,
                SchsSCH0201Q02ReserList02Args>(args);

            if (null != res)
            {
                foreach (SchsSCH0201Q02ReserList02ItemInfo item in res.ReserList02Item)
                {
                    lObj.Add(new object[]
                    {
                        item.Pksch0201,
                        item.InOutGubun,
                        item.Fkocs,
                        item.Bunho,
                        item.Gwa,
                        item.Gumsaja,
                        item.HangmogCode,
                        item.JundalTable,
                        item.JundalPart,
                        item.ReserDate,
                        item.ReserTime,
                        item.InputDate,
                        item.InputId,
                        item.Suname,
                        item.ReserYn,
                        item.CancelYn,
                        item.ActingDate,
                        item.HopeDate,
                        item.Comments,
                        item.HangmogName,
                        item.GwaName,
                        //item.UpdName,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetReserList03
        /// <summary>
        /// GetReserList03
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetReserList03(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            SchsSCH0201Q02ReserList03Args args = new SchsSCH0201Q02ReserList03Args();
            args.FromDate = dtFromDate.GetDataValue();
            args.ToDate = dtToDate.GetDataValue();
            args.Gwa = cbxJundalPart.GetDataValue();
            SchsSCH0201Q02ReserList03Result res = CloudService.Instance.Submit<SchsSCH0201Q02ReserList03Result,
                SchsSCH0201Q02ReserList03Args>(args);

            if (null != res)
            {
                foreach (SchsSCH0201Q02ReserList03ItemInfo item in res.ReserList03Item)
                {
                    lObj.Add(new object[]
                    {
                        item.ReserDate,
                        item.Suname,
                        item.InOutGubun,
                        item.Bunho,
                        item.ActingDate,
                        item.Comments,
                        item.JundalPartName,
                        item.GwaName,
                        item.UpdName,
                        item.ContKey,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #endregion

        #region Apply multi languages

        private void ApplyMultiLangForReserList()
        {
            //dwReserList
            try
            {
                dwReserList.Refresh();
                dwReserList.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_1));
                dwReserList.Modify(string.Format("t_6.text = '{0}'", Resources.DW_TXT_2));
                dwReserList.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_3));
                dwReserList.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_4));
                dwReserList.Modify(string.Format("panm_t.text = '{0}'", Resources.DW_TXT_5));
                dwReserList.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_6));
                dwReserList.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_7));
                dwReserList.Modify(string.Format("t_7.text = '{0}'", Resources.DW_TXT_8));
                if (NetInfo.Language != LangMode.Jr)
                {
                    dwReserList.Modify(string.Format("t_4.Font.Face='{0}'", Service.COMMON_FONT.Name)); // font thuong
                    dwReserList.Modify(string.Format("t_6.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("panm_t.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("t_2.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("t_1.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("t_3.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("t_5.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("t_7.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("gwa_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("reser_date.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("bunho.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("hangmog_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("reser_time.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("suname.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReserList.Modify(string.Format("acting_date.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    //dwReserList.Modify(string.Format("comments..Font.Face='{0}'", Service.COMMON_FONT.Name));
                    //dwReserList.Modify(string.Format("upd_name.Font.Face='{0}'", Service.COMMON_FONT.Name));

                    //set Height
                    dwReserList.Modify("t_4.Font.Height = '14'");
                    dwReserList.Modify("t_6.Font.Height = '14'");
                    dwReserList.Modify("panm_t.Font.Height = '14'");
                    dwReserList.Modify("t_2.Font.Height = '14'");
                    dwReserList.Modify("t_1.Font.Height = '14'");
                    dwReserList.Modify("t_3.Font.Height = '14'");
                    dwReserList.Modify("t_5.Font.Height = '14'");
                    dwReserList.Modify("t_7.Font.Height = '14'");
                    dwReserList.Modify("gwa_name.Font.Height = '14'");
                    dwReserList.Modify("reser_date.Font.Height = '14'");
                    dwReserList.Modify("bunho.Font.Height = '14'");
                    dwReserList.Modify("hangmog_name.Font.Height = '14'");
                    dwReserList.Modify("reser_time.Font.Height = '14'");
                    dwReserList.Modify("suname.Font.Height = '14'");
                    dwReserList.Modify("acting_date.Font.Height = '14'");
                }
                
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }

        private void ApplyMultiLangForReserList02()
        {
            try
            {
                //dwReserList02
                dwReserList.Refresh();
                dwReserList.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_9));
                dwReserList.Modify(string.Format("t_6.text = '{0}'", Resources.DW_TXT_10));
                dwReserList.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_11));
                dwReserList.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_12));
                dwReserList.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_13));
                dwReserList.Modify(string.Format("t_7.text = '{0}'", Resources.DW_TXT_14));
                dwReserList.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_15));
                dwReserList.Modify(string.Format("t_9.text = '{0}'", Resources.DW_TXT_16));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }

        private void ApplyMultiLangForReserList03()
        {
            try
            {
                //dwReserList03
                dwReserList.Refresh();
                dwReserList.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_17));
                dwReserList.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_18));
                dwReserList.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_19));
                dwReserList.Modify(string.Format("panm_t.text = '{0}'", Resources.DW_TXT_20));
                dwReserList.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_21));
                dwReserList.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_22));
                dwReserList.Modify(string.Format("t_6.text = '{0}'", Resources.DW_TXT_23));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }

        private void ApplyMultiLangForReserPrn()
        {
            try
            {
                //dwReserPrn
                dwReserPrn.Modify(string.Format("t_6.text = '{0}'", Resources.DW_TXT_24));
                dwReserPrn.Modify(string.Format("t_7.text = '{0}'", Resources.DW_TXT_25));
                dwReserPrn.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_26));
                dwReserPrn.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_27));
                dwReserPrn.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_28));
                dwReserPrn.Modify(string.Format("panm_t.text = '{0}'", Resources.DW_TXT_29));
                dwReserPrn.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_30));
                dwReserPrn.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_31));
                dwReserPrn.Modify(string.Format("t_8.text = '{0}'", Resources.DW_TXT_32));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }

        private void ApplyMultiLangForReserPrn2()
        {
            try
            {
                //dwReserPrn2
                dwReserPrn.Modify(string.Format("t_6.text = '{0}'", Resources.DW_TXT_33));
                dwReserPrn.Modify(string.Format("t_7.text = '{0}'", Resources.DW_TXT_34));
                dwReserPrn.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_35));
                dwReserPrn.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_36));
                dwReserPrn.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_37));
                dwReserPrn.Modify(string.Format("t_8.text = '{0}'", Resources.DW_TXT_38));
                dwReserPrn.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_39));
                dwReserPrn.Modify(string.Format("t_10.text = '{0}'", Resources.DW_TXT_40));
                dwReserPrn.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_41));
                dwReserPrn.Modify(string.Format("t_11.text = '{0}'", Resources.DW_TXT_42));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }

        private void ApplyMultiLangForReserPrn3()
        {
            try
            {
                //dwReserPrn3
                dwReserPrn.Modify(string.Format("t_6.text = '{0}'", Resources.DW_TXT_43));
                dwReserPrn.Modify(string.Format("t_7.text = '{0}'", Resources.DW_TXT_44));
                dwReserPrn.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_45));
                dwReserPrn.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_46));
                dwReserPrn.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_47));
                dwReserPrn.Modify(string.Format("panm_t.text = '{0}'", Resources.DW_TXT_48));
                dwReserPrn.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_49));
                dwReserPrn.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_50));
                dwReserPrn.Modify(string.Format("t_8.text = '{0}'", Resources.DW_TXT_51));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }
        #endregion
    }
}

