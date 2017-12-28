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

namespace IHIS.NURI
{
	/// <summary>
	/// NUR1001R07에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1001R07 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlLeft;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdInp2004;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XMstGrid grdInp1001;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XGridHeader xGridHeader5;
        //private IHIS.Framework.DataServiceSIMO dsvQueryInp1001;
        //private IHIS.Framework.DataServiceSIMO dsvQueryInp2004;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XDataWindow dw_Nur1001r07;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR1001R07()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1001R07));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.dw_Nur1001r07 = new IHIS.Framework.XDataWindow();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdInp1001 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader5 = new IHIS.Framework.XGridHeader();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdInp2004 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInp1001)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInp2004)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlTop.Size = new System.Drawing.Size(933, 35);
            this.pnlTop.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(933, 30);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.dw_Nur1001r07);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 555);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(933, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // dw_Nur1001r07
            // 
            this.dw_Nur1001r07.DataWindowObject = "dw_nur1001r07";
            this.dw_Nur1001r07.LibraryList = "..\\NURI\\nuri.nur1001r07.pbd";
            this.dw_Nur1001r07.Location = new System.Drawing.Point(74, -352);
            this.dw_Nur1001r07.Name = "dw_Nur1001r07";
            this.dw_Nur1001r07.Size = new System.Drawing.Size(73, 311);
            this.dw_Nur1001r07.TabIndex = 1;
            this.dw_Nur1001r07.Text = "xDataWindow1";
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(689, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(244, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdInp1001);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 35);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(329, 520);
            this.pnlLeft.TabIndex = 2;
            // 
            // grdInp1001
            // 
            this.grdInp1001.AddedHeaderLine = 1;
            this.grdInp1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20});
            this.grdInp1001.ColPerLine = 4;
            this.grdInp1001.Cols = 4;
            this.grdInp1001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInp1001.FixedRows = 2;
            this.grdInp1001.HeaderHeights.Add(21);
            this.grdInp1001.HeaderHeights.Add(0);
            this.grdInp1001.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader5});
            this.grdInp1001.Location = new System.Drawing.Point(0, 0);
            this.grdInp1001.Name = "grdInp1001";
            this.grdInp1001.QuerySQL = resources.GetString("grdInp1001.QuerySQL");
            this.grdInp1001.ReadOnly = true;
            this.grdInp1001.Rows = 3;
            this.grdInp1001.Size = new System.Drawing.Size(329, 520);
            this.grdInp1001.TabIndex = 1;
            this.grdInp1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdInp1001_QueryStarting);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "pkinp1001";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "pkinp1001";
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "ipwon_date";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell17.CellWidth = 90;
            this.xEditGridCell17.Col = 2;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell17.HeaderText = "入院日付";
            this.xEditGridCell17.IsJapanYearType = true;
            this.xEditGridCell17.RowSpan = 2;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "toiwon_date";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell18.CellWidth = 90;
            this.xEditGridCell18.Col = 3;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell18.HeaderText = "退院日付";
            this.xEditGridCell18.IsJapanYearType = true;
            this.xEditGridCell18.RowSpan = 2;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "ho_dong1";
            this.xEditGridCell19.CellWidth = 70;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "病棟";
            this.xEditGridCell19.Row = 1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "ho_code1";
            this.xEditGridCell20.CellWidth = 60;
            this.xEditGridCell20.Col = 1;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell20.HeaderText = "病室";
            this.xEditGridCell20.Row = 1;
            // 
            // xGridHeader5
            // 
            this.xGridHeader5.ColSpan = 2;
            this.xGridHeader5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader5.HeaderText = "病棟";
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grdInp2004);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(329, 35);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(604, 520);
            this.pnlFill.TabIndex = 3;
            // 
            // grdInp2004
            // 
            this.grdInp2004.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdInp2004.ColPerLine = 8;
            this.grdInp2004.Cols = 8;
            this.grdInp2004.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInp2004.FixedRows = 1;
            this.grdInp2004.HeaderHeights.Add(21);
            this.grdInp2004.Location = new System.Drawing.Point(0, 0);
            this.grdInp2004.MasterLayout = this.grdInp1001;
            this.grdInp2004.Name = "grdInp2004";
            this.grdInp2004.QuerySQL = resources.GetString("grdInp2004.QuerySQL");
            this.grdInp2004.ReadOnly = true;
            this.grdInp2004.Rows = 2;
            this.grdInp2004.Size = new System.Drawing.Size(604, 520);
            this.grdInp2004.TabIndex = 0;
            this.grdInp2004.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdInp2004_QueryStarting);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "fkinp1001";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "fkinp1001";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "order_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 100;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "転科転室日付";
            this.xEditGridCell7.IsJapanYearType = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "from_gwa";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "from_gwa";
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "to_gwa";
            this.xEditGridCell9.CellWidth = 90;
            this.xEditGridCell9.Col = 6;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "診療科";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "from_doctor";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell10.HeaderText = "from_doctor";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "to_doctor";
            this.xEditGridCell11.CellWidth = 100;
            this.xEditGridCell11.Col = 7;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "主治医";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "from_ho_dong1";
            this.xEditGridCell12.CellWidth = 70;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "from_ho_dong1";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "to_ho_dong1";
            this.xEditGridCell13.CellWidth = 90;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderText = "病棟";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "from_ho_code1";
            this.xEditGridCell14.CellWidth = 60;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "from_ho_code1";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "to_ho_code1";
            this.xEditGridCell15.CellWidth = 50;
            this.xEditGridCell15.Col = 4;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "病室";
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "trans_cnt";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.CellWidth = 40;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "順番";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "trans_time";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell2.CellWidth = 70;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "時間";
            this.xEditGridCell2.Mask = "HH:MI";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "from_bed_no";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "from_bed";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "to_bed_no";
            this.xEditGridCell4.CellWidth = 45;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "病床";
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NUR1001R07
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1001R07";
            this.Size = new System.Drawing.Size(933, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1001R07_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInp1001)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInp2004)).EndInit();
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
				case "print":
					msg = (NetInfo.Language == LangMode.Ko ? "출력할 병동이동이력정보가 없습니다."
						: "出力する病棟移動履歴情報がありません。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				default:
					break;
			}
		}
		#endregion

		#region Screen Load
		private void NUR1001R07_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{

			if (this.OpenParam != null)
			{
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
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

		#region 조회
		private void GetInpData()
		{
			if (this.paBox.BunHo.ToString() == "") return;			
            
            if (this.grdInp1001.QueryLayout(false))
			{
				if (this.grdInp1001.RowCount > 0)
				{
					if (!this.grdInp2004.QueryLayout(false))
					{
						XMessageBox.Show(Service.ErrFullMsg.ToString());
						return;
					}
				}
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}
		}
		#endregion

		#region 출력
		private void SetPrint()
		{
			this.dw_Nur1001r07.Reset();

			if (this.grdInp2004.RowCount == 0)
			{
				this.GetMessage("print");
				return;
			}
			else
			{
				this.dw_Nur1001r07.FillData(this.grdInp2004.LayoutTable);
				this.dw_Nur1001r07.Modify("tbxbunho.Text = '" + this.paBox.BunHo.ToString() + "(" + this.paBox.SuName.ToString() + ")" + "'");
				this.dw_Nur1001r07.Print(true);
				return;
			}
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
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

					//조회
					this.GetInpData();
					break;
				case FunctionType.Print:
					if (!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					try
					{	
						Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
						SetMsg("");

						//출력
						this.SetPrint();
				
					}
					finally
					{
						SetMsg(" ");
						Cursor.Current = System.Windows.Forms.Cursors.Default;
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 환자번호를 입력을 했을 경우에
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			//조회
			this.GetInpData();
		}
		#endregion

        #region QueryStarting
        private void grdInp1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdInp1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode );
            this.grdInp1001.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void grdInp2004_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdInp2004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdInp2004.SetBindVarValue("f_bunho",paBox.BunHo);
            this.grdInp2004.SetBindVarValue("f_fkinp1001",this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber,"pkinp1001"));
        }
        #endregion
    }
}

