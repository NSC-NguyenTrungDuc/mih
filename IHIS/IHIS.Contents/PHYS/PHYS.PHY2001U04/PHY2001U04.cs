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
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Phys;
using IHIS.CloudConnector.Contracts.Results.Phys;
using IHIS.CloudConnector.Contracts.Models.Phys;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Results;
using System.Collections.Generic;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.PHYS.Properties;
#endregion

namespace IHIS.PHYS
{
    /// <summary>
    /// NUR2001U04에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class PHY2001U04 : IHIS.Framework.XScreen
    {
        #region Fields
        private string Aampm_gubun = string.Empty;
        private string mHospCode = string.Empty;

        //予約・実績一覧画面、来院履歴一覧画面表示フラグ
        private bool JissekiVisibleYN = false;
        private bool NaewonRirekiVisibleYN = false;
        private bool mPowerQuery = false;

        private IHIS.PHYS.RehaBiz mRehaBiz = null;
        private NewOrderOUT noFormOUT = new NewOrderOUT();
        private NewOrderINP noFormINP = new NewOrderINP();
        private int mReconnectCnt = 0;
        private bool mQueryFlag = false;
        private string mDoctor;
        #endregion

        #region Auto generated code

        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlLeft;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XDatePicker dtpNaewonDate;
        private IHIS.Framework.XLabel lblNaewon_date;
        private IHIS.Framework.XLabel lblGwa;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdPatientList;
        private IHIS.Framework.XButton btnDoctorChange;
        private IHIS.Framework.XButton btnBody;
        private IHIS.Framework.XButton btnOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        //        private IHIS.Framework.DataServiceSIMO dsvQuery;
        //        private IHIS.Framework.DataServiceSISO dsvDoctorChange;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XLabel lblDoctor;
        private IHIS.Framework.XDisplayBox dbxDoctor_name;
        private IHIS.Framework.XFindBox fbxDoctor;
        private IHIS.Framework.XLabel lblBunho;
        private IHIS.Framework.XDictComboBox cboGwa;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XButton btnJusangi;
        private IHIS.Framework.SingleLayout layPKOUT1001;
        private IHIS.Framework.SingleLayoutItem singleLayoutItem1;
        private XToolTip xToolTip1;
        private XButton btnConfirm;
        private XEditGridCell xEditGridCell21;
        private XButton btnEMR;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XCheckBox cbxAutoQuery;
        private Timer timer1;
        private XButton btnAllergy;
        private XButton btnPrint;
        private XEditGridCell xEditGridCell25;
        private XButton btnGamyum;
        private XDictComboBox cboTime;
        private XButton btnJubsu;
        private XPanel xPanel1;
        private XPanel pnlNaewon;
        private XRadioButton rbtNaewon;
        private XRadioButton rbtNaewonAll;
        private XRadioButton rbtMiNaewon;
        private XRadioButton rbtJinryoAll;
        private XRadioButton rbtJinryoEnd;
        private XRadioButton rbtJinryoNotEnd;
        private XButton btnDelete;
        private XEditGridCell xEditGridCell26;
        private SingleLayout layDoctorName;
        private SingleLayoutItem singleLayoutItem2;
        private XButton btnReser;
        private XButton btnJinryoEnd;
        private XPanel pnlNurse;
        private XButton btnJubsuOpen;
        private XEditGridCell xEditGridCell27;
        private XButton btnOUT0106;
        private XEditGridCell xEditGridCell28;
        private XDictComboBox cboJubsuGubun;
        private XPanel pnlPart;
        private XButton btnOrderAct;
        private XLabel lbJubsuGubun;
        private XEditGridCell xEditGridCell29;
        private XGrid grdPaCnt;
        private XGridCell xGridCell1;
        private XGridCell xGridCell2;
        private XGridCell xGridCell3;
        private XGroupBox gbxPaCnt;
        private XGridCell xGridCell4;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XButton btnBunhoChage;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XButton btnRehaJubsu;
        private XPanel pnlJisseki;
        private XEditGrid grdList;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XPanel xPanel2;
        private XLabel xLabel1;
        private XTextBox txtBR_TO;
        private XTextBox txtBR_FROM;
        private XTextBox xTextBox1;
        private XButton btnSaisin;
        private XButton btnGaisin2;
        private XButton btnGaisin1;
        private XButton btnReha;
        private XTextBox txtCnt_saisin;
        private XTextBox txtCnt_gaisin2;
        private XTextBox txtCnt_gaisin1;
        private XLabel xLabel5;
        private XLabel xLabel4;
        private XLabel xLabel3;
        private XLabel xLabel2;
        private XTextBox txtCnt_reha;
        private XLabel xLabel6;
        private XButton btnVital;
        private XLabel xLabel8;
        private XLabel xLabel7;
        private XTextBox txtPulse;
        private XPanel pnlVital;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XPanel pnlNaewonRireki;
        private XEditGrid grdOUT1001;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XPanel xPanel3;
        private XButton btnNaewonRirekiVisibleYN;
        private XButton btnJissekiVisibleYN;
        private XButton btnHealthQuestionnair;
        private XTabControl tabPHY;
        private IHIS.X.Magic.Controls.TabPage tabGairai;
        private IHIS.X.Magic.Controls.TabPage tabOUT;
        private IHIS.X.Magic.Controls.TabPage tabINP;
        private XEditGrid grdOUT;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell65;
        private XComboItem xComboItem11;
        private XComboItem xComboItem12;
        private XEditGrid grdINP;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XComboItem xComboItem19;
        private XComboItem xComboItem20;
        private Timer timer_NewOrder;
        private XCheckBox cbxAutoNewIraiCheck;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XComboItem xComboItem7;
        private XComboItem xComboItem8;
        private XComboItem xComboItem9;
        private XComboItem xComboItem10;
        private XComboItem xComboItem13;
        private XComboItem xComboItem14;
        private XComboItem xComboItem15;
        private XComboItem xComboItem16;
        private XComboItem xComboItem17;
        private XComboItem xComboItem18;
        private XDictComboBox cboNewTime;
        private XCheckBox cbxAuto_Cusor;
        private XCheckBox cbxSinryouryou;
        private XLabel xLabel9;
        private XEditGridCell xEditGridCell78;
        private XEditMask txtBT;
        private XFlatRadioButton rbtJisseki;
        private XFlatRadioButton rbtYoyaku;
        private XEditGrid grdExcel;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell103;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell111;
        private XEditGridCell xEditGridCell112;
        private XEditGridCell xEditGridCell113;
        private XEditGridCell xEditGridCell114;
        private XEditGridCell xEditGridCell115;

        private IContainer components;

        #region 소멸자
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
        #endregion

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PHY2001U04));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.btnNaewonRirekiVisibleYN = new IHIS.Framework.XButton();
            this.btnJissekiVisibleYN = new IHIS.Framework.XButton();
            this.lbJubsuGubun = new IHIS.Framework.XLabel();
            this.cboJubsuGubun = new IHIS.Framework.XDictComboBox();
            this.pnlNaewon = new IHIS.Framework.XPanel();
            this.rbtNaewonAll = new IHIS.Framework.XRadioButton();
            this.rbtMiNaewon = new IHIS.Framework.XRadioButton();
            this.rbtNaewon = new IHIS.Framework.XRadioButton();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.rbtJinryoAll = new IHIS.Framework.XRadioButton();
            this.rbtJinryoEnd = new IHIS.Framework.XRadioButton();
            this.rbtJinryoNotEnd = new IHIS.Framework.XRadioButton();
            this.cboGwa = new IHIS.Framework.XDictComboBox();
            this.lblBunho = new IHIS.Framework.XLabel();
            this.dbxDoctor_name = new IHIS.Framework.XDisplayBox();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.lblDoctor = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.lblGwa = new IHIS.Framework.XLabel();
            this.lblNaewon_date = new IHIS.Framework.XLabel();
            this.dtpNaewonDate = new IHIS.Framework.XDatePicker();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.cboNewTime = new IHIS.Framework.XDictComboBox();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.cbxAutoNewIraiCheck = new IHIS.Framework.XCheckBox();
            this.cbxAutoQuery = new IHIS.Framework.XCheckBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.tabPHY = new IHIS.Framework.XTabControl();
            this.tabGairai = new IHIS.X.Magic.Controls.TabPage();
            this.grdExcel = new IHIS.Framework.XEditGrid();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.grdPatientList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.tabOUT = new IHIS.X.Magic.Controls.TabPage();
            this.grdOUT = new IHIS.Framework.XEditGrid();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xComboItem12 = new IHIS.Framework.XComboItem();
            this.tabINP = new IHIS.X.Magic.Controls.TabPage();
            this.grdINP = new IHIS.Framework.XEditGrid();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xComboItem13 = new IHIS.Framework.XComboItem();
            this.xComboItem14 = new IHIS.Framework.XComboItem();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xComboItem15 = new IHIS.Framework.XComboItem();
            this.xComboItem16 = new IHIS.Framework.XComboItem();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xComboItem17 = new IHIS.Framework.XComboItem();
            this.xComboItem18 = new IHIS.Framework.XComboItem();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xComboItem19 = new IHIS.Framework.XComboItem();
            this.xComboItem20 = new IHIS.Framework.XComboItem();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtCnt_reha = new IHIS.Framework.XTextBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.txtCnt_saisin = new IHIS.Framework.XTextBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.txtCnt_gaisin2 = new IHIS.Framework.XTextBox();
            this.txtCnt_gaisin1 = new IHIS.Framework.XTextBox();
            this.pnlVital = new IHIS.Framework.XPanel();
            this.txtBT = new IHIS.Framework.XEditMask();
            this.cbxAuto_Cusor = new IHIS.Framework.XCheckBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.btnVital = new IHIS.Framework.XButton();
            this.txtBR_FROM = new IHIS.Framework.XTextBox();
            this.txtPulse = new IHIS.Framework.XTextBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.txtBR_TO = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnReha = new IHIS.Framework.XButton();
            this.cbxSinryouryou = new IHIS.Framework.XCheckBox();
            this.btnSaisin = new IHIS.Framework.XButton();
            this.btnJinryoEnd = new IHIS.Framework.XButton();
            this.btnGaisin2 = new IHIS.Framework.XButton();
            this.btnGaisin1 = new IHIS.Framework.XButton();
            this.gbxPaCnt = new IHIS.Framework.XGroupBox();
            this.grdPaCnt = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.pnlNurse = new IHIS.Framework.XPanel();
            this.btnDoctorChange = new IHIS.Framework.XButton();
            this.btnBody = new IHIS.Framework.XButton();
            this.btnAllergy = new IHIS.Framework.XButton();
            this.btnHealthQuestionnair = new IHIS.Framework.XButton();
            this.btnGamyum = new IHIS.Framework.XButton();
            this.btnJubsu = new IHIS.Framework.XButton();
            this.btnOUT0106 = new IHIS.Framework.XButton();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnJusangi = new IHIS.Framework.XButton();
            this.btnRehaJubsu = new IHIS.Framework.XButton();
            this.pnlPart = new IHIS.Framework.XPanel();
            this.xTextBox1 = new IHIS.Framework.XTextBox();
            this.btnReser = new IHIS.Framework.XButton();
            this.btnOrder = new IHIS.Framework.XButton();
            this.btnBunhoChage = new IHIS.Framework.XButton();
            this.btnEMR = new IHIS.Framework.XButton();
            this.btnOrderAct = new IHIS.Framework.XButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.btnJubsuOpen = new IHIS.Framework.XButton();
            this.layPKOUT1001 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xToolTip1 = new IHIS.Framework.XToolTip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.layDoctorName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.pnlJisseki = new IHIS.Framework.XPanel();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.rbtJisseki = new IHIS.Framework.XFlatRadioButton();
            this.rbtYoyaku = new IHIS.Framework.XFlatRadioButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pnlNaewonRireki = new IHIS.Framework.XPanel();
            this.grdOUT1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.timer_NewOrder = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlNaewon.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.tabPHY.SuspendLayout();
            this.tabGairai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).BeginInit();
            this.tabOUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT)).BeginInit();
            this.tabINP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.pnlVital.SuspendLayout();
            this.gbxPaCnt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaCnt)).BeginInit();
            this.pnlNurse.SuspendLayout();
            this.pnlPart.SuspendLayout();
            this.pnlJisseki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.pnlNaewonRireki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "전송_16.gif");
            this.ImageList.Images.SetKeyName(6, "EMR.ico");
            this.ImageList.Images.SetKeyName(7, "약국정보관리.ico");
            this.ImageList.Images.SetKeyName(8, "WTRS.ico");
            this.ImageList.Images.SetKeyName(9, "재진예약.gif");
            this.ImageList.Images.SetKeyName(10, "타과의뢰.ico");
            this.ImageList.Images.SetKeyName(11, "의학유전학_2.ico");
            this.ImageList.Images.SetKeyName(12, "인쇄.gif");
            this.ImageList.Images.SetKeyName(13, "재진예약_1.gif");
            this.ImageList.Images.SetKeyName(14, "항암요법.gif");
            this.ImageList.Images.SetKeyName(15, "건진운영관리.ico");
            this.ImageList.Images.SetKeyName(16, "환경설정.gif");
            this.ImageList.Images.SetKeyName(17, "삭제.gif");
            this.ImageList.Images.SetKeyName(18, "신규.gif");
            this.ImageList.Images.SetKeyName(19, "작성.gif");
            this.ImageList.Images.SetKeyName(20, "환자조회.gif");
            this.ImageList.Images.SetKeyName(21, "G_F6.gif");
            this.ImageList.Images.SetKeyName(22, "G_F7.gif");
            this.ImageList.Images.SetKeyName(23, "G_F8.gif");
            this.ImageList.Images.SetKeyName(24, "G_F9.gif");
            this.ImageList.Images.SetKeyName(25, "G_F10.gif");
            this.ImageList.Images.SetKeyName(26, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(27, "YESEN1.ICO");
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.btnNaewonRirekiVisibleYN);
            this.pnlTop.Controls.Add(this.btnJissekiVisibleYN);
            this.pnlTop.Controls.Add(this.lbJubsuGubun);
            this.pnlTop.Controls.Add(this.cboJubsuGubun);
            this.pnlTop.Controls.Add(this.pnlNaewon);
            this.pnlTop.Controls.Add(this.xPanel1);
            this.pnlTop.Controls.Add(this.cboGwa);
            this.pnlTop.Controls.Add(this.lblBunho);
            this.pnlTop.Controls.Add(this.dbxDoctor_name);
            this.pnlTop.Controls.Add(this.fbxDoctor);
            this.pnlTop.Controls.Add(this.lblDoctor);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.lblGwa);
            this.pnlTop.Controls.Add(this.lblNaewon_date);
            this.pnlTop.Controls.Add(this.dtpNaewonDate);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // btnNaewonRirekiVisibleYN
            // 
            this.btnNaewonRirekiVisibleYN.AccessibleDescription = null;
            this.btnNaewonRirekiVisibleYN.AccessibleName = null;
            resources.ApplyResources(this.btnNaewonRirekiVisibleYN, "btnNaewonRirekiVisibleYN");
            this.btnNaewonRirekiVisibleYN.BackgroundImage = null;
            this.btnNaewonRirekiVisibleYN.ImageIndex = 27;
            this.btnNaewonRirekiVisibleYN.ImageList = this.ImageList;
            this.btnNaewonRirekiVisibleYN.Name = "btnNaewonRirekiVisibleYN";
            this.btnNaewonRirekiVisibleYN.Click += new System.EventHandler(this.btnNaewonRirekiVisibleYN_Click);
            // 
            // btnJissekiVisibleYN
            // 
            this.btnJissekiVisibleYN.AccessibleDescription = null;
            this.btnJissekiVisibleYN.AccessibleName = null;
            resources.ApplyResources(this.btnJissekiVisibleYN, "btnJissekiVisibleYN");
            this.btnJissekiVisibleYN.BackgroundImage = null;
            this.btnJissekiVisibleYN.ImageIndex = 27;
            this.btnJissekiVisibleYN.ImageList = this.ImageList;
            this.btnJissekiVisibleYN.Name = "btnJissekiVisibleYN";
            this.btnJissekiVisibleYN.Click += new System.EventHandler(this.btnJissekiVisibleYN_Click);
            // 
            // lbJubsuGubun
            // 
            this.lbJubsuGubun.AccessibleDescription = null;
            this.lbJubsuGubun.AccessibleName = null;
            resources.ApplyResources(this.lbJubsuGubun, "lbJubsuGubun");
            this.lbJubsuGubun.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbJubsuGubun.EdgeRounding = false;
            this.lbJubsuGubun.Image = null;
            this.lbJubsuGubun.Name = "lbJubsuGubun";
            // 
            // cboJubsuGubun
            // 
            this.cboJubsuGubun.AccessibleDescription = null;
            this.cboJubsuGubun.AccessibleName = null;
            resources.ApplyResources(this.cboJubsuGubun, "cboJubsuGubun");
            this.cboJubsuGubun.BackgroundImage = null;
            this.cboJubsuGubun.ExecuteQuery = null;
            this.cboJubsuGubun.Name = "cboJubsuGubun";
            this.cboJubsuGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboJubsuGubun.ParamList")));
            this.cboJubsuGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboJubsuGubun.SelectedIndexChanged += new System.EventHandler(this.cboJubsuGubun_SelectedIndexChanged);
            // 
            // pnlNaewon
            // 
            this.pnlNaewon.AccessibleDescription = null;
            this.pnlNaewon.AccessibleName = null;
            resources.ApplyResources(this.pnlNaewon, "pnlNaewon");
            this.pnlNaewon.BackgroundImage = null;
            this.pnlNaewon.Controls.Add(this.rbtNaewonAll);
            this.pnlNaewon.Controls.Add(this.rbtMiNaewon);
            this.pnlNaewon.Controls.Add(this.rbtNaewon);
            this.pnlNaewon.Font = null;
            this.pnlNaewon.Name = "pnlNaewon";
            // 
            // rbtNaewonAll
            // 
            this.rbtNaewonAll.AccessibleDescription = null;
            this.rbtNaewonAll.AccessibleName = null;
            resources.ApplyResources(this.rbtNaewonAll, "rbtNaewonAll");
            this.rbtNaewonAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.rbtNaewonAll.BackgroundImage = null;
            this.rbtNaewonAll.FlatAppearance.BorderSize = 3;
            this.rbtNaewonAll.Name = "rbtNaewonAll";
            this.rbtNaewonAll.Tag = "Naewon";
            this.rbtNaewonAll.UseVisualStyleBackColor = false;
            this.rbtNaewonAll.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtMiNaewon
            // 
            this.rbtMiNaewon.AccessibleDescription = null;
            this.rbtMiNaewon.AccessibleName = null;
            resources.ApplyResources(this.rbtMiNaewon, "rbtMiNaewon");
            this.rbtMiNaewon.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.rbtMiNaewon.BackgroundImage = null;
            this.rbtMiNaewon.FlatAppearance.BorderSize = 3;
            this.rbtMiNaewon.Name = "rbtMiNaewon";
            this.rbtMiNaewon.Tag = "Naewon";
            this.rbtMiNaewon.UseVisualStyleBackColor = false;
            this.rbtMiNaewon.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtNaewon
            // 
            this.rbtNaewon.AccessibleDescription = null;
            this.rbtNaewon.AccessibleName = null;
            resources.ApplyResources(this.rbtNaewon, "rbtNaewon");
            this.rbtNaewon.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightPink);
            this.rbtNaewon.BackgroundImage = null;
            this.rbtNaewon.Checked = true;
            this.rbtNaewon.FlatAppearance.BorderSize = 3;
            this.rbtNaewon.Name = "rbtNaewon";
            this.rbtNaewon.TabStop = true;
            this.rbtNaewon.Tag = "Naewon";
            this.rbtNaewon.UseVisualStyleBackColor = false;
            this.rbtNaewon.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.rbtJinryoAll);
            this.xPanel1.Controls.Add(this.rbtJinryoEnd);
            this.xPanel1.Controls.Add(this.rbtJinryoNotEnd);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // rbtJinryoAll
            // 
            this.rbtJinryoAll.AccessibleDescription = null;
            this.rbtJinryoAll.AccessibleName = null;
            resources.ApplyResources(this.rbtJinryoAll, "rbtJinryoAll");
            this.rbtJinryoAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.PowderBlue);
            this.rbtJinryoAll.BackgroundImage = null;
            this.rbtJinryoAll.FlatAppearance.BorderSize = 3;
            this.rbtJinryoAll.Name = "rbtJinryoAll";
            this.rbtJinryoAll.Tag = "Jinryo";
            this.rbtJinryoAll.UseVisualStyleBackColor = false;
            this.rbtJinryoAll.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtJinryoEnd
            // 
            this.rbtJinryoEnd.AccessibleDescription = null;
            this.rbtJinryoEnd.AccessibleName = null;
            resources.ApplyResources(this.rbtJinryoEnd, "rbtJinryoEnd");
            this.rbtJinryoEnd.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.PowderBlue);
            this.rbtJinryoEnd.BackgroundImage = null;
            this.rbtJinryoEnd.FlatAppearance.BorderSize = 3;
            this.rbtJinryoEnd.Name = "rbtJinryoEnd";
            this.rbtJinryoEnd.Tag = "Jinryo";
            this.rbtJinryoEnd.UseVisualStyleBackColor = false;
            this.rbtJinryoEnd.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtJinryoNotEnd
            // 
            this.rbtJinryoNotEnd.AccessibleDescription = null;
            this.rbtJinryoNotEnd.AccessibleName = null;
            resources.ApplyResources(this.rbtJinryoNotEnd, "rbtJinryoNotEnd");
            this.rbtJinryoNotEnd.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightPink);
            this.rbtJinryoNotEnd.BackgroundImage = null;
            this.rbtJinryoNotEnd.Checked = true;
            this.rbtJinryoNotEnd.FlatAppearance.BorderSize = 3;
            this.rbtJinryoNotEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(195)))), ((int)(((byte)(200)))));
            this.rbtJinryoNotEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(195)))), ((int)(((byte)(200)))));
            this.rbtJinryoNotEnd.Name = "rbtJinryoNotEnd";
            this.rbtJinryoNotEnd.TabStop = true;
            this.rbtJinryoNotEnd.Tag = "Jinryo";
            this.rbtJinryoNotEnd.UseVisualStyleBackColor = false;
            this.rbtJinryoNotEnd.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.ExecuteQuery = null;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGwa.ParamList")));
            this.cboGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGwa.SelectionChangeCommitted += new System.EventHandler(this.cboGwa_SelectionChangeCommitted);
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            this.cboGwa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.cboGwa.DDLBSetting += new System.EventHandler(this.cboGwa_DDLBSetting);
            // 
            // lblBunho
            // 
            this.lblBunho.AccessibleDescription = null;
            this.lblBunho.AccessibleName = null;
            resources.ApplyResources(this.lblBunho, "lblBunho");
            this.lblBunho.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBunho.EdgeRounding = false;
            this.lblBunho.Image = null;
            this.lblBunho.Name = "lblBunho";
            // 
            // dbxDoctor_name
            // 
            this.dbxDoctor_name.AccessibleDescription = null;
            this.dbxDoctor_name.AccessibleName = null;
            resources.ApplyResources(this.dbxDoctor_name, "dbxDoctor_name");
            this.dbxDoctor_name.EdgeRounding = false;
            this.dbxDoctor_name.Image = null;
            this.dbxDoctor_name.Name = "dbxDoctor_name";
            this.dbxDoctor_name.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.AccessibleDescription = null;
            this.fbxDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxDoctor, "fbxDoctor");
            this.fbxDoctor.BackgroundImage = null;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            this.fbxDoctor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDoctor_FindClick);
            // 
            // lblDoctor
            // 
            this.lblDoctor.AccessibleDescription = null;
            this.lblDoctor.AccessibleName = null;
            resources.ApplyResources(this.lblDoctor, "lblDoctor");
            this.lblDoctor.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDoctor.EdgeRounding = false;
            this.lblDoctor.Image = null;
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackgroundImage = null;
            this.paBox.Name = "paBox";
            this.paBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.paBox.Validating += new System.ComponentModel.CancelEventHandler(this.paBox_Validating);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // lblGwa
            // 
            this.lblGwa.AccessibleDescription = null;
            this.lblGwa.AccessibleName = null;
            resources.ApplyResources(this.lblGwa, "lblGwa");
            this.lblGwa.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblGwa.EdgeRounding = false;
            this.lblGwa.Image = null;
            this.lblGwa.Name = "lblGwa";
            this.lblGwa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // lblNaewon_date
            // 
            this.lblNaewon_date.AccessibleDescription = null;
            this.lblNaewon_date.AccessibleName = null;
            resources.ApplyResources(this.lblNaewon_date, "lblNaewon_date");
            this.lblNaewon_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNaewon_date.EdgeRounding = false;
            this.lblNaewon_date.Image = null;
            this.lblNaewon_date.Name = "lblNaewon_date";
            this.lblNaewon_date.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // dtpNaewonDate
            // 
            this.dtpNaewonDate.AccessibleDescription = null;
            this.dtpNaewonDate.AccessibleName = null;
            resources.ApplyResources(this.dtpNaewonDate, "dtpNaewonDate");
            this.dtpNaewonDate.BackgroundImage = null;
            this.dtpNaewonDate.IsVietnameseYearType = false;
            this.dtpNaewonDate.Name = "dtpNaewonDate";
            this.dtpNaewonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpNaewonDate_DataValidating);
            this.dtpNaewonDate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.cboNewTime);
            this.pnlBottom.Controls.Add(this.cboTime);
            this.pnlBottom.Controls.Add(this.btnConfirm);
            this.pnlBottom.Controls.Add(this.cbxAutoNewIraiCheck);
            this.pnlBottom.Controls.Add(this.cbxAutoQuery);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // cboNewTime
            // 
            this.cboNewTime.AccessibleDescription = null;
            this.cboNewTime.AccessibleName = null;
            resources.ApplyResources(this.cboNewTime, "cboNewTime");
            this.cboNewTime.BackgroundImage = null;
            this.cboNewTime.ExecuteQuery = null;
            this.cboNewTime.Name = "cboNewTime";
            this.cboNewTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboNewTime.ParamList")));
            this.cboNewTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboNewTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.cboNewTime.SelectedValueChanged += new System.EventHandler(this.cboNewTime_SelectedValueChanged);
            // 
            // cboTime
            // 
            this.cboTime.AccessibleDescription = null;
            this.cboTime.AccessibleName = null;
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.BackgroundImage = null;
            this.cboTime.ExecuteQuery = null;
            this.cboTime.Name = "cboTime";
            this.cboTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTime.ParamList")));
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.cboTime.SelectedValueChanged += new System.EventHandler(this.cboTime_SelectedValueChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleDescription = null;
            this.btnConfirm.AccessibleName = null;
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.BackgroundImage = null;
            this.btnConfirm.ImageIndex = 5;
            this.btnConfirm.ImageList = this.ImageList;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cbxAutoNewIraiCheck
            // 
            this.cbxAutoNewIraiCheck.AccessibleDescription = null;
            this.cbxAutoNewIraiCheck.AccessibleName = null;
            resources.ApplyResources(this.cbxAutoNewIraiCheck, "cbxAutoNewIraiCheck");
            this.cbxAutoNewIraiCheck.BackgroundImage = null;
            this.cbxAutoNewIraiCheck.Checked = true;
            this.cbxAutoNewIraiCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoNewIraiCheck.Name = "cbxAutoNewIraiCheck";
            this.cbxAutoNewIraiCheck.UseVisualStyleBackColor = false;
            this.cbxAutoNewIraiCheck.CheckedChanged += new System.EventHandler(this.cbxAutoNewIraiCheck_CheckedChanged);
            this.cbxAutoNewIraiCheck.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // cbxAutoQuery
            // 
            this.cbxAutoQuery.AccessibleDescription = null;
            this.cbxAutoQuery.AccessibleName = null;
            resources.ApplyResources(this.cbxAutoQuery, "cbxAutoQuery");
            this.cbxAutoQuery.BackgroundImage = null;
            this.cbxAutoQuery.Checked = true;
            this.cbxAutoQuery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoQuery.Name = "cbxAutoQuery";
            this.cbxAutoQuery.UseVisualStyleBackColor = false;
            this.cbxAutoQuery.CheckedChanged += new System.EventHandler(this.cbxAutoQuery_CheckedChanged);
            this.cbxAutoQuery.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, global::IHIS.PHYS.Properties.Resources.XMessageBox4),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, Resources.Xlabel_Process, -1, global::IHIS.PHYS.Properties.Resources.XMessageBox4),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, global::IHIS.PHYS.Properties.Resources.XMessageBox4),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, "", -1, global::IHIS.PHYS.Properties.Resources.XMessageBox4),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, global::IHIS.PHYS.Properties.Resources.XMessageBox4)});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.AccessibleDescription = null;
            this.pnlLeft.AccessibleName = null;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.BackgroundImage = null;
            this.pnlLeft.Controls.Add(this.tabPHY);
            this.pnlLeft.Font = null;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // tabPHY
            // 
            this.tabPHY.AccessibleDescription = null;
            this.tabPHY.AccessibleName = null;
            resources.ApplyResources(this.tabPHY, "tabPHY");
            this.tabPHY.BackgroundImage = null;
            this.tabPHY.Font = null;
            this.tabPHY.IDEPixelArea = true;
            this.tabPHY.IDEPixelBorder = false;
            this.tabPHY.Name = "tabPHY";
            this.tabPHY.SelectedIndex = 0;
            this.tabPHY.SelectedTab = this.tabGairai;
            this.tabPHY.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabGairai,
            this.tabOUT,
            this.tabINP});
            this.tabPHY.SelectionChanged += new System.EventHandler(this.tabPHY_SelectionChanged);
            // 
            // tabGairai
            // 
            this.tabGairai.AccessibleDescription = null;
            this.tabGairai.AccessibleName = null;
            resources.ApplyResources(this.tabGairai, "tabGairai");
            this.tabGairai.BackgroundImage = null;
            this.tabGairai.Controls.Add(this.grdExcel);
            this.tabGairai.Controls.Add(this.grdPatientList);
            this.tabGairai.Name = "tabGairai";
            this.tabGairai.Tag = "0";
            // 
            // grdExcel
            // 
            resources.ApplyResources(this.grdExcel, "grdExcel");
            this.grdExcel.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell86,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell103,
            this.xEditGridCell105,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115});
            this.grdExcel.ColPerLine = 20;
            this.grdExcel.Cols = 21;
            this.grdExcel.ExecuteQuery = null;
            this.grdExcel.FixedCols = 1;
            this.grdExcel.FixedRows = 1;
            this.grdExcel.HeaderHeights.Add(33);
            this.grdExcel.Name = "grdExcel";
            this.grdExcel.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdExcel.ParamList")));
            this.grdExcel.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdExcel.RowHeaderVisible = true;
            this.grdExcel.Rows = 2;
            this.grdExcel.ToolTipActive = true;
            this.grdExcel.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdExcel_QueryStarting);
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.ApplyPaintingEvent = true;
            this.xEditGridCell80.CellName = "gwa_name";
            this.xEditGridCell80.CellWidth = 62;
            this.xEditGridCell80.Col = 8;
            this.xEditGridCell80.EnableSort = true;
            this.xEditGridCell80.ExecuteQuery = null;
            this.xEditGridCell80.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsReadOnly = true;
            this.xEditGridCell80.IsUpdatable = false;
            this.xEditGridCell80.IsUpdCol = false;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.ApplyPaintingEvent = true;
            this.xEditGridCell81.CellName = "bunho";
            this.xEditGridCell81.CellWidth = 70;
            this.xEditGridCell81.Col = 9;
            this.xEditGridCell81.EnableSort = true;
            this.xEditGridCell81.ExecuteQuery = null;
            this.xEditGridCell81.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.IsUpdatable = false;
            this.xEditGridCell81.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.ApplyPaintingEvent = true;
            this.xEditGridCell82.CellName = "suname";
            this.xEditGridCell82.CellWidth = 90;
            this.xEditGridCell82.Col = 10;
            this.xEditGridCell82.EnableSort = true;
            this.xEditGridCell82.ExecuteQuery = null;
            this.xEditGridCell82.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.IsUpdatable = false;
            this.xEditGridCell82.IsUpdCol = false;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.ApplyPaintingEvent = true;
            this.xEditGridCell83.CellName = "suname2";
            this.xEditGridCell83.CellWidth = 90;
            this.xEditGridCell83.Col = 11;
            this.xEditGridCell83.EnableSort = true;
            this.xEditGridCell83.ExecuteQuery = null;
            this.xEditGridCell83.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsReadOnly = true;
            this.xEditGridCell83.IsUpdatable = false;
            this.xEditGridCell83.IsUpdCol = false;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.ApplyPaintingEvent = true;
            this.xEditGridCell86.CellName = "doctor_name";
            this.xEditGridCell86.CellWidth = 69;
            this.xEditGridCell86.Col = 13;
            this.xEditGridCell86.EnableSort = true;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.IsUpdatable = false;
            this.xEditGridCell86.IsUpdCol = false;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.ApplyPaintingEvent = true;
            this.xEditGridCell89.CellName = "birth";
            this.xEditGridCell89.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell89.Col = 12;
            this.xEditGridCell89.EnableSort = true;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsJapanYearType = true;
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsUpdCol = false;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "age_sex";
            this.xEditGridCell90.Col = 16;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.IsUpdatable = false;
            this.xEditGridCell90.IsUpdCol = false;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.ApplyPaintingEvent = true;
            this.xEditGridCell92.CellName = "jubsu_time";
            this.xEditGridCell92.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell92.CellWidth = 45;
            this.xEditGridCell92.Col = 6;
            this.xEditGridCell92.EnableSort = true;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsUpdatable = false;
            this.xEditGridCell92.IsUpdCol = false;
            this.xEditGridCell92.Mask = "HH:MI";
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.ApplyPaintingEvent = true;
            this.xEditGridCell93.CellName = "order_end_yn";
            this.xEditGridCell93.CellWidth = 33;
            this.xEditGridCell93.Col = 4;
            this.xEditGridCell93.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell93.EnableSort = true;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsUpdatable = false;
            this.xEditGridCell93.IsUpdCol = false;
            this.xEditGridCell93.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.ApplyPaintingEvent = true;
            this.xEditGridCell94.CellName = "hold_yn";
            this.xEditGridCell94.CellWidth = 33;
            this.xEditGridCell94.Col = 3;
            this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell94.EnableSort = true;
            this.xEditGridCell94.ExecuteQuery = null;
            this.xEditGridCell94.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.IsUpdCol = false;
            this.xEditGridCell94.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.ApplyPaintingEvent = true;
            this.xEditGridCell98.CellName = "sunab_yn";
            this.xEditGridCell98.CellWidth = 33;
            this.xEditGridCell98.Col = 5;
            this.xEditGridCell98.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell98.EnableSort = true;
            this.xEditGridCell98.ExecuteQuery = null;
            this.xEditGridCell98.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsUpdatable = false;
            this.xEditGridCell98.IsUpdCol = false;
            this.xEditGridCell98.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.ApplyPaintingEvent = true;
            this.xEditGridCell99.CellName = "naewon_yn";
            this.xEditGridCell99.CellWidth = 33;
            this.xEditGridCell99.Col = 2;
            this.xEditGridCell99.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell99.EnableSort = true;
            this.xEditGridCell99.ExecuteQuery = null;
            this.xEditGridCell99.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsReadOnly = true;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.ApplyPaintingEvent = true;
            this.xEditGridCell100.CellName = "jubsu_gubun";
            this.xEditGridCell100.CellWidth = 92;
            this.xEditGridCell100.Col = 14;
            this.xEditGridCell100.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell100.EnableSort = true;
            this.xEditGridCell100.ExecuteQuery = null;
            this.xEditGridCell100.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.MaxDropDownItems = 11;
            this.xEditGridCell100.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.AlterateRowBackColor = IHIS.Framework.XColor.XGridColHeaderGradientStartColor;
            this.xEditGridCell103.CellName = "arrive_time";
            this.xEditGridCell103.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell103.CellWidth = 45;
            this.xEditGridCell103.Col = 7;
            this.xEditGridCell103.EnableSort = true;
            this.xEditGridCell103.ExecuteQuery = null;
            this.xEditGridCell103.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.Mask = "HH:MI";
            this.xEditGridCell103.RowBackColor = IHIS.Framework.XColor.XGridColHeaderGradientStartColor;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.ApplyPaintingEvent = true;
            this.xEditGridCell105.CellName = "last_naewon";
            this.xEditGridCell105.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell105.Col = 15;
            this.xEditGridCell105.ExecuteQuery = null;
            this.xEditGridCell105.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsJapanYearType = true;
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsUpdatable = false;
            this.xEditGridCell105.IsUpdCol = false;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "gaein";
            this.xEditGridCell111.CellWidth = 1;
            this.xEditGridCell111.Col = 17;
            this.xEditGridCell111.ExecuteQuery = null;
            this.xEditGridCell111.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsUpdCol = false;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "bp_from";
            this.xEditGridCell112.CellWidth = 35;
            this.xEditGridCell112.Col = 18;
            this.xEditGridCell112.EnableSort = true;
            this.xEditGridCell112.ExecuteQuery = null;
            this.xEditGridCell112.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "bp_to";
            this.xEditGridCell113.CellWidth = 35;
            this.xEditGridCell113.Col = 19;
            this.xEditGridCell113.EnableSort = true;
            this.xEditGridCell113.ExecuteQuery = null;
            this.xEditGridCell113.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "pulse";
            this.xEditGridCell114.CellWidth = 35;
            this.xEditGridCell114.Col = 20;
            this.xEditGridCell114.EnableSort = true;
            this.xEditGridCell114.ExecuteQuery = null;
            this.xEditGridCell114.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsUpdatable = false;
            this.xEditGridCell114.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "bt";
            this.xEditGridCell115.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell115.CellWidth = 35;
            this.xEditGridCell115.Col = 1;
            this.xEditGridCell115.DecimalDigits = 1;
            this.xEditGridCell115.ExecuteQuery = null;
            this.xEditGridCell115.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdPatientList
            // 
            resources.ApplyResources(this.grdPatientList, "grdPatientList");
            this.grdPatientList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell12,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell30,
            this.xEditGridCell29,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell78,
            this.xEditGridCell31});
            this.grdPatientList.ColPerLine = 21;
            this.grdPatientList.Cols = 22;
            this.grdPatientList.ExecuteQuery = null;
            this.grdPatientList.FixedCols = 1;
            this.grdPatientList.FixedRows = 1;
            this.grdPatientList.HeaderHeights.Add(33);
            this.grdPatientList.Name = "grdPatientList";
            this.grdPatientList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatientList.ParamList")));
            this.grdPatientList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdPatientList.RowHeaderVisible = true;
            this.grdPatientList.Rows = 2;
            this.grdPatientList.ToolTipActive = true;
            this.grdPatientList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdPatientList_KeyDown);
            this.grdPatientList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPatientList_GridColumnChanged);
            this.grdPatientList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPatientList_QueryEnd);
            this.grdPatientList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.grdPatientList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdPatientList_MouseClick);
            this.grdPatientList.GridSorted += new System.EventHandler(this.grdPatientList_GridSorted);
            this.grdPatientList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPatientList_RowFocusChanged);
            this.grdPatientList.DoubleClick += new System.EventHandler(this.grdPatientList_DoubleClick);
            this.grdPatientList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPatientList_GridCellPainting);
            this.grdPatientList.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdPatientList_ItemValueChanging);
            this.grdPatientList.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdPatientList_GridColumnProtectModify);
            this.grdPatientList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPatientList_QueryStarting);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gwa";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.ApplyPaintingEvent = true;
            this.xEditGridCell12.CellName = "gwa_name";
            this.xEditGridCell12.CellWidth = 62;
            this.xEditGridCell12.Col = 8;
            this.xEditGridCell12.EnableSort = true;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.ApplyPaintingEvent = true;
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 70;
            this.xEditGridCell1.Col = 9;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.ApplyPaintingEvent = true;
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.CellWidth = 90;
            this.xEditGridCell2.Col = 10;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsUpdCol = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.ApplyPaintingEvent = true;
            this.xEditGridCell3.CellName = "suname2";
            this.xEditGridCell3.CellWidth = 90;
            this.xEditGridCell3.Col = 11;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "naewon_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ApplyPaintingEvent = true;
            this.xEditGridCell7.CellName = "doctor_name";
            this.xEditGridCell7.CellWidth = 69;
            this.xEditGridCell7.Col = 13;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "naewon_type";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "jubsu_no";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.ApplyPaintingEvent = true;
            this.xEditGridCell10.CellName = "birth";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = 12;
            this.xEditGridCell10.EnableSort = true;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsJapanYearType = true;
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "age_sex";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "pkout1001";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.ApplyPaintingEvent = true;
            this.xEditGridCell14.CellName = "jubsu_time";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell14.CellWidth = 45;
            this.xEditGridCell14.Col = 6;
            this.xEditGridCell14.EnableSort = true;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.Mask = "HH:MI";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.ApplyPaintingEvent = true;
            this.xEditGridCell15.CellName = "order_end_yn";
            this.xEditGridCell15.CellWidth = 33;
            this.xEditGridCell15.Col = 4;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell15.EnableSort = true;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.ApplyPaintingEvent = true;
            this.xEditGridCell16.CellName = "hold_yn";
            this.xEditGridCell16.CellWidth = 33;
            this.xEditGridCell16.Col = 3;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell16.EnableSort = true;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "result_yn";
            this.xEditGridCell17.CellWidth = 35;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "reser_yn";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "ipwon_yn";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.ApplyPaintingEvent = true;
            this.xEditGridCell20.CellName = "sunab_yn";
            this.xEditGridCell20.CellWidth = 33;
            this.xEditGridCell20.Col = 5;
            this.xEditGridCell20.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell20.EnableSort = true;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.ApplyPaintingEvent = true;
            this.xEditGridCell21.CellName = "naewon_yn";
            this.xEditGridCell21.CellWidth = 33;
            this.xEditGridCell21.Col = 2;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell21.EnableSort = true;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.ApplyPaintingEvent = true;
            this.xEditGridCell22.CellName = "jubsu_gubun";
            this.xEditGridCell22.CellWidth = 92;
            this.xEditGridCell22.Col = 14;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell22.EnableSort = true;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.MaxDropDownItems = 11;
            this.xEditGridCell22.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "jubsu_gubun_name";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsUpdCol = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "remark";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridColHeaderGradientStartColor;
            this.xEditGridCell25.CellName = "arrive_time";
            this.xEditGridCell25.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell25.CellWidth = 45;
            this.xEditGridCell25.Col = 7;
            this.xEditGridCell25.EnableSort = true;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.Mask = "HH:MI";
            this.xEditGridCell25.RowBackColor = IHIS.Framework.XColor.XGridColHeaderGradientStartColor;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "gubun";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.ApplyPaintingEvent = true;
            this.xEditGridCell27.CellName = "last_naewon";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell27.Col = 15;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsJapanYearType = true;
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.IsUpdCol = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.ApplyPaintingEvent = true;
            this.xEditGridCell28.CellName = "ocs_comment";
            this.xEditGridCell28.CellWidth = 35;
            this.xEditGridCell28.Col = 16;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.IsUpdCol = false;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "chojae";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "group_key";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "bunho_type";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "kaigo_yn";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "gaein";
            this.xEditGridCell34.CellWidth = 1;
            this.xEditGridCell34.Col = 17;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "bp_from";
            this.xEditGridCell47.CellWidth = 35;
            this.xEditGridCell47.Col = 18;
            this.xEditGridCell47.EnableSort = true;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdatable = false;
            this.xEditGridCell47.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "bp_to";
            this.xEditGridCell48.CellWidth = 35;
            this.xEditGridCell48.Col = 19;
            this.xEditGridCell48.EnableSort = true;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "pulse";
            this.xEditGridCell49.CellWidth = 35;
            this.xEditGridCell49.Col = 20;
            this.xEditGridCell49.EnableSort = true;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "bt";
            this.xEditGridCell78.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell78.CellWidth = 35;
            this.xEditGridCell78.Col = 21;
            this.xEditGridCell78.DecimalDigits = 1;
            this.xEditGridCell78.ExecuteQuery = null;
            this.xEditGridCell78.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsUpdatable = false;
            this.xEditGridCell78.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell31.CellName = "icon";
            this.xEditGridCell31.CellWidth = 25;
            this.xEditGridCell31.Col = 1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabOUT
            // 
            this.tabOUT.AccessibleDescription = null;
            this.tabOUT.AccessibleName = null;
            resources.ApplyResources(this.tabOUT, "tabOUT");
            this.tabOUT.BackgroundImage = null;
            this.tabOUT.Controls.Add(this.grdOUT);
            this.tabOUT.Name = "tabOUT";
            this.tabOUT.Selected = false;
            this.tabOUT.Tag = "1";
            // 
            // grdOUT
            // 
            resources.ApplyResources(this.grdOUT, "grdOUT");
            this.grdOUT.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell54,
            this.xEditGridCell65,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64});
            this.grdOUT.ColPerLine = 12;
            this.grdOUT.Cols = 12;
            this.grdOUT.ExecuteQuery = null;
            this.grdOUT.FixedRows = 1;
            this.grdOUT.HeaderHeights.Add(21);
            this.grdOUT.Name = "grdOUT";
            this.grdOUT.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT.ParamList")));
            this.grdOUT.Rows = 2;
            this.grdOUT.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOUT_QueryStarting);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "order_date";
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "bunho";
            this.xEditGridCell65.Col = 1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsReadOnly = true;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellLen = 50;
            this.xEditGridCell55.CellName = "suname";
            this.xEditGridCell55.Col = 2;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsReadOnly = true;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellLen = 50;
            this.xEditGridCell56.CellName = "suname2";
            this.xEditGridCell56.Col = 3;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellLen = 50;
            this.xEditGridCell57.CellName = "doctor_name";
            this.xEditGridCell57.Col = 4;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "hangmog_code";
            this.xEditGridCell58.CellWidth = 78;
            this.xEditGridCell58.Col = 5;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsReadOnly = true;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellLen = 50;
            this.xEditGridCell59.CellName = "hangmog_name";
            this.xEditGridCell59.CellWidth = 167;
            this.xEditGridCell59.Col = 6;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsReadOnly = true;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "pt_flag";
            this.xEditGridCell60.CellWidth = 30;
            this.xEditGridCell60.Col = 7;
            this.xEditGridCell60.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell60.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "Y";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = global::IHIS.PHYS.Properties.Resources.XMessageBox4;
            this.xComboItem2.ValueItem = "N";
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "ot_flag";
            this.xEditGridCell61.CellWidth = 30;
            this.xEditGridCell61.Col = 8;
            this.xEditGridCell61.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell61.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "Y";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = global::IHIS.PHYS.Properties.Resources.XMessageBox4;
            this.xComboItem4.ValueItem = "N";
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "st_flag";
            this.xEditGridCell62.CellWidth = 30;
            this.xEditGridCell62.Col = 9;
            this.xEditGridCell62.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6});
            this.xEditGridCell62.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "Y";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = global::IHIS.PHYS.Properties.Resources.XMessageBox4;
            this.xComboItem6.ValueItem = "N";
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "bu_flag";
            this.xEditGridCell63.CellWidth = 30;
            this.xEditGridCell63.Col = 10;
            this.xEditGridCell63.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem7,
            this.xComboItem8});
            this.xEditGridCell63.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "Y";
            // 
            // xComboItem8
            // 
            this.xComboItem8.DisplayItem = global::IHIS.PHYS.Properties.Resources.XMessageBox4;
            this.xComboItem8.ValueItem = "N";
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "ocs_flag";
            this.xEditGridCell64.CellWidth = 53;
            this.xEditGridCell64.Col = 11;
            this.xEditGridCell64.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem11,
            this.xComboItem12});
            this.xEditGridCell64.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsReadOnly = true;
            // 
            // xComboItem11
            // 
            resources.ApplyResources(this.xComboItem11, "xComboItem11");
            this.xComboItem11.ValueItem = "1";
            // 
            // xComboItem12
            // 
            resources.ApplyResources(this.xComboItem12, "xComboItem12");
            this.xComboItem12.ValueItem = "3";
            // 
            // tabINP
            // 
            this.tabINP.AccessibleDescription = null;
            this.tabINP.AccessibleName = null;
            resources.ApplyResources(this.tabINP, "tabINP");
            this.tabINP.BackgroundImage = null;
            this.tabINP.Controls.Add(this.grdINP);
            this.tabINP.Name = "tabINP";
            this.tabINP.Selected = false;
            this.tabINP.Tag = "2";
            // 
            // grdINP
            // 
            resources.ApplyResources(this.grdINP, "grdINP");
            this.grdINP.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell74,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77});
            this.grdINP.ColPerLine = 12;
            this.grdINP.Cols = 12;
            this.grdINP.ExecuteQuery = null;
            this.grdINP.FixedRows = 1;
            this.grdINP.HeaderHeights.Add(21);
            this.grdINP.Name = "grdINP";
            this.grdINP.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdINP.ParamList")));
            this.grdINP.Rows = 2;
            this.grdINP.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP_QueryStarting);
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "order_date";
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "bunho";
            this.xEditGridCell67.Col = 1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsReadOnly = true;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellLen = 50;
            this.xEditGridCell68.CellName = "suname";
            this.xEditGridCell68.Col = 2;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsReadOnly = true;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellLen = 50;
            this.xEditGridCell69.CellName = "suname2";
            this.xEditGridCell69.Col = 3;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellLen = 50;
            this.xEditGridCell70.CellName = "doctor_name";
            this.xEditGridCell70.Col = 4;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsReadOnly = true;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "hangmog_code";
            this.xEditGridCell71.CellWidth = 78;
            this.xEditGridCell71.Col = 5;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsReadOnly = true;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellLen = 50;
            this.xEditGridCell72.CellName = "hangmog_name";
            this.xEditGridCell72.CellWidth = 167;
            this.xEditGridCell72.Col = 6;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "pt_flag";
            this.xEditGridCell73.CellWidth = 30;
            this.xEditGridCell73.Col = 7;
            this.xEditGridCell73.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem9,
            this.xComboItem10});
            this.xEditGridCell73.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsReadOnly = true;
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "Y";
            // 
            // xComboItem10
            // 
            resources.ApplyResources(this.xComboItem10, "xComboItem10");
            this.xComboItem10.ValueItem = "N";
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "ot_flag";
            this.xEditGridCell74.CellWidth = 30;
            this.xEditGridCell74.Col = 8;
            this.xEditGridCell74.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem13,
            this.xComboItem14});
            this.xEditGridCell74.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsReadOnly = true;
            // 
            // xComboItem13
            // 
            resources.ApplyResources(this.xComboItem13, "xComboItem13");
            this.xComboItem13.ValueItem = "Y";
            // 
            // xComboItem14
            // 
            this.xComboItem14.DisplayItem = global::IHIS.PHYS.Properties.Resources.XMessageBox4;
            this.xComboItem14.ValueItem = "N";
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "st_flag";
            this.xEditGridCell75.CellWidth = 30;
            this.xEditGridCell75.Col = 9;
            this.xEditGridCell75.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem15,
            this.xComboItem16});
            this.xEditGridCell75.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsReadOnly = true;
            // 
            // xComboItem15
            // 
            resources.ApplyResources(this.xComboItem15, "xComboItem15");
            this.xComboItem15.ValueItem = "Y";
            // 
            // xComboItem16
            // 
            this.xComboItem16.DisplayItem = global::IHIS.PHYS.Properties.Resources.XMessageBox4;
            this.xComboItem16.ValueItem = "N";
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "bu_flag";
            this.xEditGridCell76.CellWidth = 30;
            this.xEditGridCell76.Col = 10;
            this.xEditGridCell76.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem17,
            this.xComboItem18});
            this.xEditGridCell76.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsReadOnly = true;
            // 
            // xComboItem17
            // 
            resources.ApplyResources(this.xComboItem17, "xComboItem17");
            this.xComboItem17.ValueItem = "Y";
            // 
            // xComboItem18
            // 
            this.xComboItem18.DisplayItem = global::IHIS.PHYS.Properties.Resources.XMessageBox4;
            this.xComboItem18.ValueItem = "N";
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "ocs_flag";
            this.xEditGridCell77.CellWidth = 53;
            this.xEditGridCell77.Col = 11;
            this.xEditGridCell77.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem19,
            this.xComboItem20});
            this.xEditGridCell77.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsReadOnly = true;
            // 
            // xComboItem19
            // 
            resources.ApplyResources(this.xComboItem19, "xComboItem19");
            this.xComboItem19.ValueItem = "1";
            // 
            // xComboItem20
            // 
            resources.ApplyResources(this.xComboItem20, "xComboItem20");
            this.xComboItem20.ValueItem = "3";
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.xPanel3);
            this.pnlFill.Controls.Add(this.pnlVital);
            this.pnlFill.Controls.Add(this.btnReha);
            this.pnlFill.Controls.Add(this.cbxSinryouryou);
            this.pnlFill.Controls.Add(this.btnSaisin);
            this.pnlFill.Controls.Add(this.btnJinryoEnd);
            this.pnlFill.Controls.Add(this.btnGaisin2);
            this.pnlFill.Controls.Add(this.btnGaisin1);
            this.pnlFill.Controls.Add(this.gbxPaCnt);
            this.pnlFill.Controls.Add(this.pnlNurse);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.xLabel3);
            this.xPanel3.Controls.Add(this.xLabel4);
            this.xPanel3.Controls.Add(this.txtCnt_reha);
            this.xPanel3.Controls.Add(this.xLabel5);
            this.xPanel3.Controls.Add(this.txtCnt_saisin);
            this.xPanel3.Controls.Add(this.xLabel6);
            this.xPanel3.Controls.Add(this.txtCnt_gaisin2);
            this.xPanel3.Controls.Add(this.txtCnt_gaisin1);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // txtCnt_reha
            // 
            this.txtCnt_reha.AccessibleDescription = null;
            this.txtCnt_reha.AccessibleName = null;
            resources.ApplyResources(this.txtCnt_reha, "txtCnt_reha");
            this.txtCnt_reha.BackgroundImage = null;
            this.txtCnt_reha.Name = "txtCnt_reha";
            this.txtCnt_reha.ReadOnly = true;
            this.txtCnt_reha.TabStop = false;
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // txtCnt_saisin
            // 
            this.txtCnt_saisin.AccessibleDescription = null;
            this.txtCnt_saisin.AccessibleName = null;
            resources.ApplyResources(this.txtCnt_saisin, "txtCnt_saisin");
            this.txtCnt_saisin.BackgroundImage = null;
            this.txtCnt_saisin.Name = "txtCnt_saisin";
            this.txtCnt_saisin.ReadOnly = true;
            this.txtCnt_saisin.TabStop = false;
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // txtCnt_gaisin2
            // 
            this.txtCnt_gaisin2.AccessibleDescription = null;
            this.txtCnt_gaisin2.AccessibleName = null;
            resources.ApplyResources(this.txtCnt_gaisin2, "txtCnt_gaisin2");
            this.txtCnt_gaisin2.BackgroundImage = null;
            this.txtCnt_gaisin2.Name = "txtCnt_gaisin2";
            this.txtCnt_gaisin2.ReadOnly = true;
            this.txtCnt_gaisin2.TabStop = false;
            // 
            // txtCnt_gaisin1
            // 
            this.txtCnt_gaisin1.AccessibleDescription = null;
            this.txtCnt_gaisin1.AccessibleName = null;
            resources.ApplyResources(this.txtCnt_gaisin1, "txtCnt_gaisin1");
            this.txtCnt_gaisin1.BackgroundImage = null;
            this.txtCnt_gaisin1.Name = "txtCnt_gaisin1";
            this.txtCnt_gaisin1.ReadOnly = true;
            this.txtCnt_gaisin1.TabStop = false;
            // 
            // pnlVital
            // 
            this.pnlVital.AccessibleDescription = null;
            this.pnlVital.AccessibleName = null;
            resources.ApplyResources(this.pnlVital, "pnlVital");
            this.pnlVital.BackgroundImage = null;
            this.pnlVital.Controls.Add(this.txtBT);
            this.pnlVital.Controls.Add(this.cbxAuto_Cusor);
            this.pnlVital.Controls.Add(this.xLabel9);
            this.pnlVital.Controls.Add(this.xLabel8);
            this.pnlVital.Controls.Add(this.btnVital);
            this.pnlVital.Controls.Add(this.txtBR_FROM);
            this.pnlVital.Controls.Add(this.txtPulse);
            this.pnlVital.Controls.Add(this.xLabel7);
            this.pnlVital.Controls.Add(this.txtBR_TO);
            this.pnlVital.Controls.Add(this.xLabel2);
            this.pnlVital.Font = null;
            this.pnlVital.Name = "pnlVital";
            // 
            // txtBT
            // 
            this.txtBT.AccessibleDescription = null;
            this.txtBT.AccessibleName = null;
            resources.ApplyResources(this.txtBT, "txtBT");
            this.txtBT.BackgroundImage = null;
            this.txtBT.DecimalDigits = 1;
            this.txtBT.EditMaskType = IHIS.Framework.MaskType.Decimal;
            this.txtBT.EditVietnameseMaskType = IHIS.Framework.MaskType.Decimal;
            this.txtBT.IsVietnameseYearType = false;
            this.txtBT.Name = "txtBT";
            // 
            // cbxAuto_Cusor
            // 
            this.cbxAuto_Cusor.AccessibleDescription = null;
            this.cbxAuto_Cusor.AccessibleName = null;
            resources.ApplyResources(this.cbxAuto_Cusor, "cbxAuto_Cusor");
            this.cbxAuto_Cusor.BackgroundImage = null;
            this.cbxAuto_Cusor.Checked = true;
            this.cbxAuto_Cusor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAuto_Cusor.Name = "cbxAuto_Cusor";
            this.cbxAuto_Cusor.UseVisualStyleBackColor = false;
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // btnVital
            // 
            this.btnVital.AccessibleDescription = null;
            this.btnVital.AccessibleName = null;
            resources.ApplyResources(this.btnVital, "btnVital");
            this.btnVital.BackgroundImage = null;
            this.btnVital.Name = "btnVital";
            this.btnVital.Click += new System.EventHandler(this.btnVital_Click);
            // 
            // txtBR_FROM
            // 
            this.txtBR_FROM.AccessibleDescription = null;
            this.txtBR_FROM.AccessibleName = null;
            resources.ApplyResources(this.txtBR_FROM, "txtBR_FROM");
            this.txtBR_FROM.BackgroundImage = null;
            this.txtBR_FROM.Name = "txtBR_FROM";
            this.txtBR_FROM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBoInt_KeyPress);
            // 
            // txtPulse
            // 
            this.txtPulse.AccessibleDescription = null;
            this.txtPulse.AccessibleName = null;
            resources.ApplyResources(this.txtPulse, "txtPulse");
            this.txtPulse.BackgroundImage = null;
            this.txtPulse.Name = "txtPulse";
            this.txtPulse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBoInt_KeyPress);
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // txtBR_TO
            // 
            this.txtBR_TO.AccessibleDescription = null;
            this.txtBR_TO.AccessibleName = null;
            resources.ApplyResources(this.txtBR_TO, "txtBR_TO");
            this.txtBR_TO.BackgroundImage = null;
            this.txtBR_TO.Name = "txtBR_TO";
            this.txtBR_TO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBoInt_KeyPress);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // btnReha
            // 
            this.btnReha.AccessibleDescription = null;
            this.btnReha.AccessibleName = null;
            resources.ApplyResources(this.btnReha, "btnReha");
            this.btnReha.BackgroundImage = null;
            this.btnReha.ImageIndex = 24;
            this.btnReha.ImageList = this.ImageList;
            this.btnReha.Name = "btnReha";
            this.btnReha.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xToolTip1.SetToolTip(this.btnReha, "リストに選択されている患者の受付区分をリハビリに変更する。");
            this.btnReha.Click += new System.EventHandler(this.btnReha_Click);
            // 
            // cbxSinryouryou
            // 
            this.cbxSinryouryou.AccessibleDescription = null;
            this.cbxSinryouryou.AccessibleName = null;
            resources.ApplyResources(this.cbxSinryouryou, "cbxSinryouryou");
            this.cbxSinryouryou.BackgroundImage = null;
            this.cbxSinryouryou.Name = "cbxSinryouryou";
            this.cbxSinryouryou.UseVisualStyleBackColor = false;
            this.cbxSinryouryou.CheckedChanged += new System.EventHandler(this.cbxAutoNewIraiCheck_CheckedChanged);
            this.cbxSinryouryou.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // btnSaisin
            // 
            this.btnSaisin.AccessibleDescription = null;
            this.btnSaisin.AccessibleName = null;
            resources.ApplyResources(this.btnSaisin, "btnSaisin");
            this.btnSaisin.BackgroundImage = null;
            this.btnSaisin.ImageIndex = 23;
            this.btnSaisin.ImageList = this.ImageList;
            this.btnSaisin.Name = "btnSaisin";
            this.btnSaisin.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xToolTip1.SetToolTip(this.btnSaisin, "リストに選択されている患者の受付区分を再診に変更しリハビリ受付件を新たに追加する。");
            this.btnSaisin.Click += new System.EventHandler(this.btnSaisin_Click);
            // 
            // btnJinryoEnd
            // 
            this.btnJinryoEnd.AccessibleDescription = null;
            this.btnJinryoEnd.AccessibleName = null;
            resources.ApplyResources(this.btnJinryoEnd, "btnJinryoEnd");
            this.btnJinryoEnd.BackgroundImage = null;
            this.btnJinryoEnd.ImageIndex = 25;
            this.btnJinryoEnd.ImageList = this.ImageList;
            this.btnJinryoEnd.Name = "btnJinryoEnd";
            this.btnJinryoEnd.Click += new System.EventHandler(this.btnJinryouEnd_Click);
            // 
            // btnGaisin2
            // 
            this.btnGaisin2.AccessibleDescription = null;
            this.btnGaisin2.AccessibleName = null;
            resources.ApplyResources(this.btnGaisin2, "btnGaisin2");
            this.btnGaisin2.BackgroundImage = null;
            this.btnGaisin2.ImageIndex = 22;
            this.btnGaisin2.ImageList = this.ImageList;
            this.btnGaisin2.Name = "btnGaisin2";
            this.btnGaisin2.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xToolTip1.SetToolTip(this.btnGaisin2, "リストに選択されている患者の受付区分を外診２に変更しリハビリ受付件を新たに追加する。");
            this.btnGaisin2.Click += new System.EventHandler(this.btnGaisin2_Click);
            // 
            // btnGaisin1
            // 
            this.btnGaisin1.AccessibleDescription = null;
            this.btnGaisin1.AccessibleName = null;
            resources.ApplyResources(this.btnGaisin1, "btnGaisin1");
            this.btnGaisin1.BackgroundImage = null;
            this.btnGaisin1.ImageIndex = 21;
            this.btnGaisin1.ImageList = this.ImageList;
            this.btnGaisin1.Name = "btnGaisin1";
            this.btnGaisin1.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xToolTip1.SetToolTip(this.btnGaisin1, "リストに選択されている患者の受付区分を外診１に変更しリハビリ受付件を新たに追加する。");
            this.btnGaisin1.Click += new System.EventHandler(this.btnGaisin1_Click);
            // 
            // gbxPaCnt
            // 
            this.gbxPaCnt.AccessibleDescription = null;
            this.gbxPaCnt.AccessibleName = null;
            resources.ApplyResources(this.gbxPaCnt, "gbxPaCnt");
            this.gbxPaCnt.BackgroundImage = null;
            this.gbxPaCnt.Controls.Add(this.grdPaCnt);
            this.gbxPaCnt.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.gbxPaCnt.Name = "gbxPaCnt";
            this.gbxPaCnt.Protect = true;
            this.gbxPaCnt.TabStop = false;
            // 
            // grdPaCnt
            // 
            resources.ApplyResources(this.grdPaCnt, "grdPaCnt");
            this.grdPaCnt.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell4,
            this.xGridCell3});
            this.grdPaCnt.ColPerLine = 3;
            this.grdPaCnt.Cols = 3;
            this.grdPaCnt.ExecuteQuery = null;
            this.grdPaCnt.FixedRows = 1;
            this.grdPaCnt.HeaderHeights.Add(22);
            this.grdPaCnt.Name = "grdPaCnt";
            this.grdPaCnt.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaCnt.ParamList")));
            this.grdPaCnt.Rows = 2;
            this.grdPaCnt.ToolTipActive = true;
            this.grdPaCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaCnt_QueryStarting);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "gwa";
            this.xGridCell1.Col = -1;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9F);
            this.xGridCell2.CellName = "gwa_name";
            this.xGridCell2.CellWidth = 55;
            this.xGridCell2.Col = 1;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 9F);
            // 
            // xGridCell4
            // 
            this.xGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9F);
            this.xGridCell4.CellName = "doctor_name";
            this.xGridCell4.CellWidth = 75;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 9F);
            this.xGridCell4.SuppressRepeating = true;
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "pa_cnt";
            this.xGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xGridCell3.CellWidth = 20;
            this.xGridCell3.Col = 2;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            // 
            // pnlNurse
            // 
            this.pnlNurse.AccessibleDescription = null;
            this.pnlNurse.AccessibleName = null;
            resources.ApplyResources(this.pnlNurse, "pnlNurse");
            this.pnlNurse.BackgroundImage = null;
            this.pnlNurse.Controls.Add(this.btnDoctorChange);
            this.pnlNurse.Controls.Add(this.btnBody);
            this.pnlNurse.Controls.Add(this.btnAllergy);
            this.pnlNurse.Controls.Add(this.btnHealthQuestionnair);
            this.pnlNurse.Controls.Add(this.btnGamyum);
            this.pnlNurse.Controls.Add(this.btnJubsu);
            this.pnlNurse.Controls.Add(this.btnOUT0106);
            this.pnlNurse.Controls.Add(this.btnDelete);
            this.pnlNurse.Font = null;
            this.pnlNurse.Name = "pnlNurse";
            // 
            // btnDoctorChange
            // 
            this.btnDoctorChange.AccessibleDescription = null;
            this.btnDoctorChange.AccessibleName = null;
            resources.ApplyResources(this.btnDoctorChange, "btnDoctorChange");
            this.btnDoctorChange.BackgroundImage = null;
            this.btnDoctorChange.ImageIndex = 0;
            this.btnDoctorChange.ImageList = this.ImageList;
            this.btnDoctorChange.Name = "btnDoctorChange";
            this.btnDoctorChange.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDoctorChange.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnDoctorChange.Click += new System.EventHandler(this.btnDoctorChange_Click);
            // 
            // btnBody
            // 
            this.btnBody.AccessibleDescription = null;
            this.btnBody.AccessibleName = null;
            resources.ApplyResources(this.btnBody, "btnBody");
            this.btnBody.BackgroundImage = null;
            this.btnBody.ImageIndex = 2;
            this.btnBody.ImageList = this.ImageList;
            this.btnBody.Name = "btnBody";
            this.btnBody.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnBody.Click += new System.EventHandler(this.btnBody_Click);
            // 
            // btnAllergy
            // 
            this.btnAllergy.AccessibleDescription = null;
            this.btnAllergy.AccessibleName = null;
            resources.ApplyResources(this.btnAllergy, "btnAllergy");
            this.btnAllergy.BackgroundImage = null;
            this.btnAllergy.ImageIndex = 11;
            this.btnAllergy.ImageList = this.ImageList;
            this.btnAllergy.Name = "btnAllergy";
            this.btnAllergy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnAllergy.Click += new System.EventHandler(this.btnAllergy_Click);
            // 
            // btnHealthQuestionnair
            // 
            this.btnHealthQuestionnair.AccessibleDescription = null;
            this.btnHealthQuestionnair.AccessibleName = null;
            resources.ApplyResources(this.btnHealthQuestionnair, "btnHealthQuestionnair");
            this.btnHealthQuestionnair.BackgroundImage = null;
            this.btnHealthQuestionnair.ImageIndex = 14;
            this.btnHealthQuestionnair.Name = "btnHealthQuestionnair";
            this.btnHealthQuestionnair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnHealthQuestionnair.Click += new System.EventHandler(this.btnHealthQuestionnair_Click);
            // 
            // btnGamyum
            // 
            this.btnGamyum.AccessibleDescription = null;
            this.btnGamyum.AccessibleName = null;
            resources.ApplyResources(this.btnGamyum, "btnGamyum");
            this.btnGamyum.BackgroundImage = null;
            this.btnGamyum.ImageIndex = 14;
            this.btnGamyum.ImageList = this.ImageList;
            this.btnGamyum.Name = "btnGamyum";
            this.btnGamyum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnGamyum.Click += new System.EventHandler(this.btnGamyum_Click);
            // 
            // btnJubsu
            // 
            this.btnJubsu.AccessibleDescription = null;
            this.btnJubsu.AccessibleName = null;
            resources.ApplyResources(this.btnJubsu, "btnJubsu");
            this.btnJubsu.BackgroundImage = null;
            this.btnJubsu.Image = global::IHIS.PHYS.Properties.Resources.전송_16;
            this.btnJubsu.Name = "btnJubsu";
            this.btnJubsu.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnJubsu.Click += new System.EventHandler(this.btnJubsu_Click);
            // 
            // btnOUT0106
            // 
            this.btnOUT0106.AccessibleDescription = null;
            this.btnOUT0106.AccessibleName = null;
            resources.ApplyResources(this.btnOUT0106, "btnOUT0106");
            this.btnOUT0106.BackgroundImage = null;
            this.btnOUT0106.ImageIndex = 19;
            this.btnOUT0106.ImageList = this.ImageList;
            this.btnOUT0106.Name = "btnOUT0106";
            this.btnOUT0106.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnOUT0106.Click += new System.EventHandler(this.btnOUT0106_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleDescription = null;
            this.btnDelete.AccessibleName = null;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.BackgroundImage = null;
            this.btnDelete.ImageIndex = 17;
            this.btnDelete.ImageList = this.ImageList;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnJusangi
            // 
            this.btnJusangi.AccessibleDescription = null;
            this.btnJusangi.AccessibleName = null;
            resources.ApplyResources(this.btnJusangi, "btnJusangi");
            this.btnJusangi.BackgroundImage = null;
            this.btnJusangi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJusangi.Image = ((System.Drawing.Image)(resources.GetObject("btnJusangi.Image")));
            this.btnJusangi.Name = "btnJusangi";
            this.btnJusangi.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnJusangi.Click += new System.EventHandler(this.btnJusangi_Click);
            // 
            // btnRehaJubsu
            // 
            this.btnRehaJubsu.AccessibleDescription = null;
            this.btnRehaJubsu.AccessibleName = null;
            resources.ApplyResources(this.btnRehaJubsu, "btnRehaJubsu");
            this.btnRehaJubsu.BackgroundImage = null;
            this.btnRehaJubsu.ImageIndex = 23;
            this.btnRehaJubsu.ImageList = this.ImageList;
            this.btnRehaJubsu.Name = "btnRehaJubsu";
            this.btnRehaJubsu.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRehaJubsu.Click += new System.EventHandler(this.btnRehaJubsu_Click);
            // 
            // pnlPart
            // 
            this.pnlPart.AccessibleDescription = null;
            this.pnlPart.AccessibleName = null;
            resources.ApplyResources(this.pnlPart, "pnlPart");
            this.pnlPart.BackgroundImage = null;
            this.pnlPart.Controls.Add(this.xTextBox1);
            this.pnlPart.Controls.Add(this.btnReser);
            this.pnlPart.Controls.Add(this.btnOrder);
            this.pnlPart.Controls.Add(this.btnBunhoChage);
            this.pnlPart.Controls.Add(this.btnEMR);
            this.pnlPart.Controls.Add(this.btnOrderAct);
            this.pnlPart.Controls.Add(this.btnPrint);
            this.pnlPart.Controls.Add(this.btnRehaJubsu);
            this.pnlPart.Controls.Add(this.btnJubsuOpen);
            this.pnlPart.Controls.Add(this.btnJusangi);
            this.pnlPart.Font = null;
            this.pnlPart.Name = "pnlPart";
            // 
            // xTextBox1
            // 
            this.xTextBox1.AccessibleDescription = null;
            this.xTextBox1.AccessibleName = null;
            resources.ApplyResources(this.xTextBox1, "xTextBox1");
            this.xTextBox1.BackgroundImage = null;
            this.xTextBox1.Name = "xTextBox1";
            // 
            // btnReser
            // 
            this.btnReser.AccessibleDescription = null;
            this.btnReser.AccessibleName = null;
            resources.ApplyResources(this.btnReser, "btnReser");
            this.btnReser.BackgroundImage = null;
            this.btnReser.ImageIndex = 13;
            this.btnReser.ImageList = this.ImageList;
            this.btnReser.Name = "btnReser";
            this.btnReser.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnReser.Click += new System.EventHandler(this.btnReser_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.AccessibleDescription = null;
            this.btnOrder.AccessibleName = null;
            resources.ApplyResources(this.btnOrder, "btnOrder");
            this.btnOrder.BackgroundImage = null;
            this.btnOrder.ImageIndex = 3;
            this.btnOrder.ImageList = this.ImageList;
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnBunhoChage
            // 
            this.btnBunhoChage.AccessibleDescription = null;
            this.btnBunhoChage.AccessibleName = null;
            resources.ApplyResources(this.btnBunhoChage, "btnBunhoChage");
            this.btnBunhoChage.BackgroundImage = null;
            this.btnBunhoChage.ImageIndex = 5;
            this.btnBunhoChage.ImageList = this.ImageList;
            this.btnBunhoChage.Name = "btnBunhoChage";
            this.btnBunhoChage.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnBunhoChage.Click += new System.EventHandler(this.btnBunhoChage_Click);
            // 
            // btnEMR
            // 
            this.btnEMR.AccessibleDescription = null;
            this.btnEMR.AccessibleName = null;
            resources.ApplyResources(this.btnEMR, "btnEMR");
            this.btnEMR.BackgroundImage = null;
            this.btnEMR.ImageIndex = 6;
            this.btnEMR.ImageList = this.ImageList;
            this.btnEMR.Name = "btnEMR";
            this.btnEMR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnEMR.Click += new System.EventHandler(this.btnEMR_Click);
            // 
            // btnOrderAct
            // 
            this.btnOrderAct.AccessibleDescription = null;
            this.btnOrderAct.AccessibleName = null;
            resources.ApplyResources(this.btnOrderAct, "btnOrderAct");
            this.btnOrderAct.BackgroundImage = null;
            this.btnOrderAct.ImageIndex = 5;
            this.btnOrderAct.ImageList = this.ImageList;
            this.btnOrderAct.Name = "btnOrderAct";
            this.btnOrderAct.Click += new System.EventHandler(this.btnOrderAct_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleDescription = null;
            this.btnPrint.AccessibleName = null;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.BackgroundImage = null;
            this.btnPrint.ImageIndex = 12;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnPrint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnJubsuOpen
            // 
            this.btnJubsuOpen.AccessibleDescription = null;
            this.btnJubsuOpen.AccessibleName = null;
            resources.ApplyResources(this.btnJubsuOpen, "btnJubsuOpen");
            this.btnJubsuOpen.BackgroundImage = null;
            this.btnJubsuOpen.ImageIndex = 18;
            this.btnJubsuOpen.ImageList = this.ImageList;
            this.btnJubsuOpen.Name = "btnJubsuOpen";
            this.btnJubsuOpen.Click += new System.EventHandler(this.btnJubsuOpen_Click);
            // 
            // layPKOUT1001
            // 
            this.layPKOUT1001.ExecuteQuery = null;
            this.layPKOUT1001.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layPKOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPKOUT1001.ParamList")));
            this.layPKOUT1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPKOUT1001_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "pkout1001";
            // 
            // xToolTip1
            // 
            this.xToolTip1.AutoPopDelay = 1000;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // layDoctorName
            // 
            this.layDoctorName.ExecuteQuery = null;
            this.layDoctorName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDoctorName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDoctorName.ParamList")));
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "doctor_name";
            // 
            // pnlJisseki
            // 
            this.pnlJisseki.AccessibleDescription = null;
            this.pnlJisseki.AccessibleName = null;
            resources.ApplyResources(this.pnlJisseki, "pnlJisseki");
            this.pnlJisseki.BackgroundImage = null;
            this.pnlJisseki.Controls.Add(this.grdList);
            this.pnlJisseki.Controls.Add(this.xPanel2);
            this.pnlJisseki.Font = null;
            this.pnlJisseki.Name = "pnlJisseki";
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46});
            this.grdList.ColPerLine = 8;
            this.grdList.Cols = 9;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(32);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.ReadOnly = true;
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.SortMode = IHIS.Framework.XGridSortMode.SingleClick;
            this.grdList.ToolTipActive = true;
            this.grdList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdList_QueryEnd);
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "kizyun_date";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell35.CellWidth = 95;
            this.xEditGridCell35.Col = 1;
            this.xEditGridCell35.EnableSort = true;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.SuppressRepeating = true;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "gwa";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellLen = 30;
            this.xEditGridCell37.CellName = "gwa_name";
            this.xEditGridCell37.Col = 2;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "doctor";
            this.xEditGridCell38.CellWidth = 121;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 30;
            this.xEditGridCell39.CellName = "doctor_name";
            this.xEditGridCell39.CellWidth = 90;
            this.xEditGridCell39.Col = 3;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "hangmog_code";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 50;
            this.xEditGridCell41.CellName = "hangmog_name";
            this.xEditGridCell41.CellWidth = 270;
            this.xEditGridCell41.Col = 4;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "jundal_part";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellLen = 30;
            this.xEditGridCell43.CellName = "jundal_part_name";
            this.xEditGridCell43.CellWidth = 113;
            this.xEditGridCell43.Col = 5;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "reser_time";
            this.xEditGridCell44.CellWidth = 67;
            this.xEditGridCell44.Col = 7;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.Mask = "##:##";
            this.xEditGridCell44.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "reser_yn";
            this.xEditGridCell45.CellWidth = 39;
            this.xEditGridCell45.Col = 6;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "act_yn";
            this.xEditGridCell46.CellWidth = 38;
            this.xEditGridCell46.Col = 8;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackColor = IHIS.Framework.XColor.XGridRowHeaderBackColor;
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.rbtJisseki);
            this.xPanel2.Controls.Add(this.rbtYoyaku);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.pnlPart);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // rbtJisseki
            // 
            this.rbtJisseki.AccessibleDescription = null;
            this.rbtJisseki.AccessibleName = null;
            resources.ApplyResources(this.rbtJisseki, "rbtJisseki");
            this.rbtJisseki.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbtJisseki.BackgroundImage = null;
            this.rbtJisseki.Name = "rbtJisseki";
            this.rbtJisseki.UseVisualStyleBackColor = false;
            // 
            // rbtYoyaku
            // 
            this.rbtYoyaku.AccessibleDescription = null;
            this.rbtYoyaku.AccessibleName = null;
            resources.ApplyResources(this.rbtYoyaku, "rbtYoyaku");
            this.rbtYoyaku.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbtYoyaku.BackgroundImage = null;
            this.rbtYoyaku.Checked = true;
            this.rbtYoyaku.Name = "rbtYoyaku";
            this.rbtYoyaku.TabStop = true;
            this.rbtYoyaku.UseVisualStyleBackColor = false;
            this.rbtYoyaku.CheckedChanged += new System.EventHandler(this.rbtYoyaku_CheckedChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // pnlNaewonRireki
            // 
            this.pnlNaewonRireki.AccessibleDescription = null;
            this.pnlNaewonRireki.AccessibleName = null;
            resources.ApplyResources(this.pnlNaewonRireki, "pnlNaewonRireki");
            this.pnlNaewonRireki.BackgroundImage = null;
            this.pnlNaewonRireki.Controls.Add(this.grdOUT1001);
            this.pnlNaewonRireki.Font = null;
            this.pnlNaewonRireki.Name = "pnlNaewonRireki";
            // 
            // grdOUT1001
            // 
            resources.ApplyResources(this.grdOUT1001, "grdOUT1001");
            this.grdOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53});
            this.grdOUT1001.ColPerLine = 3;
            this.grdOUT1001.Cols = 4;
            this.grdOUT1001.ExecuteQuery = null;
            this.grdOUT1001.FixedCols = 1;
            this.grdOUT1001.FixedRows = 1;
            this.grdOUT1001.HeaderHeights.Add(33);
            this.grdOUT1001.Name = "grdOUT1001";
            this.grdOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT1001.ParamList")));
            this.grdOUT1001.RowHeaderVisible = true;
            this.grdOUT1001.Rows = 2;
            this.grdOUT1001.ToolTipActive = true;
            this.grdOUT1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOUT1001_QueryStarting);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "bunho";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellLen = 20;
            this.xEditGridCell51.CellName = "naewon_date";
            this.xEditGridCell51.CellWidth = 68;
            this.xEditGridCell51.Col = 1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsUpdatable = false;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellLen = 2;
            this.xEditGridCell52.CellName = "jubsu_gubun";
            this.xEditGridCell52.CellWidth = 36;
            this.xEditGridCell52.Col = 2;
            this.xEditGridCell52.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellLen = 20;
            this.xEditGridCell53.CellName = "next";
            this.xEditGridCell53.CellWidth = 79;
            this.xEditGridCell53.Col = 3;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsUpdatable = false;
            // 
            // timer_NewOrder
            // 
            this.timer_NewOrder.Enabled = true;
            this.timer_NewOrder.Interval = 300000;
            this.timer_NewOrder.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // PHY2001U04
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlNaewonRireki);
            this.Controls.Add(this.pnlJisseki);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "PHY2001U04";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NUR2001U04_Closing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR2001U04_ScreenOpen);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NUR2001U04_KeyDown);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlNaewon.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.tabPHY.ResumeLayout(false);
            this.tabGairai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).EndInit();
            this.tabOUT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT)).EndInit();
            this.tabINP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.pnlVital.ResumeLayout(false);
            this.pnlVital.PerformLayout();
            this.gbxPaCnt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaCnt)).EndInit();
            this.pnlNurse.ResumeLayout(false);
            this.pnlPart.ResumeLayout(false);
            this.pnlPart.PerformLayout();
            this.pnlJisseki.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.pnlNaewonRireki.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// PHY2001U04
        /// </summary>
        public PHY2001U04()
        {
            this.mRehaBiz = new IHIS.PHYS.RehaBiz();
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // updated by Cloud
            InitializeCloud();
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            Size = new System.Drawing.Size(rc.Width - 60, rc.Height - 145);
        }
        #endregion

        #region Events

        private void NUR2001U04_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            this.timer_NewOrder.Start();
            mHospCode = EnvironInfo.HospCode;
            //this.Tag = "Close";

            this.ParentForm.KeyPreview = true;
            this.ParentForm.KeyDown += new KeyEventHandler(this.NUR2001U04_KeyDown);

            #region deleted by Cloud
//            this.grdPatientList.QuerySQL = @"SELECT A.GWA                                                                       GWA
//                                                     , FN_BAS_LOAD_GWA_NAME(A.GWA, TRUNC(A.NAEWON_DATE))                           GWA_NAME
//                                                     , A.BUNHO                                                                     BUNHO
//                                                     , B.SUNAME                                                                    SUNAME
//                                                     , B.SUNAME2                                                                   SUNAME2
//                                                     , A.NAEWON_DATE                                                               NAEWON_DATE
//                                                     , A.DOCTOR                                                                    DOCTOR
//                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, TRUNC(A.NAEWON_DATE))                     DOCTOR_NAME
//                                                     , A.NAEWON_TYPE                                                               NAEWON_TYPE
//                                                     , A.JUBSU_NO                                                                  JUBSU_NO
//                                                     , B.BIRTH                                                                     BIRTH
//                                                     , FN_BAS_LOAD_AGE(A.NAEWON_DATE,B.BIRTH,'')||' / '||B.SEX                     AGE_SEX
//                                                     , A.PKOUT1001                                                                 OUT_RES_KEY
//                                                     , A.JUBSU_TIME                                                                JUBSU_TIME
//                                                     , DECODE(NVL(NAEWON_YN, 'N'), 'E', 'Y', 'N')                                  ORDER_END_YN
//                                                     , DECODE(A.NAEWON_YN, 'H', 'Y', 'N')                                          HOLD_YN
//                                                     , ''                                                                          RESULT_YN
//                                                     , RESER_YN                                                                    RESER_YN
//                                                     , FN_CHT_JAEWON_YN(A.BUNHO )                                                  IPWON_YN 
//                                                     , FN_OUT_LOAD_SUNAB_CHECK_YN(A.PKOUT1001, A.NAEWON_DATE)                      SUNAB_YN
//                                                     , DECODE(NVL(NAEWON_YN, 'N'), 'N', 'N', 'Y')                                  NAEWON_YN
//                                                     , A.JUBSU_GUBUN                                                               JUBSU_GUBUN
//                                                     , C.CODE_NAME                                                                 JUBSU_GUBUN_NAME
//                                                     , C.REMARK                                                                    REMARK
//                                                     , A.ARRIVE_TIME                                                               ARRIVE_TIME
//                                                     , A.GUBUN                                                                     GUBUN
//                                                     , FN_OUT_LOAD_LAST_NAEWON_DATE(A.BUNHO, '%')                                  LAST_NAEWON_DATE
//                                                     , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO)                                        OCS_COMMENT
//                                                     , A.CHOJAE                                                                    CHOJAE
//                                                     , C.GROUP_KEY                                                                 GROUP_KEY
//                                                     , B.BUNHO_TYPE                                                                BUNHO_TYPE
//                                                     , D.KAIGO_YN                                                                  KAIGO_YN
//                                                     , D.GAEIN                                                                     GAEIN
//                                                     , E.BP_TO
//                                                     , E.BP_FROM
//                                                     , E.PULSE
//                                                     , E.BODY_HEAT
//                                                  FROM OUT1001 A
//                                                     , OUT0101 B
//                                                     , BAS0102 C
//                                                     , (SELECT X.HOSP_CODE, X.BUNHO, 'Y' KAIGO_YN, X.GAEIN
//                                                          FROM OUT0102 X
//                                                         WHERE X.HOSP_CODE = :f_hosp_code
//                                                           AND X.GUBUN = '70'
//                                                           AND X.START_DATE = (SELECT MAX(Y.START_DATE) 
//                                                                                 FROM OUT0102 Y
//                                                                                WHERE Y.HOSP_CODE = X.HOSP_CODE
//                                                                                  AND Y.GUBUN     = X.GUBUN                                                                               
//                                                                                  AND :f_naewon_date BETWEEN X.START_DATE 
//                                                                                                         AND X.END_DATE)
//                                                           --AND :f_naewon_date BETWEEN X.START_DATE AND X.END_DATE
//                                                         GROUP BY X.HOSP_CODE, X.BUNHO, X.GAEIN, X.START_DATE
//                                                        HAVING X.START_DATE = MAX(X.START_DATE)) D                     --KAIGO HOKEN    
//                                                     , ( SELECT * FROM NUR7001 EA
//                                                          WHERE EA.HOSP_CODE = :f_hosp_code
//                                                            AND EA.MEASURE_DATE = TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                                            AND EA.SEQ = (SELECT MAX(EB.SEQ) FROM NUR7001 EB
//                                                                           WHERE EB.HOSP_CODE    = :f_hosp_code
//                                                                             AND EB.BUNHO        = EA.BUNHO
//                                                                             AND EB.MEASURE_DATE = TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                                                             AND EB.VALD         = 'Y')) E
//                                                 WHERE A.HOSP_CODE   = :f_hosp_code
//                                                   AND B.HOSP_CODE   = A.HOSP_CODE
//                                                   AND C.HOSP_CODE   = A.HOSP_CODE
//                                                   AND A.NAEWON_DATE = TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                                   AND A.GWA         LIKE :f_gwa ||'%' 
//                                                   AND A.DOCTOR      LIKE :f_doctor || '%'
//                                                   AND A.BUNHO       LIKE :f_bunho||'%'
//                                                   AND A.BUNHO       = B.BUNHO
//                                                   AND C.CODE_TYPE   = 'JUBSU_GUBUN'
//                                                   AND A.JUBSU_GUBUN = C.CODE    
//                                                   AND D.HOSP_CODE(+)= A.HOSP_CODE
//                                                   AND D.BUNHO    (+)= A.BUNHO  
//                                                   -- 「88 : リハビリ診察」
//                                                   AND (
//                                                        (:f_jubsu_gubun = '88' AND A.JUBSU_GUBUN IN ('20','21','22'))
//                                                        OR (:f_jubsu_gubun != '88' AND A.JUBSU_GUBUN LIKE :f_jubsu_gubun)
//                                                       )
//                                                   
//                                                   AND ((:f_jinryo_yn = 'ALL' AND 1 = 1 ) OR 
//                                                        (:f_jinryo_yn = 'Y' AND NVL(NAEWON_YN, 'N')  = 'E') OR 
//                                                        (:f_jinryo_yn = 'N' AND NVL(NAEWON_YN, 'N') != 'E'))
//                                                   AND ((:f_naewon_yn = 'ALL' AND 1 = 1 ) OR 
//                                                        (:f_naewon_yn = 'Y' AND NVL(NAEWON_YN, 'N') != 'N') OR 
//                                                        (:f_naewon_yn = 'N' AND NVL(NAEWON_YN, 'N')  = 'N'))
//                                                   AND E.HOSP_CODE   (+) = A.HOSP_CODE 
//                                                   AND E.BUNHO       (+) = A.BUNHO
//                                                   AND E.MEASURE_DATE(+) = TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                                   
//";

//            if (EnvironInfo.CurrSystemID == "NURO")
//            {
//                this.grdPatientList.QuerySQL += @"
//                                                   --AND C.GROUP_KEY   IN ('1', '2')
//                                                 ORDER BY A.JUBSU_TIME, A.ARRIVE_TIME ,A.BUNHO, A.JUBSU_NO";

//                this.pnlNurse.Visible = true;
//                this.pnlPart.Visible = false;
//                //this.lbJubsuGubun.Visible = false;
//                //this.cboJubsuGubun.Visible = false;

//            }
//            else if (EnvironInfo.CurrSystemID == "OUTS")
//            {
//                this.grdPatientList.QuerySQL += @"
//                                                   --AND C.GROUP_KEY   IN ('1', '2')
//                                                 ORDER BY A.JUBSU_TIME DESC, A.ARRIVE_TIME DESC, A.BUNHO, A.JUBSU_NO";

//                this.pnlNurse.Visible = false;
//                this.pnlPart.Visible = false;
//                //this.lbJubsuGubun.Visible = false;
//                //this.cboJubsuGubun.Visible = false;

//            }
//            else
//            {
//                this.grdPatientList.QuerySQL += @"
//                                                   --AND C.GROUP_KEY   IN ('1', '2')
//                                                 ORDER BY A.JUBSU_TIME DESC, A.ARRIVE_TIME DESC, A.BUNHO, A.JUBSU_NO";

//                this.pnlNurse.Visible = true;
//                this.pnlPart.Visible = true;
//                this.lbJubsuGubun.Visible = true;
//                this.cboJubsuGubun.Visible = true;

//            }
            #endregion

            #region updated by Cloud
            this.grdPatientList.ParamList = new List<string>(new string[]
                {
                    "f_naewon_date",
                    "f_gwa",
                    "f_doctor",
                    "f_bunho",
                    "f_jubsu_gubun",
                    "f_jinryo_yn",
                    "f_naewon_yn",
                    "f_sys_id",
                });
            this.grdPatientList.ExecuteQuery = GetGrdPatientList;

            if (EnvironInfo.CurrSystemID == "NURO")
            {
                this.pnlNurse.Visible = true;
                this.pnlPart.Visible = false;
            }
            else if (EnvironInfo.CurrSystemID == "OUTS")
            {
                this.pnlNurse.Visible = false;
                this.pnlPart.Visible = false;
            }
            else
            {
                this.pnlNurse.Visible = true;
                this.pnlPart.Visible = true;
                this.lbJubsuGubun.Visible = true;
                this.cboJubsuGubun.Visible = true;
            }
            #endregion

            ////ログインシステムがPHYSのみリハビリ受付登録ボタンを見せる。
            //if (EnvironInfo.CurrSystemID == "PHYS")
            //    this.btnRehaJubsu.Visible = true;

            this.cboTime.SelectedIndex = 3;
            this.cboNewTime.SelectedIndex = 2;

            //this.grdPatientList.SavePerformer = new XSavePerformer(this);

            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            if (this.Opener is IHIS.Framework.MdiForm &&
                (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            {
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);
            }

            //열리면서 여러번 조회 안되게 하는 플레그 
            mQueryFlag = false;
            this.dtpNaewonDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpNaewonDate.AcceptData();

//            this.cboGwa.UserSQL = @"SELECT '%', FN_ADM_MSG('221')
//                                      FROM DUAL
//                                     UNION 
//                                    SELECT GWA, GWA_NAME
//                                      FROM BAS0260
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND BUSEO_GUBUN = '1'
//                                       AND :f_buseo_ymd BETWEEN START_DATE AND END_DATE
//                                     ORDER BY 1";

            if (UserInfo.Gwa.ToString() != "")
            {
                this.cboGwa.SetEditValue(UserInfo.Gwa.ToString());
                this.cboGwa.AcceptData();
            }

            if (this.cboGwa.GetDataValue() == "")
                this.cboGwa.SelectedIndex = 0;

            if (this.cboJubsuGubun.GetDataValue() == "")
            {
                if (EnvironInfo.CurrSystemID == "PFES")
                    this.cboJubsuGubun.SetDataValue("13"); // 내시경
                else if (EnvironInfo.CurrSystemID == "XRTS" || EnvironInfo.CurrSystemID == "CPLS")
                    this.cboJubsuGubun.SetDataValue("09"); //검사만의 환자
                else if (EnvironInfo.CurrSystemID == "PHYS") //리하비리
                {
                    this.cboGwa.SetDataValue("03");
                    this.cboJubsuGubun.SetDataValue("01");
                    this.grdPatientList.AutoSizeColumn(3, 0);
                    this.grdPatientList.AutoSizeColumn(5, 0);
                    this.grdPatientList.AutoSizeColumn(7, 0);
                    this.grdPatientList.AutoSizeColumn(12, 0);
                    this.grdPatientList.AutoSizeColumn(15, 0);
                    this.grdPatientList.AutoSizeColumn(17, 33);
                }
                else
                    this.cboJubsuGubun.SetDataValue("%");

            }

            //this.fbxDoctor.SetEditValue("%");
            //this.fbxDoctor.AcceptData();

            //this.dbxDoctor_name.SetEditValue("全体");
            //this.dbxDoctor_name.AcceptData();

            if (DateTime.Now.Hour > 13)
                this.Aampm_gubun = "P";
            else
                this.Aampm_gubun = "A";
            mQueryFlag = true;

            //조회
            QueryData();

            SetSinryouryouAuto();

            if (!this.NaewonRirekiVisibleYN)
                this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width - this.pnlNaewonRireki.Size.Width, ParentForm.Height);
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        return;
                    }

                    e.IsBaseCall = false;

                    switch (this.tabPHY.SelectedTab.Tag.ToString())
                    {
                        case "0":
                            //조회 PatientList
                            QueryData();
                            break;
                        case "1":
                            this.grdOUT.QueryLayout(false);
                            break;
                        case "2":
                            this.grdINP.QueryLayout(false);
                            break;
                    }
                    break;

                case FunctionType.Reset:
                    e.IsBaseCall = false;

                    this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate());
                    this.cboGwa.SelectedIndex = 0;

                    this.fbxDoctor.SetEditValue("");
                    this.fbxDoctor.AcceptData();

                    this.dbxDoctor_name.SetEditValue("");
                    this.dbxDoctor_name.AcceptData();

                    this.paBox.Reset();


                    this.cbxAutoQuery.Checked = true;
                    this.cboTime.SelectedIndex = 3;

                    this.cbxAutoNewIraiCheck.Checked = true;
                    this.cboNewTime.SelectedIndex = 2;

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    ArrayList inputList = new ArrayList();
                    int currRow = this.grdPatientList.CurrentRowNumber;

                    //inputList.Add(this.grdPatientList.GetItemString(currRow, "pkout1001"));   //0
                    //inputList.Add(this.grdPatientList.GetItemString(currRow, "gwa"));         //1
                    //inputList.Add(this.grdPatientList.GetItemString(currRow, "doctor"));      //2
                    //inputList.Add(this.grdPatientList.GetItemString(currRow, "jubsu_gubun")); //3
                    //inputList.Add(UserInfo.UserID);                                           //4
                    //inputList.Add(this.grdPatientList.GetItemString(currRow, "bunho"));       //5
                    //inputList.Add(this.grdPatientList.GetItemString(currRow, "naewon_date")); //6

                    //if (this.IsDuplicationJubsu(inputList))
                    //{
                    //    if (XMessageBox.Show("既に同じ受付区分が登録されています。このまま受付登録しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //        return;
                    //}

                    // updated by Cloud
                    if (/*this.grdPatientList.SaveLayout()*/SavePatientGrid())
                    {
                        //조회
                        QueryData();
                        this.SaveAfterSetFocus(this.grdPatientList.GetItemString(currRow, "pkout1001")); //Query後変更したＲＯＷにＦＯＣＵＳ設定
                    }
                    else
                    {
                        XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.XMessageBox_Caption5, MessageBoxIcon.Error);
                    }

                    break;
                case FunctionType.Process:

                    this.grdExcel.QueryLayout(true);
                    this.grdExcel.Export(true, true);

                    break;


                default:
                    break;
            }
        }

        private void dtpNaewonDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            switch (this.tabPHY.SelectedTab.Tag.ToString())
            {
                case "0":
                    //조회
                    if (mQueryFlag)
                        QueryData();
                    break;

                case "1":
                    this.grdOUT.QueryLayout(false);
                    break;

                case "2":
                    this.grdINP.QueryLayout(false);
                    break;
            }
        }

        private void cboGwa_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ////조회
            //QueryData();
        }

        private void cboGwa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.fbxDoctor.ResetData();
            this.dbxDoctor_name.ResetData();
            //조회
            QueryData();

        }

        private void cboJubsuGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            //조회
            QueryData();

        }

        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            //조회
            QueryData();
        }

        private void btnDoctorChange_Click(object sender, System.EventArgs e)
        {
            int selectedRow = this.grdPatientList.CurrentRowNumber;

            if (this.grdPatientList.GetItemString(selectedRow, "order_end_yn") == "Y" ||
                this.grdPatientList.GetItemString(selectedRow, "hold_yn") == "Y")
            {
                XMessageBox.Show(Resources.XMessageBox6, Resources.XMessageBox_Caption6, MessageBoxIcon.Warning);
                return;
            }

            if (this.grdPatientList.GetItemString(selectedRow, "sunab_yn") == "Y")
            {
                //XMessageBox.Show("既に診療を行っているので変更できません。", "注意", MessageBoxIcon.Warning);
                XMessageBox.Show(Resources.XMessageBox7, Resources.XMessageBox_Caption6, MessageBoxIcon.Warning);
                return;
            }

            //등록된 오더가 있는 지 확인
//            string cmdText = @"SELECT FN_OUT_CHECK_NAEWON_YN(:f_bunho, TO_DATE(:f_naewon_date, 'YYYY/MM/DD'),
//                                                                     :f_gwa  , :f_doctor, :f_naewon_type, :f_jubsu_no, :f_chojae) FROM DUAL";
//            BindVarCollection bc = new BindVarCollection();
//            bc.Add("f_bunho", this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho"));
//            bc.Add("f_naewon_date", this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "naewon_date"));
//            bc.Add("f_gwa", this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "gwa"));
//            bc.Add("f_doctor", this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "doctor"));
//            bc.Add("f_naewon_type", this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "naewon_type"));
//            bc.Add("f_jubsu_no", this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "jubsu_no"));
//            bc.Add("f_chojae", this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "chojae"));
//            object ret = Service.ExecuteScalar(cmdText, bc);

            string naewonYN = "N";

            // updated by Cloud
            PHY2001U04FnOutCheckNaewonYnArgs args = new PHY2001U04FnOutCheckNaewonYnArgs();
            args.Bunho      = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho");
            args.Chojae     = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "chojae");
            args.Doctor     = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "doctor");
            args.Gwa        = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "gwa");
            args.JubsuNo    = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "jubsu_no");
            args.NaewonDate = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "naewon_date");
            args.NaewonType = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "naewon_type");
            PHY2001U04StringResult res = CloudService.Instance.Submit<PHY2001U04StringResult, PHY2001U04FnOutCheckNaewonYnArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && !TypeCheck.IsNull(res.ResStr))
            {
                naewonYN = res.ResStr;
            }

            //if (!TypeCheck.IsNull(ret))
            //{
            //    naewonYN = ret.ToString();
            //}

            //if (naewonYN == "Y")
            //{
            //    this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과에서 내원확인이 되었으므로 수정할 수 없습니다. 진료과로 문의 하십시오." : "診療科で来院確認がされたので修正できません。\r\n診療科にお問合せください。";
            //    this.mCap = NetInfo.Language == LangMode.Ko ? "외래접수" : "外来受付";

            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else 
            if (naewonYN == "O")
            {

                XMessageBox.Show(Resources.XMessageBox8, Resources.XMessageBox_Caption6, MessageBoxIcon.Warning);
                return;
            }

            CommonItemCollection doctorOpen = new CommonItemCollection();

            if (DateTime.Now.Hour > 12)
                this.Aampm_gubun = "P";
            else
                this.Aampm_gubun = "A";

            if (this.grdPatientList.RowCount > 0)
            {
                //this.Tag = "Open";
                doctorOpen.Add("sysid", "NURO");
                doctorOpen.Add("screen", this.ScreenID.ToString());
                doctorOpen.Add("bunho", this.grdPatientList.GetItemString(selectedRow, "bunho"));
                doctorOpen.Add("doctor", this.grdPatientList.GetItemString(selectedRow, "doctor"));
                doctorOpen.Add("gwa", this.grdPatientList.GetItemString(selectedRow, "gwa"));
                doctorOpen.Add("naewon_date", this.grdPatientList.GetItemString(selectedRow, "naewon_date"));
                doctorOpen.Add("ampm", this.Aampm_gubun.ToString());
                doctorOpen.Add("pkout1001", this.grdPatientList.GetItemString(selectedRow, "pkout1001"));
                //IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "NUR2001Q00", ScreenOpenStyle.ResponseFixed, doctorOpen);

                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT1001P01", ScreenOpenStyle.ResponseFixed, doctorOpen);

                QueryData();
                //this.paBox.Reset();
                this.paBox.Focus();
            }
        }

        private void btnBody_Click(object sender, System.EventArgs e)
        {
            CommonItemCollection bodyOpen = new CommonItemCollection();

            if (this.grdPatientList.RowCount > 0)
            {
                bodyOpen.Add("bunho", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString());
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR7001U00", ScreenOpenStyle.ResponseFixed, bodyOpen);
            }
        }

        private void btnOrder_Click(object sender, System.EventArgs e)
        {
            CommonItemCollection orderOpen = new CommonItemCollection();

            if (this.grdPatientList.RowCount > 0)
            {
                orderOpen.Add("bunho", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString());
                orderOpen.Add("naewon_date", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "naewon_date").ToString());
                orderOpen.Add("gwa", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
                orderOpen.Add("doctor", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor"));
                orderOpen.Add("naewon_key", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001"));
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003P01", ScreenOpenStyle.PopUpSizable, orderOpen);
            }
        }

        private void fbxDoctor_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("gwa", this.cboGwa.GetDataValue().ToString());
            openParams.Add("word", "");
            openParams.Add("all_gubun", "Y");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void grdPatientList_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (e.DataRow["reser_yn"].ToString() == "Y")
            {
                e.BackColor = Color.LightGreen;
            }
            else if (e.DataRow["gwa"].ToString() == "04")
            {
                e.BackColor = Color.Pink;
            }
        }

        private void grdPatientList_DoubleClick(object sender, System.EventArgs e)
        {
            //if (this.grdPatientList.CurrentRowNumber < 0) return;

            //CommonItemCollection cic = new CommonItemCollection();

            //cic.Add("bunho", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString());
            //cic.Add("naewon_date", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "naewon_date").ToString());
            //IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003P01", ScreenOpenStyle.PopUpFixed, cic);

            if (this.grdPatientList.CurrentRowNumber < 0)
                return;

            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString());
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201Q12", ScreenOpenStyle.ResponseFixed, cic);
        }

        private void btnJusangi_Click(object sender, System.EventArgs e)
        {
            //if (this.grdPatientList.RowCount <= 0) return;

            //string target = "http://172.16.21.2/obis_heartlife/session/SystemLogin.aspx?pid=" + this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString() + "&uid=" + UserInfo.UserID + "&pwd=" + UserInfo.UserPswd;
            //try
            //{
            //    System.Diagnostics.Process.Start(target);
            //}
            //catch (System.ComponentModel.Win32Exception noBrowser)
            //{
            //    if (noBrowser.ErrorCode == -2147467259)
            //        MessageBox.Show(noBrowser.Message);
            //}
            //catch (System.Exception other)
            //{
            //    MessageBox.Show(other.Message);
            //}
        }

        private void cboGwa_DDLBSetting(object sender, EventArgs e)
        {
            this.cboGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.cboGwa.SetBindVarValue("f_buseo_ymd", this.dtpNaewonDate.GetDataValue());
        }

        private void grdPatientList_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.grdPatientList.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdPatientList.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_doctor", this.fbxDoctor.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdPatientList.SetBindVarValue("f_jubsu_gubun", this.cboJubsuGubun.GetDataValue());
            //this.grdPatientList.SetBindVarValue("f_query_all", this.cbxQueryAll.GetDataValue());

            // updated by Cloud
            this.grdPatientList.SetBindVarValue("f_sys_id", EnvironInfo.CurrSystemID);

            if (this.rbtJinryoAll.Checked)
                this.grdPatientList.SetBindVarValue("f_jinryo_yn", "ALL");
            else if (this.rbtJinryoEnd.Checked)
                this.grdPatientList.SetBindVarValue("f_jinryo_yn", "Y");
            else if (this.rbtJinryoNotEnd.Checked)
                this.grdPatientList.SetBindVarValue("f_jinryo_yn", "N");


            if (this.rbtNaewonAll.Checked)
                this.grdPatientList.SetBindVarValue("f_naewon_yn", "ALL");
            else if (this.rbtNaewon.Checked)
                this.grdPatientList.SetBindVarValue("f_naewon_yn", "Y");
            else if (this.rbtMiNaewon.Checked)
                this.grdPatientList.SetBindVarValue("f_naewon_yn", "N");
        }

        private void layPKOUT1001_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            layPKOUT1001.SetBindVarValue("f_hosp_code", this.mHospCode);
            layPKOUT1001.SetBindVarValue("f_pkout1001", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "pkout1001").ToString());
            layPKOUT1001.SetBindVarValue("f_naewon_date", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "naewon_date").ToString());
            layPKOUT1001.SetBindVarValue("f_bunho", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString());
            layPKOUT1001.SetBindVarValue("f_gwa", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "gwa").ToString());
            layPKOUT1001.SetBindVarValue("f_doctor", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "doctor").ToString());
            layPKOUT1001.SetBindVarValue("f_change_doctor", mDoctor);
            layPKOUT1001.SetBindVarValue("f_naewon_type", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "naewon_type").ToString());
            layPKOUT1001.SetBindVarValue("f_jubsu_no", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "jubsu_no").ToString());
            layPKOUT1001.SetBindVarValue("f_jinryo_time", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "jubsu_time").ToString());
        }

        private void grdPatientList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //            string cmdText = @"SELECT 'Y'
            //                                  FROM DUAL
            //                                 WHERE EXISTS (SELECT 'X'
            //                                                 FROM VW_OCS_INP1001_01
            //                                                WHERE HOSP_CODE   = :f_hosp_code
            //                                                  AND BUNHO       = :f_bunho
            //                                                  AND JAEWON_FLAG = 'Y'
            //                                                  AND NVL(CANCEL_YN, 'N') = 'N')";

            //            BindVarCollection bc = new BindVarCollection();
            //            bc.Add("f_hosp_code", EnvironInfo.HospCode);

            //            for (int i = 0; i < this.grdPatientList.RowCount; i++)
            //            {
            //                bc.Add("f_bunho", this.grdPatientList.GetItemString(i, "bunho"));

            //                object retVal = Service.ExecuteScalar(cmdText, bc);

            //                if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
            //                    this.grdPatientList.SetItemValue(i, "ipwon_yn", "Y");
            //                else
            //                    this.grdPatientList.SetItemValue(i, "ipwon_yn", "N");
            //            }

            //            this.grdPatientList.ResetUpdate();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // updated by Cloud
            if (/*this.grdPatientList.SaveLayout()*/ SavePatientGrid())
            {
                //조회
                QueryData();
                XMessageBox.Show(Resources.XMessageBox9, Resources.XMessageBox_Caption9);
            }
            else
            {
                XMessageBox.Show(Resources.XMessageBox10 + Service.ErrFullMsg, Resources.XMessageBox_Caption5, MessageBoxIcon.Error);
            }
        }

        private void btnEMR_Click(object sender, EventArgs e)
        {
            if (this.grdPatientList.CurrentRowNumber >= 0)
            {
                IHIS.Framework.EMRHelper.ExecuteEMR(EMRIOTGubun.OUT
                                                   , this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString()
                                                   , this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "naewon_date").ToString()
                                                   , this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "gwa").ToString()
                                                   , this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "doctor").ToString()
                                                   , this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "pkout1001").ToString());
            }

        }

        private void btnAllergy_Click(object sender, EventArgs e)
        {
            CommonItemCollection allergyOpen = new CommonItemCollection();

            if (this.grdPatientList.RowCount > 0)
            {
                allergyOpen.Add("sysid", "NURO");
                allergyOpen.Add("screen", this.ScreenID.ToString());
                allergyOpen.Add("bunho", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString());
                allergyOpen.Add("flag", "");

                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "NUR1016U00", ScreenOpenStyle.ResponseFixed, allergyOpen);
            }

        }

        private void btnGamyum_Click(object sender, EventArgs e)
        {
            CommonItemCollection allergyOpen = new CommonItemCollection();

            if (this.grdPatientList.RowCount > 0)
            {
                allergyOpen.Add("sysid", "NURO");
                allergyOpen.Add("screen", this.ScreenID.ToString());
                allergyOpen.Add("bunho", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString());
                allergyOpen.Add("flag", "");

                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "NUR1017U00", ScreenOpenStyle.ResponseFixed, allergyOpen);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CommonItemCollection printOpen = new CommonItemCollection();

            if (this.grdPatientList.RowCount > 0)
            {
                if (this.grdPatientList.CurrentRowNumber >= 0)
                {
                    if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "order_end_yn") == "Y")
                    {
                        XMessageBox.Show(Resources.XMessageBox11, Resources.XMessageBox_Caption11, MessageBoxIcon.Warning);
                        return;
                    }

                    if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") == "N")
                    {
                        XMessageBox.Show(Resources.XMessageBox12, Resources.XMessageBox_Caption12, MessageBoxIcon.Information);
                        return;
                    }

                    if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "group_key") != "1" &&
                        this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "group_key") != "2")
                    {
                        XMessageBox.Show(Resources.XMessageBox13, Resources.XMessageBox_Caption13, MessageBoxIcon.Information);
                        return;
                    }

                    IXScreen aScreen = XScreen.FindScreen("NURO", "OUT1001R01");
                    string aBunho = this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString();
                    if (aScreen == null)
                    {
                        printOpen.Add("auto_close", true);
                    }
                    else
                    {
                        aScreen.Command("Close", new CommonItemCollection());
                        printOpen.Add("auto_close", false);
                    }
                    printOpen.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
                    printOpen.Add("bunho", aBunho);

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT1001R01", ScreenOpenStyle.PopUpFixed, printOpen);

                    this.paBox.Reset();
                    this.paBox.Focus();
                    //this.Activate();
                }
            }
        }

        private void grdPatientList_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            object previousValue = grid.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer);
            string procedure_name = "PR_REH_ADD_REHASINRYOURYOU";
            ArrayList inputList_sin = new ArrayList();
            ArrayList outputList_sin = new ArrayList();

            if (e.ColName == "jubsu_gubun")
            {
                int currRow_sin = this.grdPatientList.CurrentRowNumber;

                string naewon_date = this.grdPatientList.GetItemString(currRow_sin, "naewon_date");
                string bunho = this.grdPatientList.GetItemString(currRow_sin, "bunho");
                string suname = this.grdPatientList.GetItemString(currRow_sin, "suname");
                string gwa = this.grdPatientList.GetItemString(currRow_sin, "gwa");
                string gwa_name = this.grdPatientList.GetItemString(currRow_sin, "gwa_name");
                string doctor = this.grdPatientList.GetItemString(currRow_sin, "doctor");
                string doctor_name = this.grdPatientList.GetItemString(currRow_sin, "doctor_name");
                string naewon_type = this.grdPatientList.GetItemString(currRow_sin, "naewon_type");
                string jubsu_no = this.grdPatientList.GetItemString(currRow_sin, "jubsu_no");
                string pkout1001 = this.grdPatientList.GetItemString(currRow_sin, "pkout1001");
                string gubun = this.grdPatientList.GetItemString(currRow_sin, "gubun");
                string arrive_time = this.grdPatientList.GetItemString(currRow_sin, "arrive_time");
                string naewon_yn = this.grdPatientList.GetItemString(currRow_sin, "naewon_yn");

                DialogResult dr = XMessageBox.Show(suname + Resources.XMessageBox14, Resources.XMessageBox_Caption14, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        #region deleted by Cloud

//                        Service.BeginTransaction();


//                        // 以前の受付区分が診察料自動発生対象だったのかチェック
//                        if (previousValue.ToString() == "20" || previousValue.ToString() == "21" || previousValue.ToString() == "22")
//                        {
//                            if (this.cbxSinryouryou.Checked == true)
//                            {
//                                inputList_sin = new ArrayList();
//                                outputList_sin = new ArrayList();
//                                inputList_sin.Add(naewon_date);               //1
//                                inputList_sin.Add(bunho);                     //2
//                                inputList_sin.Add(pkout1001);                 //3
//                                inputList_sin.Add(doctor);                    //4
//                                inputList_sin.Add(previousValue.ToString());  //5
//                                inputList_sin.Add(UserInfo.UserID);           //6
//                                inputList_sin.Add(EnvironInfo.HospCode);      //7
//                                inputList_sin.Add("11");                      //8 REHA 11
//                                inputList_sin.Add("D");                       //9

//                                Service.ExecuteProcedure(procedure_name, inputList_sin, outputList_sin);

//                                if (outputList_sin[0].ToString() != "1")
//                                {
//                                    XMessageBox.Show(outputList_sin[0].ToString() + "\r\n" + outputList_sin[1].ToString() + "\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
//                                    Service.RollbackTransaction();
//                                    return;
//                                }
//                            }
//                        }

//                        // 今回変わった受付区分が診察料自動発生対象なのかチェック
//                        if (e.ChangeValue.ToString() == "20" || e.ChangeValue.ToString() == "21" || e.ChangeValue.ToString() == "22")
//                        {
//                            if (this.cbxSinryouryou.Checked == true)
//                            {
//                                inputList_sin = new ArrayList();
//                                outputList_sin = new ArrayList();
//                                inputList_sin.Add(naewon_date);               //1
//                                inputList_sin.Add(bunho);                     //2
//                                inputList_sin.Add(pkout1001);                 //3
//                                inputList_sin.Add(doctor);                    //4
//                                inputList_sin.Add(e.ChangeValue.ToString());  //5
//                                inputList_sin.Add(UserInfo.UserID);           //6
//                                inputList_sin.Add(EnvironInfo.HospCode);      //7
//                                inputList_sin.Add("11");                      //8 REHA 11
//                                inputList_sin.Add("I");                       //9

//                                Service.ExecuteProcedure(procedure_name, inputList_sin, outputList_sin);

//                                if (outputList_sin[0].ToString() != "1")
//                                {
//                                    XMessageBox.Show(outputList_sin[0].ToString() + "\r\n" + outputList_sin[1].ToString() + "\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
//                                    Service.RollbackTransaction();
//                                    return;
//                                }
//                            }
//                        }

//                        string cmdText = "";
//                        BindVarCollection bind = new BindVarCollection();
//                        ArrayList inputList = new ArrayList();
//                        inputList.Add(pkout1001);                 //0
//                        inputList.Add(gwa);                       //1
//                        inputList.Add(doctor);                    //2
//                        inputList.Add(e.ChangeValue.ToString());  //3
//                        inputList.Add(UserInfo.UserID);           //4
//                        inputList.Add(bunho);                   　//5
//                        inputList.Add(naewon_date);               //6

//                        if (this.IsDuplicationJubsu(inputList))
//                        {
//                            if (XMessageBox.Show("既に同じ受付区分が登録されています。このまま受付登録しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
//                            {
//                                Service.RollbackTransaction();
//                                return;
//                            }
//                        }

//                        cmdText = @"UPDATE OUT1001 A
//                                       SET A.UPD_ID      = :f_user_id
//                                         , A.UPD_DATE    = SYSDATE
//                                         , A.NAEWON_YN   = :f_naewon_yn
//                                         , A.ARRIVE_TIME = :f_arrive_time
//                                         , A.JUBSU_GUBUN = :f_jubsu_gubun
//                                         
//                                     WHERE A.HOSP_CODE   = :f_hosp_code
//                                       AND A.PKOUT1001   = :f_pkout1001";

//                        bind.Add("f_user_id", UserInfo.UserID);
//                        bind.Add("f_naewon_yn", naewon_yn);
//                        bind.Add("f_arrive_time", this.grdPatientList.GetItemString(currRow_sin, "arrive_time"));
//                        bind.Add("f_jubsu_gubun", e.ChangeValue.ToString());
//                        bind.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bind.Add("f_pkout1001", pkout1001);

//                        if (!Service.ExecuteNonQuery(cmdText, bind))
//                        {
//                            Service.RollbackTransaction();
//                            return;
//                        }

//                        Service.CommitTransaction();
//                        this.mPowerQuery = true;
//                        this.btnList.PerformClick(FunctionType.Query);
//                        this.mPowerQuery = false;

                        #endregion

                        #region updated by Cloud
                        ArrayList inputList = new ArrayList();
                        inputList.Add(pkout1001);                 //0
                        inputList.Add(gwa);                       //1
                        inputList.Add(doctor);                    //2
                        inputList.Add(e.ChangeValue.ToString());  //3
                        inputList.Add(UserInfo.UserID);           //4
                        inputList.Add(bunho);                   　//5
                        inputList.Add(naewon_date);               //6

                        if (this.IsDuplicationJubsu(inputList))
                        {
                            if (XMessageBox.Show("既に同じ受付区分が登録されています。このまま受付登録しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                return;
                            }
                        }

                        PHY2001U04GrdPatientListItemValueChangingArgs args = new PHY2001U04GrdPatientListItemValueChangingArgs();
                        args.ArriveTime = arrive_time;
                        args.Bunho = bunho;
                        args.CbxSinryouryou = cbxSinryouryou.Checked;
                        args.ChangedValue = e.ChangeValue.ToString();
                        args.Doctor = doctor;
                        args.Fkout1001 = pkout1001;
                        args.InputId = UserInfo.UserID;
                        args.InputTab = "11";
                        args.JubsuGubun = e.ChangeValue.ToString();
                        args.NaewonYn = naewon_yn;
                        args.OrderDate = naewon_date;
                        args.PreviousValue = previousValue.ToString();
                        args.UserId = UserInfo.UserID;
                        args.IudGubun = "";
                        args.SinryouryouGubun = "";
                        PHY2001U04GrdPatientListItemValueChangingResult res = CloudService.Instance.Submit<PHY2001U04GrdPatientListItemValueChangingResult,
                            PHY2001U04GrdPatientListItemValueChangingArgs>(args);

                        if (res.Result != "1")
                        {
                            XMessageBox.Show(res.Result + "\r\n" + res.ResultMsg + "\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
                            return;
                        }

                        this.mPowerQuery = true;
                        this.btnList.PerformClick(FunctionType.Query);
                        this.mPowerQuery = false;
                        #endregion
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                    }
                }
            }
        }

        private void cbxAutoQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAutoQuery.Checked)
            {
                this.cboTime.Enabled = true;
                this.timer1.Interval = Int32.Parse(this.cboTime.GetDataValue());
            }
            else
            {
                this.cboTime.Enabled = false;
            }
        }

        private void cbxAutoNewIraiCheck_CheckedChanged(object sender, EventArgs e)
        {

            if (cbxAutoNewIraiCheck.Checked)
            {
                this.cboNewTime.Enabled = true;
                this.timer_NewOrder.Interval = Int32.Parse(this.cboNewTime.GetDataValue());
            }
            else
            {
                this.cboNewTime.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.cbxAutoQuery.Checked)
            {
                //if (this.Tag.ToString() == "Close")
                //{
                //조회
                QueryData();
                //}
            }
        }

        private void cboTime_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboTime.GetDataValue() != "")
                this.timer1.Interval = Int32.Parse(this.cboTime.GetDataValue());
        }

        private void cboNewTime_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboNewTime.GetDataValue() != "")
                this.timer_NewOrder.Interval = Int32.Parse(this.cboNewTime.GetDataValue());
        }

        private void grdPatientList_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //if (e.ColName == "naewon_yn")
            //{
            //    if (e.DataRow["order_end_yn"].ToString() == "Y" || e.DataRow["hold_yn"].ToString() == "Y" ||
            //        e.DataRow["sunab_yn"].ToString() == "Y")
            //    {
            //        e.Protect = true;
            //    }

            //    if (e.DataRow["naewon_yn"].ToString() == "Y")
            //    {
            //        string suname = this.grdPatientList.GetItemString(e.RowNumber, "suname");
            //        string gwa_name = this.grdPatientList.GetItemString(e.RowNumber, "gwa_name");
            //        string doctor_name = this.grdPatientList.GetItemString(e.RowNumber, "doctor_name");

            //        DialogResult dr = XMessageBox.Show(suname + "さんの来院チェック(" + gwa_name + " " + doctor_name + ")を外しますか？", "来院確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //        if (dr == DialogResult.Cancel)
            //        {
            //            e.Protect = true;
            //            this.grdPatientList.SetFocusToItem(e.RowNumber, "hold_yn");
            //        }
            //    }
            //}

            if (e.ColName == "jubsu_gubun")
            {
                //if (EnvironInfo.CurrSystemID != "OUTS")
                //{
                //    e.Protect = true;
                //}

                if (e.DataRow["order_end_yn"].ToString() == "Y" || e.DataRow["hold_yn"].ToString() == "Y" ||
                    e.DataRow["sunab_yn"].ToString() == "Y")
                {
                    e.Protect = true;
                }
            }
        }

        private void cbxQueryAll_CheckedChanged(object sender, EventArgs e)
        {
            //조회
            QueryData();
        }

        private void NUR2001U04_Closing(object sender, CancelEventArgs e)
        {
            if (!CheckSave())
            {
                e.Cancel = true;
                return;
            }
        }

        private void fbxDoctor_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                this.dbxDoctor_name.ResetData();
                //조회
                QueryData();
                return;
            }


            if (e.DataValue == "%")
            {
                this.dbxDoctor_name.SetDataValue("全体");
            }
            else
            {
                //this.layDoctorName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                //this.layDoctorName.SetBindVarValue("f_doctor", e.DataValue);
                //this.layDoctorName.SetBindVarValue("f_date", this.dtpNaewonDate.GetDataValue());

                //this.layDoctorName.QueryLayout();

                // updated by Cloud
                PHY2001U04LayDoctorNameArgs args = new PHY2001U04LayDoctorNameArgs();
                args.Date = this.dtpNaewonDate.GetDataValue();
                args.Doctor = e.DataValue;
                PHY2001U04StringResult res = CloudService.Instance.Submit<PHY2001U04StringResult, PHY2001U04LayDoctorNameArgs>(args);

                //this.dbxDoctor_name.SetDataValue(this.layDoctorName.GetItemValue("doctor_name"));
                this.dbxDoctor_name.SetDataValue(res.ResStr);

                //if (this.layDoctorName.GetItemValue("doctor_name").ToString() == "")
                //{
                //    XMessageBox.Show("診療医コードが有効ではありません。", "診療医コード", MessageBoxIcon.Warning);
                //    e.Cancel = true;
                //    return;
                //}

                if (res.ExecutionStatus == ExecutionStatus.Success && res.ResStr == "")
                {
                    XMessageBox.Show(Resources.XMessageBox15, Resources.XCap15 , MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }

            //조회
            QueryData();

        }

        private void NUR2001U04_MouseMove(object sender, MouseEventArgs e)
        {
            this.timer1.Stop();
            this.timer1.Start();
        }

        private void btnJubsu_Click(object sender, EventArgs e)
        {
            if (this.grdPatientList.RowCount < 1)
                return;

            JubsuForm jubsuForm = new JubsuForm(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001"));
            jubsuForm.ShowDialog();

            QueryData();
            //this.paBox.Reset();
            this.paBox.Focus();

        }

        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rbt = sender as XRadioButton;

            if (rbt.Checked)
            {
                //if (rbt.Tag.ToString() == "blue")
                //{
                //    rbt.BackColor = new XColor(Color.FromArgb());
                //}
                //else if (rbt.Tag.ToString() == "pink")
                //{
                //    rbt.BackColor = new XColor(Color.Tomato);
                //}
                //else if (rbt.Tag.ToString() == "green")
                //{
                //    rbt.BackColor = new XColor(Color.Green);
                //}

                rbt.BackColor = new XColor(Color.LightPink);

                QueryData();

            }
            else
            {
                //if (rbt.Tag.ToString() == "blue")
                //{
                //    rbt.BackColor = new XColor(Color.FromArgb(0,190, 215, 219));
                //}
                //else if (rbt.Tag.ToString() == "pink")
                //{
                //    rbt.BackColor = new XColor(Color.LightPink);
                //}
                //else if (rbt.Tag.ToString() == "green")
                //{
                //    rbt.BackColor = new XColor(Color.LightGreen);
                //}
                if (rbt.Tag.ToString() == "Jinryo")
                {
                    rbt.BackColor = new XColor(Color.PowderBlue);
                }
                else if (rbt.Tag.ToString() == "Naewon")
                {
                    rbt.BackColor = new XColor(Color.LightGreen);
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdPatientList.CurrentRowNumber >= 0)
            {
                if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "order_end_yn") == "Y")
                {
                    XMessageBox.Show(Resources.XMessageBox16, Resources.XMessageBox_Caption11, MessageBoxIcon.Warning);
                    return;
                }

                if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "hold_yn") == "Y")
                {
                    XMessageBox.Show(Resources.XMessageBox17, Resources.XMessageBox_Caption17, MessageBoxIcon.Warning);
                    return;
                }

                string naewon_date = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_date");
                string bunho = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho");
                string suname = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "suname");
                string gwa = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa");
                string gwa_name = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa_name");
                string doctor = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor");
                string doctor_name = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor_name");
                string naewon_type = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_type");
                string jubsu_no = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "jubsu_no");
                string pkout1001 = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001");
                string gubun = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gubun");

                DialogResult dr = XMessageBox.Show(suname + Resources.XMessageBox18 + gwa_name + " " + doctor_name + Resources.XMessageBox19, Resources.XMessageBox_Caption18, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    int currRow_sin = this.grdPatientList.CurrentRowNumber;

                    //リハビリ診療料削除確認
                    if (this.grdPatientList.GetItemString(currRow_sin, "jubsu_gubun") == "20"
                        || this.grdPatientList.GetItemString(currRow_sin, "jubsu_gubun") == "21"
                        || this.grdPatientList.GetItemString(currRow_sin, "jubsu_gubun") == "22")
                    {
                        string msg = "";

                        #region deleted by Cloud
//                        string cmd = @" SELECT A.PKOUT1001, B.PKOCS1003, B.HANGMOG_CODE, C.VALUE_POINT SINRYOURYOU_GUBUN, B.SUNAB_DATE
//                                          FROM OUT1001 A
//                                              ,OCS1003 B
//                                              ,OCS0132 C
//                                         WHERE A.HOSP_CODE   = :f_hosp_code
//                                           AND A.BUNHO       = :f_bunho
//                                           AND A.PKOUT1001   = :f_pkout1001
//                                           --
//                                           AND B.HOSP_CODE   = A.HOSP_CODE
//                                           AND B.FKOUT1001   = A.PKOUT1001
//                                           --
//                                           AND C.HOSP_CODE   = B.HOSP_CODE
//                                           AND C.CODE_TYPE   = 'REHA_SINRYOURYOU'
//                                           AND C.CODE_NAME   = B.HANGMOG_CODE";
//                        BindVarCollection bind = new BindVarCollection();
//                        bind.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bind.Add("f_bunho", this.grdPatientList.GetItemString(currRow_sin, "bunho"));
//                        bind.Add("f_pkout1001", this.grdPatientList.GetItemString(currRow_sin, "pkout1001"));
                        #endregion

                        // updated by Cloud
                        PHY2001U04BtnDeleteGetDataTableArgs args = new PHY2001U04BtnDeleteGetDataTableArgs();
                        args.Bunho = this.grdPatientList.GetItemString(currRow_sin, "bunho");
                        args.Pkout1001 = this.grdPatientList.GetItemString(currRow_sin, "pkout1001");
                        PHY2001U04BtnDeleteGetDataTableResult res = CloudService.Instance.Submit<PHY2001U04BtnDeleteGetDataTableResult,
                            PHY2001U04BtnDeleteGetDataTableArgs>(args);

                        DataTable dt = null;
                        if (res.ExecutionStatus == ExecutionStatus.Success && res.TblItem.Count > 0)
                        {
                            dt = Utility.ConvertToDataTable(res.TblItem);
                        }

                        //DataTable dt = Service.ExecuteDataTable(cmd, bind);

                        if (dt != null)
                        {
                            List<PHY2001U04PrRehAddRehasinryouryouInfo> lstData = new List<PHY2001U04PrRehAddRehasinryouryouInfo>();

                            foreach (DataRow dr_s in dt.Rows)
                            {
                                switch (dr_s["sinryouryou_gubun"].ToString())
                                {
                                    case "20":
                                        msg = Resources.XMessageBox20;
                                        break;
                                    case "21":
                                        msg = Resources.XMessageBox21;
                                        break;
                                    case "22":
                                        msg = Resources.XMessageBox22;
                                        break;
                                }

                                if (dr_s["sunab_date"].ToString() != "")
                                {
                                    XMessageBox.Show(Resources.XMessageBox23 + msg + Resources.XMessageBox24, Resources.XMessageBox_Caption23);
                                    return;
                                }


                                if (XMessageBox.Show(Resources.XMessageBox25 + msg + Resources.XMessageBox26, Resources.XMessageBox_Caption23, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    #region deleted by Cloud
                                    //try
                                    //{
                                    //    Service.BeginTransaction();
                                    //    ArrayList inputList_sin = new ArrayList();
                                    //    ArrayList outputList_sin = new ArrayList();

                                    //    string procedure_name = "PR_REH_ADD_REHASINRYOURYOU";

                                    //    inputList_sin.Add(this.grdPatientList.GetItemString(currRow_sin, "naewon_date"));               //1
                                    //    inputList_sin.Add(this.grdPatientList.GetItemString(currRow_sin, "bunho"));                     //2
                                    //    inputList_sin.Add(this.grdPatientList.GetItemString(currRow_sin, "pkout1001"));                 //3
                                    //    inputList_sin.Add(this.grdPatientList.GetItemString(currRow_sin, "doctor"));                    //4
                                    //    inputList_sin.Add(dr_s["sinryouryou_gubun"].ToString());                                        //5
                                    //    inputList_sin.Add(UserInfo.UserID);                                                             //6
                                    //    inputList_sin.Add(EnvironInfo.HospCode);                                                        //7
                                    //    inputList_sin.Add("11");                                                                        //8 REHA 10
                                    //    inputList_sin.Add("D");                                                                         //9

                                    //    Service.ExecuteProcedure(procedure_name, inputList_sin, outputList_sin);

                                    //    if (outputList_sin[0].ToString() != "1")
                                    //    {
                                    //        XMessageBox.Show(outputList_sin[0].ToString() + "\r\n" + outputList_sin[1].ToString() + "\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
                                    //        return;
                                    //    }
                                    //    else
                                    //        Service.CommitTransaction();
                                    //}
                                    //catch
                                    //{
                                    //    Service.RollbackTransaction();
                                    //}
                                    #endregion

                                    // updated by Cloud
                                    PHY2001U04PrRehAddRehasinryouryouInfo item = new PHY2001U04PrRehAddRehasinryouryouInfo();
                                    item.SinryouryouGubun = dr_s["sinryouryou_gubun"].ToString();

                                    lstData.Add(item);
                                }
                                else
                                {
                                    XMessageBox.Show(Resources.XMessageBox27, Resources.XMessageBox_Caption23);
                                    return;
                                }
                            }

                            // updated by Cloud
                            PHY2001U04PrRehAddRehasinryouryouArgs rehArgs = new PHY2001U04PrRehAddRehasinryouryouArgs();
                            rehArgs.Bunho = this.grdPatientList.GetItemString(currRow_sin, "bunho");
                            rehArgs.Doctor = this.grdPatientList.GetItemString(currRow_sin, "doctor");
                            rehArgs.Fkout1001 = this.grdPatientList.GetItemString(currRow_sin, "pkout1001");
                            rehArgs.InputId = UserInfo.UserID;
                            rehArgs.InputTab = "11";
                            rehArgs.IudGubun = "D";
                            rehArgs.OrderDate = this.grdPatientList.GetItemString(currRow_sin, "naewon_date");
                            rehArgs.SinryouryouGubun = lstData;
                            PHY2001U04PrRehAddRehasinryouryouResult rehRes = CloudService.Instance.Submit<PHY2001U04PrRehAddRehasinryouryouResult,
                                PHY2001U04PrRehAddRehasinryouryouArgs>(rehArgs);

                            if (rehRes.Result != "1")
                            {
                                XMessageBox.Show(rehRes.Result + "\r\n" + rehRes.ResultMsg + "\r\n" + Service.ErrFullMsg, Resources.XMessageBox_Caption3, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    // 내원확인 체크

//                    BindVarCollection bindVars = new BindVarCollection();
//                    string cmdText = @"SELECT FN_OUT_CHECK_NAEWON_YN(:f_bunho
//                                                                    , :f_naewon_date
//                                                                    , :f_gwa
//                                                                    , :f_doctor
//                                                                    , :f_naewon_type
//                                                                    , :f_old_jubsu_no
//                                                                    , :f_chojae)
//                                         FROM DUAL";

//                    bindVars.Clear();
//                    bindVars.Add("f_bunho", bunho);
//                    bindVars.Add("f_naewon_date", naewon_date);
//                    bindVars.Add("f_gwa", gwa);
//                    bindVars.Add("f_naewon_type", naewon_type);
//                    //bindVars.Add("f_old_jubsu_no", row["old_jubsu_no"].ToString());
//                    bindVars.Add("f_old_jubsu_no", jubsu_no);
//                    bindVars.Add("f_chojae", "");

                    // updated by Cloud
                    PHY2001U04FnOutCheckNaewonYnArgs fnOutArgs = new PHY2001U04FnOutCheckNaewonYnArgs();
                    fnOutArgs.Bunho = bunho;
                    fnOutArgs.Chojae = "";
                    fnOutArgs.Gwa = gwa;
                    fnOutArgs.JubsuNo = jubsu_no;
                    fnOutArgs.NaewonDate = naewon_date;
                    fnOutArgs.NaewonType = naewon_type;
                    fnOutArgs.Doctor = "";
                    PHY2001U04StringResult fnOutRes = CloudService.Instance.Submit<PHY2001U04StringResult, PHY2001U04FnOutCheckNaewonYnArgs>(fnOutArgs);

                    object retVal = /*Service.ExecuteScalar(cmdText, bindVars);*/ fnOutRes.ResStr;
                    if (retVal == null)
                    {
                    }
                    else
                    {
                        //if(retVal.ToString() == "Y")
                        //{
                        //    XMessageBox.Show("診療科で内院確認が終わりましたので削除できません。診療科に問い合わせください。");
                        //    return false;
                        //}
                        if (retVal.ToString() == "E")
                        {
                            XMessageBox.Show(Resources.XMessageBox28);
                            return;
                        }
                    }

//                    ArrayList inputList = new ArrayList();
//                    ArrayList outputList = new ArrayList();

//                    // 전표일자 구하기
//                    inputList.Add(UserInfo.UserID);

//                    cmdText = @"SELECT 'Y'
//                                  FROM DUAL 
//                                 WHERE EXISTS ( SELECT 'X'
//                                                    FROM OUT1001
//                                                   WHERE HOSP_CODE = :f_hosp_code 
//                                                   AND PKOUT1001 = :f_pkout1001 )";

//                    bindVars.Clear();
//                    bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bindVars.Add("f_pkout1001", pkout1001);

                    // updated by Cloud
                    PHY2001U04BtnDeleteExistYnArgs existArgs = new PHY2001U04BtnDeleteExistYnArgs();
                    existArgs.Pkout1001 = pkout1001;
                    PHY2001U04StringResult existRes = CloudService.Instance.Submit<PHY2001U04StringResult, PHY2001U04BtnDeleteExistYnArgs>(existArgs);

                    object retVal1 = /*Service.ExecuteScalar(cmdText, bindVars);*/ existRes.ResStr;
                    if (retVal1 == null)
                    {
                    }
                    else
                    {
                        if (retVal1.ToString() == "Y")
                        {
                            try
                            {
                                #region deleted by Cloud
//                                Service.BeginTransaction();

//                                // 내원 history table 삭제
//                                inputList.Clear();
//                                outputList.Clear();

//                                inputList.Add("D");
//                                inputList.Add(UserInfo.UserID);
//                                inputList.Add(naewon_date);
//                                inputList.Add(bunho);
//                                inputList.Add(gwa);
//                                inputList.Add(gubun);
//                                inputList.Add(0);                           // I_TUYAK_ILSU
//                                inputList.Add(doctor);
//                                inputList.Add("O");                         // I_IN_OUT
//                                inputList.Add(gwa);       // I_CHART_GWA
//                                inputList.Add("N");                         // I_SPECIAL_YN
//                                inputList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));     // I_TOIWON_DATE

//                                if (!Service.ExecuteProcedure("PR_OUT_INSERT_OUT0103", inputList, outputList))
//                                {
//                                    //XMessageBox.Show(Service.ErrFullMsg + " : PR_OUT_INSERT_OUT0103 Error");
//                                    throw new Exception("PR_OUT_INSERT_OUT0103 エラーです。");
//                                }
//                                else
//                                {
//                                    //o_err = outputList[0].ToString();
//                                }

//                                // 접수 삭제
//                                cmdText = string.Empty;

//                                cmdText = @"DELETE OUT1001
//                                             WHERE HOSP_CODE = :f_hosp_code 
//                                               AND PKOUT1001 = :f_pkout1001";

//                                bool retTF = Service.ExecuteNonQuery(cmdText, bindVars);
//                                if (!retTF)
//                                {
//                                    //XMessageBox.Show(Service.ErrFullMsg + " : OUT1001 DELETE Error");
//                                    throw new Exception("外来受付削除に失敗しました。\r\n" +
//                                                        "既に削除されている受付情報かオーダが登録されている受付情報です。\r\n" +
//                                                         Service.ErrFullMsg);
//                                }

//                                // 공비 삭제
//                                cmdText = string.Empty;

//                                cmdText = @"DELETE FROM OUT1002
//                                             WHERE HOSP_CODE = :f_hosp_code 
//                                               AND FKOUT1001 = :f_pkout1001";

//                                bool retTF1 = Service.ExecuteNonQuery(cmdText, bindVars);
//                                if (!retTF1)
//                                {
//                                }

//                                inputList.Clear();
//                                outputList.Clear();
//                                Service.CommitTransaction();

//                                //XMessageBox.Show("削除しました。","削除", MessageBoxIcon.Information);
//                                QueryData();

//                                //this.paBox.Reset();
//                                this.paBox.Focus();
                                #endregion

                                // updated by Cloud
                                PHY2001U04BtnDeleteArgs delArgs = new PHY2001U04BtnDeleteArgs();
                                delArgs.Bunho = bunho;
                                delArgs.ChartGwa = gwa;
                                delArgs.Doctor = doctor;
                                delArgs.Gubun = gubun;
                                delArgs.Gwa = gwa;
                                delArgs.InOut = "O";
                                delArgs.NaewonDate = naewon_date;
                                delArgs.SpecialYn = "N";
                                delArgs.ToiwonDate = "";
                                delArgs.TuyakIlsu = "0";
                                delArgs.User = UserInfo.UserID;
                                UpdateResult delRes = CloudService.Instance.Submit<UpdateResult, PHY2001U04BtnDeleteArgs>(delArgs);

                                string errMsg = string.Empty;
                                switch (delRes.Msg)
                                {
                                    case "1":
                                        errMsg = Resources.XMessageBox29;
                                        break;
                                    case "2":
                                        errMsg = Resources.XMessageBox30 + Service.ErrFullMsg;
                                        break;
                                    default:
                                        break;
                                }

                                if (!TypeCheck.IsNull(errMsg))
                                {
                                    throw new Exception(errMsg);
                                }

                                QueryData();

                                //this.paBox.Reset();
                                this.paBox.Focus();
                            }
                            catch (Exception xe)
                            {
                                //Service.RollbackTransaction();
                                //https://sofiamedix.atlassian.net/browse/MED-10610
                                //XMessageBox.Show(Resources.XMessageBox31 + xe.Message, Resources.XMessageBox_Caption31, MessageBoxIcon.Warning);

                            }
                        }
                    }
                }
            }

        }

        private void btnReser_Click(object sender, EventArgs e)
        {
            if (this.grdPatientList.RowCount > 0)
            {
                if (this.grdPatientList.CurrentRowNumber >= 0)
                {
                    CommonItemCollection openParam = new CommonItemCollection();

                    openParam.Add("bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));
                    openParam.Add("gwa", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
                    openParam.Add("doctor", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor"));
                    openParam.Add("naewon_date", this.dtpNaewonDate.GetDataValue());

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "RES1001U00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentMiddleLeft, openParam);

                    //this.paBox.Reset();
                    this.paBox.Focus();
                }
            }

        }

        private void btnJinryouEnd_Click(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();

            for (int i = 0; i < this.grdPatientList.RowCount; i++)
            {
                if (this.grdPatientList.IsSelectedRow(i))
                {
                    arr.Add(i);
                }
            }

            if (arr.Count == 1)
            {
                if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") == "N")
                {
                    XMessageBox.Show(Resources.XMessageBox32, Resources.XMessageBox_Caption32, MessageBoxIcon.Information);
                    return;
                }

                string suname = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "suname");
                string gwa_name = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa_name");
                string doctor_name = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor_name");
                string pkout1001 = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001");

                //진료종료취소처리
                if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "order_end_yn") == "Y")
                {
                    DialogResult dr = XMessageBox.Show(suname + Resources.XMessageBox33 + gwa_name + " " + doctor_name + Resources.XMessageBox34, Resources.XMessageBox_Caption33, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
//                        string cmdText = @"UPDATE OUT1001
//                                       SET NAEWON_YN = 'Y'
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND PKOUT1001 = :f_pkout1001";
//                        BindVarCollection bc = new BindVarCollection();

//                        bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bc.Add("f_pkout1001", pkout1001);

//                        if (!Service.ExecuteNonQuery(cmdText, bc))
//                        {
//                            XMessageBox.Show("診療終了取消に失敗しました。\r\n" + Service.ErrFullMsg, "診療終了取消失敗", MessageBoxIcon.Warning);
//                            return;
//                        }

                        // updated by Cloud
                        PHY2001U04BtnJinryouEndClickUpdateOut1001Args args = new PHY2001U04BtnJinryouEndClickUpdateOut1001Args();
                        args.NaewonYn = "Y";
                        args.Pkout1001 = pkout1001;
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, PHY2001U04BtnJinryouEndClickUpdateOut1001Args>(args);

                        if (res.ExecutionStatus != ExecutionStatus.Success || !res.Result)
                        {
                            XMessageBox.Show(Resources.XMessageBox35 + Service.ErrFullMsg, Resources.XMessageBox_Caption35, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                else //진료종료처리
                {
                    //DialogResult dr = XMessageBox.Show(suname + "さんの診療を終了しますか？\r\n　「" + gwa_name + " " + doctor_name + " 先生」", "診療終了", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //if (dr == DialogResult.Yes)
                    //{
//                    string cmdText = @"UPDATE OUT1001
//                                       SET NAEWON_YN = 'E'
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND PKOUT1001 = :f_pkout1001";
//                    BindVarCollection bc = new BindVarCollection();

//                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bc.Add("f_pkout1001", pkout1001);

//                    if (!Service.ExecuteNonQuery(cmdText, bc))
//                    {
//                        XMessageBox.Show("診療終了に失敗しました。\r\n" + Service.ErrFullMsg, "診療終了失敗", MessageBoxIcon.Warning);
//                        return;
//                    }
                    //}            

                    // updated by Cloud
                    PHY2001U04BtnJinryouEndClickUpdateOut1001Args args = new PHY2001U04BtnJinryouEndClickUpdateOut1001Args();
                    args.NaewonYn = "E";
                    args.Pkout1001 = pkout1001;
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, PHY2001U04BtnJinryouEndClickUpdateOut1001Args>(args);

                    if (res.ExecutionStatus != ExecutionStatus.Success || !res.Result)
                    {
                        XMessageBox.Show(Resources.XMessageBox36 + Service.ErrFullMsg, Resources.XMessageBox_Caption36, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else if (arr.Count > 1)
            {
                #region deleted by Cloud
//                for (int i = 0; i < arr.Count; i++)
//                {
//                    int currRow = int.Parse(arr[i].ToString());
//                    if (this.grdPatientList.GetItemString(currRow, "naewon_yn") == "N")
//                    {
//                        XMessageBox.Show("まだ来院していない患者ですので、診療終了出来ません。", "来院確認", MessageBoxIcon.Information);
//                        return;
//                    }

//                    string suname = this.grdPatientList.GetItemString(currRow, "suname");
//                    string gwa_name = this.grdPatientList.GetItemString(currRow, "gwa_name");
//                    string doctor_name = this.grdPatientList.GetItemString(currRow, "doctor_name");
//                    string pkout1001 = this.grdPatientList.GetItemString(currRow, "pkout1001");

//                    //진료종료취소처리
//                    if (this.grdPatientList.GetItemString(currRow, "order_end_yn") == "Y")
//                    {
//                        //DialogResult dr = XMessageBox.Show(suname + "さんの診療終了を取り消しますか？\r\n　「" + gwa_name + " " + doctor_name + " 先生」", "診療終了取消", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//                        //if (dr == DialogResult.Yes)
//                        //{
//                        string cmdText = @"UPDATE OUT1001
//                                       SET NAEWON_YN = 'Y'
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND PKOUT1001 = :f_pkout1001";
//                        BindVarCollection bc = new BindVarCollection();

//                        bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bc.Add("f_pkout1001", pkout1001);

//                        if (!Service.ExecuteNonQuery(cmdText, bc))
//                        {
//                            XMessageBox.Show("診療終了取消に失敗しました。\r\n" + Service.ErrFullMsg, "診療終了取消失敗", MessageBoxIcon.Warning);
//                            return;
//                        }
//                        //}
//                    }
//                    else //진료종료처리
//                    {

//                        string cmdText = @"UPDATE OUT1001
//                                       SET NAEWON_YN = 'E'
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND PKOUT1001 = :f_pkout1001";
//                        BindVarCollection bc = new BindVarCollection();

//                        bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bc.Add("f_pkout1001", pkout1001);

//                        if (!Service.ExecuteNonQuery(cmdText, bc))
//                        {
//                            XMessageBox.Show("診療終了に失敗しました。\r\n" + Service.ErrFullMsg, "診療終了失敗", MessageBoxIcon.Warning);
//                            return;
//                        }
//                    }
//                }
                #endregion

                // updated by Cloud
                List<PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info> lstData = new List<PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info>();
                for (int i = 0; i < arr.Count; i++)
                {
                    int currRow = int.Parse(arr[i].ToString());
                    if (this.grdPatientList.GetItemString(currRow, "naewon_yn") == "N")
                    {
                        XMessageBox.Show(Resources.XMessageBox37, Resources.XMessageBox_Caption12, MessageBoxIcon.Information);
                        return;
                    }
                    string pkout1001 = this.grdPatientList.GetItemString(currRow, "pkout1001");

                    PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info item = new PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info();
                    item.OrderEndYn = this.grdPatientList.GetItemString(currRow, "order_end_yn");
                    item.Pkout1001 = pkout1001;

                    lstData.Add(item);
                }

                if (lstData.Count > 0)
                {
                    PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Args args = new PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Args();
                    args.Pkout1001LstItem = lstData;
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Args>(args);

                    if (res.Msg == "1")
                    {
                        XMessageBox.Show(Resources.XMessageBox35 + Service.ErrFullMsg, Resources.XMessageBox_Caption35, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (res.Msg == "2")
                    {
                        XMessageBox.Show(Resources.XMessageBox36 + Service.ErrFullMsg, Resources.XMessageBox_Caption36, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            QueryData();
        }

        private void NUR2001U04_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F12)
            //{
            //    this.btnPrint.PerformClick();
            //}

        }

        private void btnJubsuOpen_Click(object sender, EventArgs e)
        {
            //IHIS.Framework.XScreen.OpenScreen(this, "OUT1001U01", ScreenOpenStyle.ResponseFixed);
            CommonItemCollection param = new CommonItemCollection();
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT1001U01", ScreenOpenStyle.ResponseFixed, param);
        }

        private void btnOUT0106_Click(object sender, EventArgs e)
        {
            if (this.grdPatientList.RowCount > 0)
            {
                if (this.grdPatientList.CurrentRowNumber >= 0)
                {
                    CommonItemCollection openParams = new CommonItemCollection();

                    openParams.Add("bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));

                    XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);

                    this.QueryData();
                    //this.paBox.Reset();
                    this.paBox.Focus();

                }
            }

        }

        private void btnOrderAct_Click(object sender, EventArgs e)
        {
            if (this.grdPatientList.RowCount > 0)
            {
                if (this.grdPatientList.CurrentRowNumber >= 0)
                {
                    CommonItemCollection openParams = new CommonItemCollection();

                    string jubsu_gubun = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "jubsu_gubun");

                    if (jubsu_gubun == "13") // 내시경
                        openParams.Add("jundal_table", "PFES");
                    else if (jubsu_gubun == "09") // 검사만의 환자
                        openParams.Add("jundal_table", "XRTS");

                    openParams.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
                    openParams.Add("bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));

                    XScreen.OpenScreenWithParam(this, "OCSO", "OCSACT", IHIS.Framework.ScreenOpenStyle.PopUpFixed, ScreenAlignment.ScreenMiddleCenter, openParams);

                }
            }
        }

        private void paBox_Validating(object sender, CancelEventArgs e)
        {
            if (paBox.BunHo == "")
                QueryData();

        }

        private void grdPaCnt_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPaCnt.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdPaCnt.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());

        }

        private void grdPatientList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {

            if (this.grdPatientList.GetItemString(e.CurrentRow, "order_end_yn") == "Y")
            {
                this.btnJinryoEnd.Text = "診療終了取消";
            }
            else
            {
                this.btnJinryoEnd.Text = "診療終了";
            }

            //バイタル照会
            MultiLayout layNUR7001 = new MultiLayout();

            layNUR7001.LayoutItems.Add("bp_from", DataType.String);
            layNUR7001.LayoutItems.Add("bp_to", DataType.String);
            layNUR7001.LayoutItems.Add("pulse", DataType.String);
            layNUR7001.LayoutItems.Add("bt", DataType.String);
            layNUR7001.InitializeLayoutTable();

//            layNUR7001.QuerySQL = @"SELECT B.BP_FROM
//                                         , B.BP_TO
//                                         , B.PULSE
//                                         , B.BODY_HEAT
//                                      FROM (       
//                                            SELECT MAX(SEQ) SEQ
//                                              FROM NUR7001 A
//                                             WHERE A.HOSP_CODE    = :f_hosp_code
//                                               AND A.BUNHO        = :f_bunho
//                                               AND A.MEASURE_DATE = :f_measure_date
//                                            )     AA
//                                        , NUR7001 B
//                                    WHERE B.HOSP_CODE    = :f_hosp_code
//                                      AND B.BUNHO        = :f_bunho
//                                      AND B.MEASURE_DATE = :f_measure_date
//                                      AND B.SEQ          = AA.SEQ
//                                      AND B.VALD         = 'Y'
//                                   ";

            // updated by Cloud
            layNUR7001.ParamList = new List<string>(new string[] { "f_bunho", "f_measure_date" });
            layNUR7001.ExecuteQuery = GetLayNUR7001;

            layNUR7001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layNUR7001.SetBindVarValue("f_bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));
            layNUR7001.SetBindVarValue("f_measure_date", this.dtpNaewonDate.GetDataValue());

            layNUR7001.QueryLayout(false);

            string bp_from = layNUR7001.GetItemString(0, "bp_from");
            string bp_to = layNUR7001.GetItemString(0, "bp_to");
            string pulse = layNUR7001.GetItemString(0, "pulse");
            string bt = layNUR7001.GetItemString(0, "bt");

            this.txtBR_FROM.Text = bp_from;
            this.txtBR_TO.Text = bp_to;
            this.txtPulse.Text = pulse;
            this.txtBT.Text = bt;

            //this.grdPatientList.Refresh();
            //this.grdPatientList.Refresh();
            //this.grdPatientList.Refresh();

            this.grdList.QueryLayout(false);
            this.grdOUT1001.QueryLayout(false);
            this.txtBR_TO.Focus();
        }

        private void btnBunhoChage_Click(object sender, EventArgs e)
        {
            if (this.grdPatientList.RowCount > 0)
            {
                if (this.grdPatientList.CurrentRowNumber >= 0)
                {
                    CommonItemCollection openParams = new CommonItemCollection();
                    openParams.Add("naewon_date", this.dtpNaewonDate.GetDataValue());

                    if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho_type") != "0" &&
                        this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho_type") != "")
                    {
                        openParams.Add("bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));
                    }
                    else
                    {
                        openParams.Add("bunho", "");

                    }
                    XScreen.OpenScreenWithParam(this, "NURO", "OUT1001P03", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);

                    this.QueryData();
                    //this.paBox.Reset();
                    this.paBox.Focus();
                }
            }

        }

        private void grdPatientList_GridSorted(object sender, EventArgs e)
        {

            //입원중인환자 이미지 처리
            DisplayListImage(this.grdPatientList);
        }

        private void btnRehaJubsu_Click(object sender, EventArgs e)
        {
            //既に受付区分がリハビリテーションになっている場合は無効とする。
            if (this.grdPatientList.RowCount < 1 || this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "jubsu_gubun") == "10")
                return;

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            int currRow = this.grdPatientList.CurrentRowNumber;
            inputList.Add(this.grdPatientList.GetItemString(currRow, "pkout1001"));   //0
            inputList.Add(this.grdPatientList.GetItemString(currRow, "gwa"));         //1
            inputList.Add(this.grdPatientList.GetItemString(currRow, "doctor"));      //2
            inputList.Add("10");                                                      //3
            inputList.Add(UserInfo.UserID);                                           //4
            inputList.Add(this.grdPatientList.GetItemString(currRow, "bunho"));       //5
            inputList.Add(this.grdPatientList.GetItemString(currRow, "naewon_date")); //6

            if (this.IsDuplicationJubsu(inputList))
            {
                if (XMessageBox.Show(Resources.XMessageBox38, Resources.XMessageBox_Caption23, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            //if (!Service.ExecuteProcedure("PR_OUT_MAKE_AUTO_JUBSU", inputList, outputList))
            //{
            //    XMessageBox.Show("受付データの生成に失敗しました。\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
            //    return;
            //}

            //if (outputList != null)
            //{
            //    if (outputList[1] != null)
            //    {
            //        if (outputList[1].ToString() != "0")
            //        {
            //            XMessageBox.Show("受付データの生成に失敗しました。\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
            //            return;
            //        }
            //    }
            //}

            // updated by Cloud
            PHY2001U04PrOutMakeAutoJubsuArgs args = new PHY2001U04PrOutMakeAutoJubsuArgs();
            args.Bunho = this.grdPatientList.GetItemString(currRow, "bunho");
            args.Doctor = this.grdPatientList.GetItemString(currRow, "doctor");
            args.Gwa = this.grdPatientList.GetItemString(currRow, "gwa");
            args.JubsuGubun = "10";
            args.NaewonDate = this.grdPatientList.GetItemString(currRow, "naewon_date");
            args.Pkout1001 = this.grdPatientList.GetItemString(currRow, "pkout1001");
            args.UserId = UserInfo.UserID;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, PHY2001U04PrOutMakeAutoJubsuArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.Msg != "0")
                {
                    XMessageBox.Show(Resources.XMessageBox39 + Service.ErrFullMsg, Resources.XMessageBox_Caption3, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                XMessageBox.Show(Resources.XMessageBox39 + Service.ErrFullMsg, Resources.XMessageBox_Caption3, MessageBoxIcon.Warning);
                return;
            }

            QueryData();

            //this.SaveAfterSetFocus(outputList[0].ToString()); //Query後変更したＲＯＷにＦＯＣＵＳ設定
            this.SaveAfterSetFocus(res.Msg); //Query後変更したＲＯＷにＦＯＣＵＳ設定
        }

        private void grdPatientList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            //            XEditGrid grid = sender as XEditGrid;
            //            object previousValue = grid.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer);
            //            string procedure_name = "PR_REH_ADD_REHASINRYOURYOU";
            //            ArrayList inputList_sin = new ArrayList();
            //            ArrayList outputList_sin = new ArrayList();


            //            if (e.ColName == "jubsu_gubun")
            //            {
            //                string naewon_date = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_date");
            //                string bunho = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho");
            //                string suname = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "suname");
            //                string gwa = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa");
            //                string gwa_name = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa_name");
            //                string doctor = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor");
            //                string doctor_name = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor_name");
            //                string naewon_type = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_type");
            //                string jubsu_no = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "jubsu_no");
            //                string pkout1001 = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001");
            //                string gubun = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gubun");

            //                DialogResult dr = XMessageBox.Show(suname + "さんの受付区分を変更しますか？", "受付変更確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                if (dr == DialogResult.Yes)
            //                {
            //                    try
            //                    {
            //                        Service.BeginTransaction();

            //                        int currRow_sin = this.grdPatientList.CurrentRowNumber;

            //                        // 以前の受付区分が診察料自動発生対象だったのかチェック
            //                        if (   previousValue.ToString() == "20" || previousValue.ToString() == "21" || previousValue.ToString() == "22")
            //                        {
            //                            if (this.cbxSinryouryou.Checked == true)
            //                            {
            //                                inputList_sin = new ArrayList();
            //                                outputList_sin = new ArrayList();
            //                                inputList_sin.Add(naewon_date);               //1
            //                                inputList_sin.Add(bunho);                     //2
            //                                inputList_sin.Add(pkout1001);                 //3
            //                                inputList_sin.Add(doctor);                    //4
            //                                inputList_sin.Add(previousValue.ToString());  //5
            //                                inputList_sin.Add(UserInfo.UserID);           //6
            //                                inputList_sin.Add(EnvironInfo.HospCode);      //7
            //                                inputList_sin.Add("11");                      //8 REHA 11
            //                                inputList_sin.Add("D");                       //9

            //                                Service.ExecuteProcedure(procedure_name, inputList_sin, outputList_sin);

            //                                if (outputList_sin[0].ToString() != "1")
            //                                {
            //                                    XMessageBox.Show(outputList_sin[0].ToString() + "\r\n" + outputList_sin[1].ToString() + "\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
            //                                    Service.RollbackTransaction();
            //                                    return;
            //                                }
            //                            }
            //                        }

            //                        // 今回変わった受付区分が診察料自動発生対象なのかチェック
            //                        if (   e.ChangeValue.ToString() == "20" || e.ChangeValue.ToString() == "21" || e.ChangeValue.ToString() == "22")
            //                        {
            //                            if (this.cbxSinryouryou.Checked == true)
            //                            {
            //                                inputList_sin = new ArrayList();
            //                                outputList_sin = new ArrayList();
            //                                inputList_sin.Add(naewon_date);               //1
            //                                inputList_sin.Add(bunho);                     //2
            //                                inputList_sin.Add(pkout1001);                 //3
            //                                inputList_sin.Add(doctor);                    //4
            //                                inputList_sin.Add(e.ChangeValue.ToString());  //5
            //                                inputList_sin.Add(UserInfo.UserID);           //6
            //                                inputList_sin.Add(EnvironInfo.HospCode);      //7
            //                                inputList_sin.Add("11");                      //8 REHA 11
            //                                inputList_sin.Add("I");                       //9

            //                                Service.ExecuteProcedure(procedure_name, inputList_sin, outputList_sin);

            //                                if (outputList_sin[0].ToString() != "1")
            //                                {
            //                                    XMessageBox.Show(outputList_sin[0].ToString() + "\r\n" + outputList_sin[1].ToString() + "\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
            //                                    Service.RollbackTransaction();
            //                                    return;
            //                                }
            //                            }
            //                        }

            //                        string cmdText = "";
            //                        BindVarCollection bind = new BindVarCollection();
            //                        ArrayList inputList = new ArrayList();
            //                        inputList.Add(pkout1001);                 //0
            //                        inputList.Add(gwa);                       //1
            //                        inputList.Add(doctor);                    //2
            //                        inputList.Add(e.ChangeValue.ToString());  //3
            //                        inputList.Add(UserInfo.UserID);           //4
            //                        inputList.Add(bunho);                   　//5
            //                        inputList.Add(naewon_date);               //6

            //                        if (this.IsDuplicationJubsu(inputList))
            //                        {
            //                            if (XMessageBox.Show("既に同じ受付区分が登録されています。このまま受付登録しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //                            {
            //                                Service.RollbackTransaction();
            //                                return;
            //                            }
            //                        }

            //                        cmdText = @"UPDATE OUT1001 A
            //                                       SET A.UPD_ID      = :f_user_id
            //                                         , A.UPD_DATE    = SYSDATE
            //                                         , A.NAEWON_YN   = :f_naewon_yn
            //                                         , A.ARRIVE_TIME = :f_arrive_time
            //                                         , A.JUBSU_GUBUN = :f_jubsu_gubun
            //                                         
            //                                     WHERE A.HOSP_CODE   = :f_hosp_code
            //                                       AND A.PKOUT1001   = :f_pkout1001";

            //                        bind.Add("f_user_id", UserInfo.UserID);
            //                        bind.Add("f_naewon_yn", this.grdPatientList.GetItemString(currRow_sin, "naewon_yn"));
            //                        bind.Add("f_arrive_time", this.grdPatientList.GetItemString(currRow_sin, "arrive_time"));
            //                        bind.Add("f_jubsu_gubun", this.grdPatientList.GetItemString(currRow_sin, "jubsu_gubun"));
            //                        bind.Add("f_hosp_code", EnvironInfo.HospCode);
            //                        bind.Add("f_pkout1001", this.grdPatientList.GetItemString(currRow_sin, "pkout1001"));

            //                        if (!Service.ExecuteNonQuery(cmdText, bind))
            //                        {
            //                            Service.RollbackTransaction();
            //                            return;
            //                        }

            //                        Service.CommitTransaction();
            //                        this.btnList.PerformClick(FunctionType.Query);
            //                    }
            //                    catch
            //                    {
            //                        Service.RollbackTransaction();
            //                    }
            //                }
            //            }








            //ArrayList inputList = new ArrayList();
            //int currRow = this.grdPatientList.CurrentRowNumber;

            //inputList.Add(this.grdPatientList.GetItemString(currRow, "pkout1001"));   //0
            //inputList.Add(this.grdPatientList.GetItemString(currRow, "gwa"));         //1
            //inputList.Add(this.grdPatientList.GetItemString(currRow, "doctor"));      //2
            //inputList.Add(this.grdPatientList.GetItemString(currRow, "jubsu_gubun")); //3
            //inputList.Add(UserInfo.UserID);                                           //4
            //inputList.Add(this.grdPatientList.GetItemString(currRow, "bunho"));       //5
            //inputList.Add(this.grdPatientList.GetItemString(currRow, "naewon_date")); //6

            //if (this.IsDuplicationJubsu(inputList))
            //{
            //    if (XMessageBox.Show("既に同じ受付区分が登録されています。このまま受付登録しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //    {
            //        this.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue); // 이전값으로 되돌린다.
            //        return;
            //    }
            //}
            //ArrayList arr = new ArrayList();
            //arr.Add(e.RowNumber);
            //arr.Add(e.ColName);

            //object obj = arr;
            //PostCallHelper.PostCall(new PostMethodObject(AfterSave), obj);
            //this.AfterSave(e.RowNumber, e.ColName);

            //switch (e.ChangeValue.ToString())
            //{
            //    case "20":
            //        this.btnGaisin1.PerformClick();
            //        break;
            //    case "21":
            //        this.btnGaisin2.PerformClick();
            //        break;
            //    case "22":
            //        this.btnSaisin.PerformClick();
            //        break;
            //    case "10":
            //        this.btnReha.PerformClick();
            //        break;
            //}



        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            //if (TypeCheck.IsNull(this.statFlg))
            //    XMessageBox.Show("Error");

            //// ボタン状態セット
            //if (this.statFlg.Equals("P"))
            //    this.grdList.SetBindVarValue("f_stat_flg", "P");

            //if (this.statFlg.Equals("C"))
            //    this.grdList.SetBindVarValue("f_stat_flg", "C");

            //if (this.statFlg.Equals("F"))
            //    this.grdList.SetBindVarValue("f_stat_flg", "F");

            //// ボタン色セット
            //this.changeBtnSelectModeColor(this.statFlg);
            XEditGrid grd = this.grdPatientList;

            this.grdList.SetBindVarValue("f_stat_flg", "C");
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_bunho", grd.GetItemString(grd.CurrentRowNumber, "bunho"));
            this.grdList.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
            this.grdList.SetBindVarValue("f_gwa", "%");

            if (this.fbxDoctor.GetDataValue().Equals(""))
                this.grdList.SetBindVarValue("f_doctor", this.fbxDoctor.GetDataValue());
            else
                this.grdList.SetBindVarValue("f_doctor", this.cboGwa.GetDataValue() + this.fbxDoctor.GetDataValue());

            this.grdList.SetBindVarValue("f_gubun", this.rbtYoyaku.Checked == true ? "Y" : "J");
        }

        private void grdList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            // 患者状態セット
            for (int i = 0; i < this.grdList.RowCount; i++)
            {
                string curState = this.grdList.GetItemString(i, "reser_yn");

                if (curState.Equals("A"))
                {
                    this.grdList.SetItemValue(i, "reser_yn", "当");
                }

                if (curState.Equals("N"))
                {
                    this.grdList.SetItemValue(i, "reser_yn", "未");
                }

                if (curState.Equals("Y"))
                {
                    this.grdList.SetItemValue(i, "reser_yn", "予");
                }
            }

            // GRIDのFONT色を元に戻す。
            this.grdList.ResetUpdate();
        }

        private void grdPatientList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                this.btnGaisin1.PerformClick();
            }
            else if (e.KeyCode == Keys.F7)
            {
                this.btnGaisin2.PerformClick();
            }
            else if (e.KeyCode == Keys.F8)
            {
                this.btnSaisin.PerformClick();
            }
            else if (e.KeyCode == Keys.F9)
            {
                this.btnReha.PerformClick();
            }
            else if (e.KeyCode == Keys.F10)
            {
                this.btnJinryoEnd.PerformClick();
            }
            //XMessageBox.Show(e.KeyCode + "    " + e.KeyData + "   " + e.KeyValue + "   " + e.ToString());
        }

        private void btnGaisin1_Click(object sender, EventArgs e)
        {
            if (this.IsEnableChangedJubsuGubun())
            {
                this.grdPatientList.SetItemValue(this.grdPatientList.CurrentRowNumber, "jubsu_gubun", "20");
                //this.grdPatientList.SaveLayout();
                SavePatientGrid();
                this.CreateAutoJubsu("10", "20");
            }
        }

        private void btnGaisin2_Click(object sender, EventArgs e)
        {
            if (this.IsEnableChangedJubsuGubun())
            {
                this.grdPatientList.SetItemValue(this.grdPatientList.CurrentRowNumber, "jubsu_gubun", "21");
                //this.grdPatientList.SaveLayout();
                SavePatientGrid();
                this.CreateAutoJubsu("10", "21");
            }
        }

        private void btnSaisin_Click(object sender, EventArgs e)
        {
            if (this.IsEnableChangedJubsuGubun())
            {
                this.grdPatientList.SetItemValue(this.grdPatientList.CurrentRowNumber, "jubsu_gubun", "22");
                //this.grdPatientList.SaveLayout();
                SavePatientGrid();
                this.CreateAutoJubsu("10", "22");
            }
        }

        private void btnReha_Click(object sender, EventArgs e)
        {
            if (this.IsEnableChangedJubsuGubun())
            {
                string pkout1001 = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001");
                this.grdPatientList.SetItemValue(this.grdPatientList.CurrentRowNumber, "jubsu_gubun", "10");
                //this.grdPatientList.SaveLayout();
                SavePatientGrid();
                QueryData();
                this.SaveAfterSetFocus(pkout1001); //Query後変更したＲＯＷにＦＯＣＵＳ設定
            }
        }

        private void btnVital_Click(object sender, EventArgs e)
        {
            int currRow = this.grdPatientList.CurrentRowNumber;

            if (this.ChkVitalValue())
            {
                if (this.InsertVital())
                {
                    XMessageBox.Show(Resources.XMessageBox40, Resources.XMessageBox_Caption23);
                    QueryData();
                    this.SaveAfterSetFocus(this.grdPatientList.GetItemString(currRow, "pkout1001"));
                }
                else
                {
                    XMessageBox.Show("ERR");
                    return;
                }
            }
            else
                return;
        }

        /// <summary>
        /// 정수만 등록할 수 있도록 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ComBoInt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            XComboBox numCombo = sender as XComboBox;

            if (e.KeyChar != (char)8 && !TypeCheck.IsInt(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void grdOUT1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOUT1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOUT1001.SetBindVarValue("f_bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));
            this.grdOUT1001.SetBindVarValue("f_gwa", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
            this.grdOUT1001.SetBindVarValue("f_naewon_date", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_date"));
        }

        private void btnJissekiVisibleYN_Click(object sender, EventArgs e)
        {
            if (this.JissekiVisibleYN)
            {
                this.btnJissekiVisibleYN.ImageIndex = 27;
                this.JissekiVisibleYN = false;
                this.pnlJisseki.Visible = false;
            }
            else
            {
                this.btnJissekiVisibleYN.ImageIndex = 26;
                this.JissekiVisibleYN = true;
                this.pnlJisseki.Visible = true;
            }


        }

        private void btnNaewonRirekiVisibleYN_Click(object sender, EventArgs e)
        {
            if (this.NaewonRirekiVisibleYN)
            {
                this.btnNaewonRirekiVisibleYN.ImageIndex = 27;
                this.NaewonRirekiVisibleYN = false;
                this.pnlNaewonRireki.Visible = false;
                this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width - this.pnlNaewonRireki.Size.Width, ParentForm.Height);
            }
            else
            {
                this.btnNaewonRirekiVisibleYN.ImageIndex = 26;
                this.NaewonRirekiVisibleYN = true;
                this.pnlNaewonRireki.Visible = true;
                this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width + this.pnlNaewonRireki.Size.Width, ParentForm.Height);
            }
        }

        private void btnHealthQuestionnair_Click(object sender, EventArgs e)
        {
            string targetUrl = "";
            string HQNServerIP = this.mRehaBiz.GetServerIP("HQN");
            targetUrl = "http://" + HQNServerIP + "/Public/index.html?page=answers&patientid=" + this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho");
            System.Diagnostics.Process.Start(targetUrl);
        }

        private void tabPHY_SelectionChanged(object sender, EventArgs e)
        {
            XTabControl tab = sender as XTabControl;

            switch (tab.SelectedTab.Tag.ToString())
            {
                case "0":
                    this.grdPatientList.QueryLayout(false);
                    this.pnlFill.Enabled = true;
                    break;
                case "1":
                    this.grdOUT.QueryLayout(false);
                    this.pnlFill.Enabled = false;
                    break;
                case "2":
                    this.grdINP.QueryLayout(false);
                    this.pnlFill.Enabled = false;
                    break;
            }

        }

        private void grdOUT_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOUT.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOUT.SetBindVarValue("f_order_date", this.dtpNaewonDate.GetDataValue());
        }

        private void grdINP_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP.SetBindVarValue("f_order_date", this.dtpNaewonDate.GetDataValue());
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.cbxAutoNewIraiCheck.Checked == true)
            {
                this.GetNewOrderFormOUT();
                this.GetNewOrderFormINP();
            }
        }

        private void grdPatientList_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.cbxAuto_Cusor.Checked == true)
                this.txtBR_TO.Focus();
        }

        private void rbtYoyaku_CheckedChanged(object sender, EventArgs e)
        {
            this.grdList.QueryLayout(false);
        }

        private void grdExcel_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdExcel.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdExcel.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
            this.grdExcel.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
            this.grdExcel.SetBindVarValue("f_doctor", this.fbxDoctor.GetDataValue());
            this.grdExcel.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdExcel.SetBindVarValue("f_jubsu_gubun", this.cboJubsuGubun.GetDataValue());

            if (this.rbtJinryoAll.Checked)
                this.grdExcel.SetBindVarValue("f_jinryo_yn", "ALL");
            else if (this.rbtJinryoEnd.Checked)
                this.grdExcel.SetBindVarValue("f_jinryo_yn", "Y");
            else if (this.rbtJinryoNotEnd.Checked)
                this.grdExcel.SetBindVarValue("f_jinryo_yn", "N");


            if (this.rbtNaewonAll.Checked)
                this.grdExcel.SetBindVarValue("f_naewon_yn", "ALL");
            else if (this.rbtNaewon.Checked)
                this.grdExcel.SetBindVarValue("f_naewon_yn", "Y");
            else if (this.rbtMiNaewon.Checked)
                this.grdExcel.SetBindVarValue("f_naewon_yn", "N");
        }

        #endregion

        #region Methods(private)

        /// <summary>
        /// 메세지 일괄 처리
        /// </summary>
        /// <param name="aMesgGubun">
        /// 메세지 구분
        /// </param>
        private void GetMessage(string aMesgGubun)
        {
            string msg = string.Empty;
            string caption = string.Empty;

            switch (aMesgGubun)
            {
                case "bunho":
                    XMessageBox.Show(Resources.XMessageBox41, Resources.XMessageBox_Caption41, MessageBoxIcon.Information);
                    break;
                case "orderEndYn":
                    XMessageBox.Show(Resources.XMessageBox42, Resources.XMessageBox_Caption41, MessageBoxIcon.Information);
                    break;
                case "doctor":
                   XMessageBox.Show(Resources.XMessageBox43, Resources.XMessageBox_Caption41, MessageBoxIcon.Information);
                    break;
                case "doctorChange":
                    msg = Resources.XMessageBox44;
                    msg += "\r\n[" + Service.ErrFullMsg + "]";
                    XMessageBox.Show(msg, Resources.XMessageBox_Caption44, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }

        private void QueryData()
        {
            if (!this.mQueryFlag)
                return;

            if (!this.mPowerQuery)
            {
                if (!CheckSave())
                {
                    return;
                }
            }

            if (DateTime.Now.Hour > 13)
                this.Aampm_gubun = "P";
            else
                this.Aampm_gubun = "A";

            if (this.dtpNaewonDate.GetDataValue().ToString() == "") return;

            if (this.cboGwa.GetDataValue().ToString() == "") return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.grdPatientList.QueryLayout(true))
                {
                    if (Service.ErrFullMsg == "DB Connection is not opened")
                    {
                        mReconnectCnt++;
                        //int auto_hide_time = (this.timer.Interval - 10000) / 1000;
                        //XMessageBox.Show("データベースと繋がっていません。再接続します。\r\n" + //プログラムを再起動してください。\r\n" + 
                        //                 "問題が続く場合は電算室にお問い合わせください。（" + mReconnectCnt.ToString() + "回再接続しました。）", "DBコネクションエラー", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1, MessageBoxIcon.Information, auto_hide_time);

                        if (Service.Connect())
                        {
                            mReconnectCnt = 0;
                        }
                        else
                        {
                            if (mReconnectCnt == 3)
                            {
                                mReconnectCnt = 0;
                                this.cbxAutoQuery.Checked = false;
                                XMessageBox.Show(Resources.XMessageBox45, Resources.XMessageBox_Caption45, MessageBoxIcon.Warning);

                            }
                        }

                        return;
                    }

                    if (Service.ErrCode != 3113)
                        XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }
                //this.cbxAutoQuery.Checked = true;

                if (this.grdPatientList.RowCount == 0)
                {
                    this.grdList.Reset();
                    this.grdOUT1001.Reset();
                }

                //입원중인환자 이미지 처리
                DisplayListImage(this.grdPatientList);

                //환자 카운트
                //this.grdPaCnt.QueryLayout(true);
                RefreshCounter();

            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            
            }
        }

        private void DisplayListImage(XEditGrid aGrd)
        {
            if (aGrd == null) return;

            this.grdPatientList.ResetUpdate();

            int imagColIndex = 0;

            try
            {
                //aGrd.Redraw = false; // Grid Display 멈춤               

                //for (int i = 0; i < aGrd.RowCount; i++)
                //{
                //    aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = null;
                //    aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText = "";

                //    if (aGrd.GetItemValue(i, "reser_yn").ToString().Trim() == "Y")
                //    {
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText += "/予約";
                //        //aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = this.ImageList.Images[13];
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = this.ImageList.Images[9];
                //    }

                //    if (aGrd.GetItemValue(i, "naewon_type").ToString().Trim() == "1")
                //    {
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText += "/診療依頼";
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = this.ImageList.Images[10];
                //    }

                //    if (aGrd.GetItemValue(i, "jubsu_gubun").ToString().Trim() == "07") //약환자
                //    {
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText += "/" + aGrd.GetItemValue(i, "jubsu_gubun_name").ToString().Trim();
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = this.ImageList.Images[7];
                //    }
                //    else if (aGrd.GetItemValue(i, "jubsu_gubun").ToString().Trim() == "14") //구급환자
                //    {
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText += "/" + aGrd.GetItemValue(i, "jubsu_gubun_name").ToString().Trim();
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = this.ImageList.Images[8];
                //    }
                //    else if (aGrd.GetItemValue(i, "jubsu_gubun").ToString().Trim() == "11") //건강검진 환자
                //    {
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText += "/" + aGrd.GetItemValue(i, "jubsu_gubun_name").ToString().Trim();
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = this.ImageList.Images[15];
                //    }
                //    else if (aGrd.GetItemValue(i, "jubsu_gubun").ToString().Trim() == "15") //특정검진 환자
                //    {
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText += "/" + aGrd.GetItemValue(i, "jubsu_gubun_name").ToString().Trim();
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = this.ImageList.Images[15];
                //    }

                //    if (aGrd.GetItemValue(i, "ipwon_yn").ToString().Trim() == "Y") // 입원중인 환자
                //    {
                //        //aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText = aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText + "予約";
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText += "/入院患者";
                //        aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = this.ImageList.Images[4];
                //    }
                //}
                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = null;
                    aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].ToolTipText = "";

                    if (aGrd.GetItemValue(i, "reser_yn").ToString().Trim() == "Y")
                    {
                        aGrd[i, "icon"].ToolTipText += "/予約";
                        aGrd[i, "icon"].Image = this.ImageList.Images[9];
                    }

                    if (aGrd.GetItemValue(i, "naewon_type").ToString().Trim() == "1")
                    {
                        aGrd[i, "icon"].ToolTipText += "/診療依頼";
                        aGrd[i, "icon"].Image = this.ImageList.Images[10];
                    }

                    if (aGrd.GetItemValue(i, "jubsu_gubun").ToString().Trim() == "07") //약환자
                    {
                        aGrd[i, "icon"].ToolTipText += "/" + aGrd.GetItemValue(i, "jubsu_gubun_name").ToString().Trim();
                        aGrd[i, "icon"].Image = this.ImageList.Images[7];
                    }
                    else if (aGrd.GetItemValue(i, "gwa").ToString().Trim() == "04") //구급환자
                    {
                        aGrd[i, "icon"].ToolTipText += "/" + aGrd.GetItemValue(i, "jubsu_gubun_name").ToString().Trim();
                        aGrd[i, "icon"].Image = this.ImageList.Images[8];
                    }
                    else if (aGrd.GetItemValue(i, "jubsu_gubun").ToString().Trim() == "11") //건강검진 환자
                    {
                        aGrd[i, "icon"].ToolTipText += "/" + aGrd.GetItemValue(i, "jubsu_gubun_name").ToString().Trim();
                        aGrd[i, "icon"].Image = this.ImageList.Images[15];
                    }
                    else if (aGrd.GetItemValue(i, "jubsu_gubun").ToString().Trim() == "15") //특정검진 환자
                    {
                        aGrd[i, "icon"].ToolTipText += "/" + aGrd.GetItemValue(i, "jubsu_gubun_name").ToString().Trim();
                        aGrd[i, "icon"].Image = this.ImageList.Images[15];
                    }

                    if (aGrd.GetItemValue(i, "ipwon_yn").ToString().Trim() == "Y") // 입원중인 환자
                    {
                        aGrd[i, "icon"].ToolTipText += "/入院患者";
                        aGrd[i, "icon"].Image = this.ImageList.Images[4];
                    }

                    if (aGrd.GetItemValue(i, "kaigo_yn").ToString().Trim() == "Y") // 입원중인 환자
                    {
                        aGrd[i, "icon"].ToolTipText += "/介護保険";
                        aGrd[i, "icon"].Image = this.ImageList.Images[20];
                    }
                }
                this.grdPatientList.ResetUpdate();
            }
            catch { }

            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }
        }

        private void SetSinryouryouAuto()
        {
            #region 診療料自動発生ON・OFF

//            object obj = null;

//            string cmd_sin = @"SELECT A.CODE_NAME AUTO_YN
//                                 FROM OCS0132 A
//                                WHERE A.HOSP_CODE = :f_hosp_code
//                                  AND A.CODE_TYPE = :f_code_type
//                                  AND A.CODE      = :f_code
//                              ";
//            BindVarCollection bind_sin = new BindVarCollection();
//            bind_sin.Add("f_hosp_code", EnvironInfo.HospCode);
//            bind_sin.Add("f_code", "AUTO_YN");
//            bind_sin.Add("f_code_type", "REHA_AUTO_SINRYOURYOU");
            
//            obj = Service.ExecuteScalar(cmd_sin, bind_sin);

//            if (obj != null)
//            {
//                if (obj.ToString() == "Y")
//                    this.cbxSinryouryou.Checked = true;
//            }

//            bind_sin.Add("f_code", "ENABLE_YN");

//            obj = Service.ExecuteScalar(cmd_sin, bind_sin);

//            if (obj != null)
//            {
//                if (obj.ToString() == "Y")
//                    this.cbxSinryouryou.Enabled = true;
//            }

            #endregion

            // updated by Cloud
            PHY2001U04SetSinryouryouAutoArgs args = new PHY2001U04SetSinryouryouAutoArgs();
            args.Code1 = "AUTO_YN";
            args.Code2 = "ENABLE_YN";
            args.CodeType = "REHA_AUTO_SINRYOURYOU";
            PHY2001U04SetSinryouryouAutoResult res = CloudService.Instance.Submit<PHY2001U04SetSinryouryouAutoResult, PHY2001U04SetSinryouryouAutoArgs>(args);

            if (res.Obj1 == "Y") this.cbxSinryouryou.Checked = true;
            if (res.Obj2 == "Y") this.cbxSinryouryou.Enabled = true;
        }

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
            if (this.grdPatientList.RowCount > 0)
            {
                string bunho = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho");

                return new XPatientInfo(bunho, "", "", "", this.ScreenName);
            }

            return null;
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            //if (command == "NUR2001Q00")
            //{
            //    this.Tag = "Close";
            //    this.ChangeDoctor(commandParam["change_doctor"].ToString());
            //}

            if (command == "OCS0270Q00")
            {
                if (commandParam["gwa"] != null)
                    this.cboGwa.SetDataValue(commandParam["gwa"].ToString());

                //this.dbxDoctor_name.SetEditValue(commandParam["doctor_name"].ToString());
                //this.dbxDoctor_name.AcceptData();

                this.fbxDoctor.SetEditValue(commandParam["doctor"].ToString());
                this.fbxDoctor.AcceptData();
            }

            return base.Command(command, commandParam);
        }

        #region unused code
        //private void ChangeDoctor(string doctor)
        //{
        //    if (this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString() == "")
        //    {
        //        this.GetMessage("bunho");
        //        return;
        //    }

        //    string title = "";
        //    string msg = "";

        //    //처방완료
        //    if (this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "order_end_yn").ToString() == "Y")
        //    {
        //        this.GetMessage("orderEndYn");
        //        return;
        //    }

        //    //진료의 체크
        //    if (doctor == "")
        //    {
        //        this.GetMessage("doctor");
        //        return;
        //    }

        //    title = (NetInfo.Language == LangMode.Ko ? "진료의변경" : "診療医変更");

        //    //내원확인
        //    msg = (NetInfo.Language == LangMode.Ko ? this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "suname").ToString() + "님의 진료의를 변경하시겠습니까?"
        //        : this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "suname").ToString() + "様の 診療医を 変更しますか。");
        //    if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) != DialogResult.Yes) return;

        //    //접수키,예약여부,내원여부

        //    if (CallPrDoctorChange(doctor))
        //    {
        //        //재조회
        //        QueryData();
        //    }
        //}
        #endregion

        #region unused code
//        private bool CallPrDoctorChange(string aDoctor)
//        {
//            ArrayList inputList;
//            ArrayList outputList;
//            mDoctor = aDoctor;

//            this.layPKOUT1001.QuerySQL = @"SELECT PKOUT1001
//                                             FROM OUT1001
//                                            WHERE HOSP_CODE   = :f_hosp_code
//                                              AND NAEWON_DATE = :f_naewon_date
//                                              AND BUNHO       = :f_bunho
//                                              AND GWA         = :f_gwa
//                                              AND DOCTOR      = :f_doctor
//                                              AND NAEWON_TYPE = :f_naewon_type
//                                              AND JUBSU_NO    = :f_jubsu_no    ";

//            if (!this.layPKOUT1001.QueryLayout())
//            {
//                XMessageBox.Show("該当患者は既に変更されています。再度照会を行ってください。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return false;
//            }

//            if (!TypeCheck.IsNull(this.layPKOUT1001.GetItemValue("pkout1001")))
//            {
//                inputList = new ArrayList();
//                outputList = new ArrayList();

//                inputList.Add(this.layPKOUT1001.GetItemValue("pkout1001").ToString().Trim());
//                inputList.Add(aDoctor.Trim());
//                inputList.Add(" "); //clinic_code PC파일에 기본값 " "로 되어있음

//                Service.ExecuteProcedure("PR_OCSO_DOCTOR_CHANGE2", inputList, outputList);

//                if (!TypeCheck.IsNull(outputList[0]))
//                {
//                    if (outputList[0].ToString() != "0")
//                    {
//                        if (outputList[0].ToString() == "y")
//                        {
//                            XMessageBox.Show("既にオーダが入力されている患者は医師変更が出来ません。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                            return false;
//                        }
//                        else
//                        {
//                            XMessageBox.Show("該当医者への変更に失敗しました！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                            return false;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                XMessageBox.Show("該当患者は既に変更されています。再度照会を行ってください。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return false;            
//            }
//            return true;

//            #region 주석
//            //            else
////            {
////                /* 예약테이블에서 환자의 예약키를 찾는다. */
////                if (TypeCheck.IsNull(this.layPKOUT1001.GetItemValue("pkout1001")))
////                {
////                    this.layPKOUT1001.QuerySQL = @"SELECT PKRES1001
////                                                     FROM RES1001
////                                                    WHERE JINRYO_PRE_DATE = :f_naewon_date
////                                                      AND BUNHO           = :f_bunho
////                                                      AND GWA              = :f_gwa
////                                                      AND DOCTOR          = :f_doctor
////                                                      AND NAEWON_TYPE     = :f_naewon_type
////                                                      AND JUBSU_NO        = :f_jubsu_no";

////                    if (!this.layPKOUT1001.QueryLayout())
////                    {
////                        XMessageBox.Show("該当患者は既に変更されています。再度照会をしてください。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
////                        return false;
////                    }
////                    else
////                    {
////                        if (!TypeCheck.IsNull(this.layPKOUT1001.GetItemValue("pkout1001")))
////                        {
////                            inputList = new ArrayList();
////                            outputList = new ArrayList();

////                            inputList.Add(this.layPKOUT1001.GetItemValue("pkout1001").ToString().Trim());
////                            inputList.Add(aDoctor.Trim());
////                            inputList.Add(" "); //clinic_code PC파일에 기본값 " "로 되어있음

////                            Service.ExecuteProcedure("PR_OCSO_DOCTOR_CHANGE3", inputList, outputList);

////                            if (!TypeCheck.IsNull(outputList[0]))
////                            {
////                                if (outputList[0].ToString() != "0")
////                                {
////                                    if (outputList[0].ToString() == "y")
////                                    {
////                                        XMessageBox.Show("既にオーダが入力されている患者は医師変更が出来ません。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
////                                        return false;
////                                    }
////                                    else
////                                    {
////                                        XMessageBox.Show("該当医者への変更が失敗しました！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
////                                        return false;
////                                    }
////                                }
////                            }
////                        }
////                        else
////                        {
////                            XMessageBox.Show("該当患者は既に変更されています。再度照会をしてください。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
////                            return false;
////                        }
////                    }
////                    return true;
////                }
////                else /*의사변경처리*/
////                {
////                    inputList = new ArrayList();
////                    outputList = new ArrayList();

////                    inputList.Add(this.layPKOUT1001.GetItemValue("pkout1001").ToString().Trim());
////                    inputList.Add(aDoctor.Trim());
////                    inputList.Add(" "); //clinic_code PC파일에 기본값 " "로 되어있음

////                    Service.ExecuteProcedure("PR_OCSO_DOCTOR_CHANGE2", inputList, outputList);

////                    if (!TypeCheck.IsNull(outputList[0]))
////                    {
////                        if (outputList[0].ToString() != "0")
////                        {
////                            if (outputList[0].ToString() == "y")
////                            {
////                                XMessageBox.Show("既にオーダが入力されている患者は医師変更が出来ません。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
////                                return false;
////                            }
////                            else
////                            {
////                                XMessageBox.Show("該当医者への変更が失敗しました！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
////                                return false;
////                            }
////                        }
////                    }
////                    return true;
////                }
//            //            }
//            #endregion
//        }
        #endregion

        private bool CheckSave()
        {
            if (IsExistUpdatedData())
            {
                this.timer1.Stop();
                DialogResult dr = XMessageBox.Show(Resources.XMessageBox46, Resources.XMessageBox_Caption23, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);


                this.timer1.Start();
                if (dr == DialogResult.Yes)
                {
                    // updated by Cloud
                    if (!/*this.grdPatientList.SaveLayout()*/SavePatientGrid())
                    {
                        XMessageBox.Show(Resources.XMessageBox10 + Service.ErrFullMsg, Resources.XMessageBox_Caption5, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else if (dr == DialogResult.No)
                {

                }
                else if (dr == DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsExistUpdatedData()
        {
            foreach (DataRow row in this.grdPatientList.LayoutTable.Rows)
            { 
                if(this.grdPatientList.DeletedRowCount > 0)
                    return true;

                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    return true;
            }

            return false;
        }

        public void SaveAfterSetFocus(string aPkout1001)
        {
            for (int i = 0; i < this.grdPatientList.RowCount; i++)
            {
                if (this.grdPatientList.GetItemString(i, "pkout1001") == aPkout1001)
                {
                    this.grdPatientList.UnSelectAll();
                    this.grdPatientList.SelectRow(i);
                    this.grdPatientList.SetFocusToItem(i, "bunho");
                    this.txtBR_TO.Focus();
                }
            }
        }

        /// <summary> 
        /// XEditGrid에 값을 세팅하되 이전의 RowState를 유지하며, Option해당 컬럼에서 포커스를 유지시킨다
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <param name="aRow"> int Row </param>
        /// <param name="aColName"> string 컬럼 </param>
        /// <param name="aPreviousValue"> object Setting할 Value </param>
        /// <param name="aIsProtecedFocus"> bool Optional 포커스이동막을지여부(Defalut : True) </param>
        /// <returns> void </returns>
        public void UndoPreviousValue(XEditGrid aGrd, int aRow, string aColName, object aPreviousValue)
        {
            this.UndoPreviousValue(aGrd, aRow, aColName, aPreviousValue, true);
        }

        public void UndoPreviousValue(XEditGrid aGrd, int aRow, string aColName, object aPreviousValue, bool aIsProtecedFocus)
        {
            if (aGrd == null || aRow < 0 || aColName == "") return;

            // 이전 값으로 세팅한다
            // 값을 세팅하면 Row의 상태가 변화가 되므로, 해당 Row의 상태가 UnChanged인 경우는 변경후에 다시 UnChanged로 바꾸어 준다
            // 단, Added인 경우는 Detached 상태였으면, Detached로 바꾸어 줘야 하나, A___Grid는 InsertRow시 이미 Added상태이므로, 처리불가함
            DataRowState previousRowState = aGrd.GetRowState(aRow);

            if (previousRowState != DataRowState.Deleted) aGrd.SetItemValue(aRow, aColName, aPreviousValue); // 이전 데이타로 복귀

            // 이전 Row상태가 UnChanged인 경우 UnChanged로 Undo시킴
            if (previousRowState == DataRowState.Unchanged) aGrd.LayoutTable.Rows[aRow].AcceptChanges();

            //if (aIsProtecedFocus) // 포커스이동막을지여부
            //{
            //    OrderVariables.Objects objects = new OCS.OrderVariables.Objects(aGrd, aRow, aColName);
            //    PostCallHelper.PostCall(new PostMethodObject(PostSetFocusToItem), ((object)objects)); // 현재 Column으로 Focus이동처리
            //}
        }

        private void AfterSave(object obj)
        {
            XEditGrid grd = this.grdPatientList;
            ArrayList arr = (ArrayList)obj;
            int aCurrRow = int.Parse(arr[0].ToString());
            string aCurrColName = arr[1].ToString();

            if (aCurrColName == "jubsu_gubun"
                && grd.GetItemString(aCurrRow, aCurrColName) != ""
                //&& grd.GetRowState(aCurrRow) != DataRowState.Unchanged
                )
            {
                //grd.UnSelectAll();
                //grd.SelectRow(aCurrRow);
                //grd.SetFocusToItem(aCurrRow, aCurrColName);
                this.btnList.PerformClick(FunctionType.Update);
            }
        }

        private bool IsDuplicationJubsu(ArrayList arr)
        {
            //0.pkout1001
            //1.gwa
            //2.doctor
            //3.jubsu_gubun
            //4.user_id
            //5.bunho
            //6.naewon_date

//            XEditGrid grd = this.grdPatientList;
//            string cmd = "";
//            cmd = @"SELECT FN_PHY_DUP_JUBSU_GUBUN(   '" + arr[3].ToString() + @"'
//                                                       , '" + arr[5].ToString() + @"'
//                                                       , '" + arr[1].ToString() + @"'
//                                                       , '" + arr[6].ToString() + @"'
//                                                       , '" + EnvironInfo.HospCode + "' ) FROM SYS.DUAL";

//            object result = Service.ExecuteScalar(cmd);

//            if (result.ToString() == "T")
//                return true;
//            else
//                return false;

            // updated by Cloud
            PHY2001U04FnPhyDupJubsuGubunArgs args   = new PHY2001U04FnPhyDupJubsuGubunArgs();
            args.JubsuGubun                         = arr[3].ToString();
            args.Bunho                              = arr[5].ToString();
            args.Gwa                                = arr[1].ToString();
            args.NaewonDate                         = arr[6].ToString();
            PHY2001U04StringResult res = CloudService.Instance.Submit<PHY2001U04StringResult, PHY2001U04FnPhyDupJubsuGubunArgs>(args);

            return res.ResStr == "T";

 //           for (int i = 0; i < grd.RowCount; i++)
 //           {
 //               //if (grd.GetItemString(i, "bunho") == arr[5].ToString()
 //               //    && grd.GetItemString(i, "jubsu_gubun") == arr[3].ToString()
 //               //    && grd.GetItemString(i, "naewon_date") == arr[6].ToString()
 //               //    && grd.GetItemString(i, "gwa") == arr[1].ToString()
 //               //    && grd.GetItemString(i, "pkout1001") != arr[0].ToString())


 //// I_JUBSU_GUBUN IN VARCHAR2
 ////,I_BUNHO       IN VARCHAR2
 ////,I_GWA         IN VARCHAR2
 ////,I_NAEWON_DATE IN VARCHAR2
 ////,I_HOSP_CODE   IN VARCHAR2

                
 //                   return true;
 //           }
            
        }

        private bool IsEnableChangedJubsuGubun()
        {
            int currRow = -1;
            currRow = this.grdPatientList.CurrentRowNumber;

            if (this.grdPatientList.GetItemString(currRow, "order_end_yn") == "Y")
            {
                XMessageBox.Show(Resources.XMessageBox47, Resources.XMessageBox_Caption11, MessageBoxIcon.Warning);
                return false;               
            }
            if (this.grdPatientList.GetItemString(currRow, "sunab_yn") == "Y")
            {
                XMessageBox.Show(Resources.XMessageBox48, Resources.XMessageBox_Caption11, MessageBoxIcon.Warning);
                return false;               
            }
            return true;
        }

        private void CreateAutoJubsu(string aCreate_Jubsu_gubun, string aCreate_Sinryouryou_gubun)
        {
            // Skip header row
            if (this.grdPatientList.CurrentRowNumber == -1) return;

            //
            ArrayList inputList_sin = new ArrayList();
            ArrayList outputList_sin = new ArrayList();
            //
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            //
            int currRow = this.grdPatientList.CurrentRowNumber;
            inputList.Add(this.grdPatientList.GetItemString(currRow, "pkout1001"));   //0
            inputList.Add(this.grdPatientList.GetItemString(currRow, "gwa"));         //1
            inputList.Add(this.grdPatientList.GetItemString(currRow, "doctor"));      //2
            inputList.Add(aCreate_Jubsu_gubun);                                       //3
            inputList.Add(UserInfo.UserID);                                           //4
            inputList.Add(this.grdPatientList.GetItemString(currRow, "bunho"));       //5
            inputList.Add(this.grdPatientList.GetItemString(currRow, "naewon_date")); //6

            if (this.IsDuplicationJubsu(inputList))
            {
                if (XMessageBox.Show(Resources.XMessageBox38, Resources.XMessageBox_Caption23, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            #region deleted by Cloud
            //try
            //{
            //    Service.BeginTransaction();

            //    if (!Service.ExecuteProcedure("PR_OUT_MAKE_AUTO_JUBSU", inputList, outputList))
            //    {
            //        XMessageBox.Show("受付データの生成に失敗しました。\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
            //        Service.RollbackTransaction();
            //        return;
            //    }

            //    if (outputList != null)
            //    {
            //        if (outputList[1] != null)
            //        {
            //            if (outputList[1].ToString() != "0")
            //            {
            //                XMessageBox.Show("受付データの生成に失敗しました。\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
            //                Service.RollbackTransaction();
            //                return;
            //            }
            //            else  // 受付情報生成に成功したら診療料発生。
            //            {
            //                /*
            //                    I_ORDER_DATE           IN VARCHAR2
            //                    I_BUNHO                IN VARCHAR2
            //                    I_FKOUT1001            IN VARCHAR2
            //                    I_DOCTOR               IN VARCHAR2
            //                    I_SINRYOURYOU_GUBUN    IN VARCHAR2
            //                    I_INPUT_ID             IN VARCHAR2
            //                    I_HOSP_CODE            IN VARCHAR2
            //                    I_INPUT_TAB            IN VARCHAR2
            //                    I_IUD_GUBUN            IN VARCHAR2
            //                    O_RESULT               OUT VARCHAR2
            //                    O_RESULT_MSG           OUT VARCHAR2

            //                 */
            //                if (this.cbxSinryouryou.Checked == true)
            //                {
            //                    string procedure_name = "PR_REH_ADD_REHASINRYOURYOU";
            //                    int currRow_sin = this.grdPatientList.CurrentRowNumber;
            //                    inputList_sin.Add(this.grdPatientList.GetItemString(currRow_sin, "naewon_date"));               //1
            //                    inputList_sin.Add(this.grdPatientList.GetItemString(currRow_sin, "bunho"));                     //2
            //                    inputList_sin.Add(this.grdPatientList.GetItemString(currRow_sin, "pkout1001"));                 //3
            //                    inputList_sin.Add(this.grdPatientList.GetItemString(currRow_sin, "doctor"));                    //4
            //                    inputList_sin.Add(aCreate_Sinryouryou_gubun);                                                   //5
            //                    inputList_sin.Add(UserInfo.UserID);                                                             //6
            //                    inputList_sin.Add(EnvironInfo.HospCode);                                                        //7
            //                    inputList_sin.Add("11");                                                                        //8 REHA 10
            //                    inputList_sin.Add("I");                                                                         //9

            //                    Service.ExecuteProcedure(procedure_name, inputList_sin, outputList_sin);

            //                    if (outputList_sin[0].ToString() != "1")
            //                    {
            //                        XMessageBox.Show(outputList_sin[0].ToString() + "\r\n" + outputList_sin[1].ToString() + "\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
            //                        Service.RollbackTransaction();
            //                        return;
            //                    }
            //                    else
            //                        Service.CommitTransaction();
            //                }
            //                else
            //                    Service.CommitTransaction();
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    Service.RollbackTransaction();
            //}
            #endregion

            #region updated by Cloud

            PHY2001U04CreateAutoJubsuArgs args = new PHY2001U04CreateAutoJubsuArgs();
            args.Bunho = this.grdPatientList.GetItemString(currRow, "bunho");
            args.CbxSinryouryou = cbxSinryouryou.Checked;
            args.Doctor = this.grdPatientList.GetItemString(currRow, "doctor");
            args.Fkout1001 = this.grdPatientList.GetItemString(currRow, "pkout1001");
            args.Gwa = this.grdPatientList.GetItemString(currRow, "gwa");
            args.InputId = UserInfo.UserID;
            args.InputTab = "11";
            args.IudGubun = "I";
            args.JubsuGubun = aCreate_Jubsu_gubun;
            args.NaewonDate = this.grdPatientList.GetItemString(currRow, "naewon_date");
            args.OrderDate = this.grdPatientList.GetItemString(currRow, "naewon_date");
            args.Pkout1001 = this.grdPatientList.GetItemString(currRow, "pkout1001");
            args.SinryouryouGubun = aCreate_Sinryouryou_gubun;
            args.UserId = UserInfo.UserID;
            PHY2001U04CreateAutoJubsuResult res = CloudService.Instance.Submit<PHY2001U04CreateAutoJubsuResult, PHY2001U04CreateAutoJubsuArgs>(args);

            if (res.ExecutionStatus != ExecutionStatus.Success || res.OutputList1 != "0")
            {
                XMessageBox.Show("受付データの生成に失敗しました。\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
                return;
            }

            if (res.OutputSin0 != "1")
            {
                XMessageBox.Show(res.OutputSin0 + "\r\n" + res.OutputSin1 + "\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
                return;
            }

            #endregion

            QueryData();
            this.SaveAfterSetFocus(/*outputList[0].ToString()*/res.OutputList0); //Query後変更したＲＯＷにＦＯＣＵＳ設定
        }

        private void RefreshCounter()
        {
            #region deleted by Cloud
//            BindVarCollection bindvar = new BindVarCollection();
//            bindvar.Add("f_hosp_code", EnvironInfo.HospCode);
//            bindvar.Add("f_naewon_date", dtpNaewonDate.GetDataValue());
//            bindvar.Add("f_gwa", this.cboGwa.GetDataValue());

//            string cmdText = string.Empty;
//            DataTable resTable = null;

//            cmdText = @"SELECT A.CNT G1, B.CNT G2, C.CNT SA, D.CNT RE
//                          FROM (SELECT count(*) CNT
//                                  FROM OUT1001 A
//                                 WHERE A.HOSP_CODE   = :f_hosp_code
//                                   AND A.GWA         = :f_gwa
//                                   AND A.JUBSU_GUBUN = '20'
//                                   AND A.NAEWON_DATE = :f_naewon_date) A,
//                               (SELECT count(*) CNT
//                                  FROM OUT1001 A
//                                 WHERE A.HOSP_CODE   = :f_hosp_code
//                                   AND A.GWA         = :f_gwa
//                                   AND A.JUBSU_GUBUN = '21'
//                                   AND A.NAEWON_DATE = :f_naewon_date) B,
//                               (SELECT count(*) CNT
//                                  FROM OUT1001 A
//                                 WHERE A.HOSP_CODE   = :f_hosp_code
//                                   AND A.GWA         = :f_gwa
//                                   AND A.JUBSU_GUBUN = '22'
//                                   AND A.NAEWON_DATE = :f_naewon_date) C,
//                               (SELECT count(*) CNT
//                                  FROM OUT1001 A
//                                 WHERE A.HOSP_CODE   = :f_hosp_code
//                                   AND A.GWA         = :f_gwa
//                                   AND A.JUBSU_GUBUN = '10'
//                                   AND A.NAEWON_DATE = :f_naewon_date) D";

//            resTable = Service.ExecuteDataTable(cmdText, bindvar);

//            if (resTable.Rows.Count > 0)
//            {
//                this.txtCnt_gaisin1.Text = resTable.Rows[0]["G1"].ToString();
//                this.txtCnt_gaisin2.Text = resTable.Rows[0]["G2"].ToString();
//                this.txtCnt_saisin.Text  = resTable.Rows[0]["SA"].ToString();
//                this.txtCnt_reha.Text    = resTable.Rows[0]["RE"].ToString();
//            }
//            else
//            {
//                XMessageBox.Show(Service.ErrFullMsg);
//                throw new Exception();
//            }
            #endregion

            // updated by Cloud
            PHY2001U04RefreshCounterArgs args = new PHY2001U04RefreshCounterArgs();
            args.Gwa = this.cboGwa.GetDataValue();
            args.NaewonDate = dtpNaewonDate.GetDataValue();
            PHY2001U04RefreshCounterResult res = CloudService.Instance.Submit<PHY2001U04RefreshCounterResult, PHY2001U04RefreshCounterArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.RefCounterItem.Count > 0)
            {
                this.txtCnt_gaisin1.Text = res.RefCounterItem[0].G1;
                this.txtCnt_gaisin2.Text = res.RefCounterItem[0].G2;
                this.txtCnt_saisin.Text = res.RefCounterItem[0].Sa;
                this.txtCnt_reha.Text = res.RefCounterItem[0].Re;
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                throw new Exception();
            }
        }

        private bool ChkVitalValue()
        {
            bool result = true;
            string msg = "";
            if (this.grdPatientList.CurrentRowNumber < 0)
            {
                msg = Resources.XMessageBox49;
                result = false;
            }

            if (result)
            {
                //空きがあるのかチェック
                if (this.txtBR_FROM.Text == ""
                    || this.txtBR_TO.Text == ""
                    || this.txtBR_TO.Text == "0"
                    || this.txtBR_FROM.Text == "0")
                {
                    msg = Resources.XMessageBox50;
                    result = false;
                }
            }


            if (result)
            {
                //Ｈ／Ｌの順番があってるのかチェック
                if (int.Parse(this.txtBR_TO.Text) < int.Parse(this.txtBR_FROM.Text))
                {
                    msg = Resources.XMessageBox51;
                    result = false;
                }
            }

            if (!result)
                XMessageBox.Show(msg, Resources.XMessageBox_Caption23);
            
            return result;
            
        }

        private bool InsertVital()
        {
            #region deleted by Cloud
//            //来院日の測定値としてＩＮＳＥＲＴ

//            string cmdText = "";
//            BindVarCollection item = new BindVarCollection();

//            item.Add("q_user_id", UserInfo.UserID);
//            item.Add("f_hosp_code", EnvironInfo.HospCode);
//            item.Add("f_bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));
//            item.Add("f_measure_date", this.dtpNaewonDate.GetDataValue());
//            item.Add("f_measure_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
//            item.Add("f_bp_to", this.txtBR_TO.Text);
//            item.Add("f_bp_from", this.txtBR_FROM.Text);
//            item.Add("f_pulse", this.txtPulse.Text);
//            item.Add("f_bt", this.txtBT.Text);

//            cmdText = @"SELECT NVL(MAX(A.SEQ), 0) + 1
//                          FROM NUR7001 A
//                         WHERE A.HOSP_CODE    = :f_hosp_code
//                           AND A.BUNHO        = :f_bunho
//                           AND A.MEASURE_DATE = TO_DATE(:f_measure_date, 'YYYY/MM/DD')";

//            Object retSeq = Service.ExecuteScalar(cmdText, item);
//            item.Add("f_new_seq",retSeq.ToString());

//            cmdText = @"INSERT INTO NUR7001 (SYS_DATE       , SYS_ID      ,  UPD_ID,      HOSP_CODE, 
//                                             UPD_DATE       , BUNHO       ,
//                                             MEASURE_DATE   , SEQ         ,
//                                             VALD           , HEIGHT      , 
//                                             WEIGHT         , BP_FROM     , 
//                                             BP_TO          , BODY_HEAT   ,
//                                             PULSE          , SPO2        ,
//                                             MEASURE_TIME   , BREATH      )
//                        VALUES              (SYSDATE        , :q_user_id  , :q_user_id,  :f_hosp_code, 
//                                             SYSDATE        , :f_bunho    ,
//                                             TO_DATE(:f_measure_date, 'YYYY/MM/DD') , :f_new_seq  ,
//                                             'Y'            , :f_height   ,
//                                             :f_weight      , :f_bp_from  ,
//                                             :f_bp_to       , :f_bt       ,
//                                             :f_pulse       , :f_spo2     ,
//                                             :f_measure_time, :f_breath   )  ";

//            return Service.ExecuteNonQuery(cmdText, item);
            #endregion

            // updated by Cloud
            PHY2001U04InsertVitalArgs args = new PHY2001U04InsertVitalArgs();
            args.BpFrom = this.txtBR_FROM.Text;
            args.BpTo = this.txtBR_TO.Text;
            args.Bt = this.txtBT.Text;
            args.Bunho = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho");
            args.MeasureDate = this.dtpNaewonDate.GetDataValue();
            args.MeasureTime = "";
            args.Pulse = this.txtPulse.Text;
            args.UserId = UserInfo.UserID;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, PHY2001U04InsertVitalArgs>(args);

            return (res.ExecutionStatus == ExecutionStatus.Success && res.Result);
        }

        private void GetNewOrderFormOUT()
        {
            string time = this.cboNewTime.GetDataValue();

            int nTotalSec = (int.Parse(time) + 10000) / 1000;
            int nTotalMin = nTotalSec / 60;
            int nHour     = nTotalMin / 60;
            int nMin      = nTotalMin % 60;
            int nSec      = nTotalSec % 60;

            #region deleted by Cloud
//            string cmd = @" SELECT COUNT(A.SYS_DATE)
//                              FROM OCS1003 A
//                                 , PHY8002 C
//                             WHERE A.HOSP_CODE    = :f_hosp_code
//                               AND A.ORDER_DATE   = :f_order_date
//                               AND A.INPUT_TAB    = '10'             -- Rehabilitation
//                               AND A.JUNDAL_TABLE = 'HOM'            --
//                               AND A.JUNDAL_PART  = 'HOM'            --
//                               AND A.OCS_FLAG     = '1'              -- No Acting
//                               AND A.SYS_DATE + TO_DSINTERVAL('000 '||:f_time_hour||':'||:f_time_min||':'||:f_time_sec) > SYSDATE
//                               --
//                               AND C.HOSP_CODE = A.HOSP_CODE
//                               AND C.FK_OCS    = A.PKOCS1003
//                             ORDER BY A.ORDER_DATE DESC";

//            BindVarCollection bind = new BindVarCollection();

//            bind.Add("f_hosp_code", EnvironInfo.HospCode);
//            bind.Add("f_order_date", this.dtpNaewonDate.GetDataValue());
//            bind.Add("f_time_hour", nHour.ToString().PadLeft(2, '0'));
//            bind.Add("f_time_min", nMin.ToString().PadLeft(2, '0'));
//            bind.Add("f_time_sec", nSec.ToString().PadLeft(2, '0'));

//            object obj = Service.ExecuteScalar(cmd, bind);

//            if (obj.ToString() != "0")
//            {
//                if (noFormOUT.IsHandleCreated == false)
//                    noFormOUT.ShowDialog(this);
//            }
            #endregion

            // updated by Cloud
            PHY2001U04GetNewOrderFormOUTArgs args = new PHY2001U04GetNewOrderFormOUTArgs();
            args.OrderDate = this.dtpNaewonDate.GetDataValue();
            args.TimeHour = nHour.ToString().PadLeft(2, '0');
            args.TimeMin = nMin.ToString().PadLeft(2, '0');
            args.TimeSec = nSec.ToString().PadLeft(2, '0');
            PHY2001U04StringResult res = CloudService.Instance.Submit<PHY2001U04StringResult, PHY2001U04GetNewOrderFormOUTArgs>(args);

            if (res.ResStr != "0")
            {
                if (noFormOUT.IsHandleCreated == false)
                    noFormOUT.ShowDialog(this);
            }
        }

        private void GetNewOrderFormINP()
        {
            string time = this.cboNewTime.GetDataValue();

            int nTotalSec = (int.Parse(time) + 10000) / 1000;
            int nTotalMin = nTotalSec / 60;
            int nHour = nTotalMin / 60;
            int nMin = nTotalMin % 60;
            int nSec = nTotalSec % 60;

            #region deleted by Cloud
//            string cmd = @" SELECT COUNT(A.SYS_DATE)
//                              FROM OCS2003 A
//                                 , PHY8002 C
//                             WHERE A.HOSP_CODE    = :f_hosp_code
//                               AND A.ORDER_DATE   = :f_order_date
//                               AND A.INPUT_TAB    = '10'             -- Rehabilitation
//                               AND A.JUNDAL_TABLE = 'HOM'            --
//                               AND A.JUNDAL_PART  = 'HOM'            --
//                               AND A.OCS_FLAG     = '1'              -- No Acting
//                               AND A.SYS_DATE + TO_DSINTERVAL('000 '||:f_time_hour||':'||:f_time_min||':'||:f_time_sec) > SYSDATE
//                               --
//                               AND C.HOSP_CODE = A.HOSP_CODE
//                               AND C.FK_OCS    = A.PKOCS2003
//                             ORDER BY A.ORDER_DATE DESC";
//            BindVarCollection bind = new BindVarCollection();
//            bind.Add("f_hosp_code", EnvironInfo.HospCode);
//            bind.Add("f_order_date", this.dtpNaewonDate.GetDataValue());
//            bind.Add("f_time_hour", nHour.ToString().PadLeft(2, '0'));
//            bind.Add("f_time_min", nMin.ToString().PadLeft(2, '0'));
//            bind.Add("f_time_sec", nSec.ToString().PadLeft(2, '0'));

//            object obj = Service.ExecuteScalar(cmd, bind);

//            if (obj.ToString() != "0")
//            {
//                if (noFormINP.IsHandleCreated == false)
//                    noFormINP.ShowDialog(this);
//            }
            #endregion

            // updated by Cloud
            PHY2001U04GetNewOrderFormINPArgs args = new PHY2001U04GetNewOrderFormINPArgs();
            args.OrderDate = this.dtpNaewonDate.GetDataValue();
            args.TimeHour = nHour.ToString().PadLeft(2, '0');
            args.TimeMin = nMin.ToString().PadLeft(2, '0');
            args.TimeSec = nSec.ToString().PadLeft(2, '0');
            PHY2001U04StringResult res = CloudService.Instance.Submit<PHY2001U04StringResult, PHY2001U04GetNewOrderFormINPArgs>(args);

            if (res.ResStr != "0")
            {
                if (noFormINP.IsHandleCreated == false)
                    noFormINP.ShowDialog(this);
            }
        }

        #endregion

        // deleted by Cloud
        #region XSavePerformer
//        private class XSavePerformer : ISavePerformer
//        {
//            PHY2001U04 parent;

//            public XSavePerformer(PHY2001U04 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = @"";

//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                switch (item.RowState)
//                {
//                    case DataRowState.Modified:

//                        ArrayList inputList = new ArrayList();

//                        inputList.Add(item.BindVarList["f_pkout1001"].VarValue);   //0
//                        inputList.Add(item.BindVarList["f_gwa"].VarValue);         //1
//                        inputList.Add(item.BindVarList["f_doctor"].VarValue);      //2
//                        inputList.Add(item.BindVarList["f_jubsu_gubun"].VarValue); //3
//                        inputList.Add(UserInfo.UserID);                            //4
//                        inputList.Add(item.BindVarList["f_bunho"].VarValue);       //5
//                        inputList.Add(item.BindVarList["f_naewon_date"].VarValue); //6

//                        if (parent.IsDuplicationJubsu(inputList))
//                        {
//                            if (XMessageBox.Show("既に同じ受付区分が登録されています。このまま受付登録しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
//                                return true;
//                        }

//                        cmdText = @"UPDATE OUT1001
//                                       SET UPD_ID      = :q_user_id
//                                         , UPD_DATE    = SYSDATE
//                                         , NAEWON_YN   = :f_naewon_yn
//                                         , ARRIVE_TIME = :f_arrive_time
//                                         , JUBSU_GUBUN = :f_jubsu_gubun
//                                         
//                                     WHERE HOSP_CODE   = :f_hosp_code
//                                       AND PKOUT1001   = :f_pkout1001";
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion 

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            // cboJubsuGubun
            cboJubsuGubun.ExecuteQuery = GetCboJubsuGubun;
            cboJubsuGubun.SetDictDDLB();
            // cboGwa
            cboGwa.ParamList = new List<string>(new string[] { "f_buseo_ymd" });
            cboGwa.ExecuteQuery = GetCboGwa;
            cboGwa.SetDictDDLB();
            // cboNewTime
            cboNewTime.ExecuteQuery = GetCboTime;
            cboNewTime.SetDictDDLB();
            // cboTime
            cboTime.ExecuteQuery = GetCboTime;
            cboTime.SetDictDDLB();
            // Combo in grd
            DataTable jubsuTbl = Utility.ConvertToDataTable(GetGrdCboJubsuGubun());
            grdPatientList.SetComboItems("jubsu_gubun", jubsuTbl, "code_name", "code");
            grdExcel.SetComboItems("jubsu_gubun", jubsuTbl, "code_name", "code");
            grdOUT1001.SetComboItems("jubsu_gubun", Utility.ConvertToDataTable(GetGrdCboJubsuGubunForGrdOUT1001()), "code_name", "code");

            // grdExcel
            grdExcel.ParamList = new List<string>(new string[]
                {
                    "f_naewon_date",
                    "f_gwa",
                    "f_doctor",
                    "f_bunho",
                    "f_jubsu_gubun",
                    "f_jinryo_yn",
                    "f_naewon_yn",
                });
            grdExcel.ExecuteQuery = GetGrdExcel;

            // grdINP
            grdINP.ParamList = new List<string>(new string[]
                {
                    "f_order_date",
                });
            grdINP.ExecuteQuery = GetGrdInp;

            // grdList
            grdList.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_stat_flg",
                    "f_naewon_date",
                    "f_gwa",
                    "f_doctor",
                    "f_gubun",
                });
            grdList.ExecuteQuery = GetGrdList;

            // grdOUT
            grdOUT.ParamList = new List<string>(new string[]
                {
                    "f_order_date",
                });
            grdOUT.ExecuteQuery = GetGrdOut;

            // grdOUT1001
            grdOUT1001.ParamList = new List<string>(new string[]
                {
                    "f_gwa",
                    "f_bunho",
                    "f_naewon_date",
                });
            grdOUT1001.ExecuteQuery = GetGrdOUT1001;

            // grdPaCnt
            grdPaCnt.ParamList = new List<string>(new string[]
                {
                    "f_naewon_date",
                });
            grdPaCnt.ExecuteQuery = GetGrdPaCnt;
        }
        #endregion

        #region GetCboJubsuGubun
        /// <summary>
        /// GetCboJubsuGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboJubsuGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04CboJubsuGubunResult res = CacheService.Instance.Get<PHY2001U04CboJubsuGubunArgs, PHY2001U04CboJubsuGubunResult>(new PHY2001U04CboJubsuGubunArgs(),
                delegate(PHY2001U04CboJubsuGubunResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.CboJubsuGubun.Count > 0;
                });

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.CboJubsuGubun.ForEach(delegate(PHY2001U04CboJubsuGubunInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                        item.SortKey,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdExcel
        /// <summary>
        /// GetGrdExcel
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdExcel(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04GrdExcelArgs args = new PHY2001U04GrdExcelArgs();
            args.Bunho                  = bvc["f_bunho"].VarValue;
            args.Doctor                 = bvc["f_doctor"].VarValue;
            args.Gwa                    = bvc["f_gwa"].VarValue;
            args.JinryoYn               = bvc["f_jinryo_yn"].VarValue;
            args.JubsuGubun             = bvc["f_jubsu_gubun"].VarValue;
            args.NaewonDate             = bvc["f_naewon_date"].VarValue;
            args.NaewonYn               = bvc["f_naewon_yn"].VarValue;
            PHY2001U04GrdExcelResult res = CloudService.Instance.Submit<PHY2001U04GrdExcelResult, PHY2001U04GrdExcelArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdExcelItem.ForEach(delegate(PHY2001U04GrdExcelInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.GwaName,
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.DoctorName,
                        item.Birth,
                        item.AgeSex,
                        item.JubsuTime,
                        item.OrderEndYn,
                        item.HoldYn,
                        item.SunabYn,
                        item.NaewonYn,
                        item.JubsuGubun,
                        item.ArriveTime,
                        item.LastNaewonDate,
                        item.Gaein,
                        item.BpTo,
                        item.BpFrom,
                        item.Pulse,
                        item.BodyHeat,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdInp
        /// <summary>
        /// GetGrdInp
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdInp(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04GrdInpArgs args = new PHY2001U04GrdInpArgs();
            args.OrderDate = bvc["f_order_date"].VarValue;
            PHY2001U04GrdInpResult res = CloudService.Instance.Submit<PHY2001U04GrdInpResult, PHY2001U04GrdInpArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdInpItem.ForEach(delegate(PHY2001U04GrdInpInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.OrderDate,
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.DoctorName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.PtFlag,
                        item.OtFlag,
                        item.StFlag,
                        item.BuFlag,
                        item.OcsFlag,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdList
        /// <summary>
        /// GetGrdList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04GrdListArgs args  = new PHY2001U04GrdListArgs();
            args.Bunho                  = bvc["f_bunho"].VarValue;
            args.Doctor                 = bvc["f_doctor"].VarValue;
            args.Gubun                  = bvc["f_gubun"].VarValue;
            args.Gwa                    = bvc["f_gwa"].VarValue;
            args.NaewonDate             = bvc["f_naewon_date"].VarValue;
            args.StatFlg                = bvc["f_stat_flg"].VarValue;
            PHY2001U04GrdListResult res = CloudService.Instance.Submit<PHY2001U04GrdListResult, PHY2001U04GrdListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdListItem.ForEach(delegate(PHY2001U04GrdListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.KizyunDate,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.JundalPart,
                        item.JundalPartName,
                        item.ReserTime,
                        item.ReserYn,
                        item.ActYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdOut
        /// <summary>
        /// GetGrdOut
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOut(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04GrdOutArgs args = new PHY2001U04GrdOutArgs();
            args.OrderDate = bvc["f_order_date"].VarValue;
            PHY2001U04GrdOutResult res = CloudService.Instance.Submit<PHY2001U04GrdOutResult, PHY2001U04GrdOutArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdOutItem.ForEach(delegate(PHY2001U04GrdOutInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.OrderDate,
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.DoctorName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.PtFlag,
                        item.OtFlag,
                        item.StFlag,
                        item.BuFlag,
                        item.OcsFlag,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdOUT1001
        /// <summary>
        /// GetGrdOUT1001
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOUT1001(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04GrdOut1001Args args   = new PHY2001U04GrdOut1001Args();
            args.Bunho                      = bvc["f_bunho"].VarValue;
            args.Gwa                        = bvc["f_gwa"].VarValue;
            args.NaewonDate                 = bvc["f_naewon_date"].VarValue;
            PHY2001U04GrdOut1001Result res = CloudService.Instance.Submit<PHY2001U04GrdOut1001Result, PHY2001U04GrdOut1001Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdOut1001Item.ForEach(delegate(PHY2001U04GrdOut1001Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.NaewonDate,
                        item.JubsuGubun,
                        item.Next,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdPaCnt
        /// <summary>
        /// GetGrdPaCnt
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPaCnt(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04GrdPaCntArgs args = new PHY2001U04GrdPaCntArgs();
            args.NaewonDate = bvc["f_naewon_date"].VarValue;
            PHY2001U04GrdPaCntResult res = CloudService.Instance.Submit<PHY2001U04GrdPaCntResult, PHY2001U04GrdPaCntArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdPaCntItem.ForEach(delegate(PHY2001U04GrdPaCntInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Gwa,
                        item.GwaName,
                        item.DoctorName,
                        item.PaCnt,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetCboGwa
        /// <summary>
        /// GetCboGwa
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboGwa(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04CboGwaArgs args = new PHY2001U04CboGwaArgs();
            args.BuseoYmd = bvc["f_buseo_ymd"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, PHY2001U04CboGwaArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Code, item.CodeName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetCboTime
        /// <summary>
        /// GetCboTime
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboTime(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ComboResult res = CacheService.Instance.Get<ComboNUR0102CboTimeArgs, ComboResult>(new ComboNUR0102CboTimeArgs(), delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
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

        #region GetGrdCboJubsuGubun
        /// <summary>
        /// GetGrdCboJubsuGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private List<ComboListItemInfo> GetGrdCboJubsuGubun()
        {
            List<ComboListItemInfo> lstItem = new List<ComboListItemInfo>();

            ComboResult res = CacheService.Instance.Get<PHY2001U04GrdCboJubsuGubunArgs, ComboResult>(new PHY2001U04GrdCboJubsuGubunArgs(), delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
                });

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                lstItem = res.ComboItem;
            }

            return lstItem;
        }
        #endregion

        #region GetGrdCboJubsuGubunForGrdOUT1001
        /// <summary>
        /// GetGrdCboJubsuGubunForGrdOUT1001
        /// </summary>
        /// <returns></returns>
        private List<ComboListItemInfo> GetGrdCboJubsuGubunForGrdOUT1001()
        {
            List<ComboListItemInfo> lstItem = new List<ComboListItemInfo>();

            ComboResult res = CacheService.Instance.Get<ComboJubsuGubunArgs, ComboResult>(new ComboJubsuGubunArgs(), delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
                });

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                lstItem = res.ComboItem;
            }

            return lstItem;
        }
        #endregion

        #region GetGrdPatientList
        /// <summary>
        /// GetGrdPatientList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPatientList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04GrdPatientListArgs args       = new PHY2001U04GrdPatientListArgs();
            args.Bunho                              = bvc["f_bunho"].VarValue;
            args.Doctor                             = bvc["f_doctor"].VarValue;
            args.Gwa                                = bvc["f_gwa"].VarValue;
            args.JinryoYn                           = bvc["f_jinryo_yn"].VarValue;
            args.JubsuGubun                         = bvc["f_jubsu_gubun"].VarValue;
            args.NaewonDate                         = bvc["f_naewon_date"].VarValue;
            args.NaewonYn                           = bvc["f_naewon_yn"].VarValue;
            args.SysId                              = bvc["f_sys_id"].VarValue;
            PHY2001U04GrdPatientListResult res = CloudService.Instance.Submit<PHY2001U04GrdPatientListResult, PHY2001U04GrdPatientListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdPatientItem.ForEach(delegate(PHY2001U04GrdPatientListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Gwa,
                        item.GwaName,
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.NaewonDate,
                        item.Doctor,
                        item.DoctorName,
                        item.NaewonType,
                        item.JubsuNo,
                        item.Birth,
                        item.AgeSex,
                        item.OutResKey,
                        item.JubsuTime,
                        item.OrderEndYn,
                        item.HoldYn,
                        item.ResultYn,
                        item.ReserYn,
                        item.IpwonYn,
                        item.SunabYn,
                        item.NaewonYn,
                        item.JubsuGubun,
                        item.JubsuGubunName,
                        item.Remark,
                        item.ArriveTime,
                        item.Gubun,
                        item.LastNaewonDate,
                        item.OcsComment,
                        item.Chojae,
                        item.GroupKey,
                        item.BunhoType,
                        item.KaigoYn,
                        item.Gaein,
                        item.BpTo,
                        item.BpFrom,
                        item.Pulse,
                        item.BodyHeat,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayNUR7001
        /// <summary>
        /// GetLayNUR7001
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayNUR7001(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04LayNUR7001Args args = new PHY2001U04LayNUR7001Args();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.MeasureDate = bvc["f_measure_date"].VarValue;
            PHY2001U04LayNUR7001Result res = CloudService.Instance.Submit<PHY2001U04LayNUR7001Result, PHY2001U04LayNUR7001Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayNurItem.ForEach(delegate(PHY2001U04LayNUR7001Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.BpFrom,
                        item.BpTo,
                        item.Pulse,
                        item.BodyHeat,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region SavePatientGrid
        /// <summary>
        /// SavePatientGrid
        /// </summary>
        /// <returns></returns>
        private bool SavePatientGrid()
        {
            List<PHY2001U04SaveLayoutInfo> lstData = new List<PHY2001U04SaveLayoutInfo>();

            for (int i = 0; i < grdPatientList.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdPatientList.GetRowState(i) != DataRowState.Modified) continue;

                PHY2001U04SaveLayoutInfo item   = new PHY2001U04SaveLayoutInfo();
                item.ArriveTime                 = grdPatientList.GetItemString(i, "arrive_time");
                item.JubsuGubun                 = grdPatientList.GetItemString(i, "jubsu_gubun");
                item.NaewonYn                   = grdPatientList.GetItemString(i, "naewon_yn");
                item.Pkout1001                  = grdPatientList.GetItemString(i, "pkout1001");

                lstData.Add(item);
            }

            // No change?
            if (lstData.Count == 0) return true;

            PHY2001U04SaveLayoutArgs args = new PHY2001U04SaveLayoutArgs();
            args.UserId = UserInfo.UserID;
            args.SaveLayoutItem = lstData;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, PHY2001U04SaveLayoutArgs>(args);

            return res.ExecutionStatus == ExecutionStatus.Success && res.Result;
        }
        #endregion

        #endregion
    }
}