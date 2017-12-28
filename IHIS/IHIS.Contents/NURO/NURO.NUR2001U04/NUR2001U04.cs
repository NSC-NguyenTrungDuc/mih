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
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;


using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;


using IHIS.Framework;
using IHIS.NURO.Properties;
using IHIS.CloudConnector.DataAccess;
using IHIS.CloudConnector.DataAccess.Entities;
using IHIS.CloudConnector.Utility;
using System.Data.SqlClient;

#endregion

namespace IHIS.NURO
{
    /// <summary>
    /// NUR2001U04에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class NUR2001U04 : IHIS.Framework.XScreen
    {
        #region 화면변수
        private string Aampm_gubun = string.Empty;
        private string mHospCode = string.Empty;
        #endregion

        #region 자동생성
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlLeft;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XDatePicker dtpNaewonDate;
        private IHIS.Framework.XLabel lblNaewon_date;
        private IHIS.Framework.XLabel lblGwa;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XButton btnDoctorChange;
        private IHIS.Framework.XButton btnBody;
        private IHIS.Framework.XButton btnOrder;
        //		private IHIS.Framework.DataServiceSIMO dsvQuery;
        //		private IHIS.Framework.DataServiceSISO dsvDoctorChange;
        private IHIS.Framework.XLabel lblDoctor;
        private IHIS.Framework.XDisplayBox dbxDoctor_name;
        private IHIS.Framework.XFindBox fbxDoctor;
        private IHIS.Framework.XLabel lblBunho;
        private IHIS.Framework.XDictComboBox cboGwa;
        private IHIS.Framework.XButton btnJusangi;
        private IHIS.Framework.SingleLayout layPKOUT1001;
        private IHIS.Framework.SingleLayoutItem singleLayoutItem1;
        private XToolTip xToolTip1;
        #endregion
        private XButton btnConfirm;
        private XCheckBox cbxAutoQuery;
        private Timer timer1;
        private XButton btnAllergy;
        private XButton btnPrint;
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
        private SingleLayout layDoctorName;
        private SingleLayoutItem singleLayoutItem2;
        private XButton btnReser;
        private XButton btnJinryoEnd;
        private XPanel pnlNurse;
        private XButton btnJubsuOpen;
        private XButton btnOUT0106;
        private XDictComboBox cboJubsuGubun;
        private XPanel pnlPart;
        private XButton btnOrderAct;
        private XLabel lbJubsuGubun;
        private XGrid grdPaCnt;
        private XGridCell xGridCell1;
        private XGridCell xGridCell2;
        private XGridCell xGridCell3;
        private XGroupBox gbxPaCnt;
        private XGridCell xGridCell4;
        private XButton btnBunhoChage;

        private IContainer components;
        private XButton btnIntroduce;
        private XEditGrid grdPatientList;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell31;
        private XPanel pnlOtherClinic;
        private XButton btnUpdateClinicsEmr;
        private XButton btnLinkPatient;
        private XButton btnCancelLinkPatient;
        private XButton btnAction;
        private string[] msgOrca = { "00","17", "K1", "K2", "K3" };
        private XEditGridCell xEditGridCell37;
        private XDatePicker dtpToDate;
        private XLabel xLabel6;
        private const string CACHE_NUR2001U04_COMBO_LIST_ITEM_KEYS = "NURO.Nur2001U04.CboListItem";

        #region 생성자

        public NUR2001U04()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            grdPatientList.ExecuteQuery = GetPatientList;
            layDoctorName.ExecuteQuery = GetDoctorNameList;
            layPKOUT1001.ExecuteQuery = GetForeignKeyList;
            //SetActiveIntroLeterBtn(true, 0);
            if(NetInfo.Language != IHIS.Framework.LangMode.Jr)
            {
                dtpNaewonDate.IsJapanYearType = false;
                dtpToDate.IsJapanYearType = false;

                // Hide the colums
                grdPatientList.AutoSizeColumn(xEditGridCell36.Col, 0);
                grdPatientList.AutoSizeColumn(xEditGridCell3.Col, 0);

                // https://sofiamedix.atlassian.net/browse/MED-15046
                grdPatientList.AutoSizeColumn(xEditGridCell36.Col, 98);
                grdPatientList.AutoSizeColumn(xEditGridCell12.Col, 119);
                grdPatientList.AutoSizeColumn(xEditGridCell1.Col, 121);
                grdPatientList.AutoSizeColumn(xEditGridCell2.Col, 119);
                grdPatientList.AutoSizeColumn(xEditGridCell3.Col, 113);
                grdPatientList.AutoSizeColumn(xEditGridCell7.Col, 144);
                grdPatientList.AutoSizeColumn(xEditGridCell10.Col, 87);
                grdPatientList.AutoSizeColumn(xEditGridCell14.Col, 115);
                grdPatientList.AutoSizeColumn(xEditGridCell15.Col, 108);
                grdPatientList.AutoSizeColumn(xEditGridCell16.Col, 71);
                grdPatientList.AutoSizeColumn(xEditGridCell20.Col, 92);
                grdPatientList.AutoSizeColumn(xEditGridCell21.Col, 51);
                grdPatientList.AutoSizeColumn(xEditGridCell22.Col, 93);
                grdPatientList.AutoSizeColumn(xEditGridCell25.Col, 110);
                grdPatientList.AutoSizeColumn(xEditGridCell27.Col, 143);
                grdPatientList.AutoSizeColumn(xEditGridCell28.Col, 99);
                grdPatientList.AutoSizeColumn(xEditGridCell31.Col, 31);
                grdPatientList.AutoSizeColumn(xEditGridCell20.Col, 92);
            }
        }
        #endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR2001U04));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
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
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.cbxAutoQuery = new IHIS.Framework.XCheckBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdPatientList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.pnlOtherClinic = new IHIS.Framework.XPanel();
            this.btnUpdateClinicsEmr = new IHIS.Framework.XButton();
            this.btnLinkPatient = new IHIS.Framework.XButton();
            this.btnCancelLinkPatient = new IHIS.Framework.XButton();
            this.btnIntroduce = new IHIS.Framework.XButton();
            this.btnBunhoChage = new IHIS.Framework.XButton();
            this.gbxPaCnt = new IHIS.Framework.XGroupBox();
            this.grdPaCnt = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.pnlPart = new IHIS.Framework.XPanel();
            this.btnOrderAct = new IHIS.Framework.XButton();
            this.btnOUT0106 = new IHIS.Framework.XButton();
            this.pnlNurse = new IHIS.Framework.XPanel();
            this.btnJubsuOpen = new IHIS.Framework.XButton();
            this.btnBody = new IHIS.Framework.XButton();
            this.btnJinryoEnd = new IHIS.Framework.XButton();
            this.btnOrder = new IHIS.Framework.XButton();
            this.btnAllergy = new IHIS.Framework.XButton();
            this.btnGamyum = new IHIS.Framework.XButton();
            this.btnReser = new IHIS.Framework.XButton();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnJubsu = new IHIS.Framework.XButton();
            this.btnJusangi = new IHIS.Framework.XButton();
            this.btnDoctorChange = new IHIS.Framework.XButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.btnAction = new IHIS.Framework.XButton();
            this.layPKOUT1001 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xToolTip1 = new IHIS.Framework.XToolTip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.layDoctorName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlNaewon.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.pnlOtherClinic.SuspendLayout();
            this.gbxPaCnt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaCnt)).BeginInit();
            this.pnlPart.SuspendLayout();
            this.pnlNurse.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
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
            this.ImageList.Images.SetKeyName(21, "통계.ico");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.xLabel6);
            this.pnlTop.Controls.Add(this.dtpToDate);
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
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // xLabel6
            // 
            this.xLabel6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel6.EdgeRounding = false;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsJapanYearType = true;
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // lbJubsuGubun
            // 
            this.lbJubsuGubun.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbJubsuGubun.EdgeRounding = false;
            resources.ApplyResources(this.lbJubsuGubun, "lbJubsuGubun");
            this.lbJubsuGubun.Name = "lbJubsuGubun";
            // 
            // cboJubsuGubun
            // 
            this.cboJubsuGubun.ExecuteQuery = null;
            resources.ApplyResources(this.cboJubsuGubun, "cboJubsuGubun");
            this.cboJubsuGubun.Name = "cboJubsuGubun";
            this.cboJubsuGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboJubsuGubun.ParamList")));
            this.cboJubsuGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboJubsuGubun.SelectedIndexChanged += new System.EventHandler(this.cboJubsuGubun_SelectedIndexChanged);
            // 
            // pnlNaewon
            // 
            this.pnlNaewon.Controls.Add(this.rbtNaewonAll);
            this.pnlNaewon.Controls.Add(this.rbtMiNaewon);
            this.pnlNaewon.Controls.Add(this.rbtNaewon);
            resources.ApplyResources(this.pnlNaewon, "pnlNaewon");
            this.pnlNaewon.Name = "pnlNaewon";
            // 
            // rbtNaewonAll
            // 
            resources.ApplyResources(this.rbtNaewonAll, "rbtNaewonAll");
            this.rbtNaewonAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.rbtNaewonAll.FlatAppearance.BorderSize = 3;
            this.rbtNaewonAll.Name = "rbtNaewonAll";
            this.rbtNaewonAll.Tag = "Naewon";
            this.rbtNaewonAll.UseVisualStyleBackColor = false;
            this.rbtNaewonAll.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtMiNaewon
            // 
            resources.ApplyResources(this.rbtMiNaewon, "rbtMiNaewon");
            this.rbtMiNaewon.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.rbtMiNaewon.FlatAppearance.BorderSize = 3;
            this.rbtMiNaewon.Name = "rbtMiNaewon";
            this.rbtMiNaewon.Tag = "Naewon";
            this.rbtMiNaewon.UseVisualStyleBackColor = false;
            this.rbtMiNaewon.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtNaewon
            // 
            resources.ApplyResources(this.rbtNaewon, "rbtNaewon");
            this.rbtNaewon.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightPink);
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
            this.xPanel1.Controls.Add(this.rbtJinryoAll);
            this.xPanel1.Controls.Add(this.rbtJinryoEnd);
            this.xPanel1.Controls.Add(this.rbtJinryoNotEnd);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // rbtJinryoAll
            // 
            resources.ApplyResources(this.rbtJinryoAll, "rbtJinryoAll");
            this.rbtJinryoAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.PowderBlue);
            this.rbtJinryoAll.FlatAppearance.BorderSize = 3;
            this.rbtJinryoAll.Name = "rbtJinryoAll";
            this.rbtJinryoAll.Tag = "Jinryo";
            this.rbtJinryoAll.UseVisualStyleBackColor = false;
            this.rbtJinryoAll.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtJinryoEnd
            // 
            resources.ApplyResources(this.rbtJinryoEnd, "rbtJinryoEnd");
            this.rbtJinryoEnd.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.PowderBlue);
            this.rbtJinryoEnd.FlatAppearance.BorderSize = 3;
            this.rbtJinryoEnd.Name = "rbtJinryoEnd";
            this.rbtJinryoEnd.Tag = "Jinryo";
            this.rbtJinryoEnd.UseVisualStyleBackColor = false;
            this.rbtJinryoEnd.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtJinryoNotEnd
            // 
            resources.ApplyResources(this.rbtJinryoNotEnd, "rbtJinryoNotEnd");
            this.rbtJinryoNotEnd.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightPink);
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
            this.cboGwa.ExecuteQuery = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
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
            this.lblBunho.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBunho.EdgeRounding = false;
            resources.ApplyResources(this.lblBunho, "lblBunho");
            this.lblBunho.Name = "lblBunho";
            // 
            // dbxDoctor_name
            // 
            this.dbxDoctor_name.EdgeRounding = false;
            resources.ApplyResources(this.dbxDoctor_name, "dbxDoctor_name");
            this.dbxDoctor_name.Name = "dbxDoctor_name";
            this.dbxDoctor_name.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // fbxDoctor
            // 
            resources.ApplyResources(this.fbxDoctor, "fbxDoctor");
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            this.fbxDoctor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDoctor_FindClick);
            // 
            // lblDoctor
            // 
            this.lblDoctor.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDoctor.EdgeRounding = false;
            resources.ApplyResources(this.lblDoctor, "lblDoctor");
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.paBox.Validating += new System.ComponentModel.CancelEventHandler(this.paBox_Validating);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // lblGwa
            // 
            this.lblGwa.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblGwa.EdgeRounding = false;
            resources.ApplyResources(this.lblGwa, "lblGwa");
            this.lblGwa.Name = "lblGwa";
            this.lblGwa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // lblNaewon_date
            // 
            this.lblNaewon_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNaewon_date.EdgeRounding = false;
            resources.ApplyResources(this.lblNaewon_date, "lblNaewon_date");
            this.lblNaewon_date.Name = "lblNaewon_date";
            this.lblNaewon_date.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // dtpNaewonDate
            // 
            resources.ApplyResources(this.dtpNaewonDate, "dtpNaewonDate");
            this.dtpNaewonDate.IsJapanYearType = true;
            this.dtpNaewonDate.IsVietnameseYearType = false;
            this.dtpNaewonDate.Name = "dtpNaewonDate";
            this.dtpNaewonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpNaewonDate_DataValidating);
            this.dtpNaewonDate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.cboTime);
            this.pnlBottom.Controls.Add(this.btnConfirm);
            this.pnlBottom.Controls.Add(this.cbxAutoQuery);
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // cboTime
            // 
            this.cboTime.ExecuteQuery = null;
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.Name = "cboTime";
            this.cboTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTime.ParamList")));
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.cboTime.SelectedValueChanged += new System.EventHandler(this.cboTime_SelectedValueChanged);
            // 
            // btnConfirm
            // 
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.ImageIndex = 5;
            this.btnConfirm.ImageList = this.ImageList;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cbxAutoQuery
            // 
            this.cbxAutoQuery.Checked = true;
            this.cbxAutoQuery.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.cbxAutoQuery, "cbxAutoQuery");
            this.cbxAutoQuery.Name = "cbxAutoQuery";
            this.cbxAutoQuery.UseVisualStyleBackColor = false;
            this.cbxAutoQuery.CheckedChanged += new System.EventHandler(this.cbxAutoQuery_CheckedChanged);
            this.cbxAutoQuery.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdPatientList);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
            // 
            // grdPatientList
            // 
            this.grdPatientList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell36,
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
            this.xEditGridCell35,
            this.xEditGridCell31,
            this.xEditGridCell37});
            this.grdPatientList.ColPerLine = 18;
            this.grdPatientList.Cols = 19;
            resources.ApplyResources(this.grdPatientList, "grdPatientList");
            this.grdPatientList.ExecuteQuery = null;
            this.grdPatientList.FixedCols = 1;
            this.grdPatientList.FixedRows = 1;
            this.grdPatientList.HeaderHeights.Add(31);
            this.grdPatientList.Name = "grdPatientList";
            this.grdPatientList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatientList.ParamList")));
            this.grdPatientList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdPatientList.RowHeaderVisible = true;
            this.grdPatientList.Rows = 2;
            this.grdPatientList.ToolTipActive = true;
            this.grdPatientList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPatientList_QueryEnd);
            this.grdPatientList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.grdPatientList.GridSorted += new System.EventHandler(this.grdPatientList_GridSorted);
            this.grdPatientList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPatientList_RowFocusChanged);
            this.grdPatientList.DoubleClick += new System.EventHandler(this.grdPatientList_DoubleClick);
            this.grdPatientList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPatientList_GridCellPainting);
            this.grdPatientList.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdPatientList_ItemValueChanging);
            this.grdPatientList.PreEndInitializing += new System.EventHandler(this.grdPatientList_PreEndInitializing);
            this.grdPatientList.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdPatientList_GridColumnProtectModify);
            this.grdPatientList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPatientList_QueryStarting);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.ApplyPaintingEvent = true;
            this.xEditGridCell36.CellName = "trial_yn";
            this.xEditGridCell36.CellWidth = 33;
            this.xEditGridCell36.Col = 2;
            this.xEditGridCell36.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gwa";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.ApplyPaintingEvent = true;
            this.xEditGridCell12.CellName = "gwa_name";
            this.xEditGridCell12.CellWidth = 70;
            this.xEditGridCell12.Col = 9;
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
            this.xEditGridCell1.CellWidth = 75;
            this.xEditGridCell1.Col = 10;
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
            this.xEditGridCell2.CellWidth = 95;
            this.xEditGridCell2.Col = 11;
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
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 12;
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
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ApplyPaintingEvent = true;
            this.xEditGridCell7.CellName = "doctor_name";
            this.xEditGridCell7.CellWidth = 95;
            this.xEditGridCell7.Col = 14;
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
            this.xEditGridCell10.CellWidth = 95;
            this.xEditGridCell10.Col = 13;
            this.xEditGridCell10.EnableSort = true;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
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
            this.xEditGridCell14.Col = 7;
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
            this.xEditGridCell15.Col = 5;
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
            this.xEditGridCell16.Col = 4;
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
            this.xEditGridCell20.Col = 6;
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
            this.xEditGridCell21.Col = 3;
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
            this.xEditGridCell22.CellWidth = 100;
            this.xEditGridCell22.Col = 15;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.MaxDropDownItems = 20;
            this.xEditGridCell22.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "jubsu_gubun_name";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
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
            this.xEditGridCell25.Col = 8;
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
            this.xEditGridCell27.CellWidth = 95;
            this.xEditGridCell27.Col = 16;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.ApplyPaintingEvent = true;
            this.xEditGridCell28.CellName = "ocs_comment";
            this.xEditGridCell28.CellWidth = 40;
            this.xEditGridCell28.Col = 17;
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
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "group_key";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "bunho_type";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
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
            this.xEditGridCell34.Col = 18;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "kensa_yn";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell31.CellName = "icon";
            this.xEditGridCell31.CellWidth = 25;
            this.xEditGridCell31.Col = 1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.CellLen = 80;
            this.xEditGridCell37.CellName = "sys_id";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlOtherClinic);
            this.pnlFill.Controls.Add(this.btnIntroduce);
            this.pnlFill.Controls.Add(this.btnBunhoChage);
            this.pnlFill.Controls.Add(this.gbxPaCnt);
            this.pnlFill.Controls.Add(this.pnlPart);
            this.pnlFill.Controls.Add(this.btnOUT0106);
            this.pnlFill.Controls.Add(this.pnlNurse);
            this.pnlFill.Controls.Add(this.btnReser);
            this.pnlFill.Controls.Add(this.btnDelete);
            this.pnlFill.Controls.Add(this.btnJubsu);
            this.pnlFill.Controls.Add(this.btnJusangi);
            this.pnlFill.Controls.Add(this.btnDoctorChange);
            this.pnlFill.Controls.Add(this.btnPrint);
            this.pnlFill.Controls.Add(this.btnAction);
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            // 
            // pnlOtherClinic
            // 
            this.pnlOtherClinic.Controls.Add(this.btnUpdateClinicsEmr);
            this.pnlOtherClinic.Controls.Add(this.btnLinkPatient);
            this.pnlOtherClinic.Controls.Add(this.btnCancelLinkPatient);
            resources.ApplyResources(this.pnlOtherClinic, "pnlOtherClinic");
            this.pnlOtherClinic.Name = "pnlOtherClinic";
            // 
            // btnUpdateClinicsEmr
            // 
            resources.ApplyResources(this.btnUpdateClinicsEmr, "btnUpdateClinicsEmr");
            this.btnUpdateClinicsEmr.ImageList = this.ImageList;
            this.btnUpdateClinicsEmr.Name = "btnUpdateClinicsEmr";
            this.btnUpdateClinicsEmr.Click += new System.EventHandler(this.btnUpdateClinicsEmr_Click);
            // 
            // btnLinkPatient
            // 
            resources.ApplyResources(this.btnLinkPatient, "btnLinkPatient");
            this.btnLinkPatient.ImageList = this.ImageList;
            this.btnLinkPatient.Name = "btnLinkPatient";
            this.btnLinkPatient.Click += new System.EventHandler(this.btnLinkPatient_Click);
            // 
            // btnCancelLinkPatient
            // 
            resources.ApplyResources(this.btnCancelLinkPatient, "btnCancelLinkPatient");
            this.btnCancelLinkPatient.ImageList = this.ImageList;
            this.btnCancelLinkPatient.Name = "btnCancelLinkPatient";
            this.btnCancelLinkPatient.Click += new System.EventHandler(this.btnCancelLinkPatient_Click);
            // 
            // btnIntroduce
            // 
            resources.ApplyResources(this.btnIntroduce, "btnIntroduce");
            this.btnIntroduce.ImageIndex = 19;
            this.btnIntroduce.ImageList = this.ImageList;
            this.btnIntroduce.Name = "btnIntroduce";
            this.btnIntroduce.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnIntroduce.Click += new System.EventHandler(this.btnIntroduce_Click);
            // 
            // btnBunhoChage
            // 
            resources.ApplyResources(this.btnBunhoChage, "btnBunhoChage");
            this.btnBunhoChage.ImageIndex = 5;
            this.btnBunhoChage.ImageList = this.ImageList;
            this.btnBunhoChage.Name = "btnBunhoChage";
            this.btnBunhoChage.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnBunhoChage.Click += new System.EventHandler(this.btnBunhoChage_Click);
            // 
            // gbxPaCnt
            // 
            this.gbxPaCnt.Controls.Add(this.grdPaCnt);
            resources.ApplyResources(this.gbxPaCnt, "gbxPaCnt");
            this.gbxPaCnt.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.gbxPaCnt.Name = "gbxPaCnt";
            this.gbxPaCnt.Protect = true;
            this.gbxPaCnt.TabStop = false;
            // 
            // grdPaCnt
            // 
            this.grdPaCnt.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell4,
            this.xGridCell3});
            this.grdPaCnt.ColPerLine = 3;
            this.grdPaCnt.Cols = 3;
            resources.ApplyResources(this.grdPaCnt, "grdPaCnt");
            this.grdPaCnt.ExecuteQuery = null;
            this.grdPaCnt.FixedRows = 1;
            this.grdPaCnt.HeaderHeights.Add(22);
            this.grdPaCnt.Name = "grdPaCnt";
            this.grdPaCnt.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaCnt.ParamList")));
            this.grdPaCnt.QuerySQL = resources.GetString("grdPaCnt.QuerySQL");
            this.grdPaCnt.Rows = 2;
            this.grdPaCnt.ToolTipActive = true;
            this.grdPaCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaCnt_QueryStarting);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "gwa";
            this.xGridCell1.Col = -1;
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9F);
            this.xGridCell2.CellName = "gwa_name";
            this.xGridCell2.CellWidth = 68;
            this.xGridCell2.Col = 1;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 9F);
            // 
            // xGridCell4
            // 
            this.xGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9F);
            this.xGridCell4.CellName = "doctor_name";
            this.xGridCell4.CellWidth = 55;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 9F);
            this.xGridCell4.SuppressRepeating = true;
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "pa_cnt";
            this.xGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xGridCell3.CellWidth = 31;
            this.xGridCell3.Col = 2;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            // 
            // pnlPart
            // 
            this.pnlPart.Controls.Add(this.btnOrderAct);
            resources.ApplyResources(this.pnlPart, "pnlPart");
            this.pnlPart.Name = "pnlPart";
            // 
            // btnOrderAct
            // 
            resources.ApplyResources(this.btnOrderAct, "btnOrderAct");
            this.btnOrderAct.ImageIndex = 5;
            this.btnOrderAct.ImageList = this.ImageList;
            this.btnOrderAct.Name = "btnOrderAct";
            this.btnOrderAct.Click += new System.EventHandler(this.btnOrderAct_Click);
            // 
            // btnOUT0106
            // 
            resources.ApplyResources(this.btnOUT0106, "btnOUT0106");
            this.btnOUT0106.ImageIndex = 19;
            this.btnOUT0106.ImageList = this.ImageList;
            this.btnOUT0106.Name = "btnOUT0106";
            this.btnOUT0106.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnOUT0106.Click += new System.EventHandler(this.btnOUT0106_Click);
            // 
            // pnlNurse
            // 
            this.pnlNurse.Controls.Add(this.btnJubsuOpen);
            this.pnlNurse.Controls.Add(this.btnBody);
            this.pnlNurse.Controls.Add(this.btnJinryoEnd);
            this.pnlNurse.Controls.Add(this.btnOrder);
            this.pnlNurse.Controls.Add(this.btnAllergy);
            this.pnlNurse.Controls.Add(this.btnGamyum);
            resources.ApplyResources(this.pnlNurse, "pnlNurse");
            this.pnlNurse.Name = "pnlNurse";
            // 
            // btnJubsuOpen
            // 
            resources.ApplyResources(this.btnJubsuOpen, "btnJubsuOpen");
            this.btnJubsuOpen.ImageIndex = 18;
            this.btnJubsuOpen.ImageList = this.ImageList;
            this.btnJubsuOpen.Name = "btnJubsuOpen";
            this.btnJubsuOpen.Click += new System.EventHandler(this.btnJubsuOpen_Click);
            // 
            // btnBody
            // 
            resources.ApplyResources(this.btnBody, "btnBody");
            this.btnBody.ImageIndex = 2;
            this.btnBody.ImageList = this.ImageList;
            this.btnBody.Name = "btnBody";
            this.btnBody.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnBody.Click += new System.EventHandler(this.btnBody_Click);
            // 
            // btnJinryoEnd
            // 
            resources.ApplyResources(this.btnJinryoEnd, "btnJinryoEnd");
            this.btnJinryoEnd.ImageIndex = 5;
            this.btnJinryoEnd.ImageList = this.ImageList;
            this.btnJinryoEnd.Name = "btnJinryoEnd";
            this.btnJinryoEnd.Click += new System.EventHandler(this.btnJinryouEnd_Click);
            // 
            // btnOrder
            // 
            resources.ApplyResources(this.btnOrder, "btnOrder");
            this.btnOrder.ImageIndex = 3;
            this.btnOrder.ImageList = this.ImageList;
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnAllergy
            // 
            resources.ApplyResources(this.btnAllergy, "btnAllergy");
            this.btnAllergy.ImageIndex = 11;
            this.btnAllergy.ImageList = this.ImageList;
            this.btnAllergy.Name = "btnAllergy";
            this.btnAllergy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnAllergy.Click += new System.EventHandler(this.btnAllergy_Click);
            // 
            // btnGamyum
            // 
            resources.ApplyResources(this.btnGamyum, "btnGamyum");
            this.btnGamyum.ImageIndex = 14;
            this.btnGamyum.ImageList = this.ImageList;
            this.btnGamyum.Name = "btnGamyum";
            this.btnGamyum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnGamyum.Click += new System.EventHandler(this.btnGamyum_Click);
            // 
            // btnReser
            // 
            resources.ApplyResources(this.btnReser, "btnReser");
            this.btnReser.ImageIndex = 13;
            this.btnReser.ImageList = this.ImageList;
            this.btnReser.Name = "btnReser";
            this.btnReser.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnReser.Click += new System.EventHandler(this.btnReser_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.ImageIndex = 17;
            this.btnDelete.ImageList = this.ImageList;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnJubsu
            // 
            resources.ApplyResources(this.btnJubsu, "btnJubsu");
            this.btnJubsu.ImageIndex = 16;
            this.btnJubsu.ImageList = this.ImageList;
            this.btnJubsu.Name = "btnJubsu";
            this.btnJubsu.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnJubsu.Click += new System.EventHandler(this.btnJubsu_Click);
            // 
            // btnJusangi
            // 
            this.btnJusangi.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnJusangi, "btnJusangi");
            this.btnJusangi.Image = ((System.Drawing.Image)(resources.GetObject("btnJusangi.Image")));
            this.btnJusangi.Name = "btnJusangi";
            this.btnJusangi.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnJusangi.Click += new System.EventHandler(this.btnJusangi_Click);
            // 
            // btnDoctorChange
            // 
            resources.ApplyResources(this.btnDoctorChange, "btnDoctorChange");
            this.btnDoctorChange.ImageIndex = 0;
            this.btnDoctorChange.ImageList = this.ImageList;
            this.btnDoctorChange.Name = "btnDoctorChange";
            this.btnDoctorChange.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDoctorChange.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnDoctorChange.Click += new System.EventHandler(this.btnDoctorChange_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ImageIndex = 12;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnPrint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NUR2001U04_MouseMove);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAction
            // 
            resources.ApplyResources(this.btnAction, "btnAction");
            this.btnAction.Image = ((System.Drawing.Image)(resources.GetObject("btnAction.Image")));
            this.btnAction.Name = "btnAction";
            this.btnAction.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
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
            // NUR2001U04
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            resources.ApplyResources(this, "$this");
            this.Name = "NUR2001U04";
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
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlOtherClinic.ResumeLayout(false);
            this.gbxPaCnt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaCnt)).EndInit();
            this.pnlPart.ResumeLayout(false);
            this.pnlNurse.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// 메세지 일괄 처리
        /// </summary>
        /// <param name="aMesgGubun">
        /// 메세지 구분
        /// </param>
        #region 메세지처리
        private void GetMessage(string aMesgGubun)
        {
            string msg = string.Empty;
            string caption = string.Empty;

            switch (aMesgGubun)
            {
                case "bunho":
                    msg = Resources.MSG001_MSG;
                    caption = Resources.MSG001_CAP;
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "orderEndYn":
                    msg = Resources.MSG002_MSG;
                    caption = (Resources.MSG001_CAP);
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "doctor":
                    msg = Resources.MSG003_MSG;
                    caption = (Resources.MSG001_CAP);
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "doctorChange":
                    msg = Resources.MSG004_MSG;
                    msg += "\r\n[" + Service.ErrFullMsg + "]";
                    caption = Resources.MSG004_CAP;
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 조회
        int mReconnectCnt = 0;
        private void QueryData()
        {
            if (!this.mQueryFlag)
                return;

            if (!CheckSave())
            {
                return;
            }

            if (DateTime.Now.Hour > 13)
                this.Aampm_gubun = "P";
            else
                this.Aampm_gubun = "A";

            if (this.dtpNaewonDate.GetDataValue().ToString() == "" || this.dtpToDate.GetDataValue().ToString() == "") return;

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
                                XMessageBox.Show(Resources.MSG005_MSG, Resources.MSG005_CAP, MessageBoxIcon.Warning);

                            }
                        }

                        return;
                    }

                    if (Service.ErrCode != 3113)
                        XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }
                else
                {
                    if (grdPatientList.RowCount == 0)
                    {
                        this.btnAction.Enabled = false;
                        if (rbtNaewon.Checked == true)
                        {                            
                            this.btnAction.Text = Resources.BTNACTION_TEXT_2;
                        }
                        else
                        {
                            this.btnAction.Text = Resources.BTNACTION_TEXT_1;
                        }
                    }
                }
                //this.cbxAutoQuery.Checked = true;


                //입원중인환자 이미지 처리
                DisplayListImage(this.grdPatientList);

                //환자 카운트
                //this.grdPaCnt.QueryLayout(true);


            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }
        #endregion

        #region 환자 이미지 표시
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

                    if (aGrd.GetItemValue(i, "kensa_yn").ToString().Trim() == "Y")
                    {
                        aGrd[i, "icon"].ToolTipText += Resources.AGRD_TOOLTIP001;
                        aGrd[i, "icon"].Image = this.ImageList.Images[21];
                    }

                    if (aGrd.GetItemValue(i, "reser_yn").ToString().Trim() == "Y")
                    {
                        aGrd[i, "icon"].ToolTipText += Resources.AGRD_TOOLTIP002;
                        aGrd[i, "icon"].Image = this.ImageList.Images[9];
                    }

                    if (aGrd.GetItemValue(i, "naewon_type").ToString().Trim() == "1")
                    {
                        aGrd[i, "icon"].ToolTipText += Resources.AGRD_TOOLTIP003;
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
                        aGrd[i, "icon"].ToolTipText += Resources.AGRD_TOOLTIP004;
                        aGrd[i, "icon"].Image = this.ImageList.Images[4];
                    }

                    if (aGrd.GetItemValue(i, "kaigo_yn").ToString().Trim() == "Y") // 입원중인 환자
                    {
                        aGrd[i, "icon"].ToolTipText += Resources.AGRD_TOOLTIP005;
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
        #endregion

        private IList<object[]> GetPatientList(BindVarCollection list)
        {
            this.grdPatientList.Reset();
            List<object[]> gridList = null;
            if (list != null && list.Count != 0)
            {
                // set arguments
                NuroPatientListArgs nuroPatientListArgs = new NuroPatientListArgs();
                nuroPatientListArgs.HospitalCode = list["f_hosp_code"].VarValue;
                nuroPatientListArgs.ComingDate = list["f_naewon_date"].VarValue;
                nuroPatientListArgs.DepartmentCode = list["f_gwa"].VarValue;
                nuroPatientListArgs.DoctorCode = list["f_doctor"].VarValue;
                nuroPatientListArgs.PatientCode = list["f_bunho"].VarValue;
                nuroPatientListArgs.ReceptionType = list["f_jubsu_gubun"].VarValue;
                nuroPatientListArgs.ExamStatus = list["f_jinryo_yn"].VarValue;
                nuroPatientListArgs.ComingStatus = list["f_naewon_yn"].VarValue;
                nuroPatientListArgs.CurrentSystemId = EnvironInfo.CurrSystemID;
                nuroPatientListArgs.ToDate = list["f_to_date"].VarValue;
                // get results
                NuroPatientListResult result =
                    CloudService.Instance.Submit<NuroPatientListResult, NuroPatientListArgs>(nuroPatientListArgs);
                gridList = new List<object[]>();
                IList<NuroPatientListItemInfo> patientListItems = result.PatientListItem;
                foreach (NuroPatientListItemInfo item in patientListItems)
                {
                    gridList.Add(new object[]
                    {
                        item.TrialYn,
                        item.DepartmentCode,
                        item.DepartmentName,
                        item.PatientCode,
                        item.PatientName,
                        item.PatientName2,
                        item.ComingDate,
                        item.DoctorCode,
                        item.DoctorName,
                        item.ComingType,
                        item.ReceptionCode,
                        item.Birth,
                        item.AgeSex,
                        item.OutResKey,
                        item.ReceptionTime,
                        item.OrderEndYn,
                        item.HoldYn,
                        item.ResultYn,
                        item.ReserYn,
                        item.IpwonYn,
                        item.SunabYn,
                        item.ComingStatus,
                        item.ReceptionType,
                        item.ReceptionTypeName,
                        item.Remark,
                        item.ArriveTime,
                        item.Type,
                        item.LastComingDate,
                        item.OcsComment,
                        item.Chojae,
                        item.GroupKey,
                        item.PatientType,
                        item.CareStatus,
                        item.Percentage,
                        item.ExamStatus,
                        //item.TrialYn
                        // https://sofiamedix.atlassian.net/browse/MED-14256
                        "",
                        item.SysId,
                    });
                }
            }
            return gridList;
        }

        private List<string> CreatePatientParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_hosp_code");
            paramList.Add("f_naewon_date");
            paramList.Add("f_gwa");
            paramList.Add("f_doctor");
            paramList.Add("f_bunho");
            paramList.Add("f_jubsu_gubun");
            paramList.Add("f_jinryo_yn");
            paramList.Add("f_naewon_yn");
            paramList.Add("f_to_date");
            return paramList;
        }

        private IList<object[]> GetGridCellCombo(BindVarCollection list)
        {
            InitializeComboListItemResult result = initializeComboListItem();
            IList<object[]> lstObject = new List<object[]>();
            if (result != null && result.ComboTypeItem != null)
            {
                lstObject = createListDataForCombo(result.ComboTypeItem);
            }

            return lstObject;
        }

        private IList<object[]> GetDoctorNameList(BindVarCollection list)
        {
            List<object[]> doctorNameList = new List<object[]>();

            // set arguments
            NuroNUR2001U04DoctorNameArgs doctorNameArgs = new NuroNUR2001U04DoctorNameArgs();
            doctorNameArgs.DoctorCode = list["f_doctor"].VarValue;
            doctorNameArgs.Date = list["f_date"].VarValue;
            // get results
            NuroNUR2001U04DoctorNameResult result =
                CloudService.Instance.Submit<NuroNUR2001U04DoctorNameResult, NuroNUR2001U04DoctorNameArgs>(
                    doctorNameArgs);

            IList<DataStringListItemInfo> doctorNameListItems = result.DoctorName;
            foreach (DataStringListItemInfo item in doctorNameListItems)
            {
                doctorNameList.Add(new object[]
                {
                    item.DataValue
                });
            }
            return doctorNameList;
        }

        private List<string> CreateDoctorNameParamList()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_doctor");
            lstParam.Add("f_date");
            return lstParam;
        }

        private IList<object[]> GetForeignKeyList(BindVarCollection list)
        {
            List<object[]> foreignKeyList = null;
            if (list != null && list.Count != 0)
            {
                // set arguments
                NuroNUR2001U04ForeignKeyArgs foreignKeyArgs = new NuroNUR2001U04ForeignKeyArgs();
                foreignKeyArgs.ComingDate = list["f_naewon_date"].VarValue;
                foreignKeyArgs.PatientCode = list["f_bunho"].VarValue;
                foreignKeyArgs.DepartmentCode = list["f_gwa"].VarValue;
                foreignKeyArgs.DoctorCode = list["f_doctor"].VarValue;
                foreignKeyArgs.ComingType = list["f_naewon_type"].VarValue;
                foreignKeyArgs.ReceptionNo = list["f_jubsu_no"].VarValue;

                // get results
                NuroNUR2001U04ForeignKeyResult result =
                    CloudService.Instance.Submit<NuroNUR2001U04ForeignKeyResult, NuroNUR2001U04ForeignKeyArgs>(foreignKeyArgs);
                foreignKeyList = new List<object[]>();
                IList<DataStringListItemInfo> foreignKeyListItems = result.Result;
                foreach (DataStringListItemInfo item in foreignKeyListItems)
                {
                    foreignKeyList.Add(new object[]
                    {
                        item.DataValue
                    });
                }
            }
            return foreignKeyList;
        }

        private List<string> CreateForeignKeyParamList()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_naewon_date");
            lstParam.Add("f_bunho");
            lstParam.Add("f_gwa");
            lstParam.Add("f_doctor");
            lstParam.Add("f_naewon_type");
            lstParam.Add("f_jubsu_no");
            return lstParam;
        }

        #region Screen Load

        private void NUR2001U04_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            // Init data for combobox
            initializeComboListItem();

            mHospCode = EnvironInfo.HospCode;
            //this.Tag = "Close";

            this.ParentForm.KeyPreview = true;
            this.ParentForm.KeyDown += new KeyEventHandler(this.NUR2001U04_KeyDown);
            this.grdPatientList.ParamList = CreatePatientParamList();

            if (EnvironInfo.CurrSystemID == "NURO")
            {
                this.pnlNurse.Visible = true;
                this.pnlPart.Visible = false;
                //this.lbJubsuGubun.Visible = false;
                //this.cboJubsuGubun.Visible = false;

            }
            else if (EnvironInfo.CurrSystemID == "OUTS")
            {
                this.pnlNurse.Visible = false;
                this.pnlPart.Visible = false;
                this.pnlOtherClinic.Location = new Point(0, 223);
                //this.lbJubsuGubun.Visible = false;
                //this.cboJubsuGubun.Visible = false;

            }
            else
            {
                this.pnlNurse.Visible = true;
                this.pnlPart.Visible = true;
                this.lbJubsuGubun.Visible = true;
                this.cboJubsuGubun.Visible = true;

            }

            this.cboTime.SelectedIndex = 0;

            this.grdPatientList.SavePerformer = new XSavePerformer(this);

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

            this.dtpToDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpToDate.AcceptData();

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

            IXScreen ix = FindScreen("SCHS", "SCH0201Q12");
            if (ix != null)
            {
                PostCallHelper.PostCall(ix.Activate);
            }
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
            if (this.grdPatientList.RowCount > 0)
            {
                string bunho = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho");

                return new XPatientInfo(bunho, "", "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

        #region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
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
                    if (!String.IsNullOrEmpty(UserInfo.MisaIp))
                    {
                        if (SyncPatientMisa())
                            SyncBookingMisa();
                    }
                    //조회
                    QueryData();
                    break;

                case FunctionType.Reset:
                    e.IsBaseCall = false;

                    this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate());
                    this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());

                    this.cboGwa.SelectedIndex = 0;

                    this.fbxDoctor.SetEditValue("");
                    this.fbxDoctor.AcceptData();

                    this.dbxDoctor_name.SetEditValue("");
                    this.dbxDoctor_name.AcceptData();

                    this.paBox.Reset();


                    this.cbxAutoQuery.Checked = true;
                    this.cboTime.SelectedIndex = 0;

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    // 2015.07.31 AnhNV Added START
                    List<NUR2001U04SaveLayoutInfo> lstData = GetListDataForSaveLayout();

                    if (lstData.Count > 0)
                    {
                        if (SaveGrid(lstData))
                        {
                            //조회
                            QueryData();
                            XMessageBox.Show(Resources.MSG006_MSG, Resources.MSG006_CAP);
                        }
                        else
                        {
                            XMessageBox.Show(Resources.MSG007_MSG + Service.ErrFullMsg, Resources.MSG007_CAP, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG006_MSG, Resources.MSG006_CAP);
                    }
                    // 2015.07.31 AnhNV Added END

                    //if (this.grdPatientList.SaveLayout())
                    //{
                    //    //조회
                    //    QueryData();
                    //    XMessageBox.Show(Resources.MSG006_MSG, Resources.MSG006_CAP);
                    //}
                    //else
                    //{
                    //    XMessageBox.Show(Resources.MSG007_MSG + Service.ErrFullMsg, Resources.MSG007_CAP, MessageBoxIcon.Error);
                    //}

                    break;


                default:
                    break;
            }
        }
        #endregion

        #region 내원일자를 변경을 했을 때
        bool mQueryFlag = false;
        private void dtpNaewonDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //조회
            //if (mQueryFlag)
            //    QueryData();
        }
        #endregion

        #region 진료과를 변경을 했을 때
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
        #endregion

        #region 접수구분 변경을 했을 때
        private void cboJubsuGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            //조회
            QueryData();

        }
        #endregion

        #region 환자번호를 선택을 했을 때
        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            //조회
            QueryData();
        }
        #endregion

        private string GetComingStatus()
        {
            string resultStr = "";

            NuroNUR2001U04ComingStatusArgs comingStatusArgs = new NuroNUR2001U04ComingStatusArgs();
            comingStatusArgs.PatientCode = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho");
            comingStatusArgs.ComingDate = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "naewon_date");
            comingStatusArgs.DepartmentCode = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "gwa");
            comingStatusArgs.DoctorCode = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "doctor");
            comingStatusArgs.ComingType = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "naewon_type");
            comingStatusArgs.OldReceptionNo = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "jubsu_no");
            comingStatusArgs.ExamStatus = this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "chojae");
            NuroNUR2001U04ComingStatusResult result = CloudService.Instance.Submit<NuroNUR2001U04ComingStatusResult, NuroNUR2001U04ComingStatusArgs>(comingStatusArgs);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                resultStr = result.Result;
            }

            return resultStr;
        }

        private string GetExistingKeyStatus()
        {
            NuroNUR2001U04ExistingKeyStatusArgs existingKeyStatusArgs = new NuroNUR2001U04ExistingKeyStatusArgs();
            existingKeyStatusArgs.Pkout1001 = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001");
            NuroNUR2001U04ExistingKeyStatusResult result = CloudService.Instance.Submit<NuroNUR2001U04ExistingKeyStatusResult, NuroNUR2001U04ExistingKeyStatusArgs>(existingKeyStatusArgs);
            return result.Result;
        }

        private string CallProcOcsoDoctorChange2(NuroProcOcsoDoctorChange2Args procOcsoDoctorChange2Arg)
        {
            NuroProcOcsoDoctorChange2Result result = CloudService.Instance.Submit<NuroProcOcsoDoctorChange2Result, NuroProcOcsoDoctorChange2Args>(procOcsoDoctorChange2Arg);
            return result.Flag;
        }

        private UpdateResult ExecuteTransPatientInfoRequest(NuroNUR2001U04TransPatientInfoArgs transPatientInfoArgs)
        {
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, NuroNUR2001U04TransPatientInfoArgs>(transPatientInfoArgs);
            return result;
        }

        private bool UpdateComingStatus(string comingStatus)
        {
            NuroNUR2001U04ComingStatusUpdateArgs comingStatusUpdateArgs = new NuroNUR2001U04ComingStatusUpdateArgs();
            comingStatusUpdateArgs.ComingStatus = comingStatus;
            comingStatusUpdateArgs.Pkout1001 = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001");
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, NuroNUR2001U04ComingStatusUpdateArgs>(comingStatusUpdateArgs);
            return result.Result;
        }

        private static bool UpdatePatientInfo(RowDataItem item)
        {
            NuroNUR2001U04PatientInfoUpdateArgs patientInfoUpdateArgs = new NuroNUR2001U04PatientInfoUpdateArgs();
            patientInfoUpdateArgs.UpdId = item.BindVarList["q_user_id"].VarValue;
            patientInfoUpdateArgs.ComingStatus = item.BindVarList["f_naewon_yn"].VarValue;
            patientInfoUpdateArgs.ArriveTime = item.BindVarList["f_arrive_time"].VarValue;
            patientInfoUpdateArgs.ReceptionType = item.BindVarList["f_jubsu_gubun"].VarValue;
            patientInfoUpdateArgs.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, NuroNUR2001U04PatientInfoUpdateArgs>(patientInfoUpdateArgs);
            return result.Result;
        }

        #region 진료의 변경 버튼을 클릭을 했을 때
        private void btnDoctorChange_Click(object sender, System.EventArgs e)
        {

            int selectedRow = this.grdPatientList.CurrentRowNumber;
            if (selectedRow < 0)
            {              
                XMessageBox.Show(Resources.MSG035_MSG, Resources.MSG035_CAP, MessageBoxIcon.Warning);                
                return;
            }

            if (this.grdPatientList.GetItemString(selectedRow, "order_end_yn") == "Y" ||
                this.grdPatientList.GetItemString(selectedRow, "hold_yn") == "Y")
            {
                XMessageBox.Show(Resources.MSG008_MSG, Resources.MSG008_CAP, MessageBoxIcon.Warning);
                return;
            }

            if (this.grdPatientList.GetItemString(selectedRow, "sunab_yn") == "Y")
            {
                //XMessageBox.Show("既に診療を行っているので変更できません。", "注意", MessageBoxIcon.Warning);
                XMessageBox.Show(Resources.MSG009_MSG, Resources.MSG008_CAP, MessageBoxIcon.Warning);
                return;
            }

            string comingStatus = GetComingStatus();
            string naewonYN = "N";


            if (!string.IsNullOrEmpty(comingStatus) && comingStatus.Trim().Length != 0)
            {
                naewonYN = comingStatus;
            }

            //if (naewonYN == "Y")
            //{
            //    this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과에서 내원확인이 되었으므로 수정할 수 없습니다. 진료과로 문의 하십시오." : "診療科で来院確認がされたので修正できません。\r\n診療科にお問合せください。";
            //    this.mCap = NetInfo.Language == LangMode.Ko ? "외래접수" : "外来受付";

            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else 
            if (naewonYN == "O")
            {
                string mMsg = Resources.MSG010_MSG;
                string mCap = Resources.MSG008_CAP;

                XMessageBox.Show(mMsg, mCap, MessageBoxIcon.Warning);
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

                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT1001P01", ScreenOpenStyle.ResponseFixed,
                    doctorOpen);

                QueryData();
                //this.paBox.Reset();
                this.paBox.Focus();
            }
            else
            {
                return;
            }

        }
        #endregion

        #region 신체계측 버튼을 클릭을 했을 때
        private void btnBody_Click(object sender, System.EventArgs e)
        {
            CommonItemCollection bodyOpen = new CommonItemCollection();

            if (this.grdPatientList.RowCount > 0)
            {
                bodyOpen.Add("bunho", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString());
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR7001U00", ScreenOpenStyle.ResponseFixed, bodyOpen);
            }
        }
        #endregion

        #region 간호오다등록을 클릭을 했을 때
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
        #endregion

        #region 팝업화면에서 데이터 받기
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
        #endregion

        #region 진료의변경
        private string mDoctor;
        private void ChangeDoctor(string doctor)
        {
            if (this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString() == "")
            {
                this.GetMessage("bunho");
                return;
            }

            string title = "";
            string msg = "";

            //처방완료
            if (this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "order_end_yn").ToString() == "Y")
            {
                this.GetMessage("orderEndYn");
                return;
            }

            //진료의 체크
            if (doctor == "")
            {
                this.GetMessage("doctor");
                return;
            }

            title = Resources.TITLE_TEXT;

            //내원확인
            msg = (this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "suname").ToString() + Resources.MSG011_MSG);
            if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            //접수키,예약여부,내원여부

            if (CallPrDoctorChange(doctor))
            {
                //재조회
                QueryData();
            }
        }

        private bool CallPrDoctorChange(string aDoctor)
        {
            ArrayList inputList;
            ArrayList outputList;
            mDoctor = aDoctor;

            this.layPKOUT1001.ParamList = CreateForeignKeyParamList();

            if (!this.layPKOUT1001.QueryLayout())
            {
                XMessageBox.Show(Resources.MSG012_MSG, Resources.MSG008_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!TypeCheck.IsNull(this.layPKOUT1001.GetItemValue("pkout1001")))
            {
                NuroProcOcsoDoctorChange2Args procOcsoDoctorChange2Arg = new NuroProcOcsoDoctorChange2Args();
                procOcsoDoctorChange2Arg.Pkout1001 = this.layPKOUT1001.GetItemValue("pkout1001").ToString().Trim();
                procOcsoDoctorChange2Arg.ToDoctor = aDoctor.Trim();
                procOcsoDoctorChange2Arg.ToClinicCode = " ";

                // this function is not used
                string flag = CallProcOcsoDoctorChange2(procOcsoDoctorChange2Arg);

                if (flag != "0")
                {
                    if (flag == "y")
                    {
                        XMessageBox.Show(Resources.MSG013_MSG, Resources.MSG008_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG014_MSG, Resources.MSG008_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            else
            {
                XMessageBox.Show(Resources.MSG012_MSG, Resources.MSG008_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

            #region 주석

            #endregion
        }
        #endregion

        #region 진료의 선택화면 오픈
        private void fbxDoctor_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("gwa", this.cboGwa.GetDataValue().ToString());
            openParams.Add("word", "");
            openParams.Add("all_gubun", "Y");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }
        #endregion

        #region 진료예약환자인 경우에는 색깔표시
        private void grdPatientList_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            // https://sofiamedix.atlassian.net/browse/MED-14579
            if (e.DataRow["reser_yn"].ToString() == "Y" && e.DataRow["sys_id"].ToString() == "MBS")
            {
                e.BackColor = Color.LightGreen;
            }
            else if (e.DataRow["gwa"].ToString() == "04")
            {
                e.BackColor = Color.Pink;
            }

            // https://sofiamedix.atlassian.net/browse/MED-14256
            if (e.DataRow["sys_id"].ToString() == "MBSO")
            {
                e.BackColor = Color.LightYellow;
            }

            if (e.DataRow["kensa_yn"].ToString() == "Y")
            {
                e.BackColor = Color.SkyBlue;
            }

            if (e.DataRow["trial_yn"].ToString() == "Y")
            {
                grdPatientList[e.RowNumber + 1, 2].ToolTipText = Resources.SMS_TRIAL;
            }
            else if (e.DataRow["trial_yn"].ToString() == "N")
            {
                grdPatientList[e.RowNumber + 1, 2].ToolTipText = " ";
            }

        }
        #endregion

        #region 더블클릭을 했을 때 간호오다입력화면을 연다
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
            cic.Add("naewon_date", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"));
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201Q12", ScreenOpenStyle.ResponseFixed, cic);
        }
        #endregion

        #region 주산기시스템 인터페이스
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
        #endregion

        #region Query Event
        private void cboGwa_DDLBSetting(object sender, EventArgs e)
        {
            this.cboGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.cboGwa.SetBindVarValue("f_buseo_ymd", this.dtpNaewonDate.GetDataValue());
            this.cboGwa.SetBindVarValue("f_buseo_ymd", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"));
        }

        private void grdPatientList_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.grdPatientList.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdPatientList.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_doctor", this.fbxDoctor.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdPatientList.SetBindVarValue("f_jubsu_gubun", this.cboJubsuGubun.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            //this.grdPatientList.SetBindVarValue("f_query_all", this.cbxQueryAll.GetDataValue());

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

            if (EnvironInfo.CurrSystemID == "NURO")
            {
                for (int i = 0; i < grdPatientList.RowCount; i++)
                {
                    if ((grdPatientList.GetItemString(i, "naewon_yn") == "Y") &&
                        (grdPatientList.GetItemString(i, "kensa_yn") == "Y"))
                    {

                        CommonItemCollection cic = new CommonItemCollection();
                        cic.Add("bunho", this.grdPatientList.GetItemValue(i, "bunho").ToString());
                        //cic.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
                        cic.Add("naewon_date", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"));
                        cic.Add("fkout1001", this.grdPatientList.GetItemString(i, "pkout1001"));

                        IXScreen ix = IHIS.Framework.XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201Q12", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopCenter, cic);
                    }
                }
            }

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
        #endregion

        #region 버튼클릭
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (this.grdPatientList.SaveLayout())
            //{
            //    //조회
            //    QueryData();
            //    XMessageBox.Show(Resources.MSG006_MSG, Resources.MSG006_CAP);
            //}
            //else
            //{
            //    XMessageBox.Show(Resources.MSG007_MSG + Service.ErrFullMsg, Resources.MSG007_CAP, MessageBoxIcon.Error);
            //}

            // 2015.07.31 AnhNV Added START
            List<NUR2001U04SaveLayoutInfo> lstData = GetListDataForSaveLayout();

            if (lstData.Count > 0)
            {
                if (SaveGrid(lstData))
                {
                    //조회
                    QueryData();
                    XMessageBox.Show(Resources.MSG006_MSG, Resources.MSG006_CAP);
                }
                else
                {
                    XMessageBox.Show(Resources.MSG007_MSG + Service.ErrFullMsg, Resources.MSG007_CAP, MessageBoxIcon.Error);
                }
            }
            else
            {
                XMessageBox.Show(Resources.MSG006_MSG, Resources.MSG006_CAP);
            }
            // 2015.07.31 AnhNV Added END
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
                        XMessageBox.Show(Resources.MSG015_MSG, Resources.BTN_JINRYOEND_TEXT2, MessageBoxIcon.Warning);
                        return;
                    }

                    if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") == "N")
                    {
                        XMessageBox.Show(Resources.MSG016_MSG, Resources.MSG016_CAP, MessageBoxIcon.Information);
                        return;
                    }

                    if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "group_key") != "1" &&
                        this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "group_key") != "2")
                    {
                        XMessageBox.Show(Resources.MSG017_MSG, Resources.MSG017_CAP, MessageBoxIcon.Information);
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
                    //printOpen.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
                    printOpen.Add("naewon_date", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"));
                    printOpen.Add("bunho", aBunho);

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT1001R01", ScreenOpenStyle.PopUpFixed, printOpen);

                    this.paBox.Reset();
                    this.paBox.Focus();
                    //this.Activate();
                }
            }
        }
        #endregion

        #region 진료개시 체크
        private void grdPatientList_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            //if (e.ColName == "naewon_yn")
            //{
            //    if (e.ChangeValue.ToString() == "Y")
            //    {
            //        this.grdPatientList.SetFocusToItem(e.RowNumber, "hold_yn");
            //        this.grdPatientList.SetItemValue(e.RowNumber, "arrive_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
            //    }
            //    else
            //    {
            //        //string suname = this.grdPatientList.GetItemString(e.RowNumber, "suname");
            //        //string gwa_name = this.grdPatientList.GetItemString(e.RowNumber, "gwa_name");
            //        //string doctor_name = this.grdPatientList.GetItemString(e.RowNumber, "doctor_name");

            //        //DialogResult dr = XMessageBox.Show(suname + "さんの来院チェック(" + gwa_name + " " + doctor_name + ")を外しますか？", "来院確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //        //if (dr == DialogResult.Cancel)
            //        //{
            //        //    this.grdPatientList.SetItemValue(e.RowNumber, "naewon_yn", "Y");
            //        //}
            //        //else
            //        //{
            //        //    this.grdPatientList.SetItemValue(e.RowNumber, "arrive_time", "");
            //        //}
            //        this.grdPatientList.SetItemValue(e.RowNumber, "arrive_time", "");
            //    }
            //    this.timer1.Stop();
            //    this.timer1.Start();
            //}
        }
        #endregion

        #region 타이머 관련
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.cbxAutoQuery.Checked)
            {
                //if (this.Tag.ToString() == "Close")
                //{
                //조회
                if (!String.IsNullOrEmpty(UserInfo.MisaIp))
                {
                    SyncPatientMisa();
                    SyncBookingMisa();
                }
                QueryData();
                //}
            }
        }

        private void cboTime_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboTime.GetDataValue() != "")
                this.timer1.Interval = Int32.Parse(this.cboTime.GetDataValue());
        }
        #endregion

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

        private bool CheckSave()
        {
            if (IsExistUpdatedData())
            {
                //this.timer1.Stop();
                //DialogResult dr = XMessageBox.Show(Resources.MSG018_MSG, Resources.MSG018_CAP, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);


                //this.timer1.Start();
                //if (dr == DialogResult.Yes)
                //{
                    //if (!this.grdPatientList.SaveLayout())
                    //{
                    //    XMessageBox.Show(Resources.MSG007_MSG + Service.ErrFullMsg, Resources.MSG007_CAP, MessageBoxIcon.Error);
                    //    return false;
                    //}

                    // 2015.07.31 AnhNV Added START
                    List<NUR2001U04SaveLayoutInfo> lstData = GetListDataForSaveLayout();

                    if (lstData.Count > 0)
                    {
                        if (!SaveGrid(lstData))
                        {
                            XMessageBox.Show(Resources.MSG007_MSG + Service.ErrFullMsg, Resources.MSG007_CAP, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    // 2015.07.31 AnhNV Added END
            //    }
            //    else if (dr == DialogResult.No)
            //    {

            //    }
            //    else if (dr == DialogResult.Cancel)
            //    {
            //        return false;
            //    }
            }

            return true;
        }

        private void NUR2001U04_Closing(object sender, CancelEventArgs e)
        {
            if (!CheckSave())
            {
                e.Cancel = true;
                return;
            }
        }

        private bool IsExistUpdatedData()
        {
            foreach (DataRow row in this.grdPatientList.LayoutTable.Rows)
            {
                if (this.grdPatientList.DeletedRowCount > 0)
                    return true;

                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    return true;
            }

            return false;
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
                this.dbxDoctor_name.SetDataValue(Resources.default_doctor_name);
            }
            else
            {
                this.layDoctorName.ParamList = CreateDoctorNameParamList();
                this.layDoctorName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.layDoctorName.SetBindVarValue("f_doctor", e.DataValue);
                //this.layDoctorName.SetBindVarValue("f_date", this.dtpNaewonDate.GetDataValue());
                this.layDoctorName.SetBindVarValue("f_date", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"));
                this.layDoctorName.QueryLayout();

                this.dbxDoctor_name.SetDataValue(this.layDoctorName.GetItemValue("doctor_name"));

                if (this.layDoctorName.GetItemValue("doctor_name").ToString() == "")
                {
                    XMessageBox.Show(Resources.MSG019_MSG, Resources.MSG019_CAP, MessageBoxIcon.Warning);
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
            
            int selectedRow = this.grdPatientList.CurrentRowNumber;
            if (selectedRow < 0)
            {
                XMessageBox.Show(Resources.MSG035_MSG, Resources.MSG035_CAP, MessageBoxIcon.Warning);               
                return;
            }
            if (this.grdPatientList.RowCount < 1)
            {         
                return;
            }
            JubsuForm jubsuForm = new JubsuForm(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001"),
                this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"),
                this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_date")
                );
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
                    XMessageBox.Show(Resources.MSG020_MSG, Resources.BTN_JINRYOEND_TEXT2, MessageBoxIcon.Warning);
                    return;
                }

                if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "hold_yn") == "Y")
                {
                    XMessageBox.Show(Resources.MSG021_MSG, Resources.MSG021_CAP, MessageBoxIcon.Warning);
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

                DialogResult dr = XMessageBox.Show(suname + Resources.MSG022_1_MSG + gwa_name + " " + doctor_name + Resources.MSG022_2_MSG, Resources.MSG022_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    string comingStatus = GetComingStatus();
                    if (comingStatus.Trim().Length != 0)
                    {
                        //if(retVal.ToString() == "Y")
                        //{
                        //    XMessageBox.Show("診療科で内院確認が終わりましたので削除できません。診療科に問い合わせください。");
                        //    return false;
                        //}
                        if (comingStatus.Equals("E"))
                        {
                            XMessageBox.Show(Resources.MSG023_MSG);
                            return;
                        }
                    }

                    ArrayList inputList = new ArrayList();
                    ArrayList outputList = new ArrayList();

                    // 전표일자 구하기
                    inputList.Add(UserInfo.UserID);
                    string existingKeyStatus = GetExistingKeyStatus();
                    if (existingKeyStatus.Trim().Length != 0)
                    {
                        if (existingKeyStatus.Equals("Y"))
                        {
                            NuroNUR2001U04TransPatientInfoArgs transPatientInfoArgs = new NuroNUR2001U04TransPatientInfoArgs();
                            transPatientInfoArgs.IudGubun = "D";
                            transPatientInfoArgs.User = UserInfo.UserID;
                            transPatientInfoArgs.NaewonDate = naewon_date;
                            transPatientInfoArgs.Bunho = bunho;
                            transPatientInfoArgs.Gwa = gwa;
                            transPatientInfoArgs.Gubun = gubun;
                            transPatientInfoArgs.TuyakIlsu = "0";
                            transPatientInfoArgs.Doctor = doctor;
                            transPatientInfoArgs.InOut = "O";
                            transPatientInfoArgs.ChartGwa = gwa;
                            transPatientInfoArgs.SpecialYn = "N";
                            transPatientInfoArgs.ToiwonDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                            transPatientInfoArgs.Pkout1001 = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001");
                            UpdateResult result = ExecuteTransPatientInfoRequest(transPatientInfoArgs);

                            if (result != null && "17".Equals(result.Msg))
                            {
                                XMessageBox.Show(Resources.MSG037_MSG, Resources.MSG001_CAP, MessageBoxIcon.Warning);
                                return;
                            }

                            //XMessageBox.Show("削除しました。","削除", MessageBoxIcon.Information);
                            QueryData();

                            //this.paBox.Reset();
                            this.paBox.Focus();
                            //if false to Orca
                            if (!String.IsNullOrEmpty(result.Msg))
                            {
                                if (result != null && Array.IndexOf(msgOrca, result.Msg) < 0)
                                {
                                    XMessageBox.Show(Utilities.MessageOrca(result.Msg), result.Msg, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            //if false, rollback and show message
                            if (result.ExecutionStatus != ExecutionStatus.Success || !result.Result)
                            {
                                XMessageBox.Show(Resources.MSG025_MSG + Resources.MSG024_MSG, Resources.MSG025_CAP, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            else
            {
                XMessageBox.Show(Resources.MSG035_MSG, Resources.MSG035_CAP, MessageBoxIcon.Warning);
                return;
            }

        }

        private void btnReser_Click(object sender, EventArgs e)
        {               
                    CommonItemCollection openParam = new CommonItemCollection();

                    openParam.Add("bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));
                    openParam.Add("gwa", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
                    openParam.Add("doctor", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor"));
                    //openParam.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
                    openParam.Add("naewon_date", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"));

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "RES1001U00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentMiddleLeft, openParam);

                    //this.paBox.Reset();
                    this.paBox.Focus();
                
        }

        private void btnJinryouEnd_Click(object sender, EventArgs e)
        {
            if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") == "N")
            {
                XMessageBox.Show(Resources.MSG026_MSG, Resources.MSG016_CAP, MessageBoxIcon.Information);
                return;
            }

            //if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "order_end_yn") == "Y")
            //{
            //    XMessageBox.Show("既に診療終了されている患者です。", "来院確認", MessageBoxIcon.Information);
            //    return;
            //}

            string suname = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "suname");
            string gwa_name = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa_name");
            string doctor_name = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor_name");
            string pkout1001 = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001");

            //진료종료취소처리
            if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "order_end_yn") == "Y")
            {
                DialogResult dr = XMessageBox.Show(Resources.MSG027_0_MSG + suname + Resources.MSG027_1_MSG + gwa_name + " " + doctor_name + Resources.MSG027_2_MSG, Resources.BTN_JINRYOEND_TEXT1, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (!UpdateComingStatus("Y"))
                    {
                        XMessageBox.Show(Resources.MSG028_MSG + Service.ErrFullMsg, Resources.MSG028_CAP, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else //진료종료처리
            {
                DialogResult dr = XMessageBox.Show(Resources.MSG029_0_MSG + suname + Resources.MSG029_MSG + gwa_name + " " + doctor_name + Resources.MSG027_2_MSG, Resources.BTN_JINRYOEND_TEXT2, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (!UpdateComingStatus("E"))
                    {
                        XMessageBox.Show(Resources.MSG030_MSG + Service.ErrFullMsg, Resources.MSG030_CAP, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            QueryData();

        }

        private void NUR2001U04_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.btnPrint.PerformClick();
            }

        }

        private void btnJubsuOpen_Click(object sender, EventArgs e)
        {
            //IHIS.Framework.XScreen.OpenScreen(this, "OUT1001U01", ScreenOpenStyle.ResponseFixed);
            CommonItemCollection param = new CommonItemCollection();
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT1001U01", ScreenOpenStyle.ResponseFixed, param);
        }

        private void btnOUT0106_Click(object sender, EventArgs e)
        {         
                    CommonItemCollection openParams = new CommonItemCollection();

                    openParams.Add("bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));

                    XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);

                    this.QueryData();
                    //this.paBox.Reset();
                    this.paBox.Focus();
        }

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            NUR2001U04 parent;

            public XSavePerformer(NUR2001U04 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                bool result = false;
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                /*string cmdText = @"";
                switch (item.RowState)
                {
                    case DataRowState.Modified:

                        cmdText = @"UPDATE OUT1001
                                       SET UPD_ID      = :q_user_id
                                         , UPD_DATE    = SYSDATE
                                         , NAEWON_YN   = :f_naewon_yn
                                         , ARRIVE_TIME = :f_arrive_time
                                         , JUBSU_GUBUN = :f_jubsu_gubun
                                     WHERE HOSP_CODE   = :f_hosp_code
                                       AND PKOUT1001   = :f_pkout1001";
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);*/
                if (item.RowState.Equals(DataRowState.Modified))
                {
                    result = UpdatePatientInfo(item);
                }
                return result;
            }
        }
        #endregion

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

                    //openParams.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
                    openParams.Add("naewon_date", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"));
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
           // this.grdPaCnt.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
            this.grdPaCnt.SetBindVarValue("f_naewon_date", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"));

        }

        private void grdPatientList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //HungNV added
            //SetActiveIntroLeterBtn(false, e.CurrentRow);
            if (this.grdPatientList.GetItemString(e.CurrentRow, "order_end_yn") == "Y")
            {
                this.btnJinryoEnd.Text = Resources.BTN_JINRYOEND_TEXT1;
            }
            else
            {
                this.btnJinryoEnd.Text = Resources.BTN_JINRYOEND_TEXT2;
            }

            //Enable/Disabel btnAction
            if (this.grdPatientList.GetItemString(e.CurrentRow, "reser_yn") == "Y" && this.grdPatientList.GetItemString(e.CurrentRow, "naewon_yn") == "N")
            {
                this.btnAction.Enabled = true;
                this.btnAction.Text = Resources.BTNACTION_TEXT_1;
            }
            else if (this.grdPatientList.GetItemString(e.CurrentRow, "reser_yn") == "Y" && this.grdPatientList.GetItemString(e.CurrentRow, "naewon_yn") == "Y")
            {
                this.btnAction.Enabled = true;
                this.btnAction.Text = Resources.BTNACTION_TEXT_2;
            }
            else if (this.grdPatientList.GetItemString(e.CurrentRow, "reser_yn") == "N" && this.grdPatientList.GetItemString(e.CurrentRow, "naewon_yn") == "N")
            {
                this.btnAction.Enabled = false;
                this.btnAction.Text = Resources.BTNACTION_TEXT_1;
            }
            else if (this.grdPatientList.GetItemString(e.CurrentRow, "reser_yn") == "N" && this.grdPatientList.GetItemString(e.CurrentRow, "naewon_yn") == "Y")
            {
                this.btnAction.Enabled = false;
                this.btnAction.Text = Resources.BTNACTION_TEXT_2;
            }
        }
        //HungNV added
        private void SetActiveIntroLeterBtn(bool isInit, int currentRow)
        {
            //if (isInit)
            //{
            //    if (this.grdPatientList.RowCount > 0)
            //    {
            //        string bunho = this.grdPatientList.GetItemString(0, "bunho");
            //        if (IsExistEmrRecord(bunho))
            //            this.btnIntroduce.Enabled = false;
            //        else
            //            this.btnIntroduce.Enabled = true;
            //    }
            //}
            //else
            //{
            //    string bunho = this.grdPatientList.GetItemString(currentRow, "bunho");
            //    if (IsExistEmrRecord(bunho))
            //        this.btnIntroduce.Enabled = false;
            //    else
            //        this.btnIntroduce.Enabled = true;
            //}
        }

        private bool IsExistEmrRecord(string bunho)
        {
            NUR2001U04CheckExistMedicalRecordArgs args = new NUR2001U04CheckExistMedicalRecordArgs();
            args.PatientCode = bunho;
            NUR2001U04CheckExistMedicalRecordResult res = CloudService.Instance.Submit<NUR2001U04CheckExistMedicalRecordResult, NUR2001U04CheckExistMedicalRecordArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.MedicalRecordInfo.Count > 0)
                return true;
            return false;
        }

        private void btnBunhoChage_Click(object sender, EventArgs e)
        {         
                    CommonItemCollection openParams = new CommonItemCollection();
                    //openParams.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
                    openParams.Add("naewon_date", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"));

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

        private void grdPatientList_GridSorted(object sender, EventArgs e)
        {

            //입원중인환자 이미지 처리
            DisplayListImage(this.grdPatientList);
        }

        private void grdPatientList_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell22.ExecuteQuery = GetGridCellCombo;
        }

        // Connect cloud: get data for combo
        private InitializeComboListItemResult initializeComboListItem()
        {
            InitializeComboListItemResult result = new InitializeComboListItemResult();
            InitializeComboListItemArgs args = new InitializeComboListItemArgs();
            args.CodeType = "JUBSU_GUBUN";
            args.ComboTimeType = "NUR2001U04_TIMER";

            result = CacheService.Instance.Get<InitializeComboListItemArgs, InitializeComboListItemResult>(args);

            if (result != null)
            {
                cboGwa.SetDictDDLB(createListDataForCombo(result.ComboDepartmentItem));
                cboTime.SetDictDDLB(createListDataForCombo(result.ComboTimeItem));
                cboJubsuGubun.SetDictDDLB(createListDataForCombo(result.ComboTypeItem));
            }
            return result;
        }

        private IList<object[]> createListDataForCombo(IList<ComboListItemInfo> lstComboDept)
        {
            IList<object[]> lstData = new List<object[]>();
            if (lstComboDept != null && lstComboDept.Count > 0)
            {
                foreach (ComboListItemInfo comboListItemInfo in lstComboDept)
                {
                    object[] obj = { comboListItemInfo.Code, comboListItemInfo.CodeName };
                    lstData.Add(obj);
                }
            }
            return lstData;
        }

        private void btnIntroduce_Click(object sender, EventArgs e)
        {
            string bunho = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho");

            if (String.IsNullOrEmpty(bunho))
            {
                XMessageBox.Show(Resources.lbIntroduceAlert);
                return;
            }

            string naewonDate = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_date");
            string naewonKey = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pkout1001");
            string birth = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "birth");
            string age_sex = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "age_sex");
            string doctor = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "doctor");
            //Comment for New introduce letter
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|Pdf Files|*.Pdf";
            //dialog.FilterIndex = 1;
            //dialog.RestoreDirectory = true;
            string imageToInsert = "";
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    imageToInsert = dialog.FileName;
            //}

            CommonItemCollection letterOpen = new CommonItemCollection();
            letterOpen.Add("f_bunho", bunho);
            letterOpen.Add("f_hosp_code", UserInfo.HospCode);
            letterOpen.Add("f_user_id", UserInfo.UserID);
            letterOpen.Add("f_naewon_date", naewonDate);
            letterOpen.Add("f_naewon_key", naewonKey);
            letterOpen.Add("f_image_name", imageToInsert);
            letterOpen.Add("birth", birth);
            letterOpen.Add("age_sex", age_sex);
            letterOpen.Add("doctor", doctor);
            letterOpen.Add("mOpener", this.ScreenID);

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSO", "NUR2015U01", ScreenOpenStyle.ResponseSizable,
                    letterOpen);
            btnList.PerformClick(FunctionType.Query);
        }

        #region SaveGrid
        /// <summary>
        /// SaveGrid
        /// </summary>
        /// <param name="saveLayoutLst"></param>
        /// <returns></returns>
        private bool SaveGrid(List<NUR2001U04SaveLayoutInfo> saveLayoutLst)
        {
            NUR2001U04SaveLayoutArgs args = new NUR2001U04SaveLayoutArgs();
            args.HospCode = UserInfo.HospCode;
            args.UserId = UserInfo.UserID;
            args.SaveLayoutItem = saveLayoutLst;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, NUR2001U04SaveLayoutArgs>(args);

            return res.ExecutionStatus == ExecutionStatus.Success && res.Result;
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<NUR2001U04SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<NUR2001U04SaveLayoutInfo> lstData = new List<NUR2001U04SaveLayoutInfo>();

            for (int i = 0; i < grdPatientList.RowCount; i++)
            {
                if (grdPatientList.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                NUR2001U04SaveLayoutInfo item   = new NUR2001U04SaveLayoutInfo();
                item.ArriveTime                 = grdPatientList.GetItemString(i, "arrive_time");
                item.JubsuGubun                 = grdPatientList.GetItemString(i, "jubsu_gubun");
                item.NaewonYn                   = grdPatientList.GetItemString(i, "naewon_yn");
                item.Pkout1001                  = grdPatientList.GetItemString(i, "pkout1001");

                lstData.Add(item);
            }

            return lstData;
        }
        

        #endregion

        private void btnUpdateClinicsEmr_Click(object sender, EventArgs e)
        {
            string bunho = grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho");
            string patientName = grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "suname");
            IHIS.OCS.OUT2016U00 form = new IHIS.OCS.OUT2016U00(bunho, patientName);
            form.ShowDialog(this);

            // if (!TypeCheck.IsNull(bunho))
            //{
            //IHIS.OCS.OUT2016U00 form = new IHIS.OCS.OUT2016U00(bunho, patientName);
            //form.ShowDialog(this);
            //}
            //CommonItemCollection param = new CommonItemCollection();
            //XScreen.OpenScreenWithParam(this, "NURO", "OUT2016U00", ScreenOpenStyle.ResponseFixed, param);
        }
        /// <summary>
        /// 2016.02.16 Added by AnhNV
        /// https://sofiamedix.atlassian.net/browse/MED-7465
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLinkPatient_Click(object sender, EventArgs e)
        {
            
            // Open NUR2016Q00 with selected bunho
            string bunho = grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho");
            //if (!TypeCheck.IsNull(bunho))
            //{
                CommonItemCollection paramObj = new CommonItemCollection();
                paramObj.Add("bunho", bunho);
                XScreen.OpenScreenWithParam(this, "NURO", "NUR2016Q00", ScreenOpenStyle.ResponseFixed, paramObj);
            //}
        }

        private void btnCancelLinkPatient_Click(object sender, EventArgs e)
        {
            // Open NUR2016U02 with selected bunho
            string bunho = grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho");
            //if (!TypeCheck.IsNull(bunho))
            //{
                CommonItemCollection paramObj = new CommonItemCollection();
                paramObj.Add("bunho", bunho);
                XScreen.OpenScreenWithParam(this, "NURO", "NUR2016U02", ScreenOpenStyle.ResponseFixed, paramObj);
            //}
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            int rownumber = 0;
            if (grdPatientList != null && grdPatientList.RowCount > 0 )
            {
                rownumber = grdPatientList.CurrentRowNumber;
                List<NUR2001U04SaveLayoutInfo> lstData = new List<NUR2001U04SaveLayoutInfo>();
                NUR2001U04SaveLayoutInfo item = new NUR2001U04SaveLayoutInfo();
                item.ArriveTime = grdPatientList.GetItemString(rownumber, "arrive_time");
                item.JubsuGubun = grdPatientList.GetItemString(rownumber, "jubsu_gubun");
                if (grdPatientList.GetItemString(rownumber, "naewon_yn") == "Y")
                {
                    item.NaewonYn = "N";
                }
                else
                {
                    item.NaewonYn = "Y";
                }
                item.Pkout1001 = grdPatientList.GetItemString(rownumber, "pkout1001");
                lstData.Add(item);

                if (lstData.Count > 0 && rbtNaewon.Checked == true)
                {
                    if (SaveGrid(lstData))
                    {
                        //조회
                        QueryData();
                    }
                }
                else
                {
                    if (SaveGrid_Action(lstData))
                    {
                        //조회
                        QueryData();
                    }
                }
            }            
            
        }

        private bool SaveGrid_Action(List<NUR2001U04SaveLayoutInfo> saveLayoutLst)
        {
            NUR2001U04SavebtnActionArgs args = new NUR2001U04SavebtnActionArgs();
            args.HospCode = UserInfo.HospCode;
            args.UserId = UserInfo.UserID;
            args.SaveLayoutItem = saveLayoutLst;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, NUR2001U04SavebtnActionArgs>(args);

            return res.ExecutionStatus == ExecutionStatus.Success && res.Result;
        }

        private bool SyncPatientMisa()
        {
            Service.WriteLog("Misa:" + UserInfo.MisaIp + "/" + UserInfo.MisaInstanceName);
            IMisaSyncDao misaSyncDao = DataAccess.Misa.MisaSyncDao;
            //DateTime currentDate = DateTime.ParseExact(dtpNaewonDate.GetDataValue(), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime currentDate = DateTime.ParseExact(grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);

            List<PatientMisa> lstPatient = null;
            try
            {
                lstPatient = misaSyncDao.GetPatientMisa(currentDate);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("A network-related or instance-specific error"))
                {
                    XMessageBox.Show(Resources.MSG036_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (lstPatient != null && lstPatient.Count > 0)
            {
                OUT0101U02SaveGridArgs args = new OUT0101U02SaveGridArgs();
                args.PatientList = CreatePatientInfoListFromGrid(lstPatient);
                args.UserId = UserInfo.UserID;
                args.AutoBunhoFlg = "";
                args.HospCode = UserInfo.HospCode;
                args.PatientCode = "";

                OUT0101U02SaveGridResult updateResult = CloudService.Instance.Submit<OUT0101U02SaveGridResult, OUT0101U02SaveGridArgs>(args);
                Service.WriteLog("Misa Sync Patient Result :" + updateResult.Result);
            }

            return true;

        }

        private List<NuroOUT0101U02GridPatientInfo> CreatePatientInfoListFromGrid(List<PatientMisa> lstPatient)
        {

            List<NuroOUT0101U02GridPatientInfo> patientInfoList = new List<NuroOUT0101U02GridPatientInfo>();
            foreach (PatientMisa item in lstPatient)
            {
                NuroOUT0101U02GridPatientInfo patientInfo = new NuroOUT0101U02GridPatientInfo();
                patientInfo.Bunho = item.AccountObjectCode;
                patientInfo.Suname = item.AccountObjectName;
                patientInfo.Sex = "C";
                patientInfo.Birth = "";
                patientInfo.ZipCode1 = "";
                patientInfo.ZipCode2 = "";
                patientInfo.Address1 = "";
                patientInfo.Address2 = item.Address;
                patientInfo.Tel = item.Tel;
                patientInfo.Tel1 = item.Mobile;
                patientInfo.Type = "";
                patientInfo.TelHp = item.Fax;
                patientInfo.Email = item.EmailAddress;
                patientInfo.Suname2 = item.AccountObjectName;
                patientInfo.TelType = "1";
                patientInfo.TelType2 = "2";
                patientInfo.TelType3 = "3";
                patientInfo.DeleteYn = "N";
                patientInfo.PaceMakerYn = "N";
                patientInfo.SelfPaceMaker = "N";
                patientInfo.PatientType = "0";
                patientInfo.IuGubun = "";
                patientInfo.RefId = "";
                // https://sofiamedix.atlassian.net/browse/MED-9472
                //patientInfo.Pass = "";
                patientInfo.Pass = Utility.RandomString(8);
                patientInfoList.Add(patientInfo);

            }
            return patientInfoList;
        }

        private void SyncBookingMisa()
        {
            IMisaSyncDao misaSyncDao = DataAccess.Misa.MisaSyncDao;
            //DateTime currentDate = DateTime.ParseExact(dtpNaewonDate.GetDataValue(), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime currentDate = DateTime.ParseExact(grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "last_naewon"), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);

            List<BookingMisa> lstBooking = null;
            try
            {
                lstBooking = misaSyncDao.GetBookingMisa(currentDate);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("A network-related or instance-specific error"))
                {
                    XMessageBox.Show(Resources.MSG036_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                    return;
                }
            }

            if (lstBooking != null && lstBooking.Count > 0)
            {
                UpdateJubsuDataArgs dataArgs = new UpdateJubsuDataArgs();
                dataArgs.DataInfo = CreateJubsuDataInfo(lstBooking);
                dataArgs.IsOrca = false;
                dataArgs.OrcaGigwanCode = "";
                UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, UpdateJubsuDataArgs>(dataArgs);
                if (updateResult != null && "17".Equals(updateResult.Msg))
                {
                    XMessageBox.Show(Resources.MSG037_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                    return;
                }
                Service.WriteLog("Misa Sync Booking Result :" + updateResult.Result);
            }
        }

        private List<UpdateJubsuDataInfo> CreateJubsuDataInfo(List<BookingMisa> lstBooking)
        {
            List<UpdateJubsuDataInfo> lstUpdateJubsuDataInfo = new List<UpdateJubsuDataInfo>();
            foreach (BookingMisa item in lstBooking)
            {
                UpdateJubsuDataInfo dataInfo = new UpdateJubsuDataInfo();
                dataInfo.SysId = item.ModififiedBy;
                dataInfo.UpdId = item.ModififiedBy;
                dataInfo.DepartmentCode = item.EmployeeCode;
                dataInfo.DepartmentName = "";
                dataInfo.DoctorCode = item.EmployeeCode;
                dataInfo.DoctorName = "";
                dataInfo.ExamStatus = item.AccountObjectCode;
                dataInfo.ReceptionNo = "";
                dataInfo.InsurCode = "";
                dataInfo.InsurName = "";
                dataInfo.PatientCode = item.AccountObjectCode;
                dataInfo.ComingDate = item.RefDate.ToString("yyyy/MM/dd");
                dataInfo.Pkout1001 = "";
                dataInfo.ReceptionTime = item.CreateDate.Hour.ToString("00") + item.CreateDate.Minute.ToString("00");
                dataInfo.ComingStatus = "Y";
                dataInfo.ComingType = "0";
                dataInfo.SunnabStatus = "";
                dataInfo.Fkinp1001 = "";
                dataInfo.ReceptionType = item.InventoryCode;
                dataInfo.InpTransStatus = "";
                dataInfo.Bigo = "";
                dataInfo.InsurCode1 = "";
                dataInfo.InsurCode2 = "";
                dataInfo.InsurCode3 = "";
                dataInfo.InsurCode4 = "";
                dataInfo.Priority1 = "";
                dataInfo.Priority2 = "";
                dataInfo.Priority3 = "";
                dataInfo.Priority4 = "";
                dataInfo.SujinNo = "";
                dataInfo.WonyoiOrderStatus = "";
                dataInfo.ReserStatus = "";
                dataInfo.Button = "";
                dataInfo.CheckComing = "Y";
                dataInfo.ArriveTime = item.CreateDate.Hour.ToString("00") + item.CreateDate.Minute.ToString("00");
                dataInfo.GroupKey = "";
                dataInfo.ReceptRefId = item.BrandID;
                lstUpdateJubsuDataInfo.Add(dataInfo);
            }
            return lstUpdateJubsuDataInfo;
        }

        private void dtpToDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (mQueryFlag)
                QueryData();

            DateTime fromDate = Convert.ToDateTime(dtpNaewonDate.GetDataValue());
            DateTime toDate = Convert.ToDateTime(dtpToDate.GetDataValue());

            int compare = DateTime.Compare(fromDate, toDate);
            if (compare > 0)
            {
                dtpToDate.SetDataValue(DateTime.Now);
            }
        }
    }
}

