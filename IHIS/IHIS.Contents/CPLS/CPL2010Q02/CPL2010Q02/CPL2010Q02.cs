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

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL2010Q02에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL2010Q02 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XPanel xPanel8;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdHangmog;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XDatePicker dtpFromDate;
		private IHIS.Framework.XDatePicker dtpToDate;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XDictComboBox cboJundalGubun;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private System.Windows.Forms.GroupBox groupBox1;
		private IHIS.Framework.XRadioButton rbxAll;
		private System.Windows.Forms.GroupBox groupBox2;
		private IHIS.Framework.XRadioButton rbxDochack;
		private IHIS.Framework.XRadioButton rbxMiDochack;
		private IHIS.Framework.XRadioButton rbxTodayChk;
		private IHIS.Framework.XRadioButton rbxAfterChk;
		private IHIS.Framework.XRadioButton rbxAll2;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPL2010Q02()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010Q02));
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbxTodayChk = new IHIS.Framework.XRadioButton();
            this.rbxAfterChk = new IHIS.Framework.XRadioButton();
            this.rbxAll2 = new IHIS.Framework.XRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbxMiDochack = new IHIS.Framework.XRadioButton();
            this.rbxDochack = new IHIS.Framework.XRadioButton();
            this.rbxAll = new IHIS.Framework.XRadioButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboJundalGubun = new IHIS.Framework.XDictComboBox();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdHangmog = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).BeginInit();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.groupBox2);
            this.xPanel6.Controls.Add(this.groupBox1);
            this.xPanel6.Controls.Add(this.xLabel1);
            this.xPanel6.Controls.Add(this.cboJundalGubun);
            this.xPanel6.Controls.Add(this.dtpToDate);
            this.xPanel6.Controls.Add(this.dtpFromDate);
            this.xPanel6.Controls.Add(this.xLabel9);
            this.xPanel6.Controls.Add(this.label1);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Location = new System.Drawing.Point(5, 5);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(950, 35);
            this.xPanel6.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbxTodayChk);
            this.groupBox2.Controls.Add(this.rbxAfterChk);
            this.groupBox2.Controls.Add(this.rbxAll2);
            this.groupBox2.Location = new System.Drawing.Point(706, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 30);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // rbxTodayChk
            // 
            this.rbxTodayChk.Location = new System.Drawing.Point(146, 8);
            this.rbxTodayChk.Name = "rbxTodayChk";
            this.rbxTodayChk.Size = new System.Drawing.Size(86, 18);
            this.rbxTodayChk.TabIndex = 2;
            this.rbxTodayChk.Text = "当日チェック";
            this.rbxTodayChk.UseVisualStyleBackColor = false;
            this.rbxTodayChk.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxAfterChk
            // 
            this.rbxAfterChk.Location = new System.Drawing.Point(68, 8);
            this.rbxAfterChk.Name = "rbxAfterChk";
            this.rbxAfterChk.Size = new System.Drawing.Size(74, 18);
            this.rbxAfterChk.TabIndex = 1;
            this.rbxAfterChk.Text = "後チェック";
            this.rbxAfterChk.UseVisualStyleBackColor = false;
            this.rbxAfterChk.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxAll2
            // 
            this.rbxAll2.Checked = true;
            this.rbxAll2.Location = new System.Drawing.Point(6, 8);
            this.rbxAll2.Name = "rbxAll2";
            this.rbxAll2.Size = new System.Drawing.Size(58, 18);
            this.rbxAll2.TabIndex = 0;
            this.rbxAll2.TabStop = true;
            this.rbxAll2.Text = "全体";
            this.rbxAll2.UseVisualStyleBackColor = false;
            this.rbxAll2.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbxMiDochack);
            this.groupBox1.Controls.Add(this.rbxDochack);
            this.groupBox1.Controls.Add(this.rbxAll);
            this.groupBox1.Location = new System.Drawing.Point(500, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 30);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // rbxMiDochack
            // 
            this.rbxMiDochack.Location = new System.Drawing.Point(130, 8);
            this.rbxMiDochack.Name = "rbxMiDochack";
            this.rbxMiDochack.Size = new System.Drawing.Size(68, 18);
            this.rbxMiDochack.TabIndex = 2;
            this.rbxMiDochack.Text = "未到着";
            this.rbxMiDochack.UseVisualStyleBackColor = false;
            this.rbxMiDochack.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxDochack
            // 
            this.rbxDochack.Location = new System.Drawing.Point(68, 8);
            this.rbxDochack.Name = "rbxDochack";
            this.rbxDochack.Size = new System.Drawing.Size(58, 18);
            this.rbxDochack.TabIndex = 1;
            this.rbxDochack.Text = "到着";
            this.rbxDochack.UseVisualStyleBackColor = false;
            this.rbxDochack.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxAll
            // 
            this.rbxAll.Checked = true;
            this.rbxAll.Location = new System.Drawing.Point(6, 8);
            this.rbxAll.Name = "rbxAll";
            this.rbxAll.Size = new System.Drawing.Size(58, 18);
            this.rbxAll.TabIndex = 0;
            this.rbxAll.TabStop = true;
            this.rbxAll.Text = "全体";
            this.rbxAll.UseVisualStyleBackColor = false;
            this.rbxAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(292, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(70, 21);
            this.xLabel1.TabIndex = 24;
            this.xLabel1.Text = "伝達パート";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboJundalGubun
            // 
            this.cboJundalGubun.Location = new System.Drawing.Point(364, 6);
            this.cboJundalGubun.MaxDropDownItems = 10;
            this.cboJundalGubun.Name = "cboJundalGubun";
            this.cboJundalGubun.Size = new System.Drawing.Size(132, 21);
            this.cboJundalGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboJundalGubun.TabIndex = 23;
            this.cboJundalGubun.UserSQL = "SELECT \'%\', FN_ADM_MSG(\'221\') \r\n FROM DUAL\r\n UNION ALL\r\nSELECT CODE, CODE_NAME \r\n" +
                "  FROM CPL0109\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r\n   AND CODE_TYPE = \'" +
                "01\'";
            this.cboJundalGubun.SelectionChangeCommitted += new System.EventHandler(this.cboJundalGubun_SelectionChangeCommitted);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(190, 6);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(96, 20);
            this.dtpToDate.TabIndex = 21;
            this.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(78, 6);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(96, 20);
            this.dtpFromDate.TabIndex = 20;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Location = new System.Drawing.Point(6, 6);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(70, 20);
            this.xLabel9.TabIndex = 7;
            this.xLabel9.Text = "オーダ日";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(178, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "~";
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdHangmog);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel5.Location = new System.Drawing.Point(0, 0);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(948, 507);
            this.xPanel5.TabIndex = 3;
            // 
            // grdHangmog
            // 
            this.grdHangmog.ApplyPaintEventToAllColumn = true;
            this.grdHangmog.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell13,
            this.xEditGridCell15,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell20,
            this.xEditGridCell7,
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell3,
            this.xEditGridCell8});
            this.grdHangmog.ColPerLine = 11;
            this.grdHangmog.ColResizable = true;
            this.grdHangmog.Cols = 12;
            this.grdHangmog.ControlBinding = true;
            this.grdHangmog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHangmog.FixedCols = 1;
            this.grdHangmog.FixedRows = 1;
            this.grdHangmog.HeaderHeights.Add(22);
            this.grdHangmog.Location = new System.Drawing.Point(0, 0);
            this.grdHangmog.Name = "grdHangmog";
            this.grdHangmog.RowHeaderVisible = true;
            this.grdHangmog.Rows = 2;
            this.grdHangmog.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdHangmog.Size = new System.Drawing.Size(946, 505);
            this.grdHangmog.TabIndex = 1;
            this.grdHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHangmog_QueryStarting);
            this.grdHangmog.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdHangmog_GridCellPainting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "order_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 78;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.HeaderText = "オーダ日";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.SuppressRepeating = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "bunho";
            this.xEditGridCell13.CellWidth = 85;
            this.xEditGridCell13.Col = 2;
            this.xEditGridCell13.HeaderText = "患者番号";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.SuppressRepeating = true;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 30;
            this.xEditGridCell15.CellName = "suname";
            this.xEditGridCell15.CellWidth = 102;
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.HeaderText = "氏名";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.SuppressRepeating = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 100;
            this.xEditGridCell17.CellName = "gubun_name";
            this.xEditGridCell17.CellWidth = 254;
            this.xEditGridCell17.Col = 4;
            this.xEditGridCell17.HeaderText = "伝達パート名";
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell18.CellName = "order_yn";
            this.xEditGridCell18.CellWidth = 65;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "未採血";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell19.CellName = "chehyul_yn";
            this.xEditGridCell19.CellWidth = 65;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "採血";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell21.CellName = "part_jub_yn";
            this.xEditGridCell21.CellWidth = 65;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "検査中";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell22.CellName = "result_yn";
            this.xEditGridCell22.CellWidth = 65;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "結果";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell20.CellName = "confirm_yn";
            this.xEditGridCell20.CellWidth = 65;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "確認";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "print_yn";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "印刷";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "cpl_result";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "結果値";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gwa_name";
            this.xEditGridCell9.CellWidth = 82;
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.HeaderText = "科/病棟";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.SuppressRepeating = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "pkcpl2010";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.CellName = "order";
            this.xEditGridCell1.CellWidth = 50;
            this.xEditGridCell1.Col = 6;
            this.xEditGridCell1.HeaderText = "未採血";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell2.CellName = "chehyul";
            this.xEditGridCell2.CellWidth = 50;
            this.xEditGridCell2.Col = 7;
            this.xEditGridCell2.HeaderText = "採血";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.CellName = "part_jub";
            this.xEditGridCell4.CellWidth = 50;
            this.xEditGridCell4.Col = 8;
            this.xEditGridCell4.HeaderText = "検査中";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell5.CellName = "result";
            this.xEditGridCell5.CellWidth = 50;
            this.xEditGridCell5.Col = 9;
            this.xEditGridCell5.HeaderText = "結果";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell3.CellName = "confirm";
            this.xEditGridCell3.CellWidth = 50;
            this.xEditGridCell3.Col = 10;
            this.xEditGridCell3.HeaderText = "確認";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell8.CellName = "print";
            this.xEditGridCell8.CellWidth = 50;
            this.xEditGridCell8.Col = 11;
            this.xEditGridCell8.HeaderText = "印刷";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.btnList);
            this.xPanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel8.Location = new System.Drawing.Point(0, 507);
            this.xPanel8.Name = "xPanel8";
            this.xPanel8.Size = new System.Drawing.Size(948, 36);
            this.xPanel8.TabIndex = 5;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(770, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 0;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.xPanel8);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel1.Location = new System.Drawing.Point(5, 40);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(950, 545);
            this.xPanel1.TabIndex = 0;
            // 
            // CPL2010Q02
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel6);
            this.Name = "CPL2010Q02";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.xPanel6.ResumeLayout(false);
            this.xPanel6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).EndInit();
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.cboJundalGubun.SetDataValue("%");
			QryList();
		}
		#endregion

		private void grdHangmog_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if ( e.ColName == "order" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[0];
				}
      		}
			else if ( e.ColName == "chehyul" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[1];
				}
      		}
			else if ( e.ColName == "confirm" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[4];
				}
      		}
			else if ( e.ColName == "part_jub" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[2];
				}
      		}
			else if ( e.ColName == "result" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[3];
				}
      		}
			else if ( e.ColName == "print" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[5];
				}
			}
		}

		private void dtpFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			QryList();
		}

		private void dtpToDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			QryList();
		}

		private void cboJundalGubun_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			QryList();
		}

		#region 미도착 리스트 조회
		private void QryList()
		{
            this.grdHangmog.QueryLayout(false);
		}
		#endregion

		private void rbx_CheckedChanged(object sender, System.EventArgs e)
		{
			QryList();
		}

        private void grdHangmog_QueryStarting(object sender, CancelEventArgs e)
        {

            string dochack_yn = "";
            //string after_yn = "";

            if (this.rbxAll.Checked == true) dochack_yn = "0";
            else if (this.rbxDochack.Checked == true) dochack_yn = "1";
            else dochack_yn = "2";

            //if (this.rbxAll2.Checked == true) after_yn = "0";
            //else if (this.rbxAfterChk.Checked == true) after_yn = "1";
            //else after_yn = "2";

            if (dochack_yn == "0")
            {
                //if (after_yn == "0")
                //{
                    /* 모든 내역을 다 조회 */
                    this.grdHangmog.QuerySQL = @"SELECT A.ORDER_DATE
                                                     , A.BUNHO
                                                     , D.SUNAME
                                                     , FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN)          GUBUN_NAME
                                                     , 'Y'   ORDER_YN
                                                     , MIN(DECODE(A.JUBSU_DATE,NULL,'N','Y'))         CHEHYUL_YN
                                                     , MIN(DECODE(A.PART_JUBSU_DATE,NULL,'N','Y'))    GUM_JUB_YN
--                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
--                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
                                                     , DECODE(C.RESULT_DATE,NULL,'N','Y')        RESULT_YN
                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
                                                     , MIN(NVL(A.DONER_YN,'N'))                       PRINT_YN
                                                     , MIN(C.CPL_RESULT)
                                                     , MIN(FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE))  GWA_NAME
                                                     , MIN(A.PKCPL2010)
                                                  FROM OUT0101 D
                                                     , CPL3020 C
                                                     , CPL0101 B
                                                     , CPL2010 A
                                                 WHERE A.HOSP_CODE    = :f_hosp_code
                                                   AND B.HOSP_CODE    = A.HOSP_CODE
                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
                                                   AND NVL(A.RESER_DATE,A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
                                                   AND B.EMERGENCY     = A.EMERGENCY
                                                   AND C.FKCPL2010(+)    = A.PKCPL2010
                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
                                                   AND D.BUNHO           = A.BUNHO
                                                 GROUP BY A.ORDER_DATE, A.BUNHO, D.SUNAME, A.JUNDAL_GUBUN, C.RESULT_DATE,A.RESULT_DATE
                                                 ORDER BY MIN(A.PKCPL2010) DESC";
//                }
//                else if (after_yn == "1")
//                {
//                    /* 나중에 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , MIN(A.SUNAME)
//                                                     , FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN)          GUBUN_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , MIN(DECODE(A.JUBSU_DATE,NULL,'N','Y'))         CHEHYUL_YN
//                                                     , MIN(DECODE(A.PART_JUBSU_DATE,NULL,'N','Y'))    GUM_JUB_YN
//                                                     , MIN(FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER))     RESULT_YN
//                                                     , MIN(DECODE(A.RESULT_DATE,NULL,'N','Y'))        CONFIRM_YN
//                                                     , MIN(NVL(A.DONER_YN,'N'))                       PRINT_YN
//                                                     , MIN(C.CPL_RESULT)
//                                                     , MIN(FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE))  GWA_NAME
//                                                     , MIN(A.PKCPL2010)
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND  NVL(A.RESER_DATE,A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND (A.SPECIMEN_CODE IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                    OR  A.SLIP_CODE     = '35S' ) -- 세포진
//                                                   AND C.FKCPL2010(+)    = A.PKCPL2010
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 GROUP BY A.ORDER_DATE, A.BUNHO, A.JUNDAL_GUBUN
//                                                 ORDER BY MIN(A.PKCPL2010) DESC";
//                }
//                else
//                {
//                    /* 당일 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , MIN(A.SUNAME)
//                                                     , FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN)          GUBUN_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , MIN(DECODE(A.JUBSU_DATE,NULL,'N','Y'))         CHEHYUL_YN
//                                                     , MIN(DECODE(A.PART_JUBSU_DATE,NULL,'N','Y'))    GUM_JUB_YN
//                                                     , MIN(FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER))     RESULT_YN
//                                                     , MIN(DECODE(A.RESULT_DATE,NULL,'N','Y'))        CONFIRM_YN
//                                                     , MIN(NVL(A.DONER_YN,'N'))                       PRINT_YN
//                                                     , MIN(C.CPL_RESULT)
//                                                     , MIN(FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE))  GWA_NAME
//                                                     , MIN(A.PKCPL2010)
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND NVL(A.RESER_DATE,A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND A.SPECIMEN_CODE NOT IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                   AND A.SLIP_CODE     <> '35S' -- 세포진
//                                                   AND C.FKCPL2010(+)    = A.PKCPL2010
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 GROUP BY A.ORDER_DATE, A.BUNHO, A.JUNDAL_GUBUN
//                                                 ORDER BY MIN(A.PKCPL2010) DESC";
//                }
            }
            else if (dochack_yn == "1")
            {
                //if (after_yn == "0")
                //{
                    /*  내역을 다 조회 */
                    this.grdHangmog.QuerySQL = @"SELECT A.ORDER_DATE
                                                     , A.BUNHO
                                                     , MIN(A.SUNAME)
                                                     , FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN)          GUBUN_NAME
                                                     , 'Y'   ORDER_YN
                                                     , MIN(DECODE(A.JUBSU_DATE,NULL,'N','Y'))         CHEHYUL_YN
                                                     , MIN(DECODE(A.PART_JUBSU_DATE,NULL,'N','Y'))    GUM_JUB_YN
--                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
--                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
                                                     , DECODE(C.RESULT_DATE,NULL,'N','Y')        RESULT_YN
                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
                                                     , MIN(NVL(A.DONER_YN,'N'))                       PRINT_YN
                                                     , MIN(C.CPL_RESULT)
                                                     , MIN(FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE))  GWA_NAME
                                                     , MIN(A.PKCPL2010)
                                                  FROM CPL3020 C
                                                     , CPL0101 B
                                                     , CPL2010 A
                                                 WHERE A.HOSP_CODE    = :f_hosp_code
                                                   AND B.HOSP_CODE    = A.HOSP_CODE
                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
                                                   AND NVL(A.RESER_DATE,A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
                                                   AND A.PART_JUBSU_DATE IS NOT NULL
                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
                                                   AND B.EMERGENCY     = A.EMERGENCY
                                                   AND C.FKCPL2010(+)    = A.PKCPL2010
                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
                                                    GROUP BY A.ORDER_DATE, A.BUNHO, A.JUNDAL_GUBUN, A.RESULT_DATE, C.RESULT_DATE
                                                 ORDER BY MIN(A.PKCPL2010) DESC";
//                }
//                else if (after_yn == "1")
//                {
//                    /* 나중에 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , MIN(A.SUNAME)
//                                                     , FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN)          GUBUN_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , MIN(DECODE(A.JUBSU_DATE,NULL,'N','Y'))         CHEHYUL_YN
//                                                     , MIN(DECODE(A.PART_JUBSU_DATE,NULL,'N','Y'))    GUM_JUB_YN
//                                                     , MIN(FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER))     RESULT_YN
//                                                     , MIN(DECODE(A.RESULT_DATE,NULL,'N','Y'))        CONFIRM_YN
//                                                     , MIN(NVL(A.DONER_YN,'N'))                       PRINT_YN
//                                                     , MIN(C.CPL_RESULT)
//                                                     , MIN(FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE))  GWA_NAME
//                                                     , MIN(A.PKCPL2010)
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND NVL(A.RESER_DATE,A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.PART_JUBSU_DATE IS NOT NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND (A.SPECIMEN_CODE IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                    OR  A.SLIP_CODE     = '35S' ) -- 세포진
//                                                   AND C.FKCPL2010(+)    = A.PKCPL2010
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 GROUP BY A.ORDER_DATE, A.BUNHO, A.JUNDAL_GUBUN
//                                                 ORDER BY MIN(A.PKCPL2010) DESC";
//                }
//                else
//                {
//                    /* 당일 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , MIN(A.SUNAME)
//                                                     , FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN)          GUBUN_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , MIN(DECODE(A.JUBSU_DATE,NULL,'N','Y'))         CHEHYUL_YN
//                                                     , MIN(DECODE(A.PART_JUBSU_DATE,NULL,'N','Y'))    GUM_JUB_YN
//                                                     , MIN(FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER))     RESULT_YN
//                                                     , MIN(DECODE(A.RESULT_DATE,NULL,'N','Y'))        CONFIRM_YN
//                                                     , MIN(NVL(A.DONER_YN,'N'))                       PRINT_YN
//                                                     , MIN(C.CPL_RESULT)
//                                                     , MIN(FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE))  GWA_NAME
//                                                     , MIN(A.PKCPL2010)
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND NVL(A.RESER_DATE,A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.PART_JUBSU_DATE IS NOT NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND A.SPECIMEN_CODE NOT IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                   AND A.SLIP_CODE     <> '35S' -- 세포진
//                                                   AND C.FKCPL2010(+)    = A.PKCPL2010
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 GROUP BY A.ORDER_DATE, A.BUNHO, A.JUNDAL_GUBUN
//                                                 ORDER BY MIN(A.PKCPL2010) DESC";
//                }
            }
            else/*미도착 항목들*/
            {
                //if (after_yn == "0")
                //{
                    /*  내역을 다 조회 */
                    this.grdHangmog.QuerySQL = @"SELECT A.ORDER_DATE
                                                     , A.BUNHO
                                                     , MIN(A.SUNAME)
                                                     , FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN)          GUBUN_NAME
                                                     , 'Y'   ORDER_YN
                                                     , MIN(DECODE(A.JUBSU_DATE,NULL,'N','Y'))         CHEHYUL_YN
                                                     , MIN(DECODE(A.PART_JUBSU_DATE,NULL,'N','Y'))    GUM_JUB_YN
--                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
--                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
                                                     , DECODE(C.RESULT_DATE,NULL,'N','Y')        RESULT_YN
                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
                                                     , MIN(NVL(A.DONER_YN,'N'))                       PRINT_YN
                                                     , MIN(C.CPL_RESULT)
                                                     , MIN(FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE))  GWA_NAME
                                                     , MIN(A.PKCPL2010)
                                                  FROM CPL3020 C
                                                     , CPL0101 B
                                                     , CPL2010 A
                                                 WHERE A.HOSP_CODE    = :f_hosp_code
                                                   AND B.HOSP_CODE    = A.HOSP_CODE
                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
                                                   AND NVL(A.RESER_DATE,A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
                                                   AND A.PART_JUBSU_DATE IS NULL
                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
                                                   AND B.EMERGENCY     = A.EMERGENCY
                                                   AND C.FKCPL2010(+)    = A.PKCPL2010
                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
                                                 GROUP BY A.ORDER_DATE, A.BUNHO, A.JUNDAL_GUBUN, A.RESULT_DATE, C.RESULT_DATE
                                                 ORDER BY MIN(A.PKCPL2010) DESC";
//                }
//                else if (after_yn == "1")
//                {
//                    /* 나중에 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , MIN(A.SUNAME)
//                                                     , FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN)          GUBUN_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , MIN(DECODE(A.JUBSU_DATE,NULL,'N','Y'))         CHEHYUL_YN
//                                                     , MIN(DECODE(A.PART_JUBSU_DATE,NULL,'N','Y'))    GUM_JUB_YN
//                                                     , MIN(FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER))     RESULT_YN
//                                                     , MIN(DECODE(A.RESULT_DATE,NULL,'N','Y'))        CONFIRM_YN
//                                                     , MIN(NVL(A.DONER_YN,'N'))                       PRINT_YN
//                                                     , MIN(C.CPL_RESULT)
//                                                     , MIN(FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE))  GWA_NAME
//                                                     , MIN(A.PKCPL2010)
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND NVL(A.RESER_DATE,A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.PART_JUBSU_DATE IS NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND (A.SPECIMEN_CODE IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                    OR  A.SLIP_CODE     = '35S' ) -- 세포진
//                                                   AND C.FKCPL2010(+)    = A.PKCPL2010
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 GROUP BY A.ORDER_DATE, A.BUNHO, A.JUNDAL_GUBUN
//                                                 ORDER BY MIN(A.PKCPL2010) DESC";
//                }
//                else
//                {
//                    /* 당일 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , MIN(A.SUNAME)
//                                                     , FN_CPL_CODE_NAME('01',A.JUNDAL_GUBUN)          GUBUN_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , MIN(DECODE(A.JUBSU_DATE,NULL,'N','Y'))         CHEHYUL_YN
//                                                     , MIN(DECODE(A.PART_JUBSU_DATE,NULL,'N','Y'))    GUM_JUB_YN
//                                                     , MIN(FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER))     RESULT_YN
//                                                     , MIN(DECODE(A.RESULT_DATE,NULL,'N','Y'))        CONFIRM_YN
//                                                     , MIN(NVL(A.DONER_YN,'N'))                       PRINT_YN
//                                                     , MIN(C.CPL_RESULT)
//                                                     , MIN(FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE))  GWA_NAME
//                                                     , MIN(A.PKCPL2010)
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND NVL(A.RESER_DATE,A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.PART_JUBSU_DATE IS NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND A.SPECIMEN_CODE NOT IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                   AND A.SLIP_CODE     <> '35S' -- 세포진
//                                                   AND C.FKCPL2010(+)    = A.PKCPL2010
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 GROUP BY A.ORDER_DATE, A.BUNHO, A.JUNDAL_GUBUN
//                                                 ORDER BY MIN(A.PKCPL2010) DESC";
//                }
            }

            this.grdHangmog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdHangmog.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.grdHangmog.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.grdHangmog.SetBindVarValue("f_jundal_gubun", cboJundalGubun.GetDataValue());
        }

	}
}

