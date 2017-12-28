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
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.Framework;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using IHIS.XRTS.Properties;
using IHIS.CloudConnector.Contracts.Results;
#endregion

namespace IHIS.XRTS
{
    /// <summary>
    /// XRT0000Q00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class XRT0000Q00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.MultiLayout layOrderList;
        private IHIS.Framework.XButtonList btnList;
  //      private IHIS.Framework.XDataWindow dwOrderList;
        private IHIS.Framework.XTabControl tabOrder;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private IHIS.Framework.XButton btnRequest;
        private IHIS.Framework.MultiLayout layMakeTabPage;
        private IHIS.Framework.XButton btnPacs;
        private IHIS.Framework.XButton btnAngioLoad;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayout layPacsInfo;
        private XPanel xPanel4;
        private XPanel xPanel5;
        private XLabel xLabel4;
        private XLabel xLabel2;
        private XLabel xLabel1;
        private XComboBox xcboOption;
        private XDatePicker xdpXrayDate;
        private XDatePicker xdpXrayDateTo;
        private Label label1;
        private XDatePicker xdpXrayDateFrom;
        private XRadioButton xrdbXrayDateFromTo;
        private XRadioButton xrdbXrayDate;
        private XRadioButton xrdbXrayDateNot;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
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
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
        private XButton btnPacsShutdown;
        private XButton btnPacsClose;
        private XComboItem xComboItem3;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public XRT0000Q00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            BindExecuteQueryMethod();
            
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT0000Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.btnPacsShutdown = new IHIS.Framework.XButton();
            this.btnPacsClose = new IHIS.Framework.XButton();
            this.xrdbXrayDateNot = new IHIS.Framework.XRadioButton();
            this.xrdbXrayDateFromTo = new IHIS.Framework.XRadioButton();
            this.xrdbXrayDate = new IHIS.Framework.XRadioButton();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xcboOption = new IHIS.Framework.XComboBox();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xdpXrayDate = new IHIS.Framework.XDatePicker();
            this.xdpXrayDateTo = new IHIS.Framework.XDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.xdpXrayDateFrom = new IHIS.Framework.XDatePicker();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.tabOrder = new IHIS.Framework.XTabControl();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnAngioLoad = new IHIS.Framework.XButton();
            this.btnRequest = new IHIS.Framework.XButton();
            this.btnPacs = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.layOrderList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.layMakeTabPage = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.layPacsInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMakeTabPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPacsInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.rb2);
            this.xPanel1.Controls.Add(this.rb1);
            this.xPanel1.Controls.Add(this.tabOrder);
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.xPanel5);
            this.xPanel4.Name = "xPanel4";
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.btnPacsShutdown);
            this.xPanel5.Controls.Add(this.btnPacsClose);
            this.xPanel5.Controls.Add(this.xrdbXrayDateNot);
            this.xPanel5.Controls.Add(this.xrdbXrayDateFromTo);
            this.xPanel5.Controls.Add(this.xrdbXrayDate);
            this.xPanel5.Controls.Add(this.xLabel4);
            this.xPanel5.Controls.Add(this.xLabel2);
            this.xPanel5.Controls.Add(this.xLabel1);
            this.xPanel5.Controls.Add(this.xcboOption);
            this.xPanel5.Controls.Add(this.xdpXrayDate);
            this.xPanel5.Controls.Add(this.xdpXrayDateTo);
            this.xPanel5.Controls.Add(this.label1);
            this.xPanel5.Controls.Add(this.xdpXrayDateFrom);
            this.xPanel5.Name = "xPanel5";
            // 
            // btnPacsShutdown
            // 
            resources.ApplyResources(this.btnPacsShutdown, "btnPacsShutdown");
            this.btnPacsShutdown.Name = "btnPacsShutdown";
            // 
            // btnPacsClose
            // 
            resources.ApplyResources(this.btnPacsClose, "btnPacsClose");
            this.btnPacsClose.Name = "btnPacsClose";
            // 
            // xrdbXrayDateNot
            // 
            resources.ApplyResources(this.xrdbXrayDateNot, "xrdbXrayDateNot");
            this.xrdbXrayDateNot.BackColor = IHIS.Framework.XColor.XProgressBarGradientStartColor;
            this.xrdbXrayDateNot.Checked = true;
            this.xrdbXrayDateNot.Name = "xrdbXrayDateNot";
            this.xrdbXrayDateNot.TabStop = true;
            this.xrdbXrayDateNot.UseVisualStyleBackColor = false;
            this.xrdbXrayDateNot.CheckedChanged += new System.EventHandler(this.xrdbXrayDateNot_CheckedChanged);
            // 
            // xrdbXrayDateFromTo
            // 
            resources.ApplyResources(this.xrdbXrayDateFromTo, "xrdbXrayDateFromTo");
            this.xrdbXrayDateFromTo.Name = "xrdbXrayDateFromTo";
            this.xrdbXrayDateFromTo.UseVisualStyleBackColor = true;
            this.xrdbXrayDateFromTo.CheckedChanged += new System.EventHandler(this.xrdbXrayDateFromTo_CheckedChanged);
            // 
            // xrdbXrayDate
            // 
            resources.ApplyResources(this.xrdbXrayDate, "xrdbXrayDate");
            this.xrdbXrayDate.Name = "xrdbXrayDate";
            this.xrdbXrayDate.UseVisualStyleBackColor = true;
            this.xrdbXrayDate.CheckedChanged += new System.EventHandler(this.xrdbXrayDate_CheckedChanged);
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // xcboOption
            // 
            resources.ApplyResources(this.xcboOption, "xcboOption");
            this.xcboOption.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem1,
            this.xComboItem2});
            this.xcboOption.Name = "xcboOption";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "N";
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "C";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "S";
            // 
            // xdpXrayDate
            // 
            resources.ApplyResources(this.xdpXrayDate, "xdpXrayDate");
            this.xdpXrayDate.IsVietnameseYearType = false;
            this.xdpXrayDate.Name = "xdpXrayDate";
            this.xdpXrayDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xdpXrayDate_DataValidating);
            // 
            // xdpXrayDateTo
            // 
            resources.ApplyResources(this.xdpXrayDateTo, "xdpXrayDateTo");
            this.xdpXrayDateTo.IsVietnameseYearType = false;
            this.xdpXrayDateTo.Name = "xdpXrayDateTo";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Name = "label1";
            // 
            // xdpXrayDateFrom
            // 
            resources.ApplyResources(this.xdpXrayDateFrom, "xdpXrayDateFrom");
            this.xdpXrayDateFrom.IsVietnameseYearType = false;
            this.xdpXrayDateFrom.Name = "xdpXrayDateFrom";
            // 
            // rb2
            // 
            resources.ApplyResources(this.rb2, "rb2");
            this.rb2.Checked = true;
            this.rb2.ForeColor = System.Drawing.Color.Blue;
            this.rb2.Name = "rb2";
            this.rb2.TabStop = true;
            this.rb2.Click += new System.EventHandler(this.rb2_Click);
            // 
            // rb1
            // 
            resources.ApplyResources(this.rb1, "rb1");
            this.rb1.ForeColor = System.Drawing.Color.Blue;
            this.rb1.Name = "rb1";
            this.rb1.Click += new System.EventHandler(this.rb1_Click);
            // 
            // tabOrder
            // 
            resources.ApplyResources(this.tabOrder, "tabOrder");
            this.tabOrder.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabOrder.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabOrder.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabOrder.IDEPixelArea = true;
            this.tabOrder.IDEPixelBorder = false;
            this.tabOrder.ImageList = this.ImageList;
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.ShowClose = false;
            this.tabOrder.TextColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabOrder.SelectionChanged += new System.EventHandler(this.tabOrder_SelectionChanged);
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.btnAngioLoad);
            this.xPanel2.Controls.Add(this.btnRequest);
            this.xPanel2.Controls.Add(this.btnPacs);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnAngioLoad
            // 
            resources.ApplyResources(this.btnAngioLoad, "btnAngioLoad");
            this.btnAngioLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnAngioLoad.Image")));
            this.btnAngioLoad.Name = "btnAngioLoad";
            this.btnAngioLoad.Click += new System.EventHandler(this.btnAngioLoad_Click);
            // 
            // btnRequest
            // 
            resources.ApplyResources(this.btnRequest, "btnRequest");
            this.btnRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.btnRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnRequest.Image")));
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnPacs
            // 
            resources.ApplyResources(this.btnPacs, "btnPacs");
            this.btnPacs.Image = ((System.Drawing.Image)(resources.GetObject("btnPacs.Image")));
            this.btnPacs.Name = "btnPacs";
            this.btnPacs.Click += new System.EventHandler(this.btnPacs_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // layOrderList
            // 
            this.layOrderList.ExecuteQuery = null;
            this.layOrderList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem25,
            this.multiLayoutItem26,
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
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53});
            this.layOrderList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderList.ParamList")));
            this.layOrderList.QuerySQL = resources.GetString("layOrderList.QuerySQL");
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "bunho";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "order_date";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "in_out_gubun";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "gwa";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "doctor";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "doctor_name";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "pandok_date";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "hangmog_code";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "hangmog_name";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "pandok_serial";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "gwa_name";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "chk";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "fkocs1003";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "fkocs2003";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "pacs_yn";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "pandok_status";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "portable_yn2";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "pandok_request";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "xray_date";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "act_date";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "ho_dong";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "ho_code";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "gumsa_mokjuk";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "xray_gubun";
            // 
            // layMakeTabPage
            // 
            this.layMakeTabPage.ExecuteQuery = null;
            this.layMakeTabPage.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3});
            this.layMakeTabPage.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layMakeTabPage.ParamList")));
            this.layMakeTabPage.QuerySQL = "SELECT \'%\', \'全体\', -1 FROM DUAL UNION ALL\r\nSELECT CODE2, CODE_NAME, SEQ \r\n  FROM X" +
    "RT0102 \r\n WHERE HOSP_CODE = fn_adm_load_hosp_code()\r\n    AND CODE_TYPE = \'X1\' AN" +
    "D CODE2 <> \'N\' ORDER BY 3";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "ment";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "sort";
            // 
            // layPacsInfo
            // 
            this.layPacsInfo.ExecuteQuery = null;
            this.layPacsInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29});
            this.layPacsInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPacsInfo.ParamList")));
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "code";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "code_name";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "code_value";
            // 
            // XRT0000Q00
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "XRT0000Q00";
            this.UserChanged += new System.EventHandler(this.XRT0000Q00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.XRT0000Q00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            this.xPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMakeTabPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPacsInfo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Onload
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(rc.Width - 45, rc.Height - 120);
            ApplyMultilanguageDW();
        }
        #endregion

        #region btnList
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    {
                        e.IsBaseCall = false;
                        this.OrderListQuery();
                        break;
                    }
            }
        }
        #endregion

        #region Order List Query
        private void OrderListQuery()
        {
            string bunho;
            bunho = paBox.BunHo;
            if (bunho == "") return;
   //         this.dwOrderList.Reset();
            this.layOrderList.Reset();
            this.tabOrder.SelectionChanged -= new System.EventHandler(this.tabOrder_SelectionChanged);
            this.tabOrder.SelectedIndex = 0;
            this.tabOrder.SelectionChanged += new System.EventHandler(this.tabOrder_SelectionChanged);

            this.layOrderList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layOrderList.SetBindVarValue("f_bunho", bunho);
            this.layOrderList.SetBindVarValue("f_jundal_part", "%");
            this.layOrderList.SetBindVarValue("f_sort", (rb1.Checked ? "2" : "1"));


            if (this.layOrderList.QueryLayout(true))
            {
                this.SetTabColor();
   //             this.dwOrderList.FillData(layOrderList.LayoutTable);
    //            this.dwOrderList.Refresh();
            }
            else
            {
                MessageBox.Show(Service.ErrFullMsg);
            }

        }
        private void SetTabColor()
        {
            /// <summary>
            /// 화면안에 있는 텝페이지의 글자색 초기화.
            /// </summary>
            for (int i = 0; i < tabOrder.TabPages.Count; i++)
            {
                tabOrder.TabPages[i].ImageIndex = -1;
            }

            for (int i = 0; i < layOrderList.RowCount; i++)
            {
                tabOrder.TabPages[0].ImageIndex = 0;

                for (int j = 0; j < tabOrder.TabPages.Count; j++)
                {
                    if (layOrderList.GetItemString(i, "xray_gubun") == tabOrder.TabPages[j].Tag.ToString())
                        tabOrder.TabPages[j].ImageIndex = 0;
                }
            }
        }
        #endregion

        #region [dwOrderList EVENT]
        private void dwOrderList_Click(object sender, System.EventArgs e)
        {
   //         try
   //         {
   //             int row = dwOrderList.ObjectUnderMouse.RowNumber;
   //             //string curVal = dwOrderList.GetItemString(row, "chk");

   //             //for (int i=1; i<=dwOrderList.RowCount; i++)
   //             //{
   //             //    if (curVal == "N")
   //             //    {
   //             //        if (i == row)
   //             //            this.dwOrderList.SetItemString(row, "chk", "Y");
   //             //        else
   //             //            this.dwOrderList.SetItemString(row, "chk", "N");
   //             //    }
   //             //}

   //             //XMessageBox.Show(row.ToString());

   // //            dwOrderList.Refresh();
   ////             this.dwOrderList.SetRow(row);
   //         }
   //         catch { }
        }

        private void dwOrderList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            //dwOrderList.Refresh();
            //DateTime dt_tmp = DateTime.Now;
            //if (DateTime.TryParse(this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "order_date"),out dt_tmp))
            //{
            //    this.xdpXrayDate.SetDataValue(this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "order_date"));
            //}            
        }
        #endregion

        #region Tab Select
        private void tabOrder_SelectionChanged(object sender, System.EventArgs e)
        {
            this.layOrderList.SetBindVarValue("f_bunho", paBox.BunHo);

            layOrderList.SetBindVarValue("f_jundal_part", tabOrder.SelectedTab.Tag.ToString());

            layOrderList.SetBindVarValue("f_sort", (rb1.Checked ? "2" : "1"));

            layOrderList.Reset();
            if (layOrderList.QueryLayout(true))
            {
                //dwOrderList.Reset();
                //dwOrderList.FillData(layOrderList.LayoutTable);
                //dwOrderList.Refresh();
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
        }
        #endregion

        #region dw
        private string dwGetString(XDataWindow dw, int row, string colNm)
        {
            if (!dw.IsItemNull(row, colNm))
                return dw.GetItemString(row, colNm);
            return " ";
        }
        #endregion

        #region [paBox_PatientSelected 患者選択]
        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            this.OrderListQuery();

            // PACS呼出
            this.btnPacs.PerformClick();
        }
        #endregion

        #region 스크린 오픈
        private void XRT0000Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            //hide control
            xLabel2.Visible = false;
            xdpXrayDateFrom.Visible = false;
            label1.Visible = false;
            xdpXrayDateTo.Visible = false;
            btnPacsClose.Visible = false;
            btnPacsShutdown.Visible = false;
            xLabel4.Visible = false;
            xcboOption.Visible = false;
            xrdbXrayDateFromTo.Visible = false;
            this.MakeTabPage();

            if (this.OpenParam != null)
            {
                this.paBox.SetPatientID(e.OpenParam["bunho"].ToString());

                this.xdpXrayDate.SetDataValue(e.OpenParam["naewon_date"].ToString());
            }
            else
            {
                // 이전 스크린의 등록번호를 가져온다
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                {
                    this.paBox.Focus();
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
                else
                {
                    //paBox.SetPatientID("000400017");
                }
            }

            this.xdpXrayDate.SetDataValue(EnvironInfo.GetSysDate());
            this.xdpXrayDateFrom.SetDataValue(EnvironInfo.GetSysDate());
            this.xdpXrayDateTo.SetDataValue(EnvironInfo.GetSysDate());

            this.xcboOption.SelectedIndex = 0;

            this.OrderListQuery();



        }
        #endregion

        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                this.paBox.Focus();
                this.paBox.SetPatientID(info.BunHo);
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo))
            {
                return new XPatientInfo(this.paBox.BunHo, "", "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

        #region 유저체인지
        private void XRT0000Q00_UserChanged(object sender, System.EventArgs e)
        {
            this.OnLoad(e);
        }
        #endregion

        #region 체크/언체크 처리
        private void rb1_Click(object sender, System.EventArgs e)
        {
//            dwOrderList.Modify("panm_t.text  = '" + Resources.dwOrderListText1 + "'");
//            dwOrderList.Modify("t_4.text  = '" + Resources.dwOrderListText2 + "'");
            OrderListQuery();
        }

        private void rb2_Click(object sender, System.EventArgs e)
        {
 //           dwOrderList.Modify("panm_t.text  = '" + Resources.dwOrderListText3 + "'");
 //           dwOrderList.Modify("t_4.text  = '" + Resources.dwOrderListText4 + "'");
            OrderListQuery();
        }
        #endregion

        #region 텝페이지 자동 생성
        private void MakeTabPage()
        {
            layMakeTabPage.QueryLayout(true);

            // 텝 페이지 생성시 첫번째 페이지가 선택된것으로 간주된다.
            // 따라서 전체조회가 되므로 잠시 이벤트를 없애놓음
            this.tabOrder.SelectionChanged -= new System.EventHandler(this.tabOrder_SelectionChanged);

            // 텝 페이지 생성
            for (int i = 0; i < layMakeTabPage.RowCount; i++)
            {
                IHIS.X.Magic.Controls.TabPage tabPage =
                    new IHIS.X.Magic.Controls.TabPage(layMakeTabPage.GetItemString(i, "ment"));
                tabPage.Tag = layMakeTabPage.GetItemString(i, "code");
                tabOrder.TabPages.Add(tabPage);
            }

            this.tabOrder.SelectionChanged += new System.EventHandler(this.tabOrder_SelectionChanged);
        }
        #endregion

        #region 독영조회화면 오픈
        private void btnRequest_Click(object sender, System.EventArgs e)
        {
            if (layOrderList.RowCount == 0) return;

            // 인터페이스 정보 가져오기
    //        int row = dwOrderList.CurrentRow - 1;
            int row = 1;
            string bunho = this.paBox.BunHo.ToString();
            string fkocs = "";
            string in_out_gubun = layOrderList.GetItemString(row, "in_out_gubun");
            if (in_out_gubun == "I")
                fkocs = layOrderList.GetItemString(row, "fkocs2003");
            else
                fkocs = layOrderList.GetItemString(row, "fkocs1003");

            //기존에 디렉토리가 존재하지 않는다면 만들어줌
            string path = @"C:\AOCClients";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path = @"C:\PACS_INI";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string command = @"C:\AOCClients\AOCReportView.exe";

            if (!File.Exists(command))
            {
                string msg = (NetInfo.Language == LangMode.Ko ? Resources.msg_Ko
                    : Resources.msg_JP);
                string cap = (NetInfo.Language == LangMode.Ko ? Resources.cap_Ko
                    : Resources.cap_JP);

                XMessageBox.Show(msg, cap);
                return;
            }

            string filename = @"C:\PACS_INI\Doku_query.ini";

            string patientid = bunho.Substring(1); //번호
            string accession = "9" + fkocs; //ocskey 앞에 9 붙이기
            string studydt1 = EnvironInfo.GetSysDate().AddDays(-30).ToString("yyyyMMdd");  //한달전
            string studydt2 = EnvironInfo.GetSysDate().ToString("yyyyMMdd");  //오늘일자
            string userid = UserInfo.UserID;

            Kernel32.SetProfileString(filename, "SearchKey", "PatientID", patientid);
            Kernel32.SetProfileString(filename, "SearchKey", "StudyDate1", studydt1);
            Kernel32.SetProfileString(filename, "SearchKey", "StudyDate2", studydt2);
            Kernel32.SetProfileString(filename, "SearchKey", "AccessionNumber", accession);

            Kernel32.SetProfileString(filename, "LoginUser", "UserID", userid);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = filename;

            process.Start();
        }
        #endregion

        #region 팍스콜
        private void btnPacs_Click(object sender, System.EventArgs e)
        {
            // Process Kill
            this.pacsProcKill();

            // 現在、con3、con6　のみ使用する。

            //if (this.tabOrder.SelectedTab.Tag.ToString().Equals("%"))
            //{
   //         if (this.dwOrderList.RowCount == 0)
            if (this.layOrderList.RowCount == 0)
            {
                if (this.xrdbXrayDateNot.Checked)
                {
                    //this.viewPacsInfo("con2");
                    viewPacsInfoLocal();
                }

                if (this.xrdbXrayDate.Checked)
                {
                    //this.viewPacsInfo("con3");
                    viewPacsInfoLocal();
                }

                if (this.xrdbXrayDateFromTo.Checked)
                {
                    //this.viewPacsInfo("con4");
                    viewPacsInfoLocal();
                }
            }
            else
            {
                if (this.xrdbXrayDateNot.Checked)
                {
                    //this.viewPacsInfo("con5");
                    viewPacsInfoLocal();
                }

                if (this.xrdbXrayDate.Checked)
                {
                    //this.viewPacsInfo("con6");
                    viewPacsInfoLocal();
                }

                if (this.xrdbXrayDateFromTo.Checked)
                {
                    //this.viewPacsInfo("con7");
                    viewPacsInfoLocal();
                }
            }
        }

        private void pacsProcKill()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.StartsWith("PacsClientApplication"))
                {
                    proc.Kill();
                }
            }
        }
        private void viewPacsInfoLocal()
        {

            string argements = null;

            string vw_exe_path = null;
            string param_app = null;
            string param_uname = null;
            string param_pass = null;
            string param_pid = null;

            this.layPacsInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                                            FROM XRT0102
                                           WHERE HOSP_CODE = :f_hosp_code
                                             AND CODE_TYPE = 'PACS_INFO'
                                        ORDER BY SEQ";

            this.layPacsInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            try
            {

                Process process = new Process();

                ProcessStartInfo startInfo = new ProcessStartInfo();

                //if (this.layPacsInfo.QueryLayout(true))
                //{
                //    for (int i = 0; i < this.layPacsInfo.RowCount; i++)
                //    {
                //        if (this.layPacsInfo.GetItemString(i, "code_name").Equals("VW_EXE_PATH")) vw_exe_path = layPacsInfo.GetItemString(i, "code_value");

                //        if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_APP")) param_app = layPacsInfo.GetItemString(i, "code_value");

                //        if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_UNAME")) param_uname = layPacsInfo.GetItemString(i, "code_value");

                //        if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_PASS")) param_pass = layPacsInfo.GetItemString(i, "code_value");

                //        if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_PID")) param_pid = layPacsInfo.GetItemString(i, "code_value");
                //    }
                //}

                //argements = "\"" + param_app + param_uname + UserInfo.UserID + param_pass + param_pid + paBox.BunHo + "\"";

                string link = "";
                XRT0201U00LoadLinkArgs args = new XRT0201U00LoadLinkArgs();
                args.Bunho = paBox.BunHo;
                DateTime dt_tmp = DateTime.Now;
                //if (DateTime.TryParse(this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "order_date"),out dt_tmp))
                //{
                //    args.Date = DateTime.Parse(this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "order_date")).ToString("yyyyMMdd");
                //}
                //else
                //{
                    args.Date = "%";
                //}                
                args.Client = System.Environment.MachineName;
                XRT0201U00LoadLinkResult result = CloudService.Instance.Submit<XRT0201U00LoadLinkResult, XRT0201U00LoadLinkArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    link = result.Link;
                    //open link
                    if (!string.IsNullOrEmpty(link) && link.Length > 0)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(link);
                        }
                        catch (Exception ex)
                        {
                            Service.WriteLog(ex.ToString());
                        }

                    }

                }
                

                ////startInfo.FileName = "cmd.exe";

                //startInfo.FileName = vw_exe_path;
                //startInfo.Arguments = link;


                //startInfo.UseShellExecute = false;
                //startInfo.RedirectStandardInput = true;
                //startInfo.RedirectStandardOutput = true;
                //startInfo.RedirectStandardError = true;
                //startInfo.WindowStyle = ProcessWindowStyle.Maximized;

                //process.EnableRaisingEvents = false;



                //process.StartInfo = startInfo;

                //process.Start();

                //process.Close();

                // 画面を閉じる。
                //this.btnList.PerformClick(FunctionType.Close);
            }
            catch (Exception ex)
            {
                if (ex.Message == "The system cannot find the file specified")
                {
                    SetErrMsg(Resources.XMessageBox6);
                }
                else
                {
                    this.SetErrMsg(ex.Message);
                }
            }
        }

        private void viewPacsInfo(string condition)
        {
            if (paBox.BunHo == "")
            {
                XMessageBox.Show(Resources.XMessageBox1, Resources.XMessageBox_Caption1, MessageBoxIcon.Information);
                return;
            }
            
            string viewer_ip = null;
            string vw_fd_nm = null;
            string vw_exe_nm = null;
            string param_app = null;
            string param_uname = null;
            string param_pass = null;
            string param_pid = null;
            string param_acceptno = null;
            string param_stdate = null;
            string param_stdatefrom = null;
            string param_stdateto = null;
            string param_modality = null;
            string param_oprt = null;

            // PACS_VIEWER情報取得
            this.layPacsInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                                            FROM XRT0102
                                           WHERE HOSP_CODE = :f_hosp_code
                                             AND CODE_TYPE = 'PACS_INFO'
                                        ORDER BY SEQ";

            this.layPacsInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (this.layPacsInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.layPacsInfo.RowCount; i++)
                {
                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("VIEWER_IP")) viewer_ip = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("VW_FD_NM")) vw_fd_nm = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("VW_EXE_NM")) vw_exe_nm = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_APP")) param_app = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_UNAME")) param_uname = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_PASS")) param_pass = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_PID")) param_pid = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_ACCEPTNO")) param_acceptno = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_STDATE")) param_stdate = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_STDATEFROM")) param_stdatefrom = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_STDATETO")) param_stdateto = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_MODALITY")) param_modality = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_OPRT")) param_oprt = layPacsInfo.GetItemString(i, "code_value");
                }
            }

            string pid = pid = this.paBox.BunHo;
            string acceptno = null;
            string userid = UserInfo.UserID;
            string stdate = null;
            string stdatefrom = null;
            string stdateto = null;
            string modality = null;
            //string modality = this.isSelectedModality();
            string oprt = null;

            string targetUrl = "";

            try
            {
                // 患者番号、PKOCS
                if (condition.Equals("con1"))
                {
                    //acceptno = dwOrderList.GetItemString(dwOrderList.ObjectUnderMouse.RowNumber, "chk");

   //                 int row = dwOrderList.CurrentRow - 1;
                    int row = 1;
                    string in_out_gubun = layOrderList.GetItemString(row, "in_out_gubun");
                    if (in_out_gubun == "I")
                        acceptno = layOrderList.GetItemString(row, "fkocs2003");
                    else
                        acceptno = layOrderList.GetItemString(row, "fkocs1003");

                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    param_pid + pid + param_acceptno + acceptno;
                }

                // 患者番号
                if (condition.Equals("con2"))
                {
                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    param_pid + pid;
                }

                // 患者番号、撮影日付
                if (condition.Equals("con3"))
                {
                    stdate = this.xdpXrayDate.GetDataValue().Replace("/", "");

                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    param_pid + pid + param_stdate + stdate;
                }

                // 患者番号、撮影日付FROM、撮影日付TO
                if (condition.Equals("con4"))
                {
                    stdatefrom = this.xdpXrayDateFrom.GetDataValue().Replace("/", "");
                    stdateto = this.xdpXrayDateTo.GetDataValue().Replace("/", "");

                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    param_pid + pid + param_stdatefrom + stdatefrom + param_stdateto + stdateto;
                }

                // 患者番号、モダリティ
                if (condition.Equals("con5"))
                {
 //                   modality = this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "xray_gubun");

                    //targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    //param_pid + pid + param_modality + modality;

                    // 2013/09/14
                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    param_pid + pid;
                }

                // 患者番号、撮影日付、モダリティ
                if (condition.Equals("con6"))
                {
                    //stdate = this.xdpXrayDate.GetDataValue().Replace("/", "");
 //                   stdate = this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "act_date").Replace("/", "");
                    //modality = this.getModalityCode(this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "hangmog_code"));
 //                   modality = this.getModalityCode2(this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "hangmog_code"));

                    //targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    //param_pid + pid + param_stdate + stdate + param_modality + modality;

                    // 2013/09/14
                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    param_pid + pid + param_stdate + stdate;
                }

                // 患者番号、撮影日付FROM、撮影日付TO、モダリティ
                if (condition.Equals("con7"))
                {
                    stdatefrom = this.xdpXrayDateFrom.GetDataValue().Replace("/", "");
                    stdateto = this.xdpXrayDateTo.GetDataValue().Replace("/", "");
                    //modality = this.getModalityCode(this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "hangmog_code"));
 //                   modality = this.getModalityCode2(this.layOrderList.GetItemString(this.dwOrderList.CurrentRow - 1, "hangmog_code"));

                    //targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    //param_pid + pid + param_stdatefrom + stdatefrom + param_stdateto + stdateto + param_modality + modality;

                    // 2013/09/14
                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    param_pid + pid + param_stdatefrom + stdatefrom + param_stdateto + stdateto;
                }

                /*
                if(this.xcboOption.GetDataValue().Equals("C"))
                {
                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    param_oprt + "close";
                }

                if (this.xcboOption.GetDataValue().Equals("S"))
                {
                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass +
                    param_oprt + "shutdown";
                }

                System.Diagnostics.Process.Start(viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass + param_oprt + "shutdown");
                */

                //XMessageBox.Show(targetUrl);

                System.Diagnostics.Process.Start(targetUrl);

                // 画面を閉じる。
                this.btnList.PerformClick(FunctionType.Close);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("[" + targetUrl + "] browser msg : " + noBrowser.Message);
            }
            catch (System.Exception other)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("[" + targetUrl + "] other msg : " + other.Message);
            }
        }
        #endregion

        #region [isSelectedModality モダリティ取得]
        private string isSelectedModality()
        {
            string rtnVal = null;
            string mo = this.tabOrder.SelectedTab.Tag.ToString();

            if (mo.Equals("%")) rtnVal = "%";

            return rtnVal;
        }
        #endregion

        #region 더블 클릭시 팍스 자동 콜
        private void dwOrderList_DoubleClick(object sender, System.EventArgs e)
        {
            // モダリティとMWMの連携が必要
            //this.viewPacsInfo("con1");
        }
        #endregion

        #region [getModalityCode] 撮影コードに該当するモダリティコードを取得する。
        private string getModalityCode(string xCode)
        {
            string rtnVal = "";

            string strCmd = "";
            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_hangmog_code", xCode);

            strCmd = @"SELECT MODALITY
                         FROM XRT0001
                        WHERE HOSP_CODE = :f_hosp_code
                          AND XRAY_CODE = :f_hangmog_code";

            object result = Service.ExecuteScalar(strCmd, bindVar);

            rtnVal = result.ToString();

            return rtnVal;
        }
        #endregion

        #region 안기오 화상 조회
        private void btnAngioLoad_Click(object sender, System.EventArgs e)
        {
            if (this.paBox.BunHo.ToString() == "")
            {
                XMessageBox.Show(Resources.XMessageBox5, Resources.cap_JP);
                return;
            }
            string bunho = this.paBox.BunHo.Substring(1);
            string target = "http://192.168.10.62/EVService/EVService.dll?clientCall&USER=hl&PASSWORD=hl&ID=" + bunho;

            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //if (noBrowser.ErrorCode == -2147467259)
                //    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(other.Message);
            }
        }
        #endregion

        #region [PACS照会条件設定ラジオボタン制御]
        private void xrdbXrayDateNot_CheckedChanged(object sender, EventArgs e)
        {
            if (this.xrdbXrayDateNot.Checked)
            {
                this.xrdbXrayDate.Checked = false;
                this.xrdbXrayDateFromTo.Checked = false;
            }
            this.OrderListQuery();
        }
        
        private void xrdbXrayDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.xrdbXrayDate.Checked)
            {
                this.xdpXrayDate.ReadOnly = false;
                this.xrdbXrayDateFromTo.Checked = false;

                this.xdpXrayDateFrom.ReadOnly = true;
                this.xdpXrayDateTo.ReadOnly = true;
            }
            else
            {
                this.xdpXrayDate.ReadOnly = true;
            }
        }

        private void xrdbXrayDateFromTo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.xrdbXrayDateFromTo.Checked)
            {
                this.xdpXrayDateFrom.ReadOnly  = false;
                this.xdpXrayDateTo.ReadOnly  = false;

                this.xrdbXrayDate.Checked = false;

                this.xdpXrayDate.ReadOnly = true;
            }
            else
            {
                this.xdpXrayDateFrom.ReadOnly = true;
                this.xdpXrayDateTo.ReadOnly = true;
            }
        }
        #endregion

        #region DzungTA modify

        private void BindExecuteQueryMethod()
        {
            this.layOrderList.ExecuteQuery = QueryLayOrderList;
            this.layMakeTabPage.ExecuteQuery = QueryLayMakeTabPage;
            this.layPacsInfo.ExecuteQuery = QueryLayPacsInfo;
        }

        private XRT0000Q00InitializeArgs initializeArgs = new XRT0000Q00InitializeArgs();

        private List<object[]> QueryLayMakeTabPage(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            initializeArgs.BunhoLayOrder = "";
            initializeArgs.JundalPartLayOrder = "";
            initializeArgs.SortLayOrder = "";
            initializeArgs.Date = "%";
            XRT0000Q00InitializeResult result = CloudService.Instance.Submit<XRT0000Q00InitializeResult,XRT0000Q00InitializeArgs>(initializeArgs);
            if (result != null)
            {
                foreach (XRT0000Q00LayMakeTabPageListItemInfo item in result.LayMakeTabPageList)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName,
                        item.Seq,
                    };
                    res.Add(objects);
                }
            }

            return res;
        }

        private List<object[]> QueryLayOrderList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            initializeArgs.BunhoLayOrder = bc["f_bunho"].VarValue;
            initializeArgs.JundalPartLayOrder = bc["f_jundal_part"].VarValue;
            initializeArgs.SortLayOrder = bc["f_sort"].VarValue;
            if (xrdbXrayDateNot.Checked == true)
            {
                initializeArgs.Date = "%";
            }
            else
            {
                initializeArgs.Date = DateTime.Parse(xdpXrayDate.GetDataValue()).ToString("yyyy/MM/dd");
            }
            XRT0000Q00InitializeResult result = CloudService.Instance.Submit<XRT0000Q00InitializeResult, XRT0000Q00InitializeArgs>(initializeArgs);
            if (result != null)
            {
                foreach (XRT0000Q00LayOrderListItemInfo item in result.LayOrderList)
                {
                    object[] objects =
                    {
                        item.Bunho,
                        item.DecodeResult,
                        item.OValue,
                        item.Gwa,
                        item.Doctor,
                        item.DoctorName,
                        item.NullValue,
                        item.HangmogCode,
                        item.HangmogName,
                        item.PandokSerial,
                        item.GwaName,
                        item.Chk,
                        item.Pkocs1003First,
                        item.Pkocs1003Second,
                        item.IfActSendYn,
                        item.PandokStatus,
                        item.PortableYn2,
                        item.PandokRequestYn,
                        item.XrayDate,
                        item.ActDate,
                        item.HoDong,
                        item.HoCode,
                        item.GumsaMokjuk,
                        item.XrayGubun,
                        item.SortDate
                    };
                    res.Add(objects);
                }
            }

            return res;
        }

        private void xdpXrayDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.OrderListQuery();
        }

        private List<object[]> QueryLayPacsInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            XRT0000Q00LayPacsInfoArgs args = new XRT0000Q00LayPacsInfoArgs();
            args.CodeType = "PACS_INFO";
            XRT0000Q00LayPacsInfoResult result = CacheService.Instance.Get<XRT0000Q00LayPacsInfoArgs, XRT0000Q00LayPacsInfoResult>(args); 

            if (result != null)
            {
                foreach (XRT0000Q00LayPacsInfoListItemInfo item in result.LayPacsInfoList)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName,
                        item.CodeValue,
                    };
                    res.Add(objects);
                }
            }

            return res;
        }

        private string getModalityCode2(string xCode)
        {
            string rtnVal = "";

//            string strCmd = "";
//            BindVarCollection bindVar = new BindVarCollection();

//            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
//            bindVar.Add("f_hangmog_code", xCode);

//            strCmd = @"SELECT MODALITY
//                         FROM XRT0001
//                        WHERE HOSP_CODE = :f_hosp_code
//                          AND XRAY_CODE = :f_hangmog_code";

//            object result = Service.ExecuteScalar(strCmd, bindVar);



            XRT0000Q00GetModalityCodeArgs args = new XRT0000Q00GetModalityCodeArgs();
            args.HangmogCode = xCode;
            XRT0000Q00GetModalityCodeResult result = CloudService.Instance.Submit<XRT0000Q00GetModalityCodeResult, XRT0000Q00GetModalityCodeArgs>(args);

            if (result != null)
            {
                rtnVal = result.Modality;
            }

            return rtnVal;
        }

        #endregion

        #region Apply multi languages
        private void ApplyMultilanguageDW()
        {
            ////dwOrderList
            //dwOrderList.Refresh();
            //dwOrderList.Modify(string.Format("panm_t.text = '{0}'", Properties.Resources.DW_TXT_1));
            //dwOrderList.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_2));
            //dwOrderList.Modify(string.Format("t_4.text = '{0}'", Properties.Resources.DW_TXT_3));
            //dwOrderList.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_4));
            //dwOrderList.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_5));
            //dwOrderList.Modify(string.Format("text_t.text = '{0}'", Properties.Resources.DW_TXT_6));
            //dwOrderList.Modify(string.Format("t_8.text = '{0}'", Properties.Resources.DW_TXT_7));

            //if (NetInfo.Language == LangMode.En || NetInfo.Language == LangMode.Vi)
            //{
            //    dwOrderList.Modify(string.Format("panm_t.Font.Face = '{0}'", "Arial"));
            //    dwOrderList.Modify(string.Format("t_3.Font.Face = '{0}'", "Arial"));
            //    dwOrderList.Modify(string.Format("t_4.Font.Face = '{0}'", "Arial"));
            //    dwOrderList.Modify(string.Format("t_1.Font.Face = '{0}'", "Arial"));
            //    dwOrderList.Modify(string.Format("t_2.Font.Face = '{0}'", "Arial"));
            //    dwOrderList.Modify(string.Format("text_t.Font.Face = '{0}'", "Arial"));
            //    dwOrderList.Modify(string.Format("t_8.Font.Face = '{0}'", "Arial"));

            //    dwOrderList.Modify(string.Format("compute_1.Font.Face = '{0}'", "Arial"));
            //    dwOrderList.Modify(string.Format("t_5.Font.Face = '{0}'", "Arial"));
            //    dwOrderList.Modify(string.Format("t_6.Font.Face = '{0}'", "Arial"));
            //    dwOrderList.Modify(string.Format("t_9.Font.Face = '{0}'", "Arial"));
            //}
            
        }
        #endregion
    }
}

