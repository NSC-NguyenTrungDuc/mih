#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0503Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0503Q00 : IHIS.Framework.XScreen
	{
		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		//진료과
		private string mGwa = "";
		//의사
		private string mDoctor = "";
		
		//Filtering 조건
		private string mAnswer_yn    = "";
		private string mNaewon_yn    = "";
		private string mIo_gubun     = "";
		private string mConsultGubun = "";
		
        //hospital code
        string mHospCode = EnvironInfo.HospCode;
		#endregion

		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XDisplayBox dbxDoctor_name;
		private IHIS.Framework.XDisplayBox dbxGwa_name;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XFindBox fbxDoctor;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XFindBox fbxGwa;
		private IHIS.Framework.XLabel xLabel3;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XRadioButton rbtNwY;
		private IHIS.Framework.XRadioButton rbtNwN;
		private IHIS.Framework.XRadioButton rbtNwALL;
		private IHIS.Framework.XRadioButton rbtActALL;
		private IHIS.Framework.XRadioButton rbtActN;
		private IHIS.Framework.XRadioButton rbtActY;
		private IHIS.Framework.XRadioButton rbtIOALL;
		private IHIS.Framework.XRadioButton rbtIn;
		private IHIS.Framework.XRadioButton rbtOut;
		private IHIS.Framework.XRadioButton rbtCstALL;
		private IHIS.Framework.XRadioButton rbtCstDoc;
		private IHIS.Framework.XRadioButton rbtCstGwa;
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPanel xPanel7;
		private IHIS.Framework.XTabControl tabConsultGubun;
		private IHIS.X.Magic.Controls.TabPage pageConsult;
		private IHIS.X.Magic.Controls.TabPage pageRequest;
		private IHIS.Framework.XPanel xPanel8;
		private IHIS.Framework.XPanel xPanel9;
		private IHIS.Framework.XLabel lblSlip_name;
		private IHIS.Framework.XMstGrid grdConsult;
		private IHIS.Framework.XPanel pnlAct;
		private IHIS.Framework.XPanel pnlConsultGubun;
		private IHIS.Framework.XPanel pnlIO_gubun;
		private IHIS.Framework.XPanel pnlNaewonYN;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XMstGrid grdRequest;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell61;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
		private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell67;
		private IHIS.Framework.XEditGridCell xEditGridCell68;
		private IHIS.Framework.XEditGridCell xEditGridCell69;
		private IHIS.Framework.XEditGridCell xEditGridCell70;
		private IHIS.Framework.XDatePicker dpkTo_date;
		private IHIS.Framework.XDatePicker dpkFrom_date;
		private IHIS.Framework.XEditGrid grdConsultOUT1001;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell71;
		private IHIS.Framework.XEditGridCell xEditGridCell72;
		private IHIS.Framework.XEditGridCell xEditGridCell73;
		private IHIS.Framework.XEditGridCell xEditGridCell74;
		private IHIS.Framework.XEditGridCell xEditGridCell75;
		private IHIS.Framework.XEditGridCell xEditGridCell76;
		private IHIS.Framework.XEditGridCell xEditGridCell77;
		private IHIS.Framework.XEditGridCell xEditGridCell78;
		private IHIS.Framework.XEditGridCell xEditGridCell79;
		private IHIS.Framework.XEditGrid grdRequestOUT1001;
		private IHIS.Framework.XEditGridCell xEditGridCell80;
		private IHIS.Framework.XEditGridCell xEditGridCell81;
		private IHIS.Framework.XEditGridCell xEditGridCell82;
		private IHIS.Framework.XEditGridCell xEditGridCell83;
		private IHIS.Framework.XEditGridCell xEditGridCell84;
		private IHIS.Framework.XEditGridCell xEditGridCell85;
		private IHIS.Framework.XEditGridCell xEditGridCell86;
		private IHIS.Framework.XEditGridCell xEditGridCell87;
		private IHIS.Framework.XEditGridCell xEditGridCell88;
		private IHIS.Framework.XEditGridCell xEditGridCell89;
		private IHIS.Framework.XEditGridCell xEditGridCell90;
		private IHIS.Framework.XEditGridCell xEditGridCell91;
		private IHIS.Framework.XEditGridCell xEditGridCell92;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        /// <summary>
        /// Param loadConsultInfoResult
        /// </summary>
	    private OCS0503Q00LoadConsultInfoResult loadConsultInfoResult;

        /// <summary>
        /// param FilteringTheInformationResult
        /// </summary>
	    private OCS0503Q00FilteringTheInformationResult filteringTheInformationResult;


		public OCS0503Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            this.xComboItem3.DisplayItem = Resource.ValueItem_O;
            this.xComboItem4.DisplayItem = Resource.ValueItem_Y; 
            this.xComboItem1.DisplayItem = Resource.ValueItem_O;
            this.xComboItem2.DisplayItem = Resource.ValueItem_Y;

            grdConsult.ExecuteQuery = grdConsult_ExecuteQuery;
            grdRequest.ExecuteQuery = grdRequest_ExecuteQuery;
            grdConsultOUT1001.ExecuteQuery = grdConsultOUT1001_ExecuteQuery;
            grdRequestOUT1001.ExecuteQuery = grdRequestOUT1001_ExecuteQuery;

            //TODO disable IN Hospital Tab MED-5790
            InivisbleRbtIn();
		}

        private void InivisbleRbtIn()
        {
            rbtIn.Visible = false;
            rbtOut.Width += 145;
            rbtOut.TextAlign = ContentAlignment.MiddleCenter;
            rbtIOALL.Visible = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0503Q00));
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dbxDoctor_name = new IHIS.Framework.XDisplayBox();
            this.dbxGwa_name = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.fbxGwa = new IHIS.Framework.XFindBox();
            this.pnlNaewonYN = new IHIS.Framework.XPanel();
            this.rbtNwALL = new IHIS.Framework.XRadioButton();
            this.rbtNwN = new IHIS.Framework.XRadioButton();
            this.rbtNwY = new IHIS.Framework.XRadioButton();
            this.pnlConsultGubun = new IHIS.Framework.XPanel();
            this.rbtCstALL = new IHIS.Framework.XRadioButton();
            this.rbtCstDoc = new IHIS.Framework.XRadioButton();
            this.rbtCstGwa = new IHIS.Framework.XRadioButton();
            this.pnlAct = new IHIS.Framework.XPanel();
            this.rbtActALL = new IHIS.Framework.XRadioButton();
            this.rbtActN = new IHIS.Framework.XRadioButton();
            this.rbtActY = new IHIS.Framework.XRadioButton();
            this.pnlIO_gubun = new IHIS.Framework.XPanel();
            this.rbtIOALL = new IHIS.Framework.XRadioButton();
            this.rbtIn = new IHIS.Framework.XRadioButton();
            this.rbtOut = new IHIS.Framework.XRadioButton();
            this.dpkTo_date = new IHIS.Framework.XDatePicker();
            this.dpkFrom_date = new IHIS.Framework.XDatePicker();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.grdRequestOUT1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.grdRequest = new IHIS.Framework.XMstGrid();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.grdConsultOUT1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.grdConsult = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.lblSlip_name = new IHIS.Framework.XLabel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.tabConsultGubun = new IHIS.Framework.XTabControl();
            this.pageConsult = new IHIS.X.Magic.Controls.TabPage();
            this.pageRequest = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel3.SuspendLayout();
            this.pnlNaewonYN.SuspendLayout();
            this.pnlConsultGubun.SuspendLayout();
            this.pnlAct.SuspendLayout();
            this.pnlIO_gubun.SuspendLayout();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel7.SuspendLayout();
            this.xPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRequestOUT1001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConsultOUT1001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConsult)).BeginInit();
            this.xPanel8.SuspendLayout();
            this.tabConsultGubun.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.dbxDoctor_name);
            this.xPanel3.Controls.Add(this.dbxGwa_name);
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Controls.Add(this.fbxDoctor);
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Controls.Add(this.fbxGwa);
            this.xPanel3.Controls.Add(this.pnlNaewonYN);
            this.xPanel3.Controls.Add(this.pnlConsultGubun);
            this.xPanel3.Controls.Add(this.pnlAct);
            this.xPanel3.Controls.Add(this.pnlIO_gubun);
            this.xPanel3.Controls.Add(this.dpkTo_date);
            this.xPanel3.Controls.Add(this.dpkFrom_date);
            this.xPanel3.Controls.Add(this.xLabel3);
            this.xPanel3.Controls.Add(this.label1);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // dbxDoctor_name
            // 
            this.dbxDoctor_name.AccessibleDescription = null;
            this.dbxDoctor_name.AccessibleName = null;
            resources.ApplyResources(this.dbxDoctor_name, "dbxDoctor_name");
            this.dbxDoctor_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxDoctor_name.EdgeRounding = false;
            this.dbxDoctor_name.Image = null;
            this.dbxDoctor_name.Name = "dbxDoctor_name";
            // 
            // dbxGwa_name
            // 
            this.dbxGwa_name.AccessibleDescription = null;
            this.dbxGwa_name.AccessibleName = null;
            resources.ApplyResources(this.dbxGwa_name, "dbxGwa_name");
            this.dbxGwa_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxGwa_name.EdgeRounding = false;
            this.dbxGwa_name.Image = null;
            this.dbxGwa_name.Name = "dbxGwa_name";
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
            // fbxDoctor
            // 
            this.fbxDoctor.AccessibleDescription = null;
            this.fbxDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxDoctor, "fbxDoctor");
            this.fbxDoctor.BackgroundImage = null;
            this.fbxDoctor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDoctor_FindClick);
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
            // fbxGwa
            // 
            this.fbxGwa.AccessibleDescription = null;
            this.fbxGwa.AccessibleName = null;
            resources.ApplyResources(this.fbxGwa, "fbxGwa");
            this.fbxGwa.BackgroundImage = null;
            this.fbxGwa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxGwa.Name = "fbxGwa";
            this.fbxGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxGwa_DataValidating);
            this.fbxGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxGwa_FindClick);
            // 
            // pnlNaewonYN
            // 
            this.pnlNaewonYN.AccessibleDescription = null;
            this.pnlNaewonYN.AccessibleName = null;
            resources.ApplyResources(this.pnlNaewonYN, "pnlNaewonYN");
            this.pnlNaewonYN.BackgroundImage = null;
            this.pnlNaewonYN.Controls.Add(this.rbtNwALL);
            this.pnlNaewonYN.Controls.Add(this.rbtNwN);
            this.pnlNaewonYN.Controls.Add(this.rbtNwY);
            this.pnlNaewonYN.Font = null;
            this.pnlNaewonYN.Name = "pnlNaewonYN";
            // 
            // rbtNwALL
            // 
            this.rbtNwALL.AccessibleDescription = null;
            this.rbtNwALL.AccessibleName = null;
            resources.ApplyResources(this.rbtNwALL, "rbtNwALL");
            this.rbtNwALL.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtNwALL.BackgroundImage = null;
            this.rbtNwALL.Checked = true;
            this.rbtNwALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtNwALL.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtNwALL.ImageList = this.ImageList;
            this.rbtNwALL.Name = "rbtNwALL";
            this.rbtNwALL.TabStop = true;
            this.rbtNwALL.UseVisualStyleBackColor = false;
            this.rbtNwALL.Click += new System.EventHandler(this.rbtNaewon_Click);
            // 
            // rbtNwN
            // 
            this.rbtNwN.AccessibleDescription = null;
            this.rbtNwN.AccessibleName = null;
            resources.ApplyResources(this.rbtNwN, "rbtNwN");
            this.rbtNwN.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtNwN.BackgroundImage = null;
            this.rbtNwN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtNwN.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtNwN.ImageList = this.ImageList;
            this.rbtNwN.Name = "rbtNwN";
            this.rbtNwN.UseVisualStyleBackColor = false;
            this.rbtNwN.Click += new System.EventHandler(this.rbtNaewon_Click);
            // 
            // rbtNwY
            // 
            this.rbtNwY.AccessibleDescription = null;
            this.rbtNwY.AccessibleName = null;
            resources.ApplyResources(this.rbtNwY, "rbtNwY");
            this.rbtNwY.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtNwY.BackgroundImage = null;
            this.rbtNwY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtNwY.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtNwY.ImageList = this.ImageList;
            this.rbtNwY.Name = "rbtNwY";
            this.rbtNwY.UseVisualStyleBackColor = false;
            this.rbtNwY.Click += new System.EventHandler(this.rbtNaewon_Click);
            // 
            // pnlConsultGubun
            // 
            this.pnlConsultGubun.AccessibleDescription = null;
            this.pnlConsultGubun.AccessibleName = null;
            resources.ApplyResources(this.pnlConsultGubun, "pnlConsultGubun");
            this.pnlConsultGubun.BackgroundImage = null;
            this.pnlConsultGubun.Controls.Add(this.rbtCstALL);
            this.pnlConsultGubun.Controls.Add(this.rbtCstDoc);
            this.pnlConsultGubun.Controls.Add(this.rbtCstGwa);
            this.pnlConsultGubun.Font = null;
            this.pnlConsultGubun.Name = "pnlConsultGubun";
            // 
            // rbtCstALL
            // 
            this.rbtCstALL.AccessibleDescription = null;
            this.rbtCstALL.AccessibleName = null;
            resources.ApplyResources(this.rbtCstALL, "rbtCstALL");
            this.rbtCstALL.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtCstALL.BackgroundImage = null;
            this.rbtCstALL.Checked = true;
            this.rbtCstALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtCstALL.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtCstALL.ImageList = this.ImageList;
            this.rbtCstALL.Name = "rbtCstALL";
            this.rbtCstALL.TabStop = true;
            this.rbtCstALL.UseVisualStyleBackColor = false;
            this.rbtCstALL.Click += new System.EventHandler(this.rbtConsultGubun_Click);
            // 
            // rbtCstDoc
            // 
            this.rbtCstDoc.AccessibleDescription = null;
            this.rbtCstDoc.AccessibleName = null;
            resources.ApplyResources(this.rbtCstDoc, "rbtCstDoc");
            this.rbtCstDoc.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtCstDoc.BackgroundImage = null;
            this.rbtCstDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtCstDoc.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtCstDoc.ImageList = this.ImageList;
            this.rbtCstDoc.Name = "rbtCstDoc";
            this.rbtCstDoc.UseVisualStyleBackColor = false;
            this.rbtCstDoc.Click += new System.EventHandler(this.rbtConsultGubun_Click);
            // 
            // rbtCstGwa
            // 
            this.rbtCstGwa.AccessibleDescription = null;
            this.rbtCstGwa.AccessibleName = null;
            resources.ApplyResources(this.rbtCstGwa, "rbtCstGwa");
            this.rbtCstGwa.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtCstGwa.BackgroundImage = null;
            this.rbtCstGwa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtCstGwa.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtCstGwa.ImageList = this.ImageList;
            this.rbtCstGwa.Name = "rbtCstGwa";
            this.rbtCstGwa.UseVisualStyleBackColor = false;
            this.rbtCstGwa.Click += new System.EventHandler(this.rbtConsultGubun_Click);
            // 
            // pnlAct
            // 
            this.pnlAct.AccessibleDescription = null;
            this.pnlAct.AccessibleName = null;
            resources.ApplyResources(this.pnlAct, "pnlAct");
            this.pnlAct.BackgroundImage = null;
            this.pnlAct.Controls.Add(this.rbtActALL);
            this.pnlAct.Controls.Add(this.rbtActN);
            this.pnlAct.Controls.Add(this.rbtActY);
            this.pnlAct.Font = null;
            this.pnlAct.Name = "pnlAct";
            // 
            // rbtActALL
            // 
            this.rbtActALL.AccessibleDescription = null;
            this.rbtActALL.AccessibleName = null;
            resources.ApplyResources(this.rbtActALL, "rbtActALL");
            this.rbtActALL.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtActALL.BackgroundImage = null;
            this.rbtActALL.Checked = true;
            this.rbtActALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtActALL.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtActALL.ImageList = this.ImageList;
            this.rbtActALL.Name = "rbtActALL";
            this.rbtActALL.TabStop = true;
            this.rbtActALL.UseVisualStyleBackColor = false;
            this.rbtActALL.Click += new System.EventHandler(this.rbtAct_Click);
            // 
            // rbtActN
            // 
            this.rbtActN.AccessibleDescription = null;
            this.rbtActN.AccessibleName = null;
            resources.ApplyResources(this.rbtActN, "rbtActN");
            this.rbtActN.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtActN.BackgroundImage = null;
            this.rbtActN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtActN.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtActN.ImageList = this.ImageList;
            this.rbtActN.Name = "rbtActN";
            this.rbtActN.UseVisualStyleBackColor = false;
            this.rbtActN.Click += new System.EventHandler(this.rbtAct_Click);
            // 
            // rbtActY
            // 
            this.rbtActY.AccessibleDescription = null;
            this.rbtActY.AccessibleName = null;
            resources.ApplyResources(this.rbtActY, "rbtActY");
            this.rbtActY.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtActY.BackgroundImage = null;
            this.rbtActY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtActY.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtActY.ImageList = this.ImageList;
            this.rbtActY.Name = "rbtActY";
            this.rbtActY.UseVisualStyleBackColor = false;
            this.rbtActY.Click += new System.EventHandler(this.rbtAct_Click);
            // 
            // pnlIO_gubun
            // 
            this.pnlIO_gubun.AccessibleDescription = null;
            this.pnlIO_gubun.AccessibleName = null;
            resources.ApplyResources(this.pnlIO_gubun, "pnlIO_gubun");
            this.pnlIO_gubun.BackgroundImage = null;
            this.pnlIO_gubun.Controls.Add(this.rbtIOALL);
            this.pnlIO_gubun.Controls.Add(this.rbtIn);
            this.pnlIO_gubun.Controls.Add(this.rbtOut);
            this.pnlIO_gubun.Font = null;
            this.pnlIO_gubun.Name = "pnlIO_gubun";
            // 
            // rbtIOALL
            // 
            this.rbtIOALL.AccessibleDescription = null;
            this.rbtIOALL.AccessibleName = null;
            resources.ApplyResources(this.rbtIOALL, "rbtIOALL");
            this.rbtIOALL.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtIOALL.BackgroundImage = null;
            this.rbtIOALL.Checked = true;
            this.rbtIOALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtIOALL.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtIOALL.ImageList = this.ImageList;
            this.rbtIOALL.Name = "rbtIOALL";
            this.rbtIOALL.TabStop = true;
            this.rbtIOALL.UseVisualStyleBackColor = false;
            this.rbtIOALL.Click += new System.EventHandler(this.rbtIO_gubun_Click);
            // 
            // rbtIn
            // 
            this.rbtIn.AccessibleDescription = null;
            this.rbtIn.AccessibleName = null;
            resources.ApplyResources(this.rbtIn, "rbtIn");
            this.rbtIn.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtIn.BackgroundImage = null;
            this.rbtIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtIn.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtIn.ImageList = this.ImageList;
            this.rbtIn.Name = "rbtIn";
            this.rbtIn.UseVisualStyleBackColor = false;
            this.rbtIn.Click += new System.EventHandler(this.rbtIO_gubun_Click);
            // 
            // rbtOut
            // 
            this.rbtOut.AccessibleDescription = null;
            this.rbtOut.AccessibleName = null;
            resources.ApplyResources(this.rbtOut, "rbtOut");
            this.rbtOut.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtOut.BackgroundImage = null;
            this.rbtOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOut.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtOut.ImageList = this.ImageList;
            this.rbtOut.Name = "rbtOut";
            this.rbtOut.UseVisualStyleBackColor = false;
            this.rbtOut.Click += new System.EventHandler(this.rbtIO_gubun_Click);
            // 
            // dpkTo_date
            // 
            this.dpkTo_date.AccessibleDescription = null;
            this.dpkTo_date.AccessibleName = null;
            resources.ApplyResources(this.dpkTo_date, "dpkTo_date");
            this.dpkTo_date.BackgroundImage = null;
            this.dpkTo_date.IsVietnameseYearType = false;
            this.dpkTo_date.Name = "dpkTo_date";
            this.dpkTo_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkTo_date_DataValidating);
            // 
            // dpkFrom_date
            // 
            this.dpkFrom_date.AccessibleDescription = null;
            this.dpkFrom_date.AccessibleName = null;
            resources.ApplyResources(this.dpkFrom_date, "dpkFrom_date");
            this.dpkFrom_date.BackgroundImage = null;
            this.dpkFrom_date.IsVietnameseYearType = false;
            this.dpkFrom_date.Name = "dpkFrom_date";
            this.dpkFrom_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkFrom_date_DataValidating);
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
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.xButtonList1);
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
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
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel7
            // 
            this.xPanel7.AccessibleDescription = null;
            this.xPanel7.AccessibleName = null;
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.BackgroundImage = null;
            this.xPanel7.Controls.Add(this.xPanel9);
            this.xPanel7.Controls.Add(this.xPanel8);
            this.xPanel7.Controls.Add(this.tabConsultGubun);
            this.xPanel7.Font = null;
            this.xPanel7.Name = "xPanel7";
            // 
            // xPanel9
            // 
            this.xPanel9.AccessibleDescription = null;
            this.xPanel9.AccessibleName = null;
            resources.ApplyResources(this.xPanel9, "xPanel9");
            this.xPanel9.BackgroundImage = null;
            this.xPanel9.Controls.Add(this.grdRequestOUT1001);
            this.xPanel9.Controls.Add(this.grdConsultOUT1001);
            this.xPanel9.Controls.Add(this.lblSlip_name);
            this.xPanel9.Font = null;
            this.xPanel9.Name = "xPanel9";
            // 
            // grdRequestOUT1001
            // 
            resources.ApplyResources(this.grdRequestOUT1001, "grdRequestOUT1001");
            this.grdRequestOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell86,
            this.xEditGridCell85,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90});
            this.grdRequestOUT1001.ColPerLine = 4;
            this.grdRequestOUT1001.Cols = 4;
            this.grdRequestOUT1001.ExecuteQuery = null;
            this.grdRequestOUT1001.FixedRows = 1;
            this.grdRequestOUT1001.HeaderHeights.Add(21);
            this.grdRequestOUT1001.MasterLayout = this.grdRequest;
            this.grdRequestOUT1001.Name = "grdRequestOUT1001";
            this.grdRequestOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRequestOUT1001.ParamList")));
            this.grdRequestOUT1001.QuerySQL = resources.GetString("grdRequestOUT1001.QuerySQL");
            this.grdRequestOUT1001.ReadOnly = true;
            this.grdRequestOUT1001.Rows = 2;
            this.grdRequestOUT1001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdRequestOUT1001_MouseDown);
            this.grdRequestOUT1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRequestOUT1001_QueryStarting);
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "reser_yn";
            this.xEditGridCell80.CellWidth = 66;
            this.xEditGridCell80.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "jinryo_time";
            this.xEditGridCell81.CellWidth = 100;
            this.xEditGridCell81.Col = 1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.Mask = "##:##";
            this.xEditGridCell81.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "gwa_name";
            this.xEditGridCell82.Col = 2;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "doctor_name";
            this.xEditGridCell83.Col = 3;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "naewon_yn";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "bunho";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "naewon_date";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "gwa";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "doctor";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "naewon_type";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "jubsu_no";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // grdRequest
            // 
            resources.ApplyResources(this.grdRequest, "grdRequest");
            this.grdRequest.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell92,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70});
            this.grdRequest.ColPerLine = 13;
            this.grdRequest.Cols = 14;
            this.grdRequest.ExecuteQuery = null;
            this.grdRequest.FixedCols = 1;
            this.grdRequest.FixedRows = 1;
            this.grdRequest.HeaderHeights.Add(26);
            this.grdRequest.Name = "grdRequest";
            this.grdRequest.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRequest.ParamList")));
            this.grdRequest.QuerySQL = resources.GetString("grdRequest.QuerySQL");
            this.grdRequest.RowHeaderVisible = true;
            this.grdRequest.Rows = 2;
            this.grdRequest.ToolTipActive = true;
            this.grdRequest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdRequest_MouseDown);
            this.grdRequest.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRequest_QueryStarting);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "io_gubun";
            this.xEditGridCell36.CellWidth = 150;
            this.xEditGridCell36.Col = 3;
            this.xEditGridCell36.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell36.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsUpdatable = false;
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "O";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "I";
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "answer_yn";
            this.xEditGridCell37.CellWidth = 60;
            this.xEditGridCell37.Col = 1;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsUpdatable = false;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "gwa_consult_yn";
            this.xEditGridCell38.CellWidth = 100;
            this.xEditGridCell38.Col = 2;
            this.xEditGridCell38.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsUpdatable = false;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "naewon_date";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell40.CellWidth = 87;
            this.xEditGridCell40.Col = 4;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsUpdatable = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "jinryo_time";
            this.xEditGridCell41.CellWidth = 65;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsUpdatable = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Mask = "##:##";
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "bunho";
            this.xEditGridCell42.CellWidth = 92;
            this.xEditGridCell42.Col = 5;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsUpdatable = false;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "suname";
            this.xEditGridCell43.CellWidth = 99;
            this.xEditGridCell43.Col = 6;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsUpdatable = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "suname2";
            this.xEditGridCell44.CellWidth = 140;
            this.xEditGridCell44.Col = 7;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsUpdatable = false;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "ho_dong";
            this.xEditGridCell45.CellWidth = 100;
            this.xEditGridCell45.Col = 9;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsUpdatable = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "sex_age";
            this.xEditGridCell46.CellWidth = 100;
            this.xEditGridCell46.Col = 8;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "gubun_name";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdatable = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "gwa";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "doctor";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "naewon_type";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "jubsu_no";
            this.xEditGridCell52.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "chojae";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsUpdatable = false;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "chojae_name";
            this.xEditGridCell56.CellWidth = 100;
            this.xEditGridCell56.Col = 10;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsUpdatable = false;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "pk_naewon";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsUpdatable = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "naewon_yn";
            this.xEditGridCell59.CellWidth = 66;
            this.xEditGridCell59.Col = 11;
            this.xEditGridCell59.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsUpdatable = false;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "req_date";
            this.xEditGridCell92.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsUpdatable = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "req_gwa";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsUpdatable = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "req_doctor";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsUpdatable = false;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "consult_gwa";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "consult_doctor";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "req_io_gubun";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "gwa_name";
            this.xEditGridCell65.CellWidth = 100;
            this.xEditGridCell65.Col = 12;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsUpdatable = false;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "doctor_name";
            this.xEditGridCell66.CellWidth = 100;
            this.xEditGridCell66.Col = 13;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsUpdatable = false;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "answer_upd_yn";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsUpdatable = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "app_date";
            this.xEditGridCell68.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsUpdatable = false;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "pkocs0503";
            this.xEditGridCell69.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsUpdatable = false;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "order_end_yn";
            this.xEditGridCell70.CellWidth = 34;
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsUpdatable = false;
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // grdConsultOUT1001
            // 
            resources.ApplyResources(this.grdConsultOUT1001, "grdConsultOUT1001");
            this.grdConsultOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell13,
            this.xEditGridCell48,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell75,
            this.xEditGridCell74,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79});
            this.grdConsultOUT1001.ColPerLine = 4;
            this.grdConsultOUT1001.Cols = 4;
            this.grdConsultOUT1001.ExecuteQuery = null;
            this.grdConsultOUT1001.FixedRows = 1;
            this.grdConsultOUT1001.HeaderHeights.Add(21);
            this.grdConsultOUT1001.MasterLayout = this.grdConsult;
            this.grdConsultOUT1001.Name = "grdConsultOUT1001";
            this.grdConsultOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdConsultOUT1001.ParamList")));
            this.grdConsultOUT1001.QuerySQL = resources.GetString("grdConsultOUT1001.QuerySQL");
            this.grdConsultOUT1001.ReadOnly = true;
            this.grdConsultOUT1001.Rows = 2;
            this.grdConsultOUT1001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdConsultOUT1001_MouseDown);
            this.grdConsultOUT1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdConsultOUT1001_QueryStarting);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "reser_yn";
            this.xEditGridCell13.CellWidth = 66;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "jinryo_time";
            this.xEditGridCell48.CellWidth = 100;
            this.xEditGridCell48.Col = 1;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.Mask = "##:##";
            this.xEditGridCell48.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "gwa_name";
            this.xEditGridCell71.Col = 2;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "doctor_name";
            this.xEditGridCell72.Col = 3;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "naewon_yn";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "bunho";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "naewon_date";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "gwa";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "doctor";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "naewon_type";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "jubsu_no";
            this.xEditGridCell79.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // grdConsult
            // 
            resources.ApplyResources(this.grdConsult, "grdConsult");
            this.grdConsult.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell91,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35});
            this.grdConsult.ColPerLine = 13;
            this.grdConsult.Cols = 14;
            this.grdConsult.ExecuteQuery = null;
            this.grdConsult.FixedCols = 1;
            this.grdConsult.FixedRows = 1;
            this.grdConsult.HeaderHeights.Add(25);
            this.grdConsult.Name = "grdConsult";
            this.grdConsult.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdConsult.ParamList")));
            this.grdConsult.QuerySQL = resources.GetString("grdConsult.QuerySQL");
            this.grdConsult.RowHeaderVisible = true;
            this.grdConsult.Rows = 2;
            this.grdConsult.ToolTipActive = true;
            this.grdConsult.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdConsult_MouseDown);
            this.grdConsult.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdConsult_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "io_gubun";
            this.xEditGridCell1.CellWidth = 150;
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "O";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "I";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "answer_yn";
            this.xEditGridCell2.CellWidth = 38;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "gwa_consult_yn";
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "naewon_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 130;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "jinryo_time";
            this.xEditGridCell6.CellWidth = 65;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Mask = "##:##";
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "bunho";
            this.xEditGridCell7.CellWidth = 92;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "suname";
            this.xEditGridCell8.CellWidth = 99;
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "suname2";
            this.xEditGridCell9.CellWidth = 140;
            this.xEditGridCell9.Col = 7;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "ho_dong";
            this.xEditGridCell10.CellWidth = 100;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "sex_age";
            this.xEditGridCell11.CellWidth = 100;
            this.xEditGridCell11.Col = 8;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "gubun_name";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "gwa";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "doctor";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "naewon_type";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "jubsu_no";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "chojae";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "chojae_name";
            this.xEditGridCell21.CellWidth = 120;
            this.xEditGridCell21.Col = 10;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdatable = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "pk_naewon";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "naewon_yn";
            this.xEditGridCell24.CellWidth = 68;
            this.xEditGridCell24.Col = 11;
            this.xEditGridCell24.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsUpdatable = false;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "req_date";
            this.xEditGridCell91.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsUpdatable = false;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "req_gwa";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "req_doctor";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "consult_gwa";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "consult_doctor";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "req_io_gubun";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "cons_gwa_name";
            this.xEditGridCell30.Col = 12;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdatable = false;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "cons_doctor_name";
            this.xEditGridCell31.CellWidth = 99;
            this.xEditGridCell31.Col = 13;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdatable = false;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "answer_upd_yn";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "app_date";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "pkocs0503";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "order_end_yn";
            this.xEditGridCell35.CellWidth = 34;
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // lblSlip_name
            // 
            this.lblSlip_name.AccessibleDescription = null;
            this.lblSlip_name.AccessibleName = null;
            resources.ApplyResources(this.lblSlip_name, "lblSlip_name");
            this.lblSlip_name.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSlip_name.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSlip_name.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSlip_name.Image = null;
            this.lblSlip_name.Name = "lblSlip_name";
            // 
            // xPanel8
            // 
            this.xPanel8.AccessibleDescription = null;
            this.xPanel8.AccessibleName = null;
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.BackgroundImage = null;
            this.xPanel8.Controls.Add(this.grdRequest);
            this.xPanel8.Controls.Add(this.grdConsult);
            this.xPanel8.Font = null;
            this.xPanel8.Name = "xPanel8";
            // 
            // tabConsultGubun
            // 
            this.tabConsultGubun.AccessibleDescription = null;
            this.tabConsultGubun.AccessibleName = null;
            resources.ApplyResources(this.tabConsultGubun, "tabConsultGubun");
            this.tabConsultGubun.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.tabConsultGubun.BackgroundImage = null;
            this.tabConsultGubun.Font = null;
            this.tabConsultGubun.ForeColor = System.Drawing.Color.Empty;
            this.tabConsultGubun.IDEPixelArea = true;
            this.tabConsultGubun.IDEPixelBorder = false;
            this.tabConsultGubun.ImageList = this.ImageList;
            this.tabConsultGubun.Name = "tabConsultGubun";
            this.tabConsultGubun.SelectedIndex = 0;
            this.tabConsultGubun.SelectedTab = this.pageConsult;
            this.tabConsultGubun.ShowArrows = false;
            this.tabConsultGubun.ShowClose = false;
            this.tabConsultGubun.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.pageConsult,
            this.pageRequest});
            this.tabConsultGubun.TextColor = System.Drawing.Color.Empty;
            this.tabConsultGubun.SelectionChanged += new System.EventHandler(this.tabConsultGubun_SelectionChanged);
            // 
            // pageConsult
            // 
            this.pageConsult.AccessibleDescription = null;
            this.pageConsult.AccessibleName = null;
            resources.ApplyResources(this.pageConsult, "pageConsult");
            this.pageConsult.BackgroundImage = null;
            this.pageConsult.Font = null;
            this.pageConsult.ImageIndex = 1;
            this.pageConsult.ImageList = this.ImageList;
            this.pageConsult.Name = "pageConsult";
            // 
            // pageRequest
            // 
            this.pageRequest.AccessibleDescription = null;
            this.pageRequest.AccessibleName = null;
            resources.ApplyResources(this.pageRequest, "pageRequest");
            this.pageRequest.BackgroundImage = null;
            this.pageRequest.Font = null;
            this.pageRequest.ImageIndex = 0;
            this.pageRequest.ImageList = this.ImageList;
            this.pageRequest.Name = "pageRequest";
            this.pageRequest.Selected = false;
            // 
            // OCS0503Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel7);
            this.Controls.Add(this.xPanel6);
            this.Controls.Add(this.xPanel3);
            this.Name = "OCS0503Q00";
            this.UserChanged += new System.EventHandler(this.OCS0503Q00_UserChanged);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.pnlNaewonYN.ResumeLayout(false);
            this.pnlConsultGubun.ResumeLayout(false);
            this.pnlAct.ResumeLayout(false);
            this.pnlIO_gubun.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel7.ResumeLayout(false);
            this.xPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRequestOUT1001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConsultOUT1001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConsult)).EndInit();
            this.xPanel8.ResumeLayout(false);
            this.tabConsultGubun.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);

			InitialDesign();
		    
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void InitialDesign()
		{
			// Dock 처리
			grdConsult.Dock = DockStyle.Fill;
			grdRequest.Dock = DockStyle.Fill;
			grdRequest.Visible = false;		
			grdConsultOUT1001.Dock = DockStyle.Fill;
			grdRequestOUT1001.Dock = DockStyle.Fill;					
			grdRequestOUT1001.Visible = false;
			
			tabConsultGubun.SelectedIndex = 0;
		}

		private void PostLoad()
		{	
			// 사용자 변경 Event Call ////////////////////////////////////			
			this.OCS0503Q00_UserChanged(this, new System.EventArgs()); 
			///////////////////////////////////////////////////////////////
		}

		private void OCS0503Q00_UserChanged(object sender, System.EventArgs e)
		{
			if(UserInfo.Gwa == "01")
				dpkFrom_date.SetDataValue(EnvironInfo.GetSysDate().AddMonths(-2).ToString("yyyy/MM/dd"));
			else
				dpkFrom_date.SetDataValue(EnvironInfo.GetSysDate().AddMonths(-1).ToString("yyyy/MM/dd"));

			dpkTo_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

			if(UserInfo.UserGubun == UserType.Doctor)
			{
				if(!TypeCheck.IsNull(UserInfo.Gwa))
				{
					this.fbxGwa.SetDataValue(UserInfo.Gwa);
					this.dbxGwa_name.SetDataValue(UserInfo.GwaName);
					this.fbxDoctor.SetDataValue(UserInfo.DoctorID);
					this.dbxDoctor_name.SetDataValue(UserInfo.UserName);
					mGwa = UserInfo.Gwa;
					mDoctor = UserInfo.UserID;

					LoadConsultInfo();
				}				
			}
			else
			{
				fbxDoctor.SetDataValue("%");
                dbxDoctor_name.SetDataValue(Resource.msg_all);
			}
		}
		#endregion

		#region [Load Code Name]
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
			string codeName = "";
			string cmdText = "";
			object retVal = null;
			IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();

			if(code.Trim() == "" ) return codeName;

			switch (codeMode)
			{				
				case "gwa_name":
//					cmdText = @"SELECT A.GWA_NAME 
//                                  FROM VW_BAS_GWA A  
//                                 WHERE A.HOSP_CODE       = :f_hosp_code
//                                   AND ( A.OUT_JUBSU_YN  = 'Y'  OR A.IPWON_YN = 'Y' )                   
//                                   AND A.START_DATE      = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, TRUNC(SYSDATE) )
//                                   AND A.GWA = :f_code ";
//
//					bindVars.Clear();
//					bindVars.Add("f_code",code);
//                    bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//					retVal = Service.ExecuteScalar(cmdText,bindVars);

                    // Use connect cloud service
                    OCS0503Q00DepartmentNameArgs args = new OCS0503Q00DepartmentNameArgs();
			        args.GwaCode = code;
			        OCS0503Q00DepartmentNameResult departmentNameResult =
			            CloudService.Instance.Submit<OCS0503Q00DepartmentNameResult, OCS0503Q00DepartmentNameArgs>(args);

                    if (departmentNameResult == null || departmentNameResult.ExecutionStatus != ExecutionStatus.Success)
						codeName = "";					
					else
                        codeName = departmentNameResult.GwaName;

					break;
				case "doctor_name":
					string gwa = fbxGwa.GetDataValue();

					if(TypeCheck.IsNull(gwa))
					{
						codeName = "XXX";
						break;
					}

//					cmdText = @"SELECT A.DOCTOR_NAME 
//                                  FROM BAS0270 A 
//                                 WHERE A.HOSP_CODE  = :f_hosp_code
//                                   AND A.DOCTOR_GWA = :f_gwa
//                                   AND A.START_DATE = FN_BAS_LOAD_DOCTOR_YMD( A.DOCTOR , TRUNC(SYSDATE) ) 
//                                   AND NVL(A.END_DATE, ADD_MONTHS(SYSDATE,1)) > TRUNC(SYSDATE) 
//                                   AND A.DOCTOR     = :f_code ";
//
//					bindVars.Clear();
//					bindVars.Add("f_code",code);
//					bindVars.Add("f_gwa",gwa);
//                    bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//					retVal = Service.ExecuteScalar(cmdText,bindVars);

                    // Connect to cloud service
                    OCS0503Q00DoctorNameArgs doctorNameArgs = new OCS0503Q00DoctorNameArgs();
			        doctorNameArgs.Gwa = gwa;
			        doctorNameArgs.DoctorCode = code;
			        OCS0503Q00DoctorNameResult doctorNameResult =
			            CloudService.Instance.Submit<OCS0503Q00DoctorNameResult, OCS0503Q00DoctorNameArgs>(doctorNameArgs);

                    if (doctorNameResult == null || doctorNameResult.ExecutionStatus != ExecutionStatus.Success)
						codeName = "";					
					else
                        codeName = doctorNameResult.DoctorName;
					break;
				default:
					break;
			}

			return codeName;
		}
		#endregion

		#region [GetFindWorker]
		private XFindWorker GetFindWorker(string findMode, string ref_code)
		{
			XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
			
			switch (findMode)
			{
				case "gwa":
					fdwCommon.AutoQuery    = true;
					fdwCommon.ServerFilter = false;
//					fdwCommon.InputSQL = @"SELECT A.GWA, A.GWA_NAME
//                                             FROM VW_BAS_GWA A
//                                            WHERE A.HOSP_CODE    = :f_hosp_code
//                                              AND A.START_DATE   = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, TRUNC(SYSDATE) )
//                                              AND A.OUT_JUBSU_YN = 'Y'
//                                            ORDER BY A.GWA";
//                    
//                    fdwCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);


                    // Connect to cloud service
			        fdwCommon.ExecuteQuery = fdwCommon_Gwa;
                    fdwCommon.FormText = Resource.fdwCommon_FormText1;
                    fdwCommon.ColInfos.Add("gwa", Resource.fdwCommon_col_gwa, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("gwa_name", Resource.fdwCommon_col_gwa_name, FindColType.String, 300, 0, true, FilterType.Yes);

					break;
				case "doctor":
					fdwCommon.AutoQuery    = true;
					fdwCommon.ServerFilter = false;
//                    fdwCommon.InputSQL = @"SELECT '%' DOCTOR, FN_ADM_MSG(221) DOCTOR_NAME, '0' SORT FROM SYS.DUAL                 
//                                           UNION ALL                                                                 
//                                           SELECT A.DOCTOR DOCTOR, A.DOCTOR_NAME, SUBSTR(A.DOCTOR, 3, 1)||A.DOCTOR SORT     
//                                             FROM BAS0270 A                                                          
//                                            WHERE A.HOSP_CODE = :f_hosp_code
//                                              AND A.START_DATE = FN_BAS_LOAD_DOCTOR_YMD( A.DOCTOR , TRUNC(SYSDATE) ) 
//                                              AND NVL(A.END_DATE,ADD_MONTHS(SYSDATE,1)) > TRUNC(SYSDATE)
//                                              AND A.DOCTOR_GWA = :f_gwa
//                                            ORDER BY 3 ";

                    fdwCommon.ParamList = new List<string>(new String[] { "f_gwa" });
                    fdwCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    fdwCommon.SetBindVarValue("f_gwa", ref_code);
			        fdwCommon.ExecuteQuery = fdwCommon_Doctor;
                    fdwCommon.FormText = Resource.fdwCommon_FormText2;
                    fdwCommon.ColInfos.Add("doctor", Resource.fdwCommon_col_doctor, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("doctor_name", Resource.fdwCommon_col_doctor_name, FindColType.String, 300, 0, true, FilterType.Yes);
					fdwCommon.ColInfos.Add("sort"       , " "             , FindColType.String, 0  , 0, false, FilterType.No );
			
					break;
				default:
					break;
			}

			return fdwCommon;
		}
		#endregion

		#region [RadioButton 조회 Data Filtering]
		/// <summary>
		/// 의뢰내용 응답여부
		/// </summary>
		private void rbtAct_Click(object sender, System.EventArgs e)
		{
			mAnswer_yn = "";
            
			if(rbtActY.Checked)
				mAnswer_yn = "Y";
			else if(rbtActN.Checked)
				mAnswer_yn = "N";
            		    
			foreach(object obj in pnlAct.Controls)
			{
				if(((XRadioButton)obj).Checked)
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
					((XRadioButton)obj).ImageIndex = 1;
				}
				else
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
					((XRadioButton)obj).ImageIndex = 0;
				}
			}

			SetFilter();
		}
		/// <summary>
		/// 입원외래구분
		/// </summary>
		private void rbtIO_gubun_Click(object sender, System.EventArgs e)
		{
			mIo_gubun = "";
            
			if(rbtOut.Checked)
				mIo_gubun = "O";
			else if(rbtIn.Checked)
				mIo_gubun = "I";
            		    
			foreach(object obj in pnlIO_gubun.Controls)
			{
				if(((XRadioButton)obj).Checked)
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
					((XRadioButton)obj).ImageIndex = 1;
				}
				else
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
					((XRadioButton)obj).ImageIndex = 0;
				}
			}

			SetFilter();
		}
		/// <summary>
		/// Consult 구분
		/// </summary
		private void rbtConsultGubun_Click(object sender, System.EventArgs e)
		{
			mConsultGubun = "";
            
			if(rbtCstGwa.Checked)
				mConsultGubun = "Y";
			else if(rbtCstDoc.Checked)
				mConsultGubun = "N";
            		    
			foreach(object obj in pnlConsultGubun.Controls)
			{
				if(((XRadioButton)obj).Checked)
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
					((XRadioButton)obj).ImageIndex = 1;
				}
				else
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
					((XRadioButton)obj).ImageIndex = 0;
				}
			}

			SetFilter();
		}
		/// <summary>
		/// 내원여부
		/// </summary>
		private void rbtNaewon_Click(object sender, System.EventArgs e)
		{
			mNaewon_yn = "";
            
			if(rbtNwY.Checked)
				mNaewon_yn = "Y";
			else if(rbtNwN.Checked)
				mNaewon_yn = "N";
            		    
			foreach(object obj in pnlNaewonYN.Controls)
			{
				if(((XRadioButton)obj).Checked)
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
					((XRadioButton)obj).ImageIndex = 1;
				}
				else
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
					((XRadioButton)obj).ImageIndex = 0;
				}
			}

			SetFilter();
		}       
        /// <summary>
		/// 의뢰내용을 Filtering합니다.
		/// </summary>
		private void SetFilter()
		{
			string filter = "";
		
			if(mAnswer_yn != "")
				filter = " answer_yn = '" + mAnswer_yn + "' ";
			
			if(mIo_gubun != "")
				filter = filter +  (filter == "" ? filter = " io_gubun = '" + mIo_gubun + "' " : " and io_gubun = '" + mIo_gubun + "' ");
			
			if(mConsultGubun != "")
				filter = filter + (filter == "" ? filter = " gwa_consult_yn = '" + mConsultGubun + "' " : " and gwa_consult_yn = '" + mConsultGubun + "' ");
			
			if(mNaewon_yn != "")
				filter = filter + (filter == "" ? filter = " naewon_yn = '" + mNaewon_yn + "' " : " and naewon_yn = '" + mNaewon_yn + "' ");
            
			grdConsult.ClearFilter();
			if(grdConsult.RowCount > 0) 
			{
				grdConsult.SetFilter(filter);
				if(grdConsult.RowCount > 0)
					grdConsult.SetFocusToItem(0, 0);
			}

			grdRequest.ClearFilter();
			if(grdRequest.RowCount > 0) 
			{
				grdRequest.SetFilter(filter);
				if(grdRequest.RowCount > 0)
					grdRequest.SetFocusToItem(0, 0);
			}
            
            // Connec to cloud service
            filteringTheInformationResult = FilteringTheInformation();

			grdConsultOUT1001.QueryLayout(true);
			grdRequestOUT1001.QueryLayout(true);
		}
		#endregion

		#region [Control Event]
		private void dpkFrom_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			LoadConsultInfo();
		}

		private void dpkTo_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			LoadConsultInfo();
		}

		private void fbxGwa_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			fbxGwa.FindWorker = this.GetFindWorker("gwa", "");
		}

		private void fbxGwa_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string codeName = "";

			fbxDoctor.SetDataValue("%");
		    string text = NetInfo.Language == LangMode.Jr ? "全体" : Resource.msg_all;
            dbxDoctor_name.SetDataValue(text);				

			if(e.DataValue == "")
			{
				dbxGwa_name.SetDataValue("");				
				return;
			}

			//Check Origin Data
			codeName = this.GetCodeName("gwa_name", e.DataValue.ToString());

			if(codeName == "")
			{
                mbxMsg = Resource.msg_invalid_key;
				mbxCap = "";
				XMessageBox.Show(mbxMsg, mbxCap);			
				dbxGwa_name.SetEditValue("");
			}					
			else
			{				
				dbxGwa_name.SetEditValue(codeName);			

				mGwa = e.DataValue;
				LoadConsultInfo();
			}
		}

		private void fbxDoctor_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string codeName = "";
            string text = Resource.msg_all;
			if(e.DataValue == "" || e.DataValue == "%")
			{
                dbxDoctor_name.SetDataValue(text);
				if(e.DataValue == "") fbxDoctor.SetDataValue("%");				

				if(this.fbxGwa.GetDataValue() != mDoctor && this.dbxGwa_name.GetDataValue() != "")
				{
					mDoctor = fbxGwa.GetDataValue();
					LoadConsultInfo();
				}
				return;
			}

            codeName = this.GetCodeName("doctor_name", e.DataValue.ToString());

			if(codeName == "")
			{
				mbxMsg = Resource.msg_invalid_key;
				mbxCap = "";
				XMessageBox.Show(mbxMsg, mbxCap);
				
				fbxDoctor.SetDataValue("%");
                dbxDoctor_name.SetDataValue(text);
				
			}	
			else if(codeName == "XXX")
			{
                mbxMsg = Resource.msg_invalid_key;
				mbxCap = "";
				XMessageBox.Show(mbxMsg, mbxCap);
				
				fbxDoctor.SetDataValue("%");
				dbxDoctor_name.SetDataValue(text);				
			}			
			else
			{
				dbxDoctor_name.SetEditValue(codeName);

				mDoctor = e.DataValue;
				LoadConsultInfo();
			}
		}

		private void fbxDoctor_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string gwa = fbxGwa.GetDataValue();

			if(TypeCheck.IsNull(gwa))
			{
                mbxMsg = Resource.msg_invalid_key;
				mbxCap = "";
				XMessageBox.Show(mbxMsg, mbxCap);
				return;
			}
					
			fbxDoctor.FindWorker = this.GetFindWorker("doctor", gwa);
		}
		#endregion

		#region [TabPage Event]
		private void tabConsultGubun_SelectionChanged(object sender, System.EventArgs e)
		{
			if(tabConsultGubun.SelectedIndex == 0)
			{
				pageConsult.ImageIndex = 1;
				pageRequest.ImageIndex = 0;

				grdConsult.Visible = true;
				grdRequest.Visible = false;
				grdConsultOUT1001.Visible = true;
				grdRequestOUT1001.Visible = false;
			}
			else
			{
				pageConsult.ImageIndex = 0;
				pageRequest.ImageIndex = 1;

				grdConsult.Visible = false;
				grdRequest.Visible = true;
				grdConsultOUT1001.Visible = false;
				grdRequestOUT1001.Visible = true;
			}
		}
		#endregion

		#region [Function]
		private void LoadConsultInfo()
		{
            // Connect to cloud service
            loadConsultInfoResult = LoadConsultInfoFromCloudService();

			grdConsult.QueryLayout(true);
			grdRequest.QueryLayout(true);

            SetFilter();
		}
		#endregion

		#region [타과의뢰내역 show]
		private void ShowOCS0503U00(int rowIndex)
		{
			if(rowIndex < 0) return;

			string bunho      = grdRequest.GetItemString(rowIndex, "bunho");
			string req_gwa    = grdRequest.GetItemString(rowIndex, "req_gwa");
			string req_doctor = grdRequest.GetItemString(rowIndex, "req_doctor");
			string req_date   = grdRequest.GetItemString(rowIndex, "req_date");

			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("bunho"     , bunho);
			openParams.Add("req_gwa"   , req_gwa);
			openParams.Add("req_doctor", req_doctor);
			openParams.Add("req_date"  , req_date);
			XScreen.OpenScreenWithParam( this, "OCSA", "OCS0503U00", ScreenOpenStyle.ResponseFixed, openParams);
		}

		private void ShowOCS0503U01(int rowIndex)
		{
			if(rowIndex < 0) return;

			string bunho          = grdConsult.GetItemString(rowIndex, "bunho");
			string consult_gwa    = grdConsult.GetItemString(rowIndex, "consult_gwa");
			string consult_doctor = grdConsult.GetItemString(rowIndex, "consult_doctor");
			string req_date       = grdConsult.GetItemString(rowIndex, "req_date");

			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("bunho"         , bunho);
			openParams.Add("consult_gwa"   , consult_gwa);
			openParams.Add("consult_doctor", consult_doctor);
			openParams.Add("req_date"      , req_date);
			XScreen.OpenScreenWithParam( this, "OCSA", "OCS0503U01", ScreenOpenStyle.ResponseFixed, openParams);
		}

		private void grdConsult_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdConsult.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				ShowOCS0503U01(curRowIndex);
			}
		}

		private void grdRequest_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdRequest.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				ShowOCS0503U00(curRowIndex);
			}
		}
		#endregion

		#region [진료내역 조회]
		private void ShowOCS1003Q03(XEditGrid grd, int rowIndex)
		{
			if(grd == null || rowIndex < 0) return;

			string bunho       = grd.GetItemString(rowIndex, "bunho");
			string naewon_date = grd.GetItemString(rowIndex, "naewon_date");
			string gwa         = grd.GetItemString(rowIndex, "gwa");
			string doctor      = grd.GetItemString(rowIndex, "doctor");
			string naewon_type = grd.GetItemString(rowIndex, "naewon_type");
			string jubsu_no    = grd.GetItemString(rowIndex, "jubsu_no");

			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("bunho"      , bunho);
			openParams.Add("naewon_date", naewon_date);
			openParams.Add("gwa"        , gwa);
			openParams.Add("doctor"     , doctor);
			openParams.Add("naewon_type", naewon_type);
			openParams.Add("jubsu_no"   , jubsu_no);
			XScreen.OpenScreenWithParam( this, "OCSO", "OCS1003Q03", ScreenOpenStyle.ResponseFixed, openParams);
		}

		private void grdConsultOUT1001_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdConsultOUT1001.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				ShowOCS1003Q03(grdConsultOUT1001, curRowIndex);
			}
		}

		private void grdRequestOUT1001_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdRequestOUT1001.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				ShowOCS1003Q03(grdRequestOUT1001, curRowIndex);
			}
		}
		#endregion

		#region [ButtonList Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{				
				case FunctionType.Query:
					e.IsBaseCall = false;
					LoadConsultInfo();
					break;
				default:
					break;
			}
		}
		#endregion

		#region [QueryStarting Event]
		private void grdConsultOUT1001_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			grdConsultOUT1001.SetBindVarValue("f_naewon_date", grdConsult.GetItemString(grdConsult.CurrentRowNumber,"naewon_date"));
//            grdConsultOUT1001.SetBindVarValue("f_bunho",       grdConsult.GetItemString(grdConsult.CurrentRowNumber, "bunho"));
//            grdConsultOUT1001.SetBindVarValue("f_hosp_code",   mHospCode);
		}

		private void grdRequestOUT1001_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			grdRequestOUT1001.SetBindVarValue("f_naewon_date", grdRequest.GetItemString(grdConsult.CurrentRowNumber,"naewon_date"));
//            grdRequestOUT1001.SetBindVarValue("f_bunho",       grdRequest.GetItemString(grdConsult.CurrentRowNumber, "bunho"));
//            grdRequestOUT1001.SetBindVarValue("f_hosp_code",   mHospCode);
		}

		private void grdConsult_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			grdConsult.SetBindVarValue("f_gwa",       fbxGwa.GetDataValue().ToString());
//			grdConsult.SetBindVarValue("f_doctor",    fbxDoctor.GetDataValue().ToString());
//			grdConsult.SetBindVarValue("f_from_date", dpkFrom_date.GetDataValue().ToString());
//            grdConsult.SetBindVarValue("f_to_date",   dpkTo_date.GetDataValue().ToString());
//            grdConsult.SetBindVarValue("f_hosp_code", mHospCode);
		}

		private void grdRequest_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			grdRequest.SetBindVarValue("f_gwa",       fbxGwa.GetDataValue().ToString());
//			grdRequest.SetBindVarValue("f_doctor",    fbxDoctor.GetDataValue().ToString());
//			grdRequest.SetBindVarValue("f_from_date", dpkFrom_date.GetDataValue().ToString());
//            grdRequest.SetBindVarValue("f_to_date",   dpkTo_date.GetDataValue().ToString());
//            grdRequest.SetBindVarValue("f_hosp_code", mHospCode);
		}
		#endregion

        #region [Get list doctor info]
        /// <summary>
        /// fdwCommon_Doctor
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
	    private IList<object[]> fdwCommon_Doctor(BindVarCollection varCollection)
	    {
            List<object[]> lstObject = new List<object[]>();
	        string gwa = varCollection["f_gwa"].VarValue;
	        if (string.IsNullOrEmpty(gwa))
	        {
	            return lstObject;
	        }
            OCS0503Q00FdwCommonDoctorArgs args = new OCS0503Q00FdwCommonDoctorArgs();
	        args.GwaCode = gwa;
	        OCS0503Q00FdwCommonDoctorResult doctorResult =
	            CloudService.Instance.Submit<OCS0503Q00FdwCommonDoctorResult, OCS0503Q00FdwCommonDoctorArgs>(args);
	        if (doctorResult != null && doctorResult.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<OCS0503Q00DoctorListInfo> lstDoctorListInfo = doctorResult.DoctorInfo;
	            if (lstDoctorListInfo != null && lstDoctorListInfo.Count > 0)
	            {
	                foreach (OCS0503Q00DoctorListInfo doctorListInfo in lstDoctorListInfo)
	                {
                        lstObject.Add(new object[]
	                    {
    	                    doctorListInfo.Doctor,
                            doctorListInfo.DoctorName,
                            doctorListInfo.DoctorSort
	                    });
	                }
	                
	            }
	        }
	        return lstObject;
        }
        #endregion

        #region get Gwa info
        /// <summary>
        /// fdwCommon_Gwa
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
	    private IList<object[]> fdwCommon_Gwa(BindVarCollection varCollection)
	    {
            List<object[]> lstObject = new List<object[]>();
	        OCS0503Q00FdwCommonGwaArgs args = new OCS0503Q00FdwCommonGwaArgs();
            ComboResult comboResult = CacheService.Instance.Get<OCS0503Q00FdwCommonGwaArgs, ComboResult>(args);
	        if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<ComboListItemInfo> lstComboListItemInfo = comboResult.ComboItem;
	            if (lstComboListItemInfo != null && lstComboListItemInfo.Count > 0)
	            {
	                foreach (ComboListItemInfo itemInfo in lstComboListItemInfo)
	                {
                        lstObject.Add(new object[]
	                    {
    	                    itemInfo.Code,
                            itemInfo.CodeName
	                    });
	                }
	                
	            }
	        }
	        return lstObject;
        }
        #endregion

        #region [grdRequestOUT1001 execute query]
        /// <summary>
        /// grdRequestOUT1001_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> grdRequestOUT1001_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObjs = new List<object[]>();
            if (filteringTheInformationResult != null)
            {
                List<OCS0503Q00FilteringTheInformationInfo> lstFilteringTheInformationInfo =
                    filteringTheInformationResult.GridRequestOut1001Info;
                if (lstFilteringTheInformationInfo != null && lstFilteringTheInformationInfo.Count > 0)
                {
                    lstObjs = ConvertFilteringTheInformationInfoToListObject(lstFilteringTheInformationInfo);
                }
            }
            return lstObjs;
        }
        #endregion

        #region [grdConsultOUT1001 execute query]
        /// <summary>
        /// grdConsultOUT1001_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
	    private IList<object[]> grdConsultOUT1001_ExecuteQuery(BindVarCollection varCollection)
	    {
	        IList<object[]> lstObjs = new List<object[]>();
	        if (filteringTheInformationResult != null)
	        {
	            List<OCS0503Q00FilteringTheInformationInfo> lstFilteringTheInformationInfo =
	                filteringTheInformationResult.GrdConsultOut1001;
	            if (lstFilteringTheInformationInfo != null && lstFilteringTheInformationInfo.Count > 0)
	            {
	                lstObjs = ConvertFilteringTheInformationInfoToListObject(lstFilteringTheInformationInfo);
	            }
	        }
	        return lstObjs;
	    } 
        #endregion

        #region [Connect to cloud service: get Filtering The Information]
        /// <summary>
        /// FilteringTheInformation
        /// </summary>
        /// <returns></returns>
        private OCS0503Q00FilteringTheInformationResult FilteringTheInformation()
	    {
	        OCS0503Q00FilteringTheInformationArgs args = new OCS0503Q00FilteringTheInformationArgs();
            args.GrdConsultNaewonDate = grdConsult.GetItemString(grdConsult.CurrentRowNumber, "naewon_date");
            args.GrdConsultBunho = grdConsult.GetItemString(grdConsult.CurrentRowNumber, "bunho");
            args.GridRequestBunho = grdRequest.GetItemString(grdConsult.CurrentRowNumber, "bunho");
	        args.GridRequestNaewonDate = grdRequest.GetItemString(grdConsult.CurrentRowNumber, "naewon_date");
	        OCS0503Q00FilteringTheInformationResult informationResult =
	            CloudService.Instance
	                .Submit<OCS0503Q00FilteringTheInformationResult, OCS0503Q00FilteringTheInformationArgs>(args);
	        if (informationResult == null || informationResult.ExecutionStatus != ExecutionStatus.Success)
	        {
	            return null;
	        }
	        return informationResult;
        }
        #endregion

        #region [grdConsult get data from cloud service]
        /// <summary>
        /// grdConsult ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
	    private IList<object[]> grdConsult_ExecuteQuery(BindVarCollection varCollection)
	    {
	        IList<object[]> lstObjs = new List<object[]>();
	        if (loadConsultInfoResult != null)
	        {
	            List<OCS0503Q00LoadConsultInfo> lstLoadConsultInfo = loadConsultInfoResult.GridConsultInfo;
	            if (lstLoadConsultInfo != null && lstLoadConsultInfo.Count > 0)
	            {
	                lstObjs = ConvertLoadConsultInfoToListObject(lstLoadConsultInfo);
	            }
	        }

	        return lstObjs;
        }
        #endregion

        #region [grdConsult get data from cloud service]
        /// <summary>
        /// grdRequest_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> grdRequest_ExecuteQuery(BindVarCollection varCollection)
	    {
            IList<object[]> lstObjs = new List<object[]>();
            if (loadConsultInfoResult != null)
            {
                List<OCS0503Q00LoadConsultInfo> lstLoadConsultInfo = loadConsultInfoResult.GridRequestOut1001Info;
                if (lstLoadConsultInfo != null && lstLoadConsultInfo.Count > 0)
                {
                    lstObjs = ConvertLoadConsultInfoToListObject(lstLoadConsultInfo);
                }
            }

            return lstObjs;
        }
        #endregion

        #region[Connect to cloud service OCS0503Q00LoadConsultInfo ]

        /// <summary>
        /// LoadConsultInfoFromCloudService
        /// </summary>
        /// <returns></returns>
	    private OCS0503Q00LoadConsultInfoResult LoadConsultInfoFromCloudService()
	    {
	        OCS0503Q00LoadConsultInfoArgs loadConsultInfoArgs = new OCS0503Q00LoadConsultInfoArgs();
	        loadConsultInfoArgs.Gwa = fbxGwa.GetDataValue().ToString();
	        loadConsultInfoArgs.Doctor = fbxDoctor.GetDataValue().ToString();
	        loadConsultInfoArgs.FromDate = dpkFrom_date.GetDataValue().ToString();
	        loadConsultInfoArgs.ToDate = dpkTo_date.GetDataValue();

	        OCS0503Q00LoadConsultInfoResult loadConsultInfoResult =
	            CloudService.Instance.Submit<OCS0503Q00LoadConsultInfoResult, OCS0503Q00LoadConsultInfoArgs>(
	                loadConsultInfoArgs);
	        if (loadConsultInfoResult == null || loadConsultInfoResult.ExecutionStatus != ExecutionStatus.Success)
	        {
	            return null;
	        }

	        return loadConsultInfoResult;
	    }
        #endregion

        #region [Convert from List<OCS0503Q00LoadConsultInfo> to List<object>]
        /// <summary>
        /// ConvertToListObject
        /// </summary>
        /// <param name="lstConsultListInfo"></param>
        /// <returns></returns>
	    private List<object[]> ConvertLoadConsultInfoToListObject(List<OCS0503Q00LoadConsultInfo> lstConsultListInfo)
	    {
	        List<object[]> lstObject = new List<object[]>();
            foreach (OCS0503Q00LoadConsultInfo info in lstConsultListInfo)
            {
                lstObject.Add(new object[]
                {
                    info.IoGubun,
                    info.AnswerYn,
                    info.GwaConsultYn,
                    info.NaewonDate,
                    info.JinryoTime,
                    info.Bunho,
                    info.Suname,
                    info.Suname2,
                    info.HoDong,
                    info.SexAge,
                    info.GubunName,
                    info.Gwa,
                    info.Doctor,
                    info.NaewonType,
                    info.JubsuNo,
                    info.Chojae,
                    info.ChojaeName,
                    info.PkNaewon,
                    info.NaewonYn,
                    info.ReqDate,
                    info.ReqGwa,
                    info.ReqDoctor,
                    info.ConsultGwa,
                    info.ConsultDoctor,
                    info.ReqIoGubun,
                    info.ConsGwaName,
                    info.ConsDoctorName,
                    info.AnswerUpdYn,
                    info.AppDate,
                    info.Pkocs0503,
                    info.OrderEndYn
                });
            }
	        return lstObject;
	    } 
        #endregion

        #region [Convert from List<OCS0503Q00FilteringTheInformationInfo> to List<object>]
        /// <summary>
        /// ConvertGrdRequestOUT1001ListInfoToListObject
        /// </summary>
        /// <param name="lstGrdRequestOut1001ListInfo"></param>
        /// <returns></returns>
	    private IList<object[]> ConvertFilteringTheInformationInfoToListObject(
	        List<OCS0503Q00FilteringTheInformationInfo> lstGrdRequestOut1001ListInfo)
	    {
            List<object[]> lstObject = new List<object[]>();
	        foreach (OCS0503Q00FilteringTheInformationInfo info in lstGrdRequestOut1001ListInfo)
	        {
	            lstObject.Add(new object[]
	            {
	                info.ReserYn,
                    info.JinryoTime,
                    info.GwaName,
                    info.DoctorName,
                    info.NaewonYn,
                    info.Bunho,
                    info.NaewonDate,
                    info.Gwa,
                    info.Doctor,
                    info.NaewonType,
                    info.JubsuNo
	            });
	        }
	        return lstObject;
	    }
        #endregion
    }
}

