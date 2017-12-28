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
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Results.Adma;

#endregion

namespace IHIS.PFES
{
    /// <summary>
    /// CPL7001Q02에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class PFE7001Q01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel2;
 //       private IHIS.Framework.XDataWindow dwDailyReport;
        private XLabel xLabel12;
        private XDictComboBox cboIO;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private MultiLayout layDailyReport;
        private XLabel xLabel1;
        private XDictComboBox cboPart;
        private XDatePicker dtKensaDate;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem16;


        private string hospitalName = "";
        public PFE7001Q01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // Updated by Cloud
            layDailyReport.ParamList = new List<string>(new string[]
                {
                    "f_io_gubun",
                    "f_kensa_date",
                    "f_part_code",
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PFE7001Q01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dtKensaDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboPart = new IHIS.Framework.XDictComboBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.cboIO = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
  //          this.dwDailyReport = new IHIS.Framework.XDataWindow();
            this.layDailyReport = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layDailyReport)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.dtKensaDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.cboPart);
            this.xPanel1.Controls.Add(this.xLabel12);
            this.xPanel1.Controls.Add(this.cboIO);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // dtKensaDate
            // 
            this.dtKensaDate.AccessibleDescription = null;
            this.dtKensaDate.AccessibleName = null;
            resources.ApplyResources(this.dtKensaDate, "dtKensaDate");
            this.dtKensaDate.BackgroundImage = null;
            this.dtKensaDate.IsVietnameseYearType = false;
            this.dtKensaDate.Name = "dtKensaDate";
            this.dtKensaDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtFromDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = null;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // cboPart
            // 
            this.cboPart.AccessibleDescription = null;
            this.cboPart.AccessibleName = null;
            resources.ApplyResources(this.cboPart, "cboPart");
            this.cboPart.BackgroundImage = null;
            this.cboPart.ExecuteQuery = null;
            this.cboPart.Font = null;
            this.cboPart.Name = "cboPart";
            this.cboPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboPart.ParamList")));
            this.cboPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboPart.SelectedIndexChanged += new System.EventHandler(this.cboPart_SelectedIndexChanged);
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.Font = null;
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // cboIO
            // 
            this.cboIO.AccessibleDescription = null;
            this.cboIO.AccessibleName = null;
            resources.ApplyResources(this.cboIO, "cboIO");
            this.cboIO.BackgroundImage = null;
            this.cboIO.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cboIO.ExecuteQuery = null;
            this.cboIO.Font = null;
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
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = null;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
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
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
  //          this.xPanel2.Controls.Add(this.dwDailyReport);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // dwDailyReport
            // 
            //resources.ApplyResources(this.dwDailyReport, "dwDailyReport");
            //this.dwDailyReport.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            //this.dwDailyReport.DataWindowObject = "pfe7001q01";
            //this.dwDailyReport.LibraryList = "PFES\\pfes.pfe7001q01.pbd";
            //this.dwDailyReport.LiveScroll = false;
            //this.dwDailyReport.Name = "dwDailyReport";
            //this.dwDailyReport.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            //this.dwDailyReport.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_RowFocusChanged);
            //this.dwDailyReport.Click += new System.EventHandler(this.dwReserList_Click);
            // 
            // layDailyReport
            // 
            this.layDailyReport.ExecuteQuery = null;
            this.layDailyReport.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem16});
            this.layDailyReport.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDailyReport.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gumsa_date";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "io_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "bunho";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "gwa";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "doctor";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "jundal_part";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "hangmog_code";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "hangmog_name";
            // 
            // PFE7001Q01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "PFE7001Q01";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CPL7001Q01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layDailyReport)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //13660
            try
            {
                Adm107UFbxHospCodeDataValidatingArgs args = new Adm107UFbxHospCodeDataValidatingArgs();
                args.HospCode = UserInfo.HospCode;
                Adm107UFbxHospCodeDataValidatingResult result = CloudService.Instance.Submit<Adm107UFbxHospCodeDataValidatingResult, Adm107UFbxHospCodeDataValidatingArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    hospitalName = result.YoyangName;
                }
            }
            catch
            { }
            finally
            {
                ApplyMultiLangDataWindow();

                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        private void ApplyMultiLangDataWindow()
        {         
            //dwDailyReport
            //dwDailyReport.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_001));
            //dwDailyReport.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_002));
            //dwDailyReport.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_003));
            //dwDailyReport.Modify(string.Format("t_4.text = '{0}'", Properties.Resources.DW_TXT_004));
            //dwDailyReport.Modify(string.Format("t_5.text = '{0}'", Properties.Resources.DW_TXT_005));
            //dwDailyReport.Modify(string.Format("t_6.text = '{0}'", Properties.Resources.DW_TXT_006));
            //dwDailyReport.Modify(string.Format("t_7.text = '{0}'", Properties.Resources.DW_TXT_007));
            //dwDailyReport.Modify(string.Format("t_8.text = '{0}'", Properties.Resources.DW_TXT_008));
            //dwDailyReport.Modify(string.Format("t_9.text = '{0}'", Properties.Resources.DW_TXT_009));
            //dwDailyReport.Modify(string.Format("t_10.text = '{0}'", Properties.Resources.DW_TXT_010));
            //dwDailyReport.Modify(string.Format("t_11.text = '{0}'", Properties.Resources.DW_TXT_011));
            //dwDailyReport.Modify(string.Format("t_12.text = '{0}'", Properties.Resources.DW_TXT_012));
            //dwDailyReport.Modify(string.Format("t_13.text = '{0}'", Properties.Resources.DW_TXT_013));
            //dwDailyReport.Modify(string.Format("t_14.text = '{0}'", Properties.Resources.DW_TXT_014));
            //dwDailyReport.Modify(string.Format("t_15.text = '{0}'", Properties.Resources.DW_TXT_015));
            //dwDailyReport.Modify(string.Format("t_16.text = '{0}'", hospitalName));
            //if (NetInfo.Language != LangMode.Jr)
            //{
            //    dwDailyReport.Modify(string.Format("t_6.Font.Face='{0}'", Service.COMMON_FONT_BOLD.Name)); // font đậm                
            //    dwDailyReport.Modify(string.Format("t_1.Font.Face='{0}'", Service.COMMON_FONT.Name)); // font thường
            //    dwDailyReport.Modify(string.Format("t_2.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_9.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("gumsa_date.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_3.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_4.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_10.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_7.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_8.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_5.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_11.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_12.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_13.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("bunho.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("suname.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("gwa.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("doctor.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("jundal_part.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("hangmog_code.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("hangmog_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_14.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_15.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_16.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("page_1.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("page_2.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("compute_2.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("compute_1.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //}
        }

        #endregion

        #region CPL7001Q01_ScreenOpen

        private void CPL7001Q01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 基準日付セット
            this.dtKensaDate.SetEditValue(EnvironInfo.GetSysDate());

            // 디폴트 入外セット 
            this.cboIO.SelectedIndex = 0;

            this.cboPart.SelectedIndex = 0;
        }
        #endregion

        #region layMonthlyReportQuery
        private void layDailyReportQuery()
        {
  //          dwDailyReport.Reset();
            ApplyMultiLangDataWindow();

            layDailyReport.Reset();

            #region deleted by Cloud
//            this.layDailyReport.QuerySQL = @"SELECT :f_kensa_date                                       GUMSA_DATE
//                                                     , 'O'                                                 IO_GUBUN
//                                                     , A.BUNHO                                             BUNHO
//                                                     , C.SUNAME                                            SUNAME
//                                                     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)           GWA
//                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)     DOCTOR_NAME
//                                                     , (SELECT X.CODE_NAME
//                                                          FROM OCS0132 X
//                                                         WHERE X.HOSP_CODE = A.HOSP_CODE
//                                                           AND X.CODE_TYPE = 'OCS_ACT_PART_02'
//                                                           AND X.CODE      = A.JUNDAL_PART)                JUNDAL_PART
//                                                     , A.HANGMOG_CODE                                      HANGMOG_CODE
//                                                     , B.HANGMOG_NAME                                      HANGMOG_NAME
//                                                   FROM OUT0101 C
//                                                      , OCS0103 B
//                                                      , OCS1003 A
//                                                 WHERE A.HOSP_CODE        = :f_hosp_code
//                                                   AND NVL(A.RESER_DATE, A.ORDER_DATE) = :f_kensa_date
//                                                   AND 'O'                LIKE :f_io_gubun
//                                                   AND A.ACTING_DATE      IS NOT NULL
//                                                   AND A.SLIP_CODE        LIKE 'E%' --生体検査
//                                                   AND A.JUNDAL_TABLE     IN ('PFE', 'CPL')
//                                                   AND A.JUNDAL_PART      LIKE :f_part_code --ENDO(内視鏡), ECHO(超音波), EKG(心電図), PFEC(その他)
//                                                   AND NVL(A.DC_YN, 'N')  = 'N'
//                                                   AND B.HOSP_CODE        = A.HOSP_CODE
//                                                   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
//                                                   AND B.SG_CODE          IS NOT NULL
//                                                   AND A.ORDER_DATE       BETWEEN B.START_DATE AND B.END_DATE
//                                                   AND C.HOSP_CODE        = A.HOSP_CODE
//                                                   AND C.BUNHO            = A.BUNHO
//                                                UNION
//                                                SELECT :f_kensa_date                                       GUMSA_DATE
//                                                     , 'I'                                                 IO_GUBUN
//                                                     , A.BUNHO                                             BUNHO
//                                                     , C.SUNAME                                            SUNAME
//                                                     , D.HO_DONG || '-' || D.HO_CODE                       GWA
//                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)     DOCTOR_NAME
//                                                     , (SELECT X.CODE_NAME
//                                                          FROM OCS0132 X
//                                                         WHERE X.HOSP_CODE = A.HOSP_CODE
//                                                           AND X.CODE_TYPE = 'OCS_ACT_PART_02'
//                                                           AND X.CODE      = A.JUNDAL_PART)                JUNDAL_PART
//                                                     , A.HANGMOG_CODE                                      HANGMOG_CODE
//                                                     , B.HANGMOG_NAME                                      HANGMOG_NAME
//                                                   FROM PFE0201 D
//                                                      , OUT0101 C
//                                                      , OCS0103 B
//                                                      , OCS2003 A
//                                                 WHERE A.HOSP_CODE        = :f_hosp_code
//                                                   AND NVL(A.RESER_DATE, A.ORDER_DATE) = :f_kensa_date
//                                                   AND 'I'                LIKE :f_io_gubun
//                                                   AND A.ACTING_DATE      IS NOT NULL
//                                                   AND A.SLIP_CODE        LIKE 'E%' --生体検査
//                                                   AND A.JUNDAL_TABLE     IN ('PFE', 'CPL')
//                                                   AND A.JUNDAL_PART      LIKE :f_part_code --ENDO(内視鏡), ECHO(超音波), EKG(心電図), PFEC(その他)
//                                                   AND NVL(A.DC_YN, 'N')  = 'N'
//                                                   AND B.HOSP_CODE        = A.HOSP_CODE
//                                                   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
//                                                   AND B.SG_CODE          IS NOT NULL
//                                                   AND A.ORDER_DATE       BETWEEN B.START_DATE AND B.END_DATE
//                                                   AND C.HOSP_CODE        = A.HOSP_CODE
//                                                   AND C.BUNHO            = A.BUNHO
//                                                   AND D.HOSP_CODE        = A.HOSP_CODE
//                                                   AND D.FKOCS2003        = A.PKOCS2003
//                                                 ORDER BY IO_GUBUN
//                                                        , BUNHO
//                                                        , GWA
//                                                        , DOCTOR_NAME
//                                                        , HANGMOG_CODE";
            #endregion            

            // Updated by Cloud
            this.layDailyReport.ExecuteQuery = GetLayDailyReport;

            this.layDailyReport.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDailyReport.SetBindVarValue("f_kensa_date", this.dtKensaDate.GetDataValue());
            this.layDailyReport.SetBindVarValue("f_io_gubun", this.cboIO.GetDataValue());
            this.layDailyReport.SetBindVarValue("f_part_code", this.cboPart.GetDataValue());


            if (this.layDailyReport.QueryLayout(true))
            {
                //dwDailyReport.Reset();
                //dwDailyReport.Modify("t_12.text = '" + this.cboIO.Text + "'");
                //dwDailyReport.Modify("t_13.text = '" + this.cboPart.Text + "'");                
                //dwDailyReport.FillData(layDailyReport.LayoutTable);
                //dwDailyReport.Refresh();
            }
        }
        #endregion                

        #region dw
        private void dwReserList_Click(object sender, System.EventArgs e)
        {
  //          dwDailyReport.Refresh();
        }

        private void dwReserList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
  //          dwDailyReport.Refresh();
        }
        #endregion

        #region [ボタンリストクリック] 
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch( e.Func )
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.layDailyReportQuery();

                    break;
                case FunctionType.Print:
                    e.IsBaseCall = false;

                    if (this.layDailyReport.RowCount > 0)
                    {
                        //this.dwDailyReport.Reset();

                        //this.dwDailyReport.FillData(this.layDailyReport.LayoutTable);

                        //this.dwDailyReport.Refresh();

                        //this.dwDailyReport.Print();
                    }
                    break;
                case FunctionType.Preview:
                    e.IsBaseCall = false;
   //                 this.dwDailyReport.Export(true);
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

        #region [dtFromDate_DataValidating 日付選択]
        private void dtFromDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
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

            PFE7001Q01LayDailyReportArgs args = new PFE7001Q01LayDailyReportArgs();
            args.IoGubun = bvc["f_io_gubun"].VarValue;
            args.KensaDate = bvc["f_kensa_date"].VarValue;
            args.PartCode = bvc["f_part_code"].VarValue;
            PFE7001Q01LayDailyReportResult res = CloudService.Instance.Submit<PFE7001Q01LayDailyReportResult,
                PFE7001Q01LayDailyReportArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {                
                res.DailyReportItem.ForEach(delegate(PFE7001Q01LayDailyReportInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.GumsaDate,
                        item.IoGubun,
                        item.Bunho,
                        item.Suname,
                        item.Gwa,
                        item.DoctorName,
                        item.JundalPart,
                        item.HangmogCode,
                        item.HangmogName,
                        hospitalName
                    });
                });               
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}

