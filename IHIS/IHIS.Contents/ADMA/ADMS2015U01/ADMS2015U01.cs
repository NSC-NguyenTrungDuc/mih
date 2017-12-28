/*********************************************************************************
 * 프로그램명: ADM107U
 *  내    용 : 사용자별 메뉴 등록
 *             사용자를 파인드박스에서 선택한 후,
 *             선택한 사용자에 맞는 메뉴를 등록시키도록 해주는 프로그램
 *  작 성 자 : 김민수
 *  날    짜 : 2005.3.8
 * *******************************************************************************/

#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.ADMA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.ADMA
{
	

	/// <summary>
	/// ADM107U에 대한 요약 설명입니다.
	/// </summary>
    [ToolboxItem(false)]
    public class ADMS2015U01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XTreeView SysTreeView;


        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

//        private string mainUSERID = "";
        private IHIS.Framework.XButton btnSave;
        private IHIS.Framework.XButton btnClose;
        private IHIS.Framework.XButton btnReset;
        private IHIS.Framework.XFindWorker fwkHospital;
        private IHIS.Framework.XDisplayBox dbxHospitalNm;
        private IHIS.Framework.XFindBox fbxHospital;
        //private IHIS.Framework.ValidationServiceDyn vsvUserID;
        private IHIS.Framework.XDisplayBox dbxSysNm;
        private IHIS.Framework.XFindBox fbxSysID;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.SingleLayout vsvSysID;
        private IHIS.Framework.XFindWorker fwkSysID;
        private IHIS.Framework.MultiLayout layRootList;
        private IHIS.Framework.MultiLayout layDownList;
        //private IHIS.Framework.MultiLayout dsvRootList;
        //private IHIS.Framework.MultiLayout dsvDownList;
        private IHIS.Framework.MultiLayout layRootSave;
        private IHIS.Framework.MultiLayout layDownSaves;
        //private IHIS.Framework.DataServiceMMISO dsvUpdate;
        private IHIS.Framework.XButton btnAllSelect;
        private IHIS.Framework.XButton btnAllDissolution;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private SingleLayout layCommon;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;//menu호출시 필요한USER_ID
        private int absCount = 0;

        public ADMS2015U01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            fwkHospital.ExecuteQuery = GetFwkHopitalCode;
            // fwkSysID
            fwkSysID.ParamList = new List<string>(new string[] { "f_hosp_code" });
            fwkSysID.ExecuteQuery = GetFwkSysId;
            // layRootList
            layRootList.ParamList = new List<string>(new string[] { "f_hosp_code", "f_sys_id" });
            layRootList.ExecuteQuery = GetLayRootList;
            // layDownList
            layDownList.ParamList = new List<string>(new string[] { "f_hosp_code", "f_sys_id", "f_uppr_menu" });
            layDownList.ExecuteQuery = GetLayDownList;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMS2015U01));
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.fbxHospital = new IHIS.Framework.XFindBox();
            this.fwkHospital = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.dbxHospitalNm = new IHIS.Framework.XDisplayBox();
            this.SysTreeView = new IHIS.Framework.XTreeView();
            this.layRootList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.fbxSysID = new IHIS.Framework.XFindBox();
            this.fwkSysID = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.layRootSave = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.layDownSaves = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.layDownList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.btnSave = new IHIS.Framework.XButton();
            this.btnReset = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.dbxSysNm = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.vsvSysID = new IHIS.Framework.SingleLayout();
            this.btnAllSelect = new IHIS.Framework.XButton();
            this.btnAllDissolution = new IHIS.Framework.XButton();
            this.layCommon = new IHIS.Framework.SingleLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layRootList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layRootSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDownSaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDownList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "선택.ICO");
            this.ImageList.Images.SetKeyName(1, "미선택.ICO");
            this.ImageList.Images.SetKeyName(2, "닫힌폴더.gif");
            this.ImageList.Images.SetKeyName(3, "보기.gif");
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // fbxHospital
            // 
            this.fbxHospital.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHospital.FindWorker = this.fwkHospital;
            resources.ApplyResources(this.fbxHospital, "fbxHospital");
            this.fbxHospital.Name = "fbxHospital";
            this.fbxHospital.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHospital_DataValidating);
            this.fbxHospital.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxID_FindSelected);
            // 
            // fwkHospital
            // 
            this.fwkHospital.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkHospital.ExecuteQuery = null;
            this.fwkHospital.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkHospital.ParamList")));
            this.fwkHospital.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkHospital_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "userID";
            this.findColumnInfo1.ColWidth = 105;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "userNM";
            this.findColumnInfo2.ColWidth = 218;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // dbxHospitalNm
            // 
            resources.ApplyResources(this.dbxHospitalNm, "dbxHospitalNm");
            this.dbxHospitalNm.Name = "dbxHospitalNm";
            // 
            // SysTreeView
            // 
            this.SysTreeView.CheckBoxes = true;
            resources.ApplyResources(this.SysTreeView, "SysTreeView");
            this.SysTreeView.ImageList = this.ImageList;
            this.SysTreeView.Name = "SysTreeView";
            this.SysTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.SysTreeView_AfterCheck);
            this.SysTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.SysTreeView_BeforeCheck);
            // 
            // layRootList
            // 
            this.layRootList.ExecuteQuery = null;
            this.layRootList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9});
            this.layRootList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layRootList.ParamList")));
            this.layRootList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layRootList_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "HOSP_CODE";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "SYS_ID";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "TR_ID";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "TR_SEQ";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "PGM_ID";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "UPPR_MENU";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "PGM_NM";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "PGM_TP";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "USER_YN";
            // 
            // fbxSysID
            // 
            this.fbxSysID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxSysID.FindWorker = this.fwkSysID;
            resources.ApplyResources(this.fbxSysID, "fbxSysID");
            this.fbxSysID.Name = "fbxSysID";
            this.fbxSysID.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSysID_DataValidating);
            this.fbxSysID.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxID_FindSelected);
            // 
            // fwkSysID
            // 
            this.fwkSysID.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkSysID.ExecuteQuery = null;
            this.fwkSysID.InputSQL = "SELECT A.SYS_ID\r\n       , A.SYS_NM\r\n  FROM ADM0200 A\r\n ORDER BY 1";
            this.fwkSysID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkSysID.ParamList")));
            this.fwkSysID.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkSysID_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "sysID";
            this.findColumnInfo3.ColWidth = 105;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "sysNM";
            this.findColumnInfo4.ColWidth = 218;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // layRootSave
            // 
            this.layRootSave.ExecuteQuery = null;
            this.layRootSave.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21});
            this.layRootSave.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layRootSave.ParamList")));
            this.layRootSave.UseDefaultTransaction = false;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "user_id";
            this.multiLayoutItem19.IsUpdItem = true;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "sys_id";
            this.multiLayoutItem20.IsUpdItem = true;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "use_yn";
            this.multiLayoutItem21.IsUpdItem = true;
            // 
            // layDownSaves
            // 
            this.layDownSaves.ExecuteQuery = null;
            this.layDownSaves.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27});
            this.layDownSaves.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDownSaves.ParamList")));
            this.layDownSaves.UseDefaultTransaction = false;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "user_id";
            this.multiLayoutItem22.IsUpdItem = true;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "sys_id";
            this.multiLayoutItem23.IsUpdItem = true;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "tr_id";
            this.multiLayoutItem24.IsUpdItem = true;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "tr_seq";
            this.multiLayoutItem25.IsUpdItem = true;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "uppr_menu";
            this.multiLayoutItem26.IsUpdItem = true;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "use_yn";
            this.multiLayoutItem27.IsUpdItem = true;
            // 
            // layDownList
            // 
            this.layDownList.ExecuteQuery = null;
            this.layDownList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18});
            this.layDownList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDownList.ParamList")));
            this.layDownList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDownList_QueryStarting);
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "HOSP_CODE";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "SYS_ID";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "TR_ID";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "TR_SEQ";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "PGM_ID";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "UPPR_MENU";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "PGM_NM";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "PGM_TP";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "USE_YN";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Name = "btnReset";
            this.btnReset.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dbxSysNm
            // 
            resources.ApplyResources(this.dbxSysNm, "dbxSysNm");
            this.dbxSysNm.Name = "dbxSysNm";
            // 
            // xLabel2
            // 
            this.xLabel2.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // vsvSysID
            // 
            this.vsvSysID.ExecuteQuery = null;
            this.vsvSysID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvSysID.ParamList")));
            // 
            // btnAllSelect
            // 
            resources.ApplyResources(this.btnAllSelect, "btnAllSelect");
            this.btnAllSelect.ImageIndex = 0;
            this.btnAllSelect.ImageList = this.ImageList;
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnAllDissolution
            // 
            resources.ApplyResources(this.btnAllDissolution, "btnAllDissolution");
            this.btnAllDissolution.ImageIndex = 1;
            this.btnAllDissolution.ImageList = this.ImageList;
            this.btnAllDissolution.Name = "btnAllDissolution";
            this.btnAllDissolution.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnAllDissolution.Click += new System.EventHandler(this.btnAllDissolution_Click);
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // ADMS2015U01
            // 
            this.Controls.Add(this.SysTreeView);
            this.Controls.Add(this.btnAllDissolution);
            this.Controls.Add(this.btnAllSelect);
            this.Controls.Add(this.dbxSysNm);
            this.Controls.Add(this.fbxSysID);
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dbxHospitalNm);
            this.Controls.Add(this.fbxHospital);
            this.Controls.Add(this.xLabel1);
            this.Name = "ADMS2015U01";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ADM107U_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layRootList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layRootSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDownSaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDownList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region 해쉬테이블들
        // --------------------------------------------------------------------------
        // 저장서비스를 호출할때 불필요한 정보를 보내지 않기 위해 만듬.
        // 예) 체크가 되어있는 상태에서 체크를 없엔 후 다시 체크하여
        //     처음상태와 동일한 상태에서 저장 버튼이 눌려졌을때,
        //     그러한 변경 정보는 서비스의 인밸류에 담기지 안도록 해주기 위한 테이블
        // --------------------------------------------------------------------------

        // - 시스템 해쉬테이블 - 
        // -- 키 -> sysid
        // -- 값 -> hashData 객체(isfirst = 이미 생성되었는가의 정보,
        //                        initval = 최초 로딩시 체크 상태,
        //                        modval  = 로딩 이후 변경시킨 체크 상태)
        private static Hashtable SysHash = new Hashtable();
        // - 메뉴 해쉬테이블 -
        // -- 키 -> trid
        // -- 값 -> hashData 객체(isfirst = 이미 생성되었는가의 정보,
        //                        initval = 최초 로딩시 체크 상태,
        //                        modval  = 로딩 이후 변경시킨 체크 상태)
        private static Hashtable MenuHash = new Hashtable();
        // - 프로그램 해쉬테이블 -
        // -- 키 -> trid
        // -- 값 -> hashData 객체(isfirst = 이미 생성되었는가의 정보,
        //                        initval = 최초 로딩시 체크 상태,
        //                        modval  = 로딩 이후 변경시킨 체크 상태)
        private static Hashtable PgmHash = new Hashtable();
        #endregion

        #region Screen 변수
        private string mMsg = "";
        private string mCap = "";
        #endregion

        #region ADM107U_Load
        private void ADM107U_Load(object sender, EventArgs e)
        {
            this.layDownSaves.SavePerformer = new XSavePeformer(this);
            this.layRootList.SavePerformer = new XSavePeformer(this);
        }
        #endregion

        #region RootNodeMaker()
        /// <summary>
        /// 파인드박스에서 셀렉트되었을 때, 시스템노드만 완성
        /// </summary>
        /// <returns></returns>
        private bool RootNodeMaker()
        {
            //노드를 클리어합니다.
            this.SysTreeView.Nodes.Clear();

            //			TreeNode tnSys = new TreeNode(this.dbxSysNm.DataValue);
            //			tnSys.ImageIndex = 0;
            //			tnSys.SelectedImageIndex = 1;
            //			// 테그에 루트임을 알리는 메타데이타를 담는다.
            //			// 테그 정보 [ 프로그램구분, ID, upperTr, tr_seq ]
            //			tnSys.Tag = new string[]{"S", this.fbxSysID.DataValue, "", ""};
            //			// 위에서 만든 루트 노드를 메뉴트리에 붙인다.
            //			SysTreeView.Nodes.Add(tnSys);
            if (this.layRootList.RowCount < 1)
                return false;

            //root 노드 생성
            for (int i = 0; i < layRootList.RowCount; i++)
            {
                string sHOSPCODE = this.layRootList.GetItemValue(i, "HOSP_CODE").ToString();
                string sSYSID = this.layRootList.GetItemValue(i, "SYS_ID").ToString();
                string sSYSNM = this.dbxSysNm.GetDataValue();
                string sUSERYN = this.layRootList.GetItemValue(i, "USER_YN").ToString();
                string sTRID = this.layRootList.GetItemValue(i, "TR_ID").ToString();
                string sTRSEQ = this.layRootList.GetItemValue(i, "TR_SEQ").ToString();
                string sPGMID = this.layRootList.GetItemValue(i, "PGM_ID").ToString();
                string sUPPRMENU = this.layRootList.GetItemValue(i, "UPPR_MENU").ToString();
                string sPGMNM = this.layRootList.GetItemValue(i, "PGM_NM").ToString();
                string sPGMTP = this.layRootList.GetItemValue(i, "PGM_TP").ToString();

                TreeNode rootNode = new TreeNode(sPGMNM);

                rootNode.Tag = new object[] { "R", sHOSPCODE, sSYSID, sSYSNM, sUSERYN, this.absCount, sTRID, sTRSEQ, sPGMID, sUPPRMENU, sPGMNM, sPGMTP };
                this.absCount++;
                //{구분(0), USER_ID(1), SYS_ID(2), SYS_NM(3), USER_YN(4), absolute Counter(5), TR_ID(6), TR_SEQ(7), PGM_ID(8), UPPR_MENU(9), PGM_NM(10), PGM_TP(11)}

                //사용여부를 가져오고 노드에 표시한다.
                if (sUSERYN == "1")
                {
                    rootNode.Checked = true;
                    rootNode.ForeColor = Color.Purple;
                }
                else
                {
                    rootNode.Checked = false;
                    rootNode.ForeColor = Color.Black;
                }

                // hashtable에 초기값을 셋팅한다( 값들을 add시켜놓음 )
                // 초기값과 변경된 값(y or n)은 일치

                if (sPGMTP == "M")
                {
                    //					XMessageBox.Show("tr = " + sTRID + ", pgmtp = " + sPGMTP);
                    MenuHash.Add(sTRID, new hashData(true, sUSERYN, sUSERYN, sTRSEQ, sUPPRMENU));
                }
                else if (sPGMTP == "P")
                {
                    //					XMessageBox.Show("tr = " + sTRID + ", pgmtp = " + sPGMTP);
                    PgmHash.Add(sTRID, new hashData(true, sUSERYN, sUSERYN, sTRSEQ, sUPPRMENU));
                }

                //전체 트리에 시스템 노드를 추가한다.
                this.SysTreeView.Nodes.Add(rootNode);
                this.updateTree(rootNode);
                //this.SysTreeView.SelectedNode.Expand();
            }
            return true;
        }
        #endregion

        #region DownNodeMaker()
        // ----------------------------------------------------------------
        // 시스템노드를 제외한 하위 노드들이 생성된다
        // 시스템 노드를 체크 혹은 클릭했을때는 메뉴와 프로그램노드를 생성
        // 메뉴 노드를 체크 혹은 클릭했을때는 프로그램 노드를 생성
        // ----------------------------------------------------------------
        private void DownNodeMaker(TreeNode ChooseNode, int LoopCount)
        {
            for (int j = 0; j < LoopCount; j++)
            {
                // 서비스에서 받아온 데이터들( 선택된 노드의 하위 노드에 대한 데이터들)
                string dHOSPCODE = this.layDownList.GetItemValue(j, "HOSP_CODE").ToString();//표기편의를 위한 변수선언
                string dSYSID = this.layDownList.GetItemValue(j, "SYS_ID").ToString();
                string dSYSNM = this.dbxSysNm.GetDataValue();
                string dTRID = this.layDownList.GetItemValue(j, "TR_ID").ToString();
                string dUPPRMENU = this.layDownList.GetItemValue(j, "UPPR_MENU").ToString();
                string dPGMID = this.layDownList.GetItemValue(j, "PGM_ID").ToString();
                string dPGMNM = this.layDownList.GetItemValue(j, "PGM_NM").ToString();
                string dPGMTP = this.layDownList.GetItemValue(j, "PGM_TP").ToString();
                string dUSEYN = this.layDownList.GetItemValue(j, "USE_YN").ToString();
                string dTRSEQ = this.layDownList.GetItemValue(j, "TR_SEQ").ToString();

                // 메뉴 혹은 프로그램 노드를 생성한다.
                TreeNode downNode = new TreeNode(dPGMNM);

                downNode.Tag = new object[] { dPGMTP, dHOSPCODE, dSYSID, dSYSNM, dUSEYN, this.absCount, dTRID, dTRSEQ, dPGMID, dUPPRMENU, dPGMNM, dPGMTP };
                this.absCount++;
                //{구분(0), USER_ID(1), SYS_ID(2), SYS_NM(3), USER_YN(4), absolute Counter(5), TR_ID(6), TR_SEQ(7), PGM_ID(8), UPPR_MENU(9), PGM_NM(10), PGM_TP(11)}

                // 체크시와 체크가 안된시에 색깔과 폰트의 처리이다.
                if (dUSEYN == "1")
                {
                    downNode.Checked = true;
                    downNode.ForeColor = Color.Purple;
                }
                else
                {
                    downNode.Checked = false;
                    downNode.ForeColor = Color.Black;
                }
                downNode.ImageIndex = 3;
                downNode.SelectedImageIndex = 3;
                // 노드가 메뉴라면,
                if (dPGMTP == "M")
                {
                    // 선택된 노드의 정보를 읽어온 후
                    hashData hd = (hashData)SysHash[dSYSID];
                    // 선택된 노드가 처음 선택되었고, 널 값이 아니라면
                    // 메뉴 해쉬 테이블에 선택된 노드(시스템)의 하위 노드(메뉴)를 추가시킨다

                    // 현재 시스템 노드가 없으므로 무조건 집어 넣기
                    //					if ( hd != null && hd.getIsFirst() == true )
                    /*MenuHash.Add(dTRID, new hashData(true, dUSEYN, dUSEYN, dTRSEQ, dUPPRMENU));*/

                    if (!MenuHash.ContainsKey(dTRID))
                        MenuHash.Add(dTRID, new hashData(true, dUSEYN, dUSEYN, dTRSEQ, dUPPRMENU));
                    else
                    {
                        MenuHash[dTRID] = new hashData(true, dUSEYN, dUSEYN, dTRSEQ, dUPPRMENU);
                    }
                }
                // 노드가 프로그램이라면,
                else if (dPGMTP == "P")
                {
                    //					XMessageBox.Show("in downloadMaker ... PgmTP = P");
                    // 선택된 노드의 정보를 읽어온 후
                    hashData hd = (hashData)MenuHash[dUPPRMENU];
                    // 선택된 노드가 처음 선택되었고, 널 값이 아니라면,
                    // 프로그램 해쉬 테이블에 선택된 노드(메뉴)의 하위 노드(프로그램)을 추가시킨다.
                    if (hd != null && hd.getIsFirst() == true)
                    {
                        //						XMessageBox.Show("add pgmhash...  tr_id = " + dTRID );
                        if (!PgmHash.ContainsKey(dTRID))
                            PgmHash.Add(dTRID, new hashData(true, dUSEYN, dUSEYN, dTRSEQ, dUPPRMENU));
                        else
                        {
                            PgmHash[dTRID] = new hashData(true, dUSEYN, dUSEYN, dTRSEQ, dUPPRMENU);
                        }
                    }
                }

                // 하위 노드를 추가
                ChooseNode.Nodes.Add(downNode);
            }
        }
        #endregion

        #region After_Select(,)
        /// <summary>
        /// 셀렉트시 정보(node.tag)를 비교하여 하위노드를 생성하게 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SysTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //if (this.SysTreeView.SelectedNode.Nodes.Count == 0)
            //{
            //    updateTree(this.SysTreeView.SelectedNode);
            //    this.SysTreeView.SelectedNode.Expand();
            //}
        }

        #endregion

        #region updateTree
        // ----------------------------------------------------------------
        // 트리에 정보가 변경되었을때 혹은 클릭되었을때,
        // 선택된 노드의 하위노드를 셋팅, 그리고 해쉬테이블도 셋팅
        // 이 메소드는 선택된 노드의 하위 노드만을 셋팅해 주면 되기 때문에
        // 프로그램 노드가 선택되었을 때는 아무런 일도 일어나지 안는다.
        // ----------------------------------------------------------------
        private void updateTree(TreeNode node)
        {
            if (node == null)
                return;

            //{구분(0), USER_ID(1), SYS_ID(2), SYS_NM(3), USER_YN(4), absolute Counter(5), TR_ID(6)
            //, TR_SEQ(7), PGM_ID(8), UPPR_MENU(9), PGM_NM(10), PGM_TP(11)}
            object[] nodeInfo = (object[])node.Tag;//현재 체크한 노드의 태그를 가져온다.

            //			XMessageBox.Show("구분["+nodeInfo[0]+"]"+"user_id["+nodeInfo[1]+"]"+"sys_id["+nodeInfo[2]+"]"
            //				            +"sys_nm["+nodeInfo[3]+"]"+"user_yn["+nodeInfo[4]+"]"+"ads_cnt["+nodeInfo[5]+"]"
            //				            +"tr_id["+nodeInfo[6]+"]"+"tr_seq["+nodeInfo[7]+"]"+"pgm_id["+nodeInfo[8]+"]"
            //							+"uppr_menu["+nodeInfo[9]+"]"+"pgm_nm["+nodeInfo[10]+"]"+"pgm_tp["+nodeInfo[11]+"]");
            // 노드가 시스템이라면,
            if (nodeInfo[0].ToString() == "S")
            {
                try
                {
                    // 선택된 노드를 클리어 한다.
                    node.Nodes.Clear();

                    // 데이터베이스의 메뉴/프로그램 테이블에서 정보를 뽑아오기위한
                    // 인밸류 값들을 셋팅
                    //this.layDownList.SetBindVarValue("f_user_id", this.mainUSERID);
                    this.layDownList.SetBindVarValue("f_sys_id", nodeInfo[2].ToString());
                    this.layDownList.SetBindVarValue("f_uppr_menu", "");

                    //// 서비스 호출
                    if (!this.layDownList.QueryLayout(false))
                    {
                        XMessageBox.Show("서비스호출 실패", "알림");
                        return;
                    }

                    // 서비스에서 받아온 정보를 가지고 하위 노드를 구성
                    DownNodeMaker(node, this.layDownList.RowCount);

                    // 해쉬 테이블에서 현재 선택된 시스템의 노드정보를 가지고 온 후, 
                    hashData hd = (hashData)SysHash[nodeInfo[2].ToString()];
                    // 노드가 널이 아니고, 이미 생성되있는 노드라면,
                    if (hd != null && hd.getIsFirst() == true)
                    {
                        // 노드 정보에서 isfirst정보를 false로 설정해줌
                        hd.setIsFirst(false);
                        SysHash.Remove(nodeInfo[2]);
                        SysHash.Add(nodeInfo[2], hd);
                    }
                }
                catch
                { }
            }
            // 선택된 노드가 메뉴 노드라면,			
            // 메뉴와 프로그램 노드의 정보구성
            //{구분(0), USER_ID(1), SYS_ID(2), SYS_NM(3), USER_YN(4), absolute Counter(5), TR_ID(6), TR_SEQ(7), PGM_ID(8), UPPR_MENU(9), PGM_NM(10), PGM_TP(11)}
            else if (nodeInfo[0].ToString() == "R")
            {
                if (nodeInfo[11].ToString() == "M")
                {
                    try
                    {
                        // 노드를 클리어
                        node.Nodes.Clear();

                        //// 데이터베이스의 메뉴/프로그램 테이블에서 정보를 뽑아오기위한
                        //// 인밸류 값들을 셋팅
                        //this.layDownList.SetBindVarValue("f_user_id", this.mainUSERID);
                        this.layDownList.SetBindVarValue("f_sys_id", nodeInfo[2].ToString());
                        this.layDownList.SetBindVarValue("f_uppr_menu", nodeInfo[6].ToString());

                        //서비스 호출
                        if (!this.layDownList.QueryLayout(false))
                        {
                            XMessageBox.Show("서비스호출 실패", "알림");
                            return;
                        }

                        // 서비스에서 받아온 정보를 가지고 하위 노드를 구성
                        DownNodeMaker(node, this.layDownList.RowCount);

                        // 해쉬 테이블에서 현재 선택된 시스템의 노드정보를 가지고 온 후,
                        hashData hd = (hashData)MenuHash[nodeInfo[6].ToString()];
                        // 노드가 널이 아니고, 이미 생성되있는 노드라면,
                        if (hd != null && hd.getIsFirst() == true)
                        {
                            // 노드 정보에서 isfirst정보를 false로 설정해줌
                            hd.setIsFirst(false);
                            MenuHash.Remove(nodeInfo[6]);
                            MenuHash.Add(nodeInfo[6], hd);
                        }
                    }
                    catch
                    { }
                }
            }
        }
        #endregion

        #region 노드체크 재귀호출함수
        // ------------------------------------------------------------------------------
        // 노드가 체크되었을 때 발생하는 일들을 처리
        // 해쉬테이블에 변경 정보를 담기
        // 만약에 상위 노드가 체크/언체크 되면, 모든하위 노드도 체크/언체크되어야하고,
        // 모든 하위 노드가 언체크 되면, 그 상위 노드도 언체크 되어야 한다.
        // 또한 하나의 하위 노드가 체크되었다 하더라도, 그 상위노드는 체크되어져야한다.
        // ------------------------------------------------------------------------------

        // checkFlag가 1이면 노드/ 해쉬테이블 데이터의 중복생성을 방지
        int checkFlag = 0;
        private void checkNode(TreeNode node)
        {
            // 현재 체크한 노드의 태그를 가져온다.
            object[] nodeInfo = (object[])node.Tag;
            // SYS
            // {구분(0), USER_ID(1), SYS_ID(2), SYS_NM(3), USER_YN(4), absolute Counter(5)}
            // MENU & PROGRAM
            // {구분(0), USER_ID(1), SYS_ID(2), TR_ID(3), UPPR_MENU(4), USER_YN(5), absolute Counter(6)}

            // 새로 정의한 테그
            //{구분(0), USER_ID(1), SYS_ID(2), SYS_NM(3), USER_YN(4), absolute Counter(5), TR_ID(6)
            //, TR_SEQ(7), PGM_ID(8), UPPR_MENU(9), PGM_NM(10), PGM_TP(11)}

            //			XMessageBox.Show("구분["+nodeInfo[0]+"]"+"user_id["+nodeInfo[1]+"]"+"sys_id["+nodeInfo[2]+"]"
            //				            +"sys_nm["+nodeInfo[3]+"]"+"user_yn["+nodeInfo[4]+"]"+"ads_cnt["+nodeInfo[5]+"]"
            //				            +"tr_id["+nodeInfo[6]+"]"+"tr_seq["+nodeInfo[7]+"]"+"pgm_id["+nodeInfo[8]+"]"
            //							+"uppr_menu["+nodeInfo[9]+"]"+"pgm_nm["+nodeInfo[10]+"]"+"pgm_tp["+nodeInfo[11]+"]");

            // 선택된 노드가 체크된 상태라면,
            if (node.Checked == true)
            {
                // 선택된 노드의 색깔을 변경
                node.ForeColor = Color.Purple;

                // 선택된 노드가 시스템노드라면,
                if (nodeInfo[0].ToString() == "S")
                {
                    // 선택된 노드의 정보를 가져옴(sysid로 가져옴)
                    hashData hd = (hashData)SysHash[nodeInfo[2].ToString()];
                    // 선택된 노드의 체크정보가 'N'로 설정되어있다면,
                    if (hd != null && hd.getModVal() == "0")
                    {
                        // 체크정보를 'Y'로 바꾸어줌
                        hd.setModVal("1");
                        SysHash.Remove(nodeInfo[2].ToString());
                        SysHash.Add(nodeInfo[2].ToString(), hd);
                    }
                }
                // 선택된 노드가 루트노드라면,
                else if (nodeInfo[0].ToString() == "R")
                {
                    //					XMessageBox.Show("구분1 = " + nodeInfo[0].ToString() + "구분2 = " + nodeInfo[11].ToString());
                    // 선택된 노드가 메뉴노드라면,
                    if (nodeInfo[11].ToString() == "M")
                    {
                        // 선택된 노드의 정보를 가져옴(trid로 가져옴)
                        hashData hd = (hashData)MenuHash[nodeInfo[6].ToString()];
                        // 선택된 노드의 체크정보가 'N'로 설정되어있다면,
                        string inituse = hd.getInitVal();
                        string moduse = hd.getModVal();
                        //						XMessageBox.Show("TR = " + nodeInfo[6].ToString() + "inituse = " + inituse + "moduse = " + moduse );
                        if (hd != null && hd.getModVal() == "0")
                        {
                            //							XMessageBox.Show("TR = " + nodeInfo[6].ToString() + "first = " + hd.getIsFirst().ToString() 
                            //								+ "inituse = " + hd.getInitVal() + "moduse + " + hd.getModVal() );
                            // 체크정보를 'Y'로 바꾸어줌
                            hd.setModVal("1");
                            MenuHash.Remove(nodeInfo[6].ToString());
                            MenuHash.Add(nodeInfo[6].ToString(), hd);
                        }
                        // 만약 선택된 노드의 상위노드(시스템)가 존재한다면,
                        if (node.Parent != null)
                        {
                            // 그리고, 선택된 노드의 상위노드가 체크되어있지 않다면,
                            if (node.Parent.Checked == false)
                            {
                                // 이 노드의 하위노드는 이미 생성되어있기때문에,
                                // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                                checkFlag = 1;
                                // 상위노드의 체크상태를 바꾸어줌(true로)
                                // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                                // 바로 위에서 checkFlag의 값을 1로 셋팅
                                node.Parent.Checked = true;
                                node.Parent.ForeColor = Color.Purple;
                                // 상위노드의 노드 정보를 가져옴
                                object[] P1nodeInfo = (object[])node.Parent.Tag;
                                hashData P1hd = (hashData)SysHash[P1nodeInfo[2].ToString()];
                                // 상위노드가 널이 아니고, 해쉬 테이블 내의 체크정보가 'N'이라면,
                                if (P1hd != null && P1hd.getModVal() == "0")
                                {
                                    // 상위노드의 체크정보를 'Y'로 바꾸어줌
                                    P1hd.setModVal("1");
                                    SysHash.Remove(P1nodeInfo[2].ToString());
                                    SysHash.Add(P1nodeInfo[2].ToString(), P1hd);
                                }
                                // 체크이벤트가 정상 동작되도록 셋팅
                                checkFlag = 0;
                            }
                        }
                    }
                    // 선택된 노드가 프로그램 노드라면,
                    else if (nodeInfo[11].ToString() == "P")
                    {
                        // 선택된 노드의 정보를 가져옴 ( trid를 이용 )
                        hashData hd = (hashData)PgmHash[nodeInfo[6].ToString()];
                        // 선택된 노드가 널이 아니고, 체크 정보가 'N'라면,
                        if (hd != null && hd.getModVal() == "0")
                        {
                            // 체크정보를 'Y'로 바꾸어줌
                            hd.setModVal("1");
                            PgmHash.Remove(nodeInfo[6].ToString());
                            PgmHash.Add(nodeInfo[6].ToString(), hd);
                        }
                        // 선택된 노드의 상위노드(메뉴)가 존재한다면,
                        if (node.Parent != null)
                        {
                            // 그리고 상위노드가 체크되어있지않다면,
                            if (node.Parent.Checked == false)
                            {
                                // 이 노드의 하위노드는 이미 생성되어있기때문에,
                                // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                                checkFlag = 1;
                                // 상위노드의 체크상태를 바꾸어줌(true로)
                                // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                                // 바로 위에서 checkFlag의 값을 1로 셋팅
                                node.Parent.Checked = true;
                                node.Parent.ForeColor = Color.Purple;
                                // 상위노드의 정보를 가져옴
                                object[] P1nodeInfo = (object[])node.Parent.Tag;
                                hashData P1hd = (hashData)MenuHash[P1nodeInfo[6].ToString()];
                                // 상위노드의 정보가 널이 아니고, 해쉬테이블 내의 체크정보가 'N'라면,
                                if (P1hd != null && P1hd.getModVal() == "0")
                                {
                                    // 체크정보를 'Y'로 바꾸어줌
                                    P1hd.setModVal("1");
                                    MenuHash.Remove(P1nodeInfo[6].ToString());
                                    MenuHash.Add(P1nodeInfo[6].ToString(), P1hd);
                                }
                                // 체크 이벤트가 정상 동작되도록 셋팅
                                checkFlag = 0;

                                // 만약 선택된 노드의 상위노드에 또 상위노드(시스템)가 존재한다면,
                                if (node.Parent.Parent != null)
                                {
                                    // 그리고 상위/상위노드가 체크되어있지 않은 상태라면,
                                    if (node.Parent.Parent.Checked == false)
                                    {
                                        // 이 노드의 하위노드는 이미 생성되어있기때문에,
                                        // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                                        checkFlag = 1;
                                        // 상위노드의 체크상태를 바꾸어줌(true로)
                                        // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                                        // 바로 위에서 checkFlag의 값을 1로 셋팅
                                        node.Parent.Parent.Checked = true;
                                        node.Parent.Parent.ForeColor = Color.Purple;
                                        // 상위/상위노드의 정보를 가져옴
                                        object[] P2nodeInfo = (object[])node.Parent.Parent.Tag;
                                        hashData P2hd = (hashData)SysHash[P2nodeInfo[2].ToString()];
                                        // 상위/상위노드의 정보가 널이 아니고, 해쉬테이블 내의 체크정보가 'N'라면,
                                        if (P2hd != null && P2hd.getModVal() == "0")
                                        {
                                            // 체크정보를 'Y'로 바꾸어줌
                                            P2hd.setModVal("1");
                                            SysHash.Remove(P2nodeInfo[2].ToString());
                                            SysHash.Add(P2nodeInfo[2].ToString(), P2hd);
                                        }
                                        // 체크 이벤트가 정상동작되도록 셋팅
                                        checkFlag = 0;
                                    }
                                }
                            }
                        }
                    }

                }
                // 선택된 노드가 프로그램 노드라면,
                else if (nodeInfo[0].ToString() == "P")
                {
                    // 선택된 노드의 정보를 가져옴 ( trid를 이용 )
                    hashData hd = (hashData)PgmHash[nodeInfo[6].ToString()];
                    // 선택된 노드가 널이 아니고, 체크 정보가 'N'라면,
                    if (hd != null && hd.getModVal() == "0")
                    {
                        // 체크정보를 'Y'로 바꾸어줌
                        hd.setModVal("1");
                        PgmHash.Remove(nodeInfo[6].ToString());
                        PgmHash.Add(nodeInfo[6].ToString(), hd);
                    }
                    // 선택된 노드의 상위노드(메뉴)가 존재한다면,
                    if (node.Parent != null)
                    {
                        // 그리고 상위노드가 체크되어있지않다면,
                        if (node.Parent.Checked == false)
                        {
                            // 이 노드의 하위노드는 이미 생성되어있기때문에,
                            // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                            checkFlag = 1;
                            // 상위노드의 체크상태를 바꾸어줌(true로)
                            // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                            // 바로 위에서 checkFlag의 값을 1로 셋팅
                            node.Parent.Checked = true;
                            node.Parent.ForeColor = Color.Purple;
                            // 상위노드의 정보를 가져옴
                            object[] P1nodeInfo = (object[])node.Parent.Tag;
                            hashData P1hd = (hashData)MenuHash[P1nodeInfo[6].ToString()];
                            // 상위노드의 정보가 널이 아니고, 해쉬테이블 내의 체크정보가 'N'라면,
                            if (P1hd != null && P1hd.getModVal() == "0")
                            {
                                // 체크정보를 'Y'로 바꾸어줌
                                P1hd.setModVal("1");
                                MenuHash.Remove(P1nodeInfo[6].ToString());
                                MenuHash.Add(P1nodeInfo[6].ToString(), P1hd);
                            }
                            // 체크 이벤트가 정상 동작되도록 셋팅
                            checkFlag = 0;

                            // 만약 선택된 노드의 상위노드에 또 상위노드(시스템)가 존재한다면,
                            if (node.Parent.Parent != null)
                            {
                                // 그리고 상위/상위노드가 체크되어있지 않은 상태라면,
                                if (node.Parent.Parent.Checked == false)
                                {
                                    // 이 노드의 하위노드는 이미 생성되어있기때문에,
                                    // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                                    checkFlag = 1;
                                    // 상위노드의 체크상태를 바꾸어줌(true로)
                                    // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                                    // 바로 위에서 checkFlag의 값을 1로 셋팅
                                    node.Parent.Parent.Checked = true;
                                    node.Parent.Parent.ForeColor = Color.Purple;
                                    // 상위/상위노드의 정보를 가져옴
                                    object[] P2nodeInfo = (object[])node.Parent.Parent.Tag;
                                    hashData P2hd = (hashData)SysHash[P2nodeInfo[2].ToString()];
                                    // 상위/상위노드의 정보가 널이 아니고, 해쉬테이블 내의 체크정보가 'N'라면,
                                    if (P2hd != null && P2hd.getModVal() == "0")
                                    {
                                        // 체크정보를 'Y'로 바꾸어줌
                                        P2hd.setModVal("1");
                                        SysHash.Remove(P2nodeInfo[2].ToString());
                                        SysHash.Add(P2nodeInfo[2].ToString(), P2hd);
                                    }
                                    // 체크 이벤트가 정상동작되도록 셋팅
                                    checkFlag = 0;
                                }
                            }
                        }
                    }
                }

                // 현재노드의 하위 노드가 존재한다면,
                if (node.Nodes.Count > 0)
                {
                    // 하위 노드가 모두 체크되도록 각각의 하위노드에서 chedkNode 메소드를 호출한다.
                    // 재귀함수
                    foreach (TreeNode ChildNode in node.Nodes)
                    {
                        //XMessageBox.Show("체크된 하위 노드 = " + ChildNode.Text );
                        ChildNode.ForeColor = Color.Purple;
                        ChildNode.Checked = true;
                        checkNode(ChildNode);
                    }
                }
            }
            // 만약 현재 노드가 체크되지않았다면,
            else
            {
                // 노드의 색깔을 블랙으로 바꿈
                node.ForeColor = Color.Black;

                // 현재 노드가 시스템이라면,
                if (nodeInfo[0].ToString() == "S")
                {
                    // 노드의 정보를 가져옴
                    hashData hd = (hashData)SysHash[nodeInfo[2].ToString()];
                    // 노드의 해쉬테이블 체크정보가 'Y'라면
                    if (hd != null && hd.getModVal() == "1")
                    {
                        // 체크정보를 'N'로 바꿈
                        hd.setModVal("0");
                        SysHash.Remove(nodeInfo[2].ToString());
                        SysHash.Add(nodeInfo[2].ToString(), hd);
                    }
                }
                if (nodeInfo[0].ToString() == "R")
                {
                    // 현재 노드가 메뉴라면,
                    if (nodeInfo[11].ToString() == "M")
                    {
                        // 노드의 정보를 가져옴
                        hashData hd = (hashData)MenuHash[nodeInfo[6].ToString()];
                        string inituse = hd.getInitVal();
                        string moduse = hd.getModVal();
                        //						XMessageBox.Show("TR = " + nodeInfo[6].ToString() + "inituse = " + inituse + "moduse = " + moduse);
                        // 노드의 해쉬테이블 내의 체크정보가 'Y'라면,
                        if (hd != null && hd.getModVal() == "1")
                        {
                            // 체크정보를 'N'로 바꿈
                            hd.setModVal("0");
                            MenuHash.Remove(nodeInfo[6].ToString());
                            MenuHash.Add(nodeInfo[6].ToString(), hd);
                        }
                        // 만약 선택된 노드의 상위노드(시스템)가 존재한다면,
                        if (node.Parent != null)
                        {
                            // 그리고, 선택된 노드의 상위노드가 체크되어있다면,
                            if (node.Parent.Checked == true)
                            {
                                // 현재 노드와 같은 레벨의 노드들의 체크된 개수를 담을 변수
                                int cntCheck = 0;
                                foreach (TreeNode child in node.Parent.Nodes)
                                {
                                    if (child.Checked == true)
                                        cntCheck++;
                                }
                                // 현재 노드와 같은 레벨에 체크된 노드가 없다면,
                                // 상위 노드도 언체크시킴
                                if (cntCheck == 0)
                                {
                                    // 이 노드의 하위노드는 이미 생성되어있기때문에,
                                    // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                                    checkFlag = 1;
                                    // 상위노드의 체크상태를 바꾸어줌(true로)
                                    // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                                    // 바로 위에서 checkFlag의 값을 1로 셋팅
                                    node.Parent.Checked = false;
                                    node.Parent.ForeColor = Color.Black;
                                    // 상위노드의 노드 정보를 가져옴
                                    object[] P1nodeInfo = (object[])node.Parent.Tag;
                                    hashData P1hd = (hashData)SysHash[P1nodeInfo[2].ToString()];
                                    // 상위노드가 널이 아니고, 해쉬 테이블 내의 체크정보가 'Y'이라면,
                                    if (P1hd != null && P1hd.getModVal() == "1")
                                    {
                                        // 상위노드의 체크정보를 'N'로 바꾸어줌
                                        P1hd.setModVal("0");
                                        SysHash.Remove(P1nodeInfo[2].ToString());
                                        SysHash.Add(P1nodeInfo[2].ToString(), P1hd);
                                    }
                                    // 체크이벤트가 정상 동작되도록 셋팅
                                    checkFlag = 0;
                                }
                            }
                        }
                    }
                    // 현재 노드가 프로그램이라면,
                    else if (nodeInfo[11].ToString() == "P")
                    {
                        // 노드 정보를 가져옴
                        hashData hd = (hashData)PgmHash[nodeInfo[6].ToString()];
                        // 노드의 해쉬테이블 내의 체크정보가 'N'라면,
                        if (hd != null && hd.getModVal() == "1")
                        {
                            // 체크정보를 'N'로 바꿈
                            hd.setModVal("0");
                            PgmHash.Remove(nodeInfo[6].ToString());
                            PgmHash.Add(nodeInfo[6].ToString(), hd);
                        }
                        // 선택된 노드의 상위노드(메뉴)가 존재한다면,
                        if (node.Parent != null)
                        {
                            // 그리고 상위노드가 체크되어있다면,
                            if (node.Parent.Checked == true)
                            {
                                // 현재 선택된 노드와 같은 레벨의 노드들 중 언체크된 개수를 담을 변수
                                int cntCheckP = 0;
                                foreach (TreeNode child in node.Parent.Nodes)
                                {
                                    if (child.Checked == true)
                                        cntCheckP++;
                                }
                                // 만약에 선택된 노드와 같은 레벨의 노드가 모두 체크되지 않았다면,
                                // 상위노드도 언체크 시킴
                                if (cntCheckP == 0)
                                {
                                    // 이 노드의 하위노드는 이미 생성되어있기때문에,
                                    // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                                    checkFlag = 1;
                                    // 상위노드의 체크상태를 바꾸어줌(true로)
                                    // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                                    // 바로 위에서 checkFlag의 값을 1로 셋팅
                                    node.Parent.Checked = false;
                                    node.Parent.ForeColor = Color.Black;
                                    // 상위노드의 정보를 가져옴
                                    object[] P1nodeInfo = (object[])node.Parent.Tag;
                                    hashData P1hd = (hashData)MenuHash[P1nodeInfo[6].ToString()];
                                    // 상위노드의 정보가 널이 아니고, 해쉬테이블 내의 체크정보가 'Y'라면,
                                    if (P1hd != null && P1hd.getModVal() == "1")
                                    {
                                        // 체크정보를 'N'로 바꾸어줌
                                        P1hd.setModVal("0");
                                        MenuHash.Remove(P1nodeInfo[6].ToString());
                                        MenuHash.Add(P1nodeInfo[6].ToString(), P1hd);
                                    }
                                    // 체크 이벤트가 정상 동작되도록 셋팅
                                    checkFlag = 0;

                                    // 만약 선택된 노드의 상위노드에 또 상위노드(시스템)가 존재한다면,
                                    if (node.Parent.Parent != null)
                                    {
                                        // 그리고 상위/상위노드가 체크되어있는 상태라면,
                                        if (node.Parent.Parent.Checked == true)
                                        {
                                            // 상위 노드와 같은 레벨의 체크된 개수를 담을 변수
                                            int cntCheckM = 0;
                                            foreach (TreeNode child in node.Parent.Parent.Nodes)
                                            {
                                                if (child.Checked == true)
                                                    cntCheckM++;
                                            }
                                            // 상위 노드와 같은 레벨의 모든 노드가 언체크되었다면,
                                            // 상위/상위 노드도 언체크시킴
                                            if (cntCheckM == 0)
                                            {
                                                // 이 노드의 하위노드는 이미 생성되어있기때문에,
                                                // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                                                checkFlag = 1;
                                                // 상위노드의 체크상태를 바꾸어줌(true로)
                                                // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                                                // 바로 위에서 checkFlag의 값을 1로 셋팅
                                                node.Parent.Parent.Checked = false;
                                                node.Parent.Parent.ForeColor = Color.Black;
                                                // 상위/상위노드의 정보를 가져옴
                                                object[] P2nodeInfo = (object[])node.Parent.Parent.Tag;
                                                hashData P2hd = (hashData)SysHash[P2nodeInfo[2].ToString()];
                                                // 상위/상위노드의 정보가 널이 아니고, 해쉬테이블 내의 체크정보가 'Y'라면,
                                                if (P2hd != null && P2hd.getModVal() == "1")
                                                {
                                                    // 체크정보를 'N'로 바꾸어줌
                                                    P2hd.setModVal("0");
                                                    SysHash.Remove(P2nodeInfo[2].ToString());
                                                    SysHash.Add(P2nodeInfo[2].ToString(), P2hd);
                                                }
                                                // 체크 이벤트가 정상동작되도록 셋팅
                                                checkFlag = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // 현재 노드가 프로그램이라면,
                else if (nodeInfo[0].ToString() == "P")
                {
                    // 노드 정보를 가져옴
                    hashData hd = (hashData)PgmHash[nodeInfo[6].ToString()];
                    // 노드의 해쉬테이블 내의 체크정보가 'N'라면,
                    if (hd != null && hd.getModVal() == "1")
                    {
                        // 체크정보를 'N'로 바꿈
                        hd.setModVal("0");
                        PgmHash.Remove(nodeInfo[6].ToString());
                        PgmHash.Add(nodeInfo[6].ToString(), hd);
                    }
                    // 선택된 노드의 상위노드(메뉴)가 존재한다면,
                    if (node.Parent != null)
                    {
                        // 그리고 상위노드가 체크되어있다면,
                        if (node.Parent.Checked == true)
                        {
                            // 현재 선택된 노드와 같은 레벨의 노드들 중 언체크된 개수를 담을 변수
                            int cntCheckP = 0;
                            foreach (TreeNode child in node.Parent.Nodes)
                            {
                                if (child.Checked == true)
                                    cntCheckP++;
                            }
                            // 만약에 선택된 노드와 같은 레벨의 노드가 모두 체크되지 않았다면,
                            // 상위노드도 언체크 시킴
                            if (cntCheckP == 0)
                            {
                                // 이 노드의 하위노드는 이미 생성되어있기때문에,
                                // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                                checkFlag = 1;
                                // 상위노드의 체크상태를 바꾸어줌(true로)
                                // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                                // 바로 위에서 checkFlag의 값을 1로 셋팅
                                node.Parent.Checked = false;
                                node.Parent.ForeColor = Color.Black;
                                // 상위노드의 정보를 가져옴
                                object[] P1nodeInfo = (object[])node.Parent.Tag;
                                hashData P1hd = (hashData)MenuHash[P1nodeInfo[6].ToString()];
                                // 상위노드의 정보가 널이 아니고, 해쉬테이블 내의 체크정보가 'Y'라면,
                                if (P1hd != null && P1hd.getModVal() == "1")
                                {
                                    // 체크정보를 'N'로 바꾸어줌
                                    P1hd.setModVal("0");
                                    MenuHash.Remove(P1nodeInfo[6].ToString());
                                    MenuHash.Add(P1nodeInfo[6].ToString(), P1hd);
                                }
                                // 체크 이벤트가 정상 동작되도록 셋팅
                                checkFlag = 0;

                                // 만약 선택된 노드의 상위노드에 또 상위노드(시스템)가 존재한다면,
                                if (node.Parent.Parent != null)
                                {
                                    // 그리고 상위/상위노드가 체크되어있는 상태라면,
                                    if (node.Parent.Parent.Checked == true)
                                    {
                                        // 상위 노드와 같은 레벨의 체크된 개수를 담을 변수
                                        int cntCheckM = 0;
                                        foreach (TreeNode child in node.Parent.Parent.Nodes)
                                        {
                                            if (child.Checked == true)
                                                cntCheckM++;
                                        }
                                        // 상위 노드와 같은 레벨의 모든 노드가 언체크되었다면,
                                        // 상위/상위 노드도 언체크시킴
                                        if (cntCheckM == 0)
                                        {
                                            // 이 노드의 하위노드는 이미 생성되어있기때문에,
                                            // 생성의 중복을 막기위해 checkFlag를 1로 셋팅
                                            checkFlag = 1;
                                            // 상위노드의 체크상태를 바꾸어줌(true로)
                                            // 이 때 체크이벤트가 발생하고 그때 체크플래그 값에 따라 하위 노드를 생성하기 때문에
                                            // 바로 위에서 checkFlag의 값을 1로 셋팅
                                            node.Parent.Parent.Checked = false;
                                            node.Parent.Parent.ForeColor = Color.Black;
                                            // 상위/상위노드의 정보를 가져옴
                                            object[] P2nodeInfo = (object[])node.Parent.Parent.Tag;
                                            hashData P2hd = (hashData)SysHash[P2nodeInfo[2].ToString()];
                                            // 상위/상위노드의 정보가 널이 아니고, 해쉬테이블 내의 체크정보가 'Y'라면,
                                            if (P2hd != null && P2hd.getModVal() == "1")
                                            {
                                                // 체크정보를 'N'로 바꾸어줌
                                                P2hd.setModVal("0");
                                                SysHash.Remove(P2nodeInfo[2].ToString());
                                                SysHash.Add(P2nodeInfo[2].ToString(), P2hd);
                                            }
                                            // 체크 이벤트가 정상동작되도록 셋팅
                                            checkFlag = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // 현재노드의 하위 노드가 존재한다면,
                if (node.Nodes.Count > 0)
                {
                    // 모든 하위 노드의 체크 정보를 바꾸어줌
                    // 재귀 함수
                    foreach (TreeNode ChildNode in node.Nodes)
                    {
                        //XMessageBox.Show("체크되지 않은 하위 노드 = " + ChildNode.Text );
                        ChildNode.ForeColor = Color.Black;
                        ChildNode.Checked = false;
                        checkNode(ChildNode);
                    }
                }
            }

        }
        #endregion

        #region 트리가 체크된 후에 일어나는 일들
        private void SysTreeView_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            // 코드에서 체크 속성을 변환할때는 이 이벤트 처리를 억제
            if (checkFlag == 0)
                this.checkNode(e.Node);
        }
        #endregion

        #region SaveService End
        /// <summary>
        /// 저장서비스 종료시에 처리입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void dsvUpdate_ServiceEnd(object sender, IHIS.Framework.ServiceEndArgs e)
        private void dsvUpdate_ServiceEnd()
        {

            // 시스템 해쉬테이블의 키 값을 저장할 array list
            ArrayList sysKeys = new ArrayList();
            // 시스템 해쉬테이블에서 초기체크값과 변경체크값이 다른 경우에만
            // 해당키 값을 뽑아와 array list에 담는다.
            foreach (string sysID in SysHash.Keys)
            {
                hashData hd = (hashData)SysHash[sysID];
                if (hd.getInitVal() != hd.getModVal())
                {
                    sysKeys.Add(sysID);
                }
            }
            // 시스템 해쉬테이블의 초기체크값을 변경된 체크값으로 셋팅
            for (int i = 0; i < sysKeys.Count; i++)
            {
                hashData hd = (hashData)SysHash[sysKeys[i]];
                hd.setInitVal(hd.getModVal());
                SysHash.Remove(sysKeys[i]);
                SysHash.Add(sysKeys[i], hd);
            }
            // 메뉴 해쉬테이블의 키 값을 저장할 array list
            ArrayList menuKeys = new ArrayList();
            // 메뉴 해쉬테이블에서 초기체크값과 변경체크값이 다른 경우에만
            // 해당 키 값을 뽑아와 array list에 담는다.
            foreach (string trID in MenuHash.Keys)
            {
                hashData hd = (hashData)MenuHash[trID];
                if (hd.getInitVal() != hd.getModVal())
                {
                    menuKeys.Add(trID);
                }
            }
            // 메뉴 해쉬테이블의 초기체크값을 변경된 체크값으로 셋팅
            for (int i = 0; i < menuKeys.Count; i++)
            {
                hashData hd = (hashData)MenuHash[menuKeys[i]];
                hd.setInitVal(hd.getModVal());
                MenuHash.Remove(menuKeys[i]);
                MenuHash.Add(menuKeys[i], hd);
            }
            // 프로그램 해쉬테이블의 키 값을 저장할 array list
            ArrayList pgmKeys = new ArrayList();
            // 프로그램 해쉬테이블에서 초기체크값과 변경체크값이 다른 경우에만
            // 해당 키 값을 뽑아와 array list에 담는다.
            foreach (string trID in PgmHash.Keys)
            {
                hashData hd = (hashData)PgmHash[trID];
                if (hd.getInitVal() != hd.getModVal())
                {
                    pgmKeys.Add(trID);
                }
            }
            // 프로그램 해쉬테이블의 초기체크값을 변경된 체크값으로 셋팅
            for (int i = 0; i < pgmKeys.Count; i++)
            {
                hashData hd = (hashData)PgmHash[pgmKeys[i]];
                hd.setInitVal(hd.getModVal());
                PgmHash.Remove(pgmKeys[i]);
                PgmHash.Add(pgmKeys[i], hd);
            }
        }
        #endregion

        #region 트리가 체크되기 전에 일어나는 일들
        // 해쉬테이블이 생성되지 않았다면, 생성후 데이터들이 체크되었는지 안되었는지를 셋팅
        private void SysTreeView_BeforeCheck(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            //			XMessageBox.Show( "checkFlag = " + this.checkFlag.ToString() );
            if (checkFlag == 0)
            {
                //				XMessageBox.Show( "checkFlag = " + this.checkFlag.ToString() + "   node = " + e.Node.Text );
                updateTree(e.Node);
                if (e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode ChildNode in e.Node.Nodes)
                    {
                        updateTree(ChildNode);
                    }
                }
            }
        }
        #endregion

        #region 버튼이 클릭되었을 때 일어나는 일들

        // 닫기 버튼 클릭
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        // 초기화 버튼 클릭
        private void btnReset_Click(object sender, System.EventArgs e)
        {
            // 트리뷰를 클리어
            this.SysTreeView.Nodes.Clear();
            // 사용자 명 클리어
            this.dbxHospitalNm.Text = "";
            // 사용자 id 클리어
            this.fbxHospital.Text = "";
            // 시스템 ID 클리어
            this.fbxSysID.Text = "";
            // 시스템 명 클리어
            this.dbxSysNm.Text = "";
            // 사용자 명을 찾는 findbox에 포커스를 가져감
            this.fbxHospital.Focus();
        }

        // 저장 버튼 클릭
        // 각각의 해쉬테이블 내에서 체크가 변경된 경우만 추려내어
        // 서비스의 인밸류에 담는다.
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.layDownSaves.Reset();

            // Create data for register master menu
            ADMS2015U01SettingMenuArgs args = new ADMS2015U01SettingMenuArgs();
            args.HospCode = fbxHospital.GetDataValue();
            args.SystemId = fbxSysID.GetDataValue();
            List<ADMS2015U01SettingMenuInfo> listMenuInfo = new List<ADMS2015U01SettingMenuInfo>();
            int countMnP = 0;
            
            foreach (string trID in MenuHash.Keys)
            {
                ADMS2015U01SettingMenuInfo menuHashInfo = new ADMS2015U01SettingMenuInfo();
                hashData hd = (hashData)MenuHash[trID];
                
                if (hd.getInitVal() != hd.getModVal())
                {
                    menuHashInfo.TrId = trID;
                    menuHashInfo.SelectFlg = hd.getModVal();
                    listMenuInfo.Add(menuHashInfo);
                    /*this.layDownSaves.InsertRow(countMnP);
                    this.layDownSaves.SetItemValue(countMnP, "user_id", fbxHospital.GetDataValue());
                    this.layDownSaves.SetItemValue(countMnP, "sys_id", this.fbxSysID.GetDataValue());
                    this.layDownSaves.SetItemValue(countMnP, "tr_id", trID);
                    this.layDownSaves.SetItemValue(countMnP, "tr_seq", hd.getTrSeq());
                    this.layDownSaves.SetItemValue(countMnP, "uppr_menu", hd.getUpprMenu());
                    this.layDownSaves.SetItemValue(countMnP, "use_yn", hd.getModVal());
                    countMnP++;*/
                }
                
            }
            
            foreach (string trID in PgmHash.Keys)
            {
                ADMS2015U01SettingMenuInfo pgmHashInfo = new ADMS2015U01SettingMenuInfo();
                hashData hd = (hashData)PgmHash[trID];
                
                if (hd.getInitVal() != hd.getModVal())
                {
                    pgmHashInfo.TrId = trID;
                    pgmHashInfo.SelectFlg = hd.getModVal();
                    listMenuInfo.Add(pgmHashInfo);
                    /*this.layDownSaves.InsertRow(countMnP);
                    this.layDownSaves.SetItemValue(countMnP, "user_id", fbxHospital.GetDataValue());
                    this.layDownSaves.SetItemValue(countMnP, "sys_id", this.fbxSysID.GetDataValue());
                    this.layDownSaves.SetItemValue(countMnP, "tr_id", trID);
                    this.layDownSaves.SetItemValue(countMnP, "tr_seq", hd.getTrSeq());
                    this.layDownSaves.SetItemValue(countMnP, "uppr_menu", hd.getUpprMenu());
                    this.layDownSaves.SetItemValue(countMnP, "use_yn", hd.getModVal());
                    countMnP++;*/
                }
                
            }

            try
            {
                // Save data
                args.MenuInfo = listMenuInfo;
                args.UserId = UserInfo.UserID;
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, ADMS2015U01SettingMenuArgs>(args);
                if (result == null || result.ExecutionStatus != ExecutionStatus.Success || result.Result == false)
                {
                    throw new Exception();
                }
                else
                {
                    this.dsvUpdate_ServiceEnd();
                    this.mMsg = Resources.MSG002;
                    this.mCap = Resources.CAP002;
                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                this.mMsg = Resources.MSG003;
                this.mCap = Resources.CAP003;
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        private bool layDownSaves_ServiceCall()
        {
            /*string cmdText = "";

            if (this.layDownSaves.SaveLayout() == false)
            {
                return false;
            }
            else
            {
                BindVarCollection bindVals = new BindVarCollection();
                bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVals.Add("f_user_id", this.mainUSERID);
                bindVals.Add("f_sys_id", this.fbxSysID.GetDataValue());

                cmdText = @"BEGIN
                              FOR C1 IN (SELECT A.USER_ID 
                                           FROM ADM3200 A 
                                          WHERE A.HOSP_CODE  = :f_hosp_code 
                                            AND A.USER_GROUP = :f_user_id ) LOOP
                                UPDATE ADM4310 
                                   SET MENU_GEN_YN = 'N'
                                 WHERE HOSP_CODE = :f_hosp_code
                                   AND USER_ID   = C1.USER_ID
                                   AND SYS_ID    = :f_sys_id;
                                 IF SQL%NOTFOUND THEN
                                    INSERT INTO ADM4310 (HOSP_CODE, USER_ID, SYS_ID, MENU_GEN_YN)
                                    VALUES(:f_hosp_code, C1.USER_ID, :f_sys_id, 'N');	
                                 END IF;	
                              END LOOP;	
                            END;";
                if (Service.ExecuteNonQuery(cmdText, bindVals) == false)
                {
                    return false;
                }
                cmdText = @" BEGIN
                                UPDATE ADM4310 
                                   SET MENU_GEN_YN = 'N'
                                 WHERE HOSP_CODE = :f_hosp_code
                                   AND USER_ID   = :f_user_id
                                   AND SYS_ID    = :f_sys_id;
                                 IF SQL%NOTFOUND THEN
                                    INSERT INTO ADM4310 (HOSP_CODE, USER_ID, SYS_ID, MENU_GEN_YN)
                                    VALUES(:f_hosp_code, :f_user_id, :f_sys_id, 'N');    
                                 END IF;    
                              END;";
                if (Service.ExecuteNonQuery(cmdText, bindVals) == false)
                {
                    return false;
                }
                this.dsvUpdate_ServiceEnd();
            }*/
            return true;
        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private ADMS2015U01 parent = null;

            public XSavePeformer(ADMS2015U01 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                string QuerySQL = "";

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);  //병원코드
                item.BindVarList.Add("f_cr_memb", UserInfo.UserID);         //갱신자ID

                switch (callerID)
                {
                    case '1':
                        switch (item.BindVarList["f_use_yn"].VarValue)
                        {
                            case "Y":

                                cmdText = @"INSERT INTO ADM4200 (
                                                    HOSP_CODE
                                                   ,USER_ID   
                                                   ,SYS_ID
                                                   ,TR_ID
                                                   ,TR_SEQ
                                                   ,UPPR_MENU
                                                   ,CR_MEMB 
                                                   ,CR_TIME
                                            ) VALUES (
                                                    :f_hosp_code 
                                                   ,:f_user_id
                                                   ,:f_sys_id
                                                   ,:f_tr_id
                                                   ,:f_tr_seq
                                                   ,:f_uppr_menu
                                                   ,:f_cr_memb
                                                   ,SYSDATE)";
                                break;
                            case "N":
                                QuerySQL = @" SELECT NVL(COUNT(*), 0)
                                                          FROM ADM4200
                                                         WHERE HOSP_CODE = :f_hosp_code
                                                           AND USER_ID   = :f_user_id
                                                           AND SYS_ID    = :f_sys_id  
                                                           AND TR_ID     = :f_tr_id ";

                                object strcnt = Service.ExecuteScalar(QuerySQL, item.BindVarList);

                                if (strcnt.ToString() == "0")
                                {
                                    return true;
                                }
                                cmdText = @"DELETE ADM4200
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND USER_ID   = :f_user_id
                                               AND SYS_ID    = :f_sys_id
                                               AND TR_ID     = :f_tr_id ";
                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }

        }
        #endregion

        #region 시스템 ID 파인드 버튼 클릭시
        private void fbxSysID_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.fbxHospital.GetDataValue() == "")
            {
                e.Cancel = true;
                this.mMsg = NetInfo.Language == LangMode.Ko ? "사용자를 먼저 등록해 주세요" : Resources.TEXT1;
                this.mCap = NetInfo.Language == LangMode.Ko ? "" : "";
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 전체 선택 버튼 클릭시
        private void btnAllSelect_Click(object sender, System.EventArgs e)
        {
            try
            {
                //{구분(0), USER_ID(1), SYS_ID(2), SYS_NM(3), USER_YN(4), absolute Counter(5), 
                // TR_ID(6), TR_SEQ(7), PGM_ID(8), UPPR_MENU(9), PGM_NM(10), PGM_TP(11)}
                object[] nodeInfo = (object[])this.SysTreeView.SelectedNode.Tag;
                if (nodeInfo[0].ToString() == "R")
                {
                    foreach (TreeNode rootNode in this.SysTreeView.Nodes)
                        rootNode.Checked = true;
                }
                else
                {
                    foreach (TreeNode unrootNode in this.SysTreeView.SelectedNode.Parent.Nodes)
                        unrootNode.Checked = true;
                }
            }
            catch { }
        }
        #endregion

        #region 전체 해제 버튼 클릭시
        private void btnAllDissolution_Click(object sender, System.EventArgs e)
        {
            try
            {
                //{구분(0), USER_ID(1), SYS_ID(2), SYS_NM(3), USER_YN(4), absolute Counter(5), 
                // TR_ID(6), TR_SEQ(7), PGM_ID(8), UPPR_MENU(9), PGM_NM(10), PGM_TP(11)}
                object[] nodeInfo = (object[])this.SysTreeView.SelectedNode.Tag;
                if (nodeInfo[0].ToString() == "R")
                {
                    foreach (TreeNode rootNode in this.SysTreeView.Nodes)
                        rootNode.Checked = false;
                }
                else
                {
                    foreach (TreeNode unrootNode in this.SysTreeView.SelectedNode.Parent.Nodes)
                        unrootNode.Checked = false;
                }
            }
            catch { }
        }
        #endregion

        private void fbxID_FindSelected(object sender, FindEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            XDisplayBox dbxBox = this.dbxHospitalNm;

            switch (control.Name)
            {
                case "fbxHospital":
                    dbxBox = this.dbxHospitalNm;
                    break;
                case "fbxSysID":
                    dbxBox = this.dbxSysNm;
                    break;
            }
            if (TypeCheck.IsNull(e.ReturnValues) == true)
            {
                dbxBox.SetDataValue("");
            }
            else
            {
                dbxBox.SetDataValue(e.ReturnValues[1].ToString());
            }
        }

        private void fbxID_DataValidating(object sender, DataValidatingEventArgs e)
        {

            /*XFindBox control = (XFindBox)sender;
            SingleLayoutItem sli = new SingleLayoutItem();
            this.layCommon.LayoutItems.Clear();

            this.SysTreeView.Nodes.Clear();
            this.fbxSysID.Clear();
            this.dbxSysNm.SetDataValue("");

            if (e.DataValue.ToString() == "")
            {
                this.dbxHospitalNm.SetDataValue("");
            }
            else
            {
                this.layCommon.QuerySQL = @"SELECT A.USER_NM    AS USER_NM
                                              FROM ADM3200 A
                                             WHERE A.HOSP_CODE  = :f_hosp_code
                                               AND A.USER_ID    = :f_user_id 
                                             UNION
                                            SELECT A.GROUP_NM   AS USER_NM 
                                              FROM ADM3100 A
                                             WHERE A.HOSP_CODE  = :f_hosp_code
                                               AND A.USER_GROUP = :f_user_id
                                             ORDER BY 1";
                //선택시 USER_ID를 초기화
                this.mainUSERID = "";

                //USER_ID를 가져오기
                this.mainUSERID = this.fbxHospital.Text;

                sli.DataName = "dbxUserNm";
                sli.BindControl = this.dbxHospitalNm;
                this.layCommon.LayoutItems.Add(sli);
                this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.layCommon.SetBindVarValue("f_user_id", e.DataValue.ToString());
                this.layCommon.QueryLayout();
            }*/
        }
        private void fbxSysID_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (this.dbxHospitalNm.GetDataValue().ToString() == "")
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "사용자를 먼저 등록해 주세요" : Resources.TEXT1;
                this.mCap = NetInfo.Language == LangMode.Ko ? "" : "";
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (e.DataValue.ToString() == "" || fbxHospital.GetDataValue() == "")
                {
                    this.SysTreeView.Nodes.Clear();
                    this.fbxSysID.Clear();
                    this.dbxSysNm.SetDataValue("");
                    return;
                }

                ADMS2015U01SystemIdValidatingArgs vADMS2015U01SystemIdValidatingArgs = new ADMS2015U01SystemIdValidatingArgs();
                vADMS2015U01SystemIdValidatingArgs.HospCode = fbxHospital.GetDataValue();
                vADMS2015U01SystemIdValidatingArgs.SysId = e.DataValue;
                ADMS2015U01SystemIdValidatingResult result = CloudService.Instance.Submit<ADMS2015U01SystemIdValidatingResult, ADMS2015U01SystemIdValidatingArgs>(vADMS2015U01SystemIdValidatingArgs);
                if (result == null || result.ExecutionStatus != ExecutionStatus.Success || string.IsNullOrEmpty(result.SysName))
                {
                    this.SysTreeView.Nodes.Clear();
                    this.fbxSysID.Clear();
                    this.dbxSysNm.SetDataValue("");
                    return;
                }
                dbxSysNm.SetDataValue(result.SysName);

                // 노드의 변경 정보를 담을 해쉬테이블들을 초기화
                if (SysHash.Count > 0)
                    SysHash.Clear();
                if (MenuHash.Count > 0)
                    MenuHash.Clear();
                if (PgmHash.Count > 0)
                    PgmHash.Clear();

                //this.layRootList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                //this.layRootList.SetBindVarValue("f_sys_id", this.fbxSysID.GetDataValue());
                //this.layRootList.SetBindVarValue("f_user_id", this.fbxUserID.GetDataValue());
                //시스템 리스트를 가져옵니다.
                if (this.layRootList.QueryLayout(false))
                {
                    this.absCount = 0;
                    //시스템노드를 생성합니다.
                    if (RootNodeMaker())
                        this.SysTreeView.SelectedNode = this.SysTreeView.Nodes[0];
                    else
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "시스템의 메뉴등록이 선행되어야 합니다" : Resources.TEXT2;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "" : "";
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.fbxSysID.Clear();
                        this.dbxSysNm.SetDataValue("");
                    }
                }
                //else
                //{
                //    XMessageBox.Show("콜 안되었습니다.", "");
                //}
            }
        }


        private void layRootList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layRootList.SetBindVarValue("f_hosp_code", this.fbxHospital.GetDataValue());
            this.layRootList.SetBindVarValue("f_sys_id", this.fbxSysID.GetDataValue());
        }

        private void layDownList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDownList.SetBindVarValue("f_hosp_code", fbxHospital.GetDataValue());
            this.layDownList.SetBindVarValue("f_sys_id", fbxSysID.GetDataValue());      
        }

        private void fwkSysID_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkSysID.SetBindVarValue("f_hosp_code", fbxHospital.GetDataValue());
        }

        private void fbxHospital_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.SysTreeView.Nodes.Clear();
            this.dbxHospitalNm.SetDataValue("");
            this.dbxSysNm.SetDataValue("");
            if (e.DataValue.ToString() == "")
            {
                this.dbxHospitalNm.SetDataValue("");
            }
            else
            {
                ADM103UValidateFwkHospitalArgs args = new ADM103UValidateFwkHospitalArgs();
                args.HospCode = e.DataValue;
                ADM103UValidateFwkHospitalResult result =
                    CloudService.Instance.Submit<ADM103UValidateFwkHospitalResult, ADM103UValidateFwkHospitalArgs>(args);
                if (result == null || result.ExecutionStatus != ExecutionStatus.Success ||
                    String.IsNullOrEmpty(result.HospName))
                {
                    e.Cancel = true;

                    XMessageBox.Show(Resources.MSG001, Resources.CAPTION, MessageBoxIcon.Error);
                }
                else
                {
                    this.dbxHospitalNm.SetDataValue(result.HospName);
                }
            }
        }

        private void fwkHospital_QueryStarting(object sender, CancelEventArgs e)
        {

        }

        #region connect to cloud service
        /// <summary>
        /// GetFwkHopitalCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFwkHopitalCode(BindVarCollection bvc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UGetFwkHospitalArgs args = new ADM103UGetFwkHospitalArgs();
            ADM103UGetFwkHospitalResult result =
                CloudService.Instance.Submit<ADM103UGetFwkHospitalResult, ADM103UGetFwkHospitalArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.HospList)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// GetFwkSysId
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFwkSysId(BindVarCollection bc)
        {
            IList<object[]> lObj = new List<object[]>();
            string aHospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            if (string.IsNullOrEmpty(aHospCode))
            {
                return lObj;
            }

            ADMS2015U01GetSystemArgs vADMS2015U01GetSystemArgs = new ADMS2015U01GetSystemArgs();
            vADMS2015U01GetSystemArgs.HospCode = aHospCode;
            ADMS2015U01GetSystemResult result =
                CloudService.Instance.Submit<ADMS2015U01GetSystemResult, ADMS2015U01GetSystemArgs>(
                    vADMS2015U01GetSystemArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.SystemInfo)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    lObj.Add(objects);
                }
            }
            return lObj;
        }

        /// <summary>
        /// GetLayRootList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayRootList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADMS2015U01LoadUpperMenuArgs vADMS2015U01LoadUpperMenuArgs = new ADMS2015U01LoadUpperMenuArgs();
            vADMS2015U01LoadUpperMenuArgs.SysId = bc["f_sys_id"] != null ? bc["f_sys_id"].VarValue : "";
            vADMS2015U01LoadUpperMenuArgs.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            ADMS2015U01LoadUpperMenuResult result =
                CloudService.Instance.Submit<ADMS2015U01LoadUpperMenuResult, ADMS2015U01LoadUpperMenuArgs>(
                    vADMS2015U01LoadUpperMenuArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADMS2015U01MenuInfo item in result.MenuInfo)
                {
                    object[] objects =
                    {
                        fbxHospital.GetDataValue(),
                        item.SysId,                     
                        item.TrId,                      
                        item.TrSeq,                     
                        item.PgmId,                     
                        item.UpprMenu,                  
                        item.PgmNm,                     
                        item.PgmTp,                     
                        item.SelectFlg != "" ? item.SelectFlg : "0"                 
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// GetLayDownList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayDownList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADMS2015U01LoadMenuItemArgs vADMS2015U01LoadMenuItemArgs = new ADMS2015U01LoadMenuItemArgs();
            vADMS2015U01LoadMenuItemArgs.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            vADMS2015U01LoadMenuItemArgs.SysId = bc["f_sys_id"] != null ? bc["f_sys_id"].VarValue : "";
            vADMS2015U01LoadMenuItemArgs.UpprMenu = bc["f_uppr_menu"] != null ? bc["f_uppr_menu"].VarValue : "";

            ADMS2015U01LoadMenuItemResult result = CloudService.Instance.Submit<ADMS2015U01LoadMenuItemResult, ADMS2015U01LoadMenuItemArgs>(vADMS2015U01LoadMenuItemArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADMS2015U01MenuInfo item in result.MenuInfo)
                {
                    object[] objects =
                    {
                        fbxHospital.GetDataValue(),
                        item.SysId,
                        item.TrId,
                        item.TrSeq,
                        item.PgmId,
                        item.UpprMenu,
                        item.PgmNm,
                        item.PgmTp,
                        item.SelectFlg != "" ? item.SelectFlg : "0"
                    };
                    res.Add(objects);
                }
            }
            return res;
        }
        #endregion
    }
 	#region hashData class
	// 최초 선택된 정보와 변경된 정보를 키값으로 바인딩해놓은 해쉬테이블의 데이터 클래스
	public class hashData
	{
		// 처음 생성된 상태(처음 add 된 상태)이면 true
		// 생성된이후 변경된 데이터가 들어가면 false 
		protected bool IsFirst;
		// 노드가 처음 만들어질 때, 해당 노드의 체크정보
		protected string initVal;
		// 노드가 처음 만들어진 이후, 변경된 체크 정보
		protected string modVal;
		// tr_seq (메뉴 순서)
		protected string trSeq;
		// uppr_menu 
		protected string upprMenu;

		public hashData()
		{
			IsFirst = false;
			initVal = "";
			modVal = "";
		}
		
		public hashData(bool first)
		{
			IsFirst = first;
			initVal = "";
			modVal = "";
		}

		public hashData(string init, string mod )
		{
			IsFirst = false;
			initVal = init;
			modVal = mod;
		}

		public hashData(bool first, string init, string mod )
		{
			IsFirst = first;
			initVal = init;
			modVal = mod;
		}

		public hashData(bool first, string init, string mod, string trseq)
		{
			this.IsFirst = first;
			this.initVal = init;
			this.modVal = mod;
			this.trSeq = trseq;
		}

		public hashData(bool first, string init, string mod, string trseq, string upprM)
		{
			this.IsFirst = first;
			this.initVal = init;
			this.modVal = mod;
			this.trSeq = trseq;
			this.upprMenu = upprM;
		}

		// isfirst 정보를 셋팅
		public void setIsFirst(bool first)
		{
			IsFirst = first;
		}

		// initval 정보를 셋팅
		public void setInitVal ( string init )
		{
			initVal = init;
		}

		// modval 정보를 셋팅
		public void setModVal ( string mod )
		{
			modVal = mod;
		}

		// 메뉴 순서 셋팅
		public void setTrSeq ( string trseq )
		{
			this.trSeq = trseq;
		}

		// 업퍼 셋팅
		public void setUpprMenu ( string upprM )
		{
			this.upprMenu = upprM;
		}

		// isfirst 정보를 가져옴
		public bool getIsFirst()
		{
			return IsFirst;
		}

		// initval 정보를 가져옴
		public string getInitVal()
		{
			return initVal;
		}

		// modval 정보를 가져옴
		public string getModVal()
		{
			return modVal;
		}

		// 메뉴 순서 정보를 가져옴
		public string getTrSeq()
		{
			return trSeq;
		}

		// 업퍼 정보를 가져옴
		public string getUpprMenu()
		{
			return upprMenu;
		}
	}
	#endregion
}

