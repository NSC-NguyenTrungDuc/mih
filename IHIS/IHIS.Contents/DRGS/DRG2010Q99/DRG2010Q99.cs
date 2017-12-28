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

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG2010Q99에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG2010Q99 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XMstGrid grdMaster;
		private IHIS.Framework.XMstGrid grdDetail;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XButton btnOrderList;
		private IHIS.Framework.XDatePicker dtpFromDate;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XDatePicker dtpToDate;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XButton btnPrint;
		private IHIS.Framework.MultiLayout layOrder;
		private IHIS.Framework.XButton btnAllUnCheck;
		private IHIS.Framework.XButton btnAllCheck;
        private IHIS.Framework.XButton btnCommentForm;
		private IHIS.Framework.XCheckBox cbxAntiYn;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private System.Windows.Forms.ImageList imageListMixGroup;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.X.Magic.Controls.TabPage tabPage1;
		private IHIS.X.Magic.Controls.TabPage tabPage2;
		private IHIS.Framework.XPanel xPanel4;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ImageList imageList1;
        private IHIS.Framework.XPanel pnlOrder;
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
        private IHIS.Framework.XTabControl tabOrd;
		private IHIS.Framework.XButton xButton1;
        //private IHIS.Framework.XDataWindow dw_1;
        //private IHIS.Framework.XDataWindow dw_lable;
		private IHIS.Framework.XEditGrid grdOrderInfo;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell102;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell134;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell135;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell136;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell137;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell153;
		private IHIS.Framework.XEditGridCell xEditGridCell154;
		private IHIS.Framework.XEditGridCell xEditGridCell155;
		private IHIS.Framework.XEditGridCell xEditGridCell156;
		private IHIS.Framework.XEditGridCell xEditGridCell157;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell140;
		private IHIS.Framework.XEditGridCell xEditGridCell141;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell158;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell131;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
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
		private IHIS.Framework.XEditGridCell xEditGridCell71;
		private IHIS.Framework.XEditGridCell xEditGridCell72;
		private IHIS.Framework.XEditGridCell xEditGridCell159;
		private IHIS.Framework.XEditGridCell xEditGridCell139;
		private IHIS.Framework.XEditGridCell xEditGridCell94;
		private IHIS.Framework.XEditGridCell xEditGridCell73;
		private IHIS.Framework.XEditGridCell xEditGridCell152;
		private IHIS.Framework.XEditGridCell xEditGridCell74;
		private IHIS.Framework.XEditGridCell xEditGridCell95;
		private IHIS.Framework.XEditGridCell xEditGridCell96;
		private IHIS.Framework.XEditGridCell xEditGridCell97;
		private IHIS.Framework.XEditGridCell xEditGridCell142;
		private IHIS.Framework.XEditGridCell xEditGridCell145;
		private IHIS.Framework.XEditGridCell xEditGridCell146;
		private IHIS.Framework.XEditGridCell xEditGridCell160;
		private IHIS.Framework.XEditGridCell xEditGridCell161;
		private IHIS.Framework.XEditGridCell xEditGridCell149;
		private IHIS.Framework.XEditGridCell xEditGridCell147;
		private IHIS.Framework.XEditGridCell xEditGridCell148;
		private IHIS.Framework.XEditGridCell xEditGridCell75;
		private IHIS.Framework.XEditGridCell xEditGridCell76;
		private IHIS.Framework.XEditGridCell xEditGridCell77;
		private IHIS.Framework.XEditGridCell xEditGridCell78;
		private IHIS.Framework.XEditGridCell xEditGridCell79;
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
		private IHIS.Framework.XEditGridCell xEditGridCell128;
		private IHIS.Framework.XEditGridCell xEditGridCell90;
		private IHIS.Framework.XEditGridCell xEditGridCell91;
		private IHIS.Framework.XEditGridCell xEditGridCell92;
		private IHIS.Framework.XEditGridCell xEditGridCell93;
		private IHIS.Framework.XEditGridCell xEditGridCell98;
		private IHIS.Framework.XEditGridCell xEditGridCell99;
		private IHIS.Framework.XEditGridCell xEditGridCell100;
		private IHIS.Framework.XEditGridCell xEditGridCell101;
		private IHIS.Framework.XEditGridCell xEditGridCell103;
		private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell132;
		private IHIS.Framework.XEditGridCell xEditGridCell150;
		private IHIS.Framework.XEditGridCell xEditGridCell143;
		private IHIS.Framework.XEditGridCell xEditGridCell144;
		private IHIS.Framework.XEditGridCell xEditGridCell162;
		private IHIS.Framework.XEditGridCell xEditGridCell163;
		private IHIS.Framework.XEditGridCell xEditGridCell138;
		private IHIS.Framework.XEditGridCell xEditGridCell133;
		private IHIS.Framework.XGridHeader xGridHeader1;
        private MultiLayoutItem multiLayoutItem1;
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
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private XEditGridCell xEditGridCell108;
        private MultiLayout layOrderJungbo;
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
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
		private System.ComponentModel.IContainer components;

		public DRG2010Q99()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG2010Q99));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cbxAntiYn = new IHIS.Framework.XCheckBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.tabOrd = new IHIS.Framework.XTabControl();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.grdDetail = new IHIS.Framework.XMstGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.grdOrderInfo = new IHIS.Framework.XEditGrid();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xButton1 = new IHIS.Framework.XButton();
            this.btnCommentForm = new IHIS.Framework.XButton();
            this.btnAllUnCheck = new IHIS.Framework.XButton();
            this.btnAllCheck = new IHIS.Framework.XButton();
            this.btnOrderList = new IHIS.Framework.XButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.layOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.layOrderJungbo = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.tabOrd.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderInfo)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.cbxAntiYn);
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Controls.Add(this.dtpToDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpFromDate);
            this.xPanel1.Controls.Add(this.xLabel3);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // cbxAntiYn
            // 
            resources.ApplyResources(this.cbxAntiYn, "cbxAntiYn");
            this.cbxAntiYn.Name = "cbxAntiYn";
            this.cbxAntiYn.UseVisualStyleBackColor = false;
            this.cbxAntiYn.CheckedChanged += new System.EventHandler(this.cbxAntiYn_CheckedChanged);
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating_1);
            // 
            // xLabel2
            // 
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating_1);
            // 
            // xLabel3
            // 
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.tabOrd);
            this.xPanel2.Controls.Add(this.xPanel4);
            this.xPanel2.DrawBorder = true;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // tabOrd
            // 
            resources.ApplyResources(this.tabOrd, "tabOrd");
            this.tabOrd.IDEPixelArea = true;
            this.tabOrd.IDEPixelBorder = false;
            this.tabOrd.Name = "tabOrd";
            this.tabOrd.SelectedIndex = 0;
            this.tabOrd.SelectedTab = this.tabPage1;
            this.tabOrd.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.tabOrd.SelectionChanged += new System.EventHandler(this.xTabControl1_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdDetail);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            // 
            // grdDetail
            // 
            this.grdDetail.ApplyPaintEventToAllColumn = true;
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell12,
            this.xEditGridCell19,
            this.xEditGridCell11,
            this.xEditGridCell37,
            this.xEditGridCell14,
            this.xEditGridCell17,
            this.xEditGridCell60,
            this.xEditGridCell16,
            this.xEditGridCell15,
            this.xEditGridCell4,
            this.xEditGridCell13,
            this.xEditGridCell18,
            this.xEditGridCell20});
            this.grdDetail.ColPerLine = 11;
            this.grdDetail.ColResizable = true;
            this.grdDetail.Cols = 12;
            this.grdDetail.ControlBinding = true;
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(41);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.QuerySQL = resources.GetString("grdDetail.QuerySQL");
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            this.grdDetail.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdDetail_QueryEnd);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.ApplyPaintingEvent = true;
            this.xEditGridCell8.CellName = "mix_group";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 25;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell12.ApplyPaintingEvent = true;
            this.xEditGridCell12.CellName = "hangmog_name";
            this.xEditGridCell12.CellWidth = 218;
            this.xEditGridCell12.Col = 3;
            this.xEditGridCell12.DisplayMemoText = true;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell19.ApplyPaintingEvent = true;
            this.xEditGridCell19.CellName = "tonggye_code";
            this.xEditGridCell19.CellWidth = 105;
            this.xEditGridCell19.Col = 8;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell11.ApplyPaintingEvent = true;
            this.xEditGridCell11.CellName = "hangmog_code";
            this.xEditGridCell11.CellWidth = 75;
            this.xEditGridCell11.Col = 2;
            this.xEditGridCell11.EnableSort = true;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell37.ApplyPaintingEvent = true;
            this.xEditGridCell37.CellName = "reser_date";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell37.CellWidth = 75;
            this.xEditGridCell37.Col = 11;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell37.EnableSort = true;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell14.ApplyPaintingEvent = true;
            this.xEditGridCell14.CellName = "ord_danui";
            this.xEditGridCell14.CellWidth = 50;
            this.xEditGridCell14.Col = 7;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell17.ApplyPaintingEvent = true;
            this.xEditGridCell17.CellName = "bogyong_code";
            this.xEditGridCell17.CellWidth = 35;
            this.xEditGridCell17.Col = 9;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell60.ApplyPaintingEvent = true;
            this.xEditGridCell60.CellName = "suryang";
            this.xEditGridCell60.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell60.CellWidth = 40;
            this.xEditGridCell60.Col = 4;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell16.ApplyPaintingEvent = true;
            this.xEditGridCell16.CellName = "dv";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.CellWidth = 25;
            this.xEditGridCell16.Col = 6;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.ApplyPaintingEvent = true;
            this.xEditGridCell15.CellName = "dv_time";
            this.xEditGridCell15.CellWidth = 25;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "jusa_spd_gubun";
            this.xEditGridCell4.CellWidth = 43;
            this.xEditGridCell4.Col = 10;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "group_ser";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "input_gubun";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "hope_date";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // grdMaster
            // 
            this.grdMaster.ApplyPaintEventToAllColumn = true;
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell3,
            this.xEditGridCell7,
            this.xEditGridCell10,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108});
            this.grdMaster.ColPerLine = 7;
            this.grdMaster.Cols = 8;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(41);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMaster_GridCellPainting);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "reser_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.SuppressRepeating = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "drg_bunho";
            this.xEditGridCell6.CellWidth = 47;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "doctor";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "doctor_name";
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "chk";
            this.xEditGridCell7.CellWidth = 25;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jubsu_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = 7;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "gwa";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.ExecuteQuery = null;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "naewon_type";
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "order_date";
            this.xEditGridCell108.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlOrder);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // pnlOrder
            // 
            this.pnlOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pnlOrder.Controls.Add(this.grdOrderInfo);
            resources.ApplyResources(this.pnlOrder, "pnlOrder");
            this.pnlOrder.Name = "pnlOrder";
            // 
            // grdOrderInfo
            // 
            this.grdOrderInfo.AddedHeaderLine = 1;
            this.grdOrderInfo.ApplyPaintEventToAllColumn = true;
            this.grdOrderInfo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell102,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell134,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell135,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell136,
            this.xEditGridCell31,
            this.xEditGridCell137,
            this.xEditGridCell32,
            this.xEditGridCell153,
            this.xEditGridCell154,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell157,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell140,
            this.xEditGridCell141,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell158,
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
            this.xEditGridCell131,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell159,
            this.xEditGridCell139,
            this.xEditGridCell94,
            this.xEditGridCell73,
            this.xEditGridCell152,
            this.xEditGridCell74,
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
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell128,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell132,
            this.xEditGridCell150,
            this.xEditGridCell143,
            this.xEditGridCell144,
            this.xEditGridCell162,
            this.xEditGridCell163,
            this.xEditGridCell138,
            this.xEditGridCell133});
            this.grdOrderInfo.ColPerLine = 25;
            this.grdOrderInfo.ColResizable = true;
            this.grdOrderInfo.Cols = 26;
            this.grdOrderInfo.ControlBinding = true;
            resources.ApplyResources(this.grdOrderInfo, "grdOrderInfo");
            this.grdOrderInfo.EnableMultiSelection = true;
            this.grdOrderInfo.ExecuteQuery = null;
            this.grdOrderInfo.FixedCols = 1;
            this.grdOrderInfo.FixedRows = 2;
            this.grdOrderInfo.HeaderHeights.Add(30);
            this.grdOrderInfo.HeaderHeights.Add(0);
            this.grdOrderInfo.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOrderInfo.Name = "grdOrderInfo";
            this.grdOrderInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderInfo.ParamList")));
            this.grdOrderInfo.QuerySQL = resources.GetString("grdOrderInfo.QuerySQL");
            this.grdOrderInfo.ReadOnly = true;
            this.grdOrderInfo.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOrderInfo.RowHeaderVisible = true;
            this.grdOrderInfo.Rows = 3;
            this.grdOrderInfo.RowStateCheckOnPaint = false;
            this.grdOrderInfo.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrderInfo.ToolTipActive = true;
            this.grdOrderInfo.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrderInfo_GridCellPainting);
            this.grdOrderInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderInfo_QueryStarting);
            this.grdOrderInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOrderInfo_QueryEnd);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellName = "input_gubun_name";
            this.xEditGridCell21.CellWidth = 77;
            this.xEditGridCell21.Col = 17;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell21.SuppressRepeating = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.CellName = "group_ser";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell22.CellWidth = 19;
            this.xEditGridCell22.Col = 2;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.CellName = "order_gubun_name";
            this.xEditGridCell102.CellWidth = 73;
            this.xEditGridCell102.Col = 16;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell102.SuppressRepeating = true;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.CellName = "hangmog_code";
            this.xEditGridCell23.CellWidth = 81;
            this.xEditGridCell23.Col = 4;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellName = "hangmog_name";
            this.xEditGridCell24.CellWidth = 191;
            this.xEditGridCell24.Col = 5;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.RowSpan = 2;
            this.xEditGridCell24.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "specimen_code";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsReadOnly = true;
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellName = "specimen_name";
            this.xEditGridCell25.CellWidth = 33;
            this.xEditGridCell25.Col = 20;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.RowSpan = 2;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellName = "suryang";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell26.CellWidth = 46;
            this.xEditGridCell26.Col = 6;
            this.xEditGridCell26.DecimalDigits = 3;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.RowSpan = 2;
            this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "ord_danui";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellName = "ord_danui_name";
            this.xEditGridCell27.CellWidth = 76;
            this.xEditGridCell27.Col = 7;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellName = "dv_time";
            this.xEditGridCell28.CellWidth = 21;
            this.xEditGridCell28.Col = 9;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.Row = 1;
            this.xEditGridCell28.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell28.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.CellName = "dv";
            this.xEditGridCell29.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell29.CellWidth = 30;
            this.xEditGridCell29.Col = 10;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.Row = 1;
            this.xEditGridCell29.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellName = "nalsu";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell30.CellWidth = 42;
            this.xEditGridCell30.Col = 11;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "jusa";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsReadOnly = true;
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell31.CellName = "jusa_name";
            this.xEditGridCell31.CellWidth = 34;
            this.xEditGridCell31.Col = 12;
            this.xEditGridCell31.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.RowSpan = 2;
            this.xEditGridCell31.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell31.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "bogyong_code";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsReadOnly = true;
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellName = "bogyong_name";
            this.xEditGridCell32.CellWidth = 75;
            this.xEditGridCell32.Col = 13;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "jusa_spd_gubun";
            this.xEditGridCell153.CellWidth = 40;
            this.xEditGridCell153.Col = -1;
            this.xEditGridCell153.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell153, "xEditGridCell153");
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellName = "hubal_change_yn";
            this.xEditGridCell154.CellWidth = 29;
            this.xEditGridCell154.Col = -1;
            this.xEditGridCell154.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell154, "xEditGridCell154");
            this.xEditGridCell154.IsVisible = false;
            this.xEditGridCell154.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "pharmacy";
            this.xEditGridCell155.CellWidth = 18;
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell155, "xEditGridCell155");
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "drg_pack_yn";
            this.xEditGridCell156.CellWidth = 16;
            this.xEditGridCell156.Col = -1;
            this.xEditGridCell156.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell156, "xEditGridCell156");
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "powder_yn";
            this.xEditGridCell157.CellWidth = 17;
            this.xEditGridCell157.Col = -1;
            this.xEditGridCell157.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell157, "xEditGridCell157");
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellName = "wonyoi_order_yn";
            this.xEditGridCell33.CellWidth = 24;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.CellName = "wonnae_sayu_code";
            this.xEditGridCell34.CellWidth = 61;
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            this.xEditGridCell34.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell140.CellWidth = 30;
            this.xEditGridCell140.Col = 21;
            this.xEditGridCell140.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell140.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsReadOnly = true;
            this.xEditGridCell140.IsUpdatable = false;
            this.xEditGridCell140.RowSpan = 2;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell141.CellWidth = 39;
            this.xEditGridCell141.Col = 22;
            this.xEditGridCell141.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsReadOnly = true;
            this.xEditGridCell141.IsUpdatable = false;
            this.xEditGridCell141.RowSpan = 2;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell35.CellName = "emergency";
            this.xEditGridCell35.CellWidth = 23;
            this.xEditGridCell35.Col = 8;
            this.xEditGridCell35.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.RowSpan = 2;
            this.xEditGridCell35.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell35.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.CellName = "pay";
            this.xEditGridCell36.CellWidth = 35;
            this.xEditGridCell36.Col = 24;
            this.xEditGridCell36.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.RowSpan = 2;
            this.xEditGridCell36.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.CellName = "fluid_yn";
            this.xEditGridCell38.CellWidth = 32;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell39.CellName = "tpn_yn";
            this.xEditGridCell39.CellWidth = 33;
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdatable = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell39.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell40.CellName = "anti_cancer_yn";
            this.xEditGridCell40.CellWidth = 45;
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdatable = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell40.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "muhyo";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell42.CellName = "portable_yn";
            this.xEditGridCell42.CellWidth = 24;
            this.xEditGridCell42.Col = 23;
            this.xEditGridCell42.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell42.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "symya";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "ocs_flag";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "order_gubun";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellName = "input_tab";
            this.xEditGridCell158.Col = -1;
            this.xEditGridCell158.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell158, "xEditGridCell158");
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "input_gubun";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "after_act_yn";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "jundal_table";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "jundal_part";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "move_part";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "bunho";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "naewon_date";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "gwa";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "doctor";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "naewon_type";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "jubsu_no";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "pk_order";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "seq";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "pkocs1003";
            this.xEditGridCell58.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "sub_susul";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "sutak_yn";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "sang_code";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "symya_time";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "amt";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "nalsu_sayu_code";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "physical_code";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "nday_nalsu";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "nday_sunab";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "dv_1";
            this.xEditGridCell69.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "dv_2";
            this.xEditGridCell70.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "dv_3";
            this.xEditGridCell71.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "dv_4";
            this.xEditGridCell72.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellName = "dv_5";
            this.xEditGridCell159.Col = -1;
            this.xEditGridCell159.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell159, "xEditGridCell159");
            this.xEditGridCell159.IsVisible = false;
            this.xEditGridCell159.Row = -1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.CellName = "hope_date";
            this.xEditGridCell139.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell139.CellWidth = 103;
            this.xEditGridCell139.Col = 3;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
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
            this.xEditGridCell94.CellWidth = 72;
            this.xEditGridCell94.Col = 14;
            this.xEditGridCell94.DisplayMemoText = true;
            this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.RowSpan = 2;
            this.xEditGridCell94.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "mix_group";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "regular_yn";
            this.xEditGridCell152.CellWidth = 19;
            this.xEditGridCell152.Col = 18;
            this.xEditGridCell152.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell152.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell152, "xEditGridCell152");
            this.xEditGridCell152.RowSpan = 2;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell74.CellName = "reser_date";
            this.xEditGridCell74.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell74.CellWidth = 16;
            this.xEditGridCell74.Col = 25;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsUpdatable = false;
            this.xEditGridCell74.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell74.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "jubsu_date";
            this.xEditGridCell95.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsUpdatable = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "acting_date";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsUpdatable = false;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "result_date";
            this.xEditGridCell97.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsUpdatable = false;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell142.CellName = "dc_gubun";
            this.xEditGridCell142.CellWidth = 30;
            this.xEditGridCell142.Col = 19;
            this.xEditGridCell142.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell142.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsUpdatable = false;
            this.xEditGridCell142.RowSpan = 2;
            this.xEditGridCell142.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell142.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "dc_yn";
            this.xEditGridCell145.Col = -1;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.IsVisible = false;
            this.xEditGridCell145.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "bannab_yn";
            this.xEditGridCell146.Col = -1;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.IsVisible = false;
            this.xEditGridCell146.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "donbog_yn";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell160, "xEditGridCell160");
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellName = "dv_name";
            this.xEditGridCell161.Col = -1;
            this.xEditGridCell161.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell161, "xEditGridCell161");
            this.xEditGridCell161.IsVisible = false;
            this.xEditGridCell161.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "confirm_check";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "sunab_check";
            this.xEditGridCell147.Col = -1;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.IsVisible = false;
            this.xEditGridCell147.Row = -1;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "dc_check";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsUpdatable = false;
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "slip_code";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "group_yn";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "sg_code";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "order_gubun_bas";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "input_control";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "pris_name";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "kyukyeok";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "suga_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "emergency_check";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "multi_gumsa_yn";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "special_check";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "limit_suryang";
            this.xEditGridCell86.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "specimen_yn";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "jaeryo_yn";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "ord_danui_check";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "ord_danui_bas";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "jundal_table_out";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "jundal_part_out";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "portable_cr_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "bulyong_check";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "default_wonnae_sayu_code";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "special_code";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "nday_yn";
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "muhyo_yn";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "tel_yn";
            this.xEditGridCell132.Col = -1;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell150.CellName = "jundal_part_name";
            this.xEditGridCell150.Col = 1;
            this.xEditGridCell150.ExecuteQuery = null;
            this.xEditGridCell150.HeaderForeColor = IHIS.Framework.XColor.XCalendarFullHolidayTextColor;
            resources.ApplyResources(this.xEditGridCell150, "xEditGridCell150");
            this.xEditGridCell150.IsUpdatable = false;
            this.xEditGridCell150.RowSpan = 2;
            this.xEditGridCell150.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell150.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "bun_code";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "sg_gesan";
            this.xEditGridCell144.Col = -1;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsVisible = false;
            this.xEditGridCell144.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "drg_info";
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell162, "xEditGridCell162");
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellName = "drg_bunryu";
            this.xEditGridCell163.Col = -1;
            this.xEditGridCell163.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell163, "xEditGridCell163");
            this.xEditGridCell163.IsVisible = false;
            this.xEditGridCell163.Row = -1;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "data_control";
            this.xEditGridCell138.Col = -1;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsVisible = false;
            this.xEditGridCell138.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell133.CellName = "tel_display";
            this.xEditGridCell133.CellWidth = 28;
            this.xEditGridCell133.Col = 15;
            this.xEditGridCell133.ExecuteQuery = null;
            this.xEditGridCell133.IsUpdatable = false;
            this.xEditGridCell133.RowSpan = 2;
            this.xEditGridCell133.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 9;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 21;
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.grdMaster);
            this.xPanel4.Controls.Add(this.splitter1);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xButton1);
            this.xPanel3.Controls.Add(this.btnCommentForm);
            this.xPanel3.Controls.Add(this.btnAllUnCheck);
            this.xPanel3.Controls.Add(this.btnAllCheck);
            this.xPanel3.Controls.Add(this.btnOrderList);
            this.xPanel3.Controls.Add(this.btnPrint);
            this.xPanel3.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // xButton1
            // 
            this.xButton1.ImageIndex = 0;
            this.xButton1.ImageList = this.ImageList;
            resources.ApplyResources(this.xButton1, "xButton1");
            this.xButton1.Name = "xButton1";
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // btnCommentForm
            // 
            this.btnCommentForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            resources.ApplyResources(this.btnCommentForm, "btnCommentForm");
            this.btnCommentForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCommentForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCommentForm.Image")));
            this.btnCommentForm.Name = "btnCommentForm";
            // 
            // btnAllUnCheck
            // 
            this.btnAllUnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllUnCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllUnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllUnCheck.Image")));
            resources.ApplyResources(this.btnAllUnCheck, "btnAllUnCheck");
            this.btnAllUnCheck.Name = "btnAllUnCheck";
            this.btnAllUnCheck.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnAllUnCheck.Click += new System.EventHandler(this.btnAllUnCheck_Click);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllCheck.Image")));
            resources.ApplyResources(this.btnAllCheck, "btnAllCheck");
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // btnOrderList
            // 
            this.btnOrderList.ImageIndex = 0;
            this.btnOrderList.ImageList = this.ImageList;
            resources.ApplyResources(this.btnOrderList, "btnOrderList");
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.ImageList = this.ImageList;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // layOrder
            // 
            this.layOrder.ExecuteQuery = null;
            this.layOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
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
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26});
            this.layOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrder.ParamList")));
            this.layOrder.QuerySQL = resources.GetString("layOrder.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "gwa_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "doctor_name";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "suname2";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "age";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "sex";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "birth";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "drg_bunho";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "rp_bunho";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "jubsu_date";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "jusa_gubun";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "jusa_spd_gubun";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "ord_surang";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "ord_danui";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "dv_time";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "dv";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "bogyong_code";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "subul_surang";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "subul_danui";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "jaeryo_name";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "nalsu_cnt";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "order_remark";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "jaeryo_code";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "hope_date";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "pkinj1001";
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "");
            this.imageListMixGroup.Images.SetKeyName(1, "");
            this.imageListMixGroup.Images.SetKeyName(2, "");
            this.imageListMixGroup.Images.SetKeyName(3, "");
            this.imageListMixGroup.Images.SetKeyName(4, "");
            this.imageListMixGroup.Images.SetKeyName(5, "");
            this.imageListMixGroup.Images.SetKeyName(6, "");
            this.imageListMixGroup.Images.SetKeyName(7, "");
            this.imageListMixGroup.Images.SetKeyName(8, "");
            this.imageListMixGroup.Images.SetKeyName(9, "");
            this.imageListMixGroup.Images.SetKeyName(10, "");
            this.imageListMixGroup.Images.SetKeyName(11, "");
            this.imageListMixGroup.Images.SetKeyName(12, "");
            this.imageListMixGroup.Images.SetKeyName(13, "");
            this.imageListMixGroup.Images.SetKeyName(14, "");
            this.imageListMixGroup.Images.SetKeyName(15, "");
            this.imageListMixGroup.Images.SetKeyName(16, "");
            this.imageListMixGroup.Images.SetKeyName(17, "");
            this.imageListMixGroup.Images.SetKeyName(18, "");
            this.imageListMixGroup.Images.SetKeyName(19, "");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            // 
            // layOrderJungbo
            // 
            this.layOrderJungbo.ExecuteQuery = null;
            this.layOrderJungbo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42});
            this.layOrderJungbo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderJungbo.ParamList")));
            this.layOrderJungbo.QuerySQL = resources.GetString("layOrderJungbo.QuerySQL");
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "text_1";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "text_2";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "text_3";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "comments";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "bunho_comments";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "bar_drg_bunho";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "bar_rp_bunho";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "cpl_1";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "cpl_2";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "cpl_3";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "danui_1";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "danui_2";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "danui_3";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "hl_1";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "hl_2";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "hl_3";
            // 
            // DRG2010Q99
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "DRG2010Q99";
            resources.ApplyResources(this, "$this");
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.tabOrd.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderInfo)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		[Browsable(false), DataBindable]
		public string Order_gubun
		{
			get {return "2";}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);			
			
			dtpFromDate.SetDataValue(DateTime.Today);
			dtpToDate.SetDataValue(DateTime.Today);

            if (!grdMaster.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        #region [ Common Properties ]
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region
        private void PaList()
		{
            grdMaster.SetBindVarValue("f_anti_yn", cbxAntiYn.GetDataValue());
            if (!grdMaster.QueryLayout(false)) { XMessageBox.Show(Service.ErrFullMsg); return; }
		}
		#endregion

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					PaList();
					break;
				default:
					break;
			}		
		}

		private void dtpFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (!grdMaster.QueryLayout(false)) { XMessageBox.Show(Service.ErrFullMsg); return; }
		}

		private void dtpToDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (!grdMaster.QueryLayout(false)) { XMessageBox.Show(Service.ErrFullMsg); return; }
		}

		private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            if (!grdMaster.QueryLayout(false)) { XMessageBox.Show(Service.ErrFullMsg); return; }
		}

		private void btnOrderList_Click(object sender, System.EventArgs e)
		{
			if (grdMaster.RowCount < 0) return;

			for (int i=0; i<grdMaster.RowCount; i++)
			{
                ArrayList inputList  = new ArrayList();
                ArrayList outputList = new ArrayList();
                inputList.Add(grdMaster.GetItemString(i, "reser_date"));
                inputList.Add(grdMaster.GetItemString(i, "bunho"));
                inputList.Add(grdMaster.GetItemString(i, "doctor"));
                inputList.Add(TypeCheck.NVL(grdMaster.GetItemString(i, "drg_bunho"), 99999));
                inputList.Add(grdMaster.GetItemString(i, "chk"));
                inputList.Add(mHospCode);
				
				// 출력
				if ((grdMaster.GetItemString(i, "drg_bunho") == "") && (grdMaster.GetItemString(i, "chk") == "Y"))
				{
					if (Service.ExecuteProcedure("PR_INJ_MAKE_PRINT", inputList, outputList))
					{					
						grdMaster.SetItemValue(i,"drg_bunho" , outputList[0].ToString());
						grdMaster.SetItemValue(i,"jubsu_date", EnvironInfo.GetSysDate());
						grdMaster.AcceptData();

						DrgPrint(i);
					}
					else
						MessageBox.Show(Service.ErrMsg);
				}

				// 출력 취소
				if ((grdMaster.GetItemString(i, "drg_bunho") != "") && (grdMaster.GetItemString(i, "chk") == "N"))
				{
                    if (!Service.ExecuteProcedure("PR_INJ_MAKE_PRINT", inputList, outputList))
						MessageBox.Show(Service.ErrMsg);
				}
			}

			// 마감후 조회
			PaList();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{			
			int row = grdMaster.CurrentRowNumber;

			DrgPrint(row);
		}

		private void btnAllCheck_Click(object sender, System.EventArgs e)
		{
			for(int i=0; i<grdMaster.RowCount; i++)
			{
				grdMaster.SetItemValue(i, "chk", "Y");
			}
			grdMaster.AcceptData();
		}

		private void btnAllUnCheck_Click(object sender, System.EventArgs e)
		{
			for(int i=0; i<grdMaster.RowCount; i++)
			{
				grdMaster.SetItemValue(i, "chk", "N");
			}
			grdMaster.AcceptData();
		}

		private void dwSet(string childName ,int i, string order_remark)
		{
			string msg = "";

			//지정한 ChildName을 가진 DataWindowChild가 존재하는 여부 Check
			Sybase.DataWindow.DataWindowChild dwChild = null;
			try
			{
	//			dwChild = dw_1.GetChild(childName);
				dwChild.SetItemString(i, "order_remark", order_remark);
				//dwChild.Modify("t_order_remark.text  = '"+  order_remark  +"'");
			}
			catch(Exception e)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "FillChildData 에러[" + e.Message + "]"
					: "FillChildData エラー[" + e.Message + "]");
				//https://sofiamedix.atlassian.net/browse/MED-10610
				//MessageBox.Show(msg);
				
			}
		}


		private void DrgPrint(int row)
		{
			int dataRow;
			string order_remark = string.Empty;
			string rp_bunho = string.Empty;

	//		dw_1.Reset();
			layOrder.Reset();
			layOrderJungbo.Reset();

			// Order
            layOrder.SetBindVarValue("f_bunho",      grdMaster.GetItemString(row, "bunho"));
            layOrder.SetBindVarValue("f_jubsu_date", grdMaster.GetItemString(row, "jubsu_date"));
            layOrder.SetBindVarValue("f_drg_bunho",  grdMaster.GetItemString(row, "drg_bunho"));
            layOrder.SetBindVarValue("f_hosp_code",  mHospCode);
            if (layOrder.QueryLayout(false))
            {
     //           dw_1.FillChildData("dw_1", layOrder.LayoutTable);

                for (int i = 0; i < layOrder.RowCount; i++)
                {
                    if (layOrder.GetItemString(i, "rp_bunho") != rp_bunho)
                    {
                        order_remark = string.Empty;
                    }

                    if (layOrder.GetItemString(i, "order_remark") != "")
                    {
                        order_remark = order_remark + layOrder.GetItemString(i, "jaeryo_name") + " : " + layOrder.GetItemString(i, "order_remark") + "\n";
                    }

                    dwSet("dw_1", i + 1, order_remark);
                    rp_bunho = layOrder.GetItemString(i, "rp_bunho");
                }

            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }

			// Connent
			layOrderJungbo.SetBindVarValue("f_jubsu_date", grdMaster.GetItemString(row, "jubsu_date"));
            layOrderJungbo.SetBindVarValue("f_bunho",      grdMaster.GetItemString(row, "bunho"));
            layOrderJungbo.SetBindVarValue("f_drg_bunho",  grdMaster.GetItemString(row, "drg_bunho"));
            layOrderJungbo.SetBindVarValue("f_hosp_code",  mHospCode);
            if (layOrderJungbo.QueryLayout(false))
            {
    //            dw_1.FillChildData("dw_2", layOrderJungbo.LayoutTable);
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }

			if (layOrderJungbo.RowCount < 1)
			{
                dataRow = layOrderJungbo.InsertRow(0);
                layOrderJungbo.SetItemValue(dataRow, "bar_drg_bunho", grdMaster.GetItemString(row, "bunho"));
	//			dw_1.FillChildData("dw_2", layOrderJungbo.LayoutTable);
			}

	//		dw_1.AcceptText();

            //if (dw_1.RowCount > 0)	
            //{
            //    dw_1.Print();

				LablePrint(row);
	//		}
		}

		private void dtpFromDate_DataValidating_1(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			PaList();
		}

		private void dtpToDate_DataValidating_1(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			PaList();
		}

		private void cbxAntiYn_CheckedChanged(object sender, System.EventArgs e)
		{
			PaList();
		}

		private void grdMaster_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if ((grdMaster.GetItemString(e.RowNumber, "chk") == "Y") && ((grdMaster.GetItemString(e.RowNumber, "drg_bunho") != "")))
			{
				e.BackColor	= Color.Khaki;
			}
        }

        private void grdDetail_QueryEnd(object sender, QueryEndEventArgs e)
        {
            DiaplayMixGroup(grdDetail);
        }

		#region Mix Group 데이타 Image Display (DiaplayMixGroup)
		/// <summary>
		/// Mix Group 데이타 Image Display
		/// </summary>
		/// <param name="aGrd"> XEditGrid </param>
		/// <returns> void  </returns>
		private void DiaplayMixGroup(XEditGrid aGrd)
		{
			if (aGrd == null) return;

			try
			{
				int imageCnt = 0;

				// 기존 image 클리어
				for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

				for (int i = 0; i < aGrd.RowCount; i++)
				{
					// 이미 이미지 세팅이 안된건에 한해서 작업수행
					if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
					{
						//이미수행한건 빼는로직이 있어야함..
						int count = 0;
						for (int j = i; j < aGrd.RowCount; j++)
						{
							// 동일 group_ser, 동일 mix_group
							if (aGrd.GetItemValue(i, "input_gubun").ToString().Trim() == aGrd.GetItemValue(j, "input_gubun").ToString().Trim() &&
								aGrd.GetItemValue(i, "group_ser"  ).ToString().Trim() == aGrd.GetItemValue(j, "group_ser"  ).ToString().Trim() &&
								aGrd.GetItemValue(i, "mix_group"  ).ToString().Trim() == aGrd.GetItemValue(j, "mix_group"  ).ToString().Trim() &&
								aGrd.GetItemValue(i, "hope_date"  ).ToString().Trim() == aGrd.GetItemValue(j, "hope_date"  ).ToString().Trim())
							{
								count++;
								if (count > 1)
								{
									//      헤더를 빼야 실제 Row
									aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
									aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
								}
							}
						}
						// 현재는 image 갯수만큼 처리
						imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
					}
				}
			}
			finally
			{
				//aGrd.Redraw = true; // Grid Display 
			}

		}
		#endregion

		private void xTabControl1_SelectionChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grdMaster_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (tabOrd.SelectedIndex == 0 )
			{
                if (!grdOrderInfo.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
			}


		}

		private void grdOrderInfo_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			ColumnColorForOrderState("O", grdOrderInfo, e); // 처방상태에 따른 색상 처리
		}

		#region 처방상태에 따른 각 필드 색상 표현 (ColumnColorForOrderState)
		/// <summary>
		/// 처방상태에 따른 각 필드 색상 표현
		/// </summary>
		/// <param name="aIOEGubun"> string 외래입원응급구분 </param>
		/// <param name="aGrd"> XGrid Grid </param>
		/// <param name="aRow"> int Row </param>
		/// <returns> void </returns>
		public void ColumnColorForOrderState(string aIOEGubun, XGrid aGrd, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (aGrd == null || e.RowNumber < 0) return;

			// 항목코드와 항목명의 색상의 변화
			// 항목명
			// 수납된경우(외래),간호확인(입원) :: 항목명의 바탕색이 하늘색으로 변함
			// 항목코드
			// Acting 된경우 (OCS_FLAG = '3')  :: 항목 글자색이 파랑색 , 항목 바탕색이 하늘색
			// 결과 입력된경우 (ResultDate)    :: 항목 글자색이 보라색 , 항목 바탕색이 하늘색
			// RESER 된경우 (OCS_FLAG = '2' )  :: 항목 글자색이 녹색
			// OCS_FLAG '0'이 아닌 경우 전달이 된경우는 글자 두께를 두껍게한다 
			// 그 외는 기본색 (글자색은 검정, 바탕색은 흰색)
			
			if (aGrd.GetRowState(e.RowNumber) != DataRowState.Added)
			{
				switch (e.ColName)
				{
					case "order_gubun_name": // 처방구분명은 입력하는 필드가 아님..
						break;
					case "hangmog_code": // 항목코드
						if      (!TypeCheck.IsNull(aGrd.LayoutTable.Rows[e.RowNumber]["result_date"])) // 결과입력된 경우
						{
							e.ForeColor = Color.DeepPink;  // 보라색
							e.BackColor = Color.SkyBlue; // 하늘색
						}
						else if (aGrd.LayoutTable.Rows[e.RowNumber]["ocs_flag"].ToString().Trim() == "3") // Acting인 경우
						{
							e.ForeColor = Color.Blue;    // 파랑색
							e.BackColor = Color.SkyBlue; // 하늘색
						}
						else if (aGrd.LayoutTable.Rows[e.RowNumber]["ocs_flag"].ToString().Trim() == "2") // 예약인 경우
						{
							e.ForeColor = Color.Green;   // 녹색
						}
								
						// 입원이 아닌 경우는 수납체크함
						if (aGrd.LayoutTable.Rows[e.RowNumber]["ocs_flag"].ToString().Trim() == "0" && 
							((aIOEGubun != "I" && aGrd.LayoutTable.Rows[e.RowNumber]["sunab_check"].ToString().Trim() == "N") ||
							(aIOEGubun == "I" && true)) &&
							aGrd.LayoutTable.Rows[e.RowNumber]["dc_check"].ToString().Trim() == "N") // 전달이 아닌경우
						{

						}
						else
						{
							e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, IHIS.Framework.XEditGrid.DefaultFont.Size, FontStyle.Bold);
						}

						break;

					case "hangmog_name": // 항목코드
						// BackColor 지정
						// 입원이 아닌 경우 수납이 된 경우, 입원이면서 간호확인 된 경우
						if ((aIOEGubun != "I" && aGrd.LayoutTable.Rows[e.RowNumber]["sunab_check"].ToString().Trim() == "Y") ||
							(aIOEGubun == "I" && aGrd.LayoutTable.Rows[e.RowNumber]["confirm_check"].ToString().Trim() == "Y")) 
						{
							e.BackColor = Color.SkyBlue; // 하늘색
						}

						break;
				}
			}

			// Dc/반납 데이타 ForeColor = Rad 색상 표시 , Dc 원데이타는 항목과 항목명망 중간에 빨강색 라인표시
			if (!TypeCheck.IsNull(aGrd.LayoutTable.Rows[e.RowNumber]["nalsu"]) && 
				int.Parse(TypeCheck.NVL(aGrd.LayoutTable.Rows[e.RowNumber]["nalsu"], 0).ToString()) < 0)
			{
				e.ForeColor= Color.Red;
			}
			else if (aGrd.LayoutTable.Rows[e.RowNumber]["dc_yn"].ToString().Trim() == "Y")
			{
				switch (e.ColName)
				{
					case "hangmog_code": case "hangmog_name": // 항목코드
						e.DrawMiddleLine  = true;
						e.MiddleLineColor = Color.Red;
						break;
				}				
			}
		}
		#endregion

        private void grdOrderInfo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            DiaplayMixGroup(grdOrderInfo);
        }

		private void xButton1_Click(object sender, System.EventArgs e)
		{
			LablePrint(grdMaster.CurrentRowNumber);
		}

		private void LablePrint(int row)
		{
            //string print_name = SetPrint(dw_lable, true);
            //string origin_print = SetPrint(dw_lable, false);
            //dw_lable.Reset();
			layOrder.Reset();
			int jaeryo_len, newrow;

			// Order
			layOrder.SetBindVarValue("f_bunho",      grdMaster.GetItemString(row, "bunho"));
            layOrder.SetBindVarValue("f_jubsu_date", grdMaster.GetItemString(row, "jubsu_date"));
            layOrder.SetBindVarValue("f_drg_bunho",  grdMaster.GetItemString(row, "drg_bunho"));

			 
			if (layOrder.QueryLayout(false))
			{

				for (int i = 0; i< layOrder.RowCount; i++)
				{
					jaeryo_len =  layOrder.GetItemString(i,"jaeryo_name").Length;
					if ( jaeryo_len > 29)
					{
						layOrder.SetItemValue( i, "subul_surang"     , ""); 
						layOrder.SetItemValue( i, "subul_danui"      , ""); 

						newrow = i+1;
						layOrder.InsertRow(newrow);
						layOrder.SetItemValue( newrow, "bunho"            , layOrder.GetItemValue(i,"bunho"           )); 
						layOrder.SetItemValue( newrow, "gwa_name"         , layOrder.GetItemValue(i,"gwa_name"        )); 
						layOrder.SetItemValue( newrow, "doctor_name"      , layOrder.GetItemValue(i,"doctor_name"     )); 
						layOrder.SetItemValue( newrow, "suname"           , layOrder.GetItemValue(i,"suname"          )); 
						layOrder.SetItemValue( newrow, "suname2"          , layOrder.GetItemValue(i,"suname2"         )); 
						layOrder.SetItemValue( newrow, "age"              , layOrder.GetItemValue(i,"age"             )); 
						layOrder.SetItemValue( newrow, "sex"              , layOrder.GetItemValue(i,"sex"             )); 
						layOrder.SetItemValue( newrow, "birth"            , layOrder.GetItemValue(i,"birth"           )); 
						layOrder.SetItemValue( newrow, "drg_bunho"        , layOrder.GetItemValue(i,"drg_bunho"       )); 
						layOrder.SetItemValue( newrow, "rp_bunho"         , layOrder.GetItemValue(i,"rp_bunho"        )); 
						layOrder.SetItemValue( newrow, "jubsu_date"       , layOrder.GetItemValue(i,"jubsu_date"      )); 
						layOrder.SetItemValue( newrow, "jusa_gubun"       , layOrder.GetItemValue(i,"jusa_gubun"      )); 
						layOrder.SetItemValue( newrow, "jusa_spd_gubun"   , layOrder.GetItemValue(i,"jusa_spd_gubun"  )); 
						layOrder.SetItemValue( newrow, "ord_surang"       , layOrder.GetItemValue(i,"ord_surang"      )); 
						layOrder.SetItemValue( newrow, "ord_danui"        , layOrder.GetItemValue(i,"ord_danui"       )); 
						layOrder.SetItemValue( newrow, "dv_time"          , layOrder.GetItemValue(i,"dv_time"         )); 
						layOrder.SetItemValue( newrow, "dv"               , layOrder.GetItemValue(i,"dv"              )); 
						layOrder.SetItemValue( newrow, "bogyong_code"     , layOrder.GetItemValue(i,"bogyong_code"    )); 
						layOrder.SetItemValue( newrow, "subul_surang"     , layOrder.GetItemValue(i,"subul_surang"    )); 
						layOrder.SetItemValue( newrow, "subul_danui"      , layOrder.GetItemValue(i,"subul_danui"     )); 
						layOrder.SetItemValue( newrow, "jaeryo_name"      , layOrder.GetItemValue(i,"jaeryo_name"     ).ToString().Substring(30)); 
						layOrder.SetItemValue( newrow, "pkinj1001"        , layOrder.GetItemValue(i,"pkinj1001"       )); 
						layOrder.SetItemValue( newrow, "nalsu_cnt"        , layOrder.GetItemValue(i,"nalsu_cnt"       )); 
						layOrder.SetItemValue( newrow, "order_remark"     , layOrder.GetItemValue(i,"order_remark"    )); 


						layOrder.AcceptData();
					}
				}

//				dw_lable.FillData(layOrder.LayoutTable);
			}
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }

	//		dw_lable.AcceptText();
			try
			{
                //if (print_name != "")
                //    IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name);
			
                //if (dw_lable.RowCount > 0)	dw_lable.Print();

                //// 기본프린터 set
                //if (origin_print != "")
                //    IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
			}
			catch
			{}
		}


		#region SetPrint
		private string SetPrint(XDataWindow dw_print, bool lable_yn)
		{
			string print_name = "";

			if (lable_yn)
			{
				foreach( string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters )
				{
					if ( s == "SATO" )
					{
						print_name = "SATO";
						break;
					}
					else
					{
						if ( s.IndexOf("SATO") >= 0 )
							print_name = s;
					}
				}

				if ( print_name.IndexOf("SATO") < 0 )
				{
					MessageBox.Show("ラベルプリンタの設定がされていません。");
					//dw_print.PrintDialog(true);
				}
			}
			else
			{
				print_name = dw_print.PrintProperties.PrinterName;				
			}

			return print_name;
		}
		#endregion

        #region 각 그리드, 레이아웃에 바인드변수 설정
        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMaster.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            grdMaster.SetBindVarValue("f_to_date",   dtpToDate.GetDataValue());
            grdMaster.SetBindVarValue("f_bunho",     paBox.BunHo);
            grdMaster.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOrderInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrderInfo.SetBindVarValue("f_bunho",         grdMaster.GetItemString(grdMaster.CurrentRowNumber, "bunho"));
            grdOrderInfo.SetBindVarValue("f_naewon_date",   grdMaster.GetItemString(grdMaster.CurrentRowNumber, "order_date"));
            grdOrderInfo.SetBindVarValue("f_gwa",           grdMaster.GetItemString(grdMaster.CurrentRowNumber, "gwa"));
            grdOrderInfo.SetBindVarValue("f_doctor",        grdMaster.GetItemString(grdMaster.CurrentRowNumber, "doctor"));
            grdOrderInfo.SetBindVarValue("f_naewon_type",   grdMaster.GetItemString(grdMaster.CurrentRowNumber, "naewon_type"));
            grdOrderInfo.SetBindVarValue("f_order_gubun",   Order_gubun);
            grdOrderInfo.SetBindVarValue("f_hosp_code",     mHospCode);
            //grdOrderInfo.SetBindVarValue("f_jubsu_no",      grdMaster.GetItemString(grdMaster.CurrentRowNumber, "jubsu_no"));
        }
        #endregion

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDetail.SetBindVarValue("f_reser_date", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "reser_date"));
            grdDetail.SetBindVarValue("f_drg_bunho",  grdMaster.GetItemString(grdMaster.CurrentRowNumber, "drg_bunho"));
            grdDetail.SetBindVarValue("f_bunho",      grdMaster.GetItemString(grdMaster.CurrentRowNumber, "bunho"));
            grdDetail.SetBindVarValue("f_hosp_code",  mHospCode);
        }
    }
}

