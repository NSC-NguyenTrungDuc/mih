#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.NURO.Properties;

#endregion

namespace IHIS.NURO
{
	/// <summary>
    /// OUT1101Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OUT1101Q01 : XScreen
	{
        private XPanel xPanel1;
        private XLabel xLabel1;
        private XDatePicker dtpNaewonDate;
        private XEditGrid grdList;
		private XEditGridCell XEditGridCell1;
		private XEditGridCell XEditGridCell2;
        private XEditGridCell XEditGridCell3;
		private XEditGridCell XEditGridCell5;
        private XEditGridCell XEditGridCell6;
		private XEditGridCell XEditGridCell8;
		private XEditGridCell XEditGridCell9;
		private XEditGridCell XEditGridCell10;
		private XEditGridCell XEditGridCell11;
		private XEditGridCell XEditGridCell12;
		private XEditGridCell XEditGridCell13;
		private XEditGridCell XEditGridCell14;
		private XEditGridCell XEditGridCell15;
		private XEditGridCell XEditGridCell16;
        private XButtonList btnList;
        private XDataWindow dwWindow;
        private SingleLayout layPrintName;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private XLabel xLabel2;
        private XDictComboBox cboGwa;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell7;
        private XLabel xLabel3;
        private XDisplayBox dbxDoctorName;
        private XFindBox fbxDoctor;
        private XFindWorker fwkDoctor;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XPanel xPanel2;
        private XLabel xLabel4;
        private XCheckBox cbxDoctorPrint;
		//private IHIS.Framework.DataServiceDynSO dsvPrintName;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private Container components = null;

		public OUT1101Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		    cboGwa.ExecuteQuery = LoadCboGwa;
            cboGwa.SetDictDDLB();
            grdList.ParamList = new List<string>(new string[] { "f_gwa", "f_doctor", "f_naewon_date" });
            grdList.ExecuteQuery = GridExecuteQuery;
            layPrintName.ExecuteQuery = PrinNameExecuteQuery;
            fwkDoctor.ParamList = new List<string>(new string[] { "f_gwa", "f_find1" });
            fwkDoctor.ExecuteQuery = FwkDoctorExecuteQuery;
		    fwkDoctor.AutoQuery = true;
		}

	    private IList<object[]> FwkDoctorExecuteQuery(BindVarCollection varList)
	    {
            NuroOUT1101Q01FwkDoctorArgs args = new NuroOUT1101Q01FwkDoctorArgs(varList["f_gwa"].VarValue, varList["f_find1"].VarValue);
            NuroOut1101Q01FwkDoctorResult result =
                CloudService.Instance.Submit<NuroOut1101Q01FwkDoctorResult, NuroOUT1101Q01FwkDoctorArgs>(args);

            List<object[]> data = new List<object[]>();
            if (result != null)
            {
                foreach (NuroOUT1101Q01FwkDoctorInfo item in result.NuroFwkDoctorInfoList)
                {
                    data.Add(new object[]
                    {
                        item.Sabun,
                        item.DoctorName
                    });
                }
            }
            return data;
	    }

	    private IList<object[]> PrinNameExecuteQuery(BindVarCollection varList)
	    {
	        NuroOut1101Q01PrintNameInfoArgs args = new NuroOut1101Q01PrintNameInfoArgs();
            NuroOut1101Q01PrintNameInfoResult result =
                CloudService.Instance.Submit<NuroOut1101Q01PrintNameInfoResult, NuroOut1101Q01PrintNameInfoArgs>(args);

	        List<object[]> data = new List<object[]>();
            if (result != null)
            {
                foreach (NuroOUT1101Q01PrintNameInfo item in result.PrintNameInfoList)
                {
                    data.Add(new object[]
                    {
                        item.CodeName,
                        item.SortKey
                    });
                }
            }
	        return data;
	    }

	    private IList<object[]> GridExecuteQuery(BindVarCollection varList)
	    {
            IList<object[]> data = new List<object[]>();

            try
            {
                NuroOut1101Q01GridInfoArgs gridInfoArgs = new NuroOut1101Q01GridInfoArgs
                (
                    varList["f_doctor"].VarValue,
                    varList["f_gwa"].VarValue,
                    varList["f_naewon_date"].VarValue
                );

                NuroOut1101Q01GridInfoResult result = CloudService.Instance.Submit<NuroOut1101Q01GridInfoResult, NuroOut1101Q01GridInfoArgs>(gridInfoArgs);
                if (result != null)
                {
                    foreach (NuroOUT1101Q01GridInfo item in result.GridInfoList)
                    {
                        data.Add(new object[]
                    {
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.Birth,
                        item.NaewonDateJp,
                        item.NaewonDate,
                        item.SujinNo,
                        item.JubsuNo,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.JubsuGubun,
                        item.GubunName,
                        item.JubsuTime,
                        item.YoyangName
                    });
                    }
                }
            }
            catch (Exception e)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(e.Message);
            }
            return data;
	    }

	    private IList<object[]> LoadCboGwa(BindVarCollection bindVarCollection)
        {
            CloudService.Instance.Connect();
            IList<object[]> lstDataResult = new List<object[]>();
            NuroMakeDeptComboArgs args = new NuroMakeDeptComboArgs();
            ComboListItemResult result = CacheService.Instance.Get<NuroMakeDeptComboArgs, ComboListItemResult>(args, delegate(ComboListItemResult itemResult)
            {
                return itemResult != null && itemResult.ExecutionStatus == ExecutionStatus.Success &&
                       itemResult.ListItemInfos != null && itemResult.ListItemInfos.Count > 0;
            });

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                IList<ComboListItemInfo> listItemInfos = result.ListItemInfos;
                if (listItemInfos != null)
                {
                    foreach (ComboListItemInfo comboListItemInfo in listItemInfos)
                    {
                        object[] cboItem =
                        {
                            comboListItemInfo.Code,
                            comboListItemInfo.CodeName
                        };
                        lstDataResult.Add(cboItem);
                    }
                }
            }
            return lstDataResult;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT1101Q01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxDoctorName = new IHIS.Framework.XDisplayBox();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.fwkDoctor = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboGwa = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpNaewonDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.XEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.dwWindow = new IHIS.Framework.XDataWindow();
            this.layPrintName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cbxDoctorPrint = new IHIS.Framework.XCheckBox();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.xPanel2.SuspendLayout();
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
            this.xPanel1.Controls.Add(this.dbxDoctorName);
            this.xPanel1.Controls.Add(this.fbxDoctor);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.cboGwa);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpNaewonDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxDoctorName
            // 
            this.dbxDoctorName.AccessibleDescription = null;
            this.dbxDoctorName.AccessibleName = null;
            resources.ApplyResources(this.dbxDoctorName, "dbxDoctorName");
            this.dbxDoctorName.Image = null;
            this.dbxDoctorName.Name = "dbxDoctorName";
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.AccessibleDescription = null;
            this.fbxDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxDoctor, "fbxDoctor");
            this.fbxDoctor.BackgroundImage = null;
            this.fbxDoctor.FindWorker = this.fwkDoctor;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            // 
            // fwkDoctor
            // 
            this.fwkDoctor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkDoctor.ExecuteQuery = null;
            this.fwkDoctor.FormText = global::IHIS.NURO.Properties.Resources.FWKDOCTOR_FORMTEXT;
            this.fwkDoctor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkDoctor.ParamList")));
            this.fwkDoctor.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkDoctor.ServerFilter = true;
            this.fwkDoctor.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkDoctor_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "user_code";
            this.findColumnInfo3.ColWidth = 99;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "user_name";
            this.findColumnInfo4.ColWidth = 273;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.ExecuteQuery = null;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGwa.ParamList")));
            this.cboGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGwa.UserSQL = resources.GetString("cboGwa.UserSQL");
            this.cboGwa.SelectionChangeCommitted += new System.EventHandler(this.cboGwa_SelectionChangeCommitted);
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
            // dtpNaewonDate
            // 
            this.dtpNaewonDate.AccessibleDescription = null;
            this.dtpNaewonDate.AccessibleName = null;
            resources.ApplyResources(this.dtpNaewonDate, "dtpNaewonDate");
            this.dtpNaewonDate.BackgroundImage = null;
            this.dtpNaewonDate.Name = "dtpNaewonDate";
            this.dtpNaewonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpNaewonDate_DataValidating);
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
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisiblePreview = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.XEditGridCell1,
            this.XEditGridCell2,
            this.XEditGridCell3,
            this.xEditGridCell7,
            this.XEditGridCell5,
            this.XEditGridCell6,
            this.XEditGridCell8,
            this.XEditGridCell9,
            this.XEditGridCell10,
            this.XEditGridCell11,
            this.XEditGridCell12,
            this.XEditGridCell13,
            this.XEditGridCell14,
            this.XEditGridCell15,
            this.XEditGridCell16,
            this.xEditGridCell4});
            this.grdList.ColPerLine = 7;
            this.grdList.Cols = 8;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(32);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.ReadOnly = true;
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.ToolTipActive = true;
            this.grdList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdList_QueryEnd);
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // XEditGridCell1
            // 
            this.XEditGridCell1.CellName = "bunho";
            this.XEditGridCell1.CellWidth = 65;
            this.XEditGridCell1.Col = 1;
            this.XEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell1, "XEditGridCell1");
            this.XEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XEditGridCell2
            // 
            this.XEditGridCell2.CellName = "suname";
            this.XEditGridCell2.CellWidth = 100;
            this.XEditGridCell2.Col = 2;
            this.XEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell2, "XEditGridCell2");
            // 
            // XEditGridCell3
            // 
            this.XEditGridCell3.CellName = "suname2";
            this.XEditGridCell3.CellWidth = 105;
            this.XEditGridCell3.Col = 3;
            this.XEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell3, "XEditGridCell3");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "birth_jp";
            this.xEditGridCell7.CellWidth = 143;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // XEditGridCell5
            // 
            this.XEditGridCell5.CellName = "naewon_date_jp";
            this.XEditGridCell5.Col = -1;
            this.XEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell5, "XEditGridCell5");
            this.XEditGridCell5.IsVisible = false;
            this.XEditGridCell5.Row = -1;
            // 
            // XEditGridCell6
            // 
            this.XEditGridCell6.CellName = "naewon_date";
            this.XEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.XEditGridCell6.Col = -1;
            this.XEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell6, "XEditGridCell6");
            this.XEditGridCell6.IsVisible = false;
            this.XEditGridCell6.Row = -1;
            // 
            // XEditGridCell8
            // 
            this.XEditGridCell8.CellName = "sujin_no";
            this.XEditGridCell8.Col = -1;
            this.XEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell8, "XEditGridCell8");
            this.XEditGridCell8.IsVisible = false;
            this.XEditGridCell8.Row = -1;
            // 
            // XEditGridCell9
            // 
            this.XEditGridCell9.CellName = "jubsu_no";
            this.XEditGridCell9.CellType = IHIS.Framework.XCellDataType.Number;
            this.XEditGridCell9.Col = -1;
            this.XEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell9, "XEditGridCell9");
            this.XEditGridCell9.IsVisible = false;
            this.XEditGridCell9.Row = -1;
            // 
            // XEditGridCell10
            // 
            this.XEditGridCell10.CellName = "gwa";
            this.XEditGridCell10.Col = -1;
            this.XEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell10, "XEditGridCell10");
            this.XEditGridCell10.IsVisible = false;
            this.XEditGridCell10.Row = -1;
            // 
            // XEditGridCell11
            // 
            this.XEditGridCell11.CellName = "gwa_name";
            this.XEditGridCell11.Col = 5;
            this.XEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell11, "XEditGridCell11");
            // 
            // XEditGridCell12
            // 
            this.XEditGridCell12.CellName = "doctor";
            this.XEditGridCell12.Col = -1;
            this.XEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell12, "XEditGridCell12");
            this.XEditGridCell12.IsVisible = false;
            this.XEditGridCell12.Row = -1;
            // 
            // XEditGridCell13
            // 
            this.XEditGridCell13.CellName = "doctor_name";
            this.XEditGridCell13.CellWidth = 120;
            this.XEditGridCell13.Col = 7;
            this.XEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell13, "XEditGridCell13");
            // 
            // XEditGridCell14
            // 
            this.XEditGridCell14.CellName = "jubsu_gubun";
            this.XEditGridCell14.Col = -1;
            this.XEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell14, "XEditGridCell14");
            this.XEditGridCell14.IsVisible = false;
            this.XEditGridCell14.Row = -1;
            // 
            // XEditGridCell15
            // 
            this.XEditGridCell15.CellName = "jubsu_gubun_name";
            this.XEditGridCell15.Col = -1;
            this.XEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell15, "XEditGridCell15");
            this.XEditGridCell15.IsVisible = false;
            this.XEditGridCell15.Row = -1;
            // 
            // XEditGridCell16
            // 
            this.XEditGridCell16.CellName = "jubsu_time";
            this.XEditGridCell16.CellType = IHIS.Framework.XCellDataType.Time;
            this.XEditGridCell16.CellWidth = 114;
            this.XEditGridCell16.Col = 6;
            this.XEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.XEditGridCell16, "XEditGridCell16");
            this.XEditGridCell16.Mask = "HH:MI";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "yoyang_name";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // dwWindow
            // 
            resources.ApplyResources(this.dwWindow, "dwWindow");
            this.dwWindow.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwWindow.DataWindowObject = "out1101r01";
            this.dwWindow.LibraryList = "NURO\\nuro.out1101q01.pbd";
            this.dwWindow.LiveScroll = false;
            this.dwWindow.Name = "dwWindow";
            this.dwWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            // 
            // layPrintName
            // 
            this.layPrintName.ExecuteQuery = null;
            this.layPrintName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2,
            this.singleLayoutItem3});
            this.layPrintName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPrintName.ParamList")));
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "code_name";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "sort_key";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdList);
            this.xPanel2.Controls.Add(this.xPanel1);

            this.xPanel2.Controls.Add(this.dwWindow);            
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // cbxDoctorPrint
            // 
            this.cbxDoctorPrint.AccessibleDescription = null;
            this.cbxDoctorPrint.AccessibleName = null;
            resources.ApplyResources(this.cbxDoctorPrint, "cbxDoctorPrint");
            this.cbxDoctorPrint.BackgroundImage = null;
            this.cbxDoctorPrint.Checked = true;
            this.cbxDoctorPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDoctorPrint.Name = "cbxDoctorPrint";
            this.cbxDoctorPrint.UseVisualStyleBackColor = false;
            this.cbxDoctorPrint.CheckedChanged += new System.EventHandler(this.cbxDoctorPrint_CheckedChanged);
            // 
            // OUT1101Q01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.cbxDoctorPrint);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xLabel4);
            this.Name = "OUT1101Q01";
            this.Load += new System.EventHandler(this.OUT1101Q01_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUT1101Q01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Screen 변수 

        //private string mMsg = "";
        //private string mCap = "";

        private bool mIsAutoClose = false;

        //private OUT.OUTCOMVAL mValidation = new IHIS.OUT.OUTCOMVAL();

		#endregion

		#region Screen Load

        private void OUT1101Q01_Load(object sender, EventArgs e)
		{
			// DataWindow Preview설정
			dwWindow.Modify("DataWindow.Print.Preview=Yes");						
			dwWindow.Modify("DataWindow.Print.Preview.Zoom= 100");

            //this.InitScreen();

            if (OpenParam != null)
			{
                if (OpenParam.Contains("naewon_date"))
                {
                    dtpNaewonDate.SetDataValue(OpenParam["naewon_date"].ToString());
                }

                if (OpenParam.Contains("gwa"))
                {
                    cboGwa.SetEditValue(OpenParam["gwa"].ToString());
                    cboGwa.AcceptData();
                }

                if (OpenParam.Contains("auto_close"))
                {
                    ParentForm.WindowState = FormWindowState.Minimized;
                    mIsAutoClose = (bool)OpenParam["auto_close"];
                }

                if (mIsAutoClose)
                {
                    PostCallHelper.PostCall(new PostMethod(AutoCloseRoutine));
                }
			}
			else
			{
				InitScreen();
			}
		}
		#endregion

		#region Function
		private void InitScreen ()
		{
			dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-","/"));
            fbxDoctor.SetDataValue("");
            dbxDoctorName.SetDataValue("");
            if (cboGwa.ComboItems.Count > 0)
            {
                cboGwa.SelectedIndex = 0;
            }
            btnList.PerformClick(FunctionType.Query);
		}
        private void CreatScreen()
        {
            dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            if (cboGwa.ComboItems.Count > 0)
            {
                cboGwa.SelectedIndex = 0;
            }
            fbxDoctor.SetDataValue("");
            dbxDoctorName.SetDataValue("");
            grdList.Reset();
            grdList.InsertRow(0);
            LoadWindowData(dtpNaewonDate.GetDataValue().ToString(),
                                cboGwa.Text.ToString(),
                                dbxDoctorName.GetDataValue());
        }
		private void AutoCloseRoutine ()
		{
			btnList.PerformClick(FunctionType.Query);
			btnList.PerformClick(FunctionType.Print);
			btnList.PerformClick(FunctionType.Close);
		}
		#endregion

		#region DataLoad

		private void LoadData()
		{
            grdList.QueryLayout(true);
		}

        private void LoadWindowData(string naewon_date, string gwa, string doctor_name)
        {
            JapanDateInfoArgs japanDateInfoArgs = new JapanDateInfoArgs(naewon_date);
            JapanDateInfoResult res =
                CloudService.Instance.Submit<JapanDateInfoResult, JapanDateInfoArgs>(japanDateInfoArgs);
            if (res != null)
            {
                dwWindow.Modify("t_naewon_date.text = '" + res.JpDateInfo.NaewonDateJp + "'");
            }
            if (gwa == "")
            {
                gwa = Resources.ALL_TEXT;
            }
            dwWindow.Modify("t_gwaname.text = '" + gwa + "'");
            if (doctor_name == "")
            {
                doctor_name = Resources.ALL_TEXT;
            }
            dwWindow.Modify("t_doctorname.text = '" + doctor_name + "'");  
        }

        private void SetReportLanguage()
        {
            dwWindow.Modify(string.Format("t_1.text = '{0}'", xLabel4.Text));

            dwWindow.Modify(string.Format("t_12.text = '●{0}:'", xLabel1.Text));
            dwWindow.Modify(string.Format("t_13.text = '●{0}:'", xLabel2.Text));
            dwWindow.Modify(string.Format("t_14.text = '●{0}:'", xLabel3.Text));

            dwWindow.Modify(string.Format("t_9.text = '{0}'", XEditGridCell1.HeaderText));
            dwWindow.Modify(string.Format("t_10.text = '{0}'", XEditGridCell2.HeaderText));
            dwWindow.Modify(string.Format("t_7.text = '{0}'", XEditGridCell3.HeaderText));
            dwWindow.Modify(string.Format("t_8.text = '{0}'", xEditGridCell7.HeaderText));
            dwWindow.Modify(string.Format("t_5.text = '{0}'", XEditGridCell11.HeaderText));
            //dwWindow.Modify(string.Format("t_3.text = '{0}'", XEditGridCell16.HeaderText));
            dwWindow.Modify(string.Format("t_3.text = '{0}'", Resources.PrintAppointment));
            dwWindow.Modify(string.Format("t_4.text = '{0}'", XEditGridCell13.HeaderText));

            dwWindow.Modify(string.Format("t_11.text = '{0}:'", Resources.PrintPatientTotal));
            dwWindow.Modify(string.Format("t_6.text = '{0}'", Resources.PrintPeople));
        }

        private void WindowFillData()
        {
            SetReportLanguage();
            if (cbxDoctorPrint.Checked)
            {
                MultiLayout layDataPrint = new MultiLayout();
                layDataPrint = grdList.CloneToLayout();
                string doctor = "";
                string naewon_date = "";
                string gwa_name = Resources.ALL_TEXT;
                string doctor_name = "";
                foreach (DataRow dwr in grdList.LayoutTable.Rows)
                {
                    if (doctor == dwr["doctor"].ToString().Substring(3))
                    {
                        layDataPrint.LayoutTable.ImportRow(dwr);
                    }
                    else
                    {
                        if (layDataPrint.RowCount > 0)
                        {
                            LoadWindowData(naewon_date, gwa_name, doctor_name);
                            dwWindow.Reset();
                            dwWindow.FillData(layDataPrint.LayoutTable);
                            dwWindow.Print();
                            layDataPrint.Reset();
                        }
                        doctor = dwr["doctor"].ToString().Substring(3);
                        naewon_date = dwr["naewon_date"].ToString();
                        doctor_name = dwr["doctor_name"].ToString();
                        layDataPrint.LayoutTable.ImportRow(dwr);
                    }
                }
                if (layDataPrint.RowCount > 0)
                {
                    LoadWindowData(naewon_date, gwa_name, doctor_name);
                    dwWindow.Reset();
                    dwWindow.FillData(layDataPrint.LayoutTable);
                    dwWindow.Print();
                    layDataPrint.Reset();
                }
            }
            else
            {
                LoadWindowData(dtpNaewonDate.GetDataValue().ToString(),
                                                cboGwa.Text.ToString(),
                                                dbxDoctorName.GetDataValue());
                dwWindow.Reset();
                dwWindow.FillData(grdList.LayoutTable);
                dwWindow.Print();
            }
        }
		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
		{
			AcceptData();

			switch (e.Func)
			{
				case FunctionType.Query :
					e.IsBaseCall = false;
                    LoadData();
					break;
				case FunctionType.Print :
					e.IsBaseCall = false;
					if (grdList.RowCount > 0)
					{
                        WindowFillData();
					}
					break;
				case FunctionType.Reset :
					e.IsBaseCall = false;
                    CreatScreen();
					break;
			}
            fbxDoctor.Focus();
		}
		#endregion

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdList.SetBindVarValue("f_gwa", cboGwa.GetDataValue());
            grdList.SetBindVarValue("f_naewon_date", dtpNaewonDate.GetDataValue());
            grdList.SetBindVarValue("f_gwa", cboGwa.GetDataValue());
            grdList.SetBindVarValue("f_doctor", fbxDoctor.GetDataValue());
        }

        private void fwkDoctor_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkDoctor.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkDoctor.SetBindVarValue("f_gwa", cboGwa.GetDataValue());
        }

        private void fbxDoctor_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                dbxDoctorName.SetDataValue("");
                if (cboGwa.GetDataValue() == "%")
                {
                    cbxDoctorPrint.Checked = true;
                }
            }
            else
            {
                NuroOUT1101Q01DoctorNameInfoArgs doctorNameInfoArgs =
                    new NuroOUT1101Q01DoctorNameInfoArgs(cboGwa.GetDataValue(), e.DataValue);
                NuroOut1101Q01DoctorNameInfoResult res =
                    CloudService.Instance.Submit<NuroOut1101Q01DoctorNameInfoResult, NuroOUT1101Q01DoctorNameInfoArgs>(
                        doctorNameInfoArgs);
                if (res != null && res.DoctorNameInfo != null)
                {
                    dbxDoctorName.SetDataValue(res.DoctorNameInfo.DoctorName);
                }
                else
                {
                     XMessageBox.Show(Resources.DoctorCanNotFoundMessage,Resources.TitleWarning);
                }
                cbxDoctorPrint.Checked = false;
            }

            btnList.PerformClick(FunctionType.Query);
        }

        private void grdList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdList.RowCount < 1)
            {
                grdList.InsertRow(0);
            }
        }
        private void dtpNaewonDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);
        }

        private void OUT1101Q01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 
            Rectangle rc = Screen.PrimaryScreen.WorkingArea;
            ParentForm.Size = new Size(Width, (rc.Height - 130));
        }

        private void cbxDoctorPrint_CheckedChanged(object sender, EventArgs e)
        {
            bool bolval = true;
            if (cbxDoctorPrint.Checked)
            {
                cboGwa.SelectedIndex = 0;
                fbxDoctor.SetDataValue("");
                dbxDoctorName.SetDataValue("");
                btnList.PerformClick(FunctionType.Query);
                bolval = false;
            }
            foreach (XGridCell cell in grdList.CellInfos)
            {
                cell.EnableSort = bolval;
            }            
        }
        private void cboGwa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fbxDoctor.SetDataValue("");
            dbxDoctorName.SetDataValue("");
            
            if (cboGwa.GetDataValue() == "%")
            {
                cbxDoctorPrint.Checked = true;
            }
            else
            {
                cbxDoctorPrint.Checked = false;
                btnList.PerformClick(FunctionType.Query);
            }
        }
	}
}

