using System;
using System.Collections.Generic;
using System.Text;
using IHIS.Framework;
using System.Windows.Forms;

namespace IHIS.NURO
{
    public partial class RES1001U00
    {
        #region [소멸자]
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

        #region [자동생성]
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel1;
        private System.Windows.Forms.Panel panel1;
        private IHIS.Framework.XCalendar calSchedule;
        private System.Windows.Forms.Panel panel3;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel6;
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
        private IHIS.Framework.XEditGrid grdOUT1001_PM;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.MultiLayout layPlan_time;
        private IHIS.Framework.XPanel pnlPatient;
        private IHIS.Framework.XPanel pnlDoctor;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XComboBox cboGwa;
        private IHIS.Framework.XEditGrid grdOUT1001_AM;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.MultiLayout layOCS0105;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGrid grdDeleteOUT1001;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XEditGridCell xEditGridCell42;
        private IHIS.Framework.XEditGridCell xEditGridCell43;
        private IHIS.Framework.XEditGridCell xEditGridCell44;
        private IHIS.Framework.XEditGridCell xEditGridCell45;
        private IHIS.Framework.XEditGridCell xEditGridCell46;
        private IHIS.Framework.XEditGridCell xEditGridCell47;
        private IHIS.Framework.XEditGridCell xEditGridCell48;
        private IHIS.Framework.XEditGridCell xEditGridCell49;
        private IHIS.Framework.XEditGridCell xEditGridCell50;
        private IHIS.Framework.XEditGridCell xEditGridCell51;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
        private IHIS.Framework.XEditGridCell xEditGridCell53;
        private IHIS.Framework.XEditGridCell xEditGridCell54;
        private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
        private IHIS.Framework.XEditGridCell xEditGridCell57;
        private System.Windows.Forms.DataGrid grdReserList1;
        private IHIS.Framework.MultiLayout layReserList;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private IHIS.Framework.XFindBox fbxDoctor;
        private IHIS.Framework.XDisplayBox dbxDoctor_name;
        private IHIS.Framework.XButton btnNUR1001R09;
        private IHIS.Framework.XPanel pnlBtn;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private SingleLayout layCommon;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private XButton btnClear;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private XGrid grdReserList;
        private XEditGrid xGrid1;
        private XEditGridCell xGridCell1;
        private XEditGridCell xGridCell2;
        private XEditGridCell xGridCell3;
        private XEditGridCell xGridCell4;
        private XButton btnReserOrder;
        private MultiLayout layReseredData;
        private Splitter splitter1;
        private XLabel xLabel3;
        private XTextBox txtUser;
        private XDisplayBox dbxUserName;
        private SingleLayout layUserName;
        private SingleLayoutItem singleLayoutItem1;
        private XButton btnClear2;
        private XEditGridCell xGridCell6;
        private XEditGridCell xGridCell7;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell74;
        private XButton btnPABunho;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RES1001U00));
            this.pnlPatient = new IHIS.Framework.XPanel();
            this.btnPABunho = new IHIS.Framework.XButton();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.pnlBtn = new IHIS.Framework.XPanel();
            this.btnReserOrder = new IHIS.Framework.XButton();
            this.btnNUR1001R09 = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdDeleteOUT1001 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.pnlDoctor = new IHIS.Framework.XPanel();
            this.dbxLinkHospName = new IHIS.Framework.XDisplayBox();
            this.fbxLinkHospCode = new IHIS.Framework.XFindBox();
            this.fwkLinkHospCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.rbtLinkClinic = new System.Windows.Forms.RadioButton();
            this.rbtMyClinic = new System.Windows.Forms.RadioButton();
            this.btnClear2 = new IHIS.Framework.XButton();
            this.dbxUserName = new IHIS.Framework.XDisplayBox();
            this.txtUser = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.btnClear = new IHIS.Framework.XButton();
            this.dbxDoctor_name = new IHIS.Framework.XDisplayBox();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.cboGwa = new IHIS.Framework.XComboBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xGrid1 = new IHIS.Framework.XEditGrid();
            this.xGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.grdReserList1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.calSchedule = new IHIS.Framework.XCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdOUT1001_AM = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdOUT1001_PM = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.layPlan_time = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.layOCS0105 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.layReserList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.layReseredData = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layUserName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.pnlPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDeleteOUT1001)).BeginInit();
            this.pnlDoctor.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReserList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001_AM)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001_PM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPlan_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReseredData)).BeginInit();
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
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "");
            this.ImageList.Images.SetKeyName(9, "행삭제.gif");
            this.ImageList.Images.SetKeyName(10, "이름바꾸기.gif");
            this.ImageList.Images.SetKeyName(11, "타과의뢰.gif");
            this.ImageList.Images.SetKeyName(12, "입원처방.ico");
            this.ImageList.Images.SetKeyName(13, "환자조회.gif");
            this.ImageList.Images.SetKeyName(14, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(15, "YESUP1.ICO");
            // 
            // pnlPatient
            // 
            this.pnlPatient.AccessibleDescription = null;
            this.pnlPatient.AccessibleName = null;
            resources.ApplyResources(this.pnlPatient, "pnlPatient");
            this.pnlPatient.BackgroundImage = null;
            this.pnlPatient.Controls.Add(this.btnPABunho);
            this.pnlPatient.Controls.Add(this.paBox);
            this.pnlPatient.Font = null;
            this.pnlPatient.Name = "pnlPatient";
            // 
            // btnPABunho
            // 
            this.btnPABunho.AccessibleDescription = null;
            this.btnPABunho.AccessibleName = null;
            resources.ApplyResources(this.btnPABunho, "btnPABunho");
            this.btnPABunho.BackgroundImage = null;
            this.btnPABunho.ImageIndex = 13;
            this.btnPABunho.ImageList = this.ImageList;
            this.btnPABunho.Name = "btnPABunho";
            this.btnPABunho.Click += new System.EventHandler(this.btnPABunho_Click);
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackgroundImage = null;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.pnlBtn);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.xPanel2_Paint);
            // 
            // pnlBtn
            // 
            this.pnlBtn.AccessibleDescription = null;
            this.pnlBtn.AccessibleName = null;
            resources.ApplyResources(this.pnlBtn, "pnlBtn");
            this.pnlBtn.BackgroundImage = null;
            this.pnlBtn.Controls.Add(this.btnReserOrder);
            this.pnlBtn.Controls.Add(this.btnNUR1001R09);
            this.pnlBtn.Font = null;
            this.pnlBtn.Name = "pnlBtn";
            // 
            // btnReserOrder
            // 
            this.btnReserOrder.AccessibleDescription = null;
            this.btnReserOrder.AccessibleName = null;
            resources.ApplyResources(this.btnReserOrder, "btnReserOrder");
            this.btnReserOrder.BackgroundImage = null;
            this.btnReserOrder.ImageIndex = 10;
            this.btnReserOrder.ImageList = this.ImageList;
            this.btnReserOrder.Name = "btnReserOrder";
            this.btnReserOrder.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReserOrder.Click += new System.EventHandler(this.btnReserOrder_Click);
            // 
            // btnNUR1001R09
            // 
            this.btnNUR1001R09.AccessibleDescription = null;
            this.btnNUR1001R09.AccessibleName = null;
            resources.ApplyResources(this.btnNUR1001R09, "btnNUR1001R09");
            this.btnNUR1001R09.BackgroundImage = null;
            this.btnNUR1001R09.ImageIndex = 8;
            this.btnNUR1001R09.ImageList = this.ImageList;
            this.btnNUR1001R09.Name = "btnNUR1001R09";
            this.btnNUR1001R09.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnNUR1001R09.Click += new System.EventHandler(this.btnNUR1001R09_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdDeleteOUT1001
            // 
            resources.ApplyResources(this.grdDeleteOUT1001, "grdDeleteOUT1001");
            this.grdDeleteOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell57,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell77,
            this.xEditGridCell83});
            this.grdDeleteOUT1001.ColPerLine = 10;
            this.grdDeleteOUT1001.Cols = 11;
            this.grdDeleteOUT1001.ExecuteQuery = null;
            this.grdDeleteOUT1001.FixedCols = 1;
            this.grdDeleteOUT1001.FixedRows = 1;
            this.grdDeleteOUT1001.HeaderHeights.Add(22);
            this.grdDeleteOUT1001.Name = "grdDeleteOUT1001";
            this.grdDeleteOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDeleteOUT1001.ParamList")));
            this.grdDeleteOUT1001.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdDeleteOUT1001.RowHeaderVisible = true;
            this.grdDeleteOUT1001.Rows = 2;
            this.grdDeleteOUT1001.Tag = "0900";
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "jinryo_pre_time";
            this.xEditGridCell35.Col = 2;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.Mask = "##:##";
            this.xEditGridCell35.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 9;
            this.xEditGridCell36.CellName = "bunho";
            this.xEditGridCell36.CellWidth = 86;
            this.xEditGridCell36.Col = 3;
            this.xEditGridCell36.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsNotNull = true;
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdatable = false;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "suname";
            this.xEditGridCell37.Col = 5;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdatable = false;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "suname2";
            this.xEditGridCell38.CellWidth = 131;
            this.xEditGridCell38.Col = 4;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdatable = false;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "chojae";
            this.xEditGridCell39.CellWidth = 57;
            this.xEditGridCell39.Col = 6;
            this.xEditGridCell39.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdatable = false;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "reser_date";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell40.CellWidth = 91;
            this.xEditGridCell40.Col = 8;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdatable = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "pkout1001";
            this.xEditGridCell41.Col = 1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdatable = false;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "jinryo_pre_date";
            this.xEditGridCell42.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsUpdatable = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "gwa";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsUpdatable = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "seq";
            this.xEditGridCell44.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsUpdatable = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "gubun";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsUpdatable = false;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "doctor";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "res_gubun";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsUpdatable = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "changgu";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "input_gubun";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 1;
            this.xEditGridCell49.CellName = "naewon_yn";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellLen = 1;
            this.xEditGridCell50.CellName = "newrow";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell51.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell51.ButtonImage")));
            this.xEditGridCell51.CellName = "modify";
            this.xEditGridCell51.CellWidth = 68;
            this.xEditGridCell51.Col = 7;
            this.xEditGridCell51.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsUpdCol = false;
            this.xEditGridCell51.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "reser_comment";
            this.xEditGridCell77.Col = 9;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "reser_gubun";
            this.xEditGridCell83.Col = 10;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            // 
            // pnlDoctor
            // 
            this.pnlDoctor.AccessibleDescription = null;
            this.pnlDoctor.AccessibleName = null;
            resources.ApplyResources(this.pnlDoctor, "pnlDoctor");
            this.pnlDoctor.Controls.Add(this.dbxLinkHospName);
            this.pnlDoctor.Controls.Add(this.fbxLinkHospCode);
            this.pnlDoctor.Controls.Add(this.xLabel4);
            this.pnlDoctor.Controls.Add(this.rbtLinkClinic);
            this.pnlDoctor.Controls.Add(this.rbtMyClinic);
            this.pnlDoctor.Controls.Add(this.btnClear2);
            this.pnlDoctor.Controls.Add(this.dbxUserName);
            this.pnlDoctor.Controls.Add(this.txtUser);
            this.pnlDoctor.Controls.Add(this.xLabel3);
            this.pnlDoctor.Controls.Add(this.btnClear);
            this.pnlDoctor.Controls.Add(this.dbxDoctor_name);
            this.pnlDoctor.Controls.Add(this.fbxDoctor);
            this.pnlDoctor.Controls.Add(this.cboGwa);
            this.pnlDoctor.Controls.Add(this.xLabel6);
            this.pnlDoctor.Controls.Add(this.xLabel5);
            this.pnlDoctor.Font = null;
            this.pnlDoctor.Name = "pnlDoctor";
            // 
            // dbxLinkHospName
            // 
            this.dbxLinkHospName.AccessibleDescription = null;
            this.dbxLinkHospName.AccessibleName = null;
            resources.ApplyResources(this.dbxLinkHospName, "dbxLinkHospName");
            this.dbxLinkHospName.EdgeRounding = false;
            this.dbxLinkHospName.Image = null;
            this.dbxLinkHospName.Name = "dbxLinkHospName";
            // 
            // fbxLinkHospCode
            // 
            this.fbxLinkHospCode.AccessibleDescription = null;
            this.fbxLinkHospCode.AccessibleName = null;
            resources.ApplyResources(this.fbxLinkHospCode, "fbxLinkHospCode");
            this.fbxLinkHospCode.BackgroundImage = null;
            this.fbxLinkHospCode.FindWorker = this.fwkLinkHospCode;
            this.fbxLinkHospCode.Name = "fbxLinkHospCode";
            this.fbxLinkHospCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxLinkHospCode_DataValidating);
            this.fbxLinkHospCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxLinkHospCode_FindClick);
            // 
            // fwkLinkHospCode
            // 
            this.fwkLinkHospCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2,
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkLinkHospCode.ExecuteQuery = null;
            this.fwkLinkHospCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkLinkHospCode.ParamList")));
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "hosp_code";
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "hosp_name";
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "address";
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "tel";
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
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
            // rbtLinkClinic
            // 
            this.rbtLinkClinic.AccessibleDescription = null;
            this.rbtLinkClinic.AccessibleName = null;
            resources.ApplyResources(this.rbtLinkClinic, "rbtLinkClinic");
            this.rbtLinkClinic.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtLinkClinic.BackgroundImage = null;
            this.rbtLinkClinic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtLinkClinic.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtLinkClinic.ImageList = this.ImageList;
            this.rbtLinkClinic.Name = "rbtLinkClinic";
            this.rbtLinkClinic.UseVisualStyleBackColor = false;
            this.rbtLinkClinic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rbtLinkClinic_MouseDown);
            this.rbtLinkClinic.CheckedChanged += new System.EventHandler(this.rbtLinkClinic_CheckedChanged);
            // 
            // rbtMyClinic
            // 
            this.rbtMyClinic.AccessibleDescription = null;
            this.rbtMyClinic.AccessibleName = null;
            resources.ApplyResources(this.rbtMyClinic, "rbtMyClinic");
            this.rbtMyClinic.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtMyClinic.BackgroundImage = null;
            this.rbtMyClinic.Checked = true;
            this.rbtMyClinic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtMyClinic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbtMyClinic.ImageList = this.ImageList;
            this.rbtMyClinic.Name = "rbtMyClinic";
            this.rbtMyClinic.TabStop = true;
            this.rbtMyClinic.UseVisualStyleBackColor = false;
            this.rbtMyClinic.CheckedChanged += new System.EventHandler(this.rbtMyClinic_CheckedChanged);
            // 
            // btnClear2
            // 
            this.btnClear2.AccessibleDescription = null;
            this.btnClear2.AccessibleName = null;
            resources.ApplyResources(this.btnClear2, "btnClear2");
            this.btnClear2.BackgroundImage = null;
            this.btnClear2.ImageIndex = 9;
            this.btnClear2.ImageList = this.ImageList;
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Click += new System.EventHandler(this.btnClear2_Click);
            // 
            // dbxUserName
            // 
            this.dbxUserName.AccessibleDescription = null;
            this.dbxUserName.AccessibleName = null;
            resources.ApplyResources(this.dbxUserName, "dbxUserName");
            this.dbxUserName.EdgeRounding = false;
            this.dbxUserName.Image = null;
            this.dbxUserName.Name = "dbxUserName";
            this.dbxUserName.Click += new System.EventHandler(this.dbxUserName_Click);
            // 
            // txtUser
            // 
            this.txtUser.AccessibleDescription = null;
            this.txtUser.AccessibleName = null;
            resources.ApplyResources(this.txtUser, "txtUser");
            this.txtUser.BackgroundImage = null;
            this.txtUser.Name = "txtUser";
            this.txtUser.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtUser_DataValidating);
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // btnClear
            // 
            this.btnClear.AccessibleDescription = null;
            this.btnClear.AccessibleName = null;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.BackgroundImage = null;
            this.btnClear.ImageIndex = 9;
            this.btnClear.ImageList = this.ImageList;
            this.btnClear.Name = "btnClear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dbxDoctor_name
            // 
            this.dbxDoctor_name.AccessibleDescription = null;
            this.dbxDoctor_name.AccessibleName = null;
            resources.ApplyResources(this.dbxDoctor_name, "dbxDoctor_name");
            this.dbxDoctor_name.EdgeRounding = false;
            this.dbxDoctor_name.Image = null;
            this.dbxDoctor_name.Name = "dbxDoctor_name";
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.AccessibleDescription = null;
            this.fbxDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxDoctor, "fbxDoctor");
            this.fbxDoctor.BackgroundImage = null;
            this.fbxDoctor.EnableEdit = false;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.ReadOnly = true;
            this.fbxDoctor.TabStop = false;
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDoctor_FindClick);
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
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
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xGrid1);
            this.xPanel1.Controls.Add(this.grdReserList1);
            this.xPanel1.Controls.Add(this.calSchedule);
            this.xPanel1.Controls.Add(this.grdDeleteOUT1001);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xGrid1
            // 
            resources.ApplyResources(this.xGrid1, "xGrid1");
            this.xGrid1.ApplyPaintEventToAllColumn = true;
            this.xGrid1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell6,
            this.xGridCell7,
            this.xEditGridCell60,
            this.xEditGridCell62,
            this.xEditGridCell65,
            this.xEditGridCell64,
            this.xEditGridCell67,
            this.xEditGridCell70,
            this.xEditGridCell78,
            this.xEditGridCell85,
            this.xEditGridCell88,
            this.xEditGridCell61,
            this.xEditGridCell84});
            this.xGrid1.ColPerLine = 8;
            this.xGrid1.Cols = 8;
            this.xGrid1.ExecuteQuery = null;
            this.xGrid1.FixedRows = 1;
            this.xGrid1.HeaderHeights.Add(35);
            this.xGrid1.Name = "xGrid1";
            this.xGrid1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("xGrid1.ParamList")));
            this.xGrid1.QuerySQL = resources.GetString("xGrid1.QuerySQL");
            this.xGrid1.Rows = 2;
            this.xGrid1.ToolTipActive = true;
            this.xGrid1.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.xGrid1_GridButtonClick);
            this.xGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xGrid1_MouseDown);
            this.xGrid1.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.xGrid1_RowFocusChanged);
            this.xGrid1.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.xGrid1_GridCellPainting);
            this.xGrid1.PreEndInitializing += new System.EventHandler(this.xGrid1_PreEndInitializing);
            this.xGrid1.QueryStarting += new System.ComponentModel.CancelEventHandler(this.xGrid1_QueryStarting);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "jinryo_pre_date";
            this.xGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell1.CellWidth = 97;
            this.xGridCell1.Col = 1;
            this.xGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.IsReadOnly = true;
            this.xGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "jinryo_pre_time";
            this.xGridCell2.CellWidth = 115;
            this.xGridCell2.Col = 2;
            this.xGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.IsReadOnly = true;
            this.xGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "gwa_name";
            this.xGridCell3.CellWidth = 115;
            this.xGridCell3.Col = 3;
            this.xGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            this.xGridCell3.IsReadOnly = true;
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "doctor_name";
            this.xGridCell4.CellWidth = 120;
            this.xGridCell4.Col = 4;
            this.xGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.IsReadOnly = true;
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "pkout1001";
            this.xGridCell6.Col = -1;
            this.xGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell6, "xGridCell6");
            this.xGridCell6.IsReadOnly = true;
            this.xGridCell6.IsVisible = false;
            this.xGridCell6.Row = -1;
            // 
            // xGridCell7
            // 
            this.xGridCell7.CellName = "naewon_yn";
            this.xGridCell7.Col = -1;
            this.xGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell7, "xGridCell7");
            this.xGridCell7.IsReadOnly = true;
            this.xGridCell7.IsVisible = false;
            this.xGridCell7.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "bunho";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "gwa";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "doctor";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "jinryo_irai_yn";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "irai_date";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "res_user";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "reser_comment";
            this.xEditGridCell78.CellWidth = 0;
            this.xEditGridCell78.Col = 5;
            this.xEditGridCell78.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xEditGridCell78.IsReadOnly = true;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "reser_gubun";
            this.xEditGridCell85.CellWidth = 0;
            this.xEditGridCell85.Col = 7;
            this.xEditGridCell85.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "clinic_name";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.ButtonImage = global::IHIS.NURO.Properties.Resources.삭제;
            this.xEditGridCell61.ButtonScheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xEditGridCell61.CellName = "button";
            this.xEditGridCell61.CellWidth = 23;
            this.xEditGridCell61.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.ButtonImage = global::IHIS.NURO.Properties.Resources.입력;
            this.xEditGridCell84.CellName = "reser_button";
            this.xEditGridCell84.CellWidth = 0;
            this.xEditGridCell84.Col = 6;
            this.xEditGridCell84.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            // 
            // grdReserList1
            // 
            this.grdReserList1.AccessibleDescription = null;
            this.grdReserList1.AccessibleName = null;
            resources.ApplyResources(this.grdReserList1, "grdReserList1");
            this.grdReserList1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdReserList1.BackgroundImage = null;
            this.grdReserList1.CaptionFont = null;
            this.grdReserList1.CaptionVisible = false;
            this.grdReserList1.ColumnHeadersVisible = false;
            this.grdReserList1.DataMember = "";
            this.grdReserList1.Font = null;
            this.grdReserList1.GridLineColor = System.Drawing.SystemColors.Window;
            this.grdReserList1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdReserList1.Name = "grdReserList1";
            this.grdReserList1.ReadOnly = true;
            this.grdReserList1.RowHeadersVisible = false;
            this.grdReserList1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.ColumnHeadersVisible = false;
            this.dataGridTableStyle1.DataGrid = this.grdReserList1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle1.HeaderFont = null;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "reslist";
            resources.ApplyResources(this.dataGridTableStyle1, "dataGridTableStyle1");
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeadersVisible = false;
            // 
            // dataGridTextBoxColumn1
            // 
            resources.ApplyResources(this.dataGridTextBoxColumn1, "dataGridTextBoxColumn1");
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn2
            // 
            resources.ApplyResources(this.dataGridTextBoxColumn2, "dataGridTextBoxColumn2");
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn3
            // 
            resources.ApplyResources(this.dataGridTextBoxColumn3, "dataGridTextBoxColumn3");
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridTextBoxColumn4
            // 
            resources.ApplyResources(this.dataGridTextBoxColumn4, "dataGridTextBoxColumn4");
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.ReadOnly = true;
            // 
            // calSchedule
            // 
            this.calSchedule.AccessibleDescription = null;
            this.calSchedule.AccessibleName = null;
            resources.ApplyResources(this.calSchedule, "calSchedule");
            this.calSchedule.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.calSchedule.EnableMultiSelection = false;
            this.calSchedule.Footer.ShowToday = false;
            this.calSchedule.FullHolidaySelectable = true;
            this.calSchedule.Header.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calSchedule.ImageList = this.ImageList;
            this.calSchedule.MaxDate = new System.DateTime(2030, 1, 11, 0, 0, 0, 0);
            this.calSchedule.MinDate = new System.DateTime(1996, 1, 11, 0, 0, 0, 0);
            this.calSchedule.Name = "calSchedule";
            this.calSchedule.ShowFooter = false;
            this.calSchedule.ToggleSelection = true;
            this.calSchedule.DaySelected += new IHIS.Framework.XCalendarDaySelectedEventHandler(this.calSchedule_DaySelected);
            this.calSchedule.DayClick += new IHIS.Framework.XCalendarDayClickEventHandler(this.calSchedule_DayClick);
            this.calSchedule.MonthChanged += new IHIS.Framework.XCalendarMonthChangedEventHandler(this.calSchedule_MonthChanged);
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.grdOUT1001_AM);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // grdOUT1001_AM
            // 
            resources.ApplyResources(this.grdOUT1001_AM, "grdOUT1001_AM");
            this.grdOUT1001_AM.ApplyPaintEventToAllColumn = true;
            this.grdOUT1001_AM.CallerID = '2';
            this.grdOUT1001_AM.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell25,
            this.xEditGridCell29,
            this.xEditGridCell53,
            this.xEditGridCell31,
            this.xEditGridCell54,
            this.xEditGridCell58,
            this.xEditGridCell63,
            this.xEditGridCell68,
            this.xEditGridCell55,
            this.xEditGridCell71,
            this.xEditGridCell73,
            this.xEditGridCell75,
            this.xEditGridCell79,
            this.xEditGridCell81,
            this.xEditGridCell86});
            this.grdOUT1001_AM.ColPerLine = 12;
            this.grdOUT1001_AM.Cols = 13;
            this.grdOUT1001_AM.ExecuteQuery = null;
            this.grdOUT1001_AM.FixedCols = 1;
            this.grdOUT1001_AM.FixedRows = 1;
            this.grdOUT1001_AM.HeaderHeights.Add(31);
            this.grdOUT1001_AM.Name = "grdOUT1001_AM";
            this.grdOUT1001_AM.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT1001_AM.ParamList")));
            this.grdOUT1001_AM.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOUT1001_AM.RowHeaderVisible = true;
            this.grdOUT1001_AM.Rows = 2;
            this.grdOUT1001_AM.Tag = "0900";
            this.grdOUT1001_AM.ToolTipActive = true;
            this.grdOUT1001_AM.MouseLeave += new System.EventHandler(this.grd_MouseLeave);
            this.grdOUT1001_AM.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdRES1001_AM_GiveFeedback);
            this.grdOUT1001_AM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdOUT1001_AM.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdRES1001_AM_GridButtonClick);
            this.grdOUT1001_AM.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdRES1001_AM_GridColumnChanged);
            this.grdOUT1001_AM.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdRES1001_AMPM_QueryEnd);
            this.grdOUT1001_AM.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdRES1001_AM_DragEnter);
            this.grdOUT1001_AM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdOUT1001_AM.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdRES1001_AM_DragDrop);
            this.grdOUT1001_AM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grd_MouseMove);
            this.grdOUT1001_AM.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdRES1001_AM_GridCellPainting);
            this.grdOUT1001_AM.PreEndInitializing += new System.EventHandler(this.grdOUT1001_AM_PreEndInitializing);
            this.grdOUT1001_AM.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdRES1001_AM_GridColumnProtectModify);
            this.grdOUT1001_AM.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRES1001_AMPM_QueryStarting2);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "jinryo_pre_time";
            this.xEditGridCell1.CellWidth = 112;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.Mask = "##:##";
            this.xEditGridCell1.SuppressRepeating = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 9;
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 73;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.CellWidth = 115;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname2";
            this.xEditGridCell4.CellWidth = 117;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "chojae";
            this.xEditGridCell5.CellWidth = 0;
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "reser_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 76;
            this.xEditGridCell6.Col = 12;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "pkout1001";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jinryo_pre_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gwa";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "seq";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "gubun";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "doctor";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "res_gubun";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "changgu";
            this.xEditGridCell29.CellWidth = 94;
            this.xEditGridCell29.Col = 11;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdatable = false;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "input_gubun";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsUpdatable = false;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 1;
            this.xEditGridCell31.CellName = "naewon_yn";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "newrow";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "jinryo_yn";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsUpdatable = false;
            this.xEditGridCell58.IsUpdCol = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "jinryo_irai_yn";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "res_user";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell55.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell55.ButtonImage")));
            this.xEditGridCell55.CellName = "modify";
            this.xEditGridCell55.CellWidth = 0;
            this.xEditGridCell55.Col = 7;
            this.xEditGridCell55.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsUpdCol = false;
            this.xEditGridCell55.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "ipwon_image";
            this.xEditGridCell71.CellWidth = 0;
            this.xEditGridCell71.Col = 1;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsReadOnly = true;
            this.xEditGridCell71.IsUpdatable = false;
            this.xEditGridCell71.IsUpdCol = false;
            this.xEditGridCell71.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "ipwon_yn";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.IsUpdCol = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "reser_comment";
            this.xEditGridCell75.CellWidth = 0;
            this.xEditGridCell75.Col = 8;
            this.xEditGridCell75.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xEditGridCell75.IsReadOnly = true;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.ButtonImage = global::IHIS.NURO.Properties.Resources.입력;
            this.xEditGridCell79.CellName = "comment_button";
            this.xEditGridCell79.CellWidth = 0;
            this.xEditGridCell79.Col = 9;
            this.xEditGridCell79.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "reser_gubun";
            this.xEditGridCell81.CellWidth = 76;
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            this.xEditGridCell81.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "clinic_name";
            this.xEditGridCell86.Col = 10;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel1.Name = "xLabel1";
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 1;
            this.xEditGridCell33.CellName = "newrow";
            this.xEditGridCell33.Col = 8;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell27.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell27.ButtonImage")));
            this.xEditGridCell27.CellName = "modify";
            this.xEditGridCell27.CellWidth = 68;
            this.xEditGridCell27.Col = 6;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.AccessibleDescription = null;
            this.panel3.AccessibleName = null;
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackgroundImage = null;
            this.panel3.Controls.Add(this.grdOUT1001_PM);
            this.panel3.Controls.Add(this.xLabel2);
            this.panel3.Font = null;
            this.panel3.Name = "panel3";
            // 
            // grdOUT1001_PM
            // 
            resources.ApplyResources(this.grdOUT1001_PM, "grdOUT1001_PM");
            this.grdOUT1001_PM.ApplyPaintEventToAllColumn = true;
            this.grdOUT1001_PM.CallerID = '3';
            this.grdOUT1001_PM.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell26,
            this.xEditGridCell30,
            this.xEditGridCell56,
            this.xEditGridCell32,
            this.xEditGridCell34,
            this.xEditGridCell59,
            this.xEditGridCell66,
            this.xEditGridCell69,
            this.xEditGridCell28,
            this.xEditGridCell72,
            this.xEditGridCell74,
            this.xEditGridCell76,
            this.xEditGridCell80,
            this.xEditGridCell82,
            this.xEditGridCell87});
            this.grdOUT1001_PM.ColPerLine = 12;
            this.grdOUT1001_PM.Cols = 13;
            this.grdOUT1001_PM.ExecuteQuery = null;
            this.grdOUT1001_PM.FixedCols = 1;
            this.grdOUT1001_PM.FixedRows = 1;
            this.grdOUT1001_PM.HeaderHeights.Add(30);
            this.grdOUT1001_PM.Name = "grdOUT1001_PM";
            this.grdOUT1001_PM.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT1001_PM.ParamList")));
            this.grdOUT1001_PM.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOUT1001_PM.RowHeaderVisible = true;
            this.grdOUT1001_PM.Rows = 2;
            this.grdOUT1001_PM.Tag = "1400";
            this.grdOUT1001_PM.ToolTipActive = true;
            this.grdOUT1001_PM.MouseLeave += new System.EventHandler(this.grd_MouseLeave);
            this.grdOUT1001_PM.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdRES1001_PM_GiveFeedback);
            this.grdOUT1001_PM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdOUT1001_PM.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdRES1001_PM_GridButtonClick);
            this.grdOUT1001_PM.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdRES1001_PM_GridColumnChanged);
            this.grdOUT1001_PM.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdRES1001_AMPM_QueryEnd);
            this.grdOUT1001_PM.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdRES1001_PM_DragEnter);
            this.grdOUT1001_PM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdOUT1001_PM.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdRES1001_PM_DragDrop);
            this.grdOUT1001_PM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grd_MouseMove);
            this.grdOUT1001_PM.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdRES1001_PM_GridCellPainting);
            this.grdOUT1001_PM.PreEndInitializing += new System.EventHandler(this.grdOUT1001_PM_PreEndInitializing);
            this.grdOUT1001_PM.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdRES1001_PM_GridColumnProtectModify);
            this.grdOUT1001_PM.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRES1001_AMPM_QueryStarting2);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "jinryo_pre_time";
            this.xEditGridCell13.CellWidth = 109;
            this.xEditGridCell13.Col = 2;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.Mask = "##:##";
            this.xEditGridCell13.SuppressRepeating = true;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "bunho";
            this.xEditGridCell14.CellWidth = 73;
            this.xEditGridCell14.Col = 3;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "suname";
            this.xEditGridCell15.CellWidth = 114;
            this.xEditGridCell15.Col = 4;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdatable = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "suname2";
            this.xEditGridCell16.CellWidth = 116;
            this.xEditGridCell16.Col = 5;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "chojae";
            this.xEditGridCell17.CellWidth = 0;
            this.xEditGridCell17.Col = 6;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdatable = false;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "reser_date";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell18.CellWidth = 74;
            this.xEditGridCell18.Col = 12;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "pkout1001";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "jinryo_pre_date";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "gwa";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "seq";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "gubun";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "doctor";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "res_gubun";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "changgu";
            this.xEditGridCell30.CellWidth = 97;
            this.xEditGridCell30.Col = 11;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdatable = false;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "input_gubun";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellLen = 1;
            this.xEditGridCell32.CellName = "naewon_yn";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellLen = 1;
            this.xEditGridCell34.CellName = "newrow";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "jinryo_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsUpdCol = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "jinryo_irai_yn";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "res_user";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell28.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell28.ButtonImage")));
            this.xEditGridCell28.CellName = "modify";
            this.xEditGridCell28.CellWidth = 0;
            this.xEditGridCell28.Col = 7;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "ipwon_image";
            this.xEditGridCell72.CellWidth = 0;
            this.xEditGridCell72.Col = 1;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            this.xEditGridCell72.IsUpdatable = false;
            this.xEditGridCell72.IsUpdCol = false;
            this.xEditGridCell72.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "ipwon_yn";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsUpdatable = false;
            this.xEditGridCell74.IsUpdCol = false;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "reser_comment";
            this.xEditGridCell76.CellWidth = 0;
            this.xEditGridCell76.Col = 8;
            this.xEditGridCell76.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xEditGridCell76.IsReadOnly = true;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.ButtonImage = global::IHIS.NURO.Properties.Resources.입력;
            this.xEditGridCell80.CellName = "comment_button";
            this.xEditGridCell80.CellWidth = 0;
            this.xEditGridCell80.Col = 9;
            this.xEditGridCell80.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "reser_gubun";
            this.xEditGridCell82.CellWidth = 76;
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            this.xEditGridCell82.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "clinic_name";
            this.xEditGridCell87.Col = 10;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel2.Name = "xLabel2";
            // 
            // layPlan_time
            // 
            this.layPlan_time.ExecuteQuery = null;
            this.layPlan_time.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14});
            this.layPlan_time.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPlan_time.ParamList")));
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "am_start_hhmm";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "am_end_hhmm";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "pm_start_hhmm";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "pm_end_hhmm";
            // 
            // layOCS0105
            // 
            this.layOCS0105.ExecuteQuery = null;
            this.layOCS0105.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem39});
            this.layOCS0105.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS0105.ParamList")));
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "doctor";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "yymm";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "res_date";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "res_flag";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "res_inwon";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "res_outwon";
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "res_gubun";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // layReserList
            // 
            this.layReserList.ExecuteQuery = null;
            this.layReserList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19});
            this.layReserList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserList.ParamList")));
            this.layReserList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layReserList_QueryStarting);
            this.layReserList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layReserList_QueryEnd);
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jinryo_pre_date";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "jinryo_pre_time";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "gwa_name";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "doctor_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "gwa";
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // layReseredData
            // 
            this.layReseredData.ExecuteQuery = null;
            this.layReseredData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
            this.multiLayoutItem61,
            this.multiLayoutItem63});
            this.layReseredData.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReseredData.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "jinryo_pre_time";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "bunho";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "suname";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname2";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "chojae";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "reser_date";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "pkout1001";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "jinryo_pre_date";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "gwa";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "seq";
            this.multiLayoutItem24.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "gubun";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "doctor";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "res_gubun";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "changgu";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "input_gubun";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "naewon_yn";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "newrow";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "jinryo_yn";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "jinryo_irai_yn";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "res_user";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "ipwon_yn";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "reser_comment";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "reser_gubun";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "clinic_name";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "modify";
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // layUserName
            // 
            this.layUserName.ExecuteQuery = null;
            this.layUserName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layUserName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layUserName.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxUserName;
            this.singleLayoutItem1.DataName = "user_name";
            // 
            // RES1001U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlDoctor);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.pnlPatient);
            this.Name = "RES1001U00";
            this.UserChanged += new System.EventHandler(this.RES1001U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.RES1001U00_ScreenOpen);
            this.pnlPatient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.pnlBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDeleteOUT1001)).EndInit();
            this.pnlDoctor.ResumeLayout(false);
            this.pnlDoctor.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReserList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001_AM)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001_PM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPlan_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReseredData)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private RadioButton rbtLinkClinic;
        private RadioButton rbtMyClinic;
        private XDisplayBox dbxLinkHospName;
        private XFindBox fbxLinkHospCode;
        private XLabel xLabel4;
        private XFindWorker fwkLinkHospCode;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem63;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem39;
    }
}
