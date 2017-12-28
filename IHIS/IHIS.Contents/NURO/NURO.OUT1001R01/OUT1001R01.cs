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
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.NURO.Properties;
using System.Globalization;
#endregion

namespace IHIS.NURO
{
	/// <summary>
	/// OUT1001R01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OUT1001R01 : IHIS.Framework.XScreen
	{
        private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XDatePicker dtpNaewonDate;
		private IHIS.Framework.XFindBox fbxBunho;
		private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.MultiLayout dsvQryList;
        private XEditGrid grdList;
		private IHIS.Framework.XEditGridCell XEditGridCell1;
		private IHIS.Framework.XEditGridCell XEditGridCell2;
		private IHIS.Framework.XEditGridCell XEditGridCell3;
		private IHIS.Framework.XEditGridCell XEditGridCell4;
		private IHIS.Framework.XEditGridCell XEditGridCell5;
        private IHIS.Framework.XEditGridCell XEditGridCell6;
		private IHIS.Framework.XEditGridCell XEditGridCell8;
		private IHIS.Framework.XEditGridCell XEditGridCell9;
		private IHIS.Framework.XEditGridCell XEditGridCell10;
		private IHIS.Framework.XEditGridCell XEditGridCell11;
		private IHIS.Framework.XEditGridCell XEditGridCell12;
		private IHIS.Framework.XEditGridCell XEditGridCell13;
		private IHIS.Framework.XEditGridCell XEditGridCell14;
		private IHIS.Framework.XEditGridCell XEditGridCell15;
		private IHIS.Framework.XEditGridCell XEditGridCell16;
        private IHIS.Framework.XButtonList btnList;
        private SingleLayout layOut0101;
        private SingleLayoutItem singleLayoutItem1;
        private XDataWindow dwWindow;
        private SingleLayout layPrintName;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
		//private IHIS.Framework.DataServiceDynSO dsvPrintName;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OUT1001R01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //set ParamList
            this.grdList.ParamList = new List<String>(new String[] { "f_hosp_code", "f_bunho", "f_naewon_date" });
            layOut0101.ParamList = new List<String>(new String[] { "f_hosp_code", "f_bunho"});

            //set ExecuteQuery
            grdList.ExecuteQuery = LoadDataGrdList;
            layPrintName.ExecuteQuery = LoadDataPrintName;
            layOut0101.ExecuteQuery = LoadLayOut0101;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT1001R01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpNaewonDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dsvQryList = new IHIS.Framework.MultiLayout();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.XEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell4 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.layOut0101 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.dwWindow = new IHIS.Framework.XDataWindow();
            this.layPrintName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsvQryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.dbxSuname);
            this.xPanel1.Controls.Add(this.fbxBunho);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpNaewonDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(4, 4);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(585, 37);
            this.xPanel1.TabIndex = 0;
            // 
            // dbxSuname
            // 
            this.dbxSuname.Location = new System.Drawing.Point(416, 9);
            this.dbxSuname.Name = "dbxSuname";
            this.dbxSuname.Size = new System.Drawing.Size(130, 20);
            this.dbxSuname.TabIndex = 3;
            // 
            // fbxBunho
            // 
            this.fbxBunho.ApplyByteLimit = true;
            this.fbxBunho.Location = new System.Drawing.Point(316, 9);
            this.fbxBunho.MaxLength = 9;
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.Size = new System.Drawing.Size(100, 20);
            this.fbxBunho.TabIndex = 0;
            this.fbxBunho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunho_DataValidating);
            this.fbxBunho.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunho_FindClick);
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(230, 9);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(86, 20);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "患者番号";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpNaewonDate
            // 
            this.dtpNaewonDate.IsJapanYearType = true;
            this.dtpNaewonDate.Location = new System.Drawing.Point(102, 9);
            this.dtpNaewonDate.Name = "dtpNaewonDate";
            this.dtpNaewonDate.Size = new System.Drawing.Size(114, 20);
            this.dtpNaewonDate.TabIndex = 1;
            this.dtpNaewonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpNaewonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpNaewonDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(16, 9);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(86, 20);
            this.xLabel1.TabIndex = 4;
            this.xLabel1.Text = "受診日";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnList
            // 
            this.btnList.IsVisiblePreview = false;
            this.btnList.Location = new System.Drawing.Point(263, 864);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(325, 34);
            this.btnList.TabIndex = 2;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.XEditGridCell1,
            this.XEditGridCell2,
            this.XEditGridCell3,
            this.XEditGridCell4,
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
            this.xEditGridCell7,
            this.xEditGridCell17,
            this.xEditGridCell20,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell21,
            this.xEditGridCell22});
            this.grdList.ColPerLine = 22;
            this.grdList.Cols = 22;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(21);
            this.grdList.Location = new System.Drawing.Point(-11, 612);
            this.grdList.Name = "grdList";
            this.grdList.Rows = 2;
            this.grdList.Size = new System.Drawing.Size(604, 200);
            this.grdList.TabIndex = 3;
            this.grdList.Visible = false;
            this.grdList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdList_QueryEnd);
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // XEditGridCell1
            // 
            this.XEditGridCell1.CellName = "bunho";
            this.XEditGridCell1.HeaderText = "bunho";
            // 
            // XEditGridCell2
            // 
            this.XEditGridCell2.CellName = "suname";
            this.XEditGridCell2.Col = 1;
            this.XEditGridCell2.HeaderText = "suname";
            // 
            // XEditGridCell3
            // 
            this.XEditGridCell3.CellName = "suname2";
            this.XEditGridCell3.Col = 2;
            this.XEditGridCell3.HeaderText = "suname2";
            // 
            // XEditGridCell4
            // 
            this.XEditGridCell4.CellName = "birth_jp";
            this.XEditGridCell4.Col = 3;
            this.XEditGridCell4.HeaderText = "birth_jp";
            // 
            // XEditGridCell5
            // 
            this.XEditGridCell5.CellName = "naewon_date_jp";
            this.XEditGridCell5.Col = 4;
            this.XEditGridCell5.HeaderText = "naewon_date_jp";
            // 
            // XEditGridCell6
            // 
            this.XEditGridCell6.CellName = "naewon_date";
            this.XEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.XEditGridCell6.Col = 5;
            this.XEditGridCell6.HeaderText = "naewon_date";
            // 
            // XEditGridCell8
            // 
            this.XEditGridCell8.CellName = "sujin_no";
            this.XEditGridCell8.Col = 7;
            this.XEditGridCell8.HeaderText = "sujin_no";
            // 
            // XEditGridCell9
            // 
            this.XEditGridCell9.CellName = "jubsu_no";
            this.XEditGridCell9.CellType = IHIS.Framework.XCellDataType.Number;
            this.XEditGridCell9.Col = 8;
            this.XEditGridCell9.HeaderText = "jubsu_no";
            // 
            // XEditGridCell10
            // 
            this.XEditGridCell10.CellName = "gwa";
            this.XEditGridCell10.Col = 9;
            this.XEditGridCell10.HeaderText = "gwa";
            // 
            // XEditGridCell11
            // 
            this.XEditGridCell11.CellName = "gwa_name";
            this.XEditGridCell11.Col = 10;
            this.XEditGridCell11.HeaderText = "gwa_name";
            // 
            // XEditGridCell12
            // 
            this.XEditGridCell12.CellName = "doctor";
            this.XEditGridCell12.Col = 11;
            this.XEditGridCell12.HeaderText = "doctor";
            // 
            // XEditGridCell13
            // 
            this.XEditGridCell13.CellName = "doctor_name";
            this.XEditGridCell13.Col = 12;
            this.XEditGridCell13.HeaderText = "doctor_name";
            // 
            // XEditGridCell14
            // 
            this.XEditGridCell14.CellName = "jubsu_gubun";
            this.XEditGridCell14.Col = 13;
            this.XEditGridCell14.HeaderText = "jubsu_gubun";
            // 
            // XEditGridCell15
            // 
            this.XEditGridCell15.CellName = "jubsu_gubun_name";
            this.XEditGridCell15.Col = 14;
            this.XEditGridCell15.HeaderText = "jubsu_gubun_name";
            // 
            // XEditGridCell16
            // 
            this.XEditGridCell16.CellName = "jubsu_time";
            this.XEditGridCell16.CellType = IHIS.Framework.XCellDataType.Time;
            this.XEditGridCell16.Col = 15;
            this.XEditGridCell16.HeaderText = "jubsu_time";
            this.XEditGridCell16.Mask = "HH:MI";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "chojae_name";
            this.xEditGridCell7.Col = 16;
            this.xEditGridCell7.HeaderText = "CHOJAE_NAME";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "reser_yn";
            this.xEditGridCell17.Col = 17;
            this.xEditGridCell17.HeaderText = "RESER_YN";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "arrive_time";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell20.Col = 19;
            this.xEditGridCell20.HeaderText = "ARRIVE_TIME";
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "naewon_yn";
            this.xEditGridCell18.Col = 18;
            this.xEditGridCell18.HeaderText = "NAEWON_YN";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "yoyang_name";
            this.xEditGridCell19.Col = 6;
            this.xEditGridCell19.HeaderText = "YOYANG_NAME";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "sort_key";
            this.xEditGridCell21.Col = 20;
            this.xEditGridCell21.HeaderText = "sort_key";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "jundal_part";
            this.xEditGridCell22.Col = 21;
            this.xEditGridCell22.HeaderText = "jundal_part";
            // 
            // layOut0101
            // 
            this.layOut0101.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            //this.layOut0101.QuerySQL = "SELECT A.SUNAME, A.SUNAME2, FN_BAS_TO_JAPAN_DATE_CONVERT(\'1\', A.BIRTH) BIRTH\r\n  F" +
            //    "ROM OUT0101 A\r\n WHERE A.HOSP_CODE   = :f_hosp_code\r\n   AND A.BUNHO       = :f_bu" +
            //    "nho";
            this.layOut0101.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOut0101_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // dwWindow
            // 
            this.dwWindow.DataWindowObject = "out1001r01";
            this.dwWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwWindow.LibraryList = "NURO\\nuro.out1001r01.pbd";
            this.dwWindow.Location = new System.Drawing.Point(4, 41);
            this.dwWindow.Name = "dwWindow";
            this.dwWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwWindow.Size = new System.Drawing.Size(585, 819);
            this.dwWindow.TabIndex = 1;
            this.dwWindow.Text = "xDataWindow1";
            this.dwWindow.Click += new System.EventHandler(this.dwWindow_Click);
            // 
            // layPrintName
            // 
            this.layPrintName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2,
            this.singleLayoutItem3});
            //this.layPrintName.QuerySQL = "SELECT A.CODE_NAME, A.SORT_KEY\r\nFROM BAS0102 A\r\nWHERE A.HOSP_CODE = FN_ADM_LOAD_H" +
            //    "OSP_CODE\r\n  AND A.CODE_TYPE = \'PRINT_NAME\'\r\n  AND A.CODE      = \'SUJIN\'";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "code_name";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "sort_key";
            // 
            // OUT1001R01
            // 
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.dwWindow);
            this.Controls.Add(this.xPanel1);
            this.Name = "OUT1001R01";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(593, 900);
            this.Load += new System.EventHandler(this.OUT1001R01_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUT1001R01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsvQryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

        //private string mMsg = "";
        //private string mCap = "";

		private bool mIsAutoClose = false;

		//private OUT.OUTCOMVAL mValidation = new IHIS.OUT.OUTCOMVAL();

		#endregion

		#region Screen Load

        private void UpdateDataWindowLanguage()
        {
            dwWindow.Modify(string.Format("t_1.text = '{0}'", Resources.DataWindowExaminationVote));
            dwWindow.Modify(string.Format("t_19.text = '{0}'", Resources.DataWindowTitle));
            dwWindow.Modify(string.Format("t_12.text = '{0}'", Resources.DataWindowReceivedDate));

            dwWindow.Modify(string.Format("t_11.text = '{0}'", Resources.DataWindowPatientNumber));
            dwWindow.Modify(string.Format("t_13.text = '{0}'", Resources.DataWindowFullName));
            dwWindow.Modify(string.Format("t_14.text = '{0}'", Resources.DataWindowBirthday));
            dwWindow.Modify(string.Format("t_9.text = '{0}'", Resources.DataWindowSolutionContent));

            dwWindow.Modify(string.Format("t_2.text = '{0}'", Resources.DataWindowOrder));
            dwWindow.Modify(string.Format("t_35.text = '{0}'", Resources.DataWindowPree));
            dwWindow.Modify(string.Format("t_3.text = '{0}'", Resources.DataWindowDepartment));
            dwWindow.Modify(string.Format("t_8.text = '{0}'", Resources.DataWindowFirstReExamination));
            dwWindow.Modify(string.Format("t_4.text = '{0}'", Resources.DataWindowMedicalDoctor));
            dwWindow.Modify(string.Format("t_5.text = '{0}'", Resources.DataWindowAcceptedClassification));
            dwWindow.Modify(string.Format("t_42.text = '{0}'", Resources.DataWindowReservation));
            dwWindow.Modify(string.Format("t_6.text = '{0}'", Resources.DataWindowReception));
            dwWindow.Modify(string.Format("t_7.text = '{0}'", Resources.DataWindowRemarks));

            dwWindow.Modify(string.Format("t_10.text = '{0}'", Resources.DataWindowInternalMedical));
            dwWindow.Modify(string.Format("t_36.text = '{0}'", Resources.DataWindowTestUrine));
            dwWindow.Modify(string.Format("t_33.text = '{0}'", Resources.DataWindowMedicalRecord));

            dwWindow.Modify(string.Format("t_15.text = '{0}'", Resources.DataWindowIntergerForm));
            dwWindow.Modify(string.Format("t_26.text = '{0}'", Resources.DataWindowBloodAdopted));
            dwWindow.Modify(string.Format("t_34.text = '{0}'", Resources.DataWindowPrac));

            dwWindow.Modify(string.Format("t_16.text = '{0}'", Resources.DataWindowGynecology));
            dwWindow.Modify(string.Format("t_37.text = '{0}'", Resources.DataWindowHospitalBloodCount));
            dwWindow.Modify(string.Format("t_39.text = '{0}'", Resources.DataWindowHospitalizationDisplay));

            dwWindow.Modify(string.Format("t_17.text = '{0}'", Resources.DataWindowRespiratoryMedicine));
            dwWindow.Modify(string.Format("t_27.text = '{0}'", Resources.DataWindowXP));
            dwWindow.Modify(string.Format("t_40.text = '{0}'", Resources.DataWindowInformationProvidedCertificate));

            dwWindow.Modify(string.Format("t_18.text = '{0}'", Resources.DataWindowOutSide));
            dwWindow.Modify(string.Format("t_28.text = '{0}'", Resources.DataWindowECG));
            dwWindow.Modify(string.Format("t_41.text = '{0}'", Resources.DataWindowCDR));

            dwWindow.Modify(string.Format("t_20.text = '{0}'", Resources.DataWindowBrainOutSide));
            dwWindow.Modify(string.Format("t_29.text = '{0}'", Resources.DataWindowCT));
            dwWindow.Modify(string.Format("t_21.text = '{0}'", Resources.DataWindowAnalGateSchool));
            dwWindow.Modify(string.Format("t_30.text = '{0}'", Resources.DataWindowGIF));

            dwWindow.Modify(string.Format("t_22.text = '{0}'", Resources.DataWindowNoteMorphism));
            dwWindow.Modify(string.Format("t_31.text = '{0}'", Resources.DataWindowCF));

            dwWindow.Modify(string.Format("t_23.text = '{0}'", Resources.DataWindowPointDrop));
            dwWindow.Modify(string.Format("t_32.text = '{0}'", Resources.DataWindowEcho));

            dwWindow.Modify(string.Format("t_24.text = '{0}'", Resources.DataWindowOnlyMedicine));
            dwWindow.Modify(string.Format("t_38.text = '{0}'", Resources.DataWindowMRIReservation));
            dwWindow.Modify(string.Format("t_25.text = '{0}'", Resources.DataWindowNotes));
        
            string naewon_date_jp = this.grdList.GetItemString(0, "naewon_date_jp");
            string receipientText = GetDateFormat(naewon_date_jp);
            dwWindow.Modify(string.Format("t_receipientdate.text = '{0}'", receipientText));
            
            string birth_jp = this.grdList.GetItemString(0, "birth_jp");
            string birthdayText = GetDateFormat(birth_jp);
            dwWindow.Modify(string.Format("t_birthday.text = '{0}'", birthdayText));
        }

        private string GetDateFormat(string dateTime)
        {
            //char space = '-';
            string dateString = "";
           
            DateTime date = new DateTime();

            try
            {
              
                DateTime.TryParseExact(dateTime, new string[] { "yyyy/MM/dd", "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.None, out date);
            }
            catch
            {
                dateString = dateTime;
            }
            finally { }

            switch (NetInfo.Language)
            {
                case LangMode.Vi:
                    dateString = date.ToString("dd/MM/yyyy");
                    break;

                case LangMode.Jr:
                    dateString = date.ToString("yyyy/MM/dd");
                    break;
                default:
                    dateString = dateTime;
                    break;
            }

            return dateString;
        }

		private void OUT1001R01_Load(object sender, System.EventArgs e)
		{
			// DataWindow Preview설정
			this.dwWindow.Modify("DataWindow.Print.Preview=Yes");						
			this.dwWindow.Modify("DataWindow.Print.Preview.Zoom= 100");
            //2015/08/14 cloud updated
            //this.dwWindow.Modify("hosp_name.text = '" + UserInfo.HospName + "'");

            //this.InitScreen();

			if (this.OpenParam != null)
			{
				if (this.OpenParam.Contains("naewon_date"))
				{
					this.dtpNaewonDate.SetDataValue(this.OpenParam["naewon_date"].ToString());
				}
				if (this.OpenParam.Contains("bunho"))
				{
                    this.fbxBunho.SetDataValue(this.OpenParam["bunho"].ToString());
				}
				if (this.OpenParam.Contains("auto_close"))
				{
                    this.mIsAutoClose = (bool)this.OpenParam["auto_close"];
                    if (this.mIsAutoClose)
                    {
                        this.ParentForm.WindowState = FormWindowState.Minimized;
                    }
                    else
                    {
                        this.ParentForm.WindowState = FormWindowState.Normal;
                    }
                    PostCallHelper.PostCall(new PostMethod(this.AutoCloseRoutine));
                }
			}
			else
			{
                if (this.fbxBunho.Text == "")
                {
                    XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                    if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                    {
                        // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                        patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                    }

                    if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                    {
                        this.fbxBunho.SetEditValue(patientInfo.BunHo);
                        this.fbxBunho.AcceptData();
                    }
                }
                this.InitScreen();
			}
		}
		#endregion
		#region Function
		private void InitScreen ()
		{
            this.Reset();
            this.grdList.InsertRow(0);
            this.dwWindow.Reset();
            this.dwWindow.FillData(this.grdList.LayoutTable);
            this.dwWindow.Refresh();
            this.fbxBunho.Focus();
            this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
		}
		private void AutoCloseRoutine ()
		{
			this.btnList.PerformClick(FunctionType.Query);
			this.btnList.PerformClick(FunctionType.Print);
            if (this.mIsAutoClose)
            {
                this.btnList.PerformClick(FunctionType.Close);
            }
		}
		#endregion

		#region DataLoad

		private void LoadData (string aNaewonDate, string aBunho)
		{
            this.grdList.QueryLayout(true);
            this.dwWindow.Reset();
            this.dwWindow.FillData(this.grdList.LayoutTable);

            UpdateDataWindowLanguage();

            this.dwWindow.Refresh();
		}

		#endregion

		#region XButtonList
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			this.AcceptData();

			switch (e.Func)
			{
				case FunctionType.Query :
					e.IsBaseCall = false;
					this.LoadData(this.dtpNaewonDate.GetDataValue(), this.fbxBunho.GetDataValue());
					break;
				case FunctionType.Print :
					e.IsBaseCall = false;
                    DataRow[] dtRowData = this.grdList.LayoutTable.Select("naewon_yn IN" + "('Y', 'H')");

                    if (dtRowData.Length > 0)
                    {
                        try
                        {

                            // 바코드프린터명 가져오기
                            // 프로그램을 두개 만들어야 함. 보통의 프로그램과 
                            // 회계 사무실 안의 바코드쪽 컴퓨터용 프로그램 ( 거기서는 수진표 프린터 쪽으로 출력 되어야 함.)
                            //dsvPrintName.InputSQL = " SELECT CODE_NAME, SORT_KEY\r\n    FROM BAS0102\r\n  WHERE CODE_TYPE = \'PRINT_NAME\'\r\n      A" +
                            //    "ND CODE          = \'SUJIN\'\r\n";

                            if (this.layPrintName.QueryLayout() == true)
                            {
                                string printSetName = this.layPrintName.GetItemValue("code_name").ToString();
                                string paper_source = this.layPrintName.GetItemValue("sort_key").ToString();
                                if (TypeCheck.IsNull(paper_source) == true)
                                {
                                    paper_source = "0";
                                }
                                dwWindow.PrintProperties.PrinterName = printSetName;
                                dwWindow.PrintProperties.PaperSource = Int32.Parse(paper_source);
                                this.dwWindow.Print();
                            }
                        }
                        catch
                        {
                        }
                        finally
                        {
                            this.InitScreen();                            
                        }
                    }
                    else
                    {
                        string mMsg = "";
                        string mCap = "";
                        if (this.fbxBunho.GetDataValue() == "")
                        {
                            mMsg = NetInfo.Language == LangMode.Ko ? "환자번호를 입력하여주십시요."
                                                   : "患者番号を入力してください。";
                            mCap = NetInfo.Language == LangMode.Ko ? "확인" : "確認";
                        }
                        else 
                        {
                            mMsg = NetInfo.Language == LangMode.Ko ?"내원확인이되지않은환자입니다.진료접수를 해주십시요."
                        　　　　　　　　　　　　　　　　　　　　　　　    :"来院確認されていない患者です。\n 診療受付を先に行ってください。";
                            mCap = NetInfo.Language == LangMode.Ko ? "확인" : "確認";
                        }
                        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.fbxBunho.Focus();
                        return;
                    }
					break;

				case FunctionType.Reset :
					e.IsBaseCall = false;
                    //this.Reset();
					this.InitScreen();
					break;
			}
		}
		#endregion

		#region OpenScreen 
		private void OpenScreen_OUT0101Q01 ()
		{
            CommonItemCollection param = new CommonItemCollection();

            XScreen.OpenScreenWithParam(this, "NURI", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
        }
		#endregion

		#region XFindBox

		private void fbxBunho_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.OpenScreen_OUT0101Q01();
		}

		private void fbxBunho_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue == "")
			{
                this.InitScreen();
				return;
			}
			string bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
			PostCallHelper.PostCall(new PostMethodStr(PostValidating), bunho);
		}

		private void PostValidating (string aBunho)
		{
			this.fbxBunho.SetDataValue(aBunho);

            // XDisplayBox 데이터삭제
            this.dbxSuname.ResetText();
            this.layOut0101.LayoutItems.Clear();
            this.layOut0101.LayoutItems.Add("SUNAME");
            // 환자정보데이터 취득
            if (this.layOut0101.QueryLayout())
            {
                this.dbxSuname.SetEditValue(layOut0101.GetItemValue("SUNAME").ToString());
            }

            this.btnList.PerformClick(FunctionType.Query);
		}

		#endregion

		#region XDatePicker

		private void dtpNaewonDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue == "")
			{
				this.grdList.Reset();
				this.dwWindow.Reset();
				this.SetMsg("");
				return;
			}
            if (this.fbxBunho.GetDataValue() != "")
            {
			    PostCallHelper.PostCall(new PostMethod(PostDateValid));
            }
		}

		private void PostDateValid ()
		{
			this.btnList.PerformClick(FunctionType.Query);
		}

		#endregion

		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch (command)
			{
				case "OUT0101" :
                    if (commandParam != null)
                    {
                        this.fbxBunho.Focus();
                        this.fbxBunho.SetEditValue(((MultiLayout)commandParam[0]).GetItemString(0, "bunho"));
                        this.dbxSuname.SetEditValue(((MultiLayout)commandParam[0]).GetItemString(0, "suname"));
                        this.fbxBunho.AcceptData();
                    }
					break;

                case "Close":

                    this.Close();

                    break;
			}

			return base.Command (command, commandParam);
		}

        private void layOut0101_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOut0101.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layOut0101.SetBindVarValue("f_bunho", fbxBunho.GetDataValue().ToString());
        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_bunho", fbxBunho.GetDataValue().ToString());
            this.grdList.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue().ToString());
        }

        private void dwWindow_Click(object sender, EventArgs e)
        {

        }

        private void OUT1001R01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, (rc.Height - 130));
        }

        private void grdList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdList.RowCount < 1)
            {
                this.grdList.InsertRow(0);
            }
        }

        #region CloudService
        /// <summary>
        /// get data for grdList from Cloud
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OUT1001R01GrdListArgs args = new OUT1001R01GrdListArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.NaewonDate = bc["f_naewon_date"] != null ? bc["f_naewon_date"].VarValue : "";
            OUT1001R01GrdListResult result = CloudService.Instance.Submit<OUT1001R01GrdListResult, OUT1001R01GrdListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OUT1001R01GrdListInfo item in result.GridList)
                {
                    object[] objects = 
				{ 
					item.Bunho, 
					item.Suname, 
					item.Suname2, 
					item.DateConvert1, 
					item.DateConvert2, 
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
					item.ChojaeName, 
					item.ReserYn, 
					item.ArriveTime, 
					item.NaewonYn, 
					item.YoyangName, 
					item.SortKey, 
					item.JundalPart
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for layOut0101 from Cloud
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadLayOut0101(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OUT1001R01LayOut0101Args args = new OUT1001R01LayOut0101Args();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            OUT1001R01LayOut0101Result result = CloudService.Instance.Submit<OUT1001R01LayOut0101Result, OUT1001R01LayOut0101Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OUT1001R01LayOut0101Info item in result.LayoutList)
                {
                    object[] objects = 
				{ 
					item.SuName, 
					item.SuName2, 
					item.Birth
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for layPrintName from Cloud
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataPrintName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            NuroOut1101Q01PrintNameInfoArgs args = new NuroOut1101Q01PrintNameInfoArgs();
            NuroOut1101Q01PrintNameInfoResult result = CloudService.Instance.Submit<NuroOut1101Q01PrintNameInfoResult, NuroOut1101Q01PrintNameInfoArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (NuroOUT1101Q01PrintNameInfo item in result.PrintNameInfoList)
                {
                    object[] objects = 
				{ 
					item.CodeName, 
					item.SortKey
				};
                    res.Add(objects);
                }
            }
            return res;
        } 



        #endregion
    }
}

