using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;

namespace IHIS.OCSI
{
	/// <summary>
	/// FormSettingHopeDate에 대한 요약 설명입니다.version2005
	/// </summary>
	public class OCS2003U99 : IHIS.Framework.XScreen
	{
		////////////////////////////////// Screen Level 개발자 변수 기술 ///////////////////////////////////
        //private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        //private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리

		private Hashtable mHtControl = null; // Control과 연결할 HashTable

		////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [DynService Control]
		//private IHIS.Framework.ValidationServiceDyn mVsdCommon = new ValidationServiceDyn();	
		#endregion

        //private string SERVICE_FALG = null;

		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel lblDv;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XFindBox fbxBunho;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDatePicker dtpIpwon_Date;
		private IHIS.Framework.XCheckBox cbxToiwon_Res_Yn;
		private IHIS.Framework.XDatePicker dtpToiwon_Res_Date;
        private IHIS.Framework.XEditGrid grdInp1001;
		private IHIS.Framework.XCheckBox cbxToiwon_Goji_Yn;
		private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XDisplayBox dbxSuname2;
		private IHIS.Framework.XTextBox txtFkinp1001;
		private IHIS.Framework.XEditMask emToiwon_Res_Time;
		private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XComboBox cboResult;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel pnlBottomLeft;
		private IHIS.Framework.XComboBox cboNurResult;
		private IHIS.Framework.XDatePicker dtpNurToiwon_Res_Date;
        //private IHIS.Framework.DataServiceSISO dsvChkDoubleYn;
        private System.ComponentModel.Container components = null;
        private SingleLayout layCheckDupYn;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayout layChkCommon;
        private string doubleCheck_processYn = string.Empty;
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
        private SingleLayoutItem singleLayoutItem2;
        private XDatePicker dtpSigi_Magam_Date;
        private XComboBox cboKi_Gubun;
        private XLabel xLabel7;
        private XLabel xLabel6;
       
        BindVarCollection bindVars = new BindVarCollection();
		
		public OCS2003U99()
		{
			InitializeComponent();
            			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
            //this.mOrderBiz = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
            //this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리
            //저장 수행자 Set
            this.grdInp1001.SavePerformer = new XSavePerformer(this);
            
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2003U99));
this.pnlBottom = new IHIS.Framework.XPanel();
this.pnlBottomLeft = new IHIS.Framework.XPanel();
this.btnList = new IHIS.Framework.XButtonList();
this.cboNurResult = new IHIS.Framework.XComboBox();
this.dtpNurToiwon_Res_Date = new IHIS.Framework.XDatePicker();
this.pnlFill = new IHIS.Framework.XPanel();
this.grdInp1001 = new IHIS.Framework.XEditGrid();
this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
this.txtFkinp1001 = new IHIS.Framework.XTextBox();
this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
this.dtpToiwon_Res_Date = new IHIS.Framework.XDatePicker();
this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
this.emToiwon_Res_Time = new IHIS.Framework.XEditMask();
this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
this.cbxToiwon_Goji_Yn = new IHIS.Framework.XCheckBox();
this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
this.dtpSigi_Magam_Date = new IHIS.Framework.XDatePicker();
this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
this.cboKi_Gubun = new IHIS.Framework.XComboBox();
this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
this.cboResult = new IHIS.Framework.XComboBox();
this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
this.dtpIpwon_Date = new IHIS.Framework.XDatePicker();
this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
this.fbxBunho = new IHIS.Framework.XFindBox();
this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
this.dbxSuname = new IHIS.Framework.XDisplayBox();
this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
this.dbxSuname2 = new IHIS.Framework.XDisplayBox();
this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
this.cbxToiwon_Res_Yn = new IHIS.Framework.XCheckBox();
this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
this.xPanel2 = new IHIS.Framework.XPanel();
this.xLabel8 = new IHIS.Framework.XLabel();
this.xLabel7 = new IHIS.Framework.XLabel();
this.xLabel6 = new IHIS.Framework.XLabel();
this.xPanel1 = new IHIS.Framework.XPanel();
this.xLabel5 = new IHIS.Framework.XLabel();
this.xLabel1 = new IHIS.Framework.XLabel();
this.xLabel4 = new IHIS.Framework.XLabel();
this.xLabel2 = new IHIS.Framework.XLabel();
this.lblDv = new IHIS.Framework.XLabel();
this.xLabel3 = new IHIS.Framework.XLabel();
this.layCheckDupYn = new IHIS.Framework.SingleLayout();
this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
this.layChkCommon = new IHIS.Framework.SingleLayout();
this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
this.pnlBottom.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
this.pnlFill.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdInp1001)).BeginInit();
this.SuspendLayout();
// 
// ImageList
// 
this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
this.ImageList.Images.SetKeyName(0, "YESEN1.ICO");
this.ImageList.Images.SetKeyName(1, "YESUP1.ICO");
// 
// pnlBottom
// 
this.pnlBottom.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
this.pnlBottom.Controls.Add(this.pnlBottomLeft);
this.pnlBottom.Controls.Add(this.btnList);
this.pnlBottom.Controls.Add(this.cboNurResult);
this.pnlBottom.Controls.Add(this.dtpNurToiwon_Res_Date);
this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
this.pnlBottom.DrawBorder = true;
this.pnlBottom.Location = new System.Drawing.Point(0, 156);
this.pnlBottom.Name = "pnlBottom";
this.pnlBottom.Size = new System.Drawing.Size(488, 37);
this.pnlBottom.TabIndex = 3;
// 
// pnlBottomLeft
// 
this.pnlBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
this.pnlBottomLeft.Location = new System.Drawing.Point(0, 0);
this.pnlBottomLeft.Name = "pnlBottomLeft";
this.pnlBottomLeft.Padding = new System.Windows.Forms.Padding(3);
this.pnlBottomLeft.Size = new System.Drawing.Size(106, 35);
this.pnlBottomLeft.TabIndex = 9;
// 
// btnList
// 
this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
this.btnList.Location = new System.Drawing.Point(323, 0);
this.btnList.Name = "btnList";
this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
this.btnList.Size = new System.Drawing.Size(163, 35);
this.btnList.TabIndex = 6;
this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
// 
// cboNurResult
// 
this.cboNurResult.Location = new System.Drawing.Point(201, 8);
this.cboNurResult.Name = "cboNurResult";
this.cboNurResult.Size = new System.Drawing.Size(117, 21);
this.cboNurResult.TabIndex = 8;
this.cboNurResult.Visible = false;
// 
// dtpNurToiwon_Res_Date
// 
this.dtpNurToiwon_Res_Date.Location = new System.Drawing.Point(107, 8);
this.dtpNurToiwon_Res_Date.Name = "dtpNurToiwon_Res_Date";
this.dtpNurToiwon_Res_Date.Size = new System.Drawing.Size(94, 20);
this.dtpNurToiwon_Res_Date.TabIndex = 67;
this.dtpNurToiwon_Res_Date.Visible = false;
// 
// pnlFill
// 
this.pnlFill.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
this.pnlFill.Controls.Add(this.grdInp1001);
this.pnlFill.Controls.Add(this.xPanel2);
this.pnlFill.Controls.Add(this.cboResult);
this.pnlFill.Controls.Add(this.xLabel8);
this.pnlFill.Controls.Add(this.cboKi_Gubun);
this.pnlFill.Controls.Add(this.dtpSigi_Magam_Date);
this.pnlFill.Controls.Add(this.xLabel7);
this.pnlFill.Controls.Add(this.xLabel6);
this.pnlFill.Controls.Add(this.xPanel1);
this.pnlFill.Controls.Add(this.xLabel5);
this.pnlFill.Controls.Add(this.emToiwon_Res_Time);
this.pnlFill.Controls.Add(this.cbxToiwon_Goji_Yn);
this.pnlFill.Controls.Add(this.txtFkinp1001);
this.pnlFill.Controls.Add(this.dbxSuname2);
this.pnlFill.Controls.Add(this.dbxSuname);
this.pnlFill.Controls.Add(this.xLabel1);
this.pnlFill.Controls.Add(this.dtpToiwon_Res_Date);
this.pnlFill.Controls.Add(this.cbxToiwon_Res_Yn);
this.pnlFill.Controls.Add(this.xLabel4);
this.pnlFill.Controls.Add(this.dtpIpwon_Date);
this.pnlFill.Controls.Add(this.xLabel2);
this.pnlFill.Controls.Add(this.fbxBunho);
this.pnlFill.Controls.Add(this.lblDv);
this.pnlFill.Controls.Add(this.xLabel3);
this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
this.pnlFill.DrawBorder = true;
this.pnlFill.Location = new System.Drawing.Point(0, 0);
this.pnlFill.Name = "pnlFill";
this.pnlFill.Size = new System.Drawing.Size(488, 156);
this.pnlFill.TabIndex = 5;
// 
// grdInp1001
// 
this.grdInp1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell14});
this.grdInp1001.ColPerLine = 14;
this.grdInp1001.Cols = 14;
this.grdInp1001.ControlBinding = true;
this.grdInp1001.FixedRows = 1;
this.grdInp1001.HeaderHeights.Add(21);
this.grdInp1001.Location = new System.Drawing.Point(313, 39);
this.grdInp1001.Name = "grdInp1001";
this.grdInp1001.QuerySQL = resources.GetString("grdInp1001.QuerySQL");
this.grdInp1001.Rows = 2;
this.grdInp1001.Size = new System.Drawing.Size(144, 57);
this.grdInp1001.TabIndex = 56;
this.grdInp1001.Visible = false;
this.grdInp1001.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdInp1001_SaveEnd);
// 
// xEditGridCell1
// 
this.xEditGridCell1.BindControl = this.txtFkinp1001;
this.xEditGridCell1.CellName = "fkinp1001";
this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
this.xEditGridCell1.HeaderText = "fkinp1001";
this.xEditGridCell1.IsUpdatable = false;
// 
// txtFkinp1001
// 
this.txtFkinp1001.Location = new System.Drawing.Point(188, 24);
this.txtFkinp1001.Name = "txtFkinp1001";
this.txtFkinp1001.Size = new System.Drawing.Size(62, 20);
this.txtFkinp1001.TabIndex = 59;
this.txtFkinp1001.Visible = false;
// 
// xEditGridCell2
// 
this.xEditGridCell2.BindControl = this.dtpToiwon_Res_Date;
this.xEditGridCell2.CellName = "toiwon_res_date";
this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
this.xEditGridCell2.Col = 1;
this.xEditGridCell2.HeaderText = "toiwon_res_date";
// 
// dtpToiwon_Res_Date
// 
this.dtpToiwon_Res_Date.Location = new System.Drawing.Point(114, 58);
this.dtpToiwon_Res_Date.Name = "dtpToiwon_Res_Date";
this.dtpToiwon_Res_Date.Size = new System.Drawing.Size(94, 20);
this.dtpToiwon_Res_Date.TabIndex = 1;
this.dtpToiwon_Res_Date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
// 
// xEditGridCell3
// 
this.xEditGridCell3.BindControl = this.emToiwon_Res_Time;
this.xEditGridCell3.CellName = "toiwon_res_time";
this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Time;
this.xEditGridCell3.Col = 2;
this.xEditGridCell3.HeaderText = "toiwon_res_time";
// 
// emToiwon_Res_Time
// 
this.emToiwon_Res_Time.EditMaskType = IHIS.Framework.MaskType.Time;
this.emToiwon_Res_Time.Location = new System.Drawing.Point(114, 79);
this.emToiwon_Res_Time.Mask = "HH:MI";
this.emToiwon_Res_Time.Name = "emToiwon_Res_Time";
this.emToiwon_Res_Time.Size = new System.Drawing.Size(94, 20);
this.emToiwon_Res_Time.TabIndex = 2;
this.emToiwon_Res_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.emToiwon_Res_Time.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
// 
// xEditGridCell4
// 
this.xEditGridCell4.BindControl = this.cbxToiwon_Goji_Yn;
this.xEditGridCell4.CellLen = 1;
this.xEditGridCell4.CellName = "toiwon_goji_yn";
this.xEditGridCell4.Col = 3;
this.xEditGridCell4.HeaderText = "toiwon_goji_yn";
// 
// cbxToiwon_Goji_Yn
// 
this.cbxToiwon_Goji_Yn.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
this.cbxToiwon_Goji_Yn.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cbxToiwon_Goji_Yn.Location = new System.Drawing.Point(90, 106);
this.cbxToiwon_Goji_Yn.Name = "cbxToiwon_Goji_Yn";
this.cbxToiwon_Goji_Yn.Size = new System.Drawing.Size(20, 24);
this.cbxToiwon_Goji_Yn.TabIndex = 3;
this.cbxToiwon_Goji_Yn.UseVisualStyleBackColor = false;
this.cbxToiwon_Goji_Yn.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
// 
// xEditGridCell5
// 
this.xEditGridCell5.BindControl = this.dtpSigi_Magam_Date;
this.xEditGridCell5.CellName = "sigi_magam_date";
this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
this.xEditGridCell5.Col = 4;
this.xEditGridCell5.HeaderText = "sigi_magam_date";
// 
// dtpSigi_Magam_Date
// 
this.dtpSigi_Magam_Date.Location = new System.Drawing.Point(323, 130);
this.dtpSigi_Magam_Date.Name = "dtpSigi_Magam_Date";
this.dtpSigi_Magam_Date.Size = new System.Drawing.Size(94, 20);
this.dtpSigi_Magam_Date.TabIndex = 4;
this.dtpSigi_Magam_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.dtpSigi_Magam_Date.Visible = false;
// 
// xEditGridCell6
// 
this.xEditGridCell6.BindControl = this.cboKi_Gubun;
this.xEditGridCell6.CellLen = 1;
this.xEditGridCell6.CellName = "ki_gubun";
this.xEditGridCell6.Col = 5;
this.xEditGridCell6.HeaderText = "ki_gubun";
// 
// cboKi_Gubun
// 
this.cboKi_Gubun.Location = new System.Drawing.Point(470, 130);
this.cboKi_Gubun.Name = "cboKi_Gubun";
this.cboKi_Gubun.Size = new System.Drawing.Size(117, 21);
this.cboKi_Gubun.TabIndex = 5;
this.cboKi_Gubun.Visible = false;
// 
// xEditGridCell7
// 
this.xEditGridCell7.BindControl = this.cboResult;
this.xEditGridCell7.CellLen = 2;
this.xEditGridCell7.CellName = "result";
this.xEditGridCell7.Col = 6;
this.xEditGridCell7.HeaderText = "result";
// 
// cboResult
// 
this.cboResult.Location = new System.Drawing.Point(114, 129);
this.cboResult.Name = "cboResult";
this.cboResult.Size = new System.Drawing.Size(117, 21);
this.cboResult.TabIndex = 6;
// 
// xEditGridCell8
// 
this.xEditGridCell8.BindControl = this.dtpIpwon_Date;
this.xEditGridCell8.CellName = "ipwon_date";
this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
this.xEditGridCell8.Col = 7;
this.xEditGridCell8.HeaderText = "ipwon_date";
// 
// dtpIpwon_Date
// 
this.dtpIpwon_Date.Location = new System.Drawing.Point(90, 27);
this.dtpIpwon_Date.Name = "dtpIpwon_Date";
this.dtpIpwon_Date.Protect = true;
this.dtpIpwon_Date.ReadOnly = true;
this.dtpIpwon_Date.Size = new System.Drawing.Size(94, 20);
this.dtpIpwon_Date.TabIndex = 50;
this.dtpIpwon_Date.TabStop = false;
// 
// xEditGridCell9
// 
this.xEditGridCell9.BindControl = this.fbxBunho;
this.xEditGridCell9.CellLen = 9;
this.xEditGridCell9.CellName = "bunho";
this.xEditGridCell9.Col = 8;
this.xEditGridCell9.HeaderText = "bunho";
this.xEditGridCell9.IsUpdatable = false;
// 
// fbxBunho
// 
this.fbxBunho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.fbxBunho.EnableEdit = false;
this.fbxBunho.Location = new System.Drawing.Point(90, 4);
this.fbxBunho.MaxLength = 9;
this.fbxBunho.Name = "fbxBunho";
this.fbxBunho.Protect = true;
this.fbxBunho.ReadOnly = true;
this.fbxBunho.Size = new System.Drawing.Size(94, 20);
this.fbxBunho.TabIndex = 45;
this.fbxBunho.TabStop = false;
// 
// xEditGridCell10
// 
this.xEditGridCell10.BindControl = this.dbxSuname;
this.xEditGridCell10.CellLen = 30;
this.xEditGridCell10.CellName = "suname";
this.xEditGridCell10.Col = 9;
this.xEditGridCell10.HeaderText = "suname";
this.xEditGridCell10.IsUpdatable = false;
this.xEditGridCell10.IsUpdCol = false;
// 
// dbxSuname
// 
this.dbxSuname.Location = new System.Drawing.Point(185, 4);
this.dbxSuname.Name = "dbxSuname";
this.dbxSuname.Size = new System.Drawing.Size(100, 20);
this.dbxSuname.TabIndex = 57;
// 
// xEditGridCell11
// 
this.xEditGridCell11.BindControl = this.dbxSuname2;
this.xEditGridCell11.CellName = "suname2";
this.xEditGridCell11.Col = 10;
this.xEditGridCell11.HeaderText = "suname2";
// 
// dbxSuname2
// 
this.dbxSuname2.Location = new System.Drawing.Point(285, 4);
this.dbxSuname2.Name = "dbxSuname2";
this.dbxSuname2.Size = new System.Drawing.Size(96, 20);
this.dbxSuname2.TabIndex = 58;
// 
// xEditGridCell12
// 
this.xEditGridCell12.BindControl = this.cbxToiwon_Res_Yn;
this.xEditGridCell12.CellLen = 1;
this.xEditGridCell12.CellName = "toiwon_res_yn";
this.xEditGridCell12.Col = 11;
this.xEditGridCell12.HeaderText = "toiwon_res_yn";
// 
// cbxToiwon_Res_Yn
// 
this.cbxToiwon_Res_Yn.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
this.cbxToiwon_Res_Yn.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cbxToiwon_Res_Yn.Location = new System.Drawing.Point(90, 55);
this.cbxToiwon_Res_Yn.Name = "cbxToiwon_Res_Yn";
this.cbxToiwon_Res_Yn.Size = new System.Drawing.Size(20, 24);
this.cbxToiwon_Res_Yn.TabIndex = 0;
this.cbxToiwon_Res_Yn.UseVisualStyleBackColor = false;
this.cbxToiwon_Res_Yn.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
// 
// xEditGridCell13
// 
this.xEditGridCell13.CellName = "double_yn";
this.xEditGridCell13.Col = 12;
this.xEditGridCell13.HeaderText = "double_yn";
// 
// xEditGridCell14
// 
this.xEditGridCell14.CellName = "doctor_nurse_gubun";
this.xEditGridCell14.Col = 13;
this.xEditGridCell14.HeaderText = "doctor_nurse_gubun";
// 
// xPanel2
// 
this.xPanel2.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
this.xPanel2.DrawBorder = true;
this.xPanel2.Location = new System.Drawing.Point(-1, 102);
this.xPanel2.Name = "xPanel2";
this.xPanel2.Size = new System.Drawing.Size(593, 2);
this.xPanel2.TabIndex = 66;
// 
// xLabel8
// 
this.xLabel8.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
this.xLabel8.Location = new System.Drawing.Point(2, 129);
this.xLabel8.Name = "xLabel8";
this.xLabel8.Size = new System.Drawing.Size(87, 21);
this.xLabel8.TabIndex = 65;
this.xLabel8.Text = "退院事由";
// 
// xLabel7
// 
this.xLabel7.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
this.xLabel7.Location = new System.Drawing.Point(235, 130);
this.xLabel7.Name = "xLabel7";
this.xLabel7.Size = new System.Drawing.Size(87, 21);
this.xLabel7.TabIndex = 64;
this.xLabel7.Text = "食事締切日";
this.xLabel7.Visible = false;
// 
// xLabel6
// 
this.xLabel6.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
this.xLabel6.Location = new System.Drawing.Point(421, 130);
this.xLabel6.Name = "xLabel6";
this.xLabel6.Size = new System.Drawing.Size(47, 21);
this.xLabel6.TabIndex = 63;
this.xLabel6.Text = "飯区分";
this.xLabel6.Visible = false;
// 
// xPanel1
// 
this.xPanel1.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
this.xPanel1.DrawBorder = true;
this.xPanel1.Location = new System.Drawing.Point(0, 50);
this.xPanel1.Name = "xPanel1";
this.xPanel1.Size = new System.Drawing.Size(600, 2);
this.xPanel1.TabIndex = 62;
// 
// xLabel5
// 
this.xLabel5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
this.xLabel5.Location = new System.Drawing.Point(2, 79);
this.xLabel5.Name = "xLabel5";
this.xLabel5.Size = new System.Drawing.Size(87, 21);
this.xLabel5.TabIndex = 61;
this.xLabel5.Text = "退院予告時間";
// 
// xLabel1
// 
this.xLabel1.BackColor = IHIS.Framework.XColor.XPanelBackColor;
this.xLabel1.BorderColor = IHIS.Framework.XColor.XPanelBorderColor;
this.xLabel1.EdgeRounding = false;
this.xLabel1.Location = new System.Drawing.Point(114, 106);
this.xLabel1.Name = "xLabel1";
this.xLabel1.Size = new System.Drawing.Size(266, 20);
this.xLabel1.TabIndex = 55;
this.xLabel1.Text = "<= オーダ終了は看護で入力します。";
// 
// xLabel4
// 
this.xLabel4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
this.xLabel4.Location = new System.Drawing.Point(2, 56);
this.xLabel4.Name = "xLabel4";
this.xLabel4.Size = new System.Drawing.Size(87, 21);
this.xLabel4.TabIndex = 51;
this.xLabel4.Text = "退院予告日";
// 
// xLabel2
// 
this.xLabel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
this.xLabel2.Location = new System.Drawing.Point(2, 4);
this.xLabel2.Name = "xLabel2";
this.xLabel2.Size = new System.Drawing.Size(87, 21);
this.xLabel2.TabIndex = 49;
this.xLabel2.Text = "患者番号";
// 
// lblDv
// 
this.lblDv.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
this.lblDv.Location = new System.Drawing.Point(2, 106);
this.lblDv.Name = "lblDv";
this.lblDv.Size = new System.Drawing.Size(87, 21);
this.lblDv.TabIndex = 20;
this.lblDv.Text = "オーダ終了";
// 
// xLabel3
// 
this.xLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
this.xLabel3.Location = new System.Drawing.Point(2, 27);
this.xLabel3.Name = "xLabel3";
this.xLabel3.Size = new System.Drawing.Size(87, 21);
this.xLabel3.TabIndex = 19;
this.xLabel3.Text = "入院日付";
// 
// layCheckDupYn
// 
this.layCheckDupYn.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
this.layCheckDupYn.QuerySQL = resources.GetString("layCheckDupYn.QuerySQL");
this.layCheckDupYn.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCheckDupYn_QueryStarting);
// 
// singleLayoutItem1
// 
this.singleLayoutItem1.DataName = "double_yn";
// 
// layChkCommon
// 
this.layChkCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
this.layChkCommon.QuerySQL = resources.GetString("layChkCommon.QuerySQL");
// 
// singleLayoutItem2
// 
this.singleLayoutItem2.DataName = "chk";
// 
// OCS2003U99
// 
this.Controls.Add(this.pnlFill);
this.Controls.Add(this.pnlBottom);
this.Name = "OCS2003U99";
this.Size = new System.Drawing.Size(488, 193);
this.UserChanged += new System.EventHandler(this.OCS2003U99_UserChanged);
this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS2003U01_ScreenOpen);
this.pnlBottom.ResumeLayout(false);
this.pnlBottom.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
this.pnlFill.ResumeLayout(false);
this.pnlFill.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.grdInp1001)).EndInit();
this.ResumeLayout(false);

		}
		#endregion

		///////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [메소드 모듈]

		#region 입원미실행처방조회 Screen Open (OpenNoActingQuery)
		/// <summary>
		/// 입원미실행처방조회 Screen Open
		/// </summary>
		/// <param name="aBunho"> string 등록번호 </param>
		/// <param name="aOrder_Date"> string 처방일자 </param>
		/// <returns> void </returns>		
		private void OpenNoActingQuery(string aBunho, string aOrder_Date)
		{
			CommonItemCollection openParams  = new CommonItemCollection();
			
			if (!TypeCheck.IsNull(aBunho))
			{
				openParams.Add("bunho", aBunho);
				if (!TypeCheck.IsNull(aOrder_Date)) openParams.Add("order_date", aOrder_Date);

				// 응답을 받아야 하기 때문에 Response로 띄운다
				XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003Q02", ScreenOpenStyle.ResponseSizable, openParams);
			}

		}        
		#endregion

		#region 병동일지 퇴원여부 조회
        //20100513 퇴원처리 여부 조회 메소드.
        private string GetToiwonResult(string i_bunho,string i_pkinp1001, string i_toiwon_res_date)
        {
            string resultYn = "Y";

            string strSql = @" SELECT 'Y'
                                 FROM DUAL
                                WHERE EXISTS (SELECT 'X'
                                                FROM NUR1004 A
                                               WHERE A.BUNHO               = :f_bunho
                                                 AND A.FKINP1001           = :f_fkinp1001
                                                 AND A.TOIWON_DATE         = TO_DATE(:f_toiwon_date, 'YYYY/MM/DD')
                                                 AND NVL(A.TOIWON_YN, 'N') = 'Y')";

            bindVars.Add("f_bunho", i_bunho);
            bindVars.Add("f_fkinp1001", i_pkinp1001);
            bindVars.Add("f_toiwon_date", i_toiwon_res_date);

            object resultData = Service.ExecuteScalar(strSql,bindVars);

            if (resultData == null || resultData.ToString() == "")
            {
                resultYn = "N";
            }
      
            if (Service.ErrCode == 0) 
            {
                strSql = @"SELECT A.RESULT      RESULT
    	                         ,A.TOIWON_DATE TOIWON_DATE
    	                     FROM NUR1004 A
                            WHERE A.BUNHO       = :f_bunho
                              AND A.FKINP1001   = :f_fkinp1001
                              AND A.TOIWON_DATE = TO_DATE(:f_toiwon_date, 'YYYY/MM/DD')";

                DataTable resultCbo = Service.ExecuteDataTable(strSql, bindVars);
                if (resultCbo != null)
                {
                    if(resultCbo.Rows.Count > 0)
                        this.cboNurResult.SetEditValue(resultCbo.Rows[0]["result"].ToString());
                }                
            }

            return resultYn;
        }

        //private string GetToiwonYn()
        //{
        //    string pram_bunho           = string.Empty;
        //    string pram_pkinp1001       = string.Empty;
        //    string pram_toiwon_res_date = string.Empty;
        //    string result_Yn = string.Empty;

        //    //변수를 셋팅.
        //    pram_bunho           = this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "bunho").ToString();
        //    pram_pkinp1001       = this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "fkinp1001").ToString();
        //    pram_toiwon_res_date = this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "toiwon_res_date").ToString();
        //    result_Yn = GetToiwonResult(pram_bunho, pram_pkinp1001, pram_toiwon_res_date);
        //    // 
        //    if ((int)result_Yn.Length != 0)//this.DataServiceCall(this.dsvToiwonYn)
        //    {
        //        if (result_Yn == "Y")
        //        {
        //            this.btnNurToiwon.Tag = "Y";
        //            this.btnNurToiwon.Text = "日誌用取消";
        //            this.btnNurToiwon.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
        //            this.btnNurToiwon.ImageIndex = 1;
        //        }
        //        else
        //        {
        //            this.btnNurToiwon.Tag = "N";
        //            this.btnNurToiwon.Text = "日誌用退院";
        //            this.btnNurToiwon.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
        //            this.btnNurToiwon.ImageIndex = 0;
        //        }
        //    }
        //    else
        //    {
        //        XMessageBox.Show(Service.ErrFullMsg.ToString());
        //        return result_Yn = "N";
        //    }
        //    return result_Yn;
        //}
		#endregion

		#endregion
		///////////////////////////////////////////////////////////////////////////////////////////////////////
		

		///////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [Screen Event]
		/// <summary>
		/// Screen Load시 Post Event로 Call 되서 Load시 처리할 로직들을 기술한다
		/// </summary>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			this.PostLoad();

		}
		private void PostLoad()
		{
			// HashTable과 연결할 Control's Setting
            //foreach (object obj in this.pnlFill.Controls) this.SetHashTableBinding(this.mHtControl, obj);

			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS2003U99_UserChanged(this, new System.EventArgs()); //this.OnUserChanged();
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			// 화면이 열린 경우 기본적으로 퇴원예고일을 현재 일로 셋팅한다.
			this.cbxToiwon_Res_Yn.Checked = true;
            this.cbxToiwon_Goji_Yn.AcceptData();
			
			//간호가아닌 다른곳에서 연경우에는 일지용퇴원버튼을 안보이게 처리
            if (EnvironInfo.CurrSystemID.ToString() == "NURI")
            {
                //this.btnNurToiwon.Visible = true;
                //this.dtpNurToiwon_Res_Date.Visible = true;
                //this.cboNurResult.Visible = true;
            }
            else
            {
                this.dtpNurToiwon_Res_Date.Visible = false;
                this.cboNurResult.Visible = false;
            }

			// 이중유형환자인지 조회한다.
            if (!this.layCheckDupYn.QueryLayout())
			{
                if (Service.ErrCode != 0)
                {
                    XMessageBox.Show(Service.ErrFullMsg.ToString());
                    return;
                }
			}
            doubleCheck_processYn = "N";

            if(!TypeCheck.IsNull(this.layCheckDupYn.GetItemValue("double_yn")))
            { 
                //if (this.cbxToiwon_Goji_Yn.GetDataValue().Equals("Y"))
                //{
                doubleCheck_processYn = this.layCheckDupYn.GetItemValue("double_yn").ToString();
                //}
            }

			//병동일지용 퇴원확인을 했는지 조회한다. */
            //this.GetToiwonYn();
		}

		/// <summary>
		/// Screen Open시 Parameter를 받는다
		/// </summary>
		/// <remarks>
		/// 해당 등록번호와 내원정보로 입원처방 데이타 조회
		/// </remarks>
		private void OCS2003U01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Combo 세팅
			DataTable dtTemp = null;
            string strSql = string.Empty;

			// 끼구분			
            //dtTemp  = this.mOrderBiz.LoadComboDataSource("ki_gubun").LayoutTable;
            //this.cboKi_Gubun.SetComboItems(dtTemp, "code_name", "code", XComboSetType.NoAppend);

			// 퇴원사유			
            //dtTemp  = this.mOrderBiz.LoadComboDataSource("result").LayoutTable;

            strSql = @"SELECT CODE
                             , CODE_NAME
                          FROM BAS0102
                         WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                           AND CODE_TYPE = 'RESULT'
                         ORDER BY CODE";
            dtTemp = Service.ExecuteDataTable(strSql);

			this.cboResult.SetComboItems(dtTemp, "code_name", "code", XComboSetType.NoAppend);
			this.cboNurResult.SetComboItems(dtTemp, "code_name", "code", XComboSetType.NoAppend);

			if (e.OpenParam != null && e.OpenParam.Contains("fkinp1001"))
			{
				// 데이타 조회
                this.grdInp1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdInp1001.SetBindVarValue("f_fkinp1001", e.OpenParam["fkinp1001"].ToString().Trim());

                bool isQuery = this.grdInp1001.QueryLayout(true);//  // 해당 데이타 조회

                //if (this.grdInp1001.GetItemValue(this.grdInp1001.CurrentRowNumber, "toiwon_res_date").ToString() != "")
                //{
                //    this.dtpNurToiwon_Res_Date.SetEditValue(this.grdInp1001.GetItemValue(this.grdInp1001.CurrentRowNumber, "toiwon_res_date").ToString());
                //    this.dtpNurToiwon_Res_Date.AcceptData();
                //}
                //else
                //{
                //    this.dtpNurToiwon_Res_Date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                //    this.dtpNurToiwon_Res_Date.AcceptData();
                //}

				if (EnvironInfo.CurrSystemID.ToString() != "NURI")
				{
					this.grdInp1001.SetItemValue(this.grdInp1001.CurrentRowNumber, "doctor_nurse_gubun", "D");
				}
				else
				{
					this.grdInp1001.SetItemValue(this.grdInp1001.CurrentRowNumber, "doctor_nurse_gubun", "N");
				}

                this.grdInp1001.ResetUpdate();

				isQuery = false;
			}
		}

		/// <summary>
		/// 사용자 변경시
		/// </summary>
		/// <remarks>
		/// 사용자 구분에 따른 입력필드 정의
		/// </remarks>
		private void OCS2003U99_UserChanged(object sender, System.EventArgs e)
		{
			if (IHIS.Framework.UserInfo.UserGubun == UserType.Doctor) // 의사인경우 퇴원예고일 +  + 퇴원예고시간
			{
				this.cbxToiwon_Res_Yn.Protect = false;   // 퇴원예고여부
				this.dtpToiwon_Res_Date.Protect = false; // 퇴원예고일자
				this.emToiwon_Res_Time.Protect = false;  // 퇴원예고시간
				this.cbxToiwon_Goji_Yn.Protect = true;   // 처방종료여부
				this.dtpSigi_Magam_Date.Protect = true;  // 식사마감일자
				this.cboKi_Gubun.Protect = true;         // 끼구분
				this.cboResult.Protect = true;           // 퇴원사유
			}
			else // 간호인 경우 처방종료여부 등록 + 퇴원예고시간
			{
				this.cbxToiwon_Res_Yn.Protect = true;    // 퇴원예고여부
				this.dtpToiwon_Res_Date.Protect = false; // 퇴원예고일자
				this.emToiwon_Res_Time.Protect = false;  // 퇴원예고시간 (의사와 공통으로 시간은 설정할수 있게 해준다)
				this.cbxToiwon_Goji_Yn.Protect = false;  // 처방종료여부			
				this.dtpSigi_Magam_Date.Protect = false; // 식사마감일자
				this.cboKi_Gubun.Protect = false;        // 끼구분
				this.cboResult.Protect = false;          // 퇴원사유
			}
		}

		#endregion
		///////////////////////////////////////////////////////////////////////////////////////////////////////


		#region 타Screen에서 Open (Command)	
		public override object Command(string command, CommonItemCollection commandParam)
		{                       
//			switch(command.Trim())
//			{
//				case "OCS0208Q00": // 사용자 복용코드조회
//					break;
//			}

			return base.Command(command, commandParam);
		}
		#endregion

		#region buttonList ButtonList 클릭 Event : Find SQL조건 및 필드 정의 (btnList_ButtonClick)
        //20100513 edit start
        private void layCheckDupYn_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCheckDupYn.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layCheckDupYn.SetBindVarValue("f_bunho",this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber,"bunho"));
        }
   

        //20100513 edit end
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			string mbxMsg = "";
			string mbxCap = "";
			switch (e.Func)
			{
				case FunctionType.Update: // 선택

                    if (this.cbxToiwon_Goji_Yn.GetDataValue().Equals("Y"))// && doubleCheck_processYn.Equals("N"))
                    {
                        e.IsBaseCall = false; e.IsSuccess = true;

                        if (!this.AcceptData()) { e.IsSuccess = false; break; }

                        // 입원정보 존재여부 체크
                        if (this.grdInp1001.RowCount == 0 || TypeCheck.IsNull(this.fbxBunho.GetDataValue()))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "患者情報がありません。確認してください。" : "환자정보가 없습니다. 확인하십시오.";
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
                            e.IsSuccess = false; break;
                        }

                        //오다종료가 된경우와 안된경우를 나누어서 처리
                        //오다종료가 된 경우에는 원래의 로직을 태우고
                        //안되있는 경우에는 새로운 로직을 태움(2008.01.16)

                        if (IHIS.Framework.UserInfo.UserGubun == UserType.Nurse)
                        {
                            if (this.cbxToiwon_Goji_Yn.Checked == false)
                            {
                                #region // 체크했을 때만 이므로 안타는 로직임
                                /******************************************************************************
                                 * 목적     : 입원퇴원예고 정보를 저장한다(오다종료를 하지 않았을 경우에).
                                ******************************************************************************/
                                //SERVICE_FALG = "3";
                                //if (this.dtpSigi_Magam_Date.GetDataValue().ToString() == "")
                                //{
                                //    mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                                //    mbxMsg = NetInfo.Language == LangMode.Jr ? "食事締切日を入力して下さい。" : "식사마감일을 입력해 주세요.";

                                //    XMessageBox.Show(mbxMsg, mbxCap);
                                //    return;
                                //}

                                ////if (this.cboKi_Gubun.GetDataValue().ToString() == "")
                                ////{
                                ////    mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                                ////    mbxMsg = NetInfo.Language == LangMode.Jr ? "飯区分を入力して下さい。" : "끼구분을 입력해 주세요.";

                                ////    XMessageBox.Show(mbxMsg, mbxCap);
                                ////    return;
                                ////}

                                ////새로운 저장로직 콜
                                //if (this.grdInp1001.SaveLayout())//!this.DataServiceCall(this.dsvSaveInp1001_Re)
                                //{
                                //    if (this.cboResult.GetDataValue().ToString() != "")
                                //    {
                                //        this.cboNurResult.SetEditValue(this.cboResult.GetDataValue().ToString());
                                //        this.cboNurResult.AcceptData();

                                //        if (this.btnNurToiwon.Tag.ToString() == "N")
                                //        {
                                //            if (this.GetToiwonResult(this.grdInp1001.GetItemValue(grdInp1001.CurrentRowNumber, "bunho").ToString()
                                //                                    , this.grdInp1001.GetItemValue(grdInp1001.CurrentRowNumber, "fkinp1001").ToString()
                                //                                    , this.grdInp1001.GetItemValue(grdInp1001.CurrentRowNumber, "toiwon_res_date").ToString()) == "Y")
                                //            {
                                //                this.btnNurToiwon.Tag = "Y";
                                //                this.btnNurToiwon.Text = "日誌用取消";
                                //                this.btnNurToiwon.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
                                //                this.btnNurToiwon.ImageIndex = 1;
                                //            }
                                //            else
                                //            {
                                //                XMessageBox.Show(Service.ErrFullMsg.ToString());
                                //                return;
                                //            }
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                //    XMessageBox.Show(Service.ErrFullMsg.ToString());
                                //    return;
                                //}
                            #endregion                                
                            }
                            else
                            {
                                /******************************************************************************
                                 목적     : 입원퇴원예고 정보를 저장한다(오다종료를 했을 경우에).
                                 *******************************************************************************/

                                //SERVICE_FALG = "S";
                                // 간호에서 퇴원고지한 경우 의사가 퇴원예고일이 없는 경우는 오늘날짜로 세팅한다
                                if (this.cbxToiwon_Goji_Yn.GetDataValue() == "Y" && TypeCheck.IsNull(this.dtpToiwon_Res_Date.GetDataValue()))
                                {
                                    bool isProtect = this.dtpToiwon_Res_Date.Protect;

                                    this.dtpToiwon_Res_Date.Protect = false;
                                    this.dtpToiwon_Res_Date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                                    this.grdInp1001.SetItemValue(0, "toiwon_res_date", this.dtpToiwon_Res_Date.GetDataValue());
                                    this.dtpToiwon_Res_Date.Protect = isProtect;
                                }

                                if (this.grdInp1001.RowCount > 0 && GetCheckNurseConfirmD6(grdInp1001.GetItemString(0, "bunho"), grdInp1001.GetItemString(0, "fkinp1001")))
                                {
                                    mbxCap = NetInfo.Language == LangMode.Jr ? "外来検査確認" : "외래검사확인";
                                    mbxMsg = NetInfo.Language == LangMode.Jr ? "看護確認された外来検査が存在します。\n\r看護確認がされていないと退院後、該当検査が外来で表示されません。\r\n進行しますか？" : "간호확인이 안된 외래검사가 존재합니다. \r\n간호확인이 안되면 퇴원후 해당 검사가 외래에서 보이지 않습니다. \r\n진행 하시겠습니까?";

                                    if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
                                    {
                                        return;
                                    }
                                }

                                // 퇴원예고일이 있는 경우는 해당 퇴원예고일 이후에 처방은 삭제처리합니다..
                                if (!TypeCheck.IsNull(this.dtpToiwon_Res_Date.GetDataValue()))
                                {

                                    mbxCap = NetInfo.Language == LangMode.Jr ? "削除確認" : "삭제 확인";
                                    mbxMsg = NetInfo.Language == LangMode.Jr ? "退院予告日付以降の実施されてないオーダは削除します。\r\n進行しますか？" : "퇴원예고일자 이후의 시행하지 않은 오더는 삭제합니다. \r\n진행 하시겠습니까?";

                                    if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
                                    {
                                        return;
                                    }
                                }

                                // 이중유형환자인 경우에 이중유형 둘다 퇴원 처리를 할 것인지 확인.
                                if (doubleCheck_processYn == "Y")
                                {
                                    mbxCap = NetInfo.Language == LangMode.Jr ? "削除確認" : "이중유형확인";
                                    mbxMsg = NetInfo.Language == LangMode.Jr ? "複数保険型患者です。\r\n複数保険両方共に処理しますか？" : "이중유형환자입니다. \r\n이중유형둘다를 처리 하시겠습니까?";

                                    if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        //둘다 퇴원처리를 한다는 여부를 서비스로 넘김
                                        this.grdInp1001.SetItemValue(this.grdInp1001.CurrentRowNumber, "double_yn", "Y");
                                    }
                                }


                                // 신규로 퇴원예고하는 경우 
                                if (this.grdInp1001.RowCount > 0 &&
                                    //this.grdInp1001.GetItemString(0, "toiwon_res_yn").Trim() != "Y" &&
                                    this.cbxToiwon_Res_Yn.GetDataValue().Trim() == "Y")
                                {
                                    // 미실행처방조회 창을 띄운다
                                    this.OpenNoActingQuery(this.fbxBunho.GetDataValue(), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // 입원미실행처방조회 Screen Open
                                }

                                //DPC입력화면 오픈
                                //this.SetOpenDpc();


                                // 처방 데이타 삭제여부를 Opener에게 알린다
                                CommonItemCollection aParam = new CommonItemCollection();

                                if (this.Opener is XScreen) ((XScreen)this.Opener).Command("retrieve", aParam);
                                if (this.Opener is XForm) ((XForm)this.Opener).Command("retrieve", aParam);
                                
                                try
                                {
                                    Service.BeginTransaction();

                                    if (this.grdInp1001.SaveLayout())
                                    {
                                        
                                    }
                                    else
                                    {
                                       throw new Exception(); 
                                    }
                                }
                                catch
                                {
                                    Service.RollbackTransaction();
                                        e.IsSuccess = false;
                                        if(Service.ErrFullMsg != "")
                                            XMessageBox.Show(Service.ErrFullMsg);
                                        break;
                                }

                                mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
                                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                            }

                            if (this.cbxToiwon_Goji_Yn.Checked == true)
                            {
                                //예약증 출력
                                SetGumsaJinryoPrint();

                                //식수표 출력
                                //SetNutPrint();
                            }
                        }

                    #region 간호사 아닐때
                        else // 간호사 아닐때
                        {
                            // 간호에서 퇴원고지한 경우 의사가 퇴원예고일이 없는 경우는 오늘날짜로 세팅한다
                            if (this.cbxToiwon_Goji_Yn.GetDataValue() == "Y" && TypeCheck.IsNull(this.dtpToiwon_Res_Date.GetDataValue()))
                            {
                                bool isProtect = this.dtpToiwon_Res_Date.Protect;

                                this.dtpToiwon_Res_Date.Protect = false;
                                this.dtpToiwon_Res_Date.SetDataValue(EnvironInfo.GetSysDate());
                                this.grdInp1001.SetItemValue(0, "toiwon_res_date", this.dtpToiwon_Res_Date.GetDataValue());
                                this.dtpToiwon_Res_Date.Protect = isProtect;
                            }

                            if (this.grdInp1001.RowCount > 0 && GetCheckNurseConfirmD6(grdInp1001.GetItemString(0, "bunho"), grdInp1001.GetItemString(0, "fkinp1001")))
                            {
                                mbxCap = NetInfo.Language == LangMode.Jr ? "外来検査確認" : "외래검사확인";
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "看護確認された外来検査が存在します。\n\r看護確認がされていないと退院後、該当検査が外来で表示されません。\r\n進行しますか？" : "간호확인이 안된 외래검사가 존재합니다. \r\n간호확인이 안되면 퇴원후 해당 검사가 외래에서 보이지 않습니다. \r\n진행 하시겠습니까?";

                                if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    return;
                                }
                            }

                            // 퇴원예고일이 있는 경우는 해당 퇴원예고일 이후에 처방은 삭제처리합니다..
                            if (!TypeCheck.IsNull(this.dtpToiwon_Res_Date.GetDataValue()))
                            {

                                mbxCap = NetInfo.Language == LangMode.Jr ? "削除確認" : "삭제 확인";
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "退院予告日付以降の実施されてないオーダは削除します。\r\n進行しますか？" : "퇴원예고일자 이후의 시행하지 않은 오더는 삭제합니다. \r\n진행 하시겠습니까?";

                                if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    return;
                                }
                            }

                            // 이중유형환자인 경우에 이중유형 둘다 퇴원 처리를 할 것인지 확인.
                            if (doubleCheck_processYn == "Y")
                            {

                                mbxCap = NetInfo.Language == LangMode.Jr ? "削除確認" : "이중유형확인";
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "複数保険型患者です。\r\n複数保険両方共に処理しますか？" : "이중유형환자입니다. \r\n이중유형둘다를 처리 하시겠습니까?";

                                if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    //둘다 퇴원처리를 한다는 여부를 서비스로 넘김
                                    this.grdInp1001.SetItemValue(this.grdInp1001.CurrentRowNumber, "double_yn", "Y");
                                }
                            }

                            // 신규로 퇴원예고하는 경우 
                            if (this.grdInp1001.RowCount > 0 &&
                                //this.grdInp1001.GetItemString(0, "toiwon_res_yn").Trim() != "Y" &&
                                this.cbxToiwon_Res_Yn.GetDataValue().Trim() == "Y")
                            {
                                // 미실행처방조회 창을 띄운다
                                this.OpenNoActingQuery(this.fbxBunho.GetDataValue(), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // 입원미실행처방조회 Screen Open
                            }

                            // 처방 데이타 삭제여부를 Opener에게 알린다
                            CommonItemCollection aParam = new CommonItemCollection();

                            if (this.Opener is XScreen) ((XScreen)this.Opener).Command("retrieve", aParam);
                            if (this.Opener is XForm) ((XForm)this.Opener).Command("retrieve", aParam);

                            try
                            {
                                Service.BeginTransaction();

                                if (this.grdInp1001.SaveLayout())
                                {
                                    if (this.cboResult.GetDataValue().ToString() != "")
                                    {
                                        this.cboNurResult.SetEditValue(this.cboResult.GetDataValue().ToString());
                                        this.cboNurResult.AcceptData();

                                        //if (this.btnNurToiwon.Tag.ToString() == "N")
                                        //{
                                        //    if (this.GetToiwonResult(this.grdInp1001.GetItemValue(grdInp1001.CurrentRowNumber, "bunho").ToString()
                                        //                            , this.grdInp1001.GetItemValue(grdInp1001.CurrentRowNumber, "fkinp1001").ToString()
                                        //                            , this.grdInp1001.GetItemValue(grdInp1001.CurrentRowNumber, "toiwon_res_date").ToString()) == "Y")
                                        //    {
                                        //        this.btnNurToiwon.Tag = "Y";
                                        //        this.btnNurToiwon.Text = "日誌用取消";
                                        //        this.btnNurToiwon.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
                                        //        this.btnNurToiwon.ImageIndex = 1;
                                        //    }
                                        //    else
                                        //    {
                                        //        if(Service.ErrFullMsg != "")
                                        //            XMessageBox.Show(Service.ErrFullMsg.ToString());
                                        //        return;
                                        //    }
                                        //}
                                    }

                                }
                                else
                                {
                                    throw new Exception(Service.ErrFullMsg);
                                    //XMessageBox.Show(Service.ErrFullMsg); 
                                    //e.IsSuccess = false;
                                    //break;
                                }
                                Service.CommitTransaction();
                            }
                            catch
                            {
                                Service.RollbackTransaction();
                                if (Service.ErrFullMsg != "")
                                    XMessageBox.Show(Service.ErrFullMsg);
                                e.IsSuccess = false;
                                break;                            
                            }

                            mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                        }
                    #endregion

                    }

                    //취소
                    if (this.cbxToiwon_Goji_Yn.GetDataValue().Equals("N")) //&& doubleCheck_processYn.Equals("Y"))
                    {
                        e.IsBaseCall = false; e.IsSuccess = true;
                        //SERVICE_FALG = "S";

                        if (!this.AcceptData()) { e.IsSuccess = false; break; }

                        // 입원정보 존재여부 체크
                        if (this.grdInp1001.RowCount == 0 || TypeCheck.IsNull(this.fbxBunho.GetDataValue()))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "患者情報がありません。確認してください。" : "환자정보가 없습니다. 확인하십시오.";
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
                            e.IsSuccess = false; break;
                        }

                        try
                        {
                            Service.BeginTransaction();

                            if (!this.grdInp1001.SaveLayout())
                            {
                                throw new Exception(Service.ErrFullMsg);
                                //XMessageBox.Show(Service.ErrFullMsg); 
                                //e.IsSuccess = false;
                                //break;
                            }
                            Service.CommitTransaction();
                        }
                        catch
                        {
                            Service.RollbackTransaction();
                            if (Service.ErrFullMsg != "")
                                XMessageBox.Show(Service.ErrFullMsg);
                            e.IsSuccess = false;
                            break;
                        }

                        mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                    }
     			break;
			}
		}
		#endregion

		///////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [Control's Event]
		
		#region Control Get Focus시 구동 Event (Control_Enter)
        /// <summary>
        /// 이전 Value값 Tag에 저장. 추후 Validation Chek 이전 Value로 Undo하기 위함
        /// Binding된 Grid가 있는 경우 Current Grid 세팅등도 해야함
        /// </summary>
        private void Control_Enter(object sender, System.EventArgs e)
        {
            if (sender == null) return;

            if (sender is IDataControl && sender is Control)
            {
                ((Control)sender).Tag = ((IDataControl)sender).DataValue.ToString();
            }
        }
        #endregion

        #region Control Lost Focus시 구동 Event (Control_Leave)
        /// <summary>
        /// </summary>
        private void Control_Leave(object sender, System.EventArgs e)
        {
            if (sender == null) return;
        }
        #endregion

        #region Control Value변경시 처리 Event (Control_DataValidating)
        /// <summary>
		/// Binding된 Grid가 있는 경우 Current Grid 세팅등도 해야함
		/// </summary>
		private void Control_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{	
			if (sender == null) return;
			
			string mbxMsg = "", mbxCap = "";
            //string colName = this.mOrderFunc.GetHashTableColumnName(sender); // 현재 매핑되는 컬럼명을 얻어온다
            Control ctr = sender as Control;

            switch (ctr.Name)
			{
                case "dtpToiwon_Res_Date": // 퇴원예고일

					// 퇴원예고일 세팅시 선택여부 표시	
					this.cbxToiwon_Res_Yn.CheckedChanged -= new System.EventHandler(this.Control_CheckedChanged);				
					if (!TypeCheck.IsNull(e.DataValue.ToString())) 
					{			
						if (!TypeCheck.IsDateTime(e.DataValue.ToString()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "有効な日付を入力してください。" : "일자를 정확히 입력하십시오.";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

							((IDataControl)sender).DataValue = TypeCheck.NVL(((Control)sender).Tag, "");
							((Control)sender).Focus();

							return;
						}
                        if (TypeCheck.IsInt(e.DataValue.ToString()) && TypeCheck.IsInt(this.dtpIpwon_Date.GetDataValue()))
                        {
                            if (Convert.ToInt32(e.DataValue.ToString().Replace("/", "")) < Convert.ToInt32(this.dtpIpwon_Date.GetDataValue().Replace("/", "")))
                            {
                                this.cbxToiwon_Res_Yn.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);

                                mbxMsg = NetInfo.Language == LangMode.Jr ? "退院予告日は入院日より後の日付を入力してください。" : "퇴원예고일은 입원일보다 작게 지정할수 없습니다.";
                                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

                                ((IDataControl)sender).DataValue = TypeCheck.NVL(((Control)sender).Tag, "");
                                ((Control)sender).Focus();

                                return;
                            }
                        }

                        this.dtpNurToiwon_Res_Date.SetEditValue(this.dtpToiwon_Res_Date.GetDataValue());
                        this.dtpNurToiwon_Res_Date.AcceptData();

						this.cbxToiwon_Res_Yn.Checked = true;
					}
					else
					{
						this.cbxToiwon_Res_Yn.Checked = false;
					}
					this.cbxToiwon_Res_Yn.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
					break;

                case "emToiwon_Res_Time": // 퇴원예고일자

					if (!TypeCheck.IsNull(e.DataValue.ToString()))
					{
						if (TypeCheck.IsNull(this.dtpToiwon_Res_Date.GetDataValue()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "退院予告日付を先に入力してください。" : " 퇴원예고일자를 먼저 입력하여 주십시오.";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

							((IDataControl)sender).DataValue = TypeCheck.NVL(((Control)sender).Tag, "");
							this.dtpToiwon_Res_Date.Focus();						

							return;
						}
					}
					break;

				case "result": // 퇴원사유

					if (!TypeCheck.IsNull(e.DataValue.ToString()))
					{

					}
					break;

				default:
					break;
			}
		}
		#endregion

		#region Control 더블클릭시 구동 Event (Control_DoubleClick)
        /// <summary>
        /// </summary>
        private void Control_DoubleClick(object sender, System.EventArgs e)
        {
            if (sender == null) return;
        }
        #endregion

        #region Control KeyDown Event (Control_KeyDown)
        /// <summary>
		/// </summary>
		private void Control_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (sender == null) return;		
		}
		#endregion

		#region Control Keyup Event (Control_KeyPress)
		/// <summary>
		/// </summary>
		private void Control_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (sender == null) return;		
		}
		#endregion

        #region Check Control Check Changed시 구동 Event (Control_CheckedChanged)
        /// <summary>
        /// </summary>
        private void Control_CheckedChanged(object sender, System.EventArgs e)
        {
            if (sender == null) return;

            if (sender.GetType().Name.ToString().IndexOf("XCheckBox") < 0 && (sender.GetType().Name.ToString().IndexOf("XRadioButton") < 0)) return;

            XCheckBox cb = sender as XCheckBox;

            //string colName = this.mOrderFunc.GetHashTableColumnName(sender); // 현재 매핑되는 컬럼명을 얻어온다

            if(cb.Name == "cbxToiwon_Res_Yn")
            {// 퇴원예고여부

                    // 현재일자 세팅
                    if (cb.Checked)
                    {
                        this.dtpToiwon_Res_Date.Focus();
                        this.dtpToiwon_Res_Date.SetEditValue(IHIS.Framework.EnvironInfo.GetSysDate());
                        this.dtpToiwon_Res_Date.AcceptData();
                        this.emToiwon_Res_Time.Focus();
                        this.emToiwon_Res_Time.SetEditValue("1200");
                        this.emToiwon_Res_Time.AcceptData();
                    }
                    else
                    {
                        this.dtpToiwon_Res_Date.Focus();
                        this.dtpToiwon_Res_Date.SetEditValue("");
                        this.dtpToiwon_Res_Date.AcceptData();
                        this.emToiwon_Res_Time.Focus();
                        this.emToiwon_Res_Time.SetEditValue("");
                        this.emToiwon_Res_Time.AcceptData();
                    }
            }
            else if(cb.Name ==  "cbxToiwon_Goji_Yn")
            {// 처방종료

                    if (cb.Checked)
                    {
                        if (this.dtpSigi_Magam_Date.GetDataValue() == "")
                        {
                            this.dtpSigi_Magam_Date.SetEditValue(EnvironInfo.GetSysDate()); // 디폴트 오늘날짜
                            this.dtpSigi_Magam_Date.AcceptData();
                        }
                        if (this.cboKi_Gubun.GetDataValue() == "")
                        {
                            this.cboKi_Gubun.SetEditValue("1"); // 디폴트 중식
                            this.cboKi_Gubun.AcceptData();
                        }

                        if (this.cboNurResult.GetDataValue().ToString() != "")
                        {
                            if (this.cboResult.GetDataValue().ToString() == "")
                            {
                                this.cboResult.SetEditValue(this.cboNurResult.GetDataValue().ToString());
                                this.cboResult.AcceptData();
                            }
                        }
                    }
                    else
                    {
                        this.dtpSigi_Magam_Date.SetEditValue("");
                        this.dtpSigi_Magam_Date.AcceptData();
                        this.cboKi_Gubun.SetEditValue("");
                        this.cboKi_Gubun.AcceptData();
                        this.cboResult.SetEditValue("");
                        this.cboResult.AcceptData();
                    }
            }
        }
        #endregion

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
		
		#region [외래검사미확인건 CHECK]
        
		/// <summary>
		/// 외래검사미확인건 CHECK
		/// </summary>
		private bool GetCheckNurseConfirmD6(string aBunho, string aPkinp1001)
		{
            bool checkValue = false;
            layChkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layChkCommon.SetBindVarValue("f_bunho", aBunho);
            layChkCommon.SetBindVarValue("f_pkinp1001", aPkinp1001);

            if (!this.layChkCommon.QueryLayout())
                checkValue = false;
            else
            {
                if (this.layChkCommon.GetItemValue("chk").ToString() == "Y")
                    checkValue = true;
                else
                    checkValue = false;
            }

			
			return checkValue;
		}

		#endregion

        #region 퇴원여부 저장 처리후 이벤트

        //private void dsvSetToiwonYn_ServiceEnd(object sender, IHIS.Framework.ServiceEndArgs e)
        //{
        //    //20100513 edit start
        //    string pram_bunho = string.Empty;
        //    string pram_pkinp1001 = string.Empty;
        //    string pram_toiwon_res_date = string.Empty;
        //    string result_Yn = string.Empty;

        //    if(e.Result == SvcResult.OK)
        //    {
        //        SetMsg("正常に保存になりました。");

        //        pram_bunho = this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "bunho").ToString;
        //        pram_pkinp1001 = this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "fkinp1001").ToString;
        //        pram_toiwon_res_date = this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "dtpNurToiwon_Res_Date").ToString;
        //        result_Yn = GetToiwonResult(pram_bunho, pram_pkinp1001, pram_toiwon_res_date);

        //        if ((int)result_Yn.Length != 0)//this.DataServiceCall(this.dsvToiwonYn))
        //        {
        //            if (result_Yn == "Y")
        //            {
        //                this.btnNurToiwon.Tag = "Y";
        //                this.btnNurToiwon.Text = "日誌用取消";
        //                this.btnNurToiwon.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
        //                this.btnNurToiwon.ImageIndex = 1;
        //            }
        //            else
        //            {
        //                this.btnNurToiwon.Tag = "N";
        //                this.btnNurToiwon.Text = "日誌用退院";
        //                if (this.grdInp1001.GetItemValue(this.grdInp1001.CurrentRowNumber, "toiwon_res_date").ToString() != "")
        //                {
        //                    this.dtpNurToiwon_Res_Date.SetEditValue(this.grdInp1001.GetItemValue(this.grdInp1001.CurrentRowNumber, "toiwon_res_date").ToString());
        //                    this.dtpNurToiwon_Res_Date.AcceptData();
        //                }
        //                else
        //                {
        //                    this.dtpNurToiwon_Res_Date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
        //                    this.dtpNurToiwon_Res_Date.AcceptData();
        //                }
        //                this.btnNurToiwon.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
        //                this.btnNurToiwon.ImageIndex = 0;
        //            }
        //        }
        //        else
        //        {
        //            XMessageBox.Show(Service.ErrFullMsg.ToString());
        //            return;
        //        }
        //        return;
        //    } //20100513 edit end
        //    else
        //    {
        //        return;
        //    }
        //}
        #endregion

        

		private void btnNurToiwon_Click(object sender, System.EventArgs e)
		{
			string mbxCap = string.Empty;
			string mbxMsg = string.Empty;
            string i_bunho           = this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber,"bunho");
            string i_fkinp1001       = this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber,"fkinp1001");
            string i_toiwon_res_date = this.dtpToiwon_Res_Date.GetDataValue().ToString();
            string i_nur_result      = this.cboResult.GetDataValue().ToString();
            
            //if (this.btnNurToiwon.Tag.ToString() == "N")
            //{
            //    mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
            //    mbxMsg = NetInfo.Language == LangMode.Jr ? "病棟日誌用退院処理をしますか。" : "병동일지용 퇴원처리를 하시겠습니까?";

            //    if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
            //        return;

            //    bool flgYn = SetToiwonYn("Y",i_bunho,i_fkinp1001,i_toiwon_res_date,i_nur_result);

            //    //this.dsvSetToiwonYn.SetInValue("toiwon_yn", "Y");

            //    if (flgYn == true)//this.DataServiceCall(this.dsvSetToiwonYn)
            //    {
            //        this.btnNurToiwon.Tag = "Y";
            //        this.btnNurToiwon.Text = "日誌用取消";
            //        this.btnNurToiwon.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            //        this.btnNurToiwon.ImageIndex = 1;
            //    }
            //    else
            //    {
            //        XMessageBox.Show(Service.ErrFullMsg.ToString());
            //        return;
            //    }
            //}
            //else
            //{
            //    mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
            //    mbxMsg = NetInfo.Language == LangMode.Jr ? "病棟日誌用退院処理を取消しますか。" : "병동일지용 퇴원처리를 취소 하시겠습니까?";

            //    if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
            //        return;
            //    bool flgYn = SetToiwonYn("N",i_bunho,i_fkinp1001,i_toiwon_res_date,i_nur_result);
            //    //this.dsvSetToiwonYn.SetInValue("toiwon_yn", "N");

            //    if (flgYn == true)
            //    {
            //        this.btnNurToiwon.Tag = "N";
            //        this.btnNurToiwon.Text = "日誌用退院";
            //        this.btnNurToiwon.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            //        this.btnNurToiwon.ImageIndex = 0;
            //    }
            //    else
            //    {
            //        XMessageBox.Show(Service.ErrFullMsg.ToString());
            //        return;
            //    }
            //}
		}
        

		#region 검사(진료)예약표출력
		private void SetGumsaJinryoPrint()
		{
			CommonItemCollection openParams = new CommonItemCollection();
			openParams.Add("auto_close"    , "Y");
			openParams.Add("total_query_yn", "Y");
			openParams.Add("bunho"         , this.fbxBunho.GetDataValue().ToString());
			openParams.Add("reser_date"    , this.dtpToiwon_Res_Date.GetDataValue().ToString());
			openParams.Add("gwa"           , "%");

			XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R99", ScreenOpenStyle.ResponseSizable, openParams);
		}
		#endregion

		#region 식수표 출력
		private void SetNutPrint()
		{
			CommonItemCollection openParams = new CommonItemCollection();

			openParams.Add("fkinp1001"    , this.grdInp1001.GetItemValue(this.grdInp1001.CurrentRowNumber, "fkinp1001").ToString());

			XScreen.OpenScreenWithParam(this, "NUTS", "NUT3003Q99", ScreenOpenStyle.ResponseSizable, openParams);
		}
		#endregion

		#region XSavePerformer
        //20100513 edit start
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS2003U99 parent = null;
            public XSavePerformer(OCS2003U99 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                ArrayList arInParam = new ArrayList();
                ArrayList arOutParam = new ArrayList();

                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                if (UserInfo.UserGubun == UserType.Doctor)
                    item.BindVarList.Add("q_user_id", UserInfo.DoctorID);
                else
                    item.BindVarList.Add("q_user_id", UserInfo.UserID);

                
                switch (item.RowState)
                {
                    case DataRowState.Added:

                        //parent.SERVICE_FALG = null;
                        break;

                    case DataRowState.Modified :

                        //if (parent.SERVICE_FALG == null)
                        //{
                        //    break;
                        //}

                        //if (parent.SERVICE_FALG.Equals("S"))
                        //{
                            //퇴원 고지 여부에 따라 약국 반납 처방 확인
                            if (item.BindVarList["f_toiwon_goji_yn"].VarValue == "Y")
                            {
                                bool gojiResult = Service.ExecuteProcedure("PR_DRG_AUTO_OCS_BANNAB"
                                                                           ,item.BindVarList["f_toiwon_res_date"].VarValue
                                                                           ,"AUTO"
                                                                           , item.BindVarList["f_fkinp1001"].VarValue);

                                if (!gojiResult)
                                    throw new Exception();

                                arInParam.Add(item.BindVarList["f_fkinp1001"].VarValue);
                                arInParam.Add(item.BindVarList["f_bunho"].VarValue);

                                if (Service.ExecuteProcedure("PR_OCSI_CHECK_BANNAB_ACTING", arInParam, arOutParam))
                                {
                                    if (!TypeCheck.IsNull(arOutParam[0]))
                                    {
                                        if (arOutParam[0].ToString() == "Y")
                                        {
                                            XMessageBox.Show("未出力された薬の返納があります。返納リストを出力してください。");
                                            return false;
                                        }
                                    }
                                }
                                else
                                    throw new Exception();

                            }

                            //퇴원 여부 체크
                            cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS (SELECT 'Y'
                                                         FROM INP1001 A
                                                        WHERE A.HOSP_CODE = :f_hosp_code  
                                                          AND A.PKINP1001 = TO_NUMBER(NVL(TRIM(:f_fkinp1001),'0'))
                                                          AND (A.GA_TOIWON_DATE IS NOT NULL OR A.TOIWON_DATE IS NOT NULL))";


                            object result = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if (result != null && result.ToString() != "Y")
                            {
                                XMessageBox.Show("退院処理された患者です。確認してください。");
                                return false;

                            }

                            if (item.BindVarList["f_toiwon_goji_yn"].VarValue == "Y")
                            {                                
                                //미마감 퇴원약 체크
                                 cmdText = @"SELECT FN_DRG_TOIWON_ORDER_CHK(TRUNC(SYSDATE) 
                                                                         , :f_bunho
                                                                         , TO_NUMBER(NVL(TRIM(:f_fkinp1001),'0'))
                                                                           )
                                               FROM DUAL";
                           
                                 object aResult = Service.ExecuteScalar(cmdText, item.BindVarList);

                                 if (!TypeCheck.IsNull(aResult))
                                 {
                                     if (aResult.ToString() == "Y")
                                     {
                                         XMessageBox.Show("退院オーダ箋が未出力されました。（電算室問い合わせ）");
                                         return false;
                                     }
                                 }
                             }

                                /* 미시행검사 외래검사로 변경 */
                                ArrayList alInput = new ArrayList();
                                ArrayList alOutput = new ArrayList();

                                alInput.Add(item.BindVarList["f_bunho"].VarValue);
                                alInput.Add(item.BindVarList["f_fkinp1001"].VarValue);
                                alInput.Add(item.BindVarList["f_toiwon_goji_yn"].VarValue);
                                if (UserInfo.UserGubun == UserType.Doctor)
                                    alInput.Add(UserInfo.DoctorID);
                                else
                                    alInput.Add(UserInfo.UserID);

                                if (!Service.ExecuteProcedure("PR_OCS_TRANS_INPUT_GUBUN_D6", alInput, alOutput))
                                    throw new Exception();

                                if (alOutput[1].ToString() != "0")
                                {
                                    XMessageBox.Show("PR_OCS_TRANS_INPUT_GUBUN_D6 Error " + alOutput[1].ToString() + " / " + alOutput[0].ToString() + "\r\n" + Service.ErrFullMsg);
                                    return false;
                                }

                                /* 퇴원예고일 이후의 미시행 처방 자동 삭제 처리 */
                                /* INP1001 UPDATE보다 먼저 일어나야함.
                                   INP1001 트리거에서 식사 금액 재발생 처리하기위해서
                                   식사오다를 먼저정리해야 한다 */

                                if (item.BindVarList["f_toiwon_res_date"] != null   &&  (item.BindVarList["f_toiwon_res_date"].VarValue.Trim().Length > 0 
                                                                                    && item.BindVarList["f_toiwon_goji_yn"].VarValue == "Y"))
                                {
                                    alInput.Clear();
                                    alOutput.Clear();

                                    if (UserInfo.UserGubun == UserType.Doctor)
                                        alInput.Add(UserInfo.DoctorID);
                                    else
                                        alInput.Add(UserInfo.UserID);

                                    alInput.Add(item.BindVarList["f_bunho"].VarValue);
                                    alInput.Add(item.BindVarList["f_fkinp1001"].VarValue);
                                    alInput.Add(item.BindVarList["f_toiwon_res_date"].VarValue);
                                    //alInput.Add(item.BindVarList["f_sigi_magam_date"].VarValue);
                                    alInput.Add(DBNull.Value);//어차피 널이므로
                                    alInput.Add(item.BindVarList["f_ki_gubun"].VarValue);

                                    if (!Service.ExecuteProcedure("PR_OCS_DELETE_INP_ORDER_TOIWON", alInput, alOutput))
                                        throw new Exception();

                                    if (alOutput[1].ToString().CompareTo("0") != 0)
                                    {
                                        XMessageBox.Show(alOutput[0].ToString());
                                        return false;
                                    }

                                }

                            cmdText = @" SELECT DECODE(:f_toiwon_res_date,'',DECODE(TOIWON_RES_DATE,NULL,'00','09'),
			                                    DECODE(TOIWON_RES_DATE,NULL,'01','02')) IUD_GUBUN
			   			                   FROM INP1001
			                              WHERE HOSP_CODE = :f_hosp_code 
                                            AND PKINP1001 = TO_NUMBER(NVL(TRIM(:f_fkinp1001),'0'))
			                                AND ROWNUM    = 1";
                            object iud_gubun = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if (item.BindVarList["f_double_yn"].VarValue.CompareTo("Y") == 0)
                            {
                                if (item.BindVarList["f_toiwon_res_date"].VarValue != "")
                                    ExeInp1001Update(item, "Y");
                                else
                                    ExeInp1001Update(item, "N");
                            }
                            else
                            {
                                if (item.BindVarList["f_toiwon_res_time"].VarValue != "")
                                    /* 정상유형만 퇴원처리 */
                                    ExeInp1001Update(item, "1");
                                else
                                    ExeInp1001Update(item, "2");
                            }

              
                            cmdText = @" SELECT 'Y'
                                           FROM DUAL
                                          WHERE TRUNC(SYSDATE) = TO_DATE(:f_toiwon_res_date, 'YYYY/MM/DD')";
                            object rtn_value = Service.ExecuteScalar(cmdText, item.BindVarList);
                            string isExist = "";
                            if (!TypeCheck.IsNull(rtn_value))
                            { 
                                isExist = rtn_value.ToString();
                            }
                            
                            #region 의사가 당일 퇴원예고처리시
                            if (isExist == "Y" && UserInfo.UserGubun == UserType.Doctor)
                            {
                                cmdText = @"SELECT A.IP_ADDR                                               t_ho_dong_ip
                                                 , TO_CHAR(B.PKINP1001)
                                                   ||','||B.BUNHO
                                                   ||','||B.HO_CODE1
		                                           ||','||B.BED_NO
                                                   ||','||FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR,B.IPWON_DATE)
		                                           ||','||C.SUNAME                                         t_ipwon_msg
		                                      FROM NUR0106 A
                                                 , INP1001 B
                                                 , OUT0101 C
	                                         WHERE A.HOSP_CODE = :f_hosp_code 
                                               AND B.HOSP_CODE = A.HOSP_CODE
                                               AND C.HOSP_CODE = A.HOSP_CODE
                                               AND B.PKINP1001 = TO_NUMBER(NVL(TRIM(:f_fkinp1001),'0'))
		                                       AND B.HO_DONG1  = A.HO_DONG
		                                       AND B.BUNHO     = C.BUNHO";

                                
                                DataTable dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(dt))
                                {
                                    if (dt.Rows.Count > 0 )
                                    {
                                        for(int i = 0 ; i <dt.Rows.Count ; i++)
                                        {
                                            //SendToSystem(dt.Rows[i]["t_ho_dong_ip"].ToString(), "NURI", "TOIWONMSG", dt.Rows[i]["t_ipwon_msg"].ToString());
                                        }
                                    }
                                }

                                if (Service.ErrCode != 0)
                                {
                                    if(Service.ErrFullMsg != "")
                                        XMessageBox.Show(Service.ErrFullMsg);
                                    return false;
                                }
                            }

                            if (iud_gubun != null && iud_gubun.ToString().Equals("00"))
                            {
                                break;
                            }

                            #endregion

                            //parent.SERVICE_FALG = null;
                
                        //}

//                        if (parent.SERVICE_FALG.Equals("3"))
//                        {
//                            //퇴원 여부 체크
//                            cmdText = @"SELECT 'Y'
//                                          FROM DUAL
//                                         WHERE EXISTS (SELECT 'Y'
//                                                         FROM INP1001 A
//                                                        WHERE A.HOSP_CODE = :f_hosp_code 
//                                                          AND A.PKINP1001 = TO_NUMBER(NVL(TRIM(:f_fkinp1001),'0'))
//                                                          AND (A.GA_TOIWON_DATE IS NOT NULL OR A.TOIWON_DATE IS NOT NULL))";


//                            object result = Service.ExecuteScalar(cmdText, item.BindVarList);

//                            if (result.ToString() != "Y" || result.ToString() == null)
//                            {
//                                XMessageBox.Show("退院処理された患者です。確認してください。");
//                                return false;
//                            }
//                            /* INP1001 UPDATE보다 먼저 일어나야함.
//                               INP1001 트리거에서 식사 금액 재발생 처리하기위해서
//                               식사오다를 먼저정리해야 한다 */

//                            if (item.BindVarList["f_toiwon_res_date"].VarValue.Trim().Length > 0
//                                                                          && item.BindVarList["f_toiwon_goji_yn"].VarValue == "Y")
//                            {
//                                try
//                                {
//                                    cmdText = @"UPDATE OCS3003
//                                                   SET UPD_ID         = :q_user_id
//                                                      ,UPD_DATE       = SYSDATE 
//                                                      ,NUT_GUBUN      = 'X099'
//                                                      ,BUN_CODE1      = 'X0'
//                                                      ,BUN_CODE2      = '99'
//                                                      ,BUN_CODE3      = NULL
//                                                      ,BUN_CODE4      = NULL
//                                                      ,LATE_EAT_YN    = 'N'
//                                                      ,GUMGI1         = NULL
//                                                      ,GUMGI2         = NULL
//                                                      ,GUMGI3         = NULL
//                                                      ,GUMGI4         = NULL
//                                                      ,PRINT_YN       = 'N'
//                                                      ,KUMSIG_GUBUN   = '1'
//                                                      ,NUT_GIHO_CODE  = NULL
//                                                      ,NUT_GIHO_CODE2 = NULL
//                                                      ,NUT_GIHO_CODE3 = NULL
//                                                      ,REMARK         = NULL
//                                                      ,BOHOJASIK_YN   = 'N'
//                                                      ,CC             = NULL
//                                                      ,HOISU          = NULL
//                                                      ,CALORY         = NULL
//                                                      ,ALBUMIN        = NULL
//                                                      ,SALT           = NULL
//                                                      ,KAL            = NULL
//                                                      ,FAT            = NULL
//                                                WHERE HOSP_CODE       = :f_hosp_code
//                                                  AND BUNHO           = :f_bunho
//                                                  AND FKINP1001       = :f_fkinp1001
//                                                  AND ORDER_DATE      >= NVL(:f_sigi_magam_date, TO_DATE('9999/12/31','YYYY/MM/DD'))
//                                                  AND ((ORDER_DATE  = NVL(:f_sigi_magam_date, TO_DATE('9999/12/31','YYYY/MM/DD')) 
//                                                                  AND KI_GUBUN > NVL(:f_ki_gubun, 'X'))
//                                                   OR (ORDER_DATE   > NVL(:f_sigi_magam_date, TO_DATE('9999/12/31','YYYY/MM/DD'))))";

//                                    if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                                        throw new Exception();                               
//                                }
//                                catch (Exception x)
//                                {
//                                    XMessageBox.Show(Service.ErrFullMsg.ToString());
//                                    x.StackTrace.ToString();
//                                    return false;
//                                }
//                            }


//                            if (item.BindVarList["f_double_yn"] != null && item.BindVarList["f_double_yn"].VarValue.Equals("Y"))
//                            {
//                                /* 이중유형까지 퇴원처리 */
//                                ExeDupInp1001Update(item, "Y");
//                            }
//                            else
//                            {
//                                ExeInp1001Update(item, "N");
//                            }
                            
//                            parent.SERVICE_FALG = null;
                               
//                        }
                        break;
                    case DataRowState.Deleted:
                        //parent.SERVICE_FALG = null;
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }


            private void ExeInp1001Update(RowDataItem rwItem, string flg)
            {
                BindVarCollection updBindVar = new BindVarCollection();

                string strSql = "";

                switch (flg)
                {
                    case "Y":
                        strSql = @"  UPDATE INP1001
                                        SET UPD_ID              = :q_user_id
                                          , UPD_DATE            = SYSDATE
                                          , TOIWON_RES_DATE     = TO_DATE(:f_toiwon_res_date, 'YYYY/MM/DD')
                                          --, TOIWON_RES_TIME     = TO_DATE(:f_toiwon_res_date||' '||:f_toiwon_res_time, 'YYYY/MM/DD HH24:MI')
                                          , TOIWON_RES_TIME     = :f_toiwon_res_time
                                          , TOIWON_GOJI_YN      = :f_toiwon_goji_yn
                                          , SIGI_MAGAM_DATE     = TO_DATE(:f_sigi_magam_date, 'YYYY/MM/DD')
                                          , SIGI_MAGAM_YN       = DECODE(:f_sigi_magam_date,NULL,'N','Y')
                                          , KI_GUBUN            = :f_ki_gubun
                                          , RESULT              = :f_result
                                     WHERE HOSP_CODE            = :f_hosp_code 
                                       AND BUNHO                = :f_bunho
                                       AND NVL(CANCEL_YN, 'N')  = 'N'
                                       AND JAEWON_FLAG          = 'Y'";

                        updBindVar.Add("f_hosp_code", EnvironInfo.HospCode);

                        if (UserInfo.UserGubun == UserType.Doctor)
                            updBindVar.Add("q_user_id", UserInfo.DoctorID);
                        else
                            updBindVar.Add("q_user_id", UserInfo.UserID);

                        updBindVar.Add("f_toiwon_res_date", rwItem.BindVarList["f_toiwon_res_date"].VarValue);
                        updBindVar.Add("f_toiwon_res_time", rwItem.BindVarList["f_toiwon_res_time"].VarValue);
                        updBindVar.Add("f_toiwon_goji_yn", rwItem.BindVarList["f_toiwon_goji_yn"].VarValue);
                        updBindVar.Add("f_sigi_magam_date", rwItem.BindVarList["f_sigi_magam_date"].VarValue);
                        updBindVar.Add("f_ki_gubun", rwItem.BindVarList["f_ki_gubun"].VarValue);
                        updBindVar.Add("f_result", rwItem.BindVarList["f_result"].VarValue);
                        updBindVar.Add("f_bunho", rwItem.BindVarList["f_bunho"].VarValue);
                        break;

                    case "N":
                        strSql = @"UPDATE INP1001
                                     SET UPD_ID             = :q_user_id
                                       , UPD_DATE            = SYSDATE
                                       , TOIWON_RES_DATE     = NULL
                                       , TOIWON_RES_TIME     = NULL
                                       , TOIWON_GOJI_YN      = 'N'
                                       , SIGI_MAGAM_DATE     = NULL
                                       , SIGI_MAGAM_YN       = NULL
                                       , KI_GUBUN            = NULL
                                       , RESULT              = NULL
                                   WHERE HOSP_CODE           = :f_hosp_code
                                     AND BUNHO               = :f_bunho
                                     AND NVL(CANCEL_YN, 'N') = 'N'
                                     AND JAEWON_FLAG         = 'Y'";

                        updBindVar.Add("f_hosp_code", EnvironInfo.HospCode);

                        if (UserInfo.UserGubun == UserType.Doctor)
                            updBindVar.Add("q_user_id", UserInfo.DoctorID);
                        else
                            updBindVar.Add("q_user_id", UserInfo.UserID);

                        updBindVar.Add("f_bunho", rwItem.BindVarList["f_bunho"].VarValue);
                        break;

                    case "1" :
                        strSql = @"UPDATE INP1001
                                      SET UPD_ID         = :q_user_id
                                        , UPD_DATE        = SYSDATE
                                        , TOIWON_RES_DATE = TO_DATE(:f_toiwon_res_date, 'YYYY/MM/DD')
                                        --, TOIWON_RES_TIME = TO_DATE(:f_toiwon_res_date||' '||:f_toiwon_res_time, 'YYYY/MM/DD HH24:MI')
                                        , TOIWON_RES_TIME     = :f_toiwon_res_time
                                        , TOIWON_GOJI_YN  = :f_toiwon_goji_yn
                                        , SIGI_MAGAM_DATE = TO_DATE(:f_sigi_magam_date, 'YYYY/MM/DD')
                                        , SIGI_MAGAM_YN   = DECODE(:f_sigi_magam_date,NULL,'N','Y')
                                        , KI_GUBUN        = :f_ki_gubun
                                        , RESULT          = :f_result
                                    WHERE HOSP_CODE       = :f_hosp_code
                                      AND PKINP1001       = TO_NUMBER(NVL(TRIM(:f_fkinp1001),'0'))";

                        updBindVar.Add("f_hosp_code", EnvironInfo.HospCode);

                        if (UserInfo.UserGubun == UserType.Doctor)
                            updBindVar.Add("q_user_id", UserInfo.DoctorID);
                        else
                            updBindVar.Add("q_user_id", UserInfo.UserID);

                        updBindVar.Add("f_toiwon_res_date", rwItem.BindVarList["f_toiwon_res_date"].VarValue);
                        updBindVar.Add("f_toiwon_res_time", rwItem.BindVarList["f_toiwon_res_time"].VarValue);
                        updBindVar.Add("f_toiwon_goji_yn", rwItem.BindVarList["f_toiwon_goji_yn"].VarValue);
                        updBindVar.Add("f_sigi_magam_date", rwItem.BindVarList["f_sigi_magam_date"].VarValue);
                        updBindVar.Add("f_ki_gubun", rwItem.BindVarList["f_ki_gubun"].VarValue);
                        updBindVar.Add("f_result", rwItem.BindVarList["f_result"].VarValue);
                        updBindVar.Add("f_bunho", rwItem.BindVarList["f_bunho"].VarValue);
                        updBindVar.Add("f_fkinp1001", rwItem.BindVarList["f_fkinp1001"].VarValue);
                        break;

                    case "2":
                        strSql = @"UPDATE INP1001
                                      SET UPD_ID          = :q_user_id
                                        , UPD_DATE        = SYSDATE
                                        , TOIWON_RES_DATE = NULL
                                        , TOIWON_RES_TIME = NULL
                                        , TOIWON_GOJI_YN  = 'N'
                                        , SIGI_MAGAM_DATE = NULL
                                        , SIGI_MAGAM_YN   = NULL
                                        , KI_GUBUN        = NULL
                                        , RESULT          = NULL
                                   WHERE HOSP_CODE        = :f_hosp_code
                                      AND PKINP1001       = TO_NUMBER(NVL(TRIM(:f_fkinp1001),'0'))";

                        updBindVar.Add("f_hosp_code", EnvironInfo.HospCode);

                        if (UserInfo.UserGubun == UserType.Doctor)
                            updBindVar.Add("q_user_id", UserInfo.DoctorID);
                        else
                            updBindVar.Add("q_user_id", UserInfo.UserID);

                        updBindVar.Add("f_fkinp1001", rwItem.BindVarList["f_fkinp1001"].VarValue);
                        break;
                }
                if (!Service.ExecuteNonQuery(strSql, updBindVar))
                    throw new Exception(Service.ErrFullMsg);
            }


//            private void ExeDupInp1001Update(RowDataItem rwItem, string flg)
//            {
//                BindVarCollection updBindVar = new BindVarCollection();

//                string strSql = "";
//                switch (flg)
//                {
//                    case "Y":
//                        strSql = @"UPDATE INP1001
//                                 SET UPD_ID              = :q_user_id
//                                   , UPD_DATE            = SYSDATE
//                                   , TOIWON_RES_DATE     = TO_DATE(:f_toiwon_res_date, 'YYYY/MM/DD')
//                                   --, TOIWON_RES_TIME     = TO_DATE(:f_toiwon_res_date||' '||:f_toiwon_res_time, 'YYYY/MM/DD HH24:MI')
//                                   , TOIWON_RES_TIME     = :f_toiwon_res_time
//                                   , TOIWON_GOJI_YN      = :f_toiwon_goji_yn
//                                   , SIGI_MAGAM_DATE     = TO_DATE(:f_sigi_magam_date, 'YYYY/MM/DD')
//                                   , SIGI_MAGAM_YN       = DECODE(:f_sigi_magam_date,NULL,'N','Y')
//                                   , KI_GUBUN            = :f_ki_gubun
//                                   , RESULT              = :f_result
//                               WHERE HOSP_CODE           = :f_hosp_code
//                                 AND BUNHO               = :f_bunho
//                                 AND NVL(CANCEL_YN, 'N') = 'N'
//                                 AND JAEWON_FLAG         = 'Y'";

//                        updBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
//                        updBindVar.Add("q_user_id", UserInfo.UserID);
//                        updBindVar.Add("f_toiwon_res_date", rwItem.BindVarList["f_toiwon_res_date"].VarValue);
//                        updBindVar.Add("f_toiwon_res_time", rwItem.BindVarList["f_toiwon_res_time"].VarValue);
//                        updBindVar.Add("f_toiwon_goji_yn", rwItem.BindVarList["f_toiwon_goji_yn"].VarValue);
//                        updBindVar.Add("f_sigi_magam_date", rwItem.BindVarList["f_sigi_magam_date"].VarValue);
//                        updBindVar.Add("f_ki_gubun", rwItem.BindVarList["f_ki_gubun"].VarValue);
//                        updBindVar.Add("f_result", rwItem.BindVarList["f_result"].VarValue);
//                        updBindVar.Add("f_bunho", rwItem.BindVarList["f_bunho"].VarValue);

//                        break;

//                    case "N":
//                        strSql = @" UPDATE INP1001
//                                       SET UPD_ID          = :q_user_id
//                                         , UPD_DATE        = SYSDATE
//                                         , TOIWON_RES_DATE = TO_DATE(:f_toiwon_res_date, 'YYYY/MM/DD')
//                                         /*
//                                         , TOIWON_RES_TIME = DECODE(:f_toiwon_res_date, '', TO_DATE(''),
//                                                                    TO_DATE(:f_toiwon_res_date||' '||:f_toiwon_res_time,
//                                                                    'YYYY/MM/DD HH24MI')) */
//                                         , TOIWON_RES_TIME     = :f_toiwon_res_time
//                                         , TOIWON_GOJI_YN  = NVL(:f_toiwon_goji_yn, 'N')
//                                         , SIGI_MAGAM_DATE = TO_DATE(:f_sigi_magam_date, 'YYYY/MM/DD')
//                                         , SIGI_MAGAM_YN   = DECODE(:f_sigi_magam_date,NULL,'N','Y')
//                                         , KI_GUBUN        = :f_ki_gubun
//                                         , RESULT          = :f_result
//                                     WHERE HOSP_CODE       = :f_hosp_code
//                                       AND PKINP1001       = TO_NUMBER(NVL(TRIM(:f_fkinp1001),'0'))";

//                        updBindVar.Add("f_hosp_code",EnvironInfo.HospCode);
//                        updBindVar.Add("q_user_id", UserInfo.UserID);
//                        updBindVar.Add("f_bunho", rwItem.BindVarList["f_bunho"].ToString());
//                        updBindVar.Add("f_toiwon_res_date", rwItem.BindVarList["f_toiwon_res_date"].VarValue);
//                        updBindVar.Add("f_toiwon_res_time", rwItem.BindVarList["f_toiwon_res_time"].VarValue);
//                        updBindVar.Add("f_toiwon_goji_yn", rwItem.BindVarList["f_toiwon_goji_yn"].VarValue);
//                        updBindVar.Add("f_sigi_magam_date", rwItem.BindVarList["f_sigi_magam_date"].VarValue);
//                        updBindVar.Add("f_ki_gubun", rwItem.BindVarList["f_ki_gubun"].VarValue);
//                        updBindVar.Add("f_result", rwItem.BindVarList["f_result"].VarValue);
//                        updBindVar.Add("f_fkinp1001", rwItem.BindVarList["f_fkinp1001"].VarValue);

//                        break;
//                }

//                if (!Service.ExecuteNonQuery(strSql, updBindVar))
//                    throw new Exception(Service.ErrFullMsg);
//            }
        }
        #endregion

        private void grdInp1001_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (!e.IsSuccess)
                return;

            if (this.cboResult.GetDataValue().ToString() != "")
            {
                this.cboNurResult.SetEditValue(this.cboResult.GetDataValue().ToString());
                this.cboNurResult.AcceptData();

                //if (this.btnNurToiwon.Tag.ToString() == "N")
                //{
                //    if (this.SetToiwonYn("Y", this.grdInp1001.GetItemString(grdInp1001.CurrentRowNumber, "bunho")
                //                          , this.grdInp1001.GetItemString(grdInp1001.CurrentRowNumber, "fkinp1001")
                //                          , this.dtpNurToiwon_Res_Date.GetDataValue(), this.cboNurResult.GetDataValue()))
                //    { }
                //    //if (this.GetToiwonResult(this.grdInp1001.GetItemValue(grdInp1001.CurrentRowNumber, "bunho").ToString()
                //    //                        , this.grdInp1001.GetItemValue(grdInp1001.CurrentRowNumber, "fkinp1001").ToString()
                //    //                        , this.grdInp1001.GetItemValue(grdInp1001.CurrentRowNumber, "toiwon_res_date").ToString()) == "Y")
                //    //{
                //    //    this.btnNurToiwon.Tag = "Y";
                //    //    this.btnNurToiwon.Text = "日誌用取消";
                //    //    this.btnNurToiwon.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
                //    //    this.btnNurToiwon.ImageIndex = 1;
                //    //}
                //    //else
                //    //{
                //    //    XMessageBox.Show(Service.ErrFullMsg.ToString());
                //    //    return;
                //    //}
                //}
            }
        }
        //201005 edit end
    }
}
