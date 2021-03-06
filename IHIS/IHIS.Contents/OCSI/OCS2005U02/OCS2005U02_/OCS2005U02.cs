using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using System.Globalization;

namespace IHIS.OCSI
{
    public partial class OCS2005U02 : XScreen
    {
        private ToolTip toolTip;
        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        private string sik_gubun = "";
        private string mCurrentFKINP1001 = "";

        private bool mCalSwitch = true;
        
        private string mParamBunho = "";
        private string mCalledSystemID = "";
        private string mHodong = "";
        private string mHocode = "";
        private string mPRESSED_JAEWON_YN = "Y";

        private string SIKJONG  = "003";
        private string JUSIK    = "007";
        private string BUSIK    = "007";
        private string NOMIMONO = "002";

        private string SIKJONG_JOU = "001";
        private string JUSIK_JOU = "001";
        private string BUSIK_JOU = "001";
        private string NOMIMONO_JOU = "002";

        private const string BLD_BREAKFAST = "1";
        private const string BLD_LUNCH = "2";
        private const string BLD_DINNER = "3";

        private const string SIKJIN1TH = "11";
        private const string SIKJIN2TH = "12";
        private const string SIKJIN3TH = "13";
        private const string SIKJIN4TH = "14";
        private const string SIKJIN5TH = "15";

        private XEditGrid GRD = new XEditGrid();

        private XComboBox CBO_SIKJONG = new XComboBox();
        private XComboBox CBO_JUSIK = new XComboBox();
        private XComboBox CBO_BUSIK = new XComboBox();
        private XComboBox CBO_NOMIMONO = new XComboBox();
        private XTextBox TXT_COMMENT = new XTextBox();
        
        private XDatePicker DTP_FROM = new XDatePicker();
        private XDatePicker DTP_TO = new XDatePicker();
        
        private XTabControl TAB = new XTabControl();

        private string BLD_GUBUN_STR = "";

        private XRadioButton RBT_G = new XRadioButton();
        private XRadioButton RBT_S = new XRadioButton();
        private XRadioButton RBT_K = new XRadioButton();

        private XPanel PANEL_I = new XPanel();
        private XPanel PANEL_S = new XPanel();

        string FocusedFlag = "";
        private ArrayList Recover_List = new ArrayList();
        private ArrayList Recover_ListD = new ArrayList();
        private ArrayList Today_No_Magam_List = new ArrayList();
        private string mToiwon_date = "0";
        private string mPKINP1001 = "";

        //private string sik_start_gubun = "";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 라디오 버튼 관련 변수
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));
        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        
        public OCS2005U02()
        {
            InitializeComponent();

            this.grdOCS2005_B.SavePerformer = new XSavePerformer(this);
            this.grdOCS2005_L.SavePerformer = this.grdOCS2005_B.SavePerformer;
            this.grdOCS2005_D.SavePerformer = this.grdOCS2005_L.SavePerformer;
            
        }

        private void OCS2005U02_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
            this.mOrderBiz = new IHIS.OCS.OrderBiz(this.Name.ToString());             // OCS 그룹 Business 라이브러리


            xToolTip1.SetToolTip(tabOrderDate_b, "ドラッグ(DRAG)でコピーできます。");
            xToolTip1.SetToolTip(tabOrderDate_l, "ドラッグ(DRAG)でコピーできます。");
            xToolTip1.SetToolTip(tabOrderDate_d, "ドラッグ(DRAG)でコピーできます。");

            this.setComboBox("ALL");
            
            this.dtpOrder_date.SetDataValue(EnvironInfo.GetSysDate());


            this.PostLoad();

            if (this.OpenParam != null)
            {
                
                if (this.OpenParam.Contains("hodong"))
                {
                    this.mHodong = this.OpenParam["hodong"].ToString();
                    this.cboHodong.SetDataValue(this.mHodong);
                }
                if (this.OpenParam.Contains("hocode"))
                {
                    this.mHocode = this.OpenParam["hocode"].ToString();
                    this.cboHocode.SetDataValue(this.mHocode);
                }
                if (this.OpenParam.Contains("bunho"))
                {
                    this.mParamBunho = this.OpenParam["bunho"].ToString();
                    this.paBox.SetPatientID(this.mParamBunho);
                }
            }

            


            //switch (Opener.GetType().BaseType.Name)
            //{
            //    case "XScreen":
            //        if (((XScreen)Opener).ScreenID.ToString() != "")
            //            this.mCalledSystemID = ((XScreen)Opener).ScreenID.ToString();
            //        break;

            //    case "Form":
            //        if (((MdiForm)Opener).SystemID.ToString() != "")
            //            this.mCalledSystemID = "";
            //        break;
            //}

            

            //this.grdPatientList.CellInfos["suname2"].CellWidth = 0;
            //this.grdPatientList.AutoSizeColumn(4, 0);
            ////btnExpand.ImageIndex = 17;
            ////tipText = "患者番号非表示";
            ////this.toolTip.SetToolTip((Control)sender, tipText);
            //this.grdPatientList.Refresh();    


            this.timerGetMagamStatus.Start();
            this.initScreen();
        }
        private void initScreen()
        {
            this.dtpToiwonDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(1));
            this.dtpStopFromDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(1));
            this.dtpStopToDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(1));
            this.dtpSikJin.SetDataValue(EnvironInfo.GetSysDate().AddDays(1));

            this.cboStopFromBLD.SelectedIndex = 0;
            this.cboStopToBLD.SelectedIndex = 2;
            this.cboToiwonBLD.SelectedIndex = 1;
            this.cboGubun.SelectedIndex = 0;
            this.cboSikJin.SelectedIndex = 0;
            this.cboSikJinNum.SelectedIndex = 0;
            this.cboSikJinNomimono.SelectedIndex = 0;

            this.pnlStop.Visible = true;
            this.pnlToiwon.Visible = false;
            this.pnlSikJin.Visible = false;

            //if (this.mCalledSystemID == "OCS2003U99")
            //{
            //    this.rbtToiwonProcess.Visible = false;
            //    this.rbtSikJinProcess.Visible = false;
            //}

            getMagamStatus();
        }

        //   [0][ ]:食種
        //   [1][ ]:主食
        //   [2][ ]:副食
        //   [3][ ]:飲物
        //   [4][ ]:コメント
        //   [*][0]:コード
        //   [ ][0]:コード名
        //   [ ][0]:SORT    
        private void setComboBox(string mode)
        {
            XEditGrid grd = new XEditGrid();
            XComboBox cbo_s = new XComboBox();
            XComboBox cbo_j = new XComboBox();
            XComboBox cbo_b = new XComboBox();
            XComboBox cbo_n = new XComboBox();
            
            string cmd = @" SELECT A.NUR_MD_CODE, A.NUR_MD_NAME, A.SORT_KEY
                              FROM NUR0111 A 
                             WHERE A.HOSP_CODE    = '" + EnvironInfo.HospCode + @"'
                               AND A.NUR_GR_CODE  = '03'
                               AND SUBSTR(A.NUR_MD_CODE, 3, 1) = '" + TypeCheck.NVL(sik_gubun, "0") + @"'
                               AND A.NUR_MD_CODE != '0301'
                             UNION
                            SELECT A.NUR_MD_CODE, A.NUR_MD_NAME, A.SORT_KEY
                              FROM NUR0111 A
                             WHERE A.NUR_GR_CODE = '03'
                               AND A.NUR_MD_CODE IN ('0305','0309')
                             ORDER BY 3";
            DataTable dt = Service.ExecuteDataTable(cmd);

            if (mode == "ALL" || mode == BLD_BREAKFAST)
            {
                cbo_s = this.cboSikjong_b;
                cbo_j = this.cboJusik_b;
                cbo_b = this.cboBusik_b;
                cbo_n = this.cboNomimono_b;
                grd = this.grdOCS2005_B;
            }
            if (mode == "ALL" || mode == BLD_LUNCH)
            {
                cbo_s = this.cboSikjong_l;
                cbo_j = this.cboJusik_l;
                cbo_b = this.cboBusik_l;
                cbo_n = this.cboNomimono_l;
                grd = this.grdOCS2005_L;
            }
            if (mode == "ALL" || mode == BLD_DINNER)
            {
                cbo_s = this.cboSikjong_d;
                cbo_j = this.cboJusik_d;
                cbo_b = this.cboBusik_d;
                cbo_n = this.cboNomimono_d;
                grd = this.grdOCS2005_D;
            }

            if (mode == SIKJIN1TH)
            {
                cbo_s = this.cboSikjongN1;
                cbo_j = this.cboJusikN1;
                cbo_b = this.cboBusikN1;
            }
            if (mode == SIKJIN2TH)
            {
                cbo_s = this.cboSikjongN2;
                cbo_j = this.cboJusikN2;
                cbo_b = this.cboBusikN2;
            }
            if (mode == SIKJIN3TH)
            {
                cbo_s = this.cboSikjongN3;
                cbo_j = this.cboJusikN3;
                cbo_b = this.cboBusikN3;
            }
            if (mode == SIKJIN4TH)
            {
                cbo_s = this.cboSikjongN4;
                cbo_j = this.cboJusikN4;
                cbo_b = this.cboBusikN4;
            }
            if (mode == SIKJIN5TH)
            {
                cbo_s = this.cboSikjongN5;
                cbo_j = this.cboJusikN5;
                cbo_b = this.cboBusikN5;
            }
            if(cbo_s != null)
                this.setComboBox(cbo_s, "sik_jong", "%", dt);
            if (cbo_j != null)
                this.setComboBox(cbo_j, "sik_ju", "%", dt);
            if (cbo_b != null)
                this.setComboBox(cbo_b, "sik_bu", "%", dt);
            if (cbo_n != null)
                this.setComboBox(cbo_n, "sik_nomimono", "%", dt);
        }

        private void setComboBox(XComboBox cbo, string gubun, string aArgu1, DataTable dt)
        {
            DataTable dtTemp;
            dtTemp = LoadComboDataSource(gubun, aArgu1, dt).LayoutTable;
            cbo.SetComboItems(dtTemp, "code_name", "code");
            //cbo.SelectedIndex = 0;
            cbo.MaxDropDownItems = 30;
        }

        public MultiLayout LoadComboDataSource(string gubun, string aArgu1, DataTable dt)
        {
            IHIS.Framework.MultiLayout layCombo = new MultiLayout();

            layCombo.Reset();
            layCombo.LayoutItems.Clear();
            layCombo.LayoutItems.Add("code", DataType.String);
            layCombo.LayoutItems.Add("code_name", DataType.String);
            
            layCombo.InitializeLayoutTable();

            string code = "";

            

            switch (gubun)
            {
                case "sik_jong":
                    code = dt.Rows[0][0].ToString();
                    break;
                case "sik_ju":
                    code = dt.Rows[1][0].ToString();
                    break;
                case "sik_bu":
                    code = dt.Rows[2][0].ToString();
                    break;
                case "sik_nomimono":
                    code = dt.Rows[3][0].ToString();
                    break;

                default:
                    return layCombo; // 빈상태로 넘긴다
                    
            }

            layCombo.QuerySQL = @"  SELECT ' '   CODE
                                         , ' '   CODE_NAME
                                         , 0     SORT_KEY
                                      FROM SYS.DUAL
                                     UNION
                                    SELECT A.NUR_SO_CODE CODE
                                         , A.NUR_SO_NAME CODE_NAME
                                         , A.SORT_KEY    SORT_KEY
                                      FROM NUR0112 A 
                                     WHERE A.HOSP_CODE   = '" + EnvironInfo.HospCode + @"'
                                       AND A.NUR_MD_CODE = '" + code + @"' 
                                       AND A.VALD        = 'Y'
                                     ORDER BY 3"
                                       ;

            layCombo.QueryLayout(true);

            return layCombo;

        }
        private void PostLoad()
        {
            createHoDong();
            createHoCode();

            this.rbtJaewon.Checked = true;

            //if (this.grdPatientList.QueryLayout(false))
            //{
            //    this.rbtJaewon.Checked = true;
            //}
        }
        private void createHoDong()
        {
            this.cboHodong.UserSQL = @"SELECT 'EMPTY'
                                            , '未指定'
                                         FROM SYS.DUAL
                                        UNION
                                       SELECT A.CODE
                                            , A.CODE_NAME
                                         FROM VW_IFS_IF_SKJ_HO_DONG A
                                        WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()";
            this.cboHodong.SelectedIndex = 0;
        }
        private void createHoCode()
        {
            this.cboHocode.SetBindVarValue("f_ho_dong", this.cboHodong.GetDataValue());
            this.cboHocode.SetBindVarValue("f_order_date", this.dtpOrder_date.GetDataValue());
            
            this.cboHocode.InitializeLifetimeService();
            this.cboHocode.UserSQL = @"SELECT '%', '全体' 
                                         FROM SYS.DUAL
                                        UNION 
                                       SELECT 'EMPTY', '未指定' 
                                         FROM SYS.DUAL
                                        UNION 
                                       SELECT A.HO_CODE
                                            , A.HO_CODE_NAME
                                         FROM BAS0250 A
                                        WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                          AND A.HO_DONG   LIKE :f_ho_dong
                                          AND TO_DATE(:f_order_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                          AND A.START_DATE = (SELECT MAX(Z.START_DATE)
                                                                FROM BAS0250 Z
                                                               WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                                 AND Z.HO_DONG   = A.HO_DONG
                                                                 AND Z.HO_CODE   = A.HO_CODE
                                                                 AND Z.START_DATE <=  TO_DATE(:f_order_date, 'YYYY/MM/DD'))"
                ;
            this.cboHocode.AcceptData();
            this.cboHocode.SelectedIndex = 0;
        }

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPatientList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPatientList.SetBindVarValue("f_ho_dong", this.cboHodong.SelectedValue.ToString());
            this.grdPatientList.SetBindVarValue("f_ho_code", TypeCheck.NVL(this.cboHocode.SelectedValue, "%").ToString());
            //this.grdPatientList.SetBindVarValue("f_team", this.cboTeam.SelectedValue.ToString());
            this.grdPatientList.SetBindVarValue("f_order_date", this.dtpOrder_date.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_bunho", TypeCheck.NVL(this.paBox.BunHo.ToString(), "%").ToString());
            this.grdPatientList.SetBindVarValue("f_jaewon_yn", this.rbtJaewon.Checked == true? "Y" : "N" );

        }

        private void cboHodong_SelectedValueChanged(object sender, EventArgs e)
        {
            createHoCode();
            this.paBox.SetPatientID("");

            this.grdPatientList.QueryLayout(false);
                //PostCallHelper.PostCall(this.filter);

        }
        private void filter()
        {
            this.grdPatientList.SetFilter("jaewon_yn = '" + mPRESSED_JAEWON_YN + "'");
        }
        private void AllReset()
        {
            this.grdOCS2005_B.Reset();
            this.grdOCS2005_L.Reset();
            this.grdOCS2005_D.Reset();

            this.tabOrderDate_b.TabPages.Clear();
            this.tabOrderDate_l.TabPages.Clear();
            this.tabOrderDate_d.TabPages.Clear();

            this.cboSikjong_b.ResetData();
            this.cboSikjong_l.ResetData();
            this.cboSikjong_d.ResetData();

            this.cboJusik_b.ResetData();
            this.cboJusik_d.ResetData();
            this.cboJusik_l.ResetData();
            
            this.cboBusik_b.ResetData();
            this.cboBusik_d.ResetData();
            this.cboBusik_l.ResetData();

            this.cboNomimono_b.ResetData();
            this.cboNomimono_d.ResetData();
            this.cboNomimono_l.ResetData();
            
        }
        private void cboHocode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!this.paBox.BunHo.Equals(""))
            {
                AllReset();

                this.paBox.SetPatientID("");
            }

            this.grdPatientList.QueryLayout(false);
            //this.grdPatientList.SetFilter("jaewon_yn = '" + mPRESSED_JAEWON_YN + "'");
        }
        private void rbtSik_Gubun_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rbt = sender as XRadioButton;

            XComboBox cboN1 = new XComboBox();
            XComboBox cboN2 = new XComboBox();
            XComboBox cboN3 = new XComboBox();

            if (rbt.Checked == true)
            {
                switch(rbt.Tag.ToString())
                {
                    case "1":
                    case "2":
                    case "3":
                        this.SetBLDControl(rbt.Tag.ToString());
                        break;
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                    case "15":

                        switch (rbt.Tag.ToString())
                        {
                            case "11":
                                cboN1 = this.cboSikjongN1;
                                cboN2 = this.cboJusikN1;
                                cboN3 = this.cboBusikN1;

                                break;
                            case "12":
                                cboN1 = this.cboSikjongN2;
                                cboN2 = this.cboJusikN2;
                                cboN3 = this.cboBusikN2;

                                break;
                            case "13":
                                cboN1 = this.cboSikjongN3;
                                cboN2 = this.cboJusikN3;
                                cboN3 = this.cboBusikN3;

                                break;
                            case "14":
                                cboN1 = this.cboSikjongN4;
                                cboN2 = this.cboJusikN4;
                                cboN3 = this.cboBusikN4;

                                break;
                            case "15":
                                cboN1 = this.cboSikjongN5;
                                cboN2 = this.cboJusikN5;
                                cboN3 = this.cboBusikN5;

                                break;
                        }

                        this.BLD_GUBUN_STR = "【食進】";
                        this.GRD = null;
                        this.CBO_SIKJONG = null;
                        this.CBO_JUSIK = null;
                        this.CBO_BUSIK = null;
                        this.CBO_NOMIMONO = null;
                        this.TXT_COMMENT = null;
                        this.DTP_FROM = null;
                        this.DTP_TO = null;
                        this.TAB = null;
                        this.RBT_G = null;
                        this.RBT_S = null;
                        this.RBT_K = null;
                        this.PANEL_I = null;
                        this.PANEL_S = null;
                        break;
                }
                

                this.sik_gubun = rbt.CheckedValue;
                this.setComboBox(rbt.Tag.ToString());

                // direct_code setting
                if (this.GRD != null)
                {
                    int currRow = this.GRD.CurrentRowNumber;

                    switch (this.sik_gubun)
                    {
                        case "0": // 一般食
                            this.GRD.SetItemValue(currRow, "direct_code", "0301");
                            this.GRD.SetItemValue(currRow, "direct_code_d", "000");
                            this.GRD.SetItemValue(currRow, "direct_cont1", "0302");
                            this.GRD.SetItemValue(currRow, "direct_cont2", "0303");
                            this.GRD.SetItemValue(currRow, "direct_cont3", "0304");
                            this.PANEL_I.Visible = true;
                            this.PANEL_S.Visible = false;
                            break;
                        case "1": // 特別食
                            this.GRD.SetItemValue(currRow, "direct_code", "0301");
                            this.GRD.SetItemValue(currRow, "direct_code_d", "001");
                            this.GRD.SetItemValue(currRow, "direct_cont1", "0312");
                            this.GRD.SetItemValue(currRow, "direct_cont2", "0313");
                            this.GRD.SetItemValue(currRow, "direct_cont3", "0314");
                            this.PANEL_S.Visible = true;
                            this.PANEL_I.Visible = false;
                            break;
                        case "2": // 中止
                            this.GRD.SetItemValue(currRow, "direct_code", "0301");
                            this.GRD.SetItemValue(currRow, "direct_code_d", "009");
                            this.GRD.SetItemValue(currRow, "direct_cont1", "0322");
                            this.GRD.SetItemValue(currRow, "direct_cont2", "0323");
                            this.GRD.SetItemValue(currRow, "direct_cont3", "0324");
                            this.PANEL_S.Visible = false;
                            this.PANEL_I.Visible = false;

                            this.CBO_SIKJONG.SetDataValue("035");
                            this.CBO_JUSIK.SetDataValue("049");
                            this.CBO_BUSIK.SetDataValue("026");
                            break;
                    }
                }
                else
                {
                    switch (this.sik_gubun)
                    {
                        case "2": // 中止
                            cboN1.SetDataValue("035");
                            cboN2.SetDataValue("049");
                            cboN3.SetDataValue("026");
                            break;
                    }
                }
            }


            //XDatePicker dtp_s = new XDatePicker();
            //XDatePicker dtp_e = new XDatePicker();
            //XComboBox cbo_s = new XComboBox();
            //XComboBox cbo_j = new XComboBox();
            //XComboBox cbo_b = new XComboBox();
            //XComboBox cbo_n = new XComboBox();
            //XEditGrid grd = new XEditGrid();
            //if (rbt.Checked == true)
            //{
            //    switch (rbt.Tag.ToString())
            //    {
            //        case BLD_BREAKFAST:
            //            grd = this.grdOCS2005_B;
            //            dtp_s = this.dtpStartDate_b;
            //            dtp_e = this.dtpEndDate_b;
            //            cbo_s = this.cboSikjong_b;
            //            cbo_j = this.cboJusik_b;
            //            cbo_b = this.cboBusik_b;
            //            cbo_n = this.cboNomimono_b;
            //            break;
            //        case BLD_LUNCH:
            //            grd = this.grdOCS2005_L;
            //            dtp_s = this.dtpStartDate_l;
            //            dtp_e = this.dtpEndDate_l;
            //            cbo_s = this.cboSikjong_l;
            //            cbo_j = this.cboJusik_l;
            //            cbo_b = this.cboBusik_l;
            //            cbo_n = this.cboNomimono_l;
            //            break;
            //        case BLD_DINNER:
            //            grd = this.grdOCS2005_D;
            //            dtp_s = this.dtpStartDate_d;
            //            dtp_e = this.dtpEndDate_d;
            //            cbo_s = this.cboSikjong_d;
            //            cbo_j = this.cboJusik_d;
            //            cbo_b = this.cboBusik_d;
            //            cbo_n = this.cboNomimono_d;
            //            break;
            //    }
            //    int currRow = grd.CurrentRowNumber;
            //    this.sik_gubun = rbt.CheckedValue;

            //    if (rbt.Checked == true)
            //        this.setComboBox(rbt.Tag.ToString());


            //    // direct_code setting
            //    switch (this.sik_gubun)
            //    {
            //        case "0": // 一般食
            //            grd.SetItemValue(currRow, "direct_code", "0301");
            //            grd.SetItemValue(currRow, "direct_code_d", "000");
            //            grd.SetItemValue(currRow, "direct_cont1", "0302");
            //            grd.SetItemValue(currRow, "direct_cont2", "0303");
            //            grd.SetItemValue(currRow, "direct_cont3", "0304");
            //            break;
            //        case "1": // 特別食
            //            grd.SetItemValue(currRow, "direct_code", "0301");
            //            grd.SetItemValue(currRow, "direct_code_d", "001");
            //            grd.SetItemValue(currRow, "direct_cont1", "0312");
            //            grd.SetItemValue(currRow, "direct_cont2", "0313");
            //            grd.SetItemValue(currRow, "direct_cont3", "0314");
            //            break;
            //        case "2": // 中止
            //            grd.SetItemValue(currRow, "direct_code", "0301");
            //            grd.SetItemValue(currRow, "direct_code_d", "009");
            //            grd.SetItemValue(currRow, "direct_cont1", "0322");
            //            grd.SetItemValue(currRow, "direct_cont2", "0323");
            //            grd.SetItemValue(currRow, "direct_cont3", "0324");

            //            cbo_s.SetDataValue("035");
            //            cbo_j.SetDataValue("049");
            //            cbo_b.SetDataValue("026");
            //            break;
            //    }
            //}
        }

        private void rbtSikStartGubun_CheckedChanged(object sender, EventArgs e)
        {
            this.setComboBox("ALL");
        }

        #region GetPkSeq()
        /// <summary>
        /// INSERTする為に患者番号とfkinp1001でPK_SEQのMAXの値を取得する
        /// </summary>
        /// <param name="bindVars"></param>
        /// <returns></returns>
        private string GetPkSeq(BindVarCollection bindVars)
        {
            string cmdText = @"SELECT NVL(MAX(PK_SEQ), 0) + 1 PK_SEQ
                                  FROM OCS2005
                                 WHERE BUNHO             = :f_bunho
                                   AND FKINP1001         = :f_fkinp1001
                                   AND TRUNC(ORDER_DATE) = TRUNC(SYSDATE)
                                   AND HOSP_CODE         = :f_hosp_code";

            return Service.ExecuteScalar(cmdText, bindVars).ToString();
        }
        #endregion


        #region GetPkInp1001()
        /// <summary>
        /// 患者番号でその患者のPKINP1001を取得する
        /// </summary>
        /// <returns>pkinp1001</returns>
        private string GetPkInp1001()
        {
            string cmdText = string.Format(@"SELECT PKINP1001
                                               FROM INP1001 A
                                              WHERE BUNHO       = {0}
                                                AND JAEWON_FLAG = '{2}'
                                                AND HOSP_CODE   = '{1}'
                                              ORDER BY A.PKINP1001 DESC", paBox.BunHo, EnvironInfo.HospCode, this.mPRESSED_JAEWON_YN);

            object retVal = Service.ExecuteScalar(cmdText);

            if (retVal == null)
            {
                cmdText = string.Format(@"SELECT RESER_FKINP1001
                                               FROM INP1003
                                              WHERE BUNHO          = {0}
                                                AND RESER_END_TYPE = '0'
                                                AND HOSP_CODE      = '{1}'", paBox.BunHo, EnvironInfo.HospCode);

                retVal = Service.ExecuteScalar(cmdText);

                //XMessageBox.Show("在院中の患者ではありません。", "患者ID入力ミス", MessageBoxIcon.Error);
                //return "0";
            }
            if (retVal == null)
            {
                XMessageBox.Show("該当する患者がありません。", "");
                return "0";
            }
            else
                return retVal.ToString();
        }
        #endregion

        #region GetIpwon_Date()
        /// <summary>
        /// 患者の入院日を取得する
        /// </summary>
        /// <returns>pkinp1001</returns>
        private string GetIpwon_Date()
        {
            string cmdText = string.Format(@"SELECT TO_CHAR(IPWON_DATE, 'YYYY/MM/DD')
                                               FROM INP1001
                                              WHERE BUNHO       = {0}
                                                AND JAEWON_FLAG = '{2}'
                                                AND HOSP_CODE   = '{1}'", paBox.BunHo, EnvironInfo.HospCode, this.mPRESSED_JAEWON_YN);

            object retVal = Service.ExecuteScalar(cmdText);

            if (retVal == null)
            {
                cmdText = string.Format(@"SELECT TO_CHAR(RESER_DATE, 'YYYY/MM/DD')
                                            FROM INP1003
                                           WHERE BUNHO          = {0}
                                             AND RESER_END_TYPE = '0'
                                             AND HOSP_CODE      = '{1}'", paBox.BunHo, EnvironInfo.HospCode);

                retVal = Service.ExecuteScalar(cmdText);

                //XMessageBox.Show("在院中の患者ではありません。", "患者ID入力ミス", MessageBoxIcon.Error);
                //return "0";
            }
            return retVal.ToString();
        }
        #endregion

        private void grdPatientList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            int currRow = grd.GetHitRowNumber(e.Y);

            if (IsSameNameCHK(grd, currRow) == true)
            {
                if (MessageBox.Show("同じ名字又は名前の患者さんが入院されています。\n[漢字名：" + grd.GetItemString(currRow, "suname") + "], \n[カナ名："
                                                                              + grd.GetItemString(currRow, "suname2") + "], \n[年齢："
                                                                              + grd.GetItemString(currRow, "age") + "], \n[病室："
                                                                              + grd.GetItemString(currRow, "ho_dong_name") + " " + grd.GetItemString(currRow, "ho_code") + "号室] \n"
                                                                              + "\nこの患者さんでよろしいでしょうか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            this.paBox.SetPatientID(grd.GetItemString(currRow, "bunho"));
        }

        private bool IsSameNameCHK(XEditGrid aGrd, int aCurrRow)
        {
            string cmd = @"SELECT FN_ADM_IS_SAME_NAME_YN_INP_T(:f_bunho) FROM SYS.DUAL";

            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_bunho", aGrd.GetItemString(aCurrRow, "bunho"));

            object val = Service.ExecuteScalar(cmd, bindVar);

            if (TypeCheck.IsNull(val) == false && val.ToString() == "Y")
                return true;
            else
                return false;
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
            {
                this.AllReset();
            }

            Recover_List = new ArrayList();
            Today_No_Magam_List = new ArrayList();

            this.mPKINP1001 = GetPkInp1001();
            if (mPKINP1001 == "0")
            {
                paBox.Reset();
                paBox.Focus();
                return;
            }
            else
            {
                string cmd = @" SELECT A.TOIWON_DATE
                                  FROM INP1001 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.PKINP1001 = :f_pkinp1001
                              ";
                BindVarCollection bind = new BindVarCollection();
                bind.Add("f_hosp_code", EnvironInfo.HospCode);
                bind.Add("f_pkinp1001", this.mPKINP1001);

                object obj = Service.ExecuteScalar(cmd, bind);
                if (obj != null && obj.ToString() != "")
                    this.mToiwon_date = obj.ToString();
                else
                    this.mToiwon_date = "0";
            }

            tabOrderDate_b.Dispose();
            tabOrderDate_l.Dispose();
            tabOrderDate_d.Dispose();
            tabOrderDate_b = new XTabControl();
            tabOrderDate_l = new XTabControl();
            tabOrderDate_d = new XTabControl();

            this.pnlBreakFast.Controls.Add(this.tabOrderDate_b);
            this.tabOrderDate_b.IDEPixelArea = true;
            this.tabOrderDate_b.IDEPixelBorder = false;
            this.tabOrderDate_b.Location = new System.Drawing.Point(-1, 1);
            this.tabOrderDate_b.Name = "tabOrderDate_b";
            this.tabOrderDate_b.Padding = new System.Windows.Forms.Padding(2);
            this.tabOrderDate_b.Size = new System.Drawing.Size(316, 23);
            this.tabOrderDate_b.TabIndex = 54;
            this.tabOrderDate_b.Tag = "1";
            this.tabOrderDate_b.SelectionChanged += new System.EventHandler(this.tabOrderDate_SelectionChanged);
            this.tabOrderDate_b.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabOrderDate_DragDrop);
            this.tabOrderDate_b.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabOrderDate_MouseDown);
            this.tabOrderDate_b.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabOrderDate_DragEnter);
            this.tabOrderDate_b.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.tabOrderDate_GiveFeedback);
            this.tabOrderDate_b.ClosePressed += new System.EventHandler(this.tabOrderDate_ClosePressed);


            this.pnlLunch.Controls.Add(this.tabOrderDate_l);
            this.tabOrderDate_l.IDEPixelArea = true;
            this.tabOrderDate_l.IDEPixelBorder = false;
            this.tabOrderDate_l.Location = new System.Drawing.Point(-3, 1);
            this.tabOrderDate_l.Name = "tabOrderDate_l";
            this.tabOrderDate_l.Padding = new System.Windows.Forms.Padding(2);
            this.tabOrderDate_l.Size = new System.Drawing.Size(316, 23);
            this.tabOrderDate_l.TabIndex = 55;
            this.tabOrderDate_l.Tag = "2";
            this.tabOrderDate_l.SelectionChanged += new System.EventHandler(this.tabOrderDate_SelectionChanged);
            this.tabOrderDate_l.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabOrderDate_DragDrop);
            this.tabOrderDate_l.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabOrderDate_MouseDown);
            this.tabOrderDate_l.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabOrderDate_DragEnter);
            this.tabOrderDate_l.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.tabOrderDate_GiveFeedback);
            this.tabOrderDate_l.ClosePressed += new System.EventHandler(this.tabOrderDate_ClosePressed);

            this.pnlDinner.Controls.Add(this.tabOrderDate_d);
            this.tabOrderDate_d.IDEPixelArea = true;
            this.tabOrderDate_d.IDEPixelBorder = false;
            this.tabOrderDate_d.Location = new System.Drawing.Point(1, 1);
            this.tabOrderDate_d.Name = "tabOrderDate_d";
            this.tabOrderDate_d.Padding = new System.Windows.Forms.Padding(2);
            this.tabOrderDate_d.Size = new System.Drawing.Size(316, 23);
            this.tabOrderDate_d.TabIndex = 56;
            this.tabOrderDate_d.Tag = "3";
            this.tabOrderDate_d.SelectionChanged += new System.EventHandler(this.tabOrderDate_SelectionChanged);
            this.tabOrderDate_d.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabOrderDate_DragDrop);
            this.tabOrderDate_d.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabOrderDate_MouseDown);
            this.tabOrderDate_d.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabOrderDate_DragEnter);
            this.tabOrderDate_d.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.tabOrderDate_GiveFeedback);
            this.tabOrderDate_d.ClosePressed += new System.EventHandler(this.tabOrderDate_ClosePressed);

            SetTabControl();

            this.SetLabel();
        }
        private void SetLabel()
        {
            this.lbSuname.Text = this.paBox.SuName;
            this.lbSuname2.Text = this.paBox.SuName2;
            this.lbSexAge.Text = this.paBox.Sex + " / " + this.paBox.YearAge;

            if (this.paBox.BunHo != this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"))
            {
                for (int i = 0; i < this.grdPatientList.RowCount; i++)
                {
                    if (this.paBox.BunHo == this.grdPatientList.GetItemString(i, "bunho"))
                    {
                        this.grdPatientList.SetFocusToItem(i, "bunho");
                    }
                }
            }
        }

        private void getMagamStatus()
        {

            #region 食事別最終締切可否

                this.lblB.BackColor = XColor.XLabelBackColor;
                this.lblL.BackColor = XColor.XLabelBackColor;
                this.lblD.BackColor = XColor.XLabelBackColor;

                MultiLayout layMagamStatus = new MultiLayout();

                layMagamStatus.Reset();
                layMagamStatus.LayoutItems.Clear();
                layMagamStatus.LayoutItems.Add("b", DataType.String);
                layMagamStatus.LayoutItems.Add("l", DataType.String);
                layMagamStatus.LayoutItems.Add("d", DataType.String);

                layMagamStatus.InitializeLayoutTable();


                layMagamStatus.QuerySQL = @"SELECT A.NUT_JO_MAGAM_YN    B
                                                 , A.NUT_JU_MAGAM_YN    L
                                                 , A.NUT_SEOK_MAGAM_YN  D
                                              FROM INP5001 A
                                             WHERE A.HOSP_CODE  = :f_hosp_code
                                               AND A.MAGAM_DATE = :f_magam_date";

                layMagamStatus.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                layMagamStatus.SetBindVarValue("f_magam_date", this.dtpOrder_date.GetDataValue());

                layMagamStatus.QueryLayout(false);

                if (layMagamStatus.RowCount > 0)
                {
                    if (layMagamStatus.GetItemString(0, "b") == "Y")
                        this.lblB.BackColor = XColor.ErrMsgForeColor;
                    else
                        this.lblB.BackColor = XColor.XLabelBackColor;

                    if (layMagamStatus.GetItemString(0, "l") == "Y")
                        this.lblL.BackColor = XColor.ErrMsgForeColor;
                    else
                        this.lblL.BackColor = XColor.XLabelBackColor;

                    if (layMagamStatus.GetItemString(0, "d") == "Y")
                        this.lblD.BackColor = XColor.ErrMsgForeColor;
                    else
                        this.lblD.BackColor = XColor.XLabelBackColor;
                }

            #endregion


            #region 最終締切後変更可能フラグ

                string cmd_enable = @"SELECT A.CODE_NAME
                                        FROM OCS0132 A
                                       WHERE A.HOSP_CODE = :f_hosp_code
                                         AND A.CODE_TYPE = 'NUT_FINAL_MAGAM_ACTION'
                                         AND A.CODE      = :f_code
                                    ";
                BindVarCollection bind_enable = new BindVarCollection();
                bind_enable.Add("f_hosp_code", EnvironInfo.HospCode);
                bind_enable.Add("f_code", "CHANGE_YN");

                object obj_enable = Service.ExecuteScalar(cmd_enable, bind_enable);

                if (obj_enable != null && obj_enable.ToString() == "Y")
                {
                    this.lblModifyONOFF.Text = "可能";
                    this.cbxSiksaChangeYN.Checked = true;
                }
                else
                {
                    this.lblModifyONOFF.Text = "不可";
                    this.cbxSiksaChangeYN.Checked = false;
                }

            #endregion
        }
        #region SetTabControl()
        /// <summary>
        /// 日付別にタブを生成する
        /// </summary>
        /// <param name="gubun"></param>
        private void SetTabControl()
        {
            #region 注釈 XTabControl tab = new XTabControl();

            XTabControl tab = new XTabControl();

            this.SetBreakfastTab();
            this.SetLunchTab();
            this.SetDinnerTab();
            

            #endregion

            this.grdOCS2005_B.QueryLayout(false);
            this.grdOCS2005_L.QueryLayout(false);
            this.grdOCS2005_D.QueryLayout(false);

            this.layVW_OCS_OCS2005_NUT.QueryLayout(false);
            this.SetSiksaHisInfo(this.layVW_OCS_OCS2005_NUT);

            if (this.grdOCS2005_B.RowCount == 0)
            {
                //this.grdOCS2005_B.Reset();
                this.rbtB1.Checked = false;
                this.rbtB2.Checked = false;
                this.rbtB3.Checked = false;

                this.cboSikjong_b.ResetData();
                this.cboJusik_b.ResetData();
                this.cboBusik_b.ResetData();
                this.cboNomimono_b.ResetData();

                this.btnBreak.PerformClick();
                //this.dtpStartDate_b.Enabled = false;
            }
            else
                this.grdOCS2005_B.SetFocusToItem(this.grdOCS2005_B.RowCount-1, "drt_from_date");

            if (this.grdOCS2005_L.RowCount == 0)
            {
                //this.grdOCS2005_L.Reset();
                this.rbtL1.Checked = false;
                this.rbtL2.Checked = false;
                this.rbtL3.Checked = false;

                this.cboSikjong_l.ResetData();
                this.cboJusik_l.ResetData();
                this.cboBusik_l.ResetData();
                this.cboNomimono_l.ResetData();

                this.btnLunch.PerformClick();
                //this.dtpStartDate_l.Enabled = false;
            }
            else
                this.grdOCS2005_L.SetFocusToItem(this.grdOCS2005_L.RowCount - 1, "drt_from_date");

            if (this.grdOCS2005_D.RowCount == 0)
            {
                //this.grdOCS2005_D.Reset();
                this.rbtD1.Checked = false;
                this.rbtD2.Checked = false;
                this.rbtD3.Checked = false;

                this.cboSikjong_d.ResetData();
                this.cboJusik_d.ResetData();
                this.cboBusik_d.ResetData();
                this.cboNomimono_d.ResetData();

                this.btnDinner.PerformClick();
                //this.dtpStartDate_d.Enabled = false;
            }
            else
                this.grdOCS2005_D.SetFocusToItem(this.grdOCS2005_D.RowCount - 1, "drt_from_date");
        }
        #endregion


        #region [MakeTabPages]
        private void SetBreakfastTab()
        {
            XTabControl tab = new XTabControl();
            tab = tabOrderDate_b;
            //tab.TabPages.Clear();

            string cmdText = string.Format(@"SELECT PKOCS2005    ,
                                                    to_char(DRT_FROM_DATE, 'YYYY/MM/DD') as DRT_FROM_DATE,
                                                    to_char(DRT_TO_DATE, 'YYYY/MM/DD')   as DRT_TO_DATE,
                                                    SUBSTR(DIRECT_CODE, 4, 1)            as SIKA_GUBUN,
                                                    rownum
                                               FROM OCS2005
                                              WHERE ('{2}' = 'Y' AND FKINP1001    = ( SELECT B.PKINP1001
                                                                                      FROM VW_OCS_INP1001_RES_01 B
                                                                                     WHERE B.BUNHO = '{0}'
                                                                                   )
                                                     OR '{2}' = 'N' AND FKINP1001 = '{3}'
                                                    )
                                                AND DIRECT_GUBUN = '03'
                                                AND BLD_GUBUN    = '1'
                                                AND DIRECT_CODE  = '0301'
                                                AND FKOCS6015 IS NULL
                                                AND HOSP_CODE    = '{1}'
                                              ORDER BY DRT_FROM_DATE", paBox.BunHo.ToString(), EnvironInfo.HospCode, this.mPRESSED_JAEWON_YN, this.GetPkInp1001());

            DataTable result = Service.ExecuteDataTable(cmdText);

            if (result != null)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage(DateTime.Parse( result.Rows[i]["drt_from_date"].ToString()).ToString("MM/dd"));
                    tp.TabIndex = i;
                    tp.Tag = i;

                    if (result.Rows[i]["drt_to_date"].ToString() != "")
                        tp.TitleTextColor = Color.Red;

                    tab.TabPages.Add(tp);
                }
            }
            tab.SelectedIndex = tab.TabCount - 1;
        }
        private void SetLunchTab()
        {
            XTabControl tab = new XTabControl();
            tab = tabOrderDate_l;
            //tab.TabPages.Clear();

            string cmdText = string.Format(@"SELECT PKOCS2005    ,
                                                    to_char(DRT_FROM_DATE, 'YYYY/MM/DD') as DRT_FROM_DATE,
                                                    to_char(DRT_TO_DATE, 'YYYY/MM/DD')   as DRT_TO_DATE,
                                                    SUBSTR(DIRECT_CODE, 4, 1)            as SIKA_GUBUN,
                                                    rownum
                                               FROM OCS2005
                                              WHERE ('{2}' = 'Y' AND FKINP1001    = ( SELECT B.PKINP1001
                                                                                      FROM VW_OCS_INP1001_RES_01 B
                                                                                     WHERE B.BUNHO = '{0}'
                                                                                   )
                                                     OR '{2}' = 'N' AND FKINP1001 = '{3}'
                                                    )
                                                AND DIRECT_GUBUN = '03'
                                                AND BLD_GUBUN    = '2'
                                                AND DIRECT_CODE  = '0301'
                                                AND FKOCS6015 IS NULL
                                                AND HOSP_CODE    = '{1}'
                                              ORDER BY DRT_FROM_DATE", paBox.BunHo.ToString(), EnvironInfo.HospCode, this.mPRESSED_JAEWON_YN, this.GetPkInp1001());

            DataTable result = Service.ExecuteDataTable(cmdText);

            if (result != null)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    //IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage(result.Rows[i]["drt_from_date"].ToString());
                    IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage(DateTime.Parse(result.Rows[i]["drt_from_date"].ToString()).ToString("MM/dd"));
                    tp.TabIndex = i;
                    tp.Tag = i;

                    if (result.Rows[i]["drt_to_date"].ToString() != "")
                        tp.TitleTextColor = Color.Red;

                    tab.TabPages.Add(tp);
                }
            }
            tab.SelectedIndex = tab.TabCount - 1;
        }
        private void SetDinnerTab()
        {
            XTabControl tab = new XTabControl();
            tab = tabOrderDate_d;
            //tab.TabPages.Clear();

            string cmdText = string.Format(@"SELECT PKOCS2005    ,
                                                    to_char(DRT_FROM_DATE, 'YYYY/MM/DD') as DRT_FROM_DATE,
                                                    to_char(DRT_TO_DATE, 'YYYY/MM/DD')   as DRT_TO_DATE,
                                                    SUBSTR(DIRECT_CODE, 4, 1)            as SIKA_GUBUN,
                                                    rownum
                                               FROM OCS2005
                                              WHERE ('{2}' = 'Y' AND FKINP1001    = ( SELECT B.PKINP1001
                                                                                      FROM VW_OCS_INP1001_RES_01 B
                                                                                     WHERE B.BUNHO = '{0}'
                                                                                   )
                                                     OR '{2}' = 'N' AND FKINP1001 = '{3}'
                                                    )
                                                AND DIRECT_GUBUN = '03'
                                                AND BLD_GUBUN    = '3'
                                                AND DIRECT_CODE  = '0301'
                                                AND FKOCS6015 IS NULL
                                                AND HOSP_CODE    = '{1}'
                                              ORDER BY DRT_FROM_DATE", paBox.BunHo.ToString(), EnvironInfo.HospCode, this.mPRESSED_JAEWON_YN, this.GetPkInp1001());

            DataTable result = Service.ExecuteDataTable(cmdText);

            if (result != null)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    //IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage(result.Rows[i]["drt_from_date"].ToString());
                    IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage(DateTime.Parse(result.Rows[i]["drt_from_date"].ToString()).ToString("MM/dd"));
                    tp.TabIndex = i;
                    tp.Tag = i;

                    if (result.Rows[i]["drt_to_date"].ToString() != "")
                        tp.TitleTextColor = Color.Red;

                    tab.TabPages.Add(tp);
                }
            }
            tab.SelectedIndex = tab.TabCount - 1;
        }

        #endregion


        private void btnSikAdd_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
                return;

            XButton btn = sender as XButton;
            //XDatePicker dtp_s = new XDatePicker();
            //XDatePicker dtp_e = new XDatePicker();
            //XEditGrid grd = new XEditGrid();
            //XTabControl tab = new XTabControl();
            XDatePicker dtp_temp = new XDatePicker();
            this.SetBLDControl(btn.Tag.ToString());
            //新規ＴＡＢがあるかどうかチェック
            if (IsNewTab(this.TAB))
                return;
            this.RBT_G.Checked = false;
            this.RBT_S.Checked = false;
            this.RBT_K.Checked = false;

            //switch(btn.Tag.ToString())
            //{
            //    case BLD_BREAKFAST:
            //        grd = this.grdOCS2005_B;
            //        dtp_s = this.dtpStartDate_b;
            //        dtp_e = this.dtpEndDate_b;
            //        tab = this.tabOrderDate_b;
            //        this.rbtB1.Checked = false;
            //        this.rbtB2.Checked = false;
            //        this.rbtB3.Checked = false;
            //        break;
            //    case BLD_LUNCH:
            //        grd = this.grdOCS2005_L;
            //        dtp_s = this.dtpStartDate_l;
            //        dtp_e = this.dtpEndDate_l;
            //        tab = this.tabOrderDate_l;
            //        this.rbtL1.Checked = false;
            //        this.rbtL2.Checked = false;
            //        this.rbtL3.Checked = false;
            //        break;
            //    case BLD_DINNER:
            //        grd = this.grdOCS2005_D;
            //        dtp_s = this.dtpStartDate_d;
            //        dtp_e = this.dtpEndDate_d;
            //        tab = this.tabOrderDate_d;

            //        this.rbtD1.Checked = false;
            //        this.rbtD2.Checked = false;
            //        this.rbtD3.Checked = false;
            //        break;
            //}

            if (this.GRD.RowCount > 0)
            {
                this.DTP_FROM.Enabled = true;
                dtp_temp.SetDataValue("");
            }
            else
                dtp_temp.SetDataValue(GetIpwon_Date());

            string fkinp1001 = GetPkInp1001();
            DateTime dtpFromDate = EnvironInfo.GetSysDate();
            int row = -1;

            this.TAB.SelectionChanged -= new System.EventHandler(this.tabOrderDate_SelectionChanged);
            IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage("新規");
            tp.Tag = this.GRD.RowCount;
            this.TAB.TabPages.Add(tp);
            this.TAB.SelectedTab = tp;
            this.TAB.SelectionChanged += new System.EventHandler(this.tabOrderDate_SelectionChanged);

            row = this.GRD.InsertRow(-1);
            this.GRD.SetItemValue(row, "bld_gubun", btn.Tag.ToString());         // 朝､昼､夕
            this.GRD.SetItemValue(row, "fkinp1001", fkinp1001);
            this.GRD.SetItemValue(row, "drt_from_date", dtp_temp.GetDataValue()); //dtpFrom.GetDataValue());

            if (this.GRD.GetItemString(this.GRD.CurrentRowNumber, "drt_from_date") == GetIpwon_Date())
                this.DTP_FROM.Enabled = false;
            //this.GRD.SetItemValue(row, "drt_to_date", dtp_e.GetDataValue()); //dtpFrom.GetDataValue());
        }

        // 現在のＴＡＢに新規ＴＡＢがあるかどうかチェック
        // ある：true
        // ない：false
        private bool IsNewTab(XTabControl tab)
        {
            for (int i = 0; i < tab.TabCount; i++)
            {
                if (tab.TabPages[i].Title.ToString() == "新規")
                {
                    tab.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void grdOCS2005_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            this.SetBLDControl(grd.Tag.ToString());

            this.GRD.SetBindVarValue("f_bld_gubun", this.GRD.Tag.ToString());
            this.GRD.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.GRD.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.GRD.SetBindVarValue("f_jaewon_yn", this.mPRESSED_JAEWON_YN);
            this.GRD.SetBindVarValue("f_fkinp1001", this.GetPkInp1001());

            //switch (grd.Tag.ToString())
            //{
            //    case BLD_BREAKFAST:
            //        grd = this.grdOCS2005_B;
            //        break;
            //    case BLD_LUNCH:
            //        grd = this.grdOCS2005_L;
            //        break;
            //    case BLD_DINNER:
            //        grd = this.grdOCS2005_D;
            //        break;
            //}

            //if (grd.RowCount > 0)
            //    grd.SetBindVarValue("f_sik_start_date", grd.GetItemString(grd.CurrentRowNumber, "drt_from_date"));
            //else
            //    grd.SetBindVarValue("f_sik_start_date", "%");
            //grd.SetBindVarValue("f_bld_gubun", grd.Tag.ToString());
            //grd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //grd.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void cboSikjong_SelectedValueChanged(object sender, EventArgs e)
        {
            XComboBox cbo = sender as XComboBox;
            //XEditGrid grd = new XEditGrid();
            this.SetBLDControl(cbo.Tag.ToString());
            
            //switch (cbo.Tag.ToString())
            //{
            //    case BLD_BREAKFAST: grd = this.grdOCS2005_B; break;
            //    case BLD_LUNCH: grd = this.grdOCS2005_L; break;
            //    case BLD_DINNER: grd = this.grdOCS2005_D; break;
            //}
            if (this.CBO_SIKJONG != null && this.CBO_SIKJONG.SelectedValue != null)
                this.GRD.SetItemValue(this.GRD.CurrentRowNumber, "direct_cont1_d", this.CBO_SIKJONG.SelectedValue.ToString());
        }

        private void cboJusik_SelectedValueChanged(object sender, EventArgs e)
        {
            XComboBox cbo = sender as XComboBox;
            this.SetBLDControl(cbo.Tag.ToString());
            //XEditGrid grd = new XEditGrid();
            //switch (cbo.Tag.ToString())
            //{
            //    case BLD_BREAKFAST: grd = this.grdOCS2005_B; break;
            //    case BLD_LUNCH: grd = this.grdOCS2005_L; break;
            //    case BLD_DINNER: grd = this.grdOCS2005_D; break;
            //}
            if (this.CBO_JUSIK.SelectedValue != null)
                this.GRD.SetItemValue(this.GRD.CurrentRowNumber, "direct_cont2_d", this.CBO_JUSIK.SelectedValue.ToString());
        }

        private void cboBusik_SelectedValueChanged(object sender, EventArgs e)
        {
            XComboBox cbo = sender as XComboBox;
            this.SetBLDControl(cbo.Tag.ToString());
            //XEditGrid grd = new XEditGrid();
            //switch (cbo.Tag.ToString())
            //{
            //    case BLD_BREAKFAST: grd = this.grdOCS2005_B; break;
            //    case BLD_LUNCH: grd = this.grdOCS2005_L; break;
            //    case BLD_DINNER: grd = this.grdOCS2005_D; break;
            //}
            if (this.CBO_BUSIK.SelectedValue != null)
                this.GRD.SetItemValue(this.GRD.CurrentRowNumber, "direct_cont3_d", this.CBO_BUSIK.SelectedValue.ToString());
        }

        private void cboNomimono_SelectedValueChanged(object sender, EventArgs e)
        {
            XComboBox cbo = sender as XComboBox;
            this.SetBLDControl(cbo.Tag.ToString());
            //XEditGrid grd = new XEditGrid();
            //switch (cbo.Tag.ToString())
            //{
            //    case BLD_BREAKFAST: grd = this.grdOCS2005_B; break;
            //    case BLD_LUNCH: grd = this.grdOCS2005_L; break;
            //    case BLD_DINNER: grd = this.grdOCS2005_D; break;
            //}
            if (this.CBO_NOMIMONO.SelectedValue != null)
                this.GRD.SetItemValue(this.GRD.CurrentRowNumber, "nomimono", this.CBO_NOMIMONO.SelectedValue.ToString());
        }

        private void txtComment_Validated(object sender, EventArgs e)
        {
            XTextBox txt = sender as XTextBox;
            this.SetBLDControl(txt.Tag.ToString());
            //XEditGrid grd = new XEditGrid();
            //switch (txt.Tag.ToString())
            //{
            //    case BLD_BREAKFAST: grd = this.grdOCS2005_B; break;
            //    case BLD_LUNCH: grd = this.grdOCS2005_L; break;
            //    case BLD_DINNER: grd = this.grdOCS2005_D; break;
            //}
            this.GRD.SetItemValue(this.GRD.CurrentRowNumber, "kumjisik", this.TXT_COMMENT.Text);
        }

        private void tabOrderDate_SelectionChanged(object sender, EventArgs e)
        {
            XTabControl tab = sender as XTabControl;
            this.SetBLDControl(tab.Tag.ToString());

            if (this.GRD.RowCount > 0 && this.TAB.TabPages.Count > 0)
                this.GRD.SetFocusToItem(int.Parse(this.TAB.SelectedTab.Tag.ToString()), "bld_gubun");

            //PostCallHelper.PostCall(this.SelectedDisplayCalendar);
        }

        private void SelectedDisplayCalendar()
        {
            string From_date = this.GRD.GetItemString(this.GRD.CurrentRowNumber, "drt_from_date");
            string To_date = TypeCheck.NVL(this.GRD.GetItemString(this.GRD.CurrentRowNumber, "drt_to_date"), From_date).ToString();

            if (this.GRD.RowCount > 0)
                this.SelectedDisplayCalendar(DateTime.Parse(From_date), DateTime.Parse(To_date));
        }

        //選択されてた日付をカレンダーに表示
        //TO_DATEがあれば範囲選択
        //無ければFROM_DATEのみ選択表示
        private void SelectedDisplayCalendar(DateTime aFROM_DATE, DateTime aTO_DATE)
        {
            this.calSiksa.UnSelectAll();

            this.calSiksa.SetActiveMonth(aFROM_DATE.Year, aFROM_DATE.Month);

            DateTime date = aFROM_DATE;
            while (date <= DateTime.Parse(TypeCheck.NVL(aTO_DATE, aFROM_DATE).ToString()))
            {
                this.calSiksa.SelectDate(date);
                date = date.AddDays(1);
            };

            this.calSiksa.Redraw = true;
        }
        //private void grdStartDate_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        //{
        //    XEditGrid grdS = sender as XEditGrid;
        //    XEditGrid grd = new XEditGrid();
        //    switch (grdS.Tag.ToString())
        //    {
        //        case BLD_BREAKFAST: grd = this.grdOCS2005_B; break;
        //        case BLD_LUNCH: grd = this.grdOCS2005_L; break;
        //        case BLD_DINNER: grd = this.grdOCS2005_D; break;
        //    }
            
        //    grd.QueryLayout(false);

        //    if (grd.RowCount > 0)
        //    {
        //        for (int i = 0; i < grd.RowCount; i++)
        //        {
        //            if (grdS.GetItemString(e.CurrentRow, "drt_from_date") == grd.GetItemString(i, "drt_from_date"))
        //            {
        //                grd.SetFocusToItem(i, "drt_from_date");
        //            }
        //        }
        //    }
        //}

        private void grdOCS2005_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            // gridの値をコントロールに反映
            this.SetBLDControl(grd.Tag.ToString());

            switch (this.GRD.GetItemString(e.CurrentRow, "direct_code_d"))
            {
                case "000": this.RBT_G.Checked = true; break;
                case "001": this.RBT_S.Checked = true; break;
                case "009": this.RBT_K.Checked = true; break;
            }

            this.CBO_SIKJONG.SetDataValue(this.GRD.GetItemString(e.CurrentRow, "direct_cont1_d"));
            this.CBO_JUSIK.SetDataValue(this.GRD.GetItemString(e.CurrentRow, "direct_cont2_d"));
            this.CBO_BUSIK.SetDataValue(this.GRD.GetItemString(e.CurrentRow, "direct_cont3_d"));
            this.CBO_NOMIMONO.SetDataValue(this.GRD.GetItemString(e.CurrentRow, "nomimono"));

            if (this.GRD.GetItemString(this.GRD.CurrentRowNumber, "drt_from_date") == GetIpwon_Date())
                this.DTP_FROM.Enabled = false;
            else
                this.DTP_FROM.Enabled = true;
            //this.sik_gubun = grd.GetItemString(e.CurrentRow, "direct_code_d");            //食事区分(一般食、特別食、中止)
            //string direct_cont1_d = grd.GetItemString(e.CurrentRow, "direct_cont1_d");    //食事種類
            //string direct_cont2_d = grd.GetItemString(e.CurrentRow, "direct_cont2_d");    //主食
            //string direct_cont3_d = grd.GetItemString(e.CurrentRow, "direct_cont3_d");    //副食
            //string nomimono = grd.GetItemString(e.CurrentRow, "nomimono");                //飲物

            //switch (grd.Tag.ToString())
            //{
            //    case BLD_BREAKFAST:
            //        switch (this.sik_gubun)
            //        {
            //            case "000": this.rbtB1.Checked = true; break;
            //            case "001": this.rbtB2.Checked = true; break;
            //            case "009": this.rbtB3.Checked = true; break;
            //        }

            //        this.cboSikjong_b.SetDataValue(direct_cont1_d);
            //        this.cboJusik_b.SetDataValue(direct_cont2_d);
            //        this.cboBusik_b.SetDataValue(direct_cont3_d);
            //        this.cboNomimono_b.SetDataValue(nomimono);
            //        break;
            //    case BLD_LUNCH:
            //        switch (this.sik_gubun)
            //        {
            //            case "000": this.rbtL1.Checked = true; break;
            //            case "001": this.rbtL2.Checked = true; break;
            //            case "009": this.rbtL3.Checked = true; break;
            //        }

            //        this.cboSikjong_l.SetDataValue(direct_cont1_d);
            //        this.cboJusik_l.SetDataValue(direct_cont2_d);
            //        this.cboBusik_l.SetDataValue(direct_cont3_d);
            //        this.cboNomimono_l.SetDataValue(nomimono);
            //        break;
            //    case BLD_DINNER:
            //        switch (this.sik_gubun)
            //        {
            //            case "000": this.rbtD1.Checked = true; break;
            //            case "001": this.rbtD2.Checked = true; break;
            //            case "009": this.rbtD3.Checked = true; break;
            //        }

            //        this.cboSikjong_d.SetDataValue(direct_cont1_d);
            //        this.cboJusik_d.SetDataValue(direct_cont2_d);
            //        this.cboBusik_d.SetDataValue(direct_cont3_d);
            //        this.cboNomimono_d.SetDataValue(nomimono);
            //        break;
            //}
        }

        private bool IsNutCheckFromToDate(string aDate, string aBunho, string aHospCode, string aBLD_GUBUN, string aPKOCS2005, bool aMSG_YN)
        {
            string cmd = "";
            cmd = @"SELECT FN_NUT_CHECK_FROM_TO_DATE(:f_Date
                                                   , :f_Bunho
                                                   , :f_HospCode
                                                   , :f_BLD_GUBUN
                                                   , :f_PKOCS2005
                                                   , :f_FKINP1001
                                                    ) AA FROM SYS.DUAL";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_Date", aDate);
            bind.Add("f_Bunho", aBunho);
            bind.Add("f_HospCode", aHospCode);
            bind.Add("f_BLD_GUBUN", aBLD_GUBUN);
            bind.Add("f_PKOCS2005", aPKOCS2005);
            bind.Add("f_FKINP1001", this.GetPkInp1001());
            object obj = Service.ExecuteScalar(cmd, bind);

            if (obj.ToString() == "0")
            {
                return false;
            }
            else
            {
                if (aMSG_YN)
                    XMessageBox.Show(obj.ToString() + "にすでにデータがあります。日にちが重ならない様に調節してください。", "確認");
                return true;
            }
        }
        
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
                return;

            Control ctl = sender as Control;
            this.SetBLDControl(ctl.Tag.ToString());
            XComboBox cbo = new XComboBox();
            XTabControl tab = new XTabControl();
            DataRow copyFromRow = null;
            
            IHIS.X.Magic.Controls.TabPage tp_b = new IHIS.X.Magic.Controls.TabPage("新規");
            IHIS.X.Magic.Controls.TabPage tp_l = new IHIS.X.Magic.Controls.TabPage("新規");
            IHIS.X.Magic.Controls.TabPage tp_d = new IHIS.X.Magic.Controls.TabPage("新規");

            XTabControl tab_1 = new XTabControl();
            XTabControl tab_2 = new XTabControl();
            
            XEditGrid grd_1 = new XEditGrid();
            XEditGrid grd_2 = new XEditGrid();
            
            XRadioButton rbt1_1 = new XRadioButton();
            XRadioButton rbt1_2 = new XRadioButton();
            XRadioButton rbt2_1 = new XRadioButton();
            XRadioButton rbt2_2 = new XRadioButton();
            XRadioButton rbt3_1 = new XRadioButton();
            XRadioButton rbt3_2 = new XRadioButton();
            
            XComboBox cbo_s_1 = new XComboBox();
            XComboBox cbo_s_2 = new XComboBox();

            XComboBox cbo_j_1 = new XComboBox();
            XComboBox cbo_j_2 = new XComboBox();
            
            XComboBox cbo_b_1 = new XComboBox();
            XComboBox cbo_b_2 = new XComboBox();
            
            XComboBox cbo_n_1 = new XComboBox();
            XComboBox cbo_n_2 = new XComboBox();

            int Current_row_1 = -1;
            int Current_row_2 = -1;

            switch (ctl.Tag.ToString())
            {
                case BLD_BREAKFAST: // COPY TO LUNCH, COPY TO DINNER
                    //
                    tab_1 = this.tabOrderDate_l;
                    tab_2 = this.tabOrderDate_d;
                    //
                    grd_1 = this.grdOCS2005_L;
                    grd_2 = this.grdOCS2005_D;
                    //
                    rbt1_1 = this.rbtL1;
                    rbt2_1 = this.rbtL2;
                    rbt3_1 = this.rbtL3;
                    rbt1_2 = this.rbtD1;
                    rbt2_2 = this.rbtD2;
                    rbt3_2 = this.rbtD3;
                    //
                    cbo_s_1 = this.cboSikjong_l;
                    cbo_s_2 = this.cboSikjong_d;
                    //
                    cbo_j_1 = this.cboJusik_l;
                    cbo_j_2 = this.cboJusik_d;
                    //
                    cbo_b_1 = this.cboBusik_l;
                    cbo_b_2 = this.cboBusik_d;
                    //
                    cbo_n_1 = this.cboNomimono_l;
                    cbo_n_2 = this.cboNomimono_d;
                    break;
                case BLD_LUNCH: // COPY TO BREAKFAST, COPY TO DINNER
                    //
                    tab_1 = this.tabOrderDate_b;
                    tab_2 = this.tabOrderDate_d;
                    //
                    grd_1 = this.grdOCS2005_B;
                    grd_2 = this.grdOCS2005_D;
                    //
                    rbt1_1 = this.rbtB1;
                    rbt2_1 = this.rbtB2;
                    rbt3_1 = this.rbtB3;
                    rbt1_2 = this.rbtD1;
                    rbt2_2 = this.rbtD2;
                    rbt3_2 = this.rbtD3;
                    //
                    cbo_s_1 = this.cboSikjong_b;
                    cbo_s_2 = this.cboSikjong_d;
                    //
                    cbo_j_1 = this.cboJusik_b;
                    cbo_j_2 = this.cboJusik_d;
                    //
                    cbo_b_1 = this.cboBusik_b;
                    cbo_b_2 = this.cboBusik_d;
                    //
                    cbo_n_1 = this.cboNomimono_b;
                    cbo_n_2 = this.cboNomimono_d;
                    break;
                case BLD_DINNER: // COPY TO BREAKFAST, COPY TO DINNER
                    //
                    tab_1 = this.tabOrderDate_l;
                    tab_2 = this.tabOrderDate_b;
                    //
                    grd_1 = this.grdOCS2005_L;
                    grd_2 = this.grdOCS2005_B;
                    //
                    rbt1_1 = this.rbtL1;
                    rbt2_1 = this.rbtL2;
                    rbt3_1 = this.rbtL3;
                    rbt1_2 = this.rbtB1;
                    rbt2_2 = this.rbtB2;
                    rbt3_2 = this.rbtB3;
                    //
                    cbo_s_1 = this.cboSikjong_l;
                    cbo_s_2 = this.cboSikjong_b;
                    //
                    cbo_j_1 = this.cboJusik_l;
                    cbo_j_2 = this.cboJusik_b;
                    //
                    cbo_b_1 = this.cboBusik_l;
                    cbo_b_2 = this.cboBusik_b;
                    //
                    cbo_n_1 = this.cboNomimono_l;
                    cbo_n_2 = this.cboNomimono_b;
                    break;
            }

            Current_row_1 = grd_1.CurrentRowNumber;
            Current_row_2 = grd_2.CurrentRowNumber;

            DialogResult result = new DialogResult();

            if (this.GRD.RowCount > 0)
            {
                copyFromRow = this.GRD.LayoutTable.Rows[this.GRD.CurrentRowNumber];
                result = XMessageBox.Show(this.BLD_GUBUN_STR + "と同一オーダが他の食事にも適用されます。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else return;

            if (result == DialogResult.No) return;

            string directCode = copyFromRow["direct_code"].ToString();

            tabOrderDate_d.SelectionChanged -= new System.EventHandler(this.tabOrderDate_SelectionChanged);
            tabOrderDate_l.SelectionChanged -= new System.EventHandler(this.tabOrderDate_SelectionChanged);
            tabOrderDate_b.SelectionChanged -= new System.EventHandler(this.tabOrderDate_SelectionChanged);

            if (!IsNewTab(tab_1))
            {
                tp_l.Tag = grd_1.RowCount;
                tab_1.TabPages.Add(tp_l);
                tab_1.SelectedTab = tp_l;
                Current_row_1 = grd_1.InsertRow(-1);
            }
            if (!IsNewTab(tab_2))
            {
                tp_d.Tag = grd_2.RowCount;
                tab_2.TabPages.Add(tp_d);
                tab_2.SelectedTab = tp_d;
                Current_row_2 = grd_2.InsertRow(-1);
            }


            for (int i = 0; i < copyFromRow.ItemArray.Length; i++)
            {
                if (i == 1 || i == 7) continue; // pkocs2005, pk_seq
                if (i == 0)                     // direct_code
                {
                    grd_1.SetItemValue(Current_row_1, "bld_gubun", grd_1.Tag.ToString());
                    grd_2.SetItemValue(Current_row_2, "bld_gubun", grd_2.Tag.ToString());
                    continue;
                }
                if (i == 10) //食事区分
                {
                    switch (copyFromRow[i].ToString())
                    {
                        case "000":
                            rbt1_1.Checked = true;
                            rbt1_2.Checked = true;
                            break;
                        case "001":
                            rbt2_1.Checked = true;
                            rbt2_2.Checked = true;
                            break;
                        case "009":
                            rbt3_1.Checked = true;
                            rbt3_2.Checked = true;
                            break;
                    }
                }

                if (i == 12) //食種
                {
                    cbo_s_1.SetDataValue(copyFromRow[i].ToString());
                    cbo_s_2.SetDataValue(copyFromRow[i].ToString());
                }
                if (i == 14) //主食
                {
                    cbo_j_1.SetDataValue(copyFromRow[i].ToString());
                    cbo_j_2.SetDataValue(copyFromRow[i].ToString());
                }
                if (i == 16) //副食
                {
                    cbo_b_1.SetDataValue(copyFromRow[i].ToString());
                    cbo_b_2.SetDataValue(copyFromRow[i].ToString());
                }
                if (i == 17) //飲物
                {
                    if (ctl.Tag.ToString() != "2")
                    {
                        cbo_n_1.SetDataValue(copyFromRow[i].ToString());
                        cbo_n_2.SetDataValue(copyFromRow[i].ToString());
                    }
                }
                
                
                if ((ctl.Tag.ToString() != "2"))
                {
                    grd_1.SetItemValue(Current_row_1, grd_1.LayoutTable.Columns[i].ColumnName, copyFromRow[i].ToString());
                    grd_2.SetItemValue(Current_row_2, grd_2.LayoutTable.Columns[i].ColumnName, copyFromRow[i].ToString());
                }
                else if (ctl.Tag.ToString() == "2" && i != 17)
                {
                    grd_1.SetItemValue(Current_row_1, grd_1.LayoutTable.Columns[i].ColumnName, copyFromRow[i].ToString());
                    grd_2.SetItemValue(Current_row_2, grd_2.LayoutTable.Columns[i].ColumnName, copyFromRow[i].ToString());
                }

                if (i == 19) //開始日
                {
                    switch (ctl.Tag.ToString())
                    {
                        case "1":
                            
                            break;

                        case "2":
                            grd_1.SetItemValue(Current_row_1, grd_1.LayoutTable.Columns[i].ColumnName, DateTime.Parse(copyFromRow[i].ToString()).AddDays(1));
                            //grd_2.SetItemValue(Current_row_2, grd_2.LayoutTable.Columns[i].ColumnName, DateTime.Parse(copyFromRow[i].ToString()).AddDays(1));
                            break;

                        case "3":
                            grd_1.SetItemValue(Current_row_1, grd_1.LayoutTable.Columns[i].ColumnName, DateTime.Parse(copyFromRow[i].ToString()).AddDays(1));
                            grd_2.SetItemValue(Current_row_2, grd_2.LayoutTable.Columns[i].ColumnName, DateTime.Parse(copyFromRow[i].ToString()).AddDays(1));
                            break;
                    }
                }
            }

            tabOrderDate_b.SelectionChanged += new System.EventHandler(this.tabOrderDate_SelectionChanged);
            tabOrderDate_l.SelectionChanged += new System.EventHandler(this.tabOrderDate_SelectionChanged);
            tabOrderDate_d.SelectionChanged += new System.EventHandler(this.tabOrderDate_SelectionChanged);
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            XEditGrid grd = new XEditGrid();
            XTextBox txt_name = new XTextBox();
            XTextBox txt_code = new XTextBox();
            
            return base.Command(command, commandParam);
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
                return;

            XButton btn = sender as XButton;

            XEditGrid grd = new XEditGrid();
            XDatePicker dtp_s = new XDatePicker();
            DateTime date = EnvironInfo.GetSysDate();

            this.SetBLDControl(btn.Tag.ToString());

            this.RBT_G.Checked = true;
            this.CBO_SIKJONG.SetDataValue(SIKJONG);
            this.CBO_JUSIK.SetDataValue(JUSIK);
            this.CBO_BUSIK.SetDataValue(BUSIK);
            
            //switch(btn.Tag.ToString())
            //{
            //    case BLD_BREAKFAST:
            //        grd = this.grdOCS2005_B;
            //        this.rbtB1.Checked = true;
            //        this.cboSikjong_b.SetDataValue(SIKJONG);
            //        this.cboJusik_b.SetDataValue(JUSIK);
            //        this.cboBusik_b.SetDataValue(BUSIK);
            //        dtp_s = this.dtpStartDate_b;
            //        break;
            //    case BLD_LUNCH:
            //        grd = this.grdOCS2005_L;
            //        this.rbtL1.Checked = true;
            //        this.cboSikjong_l.SetDataValue(SIKJONG);
            //        this.cboJusik_l.SetDataValue(JUSIK);
            //        this.cboBusik_l.SetDataValue(BUSIK);
            //        dtp_s = this.dtpStartDate_l;
            //        break;
            //    case BLD_DINNER:
            //        grd = this.grdOCS2005_D;
            //        this.rbtD1.Checked = true;
            //        this.cboSikjong_d.SetDataValue(SIKJONG);
            //        this.cboJusik_d.SetDataValue(JUSIK);
            //        this.cboBusik_d.SetDataValue(BUSIK);
            //        dtp_s = this.dtpStartDate_d;
            //        break;
            //}
            //if (this.IsNutCheckFromToDate(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").ToString(), this.paBox.BunHo, EnvironInfo.HospCode, btn.Tag.ToString(), this.GRD.GetItemString(this.GRD.CurrentRowNumber, "pkocs2005"), false))
            //    date = EnvironInfo.GetSysDate().AddDays(1);

            //if (this.DTP_FROM.Enabled == true)
            //    this.GRD.SetItemValue(this.GRD.CurrentRowNumber, "drt_from_date", date);
        }

        private void btnDefaultJou_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
                return;

            XButton btn = sender as XButton;

            XEditGrid grd = new XEditGrid();
            XDatePicker dtp_s = new XDatePicker();
            DateTime date = EnvironInfo.GetSysDate();

            this.SetBLDControl(btn.Tag.ToString());

            this.RBT_G.Checked = true;
            this.CBO_SIKJONG.SetDataValue(SIKJONG_JOU);
            this.CBO_JUSIK.SetDataValue(JUSIK_JOU);
            this.CBO_BUSIK.SetDataValue(BUSIK_JOU);

            //if (this.IsNutCheckFromToDate(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").ToString(), this.paBox.BunHo, EnvironInfo.HospCode, btn.Tag.ToString(), this.GRD.GetItemString(this.GRD.CurrentRowNumber, "pkocs2005"), false))
            //    date = EnvironInfo.GetSysDate().AddDays(1);

            //if (this.DTP_FROM.Enabled == true)
            //    this.GRD.SetItemValue(this.GRD.CurrentRowNumber, "drt_from_date", date);
        }

        private void tabOrderDate_DragDrop(object sender, DragEventArgs e)
        {
            XTabControl tab = sender as XTabControl;
            this.SetBLDControl(tab.Tag.ToString());
            int row = -1;
            if (FocusedFlag == this.TAB.Tag.ToString()) return;  // 같은 식사구분이면 리턴

            //XEditGrid grd = new XEditGrid();

            //XComboBox cbo_s = new XComboBox();
            //XComboBox cbo_j = new XComboBox();
            //XComboBox cbo_b = new XComboBox();
            //XComboBox cbo_n = new XComboBox();

            //string gubun = "";

            //switch (tab.Tag.ToString())
            //{
            //    case BLD_BREAKFAST:
            //        grd = this.grdOCS2005_B;
            //        gubun = "【朝食】";
            //        cbo_s = this.cboSikjong_b;
            //        cbo_j = this.cboJusik_b;
            //        cbo_b = this.cboBusik_b;
            //        cbo_n = this.cboNomimono_b;

            //        break;
            //    case BLD_LUNCH:
            //        grd = this.grdOCS2005_L;
            //        gubun = "【昼食】";
            //        cbo_s = this.cboSikjong_l;
            //        cbo_j = this.cboJusik_l;
            //        cbo_b = this.cboBusik_l;
            //        cbo_n = this.cboNomimono_l;

            //        break;
            //    case BLD_DINNER:
            //        grd = this.grdOCS2005_D;
            //        gubun = "【夕食】";
            //        cbo_s = this.cboSikjong_d;
            //        cbo_j = this.cboJusik_d;
            //        cbo_b = this.cboBusik_d;
            //        cbo_n = this.cboNomimono_d;

            //        break;
            //}

            

            DialogResult result = new DialogResult();

            if (this.GRD.RowCount > 0)
               result = XMessageBox.Show(this.BLD_GUBUN_STR + "と同一オーダが他の食事にも適用されます。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else 
                return;
            
            if (result == DialogResult.No) return;

            if (!IsNewTab(this.TAB)) // 既に新規ＴＡＢがあれば現在のＴＡＢにコピー
            {
                this.TAB.SelectionChanged -= new System.EventHandler(this.tabOrderDate_SelectionChanged);

                IHIS.X.Magic.Controls.TabPage tp_new = new IHIS.X.Magic.Controls.TabPage("新規");
                tp_new.Tag = this.GRD.RowCount;
                this.TAB.TabPages.Add(tp_new);
                this.TAB.SelectedTab = tp_new;

                row = this.GRD.InsertRow(-1);
            }
            else
                row = this.GRD.CurrentRowNumber;
           
            for (int i = 0; i < dtRow.ItemArray.Length; i++)
            {
                if (i == 1 || i == 7) continue; // pkocs2005, pk_seq
                if (i == 0)                     // direct_code
                {
                    this.GRD.SetItemValue(row, "bld_gubun", this.TAB.Tag.ToString());
                    continue;
                }
                if (i == 17 && FocusedFlag == "2") continue;

                this.GRD.SetItemValue(row, this.GRD.LayoutTable.Columns[i].ColumnName, dtRow[i].ToString());
            }

            for (int i = 0; i < dtRow.ItemArray.Length; i++)
            {
                if (i == 10) //食事区分
                {
                    switch (dtRow[i].ToString())
                    {
                        case "000": this.RBT_G.Checked = true; break;
                        case "001": this.RBT_S.Checked = true; break;
                        case "009": this.RBT_K.Checked = true; break;
                    }
                }
                else if (i == 12) //食種
                    this.CBO_SIKJONG.SetDataValue(dtRow[i].ToString());
                else if (i == 14) //主食
                    this.CBO_JUSIK.SetDataValue(dtRow[i].ToString());
                else if (i == 16) //副食
                    this.CBO_BUSIK.SetDataValue(dtRow[i].ToString());
                else if (i == 17 && FocusedFlag != "2") //飲物
                    this.CBO_NOMIMONO.SetDataValue(dtRow[i].ToString());
            }
            this.TAB.SelectionChanged += new System.EventHandler(this.tabOrderDate_SelectionChanged);
        }

        private void tabOrderDate_DragEnter(object sender, DragEventArgs e)
        {
            XTabControl tab = sender as XTabControl;
            e.Effect = DragDropEffects.Move;
        }



        DataRow dtRow = null;
        IHIS.X.Magic.Menus.PopupMenu popMenu = new IHIS.X.Magic.Menus.PopupMenu();
        private void tabOrderDate_MouseDown(object sender, MouseEventArgs e)
        {
            XTabControl tab = sender as XTabControl;
            XEditGrid grd = new XEditGrid();
            this.FocusedFlag = ((Control)sender).Tag.ToString();
            
            if (tab.TabPages.Count == 0) return;

            switch (FocusedFlag)
            {
                case "1":
                    grd = this.grdOCS2005_B;
                    break;
                case "2":
                    grd = this.grdOCS2005_L;
                    break;
                case "3":
                    grd = this.grdOCS2005_D;
                    break;
            }

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                dtRow = grd.LayoutTable.Rows[grd.CurrentRowNumber];
                string dragInfo = "【 " + grd.GetItemString(grd.CurrentRowNumber, "drt_from_date") + " 】";
                DragHelper.CreateDragCursor(tab, dragInfo, this.Font);
                tab.DoDragDrop(dragInfo, DragDropEffects.Move);
            }
        }

        private void tabOrderDate_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                Cursor.Current = DragHelper.DragCursor;
        }

        private void pnlBottom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.Size = new Size(1186, 824);
            //this.Refresh();
        }

        private void dtpStartDate_Validated(object sender, EventArgs e)
        {
            XDatePicker dtp = sender as XDatePicker;
            //XEditGrid grd = new XEditGrid();
            this.SetBLDControl(dtp.Tag.ToString());

            if (this.DTP_FROM.GetDataValue() == "")
                return;
            //string msg = "";
            //switch (dtp.Tag.ToString())
            //{
            //    case BLD_BREAKFAST:
            //        dtp = this.dtpStartDate_b;
            //        grd = this.grdOCS2005_B;
            //        msg = "【朝食】";
            //        break;
            //    case BLD_LUNCH:
            //        dtp = this.dtpStartDate_l;
            //        grd = this.grdOCS2005_L;
            //        msg = "【昼食】";
            //        break;
            //    case BLD_DINNER:
            //        dtp = this.dtpStartDate_d;
            //        grd = this.grdOCS2005_D;
            //        msg = "【夕食】";
            //        break;
            //}
            //int currRow = grd.CurrentRowNumber;

            //入院日チェック
            if (int.Parse(DateTime.Parse(GetIpwon_Date()).ToString("yyyyMMdd")) > int.Parse(DateTime.Parse(this.DTP_FROM.GetDataValue().ToString()).ToString("yyyyMMdd")))
            {
                XMessageBox.Show(this.BLD_GUBUN_STR + " 入力しようとしている日付は間違っています。", "確認");
                this.DTP_FROM.Focus();
                return;
            }

            #region [drt_from_date] / [drt_to_date] 重複チェック
            if (this.IsNutCheckFromToDate(this.DTP_FROM.GetDataValue(), this.paBox.BunHo, EnvironInfo.HospCode, this.DTP_FROM.Tag.ToString(), this.GRD.GetItemString(this.GRD.CurrentRowNumber, "pkocs2005"), true))
            {
                this.DTP_FROM.Focus();
                return;
            }
            #endregion
            //this.GRD.SetItemValue(this.GRD.CurrentRowNumber, "drt_from_date", this.DTP_FROM.GetDataValue());
        }

        private void dtpEndDate_Validated(object sender, EventArgs e)
        {
            XDatePicker dtp = sender as XDatePicker;
            //XEditGrid grd = new XEditGrid();
            this.SetBLDControl(dtp.Tag.ToString());

            //switch (dtp.Tag.ToString())
            //{
            //    case BLD_BREAKFAST:
            //        dtp = this.dtpEndDate_b;
            //        grd = this.grdOCS2005_B;
            //        break;
            //    case BLD_LUNCH:
            //        dtp = this.dtpEndDate_l;
            //        grd = this.grdOCS2005_L;
            //        break;
            //    case BLD_DINNER:
            //        dtp = this.dtpEndDate_d;
            //        grd = this.grdOCS2005_D;
            //        break;
            //}

            int currRow = this.GRD.CurrentRowNumber;
            
            #region [drt_from_date] / [drt_to_date] 重複チェック
            if (this.IsNutCheckFromToDate(this.DTP_TO.GetDataValue(), this.paBox.BunHo, EnvironInfo.HospCode, this.DTP_TO.Tag.ToString(), this.GRD.GetItemString(currRow, "pkocs2005"), true))
                return;
            #endregion

            //this.GRD.SetItemValue(currRow, "drt_to_date", this.DTP_TO.GetDataValue());
        }

        private void SetBLDControl(string aTag)
        {
            switch (aTag)
            {
                case BLD_BREAKFAST:
                    this.BLD_GUBUN_STR  = "【朝食】";
                    this.GRD            = this.grdOCS2005_B;
                    this.CBO_SIKJONG    = this.cboSikjong_b;
                    this.CBO_JUSIK      = this.cboJusik_b;
                    this.CBO_BUSIK      = this.cboBusik_b;
                    this.CBO_NOMIMONO   = this.cboNomimono_b;
                    this.TXT_COMMENT    = this.txtComment_b;
                    this.DTP_FROM       = this.dtpStartDate_b;
                    this.DTP_TO         = this.dtpEndDate_b;
                    this.TAB            = this.tabOrderDate_b;
                    this.RBT_G          = this.rbtB1;
                    this.RBT_S          = this.rbtB2;
                    this.RBT_K          = this.rbtB3;
                    this.PANEL_I        = this.pnlIlban_B;
                    this.PANEL_S        = this.pnlSpecial_B;
                    break;

                case BLD_LUNCH:
                    this.BLD_GUBUN_STR  = "【昼食】";
                    this.GRD            = this.grdOCS2005_L;
                    this.CBO_SIKJONG    = this.cboSikjong_l;
                    this.CBO_JUSIK      = this.cboJusik_l;
                    this.CBO_BUSIK      = this.cboBusik_l;
                    this.CBO_NOMIMONO   = this.cboNomimono_l;
                    this.TXT_COMMENT    = this.txtComment_l;
                    this.DTP_FROM       = this.dtpStartDate_l;
                    this.DTP_TO         = this.dtpEndDate_l;
                    this.TAB            = this.tabOrderDate_l;
                    this.RBT_G          = this.rbtL1;
                    this.RBT_S          = this.rbtL2;
                    this.RBT_K          = this.rbtL3;
                    this.PANEL_I        = this.pnlIlban_L;
                    this.PANEL_S        = this.pnlSpecial_L;
                    break;

                case BLD_DINNER:
                    this.BLD_GUBUN_STR  = "【夕食】";
                    this.GRD            = this.grdOCS2005_D;
                    this.CBO_SIKJONG    = this.cboSikjong_d;
                    this.CBO_JUSIK      = this.cboJusik_d;
                    this.CBO_BUSIK      = this.cboBusik_d;
                    this.CBO_NOMIMONO   = this.cboNomimono_d;
                    this.TXT_COMMENT    = this.txtComment_d;
                    this.DTP_FROM       = this.dtpStartDate_d;
                    this.DTP_TO         = this.dtpEndDate_d;
                    this.TAB            = this.tabOrderDate_d;
                    this.RBT_G          = this.rbtD1;
                    this.RBT_S          = this.rbtD2;
                    this.RBT_K          = this.rbtD3;
                    this.PANEL_I        = this.pnlIlban_D;
                    this.PANEL_S        = this.pnlSpecial_D;
                    break;
            }
        }
        private void ResetCalender()
        {
            this.calSiksa.ResetText();
            this.calSiksa.Dates.Clear();
            this.calSiksa.ResetCalendarDates();

        }

        private void SetSiksaHisInfo(MultiLayout aLayData)
        {
            string currentDate = "";
            
            string strText = "";
            XCalendarDate dateItem;

            this.ResetCalender();

            this.calSiksa.Redraw = false;
            foreach (DataRow dr in aLayData.LayoutTable.Rows)
            {
                
                if (dr["nut_date"].ToString() != currentDate)
                {
                    if (strText != "")
                    {
                        dateItem = new XCalendarDate(DateTime.Parse(currentDate));
                        dateItem.ContentText = strText;
                        dateItem.ContentAlign = ContentAlignment.MiddleLeft;

                        if (DateTime.Parse(currentDate).ToString("yyyy/MM/dd") == this.dtpOrder_date.GetDataValue())
                        {
                            dateItem.ContentTextColor = new XColor(Color.Red);
                            dateItem.ContentFont = new Font("Migu 1M", (float)8, FontStyle.Bold);
                            dateItem.BackColor = XColor.XCalendarWeekDayBackColor;
                        }
                        else if (DateTime.Parse(currentDate) > DateTime.Parse(this.dtpOrder_date.GetDataValue())
                                 && DateTime.Parse(currentDate) < DateTime.Parse(this.dtpOrder_date.GetDataValue()).AddDays(7))
                        {
                            dateItem.ContentTextColor = new XColor(Color.Red);
                            dateItem.ContentFont = new Font("Migu 1M", (float)8, FontStyle.Regular);
                            dateItem.BackColor = new XColor(Color.LightGreen);
                        }
                        else
                        {
                            dateItem.ContentTextColor = new XColor(Color.Black);
                            dateItem.ContentFont = new Font("Migu 1M", (float)8, FontStyle.Regular);
                        }

                        this.calSiksa.Dates.Add(dateItem);
                    }
                    currentDate = dr["nut_date"].ToString();
                    strText = "";
                }

                

                switch(dr["bld_gubun"].ToString())
                {
                    case "1":
                        if (dr["sikjong"].ToString().Trim() == "禁食")
                            strText += "朝 " + "×××" + "\n";
                        else
                            strText += "朝 " + dr["sikjong"].ToString() + "" + dr["jusik"].ToString() + "" + dr["busik"].ToString() + "\n";
                        break;
                    case "2":

                        if (dr["sikjong"].ToString().Trim() == "禁食")
                            strText += "昼 " + "×××" + "\n";
                        else
                            strText += "昼 " + dr["sikjong"].ToString() + "" + dr["jusik"].ToString() + "" + dr["busik"].ToString() + "" + dr["nomimono"].ToString() + "\n";
                        break;
                    case "3":
                        
                        if (dr["sikjong"].ToString().Trim() == "禁食")
                            strText += "夕 " + "×××";
                        else
                            strText += "夕 " + dr["sikjong"].ToString() + "" + dr["jusik"].ToString() + "" + dr["busik"].ToString();
                        break;
                }
            }

            if (currentDate != "")
            {
                dateItem = new XCalendarDate(DateTime.Parse(currentDate));
                dateItem.ContentText = strText;
                dateItem.ContentTextColor = new XColor(Color.Black);
                dateItem.ContentFont = new Font("Migu 1M", (float)8, FontStyle.Regular);
                dateItem.ContentAlign = ContentAlignment.MiddleLeft;
                
                this.calSiksa.Dates.Add(dateItem);
            }

            //this.SetPresentWeek(this.calSiksa);
            this.calSiksa.Redraw = true;

        }

        private void SetPresentWeek(XCalendar aCal)
        {
            for (int i = 0; i < 7; i++)
            {
                aCal.SelectDate(EnvironInfo.GetSysDate().AddDays(i));
            }
        }

        private bool RecoveryDataCheck_delete(DataTable aDt)
        {
            string cmd_del = "";

            if (aDt == null)
                return true;

            foreach (DataRow dr in aDt.Rows)
            {
                string recovery_max_min_del = @"SELECT    LEAST(NVL(MIN(:f_drt_from_date), MIN(B.DRT_DATE)), NVL(MIN(B.DRT_DATE), MIN(:f_drt_from_date))) AS MIN_NUT_DATE
                                                         , GREATEST(NVL(MAX(:f_drt_to_date),   MAX(B.DRT_DATE)), NVL(MAX(B.DRT_DATE), MAX(:f_drt_to_date)))   AS MAX_NUT_DATE
                                                      FROM OCS2015 B
                                                     WHERE B.HOSP_CODE = :f_hosp_code
                                                       AND B.FKOCS2005 = :f_pkocs2005";

                BindVarCollection bind_del = new BindVarCollection();
                bind_del.Add("f_drt_from_date", dr["drt_from_date"].ToString());
                bind_del.Add("f_drt_to_date", dr["drt_to_date"].ToString());
                bind_del.Add("f_hosp_code", EnvironInfo.HospCode);
                bind_del.Add("f_pkocs2005", dr["pkocs2005"].ToString());

                DataTable range = Service.ExecuteDataTable(recovery_max_min_del, bind_del);

                if (range.Rows[0]["min_nut_date"].ToString() != "")
                {
                    if (range.Rows.Count > 0)
                    {
                        #region INP5001 CRON, 締切情報取得
                        cmd_del = @"SELECT A.CHARGE_YN
                                    , A.NUT_JO_MAGAM_YN
                                    , A.NUT_JU_MAGAM_YN
                                    , A.NUT_SEOK_MAGAM_YN
                                    , TO_CHAR(A.MAGAM_DATE, 'YYYY/MM/DD') MAGAM_DATE
                                 FROM INP5001 A
                                WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
                                  AND A.MAGAM_DATE BETWEEN '" + range.Rows[0]["min_nut_date"].ToString() + @"' 
                                                       AND '" + TypeCheck.NVL(range.Rows[0]["max_nut_date"].ToString(), "9998/12/31") + @"'
                                ORDER BY A.MAGAM_DATE DESC
                                  ";
                        #endregion
                    }
                }
                else if (range.Rows[0]["min_nut_date"].ToString() == "")
                {
                    cmd_del = @"SELECT A.CHARGE_YN
                                     , A.NUT_JO_MAGAM_YN
                                     , A.NUT_JU_MAGAM_YN
                                     , A.NUT_SEOK_MAGAM_YN
                                     , TO_CHAR(A.MAGAM_DATE, 'YYYY/MM/DD') MAGAM_DATE
                                  FROM INP5001 A
                                 WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
                                   AND A.MAGAM_DATE BETWEEN '" + dr["drt_from_date"].ToString() + @"' 
                                                        AND '" + TypeCheck.NVL(dr["drt_to_date"], "9998/12/31").ToString() + @"'
                                 ORDER BY A.MAGAM_DATE DESC
                                  ";
                }

                DataTable dt = Service.ExecuteDataTable(cmd_del);

                string charge_yn = "";
                string magam_date_del = "";

                //会計関係
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    if (dt != null)
                    {
                        charge_yn = dt.Rows[d]["charge_yn"].ToString();
                        magam_date_del = DateTime.Parse(dt.Rows[d]["magam_date"].ToString()).ToString("yyyy/MM/dd");
                    }

                    if (charge_yn == "Y")
                    {
                        switch (dr["bld_gubun"].ToString())
                        {
                            case BLD_BREAKFAST: // 朝食
                                if (!Recover_ListD.Contains(magam_date_del))
                                    Recover_ListD.Add(magam_date_del);
                                break;

                            case BLD_LUNCH: // 昼食
                                if (!Recover_ListD.Contains(magam_date_del))
                                    Recover_ListD.Add(magam_date_del);
                                break;

                            case BLD_DINNER: // 夕食
                                if (!Recover_ListD.Contains(magam_date_del))
                                    Recover_ListD.Add(magam_date_del);
                                break;
                        }
                    }
                }
            }

            return true;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            XButton btn = sender as XButton;
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            string magam_date = "0";

            string nut_jo_magam_yn = "0";
            string nut_ju_magam_yn = "0";
            string nut_seok_magam_yn = "0";

            switch (e.Func)
            {
                case FunctionType.Reset:
                    e.IsBaseCall = false;
                    this.paBox.SetPatientID(this.paBox.BunHo);

                    this.grdPatientList.QueryLayout(false);
                    this.grdPatientList.SetFilter("jaewon_yn = '" + mPRESSED_JAEWON_YN + "'");

                    // display calendar
                    this.layVW_OCS_OCS2005_NUT.QueryLayout(false);
                    this.SetSiksaHisInfo(this.layVW_OCS_OCS2005_NUT);

                    this.getMagamStatus();
                    break;
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdPatientList.QueryLayout(false);
                    this.grdPatientList.SetFilter("jaewon_yn = '" + mPRESSED_JAEWON_YN + "'");

                    // display calendar
                    this.layVW_OCS_OCS2005_NUT.QueryLayout(false);
                    this.SetSiksaHisInfo(this.layVW_OCS_OCS2005_NUT);
                    this.getMagamStatus();
                    break;
                case FunctionType.Update:

                    try
                    {
                        Service.BeginTransaction();
                        string cmd = @"SELECT FN_NUT_IS_SIKSA_MAGAM_YN('" + EnvironInfo.HospCode + "' ) FROM SYS.DUAL";
                        object obj = Service.ExecuteScalar(cmd);

                        if (obj.ToString() != "0")
                        {
                            magam_date = obj.ToString().Substring(0, 10);
                            nut_jo_magam_yn = obj.ToString().Substring(10, 1);
                            nut_ju_magam_yn = obj.ToString().Substring(11, 1);
                            nut_seok_magam_yn = obj.ToString().Substring(12, 1);
                        }


                        if (!this.ValidationCheck(this.grdOCS2005_B))
                            return;
                        if (!this.ValidationCheck(this.grdOCS2005_L))
                            return;
                        if (!this.ValidationCheck(this.grdOCS2005_D))
                            return;

                        #region 追加、修正対象追出
                        if (!this.RecoveryDataCheck(this.grdOCS2005_B, magam_date, nut_jo_magam_yn))
                            return;
                        if (!this.RecoveryDataCheck(this.grdOCS2005_L, magam_date, nut_ju_magam_yn))
                            return;
                        if (!this.RecoveryDataCheck(this.grdOCS2005_D, magam_date, nut_seok_magam_yn))
                            return;
                        #endregion 追加、修正対象追出

                        #region 削除対象追出
                        if (!this.RecoveryDataCheck_delete(this.grdOCS2005_B.DeletedRowTable))
                            return;
                        if (!this.RecoveryDataCheck_delete(this.grdOCS2005_L.DeletedRowTable))
                            return;
                        if (!this.RecoveryDataCheck_delete(this.grdOCS2005_D.DeletedRowTable))
                            return;
                        #endregion 削除対象追出

                        if (!this.grdOCS2005_B.SaveLayout())
                            throw new Exception("朝食の食事箋の保存に失敗しました｡");

                        if (!this.grdOCS2005_L.SaveLayout())
                            throw new Exception("昼食の食事箋の保存に失敗しました｡");

                        if (!this.grdOCS2005_D.SaveLayout())
                            throw new Exception("夕食の食事箋の保存に失敗しました｡");

                        if (this.Recover_List.Count > 0) 
                        {
                            for (int i = 0; i < this.Recover_List.Count; i++)
                            {
                                inputList.Clear();
                                inputList.Add("I_UPD_ID", UserInfo.UserID);
                                inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
                                inputList.Add("I_BUNHO", this.paBox.BunHo);
                                inputList.Add("I_FKINP1001", this.GetPkInp1001());
                                inputList.Add("I_CHARGE_DATE", this.Recover_List[i].ToString());
                                inputList.Add("I_WORK_GUBUN", "R");

                                if (Service.ExecuteProcedure("PR_OCS_DAILY_NUT", inputList, outputList))
                                {
                                    if (outputList.Count > 0)
                                    {
                                        if (outputList["O_FLAG"].ToString() == "N")
                                        {
                                            //mErrMsg = "受付が出来ません。オーダを確認してください。";
                                            throw new Exception(Service.ErrFullMsg);
                                        }
                                    }
                                }
                                else
                                    throw new Exception(Service.ErrFullMsg);
                            }
                        }

                        if (Recover_ListD.Count > 0)
                        {
                            for (int i = 0; i < Recover_ListD.Count; i++)
                            {
                                inputList.Clear();
                                inputList.Add("I_UPD_ID", UserInfo.UserID);
                                inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
                                inputList.Add("I_BUNHO", this.paBox.BunHo);
                                inputList.Add("I_FKINP1001", this.GetPkInp1001());
                                inputList.Add("I_CHARGE_DATE", Recover_ListD[i].ToString());
                                inputList.Add("I_WORK_GUBUN", "R");

                                if (Service.ExecuteProcedure("PR_OCS_DAILY_NUT", inputList, outputList))
                                {
                                    if (outputList.Count > 0)
                                    {
                                        if (outputList["O_FLAG"].ToString() == "N")
                                        {
                                            //mErrMsg = "受付が出来ません。オーダを確認してください。";
                                            throw new Exception(Service.ErrFullMsg);
                                        }
                                    }
                                }
                                else
                                    throw new Exception(Service.ErrFullMsg);
                            }
                        }
                    }
                    catch (Exception xe)
                    {
                        Service.RollbackTransaction();
                        //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "ExecuteUpdate Error", MessageBoxIcon.Error);
                        XMessageBox.Show(xe.Message);
                        this.paBox.SetPatientID(this.paBox.BunHo);
                        return;
                    }
                    this.paBox.SetPatientID(this.paBox.BunHo);
                    Service.CommitTransaction();
                    XMessageBox.Show("保存されました。", "確認");
                    this.getMagamStatus();
                    break;
            }
        }
        private bool RecoveryDataCheck(XEditGrid grd, string aMagam_date, string aBLD_MAGAM_YN)
        {
            string cmd = "";
            string charge_yn = "";
            string nut_jo_magam_yn = "";
            string nut_ju_magam_yn = "";
            string nut_seok_magam_yn = "";
            string magam_date = "";
            string drt_from_date = "";
            DialogResult result = new DialogResult();


            
            // 修正しようとしているデータが締切されているのかどうかをチェックして締切されているデータであれば「警告」メッセージ表示するように
            for (int i = 0; i < grd.RowCount; i++)
            {

                if (grd.GetRowState(i) == DataRowState.Modified || grd.GetRowState(i) == DataRowState.Added)
                {
                    #region [最終締切が終わっているのかチェック]
                    string cmd_magam_yn = "";
                    string final_b = "";
                    string final_l = "";
                    string final_d = "";
                    
                    drt_from_date = grd.GetItemString(i, "drt_from_date");

                    cmd_magam_yn = @"   SELECT NVL(A.CHARGE_YN, 'N')            CHARGE_YN
                                     , NVL(A.NUT_JO_MAGAM_YN, 'N')      NUT_JO_MAGAM_YN
                                     , NVL(A.NUT_JU_MAGAM_YN, 'N')      NUT_JU_MAGAM_YN
                                     , NVL(A.NUT_SEOK_MAGAM_YN, 'N')    NUT_SEOK_MAGAM_YN
                                  FROM INP5001 A 
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.MAGAM_DATE = :f_magam_date";
                    BindVarCollection final_bind = new BindVarCollection();
                    final_bind.Add("f_hosp_code", EnvironInfo.HospCode);
                    final_bind.Add("f_magam_date", grd.GetItemString(i, "drt_from_date"));

                    DataTable final_dt = Service.ExecuteDataTable(cmd_magam_yn, final_bind);
                    if (final_dt.Rows.Count > 0)
                    {
                        final_b = final_dt.Rows[0]["NUT_JO_MAGAM_YN"].ToString();
                        final_l = final_dt.Rows[0]["NUT_JU_MAGAM_YN"].ToString();
                        final_d = final_dt.Rows[0]["NUT_SEOK_MAGAM_YN"].ToString();
                    }
                    #endregion

                    if (grd.GetRowState(i) == DataRowState.Modified)
                    {
                        
                        string recovery_max_min = @"SELECT    LEAST(NVL(MIN(:f_drt_from_date), MIN(B.DRT_DATE)), NVL(MIN(B.DRT_DATE), MIN(:f_drt_from_date))) AS MIN_NUT_DATE
                                                         , GREATEST(NVL(MAX(:f_drt_to_date),   MAX(B.DRT_DATE)), NVL(MAX(B.DRT_DATE), MAX(:f_drt_to_date)))   AS MAX_NUT_DATE
                                                      FROM OCS2015 B
                                                     WHERE B.HOSP_CODE = :f_hosp_code
                                                       AND B.FKOCS2005 = :f_pkocs2005";

                        BindVarCollection bind = new BindVarCollection();
                        bind.Add("f_drt_from_date", grd.GetItemString(i, "drt_from_date"));
                        bind.Add("f_drt_to_date", grd.GetItemString(i, "drt_to_date"));
                        bind.Add("f_hosp_code", EnvironInfo.HospCode);
                        bind.Add("f_pkocs2005", grd.GetItemString(i, "pkocs2005"));

                        DataTable range = Service.ExecuteDataTable(recovery_max_min, bind);

                        if (range.Rows[0]["min_nut_date"].ToString() != "")
                        {
                            if (range.Rows.Count > 0)
                            {
                                #region INP5001 CRON, 締切情報取得
                                cmd = @"SELECT A.CHARGE_YN
                                    , A.NUT_JO_MAGAM_YN
                                    , A.NUT_JU_MAGAM_YN
                                    , A.NUT_SEOK_MAGAM_YN
                                    , TO_CHAR(A.MAGAM_DATE, 'YYYY/MM/DD') MAGAM_DATE
                                 FROM INP5001 A
                                WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
                                  AND A.MAGAM_DATE BETWEEN '" + range.Rows[0]["min_nut_date"].ToString() + @"' 
                                                       AND '" + TypeCheck.NVL(range.Rows[0]["max_nut_date"].ToString(), "9998/12/31") + @"'
                                ORDER BY A.MAGAM_DATE DESC
                                  ";
                                #endregion
                            }
                        }
                        else if (range.Rows[0]["min_nut_date"].ToString() == "")
                        {
                            cmd = @"SELECT A.CHARGE_YN
                                     , A.NUT_JO_MAGAM_YN
                                     , A.NUT_JU_MAGAM_YN
                                     , A.NUT_SEOK_MAGAM_YN
                                     , TO_CHAR(A.MAGAM_DATE, 'YYYY/MM/DD') MAGAM_DATE
                                  FROM INP5001 A
                                 WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
                                   AND A.MAGAM_DATE BETWEEN '" + grd.GetItemString(grd.CurrentRowNumber, "drt_from_date") + @"' 
                                                        AND '" + TypeCheck.NVL(grd.GetItemString(grd.CurrentRowNumber, "drt_to_date"), "9998/12/31") + @"'
                                 ORDER BY A.MAGAM_DATE DESC
                                  ";
                        }
//                        else
//                        {
//                            cmd = @"SELECT A.CHARGE_YN
//                                     , A.NUT_JO_MAGAM_YN
//                                     , A.NUT_JU_MAGAM_YN
//                                     , A.NUT_SEOK_MAGAM_YN
//                                     , A.MAGAM_DATE
//                                  FROM INP5001 A
//                                 WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
//                                   AND A.MAGAM_DATE BETWEEN '" + grd.GetItemString(grd.CurrentRowNumber, "drt_from_date") + @"' 
//                                                        AND '" + TypeCheck.NVL(grd.GetItemString(grd.CurrentRowNumber, "drt_to_date"), "9998/12/31") + @"'
//                                  ";
//                        }

                    }
                    else
                    {
                        cmd = @"SELECT A.CHARGE_YN
                                     , A.NUT_JO_MAGAM_YN
                                     , A.NUT_JU_MAGAM_YN
                                     , A.NUT_SEOK_MAGAM_YN
                                     , TO_CHAR(A.MAGAM_DATE, 'YYYY/MM/DD') MAGAM_DATE
                                  FROM INP5001 A
                                 WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
                                   AND A.MAGAM_DATE BETWEEN '" + grd.GetItemString(grd.CurrentRowNumber, "drt_from_date") + @"' 
                                                        AND '" + TypeCheck.NVL(grd.GetItemString(grd.CurrentRowNumber, "drt_to_date"), "9998/12/31") + @"'
                                 ORDER BY A.MAGAM_DATE DESC
                                  ";
                    }

                    DataTable dt = Service.ExecuteDataTable(cmd);


                    #region CRON作成件がなかったら　締切テーブルに締切した情報があるのかをチェック
                    /*if (dt == null)
                    {
                        string m_cmd = @"SELECT A.CHARGE_YN
                                     , A.NUT_JO_MAGAM_YN
                                     , A.NUT_JU_MAGAM_YN
                                     , A.NUT_SEOK_MAGAM_YN
                                     , A.MAGAM_DATE
                                  FROM INP5001 A
                                 WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
                                   AND A.MAGAM_DATE BETWEEN '" + grd.GetItemString(grd.CurrentRowNumber, "drt_from_date") + @"' 
                                                        AND '" + TypeCheck.NVL(grd.GetItemString(grd.CurrentRowNumber, "drt_to_date"), "9998/12/31") + @"'
                                  ";
                        DataTable m_dt = Service.ExecuteDataTable(m_cmd);
                        for (int d = 0; d < m_dt.Rows.Count; d++)
                        {
                            if (m_dt != null)
                            {
                                charge_yn = m_dt.Rows[d]["charge_yn"].ToString();
                                nut_jo_magam_yn = m_dt.Rows[d]["nut_jo_magam_yn"].ToString();
                                nut_ju_magam_yn = m_dt.Rows[d]["nut_ju_magam_yn"].ToString();
                                nut_seok_magam_yn = m_dt.Rows[d]["nut_seok_magam_yn"].ToString();
                                magam_date = DateTime.Parse(m_dt.Rows[d]["magam_date"].ToString()).ToString("yyyy/MM/dd");
                            }

                            if (m_dt.Rows.Count > 0)
                            {
                                switch (grd.GetItemString(i, "bld_gubun"))
                                {
                                    case BLD_BREAKFAST: // 朝食

                                        if (magam_date == aMagam_date && aBLD_MAGAM_YN == "Y")
                                        {
                                            result = XMessageBox.Show(magam_date + " 朝食締切が終わっています。それでも追加及び修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                            if (result == DialogResult.No)
                                                return false;
                                        }
                                        break;

                                    case BLD_LUNCH: // 昼食

                                        if (magam_date == aMagam_date && aBLD_MAGAM_YN == "Y")
                                        {
                                            result = XMessageBox.Show(magam_date + " 昼食締切が終わっています。それでも追加及び修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                            if (result == DialogResult.No)
                                                return false;
                                        }
                                        break;

                                    case BLD_DINNER: // 夕食

                                        if (magam_date == aMagam_date && aBLD_MAGAM_YN == "Y")
                                        {
                                            result = XMessageBox.Show(magam_date + " 夕食締切が終わっています。それでも追加及び修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                            if (result == DialogResult.No)
                                                return false;
                                        }
                                        break;
                                }
                            }
                        }

                    }*/
                    #endregion

                    //栄養科関係
                    if (dt.Rows.Count > 0)
                    {
                        getMagamStatus();

                        switch (grd.GetItemString(i, "bld_gubun"))
                        {
                            case BLD_BREAKFAST: // 朝食
                                if (final_b == "Y")
                                {
                                    if (this.cbxSiksaChangeYN.Checked)
                                    {
                                        result = XMessageBox.Show(dt.Rows[dt.Rows.Count - 1]["magam_date"].ToString()
                                                                  + "～" + dt.Rows[0]["magam_date"].ToString() + " 朝食の「最終締切」が終わっています。"
                                                                  + "この件に関しましては栄養室に別途通知が必要です。"
                                                                  + "それでも追加及び修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    }
                                    else
                                    {
                                        XMessageBox.Show("栄養科で最終締切が終わっています。食事変更することはできません。\r\n(変更する必要があれば栄養科に連絡してください。)", "確認");
                                        return false;
                                    }
                                }
                                if (result == DialogResult.No)
                                    return false;
                                break;
                            case BLD_LUNCH: // 昼食
                                if (final_l == "Y")
                                {
                                    if (this.cbxSiksaChangeYN.Checked)
                                    {
                                        result = XMessageBox.Show(dt.Rows[dt.Rows.Count - 1]["magam_date"].ToString()
                                                                  + "～" + dt.Rows[0]["magam_date"].ToString() + " 昼食の「最終締切」が終わっています。"
                                                                  + "この件に関しましては栄養室に別途通知が必要です。"
                                                                  + "それでも追加及び修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    }
                                    else
                                    {
                                        XMessageBox.Show("栄養科で最終締切が終わっています。食事変更することはできません。\r\n(変更する必要があれば栄養科に連絡してください。)", "確認");
                                        return false;
                                    }
                                }
                                if (result == DialogResult.No)
                                    return false;
                                break;
                            case BLD_DINNER: // 夕食
                                if (final_d == "Y")
                                {
                                    if (this.cbxSiksaChangeYN.Checked)
                                    {
                                        result = XMessageBox.Show(dt.Rows[dt.Rows.Count - 1]["magam_date"].ToString()
                                                                  + "～" + dt.Rows[0]["magam_date"].ToString() + " 夕食の「最終締切」が終わっています。"
                                                                  + "この件に関しましては栄養室に別途通知が必要です。"
                                                                  + "それでも追加及び修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    }
                                    else
                                    {
                                        XMessageBox.Show("栄養科で最終締切が終わっています。食事変更することはできません。\r\n(変更する必要があれば栄養科に連絡してください。)", "確認");
                                        return false;
                                    }
                                }
                                if (result == DialogResult.No)
                                    return false;
                                break;
                        }

                    }
                    

                    //会計関係
                    for (int d = 0; d < dt.Rows.Count; d++)
                    {
                        if (dt != null)
                        {
                            charge_yn = dt.Rows[d]["charge_yn"].ToString();
                            nut_jo_magam_yn = dt.Rows[d]["nut_jo_magam_yn"].ToString();
                            nut_ju_magam_yn = dt.Rows[d]["nut_ju_magam_yn"].ToString();
                            nut_seok_magam_yn = dt.Rows[d]["nut_seok_magam_yn"].ToString();
                            magam_date = DateTime.Parse(dt.Rows[d]["magam_date"].ToString()).ToString("yyyy/MM/dd");
                        }

                        if (charge_yn == "Y")
                        {
                            switch (grd.GetItemString(i, "bld_gubun"))
                            {
                                case BLD_BREAKFAST: // 朝食
                                    if (!this.Recover_List.Contains(magam_date))
                                        this.Recover_List.Add(magam_date);

                                    if (this.Recover_List.Count < 2)
                                    {
                                        //if (magam_date == aMagam_date && aBLD_MAGAM_YN == "Y")
                                        //if (aBLD_MAGAM_YN == "Y")
                                        //{

//                                            result = XMessageBox.Show(dt.Rows[dt.Rows.Count-1]["magam_date"].ToString() + "～" + dt.Rows[0]["magam_date"].ToString() + @" 朝食の「最終締切」が終わっています。
//この件に関しましては栄養室に別途通知が必要です。
//それでも追加及び修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//                                                if (result == DialogResult.No)
//                                                    return false;
                                        
                                        //}
                                    }
                                    break;

                                case BLD_LUNCH: // 昼食
                                    if (!this.Recover_List.Contains(magam_date))
                                        this.Recover_List.Add(magam_date);
                                    if (this.Recover_List.Count < 2)
                                    {
                                        //if (magam_date == aMagam_date && aBLD_MAGAM_YN == "Y")
                                        //if (aBLD_MAGAM_YN == "Y")
                                        //{

//                                            result = XMessageBox.Show(dt.Rows[dt.Rows.Count - 1]["magam_date"].ToString() + "～" + dt.Rows[0]["magam_date"].ToString() + @" 昼食の「最終締切」が終わっています。
//この件に関しましては栄養室に別途通知が必要です。
//それでも追加及び修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//                                            if (result == DialogResult.No)
//                                                return false;

                                        //}
                                    }
                                    break;

                                case BLD_DINNER: // 夕食
                                    if (!this.Recover_List.Contains(magam_date))
                                        this.Recover_List.Add(magam_date);

                                    if (this.Recover_List.Count < 2)
                                    {
                                        //if (magam_date == aMagam_date && aBLD_MAGAM_YN == "Y")
                                        //if (aBLD_MAGAM_YN == "Y")
                                        //{
//                                            result = XMessageBox.Show(dt.Rows[dt.Rows.Count - 1]["magam_date"].ToString() + "～" + dt.Rows[0]["magam_date"].ToString() + @" 夕食の「最終締切」が終わっています。
//この件に関しましては栄養室に別途通知が必要です。
//それでも追加及び修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//                                            if (result == DialogResult.No)
//                                                return false;

                                        //}
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool ValidationCheck(XEditGrid grd)
        {
            string BLD_GUBUN = "";
            this.SetBLDControl(grd.Tag.ToString());
            switch (grd.Tag.ToString())
            {
                case BLD_BREAKFAST:
                    BLD_GUBUN = "【朝食】";
                    break;
                case BLD_LUNCH:
                    BLD_GUBUN = "【昼食】";
                    break;
                case BLD_DINNER:
                    BLD_GUBUN = "【夕食】";
                    break;
            }

            #region 必須項目チェック
            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetRowState(i) == DataRowState.Modified || grd.GetRowState(i) == DataRowState.Added)
                {
                    //退院されている患者なのかチェックして退院患者のデータは修正できないよう様に修正
                    if (this.mToiwon_date != "0")
                    {
                        XMessageBox.Show(BLD_GUBUN + " 退院された患者のデータは修正できません。", "確認");
                        this.btnList.PerformClick(FunctionType.Reset);
                        return false;
                    }

                    //コードが有効なのかチェック
                    string cmd = @"SELECT FN_OCS_IS_SIKSA_CODE(:f_hosp_code, :f_direct_cont1, :f_direct_cont1_d
                                                                           , :f_direct_cont2, :f_direct_cont2_d
                                                                           , :f_direct_cont3, :f_direct_cont3_d) FROM SYS.DUAL";
                    BindVarCollection bind = new BindVarCollection();
                    bind.Add("f_hosp_code", EnvironInfo.HospCode);
                    //
                    bind.Add("f_direct_cont1", grd.GetItemString(i, "direct_cont1"));
                    bind.Add("f_direct_cont1_d", grd.GetItemString(i, "direct_cont1_d"));
                    //
                    bind.Add("f_direct_cont2", grd.GetItemString(i, "direct_cont2"));
                    bind.Add("f_direct_cont2_d", grd.GetItemString(i, "direct_cont2_d"));
                    //
                    bind.Add("f_direct_cont3", grd.GetItemString(i, "direct_cont3"));
                    bind.Add("f_direct_cont3_d", grd.GetItemString(i, "direct_cont3_d"));

                    object obj = Service.ExecuteScalar(cmd, bind);

                    if (obj.ToString() == "0")
                    {
                        XMessageBox.Show(BLD_GUBUN + " 食事データが正しくありません。食事データを確認してください。", "確認");
                        return false;
                    }

                    if (grd.GetItemString(i, "drt_from_date") == "")
                    {
                        XMessageBox.Show(BLD_GUBUN + " 開始日が指定されていません。確認して下さい。", "確認");
                        return false;
                    }

                    if (grd.GetItemString(i, "drt_from_date") != "")
                    {
                        if (grd.GetItemString(i, "drt_to_date") != "")
                        {
                            // start_date < end_date check
                            if (int.Parse(DateTime.Parse(grd.GetItemString(i, "drt_from_date")).ToString("yyyyMMdd")) > int.Parse(DateTime.Parse(grd.GetItemString(i, "drt_to_date")).ToString("yyyyMMdd")))
                            {
                                XMessageBox.Show(BLD_GUBUN + " 開始日または終了日が間違っています。");
                                return false;
                            }
                        }
                    }

                    if (grd.GetItemString(i, "direct_code_d").Trim() == "")
                    {
                        XMessageBox.Show(BLD_GUBUN + " 食事区分がありません。");
                        return false;
                    }
                    if (grd.GetItemString(i, "direct_cont1_d").Trim() == "" || this.CBO_SIKJONG.SelectedValue == null)
                    {
                        XMessageBox.Show(BLD_GUBUN + " 食種が選択されていません。");
                        return false;
                    }
                    if (grd.GetItemString(i, "direct_cont2_d").Trim() == "" || this.CBO_JUSIK.SelectedValue == null)
                    {
                        XMessageBox.Show(BLD_GUBUN + " 主食が選択されていません。");
                        return false;
                    }
                    if (grd.GetItemString(i, "direct_cont3_d").Trim() == "" || this.CBO_BUSIK.SelectedValue == null)
                    {
                        XMessageBox.Show(BLD_GUBUN + " 副食が選択されていません。");
                        return false;
                    }
                    if (grd.GetItemString(i, "drt_from_date") != "")
                    {
                        if (this.IsNutCheckFromToDate(grd.GetItemString(i, "drt_from_date"), this.paBox.BunHo, EnvironInfo.HospCode, grd.GetItemString(i, "bld_gubun"), grd.GetItemString(i, "pkocs2005"), true))
                            return false;
                    }
                    if (grd.GetItemString(i, "drt_to_date") != "")
                    {
                        if (this.IsNutCheckFromToDate(grd.GetItemString(i, "drt_to_date"), this.paBox.BunHo, EnvironInfo.HospCode, grd.GetItemString(i, "bld_gubun"), grd.GetItemString(i, "pkocs2005"), true))
                            return false;
                    }
                }
            }
            #endregion

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////

        #region [-- XSavePerformer --]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS2005U02 parent = null;

            public XSavePerformer(OCS2005U02 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("f_bunho", parent.paBox.BunHo);

                item.BindVarList.Remove("f_pk_seq");
                item.BindVarList.Add("f_pk_seq", parent.GetPkSeq(item.BindVarList));

                if (item.BindVarList["f_drt_to_date"].VarValue == "")
                    item.BindVarList["f_continue_yn"].VarValue = "Y";
                else
                    item.BindVarList["f_continue_yn"].VarValue = "N";

                if (parent.IsNutCheckFromToDate(item.BindVarList["f_drt_from_date"].VarValue, parent.paBox.BunHo, EnvironInfo.HospCode, item.BindVarList["f_bld_gubun"].VarValue, item.BindVarList["f_pkocs2005"].VarValue, true))
                    return false;

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO OCS2005
                                                    ( SYS_DATE,         SYS_ID,             UPD_DATE,         UPD_ID,
                                                      PKOCS2005,        BUNHO,              FKINP1001,        ORDER_DATE,
                                                      INPUT_GUBUN,      INPUT_ID,           PK_SEQ,           HOSP_CODE,
                                                      DRT_FROM_DATE,    DRT_TO_DATE,        CONTINUE_YN,      DIRECT_GUBUN,
                                                      DIRECT_CODE,      DIRECT_CONT1,       DIRECT_CONT2,     NOMIMONO,
                                                      KUMJISIK,         BLD_GUBUN,          DIRECT_CODE_D,    DIRECT_CONT1_D,
                                                      DIRECT_CONT2_D,   DIRECT_CONT3_D,     DIRECT_CONT3     )
                                            VALUES
                                                    ( SYSDATE,          :q_user_id,         SYSDATE,          :q_user_id,
                                                   OCS2005_SEQ.NEXTVAL, :f_bunho,           :f_fkinp1001,     TRUNC(SYSDATE),
                                                      'D0',             :q_user_id,         :f_pk_seq,        :f_hosp_code,
                                                      :f_drt_from_date, :f_drt_to_date,     :f_continue_yn,   '03',
                                                      :f_direct_code,   :f_direct_cont1,    :f_direct_cont2,  TRIM(:f_nomimono),
                                                      :f_kumjisik,      :f_bld_gubun,       :f_direct_code_d, :f_direct_cont1_d,
                                                      :f_direct_cont2_d,:f_direct_cont3_d,  :f_direct_cont3   )";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE OCS2005
                                               SET UPD_ID          = :q_user_id
                                                 , UPD_DATE        = SYSDATE
                                                 , DRT_FROM_DATE   = :f_drt_from_date
                                                 , DRT_TO_DATE     = :f_drt_to_date
                                                 , DIRECT_CODE     = :f_direct_code
                                                 , DIRECT_CONT1    = :f_direct_cont1
                                                 , DIRECT_CONT2    = :f_direct_cont2
                                                 , DIRECT_CONT3    = :f_direct_cont3
                                                 , DIRECT_CODE_D   = :f_direct_code_d
                                                 , DIRECT_CONT1_D  = :f_direct_cont1_d
                                                 , DIRECT_CONT2_D  = :f_direct_cont2_d
                                                 , DIRECT_CONT3_D  = :f_direct_cont3_d
                                                 , CONTINUE_YN     = :f_continue_yn
                                                 , KUMJISIK        = :f_kumjisik
                                                 , NOMIMONO        = TRIM(:f_nomimono)
                                                 

                                             WHERE PKOCS2005     = :f_pkocs2005
                                               AND HOSP_CODE     = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE OCS2005
                                             WHERE PKOCS2005     = :f_pkocs2005
                                               AND HOSP_CODE     = :f_hosp_code";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void dtpStartDate_b_DataValidating(object sender, DataValidatingEventArgs e)
        {
        }

        #region 환자리스트 그리드 확장/축소
        private void btnExpand_Click(object sender, EventArgs e)
        {
            XButton btn = sender as XButton;

            string tipText = "";
            if (this.grdPatientList.CellInfos["suname"].CellWidth != 0)
            {
                this.grdPatientList.CellInfos["suname"].CellWidth = 0;
                this.grdPatientList.AutoSizeColumn(3, 0);
                this.grdPatientList.CellInfos["suname2"].CellWidth = 80;
                this.grdPatientList.AutoSizeColumn(4, 80);
                btn.Text = "カ";
            }
            else
            {
                this.grdPatientList.CellInfos["suname"].CellWidth = 80;
                this.grdPatientList.AutoSizeColumn(3, 80);
                this.grdPatientList.CellInfos["suname2"].CellWidth = 0;
                this.grdPatientList.AutoSizeColumn(4, 0);
                btn.Text = "漢";
            }
            this.grdPatientList.Refresh();
        }
        #endregion

        private void btnShort_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;

            this.SetBLDControl(ctl.Tag.ToString().Substring(0, 1));

            if (this.sik_gubun == "") return;

            string code_type = ctl.Tag.ToString().Substring(1, 1);
            string code = ctl.Tag.ToString().Substring(2, 3);

            //XMessageBox.Show(code_type + " " + code);
            //XMessageBox.Show(this.CBO_SIKJONG.Tag.ToString() + " " + this.CBO_JUSIK.Tag.ToString() + " " + this.CBO_BUSIK.Tag.ToString() + " " + this.CBO_NOMIMONO.Tag.ToString());

            switch (code_type)
            {
                case "S":
                    this.CBO_SIKJONG.SetDataValue(code);
                    break;
                case "J":
                    this.CBO_JUSIK.SetDataValue(code);
                    break;
                case "B":
                    this.CBO_BUSIK.SetDataValue(code);
                    break;
                case "N":
                    this.CBO_NOMIMONO.SetDataValue(code);
                    break;
            }
        }

        private void btnToiwonPatientList_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCS2005Q01();
        }

        private void OpenScreen_OCS2005Q01()
        {

            string naewon_date = this.dtpOrder_date.GetDataValue().PadRight(10).Substring(0, 10).Replace("-", "/");

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("hodong", "%");
            openParams.Add("hocode", "%");

            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005Q01", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void rbtJaewon_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;

            if (control.Checked)
            {
                control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;
            }
            else 
            {
                control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;
            }

            if (this.rbtJaewon.Checked == true)
            {
                this.grdPatientList.AutoSizeColumn(4, 0);  // 退院日
                this.grdPatientList.AutoSizeColumn(5, 80); // カナ
                this.mPRESSED_JAEWON_YN = "Y";
                //this.grdPatientList.SetFilter(" jaewon_yn = 'Y'");
            }
            else
            {
                this.grdPatientList.AutoSizeColumn(4, 80);
                this.grdPatientList.AutoSizeColumn(5, 0);
                this.mPRESSED_JAEWON_YN = "N";
                //this.grdPatientList.SetFilter(" jaewon_yn = 'N'");
            }
            this.grdPatientList.QueryLayout(false);
            
        }

        private void btnLoadOldComment_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            this.SetBLDControl(ctl.Tag.ToString());

            string cmd = @" SELECT A.KUMJISIK
                              FROM OCS2005 A
                             WHERE A.HOSP_CODE     = :f_hosp_code
                               AND A.BLD_GUBUN     = :f_bld_gubun
                               AND A.FKINP1001     = :f_fkinp1001
                               AND A.DRT_FROM_DATE = (  SELECT MAX(B.DRT_FROM_DATE) DRT_FROM_DATE
                                                          FROM OCS2005 B
                                                         WHERE B.HOSP_CODE = A.HOSP_CODE
                                                           AND B.BLD_GUBUN = A.BLD_GUBUN
                                                           AND B.FKINP1001 = A.FKINP1001)";

            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_fkinp1001", this.GetPkInp1001());
            bind.Add("f_bld_gubun", ctl.Tag.ToString());

            object obj = Service.ExecuteScalar(cmd, bind);

            if (obj.ToString() != "")
            {
                this.TXT_COMMENT.Text = obj.ToString();
                this.GRD.SetItemValue(this.GRD.CurrentRowNumber, "kumjisik", obj.ToString());
            }
            else
                XMessageBox.Show("前回のコメントがありません。", "確認");
        }

        private void btnCreateStopData_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();
            string StopButtonGubun = "";
            string StopGubun = "";
            StopButtonGubun = ctl.Tag.ToString();

            if (DateTime.Parse(this.dtpStopFromDate.GetDataValue()) > DateTime.Parse(this.dtpStopToDate.GetDataValue()))
            {
                XMessageBox.Show("入力した日付が正しくありません。", "確認");
                return;
            }

            switch (StopButtonGubun)
            {
                case "1":
                    StopGubun = this.cboGubun.SelectedValue.ToString();
                    break;
                case "2":
                    StopGubun = "4";
                    break;
            }
            try
            {
                Service.BeginTransaction();

                inputList.Clear();
                if (StopGubun != "4")
                {
                    inputList.Add("I_STOP_FROM_DATE", this.dtpStopFromDate.GetDataValue());
                    inputList.Add("I_STOP_FROM_BLD" , this.cboStopFromBLD.SelectedValue.ToString());
                    inputList.Add("I_STOP_TO_DATE"  , this.dtpStopToDate.GetDataValue());
                    inputList.Add("I_STOP_TO_BLD"   , this.cboStopToBLD.SelectedValue.ToString());
                }
                else
                {
                    string bld_gubun = "";

                    if (this.cboToiwonBLD.SelectedValue.ToString() == "0")
                    {
                        inputList.Add("I_STOP_FROM_DATE", this.dtpToiwonDate.GetDataValue());
                        inputList.Add("I_STOP_FROM_BLD", "1");
                    }
                    else if (this.cboToiwonBLD.SelectedValue.ToString() == "1")
                    {
                        inputList.Add("I_STOP_FROM_DATE", this.dtpToiwonDate.GetDataValue());
                        inputList.Add("I_STOP_FROM_BLD", "2");
                    }
                    else if (this.cboToiwonBLD.SelectedValue.ToString() == "2")
                    {
                        inputList.Add("I_STOP_FROM_DATE", this.dtpToiwonDate.GetDataValue());
                        inputList.Add("I_STOP_FROM_BLD", "3");
                    }
                    else if (this.cboToiwonBLD.SelectedValue.ToString() == "3")
                    {
                        inputList.Add("I_STOP_FROM_DATE", DateTime.Parse(this.dtpToiwonDate.GetDataValue()).AddDays(1));
                        inputList.Add("I_STOP_FROM_BLD", "1");
                        //XMessageBox.Show("夕食まで食べる患者さんは食止めしなくてもいいです。","確認");
                        //return;
                    }

                    inputList.Add("I_STOP_TO_DATE"  , DateTime.Parse(this.dtpToiwonDate.GetDataValue()).AddDays(7).ToString());
                    //inputList.Add("I_STOP_TO_DATE", this.dtpStopToDate.GetDataValue());
                    inputList.Add("I_STOP_TO_BLD"   , "3");
                }
                
                inputList.Add("I_BUNHO"         , this.paBox.BunHo);
                inputList.Add("I_HOSP_CODE"     , EnvironInfo.HospCode);
                inputList.Add("I_FKINP1001"     , this.GetPkInp1001());
                inputList.Add("I_UPD_ID"        , UserInfo.UserID);
                inputList.Add("I_COMMENT_GUBUN", StopGubun); // １：外泊、２：外出、３：食止め、４：退院    
                inputList.Add("I_IUD_GUBUN"     , "I");
                inputList.Add("I_IPWON_DATE", this.GetIpwon_Date());

                if (Service.ExecuteProcedure("PR_OCS_CREATE_STOP_SIKSA", inputList, outputList))
                {
                    if (outputList.Count > 0)
                    {
                        if (outputList["O_FLAG"].ToString() == "N")
                            throw new Exception(Service.ErrFullMsg);
                            
                    }
                }
                else
                    //throw new Exception(Service.ErrFullMsg);
                    throw new Exception("食事中止処理が失敗しました。中止期間中既に作成されている食事箋があるか確認して下さい。");
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message);
                this.paBox.SetPatientID(this.paBox.BunHo);
                return;
            }
            this.paBox.SetPatientID(this.paBox.BunHo);
            Service.CommitTransaction();
            XMessageBox.Show("食事中止が正常に処理されました。","確認");
        }

        private void btnSikJin_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            /*
                I_FROM_DATE             IN     OCS2005.DRT_FROM_DATE %TYPE
              , I_FROM_BLD              IN     OCS2005.BLD_GUBUN %TYPE
              , I_BUNHO                 IN     OCS2005.BUNHO %TYPE
              , I_HOSP_CODE             IN     OCS2005.HOSP_CODE %TYPE
              , I_FKINP1001             IN     OCS2005.FKINP1001 %TYPE
              , I_UPD_ID                IN     OCS2005.UPD_ID %TYPE
              , I_COMMENT_GUBUN         IN     VARCHAR2                      -- １：外泊、２：外出、３：食止め、４：退院
              , I_SIKJIN_GUBUN          IN     NUMBER    
              --
              , I_IUD_GUBUN             IN     VARCHAR2
              --
              , O_FLAG                  OUT VARCHAR2
             */

            try
            { 
                inputList.Clear();

                inputList.Add("I_FROM_DATE", this.dtpSikJin.GetDataValue());
                inputList.Add("I_FROM_BLD", cboSikJin.SelectedValue.ToString());

                inputList.Add("I_BUNHO", this.paBox.BunHo);
                inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
                inputList.Add("I_FKINP1001", this.GetPkInp1001());
                inputList.Add("I_UPD_ID", UserInfo.UserID);
                inputList.Add("I_COMMENT_GUBUN", "5"); // １：外泊、２：外出、３：食止め、４：退院、５：UP食
                inputList.Add("I_SIKJIN_GUBUN", this.cboSikJinNum.SelectedValue.ToString());
                inputList.Add("I_IUD_GUBUN", "I");

                if (this.cboSikJinNomimono.SelectedIndex > -1)
                    inputList.Add("I_NOMIMONO", this.cboSikJinNomimono.SelectedValue.ToString());
                else
                    inputList.Add("I_NOMIMONO", "");

                inputList.Add("I_IPWON_DATE", this.GetIpwon_Date());

                                
                if(this.rbtN1S1.Checked == true)
                    inputList.Add("I_SIKGUBUN1TH", "000");
                else if (this.rbtN1S2.Checked == true)
                    inputList.Add("I_SIKGUBUN1TH", "001");
                else if (this.rbtN1S3.Checked == true)
                    inputList.Add("I_SIKGUBUN1TH", "009");

                inputList.Add("I_SIKJONG1TH", this.cboSikjongN1.SelectedValue);
                inputList.Add("I_JUSIK1TH", this.cboJusikN1.SelectedValue);
                inputList.Add("I_BUSIK1TH", this.cboBusikN1.SelectedValue);

                if(this.rbtN2S1.Checked == true)
                    inputList.Add("I_SIKGUBUN2TH", "000");
                else if (this.rbtN2S2.Checked == true)
                    inputList.Add("I_SIKGUBUN2TH", "001");
                else if (this.rbtN2S3.Checked == true)
                    inputList.Add("I_SIKGUBUN2TH", "009");

                inputList.Add("I_SIKJONG2TH",  this.cboSikjongN2.SelectedValue);
                inputList.Add("I_JUSIK2TH", this.cboJusikN2.SelectedValue);
                inputList.Add("I_BUSIK2TH", this.cboBusikN2.SelectedValue);

                if(this.rbtN3S1.Checked == true)
                    inputList.Add("I_SIKGUBUN3TH", "000");
                else if (this.rbtN3S2.Checked == true)
                    inputList.Add("I_SIKGUBUN3TH", "001");
                else if (this.rbtN3S3.Checked == true)
                    inputList.Add("I_SIKGUBUN3TH", "009");

                inputList.Add("I_SIKJONG3TH",  this.cboSikjongN3.SelectedValue);
                inputList.Add("I_JUSIK3TH", this.cboJusikN3.SelectedValue);
                inputList.Add("I_BUSIK3TH", this.cboBusikN3.SelectedValue);

                if(this.rbtN4S1.Checked == true)
                    inputList.Add("I_SIKGUBUN4TH", "000");
                else if (this.rbtN4S2.Checked == true)
                    inputList.Add("I_SIKGUBUN4TH", "001");
                else if (this.rbtN4S3.Checked == true)
                    inputList.Add("I_SIKGUBUN4TH", "009");

                inputList.Add("I_SIKJONG4TH",  this.cboSikjongN4.SelectedValue);
                inputList.Add("I_JUSIK4TH", this.cboJusikN4.SelectedValue);
                inputList.Add("I_BUSIK4TH", this.cboBusikN4.SelectedValue);

                if (this.rbtN5S1.Checked == true)
                    inputList.Add("I_SIKGUBUN5TH", "000");
                else if (this.rbtN5S2.Checked == true)
                    inputList.Add("I_SIKGUBUN5TH", "001");
                else if (this.rbtN5S3.Checked == true)
                    inputList.Add("I_SIKGUBUN5TH", "009");

                inputList.Add("I_SIKJONG5TH",  this.cboSikjongN5.SelectedValue);
                inputList.Add("I_JUSIK5TH", this.cboJusikN5.SelectedValue);
                inputList.Add("I_BUSIK5TH", this.cboBusikN5.SelectedValue);
                
                // UP食チェック
                if (!this.CheckSikjin(inputList))
                    return;

                Service.BeginTransaction();

                if (Service.ExecuteProcedure("PR_OCS_CREATE_SIKJIN", inputList, outputList))
                {
                    if (outputList.Count > 0)
                    {
                        if (outputList["O_FLAG"].ToString() == "N")
                            throw new Exception(Service.ErrFullMsg);
                    }
                }
                else
                    throw new Exception(Service.ErrFullMsg);
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message);
                this.paBox.SetPatientID(this.paBox.BunHo);
                this.rbtStopProcess.Checked = true;
                return;
            }
            this.paBox.SetPatientID(this.paBox.BunHo);
            Service.CommitTransaction();
            this.rbtStopProcess.Checked = true;
            XMessageBox.Show("UP食が正常に処理されました。", "確認");
        }
        private bool CheckSikjin(Hashtable aList)
        {
            if (TypeCheck.NVL(aList["I_SIKGUBUN1TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_SIKJONG1TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_JUSIK1TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_BUSIK1TH"], "").ToString().Trim() == ""

                || TypeCheck.NVL(aList["I_SIKGUBUN2TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_SIKJONG2TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_JUSIK2TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_BUSIK2TH"], "").ToString().Trim() == ""

                || TypeCheck.NVL(aList["I_SIKGUBUN3TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_SIKJONG3TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_JUSIK3TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_BUSIK3TH"], "").ToString().Trim() == ""

                || TypeCheck.NVL(aList["I_SIKGUBUN4TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_SIKJONG4TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_JUSIK4TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_BUSIK4TH"], "").ToString().Trim() == ""

                || TypeCheck.NVL(aList["I_SIKGUBUN5TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_SIKJONG5TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_JUSIK5TH"], "").ToString().Trim() == ""
                || TypeCheck.NVL(aList["I_BUSIK5TH"], "").ToString().Trim() == ""
              )
            {
                XMessageBox.Show("UP食の食事構成が不十分です。ご確認して下さい。", "確認");
                return false;
            }
                
            
            return true;
        }


        private void rbtProcess_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rbt = sender as XRadioButton;
            int aCalWidth = 130;
            if (rbt.Checked == true)
            {
                switch (rbt.CheckedValue.ToString())
                {
                    case "K":
                        this.pnlStop.Visible = true;
                        this.pnlToiwon.Visible = false;
                        this.pnlSikJin.Visible = false;
                        break;
                    case "T":
                        this.pnlStop.Visible = false;
                        this.pnlToiwon.Visible = true;
                        this.pnlSikJin.Visible = false;
                        break;
                    case "S":
                        this.pnlStop.Visible = false;
                        this.pnlToiwon.Visible = false;
                        this.pnlSikJin.Visible = true;
                        break;

                }

                this.pnlAutoSikjin.Visible = false;
                this.calSiksa.Visible = true;

                //画面サイズ変更
                if (rbt.Name == "rbtSikJinProcess")
                {
                    //this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Size.Width + aCalWidth, this.ParentForm.Size.Height);

                    this.pnlAutoSikjin.Visible = true;
                    this.calSiksa.Visible = false;

                    this.rbtN1S1.Checked = false;
                    this.rbtN1S2.Checked = false;
                    this.rbtN1S3.Checked = false;

                    this.rbtN2S1.Checked = false;
                    this.rbtN2S2.Checked = false;
                    this.rbtN2S3.Checked = false;

                    this.rbtN3S1.Checked = false;
                    this.rbtN3S2.Checked = false;
                    this.rbtN3S3.Checked = false;

                    this.rbtN4S1.Checked = false;
                    this.rbtN4S2.Checked = false;
                    this.rbtN4S3.Checked = false;

                    this.rbtN5S1.Checked = false;
                    this.rbtN5S2.Checked = false;
                    this.rbtN5S3.Checked = false;

                    if (this.rbtN1S1.Checked == true || this.rbtN1S2.Checked == true || this.rbtN1S3.Checked == true)
                        this.setComboBox(SIKJIN1TH);
                    if (this.rbtN2S1.Checked == true || this.rbtN2S2.Checked == true || this.rbtN2S3.Checked == true)
                        this.setComboBox(SIKJIN2TH);
                    if (this.rbtN3S1.Checked == true || this.rbtN3S2.Checked == true || this.rbtN3S3.Checked == true)
                        this.setComboBox(SIKJIN3TH);
                    if (this.rbtN4S1.Checked == true || this.rbtN4S2.Checked == true || this.rbtN4S3.Checked == true)
                        this.setComboBox(SIKJIN4TH);
                    if (this.rbtN5S1.Checked == true || this.rbtN5S2.Checked == true || this.rbtN5S3.Checked == true)
                        this.setComboBox(SIKJIN5TH);
                }
                    
            }
            //else
            //{
            //    //画面サイズ変更
            //    if (rbt.Name == "rbtSikJinProcess")
            //        this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Size.Width - aCalWidth, this.ParentForm.Size.Height);
            //}
        }

        private void cbxSikJinNomimono_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cboSikJinNomimono.Enabled == false)
                this.cboSikJinNomimono.Enabled = true;
            else
                this.cboSikJinNomimono.Enabled = false;
        }

        private void btnChiryoKekaku_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "") return;

            this.OpenScreen_OCS6010U10();
        }

        private void OpenScreen_OCS6010U10()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.paBox.BunHo);
            param.Add("fkinp1001", this.GetPkInp1001());

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.ResponseFixed, param);
        }

        private void layVW_OCS_OCS2005_NUT_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layVW_OCS_OCS2005_NUT.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layVW_OCS_OCS2005_NUT.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layVW_OCS_OCS2005_NUT.SetBindVarValue("f_fkinp1001", this.GetPkInp1001());
        }

        private void tabOrderDate_ClosePressed(object sender, EventArgs e)
        {
            IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;
            Control ctl = sender as Control;

            // 機能未オープン
            this.DeleteCurrentTab(ctl.Tag.ToString(), control.SelectedTab);
        }
        #region 현재 그룹 삭제

        private bool DeleteCurrentTab(string aBLD_GUBUN, IHIS.X.Magic.Controls.TabPage aDestTabPage)
        {
            this.SetBLDControl(aBLD_GUBUN);
            
            // checkplz
            // 削除可能チェック
            // まだ保存されてない食箋は削除可能
            string cmd = @"SELECT FN_OCS_OCS2005_DELETE_YN(:f_drt_date, :f_bld_gubun) 
                             FROM SYS.DUAL";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_drt_date", this.GRD.GetItemString(this.GRD.CurrentRowNumber, "drt_from_date"));
            bind.Add("f_bld_gubun", aBLD_GUBUN);

            object obj = Service.ExecuteScalar(cmd, bind);

            if (obj.ToString() == "Y")
            {
                if (GetIpwon_Date() == this.GRD.GetItemString(this.GRD.CurrentRowNumber, "drt_from_date"))
                {
                    XMessageBox.Show("入院日の食事箋は削除することが出来ません", "確認");
                    return false;
                }
                else
                {
                    if (MessageBox.Show("食事箋を削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return false;
                }
            }
            else
            {
                XMessageBox.Show("締切された食事箋は削除できません。","確認");
                return false;
            }

            if (aDestTabPage == null) return false;

            this.GRD.DeleteRow(this.GRD.CurrentRowNumber);
            this.TAB.TabPages.Remove(aDestTabPage);

            // 削除されたＴＡＢの再整理
            for (int i = int.Parse(aDestTabPage.Tag.ToString()); i < this.TAB.TabPages.Count; i++)
            {
                if (int.Parse(this.TAB.TabPages[i].Tag.ToString()) > int.Parse(aDestTabPage.Tag.ToString()))
                {
                    this.TAB.TabPages[i].Tag = int.Parse(this.TAB.TabPages[i].Tag.ToString()) - 1;
                }
            }
            return true;
        }

        //private void DeleteOCS2015(string aDrt_from_date, string aDrt_to_date, string aPkocs2005, string aBld_gubun)
        //{
        //    try
        //    {
        //        Service.BeginTransaction();

        //        Hashtable inputList = new Hashtable();
        //        Hashtable outputList = new Hashtable();

        //        if (Recover_ListD.Count > 0)
        //        {
        //            for (int i = 0; i < Recover_ListD.Count; i++)
        //            {
        //                inputList.Clear();
        //                inputList.Add("I_UPD_ID", UserInfo.UserID);
        //                inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
        //                inputList.Add("I_BUNHO", this.paBox.BunHo);
        //                inputList.Add("I_FKINP1001", this.GetPkInp1001());
        //                inputList.Add("I_CHARGE_DATE", Recover_ListD[i].ToString());
        //                inputList.Add("I_WORK_GUBUN", "R");

        //                if (Service.ExecuteProcedure("PR_OCS_DAILY_NUT", inputList, outputList))
        //                {
        //                    if (outputList.Count > 0)
        //                    {
        //                        if (outputList["O_FLAG"].ToString() == "N")
        //                        {
        //                            //mErrMsg = "受付が出来ません。オーダを確認してください。";
        //                            throw new Exception(Service.ErrFullMsg);
        //                        }
        //                    }
        //                }
        //                else
        //                    throw new Exception(Service.ErrFullMsg);
        //            }
        //        }

        //    }
        //    catch
        //    {
        //        Service.RollbackTransaction();
        //    }

        //    Service.CommitTransaction();
        //}

        #endregion

        private void calSiksa_DayClick(object sender, XCalendarDayClickEventArgs e)
        {
            string BreakFast = "";
            string Lunch = "";
            string Dinner = "";
            int RowNum = -1;

            // GET PKOCS2005 USE 
            string cmd = @"SELECT 
                                 B.PKOCS2005
                                ,B.DRT_FROM_DATE
                                ,B.DRT_TO_DATE
                                    
                                ,(A.IPWON_DATE + AA.ADD_DAY) AS NUT_DATE
                                ,B.BLD_GUBUN
                                ,B.FKINP1001
                               
                           FROM INP1001 A,
                                (    SELECT (LEVEL - 1) AS ADD_DAY
                                       FROM SYS.DUAL A
                                 --CONNECT BY LEVEL BETWEEN 1 AND 3650
                                 --CONNECT BY LEVEL BETWEEN 1 AND (3650 + 365 * 2)) AA,
                                    CONNECT BY LEVEL BETWEEN 1
                                                         AND (TRUNC (SYSDATE) - TO_DATE ('20020101', 'YYYYMMDD'))) AA,
                                OCS2005 B                                                 --  転科転室
                                            
                                    
                                             
                          WHERE     1 = 1
                                --
                                AND (A.IPWON_DATE + AA.ADD_DAY) = :f_nut_date
                                AND B.FKINP1001 = :f_fkinp1001
                                --
                                AND B.HOSP_CODE = A.HOSP_CODE
                                AND B.BUNHO = A.BUNHO
                                AND B.FKINP1001 = A.PKINP1001
                                -- 食事指示
                                AND B.DIRECT_GUBUN = '03'
                                --
                                AND B.DRT_FROM_DATE >= A.IPWON_DATE
                                AND (B.DRT_TO_DATE IS NULL
                                     OR B.DRT_TO_DATE <=
                                           NVL (A.TOIWON_DATE, TO_DATE ('98991231', 'YYYYMMDD')))
                                -- 適用日
                                AND B.DRT_FROM_DATE =
                                       NVL (
                                          (SELECT MAX (Z.DRT_FROM_DATE)
                                             FROM OCS2005 Z
                                            WHERE     Z.HOSP_CODE = B.HOSP_CODE
                                                  AND Z.FKINP1001 = B.FKINP1001
                                                  AND Z.DIRECT_CODE = B.DIRECT_CODE
                                                  AND Z.BUNHO = B.BUNHO
                                                  AND Z.BLD_GUBUN = B.BLD_GUBUN
                                                  AND Z.DRT_FROM_DATE <=
                                                         (A.IPWON_DATE + AA.ADD_DAY)
                                                  AND (Z.DRT_TO_DATE IS NULL
                                                       OR Z.DRT_TO_DATE >=
                                                             (A.IPWON_DATE + AA.ADD_DAY))),
                                          (SELECT MAX (Z.DRT_FROM_DATE)
                                             FROM OCS2005 Z
                                            WHERE     Z.HOSP_CODE = B.HOSP_CODE
                                                  AND Z.FKINP1001 = B.FKINP1001
                                                  AND Z.DIRECT_CODE = B.DIRECT_CODE
                                                  AND Z.BUNHO = B.BUNHO
                                                  AND Z.BLD_GUBUN = B.BLD_GUBUN
                                                  AND Z.DRT_FROM_DATE <=
                                                         (A.IPWON_DATE + AA.ADD_DAY)
                                                  AND Z.DRT_TO_DATE =
                                                         (SELECT MAX (X.DRT_TO_DATE)
                                                            FROM OCS2005 X
                                                           WHERE     X.HOSP_CODE = Z.HOSP_CODE
                                                                 AND X.DIRECT_CODE = Z.DIRECT_CODE
                                                                 AND X.BUNHO = Z.BUNHO
                                                                 AND X.BLD_GUBUN = Z.BLD_GUBUN
                                                                 AND X.DRT_FROM_DATE <=
                                                                        (A.IPWON_DATE + AA.ADD_DAY))))
                                    
                                -- 入院期間
                                AND AA.ADD_DAY <=
                                       ( (NVL (A.TOIWON_DATE, TRUNC (SYSDATE)) - A.IPWON_DATE)
                                        + DECODE (A.TOIWON_DATE, NULL, 31, 0))
                                    
                           ORDER BY  4 
                                    , 5
            ";

            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_nut_date", e.DateItem.Date.ToString("yyyy/MM/dd"));
            bind.Add("f_fkinp1001", this.GetPkInp1001());

            DataTable dt = Service.ExecuteDataTable(cmd, bind);
            if (dt != null && dt.Rows.Count > 0)
            {
                BreakFast = dt.Rows[0]["pkocs2005"].ToString();
                Lunch = dt.Rows[1]["pkocs2005"].ToString();
                Dinner = dt.Rows[2]["pkocs2005"].ToString();
            }
            // FINDING PKOCS2005 IN GRD THEN GET ROWNUM

            // SELECT TAB INDEX

            // 朝
            this.SetBLDControl("1");

            RowNum = this.GetRowNumByPKOCS2005(BreakFast);

            if(RowNum > -1)
                this.TAB.SelectedIndex = RowNum;
            


            // 昼
            this.SetBLDControl("2");

            RowNum = this.GetRowNumByPKOCS2005(Lunch);

            if (RowNum > -1)
                this.TAB.SelectedIndex = RowNum;


            // 夜
            this.SetBLDControl("3");

            RowNum = this.GetRowNumByPKOCS2005(Dinner);

            if (RowNum > -1)
                this.TAB.SelectedIndex = RowNum;

        }

        private int GetRowNumByPKOCS2005(string aBreakFast)
        {
            for (int i = 0; i < this.GRD.RowCount; i++)
            {
                if (this.GRD.GetItemString(i, "pkocs2005") == aBreakFast)
                    return i;
            }
            return -1;
        }

        private void btnCalONOFF_Click(object sender, EventArgs e)
        {
            int aCalHight = 390;

            if (this.mCalSwitch)
            {
                this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Size.Width, this.ParentForm.Size.Height - aCalHight);
                this.mCalSwitch = false;
                this.btnCalONOFF.ImageIndex = 2;
            }
            else
            {
                this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Size.Width, this.ParentForm.Size.Height + aCalHight);
                this.mCalSwitch = true;
                this.btnCalONOFF.ImageIndex = 3;
            }
        }

        private void xGroupBox5_DataValidating(object sender, DataValidatingEventArgs e)
        {

        }

        private void btnUpSikSet1_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
                return;

            XButton btn = sender as XButton;

            XRadioButton rbtN1S1 = new XRadioButton();
            XRadioButton rbtN1S2 = new XRadioButton();
            XRadioButton rbtN1S3 = new XRadioButton();
            XComboBox cbo_sN1 = new XComboBox();
            XComboBox cbo_jN1 = new XComboBox();
            XComboBox cbo_bN1 = new XComboBox();

            XRadioButton rbtN2S1 = new XRadioButton();
            XRadioButton rbtN2S2 = new XRadioButton();
            XRadioButton rbtN2S3 = new XRadioButton();
            XComboBox cbo_sN2 = new XComboBox();
            XComboBox cbo_jN2 = new XComboBox();
            XComboBox cbo_bN2 = new XComboBox();

            XRadioButton rbtN3S1 = new XRadioButton();
            XRadioButton rbtN3S2 = new XRadioButton();
            XRadioButton rbtN3S3 = new XRadioButton();
            XComboBox cbo_sN3 = new XComboBox();
            XComboBox cbo_jN3 = new XComboBox();
            XComboBox cbo_bN3 = new XComboBox();

            XRadioButton rbtN4S1 = new XRadioButton();
            XRadioButton rbtN4S2 = new XRadioButton();
            XRadioButton rbtN4S3 = new XRadioButton();
            XComboBox cbo_sN4 = new XComboBox();
            XComboBox cbo_jN4 = new XComboBox();
            XComboBox cbo_bN4 = new XComboBox();

            XRadioButton rbtN5S1 = new XRadioButton();
            XRadioButton rbtN5S2 = new XRadioButton();
            XRadioButton rbtN5S3 = new XRadioButton();
            XComboBox cbo_sN5 = new XComboBox();
            XComboBox cbo_jN5 = new XComboBox();
            XComboBox cbo_bN5 = new XComboBox();

            string SIKGUBUN1 = "";
            string SIKJONG1 = "";
            string JUSIK1 = "";
            string BUSIK1 = "";

            string SIKGUBUN2 = "";
            string SIKJONG2 = "";
            string JUSIK2 = "";
            string BUSIK2 = "";

            string SIKGUBUN3 = "";
            string SIKJONG3 = "";
            string JUSIK3 = "";
            string BUSIK3 = "";

            string SIKGUBUN4 = "";
            string SIKJONG4 = "";
            string JUSIK4 = "";
            string BUSIK4 = "";

            string SIKGUBUN5 = "";
            string SIKJONG5 = "";
            string JUSIK5 = "";
            string BUSIK5 = "";

            switch(btn.Tag.ToString())
            {
                case "1":
                    SIKGUBUN1 = "000";
                    SIKJONG1 = "029";
                    JUSIK1 = "016";
                    BUSIK1 = "019";

                    SIKGUBUN2 = "000";
                    SIKJONG2 = "003";
                    JUSIK2 = "015";
                    BUSIK2 = "016";

                    SIKGUBUN3 = "000";
                    SIKJONG3 = "003";
                    JUSIK3 = "014";
                    BUSIK3 = "013";

                    SIKGUBUN4 = "000";
                    SIKJONG4 = "003";
                    JUSIK4 = "013";
                    BUSIK4 = "010";

                    SIKGUBUN5 = "000";
                    SIKJONG5 = "003";
                    JUSIK5 = "007";
                    BUSIK5 = "007";

                    break;

                case "2":

                    SIKGUBUN1 = "001";
                    SIKJONG1 = "013";
                    JUSIK1 = "015";
                    BUSIK1 = "013";

                    SIKGUBUN2 = "009";
                    SIKJONG2 = "035";
                    JUSIK2 = "049";
                    BUSIK2 = "026";

                    SIKGUBUN3 = "000";
                    SIKJONG3 = "003";
                    JUSIK3 = "014";
                    BUSIK3 = "013";

                    SIKGUBUN4 = "009";
                    SIKJONG4 = "035";
                    JUSIK4 = "049";
                    BUSIK4 = "026";

                    SIKGUBUN5 = "001";
                    SIKJONG5 = "011";
                    JUSIK5 = "011";
                    BUSIK5 = "011";
                    break;

               
            }

            rbtN1S1 = this.rbtN1S1;
            rbtN1S2 = this.rbtN1S2;
            rbtN1S3 = this.rbtN1S3;
            cbo_sN1 = this.cboSikjongN1;
            cbo_jN1 = this.cboJusikN1;
            cbo_bN1 = this.cboBusikN1;

            rbtN2S1 = this.rbtN2S1;
            rbtN2S2 = this.rbtN2S2;
            rbtN2S3 = this.rbtN2S3;
            cbo_sN2 = this.cboSikjongN2;
            cbo_jN2 = this.cboJusikN2;
            cbo_bN2 = this.cboBusikN2;

            rbtN3S1 = this.rbtN3S1;
            rbtN3S2 = this.rbtN3S2;
            rbtN3S3 = this.rbtN3S3;
            cbo_sN3 = this.cboSikjongN3;
            cbo_jN3 = this.cboJusikN3;
            cbo_bN3 = this.cboBusikN3;

            rbtN4S1 = this.rbtN4S1;
            rbtN4S2 = this.rbtN4S2;
            rbtN4S3 = this.rbtN4S3;
            cbo_sN4 = this.cboSikjongN4;
            cbo_jN4 = this.cboJusikN4;
            cbo_bN4 = this.cboBusikN4;

            rbtN5S1 = this.rbtN5S1;
            rbtN5S2 = this.rbtN5S2;
            rbtN5S3 = this.rbtN5S3;
            cbo_sN5 = this.cboSikjongN5;
            cbo_jN5 = this.cboJusikN5;
            cbo_bN5 = this.cboBusikN5;


            switch (SIKGUBUN1)
            {
                case "000": rbtN1S1.Checked = true; break;
                case "001": rbtN1S2.Checked = true; break;
                case "009": rbtN1S3.Checked = true; break;
            }
            cbo_sN1.SetDataValue(SIKJONG1);
            cbo_jN1.SetDataValue(JUSIK1);
            cbo_bN1.SetDataValue(BUSIK1);

            switch (SIKGUBUN2)
            {
                case "000": rbtN2S1.Checked = true; break;
                case "001": rbtN2S2.Checked = true; break;
                case "009": rbtN2S3.Checked = true; break;
            }
            cbo_sN2.SetDataValue(SIKJONG2);
            cbo_jN2.SetDataValue(JUSIK2);
            cbo_bN2.SetDataValue(BUSIK2);

            switch (SIKGUBUN3)
            {
                case "000": rbtN3S1.Checked = true; break;
                case "001": rbtN3S2.Checked = true; break;
                case "009": rbtN3S3.Checked = true; break;
            }
            cbo_sN3.SetDataValue(SIKJONG3);
            cbo_jN3.SetDataValue(JUSIK3);
            cbo_bN3.SetDataValue(BUSIK3);

            switch (SIKGUBUN4)
            {
                case "000": rbtN4S1.Checked = true; break;
                case "001": rbtN4S2.Checked = true; break;
                case "009": rbtN4S3.Checked = true; break;
            }
            cbo_sN4.SetDataValue(SIKJONG4);
            cbo_jN4.SetDataValue(JUSIK4);
            cbo_bN4.SetDataValue(BUSIK4);

            switch (SIKGUBUN5)
            {
                case "000": rbtN5S1.Checked = true; break;
                case "001": rbtN5S2.Checked = true; break;
                case "009": rbtN5S3.Checked = true; break;
            }
            cbo_sN5.SetDataValue(SIKJONG5);
            cbo_jN5.SetDataValue(JUSIK5);
            cbo_bN5.SetDataValue(BUSIK5);
        }

        private void timerGetMagamStatus_Tick(object sender, EventArgs e)
        {
            this.getMagamStatus();
        }

        private void dtpOrder_date_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.getMagamStatus();
        }
    }
}


