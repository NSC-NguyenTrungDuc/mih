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
	/// ORDERTRANS에 대한 요약 설명입니다.
	/// </summary>
    [ToolboxItem(false)]

	public class INPBATCHTRANS : IHIS.Framework.XScreen
	{
        private IHIS.Framework.XPanel pnlSerch;
        private IHIS.Framework.XPanel pnlGrid;
        private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel pnlProgressBar;
		private IHIS.Framework.XProgressBar pgbProgress;
		private System.Windows.Forms.Label lbTransHangmog;
        private System.Windows.Forms.Label lbTransCnt;
        private XDisplayBox dbxSuname;
        private XFindBox fbxBunho;
        private XLabel xLabel3;
        private ToolTip toolTip1;
        private XFindWorker fwkFind;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private XEditGridCell xEditGridCell170;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell206;
        private XMonthBox monthBox;
        private XRadioButton rbnMiTrans;
        private XRadioButton rbnTrans;
        private XEditGrid grdInpList;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell130;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell191;
        private XEditGridCell xEditGridCell182;
        private XLabel xLabel1;
        private XPanel xPanel1;
        private XLabel xLabel2;
        private XDictComboBox cbxBuseo;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell6;
        private SingleLayout layOut0101;
        private SingleLayoutItem singleLayoutItem1;
        private XEditGridCell xEditGridCell7;
        private XButton btnINPORDERTRANS;
        private XDatePicker dtpJunsongToDate;
        private XDatePicker dtpJunsongFromDate;
        private IContainer components;

        public INPBATCHTRANS()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INPBATCHTRANS));
            this.pnlSerch = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.rbnTrans = new IHIS.Framework.XRadioButton();
            this.rbnMiTrans = new IHIS.Framework.XRadioButton();
            this.cbxBuseo = new IHIS.Framework.XDictComboBox();
            this.monthBox = new IHIS.Framework.XMonthBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.fwkFind = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.pnlGrid = new IHIS.Framework.XPanel();
            this.pnlProgressBar = new IHIS.Framework.XPanel();
            this.lbTransCnt = new System.Windows.Forms.Label();
            this.lbTransHangmog = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.grdInpList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell191 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell182 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell206 = new IHIS.Framework.XEditGridCell();
            this.layOut0101 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.btnINPORDERTRANS = new IHIS.Framework.XButton();
            this.dtpJunsongToDate = new IHIS.Framework.XDatePicker();
            this.dtpJunsongFromDate = new IHIS.Framework.XDatePicker();
            this.pnlSerch.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInpList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "WTRS.ico");
            this.ImageList.Images.SetKeyName(4, "재전송.gif");
            this.ImageList.Images.SetKeyName(5, "iro.png");
            this.ImageList.Images.SetKeyName(6, "_.gif");
            this.ImageList.Images.SetKeyName(7, "+.gif");
            this.ImageList.Images.SetKeyName(8, "확인.gif");
            this.ImageList.Images.SetKeyName(9, "퇴원예정.gif");
            // 
            // pnlSerch
            // 
            this.pnlSerch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSerch.BackgroundImage")));
            this.pnlSerch.Controls.Add(this.dbxSuname);
            this.pnlSerch.Controls.Add(this.dtpJunsongToDate);
            this.pnlSerch.Controls.Add(this.dtpJunsongFromDate);
            this.pnlSerch.Controls.Add(this.xLabel2);
            this.pnlSerch.Controls.Add(this.xPanel1);
            this.pnlSerch.Controls.Add(this.cbxBuseo);
            this.pnlSerch.Controls.Add(this.monthBox);
            this.pnlSerch.Controls.Add(this.xLabel1);
            this.pnlSerch.Controls.Add(this.fbxBunho);
            this.pnlSerch.Controls.Add(this.xLabel3);
            this.pnlSerch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSerch.Location = new System.Drawing.Point(4, 4);
            this.pnlSerch.Name = "pnlSerch";
            this.pnlSerch.Size = new System.Drawing.Size(1086, 37);
            this.pnlSerch.TabIndex = 0;
            // 
            // xLabel2
            // 
            this.xLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(324, 7);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(80, 21);
            this.xLabel2.TabIndex = 296;
            this.xLabel2.Text = "病　棟";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.rbnTrans);
            this.xPanel1.Controls.Add(this.rbnMiTrans);
            this.xPanel1.Location = new System.Drawing.Point(827, 2);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(261, 23);
            this.xPanel1.TabIndex = 5;
            this.xPanel1.Visible = false;
            // 
            // rbnTrans
            // 
            this.rbnTrans.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnTrans.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnTrans.Enabled = false;
            this.rbnTrans.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnTrans.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnTrans.ImageList = this.ImageList;
            this.rbnTrans.Location = new System.Drawing.Point(189, 4);
            this.rbnTrans.Name = "rbnTrans";
            this.rbnTrans.Size = new System.Drawing.Size(186, 32);
            this.rbnTrans.TabIndex = 0;
            this.rbnTrans.Text = "転送済";
            this.rbnTrans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnTrans.UseVisualStyleBackColor = false;
            this.rbnTrans.Visible = false;
            this.rbnTrans.CheckedChanged += new System.EventHandler(this.RadioTrans_CheckedChanged);
            // 
            // rbnMiTrans
            // 
            this.rbnMiTrans.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnMiTrans.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbnMiTrans.Checked = true;
            this.rbnMiTrans.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnMiTrans.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbnMiTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnMiTrans.ImageList = this.ImageList;
            this.rbnMiTrans.Location = new System.Drawing.Point(4, 4);
            this.rbnMiTrans.Name = "rbnMiTrans";
            this.rbnMiTrans.Size = new System.Drawing.Size(186, 32);
            this.rbnMiTrans.TabIndex = 0;
            this.rbnMiTrans.TabStop = true;
            this.rbnMiTrans.Text = "未転送";
            this.rbnMiTrans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnMiTrans.UseVisualStyleBackColor = false;
            this.rbnMiTrans.Visible = false;
            this.rbnMiTrans.CheckedChanged += new System.EventHandler(this.RadioTrans_CheckedChanged);
            // 
            // cbxBuseo
            // 
            this.cbxBuseo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxBuseo.Location = new System.Drawing.Point(404, 7);
            this.cbxBuseo.Name = "cbxBuseo";
            this.cbxBuseo.Size = new System.Drawing.Size(92, 21);
            this.cbxBuseo.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxBuseo.TabIndex = 2;
            this.cbxBuseo.UserSQL = resources.GetString("cbxBuseo.UserSQL");
            this.cbxBuseo.SelectionChangeCommitted += new System.EventHandler(this.cbxBuseo_SelectionChangeCommitted);
            // 
            // monthBox
            // 
            this.monthBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.monthBox.Location = new System.Drawing.Point(85, 7);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(120, 21);
            this.monthBox.TabIndex = 1;
            this.monthBox.Visible = false;
            this.monthBox.PrevButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthBox_ButtonClick);
            this.monthBox.NextButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthBox_ButtonClick);
            // 
            // xLabel1
            // 
            this.xLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(5, 7);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(80, 20);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "実施日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxSuname
            // 
            this.dbxSuname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dbxSuname.Font = new System.Drawing.Font("MS UI Gothic", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbxSuname.Location = new System.Drawing.Point(677, 7);
            this.dbxSuname.Name = "dbxSuname";
            this.dbxSuname.Size = new System.Drawing.Size(386, 20);
            this.dbxSuname.TabIndex = 7;
            // 
            // fbxBunho
            // 
            this.fbxBunho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fbxBunho.Location = new System.Drawing.Point(578, 7);
            this.fbxBunho.MaxLength = 9;
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.Size = new System.Drawing.Size(100, 20);
            this.fbxBunho.TabIndex = 3;
            this.fbxBunho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunho_DataValidating);
            this.fbxBunho.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunho_FindClick);
            // 
            // xLabel3
            // 
            this.xLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(499, 7);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(80, 20);
            this.xLabel3.TabIndex = 5;
            this.xLabel3.Text = "患者番号";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkFind
            // 
            this.fwkFind.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkFind.FormText = "保険種別照会";
            this.fwkFind.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkFind.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "gubun";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "保険種別";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "gubun_name";
            this.findColumnInfo2.ColWidth = 150;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "保険種別名";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.pnlProgressBar);
            this.pnlGrid.Controls.Add(this.grdInpList);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(4, 41);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1086, 719);
            this.pnlGrid.TabIndex = 2;
            // 
            // pnlProgressBar
            // 
            this.pnlProgressBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlProgressBar.BackgroundImage")));
            this.pnlProgressBar.Controls.Add(this.lbTransCnt);
            this.pnlProgressBar.Controls.Add(this.lbTransHangmog);
            this.pnlProgressBar.Controls.Add(this.pgbProgress);
            this.pnlProgressBar.Location = new System.Drawing.Point(257, 176);
            this.pnlProgressBar.Name = "pnlProgressBar";
            this.pnlProgressBar.Size = new System.Drawing.Size(612, 62);
            this.pnlProgressBar.TabIndex = 4;
            this.pnlProgressBar.Visible = false;
            // 
            // lbTransCnt
            // 
            this.lbTransCnt.BackColor = System.Drawing.Color.Transparent;
            this.lbTransCnt.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTransCnt.Location = new System.Drawing.Point(498, 38);
            this.lbTransCnt.Name = "lbTransCnt";
            this.lbTransCnt.Size = new System.Drawing.Size(100, 23);
            this.lbTransCnt.TabIndex = 2;
            this.lbTransCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTransHangmog
            // 
            this.lbTransHangmog.BackColor = System.Drawing.Color.Transparent;
            this.lbTransHangmog.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTransHangmog.Location = new System.Drawing.Point(12, 38);
            this.lbTransHangmog.Name = "lbTransHangmog";
            this.lbTransHangmog.Size = new System.Drawing.Size(484, 23);
            this.lbTransHangmog.TabIndex = 1;
            this.lbTransHangmog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(10, 12);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(590, 24);
            this.pgbProgress.TabIndex = 0;
            // 
            // grdInpList
            // 
            this.grdInpList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell101,
            this.xEditGridCell126,
            this.xEditGridCell142,
            this.xEditGridCell1,
            this.xEditGridCell33,
            this.xEditGridCell129,
            this.xEditGridCell34,
            this.xEditGridCell130,
            this.xEditGridCell35,
            this.xEditGridCell2,
            this.xEditGridCell36,
            this.xEditGridCell104,
            this.xEditGridCell3,
            this.xEditGridCell7,
            this.xEditGridCell4,
            this.xEditGridCell191,
            this.xEditGridCell6,
            this.xEditGridCell182});
            this.grdInpList.ColPerLine = 13;
            this.grdInpList.Cols = 14;
            this.grdInpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInpList.FixedCols = 1;
            this.grdInpList.FixedRows = 1;
            this.grdInpList.HeaderHeights.Add(28);
            this.grdInpList.Location = new System.Drawing.Point(0, 0);
            this.grdInpList.Name = "grdInpList";
            this.grdInpList.ReadOnly = true;
            this.grdInpList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdInpList.RowHeaderVisible = true;
            this.grdInpList.Rows = 2;
            this.grdInpList.RowStateCheckOnPaint = false;
            this.grdInpList.Size = new System.Drawing.Size(1086, 719);
            this.grdInpList.TabIndex = 0;
            this.grdInpList.TabStop = false;
            this.grdInpList.ToolTipActive = true;
            this.grdInpList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdInpList_MouseDown);
            this.grdInpList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdInpList_QueryEnd);
            this.grdInpList.DoubleClick += new System.EventHandler(this.grdInpList_DoubleClick);
            this.grdInpList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdInpList_QueryStarting);
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "pkinp1001";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.HeaderText = "pkinp1001";
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "bunho";
            this.xEditGridCell126.CellWidth = 75;
            this.xEditGridCell126.Col = 2;
            this.xEditGridCell126.HeaderText = "患者番号";
            this.xEditGridCell126.IsReadOnly = true;
            this.xEditGridCell126.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "suname";
            this.xEditGridCell142.CellWidth = 100;
            this.xEditGridCell142.Col = 3;
            this.xEditGridCell142.HeaderText = "漢字氏名";
            this.xEditGridCell142.IsReadOnly = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "suname2";
            this.xEditGridCell1.CellWidth = 110;
            this.xEditGridCell1.Col = 4;
            this.xEditGridCell1.HeaderText = "カナ氏名";
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "gwa";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.HeaderText = "診療科コード";
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "gwa_name";
            this.xEditGridCell129.CellWidth = 87;
            this.xEditGridCell129.Col = 5;
            this.xEditGridCell129.HeaderText = "診療科";
            this.xEditGridCell129.IsReadOnly = true;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "doctor";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.HeaderText = "診療医コード";
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "doctor_name";
            this.xEditGridCell130.CellWidth = 100;
            this.xEditGridCell130.Col = 6;
            this.xEditGridCell130.HeaderText = "診療医";
            this.xEditGridCell130.IsReadOnly = true;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "ho_dong1";
            this.xEditGridCell35.CellWidth = 72;
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.HeaderText = "病棟コード";
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "ho_dong1_name";
            this.xEditGridCell2.CellWidth = 45;
            this.xEditGridCell2.Col = 7;
            this.xEditGridCell2.HeaderText = "病棟";
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "ho_code";
            this.xEditGridCell36.CellWidth = 55;
            this.xEditGridCell36.Col = 8;
            this.xEditGridCell36.HeaderText = "病室";
            this.xEditGridCell36.IsReadOnly = true;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ipwon_date";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell104.CellWidth = 100;
            this.xEditGridCell104.Col = 9;
            this.xEditGridCell104.HeaderText = "入院日付";
            this.xEditGridCell104.IsJapanYearType = true;
            this.xEditGridCell104.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "toiwon_res_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 10;
            this.xEditGridCell3.HeaderText = "退院予定日";
            this.xEditGridCell3.IsJapanYearType = true;
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 1;
            this.xEditGridCell7.CellName = "trans_ord_yn";
            this.xEditGridCell7.CellWidth = 79;
            this.xEditGridCell7.Col = 11;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell7.HeaderText = "未転送データ";
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 1;
            this.xEditGridCell4.CellName = "unact_yn";
            this.xEditGridCell4.CellWidth = 76;
            this.xEditGridCell4.Col = 12;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell4.HeaderText = "未実施オーダ";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell191
            // 
            this.xEditGridCell191.CellName = "send_date";
            this.xEditGridCell191.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell191.CellWidth = 100;
            this.xEditGridCell191.Col = 13;
            this.xEditGridCell191.HeaderText = "最終転送日付";
            this.xEditGridCell191.IsJapanYearType = true;
            this.xEditGridCell191.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "inp_flag";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell182
            // 
            this.xEditGridCell182.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell182.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell182.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell182.AlterateRowImageIndex = 0;
            this.xEditGridCell182.CellName = "select";
            this.xEditGridCell182.CellWidth = 30;
            this.xEditGridCell182.Col = 1;
            this.xEditGridCell182.HeaderText = "選択";
            this.xEditGridCell182.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell182.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell182.RowImageIndex = 0;
            this.xEditGridCell182.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(844, 764);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 4;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellLen = 4;
            this.xEditGridCell170.CellName = "post_modifier8";
            this.xEditGridCell170.Col = -1;
            this.xEditGridCell170.HeaderText = "post_modifier8";
            this.xEditGridCell170.IsVisible = false;
            this.xEditGridCell170.Row = -1;
            // 
            // xEditGridCell206
            // 
            this.xEditGridCell206.CellName = "if_valid_yn";
            this.xEditGridCell206.Col = -1;
            this.xEditGridCell206.HeaderText = "if_valid_yn";
            this.xEditGridCell206.IsVisible = false;
            this.xEditGridCell206.Row = -1;
            // 
            // layOut0101
            // 
            this.layOut0101.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layOut0101.QuerySQL = resources.GetString("layOut0101.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // btnINPORDERTRANS
            // 
            this.btnINPORDERTRANS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnINPORDERTRANS.ImageIndex = 8;
            this.btnINPORDERTRANS.ImageList = this.ImageList;
            this.btnINPORDERTRANS.Location = new System.Drawing.Point(3, 766);
            this.btnINPORDERTRANS.Name = "btnINPORDERTRANS";
            this.btnINPORDERTRANS.Size = new System.Drawing.Size(145, 29);
            this.btnINPORDERTRANS.TabIndex = 15;
            this.btnINPORDERTRANS.Text = "入院オーダ転送画面";
            this.btnINPORDERTRANS.Click += new System.EventHandler(this.btnINPORDERTRANS_Click);
            // 
            // dtpJunsongToDate
            // 
            this.dtpJunsongToDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpJunsongToDate.IsJapanYearType = true;
            this.dtpJunsongToDate.Location = new System.Drawing.Point(203, 7);
            this.dtpJunsongToDate.Name = "dtpJunsongToDate";
            this.dtpJunsongToDate.Size = new System.Drawing.Size(118, 20);
            this.dtpJunsongToDate.TabIndex = 298;
            this.dtpJunsongToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpJunsongToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJunsongToDate_DataValidating);
            // 
            // dtpJunsongFromDate
            // 
            this.dtpJunsongFromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpJunsongFromDate.IsJapanYearType = true;
            this.dtpJunsongFromDate.Location = new System.Drawing.Point(85, 7);
            this.dtpJunsongFromDate.Name = "dtpJunsongFromDate";
            this.dtpJunsongFromDate.Size = new System.Drawing.Size(118, 20);
            this.dtpJunsongFromDate.TabIndex = 297;
            this.dtpJunsongFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpJunsongFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJunsongFromDate_DataValidating);
            // 
            // INPBATCHTRANS
            // 
            this.Controls.Add(this.btnINPORDERTRANS);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlSerch);
            this.Name = "INPBATCHTRANS";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(1094, 800);
            this.Load += new System.EventHandler(this.INPBATCHTRANS_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.INPBATCHTRANS_ScreenOpen);
            this.pnlSerch.ResumeLayout(false);
            this.pnlSerch.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInpList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

	}
		#endregion

		#region Screen 변수

		// 라디오 버튼 컬러
		private XColor mSelectedBackColor   = new XColor(Color.FromName("ActiveCaption"));
		private XColor mSelectedForeColor   = new XColor(Color.FromName("ActiveCaptionText"));
		private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
		private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

		// 오더 상태에 따른 색 변화
		// 결과 입력 완료
		private XColor mResultForeColor  = new XColor(Color.DeepPink);
		private XColor mResultBackColor  = new XColor(Color.SkyBlue);
		// 액팅완료
		private XColor mActingBackColor  = new XColor(Color.SkyBlue);
		private XColor mActingForeColor  = new XColor(Color.Blue);
		// 예약완료
		private XColor mReserForeColor   = new XColor(Color.Green);

        private int mMaxWidth = 1117;

        // 前月の最後日
        //private string query_date = "";
		#endregion

        #region Screen Load
        private void INPBATCHTRANS_Load(object sender, System.EventArgs e)
        {
            this.InitScreen();
        }
        #endregion

        #region [ Screen 이벤트 ]
        private void INPBATCHTRANS_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 
            int width = 0;
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            if (rc.Width - 30 > mMaxWidth)
                width = mMaxWidth;
            else
                width = rc.Width - 30;

            this.ParentForm.Size = new System.Drawing.Size(width, rc.Height - 105);

            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    // 등록번호
                    if (OpenParam.Contains("bunho"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
                        {
                            this.fbxBunho.SetEditValue(OpenParam["bunho"].ToString().Trim());
                            //this.btnList.PerformClick(FunctionType.Query);
                            this.fbxBunho.AcceptData();
                        }
                    }
                }
                catch (Exception ex)
                {
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }
            //
            this.monthBox.AcceptData();
        }
        #endregion

        #region [InitScreen]
        private void InitScreen()
        {
            // 基準月 前月に設定
            this.monthBox.SetEditValue(EnvironInfo.GetSysDate().AddMonths(-1).ToString("yyyyMM"));

            // 前月の最後日セット
            //this.query_date = this.monthBox.GetDataValue() + DateTime.DaysInMonth(int.Parse(this.monthBox.GetDataValue().Substring(0, 4)), int.Parse(this.monthBox.GetDataValue().Substring(4, 2))).ToString();

            // FROM日付
            this.dtpJunsongFromDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            // TO日付
            this.dtpJunsongToDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));

            // 디폴트 病棟セット
            this.cbxBuseo.SelectedIndex = 0;

            // 디폴트 미전송 체크
            this.rbnMiTrans.Checked = true;

            // 処理対象患者照会
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region [환자정보 처리]
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            this.fbxBunho.SetDataValue(info.BunHo);

            base.OnReceiveBunHo(info);
        }
        #endregion

        #region [환자정보 이벤트]
        private void fbxBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != "")
            {
                string bunho = e.DataValue;
                bunho = BizCodeHelper.GetStandardBunHo(bunho);
                this.fbxBunho.SetDataValue(bunho);

                // 在院患者チェック
                if (this.isJaewonPatient(bunho))
                {
                    //환자정보처리
                    this.SetSelectedPatientInfo();
                    // 환자오더정보처리
                    this.btnList.PerformClick(FunctionType.Query);
                }
                else {
                    XMessageBox.Show("在院中の患者ではありません。患者番号を確認してください。", "患者番号確認", MessageBoxIcon.Warning);
                    this.fbxBunho.SetDataValue("");

                    this.dbxSuname.SetDataValue("");

                    this.fbxBunho.Focus();
                }
            }
            else
            {
                this.dbxSuname.SetDataValue("");
            }
        }

        private bool isJaewonPatient(string bunho)
        {
            bool rtnVal = false;

            string strCmd = "";
            BindVarCollection bindVar = new BindVarCollection();

            //bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_bunho", bunho);
            //bindVar.Add("f_query_date", query_date);
            bindVar.Add("f_query_date", this.dtpJunsongToDate.GetDataValue());

            strCmd = @"SELECT FN_INP_JAEWON_HISTORY_CHECK(:f_bunho, :f_query_date) JAEWON_YN
                         FROM DUAL";

            object result = Service.ExecuteScalar(strCmd, bindVar);

            if (TypeCheck.IsNull(result)) rtnVal = false;
            else rtnVal = result.ToString() == "Y"? true : false;

            return rtnVal;
        }

        private void SetSelectedPatientInfo()
        {
            // XDisplayBox 데이터삭제
            this.dbxSuname.ResetText();
            // LayoutIt11ems 데이터삭제
            this.layOut0101.LayoutItems.Clear();
            this.layOut0101.LayoutItems.Add("SUNAME");
            this.layOut0101.LayoutItems.Add("SUNAME2");
            this.layOut0101.LayoutItems.Add("BIRTH");
            this.layOut0101.LayoutItems.Add("TEL");
            this.layOut0101.LayoutItems.Add("SEX");
            this.layOut0101.LayoutItems.Add("AGE");
            this.layOut0101.LayoutItems.Add("IF_VALID_YN");
            // 바인드변수설정
            this.layOut0101.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layOut0101.SetBindVarValue("f_bunho", fbxBunho.GetDataValue().ToString());
            // 환자정보데이터 취득
            if (this.layOut0101.QueryLayout())
            {
                string str = "  " + this.layOut0101.GetItemValue("SUNAME").ToString() + "  [ " +
                                    this.layOut0101.GetItemValue("SUNAME2").ToString() + " ]  " +
                                    this.layOut0101.GetItemValue("SEX").ToString() + "  / " +
                                    this.layOut0101.GetItemValue("AGE").ToString() + "才";
                this.dbxSuname.SetEditValue(str);
            }
        }
        #endregion

        #region [ 환자번호 클릭이벤트 ]
        private void fbxBunho_FindClick(object sender, CancelEventArgs e)
        {
            this.OpenScreen_OUT0101Q01();
        }
        #endregion

        #region [ 다른 화면 오픈 ]
        private void OpenScreen_OUT0101Q01()
        {
            CommonItemCollection param = new CommonItemCollection();
            XScreen.OpenScreenWithParam(this, "NURO", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
        }
        #endregion

        #region [ Command ]
        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "OUT0101":
                    if (commandParam != null)
                    {
                        this.fbxBunho.Focus();
                        this.fbxBunho.SetEditValue(((MultiLayout)commandParam[0]).GetItemString(0, "bunho"));
                        this.dbxSuname.SetEditValue(((MultiLayout)commandParam[0]).GetItemString(0, "suname"));
                        this.fbxBunho.AcceptData();
                    }
                    break;
            }
            return base.Command(command, commandParam);
        }
        #endregion

        #region [전송, 미전송 버튼클릭이벤트처리]
        private void RadioTrans_CheckedChanged(object sender, System.EventArgs e)
        {
            XRadioButton button = sender as XRadioButton;

            if (button.Checked == true)
            {
                button.ImageIndex = 0;
                button.BackColor = this.mSelectedBackColor;
                button.ForeColor = this.mSelectedForeColor;
                
                // 미전송버튼클릭시 셋팅
                if (this.rbnMiTrans.Checked == true)
                {

                }
                else
                {

                }

                this.btnList.PerformClick(FunctionType.Query);
            }
            else
            {
                button.ImageIndex = 1;
                button.BackColor = this.mUnSelectedBackColor;
                button.ForeColor = this.mUnSelectedForeColor;
            }
        }
        #endregion

        #region XLabel
        private void lbSelectAll_Click(object sender, System.EventArgs e)
        {
        }
        #endregion

        //#region [오더 데이터 전송처리함수]
        //private bool ProcessOrderSend()
        //{
        //    return true;
        //}
        //#endregion  

        #region [오더 데이터 전송함수]

        private bool OrderTrans(string fkINP3010, string trans_gubun)
        {
            DataTable send_list = new DataTable();

            BindVarCollection item = new BindVarCollection();
            string QuerySQL = "";

            item.Clear();
            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_fkINP3010", fkINP3010);

            QuerySQL = @"SELECT PKIFS3014
                           FROM IFS3014
                          WHERE HOSP_CODE = :f_hosp_code
                            AND FKINP3010 = :f_fkINP3010
                         ";

            switch (trans_gubun)
            {

                case "Y":   //trans, retrans = 10
                case "R":
                    QuerySQL = QuerySQL + " AND IF_FLAG = '10' ";
                    break;
                
                case "N":   //cancel = 20
                    QuerySQL = QuerySQL + " AND IF_FLAG = '20' ";   
                    break;
            }

            send_list = Service.ExecuteDataTable(QuerySQL, item);

            if (TypeCheck.IsNull(send_list) || send_list.Rows.Count == 0)
            {
                throw new Exception("転送するデータが存在しません。");
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            for (int i = 0; i < send_list.Rows.Count; i++)
            {
                msgText = "00221" + send_list.Rows[i]["PKIFS3014"].ToString();
                int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
                if (ret == -1)
                {
                    throw new Exception("オーダを転送する途中問題が発生しました。電文："　+ msgText);
                }
            }
            return true;
        }

        private int MakeIFS3014(string transGubun, string io_gubun, string pkINP3010, string trans_yn)
        {
            //IFS1004テータ作成

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            int retVal = -1;
            string procedureName = "";

            inputList.Clear();
            outputList.Clear();

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(io_gubun);
            inputList.Add(pkINP3010);
            inputList.Add(trans_yn);

            switch (transGubun)
            {
                case "SANG":
                    //inputList.Add("OUT_SANG_TRANS"); 
                    procedureName = "PR_IFS_OUTSANG_TRANS";
                    break;

                case  "ORDER":
                    //inputList.Add("CREATE_IF_DETAIL");
                    procedureName = "PR_IFS_ORDER_PROC_MAIN";
                    break;
            }

            bool ret = Service.ExecuteProcedure(procedureName, inputList, outputList);

            if (TypeCheck.IsNull(outputList[1]) || outputList[1].ToString() != "1")
            {
                throw new Exception(outputList[2].ToString());
            }

            if(TypeCheck.IsInt(outputList[0]))
            {
                retVal = Int32.Parse(outputList[0].ToString());
            }

            return retVal;
        }

        private bool ProcessOrderTrans(ref ArrayList listDateArry)
        {                        
            return true;
        }
        #endregion

        #region [monthBox_ButtonClick 照会月変更]
        private void monthBox_ButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
            // 前月の最後日セット
            //this.query_date = this.monthBox.GetDataValue() + DateTime.DaysInMonth(int.Parse(this.monthBox.GetDataValue().Substring(0, 4)), int.Parse(this.monthBox.GetDataValue().Substring(4, 2))).ToString();

            this.btnList.PerformClick(FunctionType.Query);
        }
        private void monthBox_DataValidating(object sender, DataValidatingEventArgs e)
        {
            // 前月の最後日セット
            //this.query_date = this.monthBox.GetDataValue() + DateTime.DaysInMonth(int.Parse(this.monthBox.GetDataValue().Substring(0, 4)), int.Parse(this.monthBox.GetDataValue().Substring(4, 2))).ToString();

            this.btnList.PerformClick(FunctionType.Query);

        }
        #endregion

        #region [病棟選択]
        private void cbxBuseo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region [ボタンリストClick]
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {

            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdInpList.QueryLayout(false);
                    break;
                case FunctionType.Process:

                    // 未転送TAB
                    if (this.rbnMiTrans.Checked == true)
                    {
                        if (XMessageBox.Show("中間精算処理を行いますか？", "中間精算実施", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                        else
                        {
                            if (this.processOrderSend())
                            {
                                XMessageBox.Show("中間精算の転送申請を成功しました。", "転送要請成功", MessageBoxIcon.Information);
                                this.btnList.PerformClick(FunctionType.Query);
                            }
                        }
                    }
                    else // 転送済TAB
                    {
                        if (XMessageBox.Show("中間精算取消処理を行いますか？", "中間精算取消", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                        else
                        {
                            if (this.processOrderCancel())
                            {
                                XMessageBox.Show("中間精算の取消申請を成功しました。", "取消要請成功", MessageBoxIcon.Information);
                                this.btnList.PerformClick(FunctionType.Query);
                            }
                        }
                    }

                    break;
            }
        }
        #endregion

        #region [오더 데이터 전송처리함수]
        private bool processOrderSend()
        {
            if (this.grdInpList.RowCount < 1) return false;

            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            for (int i = 0; i < this.grdInpList.RowCount; i++)
            {
                if (this.grdInpList.GetItemString(i, "select") == "Y")
                {
                    //XMessageBox.Show(this.grdInpList.GetItemString(i, "bunho"));

                    inputList.Clear();
                    outputList.Clear();

                    inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
                    inputList.Add("I_BUNHO", this.grdInpList.GetItemString(i, "bunho"));
                    inputList.Add("I_PKINP1001", this.grdInpList.GetItemString(i, "pkinp1001"));
                    //inputList.Add("I_YYYYMM", this.monthBox.GetDataValue());
                    inputList.Add("I_FROM_DATE", this.dtpJunsongFromDate.GetDataValue());
                    inputList.Add("I_TO_DATE", this.dtpJunsongToDate.GetDataValue());
                    inputList.Add("I_PROC_GUBUN", "Y");

                    bool ret = Service.ExecuteProcedure("PR_IFS_INP_ORDER_BATCH_PROC", inputList, outputList);

                    if (TypeCheck.IsNull(outputList["O_ERR"]) || outputList["O_ERR"].ToString() != "0")
                    {
                        throw new Exception(outputList["O_ERR"].ToString());
                    }
                }
            }

            return true;
        }
        #endregion

        #region [오더 데이터 취소처리함수]
        private bool processOrderCancel()
        {
            if (this.grdInpList.RowCount < 1) return false;

            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            for (int i = 0; i < this.grdInpList.RowCount; i++)
            {
                if (this.grdInpList.GetItemString(i, "select") == "Y")
                {
                    //XMessageBox.Show(this.grdInpList.GetItemString(i, "bunho"));

                    inputList.Clear();
                    outputList.Clear();

                    inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
                    inputList.Add("I_BUNHO", this.grdInpList.GetItemString(i, "bunho"));
                    inputList.Add("I_PKINP1001", this.grdInpList.GetItemString(i, "pkinp1001"));
                    //inputList.Add("I_YYYYMM", this.monthBox.GetDataValue());
                    inputList.Add("I_FROM_DATE", this.dtpJunsongFromDate.GetDataValue());
                    inputList.Add("I_TO_DATE", this.dtpJunsongToDate.GetDataValue());
                    inputList.Add("I_PROC_GUBUN", "N");

                    bool ret = Service.ExecuteProcedure("PR_IFS_INP_ORDER_BATCH_PROC", inputList, outputList);

                    if (TypeCheck.IsNull(outputList["O_ERR"]) || outputList["O_ERR"].ToString() != "0")
                    {
                        throw new Exception(outputList["O_ERR"].ToString());
                    }
                }
            }

            return true;
        }
        #endregion

        #region [grdInpList Query開始]
        private void grdInpList_QueryStarting(object sender, CancelEventArgs e)
        {
            // 未転送
            if (this.rbnMiTrans.Checked == true)
            {
                #region comment
                /*
                this.grdInpList.QuerySQL = @"SELECT A.PKINP1001
                                                  , A.BUNHO
                                                  , B.SUNAME
                                                  , B.SUNAME2
                                                  , A.GWA                                                                                       GWA
                                                  , FN_BAS_LOAD_GWA_NAME(A.GWA, TRUNC(SYSDATE))                                                 GWA_NAME
                                                  , A.DOCTOR                                                                                    DOCTOR
                                                  , FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, TRUNC(SYSDATE))                                          DOCTOR_NAME
                                                  , A.HO_DONG1                                                                                  HO_DONG1
                                                  , FN_BAS_LOAD_GWA_NAME(A.HO_DONG1, TRUNC(SYSDATE))                                            HO_DONG1_NAME
                                                  , A.HO_CODE1                                                                                  HO_CODE1
                                                  , TO_CHAR(A.IPWON_DATE, 'YYYY/MM/DD')                                                         IPWON_DATE
                                                  , TO_CHAR(NVL(A.TOIWON_DATE, A.TOIWON_RES_DATE), 'YYYY/MM/DD')                                TOIWON_RES_DATE
                                                  , (SELECT DISTINCT 'Y'
                                                      FROM OCS2003 C
                                                     WHERE C.HOSP_CODE = :f_hosp_code
                                                       AND C.FKINP1001 = A.PKINP1001
                                                       AND C.BUNHO     = A.BUNHO
                                                       AND NVL(C.RESER_DATE, C.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date
                                                       AND (    C.JUNDAL_TABLE = 'HOM'
                                                            OR (C.JUNDAL_TABLE <> 'HOM' AND C.OCS_FLAG  = '3')  -- 3:オーダ実施
                                                           )
                                                       AND NVL(C.IF_DATA_SEND_YN, 'N') = 'N'  -- オーダ転送可否
                                                       AND C.IF_DATA_SEND_DATE IS NULL        -- オーダ転送日
                                                       AND C.SG_CODE   IS NOT NULL            -- 内視鏡の仮オーダ区別のため
                                                    )                                                                                           TRANS_ORD_YN
                                                  , (SELECT DISTINCT 'Y'
                                                      FROM OCS2003 C
                                                     WHERE C.HOSP_CODE = :f_hosp_code
                                                       AND C.FKINP1001 = A.PKINP1001
                                                       AND C.BUNHO     = A.BUNHO
                                                       AND NVL(C.RESER_DATE, C.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date
                                                       AND C.OCS_FLAG  IN ('1', '2')  -- 1:オーダ登録, 2:オーダ受付  
                                                       AND C.SG_CODE   IS NOT NULL    -- 内視鏡の仮オーダ区別のため
                                                       AND C.JUNDAL_TABLE <> 'HOM')                                                             ACT_END_YN
                                                  , (SELECT MAX(C.IF_DATA_SEND_DATE)
                                                      FROM OCS2003 C
                                                     WHERE C.HOSP_CODE = 'K01'
                                                       AND C.FKINP1001 = A.PKINP1001
                                                       AND C.BUNHO     = A.BUNHO)                                                               TRANS_DATE
                                                  , NVL(A.TOIWON_GOJI_YN, 'N')                                                                  INP_FLAG
                                               --FROM VW_OCS_INP1001_RES_01 A
                                               FROM VW_OCS_INP1001_01          A
                                                  , OUT0101                    B
                                              WHERE :f_query_date BETWEEN A.IPWON_DATE AND NVL(A.TOIWON_DATE, TO_DATE('99981231', 'YYYYMMDD'))
                                                AND NVL(A.HO_DONG1, '%')       LIKE :f_ho_dong1
                                                --AND NVL(A.IPWON_RESER_YN, 'N') = 'N'                        -- 入院予約患者は除外
                                                --AND NVL(A.CANCEL_YN, 'N')      = 'N'
                                                AND A.BUNHO                    LIKE NVL(:f_bunho, '%')
                                                AND B.HOSP_CODE                = :f_hosp_code
                                                AND B.BUNHO                    = A.BUNHO
                                              ORDER BY INP_FLAG DESC, A.HO_DONG1, A.HO_CODE1, A.BED_NO, A.PKINP1001";
                                */
                #endregion conmment

                #region 2013.09.16 LKH S : List of SQL
                this.grdInpList.QuerySQL = @"
    SELECT  
         --  AA.HOSP_CODE                                                      AS HOSP_CODE
           AA.PKINP1001                                                      AS PKINP1001
         , AA.BUNHO                                                          AS BUNHO
         , F.SUNAME                                                          AS SUNAME
         , F.SUNAME2                                                         AS SUNAME2
         --
         --, TO_CHAR(NVL(A.ACTING_DATE, A.ORDER_DATE), 'YYYYMM')               AS ACTING_DATE
         --, NVL(A.ACTING_DATE, A.ORDER_DATE)                                  AS ACTING_DATE
         --, A.ORDER_DATE                                                      AS ORDER_DATE
         , AA.GWA                                                            AS GWA
         , FN_BAS_LOAD_GWA_NAME(AA.GWA, TRUNC(SYSDATE))                      AS GWA_NAME
         --, A.DOCTOR                                                          AS DOCTOR
         --, AA.DOCTOR                                                         AS DOCTOR
         , SUBSTR(AA.DOCTOR, -5, 5)                                          AS DOCTOR
         , FN_BAS_LOAD_DOCTOR_NAME(AA.DOCTOR, TRUNC(SYSDATE))                AS DOCTOR_NAME
         --, NVL(AB.GUBUN, '##')                                               AS GUBUN
         --, FN_BAS_LOAD_GUBUN_NAME(NVL(AB.GUBUN, '##') , TRUNC(SYSDATE))      AS GUBUN_NAME
         --, AA.CHOJAE                                                         AS CHOJAE
         --, '4'                                                               AS CHOJAE
         , AA.HO_DONG1                                                       AS HO_DONG1
         , FN_BAS_LOAD_GWA_NAME(AA.HO_DONG1, TRUNC(SYSDATE))                 AS HO_DONG1_NAME
         , AA.HO_CODE1                                                       AS HO_CODE1
         , TO_CHAR(AA.IPWON_DATE, 'YYYY/MM/DD')                              AS IPWON_DATE
         --, AA.IPWON_TIME                                                     AS IPWON_TIME
         --
         , TO_CHAR(NVL(AA.TOIWON_DATE, AA.TOIWON_RES_DATE), 'YYYY/MM/DD')    AS TOIWON_RES_DATE
         --
         , NVL(
               (SELECT 'Y' 
                  FROM SYS.DUAL
                 WHERE EXISTS (
                                SELECT 'Y'
                                  FROM OCS2003      A
                                     , OCS0103      B
                                     , BAS0310      E
                                 WHERE 1=1
                                   -- ORDER
                                   AND A.HOSP_CODE                     = AA.HOSP_CODE
                                   AND A.BUNHO                         = AA.BUNHO
                                   AND A.FKINP1001                     = AA.PKINP1001 
                                   --
                                   AND NVL(A.IF_DATA_SEND_YN, 'N')     = 'N'
                                   -- ACTING_DATE
                                   AND (   (    A.ACTING_DATE          BETWEEN :f_from_date
                                                                           AND :f_query_date
                                           )
                                        OR (    A.ACTING_DATE          IS NULL
                                            AND A.ORDER_DATE           BETWEEN :f_from_date
                                                                           AND :f_query_date

                                           )
                                       )                                    
                                   -- ???
                                   AND A.NALSU                         >= 0
                                   --AND NVL(A.DISPLAY_YN , 'Y')         = 'Y'
                                   AND NVL(A.DC_YN,'N')                = 'N'
                                   AND NVL(A.MUHYO,'N')                = 'N'
                                   -- HANGMOG_CODE
                                   AND B.HOSP_CODE                     = A.HOSP_CODE
                                   AND B.HANGMOG_CODE                  = A.HANGMOG_CODE
                                   AND B.START_DATE                    = (SELECT MAX(Z.START_DATE)
                                                                            FROM OCS0103 Z
                                                                           WHERE Z.HOSP_CODE       = A.HOSP_CODE
                                                                             AND Z.HANGMOG_CODE    = A.HANGMOG_CODE
                                                                             AND Z.START_DATE      <= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                                                             AND (   Z.END_DATE    IS NULL
                                                                                  OR Z.END_DATE    >= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                                                                 )
                                                                         )
                                   AND (   B.END_DATE                  IS NULL
                                        OR B.END_DATE                  >= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                       )
                                   -- JUMSU
                                   AND E.HOSP_CODE                    = A.HOSP_CODE
                                   AND E.SG_CODE                      = A.SG_CODE
                                   AND E.SG_YMD                       = (SELECT MAX(Z.SG_YMD)
                                                                           FROM BAS0310 Z
                                                                          WHERE Z.HOSP_CODE       = A.HOSP_CODE
                                                                            AND Z.SG_CODE         = A.SG_CODE
                                                                            AND Z.SG_YMD          <= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                                                            AND (   Z.BULYONG_YMD IS NULL
                                                                                 OR Z.BULYONG_YMD >= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                                                                )
                                                                        )
                                   AND (   E.BULYONG_YMD              IS NULL
                                        OR E.BULYONG_YMD              >= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                       )
                              )
               ), 'N'    
           )                                                                 AS TRANS_ORD_YN
         --
        , NVL(
               (SELECT 'Y' 
                  FROM SYS.DUAL
                 WHERE EXISTS (
                                SELECT 'Y'
                                  FROM OCS2003      A
                                     , OCS0103      B
                                     , BAS0310      E
                                 WHERE 1=1
                                   -- ORDER
                                   AND A.HOSP_CODE                     = AA.HOSP_CODE
                                   AND A.BUNHO                         = AA.BUNHO
                                   AND A.FKINP1001                     = AA.PKINP1001 
                                   --
                                   AND NVL(A.IF_DATA_SEND_YN, 'N')     = 'N'
                                   -- ACTING_DATE
                                   AND A.ACTING_DATE                   IS NULL
                                   --AND A.OCS_FLAG                      IN ('1', '2')
                                   AND (   1=2
                                        OR A.RESER_DATE                BETWEEN :f_from_date
                                                                           AND :f_query_date
                                        OR A.HOPE_DATE                 BETWEEN :f_from_date
                                                                           AND :f_query_date
                                        OR (    A.HOPE_DATE            IS NULL
                                            AND A.RESER_DATE           IS NULL
                                            AND A.ORDER_DATE           BETWEEN :f_from_date
                                                                           AND :f_query_date
                                           )
                                        )
                                   -- ???
                                   AND A.NALSU                         >= 0
                                   --AND NVL(A.DISPLAY_YN , 'Y')         = 'Y'
                                   AND NVL(A.DC_YN,'N')                = 'N'
                                   AND NVL(A.MUHYO,'N')                = 'N'
                                   -- HANGMOG_CODE
                                   AND B.HOSP_CODE                     = A.HOSP_CODE
                                   AND B.HANGMOG_CODE                  = A.HANGMOG_CODE
                                   AND B.START_DATE                    = (SELECT MAX(Z.START_DATE)
                                                                            FROM OCS0103 Z
                                                                           WHERE Z.HOSP_CODE       = B.HOSP_CODE
                                                                             AND Z.HANGMOG_CODE    = B.HANGMOG_CODE
                                                                             AND Z.START_DATE      <= A.ORDER_DATE
                                                                             AND (   Z.END_DATE    IS NULL
                                                                                  OR Z.END_DATE    >= A.ORDER_DATE
                                                                                 )
                                                                         )
                                   AND (   B.END_DATE                  IS NULL
                                        OR B.END_DATE                  >= A.ORDER_DATE
                                       )
                                   -- JUMSU
                                   AND E.HOSP_CODE                    = A.HOSP_CODE
                                   AND E.SG_CODE                      = A.SG_CODE
                                   AND E.SG_YMD                       = (SELECT MAX(Z.SG_YMD)
                                                                           FROM BAS0310 Z
                                                                          WHERE Z.HOSP_CODE       = E.HOSP_CODE
                                                                            AND Z.SG_CODE         = E.SG_CODE
                                                                            AND Z.SG_YMD          <= A.ORDER_DATE
                                                                            AND (   Z.BULYONG_YMD IS NULL
                                                                                 OR Z.BULYONG_YMD >= A.ORDER_DATE
                                                                                )
                                                                        )
                                   AND (   E.BULYONG_YMD              IS NULL
                                        OR E.BULYONG_YMD              >= A.ORDER_DATE
                                       )
                              )
               ), 'N'    
           )                                                                 AS ACT_ORD_YN
         --
         , (
            SELECT MAX(A.IF_DATA_SEND_DATE)
              FROM OCS2003      A
                 , OCS0103      B
                 , BAS0310      E
             WHERE 1=1
               -- ORDER
               AND A.HOSP_CODE                     = AA.HOSP_CODE
               AND A.BUNHO                         = AA.BUNHO
               AND A.FKINP1001                     = AA.PKINP1001 
               --
               --AND NVL(A.IF_DATA_SEND_YN, 'N')     = 'N'
               AND NVL(A.IF_DATA_SEND_YN, 'N')     = 'Y'
               -- ACTING_DATE
               AND (   (   A.ACTING_DATE           BETWEEN :f_from_date
                                                       AND :f_query_date
                       )
                    OR (    A.ACTING_DATE          IS NULL
                        AND A.ORDER_DATE           BETWEEN :f_from_date
                                                       AND :f_query_date
                       )
                   )                                    
               -- ???
               AND A.NALSU                         >= 0
               --AND NVL(A.DISPLAY_YN , 'Y')         = 'Y'
               AND NVL(A.DC_YN,'N')                = 'N'
               AND NVL(A.MUHYO,'N')                = 'N'
               -- HANGMOG_CODE
               AND B.HOSP_CODE                     = A.HOSP_CODE
               AND B.HANGMOG_CODE                  = A.HANGMOG_CODE
               AND B.START_DATE                    = (SELECT MAX(Z.START_DATE)
                                                        FROM OCS0103 Z
                                                       WHERE Z.HOSP_CODE       = B.HOSP_CODE
                                                         AND Z.HANGMOG_CODE    = B.HANGMOG_CODE
                                                         AND Z.START_DATE      <= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                                         AND (   Z.END_DATE    IS NULL
                                                              OR Z.END_DATE    >= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                                             )
                                                     )
               AND (   B.END_DATE                  IS NULL
                    OR B.END_DATE                  >= NVL( A.ACTING_DATE, A.ORDER_DATE)
                   )
               -- JUMSU
               AND E.HOSP_CODE                    = A.HOSP_CODE
               AND E.SG_CODE                      = A.SG_CODE
               AND E.SG_YMD                       = (SELECT MAX(Z.SG_YMD)
                                                       FROM BAS0310 Z
                                                      WHERE Z.HOSP_CODE       = E.HOSP_CODE
                                                        AND Z.SG_CODE         = E.SG_CODE
                                                        AND Z.SG_YMD          <= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                                        AND (   Z.BULYONG_YMD IS NULL
                                                             OR Z.BULYONG_YMD >= NVL( A.ACTING_DATE, A.ORDER_DATE)
                                                            )
                                                    )
               AND (   E.BULYONG_YMD              IS NULL
                    OR E.BULYONG_YMD              >= NVL( A.ACTING_DATE, A.ORDER_DATE)
                   )
            )                                                                 AS TRANS_DATE
         --
         , NVL(AA.TOIWON_GOJI_YN, 'N')                                        AS INP_FLAG
      FROM 
         -- INP1001               AA
           VW_OCS_INP1001_01     AA
         , INP1002               AB
         , OUT0101               F 
     WHERE 1=1
       -- INP1001
       AND AA.HOSP_CODE                   = :f_hosp_code
       AND AA.BUNHO                       LIKE NVL(:f_bunho, '%')
       --AND AA.BUNHO                       LIKE '%'
       --AND AA.PKINP1001                   LIKE :C_FKINP1001
       AND AA.HO_DONG1                    LIKE :f_ho_dong1
       --
       --AND AA.IPWON_DATE                  <= :f_query_date
       --AND (   AA.TOIWON_DATE             IS NULL
       --     OR AA.TOIWON_DATE             > :f_query_date
       --    )
       AND AA.IPWON_DATE                  <= :f_query_date
       AND (   AA.TOIWON_DATE             IS NULL
            OR AA.TOIWON_DATE             > :f_query_date
           )
       -- AND AA.JAEWON_FLAG                = 'Y'                                    
       -- INP1002
       AND AB.HOSP_CODE                   = AA.HOSP_CODE
       AND AB.BUNHO                       = AA.BUNHO
       AND AB.FKINP1001                   = AA.PKINP1001 
       AND AB.GUBUN_IPWON_DATE            <= :f_query_date
       AND (   AB.GUBUN_TOIWON_DATE       IS NULL
            OR AB.GUBUN_TOIWON_DATE       >= :f_query_date
           )
       --
       AND AB.PKINP1002                   = ( SELECT MAX(Z.PKINP1002)
                                                FROM INP1002                  Z 
                                               WHERE Z.HOSP_CODE              = AB.HOSP_CODE
                                                 AND Z.FKINP1001              = AB.FKINP1001
                                                 AND Z.GUBUN_IPWON_DATE       = AB.GUBUN_IPWON_DATE
                                                 AND (   Z.GUBUN_TOIWON_DATE  IS NULL
                                                      OR Z.GUBUN_TOIWON_DATE  >= :f_query_date
                                                     )
                                            )  
       -- HWANJA NAME
       AND F.HOSP_CODE                   = AA.HOSP_CODE
       AND F.BUNHO                       = AA.BUNHO
     ORDER BY 
           AA.HOSP_CODE                                                      
         , INP_FLAG                      DESC                                                 
         --, AA.PKINP1001                                                      
         , AA.HO_DONG1
         , AA.HO_CODE1
";
                #endregion 2013.09.16 LKH S : List of SQL

                this.grdInpList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                //this.grdInpList.SetBindVarValue("f_from_date", this.monthBox.GetDataValue() + "01");
                //this.grdInpList.SetBindVarValue("f_query_date", query_date);
                this.grdInpList.SetBindVarValue("f_from_date", this.dtpJunsongFromDate.GetDataValue());
                this.grdInpList.SetBindVarValue("f_query_date", this.dtpJunsongToDate.GetDataValue());
                this.grdInpList.SetBindVarValue("f_ho_dong1", this.cbxBuseo.GetDataValue());
                this.grdInpList.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
            }

            // 転送済
            if (this.rbnTrans.Checked == true)
            {
                this.grdInpList.QuerySQL = @"SELECT A.PKINP1001
                                                  , A.BUNHO
                                                  , B.SUNAME
                                                  , B.SUNAME2
                                                  , A.GWA                                                                                       GWA
                                                  , FN_BAS_LOAD_GWA_NAME(A.GWA, TRUNC(SYSDATE))                                                 GWA_NAME
                                                  , A.DOCTOR                                                                                    DOCTOR
                                                  , FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, TRUNC(SYSDATE))                                          DOCTOR_NAME
                                                  , A.HO_DONG1                                                                                  HO_DONG1
                                                  , FN_BAS_LOAD_GWA_NAME(A.HO_DONG1, TRUNC(SYSDATE))                                            HO_DONG1_NAME
                                                  , A.HO_CODE1                                                                                  HO_CODE1
                                                  , TO_CHAR(A.IPWON_DATE, 'YYYY/MM/DD')                                                         IPWON_DATE
                                                  , TO_CHAR(NVL(A.TOIWON_DATE, A.TOIWON_RES_DATE), 'YYYY/MM/DD')                                TOIWON_RES_DATE
                                                  , (SELECT DISTINCT 'Y'
                                                      FROM OCS2003 C
                                                     WHERE C.HOSP_CODE = :f_hosp_code
                                                       AND C.FKINP1001 = A.PKINP1001
                                                       AND C.BUNHO     = A.BUNHO
                                                       AND NVL(C.RESER_DATE, C.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date
                                                       AND (    C.JUNDAL_TABLE = 'HOM'
                                                            OR (C.JUNDAL_TABLE <> 'HOM' AND C.OCS_FLAG  = '3')  -- 3:オーダ実施
                                                           )
                                                       AND NVL(C.IF_DATA_SEND_YN, 'N') = 'N'  -- オーダ転送可否
                                                       AND C.IF_DATA_SEND_DATE IS NULL        -- オーダ転送日
                                                       AND C.SG_CODE   IS NOT NULL            -- 内視鏡の仮オーダ区別のため
                                                    )                                                                                           TRANS_ORD_YN
                                                  , (SELECT DISTINCT 'Y'
                                                      FROM OCS2003 C
                                                     WHERE C.HOSP_CODE = :f_hosp_code
                                                       AND C.FKINP1001 = A.PKINP1001
                                                       AND C.BUNHO     = A.BUNHO
                                                       AND NVL(C.RESER_DATE, C.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date
                                                       AND C.OCS_FLAG  IN ('1', '2')  -- 1:オーダ登録, 2:オーダ受付  
                                                       AND C.SG_CODE   IS NOT NULL    -- 内視鏡の仮オーダ区別のため
                                                       AND C.JUNDAL_TABLE <> 'HOM')                                                             ACT_END_YN
                                                  , (SELECT MAX(C.IF_DATA_SEND_DATE)
                                                      FROM OCS2003 C
                                                     WHERE C.HOSP_CODE = 'K01'
                                                       AND C.FKINP1001 = A.PKINP1001
                                                       AND C.BUNHO     = A.BUNHO)                                                               TRANS_DATE
                                                  , NVL(A.TOIWON_GOJI_YN, 'N')                                                                  INP_FLAG
                                               --FROM VW_OCS_INP1001_RES_01 A
                                               FROM VW_OCS_INP1001_01          A
                                                  , OUT0101 B
                                                  , OCS2003 D
                                              WHERE :f_query_date BETWEEN A.IPWON_DATE AND NVL(A.TOIWON_DATE, TO_DATE('99981231', 'YYYYMMDD'))
                                                AND NVL(A.HO_DONG1, '%')       LIKE :f_ho_dong1
                                                --AND NVL(A.IPWON_RESER_YN, 'N') = 'N'                        -- 入院予約患者は除外
                                                --AND NVL(A.CANCEL_YN, 'N')      = 'N'
                                                AND A.BUNHO                    LIKE NVL(:f_bunho, '%')
                                                AND B.HOSP_CODE                = :f_hosp_code
                                                AND B.BUNHO                    = A.BUNHO
                                                AND D.HOSP_CODE                = 'K01'
                                                AND D.FKINP1001                = A.PKINP1001
                                                AND D.BUNHO                    = A.BUNHO
                                                AND NVL(D.RESER_DATE, D.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date
                                                AND NVL(D.IF_DATA_SEND_YN, 'N')= 'Y'
                                                AND D.IF_DATA_SEND_DATE IS NOT NULL
                                                AND D.PKOCS2003 = (SELECT MAX(E.PKOCS2003)
                                                                     FROM OCS2003 E
                                                                    WHERE E.HOSP_CODE                 = :f_hosp_code
                                                                      AND E.FKINP1001                 = A.PKINP1001
                                                                      AND E.BUNHO                     = A.BUNHO
                                                                      AND NVL(E.RESER_DATE, E.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date
                                                                      AND NVL(E.IF_DATA_SEND_YN, 'N') = 'Y'
                                                                      AND E.IF_DATA_SEND_DATE IS NOT NULL)
                                              ORDER BY INP_FLAG DESC, A.HO_DONG1, A.HO_CODE1, A.BED_NO, A.PKINP1001";

                this.grdInpList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                //this.grdInpList.SetBindVarValue("f_from_date", this.monthBox.GetDataValue() + "01");
                //this.grdInpList.SetBindVarValue("f_query_date", query_date);
                this.grdInpList.SetBindVarValue("f_from_date", this.dtpJunsongFromDate.GetDataValue());
                this.grdInpList.SetBindVarValue("f_query_date", this.dtpJunsongToDate.GetDataValue());
                this.grdInpList.SetBindVarValue("f_ho_dong1", this.cbxBuseo.GetDataValue());
                this.grdInpList.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
            }
        }
        #endregion

        #region [grdInpList Query完了]
        private void grdInpList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdInpList.RowCount < 1) return;

            this.setGrdHeaderImage(this.grdInpList);

            this.setGridListSelect();
        }
        #endregion

        #region [GRIDの選択Column基本セット]
        private void setGridListSelect()
        {
            Image image = null;
            string select_yn = "";
            
            // 未転送の場合
            if (this.rbnMiTrans.Checked == true)
            {

                for (int i = 0; i < this.grdInpList.RowCount; i++)
                {
                    // 入院予定、退院予定　患者は未選択にセット
                    if (this.grdInpList.GetItemString(i, "inp_flag") == "Y")
                    {
                        select_yn = "N";
                        image = this.ImageList.Images[1];
                    }
                    else
                    {
                        select_yn = "Y";
                        image = this.ImageList.Images[0];
                    }

                    // 未転送オーダが無い場合、未選択にセット
                    if (!this.grdInpList.GetItemString(i, "trans_ord_yn").Equals("Y"))
                    {
                        select_yn = "N";
                        image = this.ImageList.Images[1];
                    }

                    // 未実施オーダがある場合、未選択にセット
                    if (this.grdInpList.GetItemString(i, "unact_yn") == "Y")
                    {
                        select_yn = "N";
                        image = this.ImageList.Images[1];
                    }

                    this.grdInpList.SetItemValue(i, "select", select_yn);
                    this.grdInpList[i, "select"].Image = image;
                }
            }
            else // 転送済の場合
            {
                for (int i = 0; i < this.grdInpList.RowCount; i++)
                {
                    this.grdInpList.SetItemValue(i, "select", "N");
                    this.grdInpList[i, "select"].Image = this.ImageList.Images[1];
                }
            }
        }
        #endregion

        #region [GRIDの選択Columnコントロール]
        private void grdInpList_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.grdInpList.RowCount < 1) return;

            // GRID範囲内かチェック
            if (this.grdInpList.GetHitRowNumber(e.Y) < 0) return;

            Image image = null;
            int rowNumber = -1;
            string select_yn = "";

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowNumber = this.grdInpList.GetHitRowNumber(e.Y);

                if (this.grdInpList.CurrentColName == "select")
                {
                    if (this.grdInpList.GetItemString(rowNumber, "select") == "Y")
                    {
                        select_yn = "N";
                        image = this.ImageList.Images[1];
                    }
                    else
                    {
                        // 未転送のみチェック
                        if (this.rbnMiTrans.Checked == true)
                        {
                            if (!this.grdInpList.GetItemString(rowNumber, "trans_ord_yn").Equals("Y"))
                            {
                                XMessageBox.Show("転送対象データがありません。", "転送対象データ無し", MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        select_yn = "Y";
                        image = this.ImageList.Images[0];
                    }

                    this.grdInpList.SetItemValue(rowNumber, "select", select_yn);
                    this.grdInpList[rowNumber, "select"].Image = image;
                }
            }
        }
        #endregion

        #region 그리드이미지셋팅
        private void setGrdHeaderImage(XEditGrid grid)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                // 退院予定患者
                if (grid.Name == "grdInpList" && grid.GetItemString(i, "inp_flag") == "Y")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[9];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "退院予定";
                }
            }
        }
        #endregion

        #region [入院オーダ転送画面を開く]
        private void btnINPORDERTRANS_Click(object sender, EventArgs e)
        {
            // 入院オーダ転送画面を開く。
            this.OpenScreen_INPORDERTRANS();
        }

        private void OpenScreen_INPORDERTRANS()
        {
            if (this.grdInpList.RowCount < 1) return;

            //string from_date = this.monthBox.GetDataValue() + "01";
            //string to_date = query_date;

            //from_date = from_date.Substring(0, 4) + "/" + from_date.Substring(4, 2) + "/" + from_date.Substring(6);
            //to_date = to_date.Substring(0, 4) + "/" + to_date.Substring(4, 2) + "/" + to_date.Substring(6);

            CommonItemCollection param = new CommonItemCollection();
            param.Add("bunho", this.grdInpList.GetItemString(this.grdInpList.CurrentRowNumber, "bunho"));
            //param.Add("from_date", from_date);
            //param.Add("to_date", to_date);
            param.Add("from_date", this.dtpJunsongFromDate.GetDataValue());
            param.Add("to_date", this.dtpJunsongToDate.GetDataValue());
            XScreen.OpenScreenWithParam(this, "NURI", "INPORDERTRANS", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopCenter , param);
        }

        private void grdInpList_DoubleClick(object sender, EventArgs e)
        {
            // チェック操作とダブルクリック操作を区分
            if(this.grdInpList.CurrentColName.Equals("select")) return;

            // 入院オーダ転送画面を開く。
            this.OpenScreen_INPORDERTRANS();
        }
        #endregion

        #region [検索日付変更]
        private void dtpJunsongFromDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void dtpJunsongToDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion
    }
}

