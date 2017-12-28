#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0001U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0001U00 : IHIS.Framework.XScreen
	{
		#region 사용자 변수

		private string mbxMsg = "";
		private string mbxCap = "";

		#endregion

		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XPanel pnlBody;
		private IHIS.Framework.XLabel xLabel12;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel14;
		private IHIS.Framework.XFindBox fbxZip_Code1;
		private IHIS.Framework.XTextBox txtZip_Code2;
		private IHIS.Framework.XFindBox fbxDong_Name;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XLabel xLabel10;
		private IHIS.Framework.XLabel xLabel11;
		private IHIS.Framework.XLabel xLabel13;
		private IHIS.Framework.XLabel xLabel15;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel16;
		private IHIS.Framework.XDatePicker dtpStart_Date;
		private IHIS.Framework.XTextBox txtEmail;
		private IHIS.Framework.XTextBox txtHomepage;
		private IHIS.Framework.XEditMask mskTot_Bed;
		private IHIS.Framework.XTextBox txtTel1;
		private IHIS.Framework.XTextBox txtFax;
		private IHIS.Framework.XTextBox txtTel;
		private IHIS.Framework.XTextBox txtYoyang_Name2;
		private IHIS.Framework.XTextBox txtYoyang_Name;
		private IHIS.Framework.XTextBox txtYoyang_Giho;
		private IHIS.Framework.XDatePicker dtpEnd_Date;
		private IHIS.Framework.SingleLayout layComm;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDictComboBox cboHosp_Jin_Gubun;
		private IHIS.Framework.XTextBox txtAddress;
		private IHIS.Framework.XTextBox txtAddress1;
		private IHIS.Framework.XEditGrid grdBAS0001;
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
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XFindBox fbxDodobuHyeun;
		private IHIS.Framework.XDisplayBox dbxDodobuhyeunName;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XLabel xLabel17;
		private IHIS.Framework.XLabel xLabel18;
		private IHIS.Framework.XGroupBox gbxBank;
		private IHIS.Framework.XLabel xLabel19;
		private IHIS.Framework.XLabel xLabel20;
		private IHIS.Framework.XLabel xLabel21;
		private IHIS.Framework.XLabel xLabel22;
		private IHIS.Framework.XLabel xLabel23;
		private IHIS.Framework.XTextBox txtJaedanName;
		private IHIS.Framework.XTextBox txtSimpleYoyangName;
		private IHIS.Framework.XTextBox txtBankName;
        private IHIS.Framework.XTextBox txtBankJijum;
		private IHIS.Framework.XTextBox txtBankNo;
		private IHIS.Framework.XTextBox txtBankAccName;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private XTextBox txtPresidentName;
        private XLabel xLabel25;
        private XTextBox txtGigwanCode;
        private XLabel xLabel24;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell27;
        private XButton btnCopy;
        private XHospBox xHospBox;
        private XEditGridCell xEditGridCell28;
        private XTextBox txtAcct_ref_id;
        private XGroupBox xGroupBox1;
        private XLabel xLabel30;
        private XLabel xLabel31;
        private XTextBox xTextBoxTimeZone;
        private XCheckBox checkBoxVpnYn;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XLabel xLabel26;
        private XEditGridCell xEditGridCell31;
        private XDictComboBox cbxBankAccGubun;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0001U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

//            this.grdBAS0001.SavePerformer = new XSavePeformer(this);

            //MED-12037
            if (NetInfo.Language != LangMode.Jr)
            {
                this.xLabel26.Visible = false;
                this.txtAcct_ref_id.Visible = false;
            }

            // Set ParamList and ExecuteQuery
		    cboHosp_Jin_Gubun.ExecuteQuery = ExecuteQueryCboHospJinGubun;
		    cboHosp_Jin_Gubun.SetDictDDLB();

            cbxBankAccGubun.ExecuteQuery = LoadbankAccType;
            cbxBankAccGubun.SetDictDDLB();

		    grdBAS0001.ExecuteQuery = ExecuteQueryGrdBAS0001;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0001U00));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdBAS0001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.dtpStart_Date = new IHIS.Framework.XDatePicker();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.dtpEnd_Date = new IHIS.Framework.XDatePicker();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.fbxDodobuHyeun = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.dbxDodobuhyeunName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.txtJaedanName = new IHIS.Framework.XTextBox();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.txtSimpleYoyangName = new IHIS.Framework.XTextBox();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.txtBankName = new IHIS.Framework.XTextBox();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.txtBankJijum = new IHIS.Framework.XTextBox();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.txtBankNo = new IHIS.Framework.XTextBox();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.txtBankAccName = new IHIS.Framework.XTextBox();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.txtPresidentName = new IHIS.Framework.XTextBox();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.txtGigwanCode = new IHIS.Framework.XTextBox();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.txtAcct_ref_id = new IHIS.Framework.XTextBox();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.checkBoxVpnYn = new IHIS.Framework.XCheckBox();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xTextBoxTimeZone = new IHIS.Framework.XTextBox();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.cbxBankAccGubun = new IHIS.Framework.XDictComboBox();
            this.pnlBody = new IHIS.Framework.XPanel();
            this.xGroupBox1 = new IHIS.Framework.XGroupBox();
            this.xLabel30 = new IHIS.Framework.XLabel();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.gbxBank = new IHIS.Framework.XGroupBox();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.cboHosp_Jin_Gubun = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtEmail = new IHIS.Framework.XTextBox();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.txtHomepage = new IHIS.Framework.XTextBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.mskTot_Bed = new IHIS.Framework.XEditMask();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.txtTel1 = new IHIS.Framework.XTextBox();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.txtFax = new IHIS.Framework.XTextBox();
            this.txtTel = new IHIS.Framework.XTextBox();
            this.txtYoyang_Name2 = new IHIS.Framework.XTextBox();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.txtAddress = new IHIS.Framework.XTextBox();
            this.fbxZip_Code1 = new IHIS.Framework.XFindBox();
            this.txtAddress1 = new IHIS.Framework.XTextBox();
            this.txtZip_Code2 = new IHIS.Framework.XTextBox();
            this.fbxDong_Name = new IHIS.Framework.XFindBox();
            this.txtYoyang_Name = new IHIS.Framework.XTextBox();
            this.txtYoyang_Giho = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layComm = new IHIS.Framework.SingleLayout();
            this.btnCopy = new IHIS.Framework.XButton();
            this.xHospBox = new IHIS.Framework.XHospBox();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0001)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.xGroupBox1.SuspendLayout();
            this.gbxBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "복사.gif");
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdBAS0001);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdBAS0001
            // 
            resources.ApplyResources(this.grdBAS0001, "grdBAS0001");
            this.grdBAS0001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell24,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31});
            this.grdBAS0001.ColPerLine = 1;
            this.grdBAS0001.Cols = 2;
            this.grdBAS0001.ControlBinding = true;
            this.grdBAS0001.ExecuteQuery = null;
            this.grdBAS0001.FixedCols = 1;
            this.grdBAS0001.FixedRows = 1;
            this.grdBAS0001.HeaderHeights.Add(20);
            this.grdBAS0001.Name = "grdBAS0001";
            this.grdBAS0001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0001.ParamList")));
            this.grdBAS0001.QuerySQL = resources.GetString("grdBAS0001.QuerySQL");
            this.grdBAS0001.ReadOnly = true;
            this.grdBAS0001.RowHeaderVisible = true;
            this.grdBAS0001.Rows = 2;
            this.grdBAS0001.ToolTipActive = true;
            this.grdBAS0001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdBAS0001_RowFocusChanged);
            this.grdBAS0001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0001_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.BindControl = this.dtpStart_Date;
            this.xEditGridCell1.CellName = "start_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dtpStart_Date
            // 
            this.dtpStart_Date.AccessibleDescription = null;
            this.dtpStart_Date.AccessibleName = null;
            resources.ApplyResources(this.dtpStart_Date, "dtpStart_Date");
            this.dtpStart_Date.BackgroundImage = null;
            this.dtpStart_Date.IsVietnameseYearType = false;
            this.dtpStart_Date.Name = "dtpStart_Date";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.BindControl = this.dtpEnd_Date;
            this.xEditGridCell2.CellName = "end_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dtpEnd_Date
            // 
            this.dtpEnd_Date.AccessibleDescription = null;
            this.dtpEnd_Date.AccessibleName = null;
            resources.ApplyResources(this.dtpEnd_Date, "dtpEnd_Date");
            this.dtpEnd_Date.BackgroundImage = null;
            this.dtpEnd_Date.IsVietnameseYearType = false;
            this.dtpEnd_Date.Name = "dtpEnd_Date";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "yoyang_giho";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "yoyang_name";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "yoyang_name2";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "zip_code1";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "zip_code2";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "zip_code";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "address";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellName = "address1";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "tel";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "tel1";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "fax";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellName = "tot_bed";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "homepage";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "email";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.CellName = "hosp_jin_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.BindControl = this.fbxDodobuHyeun;
            this.xEditGridCell18.CellName = "dodobuhyeun_no";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxDodobuHyeun
            // 
            this.fbxDodobuHyeun.AccessibleDescription = null;
            this.fbxDodobuHyeun.AccessibleName = null;
            resources.ApplyResources(this.fbxDodobuHyeun, "fbxDodobuHyeun");
            this.fbxDodobuHyeun.AutoTabDataSelected = true;
            this.fbxDodobuHyeun.BackgroundImage = null;
            this.fbxDodobuHyeun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxDodobuHyeun.FindWorker = this.fwkCommon;
            this.fbxDodobuHyeun.Name = "fbxDodobuHyeun";
            this.fbxDodobuHyeun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDodobuHyeun_DataValidating);
            this.fbxDodobuHyeun.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDodobuHyeun_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.BindControl = this.dbxDodobuhyeunName;
            this.xEditGridCell19.CellName = "dodobuhyeun_name";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxDodobuhyeunName
            // 
            this.dbxDodobuhyeunName.AccessibleDescription = null;
            this.dbxDodobuhyeunName.AccessibleName = null;
            resources.ApplyResources(this.dbxDodobuhyeunName, "dbxDodobuhyeunName");
            this.dbxDodobuhyeunName.Image = null;
            this.dbxDodobuhyeunName.Name = "dbxDodobuhyeunName";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.BindControl = this.txtJaedanName;
            this.xEditGridCell20.CellName = "jaedan_name";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJaedanName
            // 
            this.txtJaedanName.AccessibleDescription = null;
            this.txtJaedanName.AccessibleName = null;
            resources.ApplyResources(this.txtJaedanName, "txtJaedanName");
            this.txtJaedanName.BackgroundImage = null;
            this.txtJaedanName.Name = "txtJaedanName";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.BindControl = this.txtSimpleYoyangName;
            this.xEditGridCell21.CellName = "simple_yoyang_name";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtSimpleYoyangName
            // 
            this.txtSimpleYoyangName.AccessibleDescription = null;
            this.txtSimpleYoyangName.AccessibleName = null;
            resources.ApplyResources(this.txtSimpleYoyangName, "txtSimpleYoyangName");
            this.txtSimpleYoyangName.BackgroundImage = null;
            this.txtSimpleYoyangName.Name = "txtSimpleYoyangName";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.BindControl = this.txtBankName;
            this.xEditGridCell22.CellName = "bank_name";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtBankName
            // 
            this.txtBankName.AccessibleDescription = null;
            this.txtBankName.AccessibleName = null;
            resources.ApplyResources(this.txtBankName, "txtBankName");
            this.txtBankName.BackgroundImage = null;
            this.txtBankName.Name = "txtBankName";
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.BindControl = this.txtBankJijum;
            this.xEditGridCell23.CellName = "bank_jijun";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtBankJijum
            // 
            this.txtBankJijum.AccessibleDescription = null;
            this.txtBankJijum.AccessibleName = null;
            resources.ApplyResources(this.txtBankJijum, "txtBankJijum");
            this.txtBankJijum.BackgroundImage = null;
            this.txtBankJijum.Name = "txtBankJijum";
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.BindControl = this.txtBankNo;
            this.xEditGridCell25.CellName = "bank_no";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtBankNo
            // 
            this.txtBankNo.AccessibleDescription = null;
            this.txtBankNo.AccessibleName = null;
            resources.ApplyResources(this.txtBankNo, "txtBankNo");
            this.txtBankNo.BackgroundImage = null;
            this.txtBankNo.Name = "txtBankNo";
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.BindControl = this.txtBankAccName;
            this.xEditGridCell26.CellName = "bank_acc_name";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtBankAccName
            // 
            this.txtBankAccName.AccessibleDescription = null;
            this.txtBankAccName.AccessibleName = null;
            resources.ApplyResources(this.txtBankAccName, "txtBankAccName");
            this.txtBankAccName.BackgroundImage = null;
            this.txtBankAccName.Name = "txtBankAccName";
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.BindControl = this.txtPresidentName;
            this.xEditGridCell24.CellName = "president_name";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtPresidentName
            // 
            this.txtPresidentName.AccessibleDescription = null;
            this.txtPresidentName.AccessibleName = null;
            resources.ApplyResources(this.txtPresidentName, "txtPresidentName");
            this.txtPresidentName.BackgroundImage = null;
            this.txtPresidentName.Name = "txtPresidentName";
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.BindControl = this.txtGigwanCode;
            this.xEditGridCell27.CellName = "gigwan_code";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtGigwanCode
            // 
            this.txtGigwanCode.AccessibleDescription = null;
            this.txtGigwanCode.AccessibleName = null;
            resources.ApplyResources(this.txtGigwanCode, "txtGigwanCode");
            this.txtGigwanCode.BackgroundImage = null;
            this.txtGigwanCode.Name = "txtGigwanCode";
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.BindControl = this.txtAcct_ref_id;
            this.xEditGridCell28.CellLen = 100;
            this.xEditGridCell28.CellName = "acct_ref_id";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtAcct_ref_id
            // 
            this.txtAcct_ref_id.AccessibleDescription = null;
            this.txtAcct_ref_id.AccessibleName = null;
            resources.ApplyResources(this.txtAcct_ref_id, "txtAcct_ref_id");
            this.txtAcct_ref_id.BackgroundImage = null;
            this.txtAcct_ref_id.Name = "txtAcct_ref_id";
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.BindControl = this.checkBoxVpnYn;
            this.xEditGridCell29.CellName = "vpn_yn";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // checkBoxVpnYn
            // 
            this.checkBoxVpnYn.AccessibleDescription = null;
            this.checkBoxVpnYn.AccessibleName = null;
            resources.ApplyResources(this.checkBoxVpnYn, "checkBoxVpnYn");
            this.checkBoxVpnYn.BackgroundImage = null;
            this.checkBoxVpnYn.Name = "checkBoxVpnYn";
            this.checkBoxVpnYn.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.BindControl = this.xTextBoxTimeZone;
            this.xEditGridCell30.CellName = "time_zone";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xTextBoxTimeZone
            // 
            this.xTextBoxTimeZone.AccessibleDescription = null;
            this.xTextBoxTimeZone.AccessibleName = null;
            resources.ApplyResources(this.xTextBoxTimeZone, "xTextBoxTimeZone");
            this.xTextBoxTimeZone.BackgroundImage = null;
            this.xTextBoxTimeZone.Name = "xTextBoxTimeZone";
            this.xTextBoxTimeZone.ReadOnly = true;
            this.xTextBoxTimeZone.TabStop = false;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.BindControl = this.cbxBankAccGubun;
            this.xEditGridCell31.CellName = "bank_acc_type";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cbxBankAccGubun
            // 
            this.cbxBankAccGubun.AccessibleDescription = null;
            this.cbxBankAccGubun.AccessibleName = null;
            resources.ApplyResources(this.cbxBankAccGubun, "cbxBankAccGubun");
            this.cbxBankAccGubun.BackgroundImage = null;
            this.cbxBankAccGubun.ExecuteQuery = null;
            this.cbxBankAccGubun.Name = "cbxBankAccGubun";
            this.cbxBankAccGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxBankAccGubun.ParamList")));
            this.cbxBankAccGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // pnlBody
            // 
            this.pnlBody.AccessibleDescription = null;
            this.pnlBody.AccessibleName = null;
            resources.ApplyResources(this.pnlBody, "pnlBody");
            this.pnlBody.BackgroundImage = null;
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBody.Controls.Add(this.xGroupBox1);
            this.pnlBody.Controls.Add(this.txtAcct_ref_id);
            this.pnlBody.Controls.Add(this.xLabel26);
            this.pnlBody.Controls.Add(this.txtPresidentName);
            this.pnlBody.Controls.Add(this.xLabel25);
            this.pnlBody.Controls.Add(this.txtGigwanCode);
            this.pnlBody.Controls.Add(this.xLabel24);
            this.pnlBody.Controls.Add(this.gbxBank);
            this.pnlBody.Controls.Add(this.txtSimpleYoyangName);
            this.pnlBody.Controls.Add(this.txtJaedanName);
            this.pnlBody.Controls.Add(this.xLabel17);
            this.pnlBody.Controls.Add(this.xLabel18);
            this.pnlBody.Controls.Add(this.dbxDodobuhyeunName);
            this.pnlBody.Controls.Add(this.fbxDodobuHyeun);
            this.pnlBody.Controls.Add(this.xLabel8);
            this.pnlBody.Controls.Add(this.cboHosp_Jin_Gubun);
            this.pnlBody.Controls.Add(this.xLabel1);
            this.pnlBody.Controls.Add(this.txtEmail);
            this.pnlBody.Controls.Add(this.xLabel16);
            this.pnlBody.Controls.Add(this.txtHomepage);
            this.pnlBody.Controls.Add(this.xLabel6);
            this.pnlBody.Controls.Add(this.mskTot_Bed);
            this.pnlBody.Controls.Add(this.xLabel15);
            this.pnlBody.Controls.Add(this.txtTel1);
            this.pnlBody.Controls.Add(this.xLabel13);
            this.pnlBody.Controls.Add(this.txtFax);
            this.pnlBody.Controls.Add(this.txtTel);
            this.pnlBody.Controls.Add(this.txtYoyang_Name2);
            this.pnlBody.Controls.Add(this.xLabel11);
            this.pnlBody.Controls.Add(this.xLabel10);
            this.pnlBody.Controls.Add(this.xLabel9);
            this.pnlBody.Controls.Add(this.txtAddress);
            this.pnlBody.Controls.Add(this.fbxZip_Code1);
            this.pnlBody.Controls.Add(this.txtAddress1);
            this.pnlBody.Controls.Add(this.txtZip_Code2);
            this.pnlBody.Controls.Add(this.fbxDong_Name);
            this.pnlBody.Controls.Add(this.txtYoyang_Name);
            this.pnlBody.Controls.Add(this.txtYoyang_Giho);
            this.pnlBody.Controls.Add(this.dtpEnd_Date);
            this.pnlBody.Controls.Add(this.xLabel4);
            this.pnlBody.Controls.Add(this.xLabel14);
            this.pnlBody.Controls.Add(this.dtpStart_Date);
            this.pnlBody.Controls.Add(this.xLabel12);
            this.pnlBody.Controls.Add(this.xLabel5);
            this.pnlBody.Controls.Add(this.xLabel7);
            this.pnlBody.Controls.Add(this.xLabel3);
            this.pnlBody.Controls.Add(this.xLabel2);
            this.pnlBody.Font = null;
            this.pnlBody.Name = "pnlBody";
            // 
            // xGroupBox1
            // 
            this.xGroupBox1.AccessibleDescription = null;
            this.xGroupBox1.AccessibleName = null;
            resources.ApplyResources(this.xGroupBox1, "xGroupBox1");
            this.xGroupBox1.BackgroundImage = null;
            this.xGroupBox1.Controls.Add(this.checkBoxVpnYn);
            this.xGroupBox1.Controls.Add(this.xLabel30);
            this.xGroupBox1.Controls.Add(this.xLabel31);
            this.xGroupBox1.Controls.Add(this.xTextBoxTimeZone);
            this.xGroupBox1.Name = "xGroupBox1";
            this.xGroupBox1.Protect = true;
            this.xGroupBox1.TabStop = false;
            // 
            // xLabel30
            // 
            this.xLabel30.AccessibleDescription = null;
            this.xLabel30.AccessibleName = null;
            resources.ApplyResources(this.xLabel30, "xLabel30");
            this.xLabel30.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel30.EdgeRounding = false;
            this.xLabel30.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel30.Image = null;
            this.xLabel30.Name = "xLabel30";
            // 
            // xLabel31
            // 
            this.xLabel31.AccessibleDescription = null;
            this.xLabel31.AccessibleName = null;
            resources.ApplyResources(this.xLabel31, "xLabel31");
            this.xLabel31.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel31.EdgeRounding = false;
            this.xLabel31.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel31.Image = null;
            this.xLabel31.Name = "xLabel31";
            // 
            // xLabel26
            // 
            this.xLabel26.AccessibleDescription = null;
            this.xLabel26.AccessibleName = null;
            resources.ApplyResources(this.xLabel26, "xLabel26");
            this.xLabel26.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel26.EdgeRounding = false;
            this.xLabel26.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel26.Image = null;
            this.xLabel26.Name = "xLabel26";
            // 
            // xLabel25
            // 
            this.xLabel25.AccessibleDescription = null;
            this.xLabel25.AccessibleName = null;
            resources.ApplyResources(this.xLabel25, "xLabel25");
            this.xLabel25.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel25.EdgeRounding = false;
            this.xLabel25.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel25.Image = null;
            this.xLabel25.Name = "xLabel25";
            // 
            // xLabel24
            // 
            this.xLabel24.AccessibleDescription = null;
            this.xLabel24.AccessibleName = null;
            resources.ApplyResources(this.xLabel24, "xLabel24");
            this.xLabel24.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel24.EdgeRounding = false;
            this.xLabel24.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel24.Image = null;
            this.xLabel24.Name = "xLabel24";
            // 
            // gbxBank
            // 
            this.gbxBank.AccessibleDescription = null;
            this.gbxBank.AccessibleName = null;
            resources.ApplyResources(this.gbxBank, "gbxBank");
            this.gbxBank.BackgroundImage = null;
            this.gbxBank.Controls.Add(this.cbxBankAccGubun);
            this.gbxBank.Controls.Add(this.txtBankAccName);
            this.gbxBank.Controls.Add(this.xLabel23);
            this.gbxBank.Controls.Add(this.txtBankNo);
            this.gbxBank.Controls.Add(this.txtBankJijum);
            this.gbxBank.Controls.Add(this.xLabel22);
            this.gbxBank.Controls.Add(this.xLabel21);
            this.gbxBank.Controls.Add(this.xLabel20);
            this.gbxBank.Controls.Add(this.xLabel19);
            this.gbxBank.Controls.Add(this.txtBankName);
            this.gbxBank.Name = "gbxBank";
            this.gbxBank.Protect = true;
            this.gbxBank.TabStop = false;
            // 
            // xLabel23
            // 
            this.xLabel23.AccessibleDescription = null;
            this.xLabel23.AccessibleName = null;
            resources.ApplyResources(this.xLabel23, "xLabel23");
            this.xLabel23.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel23.EdgeRounding = false;
            this.xLabel23.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel23.Image = null;
            this.xLabel23.Name = "xLabel23";
            // 
            // xLabel22
            // 
            this.xLabel22.AccessibleDescription = null;
            this.xLabel22.AccessibleName = null;
            resources.ApplyResources(this.xLabel22, "xLabel22");
            this.xLabel22.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel22.EdgeRounding = false;
            this.xLabel22.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel22.Image = null;
            this.xLabel22.Name = "xLabel22";
            // 
            // xLabel21
            // 
            this.xLabel21.AccessibleDescription = null;
            this.xLabel21.AccessibleName = null;
            resources.ApplyResources(this.xLabel21, "xLabel21");
            this.xLabel21.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel21.EdgeRounding = false;
            this.xLabel21.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel21.Image = null;
            this.xLabel21.Name = "xLabel21";
            // 
            // xLabel20
            // 
            this.xLabel20.AccessibleDescription = null;
            this.xLabel20.AccessibleName = null;
            resources.ApplyResources(this.xLabel20, "xLabel20");
            this.xLabel20.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel20.EdgeRounding = false;
            this.xLabel20.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel20.Image = null;
            this.xLabel20.Name = "xLabel20";
            // 
            // xLabel19
            // 
            this.xLabel19.AccessibleDescription = null;
            this.xLabel19.AccessibleName = null;
            resources.ApplyResources(this.xLabel19, "xLabel19");
            this.xLabel19.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel19.EdgeRounding = false;
            this.xLabel19.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel19.Image = null;
            this.xLabel19.Name = "xLabel19";
            // 
            // xLabel17
            // 
            this.xLabel17.AccessibleDescription = null;
            this.xLabel17.AccessibleName = null;
            resources.ApplyResources(this.xLabel17, "xLabel17");
            this.xLabel17.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel17.EdgeRounding = false;
            this.xLabel17.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel17.Image = null;
            this.xLabel17.Name = "xLabel17";
            // 
            // xLabel18
            // 
            this.xLabel18.AccessibleDescription = null;
            this.xLabel18.AccessibleName = null;
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel18.Image = null;
            this.xLabel18.Name = "xLabel18";
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // cboHosp_Jin_Gubun
            // 
            this.cboHosp_Jin_Gubun.AccessibleDescription = null;
            this.cboHosp_Jin_Gubun.AccessibleName = null;
            resources.ApplyResources(this.cboHosp_Jin_Gubun, "cboHosp_Jin_Gubun");
            this.cboHosp_Jin_Gubun.BackgroundImage = null;
            this.cboHosp_Jin_Gubun.ExecuteQuery = null;
            this.cboHosp_Jin_Gubun.Name = "cboHosp_Jin_Gubun";
            this.cboHosp_Jin_Gubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboHosp_Jin_Gubun.ParamList")));
            this.cboHosp_Jin_Gubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // txtEmail
            // 
            this.txtEmail.AccessibleDescription = null;
            this.txtEmail.AccessibleName = null;
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.BackgroundImage = null;
            this.txtEmail.Name = "txtEmail";
            // 
            // xLabel16
            // 
            this.xLabel16.AccessibleDescription = null;
            this.xLabel16.AccessibleName = null;
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel16.Image = null;
            this.xLabel16.Name = "xLabel16";
            // 
            // txtHomepage
            // 
            this.txtHomepage.AccessibleDescription = null;
            this.txtHomepage.AccessibleName = null;
            resources.ApplyResources(this.txtHomepage, "txtHomepage");
            this.txtHomepage.BackgroundImage = null;
            this.txtHomepage.Name = "txtHomepage";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // mskTot_Bed
            // 
            this.mskTot_Bed.AccessibleDescription = null;
            this.mskTot_Bed.AccessibleName = null;
            resources.ApplyResources(this.mskTot_Bed, "mskTot_Bed");
            this.mskTot_Bed.BackgroundImage = null;
            this.mskTot_Bed.EditMaskType = IHIS.Framework.MaskType.Number;
            this.mskTot_Bed.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.mskTot_Bed.IsVietnameseYearType = false;
            this.mskTot_Bed.Name = "mskTot_Bed";
            // 
            // xLabel15
            // 
            this.xLabel15.AccessibleDescription = null;
            this.xLabel15.AccessibleName = null;
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel15.Image = null;
            this.xLabel15.Name = "xLabel15";
            // 
            // txtTel1
            // 
            this.txtTel1.AccessibleDescription = null;
            this.txtTel1.AccessibleName = null;
            resources.ApplyResources(this.txtTel1, "txtTel1");
            this.txtTel1.BackgroundImage = null;
            this.txtTel1.Name = "txtTel1";
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            // 
            // txtFax
            // 
            this.txtFax.AccessibleDescription = null;
            this.txtFax.AccessibleName = null;
            resources.ApplyResources(this.txtFax, "txtFax");
            this.txtFax.BackgroundImage = null;
            this.txtFax.Name = "txtFax";
            // 
            // txtTel
            // 
            this.txtTel.AccessibleDescription = null;
            this.txtTel.AccessibleName = null;
            resources.ApplyResources(this.txtTel, "txtTel");
            this.txtTel.BackgroundImage = null;
            this.txtTel.Name = "txtTel";
            // 
            // txtYoyang_Name2
            // 
            this.txtYoyang_Name2.AccessibleDescription = null;
            this.txtYoyang_Name2.AccessibleName = null;
            resources.ApplyResources(this.txtYoyang_Name2, "txtYoyang_Name2");
            this.txtYoyang_Name2.BackgroundImage = null;
            this.txtYoyang_Name2.Name = "txtYoyang_Name2";
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel10
            // 
            this.xLabel10.AccessibleDescription = null;
            this.xLabel10.AccessibleName = null;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel10.Image = null;
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // txtAddress
            // 
            this.txtAddress.AccessibleDescription = null;
            this.txtAddress.AccessibleName = null;
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.BackgroundImage = null;
            this.txtAddress.Name = "txtAddress";
            // 
            // fbxZip_Code1
            // 
            this.fbxZip_Code1.AccessibleDescription = null;
            this.fbxZip_Code1.AccessibleName = null;
            resources.ApplyResources(this.fbxZip_Code1, "fbxZip_Code1");
            this.fbxZip_Code1.BackgroundImage = null;
            this.fbxZip_Code1.Name = "fbxZip_Code1";
            this.fbxZip_Code1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxZip_Code1_FindClick);
            // 
            // txtAddress1
            // 
            this.txtAddress1.AccessibleDescription = null;
            this.txtAddress1.AccessibleName = null;
            resources.ApplyResources(this.txtAddress1, "txtAddress1");
            this.txtAddress1.BackgroundImage = null;
            this.txtAddress1.Name = "txtAddress1";
            // 
            // txtZip_Code2
            // 
            this.txtZip_Code2.AccessibleDescription = null;
            this.txtZip_Code2.AccessibleName = null;
            resources.ApplyResources(this.txtZip_Code2, "txtZip_Code2");
            this.txtZip_Code2.BackgroundImage = null;
            this.txtZip_Code2.Name = "txtZip_Code2";
            this.txtZip_Code2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
            // 
            // fbxDong_Name
            // 
            this.fbxDong_Name.AccessibleDescription = null;
            this.fbxDong_Name.AccessibleName = null;
            resources.ApplyResources(this.fbxDong_Name, "fbxDong_Name");
            this.fbxDong_Name.BackgroundImage = null;
            this.fbxDong_Name.Name = "fbxDong_Name";
            this.fbxDong_Name.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDong_Name_FindClick);
            // 
            // txtYoyang_Name
            // 
            this.txtYoyang_Name.AccessibleDescription = null;
            this.txtYoyang_Name.AccessibleName = null;
            resources.ApplyResources(this.txtYoyang_Name, "txtYoyang_Name");
            this.txtYoyang_Name.BackgroundImage = null;
            this.txtYoyang_Name.Name = "txtYoyang_Name";
            // 
            // txtYoyang_Giho
            // 
            this.txtYoyang_Giho.AccessibleDescription = null;
            this.txtYoyang_Giho.AccessibleName = null;
            resources.ApplyResources(this.txtYoyang_Giho, "txtYoyang_Giho");
            this.txtYoyang_Giho.BackgroundImage = null;
            this.txtYoyang_Giho.Name = "txtYoyang_Giho";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layComm
            // 
            this.layComm.ExecuteQuery = null;
            this.layComm.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layComm.ParamList")));
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleDescription = null;
            this.btnCopy.AccessibleName = null;
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.BackgroundImage = null;
            this.btnCopy.ImageIndex = 0;
            this.btnCopy.ImageList = this.ImageList;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // xHospBox
            // 
            this.xHospBox.AccessibleDescription = null;
            this.xHospBox.AccessibleName = null;
            resources.ApplyResources(this.xHospBox, "xHospBox");
            this.xHospBox.BackColor = System.Drawing.Color.Transparent;
            this.xHospBox.BackgroundImage = null;
            this.xHospBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xHospBox.HospCode = "";
            this.xHospBox.Name = "xHospBox";
            this.xHospBox.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xHospBox_DataValidating);
            this.xHospBox.FindClick += new System.EventHandler(this.xHospBox_FindClick);
            // 
            // BAS0001U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xHospBox);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.xPanel2);
            this.Name = "BAS0001U00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0001U00_ScreenOpen);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0001)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.xGroupBox1.ResumeLayout(false);
            this.xGroupBox1.PerformLayout();
            this.gbxBank.ResumeLayout(false);
            this.gbxBank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 바인딩 setting
		private void SetBinding()
		{
			string colName = "";

			// 환자정보
			foreach(object obj in pnlBody.Controls)
			{
				try
				{
					if( obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
					{
						colName = ((XComboBox)obj).Name.Substring(3).ToLower();
						//Binding
						if(grdBAS0001.CellInfos.Contains(colName)) grdBAS0001.SetBindControl(colName, ((XComboBox)obj));
						//						((XComboBox)obj).Enter += new System.EventHandler(this.SetGrdOCS0103_Enter);
						//						((XComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.hangmog_control_DataValidating);						
					}
					else if( obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
					{
						colName = ((XTextBox)obj).Name.Substring(3).ToLower();
						//Binding
						if(grdBAS0001.CellInfos.Contains(colName)) grdBAS0001.SetBindControl(colName, ((XTextBox)obj));
						//						((XTextBox)obj).Enter += new System.EventHandler(this.SetGrdOCS0103_Enter);
						//						((XTextBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.hangmog_control_DataValidating);

					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditMask" ) >= 0)
					{						
						colName = ((XEditMask)obj).Name.Substring(3).ToLower();

						//Binding
						if(grdBAS0001.CellInfos.Contains(colName)) grdBAS0001.SetBindControl(colName, ((XEditMask)obj));
						//						((XEditMask)obj).Enter += new System.EventHandler(this.SetGrdOCS0103_Enter);
						//						((XEditMask)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.hangmog_control_DataValidating);
					}
					else if( obj.GetType().ToString().IndexOf("XCheckBox" ) >= 0)
					{
						colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
			
						//Binding
						if(grdBAS0001.CellInfos.Contains(colName)) grdBAS0001.SetBindControl(colName, ((XCheckBox)obj));
						//						((XCheckBox)obj).Enter += new System.EventHandler(this.SetGrdOCS0103_Enter);
						//						((XCheckBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.hangmog_control_DataValidating);
					}
					else if( obj.GetType().ToString().IndexOf("XDisplayBox" ) >= 0)
					{
						colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();

						if(grdBAS0001.CellInfos.Contains(colName)) grdBAS0001.SetBindControl(colName, ((XDisplayBox)obj));

						//Binding
						//						if(grdOCS0103.CellInfos.Contains(colName)) grdOCS0103.SetBindControl(colName, ((XDisplayBox)obj));						
					}
					else if( obj.GetType().ToString().IndexOf("XFindBox" ) >= 0)
					{
						colName = ((XFindBox)obj).Name.Substring(3).ToLower();

						//Binding
						if(grdBAS0001.CellInfos.Contains(colName)) grdBAS0001.SetBindControl(colName, ((XFindBox)obj));
						//						((XFindBox)obj).Enter += new System.EventHandler(this.SetGrdOCS0103_Enter);	
						//						((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					}						
//					else if( obj.GetType().ToString().IndexOf("XDatePicker" ) >= 0) 
//					{
//						colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
//
//						//Binding
//						if(grdBAS0001.CellInfos.Contains(colName)) grdBAS0001.SetBindControl(colName, ((XDatePicker)obj));
//						//						((XFindBox)obj).Enter += new System.EventHandler(this.SetGrdOCS0103_Enter);	
//						//						((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.hangmog_control_DataValidating);
//					}
					else if( obj.GetType().ToString().IndexOf("XInfoCombo" ) >= 0) 
					{
						colName = ((XInfoCombo)obj).Name.Substring(3).ToLower();

						//Binding
						if(grdBAS0001.CellInfos.Contains(colName)) grdBAS0001.SetBindControl(colName, ((XInfoCombo)obj));
						//						((XFindBox)obj).Enter += new System.EventHandler(this.SetGrdOCS0103_Enter);	
						//						((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.hangmog_control_DataValidating);
					}
					else if( obj.GetType().ToString().IndexOf("XDictComboBox" ) >= 0) 
					{
						colName = ((XDictComboBox)obj).Name.Substring(3).ToLower();

						//Binding
						if(grdBAS0001.CellInfos.Contains(colName)) grdBAS0001.SetBindControl(colName, ((XDictComboBox)obj));
						//						((XFindBox)obj).Enter += new System.EventHandler(this.SetGrdOCS0103_Enter);	
						//						((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.hangmog_control_DataValidating);
					}

				}
				catch(Exception ex)
				{
					//https://sofiamedix.atlassian.net/browse/MED-10610
					//MessageBox.Show(ex.Message);
				}

			}
			
			//grdBoheom.SetBindControl("from_jy_date", dtpFrom_Jy_Date);
	
		}
		#endregion

		
		#region ScreenOpen
        private string mHospCode = "";
		private void BAS0001U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            // 2015.06.22 AnhNV Added START
            this.mHospCode = UserInfo.HospCode;
            //this.mHospCode = "K02"; // test data
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                xHospBox.Visible = true;
                btnList.SetEnabled(FunctionType.Insert, false);
                btnList.SetEnabled(FunctionType.Update, false);
                btnList.SetEnabled(FunctionType.Delete, false);
            }
            else
            {
                xHospBox.Visible = false;
            }
            // 2015.06.22 AnhNV Added END

			SetBinding();

			All_Query();
		}
		#endregion

		#region Protect
		private void Control_Protect()
		{
			if (grdBAS0001.RowCount <= 0)
			{
				dtpStart_Date.Protect = true;
                txtYoyang_Giho.Protect = true;
                txtGigwanCode.Protect = true;
				return;
			}

			if (grdBAS0001.CurrentRowNumber < 0)
			{
				dtpStart_Date.Protect = true;
                txtYoyang_Giho.Protect = true;
                txtGigwanCode.Protect = true;
			}
			else
			{
				if (grdBAS0001.GetRowState(grdBAS0001.CurrentRowNumber) == DataRowState.Added)
				{	
					dtpStart_Date.Protect = false;
                    txtYoyang_Giho.Protect = false;
                    txtGigwanCode.Protect = false;
				}
				else
				{
					dtpStart_Date.Protect = true;
                    txtYoyang_Giho.Protect = true;
                    txtGigwanCode.Protect = true;
				}
			}

		}

		#endregion

		#region Validating

		private void Control_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			//string name = "";
			Control Ctl = (Control) sender;

			switch (Ctl.Name)
			{
				case "fbxZip_Code1":
					if (TypeCheck.IsNull(fbxZip_Code1.GetDataValue()) == true)
					{
						txtZip_Code2.SetEditValue("");
						txtZip_Code2.AcceptData();
					}
						
					break;

					// 우편번호2
				case "txtZip_Code2":
					if (TypeCheck.IsNull(e.DataValue.ToString()))
					{
						txtAddress.SetDataValue("");
						grdBAS0001.SetItemValue(grdBAS0001.CurrentRowNumber, "address", "");
						txtAddress1.SetEditValue("");
						txtAddress1.AcceptData();
						return;
					}

					if (TypeCheck.IsNull(fbxZip_Code1.GetDataValue()) == true)
					{
						return;
					}


                    // Connect to cloud
                    BAS0001U00ControlDataValidatingArgs vBAS0001U00ControlDataValidatingArgs = new BAS0001U00ControlDataValidatingArgs();
			        vBAS0001U00ControlDataValidatingArgs.ZipCode1 = fbxZip_Code1.GetDataValue().ToString();
			        vBAS0001U00ControlDataValidatingArgs.ZipCode2 = e.DataValue.ToString();
			        vBAS0001U00ControlDataValidatingArgs.CtlName = "txtZip_Code2";
                    BAS0001U00ControlDataValidatingResult result = CloudService.Instance.Submit<BAS0001U00ControlDataValidatingResult, BAS0001U00ControlDataValidatingArgs>(vBAS0001U00ControlDataValidatingArgs);

                    // TODO comment use connect cloud
					/*layComm.Reset();
                    layComm.QuerySQL = @"SELECT A.ZIP_NAME1 || A.ZIP_NAME2 || A.ZIP_NAME3
                                          FROM BAS0123 A
                                         WHERE A.ZIP_CODE = :f_zip_code1 || :f_zip_code2";

                    layComm.SetBindVarValue("f_zip_code1", fbxZip_Code1.GetDataValue().ToString());
                    layComm.SetBindVarValue("f_zip_code2", e.DataValue.ToString());

					layComm.LayoutItems.Clear();
					layComm.LayoutItems.Add("name");

					if(layComm.QueryLayout())*/
                    if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
					{
//						if (TypeCheck.IsNull( layComm.GetItemValue("name")))
                        if (TypeCheck.IsNull(result.LayCom))
						{
							mbxMsg = Resource.TEXT1;
							mbxCap = Resource.TEXT2;
							XMessageBox.Show(mbxMsg, mbxCap);

							e.Cancel = true;
							return;
						}
					}
					else
					{
						mbxMsg = Resource.TEXT1;
						mbxCap = Resource.TEXT2;
						XMessageBox.Show(mbxMsg, mbxCap);
						e.Cancel = true;
						return;
					}

//					grdBAS0001.SetItemValue(grdBAS0001.CurrentRowNumber, "address", layComm.GetItemValue("name").ToString());
//                    txtAddress.SetEditValue(layComm.GetItemValue("name").ToString());
                    grdBAS0001.SetItemValue(grdBAS0001.CurrentRowNumber, "address", result.LayCom);
                    txtAddress.SetEditValue(result.LayCom);
					txtAddress.AcceptData();

					PostCallHelper.PostCall(new PostMethod(PostFocus));
					
					break;
			}
		}

		private void PostFocus()
		{
			txtAddress1.Focus();
		}

		#endregion
		

		#region [    우편번호 관련    ]

		#region 우편번호 앞자리(클릭시 우편번호 검색창 Open)
		private void fbxZip_Code1_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			BAS0121Q00_Open("zipCode");
	
		}
		#endregion

		#region 주소로 찾기
		private void fbxDong_Name_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			BAS0121Q00_Open("SearchGubun");

		}
		#endregion

		#region 주소찾기 창 Open
		private void BAS0121Q00_Open(string aSearchGubun)
		{
			CommonItemCollection param = new CommonItemCollection();

			if (aSearchGubun == "zipCode")
			{
				param.Add("SearchGubun", aSearchGubun);
				param.Add("zip_code1", fbxZip_Code1.GetDataValue().ToString());
				param.Add("zip_code2", txtZip_Code2.GetDataValue().ToString());
			}
			else
			{
				param.Add("SearchGubun", aSearchGubun);
				param.Add("address", fbxDong_Name.GetDataValue().ToString());
			}

			XScreen.OpenScreenWithParam(this, "BASS", "BAS0123Q00", ScreenOpenStyle.ResponseFixed, param);
		}
		#endregion

		#endregion


		#region [    버튼 리스트 관련   ]

		#region 조회
		private void All_Query()
		{
			if (!this.grdBAS0001.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg, "", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1, MessageBoxIcon.Error);
				return;
			}

			Control_Protect();

		}
		#endregion

		#region 입력
		private void All_Insert()
		{
			for (int i = 0; i < grdBAS0001.RowCount; i++)
			{
				if (TypeCheck.IsNull( grdBAS0001.GetItemString(i, "start_date").ToString()) == true)
				{
					dtpStart_Date.Focus();
					return;
				}

				if (TypeCheck.IsNull( grdBAS0001.GetItemString(i, "yoyang_giho").ToString()) == true)
				{
					txtYoyang_Giho.Focus();
					return;
				}

				if (TypeCheck.IsNull( grdBAS0001.GetItemString(i, "yoyang_name").ToString()) == true)
				{
					txtYoyang_Name.Focus();
					return;
				}

				if (TypeCheck.IsNull( grdBAS0001.GetItemString(i, "tot_bed").ToString()) == true)
				{
					mskTot_Bed.Focus();
					return;
				}
			}

			int rowNum = grdBAS0001.InsertRow(-1);
			cboHosp_Jin_Gubun.SetEditValue("H");
            cboHosp_Jin_Gubun.AcceptData();
            grdBAS0001.SetItemValue(rowNum, "end_date", "9998/12/31");

            grdBAS0001.SetItemValue(rowNum, "vpn_yn", UserInfo.VpnYn?"Y":"N");
            grdBAS0001.SetItemValue(rowNum, "time_zone", UserInfo.TimeZone);


			//grdBAS0001.SetItemValue(grdBAS0001.CurrentRowNumber, "hosp_jin_gubun", "H");

			// Protect
			Control_Protect();

			dtpStart_Date.Focus();

		}
		#endregion

		#region 저장
		private void All_Save()
		{
			int row = 0;
			int delrow = 0;
			int rowcnt = 0;

			row = grdBAS0001.RowCount;
			delrow = grdBAS0001.DeletedRowCount;

			rowcnt = row + delrow;

			if (rowcnt <= 0)  return;


			for (int i = 0; i < grdBAS0001.RowCount; i++)
			{
				if (grdBAS0001.GetRowState(i) == DataRowState.Added || grdBAS0001.GetRowState(i) == DataRowState.Modified)
				{
					if (TypeCheck.IsNull( grdBAS0001.GetItemString(i, "start_date").ToString()) == true)
					{
						mbxMsg = Resource.TEXT3;
						mbxCap = Resource.TEXT4;
						XMessageBox.Show(mbxMsg, mbxCap);

						grdBAS0001.SetFocusToItem(i, "start_date");
						dtpStart_Date.Focus();
						return;
					}

					if (TypeCheck.IsNull( grdBAS0001.GetItemString(i, "yoyang_giho").ToString()) == true)
					{
						mbxMsg = Resource.TEXT5;
                        mbxCap = Resource.TEXT4;
						XMessageBox.Show(mbxMsg, mbxCap);

						grdBAS0001.SetFocusToItem(i, "start_date");
						txtYoyang_Giho.Focus();
						return;
					}

					if (TypeCheck.IsNull( grdBAS0001.GetItemString(i, "yoyang_name").ToString()) == true)
					{
                        mbxMsg = Resource.TEXT6;
                        mbxCap = Resource.TEXT4;
						XMessageBox.Show(mbxMsg, mbxCap);

						grdBAS0001.SetFocusToItem(i, "start_date");
						txtYoyang_Name.Focus();
						return;
					}

					if (TypeCheck.IsNull( grdBAS0001.GetItemString(i, "tot_bed").ToString()) == true)
					{
						mbxMsg = Resource.TEXT7;
                        mbxCap = Resource.TEXT4;
						XMessageBox.Show(mbxMsg, mbxCap);

						grdBAS0001.SetFocusToItem(i, "start_date");
						mskTot_Bed.Focus();
						return;
					}
				}
			}

            // Connect to cloud
		    UpdateResult updateResult = GrdBAS0001SaveLayout();
//			if (!this.grdBAS0001.SaveLayout())
            if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success || updateResult.Result == false)
			{
                this.mbxMsg = Resource.TEXT8;

                this.mbxMsg += "\r\n" + Service.ErrFullMsg;

                this.mbxCap = Resource.TEXT9;

                XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
			}

            this.mbxMsg = Resource.TEXT10;

            this.mbxCap = Resource.TEXT11;

            XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

			All_Query();
            
			
		}
		#endregion

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					All_Query();
					break;
				case FunctionType.Insert:
					e.IsBaseCall = false;
					All_Insert();
					break;
				case FunctionType.Update:
					e.IsBaseCall = false;
					All_Save();
					break;
			}
		
		}

		#endregion 


		#region Command 
		// Command
		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch ( command )
			{
					// 우편번호
				case "BAS0123Q00":
					fbxZip_Code1.SetEditValue(commandParam["zip_code1"]);
					fbxZip_Code1.AcceptData();
					txtZip_Code2.SetEditValue(commandParam["zip_code2"]);
					txtZip_Code2.AcceptData();

					break;
				default:
					break;
			}

			return base.Command (command, commandParam);
		}
		#endregion

		#region 그리드 rowfocusChanged
		private void grdBAS0001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            cbxBankAccGubun.SetDataValue(grdBAS0001.GetItemString(grdBAS0001.CurrentRowNumber, "bank_acc_type"));
         Control_Protect();
		}
		#endregion

		private void fbxDodobuHyeun_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 파인드 워커 셋팅
            // TODO comment use connect cloud
            /*this.fwkCommon.InputSQL = @"SELECT A.CODE
                                             , A.CODE_NAME
                                          FROM BAS0102 A
                                         WHERE A.HOSP_CODE    = :f_hosp_code 
                                           AND A.CODE_TYPE    = :f_code_type
                                           AND(A.CODE      LIKE :f_find1 || '%'
                                            OR A.CODE_NAME LIKE :f_find1 || '%' )
                                         ORDER BY A.CODE";*/

			this.fwkCommon.ColInfos.Clear();
			this.fwkCommon.ColInfos.Add("code", Resource.TEXT12, FindColType.String, 80, 0, true, FilterType.No);
			this.fwkCommon.ColInfos.Add("code_name", Resource.TEXT13, FindColType.String, 200, 0, true, FilterType.InitYes);
			this.fwkCommon.ColInfos["code"].ColAlign = HorizontalAlignment.Center;

            this.fwkCommon.ParamList = new List<string>(new String[] { "f_code_type", "f_find1" });
            this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkCommon.SetBindVarValue("f_code_type", "DODOBUHYEUN_NO");

		    this.fwkCommon.ExecuteQuery = ExecuteQueryFbxDodobuHyeun;
		}

		private void fbxDodobuHyeun_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue == "")
			{
				this.dbxDodobuhyeunName.SetDataValue("");
				this.grdBAS0001.SetItemValue(grdBAS0001.CurrentRowNumber, "dodobuhyeun_name", "");

				this.SetMsg("");

				return ;
			}

			string name = "";

			// 벨리데이션 셋팅
            // TODO comment use connect cloud
            /*this.layComm.QuerySQL = @"SELECT CODE_NAME
                                         , SORT_KEY
                                      FROM BAS0102
                                     WHERE HOSP_CODE = :f_hosp_code 
                                       AND CODE_TYPE = :f_code_type
                                       AND CODE      = :f_code";*/

			this.layComm.LayoutItems.Clear();
            this.layComm.LayoutItems.Add("code_name");

            this.layComm.ParamList = new List<string>(new String[] { "f_code_type", "f_code" });
		    this.layComm.ExecuteQuery = ExecuteQueryFbxDodobuHyeunDataValidating;

            this.layComm.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layComm.SetBindVarValue("f_code_type", "DODOBUHYEUN_NO");
            this.layComm.SetBindVarValue("f_code", e.DataValue);

			if (this.layComm.QueryLayout())
			{
				name = this.layComm.GetItemValue("code_name").ToString();

				if (name == "")
				{
                    this.mbxMsg = (Resource.TEXT14);

					this.SetMsg(this.mbxMsg, MsgType.Error);

					e.Cancel = true;
					return ;
				}
				else
				{
					this.dbxDodobuhyeunName.SetDataValue(name);
					this.grdBAS0001.SetItemValue(grdBAS0001.CurrentRowNumber, "dodobuhyeun_name", name);

					this.SetMsg("");
				}
			}
			else
			{
                this.mbxMsg = (Resource.TEXT14);

				this.SetMsg(this.mbxMsg, MsgType.Error);

				e.Cancel = true;

				return ;
			}

		}
        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0001U00 parent = null;

            public XSavePeformer(BAS0001U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_dup_check = "";

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                switch (callerId)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                                  FROM DUAL
                                                 WHERE EXISTS ( SELECT 'X'
                                                                  FROM BAS0001 A
                                                                 WHERE A.HOSP_CODE     = :f_hosp_code
                                                                   AND A.START_DATE    = :f_start_date
                                                                   AND A.YOYANG_GIHO   = :f_yoyang_giho   )";

                                t_dup_check = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_dup_check))
                                {
                                    if (t_dup_check.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_yoyang_giho"].VarValue + "」は既に登録されています。", Resource.TEXT4,MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                /* 기존의 데이터에 END_DATE를 새로운 데이터
                                   START_DATE - 1 로 셋팅한다 */
                                cmdText = @"UPDATE BAS0001 A
                                               SET A.UPD_ID      = :q_user_id
                                                 , A.UPD_DATE    = SYSDATE
                                                 , A.END_DATE    = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
                                             WHERE A.HOSP_CODE   = :f_hosp_code
                                               AND A.YOYANG_GIHO = :f_yoyang_giho
                                               AND A.END_DATE    = TO_DATE('9998/12/31', 'YYYY/MM/DD')
                                               AND TO_DATE(:f_start_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                { 
                                
                                }
                                    //return false;

                                cmdText = @"INSERT INTO BAS0001
                                                 ( SYS_DATE                 , SYS_ID                , UPD_DATE         ,UPD_ID    ,HOSP_CODE 
                                                 , START_DATE               , END_DATE              , YOYANG_GIHO
                                                 , YOYANG_NAME              , YOYANG_NAME2          , ZIP_CODE1
                                                 , ZIP_CODE2                , ZIP_CODE              , ADDRESS
                                                 , ADDRESS1                 , TEL                   , TEL1 
                                                 , FAX                      , TOT_BED               , HOMEPAGE
                                                 , EMAIL                    , HOSP_JIN_GUBUN        , DODOBUHYEUN_NO 
                                                 , JAEDAN_NAME              , SIMPLE_YOYANG_NAME    , BANK_NAME
                                                 , BANK_JIJUM               , BANK_NO               , BANK_ACC_NAME  
                                                 , ORCA_GIGWAN_CODE         )
                                            VALUES(SYSDATE                  , :q_user_id            , SYSDATE        , :q_user_id    , :f_hosp_code
                                                 , :f_start_date            , :f_end_date           , :f_yoyang_giho
                                                 , :f_yoyang_name           , :f_yoyang_name2       , :f_zip_code1
                                                 , :f_zip_code2             , :f_zip_code1 || :f_zip_code2 , :f_address
                                                 , :f_address1              , :f_tel                , :f_tel1
                                                 , :f_fax                   , :f_tot_bed            , :f_homepage
                                                 , :f_email                 , :f_hosp_jin_gubun     , :f_dodobuhyeun_no      
                                                 , :f_jaedan_name           , :f_simple_yoyang_name , :f_bank_name         
                                                 , :f_bank_jijum            , :f_bank_no            , :f_bank_acc_name      
                                                 , :f_gigwan_code)";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE BAS0001
                                               SET UPD_ID             = :q_user_id
                                                 , UPD_DATE           = SYSDATE
                                                 , YOYANG_NAME        = :f_yoyang_name
                                                 , YOYANG_NAME2       = :f_yoyang_name2
                                                 , END_DATE           = :f_end_date
                                                 , ZIP_CODE1          = :f_zip_code1
                                                 , ZIP_CODE2          = :f_zip_code2
                                                 , ZIP_CODE           = :f_zip_code1 || :f_zip_code2
                                                 , ADDRESS            = :f_address
                                                 , ADDRESS1           = :f_address1
                                                 , TEL                = :f_tel
                                                 , TEL1               = :f_tel1
                                                 , FAX                = :f_fax
                                                 , TOT_BED            = :f_tot_bed
                                                 , HOMEPAGE           = :f_homepage
                                                 , EMAIL              = :f_email
                                                 , HOSP_JIN_GUBUN     = :f_hosp_jin_gubun
                                                 , DODOBUHYEUN_NO     = :f_dodobuhyeun_no
                                                 , JAEDAN_NAME        = :f_jaedan_name       
                                                 , SIMPLE_YOYANG_NAME = :f_simple_yoyang_name
                                                 , BANK_NAME          = :f_bank_name         
                                                 , BANK_JIJUM         = :f_bank_jijum        
                                                 , BANK_NO            = :f_bank_no           
                                                 , BANK_ACC_NAME      = :f_bank_acc_name                         
                                             WHERE HOSP_CODE          = :f_hosp_code 
                                               AND START_DATE         = :f_start_date
                                               AND YOYANG_GIHO        = :f_yoyang_giho";

                                break;

                            case DataRowState.Deleted:
                                /* 이전놈 찾아서 돌려 놓는다. */
                                cmdText = @"UPDATE BAS0001
                                               SET END_DATE        = TO_DATE('9998/12/31', 'YYYY/MM/DD')
                                             WHERE HOSP_CODE       = :f_hosp_code 
                                               AND END_DATE        = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
                                               AND YOYANG_GIHO     = :f_yoyang_giho";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                { }
                                    //return false;

                                cmdText = @"DELETE FROM BAS0001
                                             WHERE HOSP_CODE       = :f_hosp_code 
                                               AND START_DATE      = :f_start_date
                                               AND YOYANG_GIHO     = :f_yoyang_giho";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdBAS0001_QueryStarting(object sender, CancelEventArgs e)
        {
            grdBAS0001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.grdBAS0001.RowCount > 0 && this.grdBAS0001.CurrentRowNumber > -1)
            {
                DataRow row = this.grdBAS0001.LayoutTable.Rows[this.grdBAS0001.CurrentRowNumber];

                //this.grdBAS0001.LayoutTable.ImportRow(row);
                this.grdBAS0001.InsertRow();

                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    this.grdBAS0001.SetItemValue(this.grdBAS0001.CurrentRowNumber, row.Table.Columns[i].ColumnName, row.ItemArray.GetValue(i).ToString());
                }
                this.grdBAS0001.SetItemValue(this.grdBAS0001.CurrentRowNumber, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                this.grdBAS0001.AcceptData();
                this.grdBAS0001.Refresh();

            }
        }

        #region Connect to cloud

        /// <summary>
        /// ExecuteQueryCboHospJinGubun
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private IList<object[]> ExecuteQueryCboHospJinGubun(BindVarCollection bc)
	    {
            // 2015.06.22 AnhNV updated
            //IList<object[]> ListObject = new List<object[]>();
            //CboHospJinGubunArgs args = new CboHospJinGubunArgs();
            //args.CodeType = "HOSP_JIN_GUBUN";
            //ComboResult result =
            //    CacheService.Instance.Get<CboHospJinGubunArgs, ComboResult>(
            //        Constants.CacheKeyCbo.CACHE_BAS_CBO_HOSP_JIN_GUBUN, args);
            //if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    List<ComboListItemInfo> listItemInfo = result.ComboItem;
            //    foreach (ComboListItemInfo info in listItemInfo)
            //    {
            //        ListObject.Add(new object[]
            //        {
            //            info.Code,
            //            info.CodeName
            //        });
            //    }
            //}
            //return ListObject;

            IList<object[]> lObj = new List<object[]>();

            BAS0001U00CboHospJinGubunArgs args = new BAS0001U00CboHospJinGubunArgs();
            args.HospCode = this.mHospCode;
            ComboResult res = CacheService.Instance.Get<BAS0001U00CboHospJinGubunArgs, ComboResult>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
	    }

        //https://sofiamedix.atlassian.net/browse/MED-15632
        //Load bank account type
        private IList<object[]> LoadbankAccType(BindVarCollection bc)
        { 
         IList<object[]> res = new List<object[]>();
            BAS0001U00GrdBAS0001Args vBAS0001U00GrdBAS0001Args = new BAS0001U00GrdBAS0001Args();
            vBAS0001U00GrdBAS0001Args.HospCode = UserInfo.HospCode;
            BAS0001U00GrdBAS0001Result result = CloudService.Instance.Submit<BAS0001U00GrdBAS0001Result, BAS0001U00GrdBAS0001Args>(vBAS0001U00GrdBAS0001Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.BankInfo)
                {
                    object[] objects = 
				    { 
					    item.Code, 
					    item.CodeName};
                    res.Add(objects);
                };
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdBAS0001
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryGrdBAS0001(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            BAS0001U00GrdBAS0001Args vBAS0001U00GrdBAS0001Args = new BAS0001U00GrdBAS0001Args();
            vBAS0001U00GrdBAS0001Args.HospCode = this.mHospCode;
            BAS0001U00GrdBAS0001Result result = CloudService.Instance.Submit<BAS0001U00GrdBAS0001Result, BAS0001U00GrdBAS0001Args>(vBAS0001U00GrdBAS0001Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0001U00GrdBAS0001Info item in result.ItemInfo)
                {
                    object[] objects = 
				    { 
					    item.StartDate, 
					    item.EndDate, 
					    item.YoyangGiho, 
					    item.YoyangName, 
					    item.YoyangName2, 
					    item.ZipCode1, 
					    item.ZipCode2, 
					    item.ZipCode, 
					    item.Address, 
					    item.Address1, 
					    item.Tel, 
					    item.Tel1, 
					    item.Fax, 
					    item.TotBed, 
					    item.Homepage, 
					    item.Email, 
					    item.HospJinGubun, 
					    item.DodobuhyeunNo, 
					    item.DodobuhyeunName, 
					    item.JaedanName, 
					    item.SimpleYoyangName, 
					    item.BankName, 
					    item.BankJijum, 
					    item.BankNo, 
					    item.BankAccName, 
					    item.PresidentName, 
					    item.OrcaGigwanCode,
                        item.AcctRefId,
					    //item.DataRowState,
                        item.VpnYn,
                        item.TimeZone,
                        item.BankAccType
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryFbxDodobuHyeun
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryFbxDodobuHyeun(BindVarCollection bc)
        {
            //IList<object[]> res = new List<object[]>();
            //BAS0001U00FbxDodobuHyeunFindClickArgs vBAS0001U00FbxDodobuHyeunFindClickArgs = new BAS0001U00FbxDodobuHyeunFindClickArgs();
            //vBAS0001U00FbxDodobuHyeunFindClickArgs.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            //vBAS0001U00FbxDodobuHyeunFindClickArgs.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            //BAS0001U00FbxDodobuHyeunFindClickResult result = CloudService.Instance.Submit<BAS0001U00FbxDodobuHyeunFindClickResult, BAS0001U00FbxDodobuHyeunFindClickArgs>(vBAS0001U00FbxDodobuHyeunFindClickArgs);
            //if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    foreach (ComboListItemInfo item in result.FbxDodobuHyeunFindClick)
            //    {
            //        object[] objects =
            //        {
            //            item.Code,
            //            item.CodeName
            //        };
            //        res.Add(objects);
            //    }
            //}
            //return res;

            IList<object[]> lObj = new List<object[]>();

            BAS0001U00FbxDodobuHyeunFindClickArgs args = new BAS0001U00FbxDodobuHyeunFindClickArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            args.HospCode = this.mHospCode;
            ComboResult res = CloudService.Instance.Submit<ComboResult, BAS0001U00FbxDodobuHyeunFindClickArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }

        /// <summary>
        /// ExecuteQueryFbxDodobuHyeunDataValidating
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryFbxDodobuHyeunDataValidating(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0001U00FbxDodobuHyeunDataValidatingArgs vBAS0001U00FbxDodobuHyeunDataValidatingArgs = new BAS0001U00FbxDodobuHyeunDataValidatingArgs();
            vBAS0001U00FbxDodobuHyeunDataValidatingArgs.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            vBAS0001U00FbxDodobuHyeunDataValidatingArgs.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            vBAS0001U00FbxDodobuHyeunDataValidatingArgs.HospCode = this.mHospCode;
            BAS0001U00FbxDodobuHyeunDataValidatingResult result = CloudService.Instance.Submit<BAS0001U00FbxDodobuHyeunDataValidatingResult, BAS0001U00FbxDodobuHyeunDataValidatingArgs>(vBAS0001U00FbxDodobuHyeunDataValidatingArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0001U00FbxDodobuHyeunDataValidatingInfo item in result.FbxDodobHyeunValidating)
                {
                    object[] objects =
                    {
                        item.CodeName,
                        item.SortKey
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

	    private UpdateResult GrdBAS0001SaveLayout()
	    {
	        BAS0001U00ExecuteArgs args = new BAS0001U00ExecuteArgs();
	        args.ItemInfo = CreateListGridBAS0001();
	        args.UserId = UserInfo.UserID;
            args.HospCode = this.mHospCode;

	        return CloudService.Instance.Submit<UpdateResult, BAS0001U00ExecuteArgs>(args);
	    }

        /// <summary>
        /// CreateListGridBAS0001
        /// </summary>
        /// <returns></returns>
	    private List<BAS0001U00GrdBAS0001Info> CreateListGridBAS0001()
	    {
	        List<BAS0001U00GrdBAS0001Info> lstGrdBas0001Infos = new List<BAS0001U00GrdBAS0001Info>();
	        for (int i = 0; i < grdBAS0001.RowCount; i ++)
	        {
	            if (grdBAS0001.GetRowState(i) == DataRowState.Added || grdBAS0001.GetRowState(i) == DataRowState.Modified)
	            {
	                BAS0001U00GrdBAS0001Info bas0001Info = new BAS0001U00GrdBAS0001Info();
	                bas0001Info.StartDate = grdBAS0001.GetItemString(i, "start_date");
	                bas0001Info.EndDate = grdBAS0001.GetItemString(i, "end_date");
	                bas0001Info.YoyangGiho = grdBAS0001.GetItemString(i, "yoyang_giho");
	                bas0001Info.YoyangName = grdBAS0001.GetItemString(i, "yoyang_name");
	                bas0001Info.YoyangName2 = grdBAS0001.GetItemString(i, "yoyang_name2");
	                bas0001Info.ZipCode1 = grdBAS0001.GetItemString(i, "zip_code1");
	                bas0001Info.ZipCode2 = grdBAS0001.GetItemString(i, "zip_code2");
	                bas0001Info.ZipCode = grdBAS0001.GetItemString(i, "zip_code");
	                bas0001Info.Address = grdBAS0001.GetItemString(i, "address");
	                bas0001Info.Address1 = grdBAS0001.GetItemString(i, "address1");
	                bas0001Info.Tel = grdBAS0001.GetItemString(i, "tel");
	                bas0001Info.Tel1 = grdBAS0001.GetItemString(i, "tel1");
	                bas0001Info.Fax = grdBAS0001.GetItemString(i, "fax");
	                bas0001Info.TotBed = grdBAS0001.GetItemString(i, "tot_bed");
	                bas0001Info.Homepage = grdBAS0001.GetItemString(i, "homepage");
	                bas0001Info.Email = grdBAS0001.GetItemString(i, "email");
	                bas0001Info.HospJinGubun = grdBAS0001.GetItemString(i, "hosp_jin_gubun");
	                bas0001Info.DodobuhyeunNo = grdBAS0001.GetItemString(i, "dodobuhyeun_no");
	                bas0001Info.DodobuhyeunName = grdBAS0001.GetItemString(i, "dodobuhyeun_name");
	                bas0001Info.JaedanName = grdBAS0001.GetItemString(i, "jaedan_name");
	                bas0001Info.SimpleYoyangName = grdBAS0001.GetItemString(i, "simple_yoyang_name");
	                bas0001Info.BankName = grdBAS0001.GetItemString(i, "bank_name");
                    bas0001Info.BankJijum = grdBAS0001.GetItemString(i, "bank_jijun");
	                bas0001Info.BankNo = grdBAS0001.GetItemString(i, "bank_no");
	                bas0001Info.BankAccName = grdBAS0001.GetItemString(i, "bank_acc_name");
	                bas0001Info.PresidentName = grdBAS0001.GetItemString(i, "president_name");
                    bas0001Info.OrcaGigwanCode = grdBAS0001.GetItemString(i, "gigwan_code");
	                bas0001Info.DataRowState = grdBAS0001.GetRowState(i).ToString();
                    bas0001Info.AcctRefId = grdBAS0001.GetItemString(i, "acct_ref_id");

                    bas0001Info.VpnYn = grdBAS0001.GetItemString(i, "vpn_yn");
                    bas0001Info.TimeZone = grdBAS0001.GetItemString(i, "time_zone");
                    //bas0001Info.BankAccType = grdBAS0001.GetItemString(i, "bank_acc_type");
                    bas0001Info.BankAccType = cbxBankAccGubun.GetDataValue();

                    lstGrdBas0001Infos.Add(bas0001Info);
	            }
	        }

	        if (grdBAS0001.DeletedRowTable != null && grdBAS0001.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdBAS0001.DeletedRowTable.Rows)
	            {
                    BAS0001U00GrdBAS0001Info bas0001Info = new BAS0001U00GrdBAS0001Info();

                    bas0001Info.StartDate = row["start_date"].ToString();
                    bas0001Info.EndDate = row["end_date"].ToString();
                    bas0001Info.YoyangGiho = row["yoyang_giho"].ToString();
                    bas0001Info.YoyangName = row["yoyang_name"].ToString();
                    bas0001Info.YoyangName2 = row["yoyang_name2"].ToString();
                    bas0001Info.ZipCode1 = row["zip_code1"].ToString();
                    bas0001Info.ZipCode2 = row["zip_code2"].ToString();
                    bas0001Info.ZipCode = row["zip_code"].ToString();
                    bas0001Info.Address = row["address"].ToString();
                    bas0001Info.Address1 = row["address1"].ToString();
                    bas0001Info.Tel = row["tel"].ToString();
                    bas0001Info.Tel1 = row["tel1"].ToString();
                    bas0001Info.Fax = row["fax"].ToString();
                    bas0001Info.TotBed = row["tot_bed"].ToString();
                    bas0001Info.Homepage = row["homepage"].ToString();
                    bas0001Info.Email = row["email"].ToString();
                    bas0001Info.HospJinGubun = row["hosp_jin_gubun"].ToString();
                    bas0001Info.DodobuhyeunNo = row["dodobuhyeun_no"].ToString();
                    bas0001Info.DodobuhyeunName = row["dodobuhyeun_name"].ToString();
                    bas0001Info.JaedanName = row["jaedan_name"].ToString();
                    bas0001Info.SimpleYoyangName = row["simple_yoyang_name"].ToString();
                    bas0001Info.BankName = row["bank_name"].ToString();
                    bas0001Info.BankJijum = row["bank_jijun"].ToString();
                    bas0001Info.BankNo = row["bank_no"].ToString();
                    bas0001Info.BankAccName = row["bank_acc_name"].ToString();
                    bas0001Info.PresidentName = row["president_name"].ToString();
                    bas0001Info.OrcaGigwanCode = row["gigwan_code"].ToString();

	                bas0001Info.DataRowState = DataRowState.Deleted.ToString();
                    bas0001Info.AcctRefId = row["acct_ref_id"].ToString();
                    lstGrdBas0001Infos.Add(bas0001Info);
	            }
	        }
	        return lstGrdBas0001Infos;
	    } 

        #endregion

        private void xHospBox_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = e.DataValue;
                this.grdBAS0001.QueryLayout(true);

                if (e.DataValue == "NTA" && UserInfo.AdminType == AdminType.SuperAdmin)
                {
                    btnList.SetEnabled(FunctionType.Insert, true);
                    btnList.SetEnabled(FunctionType.Update, true);
                    btnList.SetEnabled(FunctionType.Delete, true);
                }
                else
                {
                    btnList.SetEnabled(FunctionType.Insert, false);
                    btnList.SetEnabled(FunctionType.Update, false);
                    btnList.SetEnabled(FunctionType.Delete, false);
                }
            }
        }

        private void xHospBox_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox.HospCode;
            this.grdBAS0001.QueryLayout(true);

            if (xHospBox.HospCode == "NTA" && UserInfo.AdminType == AdminType.SuperAdmin)
            {
                btnList.SetEnabled(FunctionType.Insert, true);
                btnList.SetEnabled(FunctionType.Update, true);
                btnList.SetEnabled(FunctionType.Delete, true);
            }
            else
            {
                btnList.SetEnabled(FunctionType.Insert, false);
                btnList.SetEnabled(FunctionType.Update, false);
                btnList.SetEnabled(FunctionType.Delete, false);
            }
        }

        private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Delete:
                    if (this.grdBAS0001.RowCount == 0)
                    {
                        XMessageBox.Show(Resource.TEXT15, Resource.TEXT4, MessageBoxIcon.Stop);
                        this.btnList.PerformClick(FunctionType.Query);
                    }
                    break;
                
            }
        }
    }
}

