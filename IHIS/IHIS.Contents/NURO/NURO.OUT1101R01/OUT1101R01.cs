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
#endregion

namespace IHIS.NURO
{
	/// <summary>
	/// OUT1001R01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OUT1101R01 : IHIS.Framework.XScreen
	{
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDatePicker dtpNaewonDate;
        private XEditGrid grdList;
		private IHIS.Framework.XEditGridCell XEditGridCell1;
		private IHIS.Framework.XEditGridCell XEditGridCell2;
        private IHIS.Framework.XEditGridCell XEditGridCell3;
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
        private XDataWindow dwWindow;
        private SingleLayout layPrintName;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private XLabel xLabel2;
        private XDictComboBox cboGwa;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell7;
		//private IHIS.Framework.DataServiceDynSO dsvPrintName;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OUT1101R01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT1101R01));
            this.xPanel1 = new IHIS.Framework.XPanel();
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
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.cboGwa);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpNaewonDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Name = "xPanel1";
            // 
            // cboGwa
            // 
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGwa.UserSQL = resources.GetString("cboGwa.UserSQL");
            this.cboGwa.SelectionChangeCommitted += new System.EventHandler(this.cboGwa_SelectionChangeCommitted);
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpNaewonDate
            // 
            resources.ApplyResources(this.dtpNaewonDate, "dtpNaewonDate");
            this.dtpNaewonDate.Name = "dtpNaewonDate";
            this.dtpNaewonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpNaewonDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // btnList
            // 
            this.btnList.IsVisiblePreview = false;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdList
            // 
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
            this.grdList.ColPerLine = 15;
            this.grdList.Cols = 15;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.Name = "grdList";
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.Rows = 2;
            this.grdList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdList_QueryEnd);
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // XEditGridCell1
            // 
            this.XEditGridCell1.CellName = "bunho";
            resources.ApplyResources(this.XEditGridCell1, "XEditGridCell1");
            // 
            // XEditGridCell2
            // 
            this.XEditGridCell2.CellName = "suname";
            this.XEditGridCell2.Col = 1;
            resources.ApplyResources(this.XEditGridCell2, "XEditGridCell2");
            // 
            // XEditGridCell3
            // 
            this.XEditGridCell3.CellName = "suname2";
            this.XEditGridCell3.Col = 2;
            resources.ApplyResources(this.XEditGridCell3, "XEditGridCell3");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "birth_jp";
            this.xEditGridCell7.Col = -1;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // XEditGridCell5
            // 
            this.XEditGridCell5.CellName = "naewon_date_jp";
            this.XEditGridCell5.Col = 4;
            resources.ApplyResources(this.XEditGridCell5, "XEditGridCell5");
            // 
            // XEditGridCell6
            // 
            this.XEditGridCell6.CellName = "naewon_date";
            this.XEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.XEditGridCell6.Col = 5;
            resources.ApplyResources(this.XEditGridCell6, "XEditGridCell6");
            // 
            // XEditGridCell8
            // 
            this.XEditGridCell8.CellName = "sujin_no";
            this.XEditGridCell8.Col = 7;
            resources.ApplyResources(this.XEditGridCell8, "XEditGridCell8");
            // 
            // XEditGridCell9
            // 
            this.XEditGridCell9.CellName = "jubsu_no";
            this.XEditGridCell9.CellType = IHIS.Framework.XCellDataType.Number;
            this.XEditGridCell9.Col = 8;
            resources.ApplyResources(this.XEditGridCell9, "XEditGridCell9");
            // 
            // XEditGridCell10
            // 
            this.XEditGridCell10.CellName = "gwa";
            this.XEditGridCell10.Col = 9;
            resources.ApplyResources(this.XEditGridCell10, "XEditGridCell10");
            // 
            // XEditGridCell11
            // 
            this.XEditGridCell11.CellName = "gwa_name";
            this.XEditGridCell11.Col = 10;
            resources.ApplyResources(this.XEditGridCell11, "XEditGridCell11");
            // 
            // XEditGridCell12
            // 
            this.XEditGridCell12.CellName = "doctor";
            this.XEditGridCell12.Col = 11;
            resources.ApplyResources(this.XEditGridCell12, "XEditGridCell12");
            // 
            // XEditGridCell13
            // 
            this.XEditGridCell13.CellName = "doctor_name";
            this.XEditGridCell13.Col = 12;
            resources.ApplyResources(this.XEditGridCell13, "XEditGridCell13");
            // 
            // XEditGridCell14
            // 
            this.XEditGridCell14.CellName = "jubsu_gubun";
            this.XEditGridCell14.Col = 13;
            resources.ApplyResources(this.XEditGridCell14, "XEditGridCell14");
            // 
            // XEditGridCell15
            // 
            this.XEditGridCell15.CellName = "jubsu_gubun_name";
            this.XEditGridCell15.Col = 3;
            resources.ApplyResources(this.XEditGridCell15, "XEditGridCell15");
            // 
            // XEditGridCell16
            // 
            this.XEditGridCell16.CellName = "jubsu_time";
            this.XEditGridCell16.CellType = IHIS.Framework.XCellDataType.Time;
            this.XEditGridCell16.Col = 6;
            resources.ApplyResources(this.XEditGridCell16, "XEditGridCell16");
            this.XEditGridCell16.Mask = "HH:MI";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "yoyang_name";
            this.xEditGridCell4.Col = 14;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // dwWindow
            // 
            this.dwWindow.DataWindowObject = "out1101r01";
            resources.ApplyResources(this.dwWindow, "dwWindow");
            this.dwWindow.LibraryList = "..\\NURO\\nuro.out1101r01.pbd";
            this.dwWindow.Name = "dwWindow";
            this.dwWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            // 
            // layPrintName
            // 
            this.layPrintName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2,
            this.singleLayoutItem3});
            this.layPrintName.QuerySQL = "SELECT A.CODE_NAME, A.SORT_KEY\r\nFROM BAS0102 A\r\nWHERE A.HOSP_CODE = FN_ADM_LOAD_H" +
                "OSP_CODE\r\n  AND A.CODE_TYPE = \'PRINT_NAME\'\r\n  AND A.CODE      = \'SUJIN\'";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "code_name";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "sort_key";
            // 
            // OUT1101R01
            // 
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.dwWindow);
            this.Controls.Add(this.xPanel1);
            this.Name = "OUT1101R01";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.OUT1001R01_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
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

		private void OUT1001R01_Load(object sender, System.EventArgs e)
		{
			// DataWindow Preview설정
			this.dwWindow.Modify("DataWindow.Print.Preview=Yes");						
			this.dwWindow.Modify("DataWindow.Print.Preview.Zoom= 100");

			//this.InitScreen();

			if (this.OpenParam != null)
			{
                if (this.OpenParam.Contains("naewon_date"))
                {
                    this.dtpNaewonDate.SetDataValue(this.OpenParam["naewon_date"].ToString());
                }

                if (this.OpenParam.Contains("gwa"))
                {
                    this.cboGwa.SetEditValue(this.OpenParam["gwa"].ToString());
                    this.cboGwa.AcceptData();
                }

                if (this.OpenParam.Contains("auto_close"))
                {
                    this.ParentForm.WindowState = FormWindowState.Minimized;
                    this.mIsAutoClose = (bool)this.OpenParam["auto_close"];
                }

                if (this.mIsAutoClose)
                {
                    PostCallHelper.PostCall(new PostMethod(this.AutoCloseRoutine));
                }
			}
			else
			{
				this.InitScreen();
			}
		}

		#endregion

		#region Function

		private void InitScreen ()
		{
			this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(-1).ToString("yyyy/MM/dd").Replace("-","/"));
            //this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            if (this.cboGwa.ComboItems.Count > 0)
            {
                this.cboGwa.SelectedIndex = 0;
            }
            this.btnList.PerformClick(FunctionType.Query);
		}

		private void AutoCloseRoutine ()
		{
			this.btnList.PerformClick(FunctionType.Query);

			this.btnList.PerformClick(FunctionType.Print);

			this.btnList.PerformClick(FunctionType.Close);
		}
		#endregion

		#region DataLoad

		private void LoadData()
		{

            //string UserSQL = @"SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1', :f_naewon_date) FROM DUAL";
                                                                          
            //SingleLayout layout = new SingleLayout();
            //layout.Reset();
            //layout.LayoutItems.Clear();
            //layout.LayoutItems.Add("naewon_date");
            //layout.QuerySQL = UserSQL;
            //layout.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue().ToString());
            //if (layout.QueryLayout())
            //{
            //    this.dwWindow.Modify("t_naewon_date.text = '" + layout.GetItemValue("naewon_date") + "'");
            //}
            //this.dwWindow.Modify("t_gwaname.text = '" + this.cboGwa.Text.ToString()+ "'");
            this.LoadWindowData(this.dtpNaewonDate.GetDataValue().ToString(), this.cboGwa.Text.ToString());
            this.grdList.QueryLayout(true);
            this.dwWindow.Reset();
            this.dwWindow.FillData(this.grdList.LayoutTable);
		}
        private void CreatScreen()
        {
            this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(-1).ToString("yyyy/MM/dd").Replace("-", "/"));
            if (this.cboGwa.ComboItems.Count > 0)
            {
                this.cboGwa.SelectedIndex = 0;
            }
            this.grdList.Reset();
            this.grdList.InsertRow(0);
            this.LoadWindowData(this.dtpNaewonDate.GetDataValue().ToString(), this.cboGwa.Text.ToString());
            this.dwWindow.Reset();
            this.dwWindow.FillData(this.grdList.LayoutTable);
        }
        private void LoadWindowData(string naewon_date, string gwa)
        {
            string UserSQL = @"SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1', :f_naewon_date) FROM DUAL";

            SingleLayout layout = new SingleLayout();
            layout.Reset();
            layout.LayoutItems.Clear();
            layout.LayoutItems.Add("naewon_date");
            layout.QuerySQL = UserSQL;
            layout.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue().ToString());
            if (layout.QueryLayout())
            {
                this.dwWindow.Modify("t_naewon_date.text = '" + layout.GetItemValue("naewon_date") + "'");
            }
            this.dwWindow.Modify("t_gwaname.text = '" + this.cboGwa.Text.ToString() + "'");
      
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
                    this.LoadData();
					break;

				case FunctionType.Print :

					e.IsBaseCall = false;

					if (this.grdList.RowCount > 0)
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
                                //this.DataServiceCall(this.dsvPrintName);
                                //string printSetName = this.dsvPrintName.GetOutValue("printer_name").ToString();
                                //string paper_source = this.dsvPrintName.GetOutValue("paper_source").ToString();

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
					}
					break;

				case FunctionType.Reset :

					e.IsBaseCall = false;

                    this.CreatScreen();

					break;
			}
		}
		#endregion

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue().ToString());
            this.grdList.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue().ToString());
        }

        private void grdList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdList.RowCount < 1)
            {
                this.grdList.InsertRow(0);
            }
        }

        private void dtpNaewonDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cboGwa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.btnList.PerformClick(FunctionType.Query);
        }

        private void cboGwa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

	}
}

