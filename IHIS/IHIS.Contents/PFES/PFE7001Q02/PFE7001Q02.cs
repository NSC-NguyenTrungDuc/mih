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
using IHIS.PFES.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Pfes;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using IHIS.CloudConnector.Contracts.Results.Pfes;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
#endregion

namespace IHIS.PFES
{
    /// <summary>
    /// PFE7001Q02에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class PFE7001Q02 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel2;
   //     private IHIS.Framework.XDataWindow dwMonthlyReport;
        private XLabel xLabel12;
        private XDictComboBox cboIO;
        private XMonthBox monthBox;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private MultiLayout layMonthlyReport;
        private XLabel xLabel1;
        private XDictComboBox cboPart;
        private MultiLayoutItem multiLayoutItem29;
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
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem69;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public PFE7001Q02()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // Updated by Cloud
            layMonthlyReport.ParamList = new List<string>(new string[]
                {
                    "f_from_date",
                    "f_io_gubun",
                    "f_part_code",
                    "f_to_date",
                });

            cboPart.ExecuteQuery = GetCboPart;
            cboPart.SetDictDDLB();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PFE7001Q02));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboPart = new IHIS.Framework.XDictComboBox();
            this.monthBox = new IHIS.Framework.XMonthBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.cboIO = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
    //        this.dwMonthlyReport = new IHIS.Framework.XDataWindow();
            this.layMonthlyReport = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layMonthlyReport)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.cboPart);
            this.xPanel1.Controls.Add(this.monthBox);
            this.xPanel1.Controls.Add(this.xLabel12);
            this.xPanel1.Controls.Add(this.cboIO);
            this.xPanel1.Controls.Add(this.xLabel2);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // cboPart
            // 
            this.cboPart.ExecuteQuery = null;
            resources.ApplyResources(this.cboPart, "cboPart");
            this.cboPart.Name = "cboPart";
            this.cboPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboPart.ParamList")));
            this.cboPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboPart.SelectedIndexChanged += new System.EventHandler(this.cboPart_SelectedIndexChanged);
            // 
            // monthBox
            // 
            resources.ApplyResources(this.monthBox, "monthBox");
            this.monthBox.Name = "monthBox";
            this.monthBox.PrevButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthBox_ButtonClick);
            this.monthBox.NextButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthBox_ButtonClick);
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Name = "xLabel12";
            // 
            // cboIO
            // 
            this.cboIO.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cboIO.ExecuteQuery = null;
            resources.ApplyResources(this.cboIO, "cboIO");
            this.cboIO.Name = "cboIO";
            this.cboIO.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboIO.ParamList")));
            this.cboIO.SelectedIndexChanged += new System.EventHandler(this.cboGumsa_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "O";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "I";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.PFES.Properties.Resources.BTN_QUERY_TEXT, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Preview, System.Windows.Forms.Shortcut.None, global::IHIS.PFES.Properties.Resources.BTN_PREVIEW_TEXT, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, global::IHIS.PFES.Properties.Resources.BTN_PRINT_TEXT, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.PFES.Properties.Resources.BTN_CLOSE_TEXT, -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
  //          this.xPanel2.Controls.Add(this.dwMonthlyReport);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // dwMonthlyReport
            // 
            //this.dwMonthlyReport.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            //this.dwMonthlyReport.DataWindowObject = "pfe7001q02";
            //resources.ApplyResources(this.dwMonthlyReport, "dwMonthlyReport");
            //this.dwMonthlyReport.LibraryList = "PFES\\pfes.pfe7001q02.pbd";
            //this.dwMonthlyReport.LiveScroll = false;
            //this.dwMonthlyReport.Name = "dwMonthlyReport";
            //this.dwMonthlyReport.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            //this.dwMonthlyReport.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_RowFocusChanged);
            //this.dwMonthlyReport.Click += new System.EventHandler(this.dwReserList_Click);
            // 
            // layMonthlyReport
            // 
            this.layMonthlyReport.ExecuteQuery = null;
            this.layMonthlyReport.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem29,
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
            this.multiLayoutItem67,
            this.multiLayoutItem69});
            this.layMonthlyReport.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layMonthlyReport.ParamList")));
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "yyyymm";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "hangmog_code";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "gumsa_name";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "d01";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "d02";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "d03";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "d04";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "d05";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "d06";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "d07";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "d08";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "d09";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "d10";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "d11";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "d12";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "d13";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "d14";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "d15";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "d16";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "d17";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "d18";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "d19";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "d20";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "d21";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "d22";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "d23";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "d24";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "d25";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "d26";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "d27";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "d28";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "d29";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "d30";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "d31";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "total";
            // 
            // PFE7001Q02
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "PFE7001Q02";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CPL7001Q02_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layMonthlyReport)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Screen 변수

        // 月の最後日
        private string last_date = "";
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyMultiLangDataWindow();

            // https://sofiamedix.atlassian.net/browse/MED-15266
            if (NetInfo.Language != LangMode.Jr)
            {
                this.ApplyMultipleFont();
            }

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void ApplyMultiLangDataWindow()
        {
            //dwMonthlyReport
            //dwMonthlyReport.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_001));
            //dwMonthlyReport.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_002));
            //dwMonthlyReport.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_003));
            //dwMonthlyReport.Modify(string.Format("t_4.text = '{0}'", Properties.Resources.DW_TXT_004));
            //dwMonthlyReport.Modify(string.Format("t_5.text = '{0}'", Properties.Resources.DW_TXT_005));
            //dwMonthlyReport.Modify(string.Format("t_6.text = '{0}'", Properties.Resources.DW_TXT_006));
            //dwMonthlyReport.Modify(string.Format("t_7.text = '{0}'", Properties.Resources.DW_TXT_007));
            //dwMonthlyReport.Modify(string.Format("t_8.text = '{0}'", Properties.Resources.DW_TXT_008));
            //dwMonthlyReport.Modify(string.Format("t_9.text = '{0}'", Properties.Resources.DW_TXT_009));
            //dwMonthlyReport.Modify(string.Format("t_15.text = '{0}'", Properties.Resources.DW_TXT_015));
            //dwMonthlyReport.Modify(string.Format("t_17.text = '{0}'", Properties.Resources.DW_TXT_017));
            //dwMonthlyReport.Modify(string.Format("t_18.text = '{0}'", Properties.Resources.DW_TXT_018));
            //dwMonthlyReport.Modify(string.Format("t_19.text = '{0}'", Properties.Resources.DW_TXT_019));
            //dwMonthlyReport.Modify(string.Format("t_20.text = '{0}'", Properties.Resources.DW_TXT_020));
            //dwMonthlyReport.Modify(string.Format("t_21.text = '{0}'", Properties.Resources.DW_TXT_021));
            //dwMonthlyReport.Modify(string.Format("t_22.text = '{0}'", Properties.Resources.DW_TXT_022));
            //dwMonthlyReport.Modify(string.Format("t_23.text = '{0}'", Properties.Resources.DW_TXT_023));
            //dwMonthlyReport.Modify(string.Format("t_24.text = '{0}'", Properties.Resources.DW_TXT_024));
            //dwMonthlyReport.Modify(string.Format("t_25.text = '{0}'", Properties.Resources.DW_TXT_025));
            //dwMonthlyReport.Modify(string.Format("t_26.text = '{0}'", Properties.Resources.DW_TXT_026));
            //dwMonthlyReport.Modify(string.Format("t_27.text = '{0}'", Properties.Resources.DW_TXT_027));
            //dwMonthlyReport.Modify(string.Format("t_28.text = '{0}'", Properties.Resources.DW_TXT_028));
            //dwMonthlyReport.Modify(string.Format("t_29.text = '{0}'", Properties.Resources.DW_TXT_029));
            //dwMonthlyReport.Modify(string.Format("t_30.text = '{0}'", Properties.Resources.DW_TXT_030));
            //dwMonthlyReport.Modify(string.Format("t_31.text = '{0}'", Properties.Resources.DW_TXT_031));
            //dwMonthlyReport.Modify(string.Format("t_32.text = '{0}'", Properties.Resources.DW_TXT_032));
            //dwMonthlyReport.Modify(string.Format("t_33.text = '{0}'", Properties.Resources.DW_TXT_033));
            //dwMonthlyReport.Modify(string.Format("t_34.text = '{0}'", Properties.Resources.DW_TXT_034));
            //dwMonthlyReport.Modify(string.Format("t_35.text = '{0}'", Properties.Resources.DW_TXT_035));
            //dwMonthlyReport.Modify(string.Format("t_36.text = '{0}'", Properties.Resources.DW_TXT_036));
            //dwMonthlyReport.Modify(string.Format("t_37.text = '{0}'", Properties.Resources.DW_TXT_037));
            //dwMonthlyReport.Modify(string.Format("t_38.text = '{0}'", Properties.Resources.DW_TXT_038));
            //dwMonthlyReport.Modify(string.Format("t_39.text = '{0}'", Properties.Resources.DW_TXT_039));
            //dwMonthlyReport.Modify(string.Format("t_40.text = '{0}'", Properties.Resources.DW_TXT_040));
            //dwMonthlyReport.Modify(string.Format("t_41.text = '{0}'", Properties.Resources.DW_TXT_041));
            //dwMonthlyReport.Modify(string.Format("t_42.text = '{0}'", Properties.Resources.DW_TXT_042));
            //dwMonthlyReport.Modify(string.Format("t_43.text = '{0}'", Properties.Resources.DW_TXT_043));
            //dwMonthlyReport.Modify(string.Format("t_44.text = '{0}'", Properties.Resources.DW_TXT_044));
            //dwMonthlyReport.Modify(string.Format("t_45.text = '{0}'", Properties.Resources.DW_TXT_045));
            //dwMonthlyReport.Modify(string.Format("t_46.text = '{0}'", Properties.Resources.DW_TXT_046));
            ////dwMonthlyReport.Modify(string.Format("date_1.text = '{0}'", EnvironInfo.GetSysDateTime().ToString()));
            ////dwMonthlyReport.Modify(string.Format("t_51.text = '{0}'", Properties.Resources.DW_TXT_051));
            ////dwMonthlyReport.Modify(string.Format("t_50.text = '{0}'", Properties.Resources.DW_TXT_050));
            //// https://sofiamedix.atlassian.net/browse/MED-15266
            //dwMonthlyReport.Modify(string.Format("t_10.text = '{0}'", Properties.Resources.DW_TXT_050));
            //dwMonthlyReport.Modify(string.Format("t_11.text = '{0}'", Properties.Resources.DW_TXT_051));
        }

        /// <summary>
        /// // https://sofiamedix.atlassian.net/browse/MED-15266
        /// </summary>
        private void ApplyMultipleFont()
        {
            // Font family
            //dwMonthlyReport.Modify(string.Format("t_1.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_2.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_3.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            ////dwMonthlyReport.Modify(string.Format("t_4.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_5.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_6.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_7.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_8.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_9.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_15.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_17.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_18.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_19.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_20.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_21.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_22.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_23.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_24.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_25.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_26.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_27.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_28.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_29.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_30.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_31.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_32.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_33.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_34.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_35.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_36.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_37.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_38.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_39.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_40.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_41.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_42.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_43.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_44.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_45.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_46.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_10.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("t_11.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //dwMonthlyReport.Modify(string.Format("date_1.Font.Face = '{0}'", Service.COMMON_FONT.Name));

            //// Font height
            //dwMonthlyReport.Modify("t_1.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_2.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_3.Font.Height = '14'");
            ////dwMonthlyReport.Modify("t_4.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_5.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_6.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_7.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_8.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_9.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_15.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_17.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_18.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_19.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_20.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_21.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_22.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_23.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_24.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_25.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_26.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_27.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_28.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_29.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_30.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_31.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_32.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_33.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_34.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_35.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_36.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_37.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_38.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_39.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_40.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_41.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_42.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_43.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_44.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_45.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_46.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_10.Font.Height = '14'");
            //dwMonthlyReport.Modify("t_11.Font.Height = '14'");
            //dwMonthlyReport.Modify("date_1.Font.Height = '14'");
        }

        #endregion

        #region CPL7001Q02_ScreenOpen

        private void CPL7001Q02_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 基準月設定
            this.monthBox.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));

            // 디폴트 入外セット 
            this.cboIO.SelectedIndex = 0;

            this.cboPart.SelectedIndex = 0;

            // 月の最後日設定
            this.last_date = this.monthBox.GetDataValue() + DateTime.DaysInMonth(int.Parse(this.monthBox.GetDataValue().Substring(0, 4)), int.Parse(this.monthBox.GetDataValue().Substring(4, 2))).ToString();
        }
        #endregion

        #region layMonthlyReportQuery
        private void layMonthlyReportQuery()
        {
  //          dwMonthlyReport.Reset();
            layMonthlyReport.Reset();

            #region deleted by Cloud
//            this.layMonthlyReport.QuerySQL = @"SELECT --TO_CHAR(TO_DATE(X.YYYYMM, 'YYYYMM'), 'YYYY') || '年' || TO_CHAR(TO_DATE(X.YYYYMM, 'YYYYMM'), 'MM') || '月'  YYYYMM
//                                                       TO_DATE(X.YYYYMM, 'YYYYMM')           YYYYMM
//                                                     , X.HANGMOG_CODE                        HANGMOG_CODE
//                                                     , MAX(X.GUMSA_NAME)                     GUMSA_NAME
//                                                     , NVL(SUM(DECODE(X.DD,'01', X.CNT)), 0) D01
//                                                     , NVL(SUM(DECODE(X.DD,'02', X.CNT)), 0) D02
//                                                     , NVL(SUM(DECODE(X.DD,'03', X.CNT)), 0) D03
//                                                     , NVL(SUM(DECODE(X.DD,'04', X.CNT)), 0) D04
//                                                     , NVL(SUM(DECODE(X.DD,'05', X.CNT)), 0) D05
//                                                     , NVL(SUM(DECODE(X.DD,'06', X.CNT)), 0) D06
//                                                     , NVL(SUM(DECODE(X.DD,'07', X.CNT)), 0) D07
//                                                     , NVL(SUM(DECODE(X.DD,'08', X.CNT)), 0) D08
//                                                     , NVL(SUM(DECODE(X.DD,'09', X.CNT)), 0) D09
//                                                     , NVL(SUM(DECODE(X.DD,'10', X.CNT)), 0) D10
//                                                                                                     
//                                                     , NVL(SUM(DECODE(X.DD,'11', X.CNT)), 0) D11
//                                                     , NVL(SUM(DECODE(X.DD,'12', X.CNT)), 0) D12
//                                                     , NVL(SUM(DECODE(X.DD,'13', X.CNT)), 0) D13
//                                                     , NVL(SUM(DECODE(X.DD,'14', X.CNT)), 0) D14
//                                                     , NVL(SUM(DECODE(X.DD,'15', X.CNT)), 0) D15
//                                                     , NVL(SUM(DECODE(X.DD,'16', X.CNT)), 0) D16
//                                                     , NVL(SUM(DECODE(X.DD,'17', X.CNT)), 0) D17
//                                                     , NVL(SUM(DECODE(X.DD,'18', X.CNT)), 0) D18
//                                                     , NVL(SUM(DECODE(X.DD,'19', X.CNT)), 0) D19
//                                                     , NVL(SUM(DECODE(X.DD,'20', X.CNT)), 0) D20
//                                                                                                     
//                                                     , NVL(SUM(DECODE(X.DD,'21', X.CNT)), 0) D21
//                                                     , NVL(SUM(DECODE(X.DD,'22', X.CNT)), 0) D22
//                                                     , NVL(SUM(DECODE(X.DD,'23', X.CNT)), 0) D23
//                                                     , NVL(SUM(DECODE(X.DD,'24', X.CNT)), 0) D24
//                                                     , NVL(SUM(DECODE(X.DD,'25', X.CNT)), 0) D25
//                                                     , NVL(SUM(DECODE(X.DD,'26', X.CNT)), 0) D26
//                                                     , NVL(SUM(DECODE(X.DD,'27', X.CNT)), 0) D27
//                                                     , NVL(SUM(DECODE(X.DD,'28', X.CNT)), 0) D28
//                                                     , NVL(SUM(DECODE(X.DD,'29', X.CNT)), 0) D29
//                                                     , NVL(SUM(DECODE(X.DD,'30', X.CNT)), 0) D30
//                                                     , NVL(SUM(DECODE(X.DD,'31', X.CNT)), 0) D31
//                                                     , NVL(SUM(DECODE(X.DD,'TOTAL', X.CNT)), SUM(X.CNT)) TOTAL
//                                                  FROM
//                                                      (SELECT 'O' IO_GUBUN
//                                                            , DECODE(GROUPING(SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 0, 6))
//                                                                   , 1, 'TOTAL' , SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 0, 6)) YYYYMM
//                                                            , DECODE(GROUPING(SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 7))
//                                                                   , 1, 'TOTAL' , SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 7)) DD
//                                                            , DECODE(GROUPING(A.HANGMOG_CODE) , 1, '外来合計' , A.HANGMOG_CODE)  HANGMOG_CODE
//                                                            , DECODE(GROUPING(A.HANGMOG_CODE) , 1, ' ', MAX(B.HANGMOG_NAME)) GUMSA_NAME
//                                                            , COUNT(A.HANGMOG_CODE)                                              CNT
//                                                         FROM OCS0103 B
//                                                            , OCS1003 A
//                                                        WHERE A.HOSP_CODE = :f_hosp_code
//                                                          AND NVL(A.RESER_DATE, A.ORDER_DATE) BETWEEN :f_from_date AND :f_to_date
//                                                          AND 'O'  LIKE :f_io_gubun
//                                                          AND A.SLIP_CODE     LIKE 'E%' --生体検査
//                                                          AND A.JUNDAL_TABLE  IN ('PFE', 'CPL')
//                                                          AND A.ACTING_DATE   IS NOT NULL
//                                                          AND A.JUNDAL_PART   LIKE :f_part_code --ENDO(内視鏡), ECHO(超音波), EKG(心電図), PFEC(その他)
//                                                          AND NVL(A.DC_YN, 'N')  = 'N'
//                                                          AND B.HOSP_CODE     = A.HOSP_CODE
//                                                          AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                          AND B.SG_CODE       IS NOT NULL
//                                                          AND A.ORDER_DATE    BETWEEN B.START_DATE AND B.END_DATE
//                                                        GROUP BY ROLLUP (SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 0, 6)
//                                                                       , SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 7)
//                                                                       , A.HANGMOG_CODE)
//                                                        UNION               
//                                                      SELECT 'I' IO_GUBUN
//                                                            , DECODE(GROUPING(SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 0, 6))
//                                                                   , 1, 'TOTAL' , SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 0, 6)) YYYYMM
//                                                            , DECODE(GROUPING(SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 7))
//                                                                   , 1, 'TOTAL' , SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 7)) DD
//                                                            , DECODE(GROUPING(A.HANGMOG_CODE) , 1, '入院合計' , A.HANGMOG_CODE)  HANGMOG_CODE
//                                                            , DECODE(GROUPING(A.HANGMOG_CODE) , 1, ' ', MAX(B.HANGMOG_NAME)) GUMSA_NAME
//                                                            , COUNT(A.HANGMOG_CODE)                                              CNT
//                                                         FROM OCS0103 B
//                                                            , OCS2003 A
//                                                        WHERE A.HOSP_CODE = :f_hosp_code
//                                                          AND NVL(A.RESER_DATE, A.ORDER_DATE) BETWEEN :f_from_date AND :f_to_date
//                                                          AND 'I'  LIKE :f_io_gubun
//                                                          AND A.SLIP_CODE     LIKE 'E%' --生体検査
//                                                          AND A.JUNDAL_TABLE  IN ('PFE', 'CPL')
//                                                          AND A.ACTING_DATE   IS NOT NULL
//                                                          AND A.JUNDAL_PART   LIKE :f_part_code --ENDO(内視鏡), ECHO(超音波), EKG(心電図), PFEC(その他)
//                                                          AND NVL(A.DC_YN, 'N')  = 'N'
//                                                          AND B.HOSP_CODE     = A.HOSP_CODE
//                                                          AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                          AND B.SG_CODE       IS NOT NULL
//                                                          AND A.ORDER_DATE    BETWEEN B.START_DATE AND B.END_DATE
//                                                        GROUP BY ROLLUP (SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 0, 6)
//                                                                       , SUBSTR(TO_CHAR(NVL(A.RESER_DATE, A.ORDER_DATE), 'YYYYMMDD'), 7)
//                                                                       , A.HANGMOG_CODE)
//                                                      ) X
//                                                  WHERE X.YYYYMM <> 'TOTAL'
//                                                GROUP BY X.IO_GUBUN, X.YYYYMM, X.HANGMOG_CODE
//                                                ORDER BY X.IO_GUBUN, X.YYYYMM, X.HANGMOG_CODE";
            #endregion

            // Updated by Cloud
            this.layMonthlyReport.ExecuteQuery = GetLayDailyReport;

            this.layMonthlyReport.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layMonthlyReport.SetBindVarValue("f_from_date", this.monthBox.GetDataValue() + "01");
            this.layMonthlyReport.SetBindVarValue("f_to_date", this.last_date);
            this.layMonthlyReport.SetBindVarValue("f_io_gubun", this.cboIO.GetDataValue());
            this.layMonthlyReport.SetBindVarValue("f_part_code", this.cboPart.GetDataValue());


            if (this.layMonthlyReport.QueryLayout(true))
            {
                //dwMonthlyReport.Reset();
                //dwMonthlyReport.Modify("t_8.text = '" + this.cboIO.Text + "'");
                //dwMonthlyReport.Modify("t_9.text = '" + this.cboPart.Text + "'");

                //dwMonthlyReport.FillData(layMonthlyReport.LayoutTable);
                //dwMonthlyReport.Refresh();
            }
        }
        #endregion                

        #region dw
        private void dwReserList_Click(object sender, System.EventArgs e)
        {
  //          dwMonthlyReport.Refresh();
        }

        private void dwReserList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
   //         dwMonthlyReport.Refresh();
        }
        #endregion

        #region [ボタンリストクリック] 
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch( e.Func )
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.layMonthlyReportQuery();

                    break;
                case FunctionType.Print:
                    e.IsBaseCall = false;
                    //this.dwMonthlyReportPrn.Reset();
                    if (this.layMonthlyReport.RowCount > 0)
                    {
                        //this.dwMonthlyReport.Reset();
                        //ApplyMultiLangDataWindow();

                        //this.dwMonthlyReport.FillData(this.layMonthlyReport.LayoutTable);

                        //this.dwMonthlyReport.Refresh();

                        //this.dwMonthlyReport.Print();
                    }
                    break;
                case FunctionType.Preview:
                    e.IsBaseCall = false;
    //                this.dwMonthlyReport.Export(true);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [Combo SelectedIndexChanged]
        private void cboGumsa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cboPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region [monthBox_ButtonClick 照会月変更]
        private void monthBox_ButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
            // 前月の最後日セット
            this.last_date = this.monthBox.GetDataValue() + DateTime.DaysInMonth(int.Parse(this.monthBox.GetDataValue().Substring(0, 4)), int.Parse(this.monthBox.GetDataValue().Substring(4, 2))).ToString();

            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region Cloud updated code

        #region GetCboPart
        /// <summary>
        /// GetCboPart
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboPart(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ComboResult res = CacheService.Instance.Get<ComboPfesCboPartArgs, ComboResult>(new ComboPfesCboPartArgs(), delegate(ComboResult result)
                {
                    return result.ExecutionStatus == ExecutionStatus.Success && result.ComboItem != null && result.ComboItem.Count > 0;
                });

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayDailyReport
        /// <summary>
        /// GetLayDailyReport
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayDailyReport(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PFE7001Q02LayMonthlyReportArgs args = new PFE7001Q02LayMonthlyReportArgs();
            args.FromDate = bvc["f_from_date"].VarValue;
            args.IoGubun = bvc["f_io_gubun"].VarValue;
            args.PartCode = bvc["f_part_code"].VarValue;
            args.ToDate = bvc["f_to_date"].VarValue;
            PFE7001Q02LayMonthlyReportResult res = CloudService.Instance.Submit<PFE7001Q02LayMonthlyReportResult,
                PFE7001Q02LayMonthlyReportArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.MonthlyReportItem.ForEach(delegate(PFE7001Q02LayMonthlyReportInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Yyyymm,
                        item.HangmogCode,
                        item.GumsaName,
                        item.D01,
                        item.D02,
                        item.D03,
                        item.D04,
                        item.D05,
                        item.D06,
                        item.D07,
                        item.D08,
                        item.D09,
                        item.D10,
                        item.D11,
                        item.D12,
                        item.D13,
                        item.D14,
                        item.D15,
                        item.D16,
                        item.D17,
                        item.D18,
                        item.D19,
                        item.D20,
                        item.D21,
                        item.D22,
                        item.D23,
                        item.D24,
                        item.D25,
                        item.D26,
                        item.D27,
                        item.D28,
                        item.D29,
                        item.D30,
                        item.D31,
                        item.Total,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}

