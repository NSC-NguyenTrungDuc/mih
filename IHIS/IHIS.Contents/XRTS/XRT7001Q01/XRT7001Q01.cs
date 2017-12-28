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
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.CloudConnector.Contracts.Results;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Models.System;
#endregion

namespace IHIS.XRTS
{
    /// <summary>
    /// CPL7001Q02에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class XRT7001Q01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel2;
 //       private IHIS.Framework.XDataWindow dwRadioHistory;
        private XLabel xLabel12;
        private XDictComboBox cboIO;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private MultiLayout layRadioHistory;
        private XLabel xLabel1;
        private XDictComboBox cboPart;
        private XLabel xLabel3;
        private XPatientBox paBox;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public XRT7001Q01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();          
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                Size = new System.Drawing.Size(rc.Width - 60, rc.Height - 145);            
            //Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //Size = new System.Drawing.Size(rc.Width - 60, rc.Height - 145);
            // updated by Cloud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT7001Q01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboPart = new IHIS.Framework.XDictComboBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.cboIO = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.layRadioHistory = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layRadioHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.cboPart);
            this.xPanel1.Controls.Add(this.xLabel12);
            this.xPanel1.Controls.Add(this.cboIO);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Name = "xLabel3";
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Name = "xLabel1";
            // 
            // cboPart
            // 
            resources.ApplyResources(this.cboPart, "cboPart");
            this.cboPart.ExecuteQuery = null;
            this.cboPart.Name = "cboPart";
            this.cboPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboPart.ParamList")));
            this.cboPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboPart.SelectedIndexChanged += new System.EventHandler(this.cboPart_SelectedIndexChanged);
            // 
            // xLabel12
            // 
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.Name = "xLabel12";
            // 
            // cboIO
            // 
            resources.ApplyResources(this.cboIO, "cboIO");
            this.cboIO.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cboIO.ExecuteQuery = null;
            this.cboIO.Name = "cboIO";
            this.cboIO.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboIO.ParamList")));
            this.cboIO.SelectedIndexChanged += new System.EventHandler(this.cboIO_SelectedIndexChanged);
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
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // layRadioHistory
            // 
            this.layRadioHistory.ExecuteQuery = null;
            this.layRadioHistory.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem16,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32});
            this.layRadioHistory.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layRadioHistory.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "suname";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "gwa";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "doctor";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "order_date";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "jundal_part";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "hangmog_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "hangmog_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "xray_code_idx";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "xray_code_idx_nm";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "tube_vol";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "tube_cur";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "xray_time";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "tube_cur_time";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "irradiation_time";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "xray_distance";
            // 
            // XRT7001Q01
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "XRT7001Q01";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.XRT7001Q01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layRadioHistory)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyMultiLangDataWindow();

            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("bunho"))
                {
                    this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
                }
            }

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void ApplyMultiLangDataWindow()
        {
            //dwRadioHistory
            //dwRadioHistory.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_001));
            //dwRadioHistory.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_002));
            //dwRadioHistory.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_003));
            //dwRadioHistory.Modify(string.Format("t_4.text = '{0}'", Properties.Resources.DW_TXT_004));
            //dwRadioHistory.Modify(string.Format("t_5.text = '{0}'", Properties.Resources.DW_TXT_005));
            //dwRadioHistory.Modify(string.Format("t_6.text = '{0}'", Properties.Resources.DW_TXT_006));
            //dwRadioHistory.Modify(string.Format("t_7.text = '{0}'", Properties.Resources.DW_TXT_007));
            //dwRadioHistory.Modify(string.Format("t_8.text = '{0}'", Properties.Resources.DW_TXT_008));
            //dwRadioHistory.Modify(string.Format("t_9.text = '{0}'", Properties.Resources.DW_TXT_009));
            //dwRadioHistory.Modify(string.Format("t_10.text = '{0}'", Properties.Resources.DW_TXT_010));
            //dwRadioHistory.Modify(string.Format("t_11.text = '{0}'", Properties.Resources.DW_TXT_011));
            //dwRadioHistory.Modify(string.Format("t_12.text = '{0}'", Properties.Resources.DW_TXT_012));
            //dwRadioHistory.Modify(string.Format("t_13.text = '{0}'", Properties.Resources.DW_TXT_013));
            //dwRadioHistory.Modify(string.Format("t_14.text = '{0}'", Properties.Resources.DW_TXT_014));
            //dwRadioHistory.Modify(string.Format("t_15.text = '{0}'", Properties.Resources.DW_TXT_015));
            //dwRadioHistory.Modify(string.Format("t_16.text = '{0}'", Properties.Resources.DW_TXT_016));
            //dwRadioHistory.Modify(string.Format("t_17.text = '{0}'", Properties.Resources.DW_TXT_017));
            //dwRadioHistory.Modify(string.Format("t_18.text = '{0}'", Properties.Resources.DW_TXT_018));
            //dwRadioHistory.Modify(string.Format("t_19.text = '{0}'", Properties.Resources.DW_TXT_019));
            //dwRadioHistory.Modify(string.Format("t_20.text = '{0}'", Properties.Resources.DW_TXT_020));
            //dwRadioHistory.Modify(string.Format("t_21.text = '{0}'", Properties.Resources.DW_TXT_021));
            //dwRadioHistory.Modify(string.Format("t_22.text = '{0}'", Properties.Resources.DW_TXT_022));
            //dwRadioHistory.Modify(string.Format("t_23.text = '{0}'", Properties.Resources.DW_TXT_023));
            //dwRadioHistory.Modify(string.Format("t_24.text = '{0}'", Properties.Resources.DW_TXT_024));
            //dwRadioHistory.Modify(string.Format("t_25.text = '{0}'", Properties.Resources.DW_TXT_025));
            //dwRadioHistory.Modify(string.Format("t_26.text = '{0}'", Properties.Resources.DW_TXT_026));
            //dwRadioHistory.Modify(string.Format("t_27.text = '{0}'", Properties.Resources.DW_TXT_027));
            //dwRadioHistory.Modify(string.Format("t_28.text = '{0}'", Properties.Resources.DW_TXT_028));
            //dwRadioHistory.Modify(string.Format("t_29.text = '{0}'", Properties.Resources.DW_TXT_029));
            //if (NetInfo.Language != LangMode.Jr)
            //{
            //    dwRadioHistory.Modify(string.Format("t_6.Font.Face='{0}'", Service.COMMON_FONT_BOLD.Name)); // font đậm
            //    dwRadioHistory.Modify(string.Format("t_9.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_3.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_4.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_10.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_14.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_15.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_18.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_17.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_16.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_5.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_11.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_12.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_6.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_1.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("bunho.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_2.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("suname.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_13.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_7.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_8.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_19.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_20.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_21.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("order_date.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("gwa.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("jundal_part.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("doctor.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("hangmog_code.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("hangmog_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("xray_time.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("tube_cur.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("tube_vol.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("xray_code_idx.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("xray_code_idx_nm.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_22.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_23.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_24.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_27.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("xray_distance.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_26.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_25.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("irradiation_time.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("page_1.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("date_1.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_28.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("compute_3.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwRadioHistory.Modify(string.Format("t_29.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //}
        }

        #endregion

        #region XRT7001Q01_ScreenOpen

        private void XRT7001Q01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 디폴트 入外セット 
            this.cboIO.SelectedIndex = 0;

            this.cboPart.SelectedIndex = 0;
        }
        #endregion

        #region layMonthlyReportQuery
        private void layDailyReportQuery()
        {
  //          dwRadioHistory.Reset();
            layRadioHistory.Reset();

            #region deleted by Cloud
//            this.layRadioHistory.QuerySQL = @"-- RADIO INFO HISTORY--
//                                                SELECT A.BUNHO
//                                                     , FN_OUT_LOAD_SUNAME(A.BUNHO) SUNAME
//                                                     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE) GWA
//                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE) DOCTOR
//                                                     , A.ORDER_DATE
//                                                     , (SELECT X.CODE_NAME
//                                                          FROM OCS0132 X
//                                                         WHERE X.HOSP_CODE = A.HOSP_CODE
//                                                           AND X.CODE_TYPE = 'OCS_ACT_PART_01'
//                                                           AND X.CODE      = A.JUNDAL_PART)    JUNDAL_PART
//                                                     , A.XRAY_CODE
//                                                     , (SELECT C.XRAY_NAME 
//                                                          FROM XRT0001 C 
//                                                         WHERE C.HOSP_CODE = A.HOSP_CODE
//                                                           AND C.XRAY_CODE = A.XRAY_CODE) XRAY_NAME
//                                                     , B.XRAY_CODE_IDX
//                                                     , B.XRAY_CODE_IDX_NM
//                                                     , TO_NUMBER(B.TUBE_VOL)
//                                                     , TO_NUMBER(B.TUBE_CUR)
//                                                     , TO_NUMBER(B.XRAY_TIME)
//                                                     , TO_NUMBER(B.TUBE_CUR_TIME)
//                                                     , TO_NUMBER(B.IRRADIATION_TIME)
//                                                     , TO_NUMBER(B.XRAY_DISTANCE)
//                                                  FROM XRT0202 B
//                                                     , XRT0201 A
//                                                 WHERE A.HOSP_CODE   = :f_hosp_code
//                                                   AND A.BUNHO       = :f_bunho
//                                                   AND A.JUNDAL_PART LIKE :f_part_code
//                                                   AND B.HOSP_CODE   = A.HOSP_CODE
//                                                   AND B.FKXRT0201   = A.PKXRT0201
//                                                   AND DECODE(A.IN_OUT_GUBUN, 'O', (SELECT 'X'
//                                                                                      FROM OCS1003 AA
//                                                                                     WHERE AA.HOSP_CODE = A.HOSP_CODE
//                                                                                       AND AA.PKOCS1003 = A.FKOCS1003)
//                                                                                   
//                                                                            , 'I', (SELECT 'X'
//                                                                                      FROM OCS2003 AA
//                                                                                     WHERE AA.HOSP_CODE = A.HOSP_CODE
//                                                                                       AND AA.PKOCS2003 = A.FKOCS2003)
//                                                                                     
//                                                                                     ) IS NOT NULL
//
//                                                 ORDER BY A.ORDER_DATE, A.XRAY_GUBUN, A.XRAY_CODE, B.XRAY_CODE_IDX";

//            this.layRadioHistory.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//            this.layRadioHistory.SetBindVarValue("f_bunho", this.paBox.BunHo);
//            this.layRadioHistory.SetBindVarValue("f_part_code", this.cboPart.GetDataValue());
            #endregion

            // updated by Cloud
            layRadioHistory.ExecuteQuery = GetLayRadioHistory;

            if (this.layRadioHistory.QueryLayout(true))
            {
                //dwRadioHistory.Reset();
                //ApplyMultiLangDataWindow();

                ////dwRadioHistory.Modify("t_12.text = '" + this.cboIO.Text + "'");
                //dwRadioHistory.Modify("t_13.text = '" + this.cboPart.Text + "'");

                //dwRadioHistory.FillData(layRadioHistory.LayoutTable);
                //dwRadioHistory.Refresh();
            }
        }
        #endregion

        #region dw
        private void dwReserList_Click(object sender, System.EventArgs e)
        {
       //     dwRadioHistory.Refresh();
        }

        private void dwReserList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
       //     dwRadioHistory.Refresh();
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

                    if (this.layRadioHistory.RowCount > 0)
                    {
                        //this.dwRadioHistory.Reset();

                        //this.dwRadioHistory.FillData(this.layRadioHistory.LayoutTable);

                        //this.dwRadioHistory.Refresh();

                        //this.dwRadioHistory.Print();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [Combo SelectedIndexChanged]
        private void cboIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cboPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region [患者番号選択]
        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region Cloud updated code

        #region GetLayRadioHistory
        /// <summary>
        /// GetLayRadioHistory
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayRadioHistory(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT7001Q01LayRadioHistoryArgs args = new XRT7001Q01LayRadioHistoryArgs();
            args.Bunho = this.paBox.BunHo;
            args.PartCode = this.cboPart.GetDataValue();
            XRT7001Q01LayRadioHistoryResult res = CloudService.Instance.Submit<XRT7001Q01LayRadioHistoryResult,
                XRT7001Q01LayRadioHistoryArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayRadioHistoryList.ForEach(delegate(XRT7001Q01LayRadioHistoryListItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.Suname,
                        item.Gwa,
                        item.Doctor,
                        item.OrderDate,
                        item.JundalPart,
                        item.XrayCode,
                        item.XrayName,
                        item.XrayCodeIdx,
                        item.XrayCodeIdxNm,
                        item.TubeVol,
                        item.TubeCur,
                        item.XrayTime,
                        item.TubeCurTime,
                        item.IrradiationTime,
                        item.XrayDistance,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetCboPart
        /// <summary>
        /// GetCboPart
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboPart(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ComboResult res = CacheService.Instance.Get<CboPartArgs, ComboResult>(new CboPartArgs());

            if (null != res && null != res.ComboItem)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}

