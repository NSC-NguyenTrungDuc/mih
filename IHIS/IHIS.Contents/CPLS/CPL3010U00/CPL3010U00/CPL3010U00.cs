#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms.VisualStyles;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.CPLS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL3010U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL3010U00 : IHIS.Framework.XScreen
    {
        #region 자동생성
        private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XPanel xPanel8;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel7;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XLabel xLabel10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XLabel xLabel12;
		private IHIS.Framework.XDisplayBox dbxJubsuTime;
		private IHIS.Framework.XDisplayBox dbxGwa;
		private IHIS.Framework.XDisplayBox dbxInOutGubun;
		private IHIS.Framework.XDisplayBox dbxTat2;
		private IHIS.Framework.XDisplayBox dbxTa2;
		private IHIS.Framework.XDisplayBox dbxTat1;
		private IHIS.Framework.XDisplayBox dbxTa1;
		private IHIS.Framework.XDisplayBox dbxBunho;
		private IHIS.Framework.XDisplayBox dbxJubsuja;
		private IHIS.Framework.XDisplayBox dbxJubsuDate;
		private IHIS.Framework.XDisplayBox dbxSpecimenName;
		private IHIS.Framework.XDisplayBox dbxSpecimenCode;
		private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XDisplayBox dbxJundalGubunName;
        private IHIS.Framework.XDatePicker dtpJubsuDate;
		private IHIS.Framework.XLabel xLabel11;
		private IHIS.Framework.XDisplayBox dbxHoDong;
		private IHIS.Framework.XDisplayBox dbxHoCode;
		private IHIS.Framework.SingleLayout vsvJubsuja;
        private IHIS.Framework.SingleLayout vsvJundalGubun;
		private IHIS.Framework.XFindWorker fwkJundalGubun;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.SingleLayout laySpecimenInfo;
		private IHIS.Framework.XEditGrid grdGum;
		private IHIS.Framework.XMstGrid grdPart;
        private IHIS.Framework.XDisplayBox dbxJu;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XDisplayBox dbxSex;
		private IHIS.Framework.XDisplayBox dbxAge;
		private IHIS.Framework.XPanel pnlUrine;
		private System.Windows.Forms.NumericUpDown numUrine;
		private IHIS.Framework.XLabel xLabel36;
		private IHIS.Framework.XDisplayBox dbxGumsaName;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.SingleLayout dsvUrine;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XDisplayBox dbxDoctor;
		private IHIS.Framework.XLabel xLabel15;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.MultiLayout layUrine;
		private IHIS.Framework.XButton btnUrine;
		private System.Windows.Forms.NumericUpDown numWeight;
		private System.Windows.Forms.NumericUpDown numHeight;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XButton btnPrintSetup;
		private IHIS.Framework.XButton btnBarcode;
		private IHIS.Framework.MultiLayout layBarcode2;
		private IHIS.Framework.MultiLayout layBarcode;
        private IHIS.Framework.SingleLayout layPrintName;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Drawing.Printing.PrintDocument printDocument1;
   //     private IHIS.Framework.XDataWindow dwBarcode;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.MultiLayout layBarcodeOne;
		private IHIS.Framework.XButton btnBunjuBarcode;
		private IHIS.Framework.XButton btn7180EndPrint;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XButton btnChangeHiv;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XButton btnChangeBlood;
        private IHIS.Framework.XButton btnChangeHangche;
		private IHIS.Framework.XPaInfoBox paInfoBox;
		private IHIS.Framework.XLabel lbNyo2;
		private IHIS.Framework.XLabel lbNyo1;
		private IHIS.Framework.XRadioButton rbxNoUsed;
		private IHIS.Framework.XRadioButton rbxUsed;
		private IHIS.Framework.XLabel lbStability;
		private IHIS.Framework.XLabel lbWeight2;
		private IHIS.Framework.XLabel lbWeight;
		private IHIS.Framework.XLabel lbHeight2;
		private IHIS.Framework.XLabel lbHeight;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditMask txtSpecimenRead;
        private IHIS.Framework.SingleLayout laySpecimenRead;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem8;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem11;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private SingleLayoutItem singleLayoutItem18;
        private SingleLayoutItem singleLayoutItem19;
        private SingleLayoutItem singleLayoutItem20;
        private SingleLayoutItem singleLayoutItem21;
        private SingleLayoutItem singleLayoutItem22;
        private SingleLayoutItem singleLayoutItem23;
        private SingleLayoutItem singleLayoutItem24;
        private SingleLayoutItem singleLayoutItem25;
        private SingleLayoutItem singleLayoutItem26;
        private SingleLayoutItem singleLayoutItem27;
        private SingleLayoutItem singleLayoutItem28;
        private SingleLayoutItem singleLayoutItem29;
        private SingleLayoutItem singleLayoutItem30;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayout layBarcodeTemp;
        private MultiLayout layBarcodeTemp2;
        private SingleLayoutItem singleLayoutItem32;
        private SingleLayoutItem singleLayoutItem31;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private MultiLayoutItem multiLayoutItem70;
        private MultiLayoutItem multiLayoutItem71;
        private MultiLayoutItem multiLayoutItem72;
        private MultiLayoutItem multiLayoutItem73;
        private MultiLayoutItem multiLayoutItem74;
        private MultiLayoutItem multiLayoutItem75;
        private MultiLayoutItem multiLayoutItem76;
        private MultiLayoutItem multiLayoutItem77;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem78;
        private MultiLayoutItem multiLayoutItem97;
        private MultiLayoutItem multiLayoutItem98;
        private MultiLayoutItem multiLayoutItem99;
        private MultiLayoutItem multiLayoutItem100;
        private MultiLayoutItem multiLayoutItem101;
        private MultiLayoutItem multiLayoutItem102;
        private MultiLayoutItem multiLayoutItem103;
        private MultiLayoutItem multiLayoutItem104;
        private MultiLayoutItem multiLayoutItem105;
        private MultiLayoutItem multiLayoutItem106;
        private MultiLayoutItem multiLayoutItem107;
        private MultiLayoutItem multiLayoutItem108;
        private MultiLayoutItem multiLayoutItem109;
        private MultiLayoutItem multiLayoutItem110;
        private MultiLayoutItem multiLayoutItem111;
        private MultiLayoutItem multiLayoutItem112;
        private MultiLayoutItem multiLayoutItem79;
        private MultiLayoutItem multiLayoutItem80;
        private MultiLayoutItem multiLayoutItem81;
        private MultiLayoutItem multiLayoutItem82;
        private MultiLayoutItem multiLayoutItem83;
        private MultiLayoutItem multiLayoutItem84;
        private MultiLayoutItem multiLayoutItem85;
        private MultiLayoutItem multiLayoutItem86;
        private MultiLayoutItem multiLayoutItem87;
        private MultiLayoutItem multiLayoutItem88;
        private MultiLayoutItem multiLayoutItem89;
        private MultiLayoutItem multiLayoutItem90;
        private MultiLayoutItem multiLayoutItem91;
        private MultiLayoutItem multiLayoutItem92;
        private MultiLayoutItem multiLayoutItem93;
        private MultiLayoutItem multiLayoutItem94;
        private MultiLayoutItem multiLayoutItem95;
        private MultiLayoutItem multiLayoutItem96;
        private MultiLayoutItem multiLayoutItem113;
        private MultiLayoutItem multiLayoutItem114;
        private SingleLayout laySpcialName_YN;
        private SingleLayoutItem singleLayoutItem33;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private SingleLayoutItem singleLayoutItem34;
        private SingleLayoutItem singleLayoutItem35;
        private XEditGridCell xEditGridCell36;
        #endregion 
        private XDictComboBox cbxActor;

        /// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPL3010U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            // Init ParamList and ExecuteQuery
            this.dsvUrine.ParamList = new List<string>(new String[] { "f_fkocs", "f_in_out_gubun", "f_specimen_ser" ,  "f_gubun"});
		    this.dsvUrine.ExecuteQuery = ExecuteQueryCPL3010U00DsvUrine;

            this.grdGum.ParamList = new List<string>(new String[] { "f_specimen_ser" });
		    this.grdGum.ExecuteQuery = ExecuteQueryCPL3010U00GrdGum;

            this.grdPart.ParamList = new List<string>(new String[] { "f_part_jubsu_date", "f_specimen_ser" });
		    this.grdPart.ExecuteQuery = ExecuteQueryCPL3010U00GrdPart;

            this.layBarcodeTemp.ParamList = new List<string>(new String[] { "f_specimen_ser" });
		    this.layBarcodeTemp.ExecuteQuery = ExecuteQueryCPL3010U00LayBarCodeTemp;

            this.layBarcodeTemp2.ParamList = new List<string>(new String[] { "f_specimen_ser" });
		    this.layBarcodeTemp2.ExecuteQuery = ExecuteQueryCPL3010U00LayBarCodeTemp2;

            this.laySpecimenInfo.ParamList = new List<string>(new String[] { "f_specimen_ser" });
            this.laySpecimenInfo.ExecuteQuery = ExecuteQueryCPL3010U00LaySpecimenInfo;

            this.laySpcialName_YN.ParamList = new List<string>(new String[] { "f_specimen_ser" });
		    this.laySpcialName_YN.ExecuteQuery = ExecuteQueryString;

            this.layPrintName.ParamList = new List<string>(new String[] { "f_ip_addr" });
		    this.layPrintName.ExecuteQuery = ExecuteQueryGetPrintName;

            // Load combobox
		    this.cbxActor.ExecuteQuery = LoadDataCbxActor;
		    this.cbxActor.SetDictDDLB();

            // Init ParamList and ExecuteQuery for singlelayout
            this.vsvJubsuja.ParamList = new List<string>(new String[] { "f_user_id" });
		    this.vsvJubsuja.ExecuteQuery = ExecuteQueryVSVJubsuja;

            this.vsvJundalGubun.ParamList = new List<string>(new String[] { "f_code", "f_code_type" });
		    this.vsvJundalGubun.ExecuteQuery = ExecuteQueryVSVJundalGubun;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL3010U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdGum = new IHIS.Framework.XEditGrid();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.grdPart = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.dbxJu = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.pnlUrine = new IHIS.Framework.XPanel();
            this.rbxNoUsed = new IHIS.Framework.XRadioButton();
            this.rbxUsed = new IHIS.Framework.XRadioButton();
            this.lbStability = new IHIS.Framework.XLabel();
            this.lbWeight2 = new IHIS.Framework.XLabel();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.lbWeight = new IHIS.Framework.XLabel();
            this.lbHeight2 = new IHIS.Framework.XLabel();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.lbHeight = new IHIS.Framework.XLabel();
            this.btnUrine = new IHIS.Framework.XButton();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.dbxDoctor = new IHIS.Framework.XDisplayBox();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.dbxGumsaName = new IHIS.Framework.XDisplayBox();
            this.lbNyo2 = new IHIS.Framework.XLabel();
            this.numUrine = new System.Windows.Forms.NumericUpDown();
            this.lbNyo1 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.paInfoBox = new IHIS.Framework.XPaInfoBox();
            this.dbxAge = new IHIS.Framework.XDisplayBox();
            this.dbxHoCode = new IHIS.Framework.XDisplayBox();
            this.dbxHoDong = new IHIS.Framework.XDisplayBox();
            this.dbxJubsuTime = new IHIS.Framework.XDisplayBox();
            this.dbxGwa = new IHIS.Framework.XDisplayBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.dbxInOutGubun = new IHIS.Framework.XDisplayBox();
            this.dbxTat2 = new IHIS.Framework.XDisplayBox();
            this.dbxTa2 = new IHIS.Framework.XDisplayBox();
            this.dbxTat1 = new IHIS.Framework.XDisplayBox();
            this.dbxTa1 = new IHIS.Framework.XDisplayBox();
            this.dbxBunho = new IHIS.Framework.XDisplayBox();
            this.dbxJubsuja = new IHIS.Framework.XDisplayBox();
            this.dbxJubsuDate = new IHIS.Framework.XDisplayBox();
            this.dbxSpecimenName = new IHIS.Framework.XDisplayBox();
            this.dbxSpecimenCode = new IHIS.Framework.XDisplayBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dbxSex = new IHIS.Framework.XDisplayBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btn7180EndPrint = new IHIS.Framework.XButton();
            this.btnBunjuBarcode = new IHIS.Framework.XButton();
            this.btnPrintSetup = new IHIS.Framework.XButton();
            this.btnBarcode = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.fwkJundalGubun = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.txtSpecimenRead = new IHIS.Framework.XEditMask();
            this.btnChangeHangche = new IHIS.Framework.XButton();
            this.btnChangeBlood = new IHIS.Framework.XButton();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.dtpJubsuDate = new IHIS.Framework.XDatePicker();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.btnChangeHiv = new IHIS.Framework.XButton();
            this.dbxJundalGubunName = new IHIS.Framework.XDisplayBox();
            this.vsvJubsuja = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem31 = new IHIS.Framework.SingleLayoutItem();
            this.vsvJundalGubun = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem32 = new IHIS.Framework.SingleLayoutItem();
            this.laySpecimenInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem20 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem21 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem22 = new IHIS.Framework.SingleLayoutItem();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.layUrine = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.dsvUrine = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem23 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem24 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem25 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem26 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem34 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem35 = new IHIS.Framework.SingleLayoutItem();
            this.layBarcode2 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem70 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem71 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem72 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem73 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem74 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem75 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem76 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem77 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcode = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.layPrintName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem30 = new IHIS.Framework.SingleLayoutItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.layBarcodeOne = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem78 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem97 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem98 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem99 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem100 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem101 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem102 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem103 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem104 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem105 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem106 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem107 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem108 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem109 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem110 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem111 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem112 = new IHIS.Framework.MultiLayoutItem();
            this.laySpecimenRead = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem27 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem28 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem29 = new IHIS.Framework.SingleLayoutItem();
            this.layBarcodeTemp = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem79 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem80 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem81 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem82 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem83 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem84 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem85 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem86 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem87 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem88 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem89 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem90 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem91 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem92 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem93 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem94 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem113 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem114 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcodeTemp2 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.laySpcialName_YN = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem33 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPart)).BeginInit();
            this.pnlUrine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrine)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paInfoBox)).BeginInit();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layUrine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp2)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Controls.Add(this.xPanel8);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.grdGum);
            this.xPanel4.Controls.Add(this.pnlUrine);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // grdGum
            // 
            resources.ApplyResources(this.grdGum, "grdGum");
            this.grdGum.ApplyPaintEventToAllColumn = true;
            this.grdGum.CallerID = '2';
            this.grdGum.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell22,
            this.xEditGridCell18,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell23,
            this.xEditGridCell19,
            this.xEditGridCell24,
            this.xEditGridCell28,
            this.xEditGridCell31});
            this.grdGum.ColPerLine = 6;
            this.grdGum.ColResizable = true;
            this.grdGum.Cols = 7;
            this.grdGum.ExecuteQuery = null;
            this.grdGum.FixedCols = 1;
            this.grdGum.FixedRows = 1;
            this.grdGum.HeaderHeights.Add(37);
            this.grdGum.MasterLayout = this.grdPart;
            this.grdGum.Name = "grdGum";
            this.grdGum.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdGum.ParamList")));
            this.grdGum.QuerySQL = resources.GetString("grdGum.QuerySQL");
            this.grdGum.RowHeaderVisible = true;
            this.grdGum.Rows = 2;
            this.grdGum.ToolTipActive = true;
            this.grdGum.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdGum_PreSaveLayout);
            this.grdGum.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdGum_RowFocusChanged);
            this.grdGum.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdGum_GridCellPainting);
            this.grdGum.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGum_QueryStarting);
            this.grdGum.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdGum_QueryEnd);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "specimen_ser";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "pkcpl2010";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "gumsa_name";
            this.xEditGridCell7.CellWidth = 135;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jangbi";
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "cpl_result";
            this.xEditGridCell11.CellWidth = 74;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "specimen_name";
            this.xEditGridCell12.CellWidth = 100;
            this.xEditGridCell12.Col = 5;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "hangmog_code";
            this.xEditGridCell13.CellWidth = 100;
            this.xEditGridCell13.Col = 6;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "part_jubsuja";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "jubsu_yn";
            this.xEditGridCell19.CellWidth = 70;
            this.xEditGridCell19.Col = 1;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "spcial_name";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "fkocs";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "confirm_yn";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // grdPart
            // 
            resources.ApplyResources(this.grdPart, "grdPart");
            this.grdPart.ApplyPaintEventToAllColumn = true;
            this.grdPart.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell36,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell14,
            this.xEditGridCell16,
            this.xEditGridCell21,
            this.xEditGridCell26,
            this.xEditGridCell25,
            this.xEditGridCell27,
            this.xEditGridCell30,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35});
            this.grdPart.ColPerLine = 10;
            this.grdPart.ColResizable = true;
            this.grdPart.Cols = 11;
            this.grdPart.ControlBinding = true;
            this.grdPart.ExecuteQuery = null;
            this.grdPart.FixedCols = 1;
            this.grdPart.FixedRows = 1;
            this.grdPart.HeaderHeights.Add(39);
            this.grdPart.Name = "grdPart";
            this.grdPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPart.ParamList")));
            this.grdPart.QuerySQL = resources.GetString("grdPart.QuerySQL");
            this.grdPart.RowHeaderVisible = true;
            this.grdPart.Rows = 2;
            this.grdPart.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPart.ToolTipActive = true;
            this.grdPart.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdPart_PreSaveLayout);
            this.grdPart.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdPart_ItemValueChanging);
            this.grdPart.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPart_RowFocusChanged);
            this.grdPart.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPart_GridCellPainting);
            this.grdPart.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPart_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "lab_no";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 11;
            this.xEditGridCell2.CellName = "specimen_ser";
            this.xEditGridCell2.CellWidth = 110;
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 5;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.SuppressRepeating = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 105;
            this.xEditGridCell4.Col = 6;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gwa_name";
            this.xEditGridCell5.CellWidth = 104;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "ho_dong";
            this.xEditGridCell6.CellWidth = 48;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "part_jubsu_date";
            this.xEditGridCell36.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell36.Col = 2;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "part_jubsu_time";
            this.xEditGridCell9.CellWidth = 50;
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.Mask = "##:##";
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "part_jubsuja";
            this.xEditGridCell10.CellWidth = 131;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "jubsuja";
            this.xEditGridCell14.CellWidth = 135;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.BindControl = this.dbxJu;
            this.xEditGridCell16.CellName = "remark";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // dbxJu
            // 
            resources.ApplyResources(this.dbxJu, "dbxJu");
            this.dbxJu.Name = "dbxJu";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "part_jubsu_flag";
            this.xEditGridCell21.CellWidth = 70;
            this.xEditGridCell21.Col = 1;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "fkocs";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "in_out_gubun";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellLen = 30;
            this.xEditGridCell27.CellName = "doctor";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 30;
            this.xEditGridCell30.CellName = "tube_name";
            this.xEditGridCell30.CellWidth = 71;
            this.xEditGridCell30.Col = 8;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 60;
            this.xEditGridCell32.Col = 9;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdCol = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "sunab_yn";
            this.xEditGridCell33.CellWidth = 55;
            this.xEditGridCell33.Col = 10;
            this.xEditGridCell33.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdCol = false;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "result_yn";
            this.xEditGridCell34.CellWidth = 46;
            this.xEditGridCell34.Col = 7;
            this.xEditGridCell34.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "label_one_more";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // pnlUrine
            // 
            resources.ApplyResources(this.pnlUrine, "pnlUrine");
            this.pnlUrine.Controls.Add(this.rbxNoUsed);
            this.pnlUrine.Controls.Add(this.rbxUsed);
            this.pnlUrine.Controls.Add(this.lbStability);
            this.pnlUrine.Controls.Add(this.lbWeight2);
            this.pnlUrine.Controls.Add(this.numWeight);
            this.pnlUrine.Controls.Add(this.lbWeight);
            this.pnlUrine.Controls.Add(this.lbHeight2);
            this.pnlUrine.Controls.Add(this.numHeight);
            this.pnlUrine.Controls.Add(this.lbHeight);
            this.pnlUrine.Controls.Add(this.btnUrine);
            this.pnlUrine.Controls.Add(this.xLabel15);
            this.pnlUrine.Controls.Add(this.dbxDoctor);
            this.pnlUrine.Controls.Add(this.xLabel36);
            this.pnlUrine.Controls.Add(this.dbxGumsaName);
            this.pnlUrine.Controls.Add(this.lbNyo2);
            this.pnlUrine.Controls.Add(this.numUrine);
            this.pnlUrine.Controls.Add(this.lbNyo1);
            this.pnlUrine.Name = "pnlUrine";
            // 
            // rbxNoUsed
            // 
            resources.ApplyResources(this.rbxNoUsed, "rbxNoUsed");
            this.rbxNoUsed.Name = "rbxNoUsed";
            this.rbxNoUsed.UseVisualStyleBackColor = false;
            // 
            // rbxUsed
            // 
            resources.ApplyResources(this.rbxUsed, "rbxUsed");
            this.rbxUsed.Name = "rbxUsed";
            this.rbxUsed.UseVisualStyleBackColor = false;
            // 
            // lbStability
            // 
            resources.ApplyResources(this.lbStability, "lbStability");
            this.lbStability.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbStability.Name = "lbStability";
            // 
            // lbWeight2
            // 
            resources.ApplyResources(this.lbWeight2, "lbWeight2");
            this.lbWeight2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbWeight2.Name = "lbWeight2";
            // 
            // numWeight
            // 
            resources.ApplyResources(this.numWeight, "numWeight");
            this.numWeight.DecimalPlaces = 1;
            this.numWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numWeight.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numWeight.Name = "numWeight";
            this.numWeight.ReadOnly = true;
            this.numWeight.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // lbWeight
            // 
            resources.ApplyResources(this.lbWeight, "lbWeight");
            this.lbWeight.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbWeight.Name = "lbWeight";
            // 
            // lbHeight2
            // 
            resources.ApplyResources(this.lbHeight2, "lbHeight2");
            this.lbHeight2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHeight2.Name = "lbHeight2";
            // 
            // numHeight
            // 
            resources.ApplyResources(this.numHeight, "numHeight");
            this.numHeight.DecimalPlaces = 1;
            this.numHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.ReadOnly = true;
            this.numHeight.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            // 
            // lbHeight
            // 
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHeight.Name = "lbHeight";
            // 
            // btnUrine
            // 
            resources.ApplyResources(this.btnUrine, "btnUrine");
            this.btnUrine.Image = ((System.Drawing.Image)(resources.GetObject("btnUrine.Image")));
            this.btnUrine.Name = "btnUrine";
            this.btnUrine.Click += new System.EventHandler(this.btnUrine_Click);
            // 
            // xLabel15
            // 
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel15.Name = "xLabel15";
            // 
            // dbxDoctor
            // 
            resources.ApplyResources(this.dbxDoctor, "dbxDoctor");
            this.dbxDoctor.Name = "dbxDoctor";
            // 
            // xLabel36
            // 
            resources.ApplyResources(this.xLabel36, "xLabel36");
            this.xLabel36.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel36.Name = "xLabel36";
            // 
            // dbxGumsaName
            // 
            resources.ApplyResources(this.dbxGumsaName, "dbxGumsaName");
            this.dbxGumsaName.Name = "dbxGumsaName";
            // 
            // lbNyo2
            // 
            resources.ApplyResources(this.lbNyo2, "lbNyo2");
            this.lbNyo2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbNyo2.Name = "lbNyo2";
            // 
            // numUrine
            // 
            resources.ApplyResources(this.numUrine, "numUrine");
            this.numUrine.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUrine.Name = "numUrine";
            // 
            // lbNyo1
            // 
            resources.ApplyResources(this.lbNyo1, "lbNyo1");
            this.lbNyo1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbNyo1.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lbNyo1.Name = "lbNyo1";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.grdPart);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.dbxJu);
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.paInfoBox);
            this.xPanel2.Controls.Add(this.dbxAge);
            this.xPanel2.Controls.Add(this.dbxHoCode);
            this.xPanel2.Controls.Add(this.dbxHoDong);
            this.xPanel2.Controls.Add(this.dbxJubsuTime);
            this.xPanel2.Controls.Add(this.dbxGwa);
            this.xPanel2.Controls.Add(this.xLabel10);
            this.xPanel2.Controls.Add(this.dbxInOutGubun);
            this.xPanel2.Controls.Add(this.dbxTat2);
            this.xPanel2.Controls.Add(this.dbxTa2);
            this.xPanel2.Controls.Add(this.dbxTat1);
            this.xPanel2.Controls.Add(this.dbxTa1);
            this.xPanel2.Controls.Add(this.dbxBunho);
            this.xPanel2.Controls.Add(this.dbxJubsuja);
            this.xPanel2.Controls.Add(this.dbxJubsuDate);
            this.xPanel2.Controls.Add(this.dbxSpecimenName);
            this.xPanel2.Controls.Add(this.dbxSpecimenCode);
            this.xPanel2.Controls.Add(this.xLabel7);
            this.xPanel2.Controls.Add(this.dbxSex);
            this.xPanel2.Controls.Add(this.xLabel6);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.dbxSuname);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // paInfoBox
            // 
            resources.ApplyResources(this.paInfoBox, "paInfoBox");
            this.paInfoBox.Name = "paInfoBox";
            // 
            // dbxAge
            // 
            resources.ApplyResources(this.dbxAge, "dbxAge");
            this.dbxAge.Name = "dbxAge";
            // 
            // dbxHoCode
            // 
            resources.ApplyResources(this.dbxHoCode, "dbxHoCode");
            this.dbxHoCode.Name = "dbxHoCode";
            // 
            // dbxHoDong
            // 
            resources.ApplyResources(this.dbxHoDong, "dbxHoDong");
            this.dbxHoDong.Name = "dbxHoDong";
            // 
            // dbxJubsuTime
            // 
            resources.ApplyResources(this.dbxJubsuTime, "dbxJubsuTime");
            this.dbxJubsuTime.Mask = "##:##";
            this.dbxJubsuTime.Name = "dbxJubsuTime";
            // 
            // dbxGwa
            // 
            resources.ApplyResources(this.dbxGwa, "dbxGwa");
            this.dbxGwa.Name = "dbxGwa";
            // 
            // xLabel10
            // 
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.Name = "xLabel10";
            // 
            // dbxInOutGubun
            // 
            resources.ApplyResources(this.dbxInOutGubun, "dbxInOutGubun");
            this.dbxInOutGubun.Name = "dbxInOutGubun";
            // 
            // dbxTat2
            // 
            resources.ApplyResources(this.dbxTat2, "dbxTat2");
            this.dbxTat2.Mask = "##日##:##";
            this.dbxTat2.Name = "dbxTat2";
            // 
            // dbxTa2
            // 
            resources.ApplyResources(this.dbxTa2, "dbxTa2");
            this.dbxTa2.Name = "dbxTa2";
            // 
            // dbxTat1
            // 
            resources.ApplyResources(this.dbxTat1, "dbxTat1");
            this.dbxTat1.Mask = "##日##:##";
            this.dbxTat1.Name = "dbxTat1";
            // 
            // dbxTa1
            // 
            resources.ApplyResources(this.dbxTa1, "dbxTa1");
            this.dbxTa1.Name = "dbxTa1";
            // 
            // dbxBunho
            // 
            resources.ApplyResources(this.dbxBunho, "dbxBunho");
            this.dbxBunho.Name = "dbxBunho";
            // 
            // dbxJubsuja
            // 
            resources.ApplyResources(this.dbxJubsuja, "dbxJubsuja");
            this.dbxJubsuja.Name = "dbxJubsuja";
            // 
            // dbxJubsuDate
            // 
            resources.ApplyResources(this.dbxJubsuDate, "dbxJubsuDate");
            this.dbxJubsuDate.Name = "dbxJubsuDate";
            // 
            // dbxSpecimenName
            // 
            resources.ApplyResources(this.dbxSpecimenName, "dbxSpecimenName");
            this.dbxSpecimenName.Name = "dbxSpecimenName";
            // 
            // dbxSpecimenCode
            // 
            resources.ApplyResources(this.dbxSpecimenCode, "dbxSpecimenCode");
            this.dbxSpecimenCode.Name = "dbxSpecimenCode";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Name = "xLabel7";
            // 
            // dbxSex
            // 
            resources.ApplyResources(this.dbxSex, "dbxSex");
            this.dbxSex.Name = "dbxSex";
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Name = "xLabel5";
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Name = "xLabel3";
            // 
            // xPanel8
            // 
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.Controls.Add(this.btn7180EndPrint);
            this.xPanel8.Controls.Add(this.btnBunjuBarcode);
            this.xPanel8.Controls.Add(this.btnPrintSetup);
            this.xPanel8.Controls.Add(this.btnBarcode);
            this.xPanel8.Controls.Add(this.btnList);
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Name = "xPanel8";
            // 
            // btn7180EndPrint
            // 
            resources.ApplyResources(this.btn7180EndPrint, "btn7180EndPrint");
            this.btn7180EndPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btn7180EndPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn7180EndPrint.Image = ((System.Drawing.Image)(resources.GetObject("btn7180EndPrint.Image")));
            this.btn7180EndPrint.Name = "btn7180EndPrint";
            this.btn7180EndPrint.Click += new System.EventHandler(this.btn7180EndPrint_Click);
            // 
            // btnBunjuBarcode
            // 
            resources.ApplyResources(this.btnBunjuBarcode, "btnBunjuBarcode");
            this.btnBunjuBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnBunjuBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBunjuBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBunjuBarcode.Image")));
            this.btnBunjuBarcode.Name = "btnBunjuBarcode";
            this.btnBunjuBarcode.Click += new System.EventHandler(this.btnBunjuBarcode_Click);
            // 
            // btnPrintSetup
            // 
            resources.ApplyResources(this.btnPrintSetup, "btnPrintSetup");
            this.btnPrintSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSetup.Image")));
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // btnBarcode
            // 
            resources.ApplyResources(this.btnBarcode, "btnBarcode");
            this.btnBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcode.Image")));
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            // 
            // fwkJundalGubun
            // 
            this.fwkJundalGubun.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkJundalGubun.ExecuteQuery = null;
            this.fwkJundalGubun.FormText = global::IHIS.CPLS.Properties.Resource.fwkJundalGubunName;
            this.fwkJundalGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkJundalGubun.ParamList")));
            this.fwkJundalGubun.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkJundalGubun.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "gubun";
            this.findColumnInfo1.ColWidth = 106;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "gubun_name";
            this.findColumnInfo2.ColWidth = 315;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "part_jubsu_flag";
            this.xEditGridCell17.CellWidth = 28;
            this.xEditGridCell17.Col = 1;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            // 
            // xPanel6
            // 
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Controls.Add(this.cbxActor);
            this.xPanel6.Controls.Add(this.txtSpecimenRead);
            this.xPanel6.Controls.Add(this.btnChangeHangche);
            this.xPanel6.Controls.Add(this.btnChangeBlood);
            this.xPanel6.Controls.Add(this.xLabel11);
            this.xPanel6.Controls.Add(this.xLabel12);
            this.xPanel6.Controls.Add(this.xLabel8);
            this.xPanel6.Controls.Add(this.dtpJubsuDate);
            this.xPanel6.Controls.Add(this.xLabel9);
            this.xPanel6.Controls.Add(this.btnChangeHiv);
            this.xPanel6.Controls.Add(this.dbxJundalGubunName);
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Name = "xPanel6";
            // 
            // cbxActor
            // 
            resources.ApplyResources(this.cbxActor, "cbxActor");
            this.cbxActor.ExecuteQuery = null;
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxActor.ParamList")));
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxActor.UserSQL = resources.GetString("cbxActor.UserSQL");
            // 
            // txtSpecimenRead
            // 
            resources.ApplyResources(this.txtSpecimenRead, "txtSpecimenRead");
            this.txtSpecimenRead.EditVietnameseMaskType = IHIS.Framework.MaskType.String;
            this.txtSpecimenRead.IsVietnameseYearType = false;
            this.txtSpecimenRead.Name = "txtSpecimenRead";
            this.txtSpecimenRead.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSpecimenRead_DataValidating);
            // 
            // btnChangeHangche
            // 
            resources.ApplyResources(this.btnChangeHangche, "btnChangeHangche");
            this.btnChangeHangche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnChangeHangche.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChangeHangche.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeHangche.Image")));
            this.btnChangeHangche.Name = "btnChangeHangche";
            this.btnChangeHangche.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnChangeHangche.Click += new System.EventHandler(this.btnChangeHangche_Click);
            // 
            // btnChangeBlood
            // 
            resources.ApplyResources(this.btnChangeBlood, "btnChangeBlood");
            this.btnChangeBlood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnChangeBlood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChangeBlood.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeBlood.Image")));
            this.btnChangeBlood.Name = "btnChangeBlood";
            this.btnChangeBlood.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnChangeBlood.Click += new System.EventHandler(this.btnChangeBlood_Click);
            // 
            // xLabel11
            // 
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel12
            // 
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // dtpJubsuDate
            // 
            resources.ApplyResources(this.dtpJubsuDate, "dtpJubsuDate");
            this.dtpJubsuDate.IsVietnameseYearType = false;
            this.dtpJubsuDate.Name = "dtpJubsuDate";
            this.dtpJubsuDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJubsuDate_DataValidating);
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Name = "xLabel9";
            // 
            // btnChangeHiv
            // 
            resources.ApplyResources(this.btnChangeHiv, "btnChangeHiv");
            this.btnChangeHiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnChangeHiv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChangeHiv.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeHiv.Image")));
            this.btnChangeHiv.Name = "btnChangeHiv";
            this.btnChangeHiv.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnChangeHiv.Click += new System.EventHandler(this.btnChangeHiv_Click);
            // 
            // dbxJundalGubunName
            // 
            resources.ApplyResources(this.dbxJundalGubunName, "dbxJundalGubunName");
            this.dbxJundalGubunName.Name = "dbxJundalGubunName";
            // 
            // vsvJubsuja
            // 
            this.vsvJubsuja.ExecuteQuery = null;
            this.vsvJubsuja.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem31});
            this.vsvJubsuja.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvJubsuja.ParamList")));
            this.vsvJubsuja.QueryStarting += new System.ComponentModel.CancelEventHandler(this.vsvJubsuja_QueryStarting);
            // 
            // singleLayoutItem31
            // 
            this.singleLayoutItem31.DataName = "jubsuja_name";
            // 
            // vsvJundalGubun
            // 
            this.vsvJundalGubun.ExecuteQuery = null;
            this.vsvJundalGubun.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem32});
            this.vsvJundalGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvJundalGubun.ParamList")));
            this.vsvJundalGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.vsvJundalGubun_QueryStarting);
            this.vsvJundalGubun.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.vsvJundalGubun_QueryEnd);
            // 
            // singleLayoutItem32
            // 
            this.singleLayoutItem32.DataName = "code_name";
            // 
            // laySpecimenInfo
            // 
            this.laySpecimenInfo.ExecuteQuery = null;
            this.laySpecimenInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem11,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17,
            this.singleLayoutItem18,
            this.singleLayoutItem19,
            this.singleLayoutItem20,
            this.singleLayoutItem21,
            this.singleLayoutItem22});
            this.laySpecimenInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySpecimenInfo.ParamList")));
            this.laySpecimenInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySpecimenInfo_QueryStarting);
            this.laySpecimenInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.laySpecimenInfo_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxBunho;
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.dbxSuname;
            this.singleLayoutItem2.DataName = "suname";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.BindControl = this.dbxSex;
            this.singleLayoutItem3.DataName = "sex";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "birth";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.BindControl = this.dbxGwa;
            this.singleLayoutItem5.DataName = "gwa";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "doctor_name";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.BindControl = this.dbxHoDong;
            this.singleLayoutItem7.DataName = "ho_dong";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.BindControl = this.dbxHoCode;
            this.singleLayoutItem8.DataName = "ho_code";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "order_date";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.BindControl = this.dbxJubsuDate;
            this.singleLayoutItem10.DataName = "jubsu_date";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "part_jubsu_date";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.BindControl = this.dbxJubsuTime;
            this.singleLayoutItem12.DataName = "jubsu_time";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "part_jubsu_time";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.BindControl = this.dbxJubsuja;
            this.singleLayoutItem14.DataName = "jubsuja";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.BindControl = this.dbxInOutGubun;
            this.singleLayoutItem15.DataName = "in_out_gubun";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "jundal_gubun";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.BindControl = this.dbxSpecimenCode;
            this.singleLayoutItem17.DataName = "specimen_code";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.BindControl = this.dbxSpecimenName;
            this.singleLayoutItem18.DataName = "specimen_name";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.BindControl = this.dbxTat1;
            this.singleLayoutItem19.DataName = "tat1";
            // 
            // singleLayoutItem20
            // 
            this.singleLayoutItem20.BindControl = this.dbxTat2;
            this.singleLayoutItem20.DataName = "tat2";
            // 
            // singleLayoutItem21
            // 
            this.singleLayoutItem21.BindControl = this.dbxAge;
            this.singleLayoutItem21.DataName = "age";
            // 
            // singleLayoutItem22
            // 
            this.singleLayoutItem22.DataName = "switch";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "part_jubsuja";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // layUrine
            // 
            this.layUrine.CallerID = '3';
            this.layUrine.ExecuteQuery = null;
            this.layUrine.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49});
            this.layUrine.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layUrine.ParamList")));
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "pkcpl1000";
            this.multiLayoutItem44.IsUpdItem = true;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "urine_ryang";
            this.multiLayoutItem45.IsUpdItem = true;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "height";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "weight";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "stability_yn";
            this.multiLayoutItem48.IsUpdItem = true;
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "specimen_ser";
            this.multiLayoutItem49.IsUpdItem = true;
            // 
            // dsvUrine
            // 
            this.dsvUrine.ExecuteQuery = null;
            this.dsvUrine.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem23,
            this.singleLayoutItem24,
            this.singleLayoutItem25,
            this.singleLayoutItem26,
            this.singleLayoutItem34,
            this.singleLayoutItem35});
            this.dsvUrine.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dsvUrine.ParamList")));
            this.dsvUrine.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dsvUrine_QueryStarting);
            // 
            // singleLayoutItem23
            // 
            this.singleLayoutItem23.DataName = "pkcpl1000";
            // 
            // singleLayoutItem24
            // 
            this.singleLayoutItem24.DataName = "urine_ryang";
            // 
            // singleLayoutItem25
            // 
            this.singleLayoutItem25.DataName = "height";
            // 
            // singleLayoutItem26
            // 
            this.singleLayoutItem26.DataName = "weight";
            // 
            // singleLayoutItem34
            // 
            this.singleLayoutItem34.DataName = "stability_yn";
            // 
            // singleLayoutItem35
            // 
            this.singleLayoutItem35.DataName = "specimen_ser";
            // 
            // layBarcode2
            // 
            this.layBarcode2.ExecuteQuery = null;
            this.layBarcode2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61,
            this.multiLayoutItem62,
            this.multiLayoutItem63,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69,
            this.multiLayoutItem70,
            this.multiLayoutItem71,
            this.multiLayoutItem72,
            this.multiLayoutItem73,
            this.multiLayoutItem74,
            this.multiLayoutItem75,
            this.multiLayoutItem76,
            this.multiLayoutItem77});
            this.layBarcode2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcode2.ParamList")));
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "jundal_gubun";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "specimen_code";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "specimen_name";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "tube_code";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "tube_name";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "in_out_gubun";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "specimen_ser";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "bunho";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "suname";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "gwa_name";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "danger_yn";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "jangbi_code";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "jangbi_name";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "hangmog_code";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "tube_max_amt";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "tube_numbering";
            // 
            // layBarcode
            // 
            this.layBarcode.ExecuteQuery = null;
            this.layBarcode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20});
            this.layBarcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcode.ParamList")));
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "jundal_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "specimen_code";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "specimen_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "tube_code";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "tube_name";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "in_out_gubun";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "specimen_ser";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "bunho";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "suname";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "gwa_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "danger_yn";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jangbi_code";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "jangbi_name";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "hangmog_code";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "tube_max_amt";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "tube_numbering";
            // 
            // layPrintName
            // 
            this.layPrintName.ExecuteQuery = null;
            this.layPrintName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem30});
            this.layPrintName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPrintName.ParamList")));
            this.layPrintName.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPrintName_QueryStarting);
            // 
            // singleLayoutItem30
            // 
            this.singleLayoutItem30.DataName = "print_name";
            // 
            // layBarcodeOne
            // 
            this.layBarcodeOne.ExecuteQuery = null;
            this.layBarcodeOne.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem38,
            this.multiLayoutItem78,
            this.multiLayoutItem97,
            this.multiLayoutItem98,
            this.multiLayoutItem99,
            this.multiLayoutItem100,
            this.multiLayoutItem101,
            this.multiLayoutItem102,
            this.multiLayoutItem103,
            this.multiLayoutItem104,
            this.multiLayoutItem105,
            this.multiLayoutItem106,
            this.multiLayoutItem107,
            this.multiLayoutItem108,
            this.multiLayoutItem109,
            this.multiLayoutItem110,
            this.multiLayoutItem111,
            this.multiLayoutItem112});
            this.layBarcodeOne.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeOne.ParamList")));
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "jundal_gubun";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "specimen_code";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "specimen_name";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "tube_code";
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "tube_name";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "in_out_gubun";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "specimen_ser";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "bunho";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "suname";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "gwa_name";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "danger_yn";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "jangbi_code";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "jangbi_name";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "tube_max_amt";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "tube_numbering";
            // 
            // laySpecimenRead
            // 
            this.laySpecimenRead.ExecuteQuery = null;
            this.laySpecimenRead.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem27,
            this.singleLayoutItem28,
            this.singleLayoutItem29});
            this.laySpecimenRead.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySpecimenRead.ParamList")));
            // 
            // singleLayoutItem27
            // 
            this.singleLayoutItem27.DataName = "jubsu_ok";
            // 
            // singleLayoutItem28
            // 
            this.singleLayoutItem28.DataName = "already_jubsu";
            // 
            // singleLayoutItem29
            // 
            this.singleLayoutItem29.DataName = "flag";
            // 
            // layBarcodeTemp
            // 
            this.layBarcodeTemp.ExecuteQuery = null;
            this.layBarcodeTemp.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem79,
            this.multiLayoutItem80,
            this.multiLayoutItem81,
            this.multiLayoutItem82,
            this.multiLayoutItem83,
            this.multiLayoutItem84,
            this.multiLayoutItem85,
            this.multiLayoutItem86,
            this.multiLayoutItem87,
            this.multiLayoutItem88,
            this.multiLayoutItem89,
            this.multiLayoutItem90,
            this.multiLayoutItem91,
            this.multiLayoutItem92,
            this.multiLayoutItem93,
            this.multiLayoutItem94,
            this.multiLayoutItem95,
            this.multiLayoutItem96,
            this.multiLayoutItem113,
            this.multiLayoutItem114});
            this.layBarcodeTemp.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeTemp.ParamList")));
            this.layBarcodeTemp.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBarcodeTemp_QueryStarting);
            this.layBarcodeTemp.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layBarcodeTemp_QueryEnd);
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "jundal_gubun";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "specimen_code";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "specimen_name";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "tube_code";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "tube_name";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "in_out_gubun";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "specimen_ser";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "bunho";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "suname";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "gwa_name";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "danger_yn";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "jangbi_code";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "jangbi_name";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "tube_count";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "hangmog_code";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "tube_max_amt";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "tube_numbering";
            // 
            // layBarcodeTemp2
            // 
            this.layBarcodeTemp2.ExecuteQuery = null;
            this.layBarcodeTemp2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem37});
            this.layBarcodeTemp2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeTemp2.ParamList")));
            this.layBarcodeTemp2.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBarcodeTemp2_QueryStarting);
            this.layBarcodeTemp2.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layBarcodeTemp2_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "jundal_gubun";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "specimen_code";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "specimen_name";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "tube_code";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "tube_name";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "in_out_gubun";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "specimen_ser";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "bunho";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "suname";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "gwa_name";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "danger_yn";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "jangbi_code";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "jangbi_name";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "tube_max_amt";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "tube_numbering";
            // 
            // laySpcialName_YN
            // 
            this.laySpcialName_YN.ExecuteQuery = null;
            this.laySpcialName_YN.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem33});
            this.laySpcialName_YN.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySpcialName_YN.ParamList")));
            this.laySpcialName_YN.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySpcialName_YN_QueryStarting);
            // 
            // singleLayoutItem33
            // 
            this.singleLayoutItem33.DataName = "spcialname_yn";
            // 
            // CPL3010U00
            // 
            resources.ApplyResources(this, "$this");
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel6);
            this.Name = "CPL3010U00";
            this.xPanel1.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPart)).EndInit();
            this.pnlUrine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrine)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paInfoBox)).EndInit();
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.xPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layUrine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            // TODO comment: use connect cloud
            /*this.grdPart.SavePerformer = new XSavePerformer(this);
            this.grdGum.SavePerformer = this.grdPart.SavePerformer;
            this.layUrine.SavePerformer = this.grdPart.SavePerformer;*/


            this.dtpJubsuDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            //this.txtHHMM.SetDataValue(EnvironInfo.GetSysDateTime().ToString("HHmm"));

            this.dbxTa1.SetDataValue("TAT1");
            this.dbxTa2.SetDataValue("TAT2");

            this.cbxActor.Text = UserInfo.UserName;

            this.txtSpecimenRead.Focus();
		}
		#endregion


        #region 채혈자 벨리데이션
        private void vsvJubsuja_QueryStarting(object sender, CancelEventArgs e)
        {
            this.vsvJubsuja.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.vsvJubsuja.SetBindVarValue("f_code", this.cbxActor.GetDataValue());
        }
		#endregion

        #region 전달파트 벨리데이션
        private void vsvJundalGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.vsvJundalGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.vsvJundalGubun.SetBindVarValue("f_code", this.fbxJundalGubun.GetDataValue());
        }
		#endregion

        #region 장비코드 벨리데이션
        private void vsvJangbi_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.vsvJangbi.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.vsvJangbi.SetBindVarValue("f_code", this.fbxJangbi.GetDataValue());
        }
		#endregion

		#region 파트그리드의 로우 포커스 체인지
		private void grdPart_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            this.pnlUrine.Size = new Size(355, 0);

			this.paInfoBox.SetPatientID(this.grdPart.GetItemString(this.grdPart.CurrentRowNumber,"bunho"));

            this.grdGum.QueryLayout(false);
            
            if (!this.laySpecimenInfo.QueryLayout())
                XMessageBox.Show(Service.ErrFullMsg);

            this.laySpcialName_YN.QueryLayout();
            if (this.laySpcialName_YN.GetItemValue("spcialname_yn").ToString() == "Y")
            {
                this.lbHeight.Visible = true; ;
                this.lbHeight2.Visible = true;
                this.numHeight.Visible = true;
                this.lbWeight.Visible = true; ;
                this.lbWeight2.Visible = true;
                this.numWeight.Visible = true;
                this.lbStability.Visible = false;
                this.rbxNoUsed.Visible = false;
                this.rbxUsed.Visible = false;

                this.dbxGumsaName.ResetData();

                for (int i = 0; i < this.grdGum.RowCount; i++)
                {
                    if (this.grdGum.GetItemString(i, "spcial_name") == "04")
                    {
                        this.grdGum.SelectRow(i);
                        this.dbxGumsaName.SetDataValue(this.grdGum.GetItemString(i, "gumsa_name"));
                        break;
                    }
                }

                this.pnlUrine.Size = new Size(355, 54);
                
                //this.dbxGumsaName.SetDataValue(this.grdGum.GetItemString(e.CurrentRow, "gumsa_name"));

                this.dsvUrine.SetBindVarValue("f_gubun", "1"); //SPECIMEN_SER로 조회
                
                if (this.dsvUrine.QueryLayout())
                {
                    if (this.dsvUrine.GetItemValue("specimen_ser").ToString() == "")
                    {
                        this.dsvUrine.SetBindVarValue("f_gubun", "2"); // 간호쪽데이타 조회
                        this.dsvUrine.QueryLayout();                        
                    }

                    try
                    {
                        this.numUrine.Value = int.Parse(this.dsvUrine.GetItemValue("urine_ryang").ToString());                        
                    }
                    catch { }
                    this.dbxDoctor.SetDataValue(this.grdPart.GetItemString(this.grdPart.CurrentRowNumber, "doctor"));
                }

                if (this.numUrine.Value <= 0)
                {
                    XMessageBox.Show(Resource.XMessageBox1, Resource.XMessageBox1_caption, MessageBoxIcon.Information);
                }

            }
            //else
            //    this.pnlUrine.Size = new Size(355, 0);
		}
		#endregion

		#region 파트파인드창 벨리데이션 후

        private void vsvJundalGubun_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //this.fbxJangbi.SetDataValue("");
            //this.txtSpecimen.SetDataValue("");
            //this.grdPart.QueryLayout(false);
        }
		#endregion

        #region grdPart_PreGetValue
        private void grdPart_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            // TODO Comment use cloud connect
            /*if ( e.RowState == DataRowState.Modified )
                this.grdPart.SetItemValue(e.RowNumber, "part_jubsuja", this.cbxActor.GetDataValue());*/
        }
		#endregion

        #region grdGum_PreGetValue
        private void grdGum_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            // TODO Comment use cloud connect
            /*if (e.RowState == DataRowState.Modified)
            {
                this.grdGum.SetItemValue(e.RowNumber, "part_jubsuja", this.cbxActor.GetDataValue());
            }*/
        }
		#endregion

		#region 버튼리스트 수행 후
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch ( e.Func )
			{
				case FunctionType.Update:
					if ( e.IsSuccess == true )
					{
                        //this.MakeMessage();
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 취소저장 후 메세지 처리/ 재조회
		private void MakeMessage()
		{
			string errorMessage = "";

			this.grdPart.QueryLayout(false);
			
			string msg = (NetInfo.Language == LangMode.Ko ? Resource.msg1_Ko
				: Resource.msg1_JP);
			string msg1 = (NetInfo.Language == LangMode.Ko ? Resource.msg2_Ko
				: Resource.msg2_JP);
			string msg2 = (NetInfo.Language == LangMode.Ko ? Resource.msg3_Ko
				: "");
			string msg3 = (NetInfo.Language == LangMode.Ko ? Resource.msg4_Ko
				: Resource.msg4_JP);
			string msg4 = (NetInfo.Language == LangMode.Ko ? Resource.msg5_Ko
				: Resource.msg5_JP);
			string msg5 = (NetInfo.Language == LangMode.Ko ? Resource.msg6_Ko
				: Resource.msg6_JP);
					
			switch ( o_flag )
			{
				case "O":
					XMessageBox.Show(msg);
					break;
				case "P":
					errorMessage = msg1 + o_specimen_ser + msg2;
					for ( int j = 0; j < this.grdPart.RowCount; j++ )
					{
						if ( this.grdPart.GetItemString(j,"specimen_ser") == o_specimen_ser)
						{
							this.grdPart.SetFocusToItem(j,"specimen_ser");
							break;
						}
					}
					for ( int i = 0; i < this.grdGum.RowCount; i++ )
					{
						if ( this.grdGum.GetItemString(i,"pkcpl2010") == o_pkcpl2010)
						{
							errorMessage += this.grdGum.GetItemString(i,"gumsa_name") 
								+ msg3;
							this.grdGum.SetFocusToItem(i,"gumsa_name");
							break;
						}
					}
					XMessageBox.Show(errorMessage);
					break;
				case "C":
					if ( o_gubun == "1" )
					{
						for ( int k = 0; k < this.grdPart.RowCount; k++ )
						{
							if ( this.grdPart.GetItemString(k,"specimen_ser") == o_specimen_ser )
							{
								this.grdPart.SetFocusToItem(k,"specimen_ser");
								break;
							}
						}
                        errorMessage = o_specimen_ser;
						errorMessage += "\n" + msg5;
					}
					else 
					{
						errorMessage = msg1 + o_specimen_ser + msg2;
						for ( int j = 0; j < this.grdPart.RowCount; j++ )
						{
							if ( this.grdPart.GetItemString(j,"specimen_ser") == o_specimen_ser )
							{
								this.grdPart.SetFocusToItem(j,"specimen_ser");
								break;
							}
						}
						for ( int i = 0; i < this.grdGum.RowCount; i++ )
						{
							if ( this.grdGum.GetItemString(i,"pkcpl2010") == o_pkcpl2010 )
							{
								errorMessage += this.grdGum.GetItemString(i,"gumsa_name") 
									+ msg4;
								this.grdGum.SetFocusToItem(i,"gumsa_name");
								break;
							}
						}
					}
					XMessageBox.Show(errorMessage);
					break;
				default:
                    //msg = (NetInfo.Language == LangMode.Ko ? "검체가 취소 저장되었습니다."
                    //    : "検体がキャンセル保存されました。");
                    //XMessageBox.Show(msg);
					break;
			}
		}
		#endregion

		#region 버튼리스트 수햏 전
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
            if (this.cbxActor.GetDataValue().Length == 0)
            {
                XMessageBox.Show(Resource.XMessageBox2, Resource.XMessageBox2_Caption, MessageBoxIcon.Warning);
                this.cbxActor.Focus();
                return;
            }

			switch ( e.Func )
			{
				case FunctionType.Query:
					e.IsBaseCall = false;

			        this.grdPart.ExecuteQuery = ExecuteQueryCPL3010U00GrdPart;
                    this.grdPart.QueryLayout(false);

					break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = true;
                    try
                    {

                        // TODO comment: Use connect to cloud 
                       /* Service.BeginTransaction();

                        if (!this.grdGum.SaveLayout())
                            throw new Exception();

                        if (!this.grdPart.SaveLayout())
                            throw new Exception();


                        Service.CommitTransaction();*/

                        // Connect to cloud service
                        CPL3010U00SaveLayoutArgs args = new CPL3010U00SaveLayoutArgs();
                        args.GrdGumInfo = CreateListGrdGumInfo();
                        args.GrdPartInfo = CreateListGrdPartInfo();
                        args.UserId = cbxActor.GetDataValue();
                        UpdateResult updateResult =
                            CloudService.Instance.Submit<UpdateResult, CPL3010U00SaveLayoutArgs>(args);
                        if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success || updateResult.Result == false) 
                            throw new Exception();

                        XMessageBox.Show(Resource.XMessageBox3 , Resource.XMessageBox2_Caption, MessageBoxIcon.Information);

                        this.btnList.PerformClick(FunctionType.Query);
                    }
                    catch
                    {
//                        Service.RollbackTransaction();
                        e.IsSuccess = false;
                        XMessageBox.Show(Resource.XMessageBox4 + mErrMsg, Resource.XMessageBox4_Caption, MessageBoxIcon.Error);
                    }

                    break;

				default:
					break;
			}
		}
		#endregion

		#region dtpJubsuDate_DataValidating
		private void dtpJubsuDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.dbxJundalGubunName.SetDataValue("");
            this.grdPart.QueryLayout(false);
		}
		#endregion

		#region 파트그리드 셀페인팅
		private void grdPart_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if ( this.grdPart.GetItemString(e.RowNumber,"part_jubsu_flag") == "Y" )
				e.BackColor = Color.LightYellow;
			else 
				e.BackColor = Color.White;

			if ( e.DataRow["sunab_yn"].ToString() == "Y" )
				e.BackColor = Color.MistyRose;

			if ( e.DataRow["emergency"].ToString() == "Y" )
				e.ForeColor = Color.Red;
		}
		#endregion

		#region 항목별그리드 셀페인팅
		private void grdGum_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if ( this.grdGum.GetItemString(e.RowNumber,"jubsu_yn") == "Y" )
				e.BackColor = Color.LightYellow;
			else
				e.BackColor = Color.White;

			if (e.DataRow["confirm_yn"].ToString() == "Y") 
				e.BackColor = XColor.XLabelGradientEndColor.Color;
		}
		#endregion

		#region 검사그리드 로우 포커스 이벤트
		private void grdGum_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            //string spcial_name = this.grdGum.GetItemString(e.CurrentRow,"spcial_name");
            //if ( spcial_name == "03" )
            //{
            //    this.lbHeight.Visible = true;;
            //    this.lbHeight2.Visible = true;
            //    this.numHeight.Visible = true;
            //    this.lbWeight.Visible = true;;
            //    this.lbWeight2.Visible = true;
            //    this.numWeight.Visible = true;
            //    this.lbStability.Visible = false;
            //    this.rbxNoUsed.Visible = false;
            //    this.rbxUsed.Visible = false;
				
            //    this.pnlUrine.Size = new Size(355, 80);
            //    this.dbxGumsaName.SetDataValue(this.grdGum.GetItemString(e.CurrentRow,"gumsa_name"));
            //    if(this.dsvUrine.QueryLayout())
            //    {
            //        try
            //        {
            //            this.numUrine.Value = int.Parse(this.dsvUrine.GetItemValue("urine_ryang").ToString());
            //            this.numHeight.Value = decimal.Parse(this.dsvUrine.GetItemValue("height").ToString());
            //            this.numWeight.Value = decimal.Parse(this.dsvUrine.GetItemValue("weight").ToString());
            //        }
            //        catch{}
            //        this.dbxDoctor.SetDataValue(this.grdPart.GetItemString(this.grdPart.CurrentRowNumber,"doctor"));
            //    }

            //}
            //else if ( (spcial_name == "04") || (spcial_name == "05") )
            //{
            //    this.lbHeight.Visible = true;;
            //    this.lbHeight2.Visible = true;
            //    this.numHeight.Visible = true;
            //    this.lbWeight.Visible = true;;
            //    this.lbWeight2.Visible = true;
            //    this.numWeight.Visible = true;
            //    this.lbStability.Visible = false;
            //    this.rbxNoUsed.Visible = false;
            //    this.rbxUsed.Visible = false;

            //    this.pnlUrine.Size = new Size(355, 54);
            //    this.dbxGumsaName.SetDataValue(this.grdGum.GetItemString(e.CurrentRow,"gumsa_name"));
            //    if(this.dsvUrine.QueryLayout())
            //    {
            //        try
            //        {
            //            this.numUrine.Value = int.Parse(this.dsvUrine.GetItemValue("urine_ryang").ToString());
            //        }
            //        catch{}
            //        this.dbxDoctor.SetDataValue(this.grdPart.GetItemString(this.grdPart.CurrentRowNumber,"doctor"));
            //    }

            //}
            //else if ( spcial_name == "01" )
            //{
            //    this.lbHeight.Visible = false;
            //    this.lbHeight2.Visible = false;
            //    this.numHeight.Visible = false;
            //    this.lbWeight.Visible = false;
            //    this.lbWeight2.Visible = false;
            //    this.numWeight.Visible = false;
            //    this.lbStability.Visible = true;
            //    this.rbxNoUsed.Visible = true;
            //    this.rbxUsed.Visible = true;

            //    this.pnlUrine.Size = new Size(355, 80);
            //    this.dbxGumsaName.SetDataValue(this.grdGum.GetItemString(e.CurrentRow,"gumsa_name"));
            //    if(this.dsvUrine.QueryLayout())
            //    {
            //        try
            //        {
            //            if ( this.layUrine.GetItemString(0,"stability_yn") == "Y" )
            //                this.rbxUsed.Checked = true;
            //            else 
            //                this.rbxNoUsed.Checked = true;
            //            this.numUrine.Value = int.Parse(this.dsvUrine.GetItemValue("urine_ryang").ToString());
            //        }
            //        catch{}
            //        this.dbxDoctor.SetDataValue(this.grdPart.GetItemString(this.grdPart.CurrentRowNumber,"doctor"));
            //    }

            //}
            //else
            //    this.pnlUrine.Size = new Size(355, 0);
		}
		#endregion

		private void btnUrine_Click(object sender, System.EventArgs e)
		{
			if ( this.pnlUrine.Size.Height > 0 )
			{
				if ( this.layUrine.RowCount == 0 )
					this.layUrine.InsertRow(-1);

                if (this.dsvUrine.GetItemValue("pkcpl1000").ToString() != "")
                {
                    this.layUrine.SetItemValue(0, "pkcpl1000", this.dsvUrine.GetItemValue("pkcpl1000").ToString());
                }
                else
                {
                    // TODO comment use connect to cloud
//                    string cmdText = @"SELECT NVL(MAX(PKCPL1000), 0) + 1
//                                          FROM CPL1000
//                                         WHERE HOSP_CODE = '" +  EnvironInfo.HospCode + "'" ;
//
//                    object pkcpl1000 = Service.ExecuteScalar(cmdText);

                    // Connect to cloud
                    CPL3010U00BtnUrineClickArgs args = new CPL3010U00BtnUrineClickArgs();
                    CPL3010U00BtnUrineClickResult result =
                        CloudService.Instance.Submit<CPL3010U00BtnUrineClickResult, CPL3010U00BtnUrineClickArgs>(args);
                    string aPkcpl1000 = "";
                    if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        aPkcpl1000 = result.Value;
                    }
                    this.layUrine.SetItemValue(0, "pkcpl1000", aPkcpl1000);
                }
				
				if ( this.rbxUsed.Checked == true )
					this.layUrine.SetItemValue(0,"stability_yn","Y");
				else
					this.layUrine.SetItemValue(0,"stability_yn","N");

                if (this.numUrine.Value <= 0)
                {
                    XMessageBox.Show(Resource.XMessageBox5, Resource.XMessageBox1_caption, MessageBoxIcon.Information);
                    return;
                }

				this.layUrine.SetItemValue(0,"urine_ryang",this.numUrine.Value);

                this.layUrine.SetItemValue(0, "specimen_ser", this.grdPart.GetItemValue(this.grdPart.CurrentRowNumber, "specimen_ser"));

                // Connect to cloud execute save layUrine
                CPL3010U00SaveLayUrineArgs saveLayUrineArgs = new CPL3010U00SaveLayUrineArgs();
                saveLayUrineArgs.UrineInfo = CreateListLayUrineInfo();
                saveLayUrineArgs.UserId = cbxActor.GetDataValue();
			    UpdateResult updateResult =
			        CloudService.Instance.Submit<UpdateResult, CPL3010U00SaveLayUrineArgs>(saveLayUrineArgs);

//                if (!this.layUrine.SaveLayout())
                if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success || updateResult.Result == false)
                {
                    XMessageBox.Show(Resource.XMessageBox4 + Service.ErrFullMsg, Resource.XMessageBox4_Caption, MessageBoxIcon.Error);
                }
                else
                {
                    XMessageBox.Show(Resource.XMessageBox6 , Resource.XMessageBox2_Caption, MessageBoxIcon.Information);                
                }
			}
		}

		#region 바코드 리더기 처리
		private void txtSpecimen_TextChanged(object sender, System.EventArgs e)
		{
            //if (this.txtSpecimen.Text.Length == 10)
            //{
            //    string specimen_ser = txtSpecimen.Text;
            //    if ( (this.dbxJubsujaName.GetDataValue().Length == 0) && (this.txtJubsuja.GetDataValue().Length == 0) )
            //    {
            //        this.txtSpecimen.SetDataValue("");
            //        string msg = (NetInfo.Language == LangMode.Ko ? "사원번호를 입력해 주세요"
            //            : "社員番号を入力してください");
            //        XMessageBox.Show(msg);
            //        this.txtJubsuja.Focus();
            //        return;
            //    }
            //    this.txtSpecimen.AcceptData();
				 
            //    if ( this.DataServiceCall(this.dsvJubsuUpdate) == true)
            //    {
            //        if ( this.dsvJubsuUpdate.GetOutValue("jubsu_ok").ToString() == "Y" )
            //        {
            //            SetPrintBacode(2);
            //            string msg = (NetInfo.Language == LangMode.Ko ? "검체가 접수되었습니다."
            //                : "検体が受付されました。");
            //            this.SetMsg(msg);
            //            if ( this.dtpJubsuDate.GetDataValue().ToString() != EnvironInfo.GetSysDate().ToString() )
            //                this.dtpJubsuDate.SetDataValue(EnvironInfo.GetSysDate());

            //            // 검체조회
            //            this.DataServiceCall(this.dsvSpecimenBySer);
            //            this.txtSpecimen.SetDataValue("");
            //            this.txtSpecimen.Focus();
            //        }
            //        else if ( this.dsvJubsuUpdate.GetOutValue("jubsu_ok").ToString() == "X" )
            //        {
            //            string msg = (NetInfo.Language == LangMode.Ko ? "해당검체는 선택된 장비로 보내질 수 없습니다."
            //                : "該当検体は選択された装置に遅れません。");
            //            XMessageBox.Show(msg);
            //            this.txtSpecimen.Focus();
            //        }
            //        else
            //        {
            //            if ( this.dsvJubsuUpdate.GetOutValue("already_jubsu").ToString() == "Y" )
            //            {
            //                string msg = (NetInfo.Language == LangMode.Ko ? "이미 접수된 검체입니다."
            //                    : "既に、受付された検体です。");
            //                XMessageBox.Show(msg);
            //                // 검체조회
            //                dsvSpecimenBySer.SetInValue("specimen_ser",specimen_ser);
            //                this.DataServiceCall(this.dsvSpecimenBySer);
            //            } 
            //            else
            //            {
            //                string msg = (NetInfo.Language == LangMode.Ko ? "검체번호가 존재하지 않습니다."
            //                    : "検体番号が存在しません。");
            //                XMessageBox.Show(msg);
            //                this.txtSpecimen.Focus();
            //            }
            //        }
            //    }
            //}
            //if ( this.txtSpecimen.Text == " " )
            //    this.txtSpecimen.SetDataValue("");
			
		}
		#endregion

		#region 응급항목 찾기
        //int flag = 0;
        //string check_hiv = "";
        //private void FindEmergency()
        //{
        //    flag = 0;
        //    for ( int i = 0 ; i < this.grdGum.RowCount; i++ )
        //    {
        //        string hangmog_code = this.grdGum.GetItemString(i,"hangmog_code");
        //        if ( hangmog_code.Trim() == "03237" || hangmog_code.Trim() == "00408" )
        //        {
        //            this.btnChangeHiv.Visible = true;
        //            if ( hangmog_code.Trim() == "03237" )
        //                this.check_hiv = "N";
        //            else
        //                this.check_hiv = "Y";
        //            flag = 1;
        //            return;
        //        }
        //    }
        //    flag = 1;
        //    this.btnChangeHiv.Visible = false;
        //}
		
//		int flag2 = 0;
//		string check_blood = "";
//		private void FindEmergency2()
//		{
//			flag2 = 0;
//			for ( int i = 0 ; i < this.grdGum.RowCount; i++ )
//			{
//				string hangmog_code = this.grdGum.GetItemString(i,"hangmog_code");
//				if ( hangmog_code.Trim() == "03924" || hangmog_code.Trim() == "0151A" )
//				{
//					this.btnChangeBlood.Visible = true;
//					if ( hangmog_code.Trim() == "03924" )
//						this.check_blood = "N";
//					else
//						this.check_blood = "Y";
//					flag2 = 1;
//					return;
//				}
//			}
//			flag2 = 1;
//			this.btnChangeBlood.Visible = false;
//		}
//		
//		int flag3 = 0;
//		string check_hangche = "";
//		private void FindEmergency3()
//		{
//			flag3 = 0;
//			for ( int i = 0 ; i < this.grdGum.RowCount; i++ )
//			{
//				string hangmog_code = this.grdGum.GetItemString(i,"hangmog_code");
//				if ( hangmog_code.Trim() == "03927" || hangmog_code.Trim() == "01600" )
//				{
//					this.btnChangeHangche.Visible = true;
//					if ( hangmog_code.Trim() == "03927" )
//						this.check_hangche = "N";
//					else
//						this.check_hangche = "Y";
//					flag3 = 1;
//					return;
//				}
//			}
//			flag3 = 1;
//			this.btnChangeHangche.Visible = false;
//		}
		
		#endregion

		private void btnBarcode_Click(object sender, System.EventArgs e)
		{
			RePrintBacode(1);
		}

		#region 프린터 설정 과 바코드 출력
		// 채혈라벨뽑기 가 구분 1
		// 분주라벨뽑기 가 구분 2
		private void RePrintBacode(int gubun)
		{
			//바코드프린터명 가져오기
            this.layPrintName.QueryLayout();
			string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

			if ( this.grdPart.RowCount < 1 ) return;

			string specimen_ser = grdPart.GetItemString(grdPart.CurrentRowNumber, "specimen_ser");
			if ( gubun == 1 )
			{
				//채혈라벨뽑기
		//		dwBarcode.Reset();
				layBarcode.Reset();
		//		dwBarcode.DataWindowObject = "d_specimen_ser";

				this.layBarcodeTemp.SetBindVarValue("f_specimen_ser", specimen_ser);
                this.layBarcodeTemp.QueryLayout(true);

				if (layBarcode.RowCount > 0)
				{
					//바코드 한껀씩 출력을 보냄
                    /*
					for (int j=0 ; j<this.layBarcode.RowCount; j++)
					{
						dwBarcode.Reset();
						layBarcodeOne.Reset();

						int rowNum = layBarcodeOne.InsertRow(j-1);
                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun", this.layBarcode.GetItemString(j, "jundal_gubun"));
                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcode.GetItemString(j, "jundal_gubun_name"));
                        layBarcodeOne.SetItemValue(rowNum, "specimen_code", this.layBarcode.GetItemString(j, "specimen_code"));
                        layBarcodeOne.SetItemValue(rowNum, "specimen_name", this.layBarcode.GetItemString(j, "specimen_name"));
                        layBarcodeOne.SetItemValue(rowNum, "tube_code", this.layBarcode.GetItemString(j, "tube_code"));
                        layBarcodeOne.SetItemValue(rowNum, "tube_name", this.layBarcode.GetItemString(j, "tube_name"));
                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser", this.layBarcode.GetItemString(j, "specimen_ser"));
                        layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode.GetItemString(j, "bunho"));
                        layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode.GetItemString(j, "suname"));
                        layBarcodeOne.SetItemValue(rowNum, "gwa_name", this.layBarcode.GetItemString(j, "gwa_name"));
                        layBarcodeOne.SetItemValue(rowNum, "danger_yn", this.layBarcode.GetItemString(j, "danger_yn"));
                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcode.GetItemString(j, "specimen_ser_ba"));
                        layBarcodeOne.SetItemValue(rowNum, "jangbi_code", this.layBarcode.GetItemString(j, "jangbi_code"));
                        layBarcodeOne.SetItemValue(rowNum, "jangbi_name", this.layBarcode.GetItemString(j, "jangbi_name"));
                        layBarcodeOne.SetItemValue(rowNum, "in_out_gubun", this.layBarcode.GetItemString(j, "in_out_gubun"));
                        layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re", this.layBarcode.GetItemString(j, "gumsa_name_re"));
                        layBarcodeOne.SetItemValue(rowNum, "tube_max_amt", this.layBarcode.GetItemString(j, "tube_max_amt"));
                        layBarcodeOne.SetItemValue(rowNum, "tube_numbering", this.layBarcode.GetItemString(j, "tube_numbering"));	

						dwBarcode.FillData(layBarcodeOne.LayoutTable);
						dwBarcode.PrintProperties.PrinterName = printSetName;
						try
						{
							dwBarcode.Print();
						}
						catch{}
					}*/

                    foreach (DataRow row in this.layBarcode.LayoutTable.Rows)
                    {
        //                dwBarcode.Reset();
                        layBarcodeOne.Reset();
                        this.layBarcodeOne.LayoutTable.ImportRow(row);

       //                 dwBarcode.FillData(layBarcodeOne.LayoutTable);
       //                 dwBarcode.PrintProperties.PrinterName = printSetName;
                        try
                        {
        //                    dwBarcode.Print();
                        }
                        catch { }
                    }
				}
			}
            //20101215
            //else
            //{
            //    //분주라벨 뽑기
            //    dwBarcode.Reset();
            //    layBarcode.Reset();
            //    dwBarcode.DataWindowObject = "d_specimen_ser";

            //    this.layBarcodeTemp2.SetBindVarValue("f_specimen_ser", specimen_ser);
            //    this.layBarcodeTemp2.QueryLayout(true);

            //    if (layBarcode2.RowCount > 0)
            //    {
            //        //바코드 한껀씩 출력을 보냄
            //        for (int j=0 ; j<this.layBarcode2.RowCount; j++)
            //        {
            //            dwBarcode.Reset();
            //            layBarcodeOne.Reset();

            //            int rowNum = layBarcodeOne.InsertRow(-1);
            //            layBarcodeOne.SetItemValue(rowNum, "jundal_gubun", this.layBarcode2.GetItemString(j, "jundal_gubun"));
            //            layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcode2.GetItemString(j, "jundal_gubun_name"));
            //            layBarcodeOne.SetItemValue(rowNum, "specimen_code", this.layBarcode2.GetItemString(j, "specimen_code"));
            //            layBarcodeOne.SetItemValue(rowNum, "specimen_name", this.layBarcode2.GetItemString(j, "specimen_name"));
            //            layBarcodeOne.SetItemValue(rowNum, "tube_code", this.layBarcode2.GetItemString(j, "tube_code"));
            //            layBarcodeOne.SetItemValue(rowNum, "tube_name", this.layBarcode2.GetItemString(j, "tube_name"));
            //            layBarcodeOne.SetItemValue(rowNum, "specimen_ser", this.layBarcode2.GetItemString(j, "specimen_ser"));
            //            layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode2.GetItemString(j, "bunho"));
            //            layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode2.GetItemString(j, "suname"));
            //            layBarcodeOne.SetItemValue(rowNum, "gwa_name", this.layBarcode2.GetItemString(j, "gwa_name"));
            //            layBarcodeOne.SetItemValue(rowNum, "danger_yn", this.layBarcode2.GetItemString(j, "danger_yn"));
            //            layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcode2.GetItemString(j, "specimen_ser_ba"));
            //            layBarcodeOne.SetItemValue(rowNum, "jangbi_code", this.layBarcode2.GetItemString(j, "jangbi_code"));
            //            layBarcodeOne.SetItemValue(rowNum, "jangbi_name", this.layBarcode2.GetItemString(j, "jangbi_name"));
            //            layBarcodeOne.SetItemValue(rowNum, "in_out_gubun", this.layBarcode2.GetItemString(j, "in_out_gubun"));
            //            layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re", this.layBarcode2.GetItemString(j, "gumsa_name_re"));
            //            layBarcodeOne.SetItemValue(rowNum, "tube_max_amt", this.layBarcode2.GetItemString(j, "tube_max_amt"));
            //            layBarcodeOne.SetItemValue(rowNum, "tube_numbering", this.layBarcode2.GetItemString(j, "tube_numbering"));	
										
            //            dwBarcode.FillData(layBarcodeOne.LayoutTable);
            //            dwBarcode.PrintProperties.PrinterName = printSetName;
            //            try
            //            {
            //                dwBarcode.Print();
            //            }
            //            catch{}
            //        }
            //    }
            //}

		}
	
		private void SetPrintBacode(int gubun)
		{
            ////바코드프린터명 가져오기
            //this.layPrintName.QueryLayout();
            //string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

            //    if ( this.grdPart.RowCount < 1 ) return;

            //dwBarcode.Reset();
            //layBarcode.Reset();
            //dwBarcode.DataWindowObject = "d_specimen_ser";
			
            //string specimen_ser = "";
            //if ( gubun == 1 )
            //{
            //    specimen_ser = grdPart.GetItemString(grdPart.CurrentRowNumber, "specimen_ser");
            //}
            //else
            //{
            //    specimen_ser = this.txtSpecimenRead.GetDataValue().Trim();
            //}

            //this.layBarcodeTemp2.SetBindVarValue("f_specimen_ser", specimen_ser);
            //this.layBarcodeTemp2.QueryLayout(true);

            //if (layBarcode2.RowCount > 0)
            //{
            //    //srl꺼 나중에 분주라벨로 바꾸어야함( 분주라벨 정의가 필요 ) -- 2006.07.30 민수 가까스로 반영 오픈 2일전...
            //    //바코드 한껀씩 출력을 보냄
            //    for (int j=0 ; j<this.layBarcode2.RowCount; j++)
            //    {
            //        dwBarcode.Reset();
            //        layBarcodeOne.Reset();

            //        int rowNum = layBarcodeOne.InsertRow(-1);
            //        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun", this.layBarcode.GetItemString(j, "jundal_gubun"));
            //        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcode.GetItemString(j, "jundal_gubun_name"));
            //        layBarcodeOne.SetItemValue(rowNum, "specimen_code", this.layBarcode.GetItemString(j, "specimen_code"));
            //        layBarcodeOne.SetItemValue(rowNum, "specimen_name", this.layBarcode.GetItemString(j, "specimen_name"));
            //        layBarcodeOne.SetItemValue(rowNum, "tube_code", this.layBarcode.GetItemString(j, "tube_code"));
            //        layBarcodeOne.SetItemValue(rowNum, "tube_name", this.layBarcode.GetItemString(j, "tube_name"));
            //        layBarcodeOne.SetItemValue(rowNum, "specimen_ser", this.layBarcode.GetItemString(j, "specimen_ser"));
            //        layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode.GetItemString(j, "bunho"));
            //        layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode.GetItemString(j, "suname"));
            //        layBarcodeOne.SetItemValue(rowNum, "gwa_name", this.layBarcode.GetItemString(j, "gwa_name"));
            //        layBarcodeOne.SetItemValue(rowNum, "danger_yn", this.layBarcode.GetItemString(j, "danger_yn"));
            //        layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcode.GetItemString(j, "specimen_ser_ba"));
            //        layBarcodeOne.SetItemValue(rowNum, "jangbi_code", this.layBarcode.GetItemString(j, "jangbi_code"));
            //        layBarcodeOne.SetItemValue(rowNum, "jangbi_name", this.layBarcode.GetItemString(j, "jangbi_name"));
            //        layBarcodeOne.SetItemValue(rowNum, "in_out_gubun", this.layBarcode.GetItemString(j, "in_out_gubun"));
            //        layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re", this.layBarcode.GetItemString(j, "gumsa_name_re"));
            //        layBarcodeOne.SetItemValue(rowNum, "tube_max_amt", this.layBarcode.GetItemString(j, "tube_max_amt"));	
										
            //        dwBarcode.FillData(layBarcodeOne.LayoutTable);
            //        dwBarcode.PrintProperties.PrinterName = printSetName;
            //        try
            //        {
            //            dwBarcode.Print();
            //        }
            //        catch{}
            //    }
            //}

		}
		#endregion

		private void btnPrintSetup_Click(object sender, System.EventArgs e)
		{
			SetPrint();
		}

		#region 바코드 프린터 설정
		private void SetPrint()
		{
			//Open the PrintDialog
			this.printDialog1.Document = this.printDocument1;
			DialogResult dr = this.printDialog1.ShowDialog();
			if(dr == DialogResult.OK)
			{
				//Get the Copy times
				int nCopy = this.printDocument1.PrinterSettings.Copies;
				//Get the number of Start Page
				int sPage = this.printDocument1.PrinterSettings.FromPage;
				//Get the number of End Page
				int ePage = this.printDocument1.PrinterSettings.ToPage;
				//Get the printer name
				string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                //this.laySetBarcode.SetInValue("printer_name",PrinterName);
                //this.DataServiceCall(this.laySetBarcode);

//                string cmdText1 = @" UPDATE ADM3300
//                                       SET USER_ID         = :q_user_id
//                                         , UP_TIME         = SYSDATE
//                                         , B_PRINT_NAME    = :f_b_print_name
//                                     WHERE HOSP_CODE       = :f_hosp_code 
//                                       AND IP_ADDR         = :f_ip_addr";

//                string cmdText2 = @"INSERT INTO ADM3300
//                                          ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
//                                            USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
//                                        VALUES 
//                                          ( :t_trm_id, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
//                                            NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name)
//                                        ";

                //BindVarCollection bc = new BindVarCollection();
                //bc.Add("q_user_id", UserInfo.UserID);
                //bc.Add("f_b_print_name", PrinterName);
                //bc.Add("f_hosp_code", EnvironInfo.HospCode);
                //bc.Add("f_ip_addr", Service.ClientIP.ToString());
//                if (!Service.ExecuteNonQuery(cmdText1, bc))
//                {
//                    if (Service.ErrFullMsg == "Execute Error(Data does not changed)")
//                    {
//                        cmdText1 = @"SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
//                                       FROM ADM3300
//                                      WHERE HOSP_CODE = :f_hosp_code  ";

//                        object t_trm_id = Service.ExecuteScalar(cmdText1, bc);

//                        if (!TypeCheck.IsNull(t_trm_id))
//                        {
//                            bc.Add("t_trm_id", t_trm_id.ToString());
//                        }

//                        if (!Service.ExecuteNonQuery(cmdText2, bc))
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg);
//                        }
//                    }
//                    else
//                    {
//                        XMessageBox.Show(Service.ErrFullMsg);
//                    }
//                }

                // TODO: Use connect cloud
                /*string cmdText = @" DECLARE 
    
                                        T_TRM_ID VARCHAR2(8) := ''; 

                                    BEGIN
                                        UPDATE ADM3300
                                           SET USER_ID         = :q_user_id
                                             , UP_TIME         = SYSDATE
                                             , B_PRINT_NAME    = :f_b_print_name
                                         WHERE HOSP_CODE       = :f_hosp_code 
                                           AND IP_ADDR         = :f_ip_addr;
                                           
                                              
                                           IF SQL%NOTFOUND THEN       
                                             
                                             SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
                                               INTO T_TRM_ID
                                               FROM ADM3300
                                              WHERE HOSP_CODE = :f_hosp_code;
                                              
                                             INSERT INTO ADM3300
                                                  ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
                                                    USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
                                                VALUES 
                                                  ( T_TRM_ID, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
                                                    NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name);       
                                                    
                                           END IF; 

                                    END;";

                BindVarCollection bc = new BindVarCollection();
                bc.Add("q_user_id", UserInfo.UserID);
                bc.Add("f_b_print_name", PrinterName);
                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_ip_addr", Service.ClientIP.ToString());

                if (!Service.ExecuteNonQuery(cmdText, bc))
                {
                    XMessageBox.Show("プリンタ設定中にエラーが発生しました。\r\n" + Service.ErrFullMsg, "注意", MessageBoxIcon.Warning);
                }*/

                // Connect to cloud
                InjsINJ1001U01SettingPrintArgs printArgs = new InjsINJ1001U01SettingPrintArgs();
			    printArgs.UserId = UserInfo.UserID;
			    printArgs.BPrintName = PrinterName;
			    printArgs.IpAddr = Service.ClientIP;
			    InjsINJ1001U01SettingPrintResult printResult =
			        CloudService.Instance.Submit<InjsINJ1001U01SettingPrintResult, InjsINJ1001U01SettingPrintArgs>(printArgs);
			    if (printResult == null || printResult.ExecutionStatus != ExecutionStatus.Success || printResult.Result == false)
			    {
                    XMessageBox.Show("プリンタ設定中にエラーが発生しました。\r\n" + Service.ErrFullMsg, "注意", MessageBoxIcon.Warning);  
			    }
			}
		}
		#endregion

		private void fbxJundalGubun_Enter(object sender, System.EventArgs e)
		{
			this.txtSpecimenRead.Focus();
		}

		private void btnBunjuBarcode_Click(object sender, System.EventArgs e)
		{
			RePrintBacode(2);
		}

		private void btn7180EndPrint_Click(object sender, System.EventArgs e)
		{
            this.layPrintName.QueryLayout();
			string printSetName = this.layPrintName.GetItemValue("print_name").ToString();
			
	//		this.dwBarcode.DataWindowObject = "d_7180_barcode";

	//		this.dwBarcode.PrintProperties.PrinterName = printSetName;

			try
			{
				this.layBarcodeOne.Reset();
				this.layBarcodeOne.InsertRow(-1);
				this.layBarcodeOne.SetItemValue(0,"specimen_ser"," 00000000000");
                //this.dwBarcode.Reset();
                //this.dwBarcode.FillData(this.layBarcodeOne.LayoutTable);
                //this.dwBarcode.Print();
			}
			catch{}
		}

		#region HIV 체인지
		private void btnChangeHiv_Click(object sender, System.EventArgs e)
		{
            //if ( flag == 1 )
            //{
            //    if ( this.check_hiv == "Y" )
            //        EmergencySave("N");
            //    else
            //        EmergencySave("Y");
	
            //    int cur_row = this.grdPart.CurrentRowNumber;
            //    this.grdPart.QueryLayout(false);
            //    this.grdPart.SetFocusToItem(cur_row,1);
            //}
		}

//        private bool EmergencySave(string aCheckYN)
//        {
//            string cmdText = "";
//            string specimen_ser = this.grdGum.GetItemString(this.grdGum.CurrentRowNumber, "specimen_ser");

//            BindVarCollection bc = new BindVarCollection();

//            bc.Add("q_user_id", UserInfo.UserID);
//            bc.Add("f_hosp_code", EnvironInfo.HospCode);
//            bc.Add("f_specimen_ser", specimen_ser);

//            if (aCheckYN == "Y")
//            { 
//                cmdText = @"UPDATE CPL3020
//                               SET UPD_ID               = :q_user_id
//                                 , UPD_DATE             = SYSDATE
//                                 , HANGMOG_CODE         = '00408' 
//                             WHERE HOSP_CODE            = :f_hosp_code
//                               AND SPECIMEN_SER         = :f_specimen_ser
//                               AND HANGMOG_CODE         = '03237'";

//                if (!Service.ExecuteNonQuery(cmdText, bc))
//                {
//                    XMessageBox.Show("UPDATE CPL3020 Error. 03237\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
//                    return false;
//                }

//                cmdText = @"UPDATE CPL2010
//                               SET UPD_ID     　         = :q_user_id
//                                 , UPD_DATE             = SYSDATE
//                                 , HANGMOG_CODE         = '00408' 
//                                 , JUNDAL_GUBUN         = '03'
//                             WHERE HOSP_CODE            = :f_hosp_code
//                               AND SPECIMEN_SER         = :f_specimen_ser
//                               AND HANGMOG_CODE         = '03237'";

//                if (!Service.ExecuteNonQuery(cmdText, bc))
//                {
//                    XMessageBox.Show("UPDATE CPL2010 Error. 03237\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
//                    return false;
//                }
//            }
//            else
//            {
//                cmdText = @"UPDATE CPL3020
//                               SET UPD_ID               = :q_user_id
//                                 , UPD_DATE             = SYSDATE
//                                 , HANGMOG_CODE         = '03237' 
//                             WHERE HOSP_CODE            = :f_hosp_code
//                               AND SPECIMEN_SER         = :f_specimen_ser
//                               AND HANGMOG_CODE         = '00408'";

//                if (!Service.ExecuteNonQuery(cmdText, bc))
//                {
//                    XMessageBox.Show("UPDATE CPL3020 Error. 00408 \r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
//                    return false;
//                }

//                cmdText = @"UPDATE CPL2010
//                               SET UPD_ID     　         = :q_user_id
//                                 , UPD_DATE             = SYSDATE
//                                 , HANGMOG_CODE         = '03237' 
//                                 , JUNDAL_GUBUN         = '15'
//                             WHERE HOSP_CODE            = :f_hosp_code
//                               AND SPECIMEN_SER         = :f_specimen_ser
//                               AND HANGMOG_CODE         = '00408'";

//                if (!Service.ExecuteNonQuery(cmdText, bc))
//                {
//                    XMessageBox.Show("UPDATE CPL2010 Error. 00408 \r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
//                    return false;
//                }
//            }
//            return true;
//        }
		#endregion

		private void grdPart_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
		{
			if ( e.ChangeValue.ToString() == "N" )
			{
				if ( this.grdPart.GetItemString(e.RowNumber,"result_yn") == "Y" )
				{
					if ( XMessageBox.Show(Resource.XMessageBox7,Resource.XMessageBox7_caption,MessageBoxButtons.YesNo) == DialogResult.Yes )
					{
						this.grdPart.SetItemValue(e.RowNumber,"part_jubsu_flag","N");
					}
					else
					{
						this.grdPart.SetItemValue(e.RowNumber,"part_jubsu_flag","Y");
					}
				}
			}
		}

		private void btnChangeBlood_Click(object sender, System.EventArgs e)
		{
//			if ( flag2 == 1 )
//			{
//				if ( this.check_blood == "Y" )
//					this.layEmergency2.SetInValue("check_yn","N");
//				else
//					this.layEmergency2.SetInValue("check_yn","Y");
//				this.DataServiceCall(this.layEmergency2);	
//				int cur_row = this.grdPart.CurrentRowNumber;
//				this.DataServiceCall(this.dsvPart);
//				this.grdPart.SetFocusToItem(cur_row,1);
//			}
		}

		private void btnChangeHangche_Click(object sender, System.EventArgs e)
		{
//			if ( flag3 == 1 )
//			{
//				if ( this.check_hangche == "Y" )
//					this.layEmergency3.SetInValue("check_yn","N");
//				else
//					this.layEmergency3.SetInValue("check_yn","Y");
//				this.DataServiceCall(this.layEmergency3);	
//				int cur_row = this.grdPart.CurrentRowNumber;
//				this.DataServiceCall(this.dsvPart);
//				this.grdPart.SetFocusToItem(cur_row,1);
//			}
		}

		#region 접수 후 라벨 한장 더 뽑는 경우
        //private void dsvSpecimenBySer_ServiceEnd(object sender, IHIS.Framework.ServiceEndArgs e)
        //{
        //    for ( int i=0; i<grdPart.RowCount; i++ )
        //    {
        //        if ( grdPart.GetItemString(i,"label_one_more") == "Y" )
        //        {
        //            grdPart.SetFocusToItem(i,"specimen_ser");
        //            btnBarcode_Click(null,null);
        //        }
        //    }
        //}
		#endregion

		#region 검체번호 실제 로직
		private void txtSpecimenRead_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string specimen_ser = e.DataValue;
            if (this.cbxActor.GetDataValue().Length == 0)
			{
                XMessageBox.Show(Resource.XMessageBox2, Resource.XMessageBox8_Caption, MessageBoxIcon.Warning);
                this.cbxActor.Focus();
				return;
			}
			this.txtSpecimenRead.AcceptData();

            if (QueryLaySpecimenRead())
			{
				if ( this.laySpecimenRead.GetItemValue("jubsu_ok").ToString() == "Y" )
				{
					//SetPrintBacode(2); 20101215

                    XMessageBox.Show(Resource.XMessageBox8, Resource.XMessageBox9_Caption, MessageBoxIcon.Information);

                    //if (this.dtpJubsuDate.GetDataValue() != EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"))
                    //    this.dtpJubsuDate.SetDataValue(EnvironInfo.GetSysDate());

					// 검체조회
                    QuerySpecimenBySer(specimen_ser);

					//this.MakeDataDnl(); ???
					this.txtSpecimenRead.SetDataValue("");
					this.txtSpecimenRead.Focus();
				}
				else
				{
                    if (this.laySpecimenRead.GetItemValue("already_jubsu").ToString() == "Y")
					{
                        XMessageBox.Show(Resource.XMessageBox10, Resource.XMessageBox9_Caption, MessageBoxIcon.Warning);

						// 검체조회
                        QuerySpecimenBySer(specimen_ser);
					} 
					else
					{
                        XMessageBox.Show(Resource.XMessageBox11, Resource.XMessageBox8_Caption, MessageBoxIcon.Warning);
					}

					this.txtSpecimenRead.SelectAll();
					this.txtSpecimenRead.Focus();
				}
			}
			else
			{
				//XMessageBox.Show(laySpecimenRead.ErrFullMsg);
			}
		}




        private void QuerySpecimenBySer(string specimen_ser)
        {

            // TODO comment: use connect to cloud service
            /*string tempSql = this.grdPart.QuerySQL;

            this.grdPart.QuerySQL = @"SELECT DISTINCT
                                               ' ' LAB_NO
                                             , B.SPECIMEN_SER
                                             , B.BUNHO    
                                             , C.SUNAME
                                             , FN_BAS_LOAD_GWA_NAME(B.GWA,SYSDATE)
                                             , B.HO_DONG
                                             , B.PART_JUBSU_DATE
                                             , B.PART_JUBSU_TIME
                                             , B.PART_JUBSUJA
                                             , B.JUBSUJA
                                             --, B.JUNDAL_GUBUN
                                             , FN_CPL_LOAD_COMMENT(B.SPECIMEN_SER)      REMARK
                                             , DECODE(B.PART_JUBSU_DATE,NULL,'N','Y') PART_JUBSU_FLAG
                                             , 0                                      FKOCS
                                             , B.IN_OUT_GUBUN
                                             , B.DOCTOR_NAME
                                             --, D.CODE_NAME    PART_NAME
                                             , E.CODE_NAME    TUBE_NAME
                                             , B.EMERGENCY    EMERGENCY
                                             , DECODE(B.SUNAB_DATE,NULL,'N','Y')     SUNAB_YN
                                             , DECODE(B.RESULT_DATE,NULL,'N','Y')    RESULT_YN
                                             , DECODE(F.CODE,NULL,'N','Y')           LABEL_ONE_MORE
                                          FROM CPL0109 F,
                                               CPL0109 E,
                                               CPL0109 D,
                                               OUT0101 C,
                                               CPL2010 B
                                         WHERE B.HOSP_CODE       = :f_hosp_code
                                           AND C.HOSP_CODE       = B.HOSP_CODE
                                           AND D.HOSP_CODE       = B.HOSP_CODE
                                           AND E.HOSP_CODE(+)    = B.HOSP_CODE
                                           AND F.HOSP_CODE(+)    = B.HOSP_CODE
                                           AND B.SPECIMEN_SER    = :f_specimen_ser
                                           AND C.BUNHO           = B.BUNHO
                                           AND NVL(B.DC_YN,'N')  = 'N'
                                           AND D.CODE_TYPE       = '01'
                                           AND D.CODE            = B.JUNDAL_GUBUN
                                           AND E.CODE_TYPE(+)    = '02'
                                           AND E.CODE     (+)    = B.TUBE_CODE
                                           AND F.CODE_TYPE(+)    = '21'
                                           AND F.CODE     (+)    = B.TUBE_CODE";*/

            this.grdPart.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPart.SetBindVarValue("f_specimen_ser", specimen_ser);
            this.grdPart.ExecuteQuery = ExecuteQuerSpecimenBySer;
            this.grdPart.QueryLayout(true);

//            this.grdPart.QuerySQL = tempSql;
        }

        private bool QueryLaySpecimenRead()
        {
            string insert_ok = "N";
            string already_jubsu = "N";
            string flag = "";

            /*Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            string cmdText = "";
            BindVarCollection bc = new BindVarCollection();*/

            this.laySpecimenRead.Reset();

            CPL3010U00QueryLaySpecimenReadArgs args = new CPL3010U00QueryLaySpecimenReadArgs();
            args.SpecimenReadValue = txtSpecimenRead.GetDataValue();
            args.PartJubsuja = cbxActor.GetDataValue();
            args.GumJubsuDate = dtpJubsuDate.GetDataValue();
            CPL3010U00QueryLaySpecimenReadResult result =
                CloudService.Instance.Submit<CPL3010U00QueryLaySpecimenReadResult, CPL3010U00QueryLaySpecimenReadArgs>(
                    args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                insert_ok = result.InsertOk;
                already_jubsu = result.AlreadyJubsu;
                flag = result.Flag;
            }

            // TODO: Use connect to cloud
            /*bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_specimen_ser", txtSpecimenRead.GetDataValue());
            bc.Add("f_part_jubsuja", this.cbxActor.GetDataValue());
            bc.Add("f_gum_jubsu_date", this.dtpJubsuDate.GetDataValue());
            bc.Add("f_gum_jubsu_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));

            cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS ( SELECT 'X'
                                          FROM CPL2010
                                         WHERE HOSP_CODE       = :f_hosp_code
                                           AND SPECIMEN_SER    = :f_specimen_ser
                                           AND PART_JUBSU_DATE IS NULL )";

            object o_insert_ok = Service.ExecuteScalar(cmdText, bc);

            if (!TypeCheck.IsNull(o_insert_ok))
            {
                insert_ok = o_insert_ok.ToString();

                if (insert_ok == "Y")
                {
                    cmdText = @"UPDATE CPL2010
                                   SET GUM_JUBSU_DATE = :f_gum_jubsu_date
                                     , GUM_JUBSU_TIME = :f_gum_jubsu_time
                                     , GUM_JUBSUJA    = :f_part_jubsuja
                                 WHERE HOSP_CODE      = :f_hosp_code
                                   AND SPECIMEN_SER   = :f_specimen_ser
                                   AND GUM_JUBSU_DATE IS NULL";

                    if (!Service.ExecuteNonQuery(cmdText, bc))
                    {
                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                        {
                            XMessageBox.Show(Resource.XMessageBox12 + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    cmdText = @"SELECT JUNDAL_GUBUN
                                  FROM CPL2010
                                 WHERE HOSP_CODE      = :f_hosp_code
                                   AND SPECIMEN_SER   = :f_specimen_ser
                                   AND PART_JUBSU_DATE IS NULL
                                 GROUP BY JUNDAL_GUBUN";

                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);

                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            inputList.Clear();
                            inputList.Add("I_SPECIMEN_SER", txtSpecimenRead.GetDataValue());
                            inputList.Add("I_JUNDAL_GUBUN", dt.Rows[i]["jundal_gubun"].ToString());
                            inputList.Add("I_PART_JUBSU_DATE", this.dtpJubsuDate.GetDataValue());
                            inputList.Add("I_PART_JUBSU_TIME", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                            inputList.Add("I_PART_JUBSUJA", this.cbxActor.GetDataValue());
                            inputList.Add("I_USER_ID", this.cbxActor.GetDataValue());
                            inputList.Add("IO_FLAG", "");

                            if (!Service.ExecuteProcedure("PR_CPL_PART_JUBSU", inputList, outputList))
                            {
                                XMessageBox.Show(Resource.XMessageBox13 + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                                return false;
                            }
                            if (outputList.Count > 0)
                                flag = outputList["IO_FLAG"].ToString();
                        }
                    }

                    this.laySpecimenRead.SetItemValue("jubsu_ok", insert_ok);
                    this.laySpecimenRead.SetItemValue("already_jubsu", already_jubsu);
                    this.laySpecimenRead.SetItemValue("flag", flag);
                    return true;
                }
            }

            cmdText = @"SELECT 'Y'                                            
                          FROM DUAL                                          
                         WHERE EXISTS ( SELECT 'X'                           
                                          FROM CPL2010
                                         WHERE HOSP_CODE       = :f_hosp_code
                                           AND SPECIMEN_SER    = :f_specimen_ser
                                           AND PART_JUBSU_DATE IS NOT NULL)";

            object o_already_jubsu = Service.ExecuteScalar(cmdText, bc);

            if (!TypeCheck.IsNull(o_already_jubsu))
            {
                already_jubsu = o_already_jubsu.ToString();

                if (already_jubsu == "N")
                {
                    cmdText = @"SELECT 'Z'                                           
                                  FROM DUAL                                          
                                 WHERE NOT EXISTS ( SELECT 'X'                           
                                                      FROM CPL2010
                                                     WHERE HOSP_CODE    = :f_hosp_code
                                                       AND SPECIMEN_SER = :f_specimen_ser)";
                    o_already_jubsu = Service.ExecuteScalar(cmdText, bc);

                    if (!TypeCheck.IsNull(o_already_jubsu))
                    {
                        already_jubsu = o_already_jubsu.ToString();
                    }
                }
            }*/

            this.laySpecimenRead.SetItemValue("jubsu_ok", insert_ok);
            this.laySpecimenRead.SetItemValue("already_jubsu", already_jubsu);
            this.laySpecimenRead.SetItemValue("flag", flag);

            return true;
        }
		#endregion

		private bool SetConection()
		{
			try
			{
				if(!Directory.Exists(ORDER_FILE_PATH))
					return false;
				
				return true;
			}
			catch(Exception xe)
			{
				//https://sofiamedix.atlassian.net/browse/MED-10610
				//XMessageBox.Show(xe.Message);
				return false;
			}

		}

        //private void btnReTrans_Click(object sender, System.EventArgs e)
        //{
        //    MakeDataDnl();
        //}
		
		private string ORDER_FILE_PATH = @"T:\dnl";

        //private bool MakeDataDnl()
        //{
        //    if (SetConection())
        //    {
        //        if (this.grdPart.RowCount < 1) return false;

        //        string specimen_ser = grdPart.GetItemString(grdPart.CurrentRowNumber, "specimen_ser");

        //        bool IsMakeData = false;
        //        bool IsMakeDataABD = false;
        //        bool IsMakeDataDAT = false;
        //        bool IsMakeDataIDAT = false;
        //        bool IsMakeDataSCR = false;

        //        for (int i = 0; i < this.grdGum.RowCount; i++)
        //        {
        //            if (grdGum.GetItemString(i, "hangmog_code") == "00294") // ABO 식
        //            {
        //                IsMakeData = true;
        //                IsMakeDataABD = true;
        //            }
        //            else if (grdGum.GetItemString(i, "hangmog_code") == "00295") // 
        //            {
        //                IsMakeData = true;
        //                IsMakeDataABD = true;
        //            }
        //            else if (grdGum.GetItemString(i, "hangmog_code") == "00296") // 
        //            {
        //                IsMakeData = true;
        //                IsMakeDataABD = true;
        //            }
        //            else if (grdGum.GetItemString(i, "hangmog_code") == "00297") // 
        //            {
        //                IsMakeData = true;
        //                IsMakeDataDAT = true;
        //            }
        //            else if (grdGum.GetItemString(i, "hangmog_code") == "00298") // 
        //            {
        //                IsMakeData = true;
        //                IsMakeDataIDAT = true;

        //            }
        //            else if (grdGum.GetItemString(i, "hangmog_code") == "00299") // 
        //            {
        //                IsMakeData = true;
        //                IsMakeDataSCR = true;
        //            }
        //        }

        //        if (IsMakeData)
        //        {
        //            string sendData = "";
        //            sendData += @"H|\^&|||LIS|||||||||" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\r\n"; //헤더
        //            sendData += "P|1|" + this.grdPart.GetItemString(grdPart.CurrentRowNumber, "bunho") + "|||^|||||||||||||||||||||||||||||" + "\r\n";//환자

        //            if (IsMakeDataABD)
        //                sendData += "O|1|" + specimen_ser + "||ABD|N||||||N||||CENTBLOOD||||" + "\r\n";
        //            if (IsMakeDataDAT)
        //                sendData += "O|1|" + specimen_ser + "||DAT|N||||||N||||CENTBLOOD||||" + "\r\n";
        //            if (IsMakeDataIDAT)
        //                sendData += "O|1|" + specimen_ser + "||IDAT|N||||||N||||CENTBLOOD||||" + "\r\n";
        //            if (IsMakeDataSCR)
        //                sendData += "O|1|" + specimen_ser + "||SCR|N||||||N||||CENTBLOOD||||" + "\r\n";

        //            sendData += "L|1|N" + "\r\n"; // 라스트 레코드

        //            try
        //            {
        //                string fileName = ORDER_FILE_PATH + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".dnl";
        //                StreamWriter swData = new StreamWriter(fileName, false, Encoding.GetEncoding("Shift_JIS"));
        //                swData.WriteLine(sendData, swData);
        //                swData.Close();
        //            }
        //            catch
        //            {
        //            }

        //            IsMakeData = false;

        //        }
        //    }
        //    return true;
        //}

        private void laySpecimenInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.laySpecimenInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.laySpecimenInfo.SetBindVarValue("f_specimen_ser", this.grdPart.GetItemString(this.grdPart.CurrentRowNumber, "specimen_ser"));
        }

        private void laySpecimenInfo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (laySpecimenInfo.GetItemValue("switch").ToString() != "0")
                laySpecimenInfo.SetItemValue("switch", "1");
        }

        private void grdPart_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPart.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPart.SetBindVarValue("f_part_jubsu_date", this.dtpJubsuDate.GetDataValue());
        }

        private void dsvUrine_QueryStarting(object sender, CancelEventArgs e)
        {
            this.dsvUrine.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.dsvUrine.SetBindVarValue("f_fkocs", this.grdGum.GetItemString(this.grdGum.CurrentRowNumber, "fkocs"));
            this.dsvUrine.SetBindVarValue("f_in_out_gubun", this.grdPart.GetItemString(this.grdPart.CurrentRowNumber, "in_out_gubun"));
            this.dsvUrine.SetBindVarValue("f_specimen_ser", this.grdPart.GetItemString(this.grdPart.CurrentRowNumber, "specimen_ser"));
        }
                

        private void layPrintName_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPrintName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layPrintName.SetBindVarValue("f_ip_addr", Service.ClientIP.ToString());
        }

        private void layBarcodeTemp_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBarcodeTemp.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layBarcodeTemp_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                this.layBarcode.Reset();
                int t_tube_count = 0;
                //int rowNum = 0;
                /*
                for (int i = 0; i < layBarcodeTemp.RowCount; i++)
                {
                    t_tube_count = layBarcodeTemp.GetItemInt(i, "tube_count");

                    for (int j = 0; j < t_tube_count; j++)
                    {
                        rowNum = this.layBarcode.InsertRow(j-1);

                        this.layBarcode.SetItemValue(rowNum, "jundal_gubun", this.layBarcodeTemp.GetItemString(i, "jundal_gubun"));
                        this.layBarcode.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcodeTemp.GetItemString(i, "jundal_gubun_name"));
                        this.layBarcode.SetItemValue(rowNum, "specimen_code", this.layBarcodeTemp.GetItemString(i, "specimen_code"));
                        this.layBarcode.SetItemValue(rowNum, "specimen_name", this.layBarcodeTemp.GetItemString(i, "specimen_name"));
                        this.layBarcode.SetItemValue(rowNum, "tube_code", this.layBarcodeTemp.GetItemString(i, "tube_code"));
                        this.layBarcode.SetItemValue(rowNum, "tube_name", this.layBarcodeTemp.GetItemString(i, "tube_name"));
                        this.layBarcode.SetItemValue(rowNum, "in_out_gubun", this.layBarcodeTemp.GetItemString(i, "in_out_gubun"));
                        this.layBarcode.SetItemValue(rowNum, "specimen_ser", this.layBarcodeTemp.GetItemString(i, "specimen_ser"));
                        this.layBarcode.SetItemValue(rowNum, "bunho", this.layBarcodeTemp.GetItemString(i, "bunho"));
                        this.layBarcode.SetItemValue(rowNum, "suname", this.layBarcodeTemp.GetItemString(i, "suname"));
                        this.layBarcode.SetItemValue(rowNum, "gwa_name", this.layBarcodeTemp.GetItemString(i, "gwa_name"));
                        this.layBarcode.SetItemValue(rowNum, "danger_yn", this.layBarcodeTemp.GetItemString(i, "danger_yn"));
                        this.layBarcode.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcodeTemp.GetItemString(i, "specimen_ser_ba"));
                        this.layBarcode.SetItemValue(rowNum, "jangbi_code", this.layBarcodeTemp.GetItemString(i, "jangbi_code"));
                        this.layBarcode.SetItemValue(rowNum, "jangbi_name", this.layBarcodeTemp.GetItemString(i, "jangbi_name"));
                        this.layBarcode.SetItemValue(rowNum, "gumsa_name_re", this.layBarcodeTemp.GetItemString(i, "gumsa_name_re"));
                        this.layBarcode.SetItemValue(rowNum, "tube_max_amt", this.layBarcodeTemp.GetItemString(i, "tube_max_amt"));
                        this.layBarcode.SetItemValue(rowNum, "tube_numbering", this.layBarcodeTemp.GetItemString(i, "tube_numbering"));
                    }
                }
                */

                foreach (DataRow row in this.layBarcodeTemp.LayoutTable.Rows)
                {
                    t_tube_count = 0;

                    if (!TypeCheck.IsNull(row["tube_count"]))
                        t_tube_count = Convert.ToInt32(row["tube_count"]);

                    for (int j = 0; j < t_tube_count; j++)
                    {
                        this.layBarcode.LayoutTable.ImportRow(row);
                    }
                }
            }

        }
        
        private void layBarcodeTemp2_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBarcodeTemp2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layBarcodeTemp2_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                this.layBarcode2.Reset();
                //int t_tube_count = 0;
                //int rowNum = 0;
                /*
                for (int i = 0; i < layBarcodeTemp2.RowCount; i++)
                {
                    //t_tube_count = layBarcodeTemp2.GetItemInt(i, "tube_count");

                    //for (int j = 0; j < t_tube_count; j++)
                    //{
                        rowNum = this.layBarcode2.InsertRow(i-1);

                        this.layBarcode2.SetItemValue(rowNum, "jundal_gubun", this.layBarcodeTemp2.GetItemString(i, "jundal_gubun"));
                        this.layBarcode2.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcodeTemp2.GetItemString(i, "jundal_gubun_name"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_code", this.layBarcodeTemp2.GetItemString(i, "specimen_code"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_name", this.layBarcodeTemp2.GetItemString(i, "specimen_name"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_code", this.layBarcodeTemp2.GetItemString(i, "tube_code"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_name", this.layBarcodeTemp2.GetItemString(i, "tube_name"));
                        this.layBarcode2.SetItemValue(rowNum, "in_out_gubun", this.layBarcodeTemp2.GetItemString(i, "in_out_gubun"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_ser", this.layBarcodeTemp2.GetItemString(i, "specimen_ser"));
                        this.layBarcode2.SetItemValue(rowNum, "bunho", this.layBarcodeTemp2.GetItemString(i, "bunho"));
                        this.layBarcode2.SetItemValue(rowNum, "suname", this.layBarcodeTemp2.GetItemString(i, "suname"));
                        this.layBarcode2.SetItemValue(rowNum, "gwa_name", this.layBarcodeTemp2.GetItemString(i, "gwa_name"));
                        this.layBarcode2.SetItemValue(rowNum, "danger_yn", this.layBarcodeTemp2.GetItemString(i, "danger_yn"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcodeTemp2.GetItemString(i, "specimen_ser_ba"));
                        this.layBarcode2.SetItemValue(rowNum, "jangbi_code", this.layBarcodeTemp2.GetItemString(i, "jangbi_code"));
                        this.layBarcode2.SetItemValue(rowNum, "jangbi_name", this.layBarcodeTemp2.GetItemString(i, "jangbi_name"));
                        this.layBarcode2.SetItemValue(rowNum, "gumsa_name_re", this.layBarcodeTemp2.GetItemString(i, "gumsa_name_re"));
                        this.layBarcode2.SetItemValue(rowNum, "hangmog_code", this.layBarcodeTemp2.GetItemString(i, "gumsa_name_re"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_max_amt", this.layBarcodeTemp2.GetItemString(i, "tube_max_amt"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_numbering", this.layBarcodeTemp2.GetItemString(i, "tube_numbering"));
                    //}
                }
                */
                foreach (DataRow row in this.layBarcodeTemp2.LayoutTable.Rows)
                {
       //             dwBarcode.Reset();
                    layBarcode2.Reset();
                    this.layBarcode2.LayoutTable.ImportRow(row);
                }
            }

        }

        #region XSavePerformer 
        string o_gubun = "";
        string o_flag = "";
        string o_specimen_ser = "";
        string o_pkcpl2010 = "";

        string mErrMsg = "";
        private class XSavePerformer : ISavePerformer
        {
            CPL3010U00 parent;

            public XSavePerformer(CPL3010U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                parent.mErrMsg = "";
                parent.o_flag = "";

                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();

                item.BindVarList.Add("q_user_id", parent.cbxActor.GetDataValue());
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                { 
                    case '1':

                        switch (item.RowState)
                        { 
                            case DataRowState.Modified:

                                cmdText = @"SELECT DECODE( NVL(MIN(SPECIMEN_SER), 'N'), 'N', 'N', 'Y') 
                                              FROM CPL2010
                                             WHERE HOSP_CODE      = :f_hosp_code 
                                               AND SPECIMEN_SER   = :f_specimen_ser
                                               AND GUM_JUBSU_DATE IS NOT NULL";

                                object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                string t_flag = "";

                                if (!TypeCheck.IsNull(retVal))
                                {
                                    t_flag = retVal.ToString();
                                }

                                cmdText = @"UPDATE CPL2010
                                               SET GUM_JUBSU_DATE = NULL
                                                 , GUM_JUBSU_TIME = NULL
                                                 , GUM_JUBSUJA    = NULL
                                             WHERE HOSP_CODE      = :f_hosp_code 
                                               AND SPECIMEN_SER   = :f_specimen_ser
                                               AND GUM_JUBSU_DATE IS NOT NULL";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        parent.mErrMsg = Service.ErrFullMsg;
                                        return false;
                                    }
                                }

                                inputList.Clear();
                                inputList.Add(parent.cbxActor.GetDataValue());
                                inputList.Add(item.BindVarList["f_specimen_ser"].VarValue);
                                inputList.Add(DBNull.Value);
                                inputList.Add("1");
                                inputList.Add(item.BindVarList["f_part_jubsuja"].VarValue);

                                if (!Service.ExecuteProcedure("PR_CPL_PART_JUBSU_CANCEL", inputList, outputList))
                                {
                                    parent.mErrMsg = Service.ErrFullMsg;
                                    return false;
                                }

                                if (outputList.Count > 0)
                                    t_flag = outputList[0].ToString();

                                if (parent.o_flag == "C" || parent.o_flag == "P" || parent.o_flag == "O")
                                {
                                    parent.o_gubun = "1";
                                    parent.o_flag = t_flag;
                                    parent.o_specimen_ser = item.BindVarList["f_part_jubsuja"].VarValue;
                                    parent.o_pkcpl2010 = "";
                                }
                                return true;

                                //break;
                        }

                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:

                                if (item.BindVarList["f_jubsu_yn"].VarValue == "N")
                                {
                                    inputList.Clear();
                                    inputList.Add(parent.cbxActor.GetDataValue());
                                    inputList.Add(item.BindVarList["f_specimen_ser"].VarValue);
                                    inputList.Add(item.BindVarList["f_fkcpl2010"].VarValue);
                                    inputList.Add("2");
                                    inputList.Add(item.BindVarList["f_part_jubsuja"].VarValue);

                                    if (!Service.ExecuteProcedure("PR_CPL_PART_JUBSU_CANCEL", inputList, outputList))
                                    {
                                        parent.mErrMsg = Service.ErrFullMsg;
                                        return false;
                                    }

                                    string t_flag = "";
                                    if (outputList.Count > 0)
                                        t_flag = outputList[0].ToString();

                                    if (parent.o_flag == "C" || parent.o_flag == "P" || parent.o_flag == "O")
                                    {
                                        parent.o_gubun = "2";
                                        parent.o_flag = t_flag;
                                        parent.o_specimen_ser = item.BindVarList["f_part_jubsuja"].VarValue;
                                        parent.o_pkcpl2010 = item.BindVarList["f_fkcpl2010"].VarValue;
                                    }
                                }                          

                                return true;

                                //break;
                        }

                        break;

                    case '3':

                        cmdText = @"BEGIN

                                    UPDATE CPL1000
                                       SET UPD_ID       = :q_user_id
                                         , UPD_DATE     = SYSDATE
                                         , URINE_RYANG  = NVL(:f_urine_ryang,'0')
                                         , STABILITY_YN = :f_stability_yn 
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       --AND PKCPL1000    = :f_pkcpl1000
                                       AND SPECIMEN_SER = :f_specimen_ser
                                       ;  
                                       

                                      IF SQL%NOTFOUND THEN
                                      
                                        INSERT INTO CPL1000
                                             ( SYS_DATE         , SYS_ID            
                                             , UPD_DATE         , UPD_ID            ,HOSP_CODE
                                             , PKCPL1000        , URINE_RYANG       
                                             , STABILITY_YN     , SPECIMEN_SER )
                                        VALUES 
                                             ( SYSDATE          , :q_user_id                 
                                             , SYSDATE          , :q_user_id        , :f_hosp_code
                                             , :f_pkcpl1000     , NVL(:f_urine_ryang,'0') 
                                             , :f_stability_yn  , :f_specimen_ser          );
                                      
                                      END IF;

                                    END;";
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }   
        }

        #endregion

        private void fwkJangbi_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.fwkJangbi.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.fwkJangbi.SetBindVarValue("f_jundal_gubun", this.fbxJundalGubun.GetDataValue());
        }

        private void fbxJundalGubun_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.vsvJundalGubun.SetBindVarValue("f_code", e.DataValue);
            this.vsvJundalGubun.QueryLayout();

            if (this.vsvJundalGubun.GetItemValue("code_name").ToString() == "")
            {
                e.Cancel = true;
                return;
            }
        }
        private void grdGum_QueryEnd(object sender, QueryEndEventArgs e)
        {
            // TODO comment: Use connect to cloud
            /*string cmdText = @"SELECT DECODE(IN_OUT_GUBUN,'O',FKOCS1003,'I',FKOCS2003)
                                  FROM CPL2010
                                 WHERE HOSP_CODE = :f_hosp_code
                                   AND PKCPL2010 = :f_fkcpl2010";
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);

            for (int i = 0; i < this.grdGum.RowCount; i++)
            {
                bc.Remove("f_fkcpl2010");
                bc.Add("f_fkcpl2010", this.grdGum.GetItemString(i, "pkcpl2010"));

                object t_fkocs = Service.ExecuteScalar(cmdText, bc);
                
                if(!TypeCheck.IsNull(t_fkocs))
                    this.grdGum.SetItemValue(i, "fkocs", t_fkocs.ToString());

            }*/

            this.grdGum.ResetUpdate();

            // 응급시 항목 바꿀수 있도록 수정
            //this.FindEmergency();
            //			this.FindEmergency2();
            //			this.FindEmergency3();
            this.txtSpecimenRead.Focus();

        }

        private void grdGum_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdGum.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdGum.SetBindVarValue("f_specimen_ser", this.grdPart.GetItemString(this.grdPart.CurrentRowNumber, "specimen_ser"));
            //this.grdGum.SetBindVarValue("f_jundal_gubun", this.grdPart.GetItemString(this.grdPart.CurrentRowNumber, "jundal_gubun"));
        }

        private void laySpcialName_YN_QueryStarting(object sender, CancelEventArgs e)
        {
            this.laySpcialName_YN.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.laySpcialName_YN.SetBindVarValue("f_specimen_ser", this.grdPart.GetItemString(this.grdPart.CurrentRowNumber, "specimen_ser"));
        }

        #region Connect to cloud service

        /// <summary>
        /// dsvUrine ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryCPL3010U00DsvUrine(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00DsvUrineArgs vCPL3010U00DsvUrineArgs = new CPL3010U00DsvUrineArgs();
            vCPL3010U00DsvUrineArgs.SpecimenSer = bc["f_specimen_ser"].VarValue;
            vCPL3010U00DsvUrineArgs.Fkocs = bc["f_fkocs"].VarValue;
            vCPL3010U00DsvUrineArgs.InOutGubun = bc["f_in_out_gubun"].VarValue;
            vCPL3010U00DsvUrineArgs.Gubun = bc["f_gubun"].VarValue;
            CPL3010U00DsvUrineResult result =
                CloudService.Instance.Submit<CPL3010U00DsvUrineResult, CPL3010U00DsvUrineArgs>(vCPL3010U00DsvUrineArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3010U00DsvUrineListItemInfo item in result.DsvUrineItem)
                {
                    object[] objects =
                    {
                        item.Pkcpl1000,
                        item.UrineRyang,
                        item.Height,
                        item.Weight,
                        item.StabilityYn,
                        item.SpecimenSer
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// GrdGum ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryCPL3010U00GrdGum(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00GrdGumArgs vCPL3010U00GrdGumArgs = new CPL3010U00GrdGumArgs();
            vCPL3010U00GrdGumArgs.SpecimenSer = bc["f_specimen_ser"].VarValue;
            CPL3010U00GrdGumResult result =
                CloudService.Instance.Submit<CPL3010U00GrdGumResult, CPL3010U00GrdGumArgs>(vCPL3010U00GrdGumArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3010U00GrdGumListItemInfo item in result.GrdGumItem)
                {
                    object[] objects =
                    {
                        item.SpecimenSer,
                        item.Fkcpl2010,
                        item.GumsaName,
                        item.JangbiName,
                        item.CplResult,
                        item.SpecimenName,
                        item.HangmogCode,
                        item.PartJubsuja,
                        item.SubJubsuYn,
                        item.SpcialName,
                        item.Fkocs,
                        item.ConfirmYn,
                        item.DataRowState
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// GrdPart ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryCPL3010U00GrdPart(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00GrdPartArgs vCPL3010U00GrdPartArgs = new CPL3010U00GrdPartArgs();
            vCPL3010U00GrdPartArgs.PartJubsuDate = bc["f_part_jubsu_date"].VarValue;
            CPL3010U00GrdPartResult result =
                CloudService.Instance.Submit<CPL3010U00GrdPartResult, CPL3010U00GrdPartArgs>(vCPL3010U00GrdPartArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3010U00GrdPartListItemInfo item in result.GrdPartInfo)
                {
                    object[] objects =
                    {
                        item.LabNo,
                        item.SpecimenSer,
                        item.Bunho,
                        item.Suname2,
                        item.FnBasLoadGwaName,
                        item.HoDong,
                        item.PartJubsuDate,
                        item.PartJubsuTime,
                        item.PartJubsuja,
                        item.Jubsuja,
                        item.Remark,
                        item.PartJubsuFlag,
                        item.Fkocs,
                        item.InOutGubun,
                        item.DoctorName,
                        item.TubeName,
                        item.Emergency,
                        item.SunabYn,
                        item.ResultYn,
                        item.LabelOneMore,
                        item.DataRowState
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// LayBarCodeTemp ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryCPL3010U00LayBarCodeTemp(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00LayBarCodeTempArgs vCPL3010U00LayBarCodeTempArgs = new CPL3010U00LayBarCodeTempArgs();
            vCPL3010U00LayBarCodeTempArgs.SpecimenSer = bc["f_specimen_ser"].VarValue;
            CPL3010U00LayBarCodeTempResult result = CloudService.Instance.Submit<CPL3010U00LayBarCodeTempResult, CPL3010U00LayBarCodeTempArgs>(vCPL3010U00LayBarCodeTempArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3010U00LayBarCodeTempListItemInfo item in result.LayBarCodeTempItem)
                {
                    object[] objects =
                    {
                        item.JundalGubun,
                        item.JundalGubunName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.TubeCode,
                        item.TubeName,
                        item.InOutGubun,
                        item.SpecimenSer,
                        item.Bunho,
                        item.Suname,
                        item.GwaName,
                        item.DangerYn,
                        item.SpecimenSerBa,
                        item.JangbiCode,
                        item.JangbiName,
                        item.GumsaNameRe,
                        item.TubeCount,
                        item.TubeMaxAmt,
                        item.TubeNumbering,
                        item.HangmogCode
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// LayBarCodeTemp2 ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryCPL3010U00LayBarCodeTemp2(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00LayBarCodeTemp2Args vCPL3010U00LayBarCodeTemp2Args = new CPL3010U00LayBarCodeTemp2Args();
            vCPL3010U00LayBarCodeTemp2Args.SpecimenSer = bc["f_specimen_ser"].VarValue;
            CPL3010U00LayBarCodeTemp2Result result = CloudService.Instance.Submit<CPL3010U00LayBarCodeTemp2Result, CPL3010U00LayBarCodeTemp2Args>(vCPL3010U00LayBarCodeTemp2Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3010U00LayBarCodeTemp2ListItemInfo item in result.LayBarCodeTemp2)
                {
                    object[] objects =
                    {
                        item.JundalGubun,
                        item.JundalGubunName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.TubeCode,
                        item.TubeName,
                        item.InOutGubun,
                        item.SpecimenSer,
                        item.Bunho,
                        item.Suname,
                        item.UitakName,
                        item.DangerYn,
                        item.SpecimenSerBa,
                        item.JangbiName,
                        item.GumsaNameRe,
                        item.TubeAmt,
                        item.TubeNumbering
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// LaySpecimenInfo ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryCPL3010U00LaySpecimenInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00LaySpecimenArgs vCPL3010U00LaySpecimenArgs = new CPL3010U00LaySpecimenArgs();
            vCPL3010U00LaySpecimenArgs.SpecimenSer = bc["f_specimen_ser"].VarValue;
            CPL3010U00LaySpecimenResult result = CloudService.Instance.Submit<CPL3010U00LaySpecimenResult, CPL3010U00LaySpecimenArgs>(vCPL3010U00LaySpecimenArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3010U00LaySpecimenInfoListItemInfo item in result.LaySpecimenInfo)
                {
                    object[] objects =
                    {
                        item.Bunho,
                        item.Suname,
                        item.Sex,
                        item.Birth,
                        item.GwaName,
                        item.DoctorName,
                        item.HoDongName,
                        item.HoCode,
                        item.OrderDate,
                        item.JubsuDate,
                        item.PartJubsuDate,
                        item.JubsuTime,
                        item.PartJubsuTime,
                        item.Jubsuja,
                        item.InOutGubun,
                        item.JundalGubun,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.Tat1,
                        item.Tat2,
                        item.Age
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// LoadDataCbxActor
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadDataCbxActor(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboADM3200CbxActorArgs args = new ComboADM3200CbxActorArgs();
            //ComboResult result = CacheService.Instance.Get<ComboADM3200CbxActorArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_ADM3200_CBXACTOR,
            //    args, delegate(ComboResult cboResult)
            //    {
            //        return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
            //               cboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<ComboADM3200CbxActorArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }

            return dataList;
        }

        /// <summary>
        /// laySpcialName_YN ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryString(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00LaySpecimenReadArgs vCPL3010U00LaySpecimenReadArgs = new CPL3010U00LaySpecimenReadArgs();
            vCPL3010U00LaySpecimenReadArgs.SpecimenSer = bc["f_specimen_ser"].VarValue;
            CPL3010U00LaySpecimenReadResult result = CloudService.Instance.Submit<CPL3010U00LaySpecimenReadResult, CPL3010U00LaySpecimenReadArgs>(vCPL3010U00LaySpecimenReadArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                string yValue = result.YValue;
                res.Add(new object[] { yValue });
            }

            return res;
        }

        /// <summary>
        /// vsvJubsuja ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryVSVJubsuja(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00VSVJubsujaArgs vCPL3010U00VSVJubsujaArgs = new CPL3010U00VSVJubsujaArgs();
            vCPL3010U00VSVJubsujaArgs.UserId = bc["f_user_id"].VarValue;
            CPL3010U00VSVJubsujaResult result = CloudService.Instance.Submit<CPL3010U00VSVJubsujaResult, CPL3010U00VSVJubsujaArgs>(vCPL3010U00VSVJubsujaArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                string vsvJubsuja = result.UserName;
                res.Add(new object[] { vsvJubsuja });
            }
            return res;
        }

        /// <summary>
        /// vsvJundalGubun  ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryVSVJundalGubun(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00VSVJundalGubunArgs vCPL3010U00VSVJundalGubunArgs = new CPL3010U00VSVJundalGubunArgs();
            vCPL3010U00VSVJundalGubunArgs.Code = bc["f_code"].VarValue;
            vCPL3010U00VSVJundalGubunArgs.CodeType = "01";
            CPL3010U00VSVJundalGubunResult result = CloudService.Instance.Submit<CPL3010U00VSVJundalGubunResult, CPL3010U00VSVJundalGubunArgs>(vCPL3010U00VSVJundalGubunArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                string vsvJundalGubun = result.CodeName;
                res.Add(new object[] { vsvJundalGubun });
               
            }
            return res;
        }

        /// <summary>
        /// get SpecimenBySer
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQuerSpecimenBySer(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00QuerySpecimenBySerArgs vCPL3010U00QuerySpecimenBySerArgs = new CPL3010U00QuerySpecimenBySerArgs();
            vCPL3010U00QuerySpecimenBySerArgs.SpecimenSer = bc["f_specimen_ser"].VarValue;
            CPL3010U00QuerySpecimenBySerResult result = CloudService.Instance.Submit<CPL3010U00QuerySpecimenBySerResult, CPL3010U00QuerySpecimenBySerArgs>(vCPL3010U00QuerySpecimenBySerArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3010U00GrdPartListItemInfo item in result.GrdPartList)
                {
                    object[] objects =
                    {
                        item.LabNo,
                        item.SpecimenSer,
                        item.Bunho,
                        item.Suname2,
                        item.FnBasLoadGwaName,
                        item.HoDong,
                        item.PartJubsuDate,
                        item.PartJubsuTime,
                        item.PartJubsuja,
                        item.Jubsuja,
                        item.Remark,
                        item.PartJubsuFlag,
                        item.Fkocs,
                        item.InOutGubun,
                        item.DoctorName,
                        item.TubeName,
                        item.Emergency,
                        item.SunabYn,
                        item.ResultYn,
                        item.LabelOneMore,
                        item.DataRowState
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// CreateListGrdPartInfo
        /// </summary>
        /// <returns></returns>
        private List<CPL3010U00GrdPartListItemInfo> CreateListGrdPartInfo()
        {
            List<CPL3010U00GrdPartListItemInfo> lstGrdPartListItemInfo = new List<CPL3010U00GrdPartListItemInfo>();
            for (int i = 0; i < grdPart.RowCount; i++)
            {
                if (grdPart.GetRowState(i) == DataRowState.Added || grdPart.GetRowState(i) == DataRowState.Modified)
                {
                    CPL3010U00GrdPartListItemInfo itemInfo = new CPL3010U00GrdPartListItemInfo();
//                    itemInfo.LabNo = grdPart.GetItemString(i, "lab_no");
                    itemInfo.SpecimenSer = grdPart.GetItemString(i, "specimen_ser");

//                    itemInfo.Bunho = grdPart.GetItemString(i, "bunho");
//                    itemInfo.Suname2 = grdPart.GetItemString(i, "suname2");
//                    itemInfo.FnBasLoadGwaName = grdPart.GetItemString(i, "fn_bas_load_gwa_name");
//                    itemInfo.HoDong = grdPart.GetItemString(i, "ho_dong");
//                    itemInfo.PartJubsuDate = grdPart.GetItemString(i, "part_jubsu_date");
//                    itemInfo.PartJubsuTime = grdPart.GetItemString(i, "part_jubsu_time");
//                    itemInfo.PartJubsuja = grdPart.GetItemString(i, "part_jubsuja");
//                    itemInfo.Jubsuja = grdPart.GetItemString(i, "jubsuja");
//                    itemInfo.Remark = grdPart.GetItemString(i, "remark");
//                    itemInfo.PartJubsuFlag = grdPart.GetItemString(i, "part_jubsu_flag");
//                    itemInfo.Fkocs = grdPart.GetItemString(i, "fkocs");
//                    itemInfo.InOutGubun = grdPart.GetItemString(i, "in_out_gubun");
//                    itemInfo.DoctorName = grdPart.GetItemString(i, "doctor_name");
//                    itemInfo.TubeName = grdPart.GetItemString(i, "tube_name");
//                    itemInfo.Emergency = grdPart.GetItemString(i, "emergency");
//                    itemInfo.SunabYn = grdPart.GetItemString(i, "sunab_yn");
//                    itemInfo.ResultYn = grdPart.GetItemString(i, "result_yn");
//                    itemInfo.LabelOneMore = grdPart.GetItemString(i, "label_one_more");
                    if (grdPart.GetRowState(i) == DataRowState.Modified)
                    {
                        itemInfo.PartJubsuja = cbxActor.GetDataValue();
                    }
                    itemInfo.DataRowState = grdPart.GetRowState(i).ToString();

                    lstGrdPartListItemInfo.Add(itemInfo);
                }
            }
/*
            if (grdPart.DeletedRowTable != null && grdPart.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdPart.DeletedRowTable.Rows)
                {
                    CPL3010U00GrdPartListItemInfo itemInfo = new CPL3010U00GrdPartListItemInfo();
                    itemInfo.LabNo = row["lab_no"].ToString();
                    itemInfo.SpecimenSer = row["specimen_ser"].ToString();
                    itemInfo.Bunho = row["bunho"].ToString();
                    itemInfo.Suname2 = row["suname2"].ToString();
                    itemInfo.FnBasLoadGwaName = row["fn_bas_load_gwa_name"].ToString();
                    itemInfo.HoDong = row["ho_dong"].ToString();
                    itemInfo.PartJubsuDate = row["part_jubsu_date"].ToString();
                    itemInfo.PartJubsuTime = row["part_jubsu_time"].ToString();
                    itemInfo.Jubsuja = row["jubsuja"].ToString();
                    itemInfo.Remark = row["remark"].ToString();
                    itemInfo.PartJubsuFlag = row["part_jubsu_flag"].ToString();
                    itemInfo.Fkocs = row["fkocs"].ToString();
                    itemInfo.InOutGubun = row["in_out_gubun"].ToString();
                    itemInfo.DoctorName = row["doctor_name"].ToString();
                    itemInfo.TubeName = row["tube_name"].ToString();
                    itemInfo.Emergency = row["emergency"].ToString();
                    itemInfo.SunabYn = row["sunab_yn"].ToString();
                    itemInfo.ResultYn = row["result_yn"].ToString();
                    itemInfo.LabelOneMore = row["label_one_more"].ToString();
                    itemInfo.PartJubsuja = row["part_jubsuja"].ToString();
                    itemInfo.DataRowState = DataRowState.Deleted.ToString();

                    lstGrdPartListItemInfo.Add(itemInfo);
                }
            }*/
            return lstGrdPartListItemInfo;
        }

        /// <summary>
        /// CreateListGrdGumInfo
        /// </summary>
        /// <returns></returns>
	    private List<CPL3010U00GrdGumListItemInfo> CreateListGrdGumInfo()
	    {
	        List<CPL3010U00GrdGumListItemInfo> lstGrdGumListItemInfo = new List<CPL3010U00GrdGumListItemInfo>();
	        for (int i = 0; i < grdGum.RowCount; i++)
	        {
	            if (grdGum.GetRowState(i) == DataRowState.Added || grdGum.GetRowState(i) == DataRowState.Modified)
	            {
	                CPL3010U00GrdGumListItemInfo itemInfo = new CPL3010U00GrdGumListItemInfo();
	                itemInfo.SpecimenSer = grdGum.GetItemString(i, "specimen_ser");
	                itemInfo.Fkcpl2010 = grdGum.GetItemString(i, "fkcpl2010");
//	                itemInfo.GumsaName = grdGum.GetItemString(i, "gumsa_name");
//	                itemInfo.JangbiName = grdGum.GetItemString(i, "jangbi_name");
//	                itemInfo.CplResult = grdGum.GetItemString(i, "cpl_result");
//	                itemInfo.SpecimenName = grdGum.GetItemString(i, "specimen_name");
//	                itemInfo.HangmogCode = grdGum.GetItemString(i, "hangmog_code");
	                itemInfo.SubJubsuYn = grdGum.GetItemString(i, "jubsu_yn");
//	                itemInfo.SpcialName = grdGum.GetItemString(i, "spcial_name");
//	                itemInfo.Fkocs = grdGum.GetItemString(i, "fkocs");
//	                itemInfo.ConfirmYn = grdGum.GetItemString(i, "confirm_yn");
	                itemInfo.DataRowState = grdGum.GetRowState(i).ToString();
	                if (grdGum.GetRowState(i) == DataRowState.Modified)
	                {
                        itemInfo.PartJubsuja = this.cbxActor.GetDataValue();
	                }
                    lstGrdGumListItemInfo.Add(itemInfo);
	            }
	        }
/*
	        if (grdGum.DeletedRowTable != null && grdGum.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdGum.DeletedRowTable.Rows)
	            {
                    CPL3010U00GrdGumListItemInfo itemInfo = new CPL3010U00GrdGumListItemInfo();
                    itemInfo.SpecimenSer = row["specimen_ser"].ToString();
                    itemInfo.Fkcpl2010 = row["fkcpl2010"].ToString();
                    itemInfo.GumsaName = row["gumsa_name"].ToString();
                    itemInfo.JangbiName = row["jangbi_name"].ToString();
                    itemInfo.CplResult = row["cpl_result"].ToString();
                    itemInfo.SpecimenName = row["specimen_name"].ToString();
                    itemInfo.HangmogCode = row["hangmog_code"].ToString();
                    itemInfo.SubJubsuYn = row["jubsu_yn"].ToString();
                    itemInfo.SpcialName = row["spcial_name"].ToString();
                    itemInfo.Fkocs = row["fkocs"].ToString();
                    itemInfo.ConfirmYn = row["confirm_yn"].ToString();
                    itemInfo.PartJubsuja = row["part_jubsuja"].ToString();
	                itemInfo.DataRowState = DataRowState.Deleted.ToString();

                    lstGrdGumListItemInfo.Add(itemInfo);
	            }
                
	        }*/
	        return lstGrdGumListItemInfo;
	    }

        /// <summary>
        /// CreateListLayUrineInfo
        /// </summary>
        /// <returns></returns>
	    private List<CPL3010U00LayUrineInfo> CreateListLayUrineInfo()
	    {
	        List<CPL3010U00LayUrineInfo> lstLayUrineInfo = new List<CPL3010U00LayUrineInfo>();

	        foreach (DataRow row in layUrine.LayoutTable.Rows)
	        {
	            if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
	            {
	                CPL3010U00LayUrineInfo itemInfo = new CPL3010U00LayUrineInfo();
	                itemInfo.UserId = row["user_id"].ToString();
	                itemInfo.UrineRyang = row["urine_ryang"].ToString();
	                itemInfo.StabilityYn = row["stability_yn"].ToString();
	                itemInfo.SpecimenSer = row["specimen_ser"].ToString();
	                itemInfo.Pkcpl1000 = row["pkcpl1000"].ToString();

	                lstLayUrineInfo.Add(itemInfo);
	            }
	        }
            return lstLayUrineInfo;
	    }

        /// <summary>
        /// layPrintName
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGetPrintName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3010U00GetPrintNameArgs vCPL3010U00GetPrintNameArgs = new CPL3010U00GetPrintNameArgs();
            vCPL3010U00GetPrintNameArgs.IpAddr = bc["f_ip_addr"] != null ? bc["f_ip_addr"].VarValue : "";
            CPL3010U00GetPrintNameResult result = CloudService.Instance.Submit<CPL3010U00GetPrintNameResult, CPL3010U00GetPrintNameArgs>(vCPL3010U00GetPrintNameArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.Addr)
                {
                    object[] objects =
                    {
                        item.DataValue
                    };
                    res.Add(objects);
                }
            }
            return res;
        } 



	    #endregion
    }
}

