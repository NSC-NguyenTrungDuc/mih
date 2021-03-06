using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.OCSI;

namespace IHIS.OCSI
{
    public partial class AutoMaking : XForm
    {
        public AutoMaking()
        {
            InitializeComponent();
        }

        private const string SIKJIN1TH = "11";
        private const string SIKJIN2TH = "12";
        private const string SIKJIN3TH = "13";
        private const string SIKJIN4TH = "14";
        private const string SIKJIN5TH = "15";

        private string sik_gubun = "";

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

        private void AutoMaking_Load(object sender, EventArgs e)
        {
            this.setComboBox(SIKJIN1TH);
            this.setComboBox(SIKJIN2TH);
            this.setComboBox(SIKJIN3TH);
            this.setComboBox(SIKJIN4TH);
            this.setComboBox(SIKJIN5TH);
        }

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
            if (cbo_s != null)
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

        private void rbtSik_Gubun_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rbt = sender as XRadioButton;

            XComboBox cboN1 = new XComboBox();
            XComboBox cboN2 = new XComboBox();
            XComboBox cboN3 = new XComboBox();

            if (rbt.Checked == true)
            {
                switch (rbt.Tag.ToString())
                {
                    case "1":
                    case "2":
                    case "3":
                        
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
        }
    }
}