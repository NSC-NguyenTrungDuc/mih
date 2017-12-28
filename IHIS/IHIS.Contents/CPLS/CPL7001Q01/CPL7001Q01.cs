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
using IHIS.CPLS.Properties;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL7001Q02에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL7001Q01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel2;
    //    private IHIS.Framework.XDataWindow dwDailyReport;
        private XLabel xLabel12;
        private XDictComboBox cboIO;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private MultiLayout layDailyReport;
        private XLabel xLabel1;
        private XDictComboBox cboUitak;
        private XDatePicker dtKensaDate;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CPL7001Q01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // Updated by Cloud
            layDailyReport.ParamList = new List<string>(new string[] { "f_io_gubun", "f_kensa_date", "f_uitak_code" });

            cboUitak.ExecuteQuery = GetUiTakCombo;
            cboUitak.SetDictDDLB();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL7001Q01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dtKensaDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboUitak = new IHIS.Framework.XDictComboBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.cboIO = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.layDailyReport = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDailyReport)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dtKensaDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.cboUitak);
            this.xPanel1.Controls.Add(this.xLabel12);
            this.xPanel1.Controls.Add(this.cboIO);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // dtKensaDate
            // 
            resources.ApplyResources(this.dtKensaDate, "dtKensaDate");
            this.dtKensaDate.IsVietnameseYearType = false;
            this.dtKensaDate.Name = "dtKensaDate";
            this.dtKensaDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtFromDate_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Name = "xLabel1";
            // 
            // cboUitak
            // 
            resources.ApplyResources(this.cboUitak, "cboUitak");
            this.cboUitak.ExecuteQuery = null;
            this.cboUitak.Name = "cboUitak";
            this.cboUitak.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboUitak.ParamList")));
            this.cboUitak.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboUitak.UserSQL = resources.GetString("cboUitak.UserSQL");
            this.cboUitak.SelectedIndexChanged += new System.EventHandler(this.cboUitak_SelectedIndexChanged);
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
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Name = "xLabel2";
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
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.CPLS.Properties.Resources.TEXT001, -1, global::IHIS.CPLS.Properties.Resources.TEXT001),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Preview, System.Windows.Forms.Shortcut.None, global::IHIS.CPLS.Properties.Resources.TEXT002, -1, global::IHIS.CPLS.Properties.Resources.TEXT002),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, global::IHIS.CPLS.Properties.Resources.TEXT003, -1, global::IHIS.CPLS.Properties.Resources.TEXT003),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.CPLS.Properties.Resources.TEXT004, -1, global::IHIS.CPLS.Properties.Resources.TEXT004)});
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // layDailyReport
            // 
            this.layDailyReport.ExecuteQuery = null;
            this.layDailyReport.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem17,
            this.multiLayoutItem18});
            this.layDailyReport.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDailyReport.ParamList")));
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "gumsa_date";
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
            this.multiLayoutItem12.DataName = "gwa";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "doctor";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "hangmog_code";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "hangmog_name";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "specimen_ser";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "specimen_name";
            // 
            // CPL7001Q01
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL7001Q01";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CPL7001Q01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDailyReport)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyDataWindowLanguage();

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void ApplyDataWindowLanguage()
        {

            ////dwDailyReport
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
            //if (NetInfo.Language != LangMode.Jr)
            //{
            //    dwDailyReport.Modify(string.Format("t_1.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_2.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_3.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_4.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_5.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_6.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_7.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_8.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_9.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_10.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_11.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_12.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_13.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_14.Font.Face = '{0}'", Service.COMMON_FONT.Name));
            //    dwDailyReport.Modify(string.Format("t_15.Font.Face = '{0}'", Service.COMMON_FONT.Name));

            //    dwDailyReport.Modify("t_1.Font.Height = '14'");
            //    dwDailyReport.Modify("t_2.Font.Height = '14'");
            //    dwDailyReport.Modify("t_3.Font.Height = '14'");
            //    dwDailyReport.Modify("t_4.Font.Height = '14'");
            //    dwDailyReport.Modify("t_5.Font.Height = '14'");
            //    dwDailyReport.Modify("t_6.Font.Height = '18'");
            //    dwDailyReport.Modify("t_7.Font.Height = '14'");
            //    dwDailyReport.Modify("t_8.Font.Height = '14'");
            //    dwDailyReport.Modify("t_9.Font.Height = '14'");
            //    dwDailyReport.Modify("t_10.Font.Height = '14'");
            //    dwDailyReport.Modify("t_11.Font.Height = '14'");
            //    dwDailyReport.Modify("t_12.Font.Height = '14'");
            //    dwDailyReport.Modify("t_13.Font.Height = '14'");
            //    dwDailyReport.Modify("t_14.Font.Height = '14'");
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

            this.cboUitak.SelectedIndex = 0;
        }
        #endregion

        #region layMonthlyReportQuery
        private void layDailyReportQuery()
        {
  //          dwDailyReport.Reset();
            ApplyDataWindowLanguage();

            layDailyReport.Reset();

            #region deleted by Cloud
//            this.layDailyReport.QuerySQL = @"SELECT :f_kensa_date GUMSA_DATE
//                                                  , A.BUNHO BUNHO
//                                                  , A.SUNAME SUNAME
//                                                  , DECODE(A.IN_OUT_GUBUN, 'O', FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE), FN_BAS_LOAD_GWA_NAME(A.HO_DONG, A.ORDER_DATE)|| '-' || A.HO_CODE) GWA
//                                                  , A.DOCTOR_NAME DOCTOR_NAME
//                                                  , A.HANGMOG_CODE HANGMOG_CODE
//                                                  , C.HANGMOG_NAME HANGMOG_NAME
//                                                  , A.SPECIMEN_SER
//                                                  , (SELECT X.CODE_NAME
//                                                       FROM CPL0109 X
//                                                      WHERE X.HOSP_CODE = A.HOSP_CODE
//                                                        AND X.CODE_TYPE = '04'
//                                                        AND X.CODE      = A.SPECIMEN_CODE)  SPECIMEN_NAME
//                                               FROM OCS0103 C
//                                                  , CPL0101 B
//                                                  , CPL2010 A
//                                              WHERE A.HOSP_CODE = :f_hosp_code
//                                                AND NVL(A.RESER_DATE, A.ORDER_DATE) = :f_kensa_date
//                                                AND A.IN_OUT_GUBUN  LIKE :f_io_gubun
//                                                AND A.UITAK_CODE    LIKE :f_uitak_code
//                                                AND A.PART_JUBSU_DATE IS NOT NULL
//                                                AND A.DC_YN         = 'N'
//                                                AND B.HOSP_CODE     = A.HOSP_CODE
//                                                AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                AND B.EMERGENCY     = A.EMERGENCY
//                                                --AND B.TONG_GUBUN    = 'Y'
//                                                AND C.HOSP_CODE     = A.HOSP_CODE
//                                                AND C.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                AND A.ORDER_DATE    BETWEEN C.START_DATE AND C.END_DATE
//                                              ORDER BY A.BUNHO
//                                                     , GWA
//                                                     , DOCTOR_NAME
//                                                     , SPECIMEN_NAME
//                                                     , HANGMOG_CODE";
            #endregion

            // Updated by Cloud
            layDailyReport.ExecuteQuery = GetLayDailyReport;

            //this.layReserList01.QuerySQL += @"ORDER BY 9 /*JUNDAL_PART*/ , 10 /*RESER_DATE*/ , 11 /*RESER_TIME*/ , 4 /*BUNHO*/";
            //// 디스플레이 용
            //this.dwMonthlyReport.DataWindowObject = "d_reser_list_01";

            //// 프린트 용
            //this.dwMonthlyReportPrn.DataWindowObject = "d_reser_list_prn";


            this.layDailyReport.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDailyReport.SetBindVarValue("f_kensa_date", this.dtKensaDate.GetDataValue());
            this.layDailyReport.SetBindVarValue("f_io_gubun", this.cboIO.GetDataValue());
            this.layDailyReport.SetBindVarValue("f_uitak_code", this.cboUitak.GetDataValue());


            if (this.layDailyReport.QueryLayout(true))
            {
                //dwDailyReport.Reset();
                //dwDailyReport.Modify("t_13.text = '" + this.cboIO.Text + "'");
                //dwDailyReport.Modify("t_14.text = '" + this.cboUitak.Text + "'");

                //dwDailyReport.FillData(layDailyReport.LayoutTable);
                //dwDailyReport.Refresh();
            }
        }
        #endregion                

        #region dw
        private void dwReserList_Click(object sender, System.EventArgs e)
        {
     //       dwDailyReport.Refresh();
        }

        private void dwReserList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
      //      dwDailyReport.Refresh();
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

                    //if (this.layDailyReport.RowCount > 0)
                    //{
                    //    this.dwDailyReport.Reset();

                    //    this.dwDailyReport.FillData(this.layDailyReport.LayoutTable);

                    //    this.dwDailyReport.Refresh();

                    //    this.dwDailyReport.Print();
                    //}
                    break;
                case FunctionType.Preview:
                    e.IsBaseCall = false;
      //              dwDailyReport.Export(true);
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

        private void cboUitak_SelectedIndexChanged(object sender, EventArgs e)
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

        #region GetUiTakCombo
        /// <summary>
        /// GetUiTakCombo
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetUiTakCombo(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            //ComboResult res = CacheService.Instance.Get<ComboCplsUiTakArgs, ComboResult>(
            //    Constants.CacheKeyCbo.CACHE_CPLS_CBO_UITAK, new ComboCplsUiTakArgs(), delegate(ComboResult result)
            //    {
            //        return result.ExecutionStatus == ExecutionStatus.Success
            //            && null != result.ComboItem
            //            && result.ComboItem.Count > 0;
            //    });
            //ComboResult res = CacheService.Instance.Get<ComboCplsUiTakArgs, ComboResult>(new ComboCplsUiTakArgs(), delegate(ComboResult result)
            //    {
            //        return result.ExecutionStatus == ExecutionStatus.Success
            //            && null != result.ComboItem
            //            && result.ComboItem.Count > 0;
            //    });

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            // https://sofiamedix.atlassian.net/browse/MED-16358
            ComboResult res = CloudService.Instance.Submit<ComboResult, CPL3010U01GetCboCompanyArgs>(new CPL3010U01GetCboCompanyArgs());
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

            CPL7001Q01LayDailyReportArgs args = new CPL7001Q01LayDailyReportArgs();
            args.IoGubun = bvc["f_io_gubun"].VarValue;
            args.KensaDate = bvc["f_kensa_date"].VarValue;
            args.UitakCode = bvc["f_uitak_code"].VarValue;
            CPL7001Q01LayDailyReportResult res = CloudService.Instance.Submit<CPL7001Q01LayDailyReportResult,
                CPL7001Q01LayDailyReportArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ListIem.ForEach(delegate(CPL7001Q01LayDailyReportInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.GumsaDate,
                        item.Bunho,
                        item.Suname,
                        item.Gwa,
                        item.DoctorName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SpecimenSer,
                        item.SpecimenName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}

