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
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector;
using IHIS.Framework;
using IHIS.CloudConnector.Caching;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using Sybase.DataWindow;
using System.Reflection;
using IHIS.SCHS.Properties;
#endregion

namespace IHIS.SCHS
{
	/// <summary>
	/// SCH0201Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH0201Q01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XDictComboBox cbxJundalPart;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.MultiLayout layReserList01;
		private IHIS.Framework.XDataWindow dwReserList;
		private IHIS.Framework.XDatePicker dtFromDate;
        private IHIS.Framework.XDatePicker dtToDate;
        private IHIS.Framework.XDataWindow dwReserPrn;
        private XLabel xLabel12;
        private XDictComboBox cboGumsa;
        private MultiLayout layCheckJundalTable;
        private MultiLayoutItem multiLayoutItem29;
        private SingleLayout layExistsJundalTable;
        private SingleLayoutItem singleLayoutItem1;
        private XPanel pnlRbx;
        private XRadioButton rbxPart;
        private XRadioButton rbxPatient;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
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
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private const string CACHE_COMBOGUMSA_KEYS = "SCHS.SCH0201Q01.CmbGumsa";

		public SCH0201Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            this.cboGumsa.ExecuteQuery = ComboGumsa;
            this.cbxJundalPart.ExecuteQuery = ComboJundal;
            this.layReserList01.ExecuteQuery = GetReserList;

            if (!NetInfo.Language.Equals(LangMode.Jr))
            {
                xLabel2.Size = new Size(80, 23);
                xLabel12.Size = new Size(85, 23);
                xLabel1.Size = new Size(90, 23);
                xLabel1.Font = new System.Drawing.Font("Arial", 8.75F);
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0201Q01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pnlRbx = new IHIS.Framework.XPanel();
            this.rbxPart = new IHIS.Framework.XRadioButton();
            this.rbxPatient = new IHIS.Framework.XRadioButton();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.cboGumsa = new IHIS.Framework.XDictComboBox();
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
            this.layReserList01 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.layCheckJundalTable = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.layExistsJundalTable = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.pnlRbx.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCheckJundalTable)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.pnlRbx);
            this.xPanel1.Controls.Add(this.xLabel12);
            this.xPanel1.Controls.Add(this.cboGumsa);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.dtToDate);
            this.xPanel1.Controls.Add(this.dtFromDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.cbxJundalPart);
            this.xPanel1.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // pnlRbx
            // 
            this.pnlRbx.Controls.Add(this.rbxPart);
            this.pnlRbx.Controls.Add(this.rbxPatient);
            resources.ApplyResources(this.pnlRbx, "pnlRbx");
            this.pnlRbx.Name = "pnlRbx";
            // 
            // rbxPart
            // 
            resources.ApplyResources(this.rbxPart, "rbxPart");
            this.rbxPart.Checked = true;
            this.rbxPart.FlatAppearance.BorderSize = 2;
            this.rbxPart.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSeaGreen;
            this.rbxPart.Name = "rbxPart";
            this.rbxPart.TabStop = true;
            this.rbxPart.UseVisualStyleBackColor = true;
            this.rbxPart.CheckedChanged += new System.EventHandler(this.rbxPart_CheckedChanged);
            // 
            // rbxPatient
            // 
            resources.ApplyResources(this.rbxPatient, "rbxPatient");
            this.rbxPatient.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSeaGreen;
            this.rbxPatient.Name = "rbxPatient";
            this.rbxPatient.UseVisualStyleBackColor = true;
            this.rbxPatient.CheckedChanged += new System.EventHandler(this.rbxPart_CheckedChanged);
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Name = "xLabel12";
            // 
            // cboGumsa
            // 
            this.cboGumsa.ExecuteQuery = null;
            resources.ApplyResources(this.cboGumsa, "cboGumsa");
            this.cboGumsa.Name = "cboGumsa";
            this.cboGumsa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGumsa.ParamList")));
            this.cboGumsa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGumsa.UserSQL = resources.GetString("cboGumsa.UserSQL");
            this.cboGumsa.SelectedIndexChanged += new System.EventHandler(this.cboGumsa_SelectedIndexChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // dtToDate
            // 
            resources.ApplyResources(this.dtToDate, "dtToDate");
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtToDate_DataValidating);
            // 
            // dtFromDate
            // 
            resources.ApplyResources(this.dtFromDate, "dtFromDate");
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtFromDate_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // cbxJundalPart
            // 
            this.cbxJundalPart.ExecuteQuery = null;
            resources.ApplyResources(this.cbxJundalPart, "cbxJundalPart");
            this.cbxJundalPart.Name = "cbxJundalPart";
            this.cbxJundalPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxJundalPart.ParamList")));
            this.cbxJundalPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxJundalPart.UserSQL = resources.GetString("cbxJundalPart.UserSQL");
            this.cbxJundalPart.SelectionChangeCommitted += new System.EventHandler(this.cbxJundalPart_SelectionChangeCommitted);
            this.cbxJundalPart.DDLBSetting += new System.EventHandler(this.cbxJundalPart_DDLBSetting);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.dwReserPrn);
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // dwReserPrn
            // 
            this.dwReserPrn.DataWindowObject = "d_reser_list_prn";
            this.dwReserPrn.LibraryList = "SCHS\\schs.sch0201q01.pbd";
            resources.ApplyResources(this.dwReserPrn, "dwReserPrn");
            this.dwReserPrn.Name = "dwReserPrn";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.dwReserList);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // dwReserList
            // 
            this.dwReserList.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList.DataWindowObject = "d_reser_list_01";
            resources.ApplyResources(this.dwReserList, "dwReserList");
            this.dwReserList.LibraryList = "SCHS\\schs.sch0201q01.pbd";
            this.dwReserList.LiveScroll = false;
            this.dwReserList.Name = "dwReserList";
            this.dwReserList.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwReserList.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_RowFocusChanged);
            this.dwReserList.Click += new System.EventHandler(this.dwReserList_Click);
            // 
            // layReserList01
            // 
            this.layReserList01.ExecuteQuery = null;
            this.layReserList01.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
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
            this.multiLayoutItem30,
            this.multiLayoutItem31});
            this.layReserList01.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserList01.ParamList")));
            this.layReserList01.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layReserList01_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pksch0201";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "in_out_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "fkocs";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "bunho";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "gwa";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "gumsaja";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "hangmog_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "jundal_table";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "jundal_part";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "reser_date";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "reser_time";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "input_date";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "input_id";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "suname";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "reser_yn";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "cancel_yn";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "acting_date";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "hope_date";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "comments";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "hangmog_name";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "jundal_part_name";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "gwa_name";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "ho_dong";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "sex";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "age";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "birth";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "input_gwa";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "doctor_name";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "upd_name";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "portable_yn";
            // 
            // layCheckJundalTable
            // 
            this.layCheckJundalTable.ExecuteQuery = null;
            this.layCheckJundalTable.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem29});
            this.layCheckJundalTable.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCheckJundalTable.ParamList")));
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "jundal_table";
            // 
            // layExistsJundalTable
            // 
            this.layExistsJundalTable.ExecuteQuery = null;
            this.layExistsJundalTable.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layExistsJundalTable.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layExistsJundalTable.ParamList")));
            this.layExistsJundalTable.QuerySQL = resources.GetString("layExistsJundalTable.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "isExist";
            // 
            // SCH0201Q01
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "SCH0201Q01";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.SCH0201Q01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.pnlRbx.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layReserList01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCheckJundalTable)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
		}
		#endregion

        #region SCH0201Q01_ScreenOpen

        string mJundalTable = "";
        string mHangmogCode = "";

        private void SCH0201Q01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            mJundalTable = "";
            mHangmogCode = "";

            dtFromDate.SetDataValue(DateTime.Now);
            dtToDate.SetDataValue(DateTime.Now);

            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("jundal_table"))
                {
                    mJundalTable = this.OpenParam["jundal_table"].ToString();
                }

                if (this.OpenParam.Contains("hangmog_code"))
                {
                    mHangmogCode = this.OpenParam["hangmog_code"].ToString();
                }

                ////this.layExistsJundalTable.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                ////this.layExistsJundalTable.SetBindVarValue("f_hangmog_code", mHangmogCode);
                ////this.layExistsJundalTable.SetBindVarValue("f_jundal_table", mJundalTable);
                ////this.layExistsJundalTable.QueryLayout();

                ////if (this.layExistsJundalTable.GetItemValue("isExist").ToString() != "Y")
                ////{
                //this.layCheckJundalTable.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                //this.layCheckJundalTable.SetBindVarValue("f_hangmog_code", mHangmogCode);
                //this.layCheckJundalTable.QueryLayout(true);

                //if (this.layCheckJundalTable.RowCount > 0)
                //{
                //    this.mJundalTable = this.layCheckJundalTable.GetItemString(0, "jundal_table");
                //}
                ////}
                //this.cboGumsa.SetEditValue(this.mJundalTable);

            }
            ApplyMultiLanguages();
            this.cboGumsa.SetDictDDLB();
            this.cboGumsa.SetEditValue("%");

            //QueryByJundalTable();
        }
        #endregion

        #region Reser List Query
        private void ReserList01Query(string jundal_table, string jundal_part)
		{
			dwReserList.Reset();
			layReserList01.Reset();

            if (this.layReserList01.QueryLayout(true))
            {
                this.dwReserList.FillData(this.layReserList01.LayoutTable);
                this.dwReserList.Refresh();
            }

            #region comments
//            //string jundal_table = "", jundal_part = "";

//            jundal_table = cboGumsa.GetDataValue();
//            jundal_part = cbxJundalPart.GetDataValue();

//            this.layReserList01.QuerySQL = @"SELECT  DISTINCT
//                                                    --A.PKSCH0201                                                             PKSCH0201
//                                                    DECODE(A.JUNDAL_TABLE, 'CPL', '', A.PKSCH0201)                          PKSCH0201
//                                                   ,A.IN_OUT_GUBUN                                                          IN_OUT_GUBUN
//                                                   --,A.FKOCS                                                                 FKOCS
//                                                   ,DECODE(A.JUNDAL_TABLE, 'CPL', '', A.FKOCS)                              FKOCS
//                                                   ,A.BUNHO                                                                 BUNHO
//                                                   ,A.GWA                                                                   GWA
//                                                   ,A.GUMSAJA                                                               GUMSAJA
//                                                   --,A.HANGMOG_CODE                                                          HANGMOG_CODE
//                                                   ,DECODE(A.JUNDAL_TABLE, 'CPL', '', A.HANGMOG_CODE)                       HANGMOG_CODE
//                                                   ,A.JUNDAL_TABLE                                                          JUNDAL_TABLE
//                                                   ,A.JUNDAL_PART                                                           JUNDAL_PART
//                                                   ,TO_CHAR(A.RESER_DATE, 'YYYY/MM/DD')                                     RESER_DATE
//                                                   ,A.RESER_TIME                                                            RESER_TIME
//                                                   ,TO_CHAR(A.INPUT_DATE, 'YYYY/MM/DD')                                     INPUT_DATE
//                                                   ,A.INPUT_ID                                                              INPUT_ID
//                                                   ,DECODE(A.FKOCS, NULL, FN_SCH_LOAD_CODE_NAME('SOGAE_TEXT', '01'), '') || B.SUNAME || ' [' ||  B.SUNAME2 || ']'      SUNAME
//                                                   ,A.RESER_YN                                                              RESER_YN
//                                                   ,A.CANCEL_YN                                                             CANCEL_YN
//                                                   ,TO_CHAR(A.ACTING_DATE, 'YYYY/MM/DD')                                    ACTING_DATE
//                                                   ,TO_CHAR(A.HOPE_DATE, 'YYYY/MM/DD')                                      HOPE_DATE
//                                                   ,A.COMMENTS                                                              COMMENTS
//                                                   --,DECODE(A.JUNDAL_TABLE,'CPL',D.JUNDAL_PART_NAME, C.HANGMOG_NAME) ||      
//                                                   ,DECODE(A.JUNDAL_TABLE,'CPL', '検体検査' || '[' || A.Order_Date || ':GR-' || FN_SCH_OCS_GROUP_SER(A.HOSP_CODE, A.FKOCS) ||']', C.HANGMOG_NAME) ||
//                                                    DECODE(NVL(A.JUSA_RESER_YN,'N'),'Y','('||FN_ADM_MSG(4108)||')','')      HANGMOG_NAME
//                                                   ,NVL(D.JUNDAL_PART_NAME, FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.RESER_DATE))   JUNDAL_PART_NAME
//                                                   ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.INPUT_DATE)                               GWA_NAME
//                                                   ,HO_DONG1                                                                HO_DONG1
//                                                   ,B.SEX                                                                   SEX
//                                                   ,FN_BAS_LOAD_AGE(TRUNC(SYSDATE), B.BIRTH, NULL)                          AGE
//                                                   ,B.BIRTH                                                                 BIRTH
//                                                   ,DECODE(A.IN_OUT_GUBUN, 'I', FN_BAS_LOAD_GWA_NAME(E.HO_DONG1, TRUNC(SYSDATE))|| '-' || E.HO_CODE1,
//                                                                           'O', FN_BAS_LOAD_GWA_NAME(A.GWA     , TRUNC(SYSDATE))) INPUT_GWA
//                                                   ,FN_SCH_LOAD_DOCTOR_NAME(A.IN_OUT_GUBUN, A.FKOCS)                        DOCTOR_NAME
//                                                   ,FN_ADM_LOAD_USER_NAME(A.UPD_ID)                                         UPD_NAME
//                                            --       ,A.JUNDAL_PART||TO_CHAR(A.RESER_DATE, 'yyyy/mm/dd')||A.RESER_TIME||A.BUNHO||A.PKSCH0201
//                                                   ,DECODE((SELECT Z.PORTABLE_YN
//                                                              FROM OCS2003 Z
//                                                             WHERE Z.HOSP_CODE = 'K01'
//                                                               AND Z.PKOCS2003 = A.FKOCS), 'Y', '○', '')                   PORTABLE_YN
//                                              FROM INP1001 E,
//                                                   SCH0001 D,
//                                                   OCS0103 C,
//                                                   OUT0101 B,
//                                                   SCH0201 A
//                                             WHERE A.HOSP_CODE     = :f_hosp_code
//                                               AND B.HOSP_CODE(+)  = A.HOSP_CODE
//                                               AND C.HOSP_CODE     = A.HOSP_CODE
//                                               AND D.HOSP_CODE(+)  = A.HOSP_CODE
//                                               AND E.HOSP_CODE(+)  = A.HOSP_CODE
//                                               AND A.RESER_DATE    BETWEEN TO_DATE(:f_from_date,'yyyy/mm/dd') AND TO_DATE(:f_to_date,'yyyy/mm/dd')
//                                               AND A.JUNDAL_TABLE  LIKE '%' ||:f_jundal_table||'%'
//                                               AND (A.JUNDAL_PART   LIKE '%' ||:f_jundal_part||'%' OR A.JUNDAL_TABLE  LIKE '%' ||:f_jundal_part||'%')
//                                               AND A.RESER_YN      = 'Y'
//                                               AND NVL(A.CANCEL_YN,'N') = 'N'
//                                               --AND FN_SCH_ORDER_CHK(A.IN_OUT_GUBUN, A.FKOCS) = 'Y'
//                                               AND B.BUNHO        (+)= A.BUNHO
//                                               AND C.HANGMOG_CODE  = A.HANGMOG_CODE
//                                               AND D.JUNDAL_PART  (+)= A.JUNDAL_PART
//                                               AND E.BUNHO        (+)= A.BUNHO
//                                               AND E.TOIWON_DATE  (+) IS NULL
//                                             UNION ALL
//                                             SELECT DISTINCT
//                                                    --A.PKSCH0201                                                             PKSCH0201
//                                                    DECODE(A.JUNDAL_TABLE, 'CPL', '', A.PKSCH0201)                          PKSCH0201
//                                                   ,A.IN_OUT_GUBUN                                                          IN_OUT_GUBUN
//                                                   --,A.FKOCS                                                                 FKOCS
//                                                   ,DECODE(A.JUNDAL_TABLE, 'CPL', '', A.FKOCS)                              FKOCS
//                                                   ,A.BUNHO                                                                 BUNHO
//                                                   ,A.GWA                                                                   GWA
//                                                   ,A.GUMSAJA                                                               GUMSAJA
//                                                   --,A.HANGMOG_CODE                                                          HANGMOG_CODE
//                                                   ,DECODE(A.JUNDAL_TABLE, 'CPL', '', A.HANGMOG_CODE)                       HANGMOG_CODE
//                                                   ,A.JUNDAL_TABLE                                                          JUNDAL_TABLE
//                                                   ,A.JUNDAL_PART                                                           JUNDAL_PART
//                                                   ,TO_CHAR(A.RESER_DATE, 'YYYY/MM/DD')                                     RESER_DATE
//                                                   ,A.RESER_TIME                                                            RESER_TIME
//                                                   ,TO_CHAR(A.INPUT_DATE, 'YYYY/MM/DD')                                     INPUT_DATE
//                                                   ,A.INPUT_ID                                                              INPUT_ID
//                                                   ,DECODE(A.FKOCS, NULL, FN_SCH_LOAD_CODE_NAME('SOGAE_TEXT', '01'), '')|| B.SUNAME || ' [' ||  B.SUNAME2 || ']'      SUNAME
//                                                   ,A.RESER_YN                                                              RESER_YN
//                                                   ,A.CANCEL_YN                                                             CANCEL_YN
//                                                   ,TO_CHAR(A.ACTING_DATE, 'YYYY/MM/DD')                                    ACTING_DATE
//                                                   ,TO_CHAR(A.HOPE_DATE, 'YYYY/MM/DD')                                      HOPE_DATE
//                                                   ,A.COMMENTS                                                              COMMENTS
//                                                   --,DECODE(A.JUNDAL_TABLE,'CPL', '検体検査' || '[' || A.Order_Date || ':GR-' || FN_SCH_OCS_GROUP_SER(A.HOSP_CODE, A.FKOCS) ||']', C.HANGMOG_NAME) ||
//                                                   ,DECODE(A.JUNDAL_TABLE,'CPL',D.JUNDAL_PART_NAME, C.HANGMOG_NAME) ||
//                                                    DECODE(NVL(A.JUSA_RESER_YN,'N'),'Y','('||FN_ADM_MSG(4108)||')','')      HANGMOG_NAME
//                                                   ,NVL(D.JUNDAL_PART_NAME, FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.RESER_DATE))   JUNDAL_PART_NAME
//                                                   ,''                                                                      GWA_NAME
//                                                   ,''                                                                      HO_DONG1
//                                                   ,B.SEX                                                                   SEX
//                                                   ,FN_BAS_LOAD_AGE(TRUNC(SYSDATE), B.BIRTH, NULL)                          AGE
//                                                   ,B.BIRTH                                                                 BIRTH
//                                                   ,''                                                                      INPUT_GWA
//                                                   ,''                                                                      DOCTOR_NAME
//                                                   ,FN_ADM_LOAD_USER_NAME(A.UPD_ID)                                         UPD_NAME
//                                                   --,A.JUNDAL_PART||TO_CHAR(A.RESER_DATE, 'yyyy/mm/dd')||A.RESER_TIME||A.BUNHO||A.PKSCH0201
//                                                   ,''                                                                      PORTABLE_YN
//                                              FROM SCH0001 D,
//                                                   OCS0103 C,
//                                                   OUT0101 B,
//                                                   SCH0201 A
//                                             WHERE A.HOSP_CODE     = :f_hosp_code
//                                               AND B.HOSP_CODE(+)  = A.HOSP_CODE
//                                               AND C.HOSP_CODE     = A.HOSP_CODE
//                                               AND D.HOSP_CODE(+)  = A.HOSP_CODE
//                                               AND A.RESER_DATE         BETWEEN TO_DATE(:f_from_date,'yyyy/mm/dd') AND TO_DATE(:f_to_date,'yyyy/mm/dd')
//                                               AND A.JUNDAL_TABLE  LIKE '%' ||:f_jundal_table||'%'
//                                               AND (A.JUNDAL_PART   LIKE '%' ||:f_jundal_part||'%' OR A.JUNDAL_TABLE  LIKE '%' ||:f_jundal_part||'%')
//                                               AND NVL(A.CANCEL_YN,'N') = 'N'
//                                               AND A.IN_OUT_GUBUN       = 'X'
//                                               AND B.BUNHO           (+)= A.BUNHO
//                                               AND C.HANGMOG_CODE       = A.HANGMOG_CODE
//                                               AND D.JUNDAL_PART     (+)= A.JUNDAL_PART 
//                                             ";

//            if (this.rbxPatient.Checked)// 환자별 별도 내역
//            {
//                this.layReserList01.QuerySQL += @"ORDER BY 4 /*BUNHO*/ , 10 /*RESER_DATE*/ , 11 /*RESER_TIME*/  ";
//                // 디스플레이 용
//                this.dwReserList.DataWindowObject = "d_reser_list_pa";

//                // 프린트 용
//                this.dwReserPrn.DataWindowObject = "d_reser_list_pa_prn";
//            }
//            else //파트별
//            {
//                this.layReserList01.QuerySQL += @"ORDER BY 9 /*JUNDAL_PART*/ , 10 /*RESER_DATE*/ , 11 /*RESER_TIME*/ , 4 /*BUNHO*/";
//                // 디스플레이 용
//                this.dwReserList.DataWindowObject = "d_reser_list_01";

//                // 프린트 용
//                this.dwReserPrn.DataWindowObject = "d_reser_list_prn";
//            }

//            this.layReserList01.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//            this.layReserList01.SetBindVarValue("f_jundal_table", jundal_table);
//            this.layReserList01.SetBindVarValue("f_jundal_part", jundal_part);
//            this.layReserList01.SetBindVarValue("f_from_date", dtFromDate.GetDataValue());
//            this.layReserList01.SetBindVarValue("f_to_date", dtToDate.GetDataValue());

//            if (this.layReserList01.QueryLayout(true))
//            {
//                dwReserList.FillData(layReserList01.LayoutTable);
//                dwReserList.Refresh();
//            }
            #endregion
        }
		#endregion

		#region dw
		private void dwReserList_Click(object sender, System.EventArgs e)
		{
			dwReserList.Refresh();
		}

		private void dwReserList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList.Refresh();
		}
		#endregion

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch( e.Func )
			{
				case FunctionType.Query:
					e.IsBaseCall = false;

                    // 검사종목 조회
                    QueryByJundalTable();

					break;
				case FunctionType.Print:
					e.IsBaseCall = false;
					dwReserPrn.Reset();
					if (layReserList01.RowCount > 0)
					{
                        try
                        {
                            dwReserPrn.FillData(layReserList01.LayoutTable);

                            string FromDate = "t_from_date.text = '" + dtFromDate.GetDataValue() + "'";
                            string ToDate = "t_to_date.text = '" + dtToDate.GetDataValue() + "'";
                            dwReserPrn.Modify(FromDate);
                            dwReserPrn.Modify(ToDate);
                            dwReserPrn.Refresh();

                            dwReserPrn.Print();
                        }
                        catch (Exception ex)
                        {
                            break;
                        }
					}
					break;
				default:
					break;
			}
        }

        private void cboGumsa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mJundalTable = this.cboGumsa.GetDataValue();
            this.cbxJundalPart.SetDictDDLB();
            this.cbxJundalPart.SelectedIndex = 0;
            QueryByJundalTable();
        }

        private void QueryByJundalTable()
        {
            //this.layJundalPart.QueryLayout(true);

            ReserList01Query(this.cboGumsa.GetDataValue(), this.cbxJundalPart.GetDataValue());

            //if (this.layJundalPart.RowCount > 0)
            //{
            //    ReserList01Query(this.cboGumsa.GetDataValue(), this.cbxJundalPart.GetDataValue());
            //}
            //else
            //{
            //    if (this.cbxJundalPart.GetDataValue() == "%")
            //    {
            //        //내시경의경우 전달테이블이 ENDO,전달파트가 GIF등이므로
            //        //항목코드의 전달파트와 맞춰주기위해서 
            //        ReserList01Query("%", this.cboGumsa.GetDataValue());
            //    }
            //    else
            //        ReserList01Query(this.cboGumsa.GetDataValue(), this.cbxJundalPart.GetDataValue());
            //}        
        }

        private void cbxJundalPart_DDLBSetting(object sender, EventArgs e)
        {
            //this.cbxJundalPart.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.cbxJundalPart.SetBindVarValue("f_jundal_table", this.cboGumsa.GetDataValue());
        }

        private void dtFromDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void dtToDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cbxJundalPart_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (TypeCheck.IsNull(cbxJundalPart.GetDataValue().ToString()) == false)
            {
                QueryByJundalTable();
            }
        }

        private void layReserList01_QueryStarting(object sender, CancelEventArgs e)
        {
        }
        private void rbxPart_CheckedChanged(object sender, EventArgs e)
        {
            QueryByJundalTable();
        }

        #region Updated code

        #region ComboGumsa
        /// <summary>
        /// Load data into gumsaCbo
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> ComboGumsa(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            SchsSCH0201Q01GumsaComboListArgs args = new SchsSCH0201Q01GumsaComboListArgs();
            args.HangmogCode = this.mHangmogCode;
            SchsSCH0201Q01GumsaComboListResult result = CacheService.Instance.Get<SchsSCH0201Q01GumsaComboListArgs, SchsSCH0201Q01GumsaComboListResult>(args);

            //SchsSCH0201Q01GumsaComboListResult result = CloudService.Instance.Submit<SchsSCH0201Q01GumsaComboListResult, SchsSCH0201Q01GumsaComboListArgs>(args);

            if (result != null)
            {
                IList<ComboListItemInfo> listItem = result.GumsaComboItem;

                foreach (ComboListItemInfo item in listItem)
                {
                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }

                if (!string.IsNullOrEmpty(result.SelectedValue))
                {
                    this.mJundalTable = result.SelectedValue;
                    // Default selected
                    this.cboGumsa.SetEditValue(this.mJundalTable);
                }
            }

            return lstResult;
        }
        #endregion

        #region ComboJundal
        /// <summary>
        /// Load data into jundalCbo
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> ComboJundal(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            SchsSCH0201Q01SCH0001ComboListArgs args = new SchsSCH0201Q01SCH0001ComboListArgs();
            args.JundalTable = this.mJundalTable;
            ComboListItemResult result = CloudService.Instance.Submit<ComboListItemResult, SchsSCH0201Q01SCH0001ComboListArgs>(args);

            if (result != null)
            {
                IList<ComboListItemInfo> listItem = result.ListItemInfos;

                foreach (ComboListItemInfo item in listItem)
                {
                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }
        #endregion

        #region GetReserList
        /// <summary>
        /// GetReserList
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<object[]> GetReserList(BindVarCollection list)
        {
            List<object[]> lObj = new List<object[]>();

            SchsSCH0201Q01ReserListArgs args = new SchsSCH0201Q01ReserListArgs();
            args.ChkChecked = rbxPatient.Checked;
            args.FromDate = dtFromDate.GetDataValue();
            args.ToDate = dtToDate.GetDataValue();
            args.JundalPart = cbxJundalPart.GetDataValue();
            args.JundalTable = cboGumsa.GetDataValue();
            SchsSCH0201Q01ReserListResult res = CloudService.Instance.Submit<SchsSCH0201Q01ReserListResult, SchsSCH0201Q01ReserListArgs>(args);

            if (null != res && res.ReserListItem.Count > 0)
            {
                foreach (SchsSCH0201Q01ReserListItemInfo item in res.ReserListItem)
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
                        item.JundalPartName,
                        item.GwaName,
                        item.HoDong1,
                        item.Sex,
                        item.Age,
                        item.Birth,
                        item.InputGwa,
                        item.DoctorName,
                        item.UpdName,
                        item.PortableYn,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #endregion

        #region Apply Multi languages
        private void ApplyMultiLanguages()
        {
            //dwReserList
            dwReserList.Refresh();
            dwReserList.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_1));
            dwReserList.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_2));
            dwReserList.Modify(string.Format("t_6.text = '{0}'", Resources.DW_TXT_3));
            dwReserList.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_4));
            dwReserList.Modify(string.Format("t_8.text = '{0}'", Resources.DW_TXT_5));
            dwReserList.Modify(string.Format("t_10.text = '{0}'", Resources.DW_TXT_6));
            dwReserList.Modify(string.Format("t_11.text = '{0}'", Resources.DW_TXT_7));
            dwReserList.Modify(string.Format("t_12.text = '{0}'", Resources.DW_TXT_7));
            dwReserList.Modify(string.Format("panm_t.text = '{0}'", Resources.DW_TXT_8));
            dwReserList.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_9));
            dwReserList.Modify(string.Format("t_13.text = '{0}'", Resources.DW_TXT_10));
            dwReserList.Modify(string.Format("t_7.text = '{0}'", Resources.DW_TXT_11));
            dwReserList.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_12));
            //dwReserPrn
            dwReserPrn.Refresh();
            dwReserPrn.Modify(string.Format("t_6.text = '{0}'", Resources.DW_TXT_13));
            dwReserPrn.Modify(string.Format("t_7.text = '{0}'", Resources.DW_TXT_14));
            dwReserPrn.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_15));
            dwReserPrn.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_16));
            dwReserPrn.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_17));
            dwReserPrn.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_18));
            dwReserPrn.Modify(string.Format("t_8.text = '{0}'", Resources.DW_TXT_19));
            dwReserPrn.Modify(string.Format("t_10.text = '{0}'", Resources.DW_TXT_20));
            dwReserPrn.Modify(string.Format("t_11.text = '{0}'", Resources.DW_TXT_21));
            dwReserPrn.Modify(string.Format("t_12.text = '{0}'", Resources.DW_TXT_21));
            dwReserPrn.Modify(string.Format("panm_t.text = '{0}'", Resources.DW_TXT_22));
            dwReserPrn.Modify(string.Format("t_15.text = '{0}'", Resources.DW_TXT_23));
            dwReserPrn.Modify(string.Format("t_13.text = '{0}'", Resources.DW_TXT_24));
            dwReserPrn.Modify(string.Format("t_14.text = '{0}'", Resources.DW_TXT_25));
            dwReserPrn.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_26));

            if (NetInfo.Language == LangMode.En || NetInfo.Language == LangMode.Vi)
            {
                dwReserList.Modify(string.Format("t_4.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_2.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_6.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_1.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_8.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_10.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_11.Font.Face = '{0}'", "Arial"));

                dwReserList.Modify(string.Format("panm_t.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_5.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_13.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_7.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_3.Font.Face = '{0}'", "Arial"));
                dwReserList.Modify(string.Format("t_7.Font.Face = '{0}'", "Arial"));
                
            }
        }
        #endregion
    }
}

