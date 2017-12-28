using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.Framework;
using System.ComponentModel.Design;

namespace IHIS.CPLS
{
	/// <summary>
	/// MultiResultView에 대한 요약 설명입니다.
    /// </summary>
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))] 
	public class MultiResultView : System.Windows.Forms.UserControl, ISupportInitialize
	{
		private IHIS.Framework.XDataWindow dwSigeyul;
		private IHIS.Framework.XButton btnNext;
		private IHIS.Framework.XButton btnPre;
		private IHIS.Framework.XFlatRadioButton rbxPartJubsuYN;
		private IHIS.Framework.XFlatRadioButton rbxJubsuYN;
		private IHIS.Framework.XButton btnPrint;
        private IHIS.Framework.MultiLayout laySigeyul;
        private IHIS.Framework.MultiLayout layPreSigeyul;
        private IHIS.Framework.XDataWindow dw_print;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGrid grdSigeyul;
		private IHIS.Framework.SingleLayout layPaInfo;
		private System.Windows.Forms.Label label1;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
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
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
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
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem76;
        private MultiLayoutItem multiLayoutItem77;
        private MultiLayoutItem multiLayoutItem78;
        private MultiLayoutItem multiLayoutItem79;
        private MultiLayoutItem multiLayoutItem80;
        private MultiLayoutItem multiLayoutItem81;
        private MultiLayoutItem multiLayoutItem82;
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        #region ISupportInitialize
        /// <summary>
        /// 초기화가 시작됨을 개체에 알립니다.
        /// </summary>
        void ISupportInitialize.BeginInit()
        {
        }
        /// <summary>
        /// 초기화 종료시 환자번호 BOX 초기화(InitialzePaComment)합니다.
        /// </summary>
        void ISupportInitialize.EndInit()
        {
        }
        #endregion

        #region 생성자(현재는 아무런 작업도 안함 단지 그리기만 할 뿐)
        public MultiResultView()
		{
            try
            {
                // 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
                InitializeComponent();

                this.ModifyDW = new ModifyDWDelegate(MultiLanguageForDW);
            }
            catch/*(Exception x)*/
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(x.StackTrace + "////" + x.Message);
                
            }
			// TODO: InitializeComponent를 호출한 다음 초기화 작업을 추가합니다.
		}
		#endregion

		#region Dispose
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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiResultView));
            this.dwSigeyul = new IHIS.Framework.XDataWindow();
            this.btnNext = new IHIS.Framework.XButton();
            this.btnPre = new IHIS.Framework.XButton();
            this.rbxPartJubsuYN = new IHIS.Framework.XFlatRadioButton();
            this.rbxJubsuYN = new IHIS.Framework.XFlatRadioButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.laySigeyul = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
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
            this.layPreSigeyul = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem76 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem77 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem78 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem79 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem80 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem81 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem82 = new IHIS.Framework.MultiLayoutItem();
            this.dw_print = new IHIS.Framework.XDataWindow();
            this.grdSigeyul = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.layPaInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.laySigeyul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreSigeyul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSigeyul)).BeginInit();
            this.SuspendLayout();
            // 
            // dwSigeyul
            // 
            resources.ApplyResources(this.dwSigeyul, "dwSigeyul");
            this.dwSigeyul.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwSigeyul.DataWindowObject = "d_cpl_lib_sigeyul";
            this.dwSigeyul.LibraryList = "CPLS\\cpls.lib.controls.pbd";
            this.dwSigeyul.Name = "dwSigeyul";
            this.dwSigeyul.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwSigeyul.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwSigeyul_RowFocusChanged);
            this.dwSigeyul.Click += new System.EventHandler(this.dwSigeyul_Click);
            // 
            // btnNext
            // 
            this.btnNext.AccessibleDescription = null;
            this.btnNext.AccessibleName = null;
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.BackgroundImage = null;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Name = "btnNext";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.AccessibleDescription = null;
            this.btnPre.AccessibleName = null;
            resources.ApplyResources(this.btnPre, "btnPre");
            this.btnPre.BackgroundImage = null;
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            this.btnPre.Name = "btnPre";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // rbxPartJubsuYN
            // 
            this.rbxPartJubsuYN.AccessibleDescription = null;
            this.rbxPartJubsuYN.AccessibleName = null;
            resources.ApplyResources(this.rbxPartJubsuYN, "rbxPartJubsuYN");
            this.rbxPartJubsuYN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxPartJubsuYN.BackgroundImage = null;
            this.rbxPartJubsuYN.Checked = true;
            this.rbxPartJubsuYN.Name = "rbxPartJubsuYN";
            this.rbxPartJubsuYN.TabStop = true;
            this.rbxPartJubsuYN.UseVisualStyleBackColor = false;
            // 
            // rbxJubsuYN
            // 
            this.rbxJubsuYN.AccessibleDescription = null;
            this.rbxJubsuYN.AccessibleName = null;
            resources.ApplyResources(this.rbxJubsuYN, "rbxJubsuYN");
            this.rbxJubsuYN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxJubsuYN.BackgroundImage = null;
            this.rbxJubsuYN.Name = "rbxJubsuYN";
            this.rbxJubsuYN.UseVisualStyleBackColor = false;
            this.rbxJubsuYN.CheckedChanged += new System.EventHandler(this.rbxJubsuYN_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleDescription = null;
            this.btnPrint.AccessibleName = null;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.BackgroundImage = null;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // laySigeyul
            // 
            this.laySigeyul.ExecuteQuery = null;
            this.laySigeyul.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
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
            this.multiLayoutItem75});
            this.laySigeyul.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySigeyul.ParamList")));
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "gumsa_name";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "from_standard";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "to_standard";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "result_date1";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "result_1";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "standard_yn_1";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "result_date2";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "result_2";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "standard_yn_2";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "result_date3";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "result_3";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "standard_yn_3";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "result_date4";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "result_4";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "standard_yn_4";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "result_date5";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "result_5";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "standard_yn_5";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "result_date6";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "result_6";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "standard_yn_6";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "result_date7";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "result_7";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "standard_yn_7";
            // 
            // layPreSigeyul
            // 
            this.layPreSigeyul.ExecuteQuery = null;
            this.layPreSigeyul.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem76,
            this.multiLayoutItem77,
            this.multiLayoutItem78,
            this.multiLayoutItem79,
            this.multiLayoutItem80,
            this.multiLayoutItem81,
            this.multiLayoutItem82});
            this.layPreSigeyul.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPreSigeyul.ParamList")));
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "gumsa_name";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "from_standard";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "to_standard";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "result_date1";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "result_1";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "standard_yn_1";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "result_date2";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "result_2";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "standard_yn_2";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "result_date3";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "result_3";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "standard_yn_3";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "result_date4";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "result_4";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "standard_yn_4";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "result_date5";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "result_5";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "standard_yn_5";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "result_date6";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "result_6";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "standard_yn_6";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "result_date7";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "result_7";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "standard_yn_7";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "bunho";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "suname";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "sex";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "age";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "birth";
            // 
            // dw_print
            // 
            resources.ApplyResources(this.dw_print, "dw_print");
            this.dw_print.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dw_print.DataWindowObject = "d_cpl_lib_sigeyul_back";
            this.dw_print.LibraryList = "CPLS\\cpls.lib.controls.pbd";
            this.dw_print.Name = "dw_print";
            // 
            // grdSigeyul
            // 
            resources.ApplyResources(this.grdSigeyul, "grdSigeyul");
            this.grdSigeyul.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdSigeyul.ColPerLine = 6;
            this.grdSigeyul.Cols = 6;
            this.grdSigeyul.ExecuteQuery = null;
            this.grdSigeyul.FixedRows = 1;
            this.grdSigeyul.HeaderHeights.Add(19);
            this.grdSigeyul.Name = "grdSigeyul";
            this.grdSigeyul.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSigeyul.ParamList")));
            this.grdSigeyul.QuerySQL = resources.GetString("grdSigeyul.QuerySQL");
            this.grdSigeyul.Rows = 2;
            this.grdSigeyul.ToolTipActive = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_name";
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gubun";
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "base_date";
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "dummy";
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // layPaInfo
            // 
            this.layPaInfo.ExecuteQuery = null;
            this.layPaInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
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
            this.singleLayoutItem19});
            this.layPaInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPaInfo.ParamList")));
            this.layPaInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPaInfo_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "suname";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "SuName2";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "sex";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "age";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "MonthAge";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "Gubun";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "GubunName";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "birth";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "Tel";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "Tel1";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "TelHP";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "Email";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.DataName = "Zip1";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "Zip2";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.DataName = "Address1";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "Address2";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "InHospital";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Name = "label1";
            // 
            // MultiResultView
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = null;
            this.Controls.Add(this.grdSigeyul);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rbxPartJubsuYN);
            this.Controls.Add(this.rbxJubsuYN);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.dwSigeyul);
            this.Controls.Add(this.dw_print);
            this.Font = null;
            this.Name = "MultiResultView";
            ((System.ComponentModel.ISupportInitialize)(this.laySigeyul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreSigeyul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSigeyul)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Fields
		private int flag = 0;
		private string mBunho = "";
		private string mSuname = "";
		private string mSex = "";
		private string mAge = "";
		private string mBirth = "";
		#endregion
		
		#region Methods

        #region ResetData()
        public void ResetData()
        {
            this.dwSigeyul.Reset();
            dwSigeyul.Reset();
        }
        #endregion 

        #region 초기 쿼리
        private void BaseQuery()
		{
			string bunho = "";
			 
			string base_date = "";
			
			//강제로 매 실행시 base_date값 갱신
			//이유는 데이터가 체인지 되지 않으면 인변수로 넘어가지 않기 때문..
			base_date = EnvironInfo.GetSysDate().AddDays(flag).ToString().Substring(2,2) + "." 
				+ EnvironInfo.GetSysDate().AddDays(flag).ToString().Substring(5,2) + "."
				+ EnvironInfo.GetSysDate().AddDays(flag).ToString().Substring(8,2) + "(24:00)";
				
			for ( int i=0; i < this.grdSigeyul.RowCount; i++ )
			{
                this.grdSigeyul.SetItemValue(i, "gubun", "1");

				this.grdSigeyul.SetItemValue(i,"base_date",base_date);

				bunho = grdSigeyul.GetItemString(i, "bunho");
			}

			mBunho = bunho;
			//환자정보 조회
            layPaInfo.ExecuteQuery = ExecuteQueryLayPaInfo;
			layPaInfo.QueryLayout();

			mSuname = layPaInfo.GetItemValue("suname").ToString();
            mSex = layPaInfo.GetItemValue("sex").ToString();
            mAge = layPaInfo.GetItemValue("age").ToString();
            mBirth = layPaInfo.GetItemValue("birth").ToString();

			SigeyulQry("pre");

			flag++;
		}
		#endregion

		#region SigeyulQry
		private void SigeyulQry(string gubun)
		{
			grdSigeyul.AcceptData();
			dwSigeyul.Reset();
			dw_print.Reset();
			bool QryYN = false;

            // 접수일 기준
            if (rbxJubsuYN.Checked)
                QryYN = GetJubsuSigeyulData();
            // 파트접수일 기준
            if (rbxPartJubsuYN.Checked)
                QryYN = GetPreJubsuSigeyulData();

			if (QryYN)
			{
				//전 조회 버튼인지 이후 조회 버튼인지 구분
				if ( gubun == "pre" )
				{
					layPreSigeyul.Reset();
					for (int i=0; i<this.laySigeyul.RowCount; i++) 
					{
						//이전조회시 결과 일자 뒤집기
                        int rowNum = layPreSigeyul.InsertRow(i);

                        layPreSigeyul.SetItemValue(rowNum, "gumsa_name", laySigeyul.GetItemString(i, "gumsa_name"));
                        layPreSigeyul.SetItemValue(rowNum, "from_standard", laySigeyul.GetItemString(i, "from_standard"));
                        layPreSigeyul.SetItemValue(rowNum, "to_standard", laySigeyul.GetItemString(i, "to_standard"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date1", laySigeyul.GetItemString(i, "result_date7"));
                        layPreSigeyul.SetItemValue(rowNum, "result_1", laySigeyul.GetItemString(i, "result_7"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_1", laySigeyul.GetItemString(i, "standard_yn_7"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date2", laySigeyul.GetItemString(i, "result_date6"));
                        layPreSigeyul.SetItemValue(rowNum, "result_2", laySigeyul.GetItemString(i, "result_6"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_2", laySigeyul.GetItemString(i, "standard_yn_6"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date3", laySigeyul.GetItemString(i, "result_date5"));
                        layPreSigeyul.SetItemValue(rowNum, "result_3", laySigeyul.GetItemString(i, "result_5"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_3", laySigeyul.GetItemString(i, "standard_yn_5"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date4", laySigeyul.GetItemString(i, "result_date4"));
                        layPreSigeyul.SetItemValue(rowNum, "result_4", laySigeyul.GetItemString(i, "result_4"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_4", laySigeyul.GetItemString(i, "standard_yn_4"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date5", laySigeyul.GetItemString(i, "result_date3"));
                        layPreSigeyul.SetItemValue(rowNum, "result_5", laySigeyul.GetItemString(i, "result_3"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_5", laySigeyul.GetItemString(i, "standard_yn_3"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date6", laySigeyul.GetItemString(i, "result_date2"));
                        layPreSigeyul.SetItemValue(rowNum, "result_6", laySigeyul.GetItemString(i, "result_2"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_6", laySigeyul.GetItemString(i, "standard_yn_2"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date7", laySigeyul.GetItemString(i, "result_date1"));
                        layPreSigeyul.SetItemValue(rowNum, "result_7", laySigeyul.GetItemString(i, "result_1"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_7", laySigeyul.GetItemString(i, "standard_yn_1"));

                        layPreSigeyul.SetItemValue(rowNum, "bunho", mBunho);
                        layPreSigeyul.SetItemValue(rowNum, "suname", mSuname);
                        layPreSigeyul.SetItemValue(rowNum, "sex", mSex);
                        layPreSigeyul.SetItemValue(rowNum, "age", mAge);
                        layPreSigeyul.SetItemValue(rowNum, "birth", mBirth);
					}

					//좌측정렬하기
					for ( int j=1; j<=7; j++ )
					{
						if ( layPreSigeyul.GetItemString(0,"result_date1").Length == 0 )
						{
							for ( int k=0; k<this.layPreSigeyul.RowCount; k++ )
							{
								layPreSigeyul.SetItemValue(k,"result_date1",layPreSigeyul.GetItemString(k,"result_date2"));
								layPreSigeyul.SetItemValue(k,"result_1",layPreSigeyul.GetItemString(k,"result_2"));
								layPreSigeyul.SetItemValue(k,"standard_yn_1",layPreSigeyul.GetItemString(k,"standard_yn_2"));
								layPreSigeyul.SetItemValue(k,"result_date2",layPreSigeyul.GetItemString(k,"result_date3"));
								layPreSigeyul.SetItemValue(k,"result_2",layPreSigeyul.GetItemString(k,"result_3"));
								layPreSigeyul.SetItemValue(k,"standard_yn_2",layPreSigeyul.GetItemString(k,"standard_yn_3"));
								layPreSigeyul.SetItemValue(k,"result_date3",layPreSigeyul.GetItemString(k,"result_date4"));
								layPreSigeyul.SetItemValue(k,"result_3",layPreSigeyul.GetItemString(k,"result_4"));
								layPreSigeyul.SetItemValue(k,"standard_yn_3",layPreSigeyul.GetItemString(k,"standard_yn_4"));
								layPreSigeyul.SetItemValue(k,"result_date4",layPreSigeyul.GetItemString(k,"result_date5"));
								layPreSigeyul.SetItemValue(k,"result_4",layPreSigeyul.GetItemString(k,"result_5"));
								layPreSigeyul.SetItemValue(k,"standard_yn_4",layPreSigeyul.GetItemString(k,"standard_yn_5"));
								layPreSigeyul.SetItemValue(k,"result_date5",layPreSigeyul.GetItemString(k,"result_date6"));
								layPreSigeyul.SetItemValue(k,"result_5",layPreSigeyul.GetItemString(k,"result_6"));
								layPreSigeyul.SetItemValue(k,"standard_yn_5",layPreSigeyul.GetItemString(k,"standard_yn_6"));
								layPreSigeyul.SetItemValue(k,"result_date6",layPreSigeyul.GetItemString(k,"result_date7"));
								layPreSigeyul.SetItemValue(k,"result_6",layPreSigeyul.GetItemString(k,"result_7"));
								layPreSigeyul.SetItemValue(k,"standard_yn_6",layPreSigeyul.GetItemString(k,"standard_yn_7"));
								layPreSigeyul.SetItemValue(k,"result_date7","");
								layPreSigeyul.SetItemValue(k,"result_7","");
								layPreSigeyul.SetItemValue(k,"standard_yn_7","");

								layPreSigeyul.SetItemValue(k,"bunho",mBunho);
								layPreSigeyul.SetItemValue(k,"suname",mSuname);
								layPreSigeyul.SetItemValue(k,"sex",mSex);
								layPreSigeyul.SetItemValue(k,"age",mAge);
								layPreSigeyul.SetItemValue(k,"birth",mBirth);
							}
						}
					}
					
					dwSigeyul.FillData(layPreSigeyul.LayoutTable);
					dw_print.FillData(layPreSigeyul.LayoutTable);
				}
				else
				{
					dwSigeyul.FillData(laySigeyul.LayoutTable);
					dw_print.FillData(laySigeyul.LayoutTable);
				}
			}
			dwSigeyul.Refresh();
		}
		#endregion

        #region GetSigeyulData
        private bool GetJubsuSigeyulData()
        {
            this.laySigeyul.Reset();
            // Connect to cloud
            List<MultiResultViewGrdSigeyulInfo> lsGrdSigeyulInfo = CreateListGrdSigeyulItem();
            if (lsGrdSigeyulInfo != null && lsGrdSigeyulInfo.Count > 0)
            {
                MultiResultViewGetJubsuSigeyulArgs args = new MultiResultViewGetJubsuSigeyulArgs();
                args.GrdSigeyulItem = lsGrdSigeyulInfo;
                args.UserId = UserInfo.UserID;
                MultiResultViewLaySigeyulResult result =
                    CloudService.Instance.Submit<MultiResultViewLaySigeyulResult, MultiResultViewGetJubsuSigeyulArgs>(
                        args);
                if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                {
                    List<MultiResultViewLaySigeyulInfo> lstLaySigeyulInfo = result.LaySigeyulInfo;
                    if (lstLaySigeyulInfo == null || lstLaySigeyulInfo.Count < 0)
                    {
                        return false;
                    }

                    for (int i = 0; i < lstLaySigeyulInfo.Count; i++)
                    {
                        int rowNum = this.laySigeyul.InsertRow(i);
                        this.laySigeyul.SetItemValue(rowNum, "gumsa_name", lstLaySigeyulInfo[i].GumsaName);
                        List<MultiResultViewDataForLaySigeyulInfo> lstDataForLaySigeyulInfo = lstLaySigeyulInfo[i].DataInfo;
                        if (lstDataForLaySigeyulInfo != null && lstDataForLaySigeyulInfo.Count > 0)
                        {
                            int tCnt = 0;
                            foreach (MultiResultViewDataForLaySigeyulInfo info in lstDataForLaySigeyulInfo)
                            {
                                tCnt ++;
                                if (tCnt > 7)
                                    break;

                                if (tCnt == Int32.Parse(info.TCnt))
                                {
                                    this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), info.ResultDate);
                                    this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), info.Result);
                                    this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), info.StandardYn);
                                    this.laySigeyul.SetItemValue(rowNum, "from_standard", info.FromStandard);
                                    this.laySigeyul.SetItemValue(rowNum, "to_standard", info.ToStandard);
                                }
                            }
                        }
                    }

                }
            }
            
            // TODO comment use connect to cloud
            /*string o_jubsu_date = "";
            string o_jubsu_time = "";
            string o_jubsu_time2 = "";
            string o_cpl_result = "";
            string o_standard_yn = "";
            string o_hangmog_name = "";
            string o_from_standard = "";
            string o_to_standard = "";

            string t_hangmog_code = "";
            string t_base_date = "";

            string cmdText = "";
            BindVarCollection bc = new BindVarCollection();

            cmdText = @"DELETE CPLTEMP
                         WHERE HOSP_CODE  = :f_hosp_code
                           AND IP_ADDRESS = :q_user_id -- 컬럼명 아이피지만 실데이타는 유저아이디
                           AND JUNDAL_GUBUN = 'XX'";

            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("q_user_id", UserInfo.UserID);

            Service.ExecuteNonQuery(cmdText, bc);

            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {
                cmdText = @"INSERT INTO CPLTEMP 
                                 ( IP_ADDRESS       , JUNDAL_GUBUN
                                 , SEQ_CODE         , HANGMOG_CODE      , HOSP_CODE   )
                            VALUES 
                                 ( :q_user_id       , 'XX'
                                 , TO_CHAR(:i)      , :f_hangmog_code   , :f_hosp_code )";

                bc.Add("i", i.ToString());
                bc.Add("f_hangmog_code", this.grdSigeyul.GetItemString(i, "hangmog_code"));

                Service.ExecuteNonQuery(cmdText, bc);
            }
            
            this.laySigeyul.Reset();
            bc.Clear();

            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {
                int rowNum = this.laySigeyul.InsertRow(i);
                
                t_hangmog_code = this.grdSigeyul.GetItemString(i, "hangmog_code");
                t_base_date = this.grdSigeyul.GetItemString(i, "base_date");

                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("q_user_id", UserInfo.UserID);
                bc.Add("f_bunho", this.grdSigeyul.GetItemString(i, "bunho"));
                bc.Add("f_hangmog_code", t_hangmog_code);
                bc.Add("f_hangmog_name", this.grdSigeyul.GetItemString(i, "hangmog_name"));
                bc.Add("f_base_date", t_base_date);

                this.laySigeyul.SetItemValue(rowNum, "gumsa_name", this.grdSigeyul.GetItemString(i, "hangmog_name"));

                if (this.grdSigeyul.GetItemString(i, "gubun") == "0")
                {
                    /*********** 결과일자 LOAD **********#1#
                    cmdText = @"  SELECT DISTINCT 
                                         TO_CHAR(A.JUBSU_DATE, 'YYYY/MM/DD')   JUBSU_DATE
                                       , SUBSTR(A.JUBSU_TIME,1,3)              JUBSU_TIME
                                       , TO_CHAR(A.JUBSU_DATE,'YY.MM.DD')
                                         ||'('||SUBSTR(A.JUBSU_TIME,1,2)||':'||SUBSTR(A.JUBSU_TIME,3,1)||'0)' JUBSU_TIME2
                                    FROM CPLTEMP C,
                                         CPL3020 B,
                                         CPL2010 A
                                   WHERE A.HOSP_CODE     = :f_hosp_code
                                     AND B.HOSP_CODE     = A.HOSP_CODE
                                     AND C.HOSP_CODE     = A.HOSP_CODE
                                     AND A.BUNHO         = :f_bunho
                                     AND A.RESULT_DATE   IS NOT NULL
                                     AND B.SPECIMEN_SER  = A.SPECIMEN_SER
                                     AND C.IP_ADDRESS    = :q_user_id
                                     AND C.JUNDAL_GUBUN  = 'XX'
                                     AND B.HANGMOG_CODE  = C.HANGMOG_CODE
                                   ORDER BY TO_CHAR(A.JUBSU_DATE, 'YYYY/MM/DD') , SUBSTR(A.JUBSU_TIME,1,3)";


                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                    if (dt.Rows.Count < 1)
                        return false;
                    int tCnt = 0;

                    foreach(DataRow row in dt.Rows)
                    {
                        tCnt++;
                        if (tCnt > 7)
                            break;

                        o_jubsu_date = row["jubsu_date"].ToString();
                        o_jubsu_time = row["jubsu_time"].ToString();
                        o_jubsu_time2 = row["jubsu_time2"].ToString();

                        cmdText = @"  SELECT B.CPL_RESULT       CPL_RESULT
                                            ,B.STANDARD_YN      STANDARD_YN
                                            ,C.GUMSA_NAME       GUMSA_NAME
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('1', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY, A.SEX, A.AGE) FROM_STANDARD
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('2', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY,  A.SEX, A.AGE) TO_STANDARD
                                       
                                        FROM CPL0101 C,
                                             CPL3020 B,
                                             CPL2010 A
                                       WHERE A.HOSP_CODE     = :f_hosp_code
                                         AND B.HOSP_CODE     = A.HOSP_CODE
                                         AND C.HOSP_CODE     = A.HOSP_CODE
                                         AND A.BUNHO         = :f_bunho
                                         AND B.FKCPL2010     = A.PKCPL2010
                                         AND B.HANGMOG_CODE  = :f_hangmog_code
                                         AND A.PART_JUBSU_DATE   = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY ";

                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        if(Service.ErrCode != 0)
                        o_cpl_result = "";
                        o_standard_yn = "";
                        o_hangmog_name = "";  

                        if (!TypeCheck.IsNull(dt2))
                        {
                            o_cpl_result = dt2.Rows[0]["cpl_result"].ToString();
                            o_standard_yn = dt2.Rows[0]["standard_yn"].ToString();
                            o_hangmog_name = dt2.Rows[0]["gumsa_name"].ToString();
                        }

                        this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), o_jubsu_time2);
                        this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), o_cpl_result);
                        this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), o_standard_yn);
                        this.laySigeyul.SetItemValue(rowNum, "from_standard", o_from_standard);
                        this.laySigeyul.SetItemValue(rowNum, "to_standard", o_to_standard);
                    }
                }
                else if (this.grdSigeyul.GetItemString(i, "gubun") == "1")
                {
                    /*********** 결과일자 LOAD **********#1#
                    cmdText = @"SELECT DISTINCT 
                                       TO_CHAR(A.JUBSU_DATE, 'YYYY/MM/DD')   JUBSU_DATE
                                     , SUBSTR(A.JUBSU_TIME,1,3)            JUBSU_TIME
                                     , TO_CHAR(A.JUBSU_DATE,'YY.MM.DD')
                                       ||'('||SUBSTR(A.JUBSU_TIME,1,2)||':'||SUBSTR(A.JUBSU_TIME,3,1)||'0)'  JUBSU_TIME2
                                  FROM CPLTEMP C,
                                       CPL3020 B,
                                       CPL2010 A
                                 WHERE A.HOSP_CODE     = :f_hosp_code
                                   AND B.HOSP_CODE     = A.HOSP_CODE
                                   AND C.HOSP_CODE     = A.HOSP_CODE
                                   AND A.BUNHO         = :f_bunho
                                   AND A.RESULT_DATE   IS NOT NULL
                                   AND TO_CHAR(A.JUBSU_DATE,'YY.MM.DD')||'('||SUBSTR(A.JUBSU_TIME,1,2)||':'||SUBSTR(A.JUBSU_TIME,3,1)||'0)' < :f_base_date
                                   AND B.SPECIMEN_SER  = A.SPECIMEN_SER
                                   AND C.IP_ADDRESS    = :q_user_id
                                   AND C.JUNDAL_GUBUN  = 'XX'
                                   AND B.HANGMOG_CODE  = C.HANGMOG_CODE
                                 ORDER BY TO_CHAR(A.JUBSU_DATE, 'YYYY/MM/DD') DESC , SUBSTR(A.JUBSU_TIME,1,3) DESC";

                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                    if (dt.Rows.Count < 1)
                        return false;
                    int tCnt = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        tCnt++;
                        if (tCnt > 7)
                            break;

                        o_jubsu_date = row["jubsu_date"].ToString();
                        o_jubsu_time = row["jubsu_time"].ToString();
                        o_jubsu_time2 = row["jubsu_time2"].ToString();

                        cmdText = @"  SELECT B.CPL_RESULT
                                            ,B.STANDARD_YN
                                            ,C.GUMSA_NAME
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('1', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY, A.SEX, A.AGE) FROM_STANDARD
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('2', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY,  A.SEX, A.AGE) TO_STANDARD
                                       
                                        FROM CPL0101 C,
                                             CPL3020 B,
                                             CPL2010 A
                                       WHERE A.HOSP_CODE     = :f_hosp_code
                                         AND B.HOSP_CODE     = A.HOSP_CODE
                                         AND C.HOSP_CODE     = A.HOSP_CODE
                                         AND A.BUNHO         = :f_bunho
                                         AND B.FKCPL2010     = A.PKCPL2010
                                         AND B.HANGMOG_CODE  = :f_hangmog_code
                                         AND A.PART_JUBSU_DATE   = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY ";

                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        o_cpl_result = "";
                        o_standard_yn = "";
                        o_hangmog_name = "";

                        if (!TypeCheck.IsNull(dt2))
                        {
                            o_cpl_result = dt2.Rows[0]["cpl_result"].ToString();
                            o_standard_yn = dt2.Rows[0]["standard_yn"].ToString();
                            o_hangmog_name = dt2.Rows[0]["gumsa_name"].ToString();
                        }

                        this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), o_jubsu_time2);
                        this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), o_cpl_result);
                        this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), o_standard_yn);
                        this.laySigeyul.SetItemValue(rowNum, "from_standard", o_from_standard);
                        this.laySigeyul.SetItemValue(rowNum, "to_standard", o_to_standard);
                    }
                }
                else
                {
                    /*********** 결과일자 LOAD **********#1#
                    cmdText = @"  SELECT DISTINCT 
                                         TO_CHAR(A.JUBSU_DATE, 'YYYY/MM/DD')   JUBSU_DATE
                                       , SUBSTR(A.JUBSU_TIME,1,3)              JUBSU_TIME
                                       , TO_CHAR(A.JUBSU_DATE,'YY.MM.DD')
                                         ||'('||SUBSTR(A.JUBSU_TIME,1,2)||':'||SUBSTR(A.JUBSU_TIME,3,1)||'0)' JUBSU_TIME2
                                    FROM CPLTEMP C,
                                         CPL3020 B,
                                         CPL2010 A
                                   WHERE A.HOSP_CODE     = :f_hosp_code
                                     AND B.HOSP_CODE     = A.HOSP_CODE
                                     AND C.HOSP_CODE     = A.HOSP_CODE
                                     AND A.BUNHO         = :f_bunho
                                     AND A.RESULT_DATE   IS NOT NULL
                                     AND TO_CHAR(A.JUBSU_DATE,'YY.MM.DD')||'('||SUBSTR(A.JUBSU_TIME,1,2)||':'||SUBSTR(A.JUBSU_TIME,3,1)||'0)' > :f_base_date
                                     AND B.SPECIMEN_SER  = A.SPECIMEN_SER
                                     AND C.IP_ADDRESS    = :q_user_id
                                     AND C.JUNDAL_GUBUN  = 'XX'
                                     AND B.HANGMOG_CODE  = C.HANGMOG_CODE
                                   ORDER BY TO_CHAR(A.JUBSU_DATE, 'YYYY/MM/DD') , SUBSTR(A.JUBSU_TIME,1,3)";

                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                    if (dt.Rows.Count < 1)
                        return false;
                    int tCnt = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        tCnt++;
                        if (tCnt > 7)
                            break;

                        o_jubsu_date = row["jubsu_date"].ToString();
                        o_jubsu_time = row["jubsu_time"].ToString();
                        o_jubsu_time2 = row["jubsu_time2"].ToString();

                        cmdText = @"  SELECT B.CPL_RESULT
                                            ,B.STANDARD_YN
                                            ,C.GUMSA_NAME
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('1', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY, A.SEX, A.AGE) FROM_STANDARD
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('2', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY,  A.SEX, A.AGE) TO_STANDARD
                                       
                                        FROM CPL0101 C,
                                             CPL3020 B,
                                             CPL2010 A
                                       WHERE A.HOSP_CODE     = :f_hosp_code
                                         AND B.HOSP_CODE     = A.HOSP_CODE
                                         AND C.HOSP_CODE     = A.HOSP_CODE
                                         AND A.BUNHO         = :f_bunho
                                         AND B.FKCPL2010     = A.PKCPL2010
                                         AND B.HANGMOG_CODE  = :f_hangmog_code
                                         AND A.PART_JUBSU_DATE   = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY ";

                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        o_cpl_result = "";
                        o_standard_yn = "";
                        o_hangmog_name = "";

                        if (!TypeCheck.IsNull(dt2))
                        {
                            o_cpl_result = dt2.Rows[0]["cpl_result"].ToString();
                            o_standard_yn = dt2.Rows[0]["standard_yn"].ToString();
                            o_hangmog_name = dt2.Rows[0]["gumsa_name"].ToString();
                        }

                        this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), o_jubsu_time2);
                        this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), o_cpl_result);
                        this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), o_standard_yn);
                        this.laySigeyul.SetItemValue(rowNum, "from_standard", o_from_standard);
                        this.laySigeyul.SetItemValue(rowNum, "to_standard", o_to_standard);
                    }
                }
            }*/
            return true;
        }
        #endregion

        #region GetPreJubsuSigeyulData
        private bool GetPreJubsuSigeyulData()
        {
            this.laySigeyul.Reset();
            // Connect to cloud
            List<MultiResultViewGrdSigeyulInfo> lsGrdSigeyulInfo = CreateListGrdSigeyulItem();
            if (lsGrdSigeyulInfo != null && lsGrdSigeyulInfo.Count > 0)
            {
                MultiResultViewGetPreJubsuSigeyulArgs args = new MultiResultViewGetPreJubsuSigeyulArgs();
                args.GrdSigeyulItem = lsGrdSigeyulInfo;
                args.UserId = UserInfo.UserID;
                MultiResultViewLaySigeyulResult result =
                    CloudService.Instance.Submit<MultiResultViewLaySigeyulResult, MultiResultViewGetPreJubsuSigeyulArgs>(
                        args);
                if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                {
                    List<MultiResultViewLaySigeyulInfo> lstLaySigeyulInfo = result.LaySigeyulInfo;
                    if (lstLaySigeyulInfo == null || lstLaySigeyulInfo.Count < 0)
                    {
                        return false;
                    }

                    for (int i = 0; i < lstLaySigeyulInfo.Count; i++)
                    {
                        int rowNum = this.laySigeyul.InsertRow(i);
                        this.laySigeyul.SetItemValue(rowNum, "gumsa_name", lstLaySigeyulInfo[i].GumsaName);
                        List<MultiResultViewDataForLaySigeyulInfo> lstDataForLaySigeyulInfo = lstLaySigeyulInfo[i].DataInfo;
                        if (lstDataForLaySigeyulInfo != null && lstDataForLaySigeyulInfo.Count > 0)
                        {
                            int tCnt = 0;
                            foreach (MultiResultViewDataForLaySigeyulInfo info in lstDataForLaySigeyulInfo)
                            {
                                tCnt++;
                                if (tCnt > 7)
                                    break;

                                if (tCnt == Int32.Parse(info.TCnt))
                                {
                                    this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), info.ResultDate);
                                    this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), info.Result);
                                    this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), info.StandardYn);
                                    this.laySigeyul.SetItemValue(rowNum, "from_standard", info.FromStandard);
                                    this.laySigeyul.SetItemValue(rowNum, "to_standard", info.ToStandard);
                                }
                            }
                        }
                    }

                }
            }

            // TODO comment use connect to cloud
            /*string o_jubsu_date = "";
            string o_jubsu_time = "";
            string o_jubsu_time2 = "";
            string o_cpl_result = "";
            string o_standard_yn = "";
            string o_hangmog_name = "";
            string o_from_standard = "";
            string o_to_standard = "";

            string t_hangmog_code = "";
            string t_base_date = "";

            string cmdText = "";
            BindVarCollection bc = new BindVarCollection();

            cmdText = @"DELETE CPLTEMP
                         WHERE HOSP_CODE  = :f_hosp_code
                           AND IP_ADDRESS = :q_user_id -- 컬럼명 아이피지만 실데이타는 유저아이디
                           AND JUNDAL_GUBUN = 'XX'";

            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("q_user_id", UserInfo.UserID);

            Service.ExecuteNonQuery(cmdText, bc);

            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {
                cmdText = @"INSERT INTO CPLTEMP 
                                 ( IP_ADDRESS       , JUNDAL_GUBUN
                                 , SEQ_CODE         , HANGMOG_CODE      , HOSP_CODE   )
                            VALUES 
                                 ( :q_user_id       , 'XX'
                                 , TO_CHAR(:i)      , :f_hangmog_code   , :f_hosp_code )";

                bc.Add("i", i.ToString());
                bc.Add("f_hangmog_code", this.grdSigeyul.GetItemString(i, "hangmog_code"));

                Service.ExecuteNonQuery(cmdText, bc);
            }

            this.laySigeyul.Reset();
            bc.Clear();
            int rowNum = -1;
            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {
                rowNum = this.laySigeyul.InsertRow(i);
                //XMessageBox.Show(i.ToString() + " *** " +rowNum.ToString());

                t_hangmog_code = this.grdSigeyul.GetItemString(i, "hangmog_code");
                t_base_date = this.grdSigeyul.GetItemString(i, "base_date");

                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("q_user_id", UserInfo.UserID);
                bc.Add("f_bunho", this.grdSigeyul.GetItemString(i, "bunho"));
                bc.Add("f_hangmog_code", t_hangmog_code);
                bc.Add("f_hangmog_name", this.grdSigeyul.GetItemString(i, "hangmog_name"));
                bc.Add("f_base_date", t_base_date);

                this.laySigeyul.SetItemValue(rowNum, "gumsa_name", this.grdSigeyul.GetItemString(i, "hangmog_name"));

                if (this.grdSigeyul.GetItemString(i, "gubun") == "0")
                {
                    /*********** 결과일자 LOAD **********#1#
                    cmdText = @"  SELECT DISTINCT 
                                         TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD')   JUBSU_DATE
                                       , SUBSTR(A.PART_JUBSU_TIME,1,3)              JUBSU_TIME
                                       , TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')
                                         ||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)' JUBSU_TIME2
                                    FROM CPLTEMP C,
                                         CPL3020 B,
                                         CPL2010 A
                                   WHERE A.HOSP_CODE     = :f_hosp_code
                                     AND B.HOSP_CODE     = A.HOSP_CODE
                                     AND C.HOSP_CODE     = A.HOSP_CODE
                                     AND A.BUNHO         = :f_bunho
                                     AND A.RESULT_DATE   IS NOT NULL
                                     AND B.SPECIMEN_SER  = A.SPECIMEN_SER
                                     AND C.IP_ADDRESS    = :q_user_id
                                     AND C.JUNDAL_GUBUN  = 'XX'
                                     AND B.HANGMOG_CODE  = C.HANGMOG_CODE
                                   ORDER BY TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD') , SUBSTR(A.PART_JUBSU_TIME,1,3)";


                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                    if (dt.Rows.Count < 1)
                        return false;

                    int tCnt = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        tCnt++;
                        if (tCnt > 7)
                            break;

                        o_jubsu_date = row["jubsu_date"].ToString();
                        o_jubsu_time = row["jubsu_time"].ToString();
                        o_jubsu_time2 = row["jubsu_time2"].ToString();

                        cmdText = @"  SELECT B.CPL_RESULT       CPL_RESULT
                                            ,B.STANDARD_YN      STANDARD_YN
                                            ,C.GUMSA_NAME       GUMSA_NAME
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('1', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY, A.SEX, A.AGE) FROM_STANDARD
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('2', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY,  A.SEX, A.AGE) TO_STANDARD
                                       
                                        FROM CPL0101 C,
                                             CPL3020 B,
                                             CPL2010 A
                                       WHERE A.HOSP_CODE     = :f_hosp_code
                                         AND B.HOSP_CODE     = A.HOSP_CODE
                                         AND C.HOSP_CODE     = A.HOSP_CODE
                                         AND A.BUNHO         = :f_bunho
                                         AND B.FKCPL2010     = A.PKCPL2010
                                         AND B.HANGMOG_CODE  = :f_hangmog_code
                                         AND A.PART_JUBSU_DATE  = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY ";

                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        if (Service.ErrCode != 0)
                            o_cpl_result = "";
                        o_standard_yn = "";
                        o_hangmog_name = "";

                        if (!TypeCheck.IsNull(dt2))
                        {
                            o_cpl_result = dt2.Rows[0]["cpl_result"].ToString();
                            o_standard_yn = dt2.Rows[0]["standard_yn"].ToString();
                            o_hangmog_name = dt2.Rows[0]["gumsa_name"].ToString();
                            o_from_standard = dt2.Rows[0]["from_standard"].ToString();
                            o_to_standard = dt2.Rows[0]["to_standard"].ToString();
                        }

                        this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), o_jubsu_time2);
                        this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), o_cpl_result);
                        this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), o_standard_yn);
                        this.laySigeyul.SetItemValue(rowNum, "from_standard", o_from_standard);
                        this.laySigeyul.SetItemValue(rowNum, "to_standard", o_to_standard);
                    }
                }
                else if (this.grdSigeyul.GetItemString(i, "gubun") == "1")
                {
                    /*********** 결과일자 LOAD **********#1#
                    cmdText = @"  SELECT DISTINCT 
                                         TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD')   JUBSU_DATE
                                       , SUBSTR(A.PART_JUBSU_TIME,1,3)              JUBSU_TIME
                                       , TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')
                                         ||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)'   JUBSU_TIME2
                                    FROM CPLTEMP C,
                                         CPL3020 B,
                                         CPL2010 A
                                   WHERE A.HOSP_CODE     = :f_hosp_code
                                     AND B.HOSP_CODE     = A.HOSP_CODE
                                     AND C.HOSP_CODE     = A.HOSP_CODE
                                     AND A.BUNHO         = :f_bunho
                                     AND A.RESULT_DATE   IS NOT NULL
                                     AND TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)' < :f_base_date
                                     AND B.SPECIMEN_SER  = A.SPECIMEN_SER
                                     AND C.IP_ADDRESS    = :q_user_id
                                     AND C.JUNDAL_GUBUN  = 'XX'
                                     AND B.HANGMOG_CODE  = C.HANGMOG_CODE
                                   ORDER BY TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD') DESC , SUBSTR(A.PART_JUBSU_TIME,1,3) DESC";

                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                    if (dt.Rows.Count < 1)
                        return false;

                    int tCnt = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        tCnt++;
                        if (tCnt > 7)
                            break;

                        o_jubsu_date = row["jubsu_date"].ToString();
                        o_jubsu_time = row["jubsu_time"].ToString();
                        o_jubsu_time2 = row["jubsu_time2"].ToString();

                        cmdText = @"  SELECT B.CPL_RESULT     CPL_RESULT
                                            ,B.STANDARD_YN      STANDARD_YN
                                            ,C.GUMSA_NAME       GUMSA_NAME
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('1', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY, A.SEX, A.AGE) FROM_STANDARD
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('2', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY,  A.SEX, A.AGE) TO_STANDARD
                                       
                                        FROM CPL0101 C,
                                             CPL3020 B,
                                             CPL2010 A
                                       WHERE A.HOSP_CODE     = :f_hosp_code
                                         AND B.HOSP_CODE     = A.HOSP_CODE
                                         AND C.HOSP_CODE     = A.HOSP_CODE
                                         AND A.BUNHO         = :f_bunho
                                         AND B.FKCPL2010     = A.PKCPL2010
                                         AND B.HANGMOG_CODE  = :f_hangmog_code
                                         AND A.PART_JUBSU_DATE   = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY   ";

                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        o_cpl_result = "";
                        o_standard_yn = "";
                        o_hangmog_name = "";

                        if (!TypeCheck.IsNull(dt2))
                        {
                            o_cpl_result = dt2.Rows[0]["cpl_result"].ToString();
                            o_standard_yn = dt2.Rows[0]["standard_yn"].ToString();
                            o_hangmog_name = dt2.Rows[0]["gumsa_name"].ToString();
                            o_from_standard = dt2.Rows[0]["from_standard"].ToString();
                            o_to_standard = dt2.Rows[0]["to_standard"].ToString();
                        }

                        this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), o_jubsu_time2);
                        this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), o_cpl_result);
                        this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), o_standard_yn);
                        this.laySigeyul.SetItemValue(rowNum, "from_standard", o_from_standard);
                        this.laySigeyul.SetItemValue(rowNum, "to_standard", o_to_standard);
                    }
                }
                else
                {
                    /*********** 결과일자 LOAD **********#1#
                    cmdText = @"  SELECT DISTINCT 
                                         TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD')   JUBSU_DATE
                                       , SUBSTR(A.PART_JUBSU_TIME,1,3)              JUBSU_TIME
                                       , TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')
                                         ||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)'   JUBSU_TIME2
                                    FROM CPLTEMP C,
                                         CPL3020 B,
                                         CPL2010 A
                                   WHERE A.HOSP_CODE     = :f_hosp_code
                                     AND B.HOSP_CODE     = A.HOSP_CODE
                                     AND C.HOSP_CODE     = A.HOSP_CODE
                                     AND A.BUNHO         = :f_bunho
                                     AND A.RESULT_DATE   IS NOT NULL
                                     AND TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)' > :f_base_date
                                     AND B.SPECIMEN_SER  = A.SPECIMEN_SER
                                     AND C.IP_ADDRESS    = :q_user_id
                                     AND C.JUNDAL_GUBUN  = 'XX'
                                     AND B.HANGMOG_CODE  = C.HANGMOG_CODE
                                   ORDER BY TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD') , SUBSTR(A.PART_JUBSU_TIME,1,3)";

                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                    if (dt.Rows.Count < 1)
                        return false;

                    int tCnt = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        tCnt++;
                        if (tCnt > 7)
                            break;

                        o_jubsu_date = row["jubsu_date"].ToString();
                        o_jubsu_time = row["jubsu_time"].ToString();
                        o_jubsu_time2 = row["jubsu_time2"].ToString();

                        cmdText = @"  SELECT B.CPL_RESULT         CPL_RESULT
                                            ,B.STANDARD_YN          STANDARD_YN
                                            ,C.GUMSA_NAME           GUMSA_NAME
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('1', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY, A.SEX, A.AGE) FROM_STANDARD
                                            , FN_CPL_STANDARD_FROM_TO_LOAD ('2', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY,  A.SEX, A.AGE) TO_STANDARD
                                       
                                        FROM CPL0101 C,
                                             CPL3020 B,
                                             CPL2010 A
                                       WHERE A.HOSP_CODE     = :f_hosp_code
                                         AND B.HOSP_CODE     = A.HOSP_CODE
                                         AND C.HOSP_CODE     = A.HOSP_CODE
                                         AND A.BUNHO         = :f_bunho
                                         AND B.FKCPL2010     = A.PKCPL2010
                                         AND B.HANGMOG_CODE  = :f_hangmog_code
                                         AND A.PART_JUBSU_DATE   = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY ";

                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        o_cpl_result = "";
                        o_standard_yn = "";
                        o_hangmog_name = "";

                        if (!TypeCheck.IsNull(dt2))
                        {
                            o_cpl_result = dt2.Rows[0]["cpl_result"].ToString();
                            o_standard_yn = dt2.Rows[0]["standard_yn"].ToString();
                            o_hangmog_name = dt2.Rows[0]["gumsa_name"].ToString();
                            o_from_standard = dt2.Rows[0]["from_standard"].ToString();
                            o_to_standard = dt2.Rows[0]["to_standard"].ToString();
                        }

                        this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), o_jubsu_time2);
                        this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), o_cpl_result);
                        this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), o_standard_yn);
                        this.laySigeyul.SetItemValue(rowNum, "from_standard", o_from_standard);
                        this.laySigeyul.SetItemValue(rowNum, "to_standard", o_to_standard);
                    }
                }
            }*/
            return true;
        }
        #endregion

        #region dw클릭시
        private void dwSigeyul_Click(object sender, System.EventArgs e)
		{
			dwSigeyul.Refresh();
		}

		private void dwSigeyul_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwSigeyul.Refresh();
		}
		#endregion

		#region 이전조회 버튼 클릭
		private void btnPre_Click(object sender, System.EventArgs e)
		{
            //if ( this.dwSigeyul.RowCount == 0 )	return;

            try
            {
                int temp = this.dwSigeyul.GetItemString(1, "result_date1").Length;
            }
            catch
            {
                for (int i = 0; i < this.grdSigeyul.RowCount; i++)
                {
                    this.grdSigeyul.SetItemValue(i, "gubun", "0");
                    this.grdSigeyul.SetItemValue(i, "base_date", "");
                }
                SigeyulQry("post");
                return;
            }

			for ( int i=0; i < this.grdSigeyul.RowCount; i++ )
			{
				this.grdSigeyul.SetItemValue(i,"gubun","1");
				this.grdSigeyul.SetItemValue(i,"base_date",this.dwSigeyul.GetItemString(i+1,"result_date1"));
			}
			SigeyulQry("pre");
		}
		#endregion

		#region 다음 조회 버튼 클릭
		private void btnNext_Click(object sender, System.EventArgs e)
		{
            //if ( this.dwSigeyul.RowCount == 0 )
            //    return;
            try
            {
                int temp = this.dwSigeyul.GetItemString(1, "result_date1").Length;
            }
            catch
            {
                for (int i = 0; i < this.grdSigeyul.RowCount; i++)
                {
                    this.grdSigeyul.SetItemValue(i, "gubun", "0");
                    this.grdSigeyul.SetItemValue(i, "base_date", "");
                }
                SigeyulQry("pre");
                return;
            }
			try
			{
				int temp = this.dwSigeyul.GetItemString(1,"result_date7").Length;
			}
			catch
			{
				return;
			}

			for ( int i=0; i < this.grdSigeyul.RowCount; i++ )
			{
				this.grdSigeyul.SetItemValue(i,"gubun","2");
				this.grdSigeyul.SetItemValue(i,"base_date",this.dwSigeyul.GetItemString(i+1,"result_date7"));
			}
			SigeyulQry("post");
		}
		#endregion

		#region 프린트 버튼 클릭
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			if (dw_print.RowCount > 0)
			{
				dw_print.Print();
			}
		}
		#endregion

		#region 체크박스 체크 체인지
		private void rbxJubsuYN_CheckedChanged(object sender, System.EventArgs e)
		{
            this.MultiLanguageForDW();

			//기본 시계열 조회
			BaseQuery();

            ////DW TEXT 변경
            //string text;

            //if (rbxJubsuYN.Checked == false)
            //    text = "t_2.text = '" + "(" + Properties.Resources.MSG1 + ")" + "'";
            //else
            //    text = "t_2.text = '" + "(" + Properties.Resources.MSG2 + ")" + "'";

            //dw_print.Modify(text);
            //dwSigeyul.Modify(text);

            //dw_print.Refresh();
            //dwSigeyul.Refresh();
		}
		#endregion

		#endregion

		#region 시계열 입력 그리드 설정 Method
        public void SetSigeyul(IHIS.Framework.XEditGrid arGrid)
        {
            this.grdSigeyul = arGrid;

            //조회 아웃풋 설정
            //dsvJubsuSigeyul.MInputLayout = grdSigeyul;
            //dsvPartJubsuSigeyul.MInputLayout = grdSigeyul;

            //기본 시계열 조회
            BaseQuery();
        }

        public void SetSigeyul(string aBunho, string aGroupHangmog)
        {
            string querySQL = @"SELECT MIN(:f_bunho)
                                     , A.SUB_HANGMOG_CODE
                                     , MIN(B.GUMSA_NAME)
                                  FROM CPL0101 B
                                     , CPL0106 A
                                 WHERE A.HOSP_CODE      = :f_hosp_code
                                   AND B.HOSP_CODE      = A.HOSP_CODE
                                   AND A.HANGMOG_CODE   = :f_group_hangmog
                                   AND B.HANGMOG_CODE   = A.SUB_HANGMOG_CODE
                                   AND B.SPECIMEN_CODE  = A.SUB_SPECIMEN_CODE
                                   AND B.EMERGENCY      = A.SUB_EMERGENCY
                                 GROUP BY A.SUB_HANGMOG_CODE --, B.SERIAL
                                 --ORDER BY B.SERIAL
                                 ORDER BY A.SUB_HANGMOG_CODE";
//            this.grdSigeyul.QuerySQL = querySQL;
            this.grdSigeyul.ParamList = new List<string>(new String[] { "f_bunho", "f_group_hangmog" });
            this.grdSigeyul.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSigeyul.SetBindVarValue("f_bunho", aBunho);
            this.grdSigeyul.SetBindVarValue("f_group_hangmog", aGroupHangmog);

            this.grdSigeyul.ExecuteQuery = ExecuteQueryGrdSigeyul1;
            this.grdSigeyul.QueryLayout(true);

            if (this.grdSigeyul.RowCount <= 0)
            {
                string querySQL1 = @"SELECT :f_bunho  BUNHO
                                         , HANGMOG_CODE
                                         , GUMSA_NAME
                                      FROM CPL0101
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND HANGMOG_CODE = :f_group_hangmog
                                       AND ROWNUM       = 1
                                     --ORDER BY SERIAL ";
                this.grdSigeyul.QuerySQL = querySQL1;
                this.grdSigeyul.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdSigeyul.SetBindVarValue("f_bunho", aBunho);
                this.grdSigeyul.SetBindVarValue("f_group_hangmog", aGroupHangmog);

                this.grdSigeyul.ExecuteQuery = ExecuteQueryGrdSigeyul2;
                this.grdSigeyul.QueryLayout(true);
//                this.grdSigeyul.QuerySQL = querySQL;
            }

            try
            {
                //기본 시계열 조회
                BaseQuery();
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.StackTrace);
            }
        }
		#endregion

        private void layPaInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPaInfo.ParamList = new List<string>(new String[] { "f_bunho" });
            this.layPaInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layPaInfo.SetBindVarValue("f_bunho", this.grdSigeyul.GetItemString(this.grdSigeyul.CurrentRowNumber, "bunho"));
        }

        #region Connect cloud service

        /// <summary>
        /// ExecuteQueryLayPaInfo
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
	    private IList<object[]> ExecuteQueryLayPaInfo(BindVarCollection var)
	    {
	        IList<object[]> listObject = new List<object[]>();
            MultiResultViewLayPaInfoArgs args = new MultiResultViewLayPaInfoArgs();
	        args.Bunho = var["f_bunho"].VarValue;
	        MultiResultViewLayPaInfoResult result =
	            CloudService.Instance.Submit<MultiResultViewLayPaInfoResult, MultiResultViewLayPaInfoArgs>(args);
	        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<MultiResultViewLayPaInfo> lstResultViewLayPaInfo = result.LayPaInfo;
	            if (lstResultViewLayPaInfo != null && lstResultViewLayPaInfo.Count > 0)
	            {
	                foreach (MultiResultViewLayPaInfo info in lstResultViewLayPaInfo)
	                {
	                    listObject.Add(new object[]
	                    {
	                        info.Suname,
	                        info.Suname2,
	                        info.Sex,
	                        info.YearAge,
	                        info.MonthAge,
	                        info.Gubun,
	                        info.AdmDictNm,
	                        info.Birth,
	                        info.Tel,
	                        info.Tel1,
	                        info.TelHp,
	                        info.Email,
	                        info.ZipCode1,
	                        info.ZipCode2,
	                        info.Address1,
	                        info.Address2,
	                        info.InpJaewonCheck
	                    });
	                }
	            }
	        }
	        return listObject;
	    }

        /// <summary>
        /// ExecuteQueryGrdSigeyul
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
	    private IList<object[]> ExecuteQueryGrdSigeyul1(BindVarCollection var)
	    {
	        IList<object[]> listObject = new List<object[]>();
            MultiResultViewGrdSigeyul1Args args = new MultiResultViewGrdSigeyul1Args();
	        args.Bunho = var["f_bunho"].VarValue;
	        args.GroupHangmog = var["f_group_hangmog"].VarValue;
	        MultiResultViewGrdSigeyulResult result =
	            CloudService.Instance.Submit<MultiResultViewGrdSigeyulResult, MultiResultViewGrdSigeyul1Args>(args);
	        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            listObject = CreateListObjectGrdSigeyul(result.GrdSigeyulInfo);
	        }
	        return listObject;
	    }

        /// <summary>
        /// ExecuteQueryGrdSigeyul
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryGrdSigeyul2(BindVarCollection var)
        {
            IList<object[]> listObject = new List<object[]>();
            MultiResultViewGrdSigeyul2Args args = new MultiResultViewGrdSigeyul2Args();
            args.Bunho = var["f_bunho"].VarValue;
            args.GroupHangmog = var["f_group_hangmog"].VarValue;
            MultiResultViewGrdSigeyulResult result =
                CloudService.Instance.Submit<MultiResultViewGrdSigeyulResult, MultiResultViewGrdSigeyul2Args>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                listObject = CreateListObjectGrdSigeyul(result.GrdSigeyulInfo);
            }
            return listObject;
        }

        /// <summary>
        /// CreateListObjectGrdSigeyul
        /// </summary>
        /// <param name="lstGrdSigeyulInfo"></param>
        /// <returns></returns>
	    private IList<object[]> CreateListObjectGrdSigeyul(List<MultiResultViewGrdSigeyulInfo> lstGrdSigeyulInfo)
	    {
            IList<object[]> listObject = new List<object[]>();
	        if (lstGrdSigeyulInfo != null && lstGrdSigeyulInfo.Count > 0)
	        {
	            foreach (MultiResultViewGrdSigeyulInfo info in lstGrdSigeyulInfo)
	            {
	                listObject.Add(new object[]
	                {
	                    info.Bunho,
                        info.HangmogCode, 
                        info.GumsaName
	                });
	            }
	        }
	        return listObject;
	    }

        /// <summary>
        /// CreateListGrdSigeyulItem
        /// </summary>
        /// <returns></returns>
	    private List<MultiResultViewGrdSigeyulInfo> CreateListGrdSigeyulItem()
	    {
	        List<MultiResultViewGrdSigeyulInfo> lstResultViewGrdSigeyulInfo = new List<MultiResultViewGrdSigeyulInfo>();
            for (int i = 0; i < grdSigeyul.RowCount; i++)
	        {
	            MultiResultViewGrdSigeyulInfo sigeyulInfo = new MultiResultViewGrdSigeyulInfo();
                sigeyulInfo.Bunho = this.grdSigeyul.GetItemString(i, "bunho");
                sigeyulInfo.HangmogCode = this.grdSigeyul.GetItemString(i, "hangmog_code");
                sigeyulInfo.GumsaName = this.grdSigeyul.GetItemString(i, "hangmog_name");
                sigeyulInfo.Gubun = this.grdSigeyul.GetItemString(i, "gubun");
                sigeyulInfo.BaseDate = this.grdSigeyul.GetItemString(i, "base_date");

                lstResultViewGrdSigeyulInfo.Add(sigeyulInfo);
	        }
	        return lstResultViewGrdSigeyulInfo;
	    }
        #endregion

        #region https://sofiamedix.atlassian.net/browse/MED-12171

        public delegate void ModifyDWDelegate();
        public ModifyDWDelegate ModifyDW;

        private void MultiLanguageForDW()
        {
            //DW TEXT 변경
            string text;

            if (rbxJubsuYN.Checked == false)
                text = "t_2.text = '" + "(" + Properties.Resources.MSG1 + ")" + "'";
            else
                text = "t_2.text = '" + "(" + Properties.Resources.MSG2 + ")" + "'";

            dw_print.Modify(text);
            dw_print.Modify("t_2.Font.Face='Arial'");
            dw_print.Modify("t_2.Font.Height='8'");
            dwSigeyul.Modify(text);
            dwSigeyul.Modify("t_2.Font.Face='Arial'");
            dwSigeyul.Modify("t_2.Font.Face='8'");
            dw_print.Refresh();
            dwSigeyul.Refresh();
        }

        #endregion
    }
}
