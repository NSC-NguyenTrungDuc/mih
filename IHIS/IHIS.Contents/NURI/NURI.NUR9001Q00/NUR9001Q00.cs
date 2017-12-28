#region 사용 NameSpace 지정
using System;
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
	/// NUR9001Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR9001Q00 : IHIS.Framework.XScreen
    {

        #region 추가사항
        string times1, times2, times3;
        #endregion

        #region 자동생성
        private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdNUR9001;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XButton btnOpen;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XPanel pnlTopLeft;
		private IHIS.Framework.XDatePicker dtpRecord_date;
		private IHIS.Framework.XLabel lblRecord_date;
		private IHIS.Framework.XButton btnPrint;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XButton btnOutPatient;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
        private MultiLayout layWorkTime;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR9001Q00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR9001Q00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlTopLeft = new IHIS.Framework.XPanel();
            this.dtpRecord_date = new IHIS.Framework.XDatePicker();
            this.lblRecord_date = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnOutPatient = new IHIS.Framework.XButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.btnOpen = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdNUR9001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.layWorkTime = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlTopLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR9001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWorkTime)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.pnlTopLeft);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlTop.Size = new System.Drawing.Size(960, 45);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.Controls.Add(this.dtpRecord_date);
            this.pnlTopLeft.Controls.Add(this.lblRecord_date);
            this.pnlTopLeft.Controls.Add(this.paBox);
            this.pnlTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Size = new System.Drawing.Size(958, 39);
            this.pnlTopLeft.TabIndex = 1;
            // 
            // dtpRecord_date
            // 
            this.dtpRecord_date.IsJapanYearType = true;
            this.dtpRecord_date.Location = new System.Drawing.Point(97, 5);
            this.dtpRecord_date.Name = "dtpRecord_date";
            this.dtpRecord_date.Size = new System.Drawing.Size(145, 20);
            this.dtpRecord_date.TabIndex = 1;
            this.dtpRecord_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpRecord_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpRecord_date_DataValidating);
            // 
            // lblRecord_date
            // 
            this.lblRecord_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblRecord_date.EdgeRounding = false;
            this.lblRecord_date.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord_date.Location = new System.Drawing.Point(3, 5);
            this.lblRecord_date.Name = "lblRecord_date";
            this.lblRecord_date.Size = new System.Drawing.Size(93, 20);
            this.lblRecord_date.TabIndex = 0;
            this.lblRecord_date.Text = "記録日付";
            this.lblRecord_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paBox
            // 
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.paBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.paBox.Location = new System.Drawing.Point(252, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(706, 39);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnOutPatient);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnOpen);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 556);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(960, 34);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnOutPatient
            // 
            this.btnOutPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOutPatient.ImageIndex = 2;
            this.btnOutPatient.ImageList = this.ImageList;
            this.btnOutPatient.Location = new System.Drawing.Point(252, 2);
            this.btnOutPatient.Name = "btnOutPatient";
            this.btnOutPatient.Size = new System.Drawing.Size(136, 29);
            this.btnOutPatient.TabIndex = 3;
            this.btnOutPatient.Text = "入院内訳照会";
            this.btnOutPatient.Click += new System.EventHandler(this.btnOutPatient_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.ImageIndex = 1;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Location = new System.Drawing.Point(109, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(142, 29);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "看護経過記録出力";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.ImageIndex = 0;
            this.btnOpen.ImageList = this.ImageList;
            this.btnOpen.Location = new System.Drawing.Point(1, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(107, 29);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "経過記録登録";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(714, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(244, 32);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFill.Controls.Add(this.grdNUR9001);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 45);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(960, 511);
            this.pnlFill.TabIndex = 2;
            // 
            // grdNUR9001
            // 
            this.grdNUR9001.AddedHeaderLine = 1;
            this.grdNUR9001.ApplyAutoHeight = true;
            this.grdNUR9001.ApplyPaintEventToAllColumn = true;
            this.grdNUR9001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell11,
            this.xEditGridCell10,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14});
            this.grdNUR9001.ColPerLine = 7;
            this.grdNUR9001.Cols = 8;
            this.grdNUR9001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR9001.FixedCols = 1;
            this.grdNUR9001.FixedRows = 2;
            this.grdNUR9001.HeaderHeights.Add(22);
            this.grdNUR9001.HeaderHeights.Add(0);
            this.grdNUR9001.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdNUR9001.Location = new System.Drawing.Point(0, 0);
            this.grdNUR9001.Name = "grdNUR9001";
            this.grdNUR9001.QuerySQL = resources.GetString("grdNUR9001.QuerySQL");
            this.grdNUR9001.ReadOnly = true;
            this.grdNUR9001.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdNUR9001.RowHeaderVisible = true;
            this.grdNUR9001.Rows = 3;
            this.grdNUR9001.Size = new System.Drawing.Size(958, 509);
            this.grdNUR9001.TabIndex = 0;
            this.grdNUR9001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR9001_QueryEnd);
            this.grdNUR9001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR9001_QueryStarting);
            this.grdNUR9001.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR9001_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pknur9001";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "경과기록키";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkinp1001";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "입원키";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 9;
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "환자번호";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "record_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 112;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.HeaderText = "記録日付";
            this.xEditGridCell4.IsJapanYearType = true;
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.Row = 1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "record_time";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell5.CellWidth = 52;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.HeaderText = "記録時間";
            this.xEditGridCell5.InvalidDateIsStringEmpty = false;
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.Mask = "HH:MI";
            this.xEditGridCell5.Row = 1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 1;
            this.xEditGridCell6.CellName = "soap_gubun";
            this.xEditGridCell6.CellWidth = 33;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "区分";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.RowSpan = 2;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 200;
            this.xEditGridCell7.CellName = "record_contents";
            this.xEditGridCell7.CellWidth = 520;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "内容";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 2;
            this.xEditGridCell8.CellName = "nur_plan_pro";
            this.xEditGridCell8.CellWidth = 45;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "問題点";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 8;
            this.xEditGridCell9.CellName = "record_user";
            this.xEditGridCell9.Col = 6;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.HeaderText = "記録者";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.Row = 1;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 30;
            this.xEditGridCell11.CellName = "recored_user_name";
            this.xEditGridCell11.CellWidth = 81;
            this.xEditGridCell11.Col = 7;
            this.xEditGridCell11.HeaderText = "記録者名";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.Row = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 1;
            this.xEditGridCell10.CellName = "vald";
            this.xEditGridCell10.CellWidth = 50;
            this.xEditGridCell10.CheckedValue = "N";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell10.HeaderText = "取消";
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.UnCheckedValue = "Y";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "dc_yn";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "dc_yn";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "dc_user";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "dc_user";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "mayak_use_yn";
            this.xEditGridCell14.CellWidth = 32;
            this.xEditGridCell14.Col = 5;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "麻薬";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 1;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "記録日付";
            this.xGridHeader1.HeaderWidth = 112;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 6;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader2.HeaderText = "記録者";
            // 
            // layWorkTime
            // 
            this.layWorkTime.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layWorkTime.QuerySQL = "SELECT CODE         WORK_TIME_GUUBUN\r\n     , CODE_NAME    WORK_TIME\r\n  FROM NUR01" +
                "02 \r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = \'WORK_TIME\'";
            this.layWorkTime.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layWorkTime_QueryStarting);
            this.layWorkTime.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layWorkTime_QueryEnd);
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "time_gubun";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "time";
            // 
            // NUR9001Q00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR9001Q00";
            this.Load += new System.EventHandler(this.NUR9001Q00_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTopLeft.ResumeLayout(false);
            this.pnlTopLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR9001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWorkTime)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen Load
        private string mHospCode = "";
       // private string mMessageGubun = "";
        private bool mRowCountFlag = true;  //기록이 없을 경우 true/false 구분

		private void NUR9001Q00_Load(object sender, System.EventArgs e)
		{
            this.mHospCode = EnvironInfo.HospCode;
			//화면사이즈 조정
			if(this.OpenStyle == ScreenOpenStyle.PopUpFixed || this.OpenStyle == ScreenOpenStyle.PopUpSizable)
			{
				Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
				this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);
			}

			/* 기록일자 디폴트 현재 일자 셋팅 */
            this.dtpRecord_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            /*근무시간 기준을 조회해온다*/
            this.layWorkTime.QueryLayout(false);

           // mMessageGubun = "1";
			if (this.OpenParam != null)
            {
                //if (((XScreen)this.Opener).Name == "NUR1020Q00")
                //    mMessageGubun = "2";

				this.dtpRecord_date.SetDataValue(this.OpenParam["record_date"].ToString());
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
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{			
			//Set Current Grid
			this.CurrMSLayout = this.grdNUR9001;
			this.CurrMQLayout = this.grdNUR9001;

			this.paBox.Focus();
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

		#region 등록번호를 입력을 했을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() != "")
			{
                if (!grdNUR9001.QueryLayout(false))
				{
					XMessageBox.Show(Service.ErrFullMsg);
					return;
				}
			}
		}

        /* Null값 또는 잘못된 환자번호 입력시(2011.11.25 woo)*/
        private void paBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            this.grdNUR9001.Reset();
            return;
        }

		#endregion

		#region 경과기록등록창을 오픈시킨다.
		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() != "")
			{
				//string record_date = string.Empty;
				string sysid       = EnvironInfo.CurrSystemID;
				string screen      = this.ScreenID;
				string bunho       = this.paBox.BunHo.ToString();

                /* NUR9001Q00(看護経過記録)(해당화면)에서 NUR9001U00(看護経過記録登録)을 열 때, 
                 * NUR9001Q00에서 선택한 Row의 날짜를 파라미터로 넣어 날짜 파라미터추가부분 주석처리, 
                 * NUR9001U00에서 현재날짜를 넣어주게 수정 (2011.11.30 woo) */
                //if(this.grdNUR9001.CurrentRowNumber >= 0)
                //{
                //    if(this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "record_date").ToString() != "")
                //    {
                //        record_date = this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "record_date").ToString();
                //    }
                //    else
                //    {
                //        record_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                //    }
                //}
                //else
                //{
                //    record_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                //}
   
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("NURI", "NUR9001U00");
   
				if (aScreen == null)
				{              
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sysid", sysid);
					openParams.Add( "screen", screen);
					openParams.Add( "bunho", bunho);
					//openParams.Add( "record_date", record_date);

					XScreen.OpenScreenWithParam(this, "NURI", "NUR9001U00", IHIS.Framework.ScreenOpenStyle.PopUpFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

		#region 팝업화면에서 데이터 받기
		public override object Command(string command, CommonItemCollection commandParam)
		{
			if (command == "FLAG")
			{
				if(commandParam["FLAG"].ToString() == "Y")
				{
                    if (!grdNUR9001.QueryLayout(false))
					{
						XMessageBox.Show(Service.ErrFullMsg.ToString());
					}
				}
			}

			if (command == "toiwon_date")
			{
                if (commandParam["toiwon_date"].ToString() != "")
                {
                    this.dtpRecord_date.SetEditValue(commandParam["toiwon_date"].ToString());
                    this.dtpRecord_date.AcceptData();
                }
                else
                {
                    this.dtpRecord_date.SetEditValue(EnvironInfo.GetSysDate());
                    this.dtpRecord_date.AcceptData();                
                }

                if (!grdNUR9001.QueryLayout(false))
                {
                    XMessageBox.Show(Service.ErrFullMsg.ToString());
                }
			}
			return base.Command (command, commandParam);
		}
		#endregion

		#region 조회버튼을 클릭을 했을 때
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					e.IsBaseCall = false;

					if(this.paBox.BunHo.ToString() != "")
					{
                        if (!grdNUR9001.QueryLayout(false))
						{
							XMessageBox.Show(Service.ErrFullMsg);
							return;
						}
					}
					break;

				case FunctionType.Reset:
					break;

				default:
					break;
			}
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 한 후의 이벤트
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Reset:
					/* 기록일자 디폴트 현재 일자 셋팅 */
                    this.dtpRecord_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					this.dtpRecord_date.AcceptData();
					break;
				default:
					break;
			}
		}
		#endregion

		#region 간호경과기록출력버튼을 클릭을 했을 때
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() != "")
			{
				string sysid       = EnvironInfo.CurrSystemID;
				string screen      = this.ScreenID;
				string bunho       = this.paBox.BunHo.ToString();
				
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("NURI", "NUR9001R00");
   
				if (aScreen == null)
				{              
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sysid", sysid);
					openParams.Add( "screen", screen);
					openParams.Add( "bunho", bunho);
		
					XScreen.OpenScreenWithParam(this, "NURI", "NUR9001R00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentMiddleCenter,  openParams);
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

		#region 기록시간에 따라 레드 컬러표시
		private void grdNUR9001_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{            
            if(this.layWorkTime.RowCount < 2)
                return;

            string[] temp_time = null;
            
            //일근
            if (!TypeCheck.IsNull(times1))
            {
                temp_time = times1.Split('-');
                if (temp_time.Length == 2)
                {
                    if (int.Parse(e.DataRow["record_time"].ToString()) >= Convert.ToInt32(temp_time[0])
                        && int.Parse(e.DataRow["record_time"].ToString()) < Convert.ToInt32(temp_time[1]))
                    {
                        e.ForeColor = Color.Black;
                        if (e.DataRow["mayak_use_yn"].ToString() == "Y")
                        {
                            e.ForeColor = Color.Red;
                        }
                    }
                }
            }

            //준야
            if (!TypeCheck.IsNull(times2))
            {
                temp_time = times2.Split('-');
                if (temp_time.Length == 2)
                {
                    if (int.Parse(e.DataRow["record_time"].ToString()) >= Convert.ToInt32(temp_time[0])
                        && int.Parse(e.DataRow["record_time"].ToString()) < Convert.ToInt32(temp_time[1]))
                    {
                        e.ForeColor = Color.Blue;
                        if (e.DataRow["mayak_use_yn"].ToString() == "Y")
                        {
                            e.ForeColor = Color.Red;
                        }
                    }
                }
            }

            //심야
            if (!TypeCheck.IsNull(times3))
            {
                temp_time = times3.Split('-');
                if (temp_time.Length == 2)
                {
                    if ((int.Parse(e.DataRow["record_time"].ToString()) >= Convert.ToInt32(temp_time[0]) && int.Parse(e.DataRow["record_time"].ToString()) <= 2400)
                      || (int.Parse(e.DataRow["record_time"].ToString()) <= Convert.ToInt32(temp_time[1]) && int.Parse(e.DataRow["record_time"].ToString()) >= 0))
                    {
                        e.ForeColor = Color.Red;
                        if (e.DataRow["mayak_use_yn"].ToString() == "Y")
                        {
                            e.ForeColor = Color.Black;
                        }
                    }
                }
            }
			if(e.DataRow["dc_yn"].ToString() == "Y")
			{
				e.DrawMiddleLine = true;
			}
		}
		#endregion

		#region 해당 환자의 입원내역을 조회한다.
		private void btnOutPatient_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() != "")
			{
				string sysid       = EnvironInfo.CurrSystemID;
				string screen      = this.ScreenID;
				string bunho       = this.paBox.BunHo.ToString();
				
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("NURI", "NUR9001Q01");
   
				if (aScreen == null)
				{              
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sysid", sysid);
					openParams.Add( "screen", screen);
					openParams.Add( "bunho", bunho);
		
					XScreen.OpenScreenWithParam(this, "NURI", "NUR9001Q01", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentMiddleCenter,  openParams);
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

        #region grdNUR9001 쿼리 바인드 변수 설정 2010.05. 河中
        private void grdNUR9001_QueryStarting(object sender, CancelEventArgs e)
        {
            string bunho = paBox.BunHo;
            string record_date = dtpRecord_date.GetDataValue();
            mRowCountFlag = true;   //조회 건수를 true로 해준다.

            /* 환자의 입원일자를 조회한다. */
            object retVal = null;
            string cmdText = @"SELECT IPWON_DATE IPWON_DATE
                                 FROM VW_OCS_INP1001_02
                                WHERE HOSP_CODE = :f_hosp_code 
                                  AND BUNHO     = :f_bunho
                                  AND PKINP1001 = (SELECT MAX(PKINP1001)
                                                     FROM VW_OCS_INP1001_02
                                                    WHERE HOSP_CODE   = :f_hosp_code
                                                      AND BUNHO       = :f_bunho
                                                      AND IPWON_DATE <= :f_record_date
                                                      AND NVL(CANCEL_YN, 'N') = 'N')
                                  AND NVL(CANCEL_YN, 'N') = 'N'";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", mHospCode);
            bindVars.Add("f_bunho", bunho);
            bindVars.Add("f_record_date", record_date);
            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (!TypeCheck.IsNull(retVal))
            {
                
                grdNUR9001.SetBindVarValue("f_ipwon_date", retVal.ToString().Replace("/", "").Replace("-", "").Substring(0, 8));
            }
            else
            {
                mRowCountFlag = false;  //조회 건수가 없다면 false
                /*입원일자 로드에러.*/
                //if (mMessageGubun == "1")
                //{
                //    XMessageBox.Show("入院中の患者ではありません。", "注意", MessageBoxIcon.Hand);
                //}
                //else
                //{
                    XMessageBox.Show("該当日付ではまだ入院していません。", "注意", MessageBoxIcon.Hand);

               //}
                grdNUR9001.SetBindVarValue("f_ipwon_date", "");
            }
            grdNUR9001.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR9001.SetBindVarValue("f_bunho", bunho);
            grdNUR9001.SetBindVarValue("f_record_date", record_date.Replace("/", "").Replace("-", "").Substring(0, 8));
        }


        /* 쿼리 종료 시 해당날짜에 입원중인 환자에 경과기록이 없다면 경과기록이 없다는 알림창 띄우기. (2011.11.25 woo)*/
        private void grdNUR9001_QueryEnd(object sender, QueryEndEventArgs e)
        {
            SetMsg("");
            if (mRowCountFlag && this.grdNUR9001.RowCount == 0)
            {
                XMessageBox.Show("看護経過記録がありません。", "経過記録");
                SetMsg("看護経過記録がありません。", MsgType.Normal);
            }
            else
            {
                this.grdNUR9001.SetTopRow(this.grdNUR9001.RowCount - 1 );
                this.grdNUR9001.SetFocusToItem(this.grdNUR9001.RowCount - 1, 0);
            }
        }

        #endregion

        #region layWorkTime_QueryStarting
        private void layWorkTime_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layWorkTime.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        #region layWorkTime_QueryEnd
        private void layWorkTime_QueryEnd(object sender, QueryEndEventArgs e)
        {
            for (int i = 0; i < this.layWorkTime.RowCount; i++)
            {
                if (this.layWorkTime.GetItemString(i, "time_gubun").Equals("1"))
                {
                    times1 = this.layWorkTime.GetItemString(i, "time");
                }
                else if (this.layWorkTime.GetItemString(i, "time_gubun").Equals("2"))
                {
                    times2 = this.layWorkTime.GetItemString(i, "time");
                }
                else if (this.layWorkTime.GetItemString(i, "time_gubun").Equals("3"))
                {
                    times3 = this.layWorkTime.GetItemString(i, "time");
                }
            }
        }
        #endregion


        #region 기록날짜 변경 시 기록조회 (2011.11.25 woo)
        private void dtpRecord_date_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!grdNUR9001.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }
        #endregion

    }
}

