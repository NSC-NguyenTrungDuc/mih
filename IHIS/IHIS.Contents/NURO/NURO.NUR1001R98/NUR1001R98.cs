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
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.Framework;
using IHIS.NURO.Properties;
using IHIS.CloudConnector.Contracts.Results;

#endregion

namespace IHIS.NURO
{
	/// <summary>
	/// NUR1001R98에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1001R98 : IHIS.Framework.XScreen
	{
		#region 화면변수
		private string aAuto_close     = "N";
        private string mReserDate = "";

        private string jundalT = "";
        private string jundalP = "";

        

        // 予約された全てのパート
        private string reserPart = "";
        private int print_pagecount = 1;

        //CloudVersion added 2015-10-12
        List<DataStringListItemInfo> reserPartList = new List<DataStringListItemInfo>();

		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdReser_date;
		private IHIS.Framework.XDataWindow dwReser_Print;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XLabel lblBunho;
        //private IHIS.Framework.DataServiceSIMO dsvReser_List;
        private IHIS.Framework.MultiLayout layReserInfo;
        private XEditGridCell xEditGridCell1;
        private MultiLayout layComments;
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
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem36;
        private XButton btnReserOrder;
        private MultiLayout layInfoText;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem3;
        //private IHIS.Framework.DataServiceSIMO dsvReserInfo;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;


	    private NUR1001R98LayReserInfoQueryEndResult queryEndResult = null;
		#endregion

		#region 생성자
		public NUR1001R98()
		{

            // 이 호출은 Windows Form 디자이너에 필요합니다.
		    InitializeComponent();
            // create param list
            this.grdReser_date.ParamList = CreateCheckBookingParamList();
            this.layReserInfo.ParamList = CreateInspectionOrderParamList();
            this.layInfoText.ParamList = CreateInfoTextParamList();
            
            // execute query
            this.grdReser_date.ExecuteQuery = GetCheckBookingInfoList;
            this.layReserInfo.ExecuteQuery = GetInspectionOrderList;
            this.layInfoText.ExecuteQuery = GetInfoTextList;

            if (NetInfo.Language != LangMode.Vi)
            {
                this.xEditGridCell4.IsJapanYearType = true;
            }
		}

	    protected override void OnLoad(EventArgs e)
	    {
	        base.OnLoad(e);
            ApplyMultilanguageDatawindow();
	    }

	    #endregion

		#region 소멸자
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
		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1001R98));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.lblBunho = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnReserOrder = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdReser_date = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.dwReser_Print = new IHIS.Framework.XDataWindow();
            this.layReserInfo = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.layComments = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.layInfoText = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReser_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layInfoText)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "이름바꾸기.gif");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblBunho);
            this.pnlTop.Controls.Add(this.paBox);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // lblBunho
            // 
            this.lblBunho.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBunho.EdgeRounding = false;
            this.lblBunho.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblBunho, "lblBunho");
            this.lblBunho.Name = "lblBunho";
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnReserOrder);
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnReserOrder
            // 
            this.btnReserOrder.ImageIndex = 2;
            this.btnReserOrder.ImageList = this.ImageList;
            resources.ApplyResources(this.btnReserOrder, "btnReserOrder");
            this.btnReserOrder.Name = "btnReserOrder";
            this.btnReserOrder.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReserOrder.Click += new System.EventHandler(this.btnReserOrder_Click);
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
            // grdReser_date
            // 
            this.grdReser_date.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell4,
            this.xEditGridCell1});
            this.grdReser_date.ColPerLine = 1;
            this.grdReser_date.Cols = 2;
            resources.ApplyResources(this.grdReser_date, "grdReser_date");
            this.grdReser_date.ExecuteQuery = null;
            this.grdReser_date.FixedCols = 1;
            this.grdReser_date.FixedRows = 1;
            this.grdReser_date.HeaderHeights.Add(21);
            this.grdReser_date.Name = "grdReser_date";
            this.grdReser_date.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdReser_date.ParamList")));
            this.grdReser_date.QuerySQL = resources.GetString("grdReser_date.QuerySQL");
            this.grdReser_date.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdReser_date.RowHeaderVisible = true;
            this.grdReser_date.Rows = 2;
            this.grdReser_date.RowStateCheckOnPaint = false;
            this.grdReser_date.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdReser_date_RowFocusChanged);
            this.grdReser_date.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdReser_date_QueryStarting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 75;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "reser_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 137;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            //this.xEditGridCell4.IsJapanYearType = true;
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "check";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // dwReser_Print
            // 
            this.dwReser_Print.DataWindowObject = "dw_reser_list_01";
            resources.ApplyResources(this.dwReser_Print, "dwReser_Print");
            this.dwReser_Print.LibraryList = "NURO\\nuro.nur1001r98.pbd";
            this.dwReser_Print.Name = "dwReser_Print";
            this.dwReser_Print.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            // 
            // layReserInfo
            // 
            this.layReserInfo.ExecuteQuery = null;
            this.layReserInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem36});
            this.layReserInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserInfo.ParamList")));
            this.layReserInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layReserInfo_QueryStarting);
            this.layReserInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layReserInfo_QueryEnd);
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "gwa";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "gwa_name";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "bunho";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "suname";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "reser_date";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "hangmog_name";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "reser_time";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "move_name";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "reser_day";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "age";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "birth";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "suname2";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "jundal_part";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "reser_move_name";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "hangmog_code";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "jundal_table";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "hope_date";
            this.multiLayoutItem36.DataType = IHIS.Framework.DataType.Date;
            // 
            // layComments
            // 
            this.layComments.ExecuteQuery = null;
            this.layComments.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3});
            this.layComments.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layComments.ParamList")));
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "comments";
            // 
            // layInfoText
            // 
            this.layInfoText.ExecuteQuery = null;
            this.layInfoText.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1});
            this.layInfoText.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layInfoText.ParamList")));
            this.layInfoText.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layInfoText_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "info_text";
            // 
            // NUR1001R98
            // 
            this.Controls.Add(this.dwReser_Print);
            this.Controls.Add(this.grdReser_date);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1001R98";
            resources.ApplyResources(this, "$this");
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1001R98_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReser_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layInfoText)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "print_num":
					msg = Resources.MSG001_MSG;
					caption = Resources.MSG001_CAP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				default:
					break;
			}
		}
		#endregion

		#region 예약일자리스트 조회
		private void GetReserList()
		{
			this.dwReser_Print.Reset();
            ApplyMultilanguageDatawindow();
			this.grdReser_date.Reset();

            //tungtx added hospital name to datawindow
            string t_hosp_name = "hospital_name.text = '" + UserInfo.HospName + "'";
            dwReser_Print.Modify(t_hosp_name);

            if (!this.grdReser_date.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}

		}
		#endregion

        private void FillDataWindow(IHIS.Framework.MultiLayout layReser)
        {

            string text = layReser.GetItemString(0, "reser_date");
            string[] words = text.Split('/');
            DateTime date = new DateTime(int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]));
            string dateString;

            switch (NetInfo.Language)
            {
                case LangMode.Vi:
                    dateString = date.ToString("dd/MM/yyyy");
                    //this.layReserInfo.SetItemValue(0, "reser_date", dateString);
                    dwReser_Print.Modify(string.Format("t_reser_date.text = '{0}'", dateString));
                    break;

                case LangMode.Jr:
                    dateString = date.ToString("yyyy年 MM月 dd日");
                    dwReser_Print.Modify(string.Format("t_reser_date.text = '{0}'", dateString));
                    break;
                default:
                    break;
            }

            string reserDay = layReser.GetItemString(0, "reser_day");
            reserDay = "(" + Resources.ResourceManager.GetString("DW_Number" + reserDay) + ")";
            layReser.SetItemValue(0, "reser_day", reserDay);

            string t_birthday = layReser.GetItemString(0, "birth");
            DateTime birthDay = DateTime.ParseExact(t_birthday, "yyyy/MM/dd", null);

            string birthdayText = birthDay.ToString("dd/MM/yyyy");
            dwReser_Print.Modify(string.Format("t_birthday.text = '{0}'", birthdayText));
        }

		#region 예약정보 조회
		private void GetReserInfo(string aQyery_gubun)
		{			
			switch(aQyery_gubun)
			{
				case "Y":

                    if (this.grdReser_date.RowCount <= 0)
                        this.Close();
					this.dwReser_Print.Reset();

					this.layReserInfo.Reset();
	
					if (this.layReserInfo.QueryLayout(true))
                    {

                        FillDataWindow(layReserInfo);


						this.dwReser_Print.FillData(this.layReserInfo.LayoutTable);
						try
						{
                            for (int i = 1; i <= this.print_pagecount; i++)
                            {
                                this.dwReser_Print.Print(true);
                            }
                            
						}
						catch
                        {
                            this.Close();
                            //return;
						}
					}
					else
					{
                        XMessageBox.Show(Service.ErrFullMsg.ToString());
                        this.Close();
                        //return;
					}
					
					if (this.aAuto_close.ToString() == "Y")
					{
						this.Close();
					}
					break;

				case "N":

                    if (this.grdReser_date.RowCount <= 0)
                        return;
					this.dwReser_Print.Reset();

					this.layReserInfo.Reset();					

					if (this.layReserInfo.QueryLayout(true))
					{
                        FillDataWindow(layReserInfo);
						this.dwReser_Print.FillData(this.layReserInfo.LayoutTable);
					}
					else
					{
						XMessageBox.Show(Service.ErrFullMsg.ToString());
						return;
					}
					break;
			}
		}
		#endregion

		#region Screen Load
        private string mHospCode = "";
		private void NUR1001R98_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            this.mReserDate = "";
            mHospCode = EnvironInfo.HospCode;

            NuroNUR1001R98PageCountArgs pageCountArgs = new NuroNUR1001R98PageCountArgs();
		    pageCountArgs.CodeType = "PRINT_PAGECOUNT";
		    pageCountArgs.Code = "COUNT";
		    string pageCount = GetPageCount(pageCountArgs);

            if (pageCount.Trim().Length != 0)
                this.print_pagecount = int.Parse(pageCount);

			if (this.OpenParam != null)
			{
				if(OpenParam.Contains("auto_close") && this.OpenParam["auto_close"].ToString() != "")
				{
					this.aAuto_close = this.OpenParam["auto_close"].ToString();

                    if (this.aAuto_close.ToString() == "Y")
                    { 
                        this.ParentForm.WindowState = FormWindowState.Minimized;
                        if (OpenParam.Contains("reser_date"))
                        {
                            this.mReserDate = this.OpenParam["reser_date"].ToString();
                        }
                    }
				}

                if (OpenParam.Contains("jundal_table") && this.OpenParam["jundal_table"].ToString() != "")
                {
                    this.jundalT = this.OpenParam["jundal_table"].ToString();
                }

                if (OpenParam.Contains("jundal_part") && this.OpenParam["jundal_part"].ToString() != "")
                {
                    this.jundalP = this.OpenParam["jundal_part"].ToString();
                }

				if(OpenParam.Contains("bunho") && this.OpenParam["bunho"].ToString() != "")
				{
					this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
				}

				for (int i = 0; i < this.grdReser_date.RowCount; i++)
				{
					this.grdReser_date.SetItemValue(i, "check", "Y");
				}

                if (this.aAuto_close.ToString() == "Y")
                {
                    if (this.grdReser_date.RowCount <= 0)
                        this.Close();
                }

			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.paBox.SetPatientID(patientInfo.BunHo);
				}
			}

		}
		#endregion

		#region [환자정보 Reques/Receive Event]
		/// <summary>
		/// Docking Screen에서 환자정보 변경시 Raise
		/// </summary>
		public override void OnReceiveBunHo(XPatientInfo info)
		{
			if (info != null && !TypeCheck.IsNull(info.BunHo))
			{
				this.paBox.Focus();
				this.paBox.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
			{
				return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			int aPrint_num = 0;

			switch(e.Func)
			{
				case FunctionType.Query:
					if (!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					//예약일자리스트 조회
					this.GetReserList();
					break;
				case FunctionType.Print:

                    if (layReserInfo.RowCount == 0)
                    {
                        try
                        {
                            this.dwReser_Print.Print();
                        }
                        catch { }
                    return;
                    }

					if (!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

                    /*
					//인쇄할 환자를 선택을 했는지 체크
					//for (int i = 0; i < this.grdReser_date.RowCount; i++)
					//{
					//	if (this.grdReser_date.GetItemValue(i, "check").ToString() == "Y")
					//	{
					//		aPrint_num++;
					//	}
					//}

					//if (aPrint_num == 0)
					//{
					//	this.GetMessage("print_num");
					//	e.IsBaseCall = false;
					//	e.IsSuccess = false;
					//	return;
					//}
                    */

					//출력할 예약정보 조회
					this.GetReserInfo("Y");
					break;
				default:
					break;
			}
		}
		#endregion

		#region 날짜를 변경을 했을 때
		private void dtpReser_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			//예약일자리스트 조회
			this.GetReserList();
		}
		#endregion

		#region 환자번호를 입력을 했을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			//예약일자리스트 조회
			this.GetReserList();
		}
		#endregion

		#region 그리드의 Row포커스가 변경이 될 경우
		private void grdReser_date_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{

            if (this.aAuto_close.ToString() == "Y")
                this.GetReserInfo("Y");
            //출력할 예약정보 조회
            else
			this.GetReserInfo("N");
		}
		#endregion

        private void layReserInfo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //　予約パート初期化
            this.reserPart = "";
            //string reserMoveName;
            //NuroInspectionOrderGetReserMoveNameArgs reserMoveNameArgs = new NuroInspectionOrderGetReserMoveNameArgs();
            //reserMoveNameArgs.PatientCode = this.paBox.BunHo;
            //reserMoveNameArgs.ReserDate = this.grdReser_date.GetItemString(this.grdReser_date.CurrentRowNumber, "reser_date");
            //reserMoveNameArgs.ReserYn = "Y";
            //reserMoveNameArgs.RowNum = "1";
            //for (int i = 0; i < this.layReserInfo.RowCount; i++)
            //{
            //    reserMoveNameArgs.DepartmentCode = this.layReserInfo.GetItemString(i, "gwa");
            //    reserMoveName = GetReserMoveName(reserMoveNameArgs);

            //    this.layReserInfo.SetItemValue(i, "reser_move_name", reserMoveName);

            //    // 予約パートをセットする。
                //this.setReserPart(this.layReserInfo.GetItemString(i, "jundal_part"));
            //}

            //tungtx

            for (int i = 0; i < this.layReserInfo.RowCount; i++)
            {
                this.setReserPart(this.layReserInfo.GetItemString(i, "jundal_part"));
            }
           

            NUR1001R98LayReserInfoQueryEndArgs args = new NUR1001R98LayReserInfoQueryEndArgs();
            args.PatientCode = this.paBox.BunHo;
            args.ReserDate = this.grdReser_date.GetItemString(this.grdReser_date.CurrentRowNumber, "reser_date");
            args.ReserYn = "Y";
            args.RowNum = "1";
            List<DataStringListItemInfo> departmentList = new List<DataStringListItemInfo>();
            for (int i = 0; i < this.layReserInfo.RowCount; i++)
            {
                DataStringListItemInfo info = new DataStringListItemInfo();
                info.DataValue = this.layReserInfo.GetItemString(i, "gwa");
                departmentList.Add(info);
            }
            args.DepartmentCode = departmentList;
            args.ReserPart = this.reserPartList;
            args.CodeType = "RESER_CMT_TEXT";
            args.CodeTypeGetInfoText = "RESER_INFO_TEXT";
           
            queryEndResult =
                CloudService.Instance.Submit<NUR1001R98LayReserInfoQueryEndResult, NUR1001R98LayReserInfoQueryEndArgs>(
                    args);
            
            List<DataStringListItemInfo> reserMoveNameList = queryEndResult.ReserMoveName;
            for (int i = 0; i < reserMoveNameList.Count; i++)
            {
                this.layReserInfo.SetItemValue(i, "reser_move_name", reserMoveNameList[i].DataValue);

                // 予約パートをセットする。
                this.setReserPart(this.layReserInfo.GetItemString(i, "jundal_part"));
                
            }

            

            //NuroInspectionOrderGetTelArgs telArgs = new NuroInspectionOrderGetTelArgs();
            //telArgs.ReserDate = this.grdReser_date.GetItemString(this.grdReser_date.CurrentRowNumber, "reser_date");
            
            //string tel = GetTel(telArgs);


            //tungtx
            string tel = queryEndResult.TelItem;
            string t_text = "";
            if (tel.Trim().Length != 0)
            {
                t_text = "t_tel.text = '" + tel + "'";
                dwReser_Print.Modify(t_text);

            }

            //XMessageBox.Show(this.reserPart);

            ///////////////////////////////////////////////////////////////////////////
            this.layComments.ParamList = CreateMaxCodeNameParamList();
            this.layComments.ExecuteQuery = GetMaxCodeNameList;

            this.layComments.Reset();
            this.layComments.SetBindVarValue("f_hosp_code", this.mHospCode);


            t_text = "";
            if (this.layComments.QueryLayout(true) && this.layComments.RowCount > 0)
            {
                this.layComments.QueryLayout(true);

                string comments = "";
                for (int i = 0; i < this.layComments.RowCount; i++)
                {
                    comments += this.layComments.GetItemString(i, "comments") + "\r\n";
                }
                t_text = "t_comments.text = '" + comments + "'";
            }
            else
            {
                t_text = "t_comments.text = ''";
            }

            dwReser_Print.Modify(t_text);
            //////////////////////////////////////////////////////////////////////////
            this.layInfoText.ExecuteQuery = GetInfoTextList;
            this.layInfoText.QueryLayout(true);
            string info_text = "";            
            for (int i = 0; i < this.layInfoText.RowCount; i++)
            {
                info_text += this.layInfoText.GetItemString(i, "info_text") + "\r\n";     
            }

            t_text = "";
            t_text = "t_reser_info.text = '" + info_text + "'";
            dwReser_Print.Modify(t_text);

            dwReser_Print.Refresh();
        }
       
        #region [setReserPart 予約票コメント内容取得のための予約パートをセットする。]

        bool flag = true;
        private void setReserPart(string part)
        {
            
           // if (part.Equals("")) return;

           //=== sua
            if (part.Equals(""))
            {
                if (flag == true)
                {
                    this.reserPartList.Clear();
                    flag = false;
                }
                else
                {
                    flag = true;
                }
                
                return;
            }
            //=== end

            //modified by CloudVersion on 2015-10-12
            if (this.reserPart.Equals(""))
            {
                flag = false;
                this.reserPart = "'" + part + "'";
                this.reserPartList.Clear();
                this.reserPartList.Add(new DataStringListItemInfo(part));
            }
            else
            {
                //hoang 1 line
                this.reserPartList.Clear();
                this.reserPart = this.reserPart + "," + "'" + part + "'";
                this.reserPartList.Add(new DataStringListItemInfo(part));
            }
            // 'a','b','c'
        }
        #endregion

        private void layReserInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            //XMessageBox.Show("GetItemString : " + this.grdReser_date.GetItemString(this.grdReser_date.CurrentRowNumber, "reser_date"));
            //XMessageBox.Show("GetItemDateTime : " + this.grdReser_date.GetItemDateTime(this.grdReser_date.CurrentRowNumber, "reser_date"));
            //XMessageBox.Show("GetItemValue : " + this.grdReser_date.GetItemValue(this.grdReser_date.CurrentRowNumber, "reser_date"));

            this.layReserInfo.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layReserInfo.SetBindVarValue("f_reser_date", this.grdReser_date.GetItemString(this.grdReser_date.CurrentRowNumber, "reser_date"));
            this.layReserInfo.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void grdReser_date_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdReser_date.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdReser_date.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdReser_date.SetBindVarValue("f_reser_date", this.mReserDate);
        }

        private void layInfoText_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layInfoText.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void btnReserOrder_Click(object sender, EventArgs e)
        {
            IHIS.Framework.IXScreen aScreen;

            string bunho = this.paBox.BunHo;

            aScreen = XScreen.FindScreen("SCHS", "SCH0201U10");

            if (aScreen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);

                XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201U10", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }

        }

        private IList<object[]> GetCheckBookingInfoList(BindVarCollection list)
        {
            this.layReserInfo.Reset();
            List<object[]> grdReserDate = null;
            if (list != null && list.Count != 0)
            {
                // set arguments
                NuroCheckBookingArgs nuroCheckBookingArgs = new NuroCheckBookingArgs();
                nuroCheckBookingArgs.PatientCode = list["f_bunho"].VarValue;
                nuroCheckBookingArgs.ReserDate = list["f_reser_date"].VarValue;

                // get results
                NuroCheckBookingResult result =
                    CloudService.Instance.Submit<NuroCheckBookingResult, NuroCheckBookingArgs>(nuroCheckBookingArgs);
                grdReserDate = new List<object[]>();
                IList<NuroCheckBookingInfo> checkBookingItemList = result.CheckBookingInfo;
                foreach (NuroCheckBookingInfo item in checkBookingItemList)
                {
                    grdReserDate.Add(new object[]
                    {
                        item.PatientCode,
                        item.ReserData
                    });
                }
            }
            return grdReserDate;
        }
        
	    private List<string> CreateCheckBookingParamList()
	    {
	        List<string> paramList = new List<string>();
            paramList.Add("f_hosp_code");
            paramList.Add("f_bunho");
            paramList.Add("f_reser_date");
	        return paramList;
	    }

        private IList<object[]> GetInspectionOrderList(BindVarCollection list)
        {
            #region deleted by AnhNV
            //List<object[]> reserInfoLay = null;
            //if (list != null && list.Count != 0)
            //{
            //    // set arguments
            //    NuroInspectionOrderArgs nuroInspectionOrderArgs = new NuroInspectionOrderArgs();
            //    nuroInspectionOrderArgs.PatientCode = list["f_bunho"].VarValue;
            //    nuroInspectionOrderArgs.ReserDate = list["f_reser_date"].VarValue;

            //    // get results
            //    NuroInspectionOrderResult result =
            //        CloudService.Instance.Submit<NuroInspectionOrderResult, NuroInspectionOrderArgs>(nuroInspectionOrderArgs);
            //    reserInfoLay = new List<object[]>();
            //    IList<NuroInspectionOrderInfo> inspectionOrderInfos = result.InspectionOrderInfo;
            //    foreach (NuroInspectionOrderInfo item in inspectionOrderInfos)
            //    {
            //        reserInfoLay.Add(new object[]
            //        {
            //            item.DepartmentCode,
            //            item.DepartmentName,
            //            item.PatientCode,
            //            item.PatientName,
            //            item.ReserDate,
            //            item.HangmogName,
            //            item.ReserTime,
            //            item.MoveName,
            //            item.ReserDay,
            //            item.PatientName2,
            //            item.JundalPart,
            //            item.ReserMoveName,
            //            item.ItemCode,
            //            item.JundalTable,
            //            item.HopeDate,
            //            item.Seq,
            //            item.Sort,
            //            item.SortTime
            //        });
            //    }
            //}
            //return reserInfoLay;
            #endregion

            // 2015.06.15 AnhNV hot fixed
            IList<object[]> lObj = new List<object[]>();

            NuroInspectionOrderArgs args = new NuroInspectionOrderArgs();
            args.PatientCode    = list["f_bunho"].VarValue;
            args.ReserDate      = list["f_reser_date"].VarValue;
            NuroInspectionOrderResult res = CloudService.Instance.Submit<NuroInspectionOrderResult, NuroInspectionOrderArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.InspectionOrderInfo.ForEach(delegate(NuroInspectionOrderInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Gwa,
                        item.GwaName,
                        item.Bunho,
                        item.Suname,
                        item.ReserDate,
                        item.HangmogName,
                        item.ReserTime,
                        item.MoveName,
                        item.ReserDay,
                        item.Age,
                        item.Birth,
                        item.Suname2,
                        item.JundalPart,
                        item.ReserMoveName,
                        item.HangmogCode,
                        item.JundalTable,
                        item.HopeDate,
                        item.Seq,
                        item.Sort,
                        item.SortTime,
                    });
                });
            }

            return lObj;
        }

	    private List<string> CreateInspectionOrderParamList()
	    {
	        List<string> paramList = new List<string>();
            paramList.Add("f_hosp_code");
            paramList.Add("f_reser_date");
            paramList.Add("f_bunho");
	        return paramList;
	    }
        
        private IList<object[]> GetInfoTextList(BindVarCollection list)
        {
            //List<object[]> infoTextLay = null;
            //if (list != null && list.Count != 0)
            //{
            //    // set arguments
            //    NuroInspectionOrderGetInfoTextArgs infoTextArgs = new NuroInspectionOrderGetInfoTextArgs();
            //    infoTextArgs.CodeType = "RESER_INFO_TEXT";

            //    // get results
            //    NuroInspectionOrderGetInfoTextResult result =
            //        CloudService.Instance.Submit<NuroInspectionOrderGetInfoTextResult, NuroInspectionOrderGetInfoTextArgs>(infoTextArgs);
            //    infoTextLay = new List<object[]>();
            //    IList<String> infoTextList = result.InfoTextItem;
            //    foreach (String item in infoTextList)
            //    {
            //        infoTextLay.Add(new object[]
            //        {
            //            item
            //        });
            //    }
            //}
            //return infoTextLay;

            //tungtx
            List<object[]> infoTextLay = new List<object[]>();
            List<DataStringListItemInfo> dataStringList = queryEndResult.InfoTextItem;
            foreach (DataStringListItemInfo item in dataStringList)
            {
                infoTextLay.Add(new object[]
                    {
                        item.DataValue
                    });
            }
            return infoTextLay;
        }

        private List<string> CreateInfoTextParamList()
	    {
	        List<string> paramList = new List<string>();
            paramList.Add("f_hosp_code");
	        return paramList;
	    }

        private string GetPageCount(NuroNUR1001R98PageCountArgs pageCountArgs)
        {
            // get results
            NuroNUR1001R98PageCountResult result =
                CloudService.Instance.Submit<NuroNUR1001R98PageCountResult, NuroNUR1001R98PageCountArgs>(pageCountArgs);
            return result.Count;
        }
        
        private string GetReserMoveName(NuroInspectionOrderGetReserMoveNameArgs reserMoveNameArgs)
        {
            // get results
            NuroInspectionOrderGetReserMoveNameResult result =
                CloudService.Instance.Submit<NuroInspectionOrderGetReserMoveNameResult, NuroInspectionOrderGetReserMoveNameArgs>(reserMoveNameArgs);
            return result.ReserMoveName;
        }

        private string GetTel(NuroInspectionOrderGetTelArgs telArgs)
        {
            // get results
            NuroInspectionOrderGetTelResult result =
                CloudService.Instance.Submit<NuroInspectionOrderGetTelResult, NuroInspectionOrderGetTelArgs>(telArgs);
            return result.TelItem;
        }

        private IList<object[]> GetMaxCodeNameList(BindVarCollection list)
        {
            //List<object[]> commentsLay = null;
            //if (list != null && list.Count != 0)
            //{
            //    // set arguments
            //    NuroInspectionOrderGetMaxCodeNameArgs maxCodeNameArgs = new NuroInspectionOrderGetMaxCodeNameArgs();
            //    maxCodeNameArgs.CodeType = "RESER_CMT_TEXT";
            //    maxCodeNameArgs.ReserPart = this.reserPart;

            //    // get results
            //    NuroInspectionOrderGetMaxCodeNameResult result =
            //        CloudService.Instance.Submit<NuroInspectionOrderGetMaxCodeNameResult, NuroInspectionOrderGetMaxCodeNameArgs>(maxCodeNameArgs);
            //    commentsLay = new List<object[]>();
            //    IList<String> codeNameList = result.CodeNameItem;
            //    foreach (String item in codeNameList)
            //    {
            //        commentsLay.Add(new object[]
            //        {
            //            item
            //        });
            //    }
            //}
            //return commentsLay;

            //tungtx
            List<object[]> commentsLay = new List<object[]>();
            List<DataStringListItemInfo> dataStringList = queryEndResult.CodeNameItem;
            foreach (DataStringListItemInfo item in dataStringList)
            {
                commentsLay.Add(new object[]
                    {
                        item.DataValue
                    });
            }
            return commentsLay;
        }

        private List<string> CreateMaxCodeNameParamList()
	    {
	        List<string> paramList = new List<string>();
            paramList.Add("f_hosp_code");
	        return paramList;
	    }

	    private void ApplyMultilanguageDatawindow()
	    {
	        try
	        {
                dwReser_Print.Refresh();
	            //dwReser_Print
	            dwReser_Print.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_001));
	            dwReser_Print.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_002));
	            dwReser_Print.Modify(string.Format("t_6.text = '{0}'", Properties.Resources.DW_TXT_003));
	            dwReser_Print.Modify(string.Format("t_5.text = '{0}'", Properties.Resources.DW_TXT_004));
	            dwReser_Print.Modify(string.Format("t_14.text = '{0}'", Properties.Resources.DW_TXT_005));
	            dwReser_Print.Modify(string.Format("t_22.text = '{0}'", Properties.Resources.DW_TXT_006));
	            dwReser_Print.Modify(string.Format("t_21.text = '{0}'", Properties.Resources.DW_TXT_007));
	            dwReser_Print.Modify(string.Format("t_10.text = '{0}'", Properties.Resources.DW_TXT_008));
	            dwReser_Print.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_009));
	            dwReser_Print.Modify(string.Format("t_23.text = '{0}'", Properties.Resources.DW_TXT_010));
	            dwReser_Print.Modify(string.Format("t_20.text = '{0}'", Properties.Resources.DW_TXT_011));
                dwReser_Print.Modify(string.Format("t_24.text = '{0}'", Properties.Resources.DW_TXT_012));
	            dwReser_Print.Modify(string.Format("t_28.text = '{0}'", Properties.Resources.DW_TXT_013));
	            dwReser_Print.Modify(string.Format("t_29.text = '{0}'", Properties.Resources.DW_TXT_014));
	            dwReser_Print.Modify(string.Format("t_16.text = '{0}'", Properties.Resources.DW_TXT_015));

                if (NetInfo.Language != LangMode.Jr)
                {
                    dwReser_Print.Modify(string.Format("t_1.Font.Height='25'"));
                    dwReser_Print.Modify(string.Format("t_1.Font.Face='{0}'", Service.COMMON_FONT_BOLD.Name));
                    dwReser_Print.Modify(string.Format("t_2.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_5.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_6.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_21.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_20.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_22.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_3.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_10.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_23.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_reser_date.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_birthday.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_15.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_14.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_24.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_comments.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_reser_info.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("hospital_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_29.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_16.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_tel.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("t_28.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("bunho.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("suname.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("suname2.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("reser_date.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("reser_day.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("age.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("move_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("gwa_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
                    dwReser_Print.Modify(string.Format("reser_time.Font.Face='{0}'", Service.COMMON_FONT.Name));

                    
                    dwReser_Print.Modify(string.Format("t_2.Font.Height='15'"));
                    dwReser_Print.Modify(string.Format("t_5.Font.Height='15'"));
                    dwReser_Print.Modify(string.Format("t_3.Font.Height='15'"));
                    dwReser_Print.Modify(string.Format("t_14.Font.Height='15'"));
                    dwReser_Print.Modify(string.Format("t_22.Font.Height='13'"));
                    dwReser_Print.Modify(string.Format("t_21.Font.Height='13'"));
                    dwReser_Print.Modify(string.Format("t_10.Font.Height='13'"));
                    dwReser_Print.Modify(string.Format("t_3.Font.Height='13'"));
                    dwReser_Print.Modify(string.Format("t_23.Font.Height='13'"));
                    dwReser_Print.Modify(string.Format("t_20.Font.Height='13'"));
                    dwReser_Print.Modify(string.Format("t_28.Font.Height='16'"));
                    dwReser_Print.Modify(string.Format("t_29.Font.Height='16'"));
                    dwReser_Print.Modify(string.Format("t_16.Font.Height='16'"));
                }
	        }
	        catch (Exception ex)
	        {
	            throw ex;
	        }
	    }
	}
}

