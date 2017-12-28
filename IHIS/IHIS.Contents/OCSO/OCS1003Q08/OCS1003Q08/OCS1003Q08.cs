#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCS;
#endregion

namespace IHIS.OCSO
{
    /// <summary>
    /// OCS1003Q08에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS1003Q08 : IHIS.Framework.XScreen
    {
        #region [OCS Library]
        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리		
        #endregion

        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";

        //등록번호
        private string mBunho = "";
        //처방일자
        private string mOrder_date = "";
        //INPUT GUBUN
        private string mInputGubun = "";

        #endregion

        private XPanel xPanel2;
        private XButtonList xButtonList1;
        private XPanel xPanel1;
        private XPanel xPanel4;
        private XDatePicker dpkOrder_date;
        private XLabel xLabel5;
        private XButton btnLabelPrt;
        private XPatientBox pbxSearch;
        private XPanel xPanel3;
        private XMstGrid grdOrderDateList;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell127;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell164;
        private XEditGridCell xEditGridCell151;
        private XPanel pnlOrder;
        private XEditGrid grdOrderInfo;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell102;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell153;
        private XEditGridCell xEditGridCell154;
        private XEditGridCell xEditGridCell155;
        private XEditGridCell xEditGridCell156;
        private XEditGridCell xEditGridCell157;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell158;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell152;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell145;
        private XEditGridCell xEditGridCell146;
        private XEditGridCell xEditGridCell160;
        private XEditGridCell xEditGridCell161;
        private XEditGridCell xEditGridCell149;
        private XEditGridCell xEditGridCell147;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell128;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell132;
        private XEditGridCell xEditGridCell150;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell162;
        private XTextBox txtDrg_info;
        private XEditGridCell xEditGridCell163;
        private XEditGridCell xEditGridCell165;
        private XEditGridCell xEditGridCell166;
        private XEditGridCell xEditGridCell167;
        private XGridHeader xGridHeader1;
        private XLabel lblSelectOrder;
        private System.ComponentModel.IContainer components;

        public OCS1003Q08()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리			
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


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1003Q08));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.dpkOrder_date = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.btnLabelPrt = new IHIS.Framework.XButton();
            this.pbxSearch = new IHIS.Framework.XPatientBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdOrderDateList = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.grdOrderInfo = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell160 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.txtDrg_info = new IHIS.Framework.XTextBox();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell165 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.lblSelectOrder = new IHIS.Framework.XLabel();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderDateList)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 550);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(960, 40);
            this.xPanel2.TabIndex = 8;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(780, 3);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.pbxSearch);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(960, 64);
            this.xPanel1.TabIndex = 9;
            // 
            // xPanel4
            // 
            this.xPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel4.BackgroundImage")));
            this.xPanel4.Controls.Add(this.dpkOrder_date);
            this.xPanel4.Controls.Add(this.xLabel5);
            this.xPanel4.Controls.Add(this.btnLabelPrt);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel4.Location = new System.Drawing.Point(0, 32);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(958, 30);
            this.xPanel4.TabIndex = 8;
            // 
            // dpkOrder_date
            // 
            this.dpkOrder_date.Location = new System.Drawing.Point(104, 6);
            this.dpkOrder_date.Name = "dpkOrder_date";
            this.dpkOrder_date.Size = new System.Drawing.Size(102, 20);
            this.dpkOrder_date.TabIndex = 5;
            this.dpkOrder_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(4, 6);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(98, 19);
            this.xLabel5.TabIndex = 4;
            this.xLabel5.Text = "オ―ダ日付";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLabelPrt
            // 
            this.btnLabelPrt.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLabelPrt.ImageIndex = 2;
            this.btnLabelPrt.ImageList = this.ImageList;
            this.btnLabelPrt.Location = new System.Drawing.Point(838, 0);
            this.btnLabelPrt.Name = "btnLabelPrt";
            this.btnLabelPrt.Size = new System.Drawing.Size(120, 30);
            this.btnLabelPrt.TabIndex = 7;
            this.btnLabelPrt.Text = "指示ラベル出力";
            this.btnLabelPrt.Visible = false;
            // 
            // pbxSearch
            // 
            this.pbxSearch.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.pbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxSearch.Location = new System.Drawing.Point(0, 0);
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pbxSearch.Size = new System.Drawing.Size(958, 32);
            this.pbxSearch.TabIndex = 6;
            this.pbxSearch.PatientSelected += new System.EventHandler(this.pbxSearch_PatientSelected);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdOrderDateList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 64);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(258, 486);
            this.xPanel3.TabIndex = 10;
            // 
            // grdOrderDateList
            // 
            this.grdOrderDateList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell127,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell129,
            this.xEditGridCell8,
            this.xEditGridCell164,
            this.xEditGridCell151});
            this.grdOrderDateList.ColPerLine = 3;
            this.grdOrderDateList.Cols = 4;
            this.grdOrderDateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrderDateList.EnableMultiSelection = true;
            this.grdOrderDateList.FixedCols = 1;
            this.grdOrderDateList.FixedRows = 1;
            this.grdOrderDateList.HeaderHeights.Add(21);
            this.grdOrderDateList.ImageList = this.ImageList;
            this.grdOrderDateList.Location = new System.Drawing.Point(0, 0);
            this.grdOrderDateList.Name = "grdOrderDateList";
            this.grdOrderDateList.QuerySQL = resources.GetString("grdOrderDateList.QuerySQL");
            this.grdOrderDateList.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOrderDateList.RowHeaderVisible = true;
            this.grdOrderDateList.Rows = 2;
            this.grdOrderDateList.RowStateCheckOnPaint = false;
            this.grdOrderDateList.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrderDateList.Size = new System.Drawing.Size(256, 484);
            this.grdOrderDateList.TabIndex = 0;
            this.grdOrderDateList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderDateList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "naewon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 87;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "オ―ダ日付";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "gwa";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.HeaderText = "gwa";
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 51;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderText = "診療科";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellName = "doctor_name";
            this.xEditGridCell3.CellWidth = 90;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.HeaderText = "医師";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bunho";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "bunho";
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "doctor";
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "naewon_type";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "naewon_type";
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "jubsu_no";
            this.xEditGridCell129.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.HeaderText = "jubsu_no";
            this.xEditGridCell129.IsUpdatable = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pk_order";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "pk_order";
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellName = "io_gubun";
            this.xEditGridCell164.Col = -1;
            this.xEditGridCell164.HeaderText = "io_gubun";
            this.xEditGridCell164.IsUpdatable = false;
            this.xEditGridCell164.IsVisible = false;
            this.xEditGridCell164.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "order_gubun";
            this.xEditGridCell151.Col = -1;
            this.xEditGridCell151.HeaderText = "order_gubun";
            this.xEditGridCell151.IsUpdatable = false;
            this.xEditGridCell151.IsVisible = false;
            this.xEditGridCell151.Row = -1;
            // 
            // pnlOrder
            // 
            this.pnlOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pnlOrder.Controls.Add(this.grdOrderInfo);
            this.pnlOrder.Controls.Add(this.txtDrg_info);
            this.pnlOrder.Controls.Add(this.lblSelectOrder);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrder.Location = new System.Drawing.Point(258, 64);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(702, 486);
            this.pnlOrder.TabIndex = 11;
            // 
            // grdOrderInfo
            // 
            this.grdOrderInfo.AddedHeaderLine = 1;
            this.grdOrderInfo.ApplyPaintEventToAllColumn = true;
            this.grdOrderInfo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell19,
            this.xEditGridCell102,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell134,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell135,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell136,
            this.xEditGridCell28,
            this.xEditGridCell137,
            this.xEditGridCell29,
            this.xEditGridCell153,
            this.xEditGridCell154,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell157,
            this.xEditGridCell30,
            this.xEditGridCell140,
            this.xEditGridCell141,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell158,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell59,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell139,
            this.xEditGridCell94,
            this.xEditGridCell68,
            this.xEditGridCell152,
            this.xEditGridCell9,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell142,
            this.xEditGridCell145,
            this.xEditGridCell146,
            this.xEditGridCell160,
            this.xEditGridCell161,
            this.xEditGridCell149,
            this.xEditGridCell147,
            this.xEditGridCell148,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell128,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell132,
            this.xEditGridCell150,
            this.xEditGridCell143,
            this.xEditGridCell162,
            this.xEditGridCell163,
            this.xEditGridCell165,
            this.xEditGridCell166,
            this.xEditGridCell167});
            this.grdOrderInfo.ColPerLine = 28;
            this.grdOrderInfo.ColResizable = true;
            this.grdOrderInfo.Cols = 29;
            this.grdOrderInfo.ControlBinding = true;
            this.grdOrderInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrderInfo.EnableMultiSelection = true;
            this.grdOrderInfo.FixedCols = 1;
            this.grdOrderInfo.FixedRows = 2;
            this.grdOrderInfo.HeaderHeights.Add(39);
            this.grdOrderInfo.HeaderHeights.Add(1);
            this.grdOrderInfo.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOrderInfo.Location = new System.Drawing.Point(0, 8);
            this.grdOrderInfo.MasterLayout = this.grdOrderDateList;
            this.grdOrderInfo.Name = "grdOrderInfo";
            this.grdOrderInfo.QuerySQL = resources.GetString("grdOrderInfo.QuerySQL");
            this.grdOrderInfo.ReadOnly = true;
            this.grdOrderInfo.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOrderInfo.RowHeaderVisible = true;
            this.grdOrderInfo.Rows = 3;
            this.grdOrderInfo.RowStateCheckOnPaint = false;
            this.grdOrderInfo.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrderInfo.Size = new System.Drawing.Size(702, 430);
            this.grdOrderInfo.TabIndex = 0;
            this.grdOrderInfo.ToolTipActive = true;
            this.grdOrderInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderInfo_QueryStarting);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellName = "input_gubun_name";
            this.xEditGridCell4.CellWidth = 76;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.HeaderText = "入力\r\n区分";
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.CellName = "group_ser";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.CellWidth = 41;
            this.xEditGridCell19.Col = 4;
            this.xEditGridCell19.HeaderText = "G\r\nR";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.CellName = "order_gubun_name";
            this.xEditGridCell102.CellWidth = 73;
            this.xEditGridCell102.Col = 3;
            this.xEditGridCell102.HeaderText = "オ―ダ区分";
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell102.SuppressRepeating = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.CellWidth = 74;
            this.xEditGridCell20.Col = 7;
            this.xEditGridCell20.HeaderText = "オ―ダコード";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 191;
            this.xEditGridCell21.Col = 8;
            this.xEditGridCell21.HeaderText = "オ―ダ名";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "specimen_code";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.HeaderText = "specimen_code";
            this.xEditGridCell134.IsReadOnly = true;
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.CellName = "specimen_name";
            this.xEditGridCell22.CellWidth = 33;
            this.xEditGridCell22.Col = 9;
            this.xEditGridCell22.HeaderText = "検体";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.CellName = "suryang";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell23.CellWidth = 46;
            this.xEditGridCell23.Col = 10;
            this.xEditGridCell23.DecimalDigits = 3;
            this.xEditGridCell23.HeaderText = "数量";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "ord_danui";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.HeaderText = "ord_danui";
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellName = "ord_danui_name";
            this.xEditGridCell24.CellWidth = 76;
            this.xEditGridCell24.Col = 11;
            this.xEditGridCell24.HeaderText = "単位";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.RowSpan = 2;
            this.xEditGridCell24.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellName = "dv_time";
            this.xEditGridCell25.CellWidth = 21;
            this.xEditGridCell25.Col = 12;
            this.xEditGridCell25.HeaderText = "dv_time";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.Row = 1;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellName = "dv";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell26.CellWidth = 30;
            this.xEditGridCell26.Col = 13;
            this.xEditGridCell26.HeaderText = "dv";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellName = "nalsu";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell27.CellWidth = 42;
            this.xEditGridCell27.Col = 14;
            this.xEditGridCell27.HeaderText = "日数";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "jusa";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.HeaderText = "jusa";
            this.xEditGridCell136.IsReadOnly = true;
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellName = "jusa_name";
            this.xEditGridCell28.CellWidth = 34;
            this.xEditGridCell28.Col = 15;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell28.HeaderText = "注射";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.RowSpan = 2;
            this.xEditGridCell28.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "bogyong_code";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.HeaderText = "bogyong_code";
            this.xEditGridCell137.IsReadOnly = true;
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.CellName = "bogyong_name";
            this.xEditGridCell29.CellWidth = 75;
            this.xEditGridCell29.Col = 16;
            this.xEditGridCell29.HeaderText = "用法";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.RowSpan = 2;
            this.xEditGridCell29.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "jusa_spd_gubun";
            this.xEditGridCell153.CellWidth = 40;
            this.xEditGridCell153.Col = -1;
            this.xEditGridCell153.HeaderText = "ml\r\nhr";
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellName = "hubal_change_yn";
            this.xEditGridCell154.CellWidth = 29;
            this.xEditGridCell154.Col = 27;
            this.xEditGridCell154.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell154.HeaderText = "後発\r\n不可";
            this.xEditGridCell154.RowSpan = 2;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "pharmacy";
            this.xEditGridCell155.CellWidth = 18;
            this.xEditGridCell155.Col = 26;
            this.xEditGridCell155.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell155.HeaderText = "簡\r\n易";
            this.xEditGridCell155.RowSpan = 2;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "drg_pack_yn";
            this.xEditGridCell156.CellWidth = 16;
            this.xEditGridCell156.Col = 24;
            this.xEditGridCell156.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell156.HeaderText = "一\r\n包";
            this.xEditGridCell156.RowSpan = 2;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "powder_yn";
            this.xEditGridCell157.CellWidth = 17;
            this.xEditGridCell157.Col = 25;
            this.xEditGridCell157.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell157.HeaderText = "粉\r\n砕";
            this.xEditGridCell157.RowSpan = 2;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellName = "wonyoi_order_yn";
            this.xEditGridCell30.CellWidth = 24;
            this.xEditGridCell30.Col = 20;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell30.HeaderText = "院\r\n外";
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell140.CellWidth = 30;
            this.xEditGridCell140.Col = 17;
            this.xEditGridCell140.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell140.HeaderText = "当日\r\n施行";
            this.xEditGridCell140.IsReadOnly = true;
            this.xEditGridCell140.IsUpdatable = false;
            this.xEditGridCell140.RowSpan = 2;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell141.CellWidth = 33;
            this.xEditGridCell141.Col = 18;
            this.xEditGridCell141.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell141.HeaderText = "当日\r\n結果";
            this.xEditGridCell141.IsReadOnly = true;
            this.xEditGridCell141.IsUpdatable = false;
            this.xEditGridCell141.RowSpan = 2;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 21;
            this.xEditGridCell32.Col = 19;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.HeaderText = "緊\r\n急";
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellName = "pay";
            this.xEditGridCell33.CellWidth = 35;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.HeaderText = "請求\r\n区分";
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.CellName = "anti_cancer_yn";
            this.xEditGridCell36.CellWidth = 45;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell36.HeaderText = "抗癌剤";
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "muhyo";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.HeaderText = "muhyo";
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.CellName = "portable_yn";
            this.xEditGridCell38.CellWidth = 61;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.HeaderText = "移動\r\n撮影";
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "ocs_flag";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.HeaderText = "ocs_flag";
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "order_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.HeaderText = "order_gubun";
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellName = "input_tab";
            this.xEditGridCell158.Col = -1;
            this.xEditGridCell158.HeaderText = "input_tab";
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "input_gubun";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.HeaderText = "input_gubun";
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "after_act_yn";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.HeaderText = "after_act_yn";
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "jundal_table";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.HeaderText = "jundal_table";
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jundal_part";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.HeaderText = "jundal_part";
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "move_part";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.HeaderText = "move_part";
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "bunho";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.HeaderText = "bunho";
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "naewon_date";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.HeaderText = "naewon_date";
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "gwa";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "gwa";
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "doctor";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "doctor";
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "naewon_type";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "naewon_type";
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "pk_order";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.HeaderText = "pk_order";
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "seq";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.HeaderText = "seq";
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pkocs1003";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.HeaderText = "pkocs1003";
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "sub_susul";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.HeaderText = "sub_susul";
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "sutak_yn";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.HeaderText = "sutak_yn";
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "amt";
            this.xEditGridCell59.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.HeaderText = "amt";
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "dv_1";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.HeaderText = "dv_1";
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "dv_2";
            this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.HeaderText = "dv_2";
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "dv_3";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.HeaderText = "dv_3";
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "dv_4";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.HeaderText = "dv_4";
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.CellName = "hope_date";
            this.xEditGridCell139.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell139.CellWidth = 103;
            this.xEditGridCell139.Col = 23;
            this.xEditGridCell139.HeaderText = "希望日";
            this.xEditGridCell139.IsReadOnly = true;
            this.xEditGridCell139.IsUpdatable = false;
            this.xEditGridCell139.RowSpan = 2;
            this.xEditGridCell139.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.CellName = "order_remark";
            this.xEditGridCell94.Col = 21;
            this.xEditGridCell94.DisplayMemoText = true;
            this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell94.HeaderText = "Comment";
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.RowSpan = 2;
            this.xEditGridCell94.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "mix_group";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.HeaderText = "mix_group";
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "regular_yn";
            this.xEditGridCell152.CellWidth = 19;
            this.xEditGridCell152.Col = 5;
            this.xEditGridCell152.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell152.HeaderText = "定\r\n時";
            this.xEditGridCell152.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.CellName = "reser_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.CellWidth = 106;
            this.xEditGridCell9.Col = 28;
            this.xEditGridCell9.HeaderText = "予約日付";
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.RowSpan = 2;
            this.xEditGridCell9.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "jubsu_date";
            this.xEditGridCell95.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.HeaderText = "jubsu_date";
            this.xEditGridCell95.IsUpdatable = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "acting_date";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.HeaderText = "acting_date";
            this.xEditGridCell96.IsUpdatable = false;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "result_date";
            this.xEditGridCell97.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.HeaderText = "result_date";
            this.xEditGridCell97.IsUpdatable = false;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell142.CellName = "dc_gubun";
            this.xEditGridCell142.CellWidth = 30;
            this.xEditGridCell142.Col = 6;
            this.xEditGridCell142.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell142.HeaderForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell142.HeaderText = "返却\r\n指示";
            this.xEditGridCell142.IsUpdatable = false;
            this.xEditGridCell142.RowSpan = 2;
            this.xEditGridCell142.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell142.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "dc_yn";
            this.xEditGridCell145.Col = -1;
            this.xEditGridCell145.HeaderText = "dc_yn";
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.IsVisible = false;
            this.xEditGridCell145.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "bannab_yn";
            this.xEditGridCell146.Col = -1;
            this.xEditGridCell146.HeaderText = "bannab_yn";
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.IsVisible = false;
            this.xEditGridCell146.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "donbog_yn";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.HeaderText = "donbog_yn";
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellName = "dv_name";
            this.xEditGridCell161.Col = -1;
            this.xEditGridCell161.HeaderText = "dv_name";
            this.xEditGridCell161.IsVisible = false;
            this.xEditGridCell161.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "confirm_check";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.HeaderText = "confirm_check";
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "sunab_check";
            this.xEditGridCell147.Col = -1;
            this.xEditGridCell147.HeaderText = "sunab_check";
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.IsVisible = false;
            this.xEditGridCell147.Row = -1;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "dc_check";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.HeaderText = "dc_check";
            this.xEditGridCell148.IsUpdatable = false;
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "slip_code";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.HeaderText = "slip_code";
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "group_yn";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.HeaderText = "group_yn";
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "sg_code";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.HeaderText = "sg_code";
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "order_gubun_bas";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.HeaderText = "order_gubun_bas";
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "input_control";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.HeaderText = "input_control";
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "suga_yn";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.HeaderText = "suga_yn";
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "emergency_check";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.HeaderText = "emergency_check";
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "limit_suryang";
            this.xEditGridCell80.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.HeaderText = "limit_suryang";
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "specimen_yn";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.HeaderText = "specimen_yn";
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "jaeryo_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.HeaderText = "jaeryo_yn";
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "ord_danui_check";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.HeaderText = "ord_danui_check";
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "ord_danui_bas";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.HeaderText = "ord_danui_bas";
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "jundal_table_out";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.HeaderText = "jundal_table_out";
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "jundal_part_out";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.HeaderText = "jundal_part_out";
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "bulyong_check";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.HeaderText = "bulyong_check";
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.HeaderText = "wonyoi_order_cr_yn";
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.HeaderText = "default_wonyoi_order_yn";
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "nday_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.HeaderText = "nday_yn";
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "muhyo_yn";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.HeaderText = "muhyo_yn";
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "tel_yn";
            this.xEditGridCell132.Col = -1;
            this.xEditGridCell132.HeaderText = "tel_yn";
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell150.CellName = "jundal_part_name";
            this.xEditGridCell150.Col = 22;
            this.xEditGridCell150.HeaderText = "施行科";
            this.xEditGridCell150.IsUpdatable = false;
            this.xEditGridCell150.RowSpan = 2;
            this.xEditGridCell150.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell150.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "bun_code";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.HeaderText = "bun_code";
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.BindControl = this.txtDrg_info;
            this.xEditGridCell162.CellName = "drg_info";
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.HeaderText = "drg_info";
            this.xEditGridCell162.IsReadOnly = true;
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsUpdCol = false;
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // txtDrg_info
            // 
            this.txtDrg_info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDrg_info.Location = new System.Drawing.Point(0, 438);
            this.txtDrg_info.Multiline = true;
            this.txtDrg_info.Name = "txtDrg_info";
            this.txtDrg_info.Protect = true;
            this.txtDrg_info.ReadOnly = true;
            this.txtDrg_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDrg_info.Size = new System.Drawing.Size(702, 48);
            this.txtDrg_info.TabIndex = 44;
            this.txtDrg_info.TabStop = false;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellName = "drg_bunryu";
            this.xEditGridCell163.Col = -1;
            this.xEditGridCell163.HeaderText = "drg_bunryu";
            this.xEditGridCell163.IsReadOnly = true;
            this.xEditGridCell163.IsUpdatable = false;
            this.xEditGridCell163.IsUpdCol = false;
            this.xEditGridCell163.IsVisible = false;
            this.xEditGridCell163.Row = -1;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell165.CellName = "child_gubun";
            this.xEditGridCell165.CellWidth = 26;
            this.xEditGridCell165.Col = 1;
            this.xEditGridCell165.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell165.RowSpan = 2;
            this.xEditGridCell165.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellName = "bom_source_key";
            this.xEditGridCell166.Col = -1;
            this.xEditGridCell166.IsVisible = false;
            this.xEditGridCell166.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "bom_occur_yn";
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 12;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 21;
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // lblSelectOrder
            // 
            this.lblSelectOrder.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectOrder.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectOrder.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectOrder.ImageList = this.ImageList;
            this.lblSelectOrder.Location = new System.Drawing.Point(0, 0);
            this.lblSelectOrder.Name = "lblSelectOrder";
            this.lblSelectOrder.Size = new System.Drawing.Size(702, 8);
            this.lblSelectOrder.TabIndex = 16;
            // 
            // OCS1003Q08
            // 
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Name = "OCS1003Q08";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS1003Q08_ScreenOpen);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderDateList)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #region [Screen Event]

        public override object Command(string command, CommonItemCollection commandParam)
        {

            return base.Command(command, commandParam);
        }

        protected override void OnLoad(EventArgs e)
        {
            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            if (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed)
            {
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 105);
            }

            //comboBox생성
            //CreateCombo();

            //grd Setting [외래]
            //입력구분
            //ntt
            grdOrderInfo.AutoSizeColumn(2, 0);
            //반납지시
            grdOrderInfo.AutoSizeColumn(7, 0);

            mOrder_date = IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            //input gubun 설정
            if (IHIS.Framework.UserInfo.UserGubun.ToString() == "Doctor")      //의사
                mInputGubun = "D%";
            else if (IHIS.Framework.UserInfo.UserGubun.ToString() == "Nurse") //간호사
                mInputGubun = "NR";
            else                                                         //그외의 유저
                //mInputGubun = OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items["input_gubun"].ToString();
                mInputGubun = UserInfo.InputGubun;

            base.OnLoad(e);
        }

        private void OCS1003Q08_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                        mBunho = OpenParam["bunho"].ToString().Trim();


                    if (OpenParam.Contains("order_date"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["order_date"].ToString()))
                            mOrder_date = OpenParam["order_date"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }

            dpkOrder_date.SetDataValue(mOrder_date);

            PostCallHelper.PostCall(new PostMethod(PostLoad));		
        }

        private void PostLoad()
        {

            if (TypeCheck.IsNull(mBunho))
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null)
                {
                    this.pbxSearch.SetPatientID(patientInfo.BunHo);
                }
            }
            else
                this.pbxSearch.SetPatientID(mBunho);
        }
        #endregion

        private void pbxSearch_PatientSelected(object sender, EventArgs e)
        {
            ControlClear();
            if (!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
                LoadData();
        }

        /// <summary>
        /// Control정보 Reset
        /// </summary>
        private void ControlClear()
        {
            this.grdOrderInfo.Reset();
            this.grdOrderDateList.Reset();
        }

        #region [Data Load]

        private void LoadData()
        {
            if (!TypeCheck.IsDateTime(dpkOrder_date.GetDataValue()))
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "入力された日付に誤りがあります。 ご確認ください。" : "일자를 잘못 입력하셨습니다. 확인바랍니다.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                ControlClear();

                dpkOrder_date.Focus();
                return;
            }

            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                SetMsg("");

                if (!grdOrderDateList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            finally
            {
                SetMsg(" ");
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }

        #endregion

        private void grdOrderDateList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOrderDateList.SetBindVarValue("f_bunho", pbxSearch.BunHo);
            this.grdOrderDateList.SetBindVarValue("f_order_date", dpkOrder_date.GetDataValue());
            this.grdOrderDateList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdOrderInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOrderInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOrderInfo.SetBindVarValue("f_naewon_date", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "naewon_date"));
            this.grdOrderInfo.SetBindVarValue("f_pk_order", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "pk_order"));
        }
    }
}
