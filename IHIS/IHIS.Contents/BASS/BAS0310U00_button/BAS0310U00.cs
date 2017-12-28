using System.Collections.Generic;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;

#region 사용 NameSpace 지정

using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.System;
#endregion

/*=========================================================================================
 * 일반 : boheom
   노인 : boho
   자배 : Car
   노재 : san
   공해 : ilban
 * 
 * 
 * 
 =========================================================================================*/

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0310U00에 대한 요약 설명입니다.
	/// 이프로그램 새로 만들어야 하지 않을까.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0310U00 : IHIS.Framework.XScreen
	{
		#region [사용자 변수]

		string mbxMsg = string.Empty;
		string mbxCap = string.Empty;
        MessageBoxIcon bntIcon = MessageBoxIcon.Information;
		MultiLayout layBAS0311 = null;		// 환자조회

		bool mIsUpdatable = true;

		#endregion

		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XButton btnGroup;
		private IHIS.Framework.XButton btnHistory;
        private IHIS.Framework.XButton btnCopy;
        private IHIS.Framework.XTextBox txtMent;
		private IHIS.Framework.XLabel xLabel60;
		private IHIS.Framework.XLabel xLabel61;
        private IHIS.Framework.XFindBox fbxSgCode;
        private IHIS.Framework.XFindBox fbxBun_Code1;
		private IHIS.Framework.XFindWorker fwkFind;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.SingleLayout layGroupGubun_Check;
        private IHIS.Framework.SingleLayout layComm;
        private SingleLayout layFind;
        private SingleLayoutItem singleLayoutItem2;
        private XDatePicker dtpSg_Ymd;
        private XDatePicker dtpBulyong_Ymd;
        private XLabel xLabel2;
        private XLabel xLabel3;
        private XLabel xLabel5;
        private XTextBox txtSg_Union;
        private XLabel xLabel13;
        private XLabel xLabel14;
        private XFindBox fbxBun_Code;
        private XDisplayBox dbxBun_Code_Name;
        private XLabel xLabel16;
        private XLabel xLabel19;
        private XCheckBox cbxGroup_Gubun;
        private XLabel xLabel33;
        private XFindBox fbxDanui;
        private XLabel xLabel35;
        private XLabel xLabel36;
        private XLabel xLabel37;
        private XTextBox txtSg_Name;
        private XTextBox txtSg_Name_Kana;
        private XTextBox txtSg_Code;
        private XLabel xLabel11;
        private XLabel xLabel12;
        private XLabel xLabel62;
        private XDisplayBox dbxDanui_Name;
        private XPanel pnlTop1;
        private XEditGrid grdList;
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
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XComboBox cboHubal_Gubun;
        private XComboBox cboBulyong_Sayu;
        private XComboBox cboSuga_Change;
        private XComboBox cboSunab_Qcode_Inp;
        private XComboBox cboSunab_Qcode_Out;
        private XFindBox fbxMarume_Gubun;
        private XDisplayBox dbxMarume_name;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XCheckBox cbxTax_yn;
        private XLabel xLabel4;
        private XEditGridCell xEditGridCell18;
        private XDisplayBox dbxBun_Name;
        private const int maxRowpage = 200;
        private XButton btnUpdateMst;
        private XLabel labelPrivateFee;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XCheckBox cbxPrivateFeeYn;
		
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0310U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            // Create ParamList and ExecuteQuery
            layGroupGubun_Check.ParamList = new List<string>(new String[] { "f_sg_code" });
		    layGroupGubun_Check.ExecuteQuery = ExecuteQueryLayGroupGubunCheck;

            grdList.ParamList = new List<string>(new String[] { "f_bun_code" ,"f_page_number", "f_offset" });
		    grdList.ExecuteQuery = ExecuteQueryGrdListItem;

            this.fwkFind.ParamList = new List<string>(new String[] { "f_find1", "f_code_type" });

            this.layFind.ParamList = new List<string>(new String[] { "f_bun_code", "f_code", "f_col_name" });
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0310U00));
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.cbxPrivateFeeYn = new IHIS.Framework.XCheckBox();
            this.labelPrivateFee = new IHIS.Framework.XLabel();
            this.dbxBun_Name = new IHIS.Framework.XDisplayBox();
            this.fbxBun_Code1 = new IHIS.Framework.XFindBox();
            this.fwkFind = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xLabel61 = new IHIS.Framework.XLabel();
            this.fbxSgCode = new IHIS.Framework.XFindBox();
            this.xLabel60 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnUpdateMst = new IHIS.Framework.XButton();
            this.btnCopy = new IHIS.Framework.XButton();
            this.btnHistory = new IHIS.Framework.XButton();
            this.btnGroup = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dtpSg_Ymd = new IHIS.Framework.XDatePicker();
            this.dtpBulyong_Ymd = new IHIS.Framework.XDatePicker();
            this.txtMent = new IHIS.Framework.XTextBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layGroupGubun_Check = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layComm = new IHIS.Framework.SingleLayout();
            this.layFind = new IHIS.Framework.SingleLayout();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.txtSg_Union = new IHIS.Framework.XTextBox();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.fbxBun_Code = new IHIS.Framework.XFindBox();
            this.dbxBun_Code_Name = new IHIS.Framework.XDisplayBox();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.cbxGroup_Gubun = new IHIS.Framework.XCheckBox();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.fbxDanui = new IHIS.Framework.XFindBox();
            this.xLabel35 = new IHIS.Framework.XLabel();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.xLabel37 = new IHIS.Framework.XLabel();
            this.txtSg_Name = new IHIS.Framework.XTextBox();
            this.txtSg_Name_Kana = new IHIS.Framework.XTextBox();
            this.txtSg_Code = new IHIS.Framework.XTextBox();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel62 = new IHIS.Framework.XLabel();
            this.dbxDanui_Name = new IHIS.Framework.XDisplayBox();
            this.pnlTop1 = new IHIS.Framework.XPanel();
            this.cbxTax_yn = new IHIS.Framework.XCheckBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cboSunab_Qcode_Inp = new IHIS.Framework.XComboBox();
            this.cboSunab_Qcode_Out = new IHIS.Framework.XComboBox();
            this.cboBulyong_Sayu = new IHIS.Framework.XComboBox();
            this.cboSuga_Change = new IHIS.Framework.XComboBox();
            this.cboHubal_Gubun = new IHIS.Framework.XComboBox();
            this.fbxMarume_Gubun = new IHIS.Framework.XFindBox();
            this.dbxMarume_name = new IHIS.Framework.XDisplayBox();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xPanel5.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.pnlTop1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "기록조회.gif");
            this.ImageList.Images.SetKeyName(1, "보험수가조회.ico");
            this.ImageList.Images.SetKeyName(2, "복사.gif");
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.cbxPrivateFeeYn);
            this.xPanel5.Controls.Add(this.labelPrivateFee);
            this.xPanel5.Controls.Add(this.dbxBun_Name);
            this.xPanel5.Controls.Add(this.fbxBun_Code1);
            this.xPanel5.Controls.Add(this.xLabel61);
            this.xPanel5.Controls.Add(this.fbxSgCode);
            this.xPanel5.Controls.Add(this.xLabel60);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = null;
            this.xPanel5.Name = "xPanel5";
            // 
            // cbxPrivateFeeYn
            // 
            this.cbxPrivateFeeYn.AccessibleDescription = null;
            this.cbxPrivateFeeYn.AccessibleName = null;
            resources.ApplyResources(this.cbxPrivateFeeYn, "cbxPrivateFeeYn");
            this.cbxPrivateFeeYn.BackgroundImage = null;
            this.cbxPrivateFeeYn.Name = "cbxPrivateFeeYn";
            this.cbxPrivateFeeYn.UseVisualStyleBackColor = false;
            this.cbxPrivateFeeYn.CheckedChanged += new System.EventHandler(this.cbxPrivateFeeYn_CheckedChanged);
            // 
            // labelPrivateFee
            // 
            this.labelPrivateFee.AccessibleDescription = null;
            this.labelPrivateFee.AccessibleName = null;
            resources.ApplyResources(this.labelPrivateFee, "labelPrivateFee");
            this.labelPrivateFee.Image = null;
            this.labelPrivateFee.Name = "labelPrivateFee";
            // 
            // dbxBun_Name
            // 
            this.dbxBun_Name.AccessibleDescription = null;
            this.dbxBun_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxBun_Name, "dbxBun_Name");
            this.dbxBun_Name.Image = null;
            this.dbxBun_Name.Name = "dbxBun_Name";
            // 
            // fbxBun_Code1
            // 
            this.fbxBun_Code1.AccessibleDescription = null;
            this.fbxBun_Code1.AccessibleName = null;
            resources.ApplyResources(this.fbxBun_Code1, "fbxBun_Code1");
            this.fbxBun_Code1.BackgroundImage = null;
            this.fbxBun_Code1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxBun_Code1.FindWorker = this.fwkFind;
            this.fbxBun_Code1.Name = "fbxBun_Code1";
            this.fbxBun_Code1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBun_Code1_DataValidating);
            this.fbxBun_Code1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSgCode_FindClick);
            // 
            // fwkFind
            // 
            this.fwkFind.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkFind.ExecuteQuery = null;
            this.fwkFind.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkFind.ParamList")));
            this.fwkFind.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkFind.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "sg_code";
            this.findColumnInfo1.ColWidth = 119;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sg_name";
            this.findColumnInfo2.ColWidth = 364;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xLabel61
            // 
            this.xLabel61.AccessibleDescription = null;
            this.xLabel61.AccessibleName = null;
            resources.ApplyResources(this.xLabel61, "xLabel61");
            this.xLabel61.Image = null;
            this.xLabel61.Name = "xLabel61";
            // 
            // fbxSgCode
            // 
            this.fbxSgCode.AccessibleDescription = null;
            this.fbxSgCode.AccessibleName = null;
            resources.ApplyResources(this.fbxSgCode, "fbxSgCode");
            this.fbxSgCode.BackgroundImage = null;
            this.fbxSgCode.FindWorker = this.fwkFind;
            this.fbxSgCode.Name = "fbxSgCode";
            this.fbxSgCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSgCode_DataValidating);
            this.fbxSgCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSgCode1_FindClick);
            // 
            // xLabel60
            // 
            this.xLabel60.AccessibleDescription = null;
            this.xLabel60.AccessibleName = null;
            resources.ApplyResources(this.xLabel60, "xLabel60");
            this.xLabel60.Image = null;
            this.xLabel60.Name = "xLabel60";
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.btnUpdateMst);
            this.xPanel4.Controls.Add(this.btnCopy);
            this.xPanel4.Controls.Add(this.btnHistory);
            this.xPanel4.Controls.Add(this.btnGroup);
            this.xPanel4.Controls.Add(this.btnList);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // btnUpdateMst
            // 
            this.btnUpdateMst.AccessibleDescription = null;
            this.btnUpdateMst.AccessibleName = null;
            resources.ApplyResources(this.btnUpdateMst, "btnUpdateMst");
            this.btnUpdateMst.BackgroundImage = null;
            this.btnUpdateMst.Name = "btnUpdateMst";
            this.btnUpdateMst.Click += new System.EventHandler(this.btnUpdateMst_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleDescription = null;
            this.btnCopy.AccessibleName = null;
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.BackgroundImage = null;
            this.btnCopy.ImageIndex = 2;
            this.btnCopy.ImageList = this.ImageList;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.AccessibleDescription = null;
            this.btnHistory.AccessibleName = null;
            resources.ApplyResources(this.btnHistory, "btnHistory");
            this.btnHistory.BackgroundImage = null;
            this.btnHistory.ImageIndex = 0;
            this.btnHistory.ImageList = this.ImageList;
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.AccessibleDescription = null;
            this.btnGroup.AccessibleName = null;
            resources.ApplyResources(this.btnGroup, "btnGroup");
            this.btnGroup.BackgroundImage = null;
            this.btnGroup.ImageIndex = 1;
            this.btnGroup.ImageList = this.ImageList;
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
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
            // dtpSg_Ymd
            // 
            this.dtpSg_Ymd.AccessibleDescription = null;
            this.dtpSg_Ymd.AccessibleName = null;
            resources.ApplyResources(this.dtpSg_Ymd, "dtpSg_Ymd");
            this.dtpSg_Ymd.BackgroundImage = null;
            this.dtpSg_Ymd.Name = "dtpSg_Ymd";
            // 
            // dtpBulyong_Ymd
            // 
            this.dtpBulyong_Ymd.AccessibleDescription = null;
            this.dtpBulyong_Ymd.AccessibleName = null;
            resources.ApplyResources(this.dtpBulyong_Ymd, "dtpBulyong_Ymd");
            this.dtpBulyong_Ymd.BackgroundImage = null;
            this.dtpBulyong_Ymd.Name = "dtpBulyong_Ymd";
            // 
            // txtMent
            // 
            this.txtMent.AccessibleDescription = null;
            this.txtMent.AccessibleName = null;
            resources.ApplyResources(this.txtMent, "txtMent");
            this.txtMent.BackgroundImage = null;
            this.txtMent.Name = "txtMent";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.txtMent);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // layGroupGubun_Check
            // 
            this.layGroupGubun_Check.ExecuteQuery = null;
            this.layGroupGubun_Check.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layGroupGubun_Check.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGroupGubun_Check.ParamList")));
            this.layGroupGubun_Check.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layGroupGubun_Check_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "count";
            // 
            // layComm
            // 
            this.layComm.ExecuteQuery = null;
            this.layComm.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layComm.ParamList")));
            // 
            // layFind
            // 
            this.layFind.ExecuteQuery = null;
            this.layFind.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layFind.ParamList")));
            this.layFind.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layFind_QueryStarting);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // txtSg_Union
            // 
            this.txtSg_Union.AccessibleDescription = null;
            this.txtSg_Union.AccessibleName = null;
            resources.ApplyResources(this.txtSg_Union, "txtSg_Union");
            this.txtSg_Union.BackgroundImage = null;
            this.txtSg_Union.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSg_Union.Name = "txtSg_Union";
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            // 
            // fbxBun_Code
            // 
            this.fbxBun_Code.AccessibleDescription = null;
            this.fbxBun_Code.AccessibleName = null;
            resources.ApplyResources(this.fbxBun_Code, "fbxBun_Code");
            this.fbxBun_Code.BackgroundImage = null;
            this.fbxBun_Code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxBun_Code.FindWorker = this.fwkFind;
            this.fbxBun_Code.Name = "fbxBun_Code";
            this.fbxBun_Code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBun_Code_DataValidating);
            this.fbxBun_Code.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSgCode_FindClick);
            // 
            // dbxBun_Code_Name
            // 
            this.dbxBun_Code_Name.AccessibleDescription = null;
            this.dbxBun_Code_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxBun_Code_Name, "dbxBun_Code_Name");
            this.dbxBun_Code_Name.Image = null;
            this.dbxBun_Code_Name.Name = "dbxBun_Code_Name";
            // 
            // xLabel16
            // 
            this.xLabel16.AccessibleDescription = null;
            this.xLabel16.AccessibleName = null;
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.Image = null;
            this.xLabel16.Name = "xLabel16";
            // 
            // xLabel19
            // 
            this.xLabel19.AccessibleDescription = null;
            this.xLabel19.AccessibleName = null;
            resources.ApplyResources(this.xLabel19, "xLabel19");
            this.xLabel19.Image = null;
            this.xLabel19.Name = "xLabel19";
            // 
            // cbxGroup_Gubun
            // 
            this.cbxGroup_Gubun.AccessibleDescription = null;
            this.cbxGroup_Gubun.AccessibleName = null;
            resources.ApplyResources(this.cbxGroup_Gubun, "cbxGroup_Gubun");
            this.cbxGroup_Gubun.BackgroundImage = null;
            this.cbxGroup_Gubun.Name = "cbxGroup_Gubun";
            this.cbxGroup_Gubun.UseVisualStyleBackColor = false;
            // 
            // xLabel33
            // 
            this.xLabel33.AccessibleDescription = null;
            this.xLabel33.AccessibleName = null;
            resources.ApplyResources(this.xLabel33, "xLabel33");
            this.xLabel33.Image = null;
            this.xLabel33.Name = "xLabel33";
            // 
            // fbxDanui
            // 
            this.fbxDanui.AccessibleDescription = null;
            this.fbxDanui.AccessibleName = null;
            resources.ApplyResources(this.fbxDanui, "fbxDanui");
            this.fbxDanui.BackgroundImage = null;
            this.fbxDanui.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxDanui.FindWorker = this.fwkFind;
            this.fbxDanui.Name = "fbxDanui";
            this.fbxDanui.Enter += new System.EventHandler(this.fbxSgCode_Enter);
            this.fbxDanui.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBun_Code_DataValidating);
            this.fbxDanui.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSgCode_FindClick);
            // 
            // xLabel35
            // 
            this.xLabel35.AccessibleDescription = null;
            this.xLabel35.AccessibleName = null;
            resources.ApplyResources(this.xLabel35, "xLabel35");
            this.xLabel35.Image = null;
            this.xLabel35.Name = "xLabel35";
            // 
            // xLabel36
            // 
            this.xLabel36.AccessibleDescription = null;
            this.xLabel36.AccessibleName = null;
            resources.ApplyResources(this.xLabel36, "xLabel36");
            this.xLabel36.Image = null;
            this.xLabel36.Name = "xLabel36";
            // 
            // xLabel37
            // 
            this.xLabel37.AccessibleDescription = null;
            this.xLabel37.AccessibleName = null;
            resources.ApplyResources(this.xLabel37, "xLabel37");
            this.xLabel37.Image = null;
            this.xLabel37.Name = "xLabel37";
            // 
            // txtSg_Name
            // 
            this.txtSg_Name.AccessibleDescription = null;
            this.txtSg_Name.AccessibleName = null;
            resources.ApplyResources(this.txtSg_Name, "txtSg_Name");
            this.txtSg_Name.BackgroundImage = null;
            this.txtSg_Name.Name = "txtSg_Name";
            // 
            // txtSg_Name_Kana
            // 
            this.txtSg_Name_Kana.AccessibleDescription = null;
            this.txtSg_Name_Kana.AccessibleName = null;
            resources.ApplyResources(this.txtSg_Name_Kana, "txtSg_Name_Kana");
            this.txtSg_Name_Kana.BackgroundImage = null;
            this.txtSg_Name_Kana.Name = "txtSg_Name_Kana";
            // 
            // txtSg_Code
            // 
            this.txtSg_Code.AccessibleDescription = null;
            this.txtSg_Code.AccessibleName = null;
            resources.ApplyResources(this.txtSg_Code, "txtSg_Code");
            this.txtSg_Code.BackgroundImage = null;
            this.txtSg_Code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSg_Code.Name = "txtSg_Code";
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel62
            // 
            this.xLabel62.AccessibleDescription = null;
            this.xLabel62.AccessibleName = null;
            resources.ApplyResources(this.xLabel62, "xLabel62");
            this.xLabel62.Image = null;
            this.xLabel62.Name = "xLabel62";
            // 
            // dbxDanui_Name
            // 
            this.dbxDanui_Name.AccessibleDescription = null;
            this.dbxDanui_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxDanui_Name, "dbxDanui_Name");
            this.dbxDanui_Name.Image = null;
            this.dbxDanui_Name.Name = "dbxDanui_Name";
            // 
            // pnlTop1
            // 
            this.pnlTop1.AccessibleDescription = null;
            this.pnlTop1.AccessibleName = null;
            resources.ApplyResources(this.pnlTop1, "pnlTop1");
            this.pnlTop1.BackgroundImage = null;
            this.pnlTop1.Controls.Add(this.xLabel37);
            this.pnlTop1.Controls.Add(this.cbxTax_yn);
            this.pnlTop1.Controls.Add(this.xLabel4);
            this.pnlTop1.Controls.Add(this.cboSunab_Qcode_Inp);
            this.pnlTop1.Controls.Add(this.cboSunab_Qcode_Out);
            this.pnlTop1.Controls.Add(this.cboBulyong_Sayu);
            this.pnlTop1.Controls.Add(this.cboSuga_Change);
            this.pnlTop1.Controls.Add(this.cboHubal_Gubun);
            this.pnlTop1.Controls.Add(this.dbxDanui_Name);
            this.pnlTop1.Controls.Add(this.fbxMarume_Gubun);
            this.pnlTop1.Controls.Add(this.xLabel62);
            this.pnlTop1.Controls.Add(this.dtpSg_Ymd);
            this.pnlTop1.Controls.Add(this.dtpBulyong_Ymd);
            this.pnlTop1.Controls.Add(this.xLabel12);
            this.pnlTop1.Controls.Add(this.xLabel11);
            this.pnlTop1.Controls.Add(this.txtSg_Code);
            this.pnlTop1.Controls.Add(this.txtSg_Name_Kana);
            this.pnlTop1.Controls.Add(this.txtSg_Name);
            this.pnlTop1.Controls.Add(this.xLabel36);
            this.pnlTop1.Controls.Add(this.xLabel35);
            this.pnlTop1.Controls.Add(this.fbxDanui);
            this.pnlTop1.Controls.Add(this.xLabel33);
            this.pnlTop1.Controls.Add(this.dbxMarume_name);
            this.pnlTop1.Controls.Add(this.cbxGroup_Gubun);
            this.pnlTop1.Controls.Add(this.xLabel19);
            this.pnlTop1.Controls.Add(this.xLabel16);
            this.pnlTop1.Controls.Add(this.dbxBun_Code_Name);
            this.pnlTop1.Controls.Add(this.fbxBun_Code);
            this.pnlTop1.Controls.Add(this.xLabel14);
            this.pnlTop1.Controls.Add(this.xLabel13);
            this.pnlTop1.Controls.Add(this.txtSg_Union);
            this.pnlTop1.Controls.Add(this.xLabel5);
            this.pnlTop1.Controls.Add(this.xLabel3);
            this.pnlTop1.Controls.Add(this.xLabel2);
            this.pnlTop1.DrawBorder = true;
            this.pnlTop1.Font = null;
            this.pnlTop1.Name = "pnlTop1";
            // 
            // cbxTax_yn
            // 
            this.cbxTax_yn.AccessibleDescription = null;
            this.cbxTax_yn.AccessibleName = null;
            resources.ApplyResources(this.cbxTax_yn, "cbxTax_yn");
            this.cbxTax_yn.BackgroundImage = null;
            this.cbxTax_yn.Name = "cbxTax_yn";
            this.cbxTax_yn.UseVisualStyleBackColor = false;
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // cboSunab_Qcode_Inp
            // 
            this.cboSunab_Qcode_Inp.AccessibleDescription = null;
            this.cboSunab_Qcode_Inp.AccessibleName = null;
            resources.ApplyResources(this.cboSunab_Qcode_Inp, "cboSunab_Qcode_Inp");
            this.cboSunab_Qcode_Inp.BackgroundImage = null;
            this.cboSunab_Qcode_Inp.Name = "cboSunab_Qcode_Inp";
            // 
            // cboSunab_Qcode_Out
            // 
            this.cboSunab_Qcode_Out.AccessibleDescription = null;
            this.cboSunab_Qcode_Out.AccessibleName = null;
            resources.ApplyResources(this.cboSunab_Qcode_Out, "cboSunab_Qcode_Out");
            this.cboSunab_Qcode_Out.BackgroundImage = null;
            this.cboSunab_Qcode_Out.Name = "cboSunab_Qcode_Out";
            // 
            // cboBulyong_Sayu
            // 
            this.cboBulyong_Sayu.AccessibleDescription = null;
            this.cboBulyong_Sayu.AccessibleName = null;
            resources.ApplyResources(this.cboBulyong_Sayu, "cboBulyong_Sayu");
            this.cboBulyong_Sayu.BackgroundImage = null;
            this.cboBulyong_Sayu.Name = "cboBulyong_Sayu";
            // 
            // cboSuga_Change
            // 
            this.cboSuga_Change.AccessibleDescription = null;
            this.cboSuga_Change.AccessibleName = null;
            resources.ApplyResources(this.cboSuga_Change, "cboSuga_Change");
            this.cboSuga_Change.BackgroundImage = null;
            this.cboSuga_Change.Name = "cboSuga_Change";
            // 
            // cboHubal_Gubun
            // 
            this.cboHubal_Gubun.AccessibleDescription = null;
            this.cboHubal_Gubun.AccessibleName = null;
            resources.ApplyResources(this.cboHubal_Gubun, "cboHubal_Gubun");
            this.cboHubal_Gubun.BackgroundImage = null;
            this.cboHubal_Gubun.Name = "cboHubal_Gubun";
            // 
            // fbxMarume_Gubun
            // 
            this.fbxMarume_Gubun.AccessibleDescription = null;
            this.fbxMarume_Gubun.AccessibleName = null;
            resources.ApplyResources(this.fbxMarume_Gubun, "fbxMarume_Gubun");
            this.fbxMarume_Gubun.BackgroundImage = null;
            this.fbxMarume_Gubun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxMarume_Gubun.FindWorker = this.fwkFind;
            this.fbxMarume_Gubun.Name = "fbxMarume_Gubun";
            this.fbxMarume_Gubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBun_Code_DataValidating);
            this.fbxMarume_Gubun.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSgCode_FindClick);
            // 
            // dbxMarume_name
            // 
            this.dbxMarume_name.AccessibleDescription = null;
            this.dbxMarume_name.AccessibleName = null;
            resources.ApplyResources(this.dbxMarume_name, "dbxMarume_name");
            this.dbxMarume_name.Image = null;
            this.dbxMarume_name.Name = "dbxMarume_name";
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell18,
            this.xEditGridCell23,
            this.xEditGridCell24});
            this.grdList.ColPerLine = 3;
            this.grdList.Cols = 3;
            this.grdList.ControlBinding = true;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(16);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.ReadOnly = true;
            this.grdList.Rows = 2;
            this.grdList.ToolTipActive = true;
            this.grdList.ToolTipType = IHIS.Framework.XGridToolTipType.ColumnDesc;
            this.grdList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdList_MouseMove);
            this.grdList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
            this.grdList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdList_GridCellPainting);
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.BindControl = this.txtSg_Code;
            this.xEditGridCell1.CellName = "sg_code";
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.BindControl = this.cbxGroup_Gubun;
            this.xEditGridCell2.CellName = "group_gubun";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.BindControl = this.txtSg_Name;
            this.xEditGridCell3.CellLen = 80;
            this.xEditGridCell3.CellName = "sg_name";
            this.xEditGridCell3.CellWidth = 270;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.txtSg_Name_Kana;
            this.xEditGridCell4.CellLen = 80;
            this.xEditGridCell4.CellName = "sg_name_kana";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.dtpSg_Ymd;
            this.xEditGridCell5.CellName = "sg_ymd";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.BindControl = this.cboSuga_Change;
            this.xEditGridCell6.CellLen = 2;
            this.xEditGridCell6.CellName = "suga_change";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "suga_change_nm_d";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.dtpBulyong_Ymd;
            this.xEditGridCell8.CellName = "bulyong_ymd";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.BindControl = this.cboBulyong_Sayu;
            this.xEditGridCell9.CellLen = 2;
            this.xEditGridCell9.CellName = "bulyong_sayu";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bulyong_sayu_nm_d";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.BindControl = this.fbxDanui;
            this.xEditGridCell11.CellName = "danui";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.dbxDanui_Name;
            this.xEditGridCell12.CellName = "danui_name";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.BindControl = this.fbxBun_Code;
            this.xEditGridCell13.CellLen = 3;
            this.xEditGridCell13.CellName = "bun_code";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.BindControl = this.dbxBun_Code_Name;
            this.xEditGridCell14.CellName = "bun_code_name";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.BindControl = this.fbxMarume_Gubun;
            this.xEditGridCell15.CellLen = 2;
            this.xEditGridCell15.CellName = "marume_gubun";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.BindControl = this.txtSg_Union;
            this.xEditGridCell16.CellName = "sg_union";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.BindControl = this.txtMent;
            this.xEditGridCell17.CellLen = 200;
            this.xEditGridCell17.CellName = "remark";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.BindControl = this.dbxMarume_name;
            this.xEditGridCell19.CellLen = 100;
            this.xEditGridCell19.CellName = "marume_name";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.BindControl = this.cboHubal_Gubun;
            this.xEditGridCell20.CellLen = 1;
            this.xEditGridCell20.CellName = "hubal_drg_yn";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.BindControl = this.cboSunab_Qcode_Out;
            this.xEditGridCell21.CellLen = 2;
            this.xEditGridCell21.CellName = "sunab_qcode_out";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.BindControl = this.cboSunab_Qcode_Inp;
            this.xEditGridCell22.CellLen = 2;
            this.xEditGridCell22.CellName = "sunab_qcode_inp";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.cbxTax_yn;
            this.xEditGridCell18.CellName = "tax_yn";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.BindControl = this.cbxPrivateFeeYn;
            this.xEditGridCell23.CellName = "private_fee_yn";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "modify_flg";
            this.xEditGridCell24.Col = 2;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            // 
            // BAS0310U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlTop1);
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.xPanel4);
            this.Name = "BAS0310U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BAS0310U00_Closing);
            this.Load += new System.EventHandler(this.BAS0310U00_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0310U00_ScreenOpen);
            this.xPanel5.ResumeLayout(false);
            this.xPanel5.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.pnlTop1.ResumeLayout(false);
            this.pnlTop1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            this.grdList.SavePerformer = new XSavePeformer(this);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
            this.fbxSgCode.Focus();
		}
		private void PostLoad()
		{	
			if (OpenParam != null)
			{
				fbxSgCode.SetEditValue(OpenParam["sg_code"].ToString());
				fbxSgCode.AcceptData();
				
				string system = this.Opener.ToString().Split('.')[1];

				this.mIsUpdatable = false;

				this.btnList.PerformClick(FunctionType.Query);

			}
            string userSql = @" SELECT '','なし'
                                  FROM DUAL
                                  UNION
                                SELECT CODE, CODE_NAME 
                                 FROM BAS0102 
                                WHERE HOSP_CODE = :f_hosp_code 
                                  AND CODE_TYPE = :f_code_type
                                  ORDER BY 1";
            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            layoutCombo.InitializeLayoutTable();
//            layoutCombo.QuerySQL = userSql;
            layoutCombo.ParamList = new List<string>(new String[] { "f_code_type" });
		    layoutCombo.ExecuteQuery = ExecuteQueryLayoutCombo;
            layoutCombo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layoutCombo.SetBindVarValue("f_code_type", "HUBAL_DRG_GUBUN");
            if (layoutCombo.QueryLayout(false) && layoutCombo.RowCount > 0)
            {
                this.cboHubal_Gubun.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
                this.cboHubal_Gubun.SetDataValue(null); 
            }
            layoutCombo.SetBindVarValue("f_code_type", "BULYONG_SAYU");
            if (layoutCombo.QueryLayout(false) && layoutCombo.RowCount > 0)
            {
                this.cboBulyong_Sayu.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
                this.cboBulyong_Sayu.SetDataValue(null); 
            }
            //layoutCombo.SetBindVarValue("f_code_type", "SG_GUBUN");
            //if (layoutCombo.QueryLayout(false) && layoutCombo.RowCount > 0)
            //{
            //    this.cboTensu_Gubun.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
            //}
            layoutCombo.SetBindVarValue("f_code_type", "SUGA_CHANGE");
            if (layoutCombo.QueryLayout(false) && layoutCombo.RowCount > 0)
            {
                this.cboSuga_Change.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
                this.cboSuga_Change.SetDataValue(null); 
            }
            layoutCombo.SetBindVarValue("f_code_type", "SUNAB_CONV_CODE");
            if (layoutCombo.QueryLayout(false) && layoutCombo.RowCount > 0)
            {
                this.cboSunab_Qcode_Out.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
                this.cboSunab_Qcode_Inp.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
                this.cboSunab_Qcode_Out.SetDataValue(null);
                this.cboSunab_Qcode_Inp.SetDataValue(null); 
            }
		}		
		#endregion

		#region 그리드에 리스트가 없을 때 Protect
		private void Control_Protect()
		{
			if (grdList.RowCount <=0) 
			{
				foreach(object obj in pnlTop1.Controls)
				{

					if(obj.GetType().Name == "XTextBox")
					{
						((XTextBox)obj).Protect = true;
					}
				}
			}
			else
			{
                //foreach(object obj in pnlTop1.Controls)
                //{
                //    if(obj.GetType().Name == "XTextBox")
                //    {
                //        ((XTextBox)obj).Protect = false;
                //    }

                //}
			}
		}
		#endregion

		private void BAS0310U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
//			if (OpenParam != null)
//			{
//				fbxSgCode.SetEditValue(OpenParam["sg_code"].ToString());
//				fbxSgCode.AcceptData();
//				
//				string system = this.Opener.ToString().Split('.')[1];
//
//				if (system != "BASS" && system != "INP" && system != "OUTS" && system != "BIL")
//				{
//					this.mIsUpdatable = false;
//				}
//
//				this.btnList.PerformClick(FunctionType.Query);
//			}		
		}

		// Form Load
		private void BAS0310U00_Load(object sender, System.EventArgs e)
		{
			Control_Protect();

            // Do not show Private Fee for SuperAdmin
            if (UserInfo.AdminType == AdminType.SuperAdmin) 
            {
                labelPrivateFee.Visible = false;
                cbxPrivateFeeYn.Visible = false;
            }
		}

		#region  조회
		private void All_Query()
		{
			if (!this.grdList.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg, "", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1, MessageBoxIcon.Error);
				return;
			}
            //Control_Protect();
		}
		#endregion

		#region Find 클릭
		private void fbxSgCode1_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{			
			e.Cancel = true;
			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("sg_ymd", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			openParams.Add("search_word",  fbxSgCode.GetDataValue().ToString());
            XScreen.OpenScreenWithParam(this, "BASS", "BAS0311Q01", ScreenOpenStyle.ResponseSizable, openParams);
		}
		private void fbxSgCode_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
            XFindBox findBox = (XFindBox)sender;
            this.MakeFindWorker(findBox.Name);
		}
		#endregion
		#region MakeFindWorker
		//각각의 컨트롤(파인드박스)에 적합한 파인드 워커로 셋팅
		private bool MakeFindWorker(string aCtrName)
		{	
			bool result = false;
            //점수코드참조 SQL문
            string findQuery2 = @"SELECT SG_CODE
                                       , SG_NAME
                                    FROM BAS0310
                                   WHERE HOSP_CODE = :f_hosp_code 
                                     AND (  SG_CODE  LIKE :f_find1 || '%'
                                         OR SG_NAME  LIKE :f_find1 || '%')
                                     ORDER BY SG_CODE";
            //점수코드참조 SQL문
            string findQuery3 = @"SELECT A.BUN_CODE
                                       , A.BUN_NAME
                                    FROM BAS0230 A
                                   WHERE A.HOSP_CODE = :f_hosp_code 
                                     AND A.BUN_YMD  = (SELECT MAX(B.BUN_YMD)
                                                         FROM BAS0230 B
                                                        WHERE B.HOSP_CODE = A.HOSP_CODE 
                                                          AND B.BUN_CODE  = A.BUN_CODE)
                                     AND (  A.BUN_CODE LIKE :f_find1 || '%'
                                         OR A.BUN_NAME LIKE :f_find1 || '%')
                                   ORDER BY A.BUN_CODE";
            string findQuery4 = @"SELECT CODE
                                     , CODE_NAME
                                  FROM BAS0102
                                 WHERE HOSP_CODE = :f_hosp_code 
                                   AND CODE_TYPE = :f_code_type
                                 ORDER BY CODE";
            string findQuery5 = @"SELECT CODE
                                         , CODE_NAME
                                      FROM OCS0132
                                     WHERE HOSP_CODE = :f_hosp_code 
                                       AND CODE_TYPE = 'ORD_DANUI'
                                       AND(CODE      LIKE :f_find1 || '%'
                                        OR CODE_NAME LIKE :f_find1 || '%' )
                                     ORDER BY CODE";
            
			switch ( aCtrName )
			{
				// 점수코드
				case "fbxSgCode":					
					this.fwkFind.FormText = Resource.TEXT1;
//					this.fwkFind.InputSQL = findQuery2;
			        this.fwkFind.ExecuteQuery = ExecuteQueryMakeFindWorker2;
					this.fwkFind.ColInfos[0].HeaderText = Resource.TEXT2;
                    this.fwkFind.ColInfos[1].HeaderText = Resource.TEXT3;
                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					result = true;
					break;
                // 점수변경
                case "fbxSuga_Change":
                    this.fwkFind.FormText = Resource.TEXT4;
//                    this.fwkFind.InputSQL = findQuery4;
                    this.fwkFind.ExecuteQuery = ExecuteQueryMakeFindWorker4;
                    this.fwkFind.ColInfos[0].HeaderText = Resource.TEXT5;
                    this.fwkFind.ColInfos[1].HeaderText = Resource.TEXT6;
                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkFind.SetBindVarValue("f_code_type", "SUGA_CHANGE");
                    result = true;
                    break;
                // 점수불용
                case "fbxBulyong_Sayu":
                    this.fwkFind.FormText = Resource.TEXT7;
//                    this.fwkFind.InputSQL = findQuery4;
			        this.fwkFind.ExecuteQuery = ExecuteQueryMakeFindWorker4;
                    this.fwkFind.ColInfos[0].HeaderText = Resource.TEXT8;
                    this.fwkFind.ColInfos[1].HeaderText = Resource.TEXT9;
                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkFind.SetBindVarValue("f_code_type", "BULYONG_SAYU");
                    result = true;
                    break;
					// 분류코드
				case "fbxBun_Code1":
                    this.fwkFind.FormText = Resource.TEXT10;
//                    this.fwkFind.InputSQL = findQuery3;
			        this.fwkFind.ExecuteQuery = ExecuteQueryMakeFindWorker3;
					this.fwkFind.ColInfos[0].HeaderText = Resource.TEXT11;
                    this.fwkFind.ColInfos[1].HeaderText = Resource.TEXT12;
                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					result = true;
					break;
					// 분류코드
				case "fbxBun_Code":
                    this.fwkFind.FormText = Resource.TEXT10;
//                    this.fwkFind.InputSQL = findQuery3;
                    this.fwkFind.ExecuteQuery = ExecuteQueryMakeFindWorker3;
					this.fwkFind.ColInfos[0].HeaderText = Resource.TEXT11;
                    this.fwkFind.ColInfos[1].HeaderText = Resource.TEXT12;
                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					result = true;
					break;
                    // 단위코드
                case "fbxDanui":
//                    this.fwkFind.InputSQL = findQuery5;
			        this.fwkFind.ExecuteQuery = ExecuteQueryMakeFindWorker5;
                    this.fwkFind.FormText = Resource.TEXT13;
                    this.fwkFind.ColInfos[0].HeaderText = Resource.TEXT14;
                    this.fwkFind.ColInfos[1].HeaderText = Resource.TEXT15;
                    //this.fwkFind.ColInfos.Clear();
                    //this.fwkFind.ColInfos.Add("gwa", "単位コード", FindColType.String, 100, 0, true, FilterType.InitYes);
                    //this.fwkFind.ColInfos.Add("gwa_name", "単位名", FindColType.String, 200, 0, true, FilterType.InitYes);
                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					result = true;
					break;
                    // 포괄코드
				case "fbxMarume_Gubun":
//                    this.fwkFind.InputSQL = @"SELECT A.CODE
//                                                    ,A.CODE_NAME
//                                                FROM BAS0102 A
//                                               WHERE A.HOSP_CODE    = :f_hosp_code 
//                                                 AND A.CODE_TYPE    = :f_code_type
//                                                 AND(A.CODE      LIKE :f_find1 || '%'
//                                                  OR A.CODE_NAME LIKE :f_find1 || '%' )
//                                             ORDER BY A.CODE";

                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkFind.SetBindVarValue("f_code_type", "POGWAL_GUBUN");
			        this.fwkFind.ExecuteQuery = ExecuteQueryFindWorkerFbxMarumeGubun;
                    this.fwkFind.FormText = Resource.TEXT16;
                    this.fwkFind.ColInfos[0].HeaderText = Resource.TEXT17;
                    this.fwkFind.ColInfos[1].HeaderText = Resource.TEXT18;
                    //this.fwkFind.ColInfos.Clear();
                    //this.fwkFind.ColInfos.Add("gwa", "まるめコード", FindColType.String, 100, 0, true, FilterType.InitYes);
                    //this.fwkFind.ColInfos.Add("gwa_name", "まるめ名", FindColType.String, 380, 0, true, FilterType.InitYes);
                    result = true;
					break;
                // 외래수납적용코드
                case "fbxSunab_Qcode_Out":
                    this.fwkFind.FormText = Resource.TEXT19;
//                    this.fwkFind.InputSQL = findQuery4;
                    this.fwkFind.ExecuteQuery = ExecuteQueryMakeFindWorker4;
                    this.fwkFind.ColInfos[0].HeaderText = Resource.TEXT20;
                    this.fwkFind.ColInfos[1].HeaderText = Resource.TEXT21;
                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkFind.SetBindVarValue("f_code_type", "SUNAB_CONV_CODE");
                    result = true;
                    break;
                // 입원수납적용코드
                case "fbxSunab_Qcode_Inp":
                    this.fwkFind.FormText = Resource.TEXT22;
//                    this.fwkFind.InputSQL = findQuery4;
                    this.fwkFind.ExecuteQuery = ExecuteQueryMakeFindWorker4;
                    this.fwkFind.ColInfos[0].HeaderText = Resource.TEXT23;
                    this.fwkFind.ColInfos[1].HeaderText = Resource.TEXT24;
                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkFind.SetBindVarValue("f_code_type", "SUNAB_CONV_CODE");
                    result = true;
                    break;
				default:
					XMessageBox.Show("Control Not Found","ERROR");
					result = false;
					break;
			}
			return result;
		}
		#endregion

		#region FindBox에 포커스가 갈때 Validation 체크
		private void fbxSgCode_Enter(object sender, System.EventArgs e)
		{
			//			XFindBox findBox = (XFindBox) sender;
			//			this.MakeValService(findBox);			
		}
		#endregion
		
		#region [    Validating 관련  ]

		private void fbxBun_Code_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			Control Ctl = (Control) sender;
			//Message처리
			string mbxMsg = "", mbxCap = "";

            mFindName = Ctl.Name;

			this.layFind.LayoutItems.Clear();
			
			switch ( Ctl.Name )
			{
				case "fbxBun_Code":
					if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
					{
						dbxBun_Code_Name.SetDataValue("");
						return;
					}
//					this.layFind.QuerySQL = @"SELECT A.BUN_NAME 
//                                                FROM BAS0230 A 
//                                               WHERE A.HOSP_CODE = :f_hosp_code 
//                                                 AND A.BUN_CODE  = :f_bun_code
//                                                 AND A.BUN_YMD = (SELECT MAX(B.BUN_YMD) 
//                                                                    FROM BAS0230 B 
//                                                                   WHERE B.HOSP_CODE = A.HOSP_CODE
//                                                                     AND B.BUN_CODE = A.BUN_CODE  ) ";
                    this.layFind.LayoutItems.Add("dbxBun_Code_Name");
                    this.layFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layFind.SetBindVarValue("f_bun_code", e.DataValue.ToString().Trim());
                    this.layFind.SetBindVarValue("f_col_name", "fbxBun_Code");
                    this.layFind.ExecuteQuery = ExecuteQueryFbxBunCodeDataValidating;
					if(layFind.QueryLayout())
					{
						dbxBun_Code_Name.SetEditValue(layFind.GetItemValue("dbxBun_Code_Name").ToString());
						dbxBun_Code_Name.AcceptData();
					}
					else
					{
						mbxMsg = Resource.TEXT25;
						mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
					}
					break;
					// 약제점수단위
                case "fbxDanui":
					if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
					{
						dbxDanui_Name.SetDataValue("");
						if (grdList.CurrentRowNumber < 0 ) return;
						grdList.SetItemValue(grdList.CurrentRowNumber, "danui_name", "");
                        return;
					}
					if (e.DataValue.ToString() == "000")
					{
						dbxDanui_Name.SetDataValue("");
						if (grdList.CurrentRowNumber < 0 ) return;
                        grdList.SetItemValue(grdList.CurrentRowNumber, "danui_name", "");
						return;
					}

//					this.layFind.QuerySQL = @"SELECT CODE_NAME 
//                                                FROM OCS0132 
//                                               WHERE HOSP_CODE = :f_hosp_code
//                                                 AND CODE_TYPE = 'ORD_DANUI' 
//                                                 AND CODE      = :f_code   ";

                    this.layFind.LayoutItems.Add("danui_name");
                    this.layFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layFind.SetBindVarValue("f_code", e.DataValue.ToString().Trim());
                    this.layFind.SetBindVarValue("f_col_name", "fbxDanui");
                    this.layFind.ExecuteQuery = ExecuteQueryFbxBunCodeDataValidating;
                    if (layFind.QueryLayout())
					{
                        dbxDanui_Name.SetDataValue(layFind.GetItemValue("danui_name").ToString());
						if (grdList.CurrentRowNumber < 0 ) return;
                        grdList.SetItemValue(grdList.CurrentRowNumber, "danui_name", layFind.GetItemValue("danui_name").ToString());
					}
                    if (this.layFind.GetItemValue("danui_name").ToString() == "")
					{
						mbxMsg = Resource.TEXT26;
						mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
					}
					break;
                case "fbxMarume_Gubun":
                    if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
                    {
                        dbxMarume_name.SetDataValue("");
                        return;
                    }
                    layComm.Reset();
//                    layComm.QuerySQL = @"SELECT CODE_NAME
//                                             , SORT_KEY
//                                          FROM BAS0102
//                                         WHERE HOSP_CODE = :f_hosp_code 
//                                           AND CODE_TYPE = :f_code_type
//                                           AND CODE      = :f_code";
                    layComm.ParamList = new List<string>(new String[] { "f_code", "f_col_name" });
                    layComm.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layComm.SetBindVarValue("f_code_type", "POGWAL_GUBUN");
                    layComm.SetBindVarValue("f_code", e.DataValue.ToString());
                    this.layComm.SetBindVarValue("f_col_name", "fbxMarume_Gubun");
                    this.layComm.ExecuteQuery = ExecuteQueryFbxBunCodeDataValidating;
                    layComm.LayoutItems.Clear();
                    layComm.LayoutItems.Add("code_name");
                    if (layComm.QueryLayout())
                    {
                        if (TypeCheck.IsNull(layComm.GetItemValue("code_name").ToString()) == true)
                        {
                            e.Cancel = true;
                            return;
                        }
                        dbxMarume_name.SetDataValue(layComm.GetItemValue("code_name").ToString());
                    }
                    else
                    {
                        mbxMsg = Resource.TEXT27;
                        mbxCap = Resource.TEXT28;
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        return;
                    }
                    break;	
				default:
					//XMessageBox.Show("Validation Control Not Found","ERROR");
					break;
			}		
		}
		#endregion

		#region Validation 서비스 호출전에 InValue를 셋팅
        string mFindName = "";
        private void layFind_QueryStarting(object sender, CancelEventArgs e)
		{
			string bindVal = "";

            switch (this.mFindName)
			{
                case "fbxSgCode":                               // 점수코드
					bindVal = this.fbxSgCode.Text;
					break;
                case "fbxBun_Code1":                            // 분류코드
					bindVal = this.fbxBun_Code1.Text;
					break;
				case "fbxBun_Code":								// 분류코드
					bindVal = this.fbxBun_Code.Text;
					break;
                case "fbxDanui":                                 // 약제점수단위
					bindVal = this.fbxDanui.Text;
					break;
				default:
                    //XMessageBox.Show("벨리데이션 아이템을 찾을 수 없음","에러");
					break;
			}
			this.layFind.SetBindVarValue("f_code",bindVal);			
		}
		#endregion

		#region 그리드 포커스 이동시
		private void grdList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (!layGroupGubun_Check.QueryLayout())
			{
				XMessageBox.Show(Service.ErrFullMsg, "", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1, MessageBoxIcon.Error);
				return;
			}
			if (layGroupGubun_Check.GetItemValue("count").ToString() != "0")
			{
				btnGroup.ImageIndex = 1;
			}
			else
			{
				btnGroup.ImageIndex = -1;
			}
            //Control_Protect();
            if (this.grdList.GetRowState(e.CurrentRow) == DataRowState.Added)
            {
                this.txtSg_Code.Protect = false;
                this.dtpSg_Ymd.Protect = false;
            }
            else
            {                
                this.txtSg_Code.Protect = true;
                this.dtpSg_Ymd.Protect = true;
            }

            if (UserInfo.AdminType == AdminType.Admin)
            {
                string modifyFlg = grdList.GetItemString(e.CurrentRow, "modify_flg");
                if (modifyFlg == "R")
                {
                    cbxPrivateFeeYn.Enabled = false;
                    txtSg_Code.ReadOnly = true;
                    cboSuga_Change.Enabled = false;
                    txtSg_Union.ReadOnly = true;
                    dtpBulyong_Ymd.ReadOnly = true;
                    cboBulyong_Sayu.Enabled = false;
                    txtSg_Name.ReadOnly = true;
                    txtSg_Name_Kana.ReadOnly = true;
                    cboHubal_Gubun.Enabled = false;
                    cbxGroup_Gubun.Enabled = false;

                    // https://sofiamedix.atlassian.net/browse/MED-10706
                    //fbxDanui.ReadOnly = true;
                    //fbxBun_Code.ReadOnly = true;
                    //fbxMarume_Gubun.ReadOnly = true;
                    fbxDanui.Enabled = false;
                    fbxBun_Code.Enabled = false;
                    fbxMarume_Gubun.Enabled = false;

                    // https://sofiamedix.atlassian.net/browse/MED-10707
                    //cboSunab_Qcode_Out.Enabled = false;
                    cboSunab_Qcode_Out.Enabled = true;
                    // cboSunab_Qcode_Inp.Enabled = false;
                    cboSunab_Qcode_Inp.Enabled = true;

                    cbxTax_yn.Enabled = false;
                    txtMent.ReadOnly = true;

                    btnList.SetEnabled(FunctionType.Delete, false);
                }
                else
                {
                    cbxPrivateFeeYn.Enabled = true;
                    txtSg_Code.ReadOnly = false;
                    cboSuga_Change.Enabled = true;
                    txtSg_Union.ReadOnly = false;
                    dtpBulyong_Ymd.ReadOnly = false;
                    cboBulyong_Sayu.Enabled = true;
                    txtSg_Name.ReadOnly = false;
                    txtSg_Name_Kana.ReadOnly = false;
                    cboHubal_Gubun.Enabled = true;
                    cbxGroup_Gubun.Enabled = true;
                    cboSunab_Qcode_Out.Enabled = true;
                    cbxTax_yn.Enabled = true;
                    cboSunab_Qcode_Inp.Enabled = true;
                    txtMent.ReadOnly = false;

                    // https://sofiamedix.atlassian.net/browse/MED-10839
                    //fbxDanui.ReadOnly = false;
                    //fbxBun_Code.ReadOnly = false;
                    //fbxMarume_Gubun.ReadOnly = false;
                    fbxDanui.Enabled = true;
                    fbxBun_Code.Enabled = true;
                    fbxMarume_Gubun.Enabled = true;

                    btnList.SetEnabled(FunctionType.Delete, true);
                }
            }
		}
		#endregion
	

		#region [    버튼 리스트 관련    ]
        bool boolSave = true;

		#region 버튼리스트 클릭
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
            mbxMsg = string.Empty;
            mbxCap = string.Empty;
            this.boolSave = true;

            //if (e.Func == FunctionType.Insert)
            //{
            //    if (this.mIsUpdatable == false)
            //    {
            //        XMessageBox.Show( (NetInfo.Language == LangMode.Ko ? "현재의 시스템에서는 입력이 불가능 합니다." : Resource.TEXT29)
            //            , (NetInfo.Language == LangMode.Ko ? "입력불가" : "入力不可能"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        e.IsSuccess = false;
            //        e.IsBaseCall = false;

            //        return;
            //    }
            //    //if (Validateion_Check() != 0)
            //    //{
            //    //    e.IsBaseCall = false;
            //    //    this.boolSave = false;
            //    //}
            //}
			//else
            if (e.Func == FunctionType.Delete)
			{
				if (this.mIsUpdatable == false)
				{
					XMessageBox.Show( (Resource.TEXT30)
						, Resource.XMsg0001, MessageBoxButtons.OK, MessageBoxIcon.Error);

					e.IsBaseCall = false;
					e.IsSuccess = false;

					return;
				}
                if (txtSg_Code.GetDataValue().ToString() != ""){
				    string msg = (Resource.TEXT31+" [ " + txtSg_Code.GetDataValue().ToString() + " ]"+Resource.TEXT32);
				    string cpt = (Resource.TEXT33);
    				
				    if (XMessageBox.Show(msg, cpt, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.No)
				    {
					    e.IsBaseCall = false;
				    }
                }
			}
			else if (e.Func == FunctionType.Update)
			{
				if (this.mIsUpdatable == false)
				{
                    mbxMsg = Resource.MSG001_MSG;
                    mbxCap = Resource.MSG001_CAP;
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					e.IsBaseCall = false;
					e.IsSuccess = false;
					return;
				}
                //if (grdList.RowCount <= 0)
                //{
                //    mbxMsg = (NetInfo.Language == LangMode.Ko ? "저장할 내용이 없습니다."
                //        : "保存する内容がありません。");
                //    mbxCap = (NetInfo.Language == LangMode.Ko ? "확인" : "確認");
                //    e.IsBaseCall = false;
                //    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //this.AcceptData();
                //if (Validateion_Check() != 0)
                //{
                //    e.IsBaseCall = false;
                //    this.boolSave = false;
                //    return;
                //}

//                if (this.grdList.SaveLayout())
                if (GrdListSaveLayout())
                {
                    mbxMsg = Resource.MSG003_MSG;
                    mbxCap = Resource.MSG003_CAP;
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnList.PerformClick(FunctionType.Query);
                }
                else
                {
                    this.boolSave = false;
                    if (mbxMsg == "")
                    {
                        //mbxMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resource.TEXT38;
                        //mbxMsg += "\r\n" + Service.ErrFullMsg;
                        //mbxCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Resource.TEXT39;
                        //bntIcon = MessageBoxIcon.Error;
                        mbxMsg = Resource.MSG001_MSG;
                        mbxCap = Resource.MSG001_CAP;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.OK, bntIcon);
                    }
                   
                }
			}
			else if (e.Func == FunctionType.Query)
			{
				e.IsBaseCall = false;
				All_Query();
			}			
			Control_Protect();
		}
		#endregion

		#region 버튼 리스트에서 클릭 후 이벤트
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			if (e.Func == FunctionType.Reset)
			{
				Control_Protect();
				fbxSgCode.Focus();
                this.dtpSg_Ymd.Protect = false;
			}
			else if (e.Func == FunctionType.Insert)
			{
				if (e.IsSuccess == true)
				{
					Control_Protect();
					txtSg_Code.Focus();
				}
			}
		}
		#endregion

		#endregion
		#region 그룹 버튼 클릭(그룹점수등록화면)
		private void btnGroup_Click(object sender, System.EventArgs e)
		{
			if (cbxGroup_Gubun.Checked == true)
			{
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("BASS", "BAS0312U00");

				if (aScreen == null)
				{              
					string sg_code = this.txtSg_Code.GetDataValue().ToString().Trim();
					string sg_ymd = this.dtpSg_Ymd.GetDataValue().ToString();
                    string sg_code_name = this.txtSg_Name.GetDataValue().ToString();
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sg_code", sg_code);
					openParams.Add( "sg_ymd", sg_ymd);
                    openParams.Add("sg_code_name", sg_code_name);
					if (sg_code.Trim().Length > 0)
					{
						//XScreen.OpenScreen(this, "BAS", "BAS0312U00", ScreenOpenStyle.PopUpFixed);
						XScreen.OpenScreenWithParam(this,"BASS", "BAS0312U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
					}
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

		#region 복사 버튼 클릭
		private void btnCopy_Click(object sender, System.EventArgs e)
		{
			int rowno;
			if (grdList.RowCount <= 0) return;
			if (grdList.CurrentRowNumber < 0) return;

			int currow = grdList.CurrentRowNumber;

			if (TypeCheck.IsNull(grdList.GetItemString(currow, "sg_code").ToString()) == true)
			{
				return;
			}
			this.grdList.RowFocusChanged -= new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
			rowno = grdList.InsertRow();
			grdList.SetFocusToItem(currow, "sg_code");
			foreach(XEditGridCell cell in grdList.CellInfos)
			{
				//XMessageBox.Show(grdList.GetItemValue(currow, cell.CellName).ToString());
				grdList.SetItemValue(rowno, cell.CellName, grdList.GetItemValue(currow, cell.CellName));
			}
			this.grdList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
			//int newrow = grdList.CurrentRowNumber;
			grdList.SetFocusToItem(rowno, "sg_code");
			txtSg_Code.SetEditValue("");
			txtSg_Code.AcceptData();
			txtSg_Code.Focus();
			mbxMsg = Resource.TEXT40;
			mbxCap = Resource.TEXT28;
			XMessageBox.Show(mbxMsg, mbxCap);
		}
		#endregion

		#region History 클릭
		private void btnHistory_Click(object sender, System.EventArgs e)
		{
			IHIS.Framework.IXScreen aScreen;

			aScreen = XScreen.FindScreen("BASS", "BAS0311U00");

			if (aScreen == null)
			{              
				string sg_code = this.txtSg_Code.GetDataValue().ToString().Trim();
				
				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add( "sg_code", sg_code);

				if (sg_code.Trim().Length > 0)
				{
					//XScreen.OpenScreen(this, "BAS", "BAS0312U00", ScreenOpenStyle.PopUpFixed);
					XScreen.OpenScreenWithParam(this,"BASS", "BAS0311U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
				}
			}
			else
			{
				((XScreen)aScreen).Activate();
			}
		
		}
		#endregion

		#region 마우스 무브시 튤팁을 보이기 위함
		private void grdList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			XEditGrid edg = (XEditGrid)sender;

			if (edg.RowCount <= 0) return;

			XCell ac = edg.CellAtPoint(new Point(e.X,e.Y));

			if (ac == null) return;
   
			string colName = string.Empty;

			switch (ac.Col)
			{
				case 0:
					colName = "sg_name";
					ac.ToolTipText = edg.GetItemString(ac.Row-1,colName).ToString();
					break;
				default:
					break;
			}  
		}
		#endregion

		private void fbxSgCode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            if (TypeCheck.IsNull(e.DataValue.ToString()) == true
                && TypeCheck.IsNull(fbxBun_Code1.GetDataValue().ToString()) == true)
            {
                return;
            }
            if (e.DataValue.Length > this.fbxSgCode.MaxLength)
            {
                this.SetMsg(Resource.TEXT41+ this.fbxSgCode.MaxLength.ToString() +Resource.TEXT42, MsgType.Error);
                e.Cancel = true;
                return;
            }
            this.btnList.PerformClick(FunctionType.Query);
		}

        #region 전각 반각 변경

        private string LoadKatakanaFull(string aText)
        {
            string cmd = " SELECT FN_ADM_CONVERT_KATAKANA_FULL ('" + aText + "' )" +
                         "   FROM DUAL ";

            object retValue = Service.ExecuteScalar(cmd);

            if (retValue == null || TypeCheck.IsNull(retValue))
                return "";

            return retValue.ToString();
        }
        #endregion

		private void fbxBun_Code1_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{

            XFindBox control = (XFindBox)sender;
            SingleLayoutItem sli = new SingleLayoutItem();
            this.layFind.LayoutItems.Clear();

            switch (control.Name)
            {
                case "fbxBun_Code1":
//                    this.layFind.QuerySQL = @"SELECT A.BUN_NAME 
//                                                FROM BAS0230 A 
//                                               WHERE A.HOSP_CODE = :f_hosp_code 
//                                                 AND A.BUN_CODE  = :f_bun_code
//                                                 AND A.BUN_YMD = (SELECT MAX(B.BUN_YMD) 
//                                                                    FROM BAS0230 B 
//                                                                   WHERE B.HOSP_CODE = A.HOSP_CODE
//                                                                     AND B.BUN_CODE = A.BUN_CODE  ) ";
                    sli.BindControl = this.dbxBun_Name;
                    this.layFind.LayoutItems.Add(sli);
                    this.layFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layFind.SetBindVarValue("f_bun_code", e.DataValue.ToString());
                    this.layFind.SetBindVarValue("f_col_name", "fbxBun_Code");
                    this.layFind.ExecuteQuery = ExecuteQueryFbxBunCodeDataValidating;
                    this.layFind.QueryLayout();
                    break;
            }
            if (TypeCheck.IsNull(e.DataValue.ToString()) == true
                && TypeCheck.IsNull(fbxSgCode.GetDataValue().ToString()) == true)
            {
                return;
            }
            this.btnList.PerformClick(FunctionType.Query);
        }

		#region Command
		public override object Command(string command, CommonItemCollection commandParam)
		{
			string point = string.Empty;
			switch (command)
			{
				case "BAS0311Q00":
                case "BAS0311Q01":
					layBAS0311 = (MultiLayout)commandParam["BAS0311"];
					if (layBAS0311.RowCount > 0)
					{
						fbxSgCode.SetEditValue(layBAS0311.GetItemString(0, "sg_code"));
						fbxSgCode.AcceptData();
					}
					break;
			}
			return base.Command (command, commandParam);
		}
		#endregion

		private void grdList_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			DateTime sysDate = DateTime.Parse(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
			
			if (this.grdList.GetItemString(e.RowNumber, "bulyong_ymd") != "")
			{
				DateTime bulyongDate = DateTime.Parse(this.grdList.GetItemString(e.RowNumber, "bulyong_ymd"));

				if (sysDate >= bulyongDate )
				{
					e.ForeColor = Color.Red;
				}
			}

		}
        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            // TODO comment: not use LoadKatakanaFull
//            this.grdList.SetBindVarValue("f_sg_code", "%" + TypeCheck.NVL(this.LoadKatakanaFull(this.fbxSgCode.GetDataValue().ToString()) + "%", "%").ToString());
            this.grdList.SetBindVarValue("f_bun_code", this.fbxBun_Code1.GetDataValue());            
        }
        private void layGroupGubun_Check_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layGroupGubun_Check.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layGroupGubun_Check.SetBindVarValue("f_sg_code",this.grdList.GetItemString(this.grdList.CurrentRowNumber, "sg_code"));
        }
        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0310U00 parent = null;

            public XSavePeformer(BAS0310U00 parent)
            {
                this.parent = parent;
            }
            #region 입력값 체크
            private bool Validateion_Check(BindVarCollection BindVarList)
            {
                if (TypeCheck.IsNull(BindVarList["f_sg_ymd"].VarValue) == true)
                {
                    parent.mbxMsg = (NetInfo.Language == LangMode.Ko ? "적용개시일을 입력하십시오"
                        : Resource.TEXT43);
                    
                    return false;
                }
                if (BindVarList["f_sg_code"].VarValue.Trim().Length == 0)
                {
                    parent.mbxMsg = (NetInfo.Language == LangMode.Ko ? "점수코드를 입력하십시오"
                        : Resource.TEXT44);
                    return false;
                }
                if (BindVarList["f_sg_name"].VarValue.Trim().Length == 0)
                {
                    parent.mbxMsg = (NetInfo.Language == LangMode.Ko ? "점수명을 입력하십시오"
                        : Resource.TEXT45);
                    return false;
                }
                if (BindVarList["f_sg_name_kana"].VarValue.Trim().Length == 0)
                {
                    parent.mbxMsg = (NetInfo.Language == LangMode.Ko ? "영문점수명을 입력하십시오"
                        : Resource.TEXT46);
                    return false;
                }
                if (BindVarList["f_bun_code"].VarValue.Trim().Length == 0)
                {
                    parent.mbxMsg = (NetInfo.Language == LangMode.Ko ? "분류코드를 입력하십시오"
                        : Resource.TEXT47);
                    return false;
                }
                return true; ;
            }
            #endregion

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                    case DataRowState.Modified:
                        if (!Validateion_Check(item.BindVarList))
                        {
                            parent.mbxCap = NetInfo.Language == LangMode.Ko ? "확인" : Resource.TEXT28;
                            parent.bntIcon = MessageBoxIcon.Warning;
                            return false;
                        }
                        break;
                }
                switch (callerId)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                if (item.BindVarList["f_sg_code"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT44, Resource.TEXT48, MessageBoxIcon.Error);
                                    return false;
                                }
                                else if (item.BindVarList["f_sg_ymd"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT49, Resource.TEXT48, MessageBoxIcon.Error);
                                    return false;
                                }

                                cmdText = @"SELECT 'Y' 
            	                              FROM DUAL
            	                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0310
                                                             WHERE HOSP_CODE = :f_hosp_code
                                                               AND SG_CODE   = :f_sg_code
                                                               AND SG_YMD    = :f_sg_ymd)   ";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT50+" :「" + item.BindVarList["f_sg_code"].VarValue + "」\r\n" +
                                                         Resource.TEXT51, Resource.TEXT48, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                // 동일한 코드로 기간에 있다면 이전코드꺼는 중지 시킨다.
                                //cmdText = @" UPDATE BAS0310 " +
                                //           "    SET UPD_DATE = SYSDATE " +
                                //           "      , UPD_ID   = '" + UserInfo.UserID + "' " +
                                //           "      , BULYONG_YMD = TO_DATE(:f_sg_ymd) - 1 " +
                                //           "  WHERE HOSP_CODE = :f_hosp_code " +
                                //           "    AND SG_CODE   = :f_sg_code " +
                                //           "    AND SG_YMD     <= :f_sg_ymd " +
                                //           "    AND BULYONG_YMD = TO_DATE('99981231', 'YYYYMMDD') ";

                                cmdText = @" UPDATE BAS0310
                                                SET UPD_DATE    = SYSDATE
                                                  , UPD_ID      = :f_user_id
                                                  , BULYONG_YMD = TO_DATE(:f_sg_ymd) - 1
                                              WHERE HOSP_CODE   = :f_hosp_code 
                                                AND SG_CODE     = :f_sg_code
                                                AND SG_YMD      <= :f_sg_ymd ";
                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO BAS0310
                                            ( SYS_DATE                  , SYS_ID                    , UPD_DATE                , UPD_ID   ,HOSP_CODE
                                            , SG_CODE                   , SG_NAME                   , SG_NAME_KANA              
                                            , SG_NAME_IND               , SG_YMD                    , BULYONG_YMD               
                                            , SG_UNION                  , GROUP_GUBUN               , BUN_CODE                  
                                            , SG_GUBUN                  , MARUME_GUBUN              , HUBAL_DRG_YN              
                                            , DANUI                     , SUNAB_QCODE_OUT           , SUNAB_QCODE_INP           
                                            , SUGA_CHANGE               , BULYONG_SAYU              , REMARK  
                                            , TAX_YN )
                                        VALUES
                                            ( SYSDATE                   , :f_user_id                , SYSDATE , :f_user_id , :f_hosp_code
                                            , :f_sg_code                , nvl(:f_sg_name, '')       , nvl(:f_sg_name_kana, '')  
                                            , nvl(:f_sg_name_ind, '')   , :f_sg_ymd                 , nvl(:f_bulyong_ymd, TO_DATE('99981231', 'YYYYMMDD'))             
                                            , :f_sg_union               , :f_group_gubun            , nvl(:f_bun_code, '')      
                                            , :f_sg_gubun               , :f_marume_gubun           , :f_hubal_drg_yn
                                            , :f_danui                  , :f_sunab_qcode_out        , :f_sunab_qcode_inp
                                            , :f_suga_change            , :f_bulyong_sayu           , :f_remark 
                                            , :f_tax_yn) ";
                                break;
                            case DataRowState.Modified:
                                if (item.BindVarList["f_sg_ymd"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT49, Resource.TEXT48, MessageBoxIcon.Error);
                                    return false;
                                }
                                cmdText = @"UPDATE BAS0310
                                               SET UPD_ID                  = :f_user_id
                                                 , UPD_DATE                = SYSDATE
                                                 , SG_NAME                 = :f_sg_name
                                                 , SG_NAME_KANA            = :f_sg_name_kana
                                                 , SG_NAME_IND             = :f_sg_name_ind 
                                                 , SG_YMD                  = :f_sg_ymd
                                                 , BULYONG_YMD             = :f_bulyong_ymd
                                                 , SG_UNION                = :f_sg_union 
                                                 , GROUP_GUBUN             = :f_group_gubun
                                                 , BUN_CODE                = :f_bun_code
                                                 , SG_GUBUN                = :f_sg_gubun
                                                 , MARUME_GUBUN            = :f_marume_gubun
                                                 , HUBAL_DRG_YN            = :f_hubal_drg_yn
                                                 , DANUI                   = :f_danui
                                                 , SUNAB_QCODE_OUT         = :f_sunab_qcode_out 
                                                 , SUNAB_QCODE_INP         = :f_sunab_qcode_inp
                                                 , SUGA_CHANGE             = :f_suga_change
                                                 , BULYONG_SAYU            = :f_bulyong_sayu
                                                 , REMARK                  = :f_remark
                                                 , TAX_YN                  = :f_tax_yn
                                             WHERE HOSP_CODE               = :f_hosp_code 
                                               AND SG_CODE                 = :f_sg_code
                                               AND SG_YMD                  = :f_sg_ymd ";

                                break;
                            case DataRowState.Deleted:
                                cmdText = @"SELECT 'Y' 
            	                              FROM DUAL
            	                             WHERE EXISTS ( SELECT 'X'
                                                              FROM OCS0103
                                                             WHERE HOSP_CODE = :f_hosp_code 
                                                               AND SG_CODE   = :f_sg_code  ) ";
                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT50 +"「" + item.BindVarList["f_sg_code"].VarValue + "」\r\n" +
                                                         Resource.TEXT52
                                                        + "\r\n"+Resource.TEXT53, Resource.TEXT48, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"DELETE FROM BAS0310
                                             WHERE HOSP_CODE    = :f_hosp_code 
                                               AND SG_CODE      = :f_sg_code
                                               AND SG_YMD       = :f_sg_ymd";

                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void BAS0310U00_Closing(object sender, CancelEventArgs e)
        {
            if (this.boolSave == false)
            {
                e.Cancel = true;
            }
        }

        #region Connect to cloud

        /// <summary>
        /// ExecuteQueryGrdListItem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryGrdListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            BAS0310U00GrdListArgs vBAS0310U00GrdListArgs = new BAS0310U00GrdListArgs();
            vBAS0310U00GrdListArgs.BunCode = bc["f_bun_code"] != null ? bc["f_bun_code"].VarValue : "";
            vBAS0310U00GrdListArgs.AText = this.fbxSgCode.GetDataValue().ToString();
            vBAS0310U00GrdListArgs.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            vBAS0310U00GrdListArgs.Offset = maxRowpage.ToString();

            BAS0310U00GrdListResult result = CloudService.Instance.Submit<BAS0310U00GrdListResult, BAS0310U00GrdListArgs>(vBAS0310U00GrdListArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310U00GrdListItemInfo item in result.ListInfo)
                {
                    object[] objects =
                    {
                        item.SgCode,
                        item.GroupGubun,
                        item.SgName,
                        item.SgNameKana,
                        item.SgYmd,
                        item.SugaChange,
                        item.SugaChangeNmD,
                        item.BulyongYmd,
                        item.BulyongSayu,
                        item.BulyongSayuNmD,
                        item.Danui,
                        item.DanuiName,
                        item.BunCode,
                        item.BunCodeName,
                        item.MarumeGubun,
                        item.SgUnion,
                        item.Remark,
                        item.MarumeName,
                        item.HubalDrgYn,
                        item.SunabQcodeOut,
                        item.SunabQcodeInp,
                        item.TaxYn,
                        item.PrivateFeeYn,
                        item.ModifyFlg
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryFbxBunCodeDataValidating
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryFbxBunCodeDataValidating(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310U00FbxBunCodeDataValidatingArgs vBAS0310U00FbxBunCodeDataValidatingArgs = new BAS0310U00FbxBunCodeDataValidatingArgs();
            vBAS0310U00FbxBunCodeDataValidatingArgs.BunCode = bc["f_bun_code"] != null ? bc["f_bun_code"].VarValue : "";
            vBAS0310U00FbxBunCodeDataValidatingArgs.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            vBAS0310U00FbxBunCodeDataValidatingArgs.ColName = bc["f_col_name"] != null ? bc["f_col_name"].VarValue : "";
            BAS0310U00FbxBunCodeDataValidatingResult result = CloudService.Instance.Submit<BAS0310U00FbxBunCodeDataValidatingResult, BAS0310U00FbxBunCodeDataValidatingArgs>(vBAS0310U00FbxBunCodeDataValidatingArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {

                res.Add(new object[] { result.FbxBunCode});
                
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryLayGroupGubunCheck
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private IList<object[]> ExecuteQueryLayGroupGubunCheck(BindVarCollection bc)
	    {
	        IList<object[]> res = new List<object[]>();
	        BAS0310U00layGroupGubunCheckArgs vBAS0310U00layGroupGubunCheckArgs = new BAS0310U00layGroupGubunCheckArgs();
	        vBAS0310U00layGroupGubunCheckArgs.SgCode = bc["f_sg_code"] != null ? bc["f_sg_code"].VarValue : "";
	        BAS0310U00layGroupGubunCheckResult result =
	            CloudService.Instance.Submit<BAS0310U00layGroupGubunCheckResult, BAS0310U00layGroupGubunCheckArgs>(
	                vBAS0310U00layGroupGubunCheckArgs);
	        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            res.Add(new object[] {result.Count});
	        }
	        return res;
	    }

        /// <summary>
        /// ExecuteQueryLayoutCombo
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
	    private IList<object[]> ExecuteQueryLayoutCombo(BindVarCollection varCollection)
	    {
            IList<object[]> res = new List<object[]>();
            BAS0310U00PostLoadArgs args = new BAS0310U00PostLoadArgs();
            args.CodeType = varCollection["f_code_type"] != null ? varCollection["f_code_type"].VarValue : "";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, BAS0310U00PostLoadArgs>(args);
	        if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (ComboListItemInfo itemInfo in comboResult.ComboItem)
	            {
	                res.Add(new object[] {itemInfo.Code, itemInfo.CodeName});
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// ExecuteQueryMakeFindWorker2
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryMakeFindWorker2(BindVarCollection varCollection)
        {
            IList<object[]> res = new List<object[]>();
            BAS0310U00MakeFindWorker2Args args = new BAS0310U00MakeFindWorker2Args();
            args.Find = varCollection["f_find1"] != null ? varCollection["f_find1"].VarValue : "";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, BAS0310U00MakeFindWorker2Args>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo itemInfo in comboResult.ComboItem)
                {
                    res.Add(new object[] { itemInfo.Code, itemInfo.CodeName });
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryMakeFindWorker3
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryMakeFindWorker3(BindVarCollection varCollection)
        {
            IList<object[]> res = new List<object[]>();
            BAS0310U00MakeFindWorker3Args args = new BAS0310U00MakeFindWorker3Args();
            args.Find = varCollection["f_find1"] != null ? varCollection["f_find1"].VarValue : "";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, BAS0310U00MakeFindWorker3Args>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo itemInfo in comboResult.ComboItem)
                {
                    res.Add(new object[] { itemInfo.Code, itemInfo.CodeName });
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryMakeFindWorker4
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryMakeFindWorker4(BindVarCollection varCollection)
        {
            IList<object[]> res = new List<object[]>();
            BAS0310U00MakeFindWorker4Args args = new BAS0310U00MakeFindWorker4Args();
            args.CodeType = varCollection["f_code_type"] != null ? varCollection["f_code_type"].VarValue : "";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, BAS0310U00MakeFindWorker4Args>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo itemInfo in comboResult.ComboItem)
                {
                    res.Add(new object[] { itemInfo.Code, itemInfo.CodeName });
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryMakeFindWorker5
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryMakeFindWorker5(BindVarCollection varCollection)
        {
            IList<object[]> res = new List<object[]>();
            BAS0310U00MakeFindWorker5Args args = new BAS0310U00MakeFindWorker5Args();
            args.Find = varCollection["f_find1"] != null ? varCollection["f_find1"].VarValue : "";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, BAS0310U00MakeFindWorker5Args>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo itemInfo in comboResult.ComboItem)
                {
                    res.Add(new object[] { itemInfo.Code, itemInfo.CodeName });
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryFindWorkerFbxMarumeGubun
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryFindWorkerFbxMarumeGubun(BindVarCollection varCollection)
        {
            IList<object[]> res = new List<object[]>();
            BAS0310U00MakeFindWorkerFbxMarumeGubunArgs args = new BAS0310U00MakeFindWorkerFbxMarumeGubunArgs();
            args.Find = varCollection["f_find1"] != null ? varCollection["f_find1"].VarValue : "";
            args.CodeType = varCollection["f_code_type"] != null ? varCollection["f_code_type"].VarValue : "";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, BAS0310U00MakeFindWorkerFbxMarumeGubunArgs>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo itemInfo in comboResult.ComboItem)
                {
                    res.Add(new object[] { itemInfo.Code, itemInfo.CodeName });
                }
            }
            return res;
        }

        /// <summary>
        /// createGrdListItemInfo
        /// </summary>
        /// <returns></returns>
	    private List<BAS0310U00GrdListItemInfo> createGrdListItemInfo()
	    {
	        List<BAS0310U00GrdListItemInfo> grdListItemInfo = new List<BAS0310U00GrdListItemInfo>();
	        for (int i = 0; i < grdList.RowCount; i++)
	        {
	            if (grdList.GetRowState(i) == DataRowState.Added || grdList.GetRowState(i) == DataRowState.Modified)
	            {
	                BAS0310U00GrdListItemInfo info = new BAS0310U00GrdListItemInfo();
                    // https://sofiamedix.atlassian.net/browse/MED-13356
	                //info.SgCode = grdList.GetItemString(i, "sg_code");
                    info.SgCode = txtSg_Code.Text;
	                info.GroupGubun = grdList.GetItemString(i, "group_gubun");
	                info.SgName = grdList.GetItemString(i, "sg_name");
	                info.SgNameKana = grdList.GetItemString(i, "sg_name_kana");
	                info.SgYmd = grdList.GetItemString(i, "sg_ymd");
	                info.SugaChange = grdList.GetItemString(i, "suga_change");
	                info.SugaChangeNmD = grdList.GetItemString(i, "suga_change_nm_d");
	                info.BulyongYmd = grdList.GetItemString(i, "bulyong_ymd");
	                info.BulyongSayu = grdList.GetItemString(i, "bulyong_sayu");
	                info.BulyongSayuNmD = grdList.GetItemString(i, "bulyong_sayu_nm_d");
	                info.Danui = grdList.GetItemString(i, "danui");
	                info.DanuiName = grdList.GetItemString(i, "danui_name");
	                info.BunCode = grdList.GetItemString(i, "bun_code");
	                info.BunCodeName = grdList.GetItemString(i, "bun_code_name");
	                info.MarumeGubun = grdList.GetItemString(i, "marume_gubun");
	                info.SgUnion = grdList.GetItemString(i, "sg_union");
	                info.Remark = grdList.GetItemString(i, "remark");
	                info.MarumeName = grdList.GetItemString(i, "marume_name");
	                info.HubalDrgYn = grdList.GetItemString(i, "hubal_drg_yn");
	                info.SunabQcodeOut = grdList.GetItemString(i, "sunab_qcode_out");
	                info.SunabQcodeInp = grdList.GetItemString(i, "sunab_qcode_inp");
	                info.TaxYn = grdList.GetItemString(i, "tax_yn");
                    info.RowState = grdList.GetRowState(i).ToString();
                    info.PrivateFeeYn = cbxPrivateFeeYn.Checked ? "Y" : "N";
                    // https://sofiamedix.atlassian.net/browse/MED-10719
                    info.ModifyFlg = grdList.GetItemString(i, "modify_flg");

                    grdListItemInfo.Add(info);
	            }
	        }
	        if (grdList.DeletedRowTable != null && grdList.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdList.DeletedRowTable.Rows)
	            {
                    BAS0310U00GrdListItemInfo info = new BAS0310U00GrdListItemInfo();
                    info.SgCode = row["sg_code"].ToString();
                    info.GroupGubun = row["group_gubun"].ToString();
                    info.SgName = row["sg_name"].ToString();
                    info.SgNameKana = row["sg_name_kana"].ToString();
                    info.SgYmd = row["sg_ymd"].ToString();
                    info.SugaChange = row["suga_change"].ToString();
                    info.SugaChangeNmD = row["suga_change_nm_d"].ToString();
                    info.BulyongYmd = row["bulyong_ymd"].ToString();
                    info.BulyongSayu = row["bulyong_sayu"].ToString();
                    info.BulyongSayuNmD = row["bulyong_sayu_nm_d"].ToString();
                    info.Danui = row["danui"].ToString();
                    info.DanuiName = row["danui_name"].ToString();
                    info.BunCode = row["bun_code"].ToString();
                    info.BunCodeName = row["bun_code_name"].ToString();
                    info.MarumeGubun = row["marume_gubun"].ToString();
                    info.SgUnion = row["sg_union"].ToString();
                    info.Remark = row["remark"].ToString();
                    info.MarumeName = row["marume_name"].ToString();
                    info.HubalDrgYn = row["hubal_drg_yn"].ToString();
                    info.SunabQcodeOut = row["sunab_qcode_out"].ToString();
                    info.SunabQcodeInp = row["sunab_qcode_inp"].ToString();
                    info.TaxYn = row["tax_yn"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    info.PrivateFeeYn = cbxPrivateFeeYn.Checked ? "Y" : "N";

                    grdListItemInfo.Add(info);
	            }
	        }
	        return grdListItemInfo;
	    }

        /// <summary>
        /// GrdListSaveLayout
        /// </summary>
        /// <returns></returns>
	    private bool GrdListSaveLayout()
	    {
            if (grdList.RowCount < 1) return true;
	        for (int i = 0; i < grdList.RowCount; i++)
	        {
	            if (grdList.GetRowState(i) == DataRowState.Added || grdList.GetRowState(i) == DataRowState.Modified)
	            {
	                if (!Validateion_Check(grdList.GetItemString(i, "sg_ymd"), grdList.GetItemString(i, "sg_code"),
	                        grdList.GetItemString(i, "sg_name"), grdList.GetItemString(i, "sg_name_kana"),
	                        grdList.GetItemString(i, "bun_code")))
	                {
	                    mbxCap = NetInfo.Language == LangMode.Ko ? "확인" : Resource.TEXT28;
	                    bntIcon = MessageBoxIcon.Warning;
	                    return false;
	                }
	            }
	            if (grdList.GetRowState(i) == DataRowState.Added)
	            {
                    if (grdList.GetItemString(i, "sg_code") == "")
                    {
                        XMessageBox.Show(Resource.TEXT44, Resource.TEXT48, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (grdList.GetItemString(i, "sg_ymd") == "")
                    {
                        XMessageBox.Show(Resource.TEXT49, Resource.TEXT48, MessageBoxIcon.Error);
                        return false;
                    }
	            }
                if (grdList.GetRowState(i) == DataRowState.Modified)
                {
                    if (grdList.GetItemString(i, "sg_ymd") == "")
                    {
                        XMessageBox.Show(Resource.TEXT49, Resource.TEXT48, MessageBoxIcon.Error);
                        return false;
                    }
                }
	        }
	        
            // Update data
            BAS0310U00TransactionalArgs args = new BAS0310U00TransactionalArgs();
	        args.ListInputInfo = createGrdListItemInfo();
	        args.UserId = UserInfo.UserID;

	        UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, BAS0310U00TransactionalArgs>(args);
	        if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
	            updateResult.Result == false)
	        {
	            return false;
	        }
	        return true;
	    }

        #endregion

        #region 입력값 체크
        private bool Validateion_Check(string aSgYmd, string aSgCode, string aSgName, string aSgNameKana, string aBunCode)
        {
            if (TypeCheck.IsNull(aSgYmd) == true)
            {
                mbxMsg = (Resource.TEXT43);

                return false;
            }
            if (aSgCode.Trim().Length == 0)
            {
                mbxMsg = (Resource.TEXT44);
                return false;
            }
            if (aSgName.Trim().Length == 0)
            {
                mbxMsg = (Resource.TEXT45);
                return false;
            }
            if (aSgNameKana.Trim().Length == 0)
            {
                mbxMsg = (Resource.TEXT46);
                return false;
            }
            if (aBunCode.Trim().Length == 0)
            {
                mbxMsg = (Resource.TEXT47);
                return false;
            }
            return true; ;
        }
        #endregion

        private void btnUpdateMst_Click(object sender, EventArgs e)
        {
            if (XMessageBox.Show(Resource.MSG052_MSG, Resource.TEXT33, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                UpdateMasterDataArgs args = new UpdateMasterDataArgs();
                args.ScreenName = this.ScreenID;
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, UpdateMasterDataArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success && result.Result == true)
                {
                    XMessageBox.Show(Resource.MSG003_MSG, Resource.MSG003_CAP, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    XMessageBox.Show(Resource.MSG001_MSG, Resource.MSG003_CAP, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void cbxPrivateFeeYn_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPrivateFeeYn.Checked)
            {
                if (txtSg_Code.Text == "")
                    txtSg_Code.Text = "X";
                else
                {
                    if (txtSg_Code.Text.Substring(0, 1).ToUpper() != "X")
                        txtSg_Code.Text = "X" + txtSg_Code.Text;
                }
            }
        }
    }
}

