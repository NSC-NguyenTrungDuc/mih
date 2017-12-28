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

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0100U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0100U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XEditGrid grdBAS0100;
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
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XLabel xLabel10;
		private IHIS.Framework.XLabel xLabel11;
		private IHIS.Framework.XLabel xLabel13;
		private IHIS.Framework.XPanel pnlBody;
		private IHIS.Framework.XTextBox txtComment;
		private IHIS.Framework.XFindBox fbxSiseolCode;
		private IHIS.Framework.XDisplayBox dbxSiseolName;
		private IHIS.Framework.XDictComboBox cboJukyongGubun;
		private IHIS.Framework.XFindBox fbxGubun;
		private IHIS.Framework.XDisplayBox dbxSgNameInp;
		private IHIS.Framework.XDisplayBox dbxSgNameOut;
		private IHIS.Framework.XFindBox fbxSgCodeOut;
		private IHIS.Framework.XFindBox fbxSgCodeInp;
		private IHIS.Framework.XFindBox fbxJinryoGubun1;
		private IHIS.Framework.XDisplayBox dbxJinryoGubunName1;
		private IHIS.Framework.XDisplayBox dbxJinryoGubunName2;
		private IHIS.Framework.XFindBox fbxJinryoGubun2;
		private IHIS.Framework.XDisplayBox dbxJinryoGubunName3;
		private IHIS.Framework.XFindBox fbxJinryoGubun3;
		private IHIS.Framework.XCheckBox cbxUseYn;
		private IHIS.Framework.XLabel xLabel12;
		private IHIS.Framework.XDatePicker dtpStartDate;
		private IHIS.Framework.XLabel xLabel14;
		private IHIS.Framework.XDatePicker dtpEndDate;
		private IHIS.Framework.SingleLayout layCommon;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.XDatePicker dtpJukyongDate;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XDisplayBox dbxGubunName;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XTextBox txtSearchGubun;
		private IHIS.Framework.SingleLayout layDupCheck;
        private SingleLayoutItem singleLayoutItem1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0100U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0100U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtSearchGubun = new IHIS.Framework.XTextBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.dtpJukyongDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdBAS0100 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.dtpStartDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.dtpEndDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.fbxSiseolCode = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.dbxSiseolName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.cboJukyongGubun = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.fbxGubun = new IHIS.Framework.XFindBox();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.dbxGubunName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.fbxSgCodeInp = new IHIS.Framework.XFindBox();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.dbxSgNameInp = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.fbxSgCodeOut = new IHIS.Framework.XFindBox();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.dbxSgNameOut = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.fbxJinryoGubun1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.dbxJinryoGubunName1 = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.fbxJinryoGubun2 = new IHIS.Framework.XFindBox();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.dbxJinryoGubunName2 = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.fbxJinryoGubun3 = new IHIS.Framework.XFindBox();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.dbxJinryoGubunName3 = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.txtComment = new IHIS.Framework.XTextBox();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.cbxUseYn = new IHIS.Framework.XCheckBox();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.pnlBody = new IHIS.Framework.XPanel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0100)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.txtSearchGubun);
            this.xPanel1.Controls.Add(this.xLabel8);
            this.xPanel1.Controls.Add(this.dtpJukyongDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Name = "xPanel1";
            // 
            // txtSearchGubun
            // 
            resources.ApplyResources(this.txtSearchGubun, "txtSearchGubun");
            this.txtSearchGubun.Name = "txtSearchGubun";
            this.txtSearchGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearchGubun_DataValidating);
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // dtpJukyongDate
            // 
            resources.ApplyResources(this.dtpJukyongDate, "dtpJukyongDate");
            this.dtpJukyongDate.Name = "dtpJukyongDate";
            this.dtpJukyongDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJukyongDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdBAS0100);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // grdBAS0100
            // 
            this.grdBAS0100.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell13,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell14,
            this.xEditGridCell6,
            this.xEditGridCell15,
            this.xEditGridCell7,
            this.xEditGridCell16,
            this.xEditGridCell8,
            this.xEditGridCell17,
            this.xEditGridCell9,
            this.xEditGridCell18,
            this.xEditGridCell10,
            this.xEditGridCell19,
            this.xEditGridCell12,
            this.xEditGridCell11,
            this.xEditGridCell20});
            this.grdBAS0100.ColPerLine = 1;
            this.grdBAS0100.Cols = 2;
            this.grdBAS0100.ControlBinding = true;
            resources.ApplyResources(this.grdBAS0100, "grdBAS0100");
            this.grdBAS0100.FixedCols = 1;
            this.grdBAS0100.FixedRows = 1;
            this.grdBAS0100.HeaderHeights.Add(24);
            this.grdBAS0100.Name = "grdBAS0100";
            this.grdBAS0100.QuerySQL = resources.GetString("grdBAS0100.QuerySQL");
            this.grdBAS0100.ReadOnly = true;
            this.grdBAS0100.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdBAS0100.RowHeaderVisible = true;
            this.grdBAS0100.Rows = 2;
            this.grdBAS0100.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0100_QueryStarting);
            this.grdBAS0100.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdBAS0100_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.BindControl = this.dtpStartDate;
            this.xEditGridCell1.CellName = "start_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = -1;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // dtpStartDate
            // 
            resources.ApplyResources(this.dtpStartDate, "dtpStartDate");
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Leave += new System.EventHandler(this.dtpStartDate_Leave);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.BindControl = this.dtpEndDate;
            this.xEditGridCell2.CellName = "end_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.Col = -1;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // dtpEndDate
            // 
            resources.ApplyResources(this.dtpEndDate, "dtpEndDate");
            this.dtpEndDate.Name = "dtpEndDate";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.BindControl = this.fbxSiseolCode;
            this.xEditGridCell3.CellName = "siseol_code";
            this.xEditGridCell3.CellWidth = 95;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxSiseolCode
            // 
            this.fbxSiseolCode.AutoTabDataSelected = true;
            this.fbxSiseolCode.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxSiseolCode, "fbxSiseolCode");
            this.fbxSiseolCode.Name = "fbxSiseolCode";
            this.fbxSiseolCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSiseolCode_DataValidating);
            this.fbxSiseolCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCommon_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.BindControl = this.dbxSiseolName;
            this.xEditGridCell13.CellName = "siseol_code_name";
            this.xEditGridCell13.CellWidth = 275;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // dbxSiseolName
            // 
            resources.ApplyResources(this.dbxSiseolName, "dbxSiseolName");
            this.dbxSiseolName.Name = "dbxSiseolName";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.cboJukyongGubun;
            this.xEditGridCell4.CellName = "jukyong_gubun";
            this.xEditGridCell4.Col = -1;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // cboJukyongGubun
            // 
            resources.ApplyResources(this.cboJukyongGubun, "cboJukyongGubun");
            this.cboJukyongGubun.Name = "cboJukyongGubun";
            this.cboJukyongGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboJukyongGubun.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE = \'JUKYONG_GUBUN\'";
            this.cboJukyongGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboJukyongGubun_DataValidating);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.fbxGubun;
            this.xEditGridCell5.CellName = "gubun";
            this.xEditGridCell5.Col = -1;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // fbxGubun
            // 
            this.fbxGubun.AutoTabDataSelected = true;
            this.fbxGubun.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxGubun, "fbxGubun");
            this.fbxGubun.Name = "fbxGubun";
            this.fbxGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSiseolCode_DataValidating);
            this.fbxGubun.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCommon_FindClick);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.BindControl = this.dbxGubunName;
            this.xEditGridCell14.CellName = "gubun_name";
            this.xEditGridCell14.Col = -1;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // dbxGubunName
            // 
            resources.ApplyResources(this.dbxGubunName, "dbxGubunName");
            this.dbxGubunName.Name = "dbxGubunName";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.BindControl = this.fbxSgCodeInp;
            this.xEditGridCell6.CellName = "sg_code_inp";
            this.xEditGridCell6.Col = -1;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // fbxSgCodeInp
            // 
            this.fbxSgCodeInp.AutoTabDataSelected = true;
            this.fbxSgCodeInp.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxSgCodeInp, "fbxSgCodeInp");
            this.fbxSgCodeInp.Name = "fbxSgCodeInp";
            this.fbxSgCodeInp.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSiseolCode_DataValidating);
            this.fbxSgCodeInp.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCommon_FindClick);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.BindControl = this.dbxSgNameInp;
            this.xEditGridCell15.CellName = "sg_name_inp";
            this.xEditGridCell15.Col = -1;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // dbxSgNameInp
            // 
            resources.ApplyResources(this.dbxSgNameInp, "dbxSgNameInp");
            this.dbxSgNameInp.Name = "dbxSgNameInp";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.BindControl = this.fbxSgCodeOut;
            this.xEditGridCell7.CellName = "sg_code_out";
            this.xEditGridCell7.Col = -1;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // fbxSgCodeOut
            // 
            this.fbxSgCodeOut.AutoTabDataSelected = true;
            this.fbxSgCodeOut.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxSgCodeOut, "fbxSgCodeOut");
            this.fbxSgCodeOut.Name = "fbxSgCodeOut";
            this.fbxSgCodeOut.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSiseolCode_DataValidating);
            this.fbxSgCodeOut.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCommon_FindClick);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.BindControl = this.dbxSgNameOut;
            this.xEditGridCell16.CellName = "sg_name_out";
            this.xEditGridCell16.Col = -1;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // dbxSgNameOut
            // 
            resources.ApplyResources(this.dbxSgNameOut, "dbxSgNameOut");
            this.dbxSgNameOut.Name = "dbxSgNameOut";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.fbxJinryoGubun1;
            this.xEditGridCell8.CellName = "jinryo_gubun1";
            this.xEditGridCell8.Col = -1;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // fbxJinryoGubun1
            // 
            this.fbxJinryoGubun1.AutoTabDataSelected = true;
            this.fbxJinryoGubun1.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxJinryoGubun1, "fbxJinryoGubun1");
            this.fbxJinryoGubun1.Name = "fbxJinryoGubun1";
            this.fbxJinryoGubun1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSiseolCode_DataValidating);
            this.fbxJinryoGubun1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCommon_FindClick);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.BindControl = this.dbxJinryoGubunName1;
            this.xEditGridCell17.CellName = "jinryo_gubun_name1";
            this.xEditGridCell17.Col = -1;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // dbxJinryoGubunName1
            // 
            resources.ApplyResources(this.dbxJinryoGubunName1, "dbxJinryoGubunName1");
            this.dbxJinryoGubunName1.Name = "dbxJinryoGubunName1";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.BindControl = this.fbxJinryoGubun2;
            this.xEditGridCell9.CellName = "jinryo_gubun2";
            this.xEditGridCell9.Col = -1;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // fbxJinryoGubun2
            // 
            this.fbxJinryoGubun2.AutoTabDataSelected = true;
            this.fbxJinryoGubun2.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxJinryoGubun2, "fbxJinryoGubun2");
            this.fbxJinryoGubun2.Name = "fbxJinryoGubun2";
            this.fbxJinryoGubun2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSiseolCode_DataValidating);
            this.fbxJinryoGubun2.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCommon_FindClick);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.dbxJinryoGubunName2;
            this.xEditGridCell18.CellName = "jinryo_gubun_name2";
            this.xEditGridCell18.Col = -1;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // dbxJinryoGubunName2
            // 
            resources.ApplyResources(this.dbxJinryoGubunName2, "dbxJinryoGubunName2");
            this.dbxJinryoGubunName2.Name = "dbxJinryoGubunName2";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.BindControl = this.fbxJinryoGubun3;
            this.xEditGridCell10.CellName = "jinryo_gubun3";
            this.xEditGridCell10.Col = -1;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // fbxJinryoGubun3
            // 
            this.fbxJinryoGubun3.AutoTabDataSelected = true;
            this.fbxJinryoGubun3.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxJinryoGubun3, "fbxJinryoGubun3");
            this.fbxJinryoGubun3.Name = "fbxJinryoGubun3";
            this.fbxJinryoGubun3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSiseolCode_DataValidating);
            this.fbxJinryoGubun3.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCommon_FindClick);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.BindControl = this.dbxJinryoGubunName3;
            this.xEditGridCell19.CellName = "jinryo_gubun_name3";
            this.xEditGridCell19.Col = -1;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // dbxJinryoGubunName3
            // 
            resources.ApplyResources(this.dbxJinryoGubunName3, "dbxJinryoGubunName3");
            this.dbxJinryoGubunName3.Name = "dbxJinryoGubunName3";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.txtComment;
            this.xEditGridCell12.CellLen = 1000;
            this.xEditGridCell12.CellName = "comments";
            this.xEditGridCell12.Col = -1;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // txtComment
            // 
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.BindControl = this.cbxUseYn;
            this.xEditGridCell11.CellName = "use_yn";
            this.xEditGridCell11.Col = -1;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // cbxUseYn
            // 
            resources.ApplyResources(this.cbxUseYn, "cbxUseYn");
            this.cbxUseYn.Name = "cbxUseYn";
            this.cbxUseYn.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "retrieve_yn";
            this.xEditGridCell20.Col = -1;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.dtpEndDate);
            this.pnlBody.Controls.Add(this.xLabel14);
            this.pnlBody.Controls.Add(this.dtpStartDate);
            this.pnlBody.Controls.Add(this.xLabel12);
            this.pnlBody.Controls.Add(this.cbxUseYn);
            this.pnlBody.Controls.Add(this.dbxJinryoGubunName3);
            this.pnlBody.Controls.Add(this.fbxJinryoGubun3);
            this.pnlBody.Controls.Add(this.dbxJinryoGubunName2);
            this.pnlBody.Controls.Add(this.fbxJinryoGubun2);
            this.pnlBody.Controls.Add(this.xLabel13);
            this.pnlBody.Controls.Add(this.dbxJinryoGubunName1);
            this.pnlBody.Controls.Add(this.fbxJinryoGubun1);
            this.pnlBody.Controls.Add(this.fbxSgCodeInp);
            this.pnlBody.Controls.Add(this.xLabel11);
            this.pnlBody.Controls.Add(this.xLabel10);
            this.pnlBody.Controls.Add(this.xLabel9);
            this.pnlBody.Controls.Add(this.dbxSgNameOut);
            this.pnlBody.Controls.Add(this.fbxSgCodeOut);
            this.pnlBody.Controls.Add(this.dbxSgNameInp);
            this.pnlBody.Controls.Add(this.dbxGubunName);
            this.pnlBody.Controls.Add(this.fbxGubun);
            this.pnlBody.Controls.Add(this.cboJukyongGubun);
            this.pnlBody.Controls.Add(this.dbxSiseolName);
            this.pnlBody.Controls.Add(this.fbxSiseolCode);
            this.pnlBody.Controls.Add(this.xPanel4);
            this.pnlBody.Controls.Add(this.xLabel5);
            this.pnlBody.Controls.Add(this.xLabel6);
            this.pnlBody.Controls.Add(this.xLabel7);
            this.pnlBody.Controls.Add(this.xLabel3);
            this.pnlBody.Controls.Add(this.xLabel2);
            resources.ApplyResources(this.pnlBody, "pnlBody");
            this.pnlBody.Name = "pnlBody";
            // 
            // xLabel14
            // 
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.Name = "xLabel14";
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel13
            // 
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.Name = "xLabel13";
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Name = "xLabel9";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.txtComment);
            this.xPanel4.Controls.Add(this.xLabel4);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layDupCheck
            // 
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupCheck.QuerySQL = resources.GetString("layDupCheck.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // BAS0100U00
            // 
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0100U00";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.BAS0100U00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0100)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

		private string mMsg = "";
		private string mCap = "";

		#endregion

		#region Function

		#region ControlProtect

		private void ControlProtect (bool aIsAll, bool aIsProtect)
		{
			try
			{
				for(int i=0; i<this.pnlBody.Controls.Count; i++)
				{
					if (this.pnlBody.Controls[i] is IDataControl)
					{
						((IDataControl)this.pnlBody.Controls[i]).Protect = aIsProtect;
					}
				}

				this.txtComment.Protect = aIsProtect;
			}
            catch
            {
            }

			this.dtpEndDate.Protect = true;

			if (!aIsAll)
			{
				this.dtpStartDate.Protect = !aIsProtect;
				this.fbxSiseolCode.Protect = !aIsProtect;
				this.cboJukyongGubun.Protect = !aIsProtect;
				this.fbxGubun.Protect = !aIsProtect;
			}
		}

		#endregion

		#region InitGrid

		private void InitGrid ()
		{
			this.dtpStartDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpStartDate.AcceptData();

			this.dtpEndDate.SetEditValue("9998/12/31");
			this.dtpEndDate.AcceptData();
		}

		#endregion

		#region InitScreen

		private void InitScreen()
		{
			this.dtpJukyongDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
		}

		#endregion

		#region Dup Check

		private bool DuplicateCheck(string aStartDate, string aSiseolCode, string aJukyongGubun, string aGubun)
        {
            this.layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupCheck.SetBindVarValue("f_start_date", aStartDate);
            this.layDupCheck.SetBindVarValue("f_siseol_code", aSiseolCode);
            this.layDupCheck.SetBindVarValue("f_jukyong_gubun", aJukyongGubun);
            this.layDupCheck.SetBindVarValue("f_gubun", aGubun);

            this.layDupCheck.QueryLayout();
			
			if (this.layDupCheck.GetItemValue("dup_yn").ToString() == "Y")
			{
				return true;
			}
			else
			{
				return false;
			}			
		}

		#endregion

		#region IsAbleToInsertNewRow

		private bool IsAbleToInsertNewRow()
		{
			foreach (DataRow dr in this.grdBAS0100.LayoutTable.Rows)
			{
				if (dr["start_date"].ToString()    == "" ||
					dr["siseol_code"].ToString()   == "" ||
					dr["jukyong_gubun"].ToString() == "" ||
					dr["gubun"].ToString()         == ""  )
				{
					return false;
				}
			}

			return true;
		}

		#endregion

		#endregion

		#region XFindBox

		#region FindClick

		private void fbxCommon_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XFindBox control = (XFindBox) sender;

			this.fwkCommon.ColInfos.Clear();

            string findQuery1 = @"SELECT A.CODE
                                       , A.CODE_NAME
                                    FROM BAS0102 A
                                   WHERE A.HOSP_CODE    = :f_hosp_code
                                     AND A.CODE_TYPE    = :f_code_type
                                     AND (  A.CODE      LIKE :f_find1 || '%'
                                         OR A.CODE_NAME LIKE :f_find1 || '%' )
                                     ORDER BY A.CODE";

            string findQuery5 = @"SELECT A.SG_CODE
                                         , A.SG_NAME
                                         , POINT
                                         , DECODE(POINT_GUBUN, '1', FN_ADM_MSG('683'), '2', FN_ADM_MSG('684'))
                                      FROM BAS0310 A
                                     WHERE A.HOSP_CODE    = :f_hosp_code
                                       AND (A.SG_CODE || A.SG_NAME LIKE '%' || :f_find1 || '%' )
                                       AND A.SG_YMD = (SELECT MAX(Z.SG_YMD)
                                                         FROM BAS0310 Z
                                                        WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                          AND Z.SG_CODE   = A.SG_CODE
                                                          --AND Z.SG_NAME   = A.SG_NAME
                                                          AND Z.SG_YMD   <= TO_DATE(:f_sg_ymd, 'YYYY/MM/DD') )
                                      -- AND TO_DATE(:f_sg_ymd, 'YYYY/MM/DD') BETWEEN A.SG_YMD AND A.BULYONG_YMD
                                     ORDER BY A.SG_CODE";

			switch (control.Name)
			{
				case "fbxSiseolCode" :    // 시설코드 BAS0102 , CODE_TYPE = 'SISEOL_CODE'

					#region 시설코드

					/* 파인드 워커 셋팅 */
                    this.fwkCommon.InputSQL = findQuery1;

					this.fwkCommon.FormText    = Resource.TEXT1;
					this.fwkCommon.AutoQuery   = true;
					this.fwkCommon.IsSetControlText = false;

                    /* In 변수 */
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_code_type", "SISEOL_CODE");

					/* ColInfo */
					this.fwkCommon.ColInfos.Add("code"     , Resource.TEXT     , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("code_name", Resource.TEXT2 , FindColType.String, 200, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					#endregion

                    break;
				case "fbxGubun" :         // 환자유형 BAS0210 , 

					#region 보험종별
					/* 파인드 워커 셋팅 */
                    this.fwkCommon.InputSQL = @"SELECT '%'
                                                     , FN_ADM_MSG(221)
                                                  FROM DUAL
                                                 UNION
                                                SELECT A.GUBUN
                                                     , A.GUBUN_NAME
                                                  FROM BAS0210 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code 
                                                   AND (  A.GUBUN      LIKE :f_find1 || '%'
                                                       OR A.GUBUN_NAME LIKE :f_find1 || '%')
                                                   AND TO_DATE(:f_gubun_ymd, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                                 ORDER BY 1";

					this.fwkCommon.FormText    = Resource.TEXT4;
					this.fwkCommon.AutoQuery   = true;
					this.fwkCommon.IsSetControlText = false;

                    /* In 변수 */
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_gubun_ymd", this.dtpJukyongDate.GetDataValue());

					/* ColInfo */
					this.fwkCommon.ColInfos.Add("code"     , Resource.TEXT     , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("code_name", Resource.TEXT2 , FindColType.String, 200, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;
				case "fbxSgCodeInp":      // 입원 점수코드

					#region 점수코드

					/* 파인드 워커 셋팅 */
                    this.fwkCommon.InputSQL = findQuery5;
                    this.fwkCommon.FormText = Resource.TEXT5;
                    this.fwkCommon.AutoQuery = true;
                    this.fwkCommon.IsSetControlText = true;

                    /* In 변수 */
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_sg_ymd", this.dtpJukyongDate.GetDataValue());

					/* ColInfo */
					this.fwkCommon.ColInfos.Add("sg_code"     , Resource.TEXT6     , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("sg_code_name", Resource.TEXT7 , FindColType.String, 250, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("sg_amt"      , Resource.TEXT8           , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("sg_gubun"    , Resource.TEXT9           , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;
					this.fwkCommon.ColInfos[2].ColAlign = HorizontalAlignment.Right;
					this.fwkCommon.ColInfos[3].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;
				case "fbxSgCodeOut":      // 외래 점수코드

					#region 점수코드

					/* 파인드 워커 셋팅 */
                    this.fwkCommon.InputSQL = findQuery5;
                    this.fwkCommon.FormText = Resource.TEXT5;
                    this.fwkCommon.AutoQuery = true;
                    this.fwkCommon.IsSetControlText = true;

                    /* In 변수 */
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.fwkCommon.SetBindVarValue("f_sg_ymd", this.dtpJukyongDate.GetDataValue());

					/* ColInfo */
					this.fwkCommon.ColInfos.Add("sg_code"     , Resource.TEXT6     , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("sg_code_name", Resource.TEXT7 , FindColType.String, 250, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("sg_amt"      , Resource.TEXT8           , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("sg_gubun"    , Resource.TEXT9           , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;
					this.fwkCommon.ColInfos[2].ColAlign = HorizontalAlignment.Right;
					this.fwkCommon.ColInfos[3].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;
				case "fbxJinryoGubun1":   // 진료구분 1

					#region 진료구분

					/* 파인드 워커 셋팅 */
                    this.fwkCommon.InputSQL = findQuery1;
					this.fwkCommon.FormText    = Resource.TEXT1;
					this.fwkCommon.AutoQuery   = true;
					this.fwkCommon.IsSetControlText = false;

                    /* In 변수 */
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.fwkCommon.SetBindVarValue("f_code_type", "JINRYO_GUBUN");

					/* ColInfo */
					this.fwkCommon.ColInfos.Add("code"     , Resource.TEXT     , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("code_name", Resource.TEXT2 , FindColType.String, 200, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;
				case "fbxJinryoGubun2":   // 진료구분 2

					#region 진료구분

                    /* 파인드 워커 셋팅 */
                    this.fwkCommon.InputSQL = findQuery1;
					this.fwkCommon.FormText    = Resource.TEXT1;
					this.fwkCommon.AutoQuery   = true;
					this.fwkCommon.IsSetControlText = false;

                    /* In 변수 */
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.fwkCommon.SetBindVarValue("f_code_type", "JINRYO_GUBUN");

					/* ColInfo */
					this.fwkCommon.ColInfos.Add("code"     , Resource.TEXT     , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("code_name", Resource.TEXT2 , FindColType.String, 200, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;
				case "fbxJinryoGubun3":   // 진료구분 3

					#region 진료구분

                    /* 파인드 워커 셋팅 */
                    this.fwkCommon.InputSQL = findQuery1;
					this.fwkCommon.FormText    = Resource.TEXT1;
					this.fwkCommon.AutoQuery   = true;
					this.fwkCommon.IsSetControlText = false;

                    /* In 변수 */
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.fwkCommon.SetBindVarValue("f_code_type", "JINRYO_GUBUN");

					/* ColInfo */
					this.fwkCommon.ColInfos.Add("code"     , Resource.TEXT     , FindColType.String,  80, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos.Add("code_name", Resource.TEXT2 , FindColType.String, 200, 0, true, FilterType.InitYes);
					this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;
			}
		}

		#endregion

		#region Validating

		private void fbxSiseolCode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string name = "";
			XFindBox control = (XFindBox)sender;

			this.layCommon.LayoutItems.Clear();

            string layQuery2 = @"SELECT CODE_NAME
                                     , SORT_KEY
                                  FROM BAS0102
                                 WHERE HOSP_CODE = :f_hosp_code 
                                   AND CODE_TYPE = :f_code_type
                                   AND CODE      = :f_code       ";

            string layQuery6 = @"SELECT A.GUBUN_NAME
                                     , NVL(A.GONGBI_YN, 'N')
                                     , A.JOHAP_GUBUN
                                  FROM BAS0210 A
                                 WHERE A.HOSP_CODE = :f_hosp_code 
                                   AND TO_DATE(:f_gubun_ymd, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                   AND A.GUBUN     = :f_gubun";

            string layQuery8 = @"SELECT DISTINCT 
                                   A.SG_NAME
                                 , A.SG_UNION
                                 , A.POINT
                              FROM BAS0310 A
                             WHERE A.HOSP_CODE = :f_hosp_code 
                               AND A.SG_CODE     = :f_sg_code            
                               AND A.SG_YMD = (SELECT MAX(Z.SG_YMD)
                                                         FROM BAS0310 Z
                                                        WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                          AND Z.SG_CODE   = A.SG_CODE
                                                          AND Z.SG_YMD   <= TO_DATE(:f_sg_ymd, 'YYYY/MM/DD') ) ";

			switch (control.Name)
			{
				case "fbxSiseolCode" :    // 시설코드 BAS0102 , CODE_TYPE = 'SISEOL_CODE'

					#region 시설코드

					if (e.DataValue == "")
					{
						this.dbxSiseolName.SetEditValue("");
						this.dbxSiseolName.AcceptData();
						this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "siseol_code_name", "");

						return;
					}

					#region 중복체크            

					if (this.DuplicateCheck(this.dtpStartDate.GetDataValue(), e.DataValue
						                  , this.cboJukyongGubun.GetDataValue(), this.fbxGubun.GetDataValue()))
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Resource.TEXT10);
						this.SetMsg(this.mMsg, MsgType.Error);
						e.Cancel = true;
						return;
					}
						              
					#endregion

					#region 서비스 셋팅

					this.layCommon.QuerySQL = layQuery2;

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.layCommon.SetBindVarValue("f_code_type", "SISEOL_CODE");
					this.layCommon.SetBindVarValue("f_code"     , e.DataValue  );

					this.layCommon.LayoutItems.Add("code_name");

					#endregion

					this.layCommon.QueryLayout();
					name = this.layCommon.GetItemValue("code_name").ToString();

					this.dbxSiseolName.SetEditValue(name);
					this.dbxSiseolName.AcceptData();
					this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "siseol_code_name", name);

                    if (name == "")
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지 않습니다." : Resource.TEXT11);
						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					#endregion

					break;
				case "fbxGubun" :         // 환자유형 BAS0210 , 

					#region 보험종별
					
					if (e.DataValue == "")
					{
						this.dbxGubunName.SetEditValue("");
						this.dbxGubunName.AcceptData();
						this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "gubun_name", "");

						return;
					}

					if (e.DataValue == "%")
					{
						this.dbxGubunName.SetEditValue(Resource.TEXT12);
						this.dbxGubunName.AcceptData();
						this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "gubun_name", "");

						return;
					}

					#region 중복체크

					if (this.DuplicateCheck(this.dtpStartDate.GetDataValue(), this.fbxSiseolCode.GetDataValue()
						, this.cboJukyongGubun.GetDataValue(), e.DataValue))
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Resource.TEXT10);
						this.SetMsg(this.mMsg, MsgType.Error);
						e.Cancel = true;
						return;
					}
						              
					#endregion

					#region 서비스 셋팅

                    this.layCommon.QuerySQL = layQuery6;

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layCommon.SetBindVarValue("f_gubun", e.DataValue);
                    this.layCommon.SetBindVarValue("f_gubun_ymd", this.dtpJukyongDate.GetDataValue());

					this.layCommon.LayoutItems.Add("gubun_name");

					#endregion

					this.layCommon.QueryLayout();

					name = this.layCommon.GetItemValue("gubun_name").ToString();
				
					this.dbxGubunName.SetEditValue(name);
					this.dbxGubunName.AcceptData();
					this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "gubun_name", name);
					
					if(name == "")
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "보험종별이 정확하지 않습니다." : Resource.TEXT13);

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					#endregion

					break;
				case "fbxSgCodeInp":      // 입원 점수코드

					#region 점수코드

					if (e.DataValue == "")
					{
						this.dbxSgNameInp.SetEditValue("");
						this.dbxSgNameInp.AcceptData();
						this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "sg_name_inp", "");

						return;
					}

					#region 서비스 셋팅

					this.layCommon.QuerySQL = layQuery8;

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.layCommon.SetBindVarValue("f_sg_code", e.DataValue);
                    this.layCommon.SetBindVarValue("f_sg_ymd", this.dtpJukyongDate.GetDataValue());

					this.layCommon.LayoutItems.Add("sg_name");

					#endregion

					this.layCommon.QueryLayout();

					name = this.layCommon.GetItemValue("sg_name").ToString();
                    					
					this.dbxSgNameInp.SetEditValue(name);
					this.dbxSgNameInp.AcceptData();
					this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "sg_name_inp", name);
					
					if(name == "")
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "점수코드가 정확하지 않습니다." : "コードが正確ではないです. 確認してください。");

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					#endregion

					break;

				case "fbxSgCodeOut":      // 외래 점수코드

					#region 점수코드

					if (e.DataValue == "")
					{
						this.dbxSgNameOut.SetEditValue("");
						this.dbxSgNameOut.AcceptData();
						this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "sg_name_out", "");

						return;
					}

					#region 서비스 셋팅

                    this.layCommon.QuerySQL = layQuery8;

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layCommon.SetBindVarValue("f_sg_code", e.DataValue);
                    this.layCommon.SetBindVarValue("f_sg_ymd", this.dtpJukyongDate.GetDataValue());

                    this.layCommon.LayoutItems.Add("sg_name");

					#endregion

					this.layCommon.QueryLayout();

					name = this.layCommon.GetItemValue("sg_name").ToString();

					this.dbxSgNameOut.SetEditValue(name);
					this.dbxSgNameOut.AcceptData();
					this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "sg_name_out", name);
					
					if(name == "")
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "점수코드가 정확하지 않습니다." : "コードが正確ではないです. 確認してください。");

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					#endregion

					break;
				case "fbxJinryoGubun1":   // 진료구분 1

					#region 진료구분

					if (e.DataValue == "")
					{
						this.dbxJinryoGubunName1.SetEditValue("");
						this.dbxJinryoGubunName1.AcceptData();
						this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "jinryo_gubun_name1", "");

						return;
					}

					#region 서비스 셋팅

					this.layCommon.QuerySQL = layQuery2;

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.layCommon.SetBindVarValue("f_code_type", "JINRYO_GUBUN");
                    this.layCommon.SetBindVarValue("f_code", e.DataValue);

					this.layCommon.LayoutItems.Add("code_name");

					#endregion

					this.layCommon.QueryLayout();
					name = this.layCommon.GetItemValue("code_name").ToString();
					
				    this.dbxJinryoGubunName1.SetEditValue(name);
				    this.dbxJinryoGubunName1.AcceptData();
				    this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "jinryo_gubun_name1", name);
					
					if(name == "")
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지 않습니다." : Resource.TEXT11);
						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					#endregion

					break;

				case "fbxJinryoGubun2":   // 진료구분 2

					#region 진료구분

					if (e.DataValue == "")
					{
						this.dbxJinryoGubunName2.SetEditValue("");
						this.dbxJinryoGubunName2.AcceptData();
						this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "jinryo_gubun_name2", "");

						return;
					}

					#region 서비스 셋팅

					this.layCommon.QuerySQL = layQuery2;

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.layCommon.SetBindVarValue("f_code_type", "JINRYO_GUBUN");
                    this.layCommon.SetBindVarValue("f_code", e.DataValue);

					this.layCommon.LayoutItems.Add("code_name");

					#endregion

					this.layCommon.QueryLayout();
					name = this.layCommon.GetItemValue("code_name").ToString();

					this.dbxJinryoGubunName2.SetEditValue(name);
					this.dbxJinryoGubunName2.AcceptData();
					this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "jinryo_gubun_name2", name);
					
					if(name == "")
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지 않습니다." : Resource.TEXT11);
						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					#endregion

					break;

				case "fbxJinryoGubun3":   // 진료구분 3

					#region 진료구분

					if (e.DataValue == "")
					{
						this.dbxJinryoGubunName3.SetEditValue("");
						this.dbxJinryoGubunName3.AcceptData();
						this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "jinryo_gubun_name3", name);

						return;
					}

					#region 서비스 셋팅

					this.layCommon.QuerySQL = layQuery2;

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.layCommon.SetBindVarValue("f_code_type", "JINRYO_GUBUN");
                    this.layCommon.SetBindVarValue("f_code", e.DataValue);

					this.layCommon.LayoutItems.Add("code_name");

					#endregion

					this.layCommon.QueryLayout();
					name = this.layCommon.GetItemValue("code_name").ToString();

					this.dbxJinryoGubunName3.SetEditValue(name);
					this.dbxJinryoGubunName3.AcceptData();
					this.grdBAS0100.SetItemValue(grdBAS0100.CurrentRowNumber, "jinryo_gubun_name3", name);
					
					if(name == "")
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지 않습니다." : Resource.TEXT11);
						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					#endregion

					break;
			}
		}

		#endregion
		
		#endregion

		#region Screen Load

		private void BAS0100U00_Load(object sender, System.EventArgs e)
        {
            this.grdBAS0100.SavePerformer = new XSavePeformer(this);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad ()
		{
			this.ControlProtect(true, true);

            this.InitScreen();
            LoadData();
		}

		#endregion

		#region LoadData

		private void LoadData()
		{
			this.grdBAS0100.QueryLayout(false);
		}

		#endregion 

		#region XEditGrid

		private void grdBAS0100_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
		
			if (this.grdBAS0100.GetItemString(e.CurrentRow, "retrieve_yn") == "Y")
			{
				this.ControlProtect(false, false);
			}
			else
			{
				this.ControlProtect(true, false);
			}
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			this.CurrMSLayout = this.grdBAS0100;
			this.CurrMQLayout = this.grdBAS0100;

			switch (e.Func)
			{
				case FunctionType.Query :
 
					e.IsBaseCall = false;

					this.LoadData();

					break;

				case FunctionType.Insert :

					e.IsBaseCall = false;

					if (this.IsAbleToInsertNewRow())
					{
						this.grdBAS0100.InsertRow(-1);

						this.InitGrid();

						this.fbxSiseolCode.Focus();
					}

					break;
				
				case FunctionType.Update :

					e.IsBaseCall = false;

                    if (this.grdBAS0100.SaveLayout())
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Resource.TEXT14;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //this.LoadData(); 로우 포커스 이동안되도록
                    }
                    else
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resource.TEXT15;
                        this.mMsg += "\r\n" + Service.ErrFullMsg;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Resource.TEXT15;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

					break;

				case FunctionType.Delete:

					e.IsBaseCall = true;

					break;
			}
		}

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Reset:

					this.ControlProtect(true, true);

					this.InitScreen();

					break;
			}
		}

		#endregion

		#region XComboBox

		private void cboJukyongGubun_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			#region 중복체크

			if (this.DuplicateCheck(this.dtpStartDate.GetDataValue(), e.DataValue
				, this.cboJukyongGubun.GetDataValue(), this.fbxGubun.GetDataValue()))
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Resource.TEXT10);
				this.SetMsg(this.mMsg, MsgType.Error);
				e.Cancel = true;
				return;
			}
						              
			#endregion
		}

		#endregion

		#region Focus 관련

		private void dtpStartDate_Leave(object sender, System.EventArgs e)
		{
			this.txtComment.Focus();
		}

		#endregion

		#region XDatePicker

		private void dtpJukyongDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (TypeCheck.IsDateTime(e.DataValue))
			{
				this.LoadData();
			}
		}

		#endregion

		#region XTextBox

		private void txtSearchGubun_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.LoadData();
		}

		#endregion

        private void grdBAS0100_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0100.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBAS0100.SetBindVarValue("f_jukyong_date", this.dtpJukyongDate.GetDataValue());
            this.grdBAS0100.SetBindVarValue("f_search_word", this.txtSearchGubun.GetDataValue());
        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0100U00 parent = null;

            public XSavePeformer(BAS0100U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                switch (callerId)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y' 
            	                              FROM DUAL
            	                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0100 A
                                                             WHERE A.HOSP_CODE     = :f_hosp_code 
                                                               AND A.START_DATE    = :f_start_date
                                                               AND A.SISEOL_CODE   = :f_siseol_code
                                                               AND A.JUKYONG_GUBUN = :f_jukyong_gubun
                                                               AND A.GUBUN         = :f_gubun    )   ";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT16+" :「" + item.BindVarList["f_start_date"].VarValue + "」\r\n" +
                                                         Resource.TEXT17+" :「" + item.BindVarList["f_siseol_code"].VarValue + "」\r\n" +
                                                         Resource.TEXT18+" :「" + item.BindVarList["f_jukyong_gubun"].VarValue + "」\r\n" +
                                                         Resource.TEXT19+" :「" + item.BindVarList["f_gubun"].VarValue + "」\r\n" +
                                                         Resource.TEXT20, Resource.TEXT21, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                /* 입력된 시작일 이후로의 데이터가 존재 하는지 체크 */
                                cmdText = @"SELECT 'Y'
            	                              FROM DUAL
            	                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0100 A
                                                             WHERE A.HOSP_CODE     = :f_hosp_code 
                                                               AND A.START_DATE   >= :f_start_date
                                                               AND A.SISEOL_CODE   = :f_siseol_code
                                                               AND A.JUKYONG_GUBUN = :f_jukyong_gubun
                                                               AND A.GUBUN         = :f_gubun )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT17+" :「" + item.BindVarList["f_siseol_code"].VarValue + "」\r\n" +
                                                         Resource.TEXT18+" :「" + item.BindVarList["f_jukyong_gubun"].VarValue + "」\r\n" +
                                                         Resource.TEXT19+" :「" + item.BindVarList["f_gubun"].VarValue + "」より\r\n" +
                                                         Resource.TEXT22, Resource.TEXT21, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"UPDATE BAS0403 A
            	                               SET A.END_DATE     = TO_DATE(:f_start_date, 'YYYY/MM/DD') -1
            	                             WHERE A.HOSP_CODE     = :f_hosp_code 
                                               AND A.SISEOL_CODE   = :f_siseol_code
                                               AND A.JUKYONG_GUBUN = :f_jukyong_gubun
                                               AND A.GUBUN         = :f_gubun
            	                               AND A.END_DATE     = TO_DATE('9998/12/31', 'YYYY/MM/DD')
                                               AND TO_DATE(:f_start_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE ";
                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO BAS0100
                                                 ( SYS_DATE           , SYS_ID              , UPD_DATE      , UPD_ID  , HOSP_CODE 
                                                 , START_DATE         , END_DATE            , SISEOL_CODE
                                                 , JUKYONG_GUBUN      , GUBUN               , SG_CODE_INP
                                                 , SG_CODE_OUT        , JINRYO_GUBUN1       , JINRYO_GUBUN2
                                                 , JINRYO_GUBUN3      , USE_YN              , COMMENTS        )
                                            VALUES
                                                 ( SYSDATE            , :q_user_id          , SYSDATE        , :q_user_id , :f_hosp_code
                                                 , :f_start_date      , :f_end_date         , :f_siseol_code
                                                 , :f_jukyong_gubun   , :f_gubun            , :f_sg_code_inp
                                                 , :f_sg_code_out     , :f_jinryo_gubun1    , :f_jinryo_gubun2
                                                 , :f_jinryo_gubun3   , :f_use_yn           , :f_comments      )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE BAS0100
                                               SET UPD_ID          = :q_user_id
                                                 , UPD_DATE        = SYSDATE
                                                 , END_DATE        = :f_end_date
                                                 , JUKYONG_GUBUN   = :f_jukyong_gubun
                                                 , GUBUN           = :f_gubun
                                                 , SG_CODE_INP     = :f_sg_code_inp
                                                 , SG_CODE_OUT     = :f_sg_code_out
                                                 , JINRYO_GUBUN1   = :f_jinryo_gubun1
                                                 , JINRYO_GUBUN2   = :f_jinryo_gubun2
                                                 , JINRYO_GUBUN3   = :f_jinryo_gubun3
                                                 , USE_YN          = :f_use_yn
                                                 , COMMENTS        = :f_comments
                                             WHERE HOSP_CODE       = :f_hosp_code 
                                               AND START_DATE      = :f_start_date
                                               AND SISEOL_CODE     = :f_siseol_code
                                               AND JUKYONG_GUBUN   = :f_jukyong_gubun
                                               AND GUBUN           = :f_gubun        ";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"UPDATE BAS0100
            	                               SET END_DATE   = TO_DATE('9998/12/31', 'YYYY/MM/DD')
            	                             WHERE HOSP_CODE       = :f_hosp_code 
                                               AND END_DATE        = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
                                               AND SISEOL_CODE     = :f_siseol_code
                                               AND JUKYONG_GUBUN   = :f_jukyong_gubun
                                               AND GUBUN           = :f_gubun ";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM BAS0100
                                             WHERE HOSP_CODE       = :f_hosp_code 
                                               AND START_DATE      = :f_start_date
                                               AND SISEOL_CODE     = :f_siseol_code
                                               AND JUKYONG_GUBUN   = :f_jukyong_gubun
                                               AND GUBUN           = :f_gubun        ";
                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
	}
}

