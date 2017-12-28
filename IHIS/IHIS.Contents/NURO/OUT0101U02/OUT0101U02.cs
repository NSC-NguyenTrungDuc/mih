#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.NURO;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.NURO;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
//using IHIS.CloudConnector.Messaging;
using IHIS.Framework;
using IHIS.NURO;
using IHIS.NURO.Properties;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector;
using NuroOUT0101U02GridBoheomInfo = IHIS.CloudConnector.Contracts.Models.Nuro.NuroOUT0101U02GridBoheomInfo;
using IHIS.CloudConnector.Contracts.Results;
using System.Security.Cryptography;
using System.Text;
using IHIS.CloudConnector.Utility;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using IHIS.CloudConnector.Socket;
using Microsoft.Win32;

#endregion

namespace IHIS.NURO
{
    /// <summary>
    /// OUT0101U02에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OUT0101U02 : IHIS.Framework.XScreen
    {
        #region Const & Fields

        /// <summary>
        /// BunhoInputType
        /// </summary>
        public enum BunhoInputType
        {
            AutoGen = 1,
            FreeInput = 2,
        }

        /// <summary>
        /// BunhoInputType
        /// </summary>
        private BunhoInputType _bunhoInputType = BunhoInputType.FreeInput;

        /// <summary>
        /// Patient code
        /// </summary>
        private string _bunho = string.Empty;

        #endregion

        #region 자동생성
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XInfoCombo cboSex;
        private IHIS.Framework.XLabel xLabel26;
        private IHIS.Framework.XDatePicker dtpBirth;
        private IHIS.Framework.XTextBox txtEMail;
        private IHIS.Framework.XTextBox txtTel1;
        private IHIS.Framework.XTextBox txtTel;
        private IHIS.Framework.XTextBox txtAddress2;
        private IHIS.Framework.XLabel xLabel21;
        private IHIS.Framework.XTextBox txtSuName2;
        private IHIS.Framework.XTextBox txtSuName;
        private IHIS.Framework.XLabel xLabel14;
        private IHIS.Framework.XLabel xLabel13;
        private IHIS.Framework.XLabel xLabel12;
        private IHIS.Framework.XLabel xLabel11;
        private IHIS.Framework.XLabel xLabel9;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XPanel pnlTLeft;
        private IHIS.Framework.XPanel pnlTop2;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XDatePicker dtpLast_Check_Date;
        private IHIS.Framework.XTextBox txtPiName;
        private IHIS.Framework.XTextBox txtGaein_No;
        private IHIS.Framework.XFindBox fbxJohap;
        private IHIS.Framework.XDatePicker dtpTo_Jy_Date;
        private IHIS.Framework.XDatePicker dtpFrom_Jy_Date;
        private IHIS.Framework.XLabel xLabel15;
        private IHIS.Framework.XLabel xLabel20;
        private IHIS.Framework.XLabel xLabel27;
        private IHIS.Framework.XLabel xLabel28;
        private IHIS.Framework.XLabel xLabel29;
        private IHIS.Framework.XLabel xLabel30;
        private IHIS.Framework.XLabel xLabel31;
        private IHIS.Framework.XLabel xLabel32;
        private IHIS.Framework.XLabel xLabel33;
        private IHIS.Framework.XLabel xLabel34;
        private IHIS.Framework.XPanel pnlT2Left;
        private IHIS.Framework.XPanel pnlT2Fill;
        private IHIS.Framework.XPanel pnlT2FillIn;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XLabel xLabel36;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel39;
        private IHIS.Framework.XLabel xLabel42;
        private IHIS.Framework.XLabel xLabel43;
        private IHIS.Framework.XLabel xLabel44;
        private IHIS.Framework.XLabel xLabel46;
        private IHIS.Framework.XLabel xLabel47;
        private IHIS.Framework.XEditGrid grdGongbiList;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XLabel xLabel38;
        private IHIS.Framework.XCheckBox cbxLast_Check;
        private IHIS.Framework.XFindBox fbxZip_Code1;
        private IHIS.Framework.XTextBox txtZip_Code2;
        private IHIS.Framework.XFindBox fbxGubun1;
        private IHIS.Framework.XEditGrid grdBoheom;
        private IHIS.Framework.XTextBox txtBudamja_Bunho;
        private IHIS.Framework.XDisplayBox dbxAge;
        private IHIS.Framework.XDisplayBox dbxGubun_Name1;
        private IHIS.Framework.XMemoBox mbxRemark;
        private IHIS.Framework.XDatePicker dtpLast_Check_Date2;
        private IHIS.Framework.XDisplayBox dbxGongbi_Name;
        private IHIS.Framework.XFindBox fbxGongbi_Code;
        private IHIS.Framework.XDatePicker dtpTo_Jy_Date2;
        private IHIS.Framework.XDatePicker dtpFrom_Jy_Date2;
        private IHIS.Framework.XTextBox txtTel_HP;
        private IHIS.Framework.XEditGrid grdPatient;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell46;
        private IHIS.Framework.XEditGridCell xEditGridCell47;
        private IHIS.Framework.XEditGridCell xEditGridCell50;
        private IHIS.Framework.XEditGridCell xEditGridCell53;
        private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
        private IHIS.Framework.XPanel pnlGongbi;
        private IHIS.Framework.XDisplayBox dbxJohap_Name;
        private IHIS.Framework.XCheckBox cbxLast_Check1;
        private IHIS.Framework.XFindBox fbxGaein;
        private IHIS.Framework.XTextBox txtSugubja_Bunho;
        private IHIS.Framework.XButton btnBAS0111U00;
        private IHIS.Framework.XTextBox txtJohap_gubun;
        private IHIS.Framework.XLabel xLabel52;
        private IHIS.Framework.XDictComboBox cboTel_Gubun;
        private IHIS.Framework.XDictComboBox cboTel_Gubun2;
        private IHIS.Framework.XDictComboBox cboTel_Gubun3;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XLabel xLabel53;
        private IHIS.Framework.XDictComboBox cboDelete_YN;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XPanel pnlRTop;
        private IHIS.Framework.XButton btnOUT0106U00;
        private IHIS.Framework.XEditGrid grdComment;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XDictComboBox cboBonin_Gubun;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XFindWorker fwkCommon;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XFindBox fbxAddress1;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XLabel xLabel35;
        private IHIS.Framework.XDatePicker dtpChuiduk_Date;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel18;
        private IHIS.Framework.XCheckBox cbxSelf_Pace_Maker;
        private IHIS.Framework.XCheckBox cbxPace_Maker_YN;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.MultiLayout layDupPatient;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
        private IHIS.Framework.MultiLayout layProtectGubunList;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
        private XEditGridCell xEditGridCell16;
        private XFindBox fbxBunho;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XLabel xLabel5;
        private XDictComboBox cboBunhoType;
        private XEditGridCell xEditGridCell38;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        private OUT0101U02ComboListResult comboListResult;
        private XButton genPatCodeBtn;
        private XEditGridCell xEditGridCell41;
        private XButton btnConfirm;
        private OUT0101U02GridViewResult gridViewResult;
        private XButton xButtonBAS0111U00;
        private XCheckBox cbxAutoOpen;
        private XLabel lblAutoOpen;
        DataTable tbl_PatientInfo;
        private XButton btnImport;
        private XButton btnExport;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XDictComboBox cbxBilling;
        private XLabel lblBilling;
        private XTextBox txtRefID;
        private XLabel xLabel10;
        private string rowState = "";
        private XButton btnUpdateInsur;
        private XLabel xLabel16;
        private XCheckBox cbxAutoRecept;
        private XEditGridCell xEditGridCell44;
        private static readonly string OUT0101U02_AUTO_OPEN = "OUT0101U02_AUTO_OPEN";

        // Remove unused field
        //private string pass;

        public OUT0101U02()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            this.genPatCodeBtn.Location = new Point(197,3);
            this.btnBAS0111U00.Location = new Point(180, 91);
            this.genPatCodeBtn.Width = 38;
            if (NetInfo.Language == LangMode.Vi)
            {
                this.genPatCodeBtn.Width = 65;
                fbxZip_Code1.Enabled = false;
                txtZip_Code2.Enabled = false;
                fbxAddress1.Enabled = false;
            }
            this.genPatCodeBtn.Height = 21;
            
            this.SaveLayoutList.Add(this.grdPatient);
            this.SaveLayoutList.Add(this.grdBoheom);
            this.SaveLayoutList.Add(this.grdGongbiList);
            this.grdPatient.SavePerformer = new XSavePerformer(this);
            this.grdBoheom.SavePerformer = new XSavePerformer(this);
            this.grdGongbiList.SavePerformer = new XSavePerformer(this);

            bool connOk = CloudService.Instance.Connect();
            if (connOk)
            {
                //Grid
                this.grdComment.ParamList = GridCommentParamList();
                this.grdComment.ExecuteQuery = GridCommentList;

                //Combobox
                
                this.comboListResult = GetComboListResult();
                this.cbxBilling.ExecuteQuery = ComboBillingType;
                this.cboBunhoType.ExecuteQuery = ComboBunhoType;
                this.cboTel_Gubun.ExecuteQuery = ComboTelGubun;
                this.cboTel_Gubun2.ExecuteQuery = ComboTelGubun2;
                this.cboTel_Gubun3.ExecuteQuery = ComboTelGubun3;
                this.cboBonin_Gubun.ExecuteQuery = ComboBoninGubun;
                this.cboSex.DataList = ComboSex();                
                
            }

            if (NetInfo.Language != LangMode.Jr)
            {
                this.dtpBirth.IsJapanYearType = false;
                this.dtpChuiduk_Date.IsJapanYearType = false;
                this.dtpLast_Check_Date.IsJapanYearType = false;
                this.dtpTo_Jy_Date.IsJapanYearType = false;
                this.dtpFrom_Jy_Date.IsJapanYearType = false;
                this.xEditGridCell1.IsJapanYearType = false;
                this.xEditGridCell11.IsJapanYearType = false;
                this.xEditGridCell12.IsJapanYearType = false;
                this.xEditGridCell86.IsJapanYearType = false;
                this.dtpFrom_Jy_Date2.IsJapanYearType = false;
                this.dtpTo_Jy_Date2.IsJapanYearType = false;
                this.dtpLast_Check_Date2.IsJapanYearType = false;

                //invisible name kana controls if language != Jr
                xLabel2.Visible = false;
                txtSuName2.Visible = false;
                txtSuName.Width = 413;
            }
            else {

                this.dtpBirth.IsJapanYearType = true;
                this.dtpChuiduk_Date.IsJapanYearType = true;
                this.dtpLast_Check_Date.IsJapanYearType = true;
                this.dtpTo_Jy_Date.IsJapanYearType = true;
                this.dtpFrom_Jy_Date.IsJapanYearType = true;
                this.xEditGridCell1.IsJapanYearType = true;
                this.xEditGridCell11.IsJapanYearType = true;
                this.xEditGridCell12.IsJapanYearType = true;
                this.xEditGridCell86.IsJapanYearType = true;
                this.dtpLast_Check_Date2.IsJapanYearType = true;
                this.dtpTo_Jy_Date2.IsJapanYearType = true;
                this.dtpFrom_Jy_Date2.IsJapanYearType = true;
                this.xEditGridCell18.IsJapanYearType = true;
                this.xEditGridCell23.IsJapanYearType = true;
            }

            this.btnConfirm.Image = Resources.user;
            cbxAutoOpen.CheckStateChanged += new EventHandler(cbxAutoOpen_CheckStateChanged);
            cbxAutoOpen.Checked = (bool)CacheService.Instance.Get(OUT0101U02_AUTO_OPEN, true);
        }

        void cbxAutoOpen_CheckStateChanged(object sender, EventArgs e)
        {
            CacheService.Instance.Set(OUT0101U02_AUTO_OPEN, cbxAutoOpen.Checked, TimeSpan.MaxValue);    
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT0101U02));
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnImport = new IHIS.Framework.XButton();
            this.btnExport = new IHIS.Framework.XButton();
            this.lblAutoOpen = new IHIS.Framework.XLabel();
            this.cbxAutoOpen = new IHIS.Framework.XCheckBox();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlRTop = new IHIS.Framework.XPanel();
            this.grdComment = new IHIS.Framework.XEditGrid();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.btnOUT0106U00 = new IHIS.Framework.XButton();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.pnlTLeft = new IHIS.Framework.XPanel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.cbxBilling = new IHIS.Framework.XDictComboBox();
            this.lblBilling = new IHIS.Framework.XLabel();
            this.txtRefID = new IHIS.Framework.XTextBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.genPatCodeBtn = new IHIS.Framework.XButton();
            this.cboBunhoType = new IHIS.Framework.XDictComboBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.grdPatient = new IHIS.Framework.XEditGrid();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.txtSuName = new IHIS.Framework.XTextBox();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.cboSex = new IHIS.Framework.XInfoCombo();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.dtpBirth = new IHIS.Framework.XDatePicker();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.fbxZip_Code1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.txtZip_Code2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.fbxAddress1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.txtAddress2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.txtTel = new IHIS.Framework.XTextBox();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.txtTel1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.txtTel_HP = new IHIS.Framework.XTextBox();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.txtEMail = new IHIS.Framework.XTextBox();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.txtSuName2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.dbxAge = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.cboTel_Gubun = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.cboTel_Gubun2 = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.cboTel_Gubun3 = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.cboDelete_YN = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.cbxPace_Maker_YN = new IHIS.Framework.XCheckBox();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.cbxSelf_Pace_Maker = new IHIS.Framework.XCheckBox();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel53 = new IHIS.Framework.XLabel();
            this.xLabel52 = new IHIS.Framework.XLabel();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.cbxAutoRecept = new IHIS.Framework.XCheckBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.pnlTop2 = new IHIS.Framework.XPanel();
            this.btnUpdateInsur = new IHIS.Framework.XButton();
            this.pnlT2Fill = new IHIS.Framework.XPanel();
            this.pnlT2FillIn = new IHIS.Framework.XPanel();
            this.xButtonBAS0111U00 = new IHIS.Framework.XButton();
            this.dtpChuiduk_Date = new IHIS.Framework.XDatePicker();
            this.xLabel35 = new IHIS.Framework.XLabel();
            this.cboBonin_Gubun = new IHIS.Framework.XDictComboBox();
            this.txtJohap_gubun = new IHIS.Framework.XTextBox();
            this.btnBAS0111U00 = new IHIS.Framework.XButton();
            this.fbxGaein = new IHIS.Framework.XFindBox();
            this.fbxGubun1 = new IHIS.Framework.XFindBox();
            this.dtpLast_Check_Date = new IHIS.Framework.XDatePicker();
            this.txtPiName = new IHIS.Framework.XTextBox();
            this.txtGaein_No = new IHIS.Framework.XTextBox();
            this.dbxJohap_Name = new IHIS.Framework.XDisplayBox();
            this.fbxJohap = new IHIS.Framework.XFindBox();
            this.dbxGubun_Name1 = new IHIS.Framework.XDisplayBox();
            this.dtpTo_Jy_Date = new IHIS.Framework.XDatePicker();
            this.dtpFrom_Jy_Date = new IHIS.Framework.XDatePicker();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.xLabel30 = new IHIS.Framework.XLabel();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.xLabel32 = new IHIS.Framework.XLabel();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.cbxLast_Check = new IHIS.Framework.XCheckBox();
            this.pnlT2Left = new IHIS.Framework.XPanel();
            this.grdBoheom = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xLabel34 = new IHIS.Framework.XLabel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.pnlGongbi = new IHIS.Framework.XPanel();
            this.mbxRemark = new IHIS.Framework.XMemoBox();
            this.xLabel38 = new IHIS.Framework.XLabel();
            this.dtpLast_Check_Date2 = new IHIS.Framework.XDatePicker();
            this.txtSugubja_Bunho = new IHIS.Framework.XTextBox();
            this.txtBudamja_Bunho = new IHIS.Framework.XTextBox();
            this.dbxGongbi_Name = new IHIS.Framework.XDisplayBox();
            this.fbxGongbi_Code = new IHIS.Framework.XFindBox();
            this.dtpTo_Jy_Date2 = new IHIS.Framework.XDatePicker();
            this.dtpFrom_Jy_Date2 = new IHIS.Framework.XDatePicker();
            this.xLabel39 = new IHIS.Framework.XLabel();
            this.xLabel42 = new IHIS.Framework.XLabel();
            this.xLabel43 = new IHIS.Framework.XLabel();
            this.xLabel44 = new IHIS.Framework.XLabel();
            this.xLabel46 = new IHIS.Framework.XLabel();
            this.xLabel47 = new IHIS.Framework.XLabel();
            this.cbxLast_Check1 = new IHIS.Framework.XCheckBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdGongbiList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.layDupPatient = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.layProtectGubunList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlRTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).BeginInit();
            this.pnlTLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSex)).BeginInit();
            this.pnlTop2.SuspendLayout();
            this.pnlT2Fill.SuspendLayout();
            this.pnlT2FillIn.SuspendLayout();
            this.pnlT2Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBoheom)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.pnlGongbi.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGongbiList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDupPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layProtectGubunList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellLen = 9;
            this.xEditGridCell27.CellName = "bunho";
            this.xEditGridCell27.CellWidth = 79;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsNotNull = true;
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnImport);
            this.xPanel3.Controls.Add(this.btnExport);
            this.xPanel3.Controls.Add(this.lblAutoOpen);
            this.xPanel3.Controls.Add(this.cbxAutoOpen);
            this.xPanel3.Controls.Add(this.btnConfirm);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnImport
            // 
            this.btnImport.AccessibleDescription = null;
            this.btnImport.AccessibleName = null;
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.BackgroundImage = null;
            this.btnImport.Name = "btnImport";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.AccessibleDescription = null;
            this.btnExport.AccessibleName = null;
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.BackgroundImage = null;
            this.btnExport.Name = "btnExport";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblAutoOpen
            // 
            this.lblAutoOpen.AccessibleDescription = null;
            this.lblAutoOpen.AccessibleName = null;
            resources.ApplyResources(this.lblAutoOpen, "lblAutoOpen");
            this.lblAutoOpen.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblAutoOpen.EdgeRounding = false;
            this.lblAutoOpen.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblAutoOpen.Image = null;
            this.lblAutoOpen.Name = "lblAutoOpen";
            // 
            // cbxAutoOpen
            // 
            this.cbxAutoOpen.AccessibleDescription = null;
            this.cbxAutoOpen.AccessibleName = null;
            resources.ApplyResources(this.cbxAutoOpen, "cbxAutoOpen");
            this.cbxAutoOpen.BackgroundImage = null;
            this.cbxAutoOpen.Name = "cbxAutoOpen";
            this.cbxAutoOpen.UseVisualStyleBackColor = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleDescription = null;
            this.btnConfirm.AccessibleName = null;
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.BackgroundImage = null;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.pnlRTop);
            this.pnlTop.Controls.Add(this.pnlTLeft);
            this.pnlTop.Controls.Add(this.xLabel3);
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // pnlRTop
            // 
            this.pnlRTop.AccessibleDescription = null;
            this.pnlRTop.AccessibleName = null;
            resources.ApplyResources(this.pnlRTop, "pnlRTop");
            this.pnlRTop.BackgroundImage = null;
            this.pnlRTop.Controls.Add(this.grdComment);
            this.pnlRTop.Controls.Add(this.btnOUT0106U00);
            this.pnlRTop.Controls.Add(this.xLabel8);
            this.pnlRTop.Font = null;
            this.pnlRTop.Name = "pnlRTop";
            // 
            // grdComment
            // 
            resources.ApplyResources(this.grdComment, "grdComment");
            this.grdComment.ApplyAutoHeight = true;
            this.grdComment.CallerID = '4';
            this.grdComment.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell72,
            this.xEditGridCell71,
            this.xEditGridCell73});
            this.grdComment.ColPerLine = 1;
            this.grdComment.ColResizable = true;
            this.grdComment.Cols = 2;
            this.grdComment.ExecuteQuery = null;
            this.grdComment.FixedCols = 1;
            this.grdComment.FixedRows = 1;
            this.grdComment.HeaderHeights.Add(0);
            this.grdComment.Name = "grdComment";
            this.grdComment.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdComment.ParamList")));
            this.grdComment.ReadOnly = true;
            this.grdComment.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdComment.RowHeaderVisible = true;
            this.grdComment.Rows = 2;
            this.grdComment.ToolTipActive = true;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "ser";
            this.xEditGridCell72.CellWidth = 31;
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            this.xEditGridCell72.HeaderText = global::IHIS.NURO.Properties.Resources.SER_TEXT;
            this.xEditGridCell72.IsReadOnly = true;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellLen = 80;
            this.xEditGridCell71.CellName = "comment";
            this.xEditGridCell71.CellWidth = 368;
            this.xEditGridCell71.Col = 1;
            this.xEditGridCell71.DisplayMemoText = true;
            this.xEditGridCell71.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell71.ExecuteQuery = null;
            this.xEditGridCell71.HeaderText = global::IHIS.NURO.Properties.Resources.COMMENT_TEXT;
            this.xEditGridCell71.IsReadOnly = true;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "bunho";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            this.xEditGridCell73.HeaderText = global::IHIS.NURO.Properties.Resources.BUNHO_TEXT;
            this.xEditGridCell73.IsReadOnly = true;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // btnOUT0106U00
            // 
            this.btnOUT0106U00.AccessibleDescription = null;
            this.btnOUT0106U00.AccessibleName = null;
            resources.ApplyResources(this.btnOUT0106U00, "btnOUT0106U00");
            this.btnOUT0106U00.BackgroundImage = null;
            this.btnOUT0106U00.ImageIndex = 3;
            this.btnOUT0106U00.ImageList = this.ImageList;
            this.btnOUT0106U00.Name = "btnOUT0106U00";
            this.btnOUT0106U00.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnOUT0106U00.Click += new System.EventHandler(this.btnOUT0106U00_Click);
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // pnlTLeft
            // 
            this.pnlTLeft.AccessibleDescription = null;
            this.pnlTLeft.AccessibleName = null;
            resources.ApplyResources(this.pnlTLeft, "pnlTLeft");
            this.pnlTLeft.BackgroundImage = null;
            this.pnlTLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTLeft.Controls.Add(this.xLabel16);
            this.pnlTLeft.Controls.Add(this.cbxBilling);
            this.pnlTLeft.Controls.Add(this.lblBilling);
            this.pnlTLeft.Controls.Add(this.txtRefID);
            this.pnlTLeft.Controls.Add(this.xLabel10);
            this.pnlTLeft.Controls.Add(this.genPatCodeBtn);
            this.pnlTLeft.Controls.Add(this.cboBunhoType);
            this.pnlTLeft.Controls.Add(this.xLabel5);
            this.pnlTLeft.Controls.Add(this.fbxBunho);
            this.pnlTLeft.Controls.Add(this.grdPatient);
            this.pnlTLeft.Controls.Add(this.xLabel18);
            this.pnlTLeft.Controls.Add(this.xLabel4);
            this.pnlTLeft.Controls.Add(this.cbxSelf_Pace_Maker);
            this.pnlTLeft.Controls.Add(this.cbxPace_Maker_YN);
            this.pnlTLeft.Controls.Add(this.cboDelete_YN);
            this.pnlTLeft.Controls.Add(this.fbxAddress1);
            this.pnlTLeft.Controls.Add(this.xLabel53);
            this.pnlTLeft.Controls.Add(this.cboTel_Gubun3);
            this.pnlTLeft.Controls.Add(this.cboTel_Gubun2);
            this.pnlTLeft.Controls.Add(this.cboTel_Gubun);
            this.pnlTLeft.Controls.Add(this.xLabel52);
            this.pnlTLeft.Controls.Add(this.dbxAge);
            this.pnlTLeft.Controls.Add(this.fbxZip_Code1);
            this.pnlTLeft.Controls.Add(this.txtTel_HP);
            this.pnlTLeft.Controls.Add(this.txtTel1);
            this.pnlTLeft.Controls.Add(this.txtTel);
            this.pnlTLeft.Controls.Add(this.txtAddress2);
            this.pnlTLeft.Controls.Add(this.xLabel21);
            this.pnlTLeft.Controls.Add(this.txtZip_Code2);
            this.pnlTLeft.Controls.Add(this.txtSuName2);
            this.pnlTLeft.Controls.Add(this.txtSuName);
            this.pnlTLeft.Controls.Add(this.xLabel9);
            this.pnlTLeft.Controls.Add(this.xLabel12);
            this.pnlTLeft.Controls.Add(this.xLabel7);
            this.pnlTLeft.Controls.Add(this.xLabel6);
            this.pnlTLeft.Controls.Add(this.xLabel13);
            this.pnlTLeft.Controls.Add(this.xLabel1);
            this.pnlTLeft.Controls.Add(this.xLabel11);
            this.pnlTLeft.Controls.Add(this.cboSex);
            this.pnlTLeft.Controls.Add(this.xLabel26);
            this.pnlTLeft.Controls.Add(this.dtpBirth);
            this.pnlTLeft.Controls.Add(this.xLabel2);
            this.pnlTLeft.Controls.Add(this.xLabel14);
            this.pnlTLeft.Controls.Add(this.txtEMail);
            this.pnlTLeft.Controls.Add(this.cbxAutoRecept);
            this.pnlTLeft.Font = null;
            this.pnlTLeft.Name = "pnlTLeft";
            // 
            // xLabel16
            // 
            this.xLabel16.AccessibleDescription = null;
            this.xLabel16.AccessibleName = null;
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel16.Image = null;
            this.xLabel16.Name = "xLabel16";
            // 
            // cbxBilling
            // 
            this.cbxBilling.AccessibleDescription = null;
            this.cbxBilling.AccessibleName = null;
            resources.ApplyResources(this.cbxBilling, "cbxBilling");
            this.cbxBilling.BackgroundImage = null;
            this.cbxBilling.ExecuteQuery = null;
            this.cbxBilling.Name = "cbxBilling";
            this.cbxBilling.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxBilling.ParamList")));
            this.cbxBilling.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // lblBilling
            // 
            this.lblBilling.AccessibleDescription = null;
            this.lblBilling.AccessibleName = null;
            resources.ApplyResources(this.lblBilling, "lblBilling");
            this.lblBilling.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBilling.EdgeRounding = false;
            this.lblBilling.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBilling.Image = null;
            this.lblBilling.Name = "lblBilling";
            // 
            // txtRefID
            // 
            this.txtRefID.AccessibleDescription = null;
            this.txtRefID.AccessibleName = null;
            resources.ApplyResources(this.txtRefID, "txtRefID");
            this.txtRefID.BackgroundImage = null;
            this.txtRefID.Name = "txtRefID";
            // 
            // xLabel10
            // 
            this.xLabel10.AccessibleDescription = null;
            this.xLabel10.AccessibleName = null;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel10.Image = null;
            this.xLabel10.Name = "xLabel10";
            // 
            // genPatCodeBtn
            // 
            this.genPatCodeBtn.AccessibleDescription = null;
            this.genPatCodeBtn.AccessibleName = null;
            resources.ApplyResources(this.genPatCodeBtn, "genPatCodeBtn");
            this.genPatCodeBtn.BackgroundImage = null;
            this.genPatCodeBtn.ImageIndex = 3;
            this.genPatCodeBtn.ImageList = this.ImageList;
            this.genPatCodeBtn.Name = "genPatCodeBtn";
            this.genPatCodeBtn.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.genPatCodeBtn.Click += new System.EventHandler(this.genPatCodeBtn_Click);
            // 
            // cboBunhoType
            // 
            this.cboBunhoType.AccessibleDescription = null;
            this.cboBunhoType.AccessibleName = null;
            resources.ApplyResources(this.cboBunhoType, "cboBunhoType");
            this.cboBunhoType.BackgroundImage = null;
            this.cboBunhoType.ExecuteQuery = null;
            this.cboBunhoType.Name = "cboBunhoType";
            this.cboBunhoType.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboBunhoType.ParamList")));
            this.cboBunhoType.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // fbxBunho
            // 
            this.fbxBunho.AccessibleDescription = null;
            this.fbxBunho.AccessibleName = null;
            resources.ApplyResources(this.fbxBunho, "fbxBunho");
            this.fbxBunho.BackgroundImage = null;
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxBunho.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunho_FindClick);
            // 
            // grdPatient
            // 
            resources.ApplyResources(this.grdPatient, "grdPatient");
            this.grdPatient.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell50,
            this.xEditGridCell53,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell59,
            this.xEditGridCell80,
            this.xEditGridCell38,
            this.xEditGridCell75,
            this.xEditGridCell41,
            this.xEditGridCell87,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44});
            this.grdPatient.ColPerLine = 29;
            this.grdPatient.Cols = 29;
            this.grdPatient.ControlBinding = true;
            this.grdPatient.ExecuteQuery = null;
            this.grdPatient.FixedRows = 1;
            this.grdPatient.HeaderHeights.Add(18);
            this.grdPatient.Name = "grdPatient";
            this.grdPatient.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatient.ParamList")));
            this.grdPatient.QuerySQL = resources.GetString("grdPatient.QuerySQL");
            this.grdPatient.ReadOnly = true;
            this.grdPatient.Rows = 2;
            this.grdPatient.ToolTipActive = true;
            this.grdPatient.UseDefaultTransaction = false;
            this.grdPatient.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPatient_RowFocusChanged);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.BindControl = this.txtSuName;
            this.xEditGridCell28.CellLen = 30;
            this.xEditGridCell28.CellName = "suname";
            this.xEditGridCell28.Col = 1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsNotNull = true;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtSuName
            // 
            this.txtSuName.AccessibleDescription = null;
            this.txtSuName.AccessibleName = null;
            resources.ApplyResources(this.txtSuName, "txtSuName");
            this.txtSuName.BackgroundImage = null;
            this.txtSuName.Name = "txtSuName";
            this.txtSuName.CompositionCompleted += new IHIS.Framework.CompositionEventHandler(this.txtSuName_CompositionCompleted);
            this.txtSuName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSuName_DataValidating);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.BindControl = this.cboSex;
            this.xEditGridCell29.CellLen = 1;
            this.xEditGridCell29.CellName = "sex";
            this.xEditGridCell29.Col = 2;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.HeaderText = global::IHIS.NURO.Properties.Resources.SEX_TEXT;
            this.xEditGridCell29.IsNotNull = true;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboSex
            // 
            this.cboSex.AccessibleDescription = null;
            this.cboSex.AccessibleName = null;
            resources.ApplyResources(this.cboSex, "cboSex");
            this.cboSex.BackgroundImage = null;
            this.cboSex.CodeType = "SEX_GUBUN";
            this.cboSex.DataList = null;
            this.cboSex.Name = "cboSex";
            this.cboSex.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboSex_DataValidating);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.BindControl = this.dtpBirth;
            this.xEditGridCell30.CellName = "birth";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell30.Col = 3;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.HeaderText = global::IHIS.NURO.Properties.Resources.BIRTH_TEXT;
            this.xEditGridCell30.IsNotNull = true;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dtpBirth
            // 
            this.dtpBirth.AccessibleDescription = null;
            this.dtpBirth.AccessibleName = null;
            resources.ApplyResources(this.dtpBirth, "dtpBirth");
            this.dtpBirth.BackgroundImage = null;
            this.dtpBirth.IsVietnameseYearType = false;
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Enter += new System.EventHandler(this.dtpBirth_Enter);
            this.dtpBirth.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpBirth_DataValidating);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.BindControl = this.fbxZip_Code1;
            this.xEditGridCell31.CellLen = 3;
            this.xEditGridCell31.CellName = "zip_code1";
            this.xEditGridCell31.Col = 4;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.HeaderText = global::IHIS.NURO.Properties.Resources.ZIP_CODE1_TEXT;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxZip_Code1
            // 
            this.fbxZip_Code1.AccessibleDescription = null;
            this.fbxZip_Code1.AccessibleName = null;
            resources.ApplyResources(this.fbxZip_Code1, "fbxZip_Code1");
            this.fbxZip_Code1.AutoTabAtMaxLength = true;
            this.fbxZip_Code1.AutoTabDataSelected = true;
            this.fbxZip_Code1.BackgroundImage = null;
            this.fbxZip_Code1.Name = "fbxZip_Code1";
            this.fbxZip_Code1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxZipCode_FindClick);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.BindControl = this.txtZip_Code2;
            this.xEditGridCell32.CellLen = 4;
            this.xEditGridCell32.CellName = "zip_code2";
            this.xEditGridCell32.Col = 5;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.HeaderText = global::IHIS.NURO.Properties.Resources.ZIP_CODE2_TEXT;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtZip_Code2
            // 
            this.txtZip_Code2.AccessibleDescription = null;
            this.txtZip_Code2.AccessibleName = null;
            resources.ApplyResources(this.txtZip_Code2, "txtZip_Code2");
            this.txtZip_Code2.AutoTabAtMaxLength = true;
            this.txtZip_Code2.BackgroundImage = null;
            this.txtZip_Code2.Name = "txtZip_Code2";
            this.txtZip_Code2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtZip_Code2_DataValidating);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.BindControl = this.fbxAddress1;
            this.xEditGridCell33.CellLen = 100;
            this.xEditGridCell33.CellName = "address1";
            this.xEditGridCell33.Col = 6;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.HeaderText = global::IHIS.NURO.Properties.Resources.ADDRESS1_TEXT;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxAddress1
            // 
            this.fbxAddress1.AccessibleDescription = null;
            this.fbxAddress1.AccessibleName = null;
            resources.ApplyResources(this.fbxAddress1, "fbxAddress1");
            this.fbxAddress1.BackgroundImage = null;
            this.fbxAddress1.Name = "fbxAddress1";
            this.fbxAddress1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxAddress_FindClick);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell34.BindControl = this.txtAddress2;
            this.xEditGridCell34.CellLen = 100;
            this.xEditGridCell34.CellName = "address2";
            this.xEditGridCell34.Col = 7;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell34.HeaderText = global::IHIS.NURO.Properties.Resources.ADDRESS2_TEXT;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtAddress2
            // 
            this.txtAddress2.AccessibleDescription = null;
            this.txtAddress2.AccessibleName = null;
            resources.ApplyResources(this.txtAddress2, "txtAddress2");
            this.txtAddress2.AutoTabAtMaxLength = true;
            this.txtAddress2.BackgroundImage = null;
            this.txtAddress2.Name = "txtAddress2";
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.BindControl = this.txtTel;
            this.xEditGridCell35.CellLen = 15;
            this.xEditGridCell35.CellName = "tel";
            this.xEditGridCell35.Col = 8;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.HeaderText = global::IHIS.NURO.Properties.Resources.TEL_TEXT;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtTel
            // 
            this.txtTel.AccessibleDescription = null;
            this.txtTel.AccessibleName = null;
            resources.ApplyResources(this.txtTel, "txtTel");
            this.txtTel.AutoTabAtMaxLength = true;
            this.txtTel.BackgroundImage = null;
            this.txtTel.Name = "txtTel";
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.BindControl = this.txtTel1;
            this.xEditGridCell36.CellLen = 15;
            this.xEditGridCell36.CellName = "tel1";
            this.xEditGridCell36.Col = 9;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.HeaderText = global::IHIS.NURO.Properties.Resources.TEL1_TEXT;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtTel1
            // 
            this.txtTel1.AccessibleDescription = null;
            this.txtTel1.AccessibleName = null;
            resources.ApplyResources(this.txtTel1, "txtTel1");
            this.txtTel1.AutoTabAtMaxLength = true;
            this.txtTel1.BackgroundImage = null;
            this.txtTel1.Name = "txtTel1";
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.CellLen = 2;
            this.xEditGridCell37.CellName = "gubun";
            this.xEditGridCell37.Col = 10;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.HeaderText = global::IHIS.NURO.Properties.Resources.GUBUN_TEXT;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell46.BindControl = this.txtTel_HP;
            this.xEditGridCell46.CellLen = 15;
            this.xEditGridCell46.CellName = "tel_hp";
            this.xEditGridCell46.Col = 19;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell46.HeaderText = global::IHIS.NURO.Properties.Resources.TEL_HP_TEXT;
            this.xEditGridCell46.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtTel_HP
            // 
            this.txtTel_HP.AccessibleDescription = null;
            this.txtTel_HP.AccessibleName = null;
            resources.ApplyResources(this.txtTel_HP, "txtTel_HP");
            this.txtTel_HP.AutoTabAtMaxLength = true;
            this.txtTel_HP.BackgroundImage = null;
            this.txtTel_HP.Name = "txtTel_HP";
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.BindControl = this.txtEMail;
            this.xEditGridCell47.CellLen = 40;
            this.xEditGridCell47.CellName = "email";
            this.xEditGridCell47.Col = 20;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.HeaderText = global::IHIS.NURO.Properties.Resources.EMAIL_TEXT;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtEMail
            // 
            this.txtEMail.AccessibleDescription = null;
            this.txtEMail.AccessibleName = null;
            resources.ApplyResources(this.txtEMail, "txtEMail");
            this.txtEMail.AutoTabAtMaxLength = true;
            this.txtEMail.BackgroundImage = null;
            this.txtEMail.Name = "txtEMail";
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.CellName = "gubun_name";
            this.xEditGridCell50.Col = 23;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.HeaderText = global::IHIS.NURO.Properties.Resources.GUBUN_NAME_TEXT;
            this.xEditGridCell50.IsUpdCol = false;
            this.xEditGridCell50.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell53.CellName = "dong_name";
            this.xEditGridCell53.Col = 11;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell53.HeaderText = global::IHIS.NURO.Properties.Resources.DONG_NAME_TEXT;
            this.xEditGridCell53.IsUpdCol = false;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell55.BindControl = this.txtSuName2;
            this.xEditGridCell55.CellLen = 30;
            this.xEditGridCell55.CellName = "suname2";
            this.xEditGridCell55.Col = 12;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell55.HeaderText = global::IHIS.NURO.Properties.Resources.SU_NAME2_TEXT;
            this.xEditGridCell55.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtSuName2
            // 
            this.txtSuName2.AccessibleDescription = null;
            this.txtSuName2.AccessibleName = null;
            resources.ApplyResources(this.txtSuName2, "txtSuName2");
            this.txtSuName2.BackgroundImage = null;
            this.txtSuName2.Name = "txtSuName2";
            this.txtSuName2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSuName2_DataValidating);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell56.BindControl = this.dbxAge;
            this.xEditGridCell56.CellName = "age";
            this.xEditGridCell56.Col = 13;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell56.HeaderText = global::IHIS.NURO.Properties.Resources.AGE_TEXT;
            this.xEditGridCell56.IsUpdCol = false;
            this.xEditGridCell56.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxAge
            // 
            this.dbxAge.AccessibleDescription = null;
            this.dbxAge.AccessibleName = null;
            resources.ApplyResources(this.dbxAge, "dbxAge");
            this.dbxAge.Image = null;
            this.dbxAge.Name = "dbxAge";
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell67.BindControl = this.cboTel_Gubun;
            this.xEditGridCell67.CellLen = 1;
            this.xEditGridCell67.CellName = "tel_gubun";
            this.xEditGridCell67.Col = 14;
            this.xEditGridCell67.ExecuteQuery = null;
            this.xEditGridCell67.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell67.HeaderText = global::IHIS.NURO.Properties.Resources.TEL_GUBUN_TEXT;
            this.xEditGridCell67.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboTel_Gubun
            // 
            this.cboTel_Gubun.AccessibleDescription = null;
            this.cboTel_Gubun.AccessibleName = null;
            resources.ApplyResources(this.cboTel_Gubun, "cboTel_Gubun");
            this.cboTel_Gubun.BackgroundImage = null;
            this.cboTel_Gubun.ExecuteQuery = null;
            this.cboTel_Gubun.Name = "cboTel_Gubun";
            this.cboTel_Gubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTel_Gubun.ParamList")));
            this.cboTel_Gubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell68.BindControl = this.cboTel_Gubun2;
            this.xEditGridCell68.CellLen = 1;
            this.xEditGridCell68.CellName = "tel_gubun2";
            this.xEditGridCell68.Col = 15;
            this.xEditGridCell68.ExecuteQuery = null;
            this.xEditGridCell68.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell68.HeaderText = global::IHIS.NURO.Properties.Resources.TEL_GUBUN2_TEXT;
            this.xEditGridCell68.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboTel_Gubun2
            // 
            this.cboTel_Gubun2.AccessibleDescription = null;
            this.cboTel_Gubun2.AccessibleName = null;
            resources.ApplyResources(this.cboTel_Gubun2, "cboTel_Gubun2");
            this.cboTel_Gubun2.BackgroundImage = null;
            this.cboTel_Gubun2.ExecuteQuery = null;
            this.cboTel_Gubun2.Name = "cboTel_Gubun2";
            this.cboTel_Gubun2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTel_Gubun2.ParamList")));
            this.cboTel_Gubun2.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell69.BindControl = this.cboTel_Gubun3;
            this.xEditGridCell69.CellLen = 1;
            this.xEditGridCell69.CellName = "tel_gubun3";
            this.xEditGridCell69.Col = 16;
            this.xEditGridCell69.ExecuteQuery = null;
            this.xEditGridCell69.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell69.HeaderText = global::IHIS.NURO.Properties.Resources.TEL_GUBUN3_TEXT;
            this.xEditGridCell69.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboTel_Gubun3
            // 
            this.cboTel_Gubun3.AccessibleDescription = null;
            this.cboTel_Gubun3.AccessibleName = null;
            resources.ApplyResources(this.cboTel_Gubun3, "cboTel_Gubun3");
            this.cboTel_Gubun3.BackgroundImage = null;
            this.cboTel_Gubun3.ExecuteQuery = null;
            this.cboTel_Gubun3.Name = "cboTel_Gubun3";
            this.cboTel_Gubun3.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTel_Gubun3.ParamList")));
            this.cboTel_Gubun3.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell70.BindControl = this.cboDelete_YN;
            this.xEditGridCell70.CellLen = 1;
            this.xEditGridCell70.CellName = "delete_yn";
            this.xEditGridCell70.Col = 17;
            this.xEditGridCell70.ExecuteQuery = null;
            this.xEditGridCell70.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell70.HeaderText = global::IHIS.NURO.Properties.Resources.DELETE_YN_TEXT;
            this.xEditGridCell70.InitValue = "N";
            this.xEditGridCell70.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboDelete_YN
            // 
            this.cboDelete_YN.AccessibleDescription = null;
            this.cboDelete_YN.AccessibleName = null;
            resources.ApplyResources(this.cboDelete_YN, "cboDelete_YN");
            this.cboDelete_YN.BackgroundImage = null;
            this.cboDelete_YN.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboDelete_YN.ExecuteQuery = null;
            this.cboDelete_YN.Name = "cboDelete_YN";
            this.cboDelete_YN.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDelete_YN.ParamList")));
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = global::IHIS.NURO.Properties.Resources.YES_CBO_TEXT;
            this.xComboItem1.ValueItem = "Y";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = global::IHIS.NURO.Properties.Resources.NO_CBO_TEXT;
            this.xComboItem2.ValueItem = "N";
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell59.BindControl = this.cbxPace_Maker_YN;
            this.xEditGridCell59.CellName = "pace_maker_yn";
            this.xEditGridCell59.Col = 18;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell59.HeaderText = global::IHIS.NURO.Properties.Resources.PACE_MAKER_YN_TEXT;
            this.xEditGridCell59.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cbxPace_Maker_YN
            // 
            this.cbxPace_Maker_YN.AccessibleDescription = null;
            this.cbxPace_Maker_YN.AccessibleName = null;
            resources.ApplyResources(this.cbxPace_Maker_YN, "cbxPace_Maker_YN");
            this.cbxPace_Maker_YN.BackgroundImage = null;
            this.cbxPace_Maker_YN.Name = "cbxPace_Maker_YN";
            this.cbxPace_Maker_YN.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell80.BindControl = this.cbxSelf_Pace_Maker;
            this.xEditGridCell80.CellName = "self_pace_maker";
            this.xEditGridCell80.Col = 21;
            this.xEditGridCell80.ExecuteQuery = null;
            this.xEditGridCell80.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell80.HeaderText = global::IHIS.NURO.Properties.Resources.SELF_PACE_MAKER_TEXT;
            this.xEditGridCell80.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cbxSelf_Pace_Maker
            // 
            this.cbxSelf_Pace_Maker.AccessibleDescription = null;
            this.cbxSelf_Pace_Maker.AccessibleName = null;
            resources.ApplyResources(this.cbxSelf_Pace_Maker, "cbxSelf_Pace_Maker");
            this.cbxSelf_Pace_Maker.BackgroundImage = null;
            this.cbxSelf_Pace_Maker.Name = "cbxSelf_Pace_Maker";
            this.cbxSelf_Pace_Maker.UseVisualStyleBackColor = false;
            this.cbxSelf_Pace_Maker.CheckedChanged += new System.EventHandler(this.cbxSelf_Pace_Maker_CheckedChanged);
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.BindControl = this.cboBunhoType;
            this.xEditGridCell38.CellName = "bunho_type";
            this.xEditGridCell38.Col = 25;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.HeaderText = global::IHIS.NURO.Properties.Resources.BUNHO_TYPE_TEXT;
            this.xEditGridCell38.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell75.CellName = "retrieve_yn";
            this.xEditGridCell75.Col = 22;
            this.xEditGridCell75.ExecuteQuery = null;
            this.xEditGridCell75.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell75.HeaderText = global::IHIS.NURO.Properties.Resources.RETRIEVE_YN_TEXT;
            this.xEditGridCell75.IsUpdCol = false;
            this.xEditGridCell75.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell41.CellName = "ref_id";
            this.xEditGridCell41.Col = 26;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell87.CellName = "iu_gubun";
            this.xEditGridCell87.Col = 24;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell87.HeaderText = global::IHIS.NURO.Properties.Resources.IU_GUBUN_TEXT;
            this.xEditGridCell87.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.BindControl = this.cbxBilling;
            this.xEditGridCell42.CellName = "billing_name";
            this.xEditGridCell42.Col = 27;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell43.CellName = "billing_code";
            this.xEditGridCell43.Col = 28;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell44.BindControl = this.cbxAutoRecept;
            this.xEditGridCell44.CellName = "auto_recept";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            this.xEditGridCell44.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xLabel18
            // 
            this.xLabel18.AccessibleDescription = null;
            this.xLabel18.AccessibleName = null;
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel18.Image = null;
            this.xLabel18.Name = "xLabel18";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel53
            // 
            this.xLabel53.AccessibleDescription = null;
            this.xLabel53.AccessibleName = null;
            resources.ApplyResources(this.xLabel53, "xLabel53");
            this.xLabel53.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel53.EdgeRounding = false;
            this.xLabel53.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel53.Image = null;
            this.xLabel53.Name = "xLabel53";
            // 
            // xLabel52
            // 
            this.xLabel52.AccessibleDescription = null;
            this.xLabel52.AccessibleName = null;
            resources.ApplyResources(this.xLabel52, "xLabel52");
            this.xLabel52.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel52.EdgeRounding = false;
            this.xLabel52.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel52.Image = null;
            this.xLabel52.Name = "xLabel52";
            // 
            // xLabel21
            // 
            this.xLabel21.AccessibleDescription = null;
            this.xLabel21.AccessibleName = null;
            resources.ApplyResources(this.xLabel21, "xLabel21");
            this.xLabel21.EdgeRounding = false;
            this.xLabel21.Image = null;
            this.xLabel21.Name = "xLabel21";
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel26
            // 
            this.xLabel26.AccessibleDescription = null;
            this.xLabel26.AccessibleName = null;
            resources.ApplyResources(this.xLabel26, "xLabel26");
            this.xLabel26.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel26.EdgeRounding = false;
            this.xLabel26.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel26.Image = null;
            this.xLabel26.Name = "xLabel26";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            // 
            // cbxAutoRecept
            // 
            this.cbxAutoRecept.AccessibleDescription = null;
            this.cbxAutoRecept.AccessibleName = null;
            resources.ApplyResources(this.cbxAutoRecept, "cbxAutoRecept");
            this.cbxAutoRecept.BackgroundImage = null;
            this.cbxAutoRecept.Name = "cbxAutoRecept";
            this.cbxAutoRecept.UseVisualStyleBackColor = false;
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XGridRowHeaderBackColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // fwkCommon
            // 
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // pnlTop2
            // 
            this.pnlTop2.AccessibleDescription = null;
            this.pnlTop2.AccessibleName = null;
            resources.ApplyResources(this.pnlTop2, "pnlTop2");
            this.pnlTop2.BackgroundImage = null;
            this.pnlTop2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop2.Controls.Add(this.btnUpdateInsur);
            this.pnlTop2.Controls.Add(this.pnlT2Fill);
            this.pnlTop2.Controls.Add(this.pnlT2Left);
            this.pnlTop2.Controls.Add(this.xLabel34);
            this.pnlTop2.Font = null;
            this.pnlTop2.Name = "pnlTop2";
            // 
            // btnUpdateInsur
            // 
            this.btnUpdateInsur.AccessibleDescription = null;
            this.btnUpdateInsur.AccessibleName = null;
            resources.ApplyResources(this.btnUpdateInsur, "btnUpdateInsur");
            this.btnUpdateInsur.BackgroundImage = null;
            this.btnUpdateInsur.Name = "btnUpdateInsur";
            this.btnUpdateInsur.Click += new System.EventHandler(this.btnUpdateInsur_Click);
            // 
            // pnlT2Fill
            // 
            this.pnlT2Fill.AccessibleDescription = null;
            this.pnlT2Fill.AccessibleName = null;
            resources.ApplyResources(this.pnlT2Fill, "pnlT2Fill");
            this.pnlT2Fill.BackgroundImage = null;
            this.pnlT2Fill.Controls.Add(this.pnlT2FillIn);
            this.pnlT2Fill.Font = null;
            this.pnlT2Fill.Name = "pnlT2Fill";
            // 
            // pnlT2FillIn
            // 
            this.pnlT2FillIn.AccessibleDescription = null;
            this.pnlT2FillIn.AccessibleName = null;
            resources.ApplyResources(this.pnlT2FillIn, "pnlT2FillIn");
            this.pnlT2FillIn.BackgroundImage = null;
            this.pnlT2FillIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlT2FillIn.Controls.Add(this.xButtonBAS0111U00);
            this.pnlT2FillIn.Controls.Add(this.dtpChuiduk_Date);
            this.pnlT2FillIn.Controls.Add(this.xLabel35);
            this.pnlT2FillIn.Controls.Add(this.cboBonin_Gubun);
            this.pnlT2FillIn.Controls.Add(this.txtJohap_gubun);
            this.pnlT2FillIn.Controls.Add(this.btnBAS0111U00);
            this.pnlT2FillIn.Controls.Add(this.fbxGaein);
            this.pnlT2FillIn.Controls.Add(this.fbxGubun1);
            this.pnlT2FillIn.Controls.Add(this.dtpLast_Check_Date);
            this.pnlT2FillIn.Controls.Add(this.txtPiName);
            this.pnlT2FillIn.Controls.Add(this.txtGaein_No);
            this.pnlT2FillIn.Controls.Add(this.dbxJohap_Name);
            this.pnlT2FillIn.Controls.Add(this.fbxJohap);
            this.pnlT2FillIn.Controls.Add(this.dbxGubun_Name1);
            this.pnlT2FillIn.Controls.Add(this.dtpTo_Jy_Date);
            this.pnlT2FillIn.Controls.Add(this.dtpFrom_Jy_Date);
            this.pnlT2FillIn.Controls.Add(this.xLabel15);
            this.pnlT2FillIn.Controls.Add(this.xLabel20);
            this.pnlT2FillIn.Controls.Add(this.xLabel27);
            this.pnlT2FillIn.Controls.Add(this.xLabel28);
            this.pnlT2FillIn.Controls.Add(this.xLabel29);
            this.pnlT2FillIn.Controls.Add(this.xLabel30);
            this.pnlT2FillIn.Controls.Add(this.xLabel31);
            this.pnlT2FillIn.Controls.Add(this.xLabel32);
            this.pnlT2FillIn.Controls.Add(this.xLabel33);
            this.pnlT2FillIn.Controls.Add(this.cbxLast_Check);
            this.pnlT2FillIn.Font = null;
            this.pnlT2FillIn.Name = "pnlT2FillIn";
            // 
            // xButtonBAS0111U00
            // 
            this.xButtonBAS0111U00.AccessibleDescription = null;
            this.xButtonBAS0111U00.AccessibleName = null;
            resources.ApplyResources(this.xButtonBAS0111U00, "xButtonBAS0111U00");
            this.xButtonBAS0111U00.BackgroundImage = null;
            this.xButtonBAS0111U00.ImageIndex = 0;
            this.xButtonBAS0111U00.ImageList = this.ImageList;
            this.xButtonBAS0111U00.Name = "xButtonBAS0111U00";
            this.xButtonBAS0111U00.Click += new System.EventHandler(this.btnBAS0111U00_Click);
            // 
            // dtpChuiduk_Date
            // 
            this.dtpChuiduk_Date.AccessibleDescription = null;
            this.dtpChuiduk_Date.AccessibleName = null;
            resources.ApplyResources(this.dtpChuiduk_Date, "dtpChuiduk_Date");
            this.dtpChuiduk_Date.BackgroundImage = null;
            this.dtpChuiduk_Date.IsVietnameseYearType = false;
            this.dtpChuiduk_Date.Name = "dtpChuiduk_Date";
            this.dtpChuiduk_Date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpChuiduk_Date_DataValidating);
            // 
            // xLabel35
            // 
            this.xLabel35.AccessibleDescription = null;
            this.xLabel35.AccessibleName = null;
            resources.ApplyResources(this.xLabel35, "xLabel35");
            this.xLabel35.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel35.EdgeRounding = false;
            this.xLabel35.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel35.Image = null;
            this.xLabel35.Name = "xLabel35";
            // 
            // cboBonin_Gubun
            // 
            this.cboBonin_Gubun.AccessibleDescription = null;
            this.cboBonin_Gubun.AccessibleName = null;
            resources.ApplyResources(this.cboBonin_Gubun, "cboBonin_Gubun");
            this.cboBonin_Gubun.BackgroundImage = null;
            this.cboBonin_Gubun.ExecuteQuery = null;
            this.cboBonin_Gubun.Name = "cboBonin_Gubun";
            this.cboBonin_Gubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboBonin_Gubun.ParamList")));
            this.cboBonin_Gubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboBonin_Gubun.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()" +
                "\r\n  AND CODE_TYPE = \'BON_GA_GUBUN\'\r\n";
            this.cboBonin_Gubun.SelectionChangeCommitted += new System.EventHandler(this.cboBonin_Gubun_SelectionChangeCommitted);
            // 
            // txtJohap_gubun
            // 
            this.txtJohap_gubun.AccessibleDescription = null;
            this.txtJohap_gubun.AccessibleName = null;
            resources.ApplyResources(this.txtJohap_gubun, "txtJohap_gubun");
            this.txtJohap_gubun.BackgroundImage = null;
            this.txtJohap_gubun.Name = "txtJohap_gubun";
            // 
            // btnBAS0111U00
            // 
            this.btnBAS0111U00.AccessibleDescription = null;
            this.btnBAS0111U00.AccessibleName = null;
            resources.ApplyResources(this.btnBAS0111U00, "btnBAS0111U00");
            this.btnBAS0111U00.BackgroundImage = null;
            this.btnBAS0111U00.ImageIndex = 0;
            this.btnBAS0111U00.ImageList = this.ImageList;
            this.btnBAS0111U00.Name = "btnBAS0111U00";
            this.btnBAS0111U00.Click += new System.EventHandler(this.btnBAS0111U00_Click);
            // 
            // fbxGaein
            // 
            this.fbxGaein.AccessibleDescription = null;
            this.fbxGaein.AccessibleName = null;
            resources.ApplyResources(this.fbxGaein, "fbxGaein");
            this.fbxGaein.AutoTabDataSelected = true;
            this.fbxGaein.BackgroundImage = null;
            this.fbxGaein.FindWorker = this.fwkCommon;
            this.fbxGaein.Name = "fbxGaein";
            this.fbxGaein.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxGaein.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // fbxGubun1
            // 
            this.fbxGubun1.AccessibleDescription = null;
            this.fbxGubun1.AccessibleName = null;
            resources.ApplyResources(this.fbxGubun1, "fbxGubun1");
            this.fbxGubun1.AutoTabDataSelected = true;
            this.fbxGubun1.BackgroundImage = null;
            this.fbxGubun1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxGubun1.FindWorker = this.fwkCommon;
            this.fbxGubun1.Name = "fbxGubun1";
            this.fbxGubun1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxGubun1.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // dtpLast_Check_Date
            // 
            this.dtpLast_Check_Date.AccessibleDescription = null;
            this.dtpLast_Check_Date.AccessibleName = null;
            resources.ApplyResources(this.dtpLast_Check_Date, "dtpLast_Check_Date");
            this.dtpLast_Check_Date.BackgroundImage = null;
            this.dtpLast_Check_Date.IsVietnameseYearType = false;
            this.dtpLast_Check_Date.Name = "dtpLast_Check_Date";
            // 
            // txtPiName
            // 
            this.txtPiName.AccessibleDescription = null;
            this.txtPiName.AccessibleName = null;
            resources.ApplyResources(this.txtPiName, "txtPiName");
            this.txtPiName.BackgroundImage = null;
            this.txtPiName.Name = "txtPiName";
            // 
            // txtGaein_No
            // 
            this.txtGaein_No.AccessibleDescription = null;
            this.txtGaein_No.AccessibleName = null;
            resources.ApplyResources(this.txtGaein_No, "txtGaein_No");
            this.txtGaein_No.BackgroundImage = null;
            this.txtGaein_No.Name = "txtGaein_No";
            // 
            // dbxJohap_Name
            // 
            this.dbxJohap_Name.AccessibleDescription = null;
            this.dbxJohap_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxJohap_Name, "dbxJohap_Name");
            this.dbxJohap_Name.Image = null;
            this.dbxJohap_Name.Name = "dbxJohap_Name";
            // 
            // fbxJohap
            // 
            this.fbxJohap.AccessibleDescription = null;
            this.fbxJohap.AccessibleName = null;
            resources.ApplyResources(this.fbxJohap, "fbxJohap");
            this.fbxJohap.AutoTabDataSelected = true;
            this.fbxJohap.BackgroundImage = null;
            this.fbxJohap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJohap.Name = "fbxJohap";
            this.fbxJohap.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJohap_DataValidating);
            this.fbxJohap.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // dbxGubun_Name1
            // 
            this.dbxGubun_Name1.AccessibleDescription = null;
            this.dbxGubun_Name1.AccessibleName = null;
            resources.ApplyResources(this.dbxGubun_Name1, "dbxGubun_Name1");
            this.dbxGubun_Name1.Image = null;
            this.dbxGubun_Name1.Name = "dbxGubun_Name1";
            // 
            // dtpTo_Jy_Date
            // 
            this.dtpTo_Jy_Date.AccessibleDescription = null;
            this.dtpTo_Jy_Date.AccessibleName = null;
            resources.ApplyResources(this.dtpTo_Jy_Date, "dtpTo_Jy_Date");
            this.dtpTo_Jy_Date.BackgroundImage = null;
            this.dtpTo_Jy_Date.IsVietnameseYearType = false;
            this.dtpTo_Jy_Date.Name = "dtpTo_Jy_Date";
            this.dtpTo_Jy_Date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpTo_Jy_Date_DataValidating);
            // 
            // dtpFrom_Jy_Date
            // 
            this.dtpFrom_Jy_Date.AccessibleDescription = null;
            this.dtpFrom_Jy_Date.AccessibleName = null;
            resources.ApplyResources(this.dtpFrom_Jy_Date, "dtpFrom_Jy_Date");
            this.dtpFrom_Jy_Date.BackgroundImage = null;
            this.dtpFrom_Jy_Date.IsVietnameseYearType = false;
            this.dtpFrom_Jy_Date.Name = "dtpFrom_Jy_Date";
            this.dtpFrom_Jy_Date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFrom_Jy_Date_DataValidating);
            // 
            // xLabel15
            // 
            this.xLabel15.AccessibleDescription = null;
            this.xLabel15.AccessibleName = null;
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel15.Image = null;
            this.xLabel15.Name = "xLabel15";
            // 
            // xLabel20
            // 
            this.xLabel20.AccessibleDescription = null;
            this.xLabel20.AccessibleName = null;
            resources.ApplyResources(this.xLabel20, "xLabel20");
            this.xLabel20.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel20.EdgeRounding = false;
            this.xLabel20.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel20.Image = null;
            this.xLabel20.Name = "xLabel20";
            // 
            // xLabel27
            // 
            this.xLabel27.AccessibleDescription = null;
            this.xLabel27.AccessibleName = null;
            resources.ApplyResources(this.xLabel27, "xLabel27");
            this.xLabel27.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel27.EdgeRounding = false;
            this.xLabel27.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel27.Image = null;
            this.xLabel27.Name = "xLabel27";
            // 
            // xLabel28
            // 
            this.xLabel28.AccessibleDescription = null;
            this.xLabel28.AccessibleName = null;
            resources.ApplyResources(this.xLabel28, "xLabel28");
            this.xLabel28.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel28.EdgeRounding = false;
            this.xLabel28.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel28.Image = null;
            this.xLabel28.Name = "xLabel28";
            // 
            // xLabel29
            // 
            this.xLabel29.AccessibleDescription = null;
            this.xLabel29.AccessibleName = null;
            resources.ApplyResources(this.xLabel29, "xLabel29");
            this.xLabel29.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel29.EdgeRounding = false;
            this.xLabel29.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel29.Image = null;
            this.xLabel29.Name = "xLabel29";
            // 
            // xLabel30
            // 
            this.xLabel30.AccessibleDescription = null;
            this.xLabel30.AccessibleName = null;
            resources.ApplyResources(this.xLabel30, "xLabel30");
            this.xLabel30.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel30.EdgeRounding = false;
            this.xLabel30.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel30.Image = null;
            this.xLabel30.Name = "xLabel30";
            // 
            // xLabel31
            // 
            this.xLabel31.AccessibleDescription = null;
            this.xLabel31.AccessibleName = null;
            resources.ApplyResources(this.xLabel31, "xLabel31");
            this.xLabel31.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel31.EdgeRounding = false;
            this.xLabel31.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel31.Image = null;
            this.xLabel31.Name = "xLabel31";
            // 
            // xLabel32
            // 
            this.xLabel32.AccessibleDescription = null;
            this.xLabel32.AccessibleName = null;
            resources.ApplyResources(this.xLabel32, "xLabel32");
            this.xLabel32.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel32.EdgeRounding = false;
            this.xLabel32.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel32.Image = null;
            this.xLabel32.Name = "xLabel32";
            // 
            // xLabel33
            // 
            this.xLabel33.AccessibleDescription = null;
            this.xLabel33.AccessibleName = null;
            resources.ApplyResources(this.xLabel33, "xLabel33");
            this.xLabel33.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel33.EdgeRounding = false;
            this.xLabel33.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel33.Image = null;
            this.xLabel33.Name = "xLabel33";
            // 
            // cbxLast_Check
            // 
            this.cbxLast_Check.AccessibleDescription = null;
            this.cbxLast_Check.AccessibleName = null;
            resources.ApplyResources(this.cbxLast_Check, "cbxLast_Check");
            this.cbxLast_Check.BackgroundImage = null;
            this.cbxLast_Check.Name = "cbxLast_Check";
            this.cbxLast_Check.UseVisualStyleBackColor = false;
            this.cbxLast_Check.CheckedChanged += new System.EventHandler(this.cbxLast_Check_CheckedChanged);
            // 
            // pnlT2Left
            // 
            this.pnlT2Left.AccessibleDescription = null;
            this.pnlT2Left.AccessibleName = null;
            resources.ApplyResources(this.pnlT2Left, "pnlT2Left");
            this.pnlT2Left.BackgroundImage = null;
            this.pnlT2Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlT2Left.Controls.Add(this.grdBoheom);
            this.pnlT2Left.Font = null;
            this.pnlT2Left.Name = "pnlT2Left";
            // 
            // grdBoheom
            // 
            resources.ApplyResources(this.grdBoheom, "grdBoheom");
            this.grdBoheom.ApplyPaintEventToAllColumn = true;
            this.grdBoheom.CallerID = '2';
            this.grdBoheom.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell15,
            this.xEditGridCell3,
            this.xEditGridCell14,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell13,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell17,
            this.xEditGridCell74,
            this.xEditGridCell76,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell39});
            this.grdBoheom.ColPerLine = 3;
            this.grdBoheom.Cols = 4;
            this.grdBoheom.ControlBinding = true;
            this.grdBoheom.ExecuteQuery = null;
            this.grdBoheom.FixedCols = 1;
            this.grdBoheom.FixedRows = 1;
            this.grdBoheom.HeaderHeights.Add(21);
            this.grdBoheom.Name = "grdBoheom";
            this.grdBoheom.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBoheom.ParamList")));
            this.grdBoheom.QuerySQL = resources.GetString("grdBoheom.QuerySQL");
            this.grdBoheom.ReadOnly = true;
            this.grdBoheom.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdBoheom.RowHeaderVisible = true;
            this.grdBoheom.Rows = 2;
            this.grdBoheom.ToolTipActive = true;
            this.grdBoheom.UseDefaultTransaction = false;
            this.grdBoheom.Enter += new System.EventHandler(this.grdBoheom_Enter);
            this.grdBoheom.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdBoheom_RowFocusChanged);
            this.grdBoheom.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdBoheom_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.BindControl = this.dtpFrom_Jy_Date;
            this.xEditGridCell1.CellName = "start_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 88;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellLen = 9;
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.HeaderText = global::IHIS.NURO.Properties.Resources.BUNHO_TEXT;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.CellLen = 30;
            this.xEditGridCell15.CellName = "suname";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.HeaderText = global::IHIS.NURO.Properties.Resources.SU_NAME_TEXT;
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.BindControl = this.fbxGubun1;
            this.xEditGridCell3.CellLen = 2;
            this.xEditGridCell3.CellName = "gubun1";
            this.xEditGridCell3.CellWidth = 81;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.HeaderText = global::IHIS.NURO.Properties.Resources.LABEL31_TEXT;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell14.BindControl = this.dbxGubun_Name1;
            this.xEditGridCell14.CellName = "gubun_name1";
            this.xEditGridCell14.CellWidth = 79;
            this.xEditGridCell14.Col = 2;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.BindControl = this.fbxJohap;
            this.xEditGridCell4.CellLen = 13;
            this.xEditGridCell4.CellName = "johap";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.HeaderText = global::IHIS.NURO.Properties.Resources.JOHAP_TEXT;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell5.BindControl = this.dbxJohap_Name;
            this.xEditGridCell5.CellName = "johap_name";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell5.HeaderText = global::IHIS.NURO.Properties.Resources.JOHAP_NAME_TEXT;
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell6.CellLen = 15;
            this.xEditGridCell6.CellName = "tel";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell6.HeaderText = global::IHIS.NURO.Properties.Resources.TEL2_TEXT;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell7.BindControl = this.fbxGaein;
            this.xEditGridCell7.CellLen = 15;
            this.xEditGridCell7.CellName = "gaein";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell7.HeaderText = global::IHIS.NURO.Properties.Resources.GAEIN_TEXT;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.BindControl = this.txtGaein_No;
            this.xEditGridCell8.CellLen = 30;
            this.xEditGridCell8.CellName = "gaein_no";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.HeaderText = global::IHIS.NURO.Properties.Resources.GAEIN_NO_TEXT;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell9.BindControl = this.cboBonin_Gubun;
            this.xEditGridCell9.CellLen = 1;
            this.xEditGridCell9.CellName = "bonin_gubun";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell9.HeaderText = global::IHIS.NURO.Properties.Resources.BONIN_GUBUN_TEXT;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell13.CellName = "bonin_gubun_name";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell13.HeaderText = global::IHIS.NURO.Properties.Resources.BONIN_GUBUN_NAME_TEXT;
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell10.BindControl = this.txtPiName;
            this.xEditGridCell10.CellLen = 30;
            this.xEditGridCell10.CellName = "piname";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell10.HeaderText = global::IHIS.NURO.Properties.Resources.PI_NAME_TEXT;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell11.BindControl = this.dtpLast_Check_Date;
            this.xEditGridCell11.CellName = "last_check_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell11.HeaderText = global::IHIS.NURO.Properties.Resources.LAST_CHECK_DATE_TEXT;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell12.BindControl = this.dtpTo_Jy_Date;
            this.xEditGridCell12.CellName = "end_date";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell12.CellWidth = 113;
            this.xEditGridCell12.Col = 3;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.CellName = "johap_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.HeaderText = global::IHIS.NURO.Properties.Resources.JOHAP_GUBUN_TEXT;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell74.CellName = "old_gubun";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            this.xEditGridCell74.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell74.HeaderText = global::IHIS.NURO.Properties.Resources.OLD_GUBUN_TEXT;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            this.xEditGridCell74.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell76.CellName = "retrieve_yn";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            this.xEditGridCell76.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell76.HeaderText = global::IHIS.NURO.Properties.Resources.RETRIEVE_YN1_TEXT;
            this.xEditGridCell76.IsUpdCol = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            this.xEditGridCell76.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell85.CellName = "old_start_date";
            this.xEditGridCell85.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            this.xEditGridCell85.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell85.HeaderText = global::IHIS.NURO.Properties.Resources.OLD_START_DATE_TEXT;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            this.xEditGridCell85.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.BindControl = this.dtpChuiduk_Date;
            this.xEditGridCell86.CellName = "chuiduk_date";
            this.xEditGridCell86.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.HeaderText = global::IHIS.NURO.Properties.Resources.CHUIDUK_DATE_TEXT;
            this.xEditGridCell86.IsUpdatable = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            this.xEditGridCell86.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.CellName = "end_yn";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.HeaderText = global::IHIS.NURO.Properties.Resources.END_YN_TEXT;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xLabel34
            // 
            this.xLabel34.AccessibleDescription = null;
            this.xLabel34.AccessibleName = null;
            resources.ApplyResources(this.xLabel34, "xLabel34");
            this.xLabel34.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel34.EdgeRounding = false;
            this.xLabel34.GradientEndColor = IHIS.Framework.XColor.XGridRowHeaderBackColor;
            this.xLabel34.Image = null;
            this.xLabel34.ImageList = this.ImageList;
            this.xLabel34.Name = "xLabel34";
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFill.Controls.Add(this.xPanel2);
            this.pnlFill.Controls.Add(this.xPanel1);
            this.pnlFill.Controls.Add(this.xLabel36);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.pnlGongbi);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // pnlGongbi
            // 
            this.pnlGongbi.AccessibleDescription = null;
            this.pnlGongbi.AccessibleName = null;
            resources.ApplyResources(this.pnlGongbi, "pnlGongbi");
            this.pnlGongbi.BackgroundImage = null;
            this.pnlGongbi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGongbi.Controls.Add(this.mbxRemark);
            this.pnlGongbi.Controls.Add(this.xLabel38);
            this.pnlGongbi.Controls.Add(this.dtpLast_Check_Date2);
            this.pnlGongbi.Controls.Add(this.txtSugubja_Bunho);
            this.pnlGongbi.Controls.Add(this.txtBudamja_Bunho);
            this.pnlGongbi.Controls.Add(this.dbxGongbi_Name);
            this.pnlGongbi.Controls.Add(this.fbxGongbi_Code);
            this.pnlGongbi.Controls.Add(this.dtpTo_Jy_Date2);
            this.pnlGongbi.Controls.Add(this.dtpFrom_Jy_Date2);
            this.pnlGongbi.Controls.Add(this.xLabel39);
            this.pnlGongbi.Controls.Add(this.xLabel42);
            this.pnlGongbi.Controls.Add(this.xLabel43);
            this.pnlGongbi.Controls.Add(this.xLabel44);
            this.pnlGongbi.Controls.Add(this.xLabel46);
            this.pnlGongbi.Controls.Add(this.xLabel47);
            this.pnlGongbi.Controls.Add(this.cbxLast_Check1);
            this.pnlGongbi.Font = null;
            this.pnlGongbi.Name = "pnlGongbi";
            // 
            // mbxRemark
            // 
            this.mbxRemark.AccessibleDescription = null;
            this.mbxRemark.AccessibleName = null;
            resources.ApplyResources(this.mbxRemark, "mbxRemark");
            this.mbxRemark.BackgroundImage = null;
            this.mbxRemark.DisplayMemoText = true;
            this.mbxRemark.Name = "mbxRemark";
            this.mbxRemark.TextImeMode = System.Windows.Forms.ImeMode.Hiragana;
            // 
            // xLabel38
            // 
            this.xLabel38.AccessibleDescription = null;
            this.xLabel38.AccessibleName = null;
            resources.ApplyResources(this.xLabel38, "xLabel38");
            this.xLabel38.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel38.EdgeRounding = false;
            this.xLabel38.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel38.Image = null;
            this.xLabel38.Name = "xLabel38";
            // 
            // dtpLast_Check_Date2
            // 
            this.dtpLast_Check_Date2.AccessibleDescription = null;
            this.dtpLast_Check_Date2.AccessibleName = null;
            resources.ApplyResources(this.dtpLast_Check_Date2, "dtpLast_Check_Date2");
            this.dtpLast_Check_Date2.BackgroundImage = null;
            this.dtpLast_Check_Date2.IsVietnameseYearType = false;
            this.dtpLast_Check_Date2.Name = "dtpLast_Check_Date2";
            // 
            // txtSugubja_Bunho
            // 
            this.txtSugubja_Bunho.AccessibleDescription = null;
            this.txtSugubja_Bunho.AccessibleName = null;
            resources.ApplyResources(this.txtSugubja_Bunho, "txtSugubja_Bunho");
            this.txtSugubja_Bunho.BackgroundImage = null;
            this.txtSugubja_Bunho.Name = "txtSugubja_Bunho";
            // 
            // txtBudamja_Bunho
            // 
            this.txtBudamja_Bunho.AccessibleDescription = null;
            this.txtBudamja_Bunho.AccessibleName = null;
            resources.ApplyResources(this.txtBudamja_Bunho, "txtBudamja_Bunho");
            this.txtBudamja_Bunho.BackgroundImage = null;
            this.txtBudamja_Bunho.Name = "txtBudamja_Bunho";
            this.txtBudamja_Bunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtBudamja_Bunho_DataValidating);
            // 
            // dbxGongbi_Name
            // 
            this.dbxGongbi_Name.AccessibleDescription = null;
            this.dbxGongbi_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxGongbi_Name, "dbxGongbi_Name");
            this.dbxGongbi_Name.Image = null;
            this.dbxGongbi_Name.Name = "dbxGongbi_Name";
            // 
            // fbxGongbi_Code
            // 
            this.fbxGongbi_Code.AccessibleDescription = null;
            this.fbxGongbi_Code.AccessibleName = null;
            resources.ApplyResources(this.fbxGongbi_Code, "fbxGongbi_Code");
            this.fbxGongbi_Code.AutoTabDataSelected = true;
            this.fbxGongbi_Code.BackgroundImage = null;
            this.fbxGongbi_Code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxGongbi_Code.FindWorker = this.fwkCommon;
            this.fbxGongbi_Code.Name = "fbxGongbi_Code";
            this.fbxGongbi_Code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxGongbi_Code.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // dtpTo_Jy_Date2
            // 
            this.dtpTo_Jy_Date2.AccessibleDescription = null;
            this.dtpTo_Jy_Date2.AccessibleName = null;
            resources.ApplyResources(this.dtpTo_Jy_Date2, "dtpTo_Jy_Date2");
            this.dtpTo_Jy_Date2.BackgroundImage = null;
            this.dtpTo_Jy_Date2.IsVietnameseYearType = false;
            this.dtpTo_Jy_Date2.Name = "dtpTo_Jy_Date2";
            // 
            // dtpFrom_Jy_Date2
            // 
            this.dtpFrom_Jy_Date2.AccessibleDescription = null;
            this.dtpFrom_Jy_Date2.AccessibleName = null;
            resources.ApplyResources(this.dtpFrom_Jy_Date2, "dtpFrom_Jy_Date2");
            this.dtpFrom_Jy_Date2.BackgroundImage = null;
            this.dtpFrom_Jy_Date2.IsVietnameseYearType = false;
            this.dtpFrom_Jy_Date2.Name = "dtpFrom_Jy_Date2";
            // 
            // xLabel39
            // 
            this.xLabel39.AccessibleDescription = null;
            this.xLabel39.AccessibleName = null;
            resources.ApplyResources(this.xLabel39, "xLabel39");
            this.xLabel39.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel39.EdgeRounding = false;
            this.xLabel39.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel39.Image = null;
            this.xLabel39.Name = "xLabel39";
            // 
            // xLabel42
            // 
            this.xLabel42.AccessibleDescription = null;
            this.xLabel42.AccessibleName = null;
            resources.ApplyResources(this.xLabel42, "xLabel42");
            this.xLabel42.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel42.EdgeRounding = false;
            this.xLabel42.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel42.Image = null;
            this.xLabel42.Name = "xLabel42";
            // 
            // xLabel43
            // 
            this.xLabel43.AccessibleDescription = null;
            this.xLabel43.AccessibleName = null;
            resources.ApplyResources(this.xLabel43, "xLabel43");
            this.xLabel43.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel43.EdgeRounding = false;
            this.xLabel43.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel43.Image = null;
            this.xLabel43.Name = "xLabel43";
            // 
            // xLabel44
            // 
            this.xLabel44.AccessibleDescription = null;
            this.xLabel44.AccessibleName = null;
            resources.ApplyResources(this.xLabel44, "xLabel44");
            this.xLabel44.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel44.EdgeRounding = false;
            this.xLabel44.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel44.Image = null;
            this.xLabel44.Name = "xLabel44";
            // 
            // xLabel46
            // 
            this.xLabel46.AccessibleDescription = null;
            this.xLabel46.AccessibleName = null;
            resources.ApplyResources(this.xLabel46, "xLabel46");
            this.xLabel46.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel46.EdgeRounding = false;
            this.xLabel46.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel46.Image = null;
            this.xLabel46.Name = "xLabel46";
            // 
            // xLabel47
            // 
            this.xLabel47.AccessibleDescription = null;
            this.xLabel47.AccessibleName = null;
            resources.ApplyResources(this.xLabel47, "xLabel47");
            this.xLabel47.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel47.EdgeRounding = false;
            this.xLabel47.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel47.Image = null;
            this.xLabel47.Name = "xLabel47";
            // 
            // cbxLast_Check1
            // 
            this.cbxLast_Check1.AccessibleDescription = null;
            this.cbxLast_Check1.AccessibleName = null;
            resources.ApplyResources(this.cbxLast_Check1, "cbxLast_Check1");
            this.cbxLast_Check1.BackgroundImage = null;
            this.cbxLast_Check1.Name = "cbxLast_Check1";
            this.cbxLast_Check1.UseVisualStyleBackColor = false;
            this.cbxLast_Check1.CheckedChanged += new System.EventHandler(this.cbxLast_Check1_CheckedChanged);
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel1.Controls.Add(this.grdGongbiList);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // grdGongbiList
            // 
            resources.ApplyResources(this.grdGongbiList, "grdGongbiList");
            this.grdGongbiList.ApplyPaintEventToAllColumn = true;
            this.grdGongbiList.CallerID = '3';
            this.grdGongbiList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell77,
            this.xEditGridCell16,
            this.xEditGridCell40});
            this.grdGongbiList.ColPerLine = 4;
            this.grdGongbiList.Cols = 5;
            this.grdGongbiList.ControlBinding = true;
            this.grdGongbiList.ExecuteQuery = null;
            this.grdGongbiList.FixedCols = 1;
            this.grdGongbiList.FixedRows = 1;
            this.grdGongbiList.HeaderHeights.Add(21);
            this.grdGongbiList.Name = "grdGongbiList";
            this.grdGongbiList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdGongbiList.ParamList")));
            this.grdGongbiList.QuerySQL = resources.GetString("grdGongbiList.QuerySQL");
            this.grdGongbiList.ReadOnly = true;
            this.grdGongbiList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdGongbiList.RowHeaderVisible = true;
            this.grdGongbiList.Rows = 2;
            this.grdGongbiList.ToolTipActive = true;
            this.grdGongbiList.UseDefaultTransaction = false;
            this.grdGongbiList.Enter += new System.EventHandler(this.grdGongbiList_Enter);
            this.grdGongbiList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdGongbiList_RowFocusChanged);
            this.grdGongbiList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdBoheom_GridCellPainting);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.BindControl = this.dtpFrom_Jy_Date2;
            this.xEditGridCell18.CellName = "start_date";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell18.CellWidth = 88;
            this.xEditGridCell18.Col = 1;
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellLen = 9;
            this.xEditGridCell19.CellName = "bunho";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.HeaderText = global::IHIS.NURO.Properties.Resources.LABEL6_TEXT;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.BindControl = this.txtBudamja_Bunho;
            this.xEditGridCell20.CellName = "budamja_bunho";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.HeaderText = global::IHIS.NURO.Properties.Resources.LABEL43_TEXT;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.BindControl = this.fbxGongbi_Code;
            this.xEditGridCell21.CellLen = 3;
            this.xEditGridCell21.CellName = "gongbi_code";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.HeaderText = global::IHIS.NURO.Properties.Resources.LABEL44_TEXT;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.BindControl = this.txtSugubja_Bunho;
            this.xEditGridCell22.CellLen = 25;
            this.xEditGridCell22.CellName = "sugubja_bunho";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.HeaderText = global::IHIS.NURO.Properties.Resources.LABEL42_TEXT;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.BindControl = this.dtpTo_Jy_Date2;
            this.xEditGridCell23.CellName = "end_date";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell23.CellWidth = 113;
            this.xEditGridCell23.Col = 3;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.BindControl = this.mbxRemark;
            this.xEditGridCell24.CellName = "remark";
            this.xEditGridCell24.CellWidth = 154;
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.HeaderText = global::IHIS.NURO.Properties.Resources.LABEL38_TEXT;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.BindControl = this.dtpLast_Check_Date2;
            this.xEditGridCell25.CellName = "last_check_date";
            this.xEditGridCell25.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.HeaderText = global::IHIS.NURO.Properties.Resources.LABEL15_TEXT;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.BindControl = this.dbxGongbi_Name;
            this.xEditGridCell26.CellName = "gongbi_name";
            this.xEditGridCell26.CellWidth = 78;
            this.xEditGridCell26.Col = 2;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell77.CellName = "retrieve_yn";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            this.xEditGridCell77.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            this.xEditGridCell77.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "old_start_date";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell16.CellWidth = 0;
            this.xEditGridCell16.Col = 4;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.HeaderText = global::IHIS.NURO.Properties.Resources.OLD_START_DATE_TEXT;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell40.CellName = "end_yn";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xLabel36
            // 
            this.xLabel36.AccessibleDescription = null;
            this.xLabel36.AccessibleName = null;
            resources.ApplyResources(this.xLabel36, "xLabel36");
            this.xLabel36.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel36.EdgeRounding = false;
            this.xLabel36.GradientEndColor = IHIS.Framework.XColor.XGridRowHeaderBackColor;
            this.xLabel36.Image = null;
            this.xLabel36.ImageList = this.ImageList;
            this.xLabel36.Name = "xLabel36";
            // 
            // layDupPatient
            // 
            this.layDupPatient.CallerID = '5';
            this.layDupPatient.ExecuteQuery = null;
            this.layDupPatient.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5});
            this.layDupPatient.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupPatient.ParamList")));
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
            this.multiLayoutItem3.DataName = "suname2";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "birth";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "sex";
            // 
            // layProtectGubunList
            // 
            this.layProtectGubunList.CallerID = '6';
            this.layProtectGubunList.ExecuteQuery = null;
            this.layProtectGubunList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7});
            this.layProtectGubunList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layProtectGubunList.ParamList")));
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "code";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "code_name";
            // 
            // OUT0101U02
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop2);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.xPanel3);
            this.Name = "OUT0101U02";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OUT0101U02_Closing);
            this.UserChanged += new System.EventHandler(this.OUT0101U02_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUT0101U02_ScreenOpen);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlRTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).EndInit();
            this.pnlTLeft.ResumeLayout(false);
            this.pnlTLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSex)).EndInit();
            this.pnlTop2.ResumeLayout(false);
            this.pnlT2Fill.ResumeLayout(false);
            this.pnlT2FillIn.ResumeLayout(false);
            this.pnlT2FillIn.PerformLayout();
            this.pnlT2Left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBoheom)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.pnlGongbi.ResumeLayout(false);
            this.pnlGongbi.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGongbiList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDupPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layProtectGubunList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region 사용자 변수
        string mbxMsg = string.Empty;
        string mbxCap = string.Empty;

        // 구분에 따른 체크 사항들
        //WON.LoadData.LoadBoheomInfo mGubunCheckYN = new IHIS.WON.LoadData.LoadBoheomInfo();

        string mAutoSuname2 = "";

        // 동일한 화면 오픈시 Command에서 어느 컨트롤에 셋팅할지 여부 가져가기 위하여
        string mCallControl = "";

        /**********************************************************************
         * 플레그 변수들
         * ********************************************************************/

        // 보험자번호에서 콜하는 건지 여부
        //private bool mIsCallbyJohap = false;

        // 환자번호 땃는지 여부
        private bool mIsGetBunho = false;

        // 노재 보험 저장 여부
        //private bool mIsExistNosai = false;

        /**********************************************************************
         * 하드코딩 상수 
         * ********************************************************************/
        // 생보 공비 코드
        //private string mSangBoCode = "12";

        //// 공비단독 코드
        //private string mGongbiDandok = "I1";

        //// 노인점수적용 부담자번호 2자리
        //private string NOIN_BUDAMJA_BUNHO = "27";

        // 노재 구분 수가
        //private string mNosaiGubunSuga = "4";

        // 디폴트 값
        //private string mDefaultPatientGubun     = "0";    // 환자구분 : 일반환자
        //private string mDefaultDisGubun         = "00";   // 감면구분 : 감면없음
        //private string mDefaultJubsuBreakReason = "00";   // 접수불가사유 : 해당없음

        private const string CACHE_COMBOLIST_KEYS = "NURO.OUT0101U02.CmbList";
        #endregion

        #region Screen Open

        private void OUT0101U02_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            this.InitScreen();

            GetBunhoInputType(false);

            PostCallHelper.PostCall(new PostMethod(PostInitScreen));

            // 2015.07.02 updated by Cloud
            // 값을 받아서 조회함
            if (this.OpenParam != null)
            {
                if (OpenParam.Contains("bunho"))
                {
                    fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    fbxBunho.AcceptData();

                    // Disable auto-gen bunho button
                    genPatCodeBtn.Enabled = false;
                    btnConfirm.Enabled = true;                    
                }
            }
            else
            {
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    fbxBunho.SetEditValue(patientInfo.BunHo);
                    fbxBunho.AcceptData();

                    // Disable auto-gen bunho button
                    genPatCodeBtn.Enabled = false;
                    btnConfirm.Enabled = true;                    
                }
            }
            this.cbxBilling.SetDictDDLB();
            this.cboBunhoType.SetDictDDLB();
            this.cboTel_Gubun.SetDictDDLB();
            this.cboTel_Gubun2.SetDictDDLB();
            this.cboTel_Gubun3.SetDictDDLB();
            this.cboBonin_Gubun.SetDictDDLB();

            Form form = Parent.Parent as Form;
            if (form != null)
            {
                Size formSize = new Size(996, 626);
                form.MinimumSize = formSize;
                form.Size = formSize;
                btnBAS0111U00.Visible = false;
            }
            //this.cbxBilling.SelectedValue = "N";
            loadDefaultCombo();

            // https://sofiamedix.atlassian.net/browse/PHR-685
            this.cbxAutoRecept.Enabled = true;
        }

        private void OpenFormExportPatient()
        {
            FormExportPatient form = new FormExportPatient();
            form.ShowDialog();
        }
        #endregion

        #region Open Other Screen

        /// <summary>
        /// 우편번호 조회 창 Open
        /// </summary>
        /// <param name="aSearchGubun"></param>
        /// <param name="aZipCode1"></param>
        /// <param name="aZipCode2"></param>
        /// <param name="aAddress"></param>
        private void OpenScreen_BAS0123Q00(string aSearchGubun, string aZipCode1, string aZipCode2, string aAddress)
        {
            CommonItemCollection param = new CommonItemCollection();

            if (aSearchGubun == "zipCode")
            {
                param.Add("SearchGubun", aSearchGubun);
                param.Add("zip_code1", aZipCode1);
                param.Add("zip_code2", aZipCode2);
            }
            else
            {
                param.Add("SearchGubun", aSearchGubun);
                param.Add("address", aAddress);
            }

            XScreen.OpenScreenWithParam(this, "BASS", "BAS0123Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 환자번호 파인드 클릭
        /// </summary>
        private void OpenScreen_OUT0101Q01()
        {
            XScreen.OpenScreen(this, "OUT0101Q01", ScreenOpenStyle.ResponseFixed);
        }

        /// <summary>
        /// 보험자 번호 창 오픈
        /// </summary>
        private void OpenScreen_BAS0110Q00()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("johap_ymd", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            if (this.fbxJohap.GetDataValue() != "")
            {
                param.Add("johap", this.fbxJohap.GetDataValue());
            }

            XScreen.OpenScreenWithParam(this, "BASS", "BAS0110Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 기호 등록 창 오픈
        /// </summary>
        private void OpenScreen_BAS0111U00()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("gubun", this.grdBoheom.GetItemString(this.grdBoheom.CurrentRowNumber, "gubun1"));
            param.Add("naewon_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            param.Add("johap", this.grdBoheom.GetItemString(this.grdBoheom.CurrentRowNumber, "johap"));

            XScreen.OpenScreenWithParam(this, "BASS", "BAS0111U00", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 특기사항 입력 창 오픈
        /// </summary>
        private void OpenScreen_OUT0106U00()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho"));

            XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", ScreenOpenStyle.ResponseFixed, param);
        }

        #endregion

        #region Function

        #region InitScreen

        private void InitScreen()
        {
            // 일단은 조회 전에는 입력이 가능한 상태로 존재 해야 
            // 하기 때문에 환자정보 그리드에 일단 새로운 Row가 
            // 하나는 들어있어야 한다.
            this.SetDefaultValueToPatient();
        }

        #endregion

        #endregion

        #region 프로텍트

        #region 환자정보 프로텍트

        /// <summary>
        /// 환자번호를 제외한 전 정보 프로텍트
        /// </summary>
        /// <param name="aIsProtect">프로텍트 여부 </param>
        /// <param name="aProtectGubun">프로텍트 구분 true=>전컨트롤에 대하여 false=>환자번호를 제외한 컨트롤에 대하여</param>
        private void ProtectPatientInfo(bool aIsProtect, bool aProtectGubun)
        {
            int i = 0;
            //int j = 0;

            if (aProtectGubun == true)
            {
                for (i = 0; i < this.pnlTLeft.Controls.Count; i++)
                {
                    if (this.pnlTLeft.Controls[i] is IDataControl)
                    {
                        ((IDataControl)this.pnlTLeft.Controls[i]).Protect = aIsProtect;
                    }
                }
            }
            else
            {
                for (i = 0; i < this.pnlTLeft.Controls.Count; i++)
                {
                    if (this.pnlTLeft.Controls[i] is IDataControl)
                    {
                        if (this.pnlTLeft.Controls[i].Name == "fbxBunho")
                        {
                            ((IDataControl)this.pnlTLeft.Controls[i]).Protect = !aIsProtect;
                        }
                        else
                        {
                            ((IDataControl)this.pnlTLeft.Controls[i]).Protect = aIsProtect;
                        }
                    }
                }
            }


            //for (j=0; j<this.pnlTFill.Controls.Count; j++)
            //{
            //    if (this.pnlTFill.Controls[j] is IDataControl)
            //    {
            //        ((IDataControl)this.pnlTFill.Controls[j]).Protect = aIsProtect;
            //    }
            //}
        }

        #endregion

        #region 보험정보 프로텍트

        /// <summary>
        /// 보험정보 컨트롤에 대한 프로텍트
        /// </summary>
        /// <param name="aIsProtect">프로텍트 여부</param>
        /// <param name="aProtectGubun">프로텍트 구분 true=>전컨트롤, false=>OUT0102 키값만 제외</param>
        private void ProtectBoheomInfo(bool aIsProtect, bool aProtectGubun)
        {
            int i = 0;

            if (aProtectGubun == true)
            {
                for (i = 0; i < this.pnlT2FillIn.Controls.Count; i++)
                {
                    if (this.pnlT2FillIn.Controls[i] is IDataControl)
                    {
                        ((IDataControl)this.pnlT2FillIn.Controls[i]).Protect = aIsProtect;
                    }
                }
            }
            else
            {
                for (i = 0; i < this.pnlT2FillIn.Controls.Count; i++)
                {
                    if (this.pnlT2FillIn.Controls[i] is IDataControl)
                    {
                        if (this.pnlT2FillIn.Controls[i].Name == "fbxGubun1" ||
                            this.pnlT2FillIn.Controls[i].Name == "fbxJohap" ||
                            this.pnlT2FillIn.Controls[i].Name == "dtpChuiduk_Date")
                        {
                            ((IDataControl)this.pnlT2FillIn.Controls[i]).Protect = !aIsProtect;
                        }
                        else
                        {
                            ((IDataControl)this.pnlT2FillIn.Controls[i]).Protect = aIsProtect;
                        }
                    }
                }
            }
        }

        #endregion

        #region 공비정보 프로텍트

        /// <summary>
        /// 공비정보에 대한 컨트롤 프로텍트
        /// </summary>
        /// <param name="aIsProtect">프로텍트여부</param>
        /// <param name="aProtectGubun">프로텍트 구분 true=>전컨트롤, false=>OUT0105 키값 제외</param>
        private void ProtectGongbiInfo(bool aIsProtect, bool aProtectGubun)
        {
            int i = 0;

            if (aProtectGubun == true)
            {
                for (i = 0; i < this.pnlGongbi.Controls.Count; i++)
                {
                    if (this.pnlGongbi.Controls[i] is IDataControl)
                    {
                        ((IDataControl)this.pnlGongbi.Controls[i]).Protect = aIsProtect;
                    }
                }
            }
            else
            {
                for (i = 0; i < this.pnlGongbi.Controls.Count; i++)
                {
                    if (this.pnlGongbi.Controls[i] is IDataControl)
                    {
                        if (this.pnlGongbi.Controls[i].Name == "txtBudamja_Bunho" ||
                            this.pnlGongbi.Controls[i].Name == "fbxGongbi_Code" ||
                            this.pnlGongbi.Controls[i].Name == "dtpFrom_Jy_Date2")
                        {
                            ((IDataControl)this.pnlGongbi.Controls[i]).Protect = !aIsProtect;
                        }
                        else
                        {
                            ((IDataControl)this.pnlGongbi.Controls[i]).Protect = aIsProtect;
                        }
                    }
                }
            }
        }

        #endregion

        #region 노인, 선원, 무보험인 경우 Control Protect

        /// <summary>
        /// 보험종별 나이 구분에 따른 Control 프로텍팅
        /// </summary>
        /// <param name="agubun">보험종별</param>
        private void Control_Protect(string agubun)
        {
            /* 무보험인 경우 조합, 기호, 번호 프로텍팅 */
            if (agubun == "G1" || agubun == "H1" || agubun == "I1")
            {
                //				// 조합
                //				this.fbxJohap.SetEditValue("");
                //				this.fbxJohap.AcceptData();
                //				this.fbxJohap.Protect = true;
                // 기호
                this.fbxGaein.SetEditValue("");
                this.fbxGaein.AcceptData();
                this.fbxGaein.Protect = true;
                // 번호
                this.txtGaein_No.SetEditValue("");
                this.txtGaein_No.AcceptData();
                this.txtGaein_No.Protect = true;
                // 본가구분
                this.cboBonin_Gubun.SetEditValue("");
                this.cboBonin_Gubun.AcceptData();
                this.cboBonin_Gubun.Protect = true;
                // 피보험자
                this.txtPiName.SetEditValue("");
                this.txtPiName.AcceptData();
                this.txtPiName.Protect = true;
            }
            else
            {
                if (this.grdBoheom.GetItemString(grdBoheom.CurrentRowNumber, "retrieve_yn") != "Y")
                {
                    this.fbxJohap.Protect = false;
                }
                this.fbxGaein.Protect = false;
                this.txtGaein_No.Protect = false;
                this.cboBonin_Gubun.Protect = false;
                this.txtPiName.Protect = false;
            }

            //string johapGubun = this.mGubunCheckYN.JOHAP_GUBUN ;
            int age = 0;
            if (TypeCheck.IsInt(this.dbxAge.GetDataValue()))
            {
                age = int.Parse(this.dbxAge.GetDataValue());
            }
        }
        #endregion

        #endregion

        #region 각 그리드 별 초기값 셋팅

        private void SetDefaultValueToPatient()
        {
            if (this.grdPatient.RowCount <= 0)
            {
                this.grdPatient.InsertRow(-1);
            }

            // 기본값 셋팅
            this.cboSex.SetDataValue("F");
            this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "sex", "F");

            // 생년월일 년호 기본값을 소하로 
            this.dtpBirth.SetDefaultJapanPeriod(Resources.DefaultJapanPeriod);

            // 환자번호를 입력해서 따는 경우를 제외하곤 모두
            // 업데이트만 가능 하므로
            // 일단은 업데이트 구분을 'U'로 박아놓음.
            this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "iu_gubun", "U");

            // 환자 번호 안딴 상태로
            this.SetToGetBunhoVariable(false);

            this.grdPatient.ResetUpdate();
        }
        /// <summary>
        /// 보험정보 그리드
        /// </summary>
        private void SetDefaultValueToBoheom()
        {
            // 환자번호 셋팅
            this.grdBoheom.SetItemValue(this.grdBoheom.CurrentRowNumber, "bunho"
                , this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho"));
        }

        /// <summary>
        /// 공비정보 그리드
        /// </summary>
        private void SetDefaultValueToGongbi()
        {
            this.grdGongbiList.SetItemValue(this.grdGongbiList.CurrentRowNumber, "bunho"
                , this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho"));
        }

        #endregion

        #region SettingGubunDefaultValue

        //private void SettingGubunDefaultValue ()
        //{
        //    if (this.mIsCallbyJohap == false)
        //    {
        //        this.fbxJohap.SetEditValue("");
        //        this.fbxJohap.AcceptData();
        //        this.dbxJohap_Name.SetDataValue("");
        //        this.grdBoheom.SetItemValue(this.grdBoheom.CurrentRowNumber, "johap_name", "");
        //    }
        //}

        #endregion

        #region 저장전 체크

        #region 환자정보 체크
        /// <summary>
        /// 환자 마스터 체크
        /// -- 환자번호, 이름 두개, 생년월일, 성별까지만 체크 한다.
        /// </summary>
        /// <returns></returns>
        private bool CheckOUT0101()
        {
                bool isUpdatable = true;
            this.mbxMsg = "";

            // 환자번호 체크
            if (isUpdatable == true && this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho") == "")
            {
                this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox3_Ko : Resources.XMessageBox3_Jp);
                isUpdatable = false;
            }

            // 환자이름 체크
            if (NetInfo.Language == LangMode.Jr && isUpdatable == true)
            {
                if (this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname") == "" ||
                        this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname2") == "")
                {
                    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox4_Ko : Resources.XMessageBox4_Jp);
                    isUpdatable = false;
                }
                else
                {
                    if (!Utilities.ValidateName(this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname"))
                        || !Utilities.ValidateName(this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname2")))
                    {
                        this.mbxMsg = Resources.MSG_INPUTSPACE;
                        isUpdatable = false;
                    }
                }
            }
            else if (isUpdatable == true)
            {
                if (this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname") == "")
                {
                    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox4_Ko : Resources.XMessageBox4_Jp);
                    isUpdatable = false;
                }
                else
                {
                    if (!Utilities.ValidateName(this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname")))
                    {
                        this.mbxMsg = Resources.MSG_INPUTSPACE;
                        isUpdatable = false;
                    }
                }
            }

            // 2015.08.11 AnhNV Added START
            // https://nextop-asia.atlassian.net/browse/MED-3280
            string tel = this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "tel");
            string tel1 = this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "tel1");

            // Accepts number contains 15 digits as maximum
            if ((!TypeCheck.IsNull(tel) && !TypeCheck.IsDouble(tel))
                || (!TypeCheck.IsNull(tel1) && !TypeCheck.IsDouble(tel1)))
            {
                XMessageBox.Show(Resources.MSG_PHONE_ERR, Resources.CAP_002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // 2015.08.11 AnhNV Added END

            // 생년월일 체크
            if (isUpdatable == true &&
                this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "birth") == "")
            {
                this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox5_ko : Resources.XMessageBox5_Jp);
                isUpdatable = false;
            }

            // 2015.08.03 AnhNV Added START
            // Related to https://nextop-asia.atlassian.net/browse/MED-3502
            if (TypeCheck.IsDateTime(dtpBirth.GetDataValue()))
            {
                if (Int32.Parse(dtpBirth.GetDataValue().Replace("/", "")) > Int32.Parse(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("/", "")))
                {
                    XMessageBox.Show(Resources.MSG_002, Resources.CAP_002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            // 2015.08.03 AnhNV Added END

            // 성별
            if (isUpdatable == true &&
                this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "sex") == "")
            {
                this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox6_Ko : Resources.XMessageBox6_Jp);
                isUpdatable = false;
            }

            // 메세지 출력 
            if (isUpdatable == false)
            {
                this.mbxCap = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox7_Ko : Resources.XMessageBox7_Jp);

                XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            // 삭제인경우 실제 저장 할건지 체크
            if (this.grdPatient.GetItemString(grdPatient.CurrentRowNumber, "delete_yn") == "Y")
            {
                this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox8_Ko : Resources.XMessageBox8_Jp);
                this.mbxCap = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox7_Ko : Resources.XMessageBox7_Jp);

                DialogResult result = XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region 보험정보 체크
        /// <summary>
        /// 보험정보 체크
        /// -- 노말 상태 말고 변경된 상태를 체크한다
        /// -- 보험디테일별 변수를 따로 가져간다.
        /// -- 글로벌로 선언된 디테일 변수는 변하면 안되니까
        /// -- 체크용으로 따로 선언하여 체크
        /// </summary>
        /// <returns></returns>
        private bool CheckOUT0102()
        {
            this.mbxMsg = "";
            bool isUpdatable = true;
            int i = 0;

            // 체크용 보험 디테일 정보 가져오기
            //WON.LoadData.LoadBoheomInfo gubunCheckInfo = new IHIS.WON.LoadData.LoadBoheomInfo();

            // 노재 보험 플레그 변수 
            //this.mIsExistNosai = false;

            for (i = 0; i < this.grdBoheom.RowCount; i++)
            {
                // 바뀐게 없으면 통과
                if (this.grdBoheom.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                // 보험종별 입력 여부
                if (isUpdatable == true &&
                    this.grdBoheom.GetItemString(i, "gubun1") == "")
                {
                    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox9_Ko : Resources.XMessageBox9_Jp);
                    isUpdatable = false;

                    break;
                }

                // 개시일자 입력여부
                if (isUpdatable == true &&
                    this.grdBoheom.GetItemString(i, "start_date") == "")
                {
                    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox10_Ko : Resources.XMessageBox10_Jp);
                    isUpdatable = false;

                    break;
                }

                //// 취득일자 입력여부
                //if (isUpdatable == true &&
                //    this.grdBoheom.GetItemString(i, "chuiduk_date") == "")
                //{
                //    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "취득일자를 입력해 주십시오." : "保険取得日付を入力してください。");
                //    isUpdatable = false;

                //    break;
                //}

                /*
                // 체크 정보 로드     kbh ?? 단순히 유효기간 체크인지?? gubunCheckInfo에 먼가 대입하는 건가??
				WON.BizObj.ChkGubunBAS0210(this.grdBoheom.GetItemString(this.grdBoheom.CurrentRowNumber, "gubun1")
					,this.grdBoheom.GetItemString(this.grdBoheom.CurrentRowNumber, "from_jy_date"));

				// 보험자 번호
				// 필요한데 입력 안한 경우
				if (isUpdatable == true &&
					gubunCheckInfo.JOHAP_YN == "Y" &&
					this.grdBoheom.GetItemString(i, "johap") == "")
				{
					this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "보험자번호를 입력해 주십시오." : "保険者番号を入力してください");
					isUpdatable = false;

					break;
				}
					// 필요없는데 입력되어 있는 경우
				else if (isUpdatable == true &&
					gubunCheckInfo.JOHAP_YN == "N" &&
					this.grdBoheom.GetItemString(i, "johap") != "")
				{
					this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "보험자 번호를 필요로하지 않는 보험종별 입니다. 삭제해 주시기 바랍니다" 
						: "保険者番号が必要のない保険種別です。削除してください。");
					isUpdatable = false;

					break;
				}

				// 개인기호 체크
				if (isUpdatable == true &&
					gubunCheckInfo.JOHAP_YN == "Y" &&
					this.grdBoheom.GetItemString(i, "gaein") == "")
				{
					this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "기호를 입력해 주십시오." : "記号を入力してください。");
					isUpdatable = false;

					break;
				}

				// 번호 체크 
				if (isUpdatable == true &&
					gubunCheckInfo.GAEIN_NO_YN == "Y" &&
					this.grdBoheom.GetItemString(i, "gaein_no") == "")
				{
					this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "번호를 입력해 주십시오." : "番号を入力してください。");
					isUpdatable = false;

					break;
				}
                 */

                //// 선원보험인 경우
                //if (isUpdatable == true &&
                //    this.grdBoheom.GetItemString(i, "gubun1") == "02" &&
                //    this.grdBoheom.GetItemString(i, "sunwon_gubun") == "")
                //{
                //    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "선원구분을 입력해 주세요." : "船員区分を入力してください。");
                //    isUpdatable = false;

                //    break;
                //}

                // 노재 보험 입력한 경우, 저장 후에 노재 등록 창 오픈

                //if (gubunCheckInfo.GUBUN_SUGA == this.mNosaiGubunSuga)
                //{
                //    this.mIsExistNosai = true;
                //}

            }

            if (isUpdatable == false)
            {
                this.mbxMsg = this.grdBoheom.GetItemString(i, "gubun_name1") + "-" + this.mbxMsg;
                this.mbxCap = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox11_Ko : Resources.XMessageBox11_Jp);

                XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        #endregion

        #region 환자 공비 체크
        /// <summary>
        /// 환자 공비 체크
        /// </summary>
        /// <returns></returns>
        private bool CheckOUT0105()
        {
            bool isUpdatable = true;
            //bool isFindGongbiDandok = false;
            this.mbxMsg = "";
            int i = 0;

            for (i = 0; i < this.grdGongbiList.RowCount; i++)
            {
                if (this.grdGongbiList.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                // 공비코드 입력
                if (isUpdatable == true &&
                    this.grdGongbiList.GetItemString(i, "gongbi_code") == "")
                {
                    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox12_Ko : Resources.XMessageBox12_Jp);
                    isUpdatable = false;
                    break;
                }

                // 적용일자
                if (isUpdatable == true &&
                    this.grdGongbiList.GetItemString(i, "start_date") == "")
                {
                    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox13_Ko : Resources.XMessageBox13_Jp);
                    isUpdatable = false;
                    break;
                }

                // 생보 공비 입력시 주보험종별 입력 체크 
                //if (this.grdGongbiList.GetItemString(i, "gongbi_code") == this.mSangBoCode)
                //{
                //    for (int j=0; j<this.grdBoheom.RowCount; j++)
                //    {
                //        if (this.grdBoheom.GetItemString(j, "gubun1") == "I1")
                //        {
                //            isFindGongbiDandok = true; 
                //        }
                //    }

                //    if (isFindGongbiDandok == false)
                //    {
                //        this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "주보험종별이 입력되지 않았습니다. 주보험종별을 입력해 주십시오." : "主保険種別が入力されていません。主保険種別を入力してください。");
                //        isUpdatable = false;
                //        break;
                //    }
                //}

            }

            if (isUpdatable == false)
            {
                this.mbxMsg = this.grdGongbiList.GetItemString(i, "gongbi_code") + "-" + this.mbxMsg;
                this.mbxCap = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox14_Ko : Resources.XMessageBox14_Jp);

                XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        #endregion

        #endregion

        #region 저장후 체크

        private void AfterUpdate()
        {
            #region Comment old version
            // 노재 보험 입력 한 경우 노재 입력 창 오픈
            //if (this.mIsExistNosai == true)
            //{
            //    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "노재 보험종별을 등록 하였습니다. 노재정보 입력을 위한 화면으로 전환 합니다." : "労災保険種別を登録しました。労災情報を入力をため画面を開きます。");
            //    this.mbxCap = (NetInfo.Language == LangMode.Ko ? "노재 정보 등록" : "労災情報");

            //    XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    this.OpenScreen_OUT3002U01();
            //} 
            #endregion
            //MED-13100
            if (cbxAutoOpen.Checked)
            {
                if (rowState == "I")
                {
                    CommonItemCollection paramObj = new CommonItemCollection();
                    paramObj.Add("f_bunho", this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho"));
                    XScreen.OpenScreenWithParam(this, "NURO", "OUT1001U01", ScreenOpenStyle.ResponseFixed, paramObj);
                }
            }
        }

        #endregion

        #region SetToGetBunhoVariable (bool aIsGet)

        private void SetToGetBunhoVariable(bool aIsGet)
        {
            this.mIsGetBunho = aIsGet;

            if (this.mIsGetBunho == true)
            {
                this.fbxBunho.Protect = true;
            }
            else
            {
                this.fbxBunho.Protect = false;
            }
        }

        #endregion

        #region 오늘 일자로 유효기간 체크

        private bool IsEndedGubun(XEditGrid grd, int aRowNumber)
        {
            string today = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            string toJYDate = grd.GetItemString(aRowNumber, "end_date");

            if (toJYDate == "" || TypeCheck.IsDateTime(toJYDate) == false || TypeCheck.IsDateTime(today) == false)
            {
                return false;
            }

            DateTime toDate = DateTime.Parse(toJYDate);
            DateTime toDay = DateTime.Parse(today);

            if (toDay > toDate)
            {
                return true;
            }

            return false;

        }

        #endregion

        #region 화면 닫기전 체크

        private bool CheckDataBeforeClosing()
        {
            bool aIsFind = false;

            // 각 그리드별 변경 사항 체크
            #region 환자정보
            // OUT0101 
            foreach (DataRow dr in this.grdPatient.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                {
                    foreach (DataColumn dc in this.grdPatient.LayoutTable.Columns)
                    {
                        if (dc.ColumnName == "sex")
                        {
                            if (dr[dc.ColumnName].ToString() != "F")
                            {
                                aIsFind = true;
                                break;
                            }
                        }
                        else if (dc.ColumnName == "iu_gubun")
                        {
                            if (dr[dc.ColumnName].ToString() != "U")
                            {
                                aIsFind = true;
                                break;
                            }
                        }
                        else if (dc.ColumnName == "patient_gubun")
                        {
                            if (dr[dc.ColumnName].ToString() != "00")
                            {
                                aIsFind = true;
                                break;
                            }
                        }
                        else
                        {
                            if (dr[dc.ColumnName].ToString() != "")
                            {
                                aIsFind = true;
                                break;
                            }
                        }
                    }

                    if (aIsFind == true)
                    {
                        break;
                    }
                }
            }

            if (aIsFind == true)
            {
                return true;
            }

            #endregion

            /*

			#region 보험정보
			// OUT0102
			foreach (DataRow dr in this.grdBoheom.LayoutTable.Rows)
			{
				if (dr.RowState != DataRowState.Unchanged)
				{
					foreach (Object obj in dr.ItemArray)
					{
						if (obj.ToString() != "")
						{
							aIsFind = true;
						}
					}
				}
			}

			if (aIsFind == true)
			{
				return true;
			}

			#endregion

			#region 공비정보
			// OUT0105
			foreach (DataRow dr in this.grdGongbiList.LayoutTable.Rows)
			{
				if (dr.RowState != DataRowState.Unchanged)
				{
					foreach (Object obj in dr.ItemArray)
					{
						if (obj.ToString() != "")
						{
							aIsFind = true;
						}
					}
				}
			}

			if (aIsFind == true)
			{
				return true;
			}

			#endregion

			*/
            return false;
        }

        #endregion

        #region Load Data

        #region 환자정보

        /// <summary>
        /// 환자정보 조회
        /// </summary>
        private void LoadPatient(string aBunho)
        {
            this.grdPatient.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPatient.SetBindVarValue("f_bunho", aBunho);

            if (!this.grdPatient.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg + " : grdPatient Query Error");
                return;
            }
            else
            {
                if (this.grdPatient.RowCount > 0)
                {
                    this.fbxBunho.SetDataValue(this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho"));

                    // 환자번호 땃다고 봄.
                    this.SetToGetBunhoVariable(true);
                }
                else
                {
                    // 환자번호 안땄음.
                    this.SetToGetBunhoVariable(false);
                }
            }
        }

        #endregion

        #region 보험정보

        /// <summary>
        /// 보험정보 로드
        /// </summary>
        private void LoadBoheom()
        {
            this.grdBoheom.SetBindVarValue("f_bunho", this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho"));
            this.grdBoheom.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (!this.grdBoheom.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg + " : grdBoheom Query Error");
                return;
            }
            else
            {
                if (this.grdBoheom.RowCount <= 0)
                {
                    this.ProtectBoheomInfo(true, true);
                }
            }
        }

        #endregion

        #region 공비정보

        /// <summary>
        /// 공비정보 로드
        /// </summary>
        private void LoadGongbiInfo()
        {
            this.grdGongbiList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdGongbiList.SetBindVarValue("f_bunho", this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho"));

            if (!this.grdGongbiList.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg + " : grdGongbiList Query Error");
                return;
            }
            else
            {
                if (this.grdGongbiList.RowCount <= 0)
                {
                    this.ProtectGongbiInfo(true, true);
                }
            }
        }

        #endregion

        #region 신규번호 조회

        private void LoadNewBunho(string aSuname2, string aBirth, string aSex, string aSuname)
        {
            // 번호는 직접 입력해야하므로 이로직은 안태움.
            //DialogResult result ;

            this.mbxMsg = "";

            // 일단 중복체크 하고
            // 부여할지 여부 결정
            // 중복되는 환자가 한명도 없을경우는
            // 신규번호 부여할지 선택후 부여

            // 일단 환자 번호 딴경우는 그냥 리턴 
            if (this.mIsGetBunho == true)
            {
                return;
            }

            //if (this.DupCheckBunho(aSuname2, aBirth, aSex, ref this.mbxMsg) == true)
            //{
            //    this.mbxCap = (NetInfo.Language == LangMode.Ko ? "중복번호" : "重複患者番号");

            //    result = XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (result != DialogResult.Yes) 
            //    {
            //        //this.btnList.PerformClick(FunctionType.Reset);
            //        // 안땄다고 봄
            //        this.SetToGetBunhoVariable(false);
            //        return;
            //    }
            //}
            //            else
            //            {
            //                this.mbxCap = (NetInfo.Language == LangMode.Ko ? "신환환자" : "新患患者");
            //                this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "신환환자로 등록 하시겠습니까?" : "新患患者登録しますか？");

            //                result = XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                if (result != DialogResult.Yes)
            //                {
            //                    // 안땄다고 봄
            //                    this.SetToGetBunhoVariable(false);
            //                    return;
            //                }
            //            }

            //            if(aSuname == "" || aSuname2 == "")
            //            {
            //                XMessageBox.Show("患者氏名を入力してください。");
            //                return;
            //            }

            //            if(aBirth == "")
            //            {
            //                XMessageBox.Show("生年月日を入力してください。");
            //                return;
            //            }

            //            if(aSex == "")
            //            {
            //                XMessageBox.Show("性別を入力してください。");
            //                return;
            //            }

            //            string mP_bunho = string.Empty;

            //            ArrayList inputList  = new ArrayList();
            //            ArrayList outputList = new ArrayList();

            //            inputList.Add("OUT0101");
            //            inputList.Add("BUNHO");
            //            inputList.Add(EnvironInfo.BunhoLength);

            //            if(!Service.ExecuteProcedure("PR_OUT_MAKE_BUNHO", inputList, outputList))
            //            {
            //                XMessageBox.Show(Service.ErrFullMsg + " : 新しい番号生成ができません。");
            //                return;
            //            }
            //            else
            //            {
            //                mP_bunho = outputList[0].ToString();
            //                if(mP_bunho == "")
            //                {
            //                    XMessageBox.Show(Service.ErrFullMsg + " : 新しい番号生成ができません。");
            //                    return;
            //                }
            //            }

            //            string cmdText = @"INSERT INTO OUT0101(SYS_DATE
            //												 , USER_ID
            //												 , UPD_DATE
            //												 , BUNHO
            //												 , SUNAME
            //												 , SEX
            //												 , BIRTH
            //												 , SUNAME2 )
            //										   VALUES( SYSDATE
            //												 , :f_user_id
            //												 , SYSDATE
            //												 , :f_bunho
            //												 , :f_suname
            //												 , :f_sex
            //												 , :f_birth    
            //												 , :f_suname2 )";

            //            BindVarCollection bindVars = new BindVarCollection();
            //            bindVars.Add("f_user_id", UserInfo.UserID);
            //            bindVars.Add("f_bunho"  , mP_bunho);
            //            bindVars.Add("f_suname" , aSuname);
            //            bindVars.Add("f_sex"    , aSex);
            //            bindVars.Add("f_birth"  , aBirth);
            //            bindVars.Add("f_suname2", aSuname2);

            //            bool retTF = Service.ExecuteNonQuery(cmdText, bindVars);
            //            if(!retTF)
            //            {
            //                this.mbxMsg = Service.ErrFullMsg;

            //                XMessageBox.Show(this.mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //                return;
            //            }

            //            this.fbxBunho.SetDataValue(mP_bunho);
            //            this.grdPatient.SetItemValue(this.grdPatient.CurrentRowNumber, "bunho", mP_bunho);

            //            // 환자번호 땄다고 봄
            //            this.SetToGetBunhoVariable(true);

        }

        #endregion

        #region 특기사항

        private void LoadOUT0106()
        {
            this.grdComment.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdComment.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());

            if (!this.grdComment.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg + " : grdComment Query Error");
                return;
            }
        }

        #endregion

        #endregion

        #region XTextBox

        #region Suname (한자 성명 관련)

        #region CompositionCompleted

        /// <summary>
        /// 한자 입력시 가나 자동 셋팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSuName_CompositionCompleted(object sender, IHIS.Framework.CompositionEventArgs e)
        {
            this.mAutoSuname2 += e.ResultReadString;
        }

        #endregion

        #region Validating

        /// <summary>
        /// 데이터 벨리데이팅
        /// -- 중복체크 등등
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSuName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                this.txtSuName2.SetDataValue("");
                return;
            }

            if (this.mAutoSuname2 != "")
            {
                PostCallHelper.PostCall(new PostMethodStr(PostValidatingSuname), this.mAutoSuname2);

                this.mAutoSuname2 = "";
            }
        }

        private void PostValidatingSuname(string aSuname2)
        {
            this.txtSuName2.SetEditValue(aSuname2);
            this.txtSuName2.AcceptData();
        }

        #endregion

        #endregion

        #region Suname2 (환자 가나 성명)

        /// <summary>
        /// 벨리데이팅 
        /// -- 중복환자 체킹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSuName2_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            // 조회해온 데이터가 아니고
            // 가나성명, 생일, 성별이 입력되면 새로운 번호 부여 로직을 태운다.
            if (this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "retrieve_yn") != "Y")
            {
                if (e.DataValue != "" &&
                    this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "birth") != "" &&
                    this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "sex") != "")
                {
                    this.LoadNewBunho(e.DataValue
                        , this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "birth")
                        , this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "sex")
                        , this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname"));
                }
            }
        }

        #endregion

        #region 우편번호 ( 직장 포함 )

        #region Validating

        /// <summary>
        /// 우편번호 Validating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtZip_Code2_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            string name = "";

            if (e.DataValue == "")
            {
                this.fbxAddress1.SetEditValue("");
                this.fbxAddress1.AcceptData();

                this.SetMsg("");

                return;
            }

            name = NURO.Methodes.GetZipName(this.fbxZip_Code1.GetDataValue(), e.DataValue);

            if (name == "")
            {
                this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox15_Ko : Resources.XMessageBox15_Jp);

                this.SetMsg(this.mbxMsg, MsgType.Error);

                e.Cancel = true;

                return;
            }
            else
            {
                this.fbxAddress1.SetEditValue(name);
                this.fbxAddress1.AcceptData();

                this.SetMsg("");
            }
        }


        #endregion

        #endregion

        #region 공비의 부담자 번호

        private void txtBudamja_Bunho_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //string gongbiCode = "";
            //string errFlag = "";

            if (e.DataValue == "")
            {
                return;
            }

            string law_no = ""; //bas0212 로우넘버(== 법별 번호)

            if (e.DataValue.Length >= 2)
            {
                law_no = e.DataValue.Substring(0, 2);

                //                string cmdText = @"SELECT GONGBI_CODE
                //                                      FROM BAS0212
                //                                     WHERE HOSP_CODE = :f_hosp_code
                //                                       AND LAW_NO    = :f_law_no
                //                                       AND SYSDATE BETWEEN START_DATE AND END_DATE";
                //                BindVarCollection bc = new BindVarCollection();
                //                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                //                bc.Add("f_law_no", law_no);

                NuroOUT0101U02GetInsuranceArgs argsCode = new NuroOUT0101U02GetInsuranceArgs();
                argsCode.LawNo = law_no;

                NuroOUT0101U02GetInsuranceResult result = CloudService.Instance.
                    Submit<NuroOUT0101U02GetInsuranceResult, NuroOUT0101U02GetInsuranceArgs>(argsCode);

                if (!TypeCheck.IsNull(result.InsuranceCodeItem) && result.InsuranceCodeItem.Count > 0)
                {
                    this.fbxGongbi_Code.SetEditValue(result.InsuranceCodeItem[0].InsuranceCode.ToString());
                    this.fbxGongbi_Code.AcceptData();
                }
                //object gongbi_code = Service.ExecuteScalar(cmdText, bc);

                //if (!TypeCheck.IsNull(gongbi_code))
                //{
                //    this.fbxGongbi_Code.SetEditValue(gongbi_code.ToString());
                //    this.fbxGongbi_Code.AcceptData();
                //}
            }

            /* 추후 추가
             * 
             * 부담자 번홀 앞 2자리 잘라서 bas0212 로우넘버(== 법별 번호)가튼 것을 기본으로 셋팅 .
             * 없으면 말고 
             * 
            //부담자번호로 공비코드 받아오기
			BizObj.CheckGongbiBudamja(e.DataValue, ref gongbiCode, ref errFlag );

			if (errFlag != "")
			{
				this.mbxCap = (NetInfo.Language == LangMode.Ko ? "부담자번호" : "負担者番号");

				XMessageBox.Show(errFlag, mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			this.fbxGongbi_Code.SetEditValue(gongbiCode);
			this.fbxGongbi_Code.AcceptData();
            */
        }

        #endregion

        #endregion

        #region XDataPicker

        /// <summary>
        /// 생년월일
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpBirth_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            string age = "";

            if (e.DataValue == "")
            {
                return;
            }

            string aSysDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            //if ((int.Parse(e.DataValue.Replace("/", ""))) > (int.Parse(aSysDate.Trim().Replace("/", ""))))
            //{
            //    mbxMsg = "今日以前の日付を入力してください。";
            //    XMessageBox.Show(mbxMsg, "確認", MessageBoxIcon.Exclamation);
            //    return;
            //}

            //단순 나이 계산
            //string cmdText = @"SELECT FN_BAS_LOAD_AGE(:f_sys_date, :f_birth, ' ') FROM DUAL";
            //BindVarCollection bc = new BindVarCollection();
            //bc.Add("f_sys_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            //bc.Add("f_birth", e.DataValue);

            NuroOUT0101U02GetBirthDayArgs args = new NuroOUT0101U02GetBirthDayArgs();
            args.Birth = e.DataValue;
            args.SysDate = aSysDate;

            NuroOUT0101U02GetBirthDayResult result =
                CloudService.Instance.Submit<NuroOUT0101U02GetBirthDayResult, NuroOUT0101U02GetBirthDayArgs>(args);

            if (!TypeCheck.IsNull(result.BirthDay))
                age = result.BirthDay.ToString();

            //object retVal = Service.ExecuteScalar(cmdText, bc);

            //if (!TypeCheck.IsNull(retVal))
            //    age = retVal.ToString();

            //this.mcomlib.LOAD_SEX_AGE(this.fbxBunho.GetDataValue(), OUT.GetName.GetSysDate().Replace("-", "/"), ref age, ref dummy, ref dummy, ref dummy );

            this.dbxAge.SetDataValue(age);

            // 조회해온 데이터가 아니고
            // 가나성명, 생일, 성별이 입력되면 새로운 번호 부여 로직을 태운다.
            if (this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "retrieve_yn") != "Y")
            {
                if (this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname2") != "" &&
                    e.DataValue != "" &&
                    this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "sex") != "")
                {
                    this.LoadNewBunho(this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname2")
                        , e.DataValue
                        , this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "sex")
                        , this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname"));
                }
            }
        }

        #endregion

        #region XComboBox

        /// <summary>
        /// 성별 콤보
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSex_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            // 조회해온 데이터가 아니고
            // 가나성명, 생일, 성별이 입력되면 새로운 번호 부여 로직을 태운다.
            if (this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "retrieve_yn") != "Y")
            {
                if (this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname") != "" &&
                    this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname2") != "" &&
                    this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "birth") != "" &&
                    e.DataValue != "")
                {
                    this.LoadNewBunho(this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname2")
                        , this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "birth")
                        , e.DataValue
                        , this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname"));
                }
            }
        }

        #endregion

        #region XFindBox

        #region 우편번호 관련

        /// <summary>
        /// 우편번호 일부 입력후 파인드 클릭 하는 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fbxZipCode_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.mCallControl = ((XFindBox)sender).Name;

            string zipCode1 = "";
            string zipCode2 = "";
            string address1 = "";

            switch (this.mCallControl)
            {
                case "fbxZip_Code1":

                    zipCode1 = this.fbxZip_Code1.GetDataValue();
                    zipCode2 = this.txtZip_Code2.GetDataValue();
                    address1 = this.fbxAddress1.GetDataValue();

                    break;
            }

            this.OpenScreen_BAS0123Q00("zipCode", zipCode1, zipCode2, address1);
        }

        /// <summary>
        /// 동이름 일부 입력후 파인드 클릭 하는 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fbxAddress_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.mCallControl = ((XFindBox)sender).Name;

            string zipCode1 = "";
            string zipCode2 = "";
            string address1 = "";

            switch (this.mCallControl)
            {
                case "fbxAddress1":

                    zipCode1 = this.fbxZip_Code1.GetDataValue();
                    zipCode2 = this.txtZip_Code2.GetDataValue();
                    address1 = this.fbxAddress1.GetDataValue();

                    break;
            }

            this.OpenScreen_BAS0123Q00("address", zipCode1, zipCode2, address1);
        }

        #endregion

        #region 환자번호 파인드

        /// <summary>
        /// 환자번호 파인드 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fbxBunho_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.OpenScreen_OUT0101Q01();
        }

        #endregion

        #region FindBox_FindClick
        /// <summary>
        /// XFindBox FindClick 공통 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XFindBox control = sender as XFindBox;

            switch (control.Name)
            {
                case "fbxJohap":

                    #region 보험자번호

                    this.OpenScreen_BAS0110Q00();

                    #endregion

                    break;

                case "fbxGubun1":

                    #region 보험종류

                    //this.fbxGubun1.FindWorker = WON.ComFind.GetFindGubunBAS0210(false, EnvironInfo.GetSysDate());
                    this.fwkCommon.AutoQuery = true;
                    this.fwkCommon.ServerFilter = true;


                    //TODO
                    //                    this.fwkCommon.InputSQL = @"SELECT A.GUBUN
                    //                                                     , A.GUBUN_NAME
                    //                                                  FROM BAS0210 A
                    //                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                    //                                                   AND A.JOHAP_GUBUN LIKE :f_johap_gubun || '%'
                    //                                                   AND A.GUBUN       LIKE :f_find1 || '%'
                    //                                                   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND END_DATE
                    //                                                 ORDER BY A.GUBUN";




                    //List<string> param = new List<string>();
                    //param.Add("f_johap_gubun");

                    //this.fwkCommon.ParamList = param;

                    //      this.fwkCommon.BindVarList.Clear();
                    //this.fwkCommon.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                    //this.fwkCommon.BindVarList.Add("f_johap_gubun", this.mJohapGubun);

                    this.fwkCommon.ParamList = new List<string>(new String[] { "f_johap_gubun", "f_find1" });


                    //this.fwkCommon.BindVarList.Clear();
                    //this.fwkCommon.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.BindVarList.Add("f_johap_gubun", this.mJohapGubun);

                    this.fwkCommon.ExecuteQuery = GetFwkCommonGubun;


                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("gubun", Resources.gubun, FindColType.String, 120, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos.Add("gubun_name", Resources.gubun_name, FindColType.String, 200, 0, true, FilterType.InitYes);

                    #endregion

                    break;

                case "fbxGaein":

                    #region 개인 기호

                    this.fwkCommon.AutoQuery = true;
                    this.fwkCommon.ServerFilter = true;


                    //TODO
                    //                    this.fwkCommon.InputSQL = @"SELECT A.GAEIN
                    //												 FROM BAS0111 A
                    //												WHERE A.HOSP_CODE = :f_hosp_code
                    //                                                  AND A.JOHAP     = :f_johap
                    //												  AND A.GAEIN  LIKE :f_find1 || '%'
                    //												ORDER BY A.GAEIN";

                    this.fwkCommon.ParamList = new List<string>(new String[] { "f_johap", "f_find1" });

                    this.fwkCommon.BindVarList.Clear();
                    this.fwkCommon.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.BindVarList.Add("f_johap", this.grdBoheom.GetItemString(this.grdBoheom.CurrentRowNumber, "johap"));

                    this.fwkCommon.ExecuteQuery = GetFwkCommonGaein;

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("code", Resources.fbxGaeinCode, FindColType.String, 280, 0, true, FilterType.InitYes);

                    #endregion

                    break;

                case "fbxGongbi_Code":

                    #region 공비 코드

                    //this.fbxGongbi_Code.FindWorker = WON.ComFind.GetFindGongbiBAS0212(EnvironInfo.GetSysDate());
                    this.fwkCommon.AutoQuery = true;
                    this.fwkCommon.ServerFilter = true;

                    //TODO
                    //                    this.fwkCommon.InputSQL = @"SELECT GONGBI_CODE
                    //                                                     , GONGBI_NAME
                    //                                                  FROM BAS0212
                    //                                                 WHERE HOSP_CODE = :f_hosp_code
                    //                                                   AND GONGBI_CODE  LIKE :f_find1 || '%'
                    //                                                   AND TRUNC(SYSDATE) BETWEEN START_DATE AND END_DATE";

                    //    this.fwkCommon.BindVarList.Clear();
                    //this.fwkCommon.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                    this.fwkCommon.ParamList = new List<string>(new String[] { "f_find1" });

                    this.fwkCommon.ExecuteQuery = GetFwkCommonGongbiCode;

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("gongbi_code", Resources.gongbi_code, FindColType.String, 120, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos.Add("gongbi_name", Resources.gongbi_name, FindColType.String, 280, 0, true, FilterType.InitYes);


                    #endregion

                    break;
            }
        }

        #endregion

        #region XFindValidating

        /// <summary>
        /// 파인드 박스 공통 데이터 벨리데이팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindBox_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            XFindBox control = sender as XFindBox;

            string name = "";
            //string cmdText = "";
            BindVarCollection bc = new BindVarCollection();
            object retVal = null;
            this.SetMsg("");

            switch (control.Name)
            {
                case "fbxBunho":
  
                    #region 환자번호

                    if (e.DataValue == "")
                    {
                        //this.btnList.PerformClick(FunctionType.Reset);

                        return;
                    }

                    string bunho = e.DataValue;

                    bunho = BizCodeHelper.GetStandardBunHo(bunho);

                    //this.LoadPatient(bunho);

                    PostCallHelper.PostCall(new PostMethodStr(PostBunhoValidating), bunho);

                    #endregion

                    break;

                case "fbxGubun1":

                    #region 보험종류

                    if (e.DataValue == "")
                    {
                        this.dbxGubun_Name1.SetDataValue("");
                        this.grdBoheom.SetItemValue(this.grdBoheom.CurrentRowNumber, "gubun_name1", "");

                        return;
                    }

                    //                    cmdText = @"SELECT A.GUBUN_NAME
                    //                                  FROM BAS0210 A
                    //                                 WHERE A.HOSP_CODE   = :f_hosp_code
                    //                                   AND A.GUBUN       = :f_gubun
                    //                                   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND END_DATE";
                    //                    bc.Clear();
                    //                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
                    //                    bc.Add("f_gubun", e.DataValue);

                    //                    retVal = Service.ExecuteScalar(cmdText, bc);

                    NuroOUT0101U02GetTypeNameArgs args = new NuroOUT0101U02GetTypeNameArgs();
                    args.TypeCode = e.DataValue;

                    NuroOUT0101U02GetTypeNameResult result = CloudService.Instance
                        .Submit<NuroOUT0101U02GetTypeNameResult, NuroOUT0101U02GetTypeNameArgs>(args);

                    retVal = result.TypeName;
                    if (TypeCheck.IsNull(retVal))
                    {
                        this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "보험종류를 확인하세요." : "保険種類が有効ではありません。ご確認ください。");

                        this.SetMsg(this.mbxMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }
                    else
                    {
                        name = retVal.ToString();

                        this.dbxGubun_Name1.SetDataValue(name);
                        this.grdBoheom.SetItemValue(this.grdBoheom.CurrentRowNumber, "gubun_name1", name);

                        //this.Control_Protect(e.DataValue);
                    }

                    #endregion

                    break;

                case "fbxGaein":

                    #region 개인기호

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");
                        return;
                    }

                    //name = BizObj.GetGaein(this.grdBoheom.GetItemString(this.grdBoheom.CurrentRowNumber, "johap"), e.DataValue);

                    //                    cmdText = @"SELECT A.GAEIN
                    //                                 FROM BAS0111 A
                    //                                WHERE A.HOSP_CODE = :f_hosp_code
                    //                                  AND A.JOHAP     = :f_johap
                    //                                  AND A.GAEIN     = :f_gaein";

                    //                    bc.Clear();
                    //                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
                    //                    bc.Add("f_johap", this.grdBoheom.GetItemString(this.grdBoheom.CurrentRowNumber, "johap"));
                    //                    bc.Add("f_gaein", e.DataValue);

                    //                    retVal = Service.ExecuteScalar(cmdText, bc);


                    NuroNuroOUT0101U02GetGaeinArgs argsGaein = new NuroNuroOUT0101U02GetGaeinArgs();
                    argsGaein.Johap = this.grdBoheom.GetItemString(this.grdBoheom.CurrentRowNumber, "johap");
                    argsGaein.Gaein = e.DataValue;


                    NuroNuroOUT0101U02GetGaeinResult resultGaein = CloudService.Instance
                        .Submit<NuroNuroOUT0101U02GetGaeinResult, NuroNuroOUT0101U02GetGaeinArgs>(argsGaein);

                    retVal = resultGaein.GaeinList;

                    if (TypeCheck.IsNull(resultGaein.GaeinList) || resultGaein.GaeinList.Count == 0 || TypeCheck.IsNull(resultGaein.GaeinList[0].DataValue))
                    {
                        this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "기호가 정확하지않습니다. 확인바랍니다." : "記号が有効ではありません。ご確認ください。");

                        this.SetMsg(this.mbxMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }
                    else
                    {
                        this.SetMsg("");
                    }

                    #endregion

                    break;

                case "fbxGongbi_Code":

                    #region 공비코드

                    if (e.DataValue == "")
                    {
                        this.dbxGongbi_Name.SetDataValue("");
                        this.grdGongbiList.SetItemValue(this.grdGongbiList.CurrentRowNumber, "gongbi_name", "");
                        this.SetMsg("");
                        return;
                    }

                    //name = WON.BizObj.GetGongbiNameBAS0212(e.DataValue, EnvironInfo.GetSysDate());

                    //                    cmdText = @"SELECT GONGBI_NAME
                    //                                  FROM BAS0212
                    //                                 WHERE HOSP_CODE   = :f_hosp_code
                    //                                   AND GONGBI_CODE = :f_gongbi_code
                    //                                   AND TRUNC(SYSDATE) BETWEEN START_DATE AND END_DATE ";
                    //                    bc.Clear();
                    //                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
                    //                    bc.Add("f_gongbi_code", e.DataValue);

                    //                    retVal = Service.ExecuteScalar(cmdText, bc);

                    NuroOUT0101U02GetInsuranceNameArgs argsInsurance = new NuroOUT0101U02GetInsuranceNameArgs();

                    //TODO
                    argsInsurance.GongbiCode = e.DataValue;
                    //argsInsurance.GongbiCode = "010";
                    NuroOUT0101U02GetInsuranceNameResult resultInsurance = CloudService.Instance
                        .Submit<NuroOUT0101U02GetInsuranceNameResult, NuroOUT0101U02GetInsuranceNameArgs>(argsInsurance);

                    if (resultInsurance.ExecutionStatus == ExecutionStatus.Success)
                    {
                        retVal = resultInsurance.GongbiName;

                        if (TypeCheck.IsNull(retVal))
                        {
                            this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "공비코드가 정확하지않습니다. 확인바랍니다." : "公費コードが有効ではありません。ご確認ください。");

                            this.SetMsg(this.mbxMsg, MsgType.Error);

                            fbxGongbi_Code.Focus();
                            e.Cancel = true;

                            return;
                        }
                        else
                        {
                            name = retVal.ToString();
                            this.dbxGongbi_Name.SetDataValue(name);
                            this.grdGongbiList.SetItemValue(this.grdGongbiList.CurrentRowNumber, "gongbi_name", name);

                            this.SetMsg("");
                        }
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_001);
                        fbxGongbi_Code.Focus();
                        e.Cancel = true;
                        return;
                    }



                    #endregion

                    break;
            }
        }

        /// <summary>
        /// 보험자번호 데이터 벨리데이팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fbxJohap_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            string name = "";
            //string gubun = "";
            //string errFlag = "";
            //string cmdText = "";

            this.mJohapGubun = "";

            if (e.DataValue == "")
            {
                this.dbxJohap_Name.SetDataValue("");
                this.grdBoheom.SetItemValue(this.grdBoheom.CurrentRowNumber, "johap_name", "");

                return;
            }

            //            cmdText = @"SELECT A.JOHAP_NAME         JOHAP_NAME
            //                             , A.JOHAP_GUBUN        JOHAP_GUBUN
            //                             --, FN_BAS_LOAD_CODE_NAME('JOHAP_GUBUN', A.JOHAP_GUBUN)
            //                          FROM BAS0110 A
            //                         WHERE A.HOSP_CODE = :f_hosp_code
            //                           AND A.JOHAP     = :f_johap
            //                           AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
            //                           AND A.JOHAP_GUBUN <> 'XX' 
            //                           AND A.START_DATE = (SELECT MAX(Z.START_DATE)
            //                                                 FROM BAS0110 Z
            //                                                WHERE Z.HOSP_CODE = A.HOSP_CODE
            //                                                  AND Z.JOHAP     = A.JOHAP
            //                                                  AND Z.JOHAP_GUBUN <> 'XX'  
            //                                                  --AND Z.START_DATE <= TO_DATE(:f_date, 'YYYY/MM/DD')
            //                                                    )";

            //            BindVarCollection bc = new BindVarCollection();
            //            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            //            bc.Add("f_johap", e.DataValue);
            //            bc.Add("f_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            //            DataTable dt = Service.ExecuteDataTable(cmdText, bc);

            //            if(TypeCheck.IsNull(dt))
            //            {
            //                this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox16_Ko : Resources.XMessageBox16_Jp);

            //                this.SetMsg(this.mbxMsg, MsgType.Error);
            //                e.Cancel = true;
            //                return;
            //            }

            NuroOUT0101U02GetJohapArgs argsJohap = new NuroOUT0101U02GetJohapArgs();
            argsJohap.Date = ""; // system date gets by server
            argsJohap.Johap = e.DataValue;

            NuroOUT0101U02GetJohapResult resultJohap = CloudService.Instance
                .Submit<NuroOUT0101U02GetJohapResult, NuroOUT0101U02GetJohapArgs>(argsJohap);

            if (resultJohap.ExecutionStatus == ExecutionStatus.Success && resultJohap.JohapItem.Count > 0)
            {
                this.mJohapGubun = resultJohap.JohapItem[0].JohapGubun;
                name = resultJohap.JohapItem[0].JohapName;

                this.dbxJohap_Name.SetDataValue(name);
                this.grdBoheom.SetItemValue(this.grdBoheom.CurrentRowNumber, "johap_name", name);
            }
            else
            {
                XMessageBox.Show(Resources.MSG_001);
                fbxJohap.Focus();
                e.Cancel = true;
                return;
            }

            //this.mJohapGubun = dt.Rows[0]["johap_gubun"].ToString();
            //name = dt.Rows[0]["johap_name"].ToString();

            //this.fbxGubun1.SetEditValue(this.mJohapGubun);
            //this.fbxGubun1.AcceptData();

            //dt.Dispose();
        }

        #endregion

        #endregion

        #region Command

        string mJohapGubun = ""; //보험 선택시 보험종별 조회위한 구분. 국보,사보등등
        public override object Command(string command, CommonItemCollection commandParam)
        {
            PostCallHelper.PostCall(new PostMethodStr(PostCallCommand), command);

            switch (command)
            {
                case "BAS0123Q00":

                    #region 우편번호

                    //if (this.mCallControl == "fbxZip_Code1" )
                    //{
                    this.fbxZip_Code1.SetDataValue(commandParam["zip_code1"]);
                    this.txtZip_Code2.SetDataValue(commandParam["zip_code2"]);
                    this.fbxAddress1.SetEditValue(commandParam["address"]);
                    this.fbxAddress1.AcceptData();
                    this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "zip_code1", commandParam["zip_code1"]);
                    this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "zip_code2", commandParam["zip_code2"]);

                    this.txtAddress2.Focus();
                    //}

                    this.mCallControl = "";

                    #endregion

                    break;

                case "OUT0101":

                    #region 환자검색후

                    try
                    {
                        this.fbxBunho.SetEditValue(((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["bunho"]);
                        this.fbxBunho.AcceptData();
                    }
                    catch
                    {
                    }

                    #endregion

                    break;

                case "BAS0110Q00":

                    #region 보험자번호

                    if (commandParam != null && commandParam.Contains("BAS0110"))
                    {
                        //this.mJohapGubun = ((MultiLayout)commandParam["BAS0110"]).GetItemString(0,"johap_gubun");
                        this.fbxJohap.SetEditValue(((MultiLayout)commandParam["BAS0110"]).GetItemString(0, "johap"));
                        this.fbxJohap.AcceptData();
                    }

                    #endregion

                    break;

            }

            return base.Command(command, commandParam);
        }


        #endregion

        #region XEditGrid

        #region 환자정보 그리드

        /// <summary>
        /// 환자정보 그리드 로우 포커스 체인지 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPatient_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (this.grdPatient.GetItemString(e.CurrentRow, "retrieve_yn") == "Y")
            {
                this.ProtectPatientInfo(false, false);
            }
            else
            {
                this.ProtectPatientInfo(false, true);
            }
        }

        #endregion

        #region 보험정보 그리드

        /// <summary>
        /// 보험정보 그리드 로우 포커스 체인지 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdBoheom_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (this.grdBoheom.GetItemString(e.CurrentRow, "retrieve_yn") == "Y")
            {
                this.ProtectBoheomInfo(false, false);
            }
            else
            {
                this.ProtectBoheomInfo(false, true);
            }
        }

        /// <summary>
        /// 포커스 엔터
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdBoheom_Enter(object sender, System.EventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            PostCallHelper.PostCall(new PostMethodStr(PostCallGridEnter), grd.Name);
        }

        /// <summary>
        /// 셀 페인팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdBoheom_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            //if (this.IsEndedGubun( grd, e.RowNumber) == true)
            //{
            //    e.ForeColor = Color.Red;
            //}
            if (e.DataRow["end_yn"].ToString() == "Y")
            {
                e.ForeColor = Color.Red;
            }

        }

        #endregion

        #region 공비정보 그리드

        /// <summary>
        /// 공비정보 그리드 로우 포커스 체인지 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdGongbiList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (this.grdGongbiList.GetItemString(e.CurrentRow, "retrieve_yn") == "Y")
            {
                this.ProtectGongbiInfo(false, false);
            }
            else
            {
                this.ProtectGongbiInfo(false, true);
            }
        }

        /// <summary>
        /// 공비정보 그리드 포커스 엔터
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdGongbiList_Enter(object sender, System.EventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            PostCallHelper.PostCall(new PostMethodStr(PostCallGridEnter), grd.Name);
        }

        #endregion

        #endregion

        #region Save

        private bool _concurrentFlg = false;
        private void Save()
        {

            if (UserInfo.OrcaIp != string.Empty && (grdBoheom.DeletedRowCount > 0 || grdGongbiList.DeletedRowCount > 0))
            {
                XMessageBox.Show(Resources.CAN_NOT_DELETE_INSURANCE_MGS, Resources.CAP_002, MessageBoxIcon.Warning);

                this.LoadBoheom();
                this.LoadGongbiInfo();
                return;
            }
            rowState = "";
            OUT0101U02SaveGridResult res = this.SaveGridData();
            if (!res.Result && res.ErrCode == "2")
            {
                mIsSaveSuccess = false;
                XMessageBox.Show(Resources.BUNHO_EXISTS, Resources.CAP_003, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fbxBunho.Enabled = true;
                fbxBunho.Protect = false;
                genPatCodeBtn.Enabled = true;
                fbxBunho.Focus();
                this._concurrentFlg = true;
                return;
            }
            if (!res.Result)
            {
                mIsSaveSuccess = false;
                XMessageBox.Show(Resources.XMessageBox17 + Service.ErrFullMsg, Resources.Caption17, MessageBoxIcon.Error);
                return;
            }

            this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox18_Ko : Resources.XMessageBox18_Jp);
            this.mbxCap = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox19_Ko : Resources.XMessageBox19_Jp);

            XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (fbxBunho.GetDataValue().Contains("*"))
            {
                this.fbxBunho.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
                fbxBunho.SetEditValue(res.NewPatientCode);
                fbxBunho.AcceptData();
                this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            }
            this.btnList.PerformClick(FunctionType.Query);

            // 저장후 로직 => 창을 연다든지.. 뭔가 자동으로 저장후 하는 것들 여기다 추가
            this.AfterUpdate();

            // https://sofiamedix.atlassian.net/browse/MED-13865
            this._concurrentFlg = false;
        }

        #endregion

        #region XButtonList
        private bool mIsSaveSuccess = true;
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            //OpenFormExportPatient();
            switch (e.Func)
            {
                case FunctionType.Query:

                    #region 조회

                    e.IsBaseCall = false;

                    // cloud
                    this.gridViewResult = this.GetGridViewResult(this.fbxBunho.GetDataValue());

                    this.grdPatient.ExecuteQuery = GridPatientList;
                    this.grdBoheom.ExecuteQuery = GridBoheom;
                    this.grdGongbiList.ExecuteQuery = GridGongbiList;
                    this.grdComment.ExecuteQuery = GridCommentList;

                    this.LoadPatient(this.fbxBunho.GetDataValue());

                    this.LoadBoheom();

                    this.LoadGongbiInfo();

                    this.LoadOUT0106();
                    if (String.IsNullOrEmpty(fbxBunho.Text))
                    {
                        loadDefaultCombo();
                    }

                    #endregion

                    break;

                case FunctionType.Insert:

                    #region 입력

                    e.IsBaseCall = false;

                    if (this.CurrMSLayout == this.grdBoheom)
                    {
                        if (this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho") == "")
                        {
                            this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "먼저 환자번호를 입력하시기 바랍니다." : "先に患者番号を入力してください。");

                            XMessageBox.Show(this.mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.fbxBunho.Focus();

                            return;
                        }

                        this.grdBoheom.InsertRow(-1);
                        this.SetDefaultValueToBoheom();

                        // 새로운 행 입력후 포커스는 입력할수 있는 컨트롤로
                        this.fbxJohap.Focus();
                    }
                    else if (this.CurrMSLayout == this.grdGongbiList)
                    {
                        if (this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho") == "")
                        {
                            this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "먼저 환자번호를 입력하시기 바랍니다." : "先に患者番号を入力してください。");

                            XMessageBox.Show(this.mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.fbxBunho.Focus();

                            return;
                        }

                        this.grdGongbiList.InsertRow(-1);
                        this.SetDefaultValueToGongbi();

                        // 새로운 행 입력후 포커스는 입력할수 있는 컨트롤로
                        this.txtBudamja_Bunho.Focus();
                    }

                    #endregion

                    break;

                case FunctionType.Update:

                    #region 저장

                    this.AcceptData();
                    mIsSaveSuccess = true;
                    e.IsBaseCall = false;
                    
                    if (TypeCheck.IsNull(this.grdPatient.GetItemString(grdPatient.CurrentRowNumber, "bunho")))
                    {
                        this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "bunho", this._bunho);
                    }
                    //https://sofiamedix.atlassian.net/browse/MED-11588
                    if (NetInfo.Language == LangMode.Vi)
                    {
                        if (String.IsNullOrEmpty(cbxBilling.GetDataValue()))
                        {
                            XMessageBox.Show(Resources.CheckBillingType, Resources.caption24_Jp, MessageBoxIcon.Warning);
                            cbxBilling.Focus();
                            return;
                        }
                    }

                    // // https://sofiamedix.atlassian.net/browse/MED-13859 (removed logic check iu_gubun)
                    //https://sofiamedix.atlassian.net/browse/MED-12535
                    //if (this.grdPatient.GetItemString(grdPatient.CurrentRowNumber, "iu_gubun") == "I" && !String.IsNullOrEmpty(UserInfo.OrcaIp))
                    if (!String.IsNullOrEmpty(UserInfo.OrcaIp))
                    {
                        if (!String.IsNullOrEmpty(cboBunhoType.GetDataValue()) && cboBunhoType.GetDataValue() != "0")
                        {
                            XMessageBox.Show(Resources.MSG_ORCA, Resources.MSG_ORCA_CAP, MessageBoxIcon.Warning);
                        }
                    }

                    if (this.CheckOUT0101() == true &&
                        this.CheckOUT0102() == true &&
                        this.CheckOUT0105() == true)
                    {
                        this.Save();
                    }
                    else
                    {
                        mIsSaveSuccess = false;
                    }

                    #endregion

                    break;
                case FunctionType.Delete:

                    if (this.CurrMQLayout == this.grdComment)
                    {
                        e.IsBaseCall = false;
                        return;
                    }
                    break;
                case FunctionType.Reset:
                    // https://sofiamedix.atlassian.net/browse/MED-15783
                    // This will be re-register in PostButtonClick event
                    cbxAutoOpen.CheckStateChanged -= new EventHandler(cbxAutoOpen_CheckStateChanged);
                    break;
            }
        }

        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Reset:

                    // https://sofiamedix.atlassian.net/browse/MED-15783
                    cbxAutoOpen.CheckStateChanged += new EventHandler(cbxAutoOpen_CheckStateChanged);
                    cbxAutoOpen.Checked = (bool)CacheService.Instance.Get(OUT0101U02_AUTO_OPEN, true);

                    // https://sofiamedix.atlassian.net/browse/MED-13764
                    string preBunho = grdPatient.GetItemString(grdPatient.CurrentRowNumber, "bunho");

                    if (_bunhoInputType == BunhoInputType.AutoGen)
                    {
                        this.genPatCodeBtn.Enabled = true;
                        btnConfirm.Enabled = false;
                    }
                    this.InitScreen();

                    // https://sofiamedix.atlassian.net/browse/MED-13764
                    if (_bunhoInputType == BunhoInputType.AutoGen && !TypeCheck.IsNull(this._bunho))
                    {
                        OUT1001R01LayOut0101Args args = new OUT1001R01LayOut0101Args();
                        args.Bunho = this._bunho;
                        OUT1001R01LayOut0101Result res = CloudService.Instance.Submit<OUT1001R01LayOut0101Result, OUT1001R01LayOut0101Args>(args);

                        if (res.ExecutionStatus == ExecutionStatus.Success && res.LayoutList.Count == 0)
                        {
                            // Patient does not exist
                            this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "iu_gubun", "I");
                            this.fbxBunho.SetDataValue(this._bunho); //위에서 환자번호 날라가니까 여기서 다시 셋팅
                            this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "bunho", this._bunho); //위에서 환자번호 날라가니까 여기서 다시 셋팅
                            //this.genPatCodeBtn.Enabled = false;
                            //this.fbxBunho.Enabled = false;
                        }
                    }

                    PostCallHelper.PostCall(new PostMethod(PostInitScreen));
                    if (String.IsNullOrEmpty(fbxBunho.Text))
                    {
                        loadDefaultCombo();                        
                    }
                    // https://sofiamedix.atlassian.net/browse/MED-13865
                    this._concurrentFlg = false;

                    break;
            }
        }

        #endregion

        #region XButton

        /// <summary>
        /// 기호 등록 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBAS0111U00_Click(object sender, System.EventArgs e)
        {
            if (this.grdBoheom.RowCount > 0)
            {
                this.OpenScreen_BAS0111U00();
            }
        }

        /// <summary>
        /// 특기사항 등록 창
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOUT0106U00_Click(object sender, System.EventArgs e)
        {
            if (this.grdPatient.RowCount > 0 &&
                this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "bunho") != "")
            {
                this.OpenScreen_OUT0106U00();
                this.grdComment.ExecuteQuery = GridCommentListSingleConnection;
                this.LoadOUT0106();
            }
        }

        #endregion

        #region Check Vi Lang
        private bool IsVi()
        {
            return NetInfo.Language == LangMode.Vi;
        }
        #endregion

        #region 도킹화면에서 환자번호 받기
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            fbxBunho.SetEditValue(info.BunHo);
            fbxBunho.AcceptData();
            base.OnReceiveBunHo(info);
        }
        #endregion

        #region 사용자 변경

        private void OUT0101U02_UserChanged(object sender, System.EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Reset);
        }

        #endregion

        #region 현Screen의 등록번호,성명,부서,병동 스크린명를 타Screen에 넘긴다
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(fbxBunho.GetDataValue()))
                return new XPatientInfo(fbxBunho.GetDataValue().ToString(), txtSuName.GetDataValue().ToString(), "", "", this.Name);
            return base.OnRequestBunHo();
        }
        #endregion

        #region XCheckBox

        /// <summary>
        /// 보험 최종 확인일
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxLast_Check_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.cbxLast_Check.Checked == true)
            {
                this.dtpLast_Check_Date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                this.dtpLast_Check_Date.AcceptData();
            }
        }

        /// <summary>
        /// 공비 최종 확인일
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxLast_Check1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.cbxLast_Check1.Checked == true)
            {
                this.dtpLast_Check_Date2.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                this.dtpLast_Check_Date2.AcceptData();
            }
        }

        #endregion

        #region PostCallMethod

        /// <summary>
        /// 화면 로드후
        /// </summary>
        private void PostInitScreen()
        {
            this.fbxBunho.Focus();
            
        }

        /// <summary>
        /// Command 호출후 포커스 이동등..
        /// </summary>
        /// <param name="aScreenName"></param>
        private void PostCallCommand(string aScreenName)
        {
            switch (aScreenName)
            {
                case "BAS0110Q00":

                    this.fbxGubun1.Focus();

                    break;
            }
        }

        private void PostCallGridEnter(string aGridName)
        {
            switch (aGridName)
            {
                case "grdBoheom":

                    if (this.grdBoheom.RowCount == 0)
                    {
                        this.btnList.PerformClick(FunctionType.Insert);
                    }

                    break;

                case "grdGongbiList":

                    if (this.grdGongbiList.RowCount == 0)
                    {
                        this.btnList.PerformClick(FunctionType.Insert);
                    }

                    break;
            }
        }

        private void PostBunhoValidating(string aBunho)
        {
            // 환자번호 
            this.fbxBunho.SetDataValue(aBunho);

            if (!this._concurrentFlg)
            {
                this.btnList.PerformClick(FunctionType.Query);

                if (this.grdPatient.RowCount <= 0)
                {
                    // Updated by Cloud
                    if (_bunhoInputType == BunhoInputType.AutoGen)
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-13764
                        if (XMessageBox.Show(Resources.MSG_CONFIRM_AUTO_GEN, Resources.caption24_Jp, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        {
                            this.fbxBunho.ResetData();                            
                            return;
                        }

                        //XMessageBox.Show(Resources.BUNHO_NOT_EXIST_MSG);
                        //fbxBunho.Clear();
                        //fbxBunho.Focus();
                        GetBunhoInputType(true);
                        this.AutogenBunho();
                        // Disable this button
                        genPatCodeBtn.Enabled = false;
                        btnConfirm.Enabled = true;
                        // Focus to name textbox
                        txtSuName.Focus();
                        return;
                    }

                    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox20_Ko : Resources.XMessageBox20_Jp);
                    this.mbxCap = (NetInfo.Language == LangMode.Ko ? Resources.BUNHO_TEXT : Resources.caption20);

                    DialogResult result = XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // 기본값 셋팅
                        this.SetDefaultValueToPatient();

                        // 환자번호 땄다고 봄
                        this.SetToGetBunhoVariable(true);
                        // 업데이트 구분 'I'로 변경
                        this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "iu_gubun", "I");
                        this.fbxBunho.SetDataValue(aBunho); //위에서 환자번호 날라가니까 여기서 다시 셋팅
                        this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "bunho", aBunho); //위에서 환자번호 날라가니까 여기서 다시 셋팅
                        loadDefaultCombo();                       

                    }
                    else
                    {
                        this.btnList.PerformClick(FunctionType.Reset);

                        return;
                    }
                }
                // Updated by Cloud
                else
                {
                    genPatCodeBtn.Enabled = false;
                    btnConfirm.Enabled = true;                    
                }
                if (String.IsNullOrEmpty(fbxBunho.Text))
                {
                    loadDefaultCombo();                    
                }
            }
            else // concurrency exception
            {
                OUT1001R01LayOut0101Args args = new OUT1001R01LayOut0101Args();
                args.Bunho = aBunho;
                OUT1001R01LayOut0101Result res = CloudService.Instance.Submit<OUT1001R01LayOut0101Result, OUT1001R01LayOut0101Args>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success && res.LayoutList.Count > 0)
                {
                    XMessageBox.Show(Resources.BUNHO_EXISTS, Resources.CAP_003, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "bunho", aBunho); //위에서 환자번호 날라가니까 여기서 다시 셋팅
                }
            }

            //this.txtSuName.Focus();
        }

        #endregion

        #region XDateTimePicker

        // 취득일 벨리데이팅
        private void dtpChuiduk_Date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                return;
            }

            if (this.dtpFrom_Jy_Date.GetDataValue() == "")
            {
                this.dtpFrom_Jy_Date.SetEditValue(e.DataValue);
                this.dtpFrom_Jy_Date.AcceptData();
            }
            else
            {
                DateTime fromJyDate = DateTime.Parse(this.dtpFrom_Jy_Date.GetDataValue());
                DateTime chuidukDate = DateTime.Parse(e.DataValue);

                if (fromJyDate < chuidukDate)
                {
                    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox21_Ko : Resources.XMessageBox21_Jp);

                    this.SetMsg(this.mbxMsg, MsgType.Error);

                    e.Cancel = true;
                    return;
                }
            }

            this.SetMsg("");
        }

        /// <summary>
        /// 개시일자 데이터 벨리데이팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFrom_Jy_Date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue == "" || TypeCheck.IsDateTime(e.DataValue) == false)
            {
                return;
            }


            //if (this.dtpChuiduk_Date.GetDataValue() == "")
            //{
            //    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "" : "取得日付を入力してください。");
            //    XMessageBox.Show(this.mbxMsg,"注意",MessageBoxIcon.Warning);
            //    this.dtpChuiduk_Date.Focus();
            //    return;
            //}

            // 취득일 보다 이전일자는 있을수 없지...

            if (this.dtpChuiduk_Date.GetDataValue() != "")
            {
                DateTime fromDate = DateTime.Parse(e.DataValue);
                DateTime chuidukDate = DateTime.Parse(this.dtpChuiduk_Date.GetDataValue());

                if (fromDate < chuidukDate)
                {
                    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox22_Ko : Resources.XMessageBox22_Jp);
                    this.SetMsg(this.mbxMsg, MsgType.Error);

                    e.Cancel = true;

                    return;
                }
            }

            this.SetMsg("");
        }

        private void dtpTo_Jy_Date_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "" || TypeCheck.IsDateTime(e.DataValue) == false)
            {
                return;
            }
            //if (this.dtpChuiduk_Date.GetDataValue() == "")
            //{
            //    this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "" : "取得日付を入力してください。");
            //    XMessageBox.Show(this.mbxMsg, "注意", MessageBoxIcon.Warning);
            //    this.dtpChuiduk_Date.Focus();
            //    return;
            //}

            if (this.dtpFrom_Jy_Date.GetDataValue() != "")
            {
                DateTime end_date = DateTime.Parse(e.DataValue);
                DateTime start_date = DateTime.Parse(this.dtpFrom_Jy_Date.GetDataValue());

                if (end_date < start_date)
                {
                    this.mbxMsg = Resources.XMessageBox23;
                    this.SetMsg(this.mbxMsg, MsgType.Error);

                    e.Cancel = true;

                    return;
                }
            }

            this.SetMsg("");

        }

        /// <summary>
        /// 생년월일 포커스 엔터
        ///  -- 포커스 왔을때 값이 널이면 기본값 소하로 채워줌.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpBirth_Enter(object sender, System.EventArgs e)
        {

        }


        #endregion

        #region 화면 닫을때 ( Screen Close )

        private void OUT0101U02_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.CheckDataBeforeClosing() == true)
            {
                this.mbxMsg = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox24_Ko : Resources.XMessageBox24_Jp;
                this.mbxCap = NetInfo.Language == LangMode.Ko ? Resources.caption24_Ko : Resources.caption24_Jp;

                DialogResult result = XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.btnList.PerformClick(FunctionType.Update);

                    if (!this.mIsSaveSuccess)
                    {
                        e.Cancel = true;
                    }
                }
                else if (result == DialogResult.No)
                {
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region cbxSelf_Pace_Maker_CheckedChanged
        //당원페이스메이커 체크시 페이스 메이커도 체크함
        private void cbxSelf_Pace_Maker_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb.Checked)
            {
                this.cbxPace_Maker_YN.Checked = true;
            }
        }
        #endregion

        #region 저장로직
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OUT0101U02 parent = null;

            public XSavePerformer(OUT0101U02 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                //string cmdQry = null;
                bool flag = false;

                // Not use in cloud
                //                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                //                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                //
                //				if(callerID == '1')
                //				{
                //                    //switch(item.RowState)
                //                    //{
                //                        //case DataRowState.Added:
                //
                //							string cmdText = string.Empty;
                //
                //							// 때려 넣은 건지 직접 따온건지 체크
                //                            //XMessageBox.Show(item.BindVarList["f_iu_gubun"].VarValue);
                //							if(item.BindVarList["f_iu_gubun"].VarValue == "I")
                //							{
                ////                                cmdText = @"SELECT 'Y'
                ////											  FROM DUAL
                ////											 WHERE EXISTS ( SELECT 'X'
                ////															  FROM OUT0101 A
                ////															 WHERE A.HOSP_CODE = :f_hosp_code
                ////                                                               AND A.BUNHO     = :f_bunho )";
                //
                //
                ////                                object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                //
                //							    NuroOUT0101U02CheckExistsXArgs args = new NuroOUT0101U02CheckExistsXArgs();
                //                                args.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //
                //							    NuroOUT0101U02CheckExistsXResult result = CloudService.Instance
                //							        .Submit<NuroOUT0101U02CheckExistsXResult, NuroOUT0101U02CheckExistsXArgs>(args);
                //
                //
                //
                //                                if (result.ResultValue  == null)
                //								{
                //								}
                //								else
                //								{
                //                                    if (result.ResultValue.ToString() == "Y")
                //									{
                //										XMessageBox.Show(Resources.XMessageBox25);
                //										return false;
                //									}
                //								}
                //
                ////                                cmdQry = @"INSERT INTO OUT0101
                ////                                                ( SYS_DATE          , SYS_ID            , UPD_DATE          , UPD_ID            , HOSP_CODE
                ////												, BUNHO             , SUNAME            , SEX               , BIRTH             
                ////                                                , ZIP_CODE1         , ZIP_CODE2         , ADDRESS1			, ADDRESS2
                ////												, TEL               , TEL1              , GUBUN             , TEL_HP
                ////												, EMAIL             , SUNAME2           , TEL_GUBUN         , TEL_GUBUN2
                ////												, TEL_GUBUN3        , DELETE_YN         , PACE_MAKER_YN     , SELF_PACE_MAKER   , BUNHO_TYPE )
                ////										VALUES(
                ////												SYSDATE             , :f_user_id        , SYSDATE           , :f_user_id        , :f_hosp_code
                ////												, :f_bunho          , :f_suname         , :f_sex            , :f_birth          
                ////                                                , :f_zip_code1      , :f_zip_code2      , :f_address1       , :f_address2
                ////												, :f_tel            , :f_tel1           , :f_gubun          , :f_tel_hp
                ////												, :f_email          , :f_suname2        , :f_tel_gubun      , :f_tel_gubun2
                ////												, :f_tel_gubun3     , :f_delete_yn      , :f_pace_maker_yn  , :f_self_pace_maker, NVL(:f_bunho_type, '0') )";
                //
                //							    NuroOUT0101U02InsertPatientArgs insertPatientArgs = new NuroOUT0101U02InsertPatientArgs();
                //
                //                                insertPatientArgs.Address1 = item.BindVarList["f_address1"].VarValue;
                //                                insertPatientArgs.Address2 = item.BindVarList["f_address2"].VarValue;
                //                                insertPatientArgs.Birth = item.BindVarList["f_birth"].VarValue;
                //                                insertPatientArgs.DeleteYn = item.BindVarList["f_delete_yn"].VarValue; 
                //                                insertPatientArgs.Email = item.BindVarList["f_email"].VarValue; 
                //                                insertPatientArgs.PaceMakerYn = item.BindVarList["f_pace_maker_yn"].VarValue; 
                //                                insertPatientArgs.PatientCode = item.BindVarList["f_bunho"].VarValue; 
                //                                insertPatientArgs.PatientName = item.BindVarList["f_suname"].VarValue;
                //                                insertPatientArgs.PatientName2 = item.BindVarList["f_suname2"].VarValue; 
                //                                insertPatientArgs.PatientType = item.BindVarList["f_bunho_type"].VarValue; 
                //                                insertPatientArgs.SelfPaceMaker = item.BindVarList["f_self_pace_maker"].VarValue;
                //							    insertPatientArgs.Sex = item.BindVarList["f_sex"].VarValue; 
                //							    insertPatientArgs.SysDate = DateTime.Now.ToShortDateString();
                //                                insertPatientArgs.SysId = item.BindVarList["f_user_id"].VarValue; 
                //                                insertPatientArgs.Tel = item.BindVarList["f_tel"].VarValue; 
                //                                insertPatientArgs.Tel1 = item.BindVarList["f_tel1"].VarValue; 
                //                                insertPatientArgs.TelHp = item.BindVarList["f_tel_hp"].VarValue; 
                //                                insertPatientArgs.TelType = item.BindVarList["f_tel_gubun"].VarValue; 
                //                                insertPatientArgs.TelType2 = item.BindVarList["f_tel_gubun2"].VarValue; 
                //                                insertPatientArgs.TelType3 = item.BindVarList["f_tel_gubun3"].VarValue; 
                //                                insertPatientArgs.Type = item.BindVarList["f_gubun"].VarValue; 
                //							    insertPatientArgs.UpdateDate = DateTime.Now.ToShortDateString();
                //                                insertPatientArgs.UpdateId = item.BindVarList["f_user_id"].VarValue; 
                //                                insertPatientArgs.ZipCode1 = item.BindVarList["f_zip_code1"].VarValue; 
                //                                insertPatientArgs.ZipCode2 = item.BindVarList["f_zip_code2"].VarValue; 
                //
                //                                UpdateResult insertResult = CloudService.Instance.Submit<UpdateResult, NuroOUT0101U02InsertPatientArgs>(insertPatientArgs);
                //
                //                                flag = insertResult.Result;
                //
                //							}
                //							else
                //							{
                //								// 이미 등록된 번호이기에 없는 번호인지 체크
                //								cmdText = string.Empty;
                //
                ////                                cmdText = @"SELECT DISTINCT 'Y'
                ////											  FROM OUT0101
                ////											 WHERE HOSP_CODE = :f_hosp_code
                ////                                               AND BUNHO     = :f_bunho";
                //
                ////                                object retVal1 = Service.ExecuteScalar(cmdText, item.BindVarList);
                //
                //                                
                //                                NuroOUT0101U02CheckExistsYArgs argsY = new NuroOUT0101U02CheckExistsYArgs();
                //                                argsY.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //
                //							    NuroOUT0101U02CheckExistsYResult resultY = CloudService.Instance
                //							        .Submit<NuroOUT0101U02CheckExistsYResult, NuroOUT0101U02CheckExistsYArgs>(argsY);
                //
                //								if(resultY .ResultValue  == false )
                //                                {
                //                                    XMessageBox.Show(Resources.XMessageBox26);
                //                                    return false;
                //								}
                //								else
                //								{
                //                                    //TODO
                //                                    //if(retVal1.ToString() != "Y")
                //                                    //{
                //                                    //    XMessageBox.Show(Resources.XMessageBox26);
                //                                    //    return false;
                //                                    //}
                //								}
                //
                ////                                cmdQry = @"UPDATE OUT0101
                ////											  SET UPD_ID          = :f_user_id
                ////												, UPD_DATE        = SYSDATE
                ////												, SUNAME          = :f_suname
                ////												, SEX             = :f_sex
                ////												, BIRTH           = TO_DATE(:f_birth, 'YYYY/MM/DD')
                ////												, ZIP_CODE1       = :f_zip_code1
                ////												, ZIP_CODE2       = :f_zip_code2
                ////												, ADDRESS1        = :f_address1
                ////												, ADDRESS2        = :f_address2
                ////												, TEL             = :f_tel
                ////												, TEL1            = :f_tel1
                ////												, GUBUN           = :f_gubun
                ////												, TEL_HP          = :f_tel_hp
                ////												, EMAIL           = :f_email
                ////												, SUNAME2         = :f_suname2
                ////												, TEL_GUBUN       = :f_tel_gubun
                ////												, TEL_GUBUN2      = :f_tel_gubun2
                ////												, TEL_GUBUN3      = :f_tel_gubun3
                ////												, DELETE_YN       = :f_delete_yn
                ////												, PACE_MAKER_YN   = :f_pace_maker_yn
                ////												, SELF_PACE_MAKER = :f_self_pace_maker
                ////                                                , BUNHO_TYPE      = NVL(:f_bunho_type, '0')
                ////											WHERE HOSP_CODE       = :f_hosp_code
                ////                                              AND BUNHO           = :f_bunho";
                //
                //							    NuroOUT0101U02UpdatePatientArgs updateArgs = new NuroOUT0101U02UpdatePatientArgs();
                //
                //                                updateArgs.Address1 = item.BindVarList["f_address1"].VarValue;
                //                                updateArgs.Address2 = item.BindVarList["f_address2"].VarValue;
                //                                updateArgs.Birth = item.BindVarList["f_birth"].VarValue;
                //                                updateArgs.DeleteYn = item.BindVarList["f_delete_yn"].VarValue;
                //                                updateArgs.Email = item.BindVarList["f_email"].VarValue;
                //                                updateArgs.PaceMakerYn = item.BindVarList["f_pace_maker_yn"].VarValue;
                //                                updateArgs.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //                                updateArgs.PatientName = item.BindVarList["f_suname"].VarValue;
                //                                updateArgs.PatientName2 = item.BindVarList["f_suname2"].VarValue;
                //                                updateArgs.PatientType = item.BindVarList["f_bunho_type"].VarValue;
                //                                updateArgs.SelfPaceMaker = item.BindVarList["f_self_pace_maker"].VarValue;
                //                                updateArgs.Sex = item.BindVarList["f_sex"].VarValue;
                //                                
                //                                updateArgs.Tel = item.BindVarList["f_tel"].VarValue;
                //                                updateArgs.Tel1 = item.BindVarList["f_tel1"].VarValue;
                //                                updateArgs.TelHp = item.BindVarList["f_tel_hp"].VarValue;
                //                                updateArgs.TelType = item.BindVarList["f_tel_gubun"].VarValue;
                //                                updateArgs.TelType2 = item.BindVarList["f_tel_gubun2"].VarValue;
                //                                updateArgs.TelType3 = item.BindVarList["f_tel_gubun3"].VarValue;
                //                                updateArgs.Type = item.BindVarList["f_gubun"].VarValue;
                //
                //                                updateArgs.ZipCode1 = item.BindVarList["f_zip_code1"].VarValue;
                //                                updateArgs.ZipCode2 = item.BindVarList["f_zip_code2"].VarValue;
                //                                updateArgs.UserId = item.BindVarList["f_user_id"].VarValue;
                //                                
                //                                UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, NuroOUT0101U02UpdatePatientArgs>(updateArgs);
                //
                //                                flag = updateResult.Result;
                //
                //							}
                //                            //break;
                //
                ////                        case DataRowState.Modified:
                //
                ////                            // 이미 등록된 번호이기에 없는 번호인지 체크
                ////                            string cmdText1 = @"SELECT DISTINCT 'Y'
                ////												  FROM OUT0101
                ////												 WHERE HOSP_CODE = :f_hosp_code
                ////                                                   AND BUNHO     = :f_bunho";
                //
                ////                            object retVal2 = Service.ExecuteScalar(cmdText1, item.BindVarList);
                ////                            if(retVal2 == null)
                ////                            {
                ////                                XMessageBox.Show("登録されていない患者番号です。ご確認ください。");
                ////                                return false;
                ////                            }
                ////                            else
                ////                            {
                ////                                if(retVal2.ToString() != "Y")
                ////                                {
                ////                                    XMessageBox.Show("登録されていない患者番号です。ご確認ください。");
                ////                                    return false;
                ////                                }
                ////                            }
                //
                ////                            cmdQry = @"UPDATE OUT0101
                ////										  SET UPD_ID          = :f_user_id
                ////											, UPD_DATE        = SYSDATE
                ////											, SUNAME          = :f_suname
                ////											, SEX             = :f_sex
                ////											, BIRTH           = TO_DATE(:f_birth, 'YYYY/MM/DD')
                ////											, ZIP_CODE1       = :f_zip_code1
                ////											, ZIP_CODE2       = :f_zip_code2
                ////											, ADDRESS1        = :f_address1
                ////											, ADDRESS2        = :f_address2
                ////											, TEL             = :f_tel
                ////											, TEL1            = :f_tel1
                ////											, GUBUN           = :f_gubun
                ////											, TEL_HP          = :f_tel_hp
                ////											, EMAIL           = :f_email
                ////											, SUNAME2         = :f_suname2
                ////											, TEL_GUBUN       = :f_tel_gubun
                ////											, TEL_GUBUN2      = :f_tel_gubun2
                ////											, TEL_GUBUN3      = :f_tel_gubun3
                ////											, DELETE_YN       = :f_delete_yn
                ////											, PACE_MAKER_YN   = :f_pace_maker_yn
                ////											, SELF_PACE_MAKER = :f_self_pace_maker
                ////										WHERE HOSP_CODE       = :f_hosp_code
                ////                                          AND BUNHO           = :f_bunho";
                ////                            break;
                //                    //}
                //				}
                //				else if(callerID == '2')
                //				{
                //					switch(item.RowState)
                //					{
                //						case DataRowState.Added:
                //
                //							string cmdText3 = string.Empty;
                //							BindVarCollection bindVars3 = new BindVarCollection();
                //
                ////                            // 이미 등록된 번호이기에 없는 번호인지 체크
                ////                            cmdText3 = @"SELECT DISTINCT 'Y'
                ////											FROM OUT0102
                ////											WHERE HOSP_CODE  = :f_hosp_code
                ////                                              AND BUNHO      = :f_bunho
                ////											  AND GUBUN      = :f_gubun1
                ////											  AND START_DATE = :f_start_date";
                //
                ////                            object retVal3 = Service.ExecuteScalar(cmdText3, item.BindVarList);
                //
                //					        NuroOUT0101U02GetYArgs argsY = new NuroOUT0101U02GetYArgs();
                //                            argsY.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //                            argsY.StartDate = item.BindVarList["f_start_date"].VarValue;
                //                            argsY.Type = item.BindVarList["f_gubun1"].VarValue;
                //
                //					        NuroOUT0101U02GetYResult reulstY = CloudService.Instance
                //                                .Submit<NuroOUT0101U02GetYResult, NuroOUT0101U02GetYArgs>(argsY);
                //
                //                            if (reulstY.Y  == null)
                //							{
                //							}
                //							else
                //							{
                //                                if (reulstY.Y.ToString() == "Y")
                //								{
                //									XMessageBox.Show(Resources.XMessageBox27);
                //									return false;
                //								}
                //							}
                //
                ////                            /* 기존의 데이터에 END_DATE를 새로운 데이터
                ////                               START_DATE - 1 로 셋팅한다 */
                ////                            cmdText = @"UPDATE OUT0102 A
                ////                                               SET A.UPD_ID      = :q_user_id
                ////                                                 , A.UPD_DATE    = SYSDATE
                ////                                                 , A.END_DATE    = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
                ////                                             WHERE A.HOSP_CODE     = :f_hosp_code
                ////                                               AND A.BUNHO         = :f_bunho
                ////											   AND A.GUBUN         = :f_gubun1
                ////											   --AND A.START_DATE    = :f_start_date
                ////                                               AND A.END_DATE    = TO_DATE('9998/12/31', 'YYYY/MM/DD')";
                //
                ////                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                ////                            {
                ////                                //return false;
                ////                            }
                //
                ////                            cmdQry = @"INSERT INTO OUT0102(SYS_DATE
                ////														, SYS_ID
                ////														, UPD_DATE
                ////														, UPD_ID
                ////														, HOSP_CODE
                ////														, START_DATE
                ////														, BUNHO
                ////														, GUBUN
                ////														, JOHAP
                ////														, GAEIN
                ////														, PINAME
                ////														, BON_GA_GUBUN
                ////														, END_DATE
                ////														, GAEIN_NO
                ////														, LAST_CHECK_DATE
                ////														, CHUIDUK_DATE       )
                ////												VALUES(SYSDATE
                ////														, :f_user_id
                ////														, SYSDATE
                ////														, :f_user_id
                ////														, :f_hosp_code
                ////														, :f_start_date
                ////														, :f_bunho
                ////														, :f_gubun1
                ////														, :f_johap
                ////														, :f_gaein
                ////														, :f_piname
                ////														, :f_bonin_gubun
                ////														, NVL(:f_end_date, '9998/12/31')
                ////														, :f_gaein_no
                ////														, :f_last_check_date 
                ////														, :f_chuiduk_date     )";
                //
                //					        NuroOUT0101U02InsertBoheomArgs argsInsertBoheom = new NuroOUT0101U02InsertBoheomArgs();
                //                            argsInsertBoheom.BonGaGubun = item.BindVarList["f_bonin_gubun"].VarValue;
                //                            argsInsertBoheom.ChuidukDate = item.BindVarList["f_chuiduk_date"].VarValue;
                //                            argsInsertBoheom.EndDate = item.BindVarList["f_end_date"].VarValue;
                //                            argsInsertBoheom.Gaein = item.BindVarList["f_gaein"].VarValue;
                //                            argsInsertBoheom.GaeinNo = item.BindVarList["f_gaein_no"].VarValue;
                //                            argsInsertBoheom.Johap = item.BindVarList["f_johap"].VarValue;
                //                            argsInsertBoheom.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //                            argsInsertBoheom.LastCheckDate = item.BindVarList["f_last_check_date"].VarValue;
                //                            argsInsertBoheom.Piname = item.BindVarList["f_piname"].VarValue;
                //
                //                            argsInsertBoheom.StartDate = item.BindVarList["f_start_date"].VarValue;
                //                            argsInsertBoheom.SysId = item.BindVarList["f_user_id"].VarValue;
                //                            argsInsertBoheom.Type = item.BindVarList["f_gubun1"].VarValue;
                //
                //
                //					        argsInsertBoheom.UpdateDate = string.Format("{0:yyyy/MM/dd}", DateTime.Now);
                //                            argsInsertBoheom.UpdateId = item.BindVarList["f_user_id"].VarValue;
                //                            
                //
                //					        UpdateResult insertBoheomResult = CloudService.Instance
                //					            .Submit<UpdateResult, NuroOUT0101U02InsertBoheomArgs>(argsInsertBoheom);
                //
                //                            flag = insertBoheomResult.Result;
                //							break;
                //
                //						case DataRowState.Modified:
                //
                ////                            // 이미 등록된 번호이기에 없는 번호인지 체크
                ////                            string cmdText4 = @"SELECT DISTINCT 'Y'
                ////												  FROM OUT0102
                ////												 WHERE HOSP_CODE  = :f_hosp_code
                ////                                                   AND BUNHO      = :f_bunho
                ////												   AND GUBUN      = :f_gubun1
                ////												   AND START_DATE = :f_start_date";
                //
                ////                            object retVal4 = Service.ExecuteScalar(cmdText4, item.BindVarList);
                //
                //                            NuroOUT0101U02GetYArgs argsYUpdate = new NuroOUT0101U02GetYArgs();
                //                            argsYUpdate.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //                            argsYUpdate.StartDate = item.BindVarList["f_start_date"].VarValue;
                //                            argsYUpdate.Type = item.BindVarList["f_gubun1"].VarValue;
                //
                //                            NuroOUT0101U02GetYResult reulstYUpdate = CloudService.Instance
                //                                .Submit<NuroOUT0101U02GetYResult, NuroOUT0101U02GetYArgs>(argsYUpdate);
                //
                //                            if (reulstYUpdate.Y  == null)
                //							{
                //							}
                //							else
                //							{
                //                                if (reulstYUpdate.Y .ToString() != "Y")
                //								{
                //									XMessageBox.Show(Resources.XMessageBox27);
                //									return false;
                //								}
                //							}
                //
                ////                            cmdQry = @"UPDATE OUT0102
                ////										  SET UPD_ID            = :f_user_id
                ////											, UPD_DATE          = SYSDATE
                ////											, START_DATE        = :f_start_date
                ////											, BUNHO             = :f_bunho
                ////											, GUBUN             = :f_gubun1
                ////											, JOHAP             = :f_johap
                ////											, GAEIN             = :f_gaein
                ////											, PINAME            = :f_piname
                ////											, BON_GA_GUBUN      = :f_bonin_gubun
                ////											, END_DATE          = NVL(:f_end_date, '9998/12/31')
                ////											, GAEIN_NO          = :f_gaein_no
                ////											, LAST_CHECK_DATE   = :f_last_check_date
                ////											, CHUIDUK_DATE      = :f_chuiduk_date
                ////										WHERE HOSP_CODE         = :f_hosp_code
                ////                                          AND BUNHO             = :f_bunho
                ////										  AND GUBUN             = :f_old_gubun
                ////										  AND START_DATE        = :f_old_start_date";
                //
                //					        NuroOUT0101U02UpdateBoheomArgs updateArgs = new NuroOUT0101U02UpdateBoheomArgs();
                //
                //                            updateArgs.BonGaGubun = item.BindVarList["f_bonin_gubun"].VarValue;
                //                            updateArgs.ChuidukDate = item.BindVarList["f_chuiduk_date"].VarValue;
                //                            updateArgs.EndDate = item.BindVarList["f_end_date"].VarValue;
                //                            updateArgs.Gaein = item.BindVarList["f_gaein"].VarValue;
                //                            updateArgs.GaeinNo = item.BindVarList["f_gaein_no"].VarValue;
                //                            updateArgs.Johap = item.BindVarList["f_johap"].VarValue;
                //                            updateArgs.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //                            updateArgs.LastCheckDate = item.BindVarList["f_last_check_date"].VarValue;
                //                            updateArgs.Piname = item.BindVarList["f_piname"].VarValue;
                //                            updateArgs.OldStartDate = item.BindVarList["f_old_start_date"].VarValue;
                //                            updateArgs.StartDate = item.BindVarList["f_start_date"].VarValue;
                //                            
                //                            updateArgs.Type = item.BindVarList["f_gubun1"].VarValue;
                //                            updateArgs.UserId = item.BindVarList["f_user_id"].VarValue;
                //                            updateArgs.PatientCodeOld = item.BindVarList["f_old_gubun"].VarValue;
                //
                //                            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, NuroOUT0101U02UpdateBoheomArgs>(updateArgs);
                //
                //                            flag = updateResult.Result;
                //
                //							break;
                //
                //						case DataRowState.Deleted:
                //
                ////                            cmdQry = @"DELETE OUT0102
                ////										WHERE HOSP_CODE       = :f_hosp_code
                ////                                          AND BUNHO           = :f_bunho
                ////										  AND GUBUN           = :f_old_gubun
                ////										  AND START_DATE      = TO_DATE(:f_old_start_date, 'YYYY/MM/DD')";
                //
                //					        NuroOUT0101U02DeleteBoheomArgs argsDelete = new NuroOUT0101U02DeleteBoheomArgs();
                //                            argsDelete.OldStartDate = item.BindVarList["f_old_start_date"].VarValue;
                //                            argsDelete.OldType = item.BindVarList["f_old_gubun"].VarValue;
                //                            argsDelete.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //
                //                            UpdateResult insertResult = CloudService.Instance.Submit<UpdateResult, NuroOUT0101U02DeleteBoheomArgs>(argsDelete);
                //
                //                            flag = insertResult.Result;
                //							break;
                //					}
                //				}
                //				else if(callerID == '3')
                //				{
                //					switch(item.RowState)
                //					{
                //						case DataRowState.Added:
                //
                ////                            string cmdText5 = string.Empty;
                //
                ////                            // 이미 등록된 번호이기에 없는 번호인지 체크
                ////                            cmdText5 = @"SELECT DISTINCT 'Y'
                ////										   FROM OUT0105
                ////										  WHERE HOSP_CODE    = :f_hosp_code
                ////                                            AND GONGBI_CODE  = :f_gongbi_code
                ////										    AND BUNHO        = :f_bunho
                ////										    AND START_DATE = :f_start_date";
                //
                ////                            object retVal5 = Service.ExecuteScalar(cmdText5, item.BindVarList);
                //
                //					        NuroOUT0101U02GongbiListGetYArgs argsGetY = new NuroOUT0101U02GongbiListGetYArgs();
                //                            argsGetY.GongbiCode = item.BindVarList["f_gongbi_code"].VarValue;
                //                            argsGetY.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //                            argsGetY.StartDate = item.BindVarList["f_start_date"].VarValue;
                //
                //					        NuroOUT0101U02GongbiListGetYResult resultGetY = CloudService.Instance
                //					            .Submit<NuroOUT0101U02GongbiListGetYResult, NuroOUT0101U02GongbiListGetYArgs>(argsGetY);
                //
                //
                //                            if (resultGetY.YValue  == null)
                //							{
                //							}
                //							else
                //							{
                //                                if (resultGetY.YValue.ToString() == "Y")
                //								{
                //									XMessageBox.Show(Resources.XMessageBox28);
                //									return false;
                //								}
                //							}
                //
                ////                            cmdQry = @"INSERT INTO OUT0105(SYS_DATE
                ////														 , SYS_ID
                ////														 , UPD_DATE
                ////														 , UPD_ID
                ////														 , HOSP_CODE
                ////														 , START_DATE
                ////														 , BUNHO
                ////														 , BUDAMJA_BUNHO
                ////														 , GONGBI_CODE
                ////														 , SUGUBJA_BUNHO
                ////														 , END_DATE
                ////														 , REMARK
                ////														 , LAST_CHECK_DATE  )
                ////												   VALUES (SYSDATE
                ////														 , :f_user_id
                ////														 , SYSDATE
                ////														 , :f_user_id
                ////														 , :f_hosp_code
                ////														 , :f_start_date
                ////														 , :f_bunho
                ////														 , :f_budamja_bunho
                ////														 , :f_gongbi_code
                ////														 , :f_sugubja_bunho
                ////														 , :f_end_date
                ////														 , :f_remark
                ////														 , :f_last_check_date  )";
                //
                //					        NuroOUT0101U02InsertGongbiListArgs argsInsert = new NuroOUT0101U02InsertGongbiListArgs();
                //
                //                            argsInsert.UserId = item.BindVarList["f_user_id"].VarValue;
                //                            argsInsert.StartDate = item.BindVarList["f_start_date"].VarValue;
                //                            argsInsert.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //                            argsInsert.BudamjaPatient = item.BindVarList["f_budamja_bunho"].VarValue;
                //                            argsInsert.UpdateDate = "";
                //                            argsInsert.UpdateId = "";
                //                            argsInsert.EndDate = item.BindVarList["f_end_date"].VarValue;
                //                            argsInsert.GongbiCode = item.BindVarList["f_gongbi_code"].VarValue;
                //                            argsInsert.LastCheckDate = item.BindVarList["f_last_check_date"].VarValue;
                //                            argsInsert.SugubjaPatient = item.BindVarList["f_sugubja_bunho"].VarValue;
                //                            argsInsert.Remark = item.BindVarList["f_remark"].VarValue;
                //
                //                            UpdateResult insertResult = CloudService.Instance.Submit<UpdateResult, NuroOUT0101U02InsertGongbiListArgs>(argsInsert);
                //
                //                            flag = insertResult.Result;
                //							break;
                //
                //						case DataRowState.Modified:
                //
                ////                            cmdQry = @"UPDATE OUT0105
                ////										  SET UPD_ID            = :f_user_id
                ////											, UPD_DATE          = SYSDATE
                ////											, START_DATE        = :f_start_date
                ////											, BUNHO             = :f_bunho
                ////											, BUDAMJA_BUNHO     = :f_budamja_bunho
                ////											, GONGBI_CODE       = :f_gongbi_code
                ////											, SUGUBJA_BUNHO     = :f_sugubja_bunho
                ////											, END_DATE          = :f_end_date
                ////											, REMARK            = :f_remark
                ////											, LAST_CHECK_DATE   = :f_last_check_date
                ////										WHERE HOSP_CODE         = :f_hosp_code
                ////                                          AND START_DATE        = TO_DATE(:f_old_start_date, 'YYYY/MM/DD')
                ////										  AND BUNHO             = :f_bunho
                ////										  AND GONGBI_CODE       = :f_gongbi_code";
                //
                //					        NuroOUT0101U02UpdateGongbiListArgs argsUpdate = new NuroOUT0101U02UpdateGongbiListArgs();
                //
                //                            argsUpdate.BudamjaPatient = item.BindVarList["f_budamja_bunho"].VarValue;
                //                            argsUpdate.EndDate = item.BindVarList["f_end_date"].VarValue;
                //                            argsUpdate.GongbiCode = item.BindVarList["f_gongbi_code"].VarValue;
                //                            argsUpdate.LastCheckDate = item.BindVarList["f_last_check_date"].VarValue;
                //                            argsUpdate.OldStartDate = item.BindVarList["f_old_start_date"].VarValue;
                //                            argsUpdate.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //                            argsUpdate.Remark = item.BindVarList["f_remark"].VarValue;
                //                            argsUpdate.StartDate = item.BindVarList["f_start_date"].VarValue;
                //                            argsUpdate.SugubjaCode = item.BindVarList["f_sugubja_bunho"].VarValue;
                //                            argsUpdate.UserId = item.BindVarList["f_user_id"].VarValue;
                //
                //                            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, NuroOUT0101U02UpdateGongbiListArgs>(argsUpdate);
                //
                //					        flag = updateResult.Result ;
                //							break;
                //
                //						case DataRowState.Deleted:
                //
                ////                            cmdQry = @"DELETE OUT0105
                ////										WHERE HOSP_CODE         = :f_hosp_code
                ////                                          AND START_DATE        = TO_DATE(:f_start_date, 'YYYY/MM/DD')
                ////										  AND BUNHO             = :f_bunho
                ////										  AND GONGBI_CODE       = :f_gongbi_code";
                //
                //					        NuroOUT0101U02DeleteGongbiArgs argsDeleteGongbi = new NuroOUT0101U02DeleteGongbiArgs();
                //                            argsDeleteGongbi.GongbiCode = item.BindVarList["f_gongbi_code"].VarValue;
                //                            argsDeleteGongbi.PatientCode = item.BindVarList["f_bunho"].VarValue;
                //                            argsDeleteGongbi.StartDate = item.BindVarList["f_start_date"].VarValue;
                //
                //                            UpdateResult result = CloudService.Instance.Submit<UpdateResult, NuroOUT0101U02DeleteGongbiArgs>(argsDeleteGongbi);
                //
                //					        flag = result.Result ;
                //
                //							break;
                //					}
                //				}
                //
                return flag;
                //return Service.ExecuteNonQuery(cmdQry, item.BindVarList);
            }
        }
        #endregion

        private void cboBonin_Gubun_SelectionChangeCommitted(object sender, EventArgs e)
        {

            // 본인 인경우 피보험자, 관계를 모두 본인으로
            if (this.cboBonin_Gubun.GetDataValue() == "0")
            {
                this.txtPiName.SetEditValue(this.grdPatient.GetItemString(this.grdPatient.CurrentRowNumber, "suname"));
                this.txtPiName.AcceptData();
            }
            else
            {
                this.txtPiName.SetEditValue("");
                this.txtPiName.AcceptData();
            }

        }

        #region Update Code

        //Load Data Into FwkCommon Gubun
        private IList<object[]> GetFwkCommonGubun(BindVarCollection list)
        {
            NuroOUT0101U02GetTypeArgs args = new NuroOUT0101U02GetTypeArgs();

            args.JohapGubun = list["f_johap_gubun"].VarValue;
            args.Find1 = list["f_find1"].VarValue;

            //args.Find1 = list["f_find1"].VarValue;

            NuroOUT0101U02GetTypeResult result = CloudService
                .Instance.Submit<NuroOUT0101U02GetTypeResult, NuroOUT0101U02GetTypeArgs>(args);

            IList<object[]> resultData = new List<object[]>();

            if (result != null)
            {
                IList<NuroOUT0101U02GetType> listItem = result.TypeItem;

                foreach (NuroOUT0101U02GetType item in listItem)
                {

                    object[] objects =
                        {
                            item.Type , 
                            item.TypeName  
                        };
                    resultData.Add(objects);
                }
            }
            return resultData;
        }

        ////Load Data Into FwkCommon Gaein
        private IList<object[]> GetFwkCommonGaein(BindVarCollection list)
        {
            NuroNuroOUT0101U02GetGaeinArgs args = new NuroNuroOUT0101U02GetGaeinArgs();

            args.Gaein = list["f_find1"].VarValue + "%";
            args.Johap = list["f_johap"].VarValue;

            NuroNuroOUT0101U02GetGaeinResult result = CloudService
                .Instance.Submit<NuroNuroOUT0101U02GetGaeinResult, NuroNuroOUT0101U02GetGaeinArgs>(args);

            IList<object[]> resultData = new List<object[]>();

            if (result != null)
            {
                IList<DataStringListItemInfo> listItem = result.GaeinList;

                foreach (DataStringListItemInfo item in listItem)
                {
                    object[] objects =
                        {
                            item.DataValue
                        };
                    resultData.Add(objects);
                }
            }
            return resultData;
        }

        //Load Data Into FwkCommon GongbiCode
        private IList<object[]> GetFwkCommonGongbiCode(BindVarCollection list)
        {
            NuroOUT0101U02GetInsurance2Args args = new NuroOUT0101U02GetInsurance2Args();

            //TODO
            args.Find1 = list["f_find1"].VarValue;
            //args.Find1 = "010";

            NuroOUT0101U02GetInsurance2Result result = CloudService
                .Instance.Submit<NuroOUT0101U02GetInsurance2Result, NuroOUT0101U02GetInsurance2Args>(args);

            IList<object[]> resultData = new List<object[]>();

            if (result != null)
            {
                IList<NuroOUT0101U02GetInsuranceInfo2> listItem = result.InsuranceInfo;

                foreach (NuroOUT0101U02GetInsuranceInfo2 item in listItem)
                {

                    object[] objects =
                        {
                            item.InsuranceCode  , 
                            item.InsuranceName   
                        };
                    resultData.Add(objects);
                }
            }
            return resultData;
        }

        //Load Combo box data
        private OUT0101U02ComboListResult GetComboListResult()
        {
            OUT0101U02ComboListArgs args = new OUT0101U02ComboListArgs();
            args.SexCodeType = "SEX_GUBUN";
            args.BunhoCodeType = "BUNHO_TYPE";
            args.TelCodeType = "TEL_GUBUN";
            args.BoninCodeType = "BON_GA_GUBUN";
            args.BillingCodeType = "BILLING_TYPE";
            OUT0101U02ComboListResult result = CacheService.Instance.Get<OUT0101U02ComboListArgs, OUT0101U02ComboListResult>(args);
            return result;
        }

        //Load Data Into CboBonin Gubun
        private IList<object[]> ComboBoninGubun(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            if (this.comboListResult != null)
            {
                IList<ComboListItemInfo> listItem = comboListResult.BoninComboListItem;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }
        //Load BliingType ComboBillingType
        private IList<object[]> ComboBillingType(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            if (this.comboListResult != null)
            {
                IList<ComboListItemInfo> listItem = comboListResult.BillingCodeType;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }

        //Load Data Into ComboBunhoType
        private IList<object[]> ComboBunhoType(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            if (this.comboListResult != null)
            {
                IList<ComboListItemInfo> listItem = comboListResult.BunhoComboListItem;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }
        //
        //Load Data Into ComboTelGubun
        private IList<object[]> ComboTelGubun(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            if (this.comboListResult != null)
            {
                IList<ComboListItemInfo> listItem = comboListResult.TelComboListItem;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }

        //Load Data Into ComboTelGubun2
        private IList<object[]> ComboTelGubun2(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            if (this.comboListResult != null)
            {
                IList<ComboListItemInfo> listItem = comboListResult.TelComboListItem;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }

        //Load Data Into ComboTelGubun3
        private IList<object[]> ComboTelGubun3(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            if (this.comboListResult != null)
            {
                IList<ComboListItemInfo> listItem = comboListResult.TelComboListItem;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }

        //Load Data Into ComboSex
        private IList<object[]> ComboSex()
        {
            IList<object[]> lstResult = new List<object[]>();
            if (this.comboListResult != null)
            {
                IList<ComboListItemInfo> listItem = comboListResult.SexComboListItem;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }

        private OUT0101U02GridViewResult GetGridViewResult(String bunho)
        {
            OUT0101U02GridViewArgs args = new OUT0101U02GridViewArgs();
            args.PatientCode = bunho;

            OUT0101U02GridViewResult result = CloudService.Instance
                    .Submit<OUT0101U02GridViewResult, OUT0101U02GridViewArgs>(args);
            return result;
        }

        //Grid Boheom
        private IList<object[]> GridBoheom(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();

            if (gridViewResult != null)
            {
                IList<NuroOUT0101U02GridBoheomInfo> listItem = gridViewResult.GridBoheomItem;

                foreach (NuroOUT0101U02GridBoheomInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.StartDate ,
                            item.Bunho ,
                            item.Suname ,
                            item.Gubun1 ,
                            item.GubunName1 ,
                            item.Johap ,
                            item.JohapName ,
                            item.Tel,
                            item.Gaein ,
                            item.GaeinNo ,
                            item.BoninGubun ,
                            item.BoninGubunName ,
                            item.Piname,
                            item.LastCheckDate ,
                            item.EndDate ,
                            item.JohapGubun ,
                            item.OldGubun ,
                            item.RetrieveYn ,
                            item.OldStartDate ,
                            item.ChuidukDate ,
                            item.EndYn 
                        };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }

        //Grid GongbiList
        private IList<object[]> GridGongbiList(BindVarCollection list)
        {

            IList<object[]> lstResult = new List<object[]>();

            if (gridViewResult != null)
            {
                IList<NuroOUT0101U02GridGongbiListInfo> listItem = gridViewResult.GridGongbiListItem;

                foreach (NuroOUT0101U02GridGongbiListInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.StartDate ,
                            item.Bunho ,
                            item.BudamjaBunho  ,
                            item.GongbiCode  ,
                            item.SugubjaBunho  ,
                            item.EndDate  ,
                            item.Remark  ,
                            item.LastCheckDate ,
                            item.GongbiName ,
                            item.RetrieveYn  ,
                            item.OldStartDate  ,
                            item.EndYn  
                        };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }

        //Grid PatientList
        private IList<object[]> GridPatientList(BindVarCollection list)
        {

            IList<object[]> lstResult = new List<object[]>();

            if (gridViewResult != null)
            {
                IList<NuroOUT0101U02GridPatientInfo> listItem = gridViewResult.GridPationItem;
                foreach (NuroOUT0101U02GridPatientInfo item in listItem)
                {
                    object[] objects =
                        {
                            item.Bunho ,
                            item.Suname ,
                            item.Sex ,
                            item.Birth ,
                            item.ZipCode1 ,
                            item.ZipCode2 ,
                            item.Address1 ,
                            item.Address2 ,
                            item.Tel ,
                            item.Tel1 ,
                            item.Type ,
                            item.TelHp ,
                            item.Email ,
                            item.GubunName ,
                            item.DongName ,
                            item.Suname2 ,
                            item.Age ,
                            item.TelType ,
                            item.TelType2 ,
                            item.TelType3 ,
                            item.DeleteYn ,
                            item.PaceMakerYn ,
                            item.SelfPaceMaker ,
                            item.PatientType ,
                            item.RetrieveYn ,
                            item.RefId,
                            item.IuGubun,
                            item.BillingType, // billing_name
                            // https://sofiamedix.atlassian.net/browse/PHR-685
                            null, // billing_code
                            item.AutoRecept,
                        };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }

        //Grid Comment
        private IList<object[]> GridCommentList(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();

            if (gridViewResult != null)
            {
                IList<NuroOUT0101U02GridCommentInfo> listItem = gridViewResult.GridCommentItem;

                foreach (NuroOUT0101U02GridCommentInfo item in listItem)
                {
                    object[] objects =
                        {
                            item.Ser  ,
                            item.Comment  ,
                            item.PatientCode
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }

        private IList<object[]> GridCommentListSingleConnection(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            NuroOUT0101U02GridCommentArgs args = new NuroOUT0101U02GridCommentArgs();
            args.PatientCode = list["f_bunho"].VarValue;

            NuroOUT0101U02GridCommentResult result = CloudService.Instance
                    .Submit<NuroOUT0101U02GridCommentResult, NuroOUT0101U02GridCommentArgs>(args);

            if (result != null)
            {
                IList<NuroOUT0101U02GridCommentInfo> listItem = result.GridCommentItem;

                foreach (NuroOUT0101U02GridCommentInfo item in listItem)
                {
                    object[] objects =
                        {
                            item.Ser  ,
                            item.Comment  ,
                            item.PatientCode
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }

        #region CreateParamList

        //Grd Boheom param list
        private List<string> GridCommentParamList()
        {
            List<string> param = new List<string>();
            param.Add("f_bunho");

            return param;
        }

        #endregion createParamList

        // Save Grid data
        private OUT0101U02SaveGridResult SaveGridData()
        {
            OUT0101U02SaveGridArgs args = new OUT0101U02SaveGridArgs();
            args.PatientList = CreatePatientInfoListFromGrid();
            args.BoheomList = CreateBoheomInfoListFromGrid();
            args.GongbiList = CreateGongbiInfoListFromGrid();
            args.UserId = UserInfo.UserID;
            args.AutoBunhoFlg = ((int)_bunhoInputType).ToString();
            args.HospCode = UserInfo.HospCode;
            args.PatientCode = fbxBunho.GetDataValue();
            OUT0101U02SaveGridResult res = CloudService.Instance.Submit<OUT0101U02SaveGridResult, OUT0101U02SaveGridArgs>(args);
            if (res.ErrCode == "1") // Overload bunho
            {
                XMessageBox.Show(Resources.BUNHO_OVERLOAD_MSG, Resources.CAP_003, MessageBoxIcon.Warning);
                res.Result = false;
            }            
            return res;
        }

        private List<NuroOUT0101U02GridPatientInfo> CreatePatientInfoListFromGrid()
        {
            List<NuroOUT0101U02GridPatientInfo> patientInfoList = new List<NuroOUT0101U02GridPatientInfo>();
            for (int i = 0; i < grdPatient.RowCount; i++)
            {
                NuroOUT0101U02GridPatientInfo patientInfo = new NuroOUT0101U02GridPatientInfo();
                patientInfo.Bunho = this.grdPatient.GetItemString(i, "bunho");
                patientInfo.Suname = this.grdPatient.GetItemString(i, "suname");
                patientInfo.Sex = this.grdPatient.GetItemString(i, "sex");
                patientInfo.Birth = this.grdPatient.GetItemString(i, "birth");
                patientInfo.ZipCode1 = this.grdPatient.GetItemString(i, "zip_code1");
                patientInfo.ZipCode2 = this.grdPatient.GetItemString(i, "zip_code2");
                patientInfo.Address1 = this.grdPatient.GetItemString(i, "address1");
                patientInfo.Address2 = this.grdPatient.GetItemString(i, "address2");
                patientInfo.Tel = this.grdPatient.GetItemString(i, "tel");
                patientInfo.Tel1 = this.grdPatient.GetItemString(i, "tel1");
                patientInfo.Type = this.grdPatient.GetItemString(i, "gubun");
                patientInfo.TelHp = this.grdPatient.GetItemString(i, "tel_hp");
                patientInfo.Email = this.grdPatient.GetItemString(i, "email");
                patientInfo.Suname2 = IsVi() ? this.grdPatient.GetItemString(i, "suname") : this.grdPatient.GetItemString(i, "suname2");
                patientInfo.TelType = this.grdPatient.GetItemString(i, "tel_gubun");
                patientInfo.TelType2 = this.grdPatient.GetItemString(i, "tel_gubun2");
                patientInfo.TelType3 = this.grdPatient.GetItemString(i, "tel_gubun3");
                patientInfo.DeleteYn = this.grdPatient.GetItemString(i, "delete_yn");
                patientInfo.PaceMakerYn = this.grdPatient.GetItemString(i, "pace_maker_yn");
                patientInfo.SelfPaceMaker = this.grdPatient.GetItemString(i, "self_pace_maker");
                patientInfo.PatientType = this.grdPatient.GetItemString(i, "bunho_type");
                patientInfo.IuGubun = this.grdPatient.GetItemString(i, "iu_gubun");
                patientInfo.RefId = this.grdPatient.GetItemString(i, "ref_id");
                patientInfo.BillingType = this.grdPatient.GetItemString(i, "billing_name");
                //patientInfo.Pass = pass.ToUpper();
                //hoangVV MED-8792--start
                //patientInfo.Pass = this.RandomString(8);
                patientInfo.Pass = Utility.RandomString(8); // Moves to Utility, AnhNV
                //MED-8792--end
                // https://sofiamedix.atlassian.net/browse/PHR-685
                patientInfo.AutoRecept = this.grdPatient.GetItemString(i, "auto_recept");
                rowState = this.grdPatient.GetItemString(i, "iu_gubun"); // I is insert !=i modifier
                patientInfoList.Add(patientInfo);
            }
            return patientInfoList;
        }

        private List<NuroOUT0101U02GridBoheomInfo> CreateBoheomInfoListFromGrid()
        {
            List<NuroOUT0101U02GridBoheomInfo> boheomInfoList = new List<NuroOUT0101U02GridBoheomInfo>();
            if (grdBoheom.RowCount != 0)
            {
                for (int i = 0; i < grdBoheom.RowCount; i++)
                {
                    NuroOUT0101U02GridBoheomInfo boheomInfo = new NuroOUT0101U02GridBoheomInfo();
                    boheomInfo.BoninGubun = this.grdBoheom.GetItemString(i, "bonin_gubun");
                    boheomInfo.ChuidukDate = this.grdBoheom.GetItemString(i, "chuiduk_date");
                    boheomInfo.EndDate = this.grdBoheom.GetItemString(i, "end_date");
                    boheomInfo.Gaein = this.grdBoheom.GetItemString(i, "gaein");
                    boheomInfo.GaeinNo = this.grdBoheom.GetItemString(i, "gaein_no");
                    boheomInfo.Johap = this.grdBoheom.GetItemString(i, "johap");
                    boheomInfo.Bunho = this.grdBoheom.GetItemString(i, "bunho");
                    boheomInfo.LastCheckDate = this.grdBoheom.GetItemString(i, "last_check_date");
                    boheomInfo.Piname = this.grdBoheom.GetItemString(i, "piname");
                    boheomInfo.StartDate = this.grdBoheom.GetItemString(i, "start_date");
                    boheomInfo.Gubun1 = this.grdBoheom.GetItemString(i, "gubun1");
                    boheomInfo.OldStartDate = this.grdBoheom.GetItemString(i, "old_start_date");
                    boheomInfo.OldGubun = this.grdBoheom.GetItemString(i, "old_gubun");
                    boheomInfo.DataRowState = this.grdBoheom.GetRowState(i).ToString();
                    boheomInfoList.Add(boheomInfo);
                }
            }
            // add deleted list
            if (grdBoheom.DeletedRowCount != 0)
            {
                foreach (DataRow row in this.grdBoheom.DeletedRowTable.Rows)
                {
                    NuroOUT0101U02GridBoheomInfo boheomInfo = new NuroOUT0101U02GridBoheomInfo();
                    boheomInfo.Bunho = row["bunho"].ToString();
                    boheomInfo.OldStartDate = row["old_start_date"].ToString();
                    boheomInfo.OldGubun = row["old_gubun"].ToString();
                    boheomInfo.DataRowState = DataRowState.Deleted.ToString();
                    boheomInfoList.Add(boheomInfo);
                }
            }
            return boheomInfoList;
        }

        private List<NuroOUT0101U02GridGongbiListInfo> CreateGongbiInfoListFromGrid()
        {
            List<NuroOUT0101U02GridGongbiListInfo> gongbiInfoList = new List<NuroOUT0101U02GridGongbiListInfo>();
            if (grdGongbiList.RowCount != 0)
            {
                for (int i = 0; i < grdGongbiList.RowCount; i++)
                {
                    NuroOUT0101U02GridGongbiListInfo gongbiInfo = new NuroOUT0101U02GridGongbiListInfo();
                    gongbiInfo.StartDate = this.grdGongbiList.GetItemString(i, "start_date");
                    gongbiInfo.Bunho = this.grdGongbiList.GetItemString(i, "bunho");
                    gongbiInfo.BudamjaBunho = this.grdGongbiList.GetItemString(i, "budamja_bunho");
                    gongbiInfo.EndDate = this.grdGongbiList.GetItemString(i, "end_date");
                    gongbiInfo.GongbiCode = this.grdGongbiList.GetItemString(i, "gongbi_code");
                    gongbiInfo.LastCheckDate = this.grdGongbiList.GetItemString(i, "last_check_date");
                    gongbiInfo.SugubjaBunho = this.grdGongbiList.GetItemString(i, "sugubja_bunho");
                    gongbiInfo.Remark = this.grdGongbiList.GetItemString(i, "remark");
                    gongbiInfo.OldStartDate = this.grdGongbiList.GetItemString(i, "old_start_date");
                    gongbiInfo.DataRowState = this.grdGongbiList.GetRowState(i).ToString();
                    gongbiInfoList.Add(gongbiInfo);
                }
            }
            // add deleted list
            if (grdGongbiList.DeletedRowCount != 0)
            {
                foreach (DataRow row in this.grdGongbiList.DeletedRowTable.Rows)
                {
                    NuroOUT0101U02GridGongbiListInfo gongbiInfo = new NuroOUT0101U02GridGongbiListInfo();
                    gongbiInfo.StartDate = row["start_date"].ToString();
                    gongbiInfo.Bunho = row["bunho"].ToString();
                    gongbiInfo.GongbiCode = row["gongbi_code"].ToString();
                    gongbiInfo.DataRowState = DataRowState.Deleted.ToString();
                    gongbiInfoList.Add(gongbiInfo);
                }
            }
            return gongbiInfoList;
        }
        #endregion

        #region 2015.07.02 updated

        #region GetBunhoInputType
        /// <summary>
        /// GetBunhoInputType
        /// </summary>
        private void GetBunhoInputType(bool getCode)
        {
            OUT0101U02GetPatientCodeArgs args = new OUT0101U02GetPatientCodeArgs();
            args.GetPatientCodeYn = getCode ? "Y" : "N";
            OUT0101U02GetPatientCodeResult res = CloudService.Instance.Submit<OUT0101U02GetPatientCodeResult, OUT0101U02GetPatientCodeArgs>(args);

            // Maximum of patient code
            if (res.Result == false)
            {
                
                XMessageBox.Show(Resources.BUNHO_OVERLOAD_MSG, Resources.CAP_003, MessageBoxIcon.Warning);
                fbxBunho.SetEditValue("");
                return;
                //this.Close();
            }

            if (res.AutoBunhoFlg == ((int)BunhoInputType.AutoGen).ToString())
            {
                _bunhoInputType = BunhoInputType.AutoGen;
                if (getCode)
                    this._bunho = BizCodeHelper.GetStandardBunHo(res.PatientCode);
            }
            else // in case of free input
            {
                genPatCodeBtn.Enabled = false;
                btnConfirm.Enabled = true;
            }
        }
        #endregion

        #region AutogenBunho
        /// <summary>
        /// AutogenBunho
        /// </summary>
        private void AutogenBunho()
        {
            // Prevents DataValidating event fires
            fbxBunho.DataValidating -= new DataValidatingEventHandler(FindBox_DataValidating);

            // 기본값 셋팅
            this.SetDefaultValueToPatient();

            // 환자번호 땄다고 봄
            this.SetToGetBunhoVariable(true);
            // 업데이트 구분 'I'로 변경
            this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "iu_gubun", "I");
            this.grdPatient.SetItemValue(grdPatient.CurrentRowNumber, "bunho", this._bunho); //위에서 환자번호 날라가니까 여기서 다시 셋팅
            fbxBunho.SetEditValue(this._bunho);
            fbxBunho.AcceptData();

            // Re-register Validating event
            fbxBunho.DataValidating += new DataValidatingEventHandler(FindBox_DataValidating);

            // Disable fbxBunho
            //fbxBunho.Enabled = false;
        }
        #endregion

        #region genPatCodeBtn_Click
        /// <summary>
        /// genPatCodeBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genPatCodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //GetBunhoInputType();
                //Auto-gen pass?
                //pass = this.RandomString(8);
                // Auto-gen bunho?
                if (_bunhoInputType == BunhoInputType.AutoGen)
                {
                    //added 2015/07/22
                    GetBunhoInputType(true);

                    this.AutogenBunho();
                    // Disable this button
                    //genPatCodeBtn.Enabled = false;
                    btnConfirm.Enabled = true;
                    // Focus to name textbox
                    txtSuName.Focus();
                }
                else
                {
                    // Focus to fbxBunho
                    fbxBunho.Focus();
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Generates Patient code failed!", ex);
            }
        }
        #endregion

        #endregion

        #region IsValidPhoneNumber

        #region IsValidPhoneNumber
        /// <summary>
        /// IsValidPhoneNumber
        /// </summary>
        /// <returns></returns>
        private bool IsValidPhoneNumber()
        {
            double tel1;
            double tel2;

            // Accepts number contains 15 digits as maximum
            if (double.TryParse(txtTel.Text, out tel1) == false
                || double.TryParse(txtTel1.Text, out tel2) == false
                || txtTel.TextLength > 15 
                || txtTel1.TextLength > 15)
            {
                return false;
            }

            return true;
        }
        #endregion
        
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //string bunho = grdPatient.GetItemString(grdPatient.CurrentRowNumber, "bunho");
            //if (!TypeCheck.IsNull(bunho))
            //{
            //PrintOrder();
            //}
            string bunhoShow = grdPatient.GetItemString(grdPatient.CurrentRowNumber, "bunho");            
            ShowPWD showForm = new ShowPWD(bunhoShow);
            showForm.StartPosition = FormStartPosition.CenterScreen;                
            showForm.ShowDialog();
            

        }

        private void PrintOrder()
        {
            this.GetDataTables();
            DataSet ds = new DataSet();
            XtraRpPrintPatient rpt = new XtraRpPrintPatient();
            ds.Tables.Add(tbl_PatientInfo);
            rpt.DataSource = ds;
            rpt.DataMember = "tblPatientInfo";
            //rpt.ShowPreviewDialog();
            rpt.Print();

        }

        private void GetDataTables()
        {
            tbl_PatientInfo = new DataTable("tblPatientInfo");
            tbl_PatientInfo.Columns.Add("patient_name");
            tbl_PatientInfo.Columns.Add("hosp_code");
            tbl_PatientInfo.Columns.Add("bunho");
            tbl_PatientInfo.Columns.Add("pwd");
            tbl_PatientInfo.Columns.Add("hosp_name");
            tbl_PatientInfo.Columns.Add("hosp_phone");
            tbl_PatientInfo.Columns.Add("hosp_address");
            string hospCode = UserInfo.HospCode.ToString() ;
            string patientName = string.Empty;
            string bunho = grdPatient.GetItemString(grdPatient.CurrentRowNumber, "bunho");;
            string pwd =string.Empty;
            string hospName = UserInfo.HospName.ToString();
            string hospPhone = string.Empty;
            string hospAddress = string.Empty;

            OUT0101U02GetHospitalInfoArgs args = new OUT0101U02GetHospitalInfoArgs();
            args.HospCode = UserInfo.HospCode.ToString();
            args.Bunho = fbxBunho.Text.ToString();
            OUT0101U02GetHospitalInfoResult result = CloudService.Instance
                .Submit<OUT0101U02GetHospitalInfoResult, OUT0101U02GetHospitalInfoArgs>(args);
            if (result != null)
            {
                //List<OUT0101U02HospitalItemInfo> ListItem = new List<OUT0101U02HospitalItemInfo>();
                //ListItem.Add(result.HospList);
                if (result.HospList.Count > 0)
                {
                    patientName = result.HospList[0].PatientName.ToString();
                    hospPhone = result.HospList[0].Tel.ToString();
                    hospAddress = result.HospList[0].Address.ToString();
                    pwd = result.HospList[0].Password.ToString();
                }
            }
            tbl_PatientInfo.Rows.Add(patientName, hospCode, bunho, pwd, hospName, hospPhone, hospAddress);
        }

        // Moved to Cloud
        //private string RandomString(int size)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    char c;
        //    Random rand = new Random();
        //    for (int i = 0; i < size; i++)
        //    {
        //        int number = rand.Next(48, 87);
        //        if (number >= 58 && number <= 64)
        //        {
        //            i--;
        //        }
        //        else
        //        {
        //            c = Convert.ToChar(Convert.ToInt32(number));
        //            sb.Append(c);
        //        }
        //    }
        //    return sb.ToString().ToLower();
        //}
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            OpenFormExportPatient();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FormImportPatient frm = new FormImportPatient();
            frm.ShowDialog(this);
        }
        private void loadDefaultCombo()
        {
            if (NetInfo.Language == LangMode.Vi)
            {
                cbxBilling.SelectedValue = "N";
                cbxBilling.AcceptData();
            }
            if (NetInfo.Language == LangMode.Jr)
            {
                cboBunhoType.SelectedValue = "0";
                cbxBilling.SelectedValue = "I";
                cbxBilling.AcceptData();
                cboBunhoType.AcceptData();
            }
        }

        #region MovieTalk //MED-14257
        private void btnUpdateInsur_Click(object sender, EventArgs e)
        {
             string urlMss = ConfigurationSettings.AppSettings.Get("LinkMovieTalk") + GetToken() + "&patient_code=" + fbxBunho.GetDataValue() + "&session_id=" + WebSocketClient.SessionId + "&mode=3";
             GetDefaultBrowserPath(urlMss);  
        }
        private string GetToken()
        {
            string token = "";
            string url = ConfigurationSettings.AppSettings.Get("GetTokenMovieTalk") + UserInfo.HospCode;            
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = WebRequestMethods.Http.Get;
            req.Accept = "application/json";
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();

                using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                {
                   string json = sr.ReadToEnd();
                   Newtonsoft.Json.Linq.JObject genJson = Newtonsoft.Json.Linq.JObject.Parse(json);
                   token = (string)genJson["data"]["descrypt_code"];
                }
               
            }
            catch
            {

            }
            return token;
        }
        //Get open webbrowser default.
        private void GetDefaultBrowserPath(string url)
        {
            {
                string browserPath = "";
                string CHROME = "chrome.exe";
                string FIREFOX = "firefox.exe";
                string IEXPLORE = "iexplore.exe";
                bool isOpenChorme = false;
                bool isOpenFireFox = false;
                RegistryKey browserKey = null;
                try
                {
                    browserKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
                    if (browserKey == null)
                        browserKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                    string[] browserName = browserKey.GetSubKeyNames();
                    foreach (string item in browserName)
                    {
                        if (item.ToLower().StartsWith(("Google chrome").ToLower()))
                        {
                            isOpenChorme = true;
                            break;
                        }
                        else if (item.ToLower().StartsWith("firefox.exe"))
                        {
                            isOpenFireFox = true;
                        }
                    }
                    if (isOpenChorme)
                        Process.Start(CHROME, url);
                    else if (isOpenFireFox)
                        Process.Start(FIREFOX, url);
                    else Process.Start(IEXPLORE, url);
                }
                catch
                {

                }
            }
        }
        #endregion
    }
}