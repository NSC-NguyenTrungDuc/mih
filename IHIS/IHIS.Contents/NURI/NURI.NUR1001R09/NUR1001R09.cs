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
	/// NUR1001R09에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1001R09 : IHIS.Framework.XScreen
	{
		#region 자동생성

		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlLedt;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XPanel pnlLeftTop;
		private IHIS.Framework.XEditGrid grdINP1001;
		private IHIS.Framework.XLabel lblHo_dong1;
		private IHIS.Framework.XBuseoCombo cboHo_dong;
		private IHIS.Framework.XDictComboBox cboWing_gubun;
		private IHIS.Framework.XLabel lblWing_gubun;
		private IHIS.Framework.XLabel lblGwa;
		private IHIS.Framework.XBuseoCombo cboGwa;
		private IHIS.Framework.XButton btnQuery;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XPanel pnl1;
		private IHIS.Framework.XPanel pnl2;
		private IHIS.Framework.XPanel pnl3;
		private IHIS.Framework.XPanel pnl4;
		private IHIS.Framework.XPanel pnl5;
		private IHIS.Framework.XPanel pnl6;
		private IHIS.Framework.XRadioButton rb1;
		private IHIS.Framework.XRadioButton rb2;
		private IHIS.Framework.XRadioButton rb3;
		private IHIS.Framework.XRadioButton rb4;
		private IHIS.Framework.XRadioButton rb5;
		private IHIS.Framework.XRadioButton rb6;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
        //private IHIS.Framework.DataServiceSIMO dsvHodong_Print_List;
		private IHIS.Framework.MultiLayout layHodong_Print_List;
        //private IHIS.Framework.DataServiceSIMO dsvQuery;
		private System.Windows.Forms.ImageList imageList1;
		private IHIS.Framework.XDataWindow dw_NUR1001R09_5;
		private IHIS.Framework.XDataWindow dw_NUR1001R09_1;
		private IHIS.Framework.XDataWindow dw_NUR1001R09_2;
		private IHIS.Framework.XDataWindow dw_NUR1001R09_3;
		private IHIS.Framework.XDataWindow dw_NUR1001R09_4;
		private IHIS.Framework.XDataWindow dw_NUR1001R09_6;
		private IHIS.Framework.XButton btnAllCheck;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
        private MultiLayoutItem multiLayoutItem1;
		private System.ComponentModel.IContainer components;
		#endregion

		#region 생성자
		public NUR1001R09()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1001R09));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.dw_NUR1001R09_6 = new IHIS.Framework.XDataWindow();
            this.dw_NUR1001R09_4 = new IHIS.Framework.XDataWindow();
            this.dw_NUR1001R09_3 = new IHIS.Framework.XDataWindow();
            this.dw_NUR1001R09_2 = new IHIS.Framework.XDataWindow();
            this.dw_NUR1001R09_1 = new IHIS.Framework.XDataWindow();
            this.dw_NUR1001R09_5 = new IHIS.Framework.XDataWindow();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlLedt = new IHIS.Framework.XPanel();
            this.btnAllCheck = new IHIS.Framework.XButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grdINP1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.pnlLeftTop = new IHIS.Framework.XPanel();
            this.btnQuery = new IHIS.Framework.XButton();
            this.cboGwa = new IHIS.Framework.XBuseoCombo();
            this.lblGwa = new IHIS.Framework.XLabel();
            this.cboWing_gubun = new IHIS.Framework.XDictComboBox();
            this.lblWing_gubun = new IHIS.Framework.XLabel();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblHo_dong1 = new IHIS.Framework.XLabel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.pnl6 = new IHIS.Framework.XPanel();
            this.rb6 = new IHIS.Framework.XRadioButton();
            this.pnl5 = new IHIS.Framework.XPanel();
            this.rb5 = new IHIS.Framework.XRadioButton();
            this.pnl4 = new IHIS.Framework.XPanel();
            this.rb4 = new IHIS.Framework.XRadioButton();
            this.pnl3 = new IHIS.Framework.XPanel();
            this.rb3 = new IHIS.Framework.XRadioButton();
            this.pnl2 = new IHIS.Framework.XPanel();
            this.rb2 = new IHIS.Framework.XRadioButton();
            this.pnl1 = new IHIS.Framework.XPanel();
            this.rb1 = new IHIS.Framework.XRadioButton();
            this.layHodong_Print_List = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlLedt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).BeginInit();
            this.pnlLeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.pnl6.SuspendLayout();
            this.pnl5.SuspendLayout();
            this.pnl4.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layHodong_Print_List)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageSize = new System.Drawing.Size(28, 28);
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.dw_NUR1001R09_6);
            this.pnlBottom.Controls.Add(this.dw_NUR1001R09_4);
            this.pnlBottom.Controls.Add(this.dw_NUR1001R09_3);
            this.pnlBottom.Controls.Add(this.dw_NUR1001R09_2);
            this.pnlBottom.Controls.Add(this.dw_NUR1001R09_1);
            this.pnlBottom.Controls.Add(this.dw_NUR1001R09_5);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(584, 552);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(376, 38);
            this.pnlBottom.TabIndex = 1;
            // 
            // dw_NUR1001R09_6
            // 
            this.dw_NUR1001R09_6.DataWindowObject = "dw_nur1001r09_6";
            this.dw_NUR1001R09_6.LibraryList = "..\\NURI\\nuri.nur1001r09.pbd";
            this.dw_NUR1001R09_6.Location = new System.Drawing.Point(179, 7);
            this.dw_NUR1001R09_6.Name = "dw_NUR1001R09_6";
            this.dw_NUR1001R09_6.Size = new System.Drawing.Size(26, 24);
            this.dw_NUR1001R09_6.TabIndex = 6;
            this.dw_NUR1001R09_6.Text = "xDataWindow3";
            this.dw_NUR1001R09_6.Visible = false;
            // 
            // dw_NUR1001R09_4
            // 
            this.dw_NUR1001R09_4.DataWindowObject = "dw_nur1001r09_4";
            this.dw_NUR1001R09_4.LibraryList = "..\\NURI\\nuri.nur1001r09.pbd";
            this.dw_NUR1001R09_4.Location = new System.Drawing.Point(112, 7);
            this.dw_NUR1001R09_4.Name = "dw_NUR1001R09_4";
            this.dw_NUR1001R09_4.Size = new System.Drawing.Size(26, 24);
            this.dw_NUR1001R09_4.TabIndex = 5;
            this.dw_NUR1001R09_4.Text = "xDataWindow2";
            this.dw_NUR1001R09_4.Visible = false;
            // 
            // dw_NUR1001R09_3
            // 
            this.dw_NUR1001R09_3.DataWindowObject = "dw_nur1001r09_7";
            this.dw_NUR1001R09_3.LibraryList = "..\\NURI\\nuri.nur1001r09.pbd";
            this.dw_NUR1001R09_3.Location = new System.Drawing.Point(80, 7);
            this.dw_NUR1001R09_3.Name = "dw_NUR1001R09_3";
            this.dw_NUR1001R09_3.Size = new System.Drawing.Size(26, 24);
            this.dw_NUR1001R09_3.TabIndex = 4;
            this.dw_NUR1001R09_3.Text = "xDataWindow1";
            this.dw_NUR1001R09_3.Visible = false;
            // 
            // dw_NUR1001R09_2
            // 
            this.dw_NUR1001R09_2.DataWindowObject = "dw_nur1001r09_2";
            this.dw_NUR1001R09_2.LibraryList = "..\\NURI\\nuri.nur1001r09.pbd";
            this.dw_NUR1001R09_2.Location = new System.Drawing.Point(44, 8);
            this.dw_NUR1001R09_2.Name = "dw_NUR1001R09_2";
            this.dw_NUR1001R09_2.Size = new System.Drawing.Size(26, 24);
            this.dw_NUR1001R09_2.TabIndex = 3;
            this.dw_NUR1001R09_2.Text = "xDataWindow1";
            this.dw_NUR1001R09_2.Visible = false;
            // 
            // dw_NUR1001R09_1
            // 
            this.dw_NUR1001R09_1.DataWindowObject = "dw_nur1001r09_1";
            this.dw_NUR1001R09_1.LibraryList = "..\\NURI\\nuri.nur1001r09.pbd";
            this.dw_NUR1001R09_1.Location = new System.Drawing.Point(8, 8);
            this.dw_NUR1001R09_1.Name = "dw_NUR1001R09_1";
            this.dw_NUR1001R09_1.Size = new System.Drawing.Size(26, 24);
            this.dw_NUR1001R09_1.TabIndex = 2;
            this.dw_NUR1001R09_1.Text = "xDataWindow1";
            this.dw_NUR1001R09_1.Visible = false;
            // 
            // dw_NUR1001R09_5
            // 
            this.dw_NUR1001R09_5.DataWindowObject = "dw_nur1001r09_5";
            this.dw_NUR1001R09_5.LibraryList = "..\\NURI\\nuri.nur1001r09.pbd";
            this.dw_NUR1001R09_5.Location = new System.Drawing.Point(144, 8);
            this.dw_NUR1001R09_5.Name = "dw_NUR1001R09_5";
            this.dw_NUR1001R09_5.Size = new System.Drawing.Size(26, 24);
            this.dw_NUR1001R09_5.TabIndex = 1;
            this.dw_NUR1001R09_5.Text = "xDataWindow1";
            this.dw_NUR1001R09_5.Visible = false;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.IsVisiblePreview = false;
            this.btnList.Location = new System.Drawing.Point(213, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Print;
            this.btnList.Size = new System.Drawing.Size(163, 38);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlLedt
            // 
            this.pnlLedt.Controls.Add(this.btnAllCheck);
            this.pnlLedt.Controls.Add(this.grdINP1001);
            this.pnlLedt.Controls.Add(this.pnlLeftTop);
            this.pnlLedt.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLedt.Location = new System.Drawing.Point(0, 0);
            this.pnlLedt.Name = "pnlLedt";
            this.pnlLedt.Size = new System.Drawing.Size(584, 590);
            this.pnlLedt.TabIndex = 2;
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAllCheck.ImageList = this.imageList1;
            this.btnAllCheck.Location = new System.Drawing.Point(26, 33);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(37, 22);
            this.btnAllCheck.TabIndex = 7;
            this.btnAllCheck.Tag = "N";
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
            this.imageList1.Images.SetKeyName(2, "전송_16.gif");
            // 
            // grdINP1001
            // 
            this.grdINP1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell13,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdINP1001.ColPerLine = 6;
            this.grdINP1001.Cols = 7;
            this.grdINP1001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1001.FixedCols = 1;
            this.grdINP1001.FixedRows = 1;
            this.grdINP1001.HeaderHeights.Add(21);
            this.grdINP1001.Location = new System.Drawing.Point(0, 33);
            this.grdINP1001.Name = "grdINP1001";
            this.grdINP1001.QuerySQL = resources.GetString("grdINP1001.QuerySQL");
            this.grdINP1001.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdINP1001.RowHeaderVisible = true;
            this.grdINP1001.Rows = 2;
            this.grdINP1001.RowStateCheckOnPaint = false;
            this.grdINP1001.Size = new System.Drawing.Size(584, 557);
            this.grdINP1001.TabIndex = 1;
            this.grdINP1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1001_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gwa";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "診療科";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 130;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "診療科";
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "患者番号";
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 130;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "患者氏名";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "suname2";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "suname2";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sex";
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "性別";
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "age";
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "年齢";
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "birth";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "birth";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "address1";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "address1";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "address2";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "address2";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "doctor";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "doctor";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "doctor_name";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "doctor_name";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "check";
            this.xEditGridCell12.CellWidth = 38;
            this.xEditGridCell12.Col = 1;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "C";
            // 
            // pnlLeftTop
            // 
            this.pnlLeftTop.Controls.Add(this.btnQuery);
            this.pnlLeftTop.Controls.Add(this.cboGwa);
            this.pnlLeftTop.Controls.Add(this.lblGwa);
            this.pnlLeftTop.Controls.Add(this.cboWing_gubun);
            this.pnlLeftTop.Controls.Add(this.lblWing_gubun);
            this.pnlLeftTop.Controls.Add(this.cboHo_dong);
            this.pnlLeftTop.Controls.Add(this.lblHo_dong1);
            this.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftTop.Name = "pnlLeftTop";
            this.pnlLeftTop.Size = new System.Drawing.Size(584, 33);
            this.pnlLeftTop.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageIndex = 2;
            this.btnQuery.ImageList = this.imageList1;
            this.btnQuery.Location = new System.Drawing.Point(554, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnQuery.Size = new System.Drawing.Size(28, 23);
            this.btnQuery.TabIndex = 97;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboGwa
            // 
            this.cboGwa.IsAppendAll = true;
            this.cboGwa.Location = new System.Drawing.Point(244, 6);
            this.cboGwa.MaxDropDownItems = 40;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.Size = new System.Drawing.Size(135, 21);
            this.cboGwa.TabIndex = 96;
            this.cboGwa.SelectionChangeCommitted += new System.EventHandler(this.cboHo_dong_SelectionChangeCommitted);
            // 
            // lblGwa
            // 
            this.lblGwa.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblGwa.EdgeRounding = false;
            this.lblGwa.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblGwa.Location = new System.Drawing.Point(179, 6);
            this.lblGwa.Name = "lblGwa";
            this.lblGwa.Size = new System.Drawing.Size(65, 21);
            this.lblGwa.TabIndex = 95;
            this.lblGwa.Text = "診療科";
            this.lblGwa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboWing_gubun
            // 
            this.cboWing_gubun.Location = new System.Drawing.Point(444, 6);
            this.cboWing_gubun.MaxDropDownItems = 40;
            this.cboWing_gubun.Name = "cboWing_gubun";
            this.cboWing_gubun.Size = new System.Drawing.Size(107, 21);
            this.cboWing_gubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboWing_gubun.TabIndex = 94;
            this.cboWing_gubun.UserSQL = resources.GetString("cboWing_gubun.UserSQL");
            this.cboWing_gubun.Visible = false;
            this.cboWing_gubun.SelectionChangeCommitted += new System.EventHandler(this.cboHo_dong_SelectionChangeCommitted);
            // 
            // lblWing_gubun
            // 
            this.lblWing_gubun.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblWing_gubun.EdgeRounding = false;
            this.lblWing_gubun.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblWing_gubun.Location = new System.Drawing.Point(379, 6);
            this.lblWing_gubun.Name = "lblWing_gubun";
            this.lblWing_gubun.Size = new System.Drawing.Size(65, 21);
            this.lblWing_gubun.TabIndex = 93;
            this.lblWing_gubun.Text = "ウイング";
            this.lblWing_gubun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWing_gubun.Visible = false;
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHo_dong.Location = new System.Drawing.Point(70, 6);
            this.cboHo_dong.MaxDropDownItems = 40;
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(107, 21);
            this.cboHo_dong.TabIndex = 1;
            this.cboHo_dong.SelectionChangeCommitted += new System.EventHandler(this.cboHo_dong_SelectionChangeCommitted);
            // 
            // lblHo_dong1
            // 
            this.lblHo_dong1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong1.EdgeRounding = false;
            this.lblHo_dong1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong1.Location = new System.Drawing.Point(5, 6);
            this.lblHo_dong1.Name = "lblHo_dong1";
            this.lblHo_dong1.Size = new System.Drawing.Size(65, 21);
            this.lblHo_dong1.TabIndex = 0;
            this.lblHo_dong1.Text = "病棟";
            this.lblHo_dong1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnl6);
            this.pnlFill.Controls.Add(this.pnl5);
            this.pnlFill.Controls.Add(this.pnl4);
            this.pnlFill.Controls.Add(this.pnl3);
            this.pnlFill.Controls.Add(this.pnl2);
            this.pnlFill.Controls.Add(this.pnl1);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(584, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(376, 552);
            this.pnlFill.TabIndex = 3;
            // 
            // pnl6
            // 
            this.pnl6.Controls.Add(this.rb6);
            this.pnl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl6.Location = new System.Drawing.Point(0, 460);
            this.pnl6.Name = "pnl6";
            this.pnl6.Size = new System.Drawing.Size(376, 92);
            this.pnl6.TabIndex = 5;
            // 
            // rb6
            // 
            this.rb6.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb6.BackColor = IHIS.Framework.XColor.XDisplayBoxBorderColor;
            this.rb6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb6.Enabled = false;
            this.rb6.Font = new System.Drawing.Font("MS PMincho", 36F, System.Drawing.FontStyle.Bold);
            this.rb6.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rb6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rb6.ImageIndex = 0;
            this.rb6.ImageList = this.ImageList;
            this.rb6.Location = new System.Drawing.Point(0, 0);
            this.rb6.Name = "rb6";
            this.rb6.Size = new System.Drawing.Size(376, 92);
            this.rb6.TabIndex = 3;
            this.rb6.Tag = "N";
            this.rb6.Text = "住所";
            this.rb6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb6.UseVisualStyleBackColor = false;
            this.rb6.Click += new System.EventHandler(this.rb1_Click);
            // 
            // pnl5
            // 
            this.pnl5.Controls.Add(this.rb5);
            this.pnl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl5.Location = new System.Drawing.Point(0, 368);
            this.pnl5.Name = "pnl5";
            this.pnl5.Size = new System.Drawing.Size(376, 92);
            this.pnl5.TabIndex = 4;
            // 
            // rb5
            // 
            this.rb5.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb5.BackColor = IHIS.Framework.XColor.XDisplayBoxBorderColor;
            this.rb5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb5.Enabled = false;
            this.rb5.Font = new System.Drawing.Font("MS PMincho", 36F, System.Drawing.FontStyle.Bold);
            this.rb5.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rb5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rb5.ImageIndex = 0;
            this.rb5.ImageList = this.ImageList;
            this.rb5.Location = new System.Drawing.Point(0, 0);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(376, 92);
            this.rb5.TabIndex = 3;
            this.rb5.Tag = "N";
            this.rb5.Text = "ルームネーム";
            this.rb5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb5.UseVisualStyleBackColor = false;
            this.rb5.Click += new System.EventHandler(this.rb1_Click);
            // 
            // pnl4
            // 
            this.pnl4.Controls.Add(this.rb4);
            this.pnl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl4.Location = new System.Drawing.Point(0, 276);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(376, 92);
            this.pnl4.TabIndex = 3;
            // 
            // rb4
            // 
            this.rb4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb4.BackColor = IHIS.Framework.XColor.XDisplayBoxBorderColor;
            this.rb4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb4.Enabled = false;
            this.rb4.Font = new System.Drawing.Font("MS PMincho", 36F, System.Drawing.FontStyle.Bold);
            this.rb4.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rb4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rb4.ImageIndex = 0;
            this.rb4.ImageList = this.ImageList;
            this.rb4.Location = new System.Drawing.Point(0, 0);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(376, 92);
            this.rb4.TabIndex = 3;
            this.rb4.Tag = "N";
            this.rb4.Text = "ベッドネーム";
            this.rb4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb4.UseVisualStyleBackColor = false;
            this.rb4.Click += new System.EventHandler(this.rb1_Click);
            // 
            // pnl3
            // 
            this.pnl3.Controls.Add(this.rb3);
            this.pnl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl3.Location = new System.Drawing.Point(0, 184);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(376, 92);
            this.pnl3.TabIndex = 2;
            // 
            // rb3
            // 
            this.rb3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb3.BackColor = IHIS.Framework.XColor.XDisplayBoxBorderColor;
            this.rb3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb3.Font = new System.Drawing.Font("MS PMincho", 36F, System.Drawing.FontStyle.Bold);
            this.rb3.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rb3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rb3.ImageIndex = 0;
            this.rb3.ImageList = this.ImageList;
            this.rb3.Location = new System.Drawing.Point(0, 0);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(376, 92);
            this.rb3.TabIndex = 3;
            this.rb3.Tag = "N";
            this.rb3.Text = "リストバンド";
            this.rb3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb3.UseVisualStyleBackColor = false;
            this.rb3.Click += new System.EventHandler(this.rb1_Click);
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.rb2);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl2.Location = new System.Drawing.Point(0, 92);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(376, 92);
            this.pnl2.TabIndex = 1;
            // 
            // rb2
            // 
            this.rb2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb2.BackColor = IHIS.Framework.XColor.XDisplayBoxBorderColor;
            this.rb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb2.Enabled = false;
            this.rb2.Font = new System.Drawing.Font("MS PMincho", 36F, System.Drawing.FontStyle.Bold);
            this.rb2.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rb2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rb2.ImageIndex = 0;
            this.rb2.ImageList = this.ImageList;
            this.rb2.Location = new System.Drawing.Point(0, 0);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(376, 92);
            this.rb2.TabIndex = 3;
            this.rb2.Tag = "N";
            this.rb2.Text = "カルテネーム";
            this.rb2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb2.UseVisualStyleBackColor = false;
            this.rb2.Click += new System.EventHandler(this.rb1_Click);
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.rb1);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(376, 92);
            this.pnl1.TabIndex = 0;
            // 
            // rb1
            // 
            this.rb1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb1.BackColor = IHIS.Framework.XColor.XDisplayBoxBorderColor;
            this.rb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb1.Enabled = false;
            this.rb1.Font = new System.Drawing.Font("MS PMincho", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb1.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rb1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rb1.ImageIndex = 0;
            this.rb1.ImageList = this.ImageList;
            this.rb1.Location = new System.Drawing.Point(0, 0);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(376, 92);
            this.rb1.TabIndex = 2;
            this.rb1.Tag = "N";
            this.rb1.Text = "ナースコール";
            this.rb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb1.UseVisualStyleBackColor = false;
            this.rb1.Click += new System.EventHandler(this.rb1_Click);
            // 
            // layHodong_Print_List
            // 
            this.layHodong_Print_List.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1});
            this.layHodong_Print_List.QuerySQL = "SELECT A.CODE CODE\r\n  FROM NUR0102 A\r\n WHERE A.HOSP_CODE = :f_hosp_code  \r\n   AND" +
                " A.CODE_TYPE = \'HO_DONG_NAME_GUBUN\'||\'_\'||:f_ho_dong\r\n ORDER BY 1";
            this.layHodong_Print_List.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layHodong_Print_List_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // NUR1001R09
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlLedt);
            this.Name = "NUR1001R09";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1001R09_ScreenOpen);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlLedt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).EndInit();
            this.pnlLeftTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnl6.ResumeLayout(false);
            this.pnl5.ResumeLayout(false);
            this.pnl4.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layHodong_Print_List)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 출력물 선택시 색상과 이미지 변경(클릭시)
		private void Click_SetCheckImage(object sender)
		{
			IHIS.Framework.XRadioButton rb = (IHIS.Framework.XRadioButton)sender;

			if (rb.Tag.ToString() == "N")
			{
                rb.BackColor = XColor.ActiveBorderColor; // new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveBorderColor);
				rb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rb.Tag = "Y";
				rb.Checked = true;
				rb.ImageIndex = 1;
			}
			else
			{
                rb.BackColor = XColor.XDisplayBoxBorderColor; // new IHIS.Framework.XColor(System.Drawing.SystemColors.XDisplayBoxBorderColor);
				rb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rb.Tag = "N";
				rb.Checked = false;
				rb.ImageIndex = 0;
			}
		}
		#endregion

		#region 병동별 출력물 디폴트 셋팅
		private void SetHodongPrintImage()
		{
			if (this.cboHo_dong.GetDataValue().ToString() == "") return;

			if (this.layHodong_Print_List.QueryLayout(true))
			{
				//전체 클리어
				rb1.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
				rb1.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rb1.Tag = "N";
				rb1.Checked = false;
				rb1.ImageIndex = 0;

				rb2.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
				rb2.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rb2.Tag = "N";
				rb2.Checked = false;
				rb2.ImageIndex = 0;

				rb3.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
				rb3.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rb3.Tag = "Y";
				rb3.Checked = true;
				rb3.ImageIndex = 1;

				rb4.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
				rb4.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rb4.Tag = "N";
				rb4.Checked = false;
				rb4.ImageIndex = 0;

				rb5.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
				rb5.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rb5.Tag = "N";
				rb5.Checked = false;
				rb5.ImageIndex = 0;

				rb6.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
				rb6.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rb6.Tag = "N";
				rb6.Checked = false;
				rb6.ImageIndex = 0;
                /*
				for (int i = 0; i < this.layHodong_Print_List.RowCount; i++)
				{
					switch(this.layHodong_Print_List.GetItemString(i, "code").ToString())
					{
						case "1":
							rb1.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
							rb1.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
							rb1.Tag = "Y";
							rb1.Checked = true;
							rb1.ImageIndex = 1;
							break;
						case "2":
							rb2.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
							rb2.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
							rb2.Tag = "Y";
							rb2.Checked = true;
							rb2.ImageIndex = 1;
							break;
						case "3":
							rb3.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
							rb3.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
							rb3.Tag = "Y";
							rb3.Checked = true;
							rb3.ImageIndex = 1;
							break;
						case "4":
							rb4.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
							rb4.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
							rb4.Tag = "Y";
							rb4.Checked = true;
							rb4.ImageIndex = 1;
							break;
						case "5":
							rb5.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
							rb5.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
							rb5.Tag = "Y";
							rb5.Checked = true;
							rb5.ImageIndex = 1;
							break;
						case "6":
							rb6.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
							rb6.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
							rb6.Tag = "Y";
							rb6.Checked = true;
							rb6.ImageIndex = 1;
							break;
						default:
							break;
					}
				}*/
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}
		}
		#endregion

		#region 조회
		private void GetQuery()
		{
			if (this.cboHo_dong.GetDataValue().ToString() == "") return;

			if (this.cboWing_gubun.GetDataValue().ToString() == "") return;

			if (this.cboGwa.GetDataValue().ToString() == "") return;

			this.grdINP1001.Reset();

			this.btnAllCheck.ImageIndex = 0;
			this.btnAllCheck.Tag = "N";

			if (!this.grdINP1001.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}
		}
		#endregion

		#region 인쇄
		private void SetPrint(string aPrintGubun, int aRow)
		{
			this.dw_NUR1001R09_1.Reset();
			this.dw_NUR1001R09_2.Reset();
			this.dw_NUR1001R09_3.Reset();
			this.dw_NUR1001R09_4.Reset();
			this.dw_NUR1001R09_5.Reset();
			this.dw_NUR1001R09_6.Reset();
			
			switch(aPrintGubun)
			{
				case "1": //환자명
					this.dw_NUR1001R09_1.InsertRow(1);
                    this.dw_NUR1001R09_1.SetItemString(this.dw_NUR1001R09_1.CurrentRow, "suname", this.grdINP1001.GetItemValue(aRow, "suname").ToString());
                    this.dw_NUR1001R09_1.SetItemString(this.dw_NUR1001R09_1.CurrentRow, "suname2", this.grdINP1001.GetItemValue(aRow, "suname2").ToString());
					this.dw_NUR1001R09_1.AcceptText();

                    //string origin_print_1 = dw_NUR1001R09_1.PrintProperties.PrinterName;
                    //string print_name_1 = "";

                    //foreach( string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters )
                    //{
                    //    if ( s == "SATO" )
                    //    {
                    //        print_name_1 = "SATO";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if ( s.IndexOf("SATO") >= 0 )
                    //        {
                    //            print_name_1 = s;
                    //        }
                    //    }
                    //}
                    //if ( print_name_1.IndexOf("SATO") < 0 )
                    //{
                    //    dw_NUR1001R09_1.PrintDialog(true);
                    //}
                    //else
                    //{
                    //    IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name_1);
                    dw_NUR1001R09_1.Print(true);
                    //}
					
                    //IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print_1);

					break;
				case "2": //환자명
					this.dw_NUR1001R09_2.InsertRow(1);
                    this.dw_NUR1001R09_2.SetItemString(this.dw_NUR1001R09_2.CurrentRow, "suname", this.grdINP1001.GetItemValue(aRow, "suname").ToString());
                    this.dw_NUR1001R09_2.SetItemString(this.dw_NUR1001R09_2.CurrentRow, "suname2", this.grdINP1001.GetItemValue(aRow, "suname2").ToString());
					this.dw_NUR1001R09_2.AcceptText();

                    //string origin_print_2 = dw_NUR1001R09_2.PrintProperties.PrinterName;
                    //string print_name_2 = "";

                    //foreach( string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters )
                    //{
                    //    if ( s == "SATO" )
                    //    {
                    //        print_name_2 = "SATO";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if ( s.IndexOf("SATO") >= 0 )
                    //        {
                    //            print_name_2 = s;
                    //        }
                    //    }
                    //}
                    //if ( print_name_2.IndexOf("SATO") < 0 )
                    //{
                    //    dw_NUR1001R09_2.PrintDialog(true);
                    //}
                    //else
                    //{
                    //    IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name_2);
                    dw_NUR1001R09_2.Print(true);
                    //}
					
                    //IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print_2);
					break;
				case "3": //환자번호, 생년월일, 환자명
					this.dw_NUR1001R09_3.InsertRow(1);
					this.dw_NUR1001R09_3.SetItemString(this.dw_NUR1001R09_3.CurrentRow, "bunho" , this.grdINP1001.GetItemValue(aRow, "bunho").ToString());
					this.dw_NUR1001R09_3.SetItemString(this.dw_NUR1001R09_3.CurrentRow, "blood_type" , "");
                    this.dw_NUR1001R09_3.SetItemString(this.dw_NUR1001R09_3.CurrentRow, "birth", this.grdINP1001.GetItemValue(aRow, "birth").ToString());
                    this.dw_NUR1001R09_3.SetItemString(this.dw_NUR1001R09_3.CurrentRow, "age", this.grdINP1001.GetItemValue(aRow, "age").ToString());
                    this.dw_NUR1001R09_3.SetItemString(this.dw_NUR1001R09_3.CurrentRow, "sex", this.grdINP1001.GetItemValue(aRow, "sex").ToString());
                    this.dw_NUR1001R09_3.SetItemString(this.dw_NUR1001R09_3.CurrentRow, "suname", this.grdINP1001.GetItemValue(aRow, "suname").ToString());
                    this.dw_NUR1001R09_3.SetItemString(this.dw_NUR1001R09_3.CurrentRow, "suname2", this.grdINP1001.GetItemValue(aRow, "suname2").ToString());
                    this.dw_NUR1001R09_3.SetItemString(this.dw_NUR1001R09_3.CurrentRow, "bunho_barcode", "a"+this.grdINP1001.GetItemValue(aRow, "bunho").ToString()+"a");
                    //this.dw_NUR1001R09_3.SetItemString(this.dw_NUR1001R09_3.CurrentRow, "bunho_barcode", this.grdINP1001.GetItemValue(aRow, "bunho").ToString());

                    this.dw_NUR1001R09_3.AcceptText();

                    string origin_print_3 = IHIS.Framework.PrintHelper.GetDefaultPrinterName();
                    string print_name_3 = "";

                    try
                    {
                        foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                        {
                            if (s == "SATO")
                            {
                                print_name_3 = "SATO";
                                break;
                            }
                            else
                            {
                                if (s.IndexOf("SATO") >= 0)
                                {
                                    print_name_3 = s;
                                }
                            }
                        }
                        if (print_name_3.IndexOf("SATO") < 0)
                        {
                            dw_NUR1001R09_3.PrintDialog(true);
                        }
                        else
                        {
                            IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name_3);

                            //XMessageBox.Show(print_name_3);
                            dw_NUR1001R09_3.Print(true);
                        }
                    }
                    finally
                    {
                        IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print_3);
                    }
					break;
				case "4": //환자명
					this.dw_NUR1001R09_4.InsertRow(1);
                    this.dw_NUR1001R09_4.SetItemString(this.dw_NUR1001R09_4.CurrentRow, "suname", this.grdINP1001.GetItemValue(aRow, "suname").ToString());
                    this.dw_NUR1001R09_4.SetItemString(this.dw_NUR1001R09_4.CurrentRow, "suname2", this.grdINP1001.GetItemValue(aRow, "suname2").ToString());
					this.dw_NUR1001R09_4.AcceptText();
					
					string origin_print_4 = dw_NUR1001R09_4.PrintProperties.PrinterName;
					string print_name_4 = "";

                    //foreach( string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters )
                    //{
                    //    if ( s == "SATO" )
                    //    {
                    //        print_name_4 = "SATO";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if ( s.IndexOf("SATO") >= 0 )
                    //        {
                    //            print_name_4 = s;
                    //        }
                    //    }
                    //}
                    //if ( print_name_4.IndexOf("SATO") < 0 )
                    //{
                    //    dw_NUR1001R09_4.PrintDialog(true);
                    //}
                    //else
                    //{
                    //    IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name_4);
                    dw_NUR1001R09_4.Print(true);
                    //}
					
                    //IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print_4);
					break;
				case "5": //환자명
					this.dw_NUR1001R09_5.InsertRow(1);
                    this.dw_NUR1001R09_5.SetItemString(this.dw_NUR1001R09_5.CurrentRow, "suname", this.grdINP1001.GetItemValue(aRow, "suname").ToString());
                    this.dw_NUR1001R09_5.SetItemString(this.dw_NUR1001R09_5.CurrentRow, "suname2", this.grdINP1001.GetItemValue(aRow, "suname2").ToString());
					this.dw_NUR1001R09_5.AcceptText();
					
					string origin_print_5 = dw_NUR1001R09_5.PrintProperties.PrinterName;
					string print_name_5 = "";

                    //foreach( string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters )
                    //{
                    //    if ( s == "SATO" )
                    //    {
                    //        print_name_5 = "SATO";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if ( s.IndexOf("SATO") >= 0 )
                    //        {
                    //            print_name_5 = s;
                    //        }
                    //    }
                    //}
                    //if ( print_name_5.IndexOf("SATO") < 0 )
                    //{
                    //    dw_NUR1001R09_5.PrintDialog(true);
                    //}
                    //else
                    //{
                    //    IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name_5);
                    dw_NUR1001R09_5.Print(true);
                    //}

                    //IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print_5);
					break;
				case "6": //혼자번호, 환자명, 주소
					this.dw_NUR1001R09_6.InsertRow(1);
					this.dw_NUR1001R09_6.SetItemString(this.dw_NUR1001R09_6.CurrentRow, "bunho"  , this.grdINP1001.GetItemValue(aRow, "bunho").ToString());
                    this.dw_NUR1001R09_6.SetItemString(this.dw_NUR1001R09_6.CurrentRow, "suname", this.grdINP1001.GetItemValue(aRow, "suname").ToString());
                    this.dw_NUR1001R09_6.SetItemString(this.dw_NUR1001R09_6.CurrentRow, "suname2", this.grdINP1001.GetItemValue(aRow, "suname2").ToString());
					this.dw_NUR1001R09_6.SetItemString(this.dw_NUR1001R09_6.CurrentRow, "address1", this.grdINP1001.GetItemValue(aRow, "address1").ToString());
					this.dw_NUR1001R09_6.SetItemString(this.dw_NUR1001R09_6.CurrentRow, "address2", this.grdINP1001.GetItemValue(aRow, "address2").ToString());
					this.dw_NUR1001R09_6.AcceptText();
					
					string origin_print_6 = dw_NUR1001R09_6.PrintProperties.PrinterName;
					string print_name_6 = "";

                    //foreach( string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters )
                    //{
                    //    if ( s == "SATO" )
                    //    {
                    //        print_name_6 = "SATO";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if ( s.IndexOf("SATO") >= 0 )
                    //        {
                    //            print_name_6 = s;
                    //        }
                    //    }
                    //}
                    //if ( print_name_6.IndexOf("SATO") < 0 )
                    //{
                    //    dw_NUR1001R09_6.PrintDialog(true);
                    //}
                    //else
                    //{
                    //    IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name_6);
                    dw_NUR1001R09_6.Print(true);
                    //}

                    //IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print_6);
					break;
				default:
					break;
			}
		}
		#endregion

		#region Screen Load
		private void NUR1001R09_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			this.cboHo_dong.SelectedIndex = 0;

            if (UserInfo.HoDong.ToString() != "")
            {
                this.cboHo_dong.SetDataValue(UserInfo.HoDong.ToString());
            }
            else
            {
                this.cboHo_dong.SetDataValue("1");
            }

			this.cboWing_gubun.SelectedIndex = 0;
			this.cboGwa.SelectedIndex = 0;

			//병동별 출력물 표시
			SetHodongPrintImage();

			//조회
			GetQuery();

			if (this.OpenParam != null)
			{
				if (this.OpenParam["ho_dong"].ToString() != "")
				{
					this.cboHo_dong.SetDataValue(this.OpenParam["ho_dong"].ToString());

					//병동별 출력물 표시
					SetHodongPrintImage();

					//조회
					GetQuery();
				}

				if (this.OpenParam["ho_dong"].ToString() != "")
				{
					for (int i = 0; i < this.grdINP1001.RowCount; i++)
					{
						if (this.grdINP1001.GetItemValue(i, "bunho").ToString() == this.OpenParam["bunho"].ToString())
						{
							this.grdINP1001.SetItemValue(i, "check", "Y");
							this.grdINP1001.SetFocusToItem(i, "check");
							break;
						}
					}
				}
			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					for (int j = 0; j < this.grdINP1001.RowCount; j++)
					{
						if (this.grdINP1001.GetItemValue(j, "bunho").ToString() == patientInfo.BunHo)
						{
							this.grdINP1001.SetItemValue(j, "check", "Y");
							this.grdINP1001.SetFocusToItem(j, "check");
							break;
						}
					}
				}
			}
		}
		#endregion
	
		#region 출력물을 선택을 했을 때
		private void rb1_Click(object sender, System.EventArgs e)
		{
			Click_SetCheckImage(sender);
		}
		#endregion

		#region 조회버튼을 클릭을 했을 때
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//병동별 출력물 표시
			SetHodongPrintImage();

			GetQuery();
		}
		#endregion

		#region 전체선택을 했을 때
		private void btnAllCheck_Click(object sender, System.EventArgs e)
		{
			if (this.btnAllCheck.Tag.ToString() == "N")
			{
				this.btnAllCheck.ImageIndex = 1;
				this.btnAllCheck.Tag = "Y";

				//전체선택
				for (int i= 0; i < this.grdINP1001.RowCount; i++)
				{
					this.grdINP1001.SetItemValue(i, "check", "Y");
				}
			}
			else
			{
				this.btnAllCheck.ImageIndex = 0;
				this.btnAllCheck.Tag = "N";

				//전체선택
				for (int i= 0; i < this.grdINP1001.RowCount; i++)
				{
					this.grdINP1001.SetItemValue(i, "check", "N");
				}
			}
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Print:
					if (!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					if (this.grdINP1001.RowCount <= 0) return;

					for (int i = 0; i < this.grdINP1001.RowCount; i++)
					{
						if (this.grdINP1001.GetItemValue(i, "check").ToString() == "Y")
						{
							if (this.rb1.Checked == true)
							{
								SetPrint("1", i);
							}

							if (this.rb2.Checked == true)
							{
								SetPrint("2", i);
							}

							if (this.rb3.Checked == true)
							{
								SetPrint("3", i);
							}

							if (this.rb4.Checked == true)
							{
								SetPrint("4", i);
							}

							if (this.rb5.Checked == true)
							{
								SetPrint("5", i);
							}

							if (this.rb6.Checked == true)
							{
								SetPrint("6", i);
							}
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 조회조건을 변경을 했을 때
        //private void cboWing_gubun_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    //병동별 출력물 표시
        //    SetHodongPrintImage();

        //    GetQuery();
        //}

        private void cboHo_dong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //병동별 출력물 표시
            SetHodongPrintImage();

            GetQuery();
        }

		#endregion

        #region QueryStarting
        private void layHodong_Print_List_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layHodong_Print_List.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layHodong_Print_List.SetBindVarValue("f_ho_dong", this.cboHo_dong.GetDataValue());
        }

        private void grdINP1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP1001.SetBindVarValue("f_ho_dong", this.cboHo_dong.GetDataValue());
            //this.grdINP1001.SetBindVarValue("f_wing_gubun", this.cboWing_gubun.GetDataValue());
            this.grdINP1001.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
        }
        #endregion


    }
}

