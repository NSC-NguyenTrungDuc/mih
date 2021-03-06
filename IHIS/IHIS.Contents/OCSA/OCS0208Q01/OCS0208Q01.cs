#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0208Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0208Q01 : IHIS.Framework.XScreen
	{
		#region [DynService Control]
		private IHIS.Framework.MultiLayout    layoutCombo = new MultiLayout();
		#endregion

		#region [Instance Variable]
		//Control
		private Hashtable htControl = new Hashtable();
		//Doctor
		string mDoctor       = "";
		string mBongYongCode = "";
		string mOrder_remark = "";
		string mHangmog_code = "";
		//Message처리
		string mbxMsg = "", mbxCap = "";

        string mGubun = "0";

		//선택구분
		private bool AllSelect = true;

        // Hospital Code
        string mHospCode = EnvironInfo.HospCode;
		#endregion

		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGrid grdOCS0208;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XTabControl xTabControl1;
		private IHIS.Framework.MultiLayout dloSelectValue;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XRadioButton rbtBase;
		private IHIS.Framework.XRadioButton rbtUser;
		private IHIS.Framework.XPanel panUser;
		private IHIS.Framework.XPanel panBase;
		private IHIS.Framework.XPanel pnl1;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XDisplayBox dbxBogyong;
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XGroupBox gbx2;
		private IHIS.Framework.XFlatRadioButton rb3;
		private IHIS.Framework.XFlatRadioButton rb2;
		private IHIS.Framework.XFlatRadioButton rb1;
		private System.Windows.Forms.ToolTip toolTip1;
		private IHIS.Framework.XFlatRadioButton rb4;
		private IHIS.Framework.XPanel pnlDirect;
		private IHIS.Framework.XButton btnAct_dq;
		private IHIS.Framework.XButton btnAct_time;
		private IHIS.Framework.XButton btnCnt_perday;
		private IHIS.Framework.XButton btnCnt_perhour;
		private IHIS.Framework.XCheckBox chkAct_dq4;
		private IHIS.Framework.XCheckBox chkAct_dq3;
		private IHIS.Framework.XCheckBox chkAct_dq1;
		private IHIS.Framework.XCheckBox chkAct_dq2;
		private System.Windows.Forms.VScrollBar vsbAct_time;
		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XFlatLabel xFlatLabel2;
		private IHIS.Framework.XEditMask emkAct_time;
		private IHIS.Framework.XDisplayBox xDisplayBox4;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XFlatLabel xFlatLabel5;
		private IHIS.Framework.XButton btnFreCnt_perday;
		private IHIS.Framework.XFlatLabel xFlatLabel3;
		private IHIS.Framework.XButton btnNalsu;
		private IHIS.Framework.XFlatLabel xFlatLabel6;
		private IHIS.Framework.XFlatLabel xFlatLabel4;
		private IHIS.Framework.XGrid grdDRG0121;
		private IHIS.Framework.XComboBox cboCnt_perday;
		private IHIS.Framework.XComboBox cboNalsu;
		private IHIS.Framework.XComboBox cboCnt_perhour;
		private IHIS.Framework.XButton btnProcessRemark;
		private IHIS.Framework.XCheckBox chkUseYn;
		private IHIS.Framework.XTextBox txtOrder_remark;
		private IHIS.Framework.XGroupBox gbx3;
		private IHIS.Framework.XFlatRadioButton rbDV6;
		private IHIS.Framework.XFlatRadioButton rbDV4;
		private IHIS.Framework.XFlatRadioButton rbDV3;
		private IHIS.Framework.XFlatRadioButton rbDV;
		private IHIS.Framework.XFlatRadioButton rbDV99;
		private IHIS.Framework.XFlatRadioButton rbDV2;
		private IHIS.Framework.XFlatRadioButton rbDV1;
		private IHIS.Framework.XEditGrid grdChiryoGubun;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGrid grdDrg0120;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XPanel xPanel7;
		private IHIS.Framework.XPanel xPanel8;
		private IHIS.Framework.XLabel lblSelectAll;
		private IHIS.Framework.XFlatLabel xFlatLabel7;
        private IHIS.Framework.XFlatLabel xFlatLabel8;
        private XEditGridCell xEditGridCell13;
        private XEditGrid grdBaseBogyongCode;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
		private System.ComponentModel.IContainer components;

	    private List<ComboListItemInfo> comboListItem;

		public OCS0208Q01()
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


		
		[Browsable(false), DataBindable]
		public string use_yn
		{
			get
			{
				if (chkUseYn.Checked)
					return "Y";
				
				return "N";
			}
		}

		[Browsable(false), DataBindable]
		public string hangmog_code
		{
			get
			{
				return mHangmog_code;
			}
		}

		[Browsable(false), DataBindable]
		public string bogyong_gubun
		{
			get 
			{
				foreach (Control con in gbx3.Controls) 
				{
					if (con is XFlatRadioButton)  
					{
						if ( ((XFlatRadioButton)con).Checked) 
							return ((XFlatRadioButton)con).CheckedValue.ToString();
					}
				}
				return "";
			}
		}


		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0208Q01));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xTabControl1 = new IHIS.Framework.XTabControl();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdDRG0121 = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.btnProcess = new IHIS.Framework.XButton();
            this.btnProcessRemark = new IHIS.Framework.XButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.lblSelectAll = new IHIS.Framework.XLabel();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.pnlDirect = new IHIS.Framework.XPanel();
            this.btnAct_dq = new IHIS.Framework.XButton();
            this.xFlatLabel8 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel7 = new IHIS.Framework.XFlatLabel();
            this.txtOrder_remark = new IHIS.Framework.XTextBox();
            this.cboCnt_perhour = new IHIS.Framework.XComboBox();
            this.cboNalsu = new IHIS.Framework.XComboBox();
            this.cboCnt_perday = new IHIS.Framework.XComboBox();
            this.xFlatLabel4 = new IHIS.Framework.XFlatLabel();
            this.btnNalsu = new IHIS.Framework.XButton();
            this.xFlatLabel6 = new IHIS.Framework.XFlatLabel();
            this.btnFreCnt_perday = new IHIS.Framework.XButton();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.btnAct_time = new IHIS.Framework.XButton();
            this.btnCnt_perday = new IHIS.Framework.XButton();
            this.btnCnt_perhour = new IHIS.Framework.XButton();
            this.chkAct_dq4 = new IHIS.Framework.XCheckBox();
            this.chkAct_dq3 = new IHIS.Framework.XCheckBox();
            this.chkAct_dq1 = new IHIS.Framework.XCheckBox();
            this.chkAct_dq2 = new IHIS.Framework.XCheckBox();
            this.vsbAct_time = new System.Windows.Forms.VScrollBar();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.emkAct_time = new IHIS.Framework.XEditMask();
            this.xDisplayBox4 = new IHIS.Framework.XDisplayBox();
            this.xFlatLabel5 = new IHIS.Framework.XFlatLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.panUser = new IHIS.Framework.XPanel();
            this.grdOCS0208 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.panBase = new IHIS.Framework.XPanel();
            this.grdBaseBogyongCode = new IHIS.Framework.XEditGrid();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.pnl1 = new IHIS.Framework.XPanel();
            this.grdDrg0120 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.dbxBogyong = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.grdChiryoGubun = new IHIS.Framework.XEditGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.gbx3 = new IHIS.Framework.XGroupBox();
            this.rbDV6 = new IHIS.Framework.XFlatRadioButton();
            this.rbDV4 = new IHIS.Framework.XFlatRadioButton();
            this.rbDV3 = new IHIS.Framework.XFlatRadioButton();
            this.rbDV = new IHIS.Framework.XFlatRadioButton();
            this.rbDV99 = new IHIS.Framework.XFlatRadioButton();
            this.rbDV2 = new IHIS.Framework.XFlatRadioButton();
            this.rbDV1 = new IHIS.Framework.XFlatRadioButton();
            this.gbx2 = new IHIS.Framework.XGroupBox();
            this.rb4 = new IHIS.Framework.XFlatRadioButton();
            this.rb3 = new IHIS.Framework.XFlatRadioButton();
            this.rb2 = new IHIS.Framework.XFlatRadioButton();
            this.rb1 = new IHIS.Framework.XFlatRadioButton();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.chkUseYn = new IHIS.Framework.XCheckBox();
            this.rbtBase = new IHIS.Framework.XRadioButton();
            this.rbtUser = new IHIS.Framework.XRadioButton();
            this.dloSelectValue = new IHIS.Framework.MultiLayout();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDRG0121)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel8.SuspendLayout();
            this.xPanel7.SuspendLayout();
            this.pnlDirect.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.panUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0208)).BeginInit();
            this.panBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaseBogyongCode)).BeginInit();
            this.pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChiryoGubun)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.gbx3.SuspendLayout();
            this.gbx2.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.xTabControl1);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Controls.Add(this.grdDRG0121);
            this.xPanel2.Controls.Add(this.btnProcess);
            this.xPanel2.Controls.Add(this.btnProcessRemark);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            this.toolTip1.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // xTabControl1
            // 
            this.xTabControl1.AccessibleDescription = null;
            this.xTabControl1.AccessibleName = null;
            resources.ApplyResources(this.xTabControl1, "xTabControl1");
            this.xTabControl1.BackgroundImage = null;
            this.xTabControl1.Font = null;
            this.xTabControl1.IDEPixelArea = true;
            this.xTabControl1.IDEPixelBorder = false;
            this.xTabControl1.Name = "xTabControl1";
            this.toolTip1.SetToolTip(this.xTabControl1, resources.GetString("xTabControl1.ToolTip"));
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.toolTip1.SetToolTip(this.xButtonList1, resources.GetString("xButtonList1.ToolTip"));
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdDRG0121
            // 
            resources.ApplyResources(this.grdDRG0121, "grdDRG0121");
            this.grdDRG0121.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2});
            this.grdDRG0121.ColHeaderVisible = false;
            this.grdDRG0121.ColPerLine = 1;
            this.grdDRG0121.Cols = 1;
            this.grdDRG0121.ExecuteQuery = null;
            this.grdDRG0121.FixedRows = 1;
            this.grdDRG0121.HeaderHeights.Add(0);
            this.grdDRG0121.Name = "grdDRG0121";
            this.grdDRG0121.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDRG0121.ParamList")));
            this.grdDRG0121.QuerySQL = "SELECT A.CODE    ,\r\n       A.COMMENTS\r\n  FROM DRG0121 A\r\n WHERE HOSP_CODE = FN_AD" +
                "M_LOAD_HOSP_CODE()\r\n ORDER BY A.CODE";
            this.grdDRG0121.Rows = 2;
            this.toolTip1.SetToolTip(this.grdDRG0121, resources.GetString("grdDRG0121.ToolTip"));
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "code";
            this.xGridCell1.Col = -1;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell2.CellName = "comments";
            this.xGridCell2.CellWidth = 276;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // btnProcess
            // 
            this.btnProcess.AccessibleDescription = null;
            this.btnProcess.AccessibleName = null;
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.BackgroundImage = null;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip1.SetToolTip(this.btnProcess, resources.GetString("btnProcess.ToolTip"));
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcessRemark
            // 
            this.btnProcessRemark.AccessibleDescription = null;
            this.btnProcessRemark.AccessibleName = null;
            resources.ApplyResources(this.btnProcessRemark, "btnProcessRemark");
            this.btnProcessRemark.BackgroundImage = null;
            this.btnProcessRemark.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessRemark.Image")));
            this.btnProcessRemark.Name = "btnProcessRemark";
            this.btnProcessRemark.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip1.SetToolTip(this.btnProcessRemark, resources.GetString("btnProcessRemark.ToolTip"));
            this.btnProcessRemark.Click += new System.EventHandler(this.btnProcessRemark_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.xPanel8);
            this.xPanel3.Controls.Add(this.xPanel7);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Controls.Add(this.xPanel1);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            this.toolTip1.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
            // 
            // xPanel8
            // 
            this.xPanel8.AccessibleDescription = null;
            this.xPanel8.AccessibleName = null;
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.BackgroundImage = null;
            this.xPanel8.Controls.Add(this.lblSelectAll);
            this.xPanel8.Font = null;
            this.xPanel8.Name = "xPanel8";
            this.toolTip1.SetToolTip(this.xPanel8, resources.GetString("xPanel8.ToolTip"));
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.AccessibleDescription = null;
            this.lblSelectAll.AccessibleName = null;
            resources.ApplyResources(this.lblSelectAll, "lblSelectAll");
            this.lblSelectAll.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectAll.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectAll.ImageList = this.ImageList;
            this.lblSelectAll.Name = "lblSelectAll";
            this.toolTip1.SetToolTip(this.lblSelectAll, resources.GetString("lblSelectAll.ToolTip"));
            // 
            // xPanel7
            // 
            this.xPanel7.AccessibleDescription = null;
            this.xPanel7.AccessibleName = null;
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.BackgroundImage = null;
            this.xPanel7.Controls.Add(this.pnlDirect);
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Font = null;
            this.xPanel7.Name = "xPanel7";
            this.toolTip1.SetToolTip(this.xPanel7, resources.GetString("xPanel7.ToolTip"));
            // 
            // pnlDirect
            // 
            this.pnlDirect.AccessibleDescription = null;
            this.pnlDirect.AccessibleName = null;
            resources.ApplyResources(this.pnlDirect, "pnlDirect");
            this.pnlDirect.BackgroundImage = null;
            this.pnlDirect.Controls.Add(this.btnAct_dq);
            this.pnlDirect.Controls.Add(this.xFlatLabel8);
            this.pnlDirect.Controls.Add(this.xFlatLabel7);
            this.pnlDirect.Controls.Add(this.txtOrder_remark);
            this.pnlDirect.Controls.Add(this.cboCnt_perhour);
            this.pnlDirect.Controls.Add(this.cboNalsu);
            this.pnlDirect.Controls.Add(this.cboCnt_perday);
            this.pnlDirect.Controls.Add(this.xFlatLabel4);
            this.pnlDirect.Controls.Add(this.btnNalsu);
            this.pnlDirect.Controls.Add(this.xFlatLabel6);
            this.pnlDirect.Controls.Add(this.btnFreCnt_perday);
            this.pnlDirect.Controls.Add(this.xFlatLabel3);
            this.pnlDirect.Controls.Add(this.btnAct_time);
            this.pnlDirect.Controls.Add(this.btnCnt_perday);
            this.pnlDirect.Controls.Add(this.btnCnt_perhour);
            this.pnlDirect.Controls.Add(this.chkAct_dq4);
            this.pnlDirect.Controls.Add(this.chkAct_dq3);
            this.pnlDirect.Controls.Add(this.chkAct_dq1);
            this.pnlDirect.Controls.Add(this.chkAct_dq2);
            this.pnlDirect.Controls.Add(this.vsbAct_time);
            this.pnlDirect.Controls.Add(this.xFlatLabel1);
            this.pnlDirect.Controls.Add(this.xFlatLabel2);
            this.pnlDirect.Controls.Add(this.emkAct_time);
            this.pnlDirect.Controls.Add(this.xDisplayBox4);
            this.pnlDirect.Controls.Add(this.xFlatLabel5);
            this.pnlDirect.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlDirect.Font = null;
            this.pnlDirect.Name = "pnlDirect";
            this.toolTip1.SetToolTip(this.pnlDirect, resources.GetString("pnlDirect.ToolTip"));
            // 
            // btnAct_dq
            // 
            this.btnAct_dq.AccessibleDescription = null;
            this.btnAct_dq.AccessibleName = null;
            resources.ApplyResources(this.btnAct_dq, "btnAct_dq");
            this.btnAct_dq.BackgroundImage = null;
            this.btnAct_dq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAct_dq.Image = ((System.Drawing.Image)(resources.GetObject("btnAct_dq.Image")));
            this.btnAct_dq.Name = "btnAct_dq";
            this.toolTip1.SetToolTip(this.btnAct_dq, resources.GetString("btnAct_dq.ToolTip"));
            // 
            // xFlatLabel8
            // 
            this.xFlatLabel8.AccessibleDescription = null;
            this.xFlatLabel8.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel8, "xFlatLabel8");
            this.xFlatLabel8.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel8.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xFlatLabel8.Name = "xFlatLabel8";
            this.toolTip1.SetToolTip(this.xFlatLabel8, resources.GetString("xFlatLabel8.ToolTip"));
            // 
            // xFlatLabel7
            // 
            this.xFlatLabel7.AccessibleDescription = null;
            this.xFlatLabel7.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel7, "xFlatLabel7");
            this.xFlatLabel7.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel7.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xFlatLabel7.Name = "xFlatLabel7";
            this.toolTip1.SetToolTip(this.xFlatLabel7, resources.GetString("xFlatLabel7.ToolTip"));
            // 
            // txtOrder_remark
            // 
            this.txtOrder_remark.AccessibleDescription = null;
            this.txtOrder_remark.AccessibleName = null;
            this.txtOrder_remark.AllowDrop = true;
            resources.ApplyResources(this.txtOrder_remark, "txtOrder_remark");
            this.txtOrder_remark.ApplyByteLimit = true;
            this.txtOrder_remark.BackgroundImage = null;
            this.txtOrder_remark.Name = "txtOrder_remark";
            this.toolTip1.SetToolTip(this.txtOrder_remark, resources.GetString("txtOrder_remark.ToolTip"));
            // 
            // cboCnt_perhour
            // 
            this.cboCnt_perhour.AccessibleDescription = null;
            this.cboCnt_perhour.AccessibleName = null;
            resources.ApplyResources(this.cboCnt_perhour, "cboCnt_perhour");
            this.cboCnt_perhour.BackgroundImage = null;
            this.cboCnt_perhour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboCnt_perhour.Name = "cboCnt_perhour";
            this.toolTip1.SetToolTip(this.cboCnt_perhour, resources.GetString("cboCnt_perhour.ToolTip"));
            this.cboCnt_perhour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBoNum_KeyPress);
            // 
            // cboNalsu
            // 
            this.cboNalsu.AccessibleDescription = null;
            this.cboNalsu.AccessibleName = null;
            resources.ApplyResources(this.cboNalsu, "cboNalsu");
            this.cboNalsu.BackgroundImage = null;
            this.cboNalsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboNalsu.Name = "cboNalsu";
            this.toolTip1.SetToolTip(this.cboNalsu, resources.GetString("cboNalsu.ToolTip"));
            this.cboNalsu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBoNum_KeyPress);
            // 
            // cboCnt_perday
            // 
            this.cboCnt_perday.AccessibleDescription = null;
            this.cboCnt_perday.AccessibleName = null;
            resources.ApplyResources(this.cboCnt_perday, "cboCnt_perday");
            this.cboCnt_perday.BackgroundImage = null;
            this.cboCnt_perday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboCnt_perday.Name = "cboCnt_perday";
            this.toolTip1.SetToolTip(this.cboCnt_perday, resources.GetString("cboCnt_perday.ToolTip"));
            this.cboCnt_perday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBoNum_KeyPress);
            // 
            // xFlatLabel4
            // 
            this.xFlatLabel4.AccessibleDescription = null;
            this.xFlatLabel4.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel4, "xFlatLabel4");
            this.xFlatLabel4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel4.Name = "xFlatLabel4";
            this.toolTip1.SetToolTip(this.xFlatLabel4, resources.GetString("xFlatLabel4.ToolTip"));
            // 
            // btnNalsu
            // 
            this.btnNalsu.AccessibleDescription = null;
            this.btnNalsu.AccessibleName = null;
            resources.ApplyResources(this.btnNalsu, "btnNalsu");
            this.btnNalsu.BackgroundImage = null;
            this.btnNalsu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNalsu.Image = ((System.Drawing.Image)(resources.GetObject("btnNalsu.Image")));
            this.btnNalsu.Name = "btnNalsu";
            this.toolTip1.SetToolTip(this.btnNalsu, resources.GetString("btnNalsu.ToolTip"));
            // 
            // xFlatLabel6
            // 
            this.xFlatLabel6.AccessibleDescription = null;
            this.xFlatLabel6.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel6, "xFlatLabel6");
            this.xFlatLabel6.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel6.Name = "xFlatLabel6";
            this.toolTip1.SetToolTip(this.xFlatLabel6, resources.GetString("xFlatLabel6.ToolTip"));
            // 
            // btnFreCnt_perday
            // 
            this.btnFreCnt_perday.AccessibleDescription = null;
            this.btnFreCnt_perday.AccessibleName = null;
            resources.ApplyResources(this.btnFreCnt_perday, "btnFreCnt_perday");
            this.btnFreCnt_perday.BackgroundImage = null;
            this.btnFreCnt_perday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFreCnt_perday.Image = ((System.Drawing.Image)(resources.GetObject("btnFreCnt_perday.Image")));
            this.btnFreCnt_perday.Name = "btnFreCnt_perday";
            this.toolTip1.SetToolTip(this.btnFreCnt_perday, resources.GetString("btnFreCnt_perday.ToolTip"));
            // 
            // xFlatLabel3
            // 
            this.xFlatLabel3.AccessibleDescription = null;
            this.xFlatLabel3.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel3.Name = "xFlatLabel3";
            this.toolTip1.SetToolTip(this.xFlatLabel3, resources.GetString("xFlatLabel3.ToolTip"));
            // 
            // btnAct_time
            // 
            this.btnAct_time.AccessibleDescription = null;
            this.btnAct_time.AccessibleName = null;
            resources.ApplyResources(this.btnAct_time, "btnAct_time");
            this.btnAct_time.BackgroundImage = null;
            this.btnAct_time.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAct_time.Image = ((System.Drawing.Image)(resources.GetObject("btnAct_time.Image")));
            this.btnAct_time.Name = "btnAct_time";
            this.toolTip1.SetToolTip(this.btnAct_time, resources.GetString("btnAct_time.ToolTip"));
            // 
            // btnCnt_perday
            // 
            this.btnCnt_perday.AccessibleDescription = null;
            this.btnCnt_perday.AccessibleName = null;
            resources.ApplyResources(this.btnCnt_perday, "btnCnt_perday");
            this.btnCnt_perday.BackgroundImage = null;
            this.btnCnt_perday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCnt_perday.Image = ((System.Drawing.Image)(resources.GetObject("btnCnt_perday.Image")));
            this.btnCnt_perday.Name = "btnCnt_perday";
            this.toolTip1.SetToolTip(this.btnCnt_perday, resources.GetString("btnCnt_perday.ToolTip"));
            // 
            // btnCnt_perhour
            // 
            this.btnCnt_perhour.AccessibleDescription = null;
            this.btnCnt_perhour.AccessibleName = null;
            resources.ApplyResources(this.btnCnt_perhour, "btnCnt_perhour");
            this.btnCnt_perhour.BackgroundImage = null;
            this.btnCnt_perhour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCnt_perhour.Image = ((System.Drawing.Image)(resources.GetObject("btnCnt_perhour.Image")));
            this.btnCnt_perhour.Name = "btnCnt_perhour";
            this.toolTip1.SetToolTip(this.btnCnt_perhour, resources.GetString("btnCnt_perhour.ToolTip"));
            // 
            // chkAct_dq4
            // 
            this.chkAct_dq4.AccessibleDescription = null;
            this.chkAct_dq4.AccessibleName = null;
            resources.ApplyResources(this.chkAct_dq4, "chkAct_dq4");
            this.chkAct_dq4.BackgroundImage = null;
            this.chkAct_dq4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAct_dq4.Name = "chkAct_dq4";
            this.toolTip1.SetToolTip(this.chkAct_dq4, resources.GetString("chkAct_dq4.ToolTip"));
            this.chkAct_dq4.UseVisualStyleBackColor = false;
            // 
            // chkAct_dq3
            // 
            this.chkAct_dq3.AccessibleDescription = null;
            this.chkAct_dq3.AccessibleName = null;
            resources.ApplyResources(this.chkAct_dq3, "chkAct_dq3");
            this.chkAct_dq3.BackgroundImage = null;
            this.chkAct_dq3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAct_dq3.Name = "chkAct_dq3";
            this.toolTip1.SetToolTip(this.chkAct_dq3, resources.GetString("chkAct_dq3.ToolTip"));
            this.chkAct_dq3.UseVisualStyleBackColor = false;
            // 
            // chkAct_dq1
            // 
            this.chkAct_dq1.AccessibleDescription = null;
            this.chkAct_dq1.AccessibleName = null;
            resources.ApplyResources(this.chkAct_dq1, "chkAct_dq1");
            this.chkAct_dq1.BackgroundImage = null;
            this.chkAct_dq1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAct_dq1.Name = "chkAct_dq1";
            this.toolTip1.SetToolTip(this.chkAct_dq1, resources.GetString("chkAct_dq1.ToolTip"));
            this.chkAct_dq1.UseVisualStyleBackColor = false;
            // 
            // chkAct_dq2
            // 
            this.chkAct_dq2.AccessibleDescription = null;
            this.chkAct_dq2.AccessibleName = null;
            resources.ApplyResources(this.chkAct_dq2, "chkAct_dq2");
            this.chkAct_dq2.BackgroundImage = null;
            this.chkAct_dq2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAct_dq2.Name = "chkAct_dq2";
            this.toolTip1.SetToolTip(this.chkAct_dq2, resources.GetString("chkAct_dq2.ToolTip"));
            this.chkAct_dq2.UseVisualStyleBackColor = false;
            // 
            // vsbAct_time
            // 
            this.vsbAct_time.AccessibleDescription = null;
            this.vsbAct_time.AccessibleName = null;
            resources.ApplyResources(this.vsbAct_time, "vsbAct_time");
            this.vsbAct_time.BackgroundImage = null;
            this.vsbAct_time.Font = null;
            this.vsbAct_time.Name = "vsbAct_time";
            this.toolTip1.SetToolTip(this.vsbAct_time, resources.GetString("vsbAct_time.ToolTip"));
            this.vsbAct_time.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbTime_Scroll);
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.AccessibleDescription = null;
            this.xFlatLabel1.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.toolTip1.SetToolTip(this.xFlatLabel1, resources.GetString("xFlatLabel1.ToolTip"));
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.AccessibleDescription = null;
            this.xFlatLabel2.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel2.Name = "xFlatLabel2";
            this.toolTip1.SetToolTip(this.xFlatLabel2, resources.GetString("xFlatLabel2.ToolTip"));
            // 
            // emkAct_time
            // 
            this.emkAct_time.AccessibleDescription = null;
            this.emkAct_time.AccessibleName = null;
            resources.ApplyResources(this.emkAct_time, "emkAct_time");
            this.emkAct_time.BackgroundImage = null;
            this.emkAct_time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emkAct_time.Mask = "##:##";
            this.emkAct_time.Name = "emkAct_time";
            this.toolTip1.SetToolTip(this.emkAct_time, resources.GetString("emkAct_time.ToolTip"));
            // 
            // xDisplayBox4
            // 
            this.xDisplayBox4.AccessibleDescription = null;
            this.xDisplayBox4.AccessibleName = null;
            resources.ApplyResources(this.xDisplayBox4, "xDisplayBox4");
            this.xDisplayBox4.BackColor = IHIS.Framework.XColor.XTextBoxBackColor;
            this.xDisplayBox4.EdgeRounding = false;
            this.xDisplayBox4.Image = null;
            this.xDisplayBox4.Name = "xDisplayBox4";
            this.toolTip1.SetToolTip(this.xDisplayBox4, resources.GetString("xDisplayBox4.ToolTip"));
            // 
            // xFlatLabel5
            // 
            this.xFlatLabel5.AccessibleDescription = null;
            this.xFlatLabel5.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel5, "xFlatLabel5");
            this.xFlatLabel5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel5.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xFlatLabel5.Name = "xFlatLabel5";
            this.toolTip1.SetToolTip(this.xFlatLabel5, resources.GetString("xFlatLabel5.ToolTip"));
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.panUser);
            this.xPanel4.Controls.Add(this.panBase);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            this.toolTip1.SetToolTip(this.xPanel4, resources.GetString("xPanel4.ToolTip"));
            // 
            // panUser
            // 
            this.panUser.AccessibleDescription = null;
            this.panUser.AccessibleName = null;
            resources.ApplyResources(this.panUser, "panUser");
            this.panUser.BackgroundImage = null;
            this.panUser.Controls.Add(this.grdOCS0208);
            this.panUser.Font = null;
            this.panUser.Name = "panUser";
            this.toolTip1.SetToolTip(this.panUser, resources.GetString("panUser.ToolTip"));
            // 
            // grdOCS0208
            // 
            resources.ApplyResources(this.grdOCS0208, "grdOCS0208");
            this.grdOCS0208.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell19,
            this.xEditGridCell13,
            this.xEditGridCell21,
            this.xEditGridCell12});
            this.grdOCS0208.ColPerLine = 3;
            this.grdOCS0208.Cols = 3;
            this.grdOCS0208.ExecuteQuery = null;
            this.grdOCS0208.FixedRows = 1;
            this.grdOCS0208.FocusColumnName = "bogyong_code";
            this.grdOCS0208.HeaderHeights.Add(32);
            this.grdOCS0208.Name = "grdOCS0208";
            this.grdOCS0208.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0208.ParamList")));
            this.grdOCS0208.QuerySQL = resources.GetString("grdOCS0208.QuerySQL");
            this.grdOCS0208.ReadOnly = true;
            this.grdOCS0208.Rows = 2;
            this.toolTip1.SetToolTip(this.grdOCS0208, resources.GetString("grdOCS0208.ToolTip"));
            this.grdOCS0208.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0208_QueryEnd);
            this.grdOCS0208.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0208_MouseDown);
            this.grdOCS0208.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0208_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gubun";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellLen = 7;
            this.xEditGridCell3.CellName = "bogyong_code";
            this.xEditGridCell3.CellWidth = 109;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellLen = 400;
            this.xEditGridCell4.CellName = "bogyong_name";
            this.xEditGridCell4.CellWidth = 250;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell4.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "user_yn";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "dv";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "sort_key";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell12.AlterateRowImageIndex = 0;
            this.xEditGridCell12.CellName = "select";
            this.xEditGridCell12.CellWidth = 40;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.ImageList = this.ImageList;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell12.RowImageIndex = 0;
            this.xEditGridCell12.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell12.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // panBase
            // 
            this.panBase.AccessibleDescription = null;
            this.panBase.AccessibleName = null;
            resources.ApplyResources(this.panBase, "panBase");
            this.panBase.BackgroundImage = null;
            this.panBase.Controls.Add(this.grdBaseBogyongCode);
            this.panBase.Controls.Add(this.pnl1);
            this.panBase.Controls.Add(this.xPanel6);
            this.panBase.Font = null;
            this.panBase.Name = "panBase";
            this.toolTip1.SetToolTip(this.panBase, resources.GetString("panBase.ToolTip"));
            // 
            // grdBaseBogyongCode
            // 
            resources.ApplyResources(this.grdBaseBogyongCode, "grdBaseBogyongCode");
            this.grdBaseBogyongCode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell20,
            this.xEditGridCell17,
            this.xEditGridCell18});
            this.grdBaseBogyongCode.ColPerLine = 3;
            this.grdBaseBogyongCode.Cols = 3;
            this.grdBaseBogyongCode.ExecuteQuery = null;
            this.grdBaseBogyongCode.FixedRows = 1;
            this.grdBaseBogyongCode.FocusColumnName = "bogyong_code";
            this.grdBaseBogyongCode.HeaderHeights.Add(32);
            this.grdBaseBogyongCode.Name = "grdBaseBogyongCode";
            this.grdBaseBogyongCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBaseBogyongCode.ParamList")));
            this.grdBaseBogyongCode.QuerySQL = resources.GetString("grdBaseBogyongCode.QuerySQL");
            this.grdBaseBogyongCode.ReadOnly = true;
            this.grdBaseBogyongCode.Rows = 2;
            this.toolTip1.SetToolTip(this.grdBaseBogyongCode, resources.GetString("grdBaseBogyongCode.ToolTip"));
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "gubun";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.CellLen = 7;
            this.xEditGridCell15.CellName = "bogyong_code";
            this.xEditGridCell15.CellWidth = 117;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell15.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.CellLen = 400;
            this.xEditGridCell16.CellName = "bogyong_name";
            this.xEditGridCell16.CellWidth = 337;
            this.xEditGridCell16.Col = 2;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell16.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "user_yn";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "dv";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell18.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell18.AlterateRowImageIndex = 0;
            this.xEditGridCell18.CellName = "select";
            this.xEditGridCell18.CellWidth = 34;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.ImageList = this.ImageList;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell18.RowImageIndex = 0;
            this.xEditGridCell18.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell18.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // pnl1
            // 
            this.pnl1.AccessibleDescription = null;
            this.pnl1.AccessibleName = null;
            resources.ApplyResources(this.pnl1, "pnl1");
            this.pnl1.BackgroundImage = null;
            this.pnl1.Controls.Add(this.grdDrg0120);
            this.pnl1.Controls.Add(this.grdChiryoGubun);
            this.pnl1.Controls.Add(this.xPanel5);
            this.pnl1.Font = null;
            this.pnl1.Name = "pnl1";
            this.toolTip1.SetToolTip(this.pnl1, resources.GetString("pnl1.ToolTip"));
            // 
            // grdDrg0120
            // 
            resources.ApplyResources(this.grdDrg0120, "grdDrg0120");
            this.grdDrg0120.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell2,
            this.xEditGridCell11});
            this.grdDrg0120.ColPerLine = 2;
            this.grdDrg0120.Cols = 2;
            this.grdDrg0120.ControlBinding = true;
            this.grdDrg0120.ExecuteQuery = null;
            this.grdDrg0120.FixedRows = 1;
            this.grdDrg0120.HeaderHeights.Add(33);
            this.grdDrg0120.Name = "grdDrg0120";
            this.grdDrg0120.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrg0120.ParamList")));
            this.grdDrg0120.QuerySQL = resources.GetString("grdDrg0120.QuerySQL");
            this.grdDrg0120.ReadOnly = true;
            this.grdDrg0120.Rows = 2;
            this.toolTip1.SetToolTip(this.grdDrg0120, resources.GetString("grdDrg0120.ToolTip"));
            this.grdDrg0120.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdDrg0120_QueryEnd);
            this.grdDrg0120.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdDrg0120_MouseDown);
            this.grdDrg0120.PreEndInitializing += new System.EventHandler(this.grdDrg0120_PreEndInitializing);
            this.grdDrg0120.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg0120_QueryStarting);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bogyong_code";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell6.BindControl = this.dbxBogyong;
            this.xEditGridCell6.CellName = "bogyong_name";
            this.xEditGridCell6.CellWidth = 225;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell6.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // dbxBogyong
            // 
            this.dbxBogyong.AccessibleDescription = null;
            this.dbxBogyong.AccessibleName = null;
            resources.ApplyResources(this.dbxBogyong, "dbxBogyong");
            this.dbxBogyong.ImageList = this.ImageList;
            this.dbxBogyong.Name = "dbxBogyong";
            this.toolTip1.SetToolTip(this.dbxBogyong, resources.GetString("dbxBogyong.ToolTip"));
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "block_gubun";
            this.xEditGridCell7.CellWidth = 120;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell7.UserSQL = "    SELECT CODE, CODE_NAME\r\n      FROM INV0102\r\n     WHERE CODE_TYPE = \'32\'\r\n    " +
                "   AND CODE2     = \'A\'\r\n     ORDER BY CODE\r\n";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bogyong_gubun";
            this.xEditGridCell2.CellWidth = 37;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell11.AlterateRowImageIndex = 0;
            this.xEditGridCell11.CellName = "select";
            this.xEditGridCell11.CellWidth = 30;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.ImageList = this.ImageList;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell11.RowImageIndex = 0;
            this.xEditGridCell11.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell11.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // grdChiryoGubun
            // 
            resources.ApplyResources(this.grdChiryoGubun, "grdChiryoGubun");
            this.grdChiryoGubun.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10});
            this.grdChiryoGubun.ColPerLine = 2;
            this.grdChiryoGubun.Cols = 2;
            this.grdChiryoGubun.ExecuteQuery = null;
            this.grdChiryoGubun.FixedRows = 1;
            this.grdChiryoGubun.HeaderHeights.Add(35);
            this.grdChiryoGubun.Name = "grdChiryoGubun";
            this.grdChiryoGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdChiryoGubun.ParamList")));
            this.grdChiryoGubun.QuerySQL = resources.GetString("grdChiryoGubun.QuerySQL");
            this.grdChiryoGubun.ReadOnly = true;
            this.grdChiryoGubun.Rows = 2;
            this.toolTip1.SetToolTip(this.grdChiryoGubun, resources.GetString("grdChiryoGubun.ToolTip"));
            this.grdChiryoGubun.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdChiryoGubun_QueryEnd);
            this.grdChiryoGubun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdChiryoGubun_MouseDown);
            this.grdChiryoGubun.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdChiryoGubun_RowFocusChanged);
            this.grdChiryoGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdChiryoGubun_QueryStarting);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "code";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.CellName = "code_name";
            this.xEditGridCell9.CellWidth = 124;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell9.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.AlterateRowImageIndex = 0;
            this.xEditGridCell10.CellName = "select";
            this.xEditGridCell10.CellWidth = 30;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.ImageList = this.ImageList;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.RowImageIndex = 0;
            this.xEditGridCell10.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell10.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.dbxBogyong);
            this.xPanel5.Font = null;
            this.xPanel5.Name = "xPanel5";
            this.toolTip1.SetToolTip(this.xPanel5, resources.GetString("xPanel5.ToolTip"));
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.gbx3);
            this.xPanel6.Controls.Add(this.gbx2);
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
            this.toolTip1.SetToolTip(this.xPanel6, resources.GetString("xPanel6.ToolTip"));
            // 
            // gbx3
            // 
            this.gbx3.AccessibleDescription = null;
            this.gbx3.AccessibleName = null;
            resources.ApplyResources(this.gbx3, "gbx3");
            this.gbx3.BackgroundImage = null;
            this.gbx3.Controls.Add(this.rbDV6);
            this.gbx3.Controls.Add(this.rbDV4);
            this.gbx3.Controls.Add(this.rbDV3);
            this.gbx3.Controls.Add(this.rbDV);
            this.gbx3.Controls.Add(this.rbDV99);
            this.gbx3.Controls.Add(this.rbDV2);
            this.gbx3.Controls.Add(this.rbDV1);
            this.gbx3.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.gbx3.Name = "gbx3";
            this.gbx3.Protect = true;
            this.gbx3.TabStop = false;
            this.toolTip1.SetToolTip(this.gbx3, resources.GetString("gbx3.ToolTip"));
            // 
            // rbDV6
            // 
            
            this.rbDV6.AccessibleName = null;
            resources.ApplyResources(this.rbDV6, "rbDV6");
            this.rbDV6.BackgroundImage = null;
            this.rbDV6.CheckedValue = "6";
            this.rbDV6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDV6.Name = "rbDV6";
            this.toolTip1.SetToolTip(this.rbDV6, resources.GetString("rbDV6.ToolTip"));
            this.rbDV6.UseVisualStyleBackColor = false;
            this.rbDV6.Click += new System.EventHandler(this.rbDV1_Click);
            // 
            // rbDV4
            // 
            
            this.rbDV4.AccessibleName = null;
            resources.ApplyResources(this.rbDV4, "rbDV4");
            this.rbDV4.BackgroundImage = null;
            this.rbDV4.CheckedValue = "4";
            this.rbDV4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDV4.Name = "rbDV4";
            this.toolTip1.SetToolTip(this.rbDV4, resources.GetString("rbDV4.ToolTip"));
            this.rbDV4.UseVisualStyleBackColor = false;
            this.rbDV4.Click += new System.EventHandler(this.rbDV1_Click);
            // 
            // rbDV3
            // 
            
            this.rbDV3.AccessibleName = null;
            resources.ApplyResources(this.rbDV3, "rbDV3");
            this.rbDV3.BackgroundImage = null;
            this.rbDV3.CheckedValue = "3";
            this.rbDV3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDV3.Name = "rbDV3";
            this.toolTip1.SetToolTip(this.rbDV3, resources.GetString("rbDV3.ToolTip"));
            this.rbDV3.UseVisualStyleBackColor = false;
            this.rbDV3.Click += new System.EventHandler(this.rbDV1_Click);
            // 
            // rbDV
            // 
            
            this.rbDV.AccessibleName = null;
            resources.ApplyResources(this.rbDV, "rbDV");
            this.rbDV.BackgroundImage = null;
            this.rbDV.Checked = true;
            this.rbDV.CheckedValue = "%";
            this.rbDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDV.Name = "rbDV";
            this.rbDV.TabStop = true;
            this.toolTip1.SetToolTip(this.rbDV, resources.GetString("rbDV.ToolTip"));
            this.rbDV.UseVisualStyleBackColor = false;
            this.rbDV.Click += new System.EventHandler(this.rbDV1_Click);
            // 
            // rbDV99
            // 
            
            this.rbDV99.AccessibleName = null;
            resources.ApplyResources(this.rbDV99, "rbDV99");
            this.rbDV99.BackgroundImage = null;
            this.rbDV99.CheckedValue = "99";
            this.rbDV99.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDV99.Name = "rbDV99";
            this.toolTip1.SetToolTip(this.rbDV99, resources.GetString("rbDV99.ToolTip"));
            this.rbDV99.UseVisualStyleBackColor = false;
            this.rbDV99.Click += new System.EventHandler(this.rbDV1_Click);
            // 
            // rbDV2
            // 
            
            this.rbDV2.AccessibleName = null;
            resources.ApplyResources(this.rbDV2, "rbDV2");
            this.rbDV2.BackgroundImage = null;
            this.rbDV2.CheckedValue = "2";
            this.rbDV2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDV2.Name = "rbDV2";
            this.toolTip1.SetToolTip(this.rbDV2, resources.GetString("rbDV2.ToolTip"));
            this.rbDV2.UseVisualStyleBackColor = false;
            this.rbDV2.Click += new System.EventHandler(this.rbDV1_Click);
            // 
            // rbDV1
            // 
            this.rbDV1.AccessibleDescription = null;
            this.rbDV1.AccessibleName = null;
            resources.ApplyResources(this.rbDV1, "rbDV1");
            this.rbDV1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbDV1.BackgroundImage = null;
            this.rbDV1.CheckedValue = "1";
            this.rbDV1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDV1.Name = "rbDV1";
            this.toolTip1.SetToolTip(this.rbDV1, resources.GetString("rbDV1.ToolTip"));
            this.rbDV1.UseVisualStyleBackColor = false;
            this.rbDV1.Click += new System.EventHandler(this.rbDV1_Click);
            // 
            // gbx2
            // 
            this.gbx2.AccessibleDescription = null;
            this.gbx2.AccessibleName = null;
            resources.ApplyResources(this.gbx2, "gbx2");
            this.gbx2.BackgroundImage = null;
            this.gbx2.Controls.Add(this.rb4);
            this.gbx2.Controls.Add(this.rb3);
            this.gbx2.Controls.Add(this.rb2);
            this.gbx2.Controls.Add(this.rb1);
            this.gbx2.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.gbx2.Name = "gbx2";
            this.gbx2.Protect = true;
            this.gbx2.TabStop = false;
            this.toolTip1.SetToolTip(this.gbx2, resources.GetString("gbx2.ToolTip"));
            // 
            // rb4
            // 
            
            this.rb4.AccessibleName = null;
            resources.ApplyResources(this.rb4, "rb4");
            this.rb4.BackgroundImage = null;
            this.rb4.Checked = true;
            this.rb4.CheckedValue = "4";
            this.rb4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb4.Name = "rb4";
            this.rb4.TabStop = true;
            this.toolTip1.SetToolTip(this.rb4, resources.GetString("rb4.ToolTip"));
            this.rb4.UseVisualStyleBackColor = false;
            this.rb4.Click += new System.EventHandler(this.rb1_Click);
            // 
            // rb3
            // 
            
            this.rb3.AccessibleName = null;
            resources.ApplyResources(this.rb3, "rb3");
            this.rb3.BackgroundImage = null;
            this.rb3.CheckedValue = "3";
            this.rb3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb3.Name = "rb3";
            this.toolTip1.SetToolTip(this.rb3, resources.GetString("rb3.ToolTip"));
            this.rb3.UseVisualStyleBackColor = false;
            this.rb3.Click += new System.EventHandler(this.rb1_Click);
            // 
            // rb2
            // 
            
            this.rb2.AccessibleName = null;
            resources.ApplyResources(this.rb2, "rb2");
            this.rb2.BackgroundImage = null;
            this.rb2.CheckedValue = "2";
            this.rb2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb2.Name = "rb2";
            this.toolTip1.SetToolTip(this.rb2, resources.GetString("rb2.ToolTip"));
            this.rb2.UseVisualStyleBackColor = false;
            this.rb2.Click += new System.EventHandler(this.rb1_Click);
            // 
            // rb1
            // 
            this.rb1.AccessibleDescription = null;
            this.rb1.AccessibleName = null;
            resources.ApplyResources(this.rb1, "rb1");
            this.rb1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rb1.BackgroundImage = null;
            this.rb1.CheckedValue = "1";
            this.rb1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb1.Name = "rb1";
            this.toolTip1.SetToolTip(this.rb1, resources.GetString("rb1.ToolTip"));
            this.rb1.UseVisualStyleBackColor = false;
            this.rb1.Click += new System.EventHandler(this.rb1_Click);
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.chkUseYn);
            this.xPanel1.Controls.Add(this.rbtBase);
            this.xPanel1.Controls.Add(this.rbtUser);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // chkUseYn
            // 
            this.chkUseYn.AccessibleDescription = null;
            this.chkUseYn.AccessibleName = null;
            resources.ApplyResources(this.chkUseYn, "chkUseYn");
            this.chkUseYn.BackgroundImage = null;
            this.chkUseYn.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.chkUseYn.Name = "chkUseYn";
            this.toolTip1.SetToolTip(this.chkUseYn, resources.GetString("chkUseYn.ToolTip"));
            this.chkUseYn.UseVisualStyleBackColor = false;
            this.chkUseYn.CheckedChanged += new System.EventHandler(this.chkUseYn_CheckedChanged);
            // 
            // rbtBase
            // 
            this.rbtBase.AccessibleDescription = null;
            this.rbtBase.AccessibleName = null;
            resources.ApplyResources(this.rbtBase, "rbtBase");
            this.rbtBase.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtBase.BackgroundImage = null;
            this.rbtBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtBase.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtBase.ImageList = this.ImageList;
            this.rbtBase.Name = "rbtBase";
            this.toolTip1.SetToolTip(this.rbtBase, resources.GetString("rbtBase.ToolTip"));
            this.rbtBase.UseVisualStyleBackColor = false;
            // 
            // rbtUser
            // 
            this.rbtUser.AccessibleDescription = null;
            this.rbtUser.AccessibleName = null;
            resources.ApplyResources(this.rbtUser, "rbtUser");
            this.rbtUser.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtUser.BackgroundImage = null;
            this.rbtUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtUser.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtUser.ImageList = this.ImageList;
            this.rbtUser.Name = "rbtUser";
            this.toolTip1.SetToolTip(this.rbtUser, resources.GetString("rbtUser.ToolTip"));
            this.rbtUser.UseVisualStyleBackColor = false;
            this.rbtUser.CheckedChanged += new System.EventHandler(this.rbtUser_CheckedChanged);
            // 
            // dloSelectValue
            // 
            this.dloSelectValue.ExecuteQuery = null;
            this.dloSelectValue.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectValue.ParamList")));
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 100;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 10;
            // 
            // OCS0208Q01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Name = "OCS0208Q01";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.UserChanged += new System.EventHandler(this.OCS0208Q01_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0208Q01_ScreenOpen);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDRG0121)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            this.pnlDirect.ResumeLayout(false);
            this.pnlDirect.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            this.panUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0208)).EndInit();
            this.panBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaseBogyongCode)).EndInit();
            this.pnl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChiryoGubun)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            this.gbx3.ResumeLayout(false);
            this.gbx2.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectValue)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("order_remark"))
					{
						if(OpenParam["order_remark"].ToString().Trim() != "")
						{
							mOrder_remark = OpenParam["order_remark"].ToString();
							txtOrder_remark.SetDataValue(mOrder_remark);
						}
					}

					if(OpenParam.Contains("bogyong_code"))
					{
						if(OpenParam["bogyong_code"].ToString().Trim() != "")
							mBongYongCode = OpenParam["bogyong_code"].ToString();
					}

					if(OpenParam.Contains("hangmog_code"))
					{
						if(OpenParam["hangmog_code"].ToString().Trim() != "")
							mHangmog_code = OpenParam["hangmog_code"].ToString();
					}
					
				}
				catch
				{
				}
			}
            grdChiryoGubun.ParamList = CreateGrdChiryoGubunParamList();
            grdChiryoGubun.ExecuteQuery = LoadGrdChiryoGubun;
		    grdDrg0120.ParamList = CreateGrdDrg0120ParamList();
            grdDrg0120.ExecuteQuery = LoadGrdDrg0120;
            grdOCS0208.ParamList = CreateGrdOCS0208ParamList();
            grdOCS0208.ExecuteQuery = LoadGrdOCS0208;
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void OCS0208Q01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{			
		}

		private void PostLoad()
		{
			SetControl(this.pnlDirect);

			panBase.Visible = false;
			panUser.Visible = true;
			panBase.Dock = DockStyle.None;
			panUser.Dock = DockStyle.Fill;
			chkUseYn.Visible = false;

            //CreateCombo();

			//2008.10.01 hsy
			//외용약 치료구분 조회
            //grdChiryoGubun.QueryLayout(false);

			//외용약 코멘트
            //grdDRG0121.QueryLayout(false);

            /* 2011.01.20 kimminsoo 
             * 기존의 부위 선택에서 보통의 그리드 선택방법으로 변경
             */
            //grdBaseBogyongCode.QueryLayout(false);

            
            //default Value
            //emkAct_time.SetDataValue("0000");
  			
			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS0208Q01_UserChanged(this, new System.EventArgs()); 
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			if( TypeCheck.IsNull(mBongYongCode) ) return;
			
			//복용법 선택
			if ( rbtUser.Checked )
			{	
				bool userSelect = false;

				for( int i = 0; i < grdOCS0208.RowCount; i++ )
				{
					if(grdOCS0208.GetItemString(i, "bogyong_code") == mBongYongCode)
					{
						grdOCS0208.SetFocusToItem(i, 0);
						// 체크 표시
						selectionCheck(this.grdOCS0208, i);
						userSelect = true;
						break;
					}
				}	
			
                //if( !userSelect )
                //{
                //    rbtBase.Checked = true;
                //    SetBanghwang_block( mBongYongCode );
                //}
			}
            //else
            //{
            //    SetBanghwang_block( mBongYongCode );
            //}

		}
		
		private void OCS0208Q01_UserChanged(object sender, System.EventArgs e)
		{
            if (UserInfo.UserID.Length >= 5)
            {
                mDoctor = UserInfo.UserID.ToString().Substring(0, 5);
            }
            else
            {
                mDoctor = UserInfo.UserID;
            }
            grdOCS0208.SetBindVarValue("f_doctor", mDoctor);
            grdOCS0208.QueryLayout(true);					

			if(grdOCS0208.RowCount < 1)
				rbtBase.Checked = true;
            else
                rbtUser.Checked = true;
		}	

		/// <summary>
		/// 1.Hashtable에 각 DataControl를 Load시켜서 해당 Control의 제어를 용이하게 한다.
		/// </summary>
		private void SetControl(XPanel pnl)
		{
			string colName = "";

			foreach(object obj in pnl.Controls)
			{
				try
				{
					if( obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
					{
						colName = ((XComboBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
					else if( obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
					{
						colName = ((XTextBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditMask" ) >= 0)
					{						
						colName = ((XEditMask)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
					else if( obj.GetType().ToString().IndexOf("XCheckBox" ) >= 0)
					{
						colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
					else if( obj.GetType().ToString().IndexOf("XDisplayBox" ) >= 0)
					{
						colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);										
					}
					else if( obj.GetType().ToString().IndexOf("XFindBox" ) >= 0)
					{
						colName = ((XFindBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}	
					else if( obj.GetType().ToString().IndexOf("XDatePicker" ) >= 0)
					{
						colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
				}
				catch(Exception ex)
				{
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
				}
			}
		}

//        private void CreateCombo()
//        {
//            layoutCombo.Reset();
//            layoutCombo.LayoutItems.Clear();
//            layoutCombo.LayoutItems.Add("block_gubun", DataType.String);
//            layoutCombo.LayoutItems.Add("block_name" , DataType.String);
//            layoutCombo.LayoutItems.Add("banghayang" , DataType.String);
//            layoutCombo.InitializeLayoutTable();

//            layoutCombo.QuerySQL = @"SELECT DISTINCT BLOCK_GUBUN, FN_DRG_LOAD_DRG0102( BLOCK_GUBUN, '32') BLOCK_NAME, DECODE(BANGHYANG, NULL, 'N', 'Y') BANGHYANG 
//                                       FROM DRG0120
//                                      WHERE BUNRYU1   = '6'
//                                        AND HOSP_CODE = :f_hosp_code
//                                      ORDER BY BLOCK_GUBUN";
//            layoutCombo.SetBindVarValue("f_hosp_code", mHospCode);
//            layoutCombo.QueryLayout(false);

//            if(Service.ErrCode == 0 && layoutCombo.LayoutTable != null)
//            {
//            }

//            IHIS.Framework.MultiLayout    layoutOCS0132 = new MultiLayout();

//            layoutOCS0132.Reset();
//            layoutOCS0132.LayoutItems.Clear();
//            layoutOCS0132.LayoutItems.Add("code"      , DataType.String);
//            layoutOCS0132.LayoutItems.Add("code_name" , DataType.String);
//            layoutOCS0132.InitializeLayoutTable();

//            layoutOCS0132.QuerySQL = @"SELECT CODE, CODE_NAME
//                                         FROM OCS0132
//                                        WHERE CODE_TYPE = 'DV'
//                                          AND HOSP_CODE = :f_hosp_code
//                                        ORDER BY SORT_KEY";
//            layoutOCS0132.SetBindVarValue("f_hosp_code", mHospCode);
//            layoutOCS0132.QueryLayout(false);

//            if (Service.ErrCode == 0 && layoutOCS0132.LayoutTable != null)
//            {
//                cboCnt_perday.SetComboItems( layoutOCS0132.LayoutTable, "code_name", "code");
//                cboCnt_perday.SelectedIndex = 0;

//                cboCnt_perhour.SetComboItems( layoutOCS0132.LayoutTable, "code_name", "code");
//                cboCnt_perhour.SelectedIndex = 0;
//            }

//            layoutOCS0132.Reset();

//            layoutOCS0132.SetBindVarValue("f_hosp_code", mHospCode);
//            layoutOCS0132.QuerySQL = @"SELECT CODE, CODE_NAME
//                                         FROM OCS0132
//                                        WHERE CODE_TYPE = 'NALSU'
//                                          AND HOSP_CODE = :f_hosp_code
//                                        ORDER BY SORT_KEY";
//            layoutOCS0132.SetBindVarValue("f_hosp_code", mHospCode);
//            layoutOCS0132.QueryLayout(false);

//            if (Service.ErrCode == 0 && layoutOCS0132.LayoutTable != null)
//            {
//                cboNalsu.SetComboItems(layoutOCS0132.LayoutTable, "code_name", "code");
//                cboNalsu.SelectedIndex = 0;
//            }
//        }

		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			SetMsg("");

			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					this.grdOCS0208.QueryLayout(true);					

					break;

				case FunctionType.Process:
                    
					AllSelect = true;
					CreateReturn();
					
					break;
					
				default:

					break;
			}
		}

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process:
                    
					break;

					
				default:

					break;
			}
		}

		#endregion
        
		#region [GrdOCS0208 Event]

		private void grdOCS0208_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowIndex;

			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				rowIndex = grdOCS0208.GetHitRowNumber(e.Y);
				if (rowIndex < 0) return;
                
				selectionCheck(grdOCS0208, rowIndex);
			}
			else if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				int curRowIndex = grdOCS0208.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;
                
				AllSelect = true;
				CreateReturn();
			}
		}

		#endregion

		#region [grdDrg0120 Event]

		private void grdDrg0120_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowIndex;

			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				rowIndex = grdDrg0120.GetHitRowNumber(e.Y);
				if (rowIndex < 0) return;
                
				selectionCheck(grdDrg0120, rowIndex);
			}
			else if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				int curRowIndex = grdDrg0120.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;
                
				AllSelect = true;
				CreateReturn();
			}
		
		}


		#endregion

		#region [Return Layout 생성]

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			AllSelect = true;
			CreateReturn();		
		}

		private void btnProcessRemark_Click(object sender, System.EventArgs e)
		{
			AllSelect = false;
			CreateReturn();	
		}
        
		private void CreateReturn()
		{
			this.AcceptData();
			
            //if(rbtUser.Checked)
            //{
				if(this.grdOCS0208.CurrentRowNumber < 0) 
				{					
					mbxMsg = Resources.MSG_001;
					mbxCap = Resources.CAP_001;
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
					return;				
				}	

				this.mBongYongCode = grdOCS0208.GetItemString(grdOCS0208.CurrentRowNumber, "bogyong_code");
            //}
            //else
            //{
            //    if (this.grdBaseBogyongCode.CurrentRowNumber < 0)
            //    {					
            //        mbxMsg = NetInfo.Language == LangMode.Jr ? "服用法が選択されいません。ご確認下さい。" : "복용법이 선택되지 않았습니다. 확인하세요.";
            //        mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
            //        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
            //        return;				
            //    }

            //    //2011.01.20 kimminsoo 수정
            //    //this.mBongYongCode = grdDrg0120.GetItemString(grdDrg0120.CurrentRowNumber, "bogyong_code");
            //    this.mBongYongCode = grdBaseBogyongCode.GetItemString(grdBaseBogyongCode.CurrentRowNumber, "bogyong_code");
            //}

			mOrder_remark = this.txtOrder_remark.GetDataValue().Trim();
			
            if ((mBongYongCode == "Z0V" || mBongYongCode == "Z0A") && TypeCheck.IsNull(mOrder_remark))
            {
				mbxCap = "";
				mbxMsg = Resources.MSG_002;
						
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
				this.txtOrder_remark.Focus();
				return;
			}

			//약속코드선택정보가 있는 경우 Return Value
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			if(AllSelect) commandParams.Add( "bogyong_code", mBongYongCode);
			commandParams.Add( "order_remark", mOrder_remark);
            commandParams.Add( "dv", grdOCS0208.GetItemString(grdOCS0208.CurrentRowNumber, "dv")); // dv -> DRG0120 bogyong_gubun
			scrOpener.Command(ScreenID, commandParams);

			this.Close();
			
		}
		
		#endregion

		#region [복용코드구분변경]

		private void rbtUser_CheckedChanged(object sender, System.EventArgs e)
		{
            //if(rbtUser.Checked)
            //{
            //    rbtUser.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
            //    rbtUser.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
            //    rbtUser.ImageIndex = 1;

            //    rbtBase.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
            //    rbtBase.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //    rbtBase.ImageIndex = 0;
                
            //    panBase.Visible = false;
            //    panUser.Visible = true;
            //    panBase.Dock = DockStyle.None;
            //    panUser.Dock = DockStyle.Fill;

            //    UserSangChangeColor(this.grdOCS0208);
            //    //chkUseYn.Visible = false;
            //}
            //else
            //{
            //    rbtBase.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
            //    rbtBase.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
            //    rbtBase.ImageIndex = 1;

            //    rbtUser.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
            //    rbtUser.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //    rbtUser.ImageIndex = 0;

            //    panUser.Visible = false;
            //    panBase.Visible = true;
            //    panUser.Dock = DockStyle.None;
            //    panBase.Dock = DockStyle.Fill;

            //    UserSangChangeColor(this.grdOCS0208);
            //    //chkUseYn.Visible = true;
            //}		

            panBase.Visible = false;
            panUser.Visible = true;
            panBase.Dock = DockStyle.None;
            panUser.Dock = DockStyle.Fill;

            if (rbtUser.Checked)
            {
                rbtUser.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbtUser.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbtUser.ImageIndex = 1;

                rbtBase.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtBase.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtBase.ImageIndex = 0;

                mGubun = "0";

            }
            else
            {
                rbtBase.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbtBase.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbtBase.ImageIndex = 1;

                rbtUser.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtUser.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtUser.ImageIndex = 0;

                mGubun = "1";
            }

            SetFilter();
		}

        private void SetFilter()
        {
            this.grdOCS0208.ClearFilter();
            if (grdOCS0208.RowCount > 0)
            {
                grdOCS0208.SetFilter(" gubun = '" + mGubun + "'");

                //// 돈복
                //if (mBanghyang == "99")
                //{
                //    grdOCS0208.SetFilter(" gubun = '" + mGubun);
                //    //cboDv_time.SetDataValue("*");

                //}
                //else
                //{
                //    grdOCS0208.SetFilter(" gubun = '" + mGubun);
                //    //cboDv_time.SetDataValue("/");
                //}
            }

            //SelectionBackColorChange(this.grdOCS0208);
            UserSangChangeColor(this.grdOCS0208);
        }

		#endregion		
        #region [使用者服用コード色付け]
        private void UserSangChangeColor(XEditGrid grd)
        {
            XGrid grdObject = grd;
            //기존의 색으로 변경을 시킨다
            for (int rowIndex = 0; rowIndex < grdObject.DisplayRowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "user_yn") != "N")
                {
                    XColor mSelectedForeColor = new XColor(Color.Red);
                    grdObject[rowIndex + grdObject.HeaderHeights.Count, 2].ForeColor = mSelectedForeColor;
                }
            }
        }
        #endregion
		#region [DGR 복용법]

		[Browsable(false), DataBindable]
		public string gubun
		{
			get 
			{
				foreach (Control con in gbx2.Controls) 
				{
					if (con is XFlatRadioButton)  
					{
						if ( ((XFlatRadioButton)con).Checked) 
							return ((XFlatRadioButton)con).CheckedValue.ToString();
					}
				}
				return "";
			}
		}
		
		private void Query()
		{
			int currentRow = grdDrg0120.CurrentRowNumber;

            grdDrg0120.QueryLayout(true);

			if(currentRow > 0)
				grdDrg0120.SetFocusToItem(currentRow, 0);
		}

		private void rb1_Click(object sender, System.EventArgs e)
		{
			Query();
		}

		private void cbxBlock_SelectedValueChanged(object sender, System.EventArgs e)
		{
			Query();
		}
		#endregion

		#region [복용내용생성]
        //private void btnCnt_perhour_Click(object sender, System.EventArgs e)
        //{
        //    string direct_text = "";
        //    direct_text = txtOrder_remark.GetDataValue() + " " + cboCnt_perhour.Text + "時間毎";	

        //    txtOrder_remark.SetEditValue(direct_text);

        //    txtOrder_remark.Focus();
        //    txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;
        //}

        //private void btnCnt_perday_Click(object sender, System.EventArgs e)
        //{
        //    string direct_text = "";
        //    direct_text = txtOrder_remark.GetDataValue() + "1日 " + cboCnt_perday.Text + "回 ";

        //    txtOrder_remark.SetEditValue(direct_text);			
        //    txtOrder_remark.Focus();
        //    txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;
        //}

        //private void btnFreCnt_perday_Click(object sender, System.EventArgs e)
        //{
        //    string direct_text = "";
        //    direct_text = txtOrder_remark.GetDataValue() + "1日 数回 ";

        //    txtOrder_remark.SetEditValue(direct_text);			
        //    txtOrder_remark.Focus();
        //    txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;		
        //}

        //private void btnNalsu_Click(object sender, System.EventArgs e)
        //{
        //    string direct_text = "";
        //    direct_text = txtOrder_remark.GetDataValue() + " " + cboNalsu.Text + "日分";

        //    txtOrder_remark.SetEditValue(direct_text);			
        //    txtOrder_remark.Focus();
        //    txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;
		
        //}

        //private void btnAct_time_Click(object sender, System.EventArgs e)
        //{
        //    string direct_text = "";
        //    direct_text = txtOrder_remark.GetDataValue() + " " + emkAct_time.Text + "時";
			
        //    txtOrder_remark.SetEditValue(direct_text);
			
        //    txtOrder_remark.Focus();
        //    txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;
        //}

        //private void btnAct_dq_Click(object sender, System.EventArgs e)
        //{
        //    string direct_text = "";
        //    direct_text = txtOrder_remark.GetDataValue();

        //    if(chkAct_dq1.Checked)
        //        direct_text = direct_text + " 朝/";

        //    if(chkAct_dq2.Checked)
        //        direct_text = direct_text + " 昼/";
			
        //    if(chkAct_dq3.Checked)
        //        direct_text = direct_text + " 夕/";
			
        //    if(chkAct_dq4.Checked)
        //        direct_text = direct_text + " 寝前";

        //    txtOrder_remark.SetEditValue(direct_text);
			
        //    txtOrder_remark.Focus();
        //    txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;
		
        //}

        //#region [grdDRG0121]

        //private void grdDRG0121_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    int curRowIndex = -1;			
			
        //    if(e.Button == MouseButtons.Left && e.Clicks == 2)
        //    {
        //        curRowIndex = grdDRG0121.GetHitRowNumber(e.Y);
        //        if(curRowIndex < 0) return;

        //        string direct_text = "";
        //        direct_text = txtOrder_remark.GetDataValue() + " " + grdDRG0121.GetItemString(curRowIndex, "comments");
        //        txtOrder_remark.SetEditValue(direct_text);
				
        //        txtOrder_remark.Focus();
        //        txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;
        //    }
        //    else if(e.Button == MouseButtons.Left && e.Clicks == 1)
        //    {
        //        curRowIndex = grdDRG0121.GetHitRowNumber(e.Y);
        //        if(curRowIndex < 0) return;

        //        string dragInfo = grdDRG0121.GetItemString(curRowIndex, "comments");
        //        DragHelper.CreateDragCursor(grdDRG0121, dragInfo, this.Font);
        //        txtOrder_remark.DoDragDrop(grdDRG0121.GetItemString(curRowIndex, "comments"), DragDropEffects.Move);	
        //    }		
        //}

        //private void grdDRG0121_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;  // Move 표시		
        //}

        //private void grdDRG0121_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        //{
        //    e.UseDefaultCursors = false;
        //    // Drag시에 Cursor 바꿈
        //    if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
        //    {
        //        Cursor.Current = DragHelper.DragCursor;
        //    }			
        //}

        //#endregion
		
		#region [Order_remark Drag 처리]

		/// <summary>
		/// 내용코드 grid에서 Drag했을 경우 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtOrder_remark_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string direct_text = "";
			direct_text = txtOrder_remark.GetDataValue() + " " + e.Data.GetData("System.String").ToString();

			txtOrder_remark.SetEditValue(direct_text);
			txtOrder_remark.Focus();
			txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;

		}

		private void txtOrder_remark_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시			
		}

		private void txtOrder_remark_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}			
		}

		#endregion
		
		#endregion

		#region [Scroll]
		/// <summary>
		/// Number인 경우 Scroll시 증가,감소처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void vsbNumber_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			VScrollBar vsb = sender as VScrollBar;
            
			string colName = vsb.Name.Substring(3).ToLower();
			
			double incrementValue = 0;
			double maxIncrement   = 0;
			double controlValue   = 0;

			switch (colName)
			{
				case "cnt_perhour":
					incrementValue = 1;
					maxIncrement   = 60;

					break;

				case "cnt_perday" :

					incrementValue = 1;
					maxIncrement   = 5;
					break;

				case "nalsu" :

					incrementValue = 1;
					maxIncrement   = 100;
					break;
			}

			
			switch (e.Type)
			{
				case System.Windows.Forms.ScrollEventType.LargeIncrement:
				case System.Windows.Forms.ScrollEventType.SmallIncrement:
					//감소
					controlValue = double.Parse(((IDataControl)htControl[colName]).DataValue.ToString() == "" ? "0" : ((IDataControl)htControl[colName]).DataValue.ToString());
					controlValue = controlValue - incrementValue;

					if(controlValue < 0 ) controlValue = 0;

					((IDataControl)htControl[colName]).DataValue = controlValue;

					break;
				case System.Windows.Forms.ScrollEventType.LargeDecrement:
				case System.Windows.Forms.ScrollEventType.SmallDecrement:

					//증가
					controlValue = double.Parse(((IDataControl)htControl[colName]).DataValue.ToString() == "" ? "0" : ((IDataControl)htControl[colName]).DataValue.ToString());
					controlValue = controlValue + incrementValue;

					if( controlValue >= maxIncrement) controlValue = 0;

					((IDataControl)htControl[colName]).DataValue = controlValue;
					
					break;
			}
		}

		/// <summary>
		/// Time인 경우 Scroll시 증가,감소처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void vsbTime_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			VScrollBar vsb = sender as VScrollBar;            
			string colName = vsb.Name.Substring(3).ToLower();

			XEditMask editor = (XEditMask)htControl[colName];
			bool selectHour = true;
			int  selectStart = editor.SelectionStart;

			if(selectStart > 2)
				selectHour = false;
			
			int hours = 0;
			int min   = 0;

			if( TypeCheck.IsInt(editor.GetDataValue().ToString().PadRight(4).Substring(0, 2)) )
				hours = int.Parse(editor.GetDataValue().ToString().PadRight(4).Substring(0, 2));

			if( TypeCheck.IsInt(editor.GetDataValue().ToString().PadRight(4).Substring(2)) )
				min   = int.Parse(editor.GetDataValue().ToString().PadRight(4).Substring(2));
			
			switch (e.Type)
			{
				case System.Windows.Forms.ScrollEventType.LargeIncrement:
				case System.Windows.Forms.ScrollEventType.SmallIncrement:
					//감소
					if( selectHour )
					{
						hours = hours - 1;
						if( hours < 0 )
							hours = 23;
					}
					else
					{
						min = min - 1;
						if(min < 0)
						{
							min = 59;
							hours = hours - 1;
							if( hours < 0 )
								hours = 23;
						}
					}

					break;
				case System.Windows.Forms.ScrollEventType.LargeDecrement:
				case System.Windows.Forms.ScrollEventType.SmallDecrement:

					//증가
					//감소
					if( selectHour )
					{
						hours = hours + 1;
						if( hours >= 24 )
							hours = 0;
					}
					else
					{
						min = min + 1;
						if(min >= 60)
						{
							min = 0;
							hours = hours + 1;
							if( hours >= 24 )
								hours = 0;
						}
					}
					
					break;
			}

			editor.SetDataValue(hours.ToString("00") + min.ToString("00"));
			editor.SelectionStart = selectStart;
		}
		#endregion

		#region [DV, NALSU Combo 처리]

		private void ComBoNum_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{			
			if(e.KeyChar != (char)8  && //back
				e.KeyChar != (char)9  && //tab
				e.KeyChar != (char)13 && //Enter
				e.KeyChar != (char)46 && //Delete
				!TypeCheck.IsInt(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}

		#endregion	

		#region [ 해당 복용법을 선택한다. ]

//        private void SetBanghwang_block(string aBogyong_code)
//        {
//            string banghwang   = "";
//            string block_gubun = "";
//            string chiryo_gubun= "";

//            MultiLayout layBanghwang = new MultiLayout();
//            layBanghwang.LayoutItems.Clear();
//            layBanghwang.LayoutItems.Add("banghwang",    DataType.String);
//            layBanghwang.LayoutItems.Add("block_gubun",  DataType.String);
//            layBanghwang.LayoutItems.Add("chiryo_gubun", DataType.String);
//            layBanghwang.InitializeLayoutTable();

//            layBanghwang.QuerySQL = @"SELECT A.BANGHYANG, A.BLOCK_GUBUN, A.CHIRYO_GUBUN
//                                        FROM DRG0120 A
//                                       WHERE A.BOGYONG_CODE = :f_bogyong_code 
//                                         AND A.HOSP_CODE    = :f_hosp_code";
//            layBanghwang.SetBindVarValue("f_bogyong_code", aBogyong_code);
//            layBanghwang.SetBindVarValue("f_hosp_code",    mHospCode);
//            layBanghwang.QueryLayout(false);

//            if(layBanghwang.QueryLayout(false))
//            {
//                banghwang    = layBanghwang.GetItemString(0, "banghwang");
//                block_gubun  = layBanghwang.GetItemString(0, "block_gubun");
//                chiryo_gubun = layBanghwang.GetItemString(0, "chiryo_gubun");
                
//                //방향선택
//                foreach (Control ctl in gbx2.Controls) 
//                {
//                    if (ctl is XFlatRadioButton)  
//                    {
//                        if ( ((XFlatRadioButton)ctl).CheckedValue.ToString() == banghwang ) 
//                            ((XFlatRadioButton)ctl).Checked = true;
//                    }
//                }
				
//                //치료방법 grid(grdChiryoGubun)에서 복용법 치료방법 선택
//                for (int i=0; i<this.grdChiryoGubun.RowCount; i++)
//                {
//                    if (this.grdChiryoGubun.GetItemString(i, "code") == chiryo_gubun)
//                    {
//                        this.grdChiryoGubun.SetFocusToItem(i, 0);
//                        // 체크 표시
//                        selectionCheck(this.grdChiryoGubun, i);

//                        break;
//                    }
//                }

//                Query();

//                PostCallHelper.PostCall( new PostMethodStr(SelectBogyong_code), aBogyong_code);

//            }

//        }

		private void SelectBogyong_code(string aBogyong_code)
		{
			for( int i = 0; i < grdDrg0120.RowCount; i++ )
			{
				if(grdDrg0120.GetItemString(i, "bogyong_code") == aBogyong_code)
				{
					grdDrg0120.SetFocusToItem(i, 0);
					// 체크 표시
					selectionCheck(this.grdDrg0120, i);

					break;
				}
			}
		}

		

		#endregion

		private void rbDV1_Click(object sender, System.EventArgs e)
		{
			Query();
		}

		private void chkUseYn_CheckedChanged(object sender, System.EventArgs e)
		{
            grdChiryoGubun.QueryLayout(false);
		}

		private void grdChiryoGubun_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			Query();
		}

		#region 선택체크 표지
		private void selectionCheck(object grid, int rowIndex)
		{
			XEditGrid grdObject = (XEditGrid)grid;

			for ( int i = 0; i < grdObject.RowCount; i++ )
			{
				grdObject[i + grdObject.HeaderHeights.Count,0].Image = ImageList.Images[0];
			}

			grdObject[rowIndex + grdObject.HeaderHeights.Count,0].Image = ImageList.Images[1];
		}
		#endregion

		#region 치료방법 마우스 다운
		private void grdChiryoGubun_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowIndex;

			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				rowIndex = grdChiryoGubun.GetHitRowNumber(e.Y);
				if (rowIndex < 0) return;
                
				selectionCheck(grdChiryoGubun, rowIndex);
			}
		}
		#endregion

		#region 첫번째 row 체크 표시
		private void grdOCS0208_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if (this.grdOCS0208.RowCount > 0)
			{
				selectionCheck(grdOCS0208, 0);
			}
		}
        private void grdChiryoGubun_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if (this.grdChiryoGubun.RowCount > 0)
			{
				selectionCheck(grdChiryoGubun, 0);
			}
		}
        private void grdDrg0120_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if (this.grdDrg0120.RowCount > 0)
			{
				selectionCheck(grdDrg0120, 0);
			}
		}
		#endregion

        #region 각 그리드에 바인드변수 설정
        private void grdChiryoGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            grdChiryoGubun.SetBindVarValue("f_hosp_code",     mHospCode);
            grdChiryoGubun.SetBindVarValue("f_bogyong_gubun", bogyong_gubun);
            grdChiryoGubun.SetBindVarValue("f_jaeryo_code",   hangmog_code);
            grdChiryoGubun.SetBindVarValue("f_use_yn",        use_yn);
        }

        private void grdOCS0208_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0208.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdDrg0120_QueryStarting(object sender, CancelEventArgs e)
        {
            /*string o_jaeryo_code = string.Empty;
            string cmdText = @"SELECT JAERYO_CODE
                                 FROM OCS0103
                                WHERE HANGMOG_CODE = '" + hangmog_code + "' "
                            + "   AND HOSP_CODE    = '" + mHospCode    + "' ";
            object retVal = null;
            retVal = Service.ExecuteScalar(cmdText);
            if (!TypeCheck.IsNull(retVal))
                o_jaeryo_code = retVal.ToString();
            else
                o_jaeryo_code = "";*/

            grdDrg0120.SetBindVarValue("f_banghyang",     gubun);
            grdDrg0120.SetBindVarValue("f_chiryo_gubun",  grdChiryoGubun.GetItemString(grdChiryoGubun.CurrentRowNumber, "code"));
            grdDrg0120.SetBindVarValue("f_hosp_code",     mHospCode);
            grdDrg0120.SetBindVarValue("f_jaeryo_code",   hangmog_code);
            /*grdDrg0120.SetBindVarValue("o_jaeryo_code",   o_jaeryo_code);*/
            grdDrg0120.SetBindVarValue("f_use_yn",        hangmog_code);
            grdDrg0120.SetBindVarValue("f_bogyong_gubun", bogyong_gubun);
        }
        #endregion

        //private void grdBaseBogyongCode_QueryEnd(object sender, QueryEndEventArgs e)
        //{
        //    if (this.grdBaseBogyongCode.RowCount > 0)
        //    {
        //        selectionCheck(grdBaseBogyongCode, 0);
        //    }
        //}

        //private void grdBaseBogyongCode_MouseDown(object sender, MouseEventArgs e)
        //{
        //    int rowIndex;
        //    XEditGrid aGrid = (XEditGrid)sender;

        //    if (e.Button == MouseButtons.Left && e.Clicks == 1)
        //    {
        //        rowIndex = aGrid.GetHitRowNumber(e.Y);
        //        if (rowIndex < 0) return;

        //        selectionCheck(aGrid, rowIndex);
        //    }
        //    else if (e.Button == MouseButtons.Left && e.Clicks == 2)
        //    {
        //        int curRowIndex = aGrid.GetHitRowNumber(e.Y);
        //        if (curRowIndex < 0) return;

        //        AllSelect = true;
        //        CreateReturn();
        //    }
        //}

        //private void grdBaseBogyongCode_QueryStarting(object sender, CancelEventArgs e)
        //{
        //    this.grdBaseBogyongCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        //}

        #region cloud service

	    private List<string> CreateGrdChiryoGubunParamList()
	    {
            List<string> paramList = new List<string>();
            paramList.Add("f_bogyong_gubun");
            paramList.Add("f_jaeryo_code");
            paramList.Add("f_use_yn");
            return paramList;
	    }

        private List<object[]> LoadGrdChiryoGubun(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0208Q01GrdChiryoGubunArgs args = new OCS0208Q01GrdChiryoGubunArgs();
            args.BogyongGubun = bc["f_bogyong_gubun"] != null ? bc["f_bogyong_gubun"].VarValue : "";
            args.JaeryoCode = bc["f_jaeryo_code"] != null ? bc["f_jaeryo_code"].VarValue : "";
            args.UseYn = bc["f_use_yn"] != null ? bc["f_use_yn"].VarValue : "";
            OCS0208Q01GrdChiryoGubunResult result = CloudService.Instance.Submit<OCS0208Q01GrdChiryoGubunResult, OCS0208Q01GrdChiryoGubunArgs>(args);
            if (result != null)
            {
                foreach (ComboListItemInfo item in result.ChiryoGubunInfo)
                {
                    object[] objects = 
				{ 
					item.Code, 
					item.CodeName
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<string> CreateGrdDrg0120ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_chiryo_gubun");
            paramList.Add("f_banghyang");
            paramList.Add("f_jaeryo_code");
            paramList.Add("f_use_yn");
            paramList.Add("f_bogyong_gubun");
            return paramList;
        }

        private List<object[]> LoadGrdDrg0120(BindVarCollection bc)
	    {
            List<object[]> res = new List<object[]>();
            OCS0208Q01GrdDrg0120Args args = new OCS0208Q01GrdDrg0120Args();
            args.ChiryoGubun = bc["f_chiryo_gubun"] != null ? bc["f_chiryo_gubun"].VarValue : "";
            args.Banghyang = bc["f_banghyang"] != null ? bc["f_banghyang"].VarValue : "";
            args.JaeryoCode = bc["f_jaeryo_code"] != null ? bc["f_jaeryo_code"].VarValue : "";
            args.UseYn = bc["f_use_yn"] != null ? bc["f_use_yn"].VarValue : "";
            args.BogyongGubun = bc["f_bogyong_gubun"] != null ? bc["f_bogyong_gubun"].VarValue : "";

            OCS0208Q01GrdDrg0120Result result =
                CloudService.Instance.Submit<OCS0208Q01GrdDrg0120Result, OCS0208Q01GrdDrg0120Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0208Q01GrdDrg0120Info item in result.GrdDrg0120Info)
                {
                    object[] objects = 
						{ 
                        item.BogyongCode, 
                        item.BogyongName, 
                        item.BlockGubun, 
                        item.BogyongGubun
						};
                    res.Add(objects);
                }
                comboListItem = result.ComboInfo;
            }
            return res; 
	    }

        private List<string> CreateGrdOCS0208ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_doctor");
            return paramList;
        }

	    private List<object[]> LoadGrdOCS0208(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        OCS0208Q01GrdOCS0208Args args = new OCS0208Q01GrdOCS0208Args();
	        args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
	        OCS0208Q01GrdOCS0208Result result =
	            CloudService.Instance.Submit<OCS0208Q01GrdOCS0208Result, OCS0208Q01GrdOCS0208Args>(
	                args);
	        if (result != null)
	        {
	            foreach (OCS0208Q01GrdOCS0208Info item in result.GrdOCS0208Info)
	            {
	                object[] objects =
	                {
	                    item.Gubun,
	                    item.BogyongCode,
	                    item.BogyongName,
	                    item.UserYn,
	                    item.BogyongGubun,
	                    item.Seq
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        private IList<object[]> GetGridCellCombo(BindVarCollection list)
        {
            IList<object[]> lstObject = new List<object[]>();
            if (comboListItem != null)
            {
                foreach (ComboListItemInfo item in comboListItem)
                {
                    lstObject.Add(new object[] {item.Code, item.CodeName});
                }
            }

            return lstObject;
        }
        #endregion

        private void grdDrg0120_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell7.ExecuteQuery = GetGridCellCombo;
        }
    }
}

