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
	/// NUR2004U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR2004U01 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private Hashtable mBedRadio = new Hashtable();
		private string FindName = string.Empty;
		//private int mPkinp1001 = 0;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XDatePicker dtpJunipDate;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		//private IHIS.Framework.DataServiceSIMO dsvGetJunip;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XButton btnConfirm;
		private IHIS.Framework.XButton xButton1;
		private System.Windows.Forms.Label label26;
		private IHIS.Framework.XBuseoCombo cboHoDong;
		private IHIS.Framework.XEditGrid grdInp2004;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		//private IHIS.Framework.DataServiceMISO dsvConfirmInp2004;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XFindWorker fwBed_no;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private System.ComponentModel.IContainer components = null;
        private SingleLayout layCommon;
        private SingleLayoutItem singleLayoutItem18;
        private SingleLayoutItem singleLayoutItem19;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XGridHeader xGridHeader1;
        private FindColumnInfo findColumnInfo2;
        #endregion

		#region 생성자
		public NUR2004U01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR2004U01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cboHoDong = new IHIS.Framework.XBuseoCombo();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpJunipDate = new IHIS.Framework.XDatePicker();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.xButton1 = new IHIS.Framework.XButton();
            this.grdInp2004 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.fwBed_no = new IHIS.Framework.XFindWorker();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInp2004)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.cboHoDong);
            this.xPanel1.Controls.Add(this.label26);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Controls.Add(this.dtpJunipDate);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(829, 42);
            this.xPanel1.TabIndex = 0;
            // 
            // cboHoDong
            // 
            this.cboHoDong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHoDong.ItemHeight = 13;
            this.cboHoDong.Location = new System.Drawing.Point(39, 11);
            this.cboHoDong.MaxDropDownItems = 40;
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.Size = new System.Drawing.Size(120, 21);
            this.cboHoDong.TabIndex = 83;
            this.cboHoDong.SelectionChangeCommitted += new System.EventHandler(this.cboHoDong_SelectionChangeCommitted);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label26.ForeColor = System.Drawing.Color.Orange;
            this.label26.Location = new System.Drawing.Point(3, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 22);
            this.label26.TabIndex = 82;
            this.label26.Text = "病棟";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(164, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "転入日付";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpJunipDate
            // 
            this.dtpJunipDate.IsJapanYearType = true;
            this.dtpJunipDate.Location = new System.Drawing.Point(238, 12);
            this.dtpJunipDate.Name = "dtpJunipDate";
            this.dtpJunipDate.Size = new System.Drawing.Size(107, 20);
            this.dtpJunipDate.TabIndex = 0;
            this.dtpJunipDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpJunipDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJunipDate_DataValidating);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnConfirm);
            this.xPanel2.Controls.Add(this.xButton1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 416);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.xPanel2.Size = new System.Drawing.Size(829, 38);
            this.xPanel2.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.Location = new System.Drawing.Point(680, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(84, 32);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "転入確認";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // xButton1
            // 
            this.xButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButton1.Image = ((System.Drawing.Image)(resources.GetObject("xButton1.Image")));
            this.xButton1.Location = new System.Drawing.Point(764, 3);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(62, 32);
            this.xButton1.TabIndex = 1;
            this.xButton1.Text = "閉じる";
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // grdInp2004
            // 
            this.grdInp2004.AddedHeaderLine = 1;
            this.grdInp2004.ApplyPaintEventToAllColumn = true;
            this.grdInp2004.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell10,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell9,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell6,
            this.xEditGridCell5,
            this.xEditGridCell8,
            this.xEditGridCell7});
            this.grdInp2004.ColPerLine = 12;
            this.grdInp2004.Cols = 13;
            this.grdInp2004.DefaultHeight = 26;
            this.grdInp2004.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInp2004.FixedCols = 1;
            this.grdInp2004.FixedRows = 2;
            this.grdInp2004.HeaderHeights.Add(21);
            this.grdInp2004.HeaderHeights.Add(21);
            this.grdInp2004.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdInp2004.Location = new System.Drawing.Point(0, 42);
            this.grdInp2004.Name = "grdInp2004";
            this.grdInp2004.QuerySQL = resources.GetString("grdInp2004.QuerySQL");
            this.grdInp2004.RowHeaderVisible = true;
            this.grdInp2004.Rows = 3;
            this.grdInp2004.RowStateCheckOnPaint = false;
            this.grdInp2004.Size = new System.Drawing.Size(829, 374);
            this.grdInp2004.TabIndex = 2;
            this.grdInp2004.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdInp2004_GridColumnProtectModify);
            this.grdInp2004.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdInp2004_GridCellPainting);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "fromto_gubun";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "患者番号";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "患者氏名";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.RowSpan = 2;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "order_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 100;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "申請日付";
            this.xEditGridCell11.IsJapanYearType = true;
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "gwa";
            this.xEditGridCell12.Col = 5;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "診療科";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.RowSpan = 2;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "doctor";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "doctor";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "doctor_name";
            this.xEditGridCell14.CellWidth = 94;
            this.xEditGridCell14.Col = 6;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "主治医";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.RowSpan = 2;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "ho_dong";
            this.xEditGridCell3.CellWidth = 56;
            this.xEditGridCell3.Col = 7;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "病棟";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.RowSpan = 2;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "ho_code";
            this.xEditGridCell4.CellWidth = 52;
            this.xEditGridCell4.Col = 8;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "病室";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 2;
            this.xEditGridCell9.CellName = "bed_no";
            this.xEditGridCell9.CellWidth = 43;
            this.xEditGridCell9.Col = 9;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.FindWorker = this.fwBed_no;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "病床";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.RowSpan = 2;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwBed_no
            // 
            this.fwBed_no.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo2});
            this.fwBed_no.FormText = "稼動病床";
            this.fwBed_no.InputSQL = resources.GetString("fwBed_no.InputSQL");
            this.fwBed_no.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwBed_no_QueryStarting);
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "bed_no";
            this.findColumnInfo2.HeaderText = "病床";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "kaikei_hodong";
            this.xEditGridCell15.CellWidth = 41;
            this.xEditGridCell15.Col = 10;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "病棟";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.Row = 1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "kaikei_hocode";
            this.xEditGridCell16.CellWidth = 41;
            this.xEditGridCell16.Col = 11;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "病室";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.Row = 1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "confirm_user";
            this.xEditGridCell6.CellWidth = 85;
            this.xEditGridCell6.Col = 12;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "確認者";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "fkinp1001";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "trans_cnt";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell7.ApplyPaintingEvent = true;
            this.xEditGridCell7.CellName = "confirm_yn";
            this.xEditGridCell7.CellWidth = 30;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell7.RowSpan = 2;
            this.xEditGridCell7.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 10;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "扱い";
            this.xGridHeader1.HeaderWidth = 41;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "bed_no";
            this.findColumnInfo1.HeaderText = "病床";
            // 
            // layCommon
            // 
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem18,
            this.singleLayoutItem19});
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "retVal1";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "retVal2";
            // 
            // NUR2004U01
            // 
            this.Controls.Add(this.grdInp2004);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "NUR2004U01";
            this.Size = new System.Drawing.Size(829, 454);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInp2004)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 스크린 로드
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
            if (this.OpenParam != null)
            {
                this.cboHoDong.SetEditValue(this.OpenParam["hodong"].ToString());//
            }
            else
            {
                if (UserInfo.HoDong != "")
                    this.cboHoDong.SetDataValue(UserInfo.HoDong);
                else
                    this.cboHoDong.SetDataValue("1");

            }
            this.dtpJunipDate.SetDataValue(IHIS.Framework.EnvironInfo.GetSysDate());

			//전입된 데이타로드
			this.GetJunip();
		}

		private void GetJunip()
        {
            this.grdInp2004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdInp2004.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());

            this.grdInp2004.SetBindVarValue("f_order_date", this.dtpJunipDate.GetDataValue());
            if (this.grdInp2004.QueryLayout(false))
			{
	            //cell event추가 및 이미지 설정
				this.CellMouseEvent(1,this.grdInp2004.RowCount);
			}
		}
		private void CellMouseEvent(int startRow, int endRow)
		{
			for(int i=startRow; i< endRow; i++)
			{
				AddMouseEvent(i);
			}
		}
		private void AddMouseEvent(int row)
		{
			//전입될 대상자만 클릭이벤트 추가
			if (this.grdInp2004.GetItemString(row,"fromto_gubun") == "TO")
			{
				XCell cell = null;
				cell = this.grdInp2004[row+grdInp2004.HeaderHeights.Count,1];
				cell.Image = this.ImageList.Images[0];
				cell.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;

				cell.MouseDown  += new MouseEventHandler(OnCellMouseDown);

				//to 등록번호에 변경이미지 처리
                cell = this.grdInp2004[row + grdInp2004.HeaderHeights.Count, 2];
				cell.Image = this.ImageList.Images[2];
				cell.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;

			}

		}
		private void OnCellMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left )
			{
				IHIS.Framework.XCell ac = (IHIS.Framework.XCell)sender;
				string chk = this.grdInp2004.GetItemString(ac.Row -2, ac.CellName);
				string confirm_user = this.grdInp2004.GetItemString(ac.Row -2, "confirm_user");
				
				//입원전입확인이 안되건
				if (confirm_user == "")
				{				
					if (chk == "Y")
					{
						ac.Image = this.ImageList.Images[0];
						ac.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
						this.grdInp2004.SetItemValue(ac.Row-2, ac.CellName,"N");
					}
					else
					{
						ac.Image = this.ImageList.Images[1];
						ac.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
						this.grdInp2004.SetItemValue(ac.Row-2, ac.CellName,"Y");
					}
				}
				else
				{
					
				}
			}
			
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
				case "bunho":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다. 확인바랍니다."
						: "在院中の患者ではありません。 ご確認ください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				default:
					break;
			}
		}
		#endregion

		#region 전입확인

        string modifyBunho = "";

		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
            for(int i = 0; i < this.grdInp2004.RowCount; i++)
            {
                if ((this.grdInp2004.GetItemString(i, "confirm_user") == "") && (this.grdInp2004.GetItemString(i, "confirm_yn") == "Y"))
                {
                    if (this.grdInp2004.GetItemString(i, "fromto_gubun") == "TO")
                    {
                        try
                        {
                            Service.BeginTransaction();

                            Hashtable param = new Hashtable();

                            param.Add("fkinp1001", this.grdInp2004.GetItemValue(i, "fkinp1001"));
                            param.Add("trans_cnt", this.grdInp2004.GetItemValue(i, "trans_cnt"));
                            param.Add("bunho", this.grdInp2004.GetItemString(i-1, "bunho"));
                            param.Add("from_gwa", this.grdInp2004.GetItemString(i - 1, "gwa") );
                            param.Add("to_gwa", this.grdInp2004.GetItemString(i, "gwa"));
                            param.Add("from_doctor", this.grdInp2004.GetItemString(i - 1, "doctor"));
                            param.Add("to_doctor", this.grdInp2004.GetItemString(i, "doctor"));
                            param.Add("from_ho_dong", this.grdInp2004.GetItemString(i - 1, "ho_dong"));
                            param.Add("to_ho_dong", this.grdInp2004.GetItemString(i, "ho_dong"));
                            param.Add("from_ho_code", this.grdInp2004.GetItemString(i - 1, "ho_code"));
                            param.Add("to_ho_code", this.grdInp2004.GetItemString(i, "ho_code"));
                            param.Add("from_bed_no", this.grdInp2004.GetItemString(i-1, "bed_no"));
                            param.Add("to_bed_no", this.grdInp2004.GetItemString(i, "bed_no"));
                            param.Add("from_kaikei_hodong", this.grdInp2004.GetItemString(i - 1, "kaikei_hodong"));
                            param.Add("to_kaikei_hodong", this.grdInp2004.GetItemString(i, "kaikei_hodong"));
                            param.Add("from_kaikei_hocode",this.grdInp2004.GetItemString(i - 1, "kaikei_hocode") );
                            param.Add("to_kaikei_hocode", this.grdInp2004.GetItemString(i, "kaikei_hocode"));

                            int rtn_result = GetConfirmData(param);

                            if (rtn_result == 1)
                            {
                                return;
                            }
                            
                            Service.CommitTransaction();


                            ArrayList inputList = new ArrayList();
                            ArrayList outputList = new ArrayList();

                            inputList.Add(EnvironInfo.HospCode);
                            inputList.Add(this.grdInp2004.GetItemString(i, "ho_dong"));

                            Service.ExecuteProcedure("PR_BAS_BAS0250_REFRESH", inputList, outputList);
                                                        
                            //会計転送対象か確認

                            string from_kaikei_hodong, from_kaikei_hocode, to_kaikei_hodong, to_kaikei_hocode;

                            from_kaikei_hodong = grdInp2004.GetItemString(i - 1, "kaikei_hodong");
                            from_kaikei_hocode = grdInp2004.GetItemString(i - 1, "kaikei_hocode");
                            to_kaikei_hodong = grdInp2004.GetItemString(i, "kaikei_hodong");
                            to_kaikei_hocode = grdInp2004.GetItemString(i, "kaikei_hocode");


                            if (from_kaikei_hodong.Equals(to_kaikei_hodong) && from_kaikei_hocode.Equals(to_kaikei_hocode))
                            {
                                return;
                            }
                            else
                            {
                                string if_key = SakuraChangeTrans("2", "I", grdInp2004.GetItemValue(i-1, "bunho").ToString()
                                                                  , dtpJunipDate.GetDataValue()
                                                                  , to_kaikei_hodong
                                                                  , to_kaikei_hocode
                                                                  , grdInp2004.GetItemString(i, "bed_no")
                                                                  , grdInp2004.GetItemString(i, "gwa")
                                                                  , grdInp2004.GetItemString(i, "doctor")
                                                                  , grdInp2004.GetItemString(i, "fkinp1001")
                                                                  , UserInfo.UserID, "");

                                if (!if_key.Equals(string.Empty))
                                {
                                    IFServiceCall(if_key);
                                }
                            }
                        }
                        catch(Exception xe)
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show(xe.Message, "エラー", MessageBoxIcon.Error);
                            return;
                        }
                    }

                }
            }
            //if (rtn_result == 0)
            //{
                XMessageBox.Show("完了しました。", "完了", MessageBoxIcon.Information);
                //재조회
                this.GetJunip();
            //}
		}
        //20100513 edit end
        #endregion 전입확인

        #region SakuraChangeTrans
        /// <summary>
        /// 転科転室転送情報作成(IFS3011)
        /// PR_IFS_MAKE_IPWON_HISTORY 사용
        /// </summary>
        /// <param name="data_gubun">1：入院, 2：転入, 4：退院</param>
        /// <param name="proc_gubun">I：登録, U：修正, D：削除</param>
        /// <param name="bunho">患者番号</param>
        /// <param name="data_date">データ日付</param>
        /// <param name="ho_dong">棟コード</param>
        /// <param name="ho_code">室コード</param>
        /// <param name="bed_no">床コード</param>
        /// <param name="gwa">科コード</param>
        /// <param name="doctor">医師コード</param>
        /// <param name="pkinp1001">PKINP1001</param>
        /// <param name="userid">登録者ID</param>
        /// <param name="toiwon_gubun">[""可] １：治癒、２：死亡、３：中止、４：他移、５：転医、６：転科、７：軽快、８：転棟、９：転室</param>

        private string SakuraChangeTrans(string data_gubun, string proc_gubun, string bunho, string data_date, string ho_dong, string ho_code, string bed_no, string gwa, string doctor, string pkinp1001, string userid, string toiwon_gubun)
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(proc_gubun);
            inputList.Add(bunho);
            inputList.Add(data_date);
            inputList.Add(ho_dong);
            inputList.Add(ho_code);
            inputList.Add(""); //inputList.Add(bed_no); ベッド番号は会計に必要ない。(20130621)
            inputList.Add(gwa);
            inputList.Add(doctor);
            inputList.Add(pkinp1001);
            inputList.Add(userid);
            inputList.Add(data_gubun);
            inputList.Add(toiwon_gubun);

            if (!Service.ExecuteProcedure("PR_IFS_MAKE_IPWON_HISTORY", inputList, outputList))
            {
                XMessageBox.Show("SAKURAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg,
                                  "処理失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return string.Empty;
            }
            else
            {
                if (outputList[1].ToString() != "0")
                {
                    XMessageBox.Show("SAKURAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg,
                                     "処理失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                return outputList[0].ToString();
            }
        }

        private bool IFServiceCall(string If_key)
        {

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText = "00231" + If_key;

            //XMessageBox.Show(msgText);

            int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);

            if (ret == -1)
            {
                XMessageBox.Show("SAKURAへのデータ転送に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg,
                                 "転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            XMessageBox.Show("SAKURAへのデータ転送が完了しました。",
                             "転送完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        #endregion

        #region 닫기
        private void xButton1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region 전입확인된 건 protect
		private void grdInp2004_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
            if (e.DataRow["fromto_gubun"].ToString() == "TO")
            {
                if (e.DataRow["confirm_user"].ToString() != "")
                {
                    if (e.ColName == "confirm_yn")
                        e.Protect = true;
                    else
                        e.Protect = false;
                }
            }
            else
            {
                e.Protect = true;
            }
		}
		#endregion

		private void dtpJunipDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
//			//전입된 데이타로드 => 과거일자로 전동확인되면,, 방값을 어떻게 새로 발생?
            this.GetJunip();
        }

        #region ConfirmTrans
        private void ConfirmTrans(string param_userId, int param_trans_cnt, string param_bed_no, string param_pkinp1001, int param_i_trans_cnt)
        {
            BindVarCollection bindVar = new BindVarCollection();
            try
            {
                string strSql = @"UPDATE INP2004
                                      SET UPD_DATE  = SYSDATE
                                         ,UPD_ID    = :f_user_id
                                         ,TRANS_CNT = :f_trans_cnt
                                         ,TO_NURSE_CONFIRM_ID = :f_user_id
                                         ,TO_NURSE_CONFIRM_DATE = TO_CHAR(SYSDATE, 'YYYY/MM/DD')
                                         ,TO_NURSE_CONFIRM_TIME = TO_CHAR(SYSDATE, 'HH24MI')
                                         ,TO_BED_NO = DECODE(TRIM(:f_bed_no),NULL,TO_BED_NO,'',TO_BED_NO,:f_bed_no)
                                    WHERE HOSP_CODE = :f_hosp_code 
                                      AND FKINP1001 = :f_fkinp1001
                                      AND TRANS_CNT = :f_i_trans_cnt";

                bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVar.Add("f_user_id", param_userId);
                bindVar.Add("f_trans_cnt", param_trans_cnt.ToString());
                bindVar.Add("f_bed_no", param_bed_no);
                bindVar.Add("f_fkinp1001", param_pkinp1001);
                bindVar.Add("f_i_trans_cnt", param_i_trans_cnt.ToString());

                if (!Service.ExecuteNonQuery(strSql, bindVar))
                {
                    XMessageBox.Show("該当患者の転室情報確認時にエラーが発生しました。", "エラー", MessageBoxIcon.Error);
                    return;
                }

                bindVar.Clear();
            }
            catch (Exception x)
            {
                x.StackTrace.ToString();
            }

        }
        #endregion

        #region 전과전실 취소.주석처리
//        private void ConfirmTransCancel(string param_userId, string param_pkinp1001)
//        {
//            BindVarCollection bindVar = new BindVarCollection();
//            try
//            {
//                Service.BeginTransaction();
//                string strSql = @"UPDATE INP2004
//                                             SET UPD_DATE  = SYSDATE
//                                                ,UPD_ID    = :f_user_id
//                                                ,CANCEL_YN = 'Y'
//                                           WHERE FKINP1001 = :f_fkinp1001
//                                             AND TO_NURSE_CONFIRM_DATE IS NULL";

//                bindVar.Add("f_user_id", param_userId);
//                bindVar.Add("f_fkinp1001", param_pkinp1001);

//                Service.ExecuteNonQuery(strSql, bindVar);
//                Service.CommitTransaction();
//                bindVar.Clear();

//            }
//            catch (Exception x)
//            {
//                x.StackTrace.ToString();
//                Service.RollbackTransaction();
//                XMessageBox.Show("該当患者の転室情報確認時にエラーが発生しました。");
//            }
//        }
        #endregion

        #region GetConfirmData
        public int GetConfirmData(Hashtable param)
        {
            int rtnValue = 0;
            int o_max_trans = 0;
            int o_new_trans = 0;
            BindVarCollection confirmBindVar = new BindVarCollection();
            BindVarCollection sub_confirmBindVar = new BindVarCollection();
            string junpyo_date = string.Empty;
            /*입원정보 변경처리
              심사마감체크처리
               0.INP1001 정보변경처리
               2.이중유형에 대한 전실처리.->전과는 무시하고 전실은 이중유형에도 반영
               3.전실처리시(병동병실변경시) 영양실 네임카드 자동출력
               4.영양실 식이처방 병동병실정보수정
               5.특진여부 변경시 OCS2011반영
               6.고정차지 실행(반드시 영양실반영후 처리)
               7.슬립재처리(PR_INP_TRANS_SLIP)             */
            string strSql = @" SELECT A.FKINP1001
                                     ,A.BUNHO
                                     ,TO_CHAR(A.START_DATE, 'YYYY/MM/DD') START_DATE
                                     ,A.TRANS_TIME
                                     ,A.TO_GWA
                                     ,A.TO_DOCTOR
                                     ,A.TO_RESIDENT
                                     ,A.TO_HO_CODE1
                                     ,A.TO_HO_DONG1
                                     ,A.TO_HO_CODE2
                                     ,A.TO_HO_DONG2
                                     ,A.TRANS_GUBUN
                                     ,A.TO_BED_NO
                                     ,A.TO_BED_NO2
                                     ,A.FROM_HO_CODE1
                                     ,A.FROM_HO_DONG1
                                     ,A.FROM_BED_NO
                                     ,A.TO_HO_GRADE1
                                     ,A.TO_HO_GRADE2
                                     ,A.TO_KAIKEI_HODONG
                                     ,A.TO_KAIKEI_HOCODE
                                 FROM INP2004 A
                                WHERE A.HOSP_CODE = :f_hosp_code 
                                  AND A.FKINP1001 = :f_fkinp1001
                                  AND A.TRANS_CNT = :f_trans_cnt";

            confirmBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            confirmBindVar.Add("f_fkinp1001", param["fkinp1001"].ToString());
            confirmBindVar.Add("f_trans_cnt", param["trans_cnt"].ToString());
            DataTable dtConfirm = Service.ExecuteDataTable(strSql, confirmBindVar);

            if (Service.ErrCode != 0 || dtConfirm.Rows.Count == 0)
            {
                XMessageBox.Show("該当患者の転室情報の取り込み中にエラーが発生しました。", "エラー", MessageBoxIcon.Error);
                return 1;
            }

            //string o_fkinp1001 = dtConfirm.Rows[0]["fkinp1001"].ToString();
            //string o_bunho = dtConfirm.Rows[0]["bunho"].ToString();
            string o_order_date = dtConfirm.Rows[0]["start_date"].ToString();
            string o_trans_time = dtConfirm.Rows[0]["trans_time"].ToString();
            //string o_to_gwa = dtConfirm.Rows[0]["to_gwa"].ToString();
            //string o_to_doctor = dtConfirm.Rows[0]["to_doctor"].ToString();
            string o_to_resident = dtConfirm.Rows[0]["to_resident"].ToString();
            //string o_to_ho_code1 = dtConfirm.Rows[0]["to_ho_code1"].ToString();
            //string o_to_ho_dong1 = dtConfirm.Rows[0]["to_ho_dong1"].ToString();
            string o_to_ho_code2 = dtConfirm.Rows[0]["to_ho_code2"].ToString();
            string o_to_ho_dong2 = dtConfirm.Rows[0]["to_ho_dong2"].ToString();
            string o_trans_gubun = dtConfirm.Rows[0]["trans_gubun"].ToString();
            //string o_to_bed_no = dtConfirm.Rows[0]["to_bed_no"].ToString();
            string o_to_bed_no2 = dtConfirm.Rows[0]["to_bed_no2"].ToString();
            //string o_from_ho_code1 = dtConfirm.Rows[0]["from_ho_code1"].ToString();
            //string o_from_ho_dong1 = dtConfirm.Rows[0]["from_ho_dong1"].ToString();
            //string o_from_bed_no = dtConfirm.Rows[0]["from_bed_no"].ToString();
            string o_to_grade1 = dtConfirm.Rows[0]["to_ho_grade1"].ToString();
            string o_to_grade2 = dtConfirm.Rows[0]["to_ho_grade2"].ToString();
            //string o_to_kaikei_hodong = dtConfirm.Rows[0]["to_kaikei_hodong"].ToString();
            //string o_to_kaikei_hocode = dtConfirm.Rows[0]["to_kaikei_hocode"].ToString(); 
            string o_msg = string.Empty;

            /*0.퇴원예고체크*/
            string subStrSql = @"SELECT 'Y'
                                   FROM DUAL
                                  WHERE EXISTS (SELECT 'X'
                                                  FROM VW_OCS_INP1001_01 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code 
                                                   AND A.PKINP1001 = TO_NUMBER(:f_fkinp1001)
                                                   AND A.TOIWON_GOJI_YN = 'Y')";

            sub_confirmBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            sub_confirmBindVar.Add("f_fkinp1001", param["fkinp1001"].ToString());
            Object rtn_value = Service.ExecuteScalar(subStrSql, sub_confirmBindVar);
            sub_confirmBindVar.Clear();

            if (rtn_value != null && rtn_value.ToString().Equals("Y"))
            {
                XMessageBox.Show("退院予告が完了され転棟転室の確認ができません。", "エラー", MessageBoxIcon.Error);
                return 1;
            }

            /*확인베드로 변경*/
            //o_to_bed_no = param_bed_no;
            /*현재 확인된 베드체크*/
            subStrSql = @" SELECT 'Y'
                             FROM DUAL
                            WHERE EXISTS (SELECT 'X'
                                            FROM BAS0253 B
                                           WHERE B.HOSP_CODE = :f_hosp_code
                                             AND B.HO_DONG   = :f_to_ho_dong1
                                             AND B.HO_CODE   = :f_to_ho_code1
                                             AND B.BED_NO    = :f_to_bed_no
                                             AND B.BED_STATUS   IN ('00', '01')/*공베드,예약중 */
                                             AND TRUNC(SYSDATE) BETWEEN FROM_BED_DATE  AND NVL(TO_BED_DATE, TO_DATE('9999/12/31', 'YYYY/MM/DD')))";

            sub_confirmBindVar = new BindVarCollection();
            sub_confirmBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            sub_confirmBindVar.Add("f_to_ho_dong1", param["to_ho_dong"].ToString());
            sub_confirmBindVar.Add("f_to_ho_code1", param["to_ho_code"].ToString());
            sub_confirmBindVar.Add("f_to_bed_no", param["to_bed_no"].ToString());
            rtn_value = Service.ExecuteScalar(subStrSql, sub_confirmBindVar);
            sub_confirmBindVar.Clear();

            if (rtn_value != null && rtn_value.ToString().Length == 0)
            {
                XMessageBox.Show("該当患者の変更する病床が空床ではありません。ご確認ください。", "注意", MessageBoxIcon.Warning);
                return 1;

            }
            /*현재베드 상태 체크*/
            subStrSql = @"SELECT 'Y'
                            FROM DUAL
                            WHERE EXISTS ( SELECT 'X'
                                             FROM VW_OCS_INP1001_01 B
                                            WHERE B.HOSP_CODE     = :f_hosp_code
                                              AND B.HO_DONG1      = :f_to_ho_dong1
                                              AND B.HO_CODE1      = :f_to_ho_code1
                                              AND B.BED_NO        = :f_to_bed_no
                                              AND B.BUNHO        != TO_NUMBER(:f_bunho)
                                              AND :f_change_gubun = 'N')";

            sub_confirmBindVar = new BindVarCollection();
            sub_confirmBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            sub_confirmBindVar.Add("f_to_ho_dong1", param["to_ho_dong"].ToString());
            sub_confirmBindVar.Add("f_to_ho_code1", param["to_ho_code"].ToString());
            sub_confirmBindVar.Add("f_to_bed_no", param["to_bed_no"].ToString());
            sub_confirmBindVar.Add("f_bunho", param["bunho"].ToString());
            sub_confirmBindVar.Add("f_change_gubun", "N");

            rtn_value = Service.ExecuteScalar(subStrSql, sub_confirmBindVar);
            sub_confirmBindVar.Clear();

            if (rtn_value != null && rtn_value.ToString().CompareTo("Y") == 0)
            {
                XMessageBox.Show("変更先病床は既に割り当てられた病床です。ご確認ください。", "注意", MessageBoxIcon.Warning);

                modifyBunho = param["bunho"].ToString();
                CommonItemCollection cic = new CommonItemCollection();
                cic.Add("ho_dong", param["to_ho_dong"].ToString());
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "BASS", "BAS0250Q00", ScreenOpenStyle.ResponseFixed, cic);

                return 1;
            }

            /* 먼저 여러번 전동 신청후 전동확인을 나중에 하는 경우 trans_cnt를 마지막으로 재부여 */
            this.layCommon.QuerySQL = @"SELECT MAX(TRANS_CNT)         max_trans_cnt,
                                               MAX(TRANS_CNT) + 1     new_trans_cnt
                                            FROM INP2004
                                           WHERE HOSP_CODE = :f_hosp_code
                                             AND FKINP1001 = :f_fkinp1001";

            this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layCommon.SetBindVarValue("f_fkinp1001", param["fkinp1001"].ToString());

            if (this.layCommon.QueryLayout())
            {
                o_max_trans = Convert.ToInt32(this.layCommon.GetItemValue("retVal1"));
                o_new_trans = Convert.ToInt32(this.layCommon.GetItemValue("retVal2"));
            }

            if (o_max_trans.ToString() != param["trans_cnt"].ToString())
            {
                o_max_trans = o_new_trans;
            }

            /*INP2004 전과전실확인*/
            ConfirmTrans(UserInfo.UserID, o_max_trans, param["to_bed_no"].ToString(), param["fkinp1001"].ToString(), int.Parse(param["trans_cnt"].ToString()));
            /*INP2004 전과전실취소*/
            //ConfirmTransCancel(UserInfo.UserID, o_fkinp1001);

            junpyo_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
         
             
                    /*0.입원정보변경처리*/
            BindVarCollection innerBindVar = new BindVarCollection();

             string innerSql = @"UPDATE INP1001                       
                                   SET  UPD_ID     = :f_upd_id
                                       ,UPD_DATE   = SYSDATE
                                       ,GWA        = TRIM(:f_to_gwa)  
                                       ,DOCTOR     = :f_to_doctor     
                                       ,RESIDENT   = :f_to_resident   
                                       ,HO_CODE1   = :f_to_ho_code1 
                                       ,HO_DONG1   = :f_to_ho_dong1 
                                       ,BED_NO     = :f_to_bed_no   
                                       ,BED_NO2    = :f_to_bed_no2     
                                       ,HO_CODE2   = :f_to_ho_code2   
                                       ,HO_DONG2   = :f_to_ho_dong2   
                                       ,HO_GRADE1  = :f_to_ho_grade1 
                                       ,HO_GRADE2  = :f_to_ho_grade2
                                       ,KAIKEI_HODONG = :f_to_kaikei_hodong
                                       ,KAIKEI_HOCODE = :f_to_kaikei_hocode
                                  WHERE HOSP_CODE  = :f_hosp_code
                                    AND PKINP1001   = TO_NUMBER(:f_fkinp1001)";

            innerBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            innerBindVar.Add("f_to_gwa", param["to_gwa"].ToString());
            innerBindVar.Add("f_to_doctor", param["to_doctor"].ToString());
            innerBindVar.Add("f_to_resident", o_to_resident);
            innerBindVar.Add("f_to_ho_dong1", param["to_ho_dong"].ToString());
            innerBindVar.Add("f_to_ho_code1", param["to_ho_code"].ToString());
            innerBindVar.Add("f_to_bed_no", param["to_bed_no"].ToString());
            innerBindVar.Add("f_to_bed_no2", o_to_bed_no2);
            innerBindVar.Add("f_to_ho_code2", o_to_ho_code2);
            innerBindVar.Add("f_to_ho_dong2", o_to_ho_dong2);
            innerBindVar.Add("f_to_ho_grade1", o_to_grade1);
            innerBindVar.Add("f_to_ho_grade2", o_to_grade2);
            innerBindVar.Add("f_fkinp1001", param["fkinp1001"].ToString());
            innerBindVar.Add("f_upd_id", UserInfo.UserID);
            innerBindVar.Add("f_to_kaikei_hodong", param["to_kaikei_hodong"].ToString());
            innerBindVar.Add("f_to_kaikei_hocode", param["to_kaikei_hocode"].ToString());


            if (!Service.ExecuteNonQuery(innerSql, innerBindVar))
            {
                rtnValue = 1;
                throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }
            innerBindVar.Clear();
            //    }
            //}
            if (param["from_ho_dong"].Equals(param["to_ho_dong"]) && 
                param["from_ho_code"].Equals(param["to_ho_code"]))// NurseCall Interface 전과전실
            {
                rtnValue = 0;
            }


            /*2.이중유형에 대한 전실처리.->전과는 무시하고 전실은 이중유형에도 반영*/
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add('I');
            inputList.Add(UserInfo.UserID);
            inputList.Add(param["fkinp1001"].ToString());
            inputList.Add('0');
            inputList.Add(param["bunho"].ToString());
            inputList.Add(o_order_date);
            inputList.Add(o_trans_time);
            inputList.Add(param["to_ho_code"].ToString());
            inputList.Add(param["to_ho_dong"].ToString());
            inputList.Add(o_to_grade1);
            inputList.Add(o_to_ho_code2);
            inputList.Add(o_to_ho_dong2);
            inputList.Add(o_to_grade2);
            inputList.Add(param["to_bed_no"].ToString());
            //outputList.Add(o_flag);

            Service.ExecuteProcedure("PR_INP_UPDATE_JENGWA", inputList, outputList);

            if (outputList[0].ToString() != "0")
            {
                rtnValue = 1;
                throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }
            else
            {
                rtnValue = 0;
            }
            inputList.Clear();
            outputList.Clear();
            /*
                3.전실처리시(병동병실변경시) 영양실 네임카드 자동출력
                4.영양실 식이처방 병동병실정보수정
                5.특진여부 변경시 OCS2011반영
                6.고정차지 실행(반드시 영양실반영후 처리)
            */

            inputList.Add(param["fkinp1001"].ToString());
            inputList.Add(param["bunho"].ToString());
            inputList.Add(o_order_date.Substring(0, 10));
            inputList.Add(junpyo_date);
            inputList.Add(param["to_doctor"].ToString());
            inputList.Add(o_to_resident);
            inputList.Add(o_trans_gubun);
            inputList.Add(param["to_ho_dong"].ToString());
            inputList.Add(param["to_ho_code"].ToString());
            inputList.Add(UserInfo.UserID);
            //outputList.Add(o_msg);

            if (Service.ExecuteProcedure("PR_NUR_CHANGE_GWAHODONG", inputList, outputList))
            {
                o_msg = outputList[0].ToString();
                if (o_msg != "0")
                {
                    rtnValue = 1;
                    throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
                }
            }
            else
            {
                rtnValue = 1;
                throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }           

            sub_confirmBindVar.Clear();
            return rtnValue;

        }
        #endregion


        #region Command
        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command.Equals("BAS0250Q00"))//병실선택시
            {
                for (int i = 0; i < grdInp2004.RowCount; i++)
                {
                    if (grdInp2004.GetItemString(i, "bunho") == modifyBunho)
                    {
                        //회계병동이 동일한지 여부 확인
                        if (grdInp2004.GetItemString(i + 1, "ho_dong") == grdInp2004.GetItemString(i + 1, "kaikei_hodong") &&
                            grdInp2004.GetItemString(i + 1, "ho_code") == grdInp2004.GetItemString(i + 1, "kaikei_hocode"))
                        {
                            grdInp2004.SetItemValue(i + 1, "kaikei_hodong", commandParam["ho_dong"]);
                            grdInp2004.SetItemValue(i + 1, "kaikei_hocode", commandParam["ho_code"]);
                        }

                        grdInp2004.SetItemValue(i + 1, "ho_dong", commandParam["ho_dong"]);
                        grdInp2004.SetItemValue(i + 1, "ho_code", commandParam["ho_code"]);
                        grdInp2004.SetItemValue(i + 1, "ho_grade", commandParam["ho_grade"]);
                        grdInp2004.SetItemValue(i + 1, "bed_no", commandParam["bed_no"]);

                        grdInp2004.AcceptData();
                        //btnConfirm_Click(null, null);
                        break;
                    }
                }
            }
            modifyBunho = "";
            return base.Command(command, commandParam);
        }

        #endregion



        private void fwBed_no_QueryStarting(object sender, CancelEventArgs e)
        {
            fwBed_no.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwBed_no.SetBindVarValue("f_ho_dong", this.grdInp2004.GetItemString(this.grdInp2004.CurrentRowNumber, "ho_dong"));
            fwBed_no.SetBindVarValue("f_ho_code", this.grdInp2004.GetItemString(this.grdInp2004.CurrentRowNumber, "ho_code"));
        }

        private void grdInp2004_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName != "confirm_yn")
                return;
            //처리된 항목 색깔변경
            if (!TypeCheck.IsNull(e.DataRow["confirm_user"]))
            {
                e.BackColor = Color.DarkSlateGray;
            }

        }

        private void cboHoDong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.GetJunip();
        }

	}
}

