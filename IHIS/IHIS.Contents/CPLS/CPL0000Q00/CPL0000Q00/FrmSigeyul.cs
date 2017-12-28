using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using System.IO;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CPLS.Properties;

namespace IHIS.CPLS
{
    /// <summary>
    /// CHANGETIME에 대한 요약 설명입니다.
    /// </summary>
    public class FrmSigeyul : IHIS.Framework.XForm
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel2;
  //      private IHIS.Framework.XDataWindow dwSigeyul;
        private IHIS.Framework.MultiLayout laySigeyul;
        private IHIS.Framework.XButton btnPre;
        private IHIS.Framework.XButton btnNext;
        private IHIS.Framework.MultiLayout layPreSigeyul;
    //    private IHIS.Framework.XDataWindow dw_print;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XButton btnPrint;
        private IHIS.Framework.XFlatRadioButton rbxJubsuYN;
        private IHIS.Framework.XFlatRadioButton rbxPartJubsuYN;
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
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private MultiLayoutItem multiLayoutItem70;
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
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
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

        private IHIS.Framework.XEditGrid grdSigeyul;

        public FrmSigeyul(IHIS.Framework.XEditGrid arGrid)
        {
            InitializeComponent();

            this.grdSigeyul = arGrid;

            //kbh1219
            //dsvJubsuSigeyul.MInputLayout = grdSigeyul;
            //dsvPartJubsuSigeyul.MInputLayout = grdSigeyul;

        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSigeyul));
            this.xPanel1 = new IHIS.Framework.XPanel();
    //        this.dw_print = new IHIS.Framework.XDataWindow();
            this.rbxPartJubsuYN = new IHIS.Framework.XFlatRadioButton();
            this.rbxJubsuYN = new IHIS.Framework.XFlatRadioButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnNext = new IHIS.Framework.XButton();
            this.btnPre = new IHIS.Framework.XButton();
  //          this.dwSigeyul = new IHIS.Framework.XDataWindow();
            this.laySigeyul = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem70 = new IHIS.Framework.MultiLayoutItem();
            this.layPreSigeyul = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
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
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySigeyul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreSigeyul)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
    //        this.xPanel1.Controls.Add(this.dw_print);
            this.xPanel1.Controls.Add(this.rbxPartJubsuYN);
            this.xPanel1.Controls.Add(this.rbxJubsuYN);
            this.xPanel1.Controls.Add(this.btnPrint);
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // dw_print
            // 
            //this.dw_print.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            //this.dw_print.DataWindowObject = "d_cpl3010_sigeyul_prt";
            //this.dw_print.LibraryList = "CPLS\\cpls.cpl0000q00.pbd";
            //resources.ApplyResources(this.dw_print, "dw_print");
            //this.dw_print.Name = "dw_print";
            // 
            // rbxPartJubsuYN
            // 
            this.rbxPartJubsuYN.Checked = true;
            resources.ApplyResources(this.rbxPartJubsuYN, "rbxPartJubsuYN");
            this.rbxPartJubsuYN.Name = "rbxPartJubsuYN";
            this.rbxPartJubsuYN.TabStop = true;
            this.rbxPartJubsuYN.UseVisualStyleBackColor = false;
            // 
            // rbxJubsuYN
            // 
            resources.ApplyResources(this.rbxJubsuYN, "rbxJubsuYN");
            this.rbxJubsuYN.Name = "rbxJubsuYN";
            this.rbxJubsuYN.UseVisualStyleBackColor = false;
            this.rbxJubsuYN.CheckedChanged += new System.EventHandler(this.rbxJubsuYN_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // paBox
            // 
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "選択", -1, "HotPink"),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnNext);
            this.xPanel2.Controls.Add(this.btnPre);
    //        this.xPanel2.Controls.Add(this.dwSigeyul);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Name = "btnNext";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            resources.ApplyResources(this.btnPre, "btnPre");
            this.btnPre.Name = "btnPre";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // dwSigeyul
            // 
            //this.dwSigeyul.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            //this.dwSigeyul.DataWindowObject = "d_cpl3010_sigeyul";
            //resources.ApplyResources(this.dwSigeyul, "dwSigeyul");
            //this.dwSigeyul.LibraryList = "CPLS\\cpls.cpl0000q00.pbd";
            //this.dwSigeyul.Name = "dwSigeyul";
            //this.dwSigeyul.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            //this.dwSigeyul.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwSigeyul_RowFocusChanged);
            //this.dwSigeyul.Click += new System.EventHandler(this.dwSigeyul_Click);
            // 
            // laySigeyul
            // 
            this.laySigeyul.ExecuteQuery = null;
            this.laySigeyul.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69,
            this.multiLayoutItem70});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gumsa_name";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "result_date1";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "result_1";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "result_date2";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "result_2";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "result_date3";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "result_3";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "result_date4";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "result_4";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "result_date5";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "result_5";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "result_date6";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "result_6";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "result_date7";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "result_7";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "result_date8";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "result_8";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "result_date9";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "result_9";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "standard_yn_1";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "standard_yn_2";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "standard_yn_3";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "standard_yn_4";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "standard_yn_5";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "standard_yn_6";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "standard_yn_7";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "standard_yn_8";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "standard_yn_9";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "bunho";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "suname";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "birth";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "sex";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "age";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "from_standard";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "to_standard";
            // 
            // layPreSigeyul
            // 
            this.layPreSigeyul.ExecuteQuery = null;
            this.layPreSigeyul.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
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
            this.multiLayoutItem63});
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "gumsa_name";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "result_date1";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "result_1";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "result_date2";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "result_2";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "result_date3";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "result_3";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "result_date4";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "result_4";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "result_date5";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "result_5";
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
            this.multiLayoutItem42.DataName = "result_date7";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "result_7";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "result_date8";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "result_8";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "result_date9";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "result_9";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "standard_yn_1";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "standard_yn_2";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "standard_yn_3";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "standard_yn_4";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "standard_yn_5";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "standard_yn_6";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "standard_yn_7";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "standard_yn_8";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "standard_yn_9";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "bunho";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "suname";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "birth";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "sex";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "age";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "from_standard";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "to_standard";
            // 
            // FrmSigeyul
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "FrmSigeyul";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.laySigeyul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreSigeyul)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BaseQuery();
        }

        #region 초기 쿼리
        int flag = 0;

        private void BaseQuery()
        {
            string bunho = "";
            string base_date = "";
            mResultDate1 = "";
            mResultDate7 = "";

            //강제로 매 실행시 base_date값 갱신
            //이유는 데이터가 체인지 되지 않으면 인변수로 넘어가지 않기 때문..
            base_date = EnvironInfo.GetSysDate().AddDays(flag).ToString().Substring(2, 2) + "."
                    + EnvironInfo.GetSysDate().AddDays(flag).ToString().Substring(5, 2) + "."
                    + EnvironInfo.GetSysDate().AddDays(flag).ToString().Substring(8, 2) + "(24:00)";

            for (int i = 0; i < this.grdSigeyul.RowCount; i++)
            {
                this.grdSigeyul.SetItemValue(i, "gubun", "1");

                this.grdSigeyul.SetItemValue(i, "base_date", base_date);

                bunho = grdSigeyul.GetItemString(i, "bunho");
            }
            paBox.SetPatientID(bunho);

            SigeyulQry("pre");

            flag++;
        }
        #endregion


        #region SigeyulQry
        private void SigeyulQry(string gubun)
        {
            this.AcceptData();
     //       dwSigeyul.Reset();
    //        dw_print.Reset();
            bool QryYN = false;
            ApplyMultilanguagePrintSigeyulDW();
            ApplyMultilanguageSigeyulDW();
            // 접수일 기준
            if (rbxJubsuYN.Checked)
                //QryYN = DataServiceCall(dsvJubsuSigeyul);
                //QryYN = GetJubsuSigeyulData();
                QryYN = GetJubsuSigeyulData2();
            // 파트접수일 기준
            if (rbxPartJubsuYN.Checked)
            {
                //QryYN = GetPreJubsuSigeyulData();
                QryYN = GetPreJubsuSigeyulData2();
            }

            if (QryYN)
            {
                //전 조회 버튼인지 이후 조회 버튼인지 구분
                if (gubun == "pre")
                {
                    layPreSigeyul.Reset();
                    for (int i = 0; i < this.laySigeyul.RowCount; i++)
                    {
                        //이전조회시 결과 일자 뒤집기
                        layPreSigeyul.InsertRow(i);

                        layPreSigeyul.SetItemValue(i, "gumsa_name", laySigeyul.GetItemString(i, "gumsa_name"));
                        layPreSigeyul.SetItemValue(i, "from_standard", laySigeyul.GetItemString(i, "from_standard"));
                        layPreSigeyul.SetItemValue(i, "to_standard", laySigeyul.GetItemString(i, "to_standard"));

                        layPreSigeyul.SetItemValue(i, "result_date1", laySigeyul.GetItemString(i, "result_date7"));
                        layPreSigeyul.SetItemValue(i, "result_1", laySigeyul.GetItemString(i, "result_7"));
                        layPreSigeyul.SetItemValue(i, "standard_yn_1", laySigeyul.GetItemString(i, "standard_yn_7"));
                        layPreSigeyul.SetItemValue(i, "result_date2", laySigeyul.GetItemString(i, "result_date6"));
                        layPreSigeyul.SetItemValue(i, "result_2", laySigeyul.GetItemString(i, "result_6"));
                        layPreSigeyul.SetItemValue(i, "standard_yn_2", laySigeyul.GetItemString(i, "standard_yn_6"));
                        layPreSigeyul.SetItemValue(i, "result_date3", laySigeyul.GetItemString(i, "result_date5"));
                        layPreSigeyul.SetItemValue(i, "result_3", laySigeyul.GetItemString(i, "result_5"));
                        layPreSigeyul.SetItemValue(i, "standard_yn_3", laySigeyul.GetItemString(i, "standard_yn_5"));
                        layPreSigeyul.SetItemValue(i, "result_date4", laySigeyul.GetItemString(i, "result_date4"));
                        layPreSigeyul.SetItemValue(i, "result_4", laySigeyul.GetItemString(i, "result_4"));
                        layPreSigeyul.SetItemValue(i, "standard_yn_4", laySigeyul.GetItemString(i, "standard_yn_4"));
                        layPreSigeyul.SetItemValue(i, "result_date5", laySigeyul.GetItemString(i, "result_date3"));
                        layPreSigeyul.SetItemValue(i, "result_5", laySigeyul.GetItemString(i, "result_3"));
                        layPreSigeyul.SetItemValue(i, "standard_yn_5", laySigeyul.GetItemString(i, "standard_yn_3"));
                        layPreSigeyul.SetItemValue(i, "result_date6", laySigeyul.GetItemString(i, "result_date2"));
                        layPreSigeyul.SetItemValue(i, "result_6", laySigeyul.GetItemString(i, "result_2"));
                        layPreSigeyul.SetItemValue(i, "standard_yn_6", laySigeyul.GetItemString(i, "standard_yn_2"));
                        layPreSigeyul.SetItemValue(i, "result_date7", laySigeyul.GetItemString(i, "result_date1"));
                        layPreSigeyul.SetItemValue(i, "result_7", laySigeyul.GetItemString(i, "result_1"));
                        layPreSigeyul.SetItemValue(i, "standard_yn_7", laySigeyul.GetItemString(i, "standard_yn_1"));

                        layPreSigeyul.SetItemValue(i, "bunho", paBox.BunHo);
                        layPreSigeyul.SetItemValue(i, "suname", paBox.SuName);
                        layPreSigeyul.SetItemValue(i, "sex", paBox.Sex);
                        layPreSigeyul.SetItemValue(i, "age", paBox.YearAge);
                        layPreSigeyul.SetItemValue(i, "birth", paBox.Birth);
                    }

                    //좌측정렬하기
                    for (int j = 1; j <= 7; j++)
                    {
                        if (layPreSigeyul.GetItemString(0, "result_date1").Length == 0)
                        {
                            for (int k = 0; k < this.layPreSigeyul.RowCount; k++)
                            {
                                layPreSigeyul.SetItemValue(k, "result_date1", layPreSigeyul.GetItemString(k, "result_date2"));
                                layPreSigeyul.SetItemValue(k, "result_1", layPreSigeyul.GetItemString(k, "result_2"));
                                layPreSigeyul.SetItemValue(k, "standard_yn_1", layPreSigeyul.GetItemString(k, "standard_yn_2"));
                                layPreSigeyul.SetItemValue(k, "result_date2", layPreSigeyul.GetItemString(k, "result_date3"));
                                layPreSigeyul.SetItemValue(k, "result_2", layPreSigeyul.GetItemString(k, "result_3"));
                                layPreSigeyul.SetItemValue(k, "standard_yn_2", layPreSigeyul.GetItemString(k, "standard_yn_3"));
                                layPreSigeyul.SetItemValue(k, "result_date3", layPreSigeyul.GetItemString(k, "result_date4"));
                                layPreSigeyul.SetItemValue(k, "result_3", layPreSigeyul.GetItemString(k, "result_4"));
                                layPreSigeyul.SetItemValue(k, "standard_yn_3", layPreSigeyul.GetItemString(k, "standard_yn_4"));
                                layPreSigeyul.SetItemValue(k, "result_date4", layPreSigeyul.GetItemString(k, "result_date5"));
                                layPreSigeyul.SetItemValue(k, "result_4", layPreSigeyul.GetItemString(k, "result_5"));
                                layPreSigeyul.SetItemValue(k, "standard_yn_4", layPreSigeyul.GetItemString(k, "standard_yn_5"));
                                layPreSigeyul.SetItemValue(k, "result_date5", layPreSigeyul.GetItemString(k, "result_date6"));
                                layPreSigeyul.SetItemValue(k, "result_5", layPreSigeyul.GetItemString(k, "result_6"));
                                layPreSigeyul.SetItemValue(k, "standard_yn_5", layPreSigeyul.GetItemString(k, "standard_yn_6"));
                                layPreSigeyul.SetItemValue(k, "result_date6", layPreSigeyul.GetItemString(k, "result_date7"));
                                layPreSigeyul.SetItemValue(k, "result_6", layPreSigeyul.GetItemString(k, "result_7"));
                                layPreSigeyul.SetItemValue(k, "standard_yn_6", layPreSigeyul.GetItemString(k, "standard_yn_7"));
                                layPreSigeyul.SetItemValue(k, "result_date7", "");
                                layPreSigeyul.SetItemValue(k, "result_7", "");
                                layPreSigeyul.SetItemValue(k, "standard_yn_7", "");

                                layPreSigeyul.SetItemValue(k, "bunho", paBox.BunHo);
                                layPreSigeyul.SetItemValue(k, "suname", paBox.SuName);
                                layPreSigeyul.SetItemValue(k, "sex", paBox.Sex);
                                layPreSigeyul.SetItemValue(k, "age", paBox.YearAge);
                                layPreSigeyul.SetItemValue(k, "birth", paBox.Birth);
                            }
                        }
                    }

    //                dwSigeyul.FillData(layPreSigeyul.LayoutTable);
   //                 dw_print.FillData(layPreSigeyul.LayoutTable);
                }
                else
                {
     //               dwSigeyul.FillData(laySigeyul.LayoutTable);
     //               dw_print.FillData(laySigeyul.LayoutTable);
                }
            }
    //        dwSigeyul.Refresh();
        }
        #endregion

        #region GetSigeyulData
        private bool GetJubsuSigeyulData()
        {
            string o_jubsu_date = "";
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
                    /*********** 결과일자 LOAD ***********/
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
                                         AND A.PART_JUBSU_DATE   = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY ";

                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        if (Service.ErrCode != 0)
                        { }
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
                    /*********** 결과일자 LOAD ***********/
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
                                         AND C.EMERGENCY     = B.EMERGENCY  
                                       ORDER BY B.PKCPL3020  ";

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
                    /*********** 결과일자 LOAD ***********/
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
                                         AND C.EMERGENCY     = B.EMERGENCY 
                                       ORDER BY B.PKCPL3020  ";

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
            }
            return true;
        }
        #endregion

        #region GetPreJubsuSigeyulData
        private bool GetPreJubsuSigeyulData()
        {
            string o_jubsu_date = "";
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
                    /*********** 결과일자 LOAD ***********/
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
                else if (this.grdSigeyul.GetItemString(i, "gubun") == "1") //pre
                {
                    /*********** 결과일자 LOAD ***********/
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
                else if (this.grdSigeyul.GetItemString(i, "gubun") == "2")// post
                {
                    /*********** 결과일자 LOAD ***********/
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
                else //결과조회없을 때 앞으로 돌아갈때 조회조건에 = 추가 나머지 2와 똑같음
                {
                    /*********** 결과일자 LOAD ***********/
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
                                     AND TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)' >= :f_base_date
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
            }
            return true;
        }
        #endregion

        #region dw클릭시
        private void dwSigeyul_Click(object sender, System.EventArgs e)
        {
     //       dwSigeyul.Refresh();
        }

        private void dwSigeyul_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
     //       dwSigeyul.Refresh();
        }
        #endregion

        #region 이전조회 버튼 클릭

        private string mResultDate1 = "";
        private string mResultDate7 = "";

        private void btnPre_Click(object sender, System.EventArgs e)
        {
            ////if ( this.dwSigeyul.RowCount == 0 )	return;
            //try
            //{
            //    int temp = this.dwSigeyul.GetItemString(1, "result_date1").Length;
            //    mResultDate1 = this.dwSigeyul.GetItemString(1, "result_date1");
            //    mResultDate7 = this.dwSigeyul.GetItemString(1, "result_date7");
            //}
            //catch
            //{
            //    for (int i = 0; i < this.grdSigeyul.RowCount; i++)
            //    {
            //        //this.grdSigeyul.SetItemValue(i, "gubun", "0");
            //        //this.grdSigeyul.SetItemValue(i, "base_date", "");

            //        this.grdSigeyul.SetItemValue(i, "gubun", "3");
            //        this.grdSigeyul.SetItemValue(i, "base_date", mResultDate1);
            //    }
            //    SigeyulQry("post");
            //    return;
            //}

            //for (int i = 0; i < this.grdSigeyul.RowCount; i++)
            //{
            //    this.grdSigeyul.SetItemValue(i, "gubun", "1");
            //    this.grdSigeyul.SetItemValue(i, "base_date", this.dwSigeyul.GetItemString(i + 1, "result_date1"));
            //}
            //SigeyulQry("pre");
        }
        #endregion

        #region 다음 조회 버튼 클릭
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            ////if ( this.dwSigeyul.RowCount == 0 )	return;

            //try
            //{
            //    int temp = this.dwSigeyul.GetItemString(1, "result_date1").Length;
            //    mResultDate1 = this.dwSigeyul.GetItemString(1, "result_date1");
            //    mResultDate7 = this.dwSigeyul.GetItemString(1, "result_date7");
            //}
            //catch
            //{
            //    for (int i = 0; i < this.grdSigeyul.RowCount; i++)
            //    {
            //        //this.grdSigeyul.SetItemValue(i, "gubun", "0");
            //        //this.grdSigeyul.SetItemValue(i, "base_date", "");

            //        this.grdSigeyul.SetItemValue(i, "gubun", "3");
            //        this.grdSigeyul.SetItemValue(i, "base_date", mResultDate1);
            //    }
            //    SigeyulQry("post");
            //    //SigeyulQry("pre");
            //    return;
            //}

            //try
            //{
            //    int temp = this.dwSigeyul.GetItemString(1, "result_date7").Length;
            //    mResultDate7 = this.dwSigeyul.GetItemString(1, "result_date7");
            //    mResultDate1 = this.dwSigeyul.GetItemString(1, "result_date1");
            //}
            //catch
            //{
            //    return;
            //}

            //for (int i = 0; i < this.grdSigeyul.RowCount; i++)
            //{
            //    this.grdSigeyul.SetItemValue(i, "gubun", "2");
            //    this.grdSigeyul.SetItemValue(i, "base_date", this.dwSigeyul.GetItemString(i + 1, "result_date7"));
            //}
            //SigeyulQry("post");
        }
        #endregion

        #region 프린트 버튼 클릭
        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            //if (dw_print.RowCount > 0)
            //{
            //    dw_print.Print();
            //}
        }
        #endregion

        #region 체크박스 체크 체인지
        private void rbxJubsuYN_CheckedChanged(object sender, System.EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region 조회버튼 클릭
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            if (e.Func == FunctionType.Query)
            {
                BaseQuery();
            }
        }
        #endregion


        #region Apply multi-languages
        public void ApplyMultilanguagePrintSigeyulDW()
        {
            //try
            //{
            //    //dw_print_sigeyul
            //    dw_print.Refresh();
            //    dw_print.Modify(string.Format("t_3.text = '{0}'", Properties.Resource.DW_TXT_44));
            //    dw_print.Modify(string.Format("t_4.text = '{0}'", Properties.Resource.DW_TXT_45));
            //    dw_print.Modify(string.Format("t_7.text = '{0}'", Properties.Resource.DW_TXT_46));
            //    dw_print.Modify(string.Format("t_5.text = '{0}'", Properties.Resource.DW_TXT_47));
            //    dw_print.Modify(string.Format("t_2.text = '{0}'", Properties.Resource.DW_TXT_48));
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public void ApplyMultilanguageSigeyulDW()
        {
            //try
            //{
            //    //dwSigeyul
            //    dwSigeyul.Refresh();
            //    dwSigeyul.Modify(string.Format("t_2.text = '{0}'", Resource.DW_TXT_42));
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        #endregion


        #region DzungTA modify
        private bool GetJubsuSigeyulData2()
        {
            string o_jubsu_date = "";
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

            CPL0000Q00FrmSigeyulDelCplTempArgs delCtempArgs = new CPL0000Q00FrmSigeyulDelCplTempArgs();
            delCtempArgs.UserId = UserInfo.UserID;
            UpdateResult delResult = CloudService.Instance.Submit<UpdateResult, CPL0000Q00FrmSigeyulDelCplTempArgs>(delCtempArgs);

            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {
                CPL0000Q00InsertCPLTEMPArgs insCtempArgs = new CPL0000Q00InsertCPLTEMPArgs();
                insCtempArgs.HangmogCode = this.grdSigeyul.GetItemString(i, "hangmog_code");
                insCtempArgs.I = i.ToString();
                insCtempArgs.UserId = UserInfo.UserID;
                UpdateResult insResult = CloudService.Instance.Submit<UpdateResult, CPL0000Q00InsertCPLTEMPArgs>(insCtempArgs);
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
                    DataTable dt = QuerySigeyul(t_base_date, i);
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

                        DataTable dt2 = QuerySigeyul2(i, t_hangmog_code, o_jubsu_date, o_jubsu_time);

                        if (Service.ErrCode != 0)
                        { }
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
                    DataTable dt = QuerySigeyul(t_base_date, i);
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

                        DataTable dt2 = QuerySigeyul2(i, t_hangmog_code, o_jubsu_date, o_jubsu_time);

                        if (Service.ErrCode != 0)
                        { }
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
                    DataTable dt = QuerySigeyul(t_base_date, i);
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

                        DataTable dt2 = QuerySigeyul2(i, t_hangmog_code, o_jubsu_date, o_jubsu_time);

                        if (Service.ErrCode != 0)
                        { }
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
            }
            return true;
        }

        private bool GetPreJubsuSigeyulData2()
        {
            string o_jubsu_date = "";
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

            CPL0000Q00FrmSigeyulDelCplTempArgs delCtempArgs = new CPL0000Q00FrmSigeyulDelCplTempArgs();
            delCtempArgs.UserId = UserInfo.UserID;
            UpdateResult delResult = CloudService.Instance.Submit<UpdateResult, CPL0000Q00FrmSigeyulDelCplTempArgs>(delCtempArgs);

            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {

                CPL0000Q00InsertCPLTEMPArgs insCtempArgs = new CPL0000Q00InsertCPLTEMPArgs();
                insCtempArgs.HangmogCode = this.grdSigeyul.GetItemString(i, "hangmog_code");
                insCtempArgs.I = i.ToString();
                insCtempArgs.UserId = UserInfo.UserID;
                UpdateResult insResult = CloudService.Instance.Submit<UpdateResult, CPL0000Q00InsertCPLTEMPArgs>(insCtempArgs);
            }

            this.laySigeyul.Reset();

            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {
                int rowNum = this.laySigeyul.InsertRow(i);

                t_hangmog_code = this.grdSigeyul.GetItemString(i, "hangmog_code");
                t_base_date = this.grdSigeyul.GetItemString(i, "base_date");

                this.laySigeyul.SetItemValue(rowNum, "gumsa_name", this.grdSigeyul.GetItemString(i, "hangmog_name"));

                if (this.grdSigeyul.GetItemString(i, "gubun") == "0")
                {
                    DataTable dt = QuerySigeyul(t_base_date, i);

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

                        DataTable dt2 = QuerySigeyul2(i, t_hangmog_code, o_jubsu_date, o_jubsu_time);

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
                else if (this.grdSigeyul.GetItemString(i, "gubun") == "1") //pre
                {
                    DataTable dt = QuerySigeyul(t_base_date, i);

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

                        DataTable dt2 = QuerySigeyul2(i, t_hangmog_code, o_jubsu_date, o_jubsu_time);

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
                else if (this.grdSigeyul.GetItemString(i, "gubun") == "2")// post
                {
                    DataTable dt = QuerySigeyul(t_base_date, i);

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

                        DataTable dt2 = QuerySigeyul2(i, t_hangmog_code, o_jubsu_date, o_jubsu_time);

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
                else //결과조회없을 때 앞으로 돌아갈때 조회조건에 = 추가 나머지 2와 똑같음
                {
                    DataTable dt = QuerySigeyul(t_base_date, i);

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

                        DataTable dt2 = QuerySigeyul2(i, t_hangmog_code, o_jubsu_date, o_jubsu_time);

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
            }
            return true;
        }

        private DataTable QuerySigeyul2(int i, string t_hangmog_code, string o_jubsu_date,
            string o_jubsu_time)
        {
            CPL0000Q00GetSigeyulDataSelect2Args sigeyulDataSelect2Args = new CPL0000Q00GetSigeyulDataSelect2Args();
            sigeyulDataSelect2Args.Bunho = this.grdSigeyul.GetItemString(i, "bunho");
            sigeyulDataSelect2Args.HangmogCode = t_hangmog_code;
            sigeyulDataSelect2Args.JubsuDate = o_jubsu_date;
            sigeyulDataSelect2Args.JubsuTime = o_jubsu_time;
            CPL0000Q00GetSigeyulDataSelect2Result sigeyulDataSelect2Result =
                CloudService.Instance.Submit<CPL0000Q00GetSigeyulDataSelect2Result, CPL0000Q00GetSigeyulDataSelect2Args>(
                    sigeyulDataSelect2Args);
            DataTable dt2_ = new DataTable();
            dt2_.Columns.Add("cpl_result", typeof(string));
            dt2_.Columns.Add("standard_yn", typeof(string));
            dt2_.Columns.Add("gumsa_name", typeof(string));
            dt2_.Columns.Add("from_standard", typeof(string));
            dt2_.Columns.Add("to_standard", typeof(string));
            if (sigeyulDataSelect2Result != null)
            {
                foreach (CPL0000Q00GetSigeyulDataSelect2ListItemInfo item in sigeyulDataSelect2Result.ResultList)
                {
                    DataRow dr = dt2_.NewRow();
                    dr["cpl_result"] = item.CplResult;
                    dr["standard_yn"] = item.StandardYn;
                    dr["gumsa_name"] = item.GumsaName;
                    dr["from_standard"] = item.FromStandard;
                    dr["to_standard"] = item.ToStandard;
                    dt2_.Rows.Add(dr);
                }
            }
            return dt2_;
        }

        private DataTable QuerySigeyul(string t_base_date, int i)
        {
            CPL0000Q00FrmGraphGetSigeyulArgs getSigeyulArgs = new CPL0000Q00FrmGraphGetSigeyulArgs();
            getSigeyulArgs.BaseDate = t_base_date;
            getSigeyulArgs.Bunho = this.grdSigeyul.GetItemString(i, "bunho");
            getSigeyulArgs.ConditionValue = this.grdSigeyul.GetItemString(i, "gubun");
            getSigeyulArgs.UserId = UserInfo.UserID;
            CPL0000Q00FrmGraphGetSigeyulResult getSigeyulResult =
                CloudService.Instance
                    .Submit<CPL0000Q00FrmGraphGetSigeyulResult, CPL0000Q00FrmGraphGetSigeyulArgs>(getSigeyulArgs);
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("jubsu_date", typeof(string));
            dt1.Columns.Add("jubsu_time", typeof(string));
            dt1.Columns.Add("jubsu_time2", typeof(string));
            if (getSigeyulResult != null)
            {
                foreach (CPL0000Q00GetSigeyulDataSelect1ListItemInfo item in getSigeyulResult.ResultList)
                {
                    DataRow dr = dt1.NewRow();
                    dr["jubsu_date"] = item.JubsuDate;
                    dr["jubsu_time"] = item.JubsuTime;
                    dr["jubsu_time2"] = item.JubsuTime2;
                    dt1.Rows.Add(dr);
                }
            }
            return dt1;
        }

        #endregion
    }
}
