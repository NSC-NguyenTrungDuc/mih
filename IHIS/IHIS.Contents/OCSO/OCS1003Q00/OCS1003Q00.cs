#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCS;
#endregion

namespace IHIS.OCSO
{
    /// <summary>
    /// OCS1003Q00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS1003Q00 : IHIS.Framework.XScreen
    {
        #region [OCS Library]
        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
        private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
        private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 오더별 컬럼 컨트롤 라이브러리
        #endregion

        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";

        //등록번호
        private string mBunho = "";
        //진료과
        private string mGwa = "";
        //입력구분
        private string mInput_gubun = "";
        //내원일자
        private string mNaewon_date = "";
        //pk_order
        private string mPk_order = "";
        //tel처방여부
        private string mTel_yn = "%";
        //입력오더구분
        private string mInput_tab = "%";

        //Call한 시스템 외래,입원,응급 구분
        private string mIOgubun = "";


        //Data가 없는 경우 화면 닫을지 여부
        private bool mAuto_close = false;

        //신규그룹번호발생여부
        private bool mIsNewGroupSer = true;

        //자식여부
        private string mChildYN = "";

        private IHIS.X.Magic.Menus.PopupMenu popupMenu = new IHIS.X.Magic.Menus.PopupMenu();

        //hospital code
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XMstGrid grdOUT1001;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGrid grdOCS1003;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
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
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XDatePicker dpkNaewon_date;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.MultiLayout dloSelectOCS1003;
        private IHIS.Framework.MultiLayout dloOrder_danui;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell97;
        private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XButton btnProcess;
        private IHIS.Framework.XEditGridCell xEditGridCell127;
        private System.Windows.Forms.CheckBox chkAll;
        private IHIS.Framework.XEditGridCell xEditGridCell128;
        private IHIS.Framework.XEditGridCell xEditGridCell129;
        private IHIS.Framework.XEditGridCell xEditGridCell132;
        private IHIS.Framework.XEditGridCell xEditGridCell133;
        private IHIS.Framework.XEditGridCell xEditGridCell134;
        private IHIS.Framework.XEditGridCell xEditGridCell135;
        private IHIS.Framework.XEditGridCell xEditGridCell136;
        private IHIS.Framework.XEditGridCell xEditGridCell137;
        private System.Windows.Forms.CheckBox chkIsNewGroup;
        private IHIS.Framework.XEditGridCell xEditGridCell139;
        private System.Windows.Forms.ImageList imageListMixGroup;
        private IHIS.Framework.XEditGridCell xEditGridCell140;
        private IHIS.Framework.XEditGridCell xEditGridCell141;
        private IHIS.Framework.XEditGridCell xEditGridCell142;
        private IHIS.Framework.XPanel xPanel6;
        private System.Windows.Forms.RadioButton rbtIn;
        private System.Windows.Forms.RadioButton rbtOut;
        private IHIS.Framework.XEditGridCell xEditGridCell145;
        private IHIS.Framework.XEditGridCell xEditGridCell146;
        private IHIS.Framework.XEditGridCell xEditGridCell147;
        private IHIS.Framework.XEditGridCell xEditGridCell149;
        private IHIS.Framework.XPanel pnlOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell153;
        private IHIS.Framework.XEditGridCell xEditGridCell154;
        private IHIS.Framework.XEditGridCell xEditGridCell155;
        private IHIS.Framework.XEditGridCell xEditGridCell156;
        private IHIS.Framework.XEditGridCell xEditGridCell162;
        private IHIS.Framework.XEditGridCell xEditGridCell163;
        private IHIS.Framework.XEditGridCell xEditGridCell164;
        private IHIS.Framework.XEditGridCell xEditGridCell165;
        private IHIS.Framework.XEditGridCell xEditGridCell166;
        private IHIS.Framework.XEditGridCell xEditGridCell167;
        private IHIS.Framework.XEditGridCell xEditGridCell169;
        private IHIS.Framework.XEditGridCell xEditGridCell170;
        private IHIS.Framework.XEditGridCell xEditGridCell171;
        private IHIS.Framework.XEditGridCell xEditGridCell172;
        private IHIS.Framework.XEditGridCell xEditGridCell173;
        private IHIS.Framework.XEditGridCell xEditGridCell175;
        private IHIS.Framework.XTextBox txtDrg_info;
        private IHIS.Framework.XEditGridCell xEditGridCell176;
        private IHIS.Framework.XEditGridCell xEditGridCell177;
        private IHIS.Framework.XEditGridCell xEditGridCell178;
        private IHIS.Framework.XEditGridCell xEditGridCell180;
        private IHIS.Framework.XEditGridCell xEditGridCell181;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XTabControl tabGroup;
        private MultiLayout dloSelectOUT1001;
        private XPanel xPanel4;
        private XButton btnSelectAll;
        private XEditGridCell xEditGridCell10;
        protected ImageList imageList1;
        private XButton btnDeleteAll;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private System.ComponentModel.IContainer components;

        public OCS1003Q00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.mOrderBiz = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
            this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
            this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리 
            this.mColumnControl = new IHIS.OCS.ColumnControl(this.ScreenID);      // OCS 컬럼 컨트롤 그룹 라이브러리 
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리    합니다.
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1003Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dpkNaewon_date = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.chkIsNewGroup = new System.Windows.Forms.CheckBox();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdOUT1001 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell175 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbtIn = new System.Windows.Forms.RadioButton();
            this.rbtOut = new System.Windows.Forms.RadioButton();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.grdOCS1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell165 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell173 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell169 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell171 = new IHIS.Framework.XEditGridCell();
            this.txtDrg_info = new IHIS.Framework.XTextBox();
            this.xEditGridCell172 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell176 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell177 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell178 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.tabGroup = new IHIS.Framework.XTabControl();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnDeleteAll = new IHIS.Framework.XButton();
            this.btnSelectAll = new IHIS.Framework.XButton();
            this.dloSelectOCS1003 = new IHIS.Framework.MultiLayout();
            this.dloOrder_danui = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.dloSelectOUT1001 = new IHIS.Framework.MultiLayout();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).BeginInit();
            this.xPanel6.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOUT1001)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "+.gif");
            this.ImageList.Images.SetKeyName(5, "_.gif");
            this.ImageList.Images.SetKeyName(6, "오른쪽_회색1.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.dpkNaewon_date);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1089, 30);
            this.xPanel1.TabIndex = 0;
            // 
            // dpkNaewon_date
            // 
            this.dpkNaewon_date.Location = new System.Drawing.Point(110, 6);
            this.dpkNaewon_date.Name = "dpkNaewon_date";
            this.dpkNaewon_date.Size = new System.Drawing.Size(102, 20);
            this.dpkNaewon_date.TabIndex = 5;
            this.dpkNaewon_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkNaewon_date_DataValidating);
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(10, 6);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(98, 19);
            this.xLabel5.TabIndex = 4;
            this.xLabel5.Text = "オ―ダ日付";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.chkIsNewGroup);
            this.xPanel2.Controls.Add(this.btnProcess);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 548);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1089, 42);
            this.xPanel2.TabIndex = 1;
            // 
            // chkIsNewGroup
            // 
            this.chkIsNewGroup.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkIsNewGroup.Checked = true;
            this.chkIsNewGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsNewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkIsNewGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkIsNewGroup.ImageIndex = 1;
            this.chkIsNewGroup.ImageList = this.ImageList;
            this.chkIsNewGroup.Location = new System.Drawing.Point(254, 8);
            this.chkIsNewGroup.Name = "chkIsNewGroup";
            this.chkIsNewGroup.Size = new System.Drawing.Size(218, 24);
            this.chkIsNewGroup.TabIndex = 24;
            this.chkIsNewGroup.Text = "     新規オーダグループ番号生成可否";
            this.chkIsNewGroup.UseVisualStyleBackColor = false;
            this.chkIsNewGroup.Visible = false;
            this.chkIsNewGroup.CheckedChanged += new System.EventHandler(this.chkIsNewGroup_CheckedChanged);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Location = new System.Drawing.Point(809, 5);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(78, 28);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "適 用";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(887, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            this.xButtonList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xButtonList1_MouseDown);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdOUT1001);
            this.xPanel3.Controls.Add(this.xPanel6);
            this.xPanel3.Controls.Add(this.chkAll);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 30);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(261, 518);
            this.xPanel3.TabIndex = 2;
            // 
            // grdOUT1001
            // 
            this.grdOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell127,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell146,
            this.xEditGridCell147,
            this.xEditGridCell7,
            this.xEditGridCell129,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell142,
            this.xEditGridCell162,
            this.xEditGridCell149,
            this.xEditGridCell175,
            this.xEditGridCell95});
            this.grdOUT1001.ColPerLine = 6;
            this.grdOUT1001.Cols = 7;
            this.grdOUT1001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOUT1001.EnableMultiSelection = true;
            this.grdOUT1001.FixedCols = 1;
            this.grdOUT1001.FixedRows = 1;
            this.grdOUT1001.HeaderHeights.Add(27);
            this.grdOUT1001.ImageList = this.ImageList;
            this.grdOUT1001.Location = new System.Drawing.Point(0, 52);
            this.grdOUT1001.Name = "grdOUT1001";
            this.grdOUT1001.QuerySQL = resources.GetString("grdOUT1001.QuerySQL");
            this.grdOUT1001.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOUT1001.RowHeaderVisible = true;
            this.grdOUT1001.Rows = 2;
            this.grdOUT1001.RowStateCheckOnPaint = false;
            this.grdOUT1001.Size = new System.Drawing.Size(259, 464);
            this.grdOUT1001.TabIndex = 0;
            this.grdOUT1001.ToolTipActive = true;
            this.grdOUT1001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOUT1001_QueryEnd);
            this.grdOUT1001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOUT1001_MouseDown);
            this.grdOUT1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOUT1001_RowFocusChanged);
            this.grdOUT1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOUT1001_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "naewon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.HeaderText = "オ―ダ日付";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell1.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "gwa";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.HeaderText = "gwa";
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 55;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.HeaderText = "診療科";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellName = "doctor_name";
            this.xEditGridCell3.CellWidth = 70;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.HeaderText = "医師";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellName = "nalsu";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.CellWidth = 40;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "日数";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bunho";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "bunho";
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "doctor";
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell146.CellName = "gubun_name";
            this.xEditGridCell146.Col = 5;
            this.xEditGridCell146.HeaderText = "保険種別";
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell146.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell147.CellName = "chojae";
            this.xEditGridCell147.Col = 6;
            this.xEditGridCell147.HeaderText = "初再診";
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell147.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "naewon_type";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "naewon_type";
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "jubsu_no";
            this.xEditGridCell129.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.HeaderText = "jubsu_no";
            this.xEditGridCell129.IsUpdatable = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pk_order";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "pk_order";
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "input_gubun";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "input_gubun";
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "tel_yn";
            this.xEditGridCell142.Col = -1;
            this.xEditGridCell142.HeaderText = "tel_yn";
            this.xEditGridCell142.IsUpdatable = false;
            this.xEditGridCell142.IsVisible = false;
            this.xEditGridCell142.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "toiwon_drg";
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.HeaderText = "toiwon_drg";
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "input_tab";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.HeaderText = "input_tab";
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellName = "io_gubun";
            this.xEditGridCell175.Col = -1;
            this.xEditGridCell175.HeaderText = "io_gubun";
            this.xEditGridCell175.IsUpdatable = false;
            this.xEditGridCell175.IsVisible = false;
            this.xEditGridCell175.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell95.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell95.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell95.AlterateRowImageIndex = 0;
            this.xEditGridCell95.CellName = "select";
            this.xEditGridCell95.CellWidth = 30;
            this.xEditGridCell95.Col = 1;
            this.xEditGridCell95.HeaderText = "選択";
            this.xEditGridCell95.ImageList = this.ImageList;
            this.xEditGridCell95.IsUpdatable = false;
            this.xEditGridCell95.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell95.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell95.RowImageIndex = 0;
            this.xEditGridCell95.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell95.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.rbtIn);
            this.xPanel6.Controls.Add(this.rbtOut);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel6.Location = new System.Drawing.Point(0, 24);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(259, 28);
            this.xPanel6.TabIndex = 29;
            // 
            // rbtIn
            // 
            this.rbtIn.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtIn.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtIn.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtIn.ImageIndex = 0;
            this.rbtIn.ImageList = this.ImageList;
            this.rbtIn.Location = new System.Drawing.Point(128, 0);
            this.rbtIn.Name = "rbtIn";
            this.rbtIn.Size = new System.Drawing.Size(128, 27);
            this.rbtIn.TabIndex = 26;
            this.rbtIn.Text = "入院";
            this.rbtIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtIn.UseVisualStyleBackColor = false;
            this.rbtIn.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
            // 
            // rbtOut
            // 
            this.rbtOut.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtOut.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtOut.Checked = true;
            this.rbtOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOut.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbtOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtOut.ImageIndex = 1;
            this.rbtOut.ImageList = this.ImageList;
            this.rbtOut.Location = new System.Drawing.Point(0, 0);
            this.rbtOut.Name = "rbtOut";
            this.rbtOut.Size = new System.Drawing.Size(128, 27);
            this.rbtOut.TabIndex = 27;
            this.rbtOut.TabStop = true;
            this.rbtOut.Text = "外来";
            this.rbtOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtOut.UseVisualStyleBackColor = false;
            this.rbtOut.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.chkAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAll.ImageIndex = 0;
            this.chkAll.ImageList = this.ImageList;
            this.chkAll.Location = new System.Drawing.Point(0, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(259, 24);
            this.chkAll.TabIndex = 22;
            this.chkAll.Text = "       全体診療科";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // pnlOrder
            // 
            this.pnlOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pnlOrder.Controls.Add(this.grdOCS1003);
            this.pnlOrder.Controls.Add(this.tabGroup);
            this.pnlOrder.Controls.Add(this.xPanel4);
            this.pnlOrder.Controls.Add(this.txtDrg_info);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrder.Location = new System.Drawing.Point(261, 30);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(828, 518);
            this.pnlOrder.TabIndex = 4;
            // 
            // grdOCS1003
            // 
            this.grdOCS1003.AddedHeaderLine = 1;
            this.grdOCS1003.ApplyPaintEventToAllColumn = true;
            this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell145,
            this.xEditGridCell19,
            this.xEditGridCell102,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell134,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell135,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell136,
            this.xEditGridCell28,
            this.xEditGridCell137,
            this.xEditGridCell29,
            this.xEditGridCell163,
            this.xEditGridCell164,
            this.xEditGridCell165,
            this.xEditGridCell166,
            this.xEditGridCell173,
            this.xEditGridCell30,
            this.xEditGridCell140,
            this.xEditGridCell141,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell167,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell59,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell139,
            this.xEditGridCell94,
            this.xEditGridCell68,
            this.xEditGridCell153,
            this.xEditGridCell154,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell169,
            this.xEditGridCell170,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell128,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell132,
            this.xEditGridCell171,
            this.xEditGridCell172,
            this.xEditGridCell176,
            this.xEditGridCell177,
            this.xEditGridCell178,
            this.xEditGridCell180,
            this.xEditGridCell181,
            this.xEditGridCell10,
            this.xEditGridCell133,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell97});
            this.grdOCS1003.ColPerLine = 29;
            this.grdOCS1003.ColResizable = true;
            this.grdOCS1003.Cols = 30;
            this.grdOCS1003.ControlBinding = true;
            this.grdOCS1003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS1003.EnableMultiSelection = true;
            this.grdOCS1003.FixedCols = 1;
            this.grdOCS1003.FixedRows = 2;
            this.grdOCS1003.HeaderHeights.Add(32);
            this.grdOCS1003.HeaderHeights.Add(0);
            this.grdOCS1003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS1003.Location = new System.Drawing.Point(0, 38);
            this.grdOCS1003.Name = "grdOCS1003";
            this.grdOCS1003.QuerySQL = resources.GetString("grdOCS1003.QuerySQL");
            this.grdOCS1003.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS1003.RowHeaderVisible = true;
            this.grdOCS1003.Rows = 3;
            this.grdOCS1003.RowStateCheckOnPaint = false;
            this.grdOCS1003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1003.Size = new System.Drawing.Size(828, 432);
            this.grdOCS1003.TabIndex = 0;
            this.grdOCS1003.ToolTipActive = true;
            this.grdOCS1003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1003_MouseDown);
            this.grdOCS1003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1003_QueryEnd);
            this.grdOCS1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1003_QueryStarting);
            this.grdOCS1003.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS1003_GridColumnChanged);
            this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
            this.grdOCS1003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1003_RowFocusChanged);
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell145.CellName = "input_gubun_name";
            this.xEditGridCell145.CellWidth = 40;
            this.xEditGridCell145.Col = 4;
            this.xEditGridCell145.HeaderText = "入力\r\n区分";
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.RowSpan = 2;
            this.xEditGridCell145.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell145.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell145.SuppressRepeating = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.CellName = "group_ser";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.CellWidth = 25;
            this.xEditGridCell19.Col = 6;
            this.xEditGridCell19.HeaderText = "G\r\nR";
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell19.SuppressRepeating = true;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.CellName = "order_gubun_name";
            this.xEditGridCell102.CellWidth = 73;
            this.xEditGridCell102.Col = 5;
            this.xEditGridCell102.HeaderText = "オ―ダ区分";
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell102.SuppressRepeating = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.CellWidth = 75;
            this.xEditGridCell20.Col = 9;
            this.xEditGridCell20.HeaderText = "オ―ダコード";
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 150;
            this.xEditGridCell21.Col = 10;
            this.xEditGridCell21.HeaderText = "オ―ダ名";
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "specimen_code";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.HeaderText = "specimen_code";
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.CellName = "specimen_name";
            this.xEditGridCell22.CellWidth = 60;
            this.xEditGridCell22.Col = 11;
            this.xEditGridCell22.HeaderText = "検体";
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.CellName = "suryang";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell23.CellWidth = 30;
            this.xEditGridCell23.Col = 12;
            this.xEditGridCell23.DecimalDigits = 3;
            this.xEditGridCell23.HeaderText = "数量";
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "ord_danui";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.HeaderText = "ord_danui";
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellName = "ord_danui_name";
            this.xEditGridCell24.CellWidth = 40;
            this.xEditGridCell24.Col = 13;
            this.xEditGridCell24.HeaderText = "単位";
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.RowSpan = 2;
            this.xEditGridCell24.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellName = "dv_time";
            this.xEditGridCell25.CellWidth = 21;
            this.xEditGridCell25.Col = 14;
            this.xEditGridCell25.HeaderText = "dv_time";
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.Row = 1;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellName = "dv";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell26.CellWidth = 25;
            this.xEditGridCell26.Col = 15;
            this.xEditGridCell26.HeaderText = "dv";
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellName = "nalsu";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell27.CellWidth = 30;
            this.xEditGridCell27.Col = 16;
            this.xEditGridCell27.HeaderText = "日数";
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "jusa";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.HeaderText = "jusa";
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellName = "jusa_name";
            this.xEditGridCell28.CellWidth = 50;
            this.xEditGridCell28.Col = 17;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell28.HeaderText = "注射";
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.RowSpan = 2;
            this.xEditGridCell28.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "bogyong_code";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.HeaderText = "bogyong_code";
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.CellName = "bogyong_name";
            this.xEditGridCell29.CellWidth = 109;
            this.xEditGridCell29.Col = 7;
            this.xEditGridCell29.HeaderText = "用法";
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.RowSpan = 2;
            this.xEditGridCell29.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell29.SuppressRepeating = true;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell163.CellName = "jusa_spd_gubun";
            this.xEditGridCell163.CellWidth = 40;
            this.xEditGridCell163.Col = 18;
            this.xEditGridCell163.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell163.HeaderText = "ml\r\nhr";
            this.xEditGridCell163.IsUpdatable = false;
            this.xEditGridCell163.RowSpan = 2;
            this.xEditGridCell163.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell163.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell164.CellName = "hubal_change_yn";
            this.xEditGridCell164.CellWidth = 30;
            this.xEditGridCell164.Col = 28;
            this.xEditGridCell164.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell164.HeaderText = "後発\r\n不可";
            this.xEditGridCell164.IsUpdatable = false;
            this.xEditGridCell164.RowSpan = 2;
            this.xEditGridCell164.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell164.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell165.CellName = "pharmacy";
            this.xEditGridCell165.CellWidth = 20;
            this.xEditGridCell165.Col = 26;
            this.xEditGridCell165.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell165.HeaderText = "簡\r\n易";
            this.xEditGridCell165.IsUpdatable = false;
            this.xEditGridCell165.RowSpan = 2;
            this.xEditGridCell165.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell165.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell166.CellName = "drg_pack_yn";
            this.xEditGridCell166.CellWidth = 20;
            this.xEditGridCell166.Col = 25;
            this.xEditGridCell166.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell166.HeaderText = "一\r\n包";
            this.xEditGridCell166.IsUpdatable = false;
            this.xEditGridCell166.RowSpan = 2;
            this.xEditGridCell166.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell166.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell173.CellName = "powder_yn";
            this.xEditGridCell173.CellWidth = 20;
            this.xEditGridCell173.Col = 27;
            this.xEditGridCell173.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell173.HeaderText = "粉\r\n砕";
            this.xEditGridCell173.IsUpdatable = false;
            this.xEditGridCell173.RowSpan = 2;
            this.xEditGridCell173.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell173.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellName = "wonyoi_order_yn";
            this.xEditGridCell30.CellWidth = 24;
            this.xEditGridCell30.Col = 22;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell30.HeaderText = "院\r\n外";
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell140.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell140.CellWidth = 30;
            this.xEditGridCell140.Col = 20;
            this.xEditGridCell140.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell140.HeaderText = "当日\r\n施行";
            this.xEditGridCell140.IsUpdatable = false;
            this.xEditGridCell140.RowSpan = 2;
            this.xEditGridCell140.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell140.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell141.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell141.CellWidth = 30;
            this.xEditGridCell141.Col = 19;
            this.xEditGridCell141.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell141.HeaderText = "当日\r\n結果";
            this.xEditGridCell141.IsUpdatable = false;
            this.xEditGridCell141.RowSpan = 2;
            this.xEditGridCell141.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell141.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 21;
            this.xEditGridCell32.Col = 21;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.HeaderText = "緊\r\n急";
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellName = "pay";
            this.xEditGridCell33.CellWidth = 35;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.HeaderText = "請求\r\n区分";
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.CellName = "anti_cancer_yn";
            this.xEditGridCell36.CellWidth = 45;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell36.HeaderText = "抗癌剤";
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "muhyo";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.HeaderText = "muhyo";
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.CellName = "portable_yn";
            this.xEditGridCell38.CellWidth = 61;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.HeaderText = "移動\r\n撮影";
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "ocs_flag";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.HeaderText = "ocs_flag";
            this.xEditGridCell40.IsUpdatable = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "order_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.HeaderText = "order_gubun";
            this.xEditGridCell41.IsUpdatable = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "input_tab";
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.HeaderText = "input_tab";
            this.xEditGridCell167.IsUpdatable = false;
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "input_gubun";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.HeaderText = "input_gubun";
            this.xEditGridCell42.IsUpdatable = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "after_act_yn";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.HeaderText = "after_act_yn";
            this.xEditGridCell43.IsUpdatable = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "jundal_table";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.HeaderText = "jundal_table";
            this.xEditGridCell44.IsUpdatable = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jundal_part";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.HeaderText = "jundal_part";
            this.xEditGridCell45.IsUpdatable = false;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "move_part";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.HeaderText = "move_part";
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "bunho";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.HeaderText = "bunho";
            this.xEditGridCell47.IsUpdatable = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell48.CellName = "naewon_date";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell48.Col = 3;
            this.xEditGridCell48.HeaderText = "オ―ダ日付";
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.RowSpan = 2;
            this.xEditGridCell48.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell48.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "gwa";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "gwa";
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "doctor";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "doctor";
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "naewon_type";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "naewon_type";
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "pk_order";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.HeaderText = "pk_order";
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "seq";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.HeaderText = "seq";
            this.xEditGridCell53.IsUpdatable = false;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pkocs1003";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.HeaderText = "pkocs1003";
            this.xEditGridCell54.IsUpdatable = false;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "sub_susul";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.HeaderText = "sub_susul";
            this.xEditGridCell55.IsUpdatable = false;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "sutak_yn";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.HeaderText = "sutak_yn";
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "amt";
            this.xEditGridCell59.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.HeaderText = "amt";
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "dv_1";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.HeaderText = "dv_1";
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "dv_2";
            this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.HeaderText = "dv_2";
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "dv_3";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.HeaderText = "dv_3";
            this.xEditGridCell66.IsUpdatable = false;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "dv_4";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.HeaderText = "dv_4";
            this.xEditGridCell67.IsUpdatable = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.CellName = "hope_date";
            this.xEditGridCell139.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell139.Col = 24;
            this.xEditGridCell139.HeaderText = "希望日";
            this.xEditGridCell139.IsUpdatable = false;
            this.xEditGridCell139.RowSpan = 2;
            this.xEditGridCell139.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.CellName = "order_remark";
            this.xEditGridCell94.Col = 23;
            this.xEditGridCell94.DisplayMemoText = true;
            this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell94.HeaderText = "Comment";
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.RowSpan = 2;
            this.xEditGridCell94.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "mix_group";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.HeaderText = "mix_group";
            this.xEditGridCell68.IsUpdatable = false;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell153.CellName = "home_care_yn";
            this.xEditGridCell153.CellWidth = 20;
            this.xEditGridCell153.Col = 29;
            this.xEditGridCell153.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell153.HeaderText = "在\r\n宅";
            this.xEditGridCell153.IsUpdatable = false;
            this.xEditGridCell153.RowSpan = 2;
            this.xEditGridCell153.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell153.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell154.CellName = "regular_yn";
            this.xEditGridCell154.CellWidth = 21;
            this.xEditGridCell154.Col = 8;
            this.xEditGridCell154.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell154.HeaderText = "定\r\n時";
            this.xEditGridCell154.IsUpdatable = false;
            this.xEditGridCell154.RowSpan = 2;
            this.xEditGridCell154.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell154.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "gongbi_code";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.HeaderText = "公費";
            this.xEditGridCell155.IsUpdatable = false;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell156.CellName = "gongbi_name";
            this.xEditGridCell156.Col = -1;
            this.xEditGridCell156.HeaderText = "公費";
            this.xEditGridCell156.IsUpdatable = false;
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            this.xEditGridCell156.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell156.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellName = "donbog_yn";
            this.xEditGridCell169.Col = -1;
            this.xEditGridCell169.HeaderText = "donbog_yn";
            this.xEditGridCell169.IsUpdatable = false;
            this.xEditGridCell169.IsVisible = false;
            this.xEditGridCell169.Row = -1;
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellName = "dv_name";
            this.xEditGridCell170.Col = -1;
            this.xEditGridCell170.HeaderText = "dv_name";
            this.xEditGridCell170.IsUpdatable = false;
            this.xEditGridCell170.IsVisible = false;
            this.xEditGridCell170.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "slip_code";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.HeaderText = "slip_code";
            this.xEditGridCell69.IsUpdatable = false;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "group_yn";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.HeaderText = "group_yn";
            this.xEditGridCell70.IsUpdatable = false;
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "sg_code";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.HeaderText = "sg_code";
            this.xEditGridCell71.IsUpdatable = false;
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "order_gubun_bas";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.HeaderText = "order_gubun_bas";
            this.xEditGridCell72.IsUpdatable = false;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "input_control";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.HeaderText = "input_control";
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "suga_yn";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.HeaderText = "suga_yn";
            this.xEditGridCell76.IsUpdatable = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "emergency_check";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.HeaderText = "emergency_check";
            this.xEditGridCell77.IsUpdatable = false;
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "limit_suryang";
            this.xEditGridCell80.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.HeaderText = "limit_suryang";
            this.xEditGridCell80.IsUpdatable = false;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "specimen_yn";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.HeaderText = "specimen_yn";
            this.xEditGridCell81.IsUpdatable = false;
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "jaeryo_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.HeaderText = "jaeryo_yn";
            this.xEditGridCell82.IsUpdatable = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "ord_danui_check";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.HeaderText = "ord_danui_check";
            this.xEditGridCell83.IsUpdatable = false;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "ord_danui_bas";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.HeaderText = "ord_danui_bas";
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "jundal_table_out";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.HeaderText = "jundal_table_out";
            this.xEditGridCell84.IsUpdatable = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "jundal_part_out";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.HeaderText = "jundal_part_out";
            this.xEditGridCell85.IsUpdatable = false;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "move_part_out";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "jundal_table_inp";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "jundal_part_inp";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "move_part_inp";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "bulyong_check";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.HeaderText = "bulyong_check";
            this.xEditGridCell87.IsUpdatable = false;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.HeaderText = "wonyoi_order_cr_yn";
            this.xEditGridCell88.IsUpdatable = false;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.HeaderText = "default_wonyoi_order_yn";
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "nday_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.HeaderText = "nday_yn";
            this.xEditGridCell92.IsUpdatable = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "muhyo_yn";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.HeaderText = "muhyo_yn";
            this.xEditGridCell93.IsUpdatable = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "tel_yn";
            this.xEditGridCell132.Col = -1;
            this.xEditGridCell132.HeaderText = "tel_yn";
            this.xEditGridCell132.IsUpdatable = false;
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.BindControl = this.txtDrg_info;
            this.xEditGridCell171.CellName = "drg_info";
            this.xEditGridCell171.Col = -1;
            this.xEditGridCell171.HeaderText = "drg_info";
            this.xEditGridCell171.IsReadOnly = true;
            this.xEditGridCell171.IsUpdatable = false;
            this.xEditGridCell171.IsVisible = false;
            this.xEditGridCell171.Row = -1;
            // 
            // txtDrg_info
            // 
            this.txtDrg_info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDrg_info.Location = new System.Drawing.Point(0, 470);
            this.txtDrg_info.Multiline = true;
            this.txtDrg_info.Name = "txtDrg_info";
            this.txtDrg_info.Protect = true;
            this.txtDrg_info.ReadOnly = true;
            this.txtDrg_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDrg_info.Size = new System.Drawing.Size(828, 48);
            this.txtDrg_info.TabIndex = 44;
            this.txtDrg_info.TabStop = false;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellName = "drg_bunryu";
            this.xEditGridCell172.Col = -1;
            this.xEditGridCell172.HeaderText = "drg_bunryu";
            this.xEditGridCell172.IsReadOnly = true;
            this.xEditGridCell172.IsUpdatable = false;
            this.xEditGridCell172.IsVisible = false;
            this.xEditGridCell172.Row = -1;
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell176.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell176.CellName = "child_yn";
            this.xEditGridCell176.CellWidth = 19;
            this.xEditGridCell176.Col = 2;
            this.xEditGridCell176.HeaderForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell176.IsUpdatable = false;
            this.xEditGridCell176.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell176.RowSpan = 2;
            this.xEditGridCell176.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellName = "bom_source_key";
            this.xEditGridCell177.Col = -1;
            this.xEditGridCell177.IsUpdatable = false;
            this.xEditGridCell177.IsVisible = false;
            this.xEditGridCell177.Row = -1;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellName = "bom_occur_yn";
            this.xEditGridCell178.Col = -1;
            this.xEditGridCell178.IsUpdatable = false;
            this.xEditGridCell178.IsVisible = false;
            this.xEditGridCell178.Row = -1;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellName = "org_key";
            this.xEditGridCell180.Col = -1;
            this.xEditGridCell180.IsUpdatable = false;
            this.xEditGridCell180.IsVisible = false;
            this.xEditGridCell180.Row = -1;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.CellName = "parent_key";
            this.xEditGridCell181.Col = -1;
            this.xEditGridCell181.IsUpdatable = false;
            this.xEditGridCell181.IsVisible = false;
            this.xEditGridCell181.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bun_code";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "bun_code";
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell133.CellName = "cont_key";
            this.xEditGridCell133.CellWidth = 28;
            this.xEditGridCell133.Col = -1;
            this.xEditGridCell133.IsUpdatable = false;
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            this.xEditGridCell133.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "fk_key1001";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "fk_key1001";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "wonnae_drg_yn";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "wonnae_drg_yn";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell97.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell97.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.AlterateRowImageIndex = 0;
            this.xEditGridCell97.CellName = "select";
            this.xEditGridCell97.CellWidth = 30;
            this.xEditGridCell97.Col = 1;
            this.xEditGridCell97.HeaderText = "選択";
            this.xEditGridCell97.ImageList = this.ImageList;
            this.xEditGridCell97.IsUpdatable = false;
            this.xEditGridCell97.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell97.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.RowImageIndex = 0;
            this.xEditGridCell97.RowSpan = 2;
            this.xEditGridCell97.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell97.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 14;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 21;
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // tabGroup
            // 
            this.tabGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabGroup.IDEPixelArea = true;
            this.tabGroup.IDEPixelBorder = false;
            this.tabGroup.Location = new System.Drawing.Point(0, 38);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Size = new System.Drawing.Size(828, 0);
            this.tabGroup.TabIndex = 45;
            this.tabGroup.SelectionChanged += new System.EventHandler(this.tabGroup_SelectionChanged);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.btnDeleteAll);
            this.xPanel4.Controls.Add(this.btnSelectAll);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel4.Location = new System.Drawing.Point(0, 0);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(828, 38);
            this.xPanel4.TabIndex = 46;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Image = global::IHIS.OCSO.Properties.Resources.YESEN1;
            this.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteAll.Location = new System.Drawing.Point(53, 5);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDeleteAll.Size = new System.Drawing.Size(43, 29);
            this.btnDeleteAll.TabIndex = 1;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Image = global::IHIS.OCSO.Properties.Resources.YESUP1;
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectAll.Location = new System.Drawing.Point(6, 5);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSelectAll.Size = new System.Drawing.Size(43, 29);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // dloOrder_danui
            // 
            this.dloOrder_danui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.dloOrder_danui.QuerySQL = "SELECT CODE\r\n  FROM OCS0132\r\n WHERE CODE_TYPE = \'ORD_DANUI\'\r\n ORDER BY CODE";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "");
            this.imageListMixGroup.Images.SetKeyName(1, "");
            this.imageListMixGroup.Images.SetKeyName(2, "");
            this.imageListMixGroup.Images.SetKeyName(3, "");
            this.imageListMixGroup.Images.SetKeyName(4, "");
            this.imageListMixGroup.Images.SetKeyName(5, "");
            this.imageListMixGroup.Images.SetKeyName(6, "");
            this.imageListMixGroup.Images.SetKeyName(7, "");
            this.imageListMixGroup.Images.SetKeyName(8, "");
            this.imageListMixGroup.Images.SetKeyName(9, "");
            this.imageListMixGroup.Images.SetKeyName(10, "");
            this.imageListMixGroup.Images.SetKeyName(11, "");
            this.imageListMixGroup.Images.SetKeyName(12, "");
            this.imageListMixGroup.Images.SetKeyName(13, "");
            this.imageListMixGroup.Images.SetKeyName(14, "");
            this.imageListMixGroup.Images.SetKeyName(15, "");
            this.imageListMixGroup.Images.SetKeyName(16, "");
            this.imageListMixGroup.Images.SetKeyName(17, "");
            this.imageListMixGroup.Images.SetKeyName(18, "");
            this.imageListMixGroup.Images.SetKeyName(19, "");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
            // 
            // OCS1003Q00
            // 
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS1003Q00";
            this.Size = new System.Drawing.Size(1089, 590);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOUT1001)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            return base.Command(command, commandParam);
        }

        int patientFormX;

        protected override void OnLoad(EventArgs e)
        {
            patientFormX = ParentForm.Location.X;

            //ntt 처방일자
            grdOCS1003.AutoSizeColumn(3, 0);
            grdOUT1001.SetBindVarValue("f_io_gubun", "O");

            try
            {
                popupMenu.MenuCommands.Clear();
                popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "検査情報照会" : "검사정보조회", (Image)this.ImageList.Images[2],
                    new EventHandler(this.PopUpMenuGumsaInfo_Click)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                    {
                        if (OpenParam["bunho"].ToString().Trim() == "")
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正しくありません。 ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.Close();
                            return;
                        }
                        else
                            mBunho = OpenParam["bunho"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正しくありません。 ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.Close();
                        return;
                    }

                    if (OpenParam.Contains("gwa"))
                    {
                        if (OpenParam["gwa"].ToString().Trim() == "")
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正しくありません。 ご確認ください。" : "진료과가 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.Close();
                            return;
                        }
                        else
                            mGwa = OpenParam["gwa"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正しくありません。 ご確認ください。" : "진료과가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.Close();
                        return;
                    }


                    if (OpenParam.Contains("input_gubun"))
                    {
                        if (OpenParam["input_gubun"].ToString().Trim() == "")
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正しくありません。 ご確認ください。" : "입력구분이 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.Close();
                            return;
                        }
                        else
                            mInput_gubun = OpenParam["input_gubun"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正しくありません。 ご確認ください。" : "입력구분이 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.Close();
                        return;
                    }

                    //pk_order
                    if (OpenParam.Contains("pk_order"))
                    {
                        mPk_order = OpenParam["pk_order"].ToString().Trim();
                    }

                    mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                    if (OpenParam.Contains("naewon_date"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                            mNaewon_date = OpenParam["naewon_date"].ToString();
                    }
                    dpkNaewon_date.SetDataValue(mNaewon_date);

                    //Data가 없는 경우 화면 닫을지 여부
                    if (OpenParam.Contains("auto_close"))
                    {
                        mAuto_close = bool.Parse(OpenParam["auto_close"].ToString().Trim());
                        //if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Minimized;
                        if (mAuto_close) this.ParentForm.Location = new Point(0 - ParentForm.Size.Width, ParentForm.Location.Y);
                    }

                    if (OpenParam.Contains("tel_yn"))
                    {
                        mTel_yn = OpenParam["tel_yn"].ToString().Trim();
                    }

                    if (TypeCheck.IsNull(mTel_yn))
                        mTel_yn = "%";

                    if (OpenParam.Contains("input_tab"))
                    {
                        mInput_tab = OpenParam["input_tab"].ToString().Trim();
                    }

                    if (OpenParam.Contains("io_gubun"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["io_gubun"].ToString()))
                        {
                            mIOgubun = OpenParam["io_gubun"].ToString();
                        }
                    }
                    if (OpenParam.Contains("childYN"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["childYN"].ToString()))
                        {
                            mChildYN = OpenParam["childYN"].ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }
            else
            {
                mBunho = "00044383";
                mGwa = "EN";
                mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                dpkNaewon_date.SetDataValue(mNaewon_date);
                mInput_gubun = "D0";
            }

            InitialDesign();

            //Set M/D Relation

            grdOCS1003.SetRelationKey("bunho", "bunho");
            grdOCS1003.SetRelationKey("naewon_date", "naewon_date");
            grdOCS1003.SetRelationKey("gwa", "gwa");
            grdOCS1003.SetRelationKey("input_gubun", "input_gubun");

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>
        private void InitialDesign()
        {
            // 여기서 처리 하세요
        }

        private void PostLoad()
        {            
            //comboBox생성
            CreateCombo();

            //DataLayout 생성
            CreateLayout();

            // IO_Gubun 에 대한 라디오 박스 처리
            if (this.mIOgubun == "O")
            {
                this.rbtOut.Checked = true;
            }
            else
            {
                this.rbtIn.Checked = true;
            }

           

            //check layout
            //FormWindowState가 Normal로 돌아가면서 문제가 생겨서 check Layout으로 check
            if (mAuto_close)
            {
                IHIS.Framework.MultiLayout dloCheckLayout;
                dloCheckLayout = this.grdOUT1001.CloneToLayout();

                dloCheckLayout.QuerySQL = grdOUT1001.QuerySQL;
                dloCheckLayout.SetBindVarValue("f_bunho",       mBunho);
                dloCheckLayout.SetBindVarValue("f_naewon_date", mNaewon_date);
                dloCheckLayout.SetBindVarValue("f_gwa",         mGwa);
                dloCheckLayout.SetBindVarValue("f_input_gubun", mInput_gubun);
                dloCheckLayout.SetBindVarValue("f_tel_yn",      mTel_yn);
                dloCheckLayout.SetBindVarValue("f_hosp_code",   mHospCode);

                if (!dloCheckLayout.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

                if (dloCheckLayout.RowCount < 1 && mAuto_close)
                {
                    this.Close();

                    dloSelectOCS1003.Dispose();
                    return;
                }
            }

            if (mAuto_close) this.ParentForm.Location = new Point(patientFormX, ParentForm.Location.Y);

            dpkNaewon_date.SetDataValue(mNaewon_date);

            //grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);
            //grdOUT1001.SetBindVarValue("f_gwa", mGwa);

            //if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            // 조회후 마스터 그리드에 데이터가 없는경우 
            // 디테일 쪽 클리어 아마도 tab이 제대ㅐ로 안 없어질듯...
            //if (grdOUT1001.RowCount <= 0) ClearDetailInfo();

            // 전체과 디폴트 선택 
            this.chkAll.Checked = true;


            this.Refresh();
        }

        /// <summary>
        /// DataLayout LayoutItems생성
        /// </summary>
        private void CreateLayout()
        {
            //OCS1003
            foreach (XGridCell cell in this.grdOCS1003.CellInfos)
            {
                dloSelectOCS1003.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS1003.InitializeLayoutTable();
        }
        #endregion

        #region [Combo 생성]

        private void CreateCombo()
        {
            IHIS.Framework.MultiLayout layoutCombo;
            layoutCombo = new MultiLayout();

            //주사
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            layoutCombo.InitializeLayoutTable();

            layoutCombo.QuerySQL = @"SELECT CODE, CODE_NAME
                                       FROM OCS0132
                                      WHERE CODE_TYPE = 'JUSA'
                                        AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                      ORDER BY CODE";
            layoutCombo.QueryLayout(false);
            
            if (Service.ErrCode == 0 && layoutCombo.LayoutTable != null)
            {
                grdOCS1003.SetComboItems("jusa", layoutCombo.LayoutTable, "code_name", "code");
            }

            // Combo 세팅
            DataTable dtTemp = null;

            // 급여구분
            dtTemp = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
            this.grdOCS1003.SetComboItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            // 이동촬영여부
            dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
            this.grdOCS1003.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            // 주사스피드구분
            dtTemp = this.mOrderBiz.LoadComboDataSource("jusa_spd_gubun").LayoutTable;
            this.grdOCS1003.SetListItems("jusa_spd_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);

        }
        #endregion

        #region [QueryEnd Event]
        private void grdOUT1001_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            //select 정보 reset
            //dloSelectOCS1001.Reset();
            //dloSelectOCS1003.Reset();
            bool isSelect = false;

            this.SetSelectNaewon(-1);

            //SelectionBackColorChange(grdOUT1001);
            //this.DisplayListImage(grdOUT1001);
        }

        private void grdOCS1003_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            //SelectionBackColorChange(grdOCS1003);
            childSetImage();
            
        }
        #endregion

        #region [Return Layout 생성]

        string GetMaxGroupSer(MultiLayout layout)
        {
            int max = int.Parse(layout.GetItemString(0, "group_ser"));

            for (int i = 0; i < layout.RowCount; i++)
            {
                for (int j = i; j < layout.RowCount; j++)
                {
                    if (max < int.Parse(layout.GetItemString(j, "group_ser")))
                    {
                        max = int.Parse(layout.GetItemString(j, "group_ser"));
                    }
                }
            }
            max = max + 1;
            return max.ToString();
        }
        //날수 및 기타 기본정보변경
        private void CreateReturnLayout()
        {
            this.AcceptData();

            //현재선택된 row trans
            //OCS1003
            //for (int i = 0; i < grdOCS1003.RowCount; i++)
            //{
            //    if (grdOCS1003.GetItemString(i, "select") == " ")
            //        dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
            //}

            string pk_order = "";
            int base_Nalsu = 0;
            DataRow row;
            DataRow row2;
            DataRow row3;
            for (int i = 0; i < dloSelectOCS1003.RowCount; i++)
            {
                row = dloSelectOCS1003.LayoutTable.Rows[i];

                //insert by jc[同じgroup_serであれば新しいgroup_serに変える]
                //for (int j = 0; j < i; j++)
                //{
                //    row2 = dloSelectOCS1003.LayoutTable.Rows[j];
                //    if (row["group_ser"].ToString() == row2["group_ser"].ToString()
                //        && row["fk_key1001"].ToString() != row2["fk_key1001"].ToString())
                //    {
                //        string MaxGroupSer = GetMaxGroupSer(dloSelectOCS1003);
                //        string str = row["group_ser"].ToString();
                //        for (int k = 0; k < dloSelectOCS1003.RowCount; k++)
                //        {
                //            row3 = dloSelectOCS1003.LayoutTable.Rows[k];
                //            if (str == row3["group_ser"].ToString()
                //                 && row["fk_key1001"].ToString() == row3["fk_key1001"].ToString())
                //            {
                //                dloSelectOCS1003.SetItemValue(k, "group_ser", MaxGroupSer);
                //            }
                //        }
                //    }
                //}

                //order 단위가 현재 존재하지 않는 경우
                if (row["ord_danui_check"].ToString() == "Y")
                {
                    //order 단위가 없는 경우에는 SKip
                    if (row["ord_danui"].ToString().Trim() == "")
                    {
                        dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                        i--;
                        continue;
                    }
                    else
                    {
                        if (!CheckOrd_danui(row["hangmog_code"].ToString(), row["ord_danui"].ToString()))
                        {
                            dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                            i--;
                            continue;
                        }
                    }
                }

                pk_order = row["pk_order"].ToString();
                base_Nalsu = int.Parse(row["nalsu"].ToString());


                //order_gubun
                //header '0':정규
                row["order_gubun"] = "0" + row["order_gubun"].ToString().Substring(1, 1);

                //내복약,외용약,주사재택은 DO오더의 일수를 그대로 가져 온다.
                if (row["order_gubun_bas"].ToString() == "C" || row["order_gubun_bas"].ToString() == "D" ||
                    ((row["order_gubun_bas"].ToString() == "A" || row["order_gubun_bas"].ToString() == "B") && row["home_care_yn"].ToString() == "Y"))
                {
                    row["nalsu"] = base_Nalsu;
                }

                //nday처리, 주사재택
                /*
                if (row["nday_yn"].ToString() == "N" || row["nday_yn"].ToString().Trim() == "" ||
                    ((row["order_gubun_bas"].ToString() == "A" || row["order_gubun_bas"].ToString() == "B") && row["home_care_yn"].ToString() == "Y"))
                    row["nday_nalsu"] = 1;
                else
                {
                    if (row["slip_code"].ToString() == "E09" || row["slip_code"].ToString() == "P03" || row["slip_code"].ToString() == "P04")
                        row["nday_nalsu"] = base_Nalsu;
                    else
                        row["nday_nalsu"] = row["nalsu"];

                    row["nalsu"] = 1;
                }
                 */ 
            }

            if (dloSelectOCS1003.LayoutTable.Rows.Count < 1)
                this.Close();

            if (chkIsNewGroup.Checked)
                mIsNewGroupSer = true;
            else
                mIsNewGroupSer = false;


            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("isnewgroup", mIsNewGroupSer);
            commandParams.Add("OCS1003", dloSelectOCS1003);
            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }
        #endregion

        #region [ButtonList]

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    //select 정보 reset
                    if (this.CurrMSLayout == grdOUT1001)
                    {
                        dloSelectOCS1003.Reset();
                    }

                    break;

                case FunctionType.Close:

                    dloSelectOCS1003.Dispose();

                    break;

                default:

                    break;
            }
        }

        #endregion

        #region [grdOUT1001 Event]

        private void grdOUT1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //if (e.PreviousRow > -1)
            //{
            //    //현재선택된 row trans

            //    //OCS1003
            //    for (int i = 0; i < grdOCS1003.RowCount; i++)
            //    {
            //        if (grdOCS1003.GetItemString(i, "select") == " ")
            //            dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
            //    }
            //}

            this.grdOCS1003.SetBindVarValue("f_io_gubun", this.mIOgubun);
            if (!grdOCS1003.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }

            //this.ClearDetailInfo();

            //this.MakeGroupTab(this.grdOCS1003);

            this.SetInitialOrderGridCheckImage();
        }


        /// <summary>
        /// 오더일자 List에 퇴원약여부 등을 표시한다.
        /// </summary>
        private void DisplayListImage(XGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    if (aGrd.GetItemValue(i, "toiwon_drg").ToString().Trim() == "Y") // 퇴원약
                    {
                        aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                        aGrd[i + aGrd.HeaderHeights.Count, 0].ToolTipText = aGrd[i + aGrd.HeaderHeights.Count, 0].ToolTipText + (NetInfo.Language == LangMode.Jr ? "退院薬" : "퇴원약");
                    }
                }
            }
            catch { }
            finally
            {

            }
        }

        #endregion

        #region [grdOCS1003 Event]

        private void grdOCS1003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (e.DataRow["bulyong_check"].ToString() == "Y" || e.DataRow["bulyong_check"].ToString() == "Z")
            {
                e.BackColor = ((XEditGridCell)grdOCS1003.CellInfos[e.ColName]).RowBackColor.Color;
                e.ForeColor = Color.Red;
                //insert by jc [bulyong_checkがYである時チェックボックスの後ろのNが見えてしまう不具合を修正] 2012/04/06
                if (e.ColName == "select")
                    e.ForeColor = System.Drawing.Color.Transparent;
            }

            #region 코드만 화면 Display하는 필드를 명칭으로 ToolTip 처리
            switch (e.ColName)
            {
                case "bogyong_name": // 복용명
                    grdOCS1003[e.RowNumber, e.ColName].ToolTipText = grdOCS1003.GetItemString(e.RowNumber, "bogyong_name") + grdOCS1003.GetItemString(e.RowNumber, "dv_name");
                    break;

                case "child_yn":

                    e.ForeColor = Color.Transparent;

                    break;

            }
            #endregion

            //insert by jc [院内採用薬の場合ROWの色を塗る。]
            this.mColumnControl.ColumnColorForCodeQueryGrid(mIOgubun, grid, e);
        }

        private void grdOCS1003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int rowIndex;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowIndex = grdOCS1003.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOCS1003.CurrentColNumber == 0)
                {
                    //불용처리된 것은 선택을 막는다.
                    if (grdOCS1003.GetItemString(rowIndex, "bulyong_check") == "Y")
                    {
                        //불용인 경우에는 해당 항목의 심사기준을 보여준다.
                        mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS1003.GetItemString(rowIndex, "hangmog_code"));
                        mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                        if (!TypeCheck.IsNull(mbxMsg)) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                        return;
                    }

                    if (grdOCS1003.GetItemString(rowIndex, "select") == "N")
                    {                        
                        grdOCS1003.SetItemValue(rowIndex, "select", "Y");
                        this.InsertBackTable(grdOCS1003.LayoutTable.Rows[rowIndex]);
                        SelectionBackColorChange(sender, rowIndex, "Y");

                        
                        //외래오더에서 호출이고 입원do오다 선택시
                        //원외처리
                        if (this.mIOgubun == "O" && this.rbtIn.Checked)
                        {
                            if (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "C" ||
                                this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "D")
                            {
                                SetWonyoiOrderYN(rowIndex);
                            }
                        }
                    }
                    else
                    {
                        this.RemoveBackTable(grdOCS1003.LayoutTable.Rows[rowIndex]);
                        grdOCS1003.SetItemValue(rowIndex, "select", "N");
                        SelectionBackColorChange(sender, rowIndex, "N");
                    }

                    SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);
                }
            }
            ////Double Click시 해당 항목정보를 보여준다.
            //else if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    rowIndex = grdOCS1003.GetHitRowNumber(e.Y);
            //    if (rowIndex < 0 || grdOCS1003.CurrentColNumber == 0) return;

            //    this.mOrderBiz.ShowHangmogAddInfoScreen(this, grdOCS1003.GetItemString(rowIndex, "slip_code"), grdOCS1003.GetItemString(rowIndex, "hangmog_code"));
            //}
            //else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            //{
            //    rowIndex = grdOCS1003.GetHitRowNumber(e.Y);
            //    if (rowIndex < 0) return;

            //    if (grdOCS1003.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

            //    popupMenu.TrackPopup(((IHIS.Framework.XEditGrid)sender).PointToScreen(new Point(e.X, e.Y)));
            //}

        }

        private void SetWonyoiOrderYN(int rowIndex)
        {
            string inputSql = "";
            string tusuk_gwa = "";

            inputSql  = " SELECT FN_AKU_LOAD_TUSUK_GWA GWA";
            inputSql += "   FROM DUAL A ";

            if(!TypeCheck.IsNull(Service.ExecuteScalar(inputSql)))
            {
                tusuk_gwa = Service.ExecuteScalar(inputSql).ToString();
            }

            //투석과이면 무조건 원내
            if (this.mGwa != tusuk_gwa)
            {
                //원외만가능
                if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "Y")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "Y");
                //원내만가능
                else if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "N")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "N");
                //기본원외
                else if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "1")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "Y");
                //기본원내
                else if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "2")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "N");
                //그외는 원외처리
                else
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "Y");

            }
            else
                this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "N");

        }

        private void grdOCS1003_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            if (e.CurrentRow >= 0)
            {
                // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
                this.mHangmogInfo.DisplaySpecialColHeader("O", grd, e.CurrentRow, grd.GetItemString(e.CurrentRow, "hangmog_code"));
            }
        }

        #endregion

        #region [Fuction]

        private void dpkNaewon_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //select 정보 reset
            dloSelectOCS1003.Reset();

            grdOUT1001.SetBindVarValue("f_naewon_date", e.DataValue);
            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        private void SetSelectNaewon(int aRowNumber)
        {
            int currentRow = aRowNumber;
            bool select = false;
            int start_row = -1;
            int end_row = -1;

            if (aRowNumber < 0)
            {
                start_row = 0;
                end_row = this.grdOUT1001.RowCount;
            }
            else
            {
                start_row = aRowNumber;
                end_row = aRowNumber + 1;
            }

            for (int i=start_row; i<end_row; i++)
            {
                if (this.IsExistSelectedOrder(this.grdOUT1001.GetItemString(i, "pk_order"),
                                              this.grdOUT1001.GetItemString(i, "naewon_date"),
                                              this.grdOUT1001.GetItemString(i, "gwa"),
                                              this.grdOUT1001.GetItemString(i, "doctor")))
                    select = true;
                else
                    select = false;

                if (select)
                {
                    grdOUT1001.SetItemValue(i, "select", "Y");
                    SelectionBackColorChange(grdOUT1001, i, "Y");
                }
                else
                {
                    grdOUT1001.SetItemValue(i, "select", "N");
                    SelectionBackColorChange(grdOUT1001, i, "N");
                }
            }
        }

        private void SetInitialOrderGridCheckImage()
        {

            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                if (this.IsExistSelectedOrder(this.grdOCS1003.GetItemString(i, "pkocs1003"),
                                              this.grdOCS1003.GetItemString(i, "naewon_date"),
                                              this.grdOCS1003.GetItemString(i, "gwa"),
                                              this.grdOCS1003.GetItemString(i, "doctor"),
                                              this.grdOCS1003.GetItemString(i, "group_ser")))
                {
                    grdOCS1003.SetItemValue(i, "select", "Y");
                    SelectionBackColorChange(grdOCS1003, i, "Y");
                }
                else
                {
                    grdOCS1003.SetItemValue(i, "select", "N");
                    SelectionBackColorChange(grdOCS1003, i, "N");
                }
            }
            //foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            //{
            //    if (this.IsExistSelectedOrder(this.grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "pk_order"),
            //                                  this.grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "naewon_date"),
            //                                  this.grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "gwa"),
            //                                  this.grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "doctor"),
            //                                  tpg.Tag.ToString()) == true)
            //    {
            //        tpg.ImageIndex = 1;
            //    }
            //    else
            //    {
            //        tpg.ImageIndex = 0;
            //    }
            //}
        }

        private void MakeGroupTab(XEditGrid aGrid)
        {
            string currentGroupSer = "";
            string title = "";
            IHIS.X.Magic.Controls.TabPage tpgGroup;

            this.tabGroup.SelectionChanged -= new EventHandler(tabGroup_SelectionChanged);

            // 탭페이지 클리어
            try
            {
                this.tabGroup.TabPages.Clear();
            }
            catch
            {
                this.tabGroup.Refresh();
            }

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (currentGroupSer != aGrid.GetItemString(i, "group_ser"))
                {
                    if (aGrid.GetItemString(i, "input_tab") == "01") // 약인경우는 그룹탭에 복용법을 같이 보여준다.
                    {
                        title = aGrid.GetItemString(i, "group_ser") + " グループ : " + aGrid.GetItemString(i, "bogyong_name");
                    }
                    else
                    {
                        title = aGrid.GetItemString(i, "group_ser") + " グループ";
                    }

                    tpgGroup = new IHIS.X.Magic.Controls.TabPage(title);
                    tpgGroup.ImageList = this.ImageList;
                    tpgGroup.ImageIndex = 0;
                    tpgGroup.Tag = aGrid.GetItemString(i, "group_ser");

                    this.tabGroup.TabPages.Add(tpgGroup);

                    currentGroupSer = aGrid.GetItemString(i, "group_ser");
                }
            }

            this.tabGroup.SelectionChanged += new EventHandler(tabGroup_SelectionChanged);

            SetInitialOrderGridCheckImage();

            this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
        }

        private void ClearDetailInfo()
        {
            //if (this.lblSelectOrder.Tag.ToString() == "Y")
            //{
            //    // 전체선택 해제 인경우 클리어
            //    lblSelectOrder_Click(this.lblSelectOrder, new EventArgs());
            //}

            this.btnDeleteAll.Tag = "N";
            this.btnDeleteAll.ImageIndex = 0;
            this.btnDeleteAll.Text = "全体オーダグループ選択";

            // 텝페이지 클리어
            try
            {
                this.tabGroup.TabPages.Clear();
            }
            catch
            {
                this.tabGroup.Refresh();
            }
        }

        #endregion

        #region [Cotrol Event]

        //전체진료과를 조회할 건지 여부
        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkAll.ImageIndex = 1;

                grdOUT1001.SetBindVarValue("f_gwa", "%");
            }
            else
            {
                chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkAll.ImageIndex = 0;

                grdOUT1001.SetBindVarValue("f_gwa", mGwa);
            }

            grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);
            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

        }

        //private void lblSelectOrder_Click(object sender, System.EventArgs e)
        //{
        //    if (lblSelectOrder.Tag.ToString() == "N")
        //    {
        //        foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
        //        {
        //            this.grdSelectAll(grdOCS1003, tpg.Tag.ToString(), true);
        //            tpg.ImageIndex = 1;
        //        }
        //        lblSelectOrder.ImageIndex = 1;
        //        lblSelectOrder.Text = " 全体タブ選択取消";
        //        lblSelectOrder.Tag = "Y";
        //    }
        //    else
        //    {
        //        foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
        //        {
        //            this.grdSelectAll(grdOCS1003, tpg.Tag.ToString(), false);
        //            tpg.ImageIndex = 0;
        //        }
        //        lblSelectOrder.ImageIndex = 0;
        //        lblSelectOrder.Text = " 全体タブ選択";
        //        lblSelectOrder.Tag = "N";
        //    }
        //}

        private void InsertBackTable(DataRow dr)
        {
            if (this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + dr["pkocs1003"].ToString()).Length <= 0)
                this.dloSelectOCS1003.LayoutTable.ImportRow(dr);
        }

        private void RemoveBackTable(DataRow dr)
        {
            DataRow[] rows = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + dr["pkocs1003"].ToString());
            foreach (DataRow row in rows)
                this.dloSelectOCS1003.LayoutTable.Rows.Remove(row);
        }

        private bool IsExistSelectedOrder(string aNaewonKey, string aOrderDate, string aGwa, string aDoctor, string aGroupSer)
        {
            if (rbtOut.Checked == true)
            {
                DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + aNaewonKey + " AND group_ser=" + aGroupSer);

                if (dr.Length > 0) return true;
            }
            else
            {
                DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + aNaewonKey + " AND naewon_date='" + aOrderDate + "' AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "' AND group_ser=" + aGroupSer);

                if (dr.Length > 0) return true;
            }

            return false;
        }

        private bool IsExistSelectedOrder(string aNaewonKey, string aOrderDate, string aGwa, string aDoctor)
        {
            if (rbtOut.Checked == true)
            {
                DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey);

                if (dr.Length > 0) return true;
            }
            else
            {
                DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey + " AND naewon_date='" + aOrderDate + "' AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "'");

                if (dr.Length > 0) return true;
            }

            return false;
        }

        /// <summary>
        /// 해당 Grid 전체선택 해제
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="select"></param>
        //private bool grdSelectAll(XGrid grdObject, string aGroupSer, bool select)
        private bool grdSelectAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
                {
                    this.InsertBackTable(grdObject.LayoutTable.Rows[rowIndex]);
                    this.SelectionBackColorChange(grdObject, rowIndex, "Y");
                    grdObject.SetItemValue(rowIndex, "select", "Y");
                }
            }

            //if (select)
            //{
            //    for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            //    {
            //        if (aGroupSer == grdObject.GetItemString(rowIndex, "group_ser") && grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
            //        {
            //            this.InsertBackTable(grdObject.LayoutTable.Rows[rowIndex]);
            //            grdObject.SetItemValue(rowIndex, "select", " ");
            //        }
            //    }
            //}
            //else
            //{
            //    for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            //    {
            //        if (aGroupSer == grdObject.GetItemString(rowIndex, "group_ser") && grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
            //        {
            //            this.RemoveBackTable(grdObject.LayoutTable.Rows[rowIndex]);
            //            grdObject.SetItemValue(rowIndex, "select", "");
            //        }
            //    }
            //}

            //선택된 Row 표시
            SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);

            return true;

        }

        private bool grdDeleteAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
                {
                    this.RemoveBackTable(grdObject.LayoutTable.Rows[rowIndex]);
                    this.SelectionBackColorChange(grdObject, rowIndex, "N");
                    grdObject.SetItemValue(rowIndex, "select", "N");
                }
            }
            //선택된 Row 표시
            SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);

            return true;
        }

        private bool SelectCurrentTab(string aGroupSer, bool IsSelect)
        {
            
            for (int i = 0; i < this.grdOCS1003.RowCount; i++)
            {
                if (this.grdOCS1003.GetItemString(i, "group_ser") == aGroupSer)
                {
                    if (IsSelect)
                        this.InsertBackTable(this.grdOCS1003.LayoutTable.Rows[i]);
                    else
                        this.RemoveBackTable(this.grdOCS1003.LayoutTable.Rows[i]);
                }
            }

            return true;
        }


        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            CreateReturnLayout();
        }

        private void chkIsNewGroup_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkIsNewGroup.Checked)
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkIsNewGroup.ImageIndex = 1;
                mIsNewGroupSer = true;

            }
            else
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkIsNewGroup.ImageIndex = 0;
                mIsNewGroupSer = false;
            }
        }
        
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            //bool isSelect = false;

            this.grdSelectAll(this.grdOCS1003);

            //if (this.btnSelectAllTab.Tag.ToString() == "N")
            //{
            //    isSelect = true;
            //    this.btnSelectAllTab.Tag = "Y";
            //    this.btnSelectAllTab.ImageIndex = 1;
            //    //this.btnSelectAllTab.Text = "全体オーダグループ選択取消";
            //}
            //else
            //{
            //    isSelect = false;
            //    this.btnSelectAllTab.Tag = "N";
            //    this.btnSelectAllTab.ImageIndex = 0;
            //    //this.btnSelectAllTab.Text = "全体オーダグループ選択";
            //}

            //foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            //{
            //    if (isSelect == true && tpg.ImageIndex == 1)
            //    {
            //        continue;
            //    }

            //    this.grdSelectAll(this.grdOCS1003, tpg.Tag.ToString(), isSelect);

            //    if (isSelect)
            //    {
            //        tpg.ImageIndex = 1;
            //    }
            //    else
            //    {
            //        tpg.ImageIndex = 0;
            //    }
            //}
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            this.grdDeleteAll(this.grdOCS1003);

            ////if (this.tabGroup.SelectedTab == null) return;

            //if (this.tabGroup.SelectedTab.ImageIndex == 0)
            //{
            //    this.SelectCurrentTab(this.tabGroup.SelectedTab.Tag.ToString(), true);
            //    this.tabGroup.SelectedTab.ImageIndex = 1;

            //}
            //else
            //{
            //    this.SelectCurrentTab(this.tabGroup.SelectedTab.Tag.ToString(), false);
            //    this.tabGroup.SelectedTab.ImageIndex = 0;
            //}

            //SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);
        }


        #region [ XTabPage ]

        private void tabGroup_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdOCS1003.RowCount; i++)
            {
                if (this.grdOCS1003.GetItemString(i, "group_ser") == this.tabGroup.SelectedTab.Tag.ToString())
                {
                    this.grdOCS1003.SetRowVisible(i, true);
                }
                else
                {
                    this.grdOCS1003.SetRowVisible(i, false);
                }
            }
        }

        #endregion

        #endregion

        #region [처방단위 CHECK]

        private bool CheckOrd_danui(string hangmog_code, string ord_danui)
        {
            bool chkExists = false;
            string cmdText = string.Empty;
            object retValu = null;
            cmdText = "SELECT FN_OCS_EXISTS_ORD_DANUI('" + hangmog_code + "', '" + ord_danui + "') "
                    + "  FROM DUAL ";
            retValu = Service.ExecuteScalar(cmdText);

            if (Service.ErrCode != 0 || retValu.ToString() == "")
                chkExists = false;
            else
                chkExists = true;

            return chkExists;
        }

        #endregion

        #region Mix Group 데이타 Image Display (DiaplayMixGroup)
        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DiaplayMixGroup(XEditGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                //aGrd.Redraw = false; // Grid Display 멈춤

                int imageCnt = 0;

                // 기존 image 클리어
                for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group
                            if (aGrd.GetItemValue(i, "input_gubun").ToString().Trim() == aGrd.GetItemValue(j, "input_gubun").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim() == aGrd.GetItemValue(j, "order_gubun").ToString().Trim() &&
                                aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim())
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                }
                            }
                        }
                        // 현재는 image 갯수만큼 처리
                        imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }
        #endregion

        #region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
        private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            //선택된 Row에대해서 색을 변경한다
            //data   Y :색을 변경, N :색을 변경 해제
            //image 설정
            if (data == "Y")
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
            }
            else
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
            }

            //for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            //{
            //    if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
            //    {
            //        // 돈복여부
            //        if (grdObject.GetItemString(currentRowIndex, "donbog_yn") == "Y")
            //        {
            //            grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
            //            continue;
            //        }

            //        // 불균등분할
            //        if (!TypeCheck.IsNull(grdObject.GetItemString(currentRowIndex, "dv_name")))
            //        {
            //            grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
            //            continue;
            //        }
            //    }

            //    if (data == "Y")
            //    {
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;

            //    }
            //    else
            //    {
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
            //    }
            //}
            //ntt
            this.childSetImage();
        }


        private void SelectionBackColorChange(object grid)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            //기존의 색으로 변경을 시킨다
            for (int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                //불용은 넘어간다.
                if (grdObject.CellInfos.Contains("bulyong_check") && grdObject.GetItemString(rowIndex, "bulyong_check") == "Y") continue;

                if (grdObject.GetItemString(rowIndex, "select").ToString() == " ")
                {
                    //image 변경
                    //if (grdObject.RowHeaderVisible)
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                    //else
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];

                    //ColorYn Y :색을 변경, N :색을 변경 해제
                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                        {
                            // 돈복여부
                            if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                continue;
                            }

                            // 불균등분할
                            if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                continue;
                            }
                        }

                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                    }
                }
                else
                {
                    //image 변경
                    //if (grdObject.RowHeaderVisible)
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                    //else
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                        {
                            // 돈복여부
                            if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                continue;
                            }

                            // 불균등분할
                            if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                continue;
                            }
                        }

                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                    }
                }
            }

            if (grdObject.Name == "grdOCS1003") DiaplayMixGroup(grdObject);

            //ntt
            this.childSetImage();
        }
        #endregion

        #region [외래/입원전환]
        private string IOGubun = "O";
        private void rbtOut_CheckedChanged(object sender, System.EventArgs e)
        {
            //외래
            //select 정보 reset
            //dloSelectOCS1001.Reset();
            //dloSelectOCS1003.Reset();

            //201009 그리드 리셋
            grdOCS1003.Reset();

            //현재선택된 row trans
            //OCS1003
            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                if (grdOCS1003.GetItemString(i, "select") == " ")
                    dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
            }

            if (rbtOut.Checked)
            {
                //입력구분
                //grdOCS1003.AutoSizeColumn(2, 0);

                //당일시행, 당일결과여부
                grdOCS1003.AutoSizeColumn(19, 30);
                grdOCS1003.AutoSizeColumn(20, 30);

                //insert by jc [rbtOut_CheckedChangedイベントを二度乗るのを防ぐ] 2012/03/23
                this.rbtOut.CheckedChanged -= new System.EventHandler(this.rbtOut_CheckedChanged);

                rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtOut.ImageIndex = 1;

                rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtIn.ImageIndex = 0;

                //grdOUT1001.SetBindVarValue("f_io_gubun", "O");
                IOGubun = "O";

            }
            //입원
            else
            {
                //입력구분
                //grdOCS1003.AutoSizeColumn(2, 77);

                //당일시행, 당일결과여부
                grdOCS1003.AutoSizeColumn(19, 30);
                grdOCS1003.AutoSizeColumn(20, 30);

                //insert by jc [rbtOut_CheckedChangedイベントを二度乗るのを防ぐ] 2012/03/23
                this.rbtIn.CheckedChanged -= new System.EventHandler(this.rbtOut_CheckedChanged);

                rbtIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtIn.ImageIndex = 1;

                rbtOut.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtOut.ImageIndex = 0;

                //grdOUT1001.SetBindVarValue("f_io_gubun", "I");
                IOGubun = "I";
            }

            grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);
            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

        }

        //insert by jc [rbtOut_CheckedChangedイベントを二度乗るのを防ぐ] 2012/03/23
        public void rbtEventCreate()
        {
            if (this.rbtOut.Checked)
                this.rbtOut.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
            else
                this.rbtIn.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
        }

        #endregion

        #region Order_gubun Tab 변경
        /// <summary>
        /// tab 변경시 해당 처방조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabOrderGubun_SelectionChanged(object sender, System.EventArgs e)
        {
            //if (tabOrderGubun.SelectedTab == null) return;

            //현재선택된 row trans
            //OCS1003
            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                if (grdOCS1003.GetItemString(i, "select") == " ")
                    dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
            }

            /*
            foreach (IHIS.X.Magic.Controls.TabPage page in tabOrderGubun.TabPages)
            {
                if (tabOrderGubun.SelectedTab == page)
                    page.ImageIndex = 1;
                else
                    page.ImageIndex = 0;
            }

            //column invible처리
            string input_tab = "%";
            if (tabOrderGubun.SelectedTab.Tag.ToString() == "1")
            {
                //내복약
                input_tab = "01";
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "2")
            {
                //외용약
                input_tab = "01";
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "3")
            {
                //주사
                input_tab = "02";
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "4")
            {
                //검사
                input_tab = "03";
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "5")
            {
                //방사선
                input_tab = "04";
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "6")
            {
                //처치
                input_tab = "05";
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "7")
            {
                //수술
                input_tab = "06";
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "8")
            {
                //마취
                input_tab = "07";
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "9")
            {
                //기타
                input_tab = "08";
            }
             * */

            foreach (XGridCell cell in grdOCS1003.CellInfos)
            {
                if (cell.IsVisible)
                {
                    if (mInput_tab == "%" || this.mInputControl.IsVisibleColumn(mInput_tab, cell.CellName))
                    {
                        grdOCS1003.AutoSizeColumn(cell.Col, cell.CellWidth);
                    }
                    else
                    {
                        if (cell.CellName == "child_gubun")
                            grdOCS1003.AutoSizeColumn(cell.Col, cell.CellWidth);
                        else
                            grdOCS1003.AutoSizeColumn(cell.Col, 0);
                    }
                }
            }

            //검사인 경우에는 실시일 기준으로 조회한다.
            //if (tabOrderGubun.SelectedTab.Tag.ToString() == "4" || tabOrderGubun.SelectedTab.Tag.ToString() == "5")
            if(mInput_tab.Equals("04") || mInput_tab.Equals("05") || mInput_tab.Equals("06"))
            {
                grdOUT1001[0, grdOUT1001.CellInfos["naewon_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "日付" : "일자";
                this.grdOUT1001.AutoSizeColumn(6, 0);
                this.grdOUT1001.AutoSizeColumn(7, 0);
                this.grdOCS1003.AutoSizeColumn(3, 80);

                #region [[  grdOUT1001 & grdOCS1001 QuerySQL Setting  ]]
                this.grdOUT1001.QuerySQL = @"SELECT DISTINCT    -- 4
       NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                                         NAEWON_DATE,
       A.GWA                             GWA,
       FN_BAS_LOAD_GWA_NAME( A.GWA, A.ORDER_DATE)
                                         GWA_NAME,
       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)
                                         DOCTOR_NAME,
       0                                 NALSU,
       A.BUNHO                           BUNHO,
       A.DOCTOR                          DOCTOR,
       ''                                GUBUN_NAME ,
       ''                                CHOJAE_NAME,
       '0'                               NAEWON_TYPE,
       0                                 JUBSU_NO   ,
       A.BUNHO||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||A.GWA||A.DOCTOR
                                         PK_ORDER,
       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
       :f_tel_yn                         TEL_YN,
       'N'                               TOIWON_DRG,
       :f_input_tab                      INPUT_TAB,
       :f_io_gubun                       IO_GUBUN
  FROM OCS1003 A
 WHERE :f_io_gubun    = 'O'
   AND A.BUNHO        = :f_bunho
   AND A.ORDER_DATE  < :f_naewon_date
   AND A.GWA         LIKE :f_gwa
   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
        ( :f_input_gubun = 'NR'           ) OR
        ( :f_input_gubun = 'D%'           ))
   AND NVL(A.TEL_YN     , 'N') LIKE :f_tel_yn
   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
   AND NVL(A.DC_YN,'N')        = 'N'
   AND A.NALSU                 >= 0
   AND A.INPUT_TAB            = :f_input_tab
--   AND (( :f_input_tab = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'       ) OR
--        ( :f_input_tab = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'       ))
   AND A.HOSP_CODE = :f_hosp_code        
UNION ALL
SELECT DISTINCT
       NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                                         NAEWON_DATE,
       A.INPUT_GWA                       GWA        ,
       FN_BAS_LOAD_GWA_NAME( A.INPUT_GWA, A.ORDER_DATE)
                                         GWA_NAME,
       FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE)
                                         DOCTOR_NAME,
       0                                 NALSU,
       A.BUNHO                           BUNHO      ,
       A.INPUT_DOCTOR                    DOCTOR     ,
       ' '                               GUBUN_NAME ,
       ' '                               CHOJAE_NAME,
       '0'                               NAEWON_TYPE,
       A.FKINP1001                       JUBSU_NO   ,
       A.BUNHO||RTRIM(TO_CHAR(A.FKINP1001))||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||RPAD(A.INPUT_GWA, 10)||RPAD(A.INPUT_DOCTOR, 10)
                                         PK_ORDER   ,
       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
       :f_tel_yn                         TEL_YN,
       'N'                               TOIWON_DRG,
       :f_input_tab                      INPUT_TAB,
       :f_io_gubun                       IO_GUBUN
  FROM OCS2003 A
 WHERE :f_io_gubun            = 'I'
   AND A.BUNHO                = :f_bunho
   AND A.ORDER_DATE          <= :f_naewon_date
   AND A.INPUT_GWA            LIKE :f_gwa
   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
        ( :f_input_gubun = 'NR'           ) OR
        ( :f_input_gubun = 'D%'           ))
   AND A.IO_GUBUN             IS NULL
   AND A.NALSU               >= 0
   AND NVL(A.DISPLAY_YN,'Y')  = 'Y'
   AND NVL(A.DC_YN,'N')       = 'N'
   AND A.INPUT_TAB            = :f_input_tab
--   AND (( :f_input_tab = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'       ) OR
--        ( :f_input_tab = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'       ))
   AND A.FKINP1001            = ( SELECT MAX(C.PKINP1001)
                                    FROM VW_OCS_INP1001_02 C
                                   WHERE C.BUNHO       = :f_bunho
                                     AND C.IPWON_DATE <= :f_naewon_date
                                     AND C.HOSP_CODE   = :f_hosp_code   )
   AND A.HOSP_CODE = :f_hosp_code        
 ORDER BY 12 DESC";

                this.grdOCS1003.QuerySQL = @"SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
       A.GROUP_SER                                                GROUP_SER               ,
       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
       A.HANGMOG_CODE                                             HANGMOG_CODE            ,
       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
              THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
       A.SURYANG                                                  SURYANG                 ,
       A.ORD_DANUI                                                ORD_DANUI               ,
       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
       A.DV_TIME                                                  DV_TIME                 ,
       A.DV                                                       DV                      ,
       A.NALSU                                                    NALSU                   ,
       A.JUSA                                                     JUSA                    ,
       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
       A.BOGYONG_CODE                                             BOGYONG_CODE            ,
       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                  BOGYONG_NAME            ,
       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
       A.PHARMACY                                                 PHARMACY                ,
       A.DRG_PACK_YN                                              DRG_PACK_YN             ,
       A.POWDER_YN                                                POWDER_YN               ,
       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
       NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN   ,
       NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                         DANGIL_GUMSA_RESULT_YN  ,
       NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
       A.PAY                                                      PAY                     ,
       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
       A.MUHYO                                                    MUHYO                   ,
       A.PORTABLE_YN                                              PORTABLE_YN             ,
       A.OCS_FLAG                                                 OCS_FLAG                ,
       A.ORDER_GUBUN                                              ORDER_GUBUN             ,
       A.INPUT_TAB                                                INPUT_TAB               ,
       A.INPUT_GUBUN                                              INPUT_GUBUN             ,
       A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,
       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
       A.JUNDAL_PART                                              JUNDAL_PART             ,
       A.MOVE_PART                                                MOVE_PART               ,
       A.BUNHO                                                    BUNHO                   ,
       A.ORDER_DATE                                               NAEWON_DATE             ,
       A.GWA                                                      GWA                     ,
       A.DOCTOR                                                   DOCTOR                  ,
       A.NAEWON_TYPE                                              NAEWON_TYPE             ,
       A.FKOUT1001                                                PK_ORDER                ,
       A.SEQ                                                      SEQ                     ,
       A.PKOCS1003                                                PKOCS1003               ,
       A.SUB_SUSUL                                                SUB_SUSUL               ,
       A.SUTAK_YN                                                 SUTAK_YN                ,
       A.AMT                                                      AMT                     ,
       A.DV_1                                                     DV_1                    ,
       A.DV_2                                                     DV_2                    ,
       A.DV_3                                                     DV_3                    ,
       A.DV_4                                                     DV_4                    ,
       A.HOPE_DATE                                                HOPE_DATE               ,
       A.ORDER_REMARK                                             ORDER_REMARK            ,
       A.MIX_GROUP                                                MIX_GROUP               ,
       A.HOME_CARE_YN                                             HOME_CARE_YN            ,
       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
       A.GONGBI_CODE                                              GONGBI_CODE             ,
       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
       DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                  DONBOK_YN               ,
       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4)
                                                                  DV_NAME                 ,
       B.SLIP_CODE                                                SLIP_CODE               ,
       B.GROUP_YN                                                 GROUP_YN                ,
       B.SG_CODE                                                  SG_CODE                 ,
       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
       B.INPUT_CONTROL                                            INPUT_CONTROL           ,
       NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
       DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
       NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
       NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
       B.ORD_DANUI                                                ORD_DANUI_BAS           ,
       A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
       A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
       ( CASE WHEN FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE) <> 'Y'
              THEN 'N'
              WHEN FN_OCS_BULYONG_CHECK_OUT   (B.HANGMOG_CODE, SYSDATE) = 'Y'
               AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, TRUNC(SYSDATE)) <> A.HANGMOG_CODE
              THEN 'Z'
              ELSE 'Y' END )                                      BULYONG_CHECK           ,
       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
       NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
       NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
       A.TEL_YN                                                   TEL_YN                  ,
       E.BUN_CODE                                                 BUN_CODE                ,
       E.SG_GESAN                                                 SG_GESAN                ,
       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
       ''                                                         DRG_BUNRYU              ,
       DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('O',A.PKOCS1003),'3')      CHILD_GUBUN,
       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,      
       A.PKOCS1003                                               PARENTS_KEY,
       A.BOM_SOURCE_KEY                                          CHILD_KEY,
       LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||
       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B')
               AND A.HOPE_DATE IS NOT NULL
              THEN TO_CHAR(A.HOPE_DATE, 'YYYYMMDD')
              ELSE '00000000' END )||
       LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                                    CONT_KEY
  FROM OCS0140 G,
       OCS0132 F,
       BAS0310 E,
       OCS0116 D,
       OCS0132 C,
       OCS0103 B,
       OCS1003 A
 WHERE A.BUNHO            = :f_bunho
   AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) = :f_naewon_date
   AND A.GWA              = :f_gwa
   AND A.DOCTOR           = :f_doctor
   AND A.INPUT_TAB        = :f_input_tab
   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
        ( :f_input_gubun = 'NR'           ) OR
        ( :f_input_gubun = 'D%'           ))
   AND NVL(A.TEL_YN     , 'N') LIKE :f_tel_yn
   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
   AND NVL(A.DC_YN,'N')   = 'N'
   AND A.NALSU           >= 0
   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
   AND C.CODE     (+)     = A.ORDER_GUBUN
   AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'
   AND F.CODE     (+)     = A.INPUT_GUBUN
   AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
   AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
   AND E.SG_CODE  (+)     = B.SG_CODE
   AND G.ORDER_GUBUN      = A.ORDER_GUBUN
   AND G.INPUT_TAB        = A.INPUT_TAB
--   AND (( :f_input_tab = '%'           ) OR
--        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
--        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
--        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
--        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
--        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
--        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
--        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
--        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
--        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
UNION ALL
SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
       A.GROUP_SER                                                GROUP_SER               ,
       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
       A.HANGMOG_CODE                                             HANGMOG_CODE            ,
       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
              THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
       A.SURYANG                                                  SURYANG                 ,
       A.ORD_DANUI                                                ORD_DANUI               ,
       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
       A.DV_TIME                                                  DV_TIME                 ,
       A.DV                                                       DV                      ,
       A.NALSU                                                    NALSU                   ,
       A.JUSA                                                     JUSA                    ,
       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
       A.BOGYONG_CODE                                             BOGYONG_CODE            ,
       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                  BOGYONG_NAME            ,
       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
       A.PHARMACY                                                 PHARMACY                ,
       A.DRG_PACK_YN                                              DRG_PACK_YN             ,
       A.POWDER_YN                                                POWDER_YN               ,
       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
       'N'                                                        DANGIL_GUMSA_ORDER_YN   ,
       'N'                                                        DANGIL_GUMSA_RESULT_YN  ,
       NVL(A.EMERGENCY  , 'N')                                    EMERGENCY               ,
       A.PAY                                                      PAY                     ,
       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
       A.MUHYO                                                    MUHYO                   ,
       A.PORTABLE_YN                                              PORTABLE_YN             ,
       A.OCS_FLAG                                                 OCS_FLAG                ,
       A.ORDER_GUBUN                                              ORDER_GUBUN             ,
       A.INPUT_TAB                                                INPUT_TAB               ,
       A.INPUT_GUBUN                                              INPUT_GUBUN             ,
       'N'                                                        AFTER_ACT_YN            ,
       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
       A.JUNDAL_PART                                              JUNDAL_PART             ,
       NULL                                                       MOVE_PART               ,
       A.BUNHO                                                    BUNHO                   ,
       A.ORDER_DATE                                               NAEWON_DATE             ,
       A.INPUT_PART                                               GWA                     ,
       A.INPUT_ID                                                 DOCTOR                  ,
       '0'                                                        NAEWON_TYPE             ,
       A.FKINP1001                                                PK_ORDER                ,
       A.SEQ                                                      SEQ                     ,
       A.PKOCS2003                                                PKOCS1003               ,
       A.SUB_SUSUL                                                SUB_SUSUL               ,
       NULL                                                       SUTAK_YN                ,
       A.AMT                                                      AMT                     ,
       A.DV_1                                                     DV_1                    ,
       A.DV_2                                                     DV_2                    ,
       A.DV_3                                                     DV_3                    ,
       A.DV_4                                                     DV_4                    ,
       A.HOPE_DATE                                                HOPE_DATE               ,
       A.ORDER_REMARK                                             ORDER_REMARK            ,
       A.MIX_GROUP                                                MIX_GROUP               ,
       'N'                                                        HOME_CARE_YN            ,
       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
       A.GONGBI_CODE                                              GONGBI_CODE             ,
       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
       DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                  DONBOK_YN               ,
       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4)
                                                                  DV_NAME                 ,
       B.SLIP_CODE                                                SLIP_CODE               ,
       B.GROUP_YN                                                 GROUP_YN                ,
       B.SG_CODE                                                  SG_CODE                 ,
       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
       B.INPUT_CONTROL                                            INPUT_CONTROL           ,
       NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
       DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
       NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
       NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
       B.ORD_DANUI                                                ORD_DANUI_BAS           ,
       A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
       A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
       FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
       NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
       NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
       A.TEL_YN                                                   TEL_YN                  ,
       E.BUN_CODE                                                 BUN_CODE                ,
       E.SG_GESAN                                                 SG_GESAN                ,
       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
       ''                                                         DRG_BUNRYU              ,
       DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('I',A.PKOCS2003),'3')      CHILD_GUBUN,
       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,
       A.PKOCS2003                                               PARENTS_KEY,
       A.BOM_SOURCE_KEY                                          CHILD_KEY,
       LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                                        CONT_KEY
  FROM OCS0140 G,
       OCS0132 F,
       BAS0310 E,
       OCS0116 D,
       OCS0132 C,
       OCS0103 B,
       OCS2003 A
 WHERE A.BUNHO            = :f_bunho
   AND A.FKINP1001        = :f_jubsu_no
   AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) = :f_naewon_date
   AND A.INPUT_GWA        = :f_gwa
   AND A.INPUT_DOCTOR     = :f_doctor
   AND A.INPUT_TAB        = :f_input_tab
   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
        ( :f_input_gubun = 'NR'           ) OR
        ( :f_input_gubun = 'D%'           ))
   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
   AND NVL(A.DC_YN,'N')   = 'N'
   AND A.NALSU           >= 0
   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
   AND C.CODE     (+)     = A.ORDER_GUBUN
   AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'
   AND F.CODE     (+)     = A.INPUT_GUBUN
   AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
   AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
   AND E.SG_CODE  (+)     = B.SG_CODE
   AND G.ORDER_GUBUN      = A.ORDER_GUBUN
   AND G.INPUT_TAB        = A.INPUT_TAB
--   AND (( :f_input_tab = '%'           ) OR
--        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
--        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
--        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
--        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
--        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
--        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
--        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
--        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
--        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
 ORDER BY 92";
                #endregion
                //this.dsvLDOUT1001.WorkTp = '4';
                //this.dsvLDOCS1003.WorkTp = '5';
                //this.pnlSang.Visible = false;
            }
            else
            {
                grdOUT1001[0, grdOUT1001.CellInfos["naewon_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "オ―ダ日付" : "Order일자";
                this.grdOUT1001.AutoSizeColumn(6, 80);
                this.grdOUT1001.AutoSizeColumn(7, 80);
                this.grdOCS1003.AutoSizeColumn(3, 0);

                #region [[  grdOUT1001 & grdOCS1001 QuerySQL Setting  ]]
                this.grdOUT1001.QuerySQL = @"SELECT A.NAEWON_DATE                     NAEWON_DATE,      -- 1
       A.GWA                             GWA,
       FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE)
                                         GWA_NAME,
       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                                         DOCTOR_NAME,
       0                                 NALSU,
       A.BUNHO                           BUNHO,
       A.DOCTOR                          DOCTOR,
       FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.NAEWON_DATE)
                                         GUBUN_NAME ,
       FN_BAS_LOAD_CODE_NAME ('CHOJAE', A.CHOJAE)
                                         CHOJAE_NAME,
       A.NAEWON_TYPE                     NAEWON_TYPE,
       A.JUBSU_NO                        JUBSU_NO   ,
       A.PKOUT1001                       PK_ORDER,
       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
       :f_tel_yn                         TEL_YN,
       'N'                               TOIWON_DRG,
       :f_input_tab                      INPUT_TAB,
       :f_io_gubun                       IO_GUBUN
  FROM OUT1001 A
 WHERE :f_io_gubun    = 'O'
   AND A.BUNHO        = :f_bunho
   AND A.NAEWON_DATE <= :f_naewon_date
   AND A.GWA         LIKE :f_gwa
   AND A.HOSP_CODE    = :f_hosp_code
   AND EXISTS( SELECT 'X'
                 FROM OCS0140 C,
                      OCS1003 B
                WHERE B.BUNHO        = A.BUNHO
                  AND B.ORDER_DATE   = A.NAEWON_DATE
                  AND B.GWA          = A.GWA
                  AND B.DOCTOR       = A.DOCTOR
                  AND B.NAEWON_TYPE  = A.NAEWON_TYPE
                  AND B.HOSP_CODE    = A.HOSP_CODE
                  AND NVL(B.TEL_YN     , 'N') LIKE :f_tel_yn
                  AND NVL(B.DISPLAY_YN , 'Y') = 'Y'
                  AND NVL(B.DC_YN,'N')   = 'N'
                  AND B.NALSU           >= 0
                  AND (( B.INPUT_GUBUN  = :f_input_gubun ) OR
                       ( :f_input_gubun = 'NR'           ) OR
                       ( :f_input_gubun = 'D%'           ))
                  AND B.INPUT_TAB       = :f_input_tab
                  AND C.ORDER_GUBUN     = B.ORDER_GUBUN
                  AND C.HOSP_CODE       = B.HOSP_CODE
                  AND C.INPUT_TAB       = B.INPUT_TAB
--                  AND (( :f_input_tab = '%'           ) OR
--                       ( :f_input_tab = '1' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'C'       ) OR
--                       ( :f_input_tab = '2' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'D'       ) OR
--                       ( :f_input_tab = '3' AND C.INPUT_TAB                 = '02'      ) OR
--                       ( :f_input_tab = '4' AND C.INPUT_TAB                 = '03'      ) OR
--                       ( :f_input_tab = '5' AND C.INPUT_TAB                 = '04'      ) OR
--                       ( :f_input_tab = '6' AND C.INPUT_TAB                 = '05'      ) OR
--                       ( :f_input_tab = '7' AND C.INPUT_TAB                 = '06'      ) OR
--                       ( :f_input_tab = '8' AND C.INPUT_TAB                 = '07'      ) OR
--                       ( :f_input_tab = '9' AND C.INPUT_TAB                 = '08'      ) )
                  AND ROWNUM = 1 )
UNION ALL
SELECT DISTINCT
       A.ORDER_DATE                      NAEWON_DATE,
       A.INPUT_GWA                       GWA        ,
       FN_BAS_LOAD_GWA_NAME( A.INPUT_GWA, A.ORDER_DATE)
                                         GWA_NAME,
       FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE)
                                         DOCTOR_NAME,
       0                                 NALSU,
       A.BUNHO                           BUNHO      ,
       A.INPUT_DOCTOR                    DOCTOR     ,
       ' '                               GUBUN_NAME ,
       ' '                               CHOJAE_NAME,
       '0'                               NAEWON_TYPE,
       A.FKINP1001                       JUBSU_NO   ,
       A.FKINP1001                       PK_ORDER   ,
       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
       :f_tel_yn                         TEL_YN     ,
       FN_OCS_EXISTS_TOIWON_DRG(A.BUNHO, A.FKINP1001, A.ORDER_DATE)
                                                 TOIWON_DRG,
       :f_input_tab                      INPUT_TAB,
       :f_io_gubun                       IO_GUBUN
  FROM OCS0140  B,
       OCS2003  A
 WHERE :f_io_gubun       = 'I'
   AND A.BUNHO           = :f_bunho
   AND A.ORDER_DATE     <= :f_naewon_date
   AND A.INPUT_GWA       LIKE :f_gwa
   AND A.HOSP_CODE       = :f_hosp_code
   AND A.IO_GUBUN        IS NULL
   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
        ( :f_input_gubun = 'NR'           ) OR
        ( :f_input_gubun = 'D%'           ))
   AND A.NALSU               >= 0
   AND NVL(A.DISPLAY_YN ,'Y') = 'Y'
   AND NVL(A.DC_YN      ,'N') = 'N'
   AND B.ORDER_GUBUN     = A.ORDER_GUBUN
   AND B.HOSP_CODE       = A.HOSP_CODE
   AND B.INPUT_TAB       = A.INPUT_TAB
   AND B.INPUT_TAB       = :f_input_tab
--   AND (( :f_input_tab = '%'           ) OR
--        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
--        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
--        ( :f_input_tab = '3' AND B.INPUT_TAB                 = '02'      ) OR
--        ( :f_input_tab = '4' AND B.INPUT_TAB                 = '03'      ) OR
--        ( :f_input_tab = '5' AND B.INPUT_TAB                 = '04'      ) OR
--        ( :f_input_tab = '6' AND B.INPUT_TAB                 = '05'      ) OR
--        ( :f_input_tab = '7' AND B.INPUT_TAB                 = '06'      ) OR
--        ( :f_input_tab = '8' AND B.INPUT_TAB                 = '07'      ) OR
--        ( :f_input_tab = '9' AND B.INPUT_TAB                 = '08'      ) )
   AND A.ORDER_DATE          >= ( SELECT MAX(C.TOIWON_DATE) - 90
                                    FROM VW_OCS_INP1001_02 C
                                   WHERE C.BUNHO       = :f_bunho
                                     AND C.IPWON_DATE <= :f_naewon_date
                                     AND C.HOSP_CODE   = :f_hosp_code   )
  ORDER BY 12 DESC";

                this.grdOCS1003.QuerySQL = @"SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
       A.GROUP_SER                                                GROUP_SER               ,
       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
       A.HANGMOG_CODE                                             HANGMOG_CODE            ,
       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
              THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
       A.SURYANG                                                  SURYANG                 ,
       A.ORD_DANUI                                                ORD_DANUI               ,
       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
       A.DV_TIME                                                  DV_TIME                 ,
       A.DV                                                       DV                      ,
       A.NALSU                                                    NALSU                   ,
       A.JUSA                                                     JUSA                    ,
       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
       A.BOGYONG_CODE                                             BOGYONG_CODE            ,
       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                  BOGYONG_NAME            ,
       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
       A.PHARMACY                                                 PHARMACY                ,
       A.DRG_PACK_YN                                              DRG_PACK_YN             ,
       A.POWDER_YN                                                POWDER_YN               ,
       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
       NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN   ,
       NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                         DANGIL_GUMSA_RESULT_YN  ,
       NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
       A.PAY                                                      PAY                     ,
       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
       A.MUHYO                                                    MUHYO                   ,
       A.PORTABLE_YN                                              PORTABLE_YN             ,
       A.OCS_FLAG                                                 OCS_FLAG                ,
       A.ORDER_GUBUN                                              ORDER_GUBUN             ,
       A.INPUT_TAB                                                INPUT_TAB               ,
       A.INPUT_GUBUN                                              INPUT_GUBUN             ,
       A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,
       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
       A.JUNDAL_PART                                              JUNDAL_PART             ,
       A.MOVE_PART                                                MOVE_PART               ,
       A.BUNHO                                                    BUNHO                   ,
       A.ORDER_DATE                                               ORDER_DATE              ,
       A.GWA                                                      GWA                     ,
       A.DOCTOR                                                   DOCTOR                  ,
       A.NAEWON_TYPE                                              NAEWON_TYPE             ,
       A.FKOUT1001                                                PK_ORDER                ,
       A.SEQ                                                      SEQ                     ,
       A.PKOCS1003                                                PKOCS1003               ,
       A.SUB_SUSUL                                                SUB_SUSUL               ,
       A.SUTAK_YN                                                 SUTAK_YN                ,
       A.AMT                                                      AMT                     ,
       A.DV_1                                                     DV_1                    ,
       A.DV_2                                                     DV_2                    ,
       A.DV_3                                                     DV_3                    ,
       A.DV_4                                                     DV_4                    ,
       A.HOPE_DATE                                                HOPE_DATE               ,
       A.ORDER_REMARK                                             ORDER_REMARK            ,
       A.MIX_GROUP                                                MIX_GROUP               ,
       A.HOME_CARE_YN                                             HOME_CARE_YN            ,
       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
       A.GONGBI_CODE                                              GONGBI_CODE             ,
       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
       DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                  DONBOK_YN               ,
       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4)
                                                                  DV_NAME                 ,
       B.SLIP_CODE                                                SLIP_CODE               ,
       B.GROUP_YN                                                 GROUP_YN                ,
       B.SG_CODE                                                  SG_CODE                 ,
       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
       B.INPUT_CONTROL                                            INPUT_CONTROL           ,
       NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
       DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
       NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
       NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
       B.ORD_DANUI                                                ORD_DANUI_BAS           ,
       A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
       A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
       ( CASE WHEN FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE) <> 'Y'
              THEN 'N'
              WHEN FN_OCS_BULYONG_CHECK_OUT   (B.HANGMOG_CODE, SYSDATE) = 'Y'
               AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, TRUNC(SYSDATE)) <> A.HANGMOG_CODE
              THEN 'Z'
              ELSE 'Y' END )                                      BULYONG_CHECK           ,
       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
       NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
       NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
       A.TEL_YN                                                   TEL_YN                  ,
       E.BUN_CODE                                                 BUN_CODE                ,
       E.SG_GESAN                                                 SG_GESAN                ,
       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
       ''                                                         DRG_BUNRYU              ,
       DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('O',A.PKOCS1003),'3')      CHILD_GUBUN,
       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,   
       A.PKOCS1003                                               PARENTS_KEY,
       A.BOM_SOURCE_KEY                                          CHILD_KEY,
       LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||
       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B')
               AND A.HOPE_DATE IS NOT NULL
              THEN TO_CHAR(A.HOPE_DATE, 'YYYYMMDD')
              ELSE '00000000' END )||
       LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                                  CONT_KEY
  FROM OCS0140 G,
       OCS0132 F,
       BAS0310 E,
       OCS0116 D,
       OCS0132 C,
       OCS0103 B,
       OCS1003 A
 WHERE A.BUNHO            = :f_bunho
   AND A.ORDER_DATE       = :f_naewon_date
   AND A.GWA              = :f_gwa
   AND A.DOCTOR           = :f_doctor
   AND A.NAEWON_TYPE      = :f_naewon_type
   AND A.INPUT_TAB        = :f_input_tab
   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
        ( :f_input_gubun = 'NR'           ) OR
        ( :f_input_gubun = 'D%'           ))
   AND NVL(A.TEL_YN     , 'N') LIKE :f_tel_yn
   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
   AND NVL(A.DC_YN,'N')   = 'N'
   AND A.NALSU           >= 0
   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
   AND C.CODE     (+)     = A.ORDER_GUBUN
   AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'
   AND F.CODE     (+)     = A.INPUT_GUBUN
   AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
   AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
   AND E.SG_CODE  (+)     = B.SG_CODE
   AND G.ORDER_GUBUN      = A.ORDER_GUBUN
   AND G.INPUT_TAB        = A.INPUT_TAB
--   AND (( :f_input_tab = '%'           ) OR
--        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
--        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
--        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
--        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
--        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
--        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
--        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
--        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
--        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
UNION ALL
SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
       A.GROUP_SER                                                GROUP_SER               ,
       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
       A.HANGMOG_CODE                                             HANGMOG_CODE            ,
       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
              THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
       A.SURYANG                                                  SURYANG                 ,
       A.ORD_DANUI                                                ORD_DANUI               ,
       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
       A.DV_TIME                                                  DV_TIME                 ,
       A.DV                                                       DV                      ,
       A.NALSU                                                    NALSU                   ,
       A.JUSA                                                     JUSA                    ,
       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
       A.BOGYONG_CODE                                             BOGYONG_CODE            ,
       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                  BOGYONG_NAME            ,
       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
       A.PHARMACY                                                 PHARMACY                ,
       A.DRG_PACK_YN                                              DRG_PACK_YN             ,
       A.POWDER_YN                                                POWDER_YN               ,
       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
       'N'                                                        DANGIL_GUMSA_ORDER_YN   ,
       'N'                                                        DANGIL_GUMSA_RESULT_YN  ,
       NVL(A.EMERGENCY  , 'N')                                    EMERGENCY               ,
       A.PAY                                                      PAY                     ,
       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
       A.MUHYO                                                    MUHYO                   ,
       A.PORTABLE_YN                                              PORTABLE_YN             ,
       A.OCS_FLAG                                                 OCS_FLAG                ,
       A.ORDER_GUBUN                                              ORDER_GUBUN             ,
       A.INPUT_TAB                                                INPUT_TAB               ,
       A.INPUT_GUBUN                                              INPUT_GUBUN             ,
       'N'                                                        AFTER_ACT_YN            ,
       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
       A.JUNDAL_PART                                              JUNDAL_PART             ,
       NULL                                                       MOVE_PART               ,
       A.BUNHO                                                    BUNHO                   ,
       A.ORDER_DATE                                               NAEWON_DATE             ,
       A.INPUT_PART                                               GWA                     ,
       A.INPUT_ID                                                 DOCTOR                  ,
       '0'                                                        NAEWON_TYPE             ,
       A.FKINP1001                                                PK_ORDER                ,
       A.SEQ                                                      SEQ                     ,
       A.PKOCS2003                                                PKOCS1003               ,
       A.SUB_SUSUL                                                SUB_SUSUL               ,
       NULL                                                       SUTAK_YN                ,
       A.AMT                                                      AMT                     ,
       A.DV_1                                                     DV_1                    ,
       A.DV_2                                                     DV_2                    ,
       A.DV_3                                                     DV_3                    ,
       A.DV_4                                                     DV_4                    ,
       A.HOPE_DATE                                                HOPE_DATE               ,
       A.ORDER_REMARK                                             ORDER_REMARK            ,
       A.MIX_GROUP                                                MIX_GROUP               ,
       'N'                                                        HOME_CARE_YN            ,
       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
       A.GONGBI_CODE                                              GONGBI_CODE             ,
       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
       DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                  DONBOK_YN               ,
       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4)
                                                                  DV_NAME                 ,
       B.SLIP_CODE                                                SLIP_CODE               ,
       B.GROUP_YN                                                 GROUP_YN                ,
       B.SG_CODE                                                  SG_CODE                 ,
       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
       B.INPUT_CONTROL                                            INPUT_CONTROL           ,
       NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
       DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
       NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
       NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
       B.ORD_DANUI                                                ORD_DANUI_BAS           ,
       A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
       A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
       FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
       NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
       NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
       A.TEL_YN                                                   TEL_YN                  ,
       E.BUN_CODE                                                 BUN_CODE                ,
       E.SG_GESAN                                                 SG_GESAN                ,
       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
       ''                                                         DRG_BUNRYU              ,
       DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('I',A.PKOCS2003),'3')      CHILD_GUBUN,
       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,   
       A.PKOCS2003                                               PARENTS_KEY,
       A.BOM_SOURCE_KEY                                          CHILD_KEY,
       LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                                  CONT_KEY
  FROM OCS0140 G,
       OCS0132 F,
       BAS0310 E,
       OCS0116 D,
       OCS0132 C,
       OCS0103 B,
       OCS2003 A
 WHERE A.BUNHO            = :f_bunho
   AND A.FKINP1001        = :f_jubsu_no
   AND A.ORDER_DATE       = :f_naewon_date
   AND A.INPUT_GWA        = :f_gwa
   AND A.INPUT_DOCTOR     = :f_doctor
   AND A.INPUT_TAB        = :f_input_tab
   AND (( A.INPUT_GUBUN   = :f_input_gubun ) OR
        ( :f_input_gubun  = 'NR'           ) OR
        ( :f_input_gubun  = 'D%'           ))
   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
   AND NVL(A.DC_YN,'N')   = 'N'
   AND A.NALSU           >= 0
   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
   AND C.CODE     (+)     = A.ORDER_GUBUN
   AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'
   AND F.CODE     (+)     = A.INPUT_GUBUN
   AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
   AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
   AND E.SG_CODE  (+)     = B.SG_CODE
   AND G.ORDER_GUBUN      = A.ORDER_GUBUN
   AND G.INPUT_TAB        = A.INPUT_TAB
--   AND (( :f_input_tab = '%'           ) OR
--        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
--        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
--        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
--        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
--        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
--        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
--        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
--        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
--        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
 ORDER BY 92";
                #endregion
                //this.dsvLDOUT1001.WorkTp = '1';
                //this.dsvLDOCS1003.WorkTp = '3';
                //this.pnlSang.Visible = true;
            }

            grdOUT1001.SetBindVarValue("f_naewon_date", dpkNaewon_date.GetDataValue());
            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        #endregion

        #region [검사정보조회]

        // 검사정보조회
        private void PopUpMenuGumsaInfo_Click(object sender, System.EventArgs e)
        {
            if (this.CurrMSLayout == null || CurrMSLayout.CurrentRowNumber < 0) return;

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("hangmog_code", CurrMSLayout.GetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_code"));
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        #endregion

        #region ntt childSetImage
        private void childSetImage()
        {
            for (int i = 0; i < this.grdOCS1003.RowCount; i++)
            {
                //this.grdOCS1003[i, "child_yn"].ForeColor = IHIS.Framework.XColor.XGridColHeaderForeColor;
                switch (this.grdOCS1003.GetItemString(i, "child_yn"))
                {
                    case "Y":
                        this.grdOCS1003[i, "child_yn"].Image = this.ImageList.Images[6];
                        break;
                    case "N":
                        this.grdOCS1003[i, "child_yn"].Image = this.ImageList.Images[4];
                        break;
                    default:
                        this.grdOCS1003[i, "child_yn"].Image = this.ImageList.Images[4];
                        break;

                }
                this.grdOCS1003[i, "child_yn"].ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region 각 그리드에 바인드 변수 설정
        private void grdOCS1003_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS1003.SetBindVarValue("f_bunho",       grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "bunho"));
            grdOCS1003.SetBindVarValue("f_naewon_date", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "naewon_date").Replace(" 0:00:00", ""));
            grdOCS1003.SetBindVarValue("f_gwa",         grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "gwa"));
            grdOCS1003.SetBindVarValue("f_doctor",      grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "doctor"));
            grdOCS1003.SetBindVarValue("f_naewon_type", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "naewon_type"));
            grdOCS1003.SetBindVarValue("f_input_gubun", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "input_gubun"));
            grdOCS1003.SetBindVarValue("f_tel_yn",      grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "tel_yn"));
            grdOCS1003.SetBindVarValue("f_input_tab",   grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "input_tab"));
            grdOCS1003.SetBindVarValue("f_jubsu_no",    grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "jubsu_no"));
            grdOCS1003.SetBindVarValue("f_pk_order", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "pk_order"));
            grdOCS1003.SetBindVarValue("f_hosp_code",   mHospCode);
        }

        private void grdOUT1001_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOUT1001.SetBindVarValue("f_bunho",       mBunho);
            grdOUT1001.SetBindVarValue("f_input_gubun", mInput_gubun);
            grdOUT1001.SetBindVarValue("f_tel_yn",      mTel_yn);
            grdOUT1001.SetBindVarValue("f_hosp_code",   mHospCode);
            grdOUT1001.SetBindVarValue("f_io_gubun",    IOGubun);
            grdOUT1001.SetBindVarValue("f_input_tab",   mInput_tab);
        }
        #endregion

        private void xButtonList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this.mOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }

        private void grdOCS1003_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void grdOUT1001_MouseDown(object sender, MouseEventArgs e)
        {
            //delete by jc [リストで選択機能を外してほしいって事で注釈処理] 2012/03/22
            //int rowIndex;
            
            // if (e.Button == MouseButtons.Left && e.Clicks == 1)
            //{
            //    rowIndex = grdOUT1001.GetHitRowNumber(e.Y);
            //    if (rowIndex < 0) return;

            //    if (grdOUT1001.CurrentColName != "select")
            //    {
            //        return;
            //    }
            //    if (grdOUT1001.GetItemString(rowIndex, "select") == "N")
            //    {
            //        grdOUT1001.SetItemValue(rowIndex, "select", "Y");
            //        SelectionBackColorChange(grdOUT1001, rowIndex, "Y");
            //        this.grdSelectAll(this.grdOCS1003);
            //    }
            //    else 
            //    {
            //        grdOUT1001.SetItemValue(rowIndex, "select", "N");
            //        SelectionBackColorChange(grdOUT1001, rowIndex, "N");
            //        this.grdDeleteAll(this.grdOCS1003);
            //    }
            //    //if (grdOUT1001.CurrentColNumber == 0)
            //    //{
            //    //    if (grdOUT1001.GetItemString(rowIndex, "select") == "N")
            //    //    {
            //    //        grdOUT1001.SetItemValue(rowIndex, "select", "Y");
            //    //        //외래오더에서 호출이고 입원do오다 선택시
            //    //        //원외처리
            //    //        if (this.mIOgubun == "O" && this.rbtIn.Checked)
            //    //        {
            //    //            if (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "C" ||
            //    //                this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "D")
            //    //            {
            //    //                SetWonyoiOrderYN(rowIndex);
            //    //            }
            //    //        }
            //    //    }
            //    //    else
            //    //    {
            //    //        grdOUT1001.SetItemValue(rowIndex, "select", "N");
            //    //    }
            //    //    SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);
            //    //}
            //}
        }

        

        

        
    }
}